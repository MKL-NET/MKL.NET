namespace MKLNET.Expression
{
    public abstract class MatrixExpression
    {
        public abstract matrix EvaluateMatrix();
        public static implicit operator MatrixExpression(matrix a) => new MatrixInput(a);
        public static implicit operator matrix(MatrixExpression a) => a.EvaluateMatrix();
        public static MatrixExpression operator +(MatrixExpression a, double s) => new MatrixAddScalar(a, s);
        public static MatrixExpression operator +(double s, MatrixExpression b) => new MatrixAddScalar(b, s);
        public static MatrixExpression operator -(MatrixExpression a, double s) => new MatrixAddScalar(a, -s);
        public static MatrixExpression operator -(double s, MatrixExpression a) =>
            new MatrixAddScalar(a is MatrixScale sm ? new MatrixScale(sm.E, -sm.S) : new MatrixScale(a, -1.0), s);
        public static MatrixExpression operator +(MatrixExpression a, MatrixExpression b)
        {
            if (a is MatrixTranspose ta)
            {
                return b is MatrixTranspose tb ? new MatrixAddTranspose(ta.E, TransChar.Yes, ta.S, tb.E, TransChar.Yes, tb.S)
                     : b is MatrixScale sb ? new MatrixAddTranspose(ta.E, TransChar.Yes, ta.S, sb.E, TransChar.No, sb.S)
                     : new MatrixAddTranspose(ta.E, TransChar.Yes, ta.S, b, TransChar.No, 1.0);
            }
            else if (b is MatrixTranspose tb)
            {
                return a is MatrixScale sa ? new MatrixAddTranspose(sa.E, TransChar.No, sa.S, tb.E, TransChar.Yes, tb.S)
                     : new MatrixAddTranspose(a, TransChar.No, 1.0, tb.E, TransChar.Yes, tb.S);
            }
            else if (a is MatrixScale sa)
            {
                return b is MatrixScale sb ? new MatrixAddScale(sa.E, sa.S, sb.E, sb.S)
                     : new MatrixAddScale(sa.E, sa.S, b, 1.0);
            }
            else if (b is MatrixScale sb)
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
                     : b is MatrixScale sb ? new MatrixAddTranspose(ta.E, TransChar.Yes, ta.S, sb.E, TransChar.No, -sb.S)
                     : new MatrixAddTranspose(ta.E, TransChar.Yes, ta.S, b, TransChar.No, -1.0);
            }
            else if (b is MatrixTranspose tb)
            {
                return a is MatrixScale sa ? new MatrixAddTranspose(sa.E, TransChar.No, sa.S, tb.E, TransChar.Yes, -tb.S)
                     : new MatrixAddTranspose(a, TransChar.No, 1.0, tb.E, TransChar.Yes, -tb.S);
            }
            else if (a is MatrixScale sa)
            {
                return b is MatrixScale sb ? new MatrixAddScale(sa.E, sa.S, sb.E, -sb.S)
                     : new MatrixAddScale(sa.E, sa.S, b, -1.0);
            }
            else if (b is MatrixScale sb)
            {
                return new MatrixAddScale(a, 1.0, sb.E, -sb.S);
            }
            return new MatrixSubSimple(a, b);
        }
        public static MatrixExpression operator *(MatrixExpression a, double s) =>
              a is MatrixTranspose ta ? new MatrixTranspose(ta.E, ta.S * s)
            : a is MatrixScale sa ? new MatrixScale(sa.E, sa.S * s)
            : new MatrixScale(a, s);
        public static MatrixExpression operator *(double s, MatrixExpression a) =>
              a is MatrixTranspose ta ? new MatrixTranspose(ta.E, ta.S * s)
            : a is MatrixScale sa ? new MatrixScale(sa.E, sa.S * s)
            : new MatrixScale(a, s);
        public static MatrixExpression operator *(MatrixExpression a, MatrixExpression b) => new MatrixMultiply(a, b);
        public MatrixExpression T =>
              this is MatrixTranspose t ? (t.S == 1.0 ? t.E : new MatrixScale(t.E, t.S))
            : this is MatrixScale s ? new MatrixTranspose(s.E, s.S)
            : new MatrixTranspose(this, 1.0);
        public static VectorExpression operator *(MatrixExpression m, VectorExpression v) => new MatrixVectorMultiply(m, v);
        public static VectorTExpression operator *(VectorTExpression vt, MatrixExpression m) => new VectorTMatrixMultiply(vt, m);
    }

    public class MatrixInput : MatrixExpression
    {
        readonly protected matrix m;
        public MatrixInput(matrix a) => m = a;
        public override matrix EvaluateMatrix() => m;
    }

    public class MatrixScale : MatrixExpression
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
            var a = E.EvaluateMatrix();
            var r = E is MatrixInput ? new matrix(a.Rows, a.Cols) : a;
            Blas.omatcopy(LayoutChar.ColMajor, TransChar.No, a.Rows, a.Cols, S, a.Array, a.Rows, r.Array, a.Rows);
            return r;
        }
        public new MatrixTranspose T => new(E, S);
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
            var a = E.EvaluateMatrix();
            var r = E is MatrixInput ? new matrix(a.Cols, a.Rows) : new matrix(a.Cols, a.Rows, a.Reuse());
            Blas.omatcopy(LayoutChar.ColMajor, TransChar.Yes, a.Rows, a.Cols, S, a.Array, a.Rows, r.Array, a.Cols); // Check rows, cols
            return r;
        }
    }

    public abstract class MatrixUnary : MatrixExpression
    {
        readonly MatrixExpression E;
        public MatrixUnary(MatrixExpression a) => E = a;
        protected abstract void Evaluate(matrix a, matrix o);
        public override matrix EvaluateMatrix()
        {
            var a = E.EvaluateMatrix();
            var r = E is MatrixInput ? new matrix(a.Rows, a.Cols) : a;
            Evaluate(a, r);
            return r;
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
            var r = Ea is not MatrixInput ? a
                  : Eb is not MatrixInput ? b
                  : new matrix(a.Rows, a.Cols);
            Evaluate(a, b, r);
            if (Ea is not MatrixInput && Eb is not MatrixInput) b.Dispose();
            return r;
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
            var r = Ea is not MatrixInput ? a
                  : Eb is not MatrixInput ? b
                  : new matrix(a.Rows, a.Cols);
            Vml.Add(a.Length, a.Array, 0, 1, b.Array, 0, 1, r.Array, 0, 1);
            if (Ea is not MatrixInput && Eb is not MatrixInput) b.Dispose();
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
            var r = Ea is not MatrixInput ? a
                  : Eb is not MatrixInput ? b
                  : new matrix(a.Rows, a.Cols);
            Vml.LinearFrac(a.Length, a.Array, 0, 1, b.Array, 0, 1, Sa, 0.0, Sb, 0.0, r.Array, 0, 1);
            if (Ea is not MatrixInput && Eb is not MatrixInput) b.Dispose();
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
               || (a.Rows != b.Cols || a.Cols != b.Rows)) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = Ea is not MatrixInput ? (Transa == TransChar.Yes ? new matrix(a.Cols, a.Rows, a.Reuse()) : a)
                  : Eb is not MatrixInput ? (Transb == TransChar.Yes ? new matrix(b.Cols, b.Rows, b.Reuse()) : b)
                  : new matrix(a.Rows, a.Cols);
            Blas.omatadd(LayoutChar.ColMajor, Transa, Transb, r.Rows, r.Cols, Sa, a.Array, a.Rows, Sb, b.Array, b.Rows, r.Array, r.Rows);
            if (Ea is not MatrixInput && Eb is not MatrixInput) b.Dispose();
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
            var r = Ea is not MatrixInput ? a
                  : Eb is not MatrixInput ? b
                  : new matrix(a.Rows, a.Cols);
            Vml.Sub(a.Length, a.Array, 0, 1, b.Array, 0, 1, r.Array, 0, 1);
            if (Ea is not MatrixInput && Eb is not MatrixInput) b.Dispose();
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
            var (e, sa) = E is MatrixScale Es ? (Es.E, Es.S) : (E, 1.0);
            var a = e.EvaluateMatrix();
            var r = e is MatrixInput ? new matrix(a.Rows, a.Cols) : a;
            Vml.LinearFrac(a.Length, a.Array, 0, 1, a.Array, 0, 1, sa, S, 0.0, 0.0, r.Array, 0, 1);
            return r;
        }
    }

    public class MatrixMultiply : MatrixExpression
    {
        readonly MatrixExpression Ea, Be;
        public MatrixMultiply(MatrixExpression a, MatrixExpression b)
        {
            Ea = a;
            Be = b;
        }
        public override matrix EvaluateMatrix()
        {
            // Fix this up, transpose, scale, r with correct rows, cols
            var a = Ea.EvaluateMatrix();
            var b = Be.EvaluateMatrix();
            if (a.Cols != b.Rows) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            if (Ea is not MatrixInput && a.Array.Length >= a.Rows * b.Cols)
            {
                Blas.gemm(Layout.ColMajor, Trans.No, Trans.No, a.Rows, b.Cols, a.Cols, 1.0, a.Array, a.Rows, b.Array, b.Rows, 0.0, a.Array, a.Rows);
                if (Be is not MatrixInput) b.Dispose();
                return a;
            }
            else if (Be is not MatrixInput && b.Array.Length >= a.Rows * b.Cols)
            {
                Blas.gemm(Layout.ColMajor, Trans.No, Trans.No, a.Rows, b.Cols, a.Cols, 1.0, a.Array, a.Rows, b.Array, b.Rows, 0.0, b.Array, a.Rows);
                if (Ea is not MatrixInput) a.Dispose();
                return b;
            }
            else
            {
                var r = new matrix(a.Rows, b.Cols);
                Blas.gemm(Layout.ColMajor, Trans.No, Trans.No, a.Rows, b.Cols, a.Cols, 1.0, a.Array, a.Rows, b.Array, b.Rows, 0.0, r.Array, a.Rows);
                if (Ea is not MatrixInput) a.Dispose();
                if (Be is not MatrixInput) b.Dispose();
                return r;
            }
        }
    }

    public class MatrixAbs : MatrixUnary
    {
        public MatrixAbs(MatrixExpression a) : base(a) { }
        protected override void Evaluate(matrix a, matrix r)
            => Vml.Abs(a.Length, a.Array, 0, 1, r.Array, 0, 1);
    }

    public class MatrixSqr : MatrixUnary
    {
        public MatrixSqr(MatrixExpression a) : base(a) { }
        protected override void Evaluate(matrix a, matrix r)
            => Vml.Sqr(a.Length, a.Array, 0, 1, r.Array, 0, 1);
    }

    public class MatrixInv : MatrixUnary
    {
        public MatrixInv(MatrixExpression a) : base(a) { }
        protected override void Evaluate(matrix a, matrix r)
            => Vml.Inv(a.Length, a.Array, 0, 1, r.Array, 0, 1);
    }

    public class MatrixSqrt : MatrixUnary
    {
        public MatrixSqrt(MatrixExpression a) : base(a) { }
        protected override void Evaluate(matrix a, matrix r)
            => Vml.Sqrt(a.Length, a.Array, 0, 1, r.Array, 0, 1);
    }

    public class MatrixInvSqrt : MatrixUnary
    {
        public MatrixInvSqrt(MatrixExpression a) : base(a) { }
        protected override void Evaluate(matrix a, matrix r)
            => Vml.InvSqrt(a.Length, a.Array, 0, 1, r.Array, 0, 1);
    }

    public class MatrixCbrt : MatrixUnary
    {
        public MatrixCbrt(MatrixExpression a) : base(a) { }
        protected override void Evaluate(matrix a, matrix r)
            => Vml.Cbrt(a.Length, a.Array, 0, 1, r.Array, 0, 1);
    }

    public class MatrixInvCbrt : MatrixUnary
    {
        public MatrixInvCbrt(MatrixExpression a) : base(a) { }
        protected override void Evaluate(matrix a, matrix r)
            => Vml.InvCbrt(a.Length, a.Array, 0, 1, r.Array, 0, 1);
    }

    public class MatrixPow2o3 : MatrixUnary
    {
        public MatrixPow2o3(MatrixExpression a) : base(a) { }
        protected override void Evaluate(matrix a, matrix r)
            => Vml.Pow2o3(a.Length, a.Array, 0, 1, r.Array, 0, 1);
    }

    public class MatrixPow3o2 : MatrixUnary
    {
        public MatrixPow3o2(MatrixExpression a) : base(a) { }
        protected override void Evaluate(matrix a, matrix r)
            => Vml.Pow3o2(a.Length, a.Array, 0, 1, r.Array, 0, 1);
    }

    public class MatrixExp : MatrixUnary
    {
        public MatrixExp(MatrixExpression a) : base(a) { }
        protected override void Evaluate(matrix a, matrix r)
            => Vml.Exp(a.Length, a.Array, 0, 1, r.Array, 0, 1);
    }

    public class MatrixExp2 : MatrixUnary
    {
        public MatrixExp2(MatrixExpression a) : base(a) { }
        protected override void Evaluate(matrix a, matrix r)
            => Vml.Exp2(a.Length, a.Array, 0, 1, r.Array, 0, 1);
    }

    public class MatrixExp10 : MatrixUnary
    {
        public MatrixExp10(MatrixExpression a) : base(a) { }
        protected override void Evaluate(matrix a, matrix r)
            => Vml.Exp10(a.Length, a.Array, 0, 1, r.Array, 0, 1);
    }

    public class MatrixExpm1 : MatrixUnary
    {
        public MatrixExpm1(MatrixExpression a) : base(a) { }
        protected override void Evaluate(matrix a, matrix r)
            => Vml.Expm1(a.Length, a.Array, 0, 1, r.Array, 0, 1);
    }

    public class MatrixLn : MatrixUnary
    {
        public MatrixLn(MatrixExpression a) : base(a) { }
        protected override void Evaluate(matrix a, matrix r)
            => Vml.Ln(a.Length, a.Array, 0, 1, r.Array, 0, 1);
    }

    public class MatrixLog2 : MatrixUnary
    {
        public MatrixLog2(MatrixExpression a) : base(a) { }
        protected override void Evaluate(matrix a, matrix r)
            => Vml.Log2(a.Length, a.Array, 0, 1, r.Array, 0, 1);
    }

    public class MatrixLog10 : MatrixUnary
    {
        public MatrixLog10(MatrixExpression a) : base(a) { }
        protected override void Evaluate(matrix a, matrix r)
            => Vml.Log10(a.Length, a.Array, 0, 1, r.Array, 0, 1);
    }

    public class MatrixLog1p : MatrixUnary
    {
        public MatrixLog1p(MatrixExpression a) : base(a) { }
        protected override void Evaluate(matrix a, matrix r)
            => Vml.Log1p(a.Length, a.Array, 0, 1, r.Array, 0, 1);
    }

    public class MatrixLogb : MatrixUnary
    {
        public MatrixLogb(MatrixExpression a) : base(a) { }
        protected override void Evaluate(matrix a, matrix r)
            => Vml.Logb(a.Length, a.Array, 0, 1, r.Array, 0, 1);
    }
    public class MatrixCos : MatrixUnary
    {
        public MatrixCos(MatrixExpression a) : base(a) { }
        protected override void Evaluate(matrix a, matrix r)
            => Vml.Cos(a.Length, a.Array, 0, 1, r.Array, 0, 1);
    }

    public class MatrixSin : MatrixUnary
    {
        public MatrixSin(MatrixExpression a) : base(a) { }
        protected override void Evaluate(matrix a, matrix r)
            => Vml.Sin(a.Length, a.Array, 0, 1, r.Array, 0, 1);
    }

    public class MatrixTan : MatrixUnary
    {
        public MatrixTan(MatrixExpression a) : base(a) { }
        protected override void Evaluate(matrix a, matrix r)
            => Vml.Tan(a.Length, a.Array, 0, 1, r.Array, 0, 1);
    }

    public class MatrixCospi : MatrixUnary
    {
        public MatrixCospi(MatrixExpression a) : base(a) { }
        protected override void Evaluate(matrix a, matrix r)
            => Vml.Cospi(a.Length, a.Array, 0, 1, r.Array, 0, 1);
    }

    public class MatrixSinpi : MatrixUnary
    {
        public MatrixSinpi(MatrixExpression a) : base(a) { }
        protected override void Evaluate(matrix a, matrix r)
            => Vml.Sinpi(a.Length, a.Array, 0, 1, r.Array, 0, 1);
    }

    public class MatrixTanpi : MatrixUnary
    {
        public MatrixTanpi(MatrixExpression a) : base(a) { }
        protected override void Evaluate(matrix a, matrix r)
            => Vml.Tanpi(a.Length, a.Array, 0, 1, r.Array, 0, 1);
    }

    public class MatrixCosd : MatrixUnary
    {
        public MatrixCosd(MatrixExpression a) : base(a) { }
        protected override void Evaluate(matrix a, matrix r)
            => Vml.Cosd(a.Length, a.Array, 0, 1, r.Array, 0, 1);
    }

    public class MatrixSind : MatrixUnary
    {
        public MatrixSind(MatrixExpression a) : base(a) { }
        protected override void Evaluate(matrix a, matrix r)
            => Vml.Sind(a.Length, a.Array, 0, 1, r.Array, 0, 1);
    }

    public class MatrixTand : MatrixUnary
    {
        public MatrixTand(MatrixExpression a) : base(a) { }
        protected override void Evaluate(matrix a, matrix r)
            => Vml.Tand(a.Length, a.Array, 0, 1, r.Array, 0, 1);
    }

    public class MatrixAcos : MatrixUnary
    {
        public MatrixAcos(MatrixExpression a) : base(a) { }
        protected override void Evaluate(matrix a, matrix r)
            => Vml.Acos(a.Length, a.Array, 0, 1, r.Array, 0, 1);
    }

    public class MatrixAsin : MatrixUnary
    {
        public MatrixAsin(MatrixExpression a) : base(a) { }
        protected override void Evaluate(matrix a, matrix r)
            => Vml.Asin(a.Length, a.Array, 0, 1, r.Array, 0, 1);
    }

    public class MatrixAtan : MatrixUnary
    {
        public MatrixAtan(MatrixExpression a) : base(a) { }
        protected override void Evaluate(matrix a, matrix r)
            => Vml.Atan(a.Length, a.Array, 0, 1, r.Array, 0, 1);
    }

    public class MatrixAcospi : MatrixUnary
    {
        public MatrixAcospi(MatrixExpression a) : base(a) { }
        protected override void Evaluate(matrix a, matrix r)
            => Vml.Acospi(a.Length, a.Array, 0, 1, r.Array, 0, 1);
    }

    public class MatrixAsinpi : MatrixUnary
    {
        public MatrixAsinpi(MatrixExpression a) : base(a) { }
        protected override void Evaluate(matrix a, matrix r)
            => Vml.Asinpi(a.Length, a.Array, 0, 1, r.Array, 0, 1);
    }

    public class MatrixAtanpi : MatrixUnary
    {
        public MatrixAtanpi(MatrixExpression a) : base(a) { }
        protected override void Evaluate(matrix a, matrix r)
            => Vml.Atanpi(a.Length, a.Array, 0, 1, r.Array, 0, 1);
    }

    public class MatrixCosh : MatrixUnary
    {
        public MatrixCosh(MatrixExpression a) : base(a) { }
        protected override void Evaluate(matrix a, matrix r)
            => Vml.Cosh(a.Length, a.Array, 0, 1, r.Array, 0, 1);
    }

    public class MatrixSinh : MatrixUnary
    {
        public MatrixSinh(MatrixExpression a) : base(a) { }
        protected override void Evaluate(matrix a, matrix r)
            => Vml.Sinh(a.Length, a.Array, 0, 1, r.Array, 0, 1);
    }

    public class MatrixTanh : MatrixUnary
    {
        public MatrixTanh(MatrixExpression a) : base(a) { }
        protected override void Evaluate(matrix a, matrix r)
            => Vml.Tanh(a.Length, a.Array, 0, 1, r.Array, 0, 1);
    }

    public class MatrixAcosh : MatrixUnary
    {
        public MatrixAcosh(MatrixExpression a) : base(a) { }
        protected override void Evaluate(matrix a, matrix r)
            => Vml.Acosh(a.Length, a.Array, 0, 1, r.Array, 0, 1);
    }

    public class MatrixAsinh : MatrixUnary
    {
        public MatrixAsinh(MatrixExpression a) : base(a) { }
        protected override void Evaluate(matrix a, matrix r)
            => Vml.Asinh(a.Length, a.Array, 0, 1, r.Array, 0, 1);
    }

    public class MatrixAtanh : MatrixUnary
    {
        public MatrixAtanh(MatrixExpression a) : base(a) { }
        protected override void Evaluate(matrix a, matrix r)
            => Vml.Atanh(a.Length, a.Array, 0, 1, r.Array, 0, 1);
    }

    public class MatrixErf : MatrixUnary
    {
        public MatrixErf(MatrixExpression a) : base(a) { }
        protected override void Evaluate(matrix a, matrix r)
            => Vml.Erf(a.Length, a.Array, 0, 1, r.Array, 0, 1);
    }

    public class MatrixErfc : MatrixUnary
    {
        public MatrixErfc(MatrixExpression a) : base(a) { }
        protected override void Evaluate(matrix a, matrix r)
            => Vml.Erfc(a.Length, a.Array, 0, 1, r.Array, 0, 1);
    }

    public class MatrixErfInv : MatrixUnary
    {
        public MatrixErfInv(MatrixExpression a) : base(a) { }
        protected override void Evaluate(matrix a, matrix r)
            => Vml.ErfInv(a.Length, a.Array, 0, 1, r.Array, 0, 1);
    }

    public class MatrixErfcInv : MatrixUnary
    {
        public MatrixErfcInv(MatrixExpression a) : base(a) { }
        protected override void Evaluate(matrix a, matrix r)
            => Vml.ErfcInv(a.Length, a.Array, 0, 1, r.Array, 0, 1);
    }

    public class MatrixCdfNorm : MatrixUnary
    {
        public MatrixCdfNorm(MatrixExpression a) : base(a) { }
        protected override void Evaluate(matrix a, matrix r)
            => Vml.CdfNorm(a.Length, a.Array, 0, 1, r.Array, 0, 1);
    }

    public class MatrixCdfNormInv : MatrixUnary
    {
        public MatrixCdfNormInv(MatrixExpression a) : base(a) { }
        protected override void Evaluate(matrix a, matrix r)
            => Vml.CdfNormInv(a.Length, a.Array, 0, 1, r.Array, 0, 1);
    }

    public class MatrixLGamma : MatrixUnary
    {
        public MatrixLGamma(MatrixExpression a) : base(a) { }
        protected override void Evaluate(matrix a, matrix r)
            => Vml.LGamma(a.Length, a.Array, 0, 1, r.Array, 0, 1);
    }

    public class MatrixTGamma : MatrixUnary
    {
        public MatrixTGamma(MatrixExpression a) : base(a) { }
        protected override void Evaluate(matrix a, matrix r)
            => Vml.TGamma(a.Length, a.Array, 0, 1, r.Array, 0, 1);
    }

    public class MatrixExpInt1 : MatrixUnary
    {
        public MatrixExpInt1(MatrixExpression a) : base(a) { }
        protected override void Evaluate(matrix a, matrix r)
            => Vml.ExpInt1(a.Length, a.Array, 0, 1, r.Array, 0, 1);
    }

    public class MatrixFloor : MatrixUnary
    {
        public MatrixFloor(MatrixExpression a) : base(a) { }
        protected override void Evaluate(matrix a, matrix r)
            => Vml.Floor(a.Length, a.Array, 0, 1, r.Array, 0, 1);
    }

    public class MatrixCeil : MatrixUnary
    {
        public MatrixCeil(MatrixExpression a) : base(a) { }
        protected override void Evaluate(matrix a, matrix r)
            => Vml.Ceil(a.Length, a.Array, 0, 1, r.Array, 0, 1);
    }

    public class MatrixTrunc : MatrixUnary
    {
        public MatrixTrunc(MatrixExpression a) : base(a) { }
        protected override void Evaluate(matrix a, matrix r)
            => Vml.Trunc(a.Length, a.Array, 0, 1, r.Array, 0, 1);
    }

    public class MatrixRound : MatrixUnary
    {
        public MatrixRound(MatrixExpression a) : base(a) { }
        protected override void Evaluate(matrix a, matrix r)
            => Vml.Round(a.Length, a.Array, 0, 1, r.Array, 0, 1);
    }

    public class MatrixFrac : MatrixUnary
    {
        public MatrixFrac(MatrixExpression a) : base(a) { }
        protected override void Evaluate(matrix a, matrix r)
            => Vml.Frac(a.Length, a.Array, 0, 1, r.Array, 0, 1);
    }

    public class MatrixNearbyInt : MatrixUnary
    {
        public MatrixNearbyInt(MatrixExpression a) : base(a) { }
        protected override void Evaluate(matrix a, matrix r)
            => Vml.NearbyInt(a.Length, a.Array, 0, 1, r.Array, 0, 1);
    }

    public class MatrixRint : MatrixUnary
    {
        public MatrixRint(MatrixExpression a) : base(a) { }
        protected override void Evaluate(matrix a, matrix r)
            => Vml.Rint(a.Length, a.Array, 0, 1, r.Array, 0, 1);
    }

    public class MatrixPowx : MatrixUnary
    {
        readonly double b;
        public MatrixPowx(MatrixExpression a, double b) : base(a) => this.b = b;
        protected override void Evaluate(matrix a, matrix r)
            => Vml.Powx(a.Length, a.Array, 0, 1, b, r.Array, 0, 1);
    }

    public class MatrixCopySign : MatrixBinary
    {
        public MatrixCopySign(MatrixExpression a, MatrixExpression b) : base(a, b) { }
        protected override void Evaluate(matrix a, matrix b, matrix r)
            => Vml.CopySign(a.Length, a.Array, 0, 1, b.Array, 0, 1, r.Array, 0, 1);
    }

    public class MatrixFmax : MatrixBinary
    {
        public MatrixFmax(MatrixExpression a, MatrixExpression b) : base(a, b) { }
        protected override void Evaluate(matrix a, matrix b, matrix r)
            => Vml.Fmax(a.Length, a.Array, 0, 1, b.Array, 0, 1, r.Array, 0, 1);
    }

    public class MatrixFmin : MatrixBinary
    {
        public MatrixFmin(MatrixExpression a, MatrixExpression b) : base(a, b) { }
        protected override void Evaluate(matrix a, matrix b, matrix r)
            => Vml.Fmin(a.Length, a.Array, 0, 1, b.Array, 0, 1, r.Array, 0, 1);
    }

    public class MatrixFdim : MatrixBinary
    {
        public MatrixFdim(MatrixExpression a, MatrixExpression b) : base(a, b) { }
        protected override void Evaluate(matrix a, matrix b, matrix r)
            => Vml.Fdim(a.Length, a.Array, 0, 1, b.Array, 0, 1, r.Array, 0, 1);
    }

    public class MatrixMaxMag : MatrixBinary
    {
        public MatrixMaxMag(MatrixExpression a, MatrixExpression b) : base(a, b) { }
        protected override void Evaluate(matrix a, matrix b, matrix r)
            => Vml.MaxMag(a.Length, a.Array, 0, 1, b.Array, 0, 1, r.Array, 0, 1);
    }

    public class MatrixNextAfter : MatrixBinary
    {
        public MatrixNextAfter(MatrixExpression a, MatrixExpression b) : base(a, b) { }
        protected override void Evaluate(matrix a, matrix b, matrix r)
            => Vml.NextAfter(a.Length, a.Array, 0, 1, b.Array, 0, 1, r.Array, 0, 1);
    }

    public class MatrixMul : MatrixBinary
    {
        public MatrixMul(MatrixExpression a, MatrixExpression b) : base(a, b) { }
        protected override void Evaluate(matrix a, matrix b, matrix r)
            => Vml.Mul(a.Length, a.Array, 0, 1, b.Array, 0, 1, r.Array, 0, 1);
    }

    public class MatrixFmod : MatrixBinary
    {
        public MatrixFmod(MatrixExpression a, MatrixExpression b) : base(a, b) { }
        protected override void Evaluate(matrix a, matrix b, matrix r)
            => Vml.Fmod(a.Length, a.Array, 0, 1, b.Array, 0, 1, r.Array, 0, 1);
    }

    public class MatrixAtan2 : MatrixBinary
    {
        public MatrixAtan2(MatrixExpression a, MatrixExpression b) : base(a, b) { }
        protected override void Evaluate(matrix a, matrix b, matrix r)
            => Vml.Atan2(a.Length, a.Array, 0, 1, b.Array, 0, 1, r.Array, 0, 1);
    }

    public class MatrixAtan2pi : MatrixBinary
    {
        public MatrixAtan2pi(MatrixExpression a, MatrixExpression b) : base(a, b) { }
        protected override void Evaluate(matrix a, matrix b, matrix r)
            => Vml.Atan2pi(a.Length, a.Array, 0, 1, b.Array, 0, 1, r.Array, 0, 1);
    }

    public class MatrixPowr : MatrixBinary
    {
        public MatrixPowr(MatrixExpression a, MatrixExpression b) : base(a, b) { }
        protected override void Evaluate(matrix a, matrix b, matrix r)
            => Vml.Powr(a.Length, a.Array, 0, 1, b.Array, 0, 1, r.Array, 0, 1);
    }

    public class MatrixRemainder : MatrixBinary
    {
        public MatrixRemainder(MatrixExpression a, MatrixExpression b) : base(a, b) { }
        protected override void Evaluate(matrix a, matrix b, matrix r)
            => Vml.Remainder(a.Length, a.Array, 0, 1, b.Array, 0, 1, r.Array, 0, 1);
    }

    public class MatrixHypot : MatrixBinary
    {
        public MatrixHypot(MatrixExpression a, MatrixExpression b) : base(a, b) { }
        protected override void Evaluate(matrix a, matrix b, matrix r)
            => Vml.Hypot(a.Length, a.Array, 0, 1, b.Array, 0, 1, r.Array, 0, 1);
    }

    public class MatrixDiv : MatrixBinary
    {
        public MatrixDiv(MatrixExpression a, MatrixExpression b) : base(a, b) { }
        protected override void Evaluate(matrix a, matrix b, matrix r)
            => Vml.Div(a.Length, a.Array, 0, 1, b.Array, 0, 1, r.Array, 0, 1);
    }

    public class MatrixPow : MatrixBinary
    {
        public MatrixPow(MatrixExpression a, MatrixExpression b) : base(a, b) { }
        protected override void Evaluate(matrix a, matrix b, matrix r)
            => Vml.Pow(a.Length, a.Array, 0, 1, b.Array, 0, 1, r.Array, 0, 1);
    }

    public class MatrixLinearFrac : MatrixBinary
    {
        readonly double Scalea, Shifta, Scaleb, Shiftb;
        public MatrixLinearFrac(MatrixExpression a, MatrixExpression b, double scalea, double shifta, double scaleb, double shiftb) : base(a, b)
        {
            Scalea = scalea;
            Shifta = shifta;
            Scaleb = scaleb;
            Shiftb = shiftb;
        }
        protected override void Evaluate(matrix a, matrix b, matrix r)
            => Vml.LinearFrac(a.Length, a.Array, 0, 1, b.Array, 0, 1, Scalea, Shifta, Scaleb, Shiftb, r.Array, 0, 1);
    }

    public class MatrixInverse : MatrixExpression
    {
        readonly MatrixExpression E;
        public MatrixInverse(MatrixExpression a) => E = a;
        public override matrix EvaluateMatrix()
        {
            var a = E.EvaluateMatrix();
            if (a.Rows != a.Cols) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            if (E is MatrixInput) a = Matrix.Copy(a);
            var ipiv = Pool.Int.Rent(a.Rows);
            ThrowHelper.Check(Lapack.getrf(Layout.ColMajor, a.Rows, a.Rows, a.Array, a.Rows, ipiv));
            ThrowHelper.Check(Lapack.getri(Layout.ColMajor, a.Rows, a.Array, a.Rows, ipiv));
            Pool.Int.Return(ipiv);
            return a;
        }
    }

    public class MatrixLower : MatrixExpression
    {
        readonly MatrixExpression E;
        public MatrixLower(MatrixExpression a) => E = a;
        public override matrix EvaluateMatrix()
        {
            var a = E.EvaluateMatrix();
            if (E is MatrixInput) a = Matrix.Copy(a);
            for (int c = 1; c < a.Cols; c++)
                for (int r = 0; r < c; r++)
                    a[r, c] = 0.0;
            return a;
        }
    }

    public class MatrixUpper : MatrixExpression
    {
        readonly MatrixExpression E;
        public MatrixUpper(MatrixExpression a) => E = a;
        public override matrix EvaluateMatrix()
        {
            var a = E.EvaluateMatrix();
            if (E is MatrixInput) a = Matrix.Copy(a);
            for (int c = 0; c < a.Cols; c++)
                for (int r = c + 1; r < a.Rows; r++)
                    a[r, c] = 0.0;
            return a;
        }
    }

    public class MatrixCholesky : MatrixExpression
    {
        readonly MatrixExpression E;
        public MatrixCholesky(MatrixExpression a) => E = a;
        public override matrix EvaluateMatrix()
        {
            var a = new MatrixLower(E).EvaluateMatrix();
            if (a.Rows != a.Cols) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            ThrowHelper.Check(Lapack.potrf2(Layout.ColMajor, UpLoChar.Lower, a.Rows, a.Array, a.Rows));
            return a;
        }
    }

    public class MatrixSolve : MatrixExpression
    {
        readonly MatrixExpression Ea, Eb;
        public MatrixSolve(MatrixExpression a, MatrixExpression b)
        {
            Ea = a;
            Eb = b;
        }
        public override matrix EvaluateMatrix()
        {
            var a = Ea.EvaluateMatrix();
            var b = Eb.EvaluateMatrix();
            if (a.Rows != a.Cols || a.Rows != b.Rows) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            if (Ea is MatrixInput) a = Matrix.Copy(a);
            var ipiv = Pool.Int.Rent(a.Rows);
            ThrowHelper.Check(Lapack.gesv(Layout.ColMajor, a.Rows, b.Cols, a.Array, a.Rows, ipiv, b.Array, a.Rows));
            Pool.Int.Return(ipiv);
            if (Eb is not MatrixInput) b.Dispose();
            return a;
        }
    }

    public class MatrixLeastSquares : MatrixExpression
    {
        readonly MatrixExpression Ea, Eb;
        public MatrixLeastSquares(MatrixExpression a, MatrixExpression b)
        {
            Ea = a;
            Eb = b;
        }
        public override matrix EvaluateMatrix()
        {
            var a = Ea.EvaluateMatrix();
            var b = Eb.EvaluateMatrix();
            if (a.Rows != b.Rows || a.Cols > a.Rows) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            if (Ea is MatrixInput) a = Matrix.Copy(a);
            Lapack.gels(Layout.RowMajor, TransChar.No, a.Rows, a.Cols, b.Cols, a.Array, a.Cols, b.Array, b.Cols);
            if (Eb is not MatrixInput) b.Dispose();
            return a;
        }
    }
}