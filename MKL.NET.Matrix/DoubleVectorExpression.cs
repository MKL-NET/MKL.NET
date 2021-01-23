namespace MKLNET.Expression
{
    public abstract class VectorExpression
    {
        public abstract vector EvaluateVector();
        public VectorTranspose T => new(this);
        public MatrixExpression ToMatrix()
            => this is Input ? new InputVectorToMatrix(this) : new NonInputVectorToMatrix(this);
        public static implicit operator VectorExpression(vector m) => new VectorInput(m);
        public static implicit operator vector(VectorExpression m) => m.EvaluateVector();
        public static VectorAddScalar operator +(VectorExpression a, double s) => new(a, s);
        public static VectorAddScalar operator +(double s, VectorExpression b) => new(b, s);
        public static VectorAddScalar operator -(VectorExpression m, double s) => new(m, -s);
        public static VectorScalarSub operator -(double s, VectorExpression m) => new(m, s);
        public static VectorAdd operator +(VectorExpression a, VectorExpression b) => new(a, b);
        public static VectorSub operator -(VectorExpression a, VectorExpression b) => new(a, b);
        public static VectorExpression operator *(VectorExpression a, double s) =>
            a is VectorScale sa ? new VectorScale(sa.E, sa.S * s)
            : new VectorScale(a, s);
        public static VectorExpression operator *(double s, VectorExpression a) =>
            a is VectorScale sa ? new VectorScale(sa.E, sa.S * s)
            : new VectorScale(a, s);
    }

    public abstract class VectorTExpression
    {
        public abstract vectorT EvaluateVector();
        public VectorTTranspose T => new(this);
        public MatrixExpression ToMatrix()
            => this is Input ? new InputVectorTToMatrix(this) : new NonInputVectorTToMatrix(this);
        public static implicit operator VectorTExpression(vectorT m) => new VectorTInput(m);
        public static implicit operator vectorT(VectorTExpression m) => m.EvaluateVector();
        public static VectorTAddScalar operator +(VectorTExpression m, double s) => new(m, s);
        public static VectorTAddScalar operator +(double s, VectorTExpression m) => new(m, s);
        public static VectorTAddScalar operator -(VectorTExpression m, double s) => new(m, -s);
        public static VectorTScalarSub operator -(double s, VectorTExpression m) => new(m, s);
        public static VectorTAdd operator +(VectorTExpression a, VectorTExpression b) => new(a, b);
        public static VectorTSub operator -(VectorTExpression a, VectorTExpression b) => new(a, b);
        public static double operator *(VectorTExpression vt, VectorExpression v)
        {
            var m = new MatrixMultiply(vt.ToMatrix(), v.ToMatrix()).EvaluateMatrix();
            var r = m[0, 0];
            m.Dispose();
            return r;
        }
        public static MatrixMultiply operator *(VectorExpression v, VectorTExpression vt) => new(v.ToMatrix(), vt.ToMatrix());
        public static VectorTMatrixMultiply operator *(VectorTExpression vt, MatrixExpression m) => new(vt, m);
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

    public class InputVectorToMatrix : MatrixExpression, Input
    {
        readonly VectorExpression E;
        public InputVectorToMatrix(VectorExpression a) => E = a;
        public override matrix EvaluateMatrix() => Vector.CopyToMatrix(E.EvaluateVector());
    }

    public class InputVectorTToMatrix : MatrixExpression, Input
    {
        readonly VectorTExpression E;
        public InputVectorTToMatrix(VectorTExpression a) => E = a;
        public override matrix EvaluateMatrix() => Vector.CopyToMatrix(E.EvaluateVector());
    }

    public class NonInputVectorToMatrix : MatrixExpression
    {
        readonly VectorExpression E;
        public NonInputVectorToMatrix(VectorExpression a) => E = a;
        public override matrix EvaluateMatrix()
        {
            {
                var v = E.EvaluateVector();
                return new(v.Length, 1, v);
            }
        }
    }

    public class NonInputVectorTToMatrix : MatrixExpression
    {
        readonly VectorTExpression E;
        public NonInputVectorTToMatrix(VectorTExpression a) => E = a;
        public override matrix EvaluateMatrix()
        {
            {
                var v = E.EvaluateVector();
                return new(v.Length, 1, v);
            }
        }
    }

    public class VectorResult : VectorExpression // This is not rerunable, need to make classes for all uses
    {
        readonly vector m;
        public VectorResult(vector a) => m = a;
        public override vector EvaluateVector() => m;
    }

    public class VectorTResult : VectorTExpression // This is not rerunable, need to make classes for all uses
    {
        readonly vectorT m;
        public VectorTResult(vectorT a) => m = a;
        public override vectorT EvaluateVector() => m;
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
        MatrixExpression IScale.E => E.ToMatrix();
        double IScale.S => S;

        public override vector EvaluateVector()
        {
            var m = new MatrixScale(E.ToMatrix(), S).EvaluateMatrix();
            return new(m.Rows, m);
        }
        public static VectorScale operator *(VectorScale a, double b) => new(a.E, a.S * b);
        public static VectorScale operator *(double a, VectorScale b) => new(b.E, a * b.S);
    }

    public class VectorTranspose : VectorTExpression
    {
        readonly VectorExpression E;
        public VectorTranspose(VectorExpression a) => E = a;
        public override vectorT EvaluateVector()
        {
            var m = new MatrixTranspose(E.ToMatrix()).EvaluateMatrix();
            return new(m.Rows, m);
        }
    }

    public class VectorTTranspose : VectorExpression
    {
        readonly vectorT E;
        public VectorTTranspose(vectorT a) => E = a;
        public override vector EvaluateVector()
        {
            var m = new MatrixTranspose(new InputVectorTToMatrix(E)).EvaluateMatrix();
            return new(m.Rows, m);
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
            var m = new MatrixAddScalar(E.ToMatrix(), S).EvaluateMatrix();
            return new(m.Rows, m);
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
            var m = new MatrixAddScalar(E.ToMatrix(), S).EvaluateMatrix();
            return new(m.Rows, m);
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
            var m = new MatrixScalarSub(E.ToMatrix(), S).EvaluateMatrix();
            return new(m.Rows, m);
        }
    }

    public class VectorTScalarSub : VectorTExpression
    {
        public readonly VectorTExpression E;
        public readonly double S;
        public VectorTScalarSub(VectorTExpression a, double s)
        {
            E = a;
            S = s;
        }
        public override vectorT EvaluateVector()
        {
            var m = new MatrixScalarSub(E.ToMatrix(), S).EvaluateMatrix();
            return new(m.Rows, m);
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
            var m = new MatrixAdd(A.ToMatrix(), B.ToMatrix()).EvaluateMatrix();
            return new(m.Rows, m);
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
            var m = new MatrixAdd(A.ToMatrix(), B.ToMatrix()).EvaluateMatrix();
            return new(m.Rows, m);
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
            var m = new MatrixSub(A.ToMatrix(), B.ToMatrix()).EvaluateMatrix();
            return new(m.Rows, m);
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
            var m = new MatrixSub(A.ToMatrix(), B.ToMatrix()).EvaluateMatrix();
            return new(m.Rows, m);
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
            var r = new MatrixMultiply(M, V.ToMatrix()).EvaluateMatrix();
            return new(r.Rows, r);
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
            var r = new MatrixMultiply(VT.ToMatrix(), M).EvaluateMatrix();
            return new(r.Cols, r);
        }
    }

    public class MatrixToVector : VectorExpression
    {
        readonly MatrixExpression E;
        public MatrixToVector(MatrixExpression a) => E = a;
        public override vector EvaluateVector()
        {
            var i = E.EvaluateMatrix();
            return new(i.Rows, i);
        }
    }

    public class MatrixToVectorT : VectorTExpression
    {
        readonly MatrixExpression E;
        public MatrixToVectorT(MatrixExpression a) => E = a;
        public override vectorT EvaluateVector()
        {
            var i = E.EvaluateMatrix();
            return new(i.Cols, i);
        }
    }
}
