using System;
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
        public double[] Reuse()
        {
            GC.SuppressFinalize(this);
            return Array;
        }
        ~matrix() => Pool.Return(Array);
        public MatrixTranspose T => new(this);
        public static MatrixAddScalar operator +(matrix m, double s) => new(m, s);
        public static MatrixAddScalar operator +(double s, matrix m) => new(m, s);
        public static MatrixAddScalar operator -(matrix m, double s) => new(m, -s);
        public static MatrixScalarSub operator -(double s, matrix m) => new(m, s);
        public static MatrixAdd operator +(matrix a, matrix b) => new(a, b);
        public static MatrixSub operator -(matrix a, matrix b) => new(a, b);
        public static MatrixScale operator *(matrix a, double s) => new(a, s);
        public static MatrixScale operator *(double s, matrix a) => new(a, s);
        public static MatrixMultiply operator *(matrix a, MatrixExpression b) => new(a, b);
        public static MatrixVectorMultiply operator *(matrix m, VectorExpression v) => new(m, v);
    }

    public static class Matrix
    {
        public static void ResetPools(int maxArrayLength, int maxArraysPerBucket)
        {
            Pool.Int = new(maxArrayLength, maxArraysPerBucket);
            matrix.Pool = new(maxArrayLength, maxArraysPerBucket);
        }
        public static MatrixAbs Abs(MatrixExpression m) => new(m);
        public static MatrixSqr Sqr(MatrixExpression m) => new(m);
        public static MatrixInv Inv(MatrixExpression m) => new(m);
        public static MatrixInvSqrt InvSqrt(MatrixExpression m) => new(m);
        public static MatrixCbrt Cbrt(MatrixExpression m) => new(m);
        public static MatrixInvCbrt InvCbrt(MatrixExpression m) => new(m);
        public static MatrixPow2o3 Pow2o3(MatrixExpression m) => new(m);
        public static MatrixPow3o2 Pow3o2(MatrixExpression m) => new(m);
        public static MatrixExp Exp(MatrixExpression m) => new(m);
        public static MatrixExp2 Exp2(MatrixExpression m) => new(m);
        public static MatrixExp10 Exp10(MatrixExpression m) => new(m);
        public static MatrixExpm1 Expm1(MatrixExpression m) => new(m);
        public static MatrixLn Ln(MatrixExpression m) => new(m);
        public static MatrixLog2 Log2(MatrixExpression m) => new(m);
        public static MatrixLog10 Log10(MatrixExpression m) => new(m);
        public static MatrixLog1p Log1p(MatrixExpression m) => new(m);
        public static MatrixLogb Logb(MatrixExpression m) => new(m);
        public static MatrixCos Cos(MatrixExpression m) => new(m);
        public static MatrixSin Sin(MatrixExpression m) => new(m);
        public static MatrixTan Tan(MatrixExpression m) => new(m);
        public static MatrixCospi Cospi(MatrixExpression m) => new(m);
        public static MatrixSinpi Sinpi(MatrixExpression m) => new(m);
        public static MatrixTanpi Tanpi(MatrixExpression m) => new(m);
        public static MatrixCosd Cosd(MatrixExpression m) => new(m);
        public static MatrixSind Sind(MatrixExpression m) => new(m);
        public static MatrixTand Tand(MatrixExpression m) => new(m);
        public static MatrixAcos Acos(MatrixExpression m) => new(m);
        public static MatrixAsin Asin(MatrixExpression m) => new(m);
        public static MatrixAtan Atan(MatrixExpression m) => new(m);
        public static MatrixAcospi Acospi(MatrixExpression m) => new(m);
        public static MatrixAsinpi Asinpi(MatrixExpression m) => new(m);
        public static MatrixAtanpi Atanpi(MatrixExpression m) => new(m);
        public static MatrixCosh Cosh(MatrixExpression m) => new(m);
        public static MatrixSinh Sinh(MatrixExpression m) => new(m);
        public static MatrixTanh Tanh(MatrixExpression m) => new(m);
        public static MatrixAcosh Acosh(MatrixExpression m) => new(m);
        public static MatrixAsinh Asinh(MatrixExpression m) => new(m);
        public static MatrixAtanh Atanh(MatrixExpression m) => new(m);
        public static MatrixErf Erf(MatrixExpression m) => new(m);
        public static MatrixErfc Erfc(MatrixExpression m) => new(m);
        public static MatrixErfInv ErfInv(MatrixExpression m) => new(m);
        public static MatrixErfcInv ErfcInv(MatrixExpression m) => new(m);
        public static MatrixCdfNorm CdfNorm(MatrixExpression m) => new(m);
        public static MatrixCdfNormInv CdfNormInv(MatrixExpression m) => new(m);
        public static MatrixLGamma LGamma(MatrixExpression m) => new(m);
        public static MatrixTGamma TGamma(MatrixExpression m) => new(m);
        public static MatrixExpInt1 ExpInt1(MatrixExpression m) => new(m);
        public static MatrixFloor Floor(MatrixExpression m) => new(m);
        public static MatrixCeil Ceil(MatrixExpression m) => new(m);
        public static MatrixTrunc Trunc(MatrixExpression m) => new(m);
        public static MatrixRound Round(MatrixExpression m) => new(m);
        public static MatrixFrac Frac(MatrixExpression m) => new(m);
        public static MatrixNearbyInt NearbyInt(MatrixExpression m) => new(m);
        public static MatrixRint Rint(MatrixExpression m) => new(m);
        public static MatrixPowx Powx(MatrixExpression m, double b) => new(m, b);
        public static MatrixCopySign CopySign(MatrixExpression a, MatrixExpression b) => new(a, b);
        public static MatrixFmax Fmax(MatrixExpression a, MatrixExpression b) => new(a, b);
        public static MatrixFmin Fmin(MatrixExpression a, MatrixExpression b) => new(a, b);
        public static MatrixFdim Fdim(MatrixExpression a, MatrixExpression b) => new(a, b);
        public static MatrixMaxMag MaxMag(MatrixExpression a, MatrixExpression b) => new(a, b);
        public static MatrixNextAfter NextAfter(MatrixExpression a, MatrixExpression b) => new(a, b);
        public static MatrixDot Dot(MatrixExpression a, MatrixExpression b) => new(a, b);
        public static MatrixFmod Fmod(MatrixExpression a, MatrixExpression b) => new(a, b);
        public static MatrixAtan2 Atan2(MatrixExpression a, MatrixExpression b) => new(a, b);
        public static MatrixAtan2pi Atan2pi(MatrixExpression a, MatrixExpression b) => new(a, b);
        public static MatrixPowr Powr(MatrixExpression a, MatrixExpression b) => new(a, b);
        public static MatrixRemainder Remainder(MatrixExpression a, MatrixExpression b) => new(a, b);
        public static MatrixHypot Hypot(MatrixExpression a, MatrixExpression b) => new(a, b);
        public static MatrixDiv Div(MatrixExpression a, MatrixExpression b) => new(a, b);
        public static MatrixPow Pow(MatrixExpression a, MatrixExpression b) => new(a, b);
        public static MatrixLinearFrac LinearFrac(MatrixExpression a, MatrixExpression b, double scalea, double shifta, double scaleb, double shiftb)
            => new(a, b, scalea, shifta, scaleb, shiftb);
        public static MatrixLower Lower(MatrixExpression a) => new(a);
        public static MatrixUpper Upper(MatrixExpression a) => new(a);
        public static MatrixCholesky Cholesky(MatrixExpression a) => new(a);
        public static MatrixSolve Solve(MatrixExpression a, MatrixExpression b) => new(a, b);
        public static MatrixInverse Inverse(MatrixExpression a) => new(a);
        public static MatrixLeastSquares LeastSquares(MatrixExpression a, MatrixExpression b) => new(a, b);

        public static double Asum(MatrixExpression a)
        {
            var i = a.EvaluateMatrix();
            var r = Blas.asum(i.Length, i.Array, 0, 1);
            if (a is not Input) i.Dispose();
            return r;
        }

        public static double Nrm2(MatrixExpression a)
        {
            var i = a.EvaluateMatrix();
            var r = Blas.nrm2(i.Length, i.Array, 0, 1);
            if (a is not Input) i.Dispose();
            return r;
        }

        public static (int, int) Iamax(MatrixExpression a)
        {
            var i = a.EvaluateMatrix();
            int r = Blas.iamax(i.Length, i.Array, 0, 1);
            if (a is not Input) i.Dispose();
            int col = Math.DivRem(r, i.Rows, out int row);
            return (row, col);
        }

        public static (int, int) Iamin(MatrixExpression a)
        {
            var i = a.EvaluateMatrix();
            int r = Blas.iamin(i.Length, i.Array, 0, 1);
            if (a is not Input) i.Dispose();
            int col = Math.DivRem(r, i.Rows, out int row);
            return (row, col);
        }

        public static (matrix, matrix) SinCos(MatrixExpression a)
        {
            var i = a.EvaluateMatrix();
            var sin = a is Input ? new matrix(i.Rows, i.Cols) : i;
            var cos = new matrix(i.Rows, i.Cols);
            Vml.SinCos(i.Length, i.Array, 0, 1, sin.Array, 0, 1, cos.Array, 0, 1);
            return (sin, cos);
        }

        public static (matrix, matrix) Modf(MatrixExpression a)
        {
            var i = a.EvaluateMatrix();
            var tru = a is Input ? new matrix(i.Rows, i.Cols) : i;
            var rem = new matrix(i.Rows, i.Cols);
            Vml.Modf(i.Length, i.Array, 0, 1, tru.Array, 0, 1, rem.Array, 0, 1);
            return (tru, rem);
        }

        public static matrix Copy(matrix a)
        {
            var r = new matrix(a.Rows, a.Cols);
            Blas.copy(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static (matrix, vector) Eigens(MatrixExpression a)
        {
            var i = a.EvaluateMatrix();
            if (i.Rows != i.Cols) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var v = a is Input ? new matrix(i.Rows, i.Cols) : i;
            var w = new vector(i.Rows);
            ThrowHelper.Check(Lapack.syev(Layout.ColMajor, 'V', UpLoChar.Lower, v.Rows, v.Array, v.Rows, w.Array));
            return (v, w);
        }
    }
}