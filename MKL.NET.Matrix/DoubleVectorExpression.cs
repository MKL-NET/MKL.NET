using System;

namespace MKLNET.Expression
{
    public abstract class VectorExpression
    {
        public abstract vector EvaluateVector();
        public VectorTExpression T => new VectorTranspose(this);
        MatrixExpression InputToMatrix()
        {
            var v = EvaluateVector();
            var m = new matrix(v.Length, 1, v.Array);
            GC.SuppressFinalize(m); // v owns to array, m will never be disposed
            return new MatrixInput(m);
        }
        public MatrixExpression ToMatrix() =>
              this is VectorInput ? InputToMatrix()
            : this is VectorScale s ? (s.E is VectorInput ? s.E.InputToMatrix() : new VectorToMatrix(s.E)) * s.S
            : new VectorToMatrix(this);
        public static implicit operator VectorExpression(vector a) => new VectorInput(a);
        public static implicit operator vector(VectorExpression a) => a.EvaluateVector();
        public static VectorExpression operator +(VectorExpression a, double s) => new VectorAddScalar(a, s);
        public static VectorExpression operator +(double s, VectorExpression a) => new VectorAddScalar(a, s);
        public static VectorExpression operator -(VectorExpression a, double s) => new VectorAddScalar(a, -s);
        public static VectorExpression operator -(double s, VectorExpression a) =>
            new VectorAddScalar(a is VectorScale sm ? new VectorScale(sm.E, -sm.S) : new VectorScale(a, -1.0), s);
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
            var a = vt.EvaluateVector();
            var b = v.EvaluateVector();
            if (a.Length != b.Length) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = Blas.dot(a.Length, a.Array, 0, 1, b.Array, 0, 1);
            if (vt is not VectorTInput) a.Dispose();
            if (v is not VectorInput) b.Dispose();
            return r;
        }
        public static MatrixExpression operator *(VectorExpression v, VectorTExpression vt) => new MatrixMultiply(v.ToMatrix(), vt.ToMatrix());
    }

    public abstract class VectorTExpression
    {
        public abstract vectorT EvaluateVector();
        public VectorExpression T => new VectorTTranspose(this);
        MatrixExpression InputToMatrix()
        {
            var v = EvaluateVector();
            var m = new matrix(1, v.Length, v.Array);
            GC.SuppressFinalize(m); // v owns to array, m will never be disposed
            return new MatrixInput(m);
        }
        public MatrixExpression ToMatrix() =>
              this is VectorTInput ? InputToMatrix()
            : this is VectorTScale s ? (s.E is VectorTInput ? s.E.InputToMatrix() : new VectorTToMatrix(s.E)) * s.S
            : new VectorTToMatrix(this);
        public static implicit operator VectorTExpression(vectorT a) => new VectorTInput(a);
        public static implicit operator vectorT(VectorTExpression a) => a.EvaluateVector();
        public static VectorTExpression operator +(VectorTExpression a, double s) => new VectorTAddScalar(a, s);
        public static VectorTExpression operator +(double s, VectorTExpression a) => new VectorTAddScalar(a, s);
        public static VectorTExpression operator -(VectorTExpression a, double s) => new VectorTAddScalar(a, -s);
        public static VectorTExpression operator -(double s, VectorTExpression a) =>
            new VectorTAddScalar(a is VectorTScale sm ? new VectorTScale(sm.E, -sm.S) : new VectorTScale(a, -1.0), s);
        public static VectorTExpression operator +(VectorTExpression a, VectorTExpression b) => new VectorTAdd(a, b);
        public static VectorTExpression operator -(VectorTExpression a, VectorTExpression b) => new VectorTSub(a, b);
        public static VectorTExpression operator *(VectorTExpression a, double s) => new VectorTScale(a, s);
        public static VectorTExpression operator *(double s, VectorTExpression a) => new VectorTScale(a, s);
    }

    public class VectorInput : VectorExpression
    {
        readonly vector V;
        public VectorInput(vector a) => V = a;
        public override vector EvaluateVector() => V;
    }

    public class VectorTInput : VectorTExpression
    {
        readonly vectorT V;
        public VectorTInput(vectorT a) => V = a;
        public override vectorT EvaluateVector() => V;
    }

    public class VectorToMatrix : MatrixExpression
    {
        readonly VectorExpression E;
        public VectorToMatrix(VectorExpression a) => E = a;
        public override matrix EvaluateMatrix()
        {
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
            vectorT v = E;
            return new(1, v.Length, v.Reuse());
        }
    }

    public class VectorScale : VectorExpression
    {
        public readonly VectorExpression E;
        public readonly double S;
        public VectorScale(VectorExpression a, double s)
        {
            E = a;
            S = s;
        }
        public override vector EvaluateVector()
        {
            matrix m = E.ToMatrix() * S;
            return new(m.Rows, m.Reuse());
        }
        public static VectorScale operator *(VectorScale a, double b) => new(a.E, a.S * b);
        public static VectorScale operator *(double a, VectorScale b) => new(b.E, a * b.S);
    }

    public class VectorTScale : VectorTExpression
    {
        public readonly VectorTExpression E;
        public readonly double S;
        public VectorTScale(VectorTExpression a, double s)
        {
            E = a;
            S = s;
        }
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