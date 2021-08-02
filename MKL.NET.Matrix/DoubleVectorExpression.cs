using System;

namespace MKLNET.Expression
{
    public abstract class VectorExpression
    {
        public abstract vector EvaluateVector();
        public VectorTExpression T =>
              this is VectorTTranspose t ? t.E
            : this is VectorScale s ? new VectorTScale(s.E.T, s.S)
            : new VectorTranspose(this);
        MatrixExpression InputToMatrix()
        {
            var v = EvaluateVector();
            var m = new matrix(v.Length, 1, v.Array);
            GC.SuppressFinalize(m); // v owns the array, m will never be disposed
            return new MatrixInput(m);
        }
        public MatrixExpression ToMatrix() =>
              this is VectorInput ? InputToMatrix()
            : this is VectorTTranspose vt ? vt.E.ToMatrix().T
            : this is VectorScale s ? s.E.ToMatrix() * s.S
            : new VectorToMatrix(this);
        public VectorExpression Reuse(vector v) =>
              this is MatrixVectorMultiply m ? new MatrixVectorMultiply(m.M, m.V, v.ReuseArray())
            : this;
        public VectorExpression Reuse(vectorT v) =>
              this is MatrixVectorMultiply m ? new MatrixVectorMultiply(m.M, m.V, v.ReuseArray())
            : this;
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
            a is VectorScale sa ? new VectorScale(sa.E, sa.S * s) : new VectorScale(a, s);
        public static VectorExpression operator *(double s, VectorExpression a) =>
            a is VectorScale sa ? new VectorScale(sa.E, sa.S * s) : new VectorScale(a, s);
        public static VectorExpression operator /(VectorExpression a, double s) =>
            a is VectorScale sa ? new VectorScale(sa.E, sa.S / s) : new VectorScale(a, 1 / s);
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
        public static MatrixExpression operator *(VectorExpression v, VectorTExpression vt) => new MatrixMultiply(v.ToMatrix(), vt.ToMatrix(), null);
    }

    public abstract class VectorTExpression
    {
        public abstract vectorT EvaluateVector();
        public VectorExpression T =>
              this is VectorTranspose t ? t.E
            : this is VectorTScale s ? new VectorScale(s.E.T, s.S)
            : new VectorTTranspose(this);
        MatrixExpression InputToMatrix()
        {
            var v = EvaluateVector();
            var m = new matrix(1, v.Length, v.Array);
            GC.SuppressFinalize(m); // v owns the array, m will never be disposed
            return new MatrixInput(m);
        }
        public MatrixExpression ToMatrix() =>
              this is VectorTInput ? InputToMatrix()
            : this is VectorTranspose vt ? vt.E.ToMatrix().T
            : this is VectorTScale s ? s.E.ToMatrix() * s.S
            : new VectorTToMatrix(this);
        public VectorTExpression Reuse(vectorT v) =>
              this is VectorTMatrixMultiply m ? new VectorTMatrixMultiply(m.VT, m.M, v.ReuseArray())
            : this;
        public VectorTExpression Reuse(vector v) =>
              this is VectorTMatrixMultiply m ? new VectorTMatrixMultiply(m.VT, m.M, v.ReuseArray())
            : this;
        public static implicit operator VectorTExpression(vectorT a) => new VectorTInput(a);
        public static implicit operator vectorT(VectorTExpression a) => a.EvaluateVector();
        public static VectorTExpression operator +(VectorTExpression a, double s) => new VectorTAddScalar(a, s);
        public static VectorTExpression operator +(double s, VectorTExpression a) => new VectorTAddScalar(a, s);
        public static VectorTExpression operator -(VectorTExpression a, double s) => new VectorTAddScalar(a, -s);
        public static VectorTExpression operator -(double s, VectorTExpression a) =>
            new VectorTAddScalar(a is VectorTScale sm ? new VectorTScale(sm.E, -sm.S) : new VectorTScale(a, -1.0), s);
        public static VectorTExpression operator +(VectorTExpression a, VectorTExpression b) => new VectorTAdd(a, b);
        public static VectorTExpression operator -(VectorTExpression a, VectorTExpression b) => new VectorTSub(a, b);
        public static VectorTExpression operator *(VectorTExpression a, double s) =>
            a is VectorTScale sa ? new VectorTScale(sa.E, sa.S * s) : new VectorTScale(a, s);
        public static VectorTExpression operator *(double s, VectorTExpression a) =>
            a is VectorTScale sa ? new VectorTScale(sa.E, sa.S * s) : new VectorTScale(a, s);
        public static VectorTExpression operator /(VectorTExpression a, double s) =>
            a is VectorTScale sa ? new VectorTScale(sa.E, sa.S / s) : new VectorTScale(a, 1 / s);
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

    public class VectorReuse : VectorExpression
    {
        readonly vector V;
        public VectorReuse(vector a) => V = a;
        public override vector EvaluateVector() => V;
    }

    public class VectorTReuse : VectorTExpression
    {
        readonly vectorT V;
        public VectorTReuse(vectorT a) => V = a;
        public override vectorT EvaluateVector() => V;
    }

    public class VectorToMatrix : MatrixExpression
    {
        readonly VectorExpression E;
        public VectorToMatrix(VectorExpression a) => E = a;
        public override matrix EvaluateMatrix()
        {
            vector v = E;
            return new(v.Length, 1, v.ReuseArray());
        }
    }

    public class VectorTToMatrix : MatrixExpression
    {
        readonly VectorTExpression E;
        public VectorTToMatrix(VectorTExpression a) => E = a;
        public override matrix EvaluateMatrix()
        {
            vectorT v = E;
            return new(1, v.Length, v.ReuseArray());
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
            return new(m.Rows, m.ReuseArray());
        }
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
            return new(m.Cols, m.ReuseArray());
        }
    }

    public class VectorTranspose : VectorTExpression
    {
        public readonly VectorExpression E;
        public VectorTranspose(VectorExpression a) => E = a;
        public override vectorT EvaluateVector()
        {
            matrix m = E.ToMatrix().T;
            return new(m.Cols, m.ReuseArray());
        }
    }

    public class VectorTTranspose : VectorExpression
    {
        public readonly VectorTExpression E;
        public VectorTTranspose(VectorTExpression a) => E = a;
        public override vector EvaluateVector()
        {
            matrix m = E.ToMatrix().T;
            return new(m.Rows, m.ReuseArray());
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
            return new(m.Rows, m.ReuseArray());
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
            return new(m.Cols, m.ReuseArray());
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
            return new(m.Rows, m.ReuseArray());
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
            return new(m.Cols, m.ReuseArray());
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
            return new(m.Rows, m.ReuseArray());
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
            return new(m.Cols, m.ReuseArray());
        }
    }

    public class MatrixVectorMultiply : VectorExpression
    {
        public readonly MatrixExpression M;
        public readonly VectorExpression V;
        public readonly double[]? R;
        public MatrixVectorMultiply(MatrixExpression m, VectorExpression v, double[]? reuse)
        {
            M = m;
            V = v;
            R = reuse;
        }
        public override vector EvaluateVector()
        {
            matrix r = new MatrixMultiply(M, V.ToMatrix(), R);
            return new(r.Rows, r.ReuseArray());
        }
    }

    public class VectorTMatrixMultiply : VectorTExpression
    {
        public readonly VectorTExpression VT;
        public readonly MatrixExpression M;
        public readonly double[]? R;
        public VectorTMatrixMultiply(VectorTExpression vt, MatrixExpression m, double[]? reuse)
        {
            VT = vt;
            M = m;
            R = reuse;
        }
        public override vectorT EvaluateVector()
        {
            matrix r = new MatrixMultiply(VT.ToMatrix(), M, R);
            return new(r.Cols, r.ReuseArray());
        }
    }

    public class MatrixToVector : VectorExpression
    {
        readonly MatrixExpression E;
        public MatrixToVector(MatrixExpression a) => E = a;
        public override vector EvaluateVector()
        {
            matrix i = E;
            return new(i.Rows, i.ReuseArray());
        }
    }

    public class MatrixToVectorT : VectorTExpression
    {
        readonly MatrixExpression E;
        public MatrixToVectorT(MatrixExpression a) => E = a;
        public override vectorT EvaluateVector()
        {
            matrix i = E;
            return new(i.Cols, i.ReuseArray());
        }
    }
}