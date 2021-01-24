namespace MKLNET.Expression
{
    public abstract class MatrixExpression
    {
        public abstract matrix EvaluateMatrix();
        public static implicit operator MatrixExpression(matrix m) => new MatrixInput(m);
        public static implicit operator matrix(MatrixExpression m) => m.EvaluateMatrix();
        public static MatrixAddScalar operator +(MatrixExpression a, double s) => new(a, s);
        public static MatrixAddScalar operator +(double s, MatrixExpression b) => new(b, s);
        public static MatrixAddScalar operator -(MatrixExpression a, double b) => new(a, -b);
        public static MatrixScalarSub operator -(double a, MatrixExpression b) => new(b, a);
        public static MatrixExpression operator +(MatrixExpression a, MatrixExpression b)
        {
            if (a is MatrixTranspose ta)
            {
                return b is MatrixTranspose tb ? new MatrixAddTranspose(ta.E, TransChar.Yes, ta.S, tb.E, TransChar.Yes, tb.S)
                     : b is IScale sb ? new MatrixAddTranspose(ta.E, TransChar.Yes, ta.S, sb.E, TransChar.No, sb.S)
                     : new MatrixAddTranspose(ta.E, TransChar.Yes, ta.S, b, TransChar.No, 1.0);
            }
            else if (b is MatrixTranspose tb)
            {
                return a is IScale sa ? new MatrixAddTranspose(sa.E, TransChar.No, sa.S, tb.E, TransChar.Yes, tb.S)
                     : new MatrixAddTranspose(a, TransChar.No, 1.0, tb.E, TransChar.Yes, tb.S);
            }
            else if (a is IScale sa)
            {
                return b is IScale sb ? new MatrixAddScale(sa.E, sa.S, sb.E, sb.S)
                     : new MatrixAddScale(sa.E, sa.S, b, 1.0);
            }
            else if (b is IScale sb)
            {
                return new MatrixAddScale(a, 1.0, sb.E, sb.S);
            }
            return new MatrixAddSimple(a, b);
        }
        public static MatrixExpression operator -(MatrixExpression a, MatrixExpression b)
        {
            if (a is MatrixTranspose ta)
            {
                return b is MatrixTranspose tb ? new MatrixAddTranspose(ta.E, TransChar.Yes, ta.S, tb.E, TransChar.Yes, -tb.S)
                     : b is IScale sb ? new MatrixAddTranspose(ta.E, TransChar.Yes, ta.S, sb.E, TransChar.No, -sb.S)
                     : new MatrixAddTranspose(ta.E, TransChar.Yes, ta.S, b, TransChar.No, -1.0);
            }
            else if (b is MatrixTranspose tb)
            {
                return a is IScale sa ? new MatrixAddTranspose(sa.E, TransChar.No, sa.S, tb.E, TransChar.Yes, -tb.S)
                     : new MatrixAddTranspose(a, TransChar.No, 1.0, tb.E, TransChar.Yes, -tb.S);
            }
            else if (a is IScale sa)
            {
                return b is IScale sb ? new MatrixAddScale(sa.E, sa.S, sb.E, -sb.S)
                     : new MatrixAddScale(sa.E, sa.S, b, -1.0);
            }
            else if (b is IScale sb)
            {
                return new MatrixAddScale(a, 1.0, sb.E, -sb.S);
            }
            return new MatrixSubSimple(a, b);
        }
        public static MatrixExpression operator *(MatrixExpression a, double s) =>
              a is MatrixTranspose ta ? new MatrixTranspose(ta.E, ta.S * s)
            : a is IScale sa ? new MatrixScale(sa.E, sa.S * s)
            : new MatrixScale(a, s);
        public static MatrixExpression operator *(double s, MatrixExpression a) =>
              a is MatrixTranspose ta ? new MatrixTranspose(ta.E, ta.S * s)
            : a is IScale sa ? new MatrixScale(sa.E, sa.S * s)
            : new MatrixScale(a, s);
        public static MatrixMultiply operator *(MatrixExpression a, MatrixExpression b) => new(a, b);
        public MatrixExpression T =>
              this is MatrixTranspose t ? (t.S == 1.0 ? t.E : new MatrixScale(t.E, t.S))
            : this is IScale s ? new MatrixTranspose(s.E, s.S)
            : new MatrixTranspose(this, 1.0);
        public static MatrixVectorMultiply operator *(MatrixExpression m, VectorExpression v) => new(m, v);
    }

    public interface Input { }

    public class MatrixInput : MatrixExpression, Input
    {
        readonly protected matrix m;
        public MatrixInput(matrix a) => m = a;
        public override matrix EvaluateMatrix() => m;
    }

    public interface ITransposeOrScale
    {
        MatrixExpression E { get; }
    }

    public interface IScale : ITransposeOrScale
    {
        double S { get; }
    }

    public class MatrixScale : MatrixExpression, IScale
    {
        public readonly MatrixExpression E;
        public readonly double S;
        public MatrixScale(MatrixExpression a, double s)
        {
            E = a;
            S = s;
        }
        public override matrix EvaluateMatrix()
        {
            var i = E.EvaluateMatrix();
            var o = E is Input ? new matrix(i.Rows, i.Cols) : new matrix(i.Rows, i.Cols, i.Reuse());
            Blas.omatcopy(LayoutChar.ColMajor, TransChar.No, i.Rows, i.Cols, S, i.Array, i.Rows, o.Array, i.Rows);
            return o;
        }
        public new MatrixTranspose T => new(E, S);
        double IScale.S => S;
        MatrixExpression ITransposeOrScale.E => E;

        public static MatrixScale operator *(MatrixScale a, double b) => new(a.E, a.S * b);
        public static MatrixScale operator *(double a, MatrixScale b) => new(b.E, a * b.S);
    }

    public class MatrixTranspose : MatrixExpression
    {
        public readonly MatrixExpression E;
        public readonly double S;
        public MatrixTranspose(MatrixExpression a, double s)
        {
            E = a;
            S = s;
        }
        public override matrix EvaluateMatrix()
        {
            var i = E.EvaluateMatrix();
            var o = E is Input ? new matrix(i.Cols, i.Rows) : new matrix(i.Cols, i.Rows, i.Reuse());
            Blas.omatcopy(LayoutChar.ColMajor, TransChar.Yes, i.Rows, i.Cols, S, i.Array, i.Rows, o.Array, i.Cols); // Check rows, cols
            return o;
        }
    }


    public abstract class MatrixUnary : MatrixExpression
    {
        readonly MatrixExpression E;
        public MatrixUnary(MatrixExpression a) => E = a;
        protected abstract void Evaluate(matrix a, matrix o);
        public override matrix EvaluateMatrix()
        {
            var i = E.EvaluateMatrix();
            var o = E is Input ? new matrix(i.Rows, i.Cols) : i;
            Evaluate(i, o);
            return o;
        }
    }

    public abstract class MatrixBinary : MatrixExpression
    {
        readonly MatrixExpression Ea, Eb;
        public MatrixBinary(MatrixExpression a, MatrixExpression b)
        {
            Ea = a;
            Eb = b;
        }
        protected abstract void Evaluate(matrix a, matrix b, matrix o);
        public override matrix EvaluateMatrix()
        {
            var a = Ea.EvaluateMatrix();
            var b = Eb.EvaluateMatrix();
            if (a.Rows != b.Rows || a.Cols != b.Cols) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            if (Ea is not Input)
            {
                var o = new matrix(a.Rows, a.Cols, a.Reuse());
                Evaluate(a, b, o);
                if (Eb is not Input) b.Dispose();
                return o;
            }
            else if (Eb is not Input)
            {
                var o = new matrix(b.Rows, b.Cols, b.Reuse());
                Evaluate(a, b, o);
                if (Ea is not Input) a.Dispose();
                return o;
            }
            else
            {
                var o = new matrix(a.Rows, a.Cols);
                Evaluate(a, b, o);
                return o;
            }
        }
    }

    public class MatrixAddSimple : MatrixExpression
    {
        readonly MatrixExpression Ea, Eb;
        public MatrixAddSimple(MatrixExpression a, MatrixExpression b)
        {
            Ea = a;
            Eb = b;
        }
        public override matrix EvaluateMatrix()
        {
            var a = Ea.EvaluateMatrix();
            var b = Eb.EvaluateMatrix();
            if (a.Rows != b.Rows || a.Cols != b.Cols) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = a is not Input ? a
                  : b is not Input ? b
                  : new matrix(a.Rows, a.Cols);
            Vml.Add(a.Length, a.Array, 0, 1, b.Array, 0, 1, r.Array, 0, 1);
            return r;
        }
    }

    public class MatrixAddScale : MatrixExpression
    {
        readonly MatrixExpression Ea, Eb;
        readonly double Sa, Sb;
        public MatrixAddScale(MatrixExpression a, double sa, MatrixExpression b, double sb)
        {
            Ea = a;
            Eb = b;
            Sa = sa;
            Sb = sb;
        }
        public override matrix EvaluateMatrix()
        {
            var a = Ea.EvaluateMatrix();
            var b = Eb.EvaluateMatrix();
            if (a.Rows != b.Rows || a.Cols != b.Cols) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = a is not Input ? a
                  : b is not Input ? b
                  : new matrix(a.Rows, a.Cols);
            Vml.LinearFrac(a.Length, a.Array, 0, 1, b.Array, 0, 1, Sa, 0.0, Sb, 0.0, r.Array, 0, 1);
            if (a is not Input && b is not Input) b.Dispose();
            return r;
        }
    }

    public class MatrixAddTranspose : MatrixExpression
    {
        readonly MatrixExpression Ea, Eb;
        readonly double Sa, Sb;
        readonly TransChar Transa, Transb;
        public MatrixAddTranspose(MatrixExpression a, TransChar transa, double sa, MatrixExpression b, TransChar transb, double sb)
        {
            Ea = a;
            Eb = b;
            Sa = sa;
            Sb = sb;
            Transa = transa;
            Transb = transb;
        }
        public override matrix EvaluateMatrix()
        {
            var a = Ea.EvaluateMatrix();
            var b = Eb.EvaluateMatrix();
            if ((Transa == Transb && (a.Rows != b.Rows || a.Cols != b.Cols))
               ||(a.Rows != b.Cols || a.Cols != b.Rows)) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = a is not Input ? (Transa == TransChar.Yes ? new matrix(a.Cols, a.Rows, a.Reuse()) : a)
                  : b is not Input ? (Transb == TransChar.Yes ? new matrix(b.Cols, b.Rows, b.Reuse()) : b)
                  : new matrix(a.Rows, a.Cols);
            Blas.omatadd(LayoutChar.ColMajor, Transa, Transb, r.Rows, r.Cols, Sa, a.Array, a.Rows, Sb, b.Array, b.Rows, r.Array, r.Rows);
            if (a is not Input && b is not Input) b.Dispose();
            return r;
        }
    }

    public class MatrixSubSimple : MatrixExpression
    {
        readonly MatrixExpression Ea, Eb;
        public MatrixSubSimple(MatrixExpression a, MatrixExpression b)
        {
            Ea = a;
            Eb = b;
        }
        public override matrix EvaluateMatrix()
        {
            var a = Ea.EvaluateMatrix();
            var b = Eb.EvaluateMatrix();
            if (a.Rows != b.Rows || a.Cols != b.Cols) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = a is not Input ? a
                  : b is not Input ? b
                  : new matrix(a.Rows, a.Cols);
            Vml.Sub(a.Length, a.Array, 0, 1, b.Array, 0, 1, r.Array, 0, 1);
            return r;
        }
    }

    public class MatrixAddScalar : MatrixExpression
    {
        public readonly MatrixExpression E;
        public readonly double S;
        public MatrixAddScalar(MatrixExpression a, double s)
        {
            E = a;
            S = s;
        }
        public override matrix EvaluateMatrix()
        {
            if (E is IScale Es)
            {
                var e = Es.E;
                var a = e.EvaluateMatrix();
                var o = e is Input ? new matrix(a.Rows, a.Cols) : a;
                Vml.LinearFrac(a.Length, a.Array, 0, 1, a.Array, 0, 1, Es.S, S, 0.0, 0.0, o.Array, 0, 1);
                return o;
            }
            else
            {
                var a = E.EvaluateMatrix();
                var o = E is Input ? new matrix(a.Rows, a.Cols) : a;
                Vml.LinearFrac(a.Length, a.Array, 0, 1, a.Array, 0, 1, 1.0, S, 0.0, 0.0, o.Array, 0, 1);
                return o;
            }
        }
    }

    public class MatrixScalarSub : MatrixExpression
    {
        public readonly MatrixExpression E;
        public readonly double S;
        public MatrixScalarSub(MatrixExpression a, double s)
        {
            E = a;
            S = s;
        }
        public override matrix EvaluateMatrix()
        {
            if (E is IScale Es)
            {
                var e = Es.E;
                var a = e.EvaluateMatrix();
                var o = e is Input ? new matrix(a.Rows, a.Cols) : a;
                Vml.LinearFrac(a.Length, a.Array, 0, 1, a.Array, 0, 1, -Es.S, S, 0.0, 0.0, o.Array, 0, 1);
                return o;
            }
            else
            {
                var a = E.EvaluateMatrix();
                var o = E is Input ? new matrix(a.Rows, a.Cols) : a;
                Vml.LinearFrac(a.Length, a.Array, 0, 1, a.Array, 0, 1, -1.0, S, 0.0, 0.0, o.Array, 0, 1);
                return o;
            }
        }
    }

    public class MatrixMultiply : MatrixExpression
    {
        readonly MatrixExpression ae, be;
        public MatrixMultiply(MatrixExpression a, MatrixExpression b)
        {
            ae = a;
            be = b;
        }
        public override matrix EvaluateMatrix()
        {
            var a = ae.EvaluateMatrix();
            var b = be.EvaluateMatrix();
            if (a.Cols != b.Rows) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            if (ae is not Input && a.Array.Length >= a.Rows * b.Cols)
            {
                Blas.gemm(Layout.ColMajor, Trans.No, Trans.No, a.Rows, b.Cols, a.Cols, 1.0, a.Array, a.Rows, b.Array, b.Rows, 0.0, a.Array, a.Rows);
                if (be is not Input) b.Dispose();
                return a;
            }
            else if (be is not Input && b.Array.Length >= a.Rows * b.Cols)
            {
                Blas.gemm(Layout.ColMajor, Trans.No, Trans.No, a.Rows, b.Cols, a.Cols, 1.0, a.Array, a.Rows, b.Array, b.Rows, 0.0, b.Array, a.Rows);
                if (ae is not Input) a.Dispose();
                return b;
            }
            else
            {
                var r = new matrix(a.Rows, b.Cols);
                Blas.gemm(Layout.ColMajor, Trans.No, Trans.No, a.Rows, b.Cols, a.Cols, 1.0, a.Array, a.Rows, b.Array, b.Rows, 0.0, r.Array, a.Rows);
                if (ae is not Input) a.Dispose();
                if (be is not Input) b.Dispose();
                return r;
            }
        }
    }

    public class MatrixAbs : MatrixUnary
    {
        public MatrixAbs(MatrixExpression a) : base(a) { }
        protected override void Evaluate(matrix a, matrix o)
            => Vml.Abs(a.Length, a.Array, 0, 1, o.Array, 0, 1);
    }
    public class MatrixSqr : MatrixUnary
    {
        public MatrixSqr(MatrixExpression a) : base(a) { }
        protected override void Evaluate(matrix a, matrix o)
            => Vml.Sqr(a.Length, a.Array, 0, 1, o.Array, 0, 1);
    }
    public class MatrixInv : MatrixUnary
    {
        public MatrixInv(MatrixExpression a) : base(a) { }
        protected override void Evaluate(matrix a, matrix o)
            => Vml.Inv(a.Length, a.Array, 0, 1, o.Array, 0, 1);
    }
    public class MatrixSqrt : MatrixUnary
    {
        public MatrixSqrt(MatrixExpression a) : base(a) { }
        protected override void Evaluate(matrix a, matrix o)
            => Vml.Sqrt(a.Length, a.Array, 0, 1, o.Array, 0, 1);
    }
    public class MatrixInvSqrt : MatrixUnary
    {
        public MatrixInvSqrt(MatrixExpression a) : base(a) { }
        protected override void Evaluate(matrix a, matrix o)
            => Vml.InvSqrt(a.Length, a.Array, 0, 1, o.Array, 0, 1);
    }
    public class MatrixCbrt : MatrixUnary
    {
        public MatrixCbrt(MatrixExpression a) : base(a) { }
        protected override void Evaluate(matrix a, matrix o)
            => Vml.Cbrt(a.Length, a.Array, 0, 1, o.Array, 0, 1);
    }
    public class MatrixInvCbrt : MatrixUnary
    {
        public MatrixInvCbrt(MatrixExpression a) : base(a) { }
        protected override void Evaluate(matrix a, matrix o)
            => Vml.InvCbrt(a.Length, a.Array, 0, 1, o.Array, 0, 1);
    }
    public class MatrixPow2o3 : MatrixUnary
    {
        public MatrixPow2o3(MatrixExpression a) : base(a) { }
        protected override void Evaluate(matrix a, matrix o)
            => Vml.Pow2o3(a.Length, a.Array, 0, 1, o.Array, 0, 1);
    }
    public class MatrixPow3o2 : MatrixUnary
    {
        public MatrixPow3o2(MatrixExpression a) : base(a) { }
        protected override void Evaluate(matrix a, matrix o)
            => Vml.Pow3o2(a.Length, a.Array, 0, 1, o.Array, 0, 1);
    }
    public class MatrixExp : MatrixUnary
    {
        public MatrixExp(MatrixExpression a) : base(a) { }
        protected override void Evaluate(matrix a, matrix o)
            => Vml.Exp(a.Length, a.Array, 0, 1, o.Array, 0, 1);
    }
    public class MatrixExp2 : MatrixUnary
    {
        public MatrixExp2(MatrixExpression a) : base(a) { }
        protected override void Evaluate(matrix a, matrix o)
            => Vml.Exp2(a.Length, a.Array, 0, 1, o.Array, 0, 1);
    }
    public class MatrixExp10 : MatrixUnary
    {
        public MatrixExp10(MatrixExpression a) : base(a) { }
        protected override void Evaluate(matrix a, matrix o)
            => Vml.Exp10(a.Length, a.Array, 0, 1, o.Array, 0, 1);
    }
    public class MatrixExpm1 : MatrixUnary
    {
        public MatrixExpm1(MatrixExpression a) : base(a) { }
        protected override void Evaluate(matrix a, matrix o)
            => Vml.Expm1(a.Length, a.Array, 0, 1, o.Array, 0, 1);
    }
    public class MatrixLn : MatrixUnary
    {
        public MatrixLn(MatrixExpression a) : base(a) { }
        protected override void Evaluate(matrix a, matrix o)
            => Vml.Ln(a.Length, a.Array, 0, 1, o.Array, 0, 1);
    }
    public class MatrixLog2 : MatrixUnary
    {
        public MatrixLog2(MatrixExpression a) : base(a) { }
        protected override void Evaluate(matrix a, matrix o)
            => Vml.Log2(a.Length, a.Array, 0, 1, o.Array, 0, 1);
    }
    public class MatrixLog10 : MatrixUnary
    {
        public MatrixLog10(MatrixExpression a) : base(a) { }
        protected override void Evaluate(matrix a, matrix o)
            => Vml.Log10(a.Length, a.Array, 0, 1, o.Array, 0, 1);
    }
    public class MatrixLog1p : MatrixUnary
    {
        public MatrixLog1p(MatrixExpression a) : base(a) { }
        protected override void Evaluate(matrix a, matrix o)
            => Vml.Log1p(a.Length, a.Array, 0, 1, o.Array, 0, 1);
    }
    public class MatrixLogb : MatrixUnary
    {
        public MatrixLogb(MatrixExpression a) : base(a) { }
        protected override void Evaluate(matrix a, matrix o)
            => Vml.Logb(a.Length, a.Array, 0, 1, o.Array, 0, 1);
    }
    public class MatrixCos : MatrixUnary
    {
        public MatrixCos(MatrixExpression a) : base(a) { }
        protected override void Evaluate(matrix a, matrix o)
            => Vml.Cos(a.Length, a.Array, 0, 1, o.Array, 0, 1);
    }
    public class MatrixSin : MatrixUnary
    {
        public MatrixSin(MatrixExpression a) : base(a) { }
        protected override void Evaluate(matrix a, matrix o)
            => Vml.Sin(a.Length, a.Array, 0, 1, o.Array, 0, 1);
    }
    public class MatrixTan : MatrixUnary
    {
        public MatrixTan(MatrixExpression a) : base(a) { }
        protected override void Evaluate(matrix a, matrix o)
            => Vml.Tan(a.Length, a.Array, 0, 1, o.Array, 0, 1);
    }
    public class MatrixCospi : MatrixUnary
    {
        public MatrixCospi(MatrixExpression a) : base(a) { }
        protected override void Evaluate(matrix a, matrix o)
            => Vml.Cospi(a.Length, a.Array, 0, 1, o.Array, 0, 1);
    }
    public class MatrixSinpi : MatrixUnary
    {
        public MatrixSinpi(MatrixExpression a) : base(a) { }
        protected override void Evaluate(matrix a, matrix o)
            => Vml.Sinpi(a.Length, a.Array, 0, 1, o.Array, 0, 1);
    }
    public class MatrixTanpi : MatrixUnary
    {
        public MatrixTanpi(MatrixExpression a) : base(a) { }
        protected override void Evaluate(matrix a, matrix o)
            => Vml.Tanpi(a.Length, a.Array, 0, 1, o.Array, 0, 1);
    }
    public class MatrixCosd : MatrixUnary
    {
        public MatrixCosd(MatrixExpression a) : base(a) { }
        protected override void Evaluate(matrix a, matrix o)
            => Vml.Cosd(a.Length, a.Array, 0, 1, o.Array, 0, 1);
    }
    public class MatrixSind : MatrixUnary
    {
        public MatrixSind(MatrixExpression a) : base(a) { }
        protected override void Evaluate(matrix a, matrix o)
            => Vml.Sind(a.Length, a.Array, 0, 1, o.Array, 0, 1);
    }
    public class MatrixTand : MatrixUnary
    {
        public MatrixTand(MatrixExpression a) : base(a) { }
        protected override void Evaluate(matrix a, matrix o)
            => Vml.Tand(a.Length, a.Array, 0, 1, o.Array, 0, 1);
    }
    public class MatrixAcos : MatrixUnary
    {
        public MatrixAcos(MatrixExpression a) : base(a) { }
        protected override void Evaluate(matrix a, matrix o)
            => Vml.Acos(a.Length, a.Array, 0, 1, o.Array, 0, 1);
    }
    public class MatrixAsin : MatrixUnary
    {
        public MatrixAsin(MatrixExpression a) : base(a) { }
        protected override void Evaluate(matrix a, matrix o)
            => Vml.Asin(a.Length, a.Array, 0, 1, o.Array, 0, 1);
    }
    public class MatrixAtan : MatrixUnary
    {
        public MatrixAtan(MatrixExpression a) : base(a) { }
        protected override void Evaluate(matrix a, matrix o)
            => Vml.Atan(a.Length, a.Array, 0, 1, o.Array, 0, 1);
    }
    public class MatrixAcospi : MatrixUnary
    {
        public MatrixAcospi(MatrixExpression a) : base(a) { }
        protected override void Evaluate(matrix a, matrix o)
            => Vml.Acospi(a.Length, a.Array, 0, 1, o.Array, 0, 1);
    }
    public class MatrixAsinpi : MatrixUnary
    {
        public MatrixAsinpi(MatrixExpression a) : base(a) { }
        protected override void Evaluate(matrix a, matrix o)
            => Vml.Asinpi(a.Length, a.Array, 0, 1, o.Array, 0, 1);
    }
    public class MatrixAtanpi : MatrixUnary
    {
        public MatrixAtanpi(MatrixExpression a) : base(a) { }
        protected override void Evaluate(matrix a, matrix o)
            => Vml.Atanpi(a.Length, a.Array, 0, 1, o.Array, 0, 1);
    }
    public class MatrixCosh : MatrixUnary
    {
        public MatrixCosh(MatrixExpression a) : base(a) { }
        protected override void Evaluate(matrix a, matrix o)
            => Vml.Cosh(a.Length, a.Array, 0, 1, o.Array, 0, 1);
    }
    public class MatrixSinh : MatrixUnary
    {
        public MatrixSinh(MatrixExpression a) : base(a) { }
        protected override void Evaluate(matrix a, matrix o)
            => Vml.Sinh(a.Length, a.Array, 0, 1, o.Array, 0, 1);
    }
    public class MatrixTanh : MatrixUnary
    {
        public MatrixTanh(MatrixExpression a) : base(a) { }
        protected override void Evaluate(matrix a, matrix o)
            => Vml.Tanh(a.Length, a.Array, 0, 1, o.Array, 0, 1);
    }
    public class MatrixAcosh : MatrixUnary
    {
        public MatrixAcosh(MatrixExpression a) : base(a) { }
        protected override void Evaluate(matrix a, matrix o)
            => Vml.Acosh(a.Length, a.Array, 0, 1, o.Array, 0, 1);
    }
    public class MatrixAsinh : MatrixUnary
    {
        public MatrixAsinh(MatrixExpression a) : base(a) { }
        protected override void Evaluate(matrix a, matrix o)
            => Vml.Asinh(a.Length, a.Array, 0, 1, o.Array, 0, 1);
    }
    public class MatrixAtanh : MatrixUnary
    {
        public MatrixAtanh(MatrixExpression a) : base(a) { }
        protected override void Evaluate(matrix a, matrix o)
            => Vml.Atanh(a.Length, a.Array, 0, 1, o.Array, 0, 1);
    }
    public class MatrixErf : MatrixUnary
    {
        public MatrixErf(MatrixExpression a) : base(a) { }
        protected override void Evaluate(matrix a, matrix o)
            => Vml.Erf(a.Length, a.Array, 0, 1, o.Array, 0, 1);
    }
    public class MatrixErfc : MatrixUnary
    {
        public MatrixErfc(MatrixExpression a) : base(a) { }
        protected override void Evaluate(matrix a, matrix o)
            => Vml.Erfc(a.Length, a.Array, 0, 1, o.Array, 0, 1);
    }
    public class MatrixErfInv : MatrixUnary
    {
        public MatrixErfInv(MatrixExpression a) : base(a) { }
        protected override void Evaluate(matrix a, matrix o)
            => Vml.ErfInv(a.Length, a.Array, 0, 1, o.Array, 0, 1);
    }
    public class MatrixErfcInv : MatrixUnary
    {
        public MatrixErfcInv(MatrixExpression a) : base(a) { }
        protected override void Evaluate(matrix a, matrix o)
            => Vml.ErfcInv(a.Length, a.Array, 0, 1, o.Array, 0, 1);
    }
    public class MatrixCdfNorm : MatrixUnary
    {
        public MatrixCdfNorm(MatrixExpression a) : base(a) { }
        protected override void Evaluate(matrix a, matrix o)
            => Vml.CdfNorm(a.Length, a.Array, 0, 1, o.Array, 0, 1);
    }
    public class MatrixCdfNormInv : MatrixUnary
    {
        public MatrixCdfNormInv(MatrixExpression a) : base(a) { }
        protected override void Evaluate(matrix a, matrix o)
            => Vml.CdfNormInv(a.Length, a.Array, 0, 1, o.Array, 0, 1);
    }
    public class MatrixLGamma : MatrixUnary
    {
        public MatrixLGamma(MatrixExpression a) : base(a) { }
        protected override void Evaluate(matrix a, matrix o)
            => Vml.LGamma(a.Length, a.Array, 0, 1, o.Array, 0, 1);
    }
    public class MatrixTGamma : MatrixUnary
    {
        public MatrixTGamma(MatrixExpression a) : base(a) { }
        protected override void Evaluate(matrix a, matrix o)
            => Vml.TGamma(a.Length, a.Array, 0, 1, o.Array, 0, 1);
    }
    public class MatrixExpInt1 : MatrixUnary
    {
        public MatrixExpInt1(MatrixExpression a) : base(a) { }
        protected override void Evaluate(matrix a, matrix o)
            => Vml.ExpInt1(a.Length, a.Array, 0, 1, o.Array, 0, 1);
    }
    public class MatrixFloor : MatrixUnary
    {
        public MatrixFloor(MatrixExpression a) : base(a) { }
        protected override void Evaluate(matrix a, matrix o)
            => Vml.Floor(a.Length, a.Array, 0, 1, o.Array, 0, 1);
    }
    public class MatrixCeil : MatrixUnary
    {
        public MatrixCeil(MatrixExpression a) : base(a) { }
        protected override void Evaluate(matrix a, matrix o)
            => Vml.Ceil(a.Length, a.Array, 0, 1, o.Array, 0, 1);
    }
    public class MatrixTrunc : MatrixUnary
    {
        public MatrixTrunc(MatrixExpression a) : base(a) { }
        protected override void Evaluate(matrix a, matrix o)
            => Vml.Trunc(a.Length, a.Array, 0, 1, o.Array, 0, 1);
    }
    public class MatrixRound : MatrixUnary
    {
        public MatrixRound(MatrixExpression a) : base(a) { }
        protected override void Evaluate(matrix a, matrix o)
            => Vml.Round(a.Length, a.Array, 0, 1, o.Array, 0, 1);
    }
    public class MatrixFrac : MatrixUnary
    {
        public MatrixFrac(MatrixExpression a) : base(a) { }
        protected override void Evaluate(matrix a, matrix o)
            => Vml.Frac(a.Length, a.Array, 0, 1, o.Array, 0, 1);
    }
    public class MatrixNearbyInt : MatrixUnary
    {
        public MatrixNearbyInt(MatrixExpression a) : base(a) { }
        protected override void Evaluate(matrix a, matrix o)
            => Vml.NearbyInt(a.Length, a.Array, 0, 1, o.Array, 0, 1);
    }
    public class MatrixRint : MatrixUnary
    {
        public MatrixRint(MatrixExpression a) : base(a) { }
        protected override void Evaluate(matrix a, matrix o)
            => Vml.Rint(a.Length, a.Array, 0, 1, o.Array, 0, 1);
    }
    public class MatrixPowx : MatrixUnary
    {
        readonly double b;
        public MatrixPowx(MatrixExpression a, double b) : base(a) => this.b = b;
        protected override void Evaluate(matrix a, matrix o)
            => Vml.Powx(a.Length, a.Array, 0, 1, b, o.Array, 0, 1);
    }
    public class MatrixCopySign : MatrixBinary
    {
        public MatrixCopySign(MatrixExpression a, MatrixExpression b) : base(a, b) { }
        protected override void Evaluate(matrix a, matrix b, matrix o)
            => Vml.CopySign(a.Length, a.Array, 0, 1, b.Array, 0, 1, o.Array, 0, 1);
    }
    public class MatrixFmax : MatrixBinary
    {
        public MatrixFmax(MatrixExpression a, MatrixExpression b) : base(a, b) { }
        protected override void Evaluate(matrix a, matrix b, matrix o)
            => Vml.Fmax(a.Length, a.Array, 0, 1, b.Array, 0, 1, o.Array, 0, 1);
    }
    public class MatrixFmin : MatrixBinary
    {
        public MatrixFmin(MatrixExpression a, MatrixExpression b) : base(a, b) { }
        protected override void Evaluate(matrix a, matrix b, matrix o)
            => Vml.Fmin(a.Length, a.Array, 0, 1, b.Array, 0, 1, o.Array, 0, 1);
    }
    public class MatrixFdim : MatrixBinary
    {
        public MatrixFdim(MatrixExpression a, MatrixExpression b) : base(a, b) { }
        protected override void Evaluate(matrix a, matrix b, matrix o)
            => Vml.Fdim(a.Length, a.Array, 0, 1, b.Array, 0, 1, o.Array, 0, 1);
    }
    public class MatrixMaxMag : MatrixBinary
    {
        public MatrixMaxMag(MatrixExpression a, MatrixExpression b) : base(a, b) { }
        protected override void Evaluate(matrix a, matrix b, matrix o)
            => Vml.MaxMag(a.Length, a.Array, 0, 1, b.Array, 0, 1, o.Array, 0, 1);
    }
    public class MatrixNextAfter : MatrixBinary
    {
        public MatrixNextAfter(MatrixExpression a, MatrixExpression b) : base(a, b) { }
        protected override void Evaluate(matrix a, matrix b, matrix o)
            => Vml.NextAfter(a.Length, a.Array, 0, 1, b.Array, 0, 1, o.Array, 0, 1);
    }
    public class MatrixDot : MatrixBinary
    {
        public MatrixDot(MatrixExpression a, MatrixExpression b) : base(a, b) { }
        protected override void Evaluate(matrix a, matrix b, matrix o)
            => Vml.Mul(a.Length, a.Array, 0, 1, b.Array, 0, 1, o.Array, 0, 1);
    }
    public class MatrixFmod : MatrixBinary
    {
        public MatrixFmod(MatrixExpression a, MatrixExpression b) : base(a, b) { }
        protected override void Evaluate(matrix a, matrix b, matrix o)
            => Vml.Fmod(a.Length, a.Array, 0, 1, b.Array, 0, 1, o.Array, 0, 1);
    }
    public class MatrixAtan2 : MatrixBinary
    {
        public MatrixAtan2(MatrixExpression a, MatrixExpression b) : base(a, b) { }
        protected override void Evaluate(matrix a, matrix b, matrix o)
            => Vml.Atan2(a.Length, a.Array, 0, 1, b.Array, 0, 1, o.Array, 0, 1);
    }
    public class MatrixAtan2pi : MatrixBinary
    {
        public MatrixAtan2pi(MatrixExpression a, MatrixExpression b) : base(a, b) { }
        protected override void Evaluate(matrix a, matrix b, matrix o)
            => Vml.Atan2pi(a.Length, a.Array, 0, 1, b.Array, 0, 1, o.Array, 0, 1);
    }
    public class MatrixPowr : MatrixBinary
    {
        public MatrixPowr(MatrixExpression a, MatrixExpression b) : base(a, b) { }
        protected override void Evaluate(matrix a, matrix b, matrix o)
            => Vml.Powr(a.Length, a.Array, 0, 1, b.Array, 0, 1, o.Array, 0, 1);
    }
    public class MatrixRemainder : MatrixBinary
    {
        public MatrixRemainder(MatrixExpression a, MatrixExpression b) : base(a, b) { }
        protected override void Evaluate(matrix a, matrix b, matrix o)
            => Vml.Remainder(a.Length, a.Array, 0, 1, b.Array, 0, 1, o.Array, 0, 1);
    }
    public class MatrixHypot : MatrixBinary
    {
        public MatrixHypot(MatrixExpression a, MatrixExpression b) : base(a, b) { }
        protected override void Evaluate(matrix a, matrix b, matrix o)
            => Vml.Hypot(a.Length, a.Array, 0, 1, b.Array, 0, 1, o.Array, 0, 1);
    }
    public class MatrixDiv : MatrixBinary
    {
        public MatrixDiv(MatrixExpression a, MatrixExpression b) : base(a, b) { }
        protected override void Evaluate(matrix a, matrix b, matrix o)
            => Vml.Div(a.Length, a.Array, 0, 1, b.Array, 0, 1, o.Array, 0, 1);
    }
    public class MatrixPow : MatrixBinary
    {
        public MatrixPow(MatrixExpression a, MatrixExpression b) : base(a, b) { }
        protected override void Evaluate(matrix a, matrix b, matrix o)
            => Vml.Pow(a.Length, a.Array, 0, 1, b.Array, 0, 1, o.Array, 0, 1);
    }
    public class MatrixLinearFrac : MatrixBinary
    {
        readonly double scalea, shifta, scaleb, shiftb;
        public MatrixLinearFrac(MatrixExpression a, MatrixExpression b, double scalea, double shifta, double scaleb, double shiftb) : base(a, b)
        {
            this.scalea = scalea;
            this.shifta = shifta;
            this.scaleb = scaleb;
            this.shiftb = shiftb;
        }
        protected override void Evaluate(matrix a, matrix b, matrix o)
            => Vml.LinearFrac(a.Length, a.Array, 0, 1, b.Array, 0, 1, scalea, shifta, scaleb, shiftb, o.Array, 0, 1);
    }
    public class MatrixInverse : MatrixExpression
    {
        readonly MatrixExpression i;
        public MatrixInverse(MatrixExpression a) => i = a;
        public override matrix EvaluateMatrix()
        {
            var a = i.EvaluateMatrix();
            if (i is Input) a = Matrix.Copy(a);
            if (a.Rows != a.Cols) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var ipiv = Pool.Int.Rent(a.Rows);
            ThrowHelper.Check(Lapack.getrf(Layout.ColMajor, a.Rows, a.Rows, a.Array, a.Rows, ipiv));
            ThrowHelper.Check(Lapack.getri(Layout.ColMajor, a.Rows, a.Array, a.Rows, ipiv));
            Pool.Int.Return(ipiv);
            return a;
        }
    }
    public class MatrixLower : MatrixExpression
    {
        readonly MatrixExpression i;
        public MatrixLower(MatrixExpression a) => i = a;
        public override matrix EvaluateMatrix()
        {
            var a = i.EvaluateMatrix();
            if (i is Input) a = Matrix.Copy(a);
            for (int c = 1; c < a.Cols; c++)
                for (int r = 0; r < c; r++)
                    a[r, c] = 0.0;
            return a;
        }
    }
    public class MatrixUpper : MatrixExpression
    {
        readonly MatrixExpression i;
        public MatrixUpper(MatrixExpression a) => i = a;
        public override matrix EvaluateMatrix()
        {
            var a = i.EvaluateMatrix();
            if (i is Input) a = MKLNET.Matrix.Copy(a);
            for (int c = 0; c < a.Cols; c++)
                for (int r = c + 1; r < a.Rows; r++)
                    a[r, c] = 0.0;
            return a;
        }
    }
    public class MatrixCholesky : MatrixExpression
    {
        readonly MatrixExpression i;
        public MatrixCholesky(MatrixExpression a) => i = a;
        public override matrix EvaluateMatrix()
        {
            var a = new MatrixLower(i).EvaluateMatrix();
            if (a.Rows != a.Cols) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            ThrowHelper.Check(Lapack.potrf2(Layout.ColMajor, UpLoChar.Lower, a.Rows, a.Array, a.Rows));
            return a;
        }
    }
    public class MatrixSolve : MatrixExpression
    {
        readonly MatrixExpression i, j;
        public MatrixSolve(MatrixExpression a, MatrixExpression b)
        {
            i = a;
            j = b;
        }
        public override matrix EvaluateMatrix()
        {
            var a = i.EvaluateMatrix();
            var b = j.EvaluateMatrix();
            if (a.Rows != a.Cols || a.Rows != b.Rows) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            if (i is Input) a = Matrix.Copy(a);
            var ipiv = Pool.Int.Rent(a.Rows);
            ThrowHelper.Check(Lapack.gesv(Layout.ColMajor, a.Rows, b.Cols, a.Array, a.Rows, ipiv, b.Array, a.Rows));
            Pool.Int.Return(ipiv);
            if (j is not Input) b.Dispose();
            return a;
        }
    }
    public class MatrixLeastSquares : MatrixExpression
    {
        readonly MatrixExpression i, j;
        public MatrixLeastSquares(MatrixExpression a, MatrixExpression b)
        {
            i = a;
            j = b;
        }
        public override matrix EvaluateMatrix()
        {
            var a = i.EvaluateMatrix();
            var b = j.EvaluateMatrix();
            if (a.Rows != b.Rows || a.Cols > a.Rows) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            if (i is Input) a = Matrix.Copy(a);
            Lapack.gels(Layout.RowMajor, TransChar.No, a.Rows, a.Cols, b.Cols, a.Array, a.Cols, b.Array, b.Cols);
            if (j is not Input) b.Dispose();
            return a;
        }
    }
}