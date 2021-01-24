namespace MKLNET.Expression
{
    public abstract class VectorExpression
    {
        public abstract vector EvaluateVector();
        public VectorTExpression T => new VectorTranspose(this);
        public MatrixExpression ToMatrix() =>
              this is VectorScale e ? new VectorToMatrix(e.E) * e.S : new VectorToMatrix(this);
        public static implicit operator VectorExpression(vector m) => new VectorInput(m);
        public static implicit operator vector(VectorExpression m) => m.EvaluateVector();
        public static VectorExpression operator +(VectorExpression a, double s) => new VectorAddScalar(a, s);
        public static VectorExpression operator +(double s, VectorExpression b) => new VectorAddScalar(b, s);
        public static VectorExpression operator -(VectorExpression m, double s) => new VectorAddScalar(m, -s);
        public static VectorExpression operator -(double s, VectorExpression m) => new VectorScalarSub(m, s);
        public static VectorExpression operator +(VectorExpression a, VectorExpression b) => new VectorAdd(a, b);
        public static VectorExpression operator -(VectorExpression a, VectorExpression b) => new VectorSub(a, b);
        public static VectorExpression operator *(VectorExpression a, double s) =>
            a is VectorScale sa ? new VectorScale(sa.E, sa.S * s)
            : new VectorScale(a, s);
        public static VectorExpression operator *(double s, VectorExpression a) =>
            a is VectorScale sa ? new VectorScale(sa.E, sa.S * s)
            : new VectorScale(a, s);
        public static double operator *(VectorTExpression vt, VectorExpression v)
        {
            matrix m = new MatrixMultiply(vt.ToMatrix(), v.ToMatrix());
            var r = m[0, 0];
            m.Dispose();
            return r;
        }
        public static MatrixExpression operator *(VectorExpression v, VectorTExpression vt) => new MatrixMultiply(v.ToMatrix(), vt.ToMatrix());
    }

    public abstract class VectorTExpression
    {
        public abstract vectorT EvaluateVector();
        public VectorExpression T => new VectorTTranspose(this);
        public MatrixExpression ToMatrix() =>
              this is VectorTScale e ? new VectorTToMatrix(e.E) * e.S : new VectorTToMatrix(this);
        public static implicit operator VectorTExpression(vectorT m) => new VectorTInput(m);
        public static implicit operator vectorT(VectorTExpression m) => m.EvaluateVector();
        public static VectorTExpression operator +(VectorTExpression m, double s) => new VectorTAddScalar(m, s);
        public static VectorTExpression operator +(double s, VectorTExpression m) => new VectorTAddScalar(m, s);
        public static VectorTExpression operator -(VectorTExpression m, double s) => new VectorTAddScalar(m, -s);
        public static VectorTExpression operator -(double s, VectorTExpression m) => new VectorTScalarSub(s, m);
        public static VectorTExpression operator +(VectorTExpression a, VectorTExpression b) => new VectorTAdd(a, b);
        public static VectorTExpression operator -(VectorTExpression a, VectorTExpression b) => new VectorTSub(a, b);
        public static VectorTExpression operator *(VectorTExpression a, double s) => new VectorTScale(a, s);
        public static VectorTExpression operator *(double s, VectorTExpression a) => new VectorTScale(a, s);
    }

    public class VectorInput : VectorExpression, Input
    {
        readonly vector m;
        public VectorInput(vector a) => m = a;
        public override vector EvaluateVector() => m;
    }

    public class VectorTInput : VectorTExpression, Input
    {
        readonly vectorT m;
        public VectorTInput(vectorT a) => m = a;
        public override vectorT EvaluateVector() => m;
    }

    public class VectorToMatrix : MatrixExpression
    {
        readonly VectorExpression E;
        public VectorToMatrix(VectorExpression a) => E = a;
        public override matrix EvaluateMatrix()
        {
            if (E is Input) return Vector.CopyToMatrix(E);
            vector v = E;
            return new(v.Length, 1, v.Reuse());
        }
    }

    public class VectorTToMatrix : MatrixExpression
    {
        readonly VectorTExpression E;
        public VectorTToMatrix(VectorTExpression a) => E = a;
        public override matrix EvaluateMatrix()
        {
            if (E is Input) return Vector.CopyToMatrix(E);
            vectorT v = E;
            return new(1, v.Length, v.Reuse());
        }
    }

    public class NonInputVectorScaleToMatrix : MatrixExpression, IScale
    {
        readonly VectorScale E;
        public NonInputVectorScaleToMatrix(VectorScale a) => E = a;
        public double S => E.S;
        MatrixExpression ITransposeOrScale.E => E.E.ToMatrix();
        public override matrix EvaluateMatrix()
        {
            vector v = E;
            return new(v.Length, 1, v.Reuse());
        }
    }

    public class NonInputVectorTScaleToMatrix : MatrixExpression, IScale
    {
        readonly VectorTScale E;
        public NonInputVectorTScaleToMatrix(VectorTScale a) => E = a;
        public double S => E.S;
        MatrixExpression ITransposeOrScale.E => E.E.ToMatrix();
        public override matrix EvaluateMatrix()
        {
            vectorT v = E;
            return new(1, v.Length, v.Reuse());
        }
    }

    public class VectorScale : VectorExpression, IScale
    {
        public readonly VectorExpression E;
        public readonly double S;
        public VectorScale(VectorExpression a, double s)
        {
            E = a;
            S = s;
        }
        MatrixExpression ITransposeOrScale.E => E.ToMatrix();
        double IScale.S => S;

        public override vector EvaluateVector()
        {
            matrix m = E.ToMatrix() * S;
            return new(m.Rows, m.Reuse());
        }
        public static VectorScale operator *(VectorScale a, double b) => new(a.E, a.S * b);
        public static VectorScale operator *(double a, VectorScale b) => new(b.E, a * b.S);
    }

    public class VectorTScale : VectorTExpression, IScale
    {
        public readonly VectorTExpression E;
        public readonly double S;
        public VectorTScale(VectorTExpression a, double s)
        {
            E = a;
            S = s;
        }
        MatrixExpression ITransposeOrScale.E => E.ToMatrix();
        double IScale.S => S;

        public override vectorT EvaluateVector()
        {
            matrix m = E.ToMatrix() * S;
            return new(m.Rows, m.Reuse());
        }
        public static VectorTScale operator *(VectorTScale a, double b) => new(a.E, a.S * b);
        public static VectorTScale operator *(double a, VectorTScale b) => new(b.E, a * b.S);
    }

    public class VectorTranspose : VectorTExpression
    {
        readonly VectorExpression E;
        public VectorTranspose(VectorExpression a) => E = a;
        public override vectorT EvaluateVector()
        {
            matrix m = E.ToMatrix().T;
            return new(m.Cols, m.Reuse());
        }
    }

    public class VectorTTranspose : VectorExpression
    {
        readonly VectorTExpression E;
        public VectorTTranspose(VectorTExpression a) => E = a;
        public override vector EvaluateVector()
        {
            matrix m = E.ToMatrix().T;
            return new(m.Rows, m.Reuse());
        }
    }

    public class VectorAddScalar : VectorExpression
    {
        public readonly VectorExpression E;
        public readonly double S;
        public VectorAddScalar(VectorExpression a, double s)
        {
            E = a;
            S = s;
        }
        public override vector EvaluateVector()
        {
            matrix m = E.ToMatrix() + S;
            return new(m.Rows, m.Reuse());
        }
    }

    public class VectorTAddScalar : VectorTExpression
    {
        public readonly VectorTExpression E;
        public readonly double S;
        public VectorTAddScalar(VectorTExpression a, double s)
        {
            E = a;
            S = s;
        }
        public override vectorT EvaluateVector()
        {
            matrix m = E.ToMatrix() + S;
            return new(m.Rows, m.Reuse());
        }
    }

    public class VectorScalarSub : VectorExpression
    {
        public readonly VectorExpression E;
        public readonly double S;
        public VectorScalarSub(VectorExpression a, double s)
        {
            E = a;
            S = s;
        }
        public override vector EvaluateVector()
        {
            matrix m = S - E.ToMatrix();
            return new(m.Rows, m.Reuse());
        }
    }

    public class VectorTScalarSub : VectorTExpression
    {
        public readonly VectorTExpression E;
        public readonly double S;
        public VectorTScalarSub(double s, VectorTExpression a)
        {
            E = a;
            S = s;
        }
        public override vectorT EvaluateVector()
        {
            matrix m = S - E.ToMatrix();
            return new(m.Rows, m.Reuse());
        }
    }

    public class VectorAdd : VectorExpression
    {
        readonly VectorExpression A, B;
        public VectorAdd(VectorExpression a, VectorExpression b)
        {
            A = a;
            B = b;
        }
        public override vector EvaluateVector()
        {
            matrix m = A.ToMatrix() + B.ToMatrix();
            return new(m.Rows, m.Reuse());
        }
    }

    public class VectorTAdd : VectorTExpression
    {
        readonly VectorTExpression A, B;
        public VectorTAdd(VectorTExpression a, VectorTExpression b)
        {
            A = a;
            B = b;
        }
        public override vectorT EvaluateVector()
        {
            matrix m = A.ToMatrix() + B.ToMatrix();
            return new(m.Rows, m.Reuse());
        }
    }

    public class VectorSub : VectorExpression
    {
        readonly VectorExpression A, B;
        public VectorSub(VectorExpression a, VectorExpression b)
        {
            A = a;
            B = b;
        }
        public override vector EvaluateVector()
        {
            matrix m = A.ToMatrix() - B.ToMatrix();
            return new(m.Rows, m.Reuse());
        }
    }

    public class VectorTSub : VectorTExpression
    {
        readonly VectorTExpression A, B;
        public VectorTSub(VectorTExpression a, VectorTExpression b)
        {
            A = a;
            B = b;
        }
        public override vectorT EvaluateVector()
        {
            matrix m = A.ToMatrix() - B.ToMatrix();
            return new(m.Rows, m.Reuse());
        }
    }

    public class MatrixVectorMultiply : VectorExpression
    {
        readonly MatrixExpression M;
        readonly VectorExpression V;
        public MatrixVectorMultiply(MatrixExpression m, VectorExpression v)
        {
            M = m;
            V = v;
        }
        public override vector EvaluateVector()
        {
            matrix r = M * V.ToMatrix();
            return new(r.Rows, r.Reuse());
        }
    }

    public class VectorTMatrixMultiply : VectorTExpression
    {
        readonly VectorTExpression VT;
        readonly MatrixExpression M;
        public VectorTMatrixMultiply(VectorTExpression vt, MatrixExpression m)
        {
            VT = vt;
            M = m;
        }
        public override vectorT EvaluateVector()
        {
            matrix r = VT.ToMatrix() * M;
            return new(r.Cols, r.Reuse());
        }
    }

    public class MatrixToVector : VectorExpression
    {
        readonly MatrixExpression E;
        public MatrixToVector(MatrixExpression a) => E = a;
        public override vector EvaluateVector()
        {
            matrix i = E;
            return new(i.Rows, i.Reuse());
        }
    }

    public class MatrixToVectorT : VectorTExpression
    {
        readonly MatrixExpression E;
        public MatrixToVectorT(MatrixExpression a) => E = a;
        public override vectorT EvaluateVector()
        {
            matrix i = E;
            return new(i.Cols, i.Reuse());
        }
    }
}