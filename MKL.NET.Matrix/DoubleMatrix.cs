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
        public MatrixExpression T => new MatrixTranspose(this, 1.0);
        public static MatrixExpression operator +(matrix a, double s) => new MatrixAddScalar(a, s);
        public static MatrixExpression operator +(double s, matrix a) => new MatrixAddScalar(a, s);
        public static MatrixExpression operator -(matrix a, double s) => new MatrixAddScalar(a, -s);
        public static MatrixExpression operator -(double s, matrix a) => s - (MatrixExpression)a;
        public static MatrixExpression operator +(matrix a, matrix b) => new MatrixAddSimple(a, b);
        public static MatrixExpression operator +(matrix a, MatrixExpression b) => (MatrixExpression)a + b;
        public static MatrixExpression operator +(MatrixExpression a, matrix b) => a + (MatrixExpression)b;
        public static MatrixExpression operator -(matrix a, matrix b) => new MatrixSubSimple(a, b);
        public static MatrixExpression operator -(MatrixExpression a, matrix b) => a - (MatrixExpression)b;
        public static MatrixExpression operator -(matrix a, MatrixExpression b) => (MatrixExpression)a - b;
        public static MatrixExpression operator *(matrix a, double s) => new MatrixScale(a, s);
        public static MatrixExpression operator *(double s, matrix a) => new MatrixScale(a, s);
        public static MatrixExpression operator *(matrix a, matrix b) => new MatrixMultiply(a, b);
        public static MatrixExpression operator *(matrix a, MatrixExpression b) => new MatrixMultiply(a, b);
        public static MatrixExpression operator *(MatrixExpression a, matrix b) => new MatrixMultiply(a, b);
        public static VectorExpression operator *(matrix m, vector v) => new MatrixVectorMultiply(m, v);
        public static VectorExpression operator *(matrix m, VectorExpression v) => new MatrixVectorMultiply(m, v);
        public static VectorTExpression operator *(vectorT vt, matrix m) => new VectorTMatrixMultiply(vt, m);
        public static VectorTExpression operator *(VectorTExpression vt, matrix m) => new VectorTMatrixMultiply(vt, m);
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
        public static MatrixExpression Trunc(MatrixExpression m) => new MatrixTrunc(m);
        public static MatrixExpression Round(MatrixExpression m) => new MatrixRound(m);
        public static MatrixExpression Frac(MatrixExpression m) => new MatrixFrac(m);
        public static MatrixExpression NearbyInt(MatrixExpression m) => new MatrixNearbyInt(m);
        public static MatrixExpression Rint(MatrixExpression m) => new MatrixRint(m);
        public static MatrixExpression Powx(MatrixExpression m, double b) => new MatrixPowx(m, b);
        public static MatrixExpression CopySign(MatrixExpression a, MatrixExpression b) => new MatrixCopySign(a, b);
        public static MatrixExpression Fmax(MatrixExpression a, MatrixExpression b) => new MatrixFmax(a, b);
        public static MatrixExpression Fmin(MatrixExpression a, MatrixExpression b) => new MatrixFmin(a, b);
        public static MatrixExpression Fdim(MatrixExpression a, MatrixExpression b) => new MatrixFdim(a, b);
        public static MatrixExpression MaxMag(MatrixExpression a, MatrixExpression b) => new MatrixMaxMag(a, b);
        public static MatrixExpression NextAfter(MatrixExpression a, MatrixExpression b) => new MatrixNextAfter(a, b);
        public static MatrixExpression Dot(MatrixExpression a, MatrixExpression b) => new MatrixDot(a, b);
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
            var i = a.EvaluateMatrix();
            var r = Blas.asum(i.Length, i.Array, 0, 1);
            if (a is not MatrixInput) i.Dispose();
            return r;
        }

        public static double Nrm2(MatrixExpression a)
        {
            var i = a.EvaluateMatrix();
            var r = Blas.nrm2(i.Length, i.Array, 0, 1);
            if (a is not MatrixInput) i.Dispose();
            return r;
        }

        public static (int, int) Iamax(MatrixExpression a)
        {
            var i = a.EvaluateMatrix();
            int r = Blas.iamax(i.Length, i.Array, 0, 1);
            if (a is not MatrixInput) i.Dispose();
            int col = Math.DivRem(r, i.Rows, out int row);
            return (row, col);
        }

        public static (int, int) Iamin(MatrixExpression a)
        {
            var i = a.EvaluateMatrix();
            int r = Blas.iamin(i.Length, i.Array, 0, 1);
            if (a is not MatrixInput) i.Dispose();
            int col = Math.DivRem(r, i.Rows, out int row);
            return (row, col);
        }

        public static (matrix, matrix) SinCos(MatrixExpression a)
        {
            var i = a.EvaluateMatrix();
            var sin = a is MatrixInput ? new matrix(i.Rows, i.Cols) : i;
            var cos = new matrix(i.Rows, i.Cols);
            Vml.SinCos(i.Length, i.Array, 0, 1, sin.Array, 0, 1, cos.Array, 0, 1);
            return (sin, cos);
        }

        public static (matrix, matrix) Modf(MatrixExpression a)
        {
            var i = a.EvaluateMatrix();
            var tru = a is MatrixInput ? new matrix(i.Rows, i.Cols) : i;
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
            var v = a is MatrixInput ? new matrix(i.Rows, i.Cols) : i;
            var w = new vector(i.Rows);
            ThrowHelper.Check(Lapack.syev(Layout.ColMajor, 'V', UpLoChar.Lower, v.Rows, v.Array, v.Rows, w.Array));
            return (v, w);
        }
    }
}