using System;
using System.Data.Common;
using MKLNET.Expression;

namespace MKLNET
{
    public class matrix : IDisposable
    {
        internal static ArrayPool<double> Pool = new(1024 * 1024, 10);
        public readonly int Rows, Cols;
        public double[] Array;
        public int Length => Rows * Cols;
        public matrix(int rows, int cols, double[] reuse)
        {
            Rows = rows;
            Cols = cols;
            Array = reuse;
        }
        public matrix(int rows, int cols) : this(rows, cols, Pool.Rent(rows * cols)) { }
        public double this[int row, int col]
        {
            get => Array[col * Rows + row];
            set => Array[col * Rows + row] = value;
        }
        public void Dispose()
        {
            Pool.Return(Array);
            GC.SuppressFinalize(this);
        }
        public double[] ReuseArray()
        {
            GC.SuppressFinalize(this);
            return Array;
        }
        public MatrixExpression Reuse() => new MatrixReuse(this);
        ~matrix() => Pool.Return(Array);
        public MatrixExpression T => new MatrixTranspose(this);
        public static MatrixExpression operator +(matrix a, double s) => new MatrixAddScalar(a, s);
        public static MatrixExpression operator +(double s, matrix a) => new MatrixAddScalar(a, s);
        public static MatrixExpression operator -(matrix a, double s) => new MatrixAddScalar(a, -s);
        public static MatrixExpression operator -(double s, matrix a) => s - (MatrixExpression)a;
        public static MatrixExpression operator +(matrix a, matrix b) => new MatrixAddSimple(a, b, null);
        public static MatrixExpression operator +(matrix a, MatrixExpression b) => (MatrixExpression)a + b;
        public static MatrixExpression operator +(MatrixExpression a, matrix b) => a + (MatrixExpression)b;
        public static MatrixExpression operator -(matrix a, matrix b) => new MatrixSubSimple(a, b, null);
        public static MatrixExpression operator -(MatrixExpression a, matrix b) => a - (MatrixExpression)b;
        public static MatrixExpression operator -(matrix a, MatrixExpression b) => (MatrixExpression)a - b;
        public static MatrixExpression operator *(matrix a, double s) => new MatrixScale(a, s);
        public static MatrixExpression operator *(double s, matrix a) => new MatrixScale(a, s);
        public static MatrixExpression operator /(matrix a, double s) => new MatrixScale(a, 1 / s);
        public static MatrixExpression operator *(matrix a, matrix b) => new MatrixMultiply(a, b, null);
        public static MatrixExpression operator *(matrix a, MatrixExpression b) => new MatrixMultiply(a, b, null);
        public static MatrixExpression operator *(MatrixExpression a, matrix b) => new MatrixMultiply(a, b, null);
        public static VectorExpression operator *(matrix m, vector v) => new MatrixVectorMultiply(m, v, null);
        public static VectorExpression operator *(matrix m, VectorExpression v) => new MatrixVectorMultiply(m, v, null);
        public static VectorTExpression operator *(vectorT vt, matrix m) => new VectorTMatrixMultiply(vt, m, null);
        public static VectorTExpression operator *(VectorTExpression vt, matrix m) => new VectorTMatrixMultiply(vt, m, null);
    }

    public static class Matrix
    {
        public static void ResetPools(int maxArrayLength, int maxArraysPerBucket)
        {
            Pool.Int = new(maxArrayLength, maxArraysPerBucket);
            matrix.Pool = new(maxArrayLength, maxArraysPerBucket);
        }
        public static MatrixExpression Abs(MatrixExpression m) => new MatrixAbs(m);
        public static MatrixExpression Sqr(MatrixExpression m) => new MatrixSqr(m);
        public static MatrixExpression Sqrt(MatrixExpression m) => new MatrixSqrt(m);
        public static MatrixExpression Inv(MatrixExpression m) => new MatrixInv(m);
        public static MatrixExpression InvSqrt(MatrixExpression m) => new MatrixInvSqrt(m);
        public static MatrixExpression Cbrt(MatrixExpression m) => new MatrixCbrt(m);
        public static MatrixExpression InvCbrt(MatrixExpression m) => new MatrixInvCbrt(m);
        public static MatrixExpression Pow2o3(MatrixExpression m) => new MatrixPow2o3(m);
        public static MatrixExpression Pow3o2(MatrixExpression m) => new MatrixPow3o2(m);
        public static MatrixExpression Exp(MatrixExpression m) => new MatrixExp(m);
        public static MatrixExpression Exp2(MatrixExpression m) => new MatrixExp2(m);
        public static MatrixExpression Exp10(MatrixExpression m) => new MatrixExp10(m);
        public static MatrixExpression Expm1(MatrixExpression m) => new MatrixExpm1(m);
        public static MatrixExpression Ln(MatrixExpression m) => new MatrixLn(m);
        public static MatrixExpression Log2(MatrixExpression m) => new MatrixLog2(m);
        public static MatrixExpression Log10(MatrixExpression m) => new MatrixLog10(m);
        public static MatrixExpression Log1p(MatrixExpression m) => new MatrixLog1p(m);
        public static MatrixExpression Logb(MatrixExpression m) => new MatrixLogb(m);
        public static MatrixExpression Cos(MatrixExpression m) => new MatrixCos(m);
        public static MatrixExpression Sin(MatrixExpression m) => new MatrixSin(m);
        public static MatrixExpression Tan(MatrixExpression m) => new MatrixTan(m);
        public static MatrixExpression Cospi(MatrixExpression m) => new MatrixCospi(m);
        public static MatrixExpression Sinpi(MatrixExpression m) => new MatrixSinpi(m);
        public static MatrixExpression Tanpi(MatrixExpression m) => new MatrixTanpi(m);
        public static MatrixExpression Cosd(MatrixExpression m) => new MatrixCosd(m);
        public static MatrixExpression Sind(MatrixExpression m) => new MatrixSind(m);
        public static MatrixExpression Tand(MatrixExpression m) => new MatrixTand(m);
        public static MatrixExpression Acos(MatrixExpression m) => new MatrixAcos(m);
        public static MatrixExpression Asin(MatrixExpression m) => new MatrixAsin(m);
        public static MatrixExpression Atan(MatrixExpression m) => new MatrixAtan(m);
        public static MatrixExpression Acospi(MatrixExpression m) => new MatrixAcospi(m);
        public static MatrixExpression Asinpi(MatrixExpression m) => new MatrixAsinpi(m);
        public static MatrixExpression Atanpi(MatrixExpression m) => new MatrixAtanpi(m);
        public static MatrixExpression Cosh(MatrixExpression m) => new MatrixCosh(m);
        public static MatrixExpression Sinh(MatrixExpression m) => new MatrixSinh(m);
        public static MatrixExpression Tanh(MatrixExpression m) => new MatrixTanh(m);
        public static MatrixExpression Acosh(MatrixExpression m) => new MatrixAcosh(m);
        public static MatrixExpression Asinh(MatrixExpression m) => new MatrixAsinh(m);
        public static MatrixExpression Atanh(MatrixExpression m) => new MatrixAtanh(m);
        public static MatrixExpression Erf(MatrixExpression m) => new MatrixErf(m);
        public static MatrixExpression Erfc(MatrixExpression m) => new MatrixErfc(m);
        public static MatrixExpression ErfInv(MatrixExpression m) => new MatrixErfInv(m);
        public static MatrixExpression ErfcInv(MatrixExpression m) => new MatrixErfcInv(m);
        public static MatrixExpression CdfNorm(MatrixExpression m) => new MatrixCdfNorm(m);
        public static MatrixExpression CdfNormInv(MatrixExpression m) => new MatrixCdfNormInv(m);
        public static MatrixExpression LGamma(MatrixExpression m) => new MatrixLGamma(m);
        public static MatrixExpression TGamma(MatrixExpression m) => new MatrixTGamma(m);
        public static MatrixExpression ExpInt1(MatrixExpression m) => new MatrixExpInt1(m);
        public static MatrixExpression Floor(MatrixExpression m) => new MatrixFloor(m);
        public static MatrixExpression Ceil(MatrixExpression m) => new MatrixCeil(m);
        public static MatrixExpression Truncate(MatrixExpression m) => new MatrixTrunc(m);
        public static MatrixExpression Round(MatrixExpression m) => new MatrixNearbyInt(m);
        public static MatrixExpression RoundAwayFromZero(MatrixExpression m) => new MatrixRound(m);
        public static MatrixExpression Frac(MatrixExpression m) => new MatrixFrac(m);
        public static MatrixExpression NearbyInt(MatrixExpression m) => new MatrixNearbyInt(m);
        public static MatrixExpression Rint(MatrixExpression m) => new MatrixRint(m);
        public static MatrixExpression Powx(MatrixExpression m, double b) => new MatrixPowx(m, b);
        public static MatrixExpression CopySign(MatrixExpression a, MatrixExpression b) => new MatrixCopySign(a, b);
        public static MatrixExpression Max(MatrixExpression a, MatrixExpression b) => new MatrixFmax(a, b);
        public static MatrixExpression Max(MatrixExpression a, double b) => new MatrixMaxScalar(a, b);
        public static MatrixExpression Min(MatrixExpression a, MatrixExpression b) => new MatrixFmin(a, b);
        public static MatrixExpression Min(MatrixExpression a, double b) => new MatrixMinScalar(a, b);
        public static MatrixExpression Fdim(MatrixExpression a, MatrixExpression b) => new MatrixFdim(a, b);
        public static MatrixExpression MaxMag(MatrixExpression a, MatrixExpression b) => new MatrixMaxMag(a, b);
        public static MatrixExpression NextAfter(MatrixExpression a, MatrixExpression b) => new MatrixNextAfter(a, b);
        public static MatrixExpression Mul(MatrixExpression a, MatrixExpression b) => new MatrixMul(a, b);
        public static MatrixExpression Fmod(MatrixExpression a, MatrixExpression b) => new MatrixFmod(a, b);
        public static MatrixExpression Atan2(MatrixExpression a, MatrixExpression b) => new MatrixAtan2(a, b);
        public static MatrixExpression Atan2pi(MatrixExpression a, MatrixExpression b) => new MatrixAtan2pi(a, b);
        public static MatrixExpression Powr(MatrixExpression a, MatrixExpression b) => new MatrixPowr(a, b);
        public static MatrixExpression Remainder(MatrixExpression a, MatrixExpression b) => new MatrixRemainder(a, b);
        public static MatrixExpression Hypot(MatrixExpression a, MatrixExpression b) => new MatrixHypot(a, b);
        public static MatrixExpression Div(MatrixExpression a, MatrixExpression b) => new MatrixDiv(a, b);
        public static MatrixExpression Pow(MatrixExpression a, MatrixExpression b) => new MatrixPow(a, b);
        public static MatrixExpression LinearFrac(MatrixExpression a, MatrixExpression b, double scalea, double shifta, double scaleb, double shiftb)
            => new MatrixLinearFrac(a, b, scalea, shifta, scaleb, shiftb);
        public static MatrixExpression Lower(MatrixExpression a) => new MatrixLower(a);
        public static MatrixExpression Upper(MatrixExpression a) => new MatrixUpper(a);
        public static MatrixExpression Cholesky(MatrixExpression a) => new MatrixCholesky(a);
        public static MatrixExpression Solve(MatrixExpression a, MatrixExpression b) => new MatrixSolve(a, b);
        public static MatrixExpression Inverse(MatrixExpression a) => new MatrixInverse(a);
        public static MatrixExpression LeastSquares(MatrixExpression a, MatrixExpression b) => new MatrixLeastSquares(a, b);

        public static double Asum(MatrixExpression a)
        {
            var i = a.Evaluate();
            var r = Blas.asum(i.Length, i.Array, 0, 1);
            if (a is not MatrixInput) i.Dispose();
            return r;
        }

        public static double Nrm2(MatrixExpression a)
        {
            var i = a.Evaluate();
            var r = Blas.nrm2(i.Length, i.Array, 0, 1);
            if (a is not MatrixInput) i.Dispose();
            return r;
        }

        public static (int, int) Iamax(MatrixExpression a)
        {
            var i = a.Evaluate();
            int r = Blas.iamax(i.Length, i.Array, 0, 1);
            if (a is not MatrixInput) i.Dispose();
            int col = Math.DivRem(r, i.Rows, out int row);
            return (row, col);
        }

        public static (int, int) Iamin(MatrixExpression a)
        {
            var i = a.Evaluate();
            int r = Blas.iamin(i.Length, i.Array, 0, 1);
            if (a is not MatrixInput) i.Dispose();
            int col = Math.DivRem(r, i.Rows, out int row);
            return (row, col);
        }

        public static matrix Copy(matrix a)
        {
            var r = new matrix(a.Rows, a.Cols);
            Blas.copy(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static (matrix, matrix) SinCos(MatrixExpression a)
        {
            var sin = a.Evaluate();
            if (a is MatrixInput) sin = Copy(sin);
            var cos = new matrix(sin.Rows, sin.Cols);
            Vml.SinCos(sin.Length, sin.Array, sin.Array, cos.Array);
            return (sin, cos);
        }

        public static double Det(MatrixExpression a)
        {
            var m = a.Evaluate();
            if (a is MatrixInput) m = Copy(m);
            var ipiv = Pool.Int.Rent(m.Rows);
            ThrowHelper.Check(Lapack.getrf(Layout.ColMajor, m.Rows, m.Rows, m.Array, m.Rows, ipiv));
            Pool.Int.Return(ipiv);
            double r = m[0, 0];
            for (int i = 1; i < m.Rows; i++)
                r *= m[i, i];
            m.Dispose();
            return -r;
        }

        public static (matrix, matrix) Modf(MatrixExpression a)
        {
            var tru = a.Evaluate();
            if (a is MatrixInput) tru = Copy(tru);
            var rem = new matrix(tru.Rows, tru.Cols);
            Vml.Modf(tru.Length, tru.Array, tru.Array, rem.Array);
            return (tru, rem);
        }

        public static (matrix, vector) Eigens(MatrixExpression a)
        {
            var v = a.Evaluate();
            if (v.Rows != v.Cols) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            if (a is MatrixInput) v = Copy(v);
            var w = new vector(v.Rows);
            ThrowHelper.Check(Lapack.syev(Layout.ColMajor, 'V', UpLoChar.Lower, v.Rows, v.Array, v.Rows, w.Array));
            return (v, w);
        }

        public static MatrixExpression Identity(int n)
        {
            var m = new matrix(n, n);
            var a = m.Array;
            for (int i = 0; i < n * n; i++)
                a[i] = i % (n + 1) == 0 ? 1 : 0;
            return new MatrixReuse(m);
        }

        /// <summary>
        /// Multiply for a symmetric matrix S. c = S * b
        /// </summary>
        /// <param name="A"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        public static void Symmetric_Multiply_Update(matrix S, vector b, vector c)
        {
            Blas.symm(Layout.ColMajor, Side.Left, UpLo.Lower, b.Length, 1, 1, S.Array, S.Rows, b.Array, b.Length, 0, c.Array, c.Length);
        }

        /// <summary>
        /// Performs a symmetric rank-k update. C = alpha * A * A.T + beta * C.
        /// </summary>
        /// <param name="alpha"></param>
        /// <param name="A"></param>
        /// <param name="beta"></param>
        /// <param name="C"></param>
        public static void Symmetric_Rank_k_Update(double alpha, matrix A, double beta, matrix C)
        {
            Blas.syrk(Layout.ColMajor, UpLo.Lower, Trans.No, A.Rows, A.Cols, alpha, A.Array, A.Rows, beta, C.Array, C.Rows);
        }

        /// <summary>
        /// Performs a symmetric rank-k update. C = alpha * A * A.T + beta * C.
        /// </summary>
        /// <param name="alpha"></param>
        /// <param name="A"></param>
        /// <param name="beta"></param>
        /// <param name="C"></param>
        public static void Symmetric_Rank_k_Update(double alpha, vector A, double beta, matrix C)
        {
            Blas.syrk(Layout.ColMajor, UpLo.Lower, Trans.No, A.Length, 1, alpha, A.Array, A.Length, beta, C.Array, C.Rows);
        }

        /// <summary>
        /// Performs a symmetric rank-2k update. C = alpha * A * B.T + alpha * B * A.T + beta * C.
        /// </summary>
        /// <param name="alpha"></param>
        /// <param name="A"></param>
        /// <param name="beta"></param>
        /// <param name="C"></param>
        public static void Symmetric_Rank_2k_Update(double alpha, matrix A, matrix B, double beta, matrix C)
        {
            Blas.syr2k(Layout.ColMajor, UpLo.Lower, Trans.No, A.Rows, A.Cols, alpha, A.Array, A.Rows, B.Array, B.Rows, beta, C.Array, C.Rows);
        }

        /// <summary>
        /// Performs a symmetric rank-2k update. C = alpha * A * B.T + alpha * B * A.T + beta * C.
        /// </summary>
        /// <param name="alpha"></param>
        /// <param name="A"></param>
        /// <param name="beta"></param>
        /// <param name="C"></param>
        public static void Symmetric_Rank_2k_Update(double alpha, vector A, vector B, double beta, matrix C)
        {
            Blas.syr2k(Layout.ColMajor, UpLo.Lower, Trans.No, A.Length, 1, alpha, A.Array, A.Length, B.Array, B.Length, beta, C.Array, C.Rows);
        }
    }
}