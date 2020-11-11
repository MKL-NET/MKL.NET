using System;
using System.Buffers;

namespace MKLNET
{
    public static class Matrix
    {
        public static class Inplace
        {
            public static void Abs(matrix a)
            {
                Vml.Abs(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            }

            public static void Add(matrix a, matrix b)
            {
                Vml.Add(a.Length, a.Array, 0, 1, b.Array, 0, 1, a.Array, 0, 1);
            }

            public static void Sub(matrix a, matrix b)
            {
                Vml.Sub(a.Length, a.Array, 0, 1, b.Array, 0, 1, a.Array, 0, 1);
            }

            public static void Sqr(matrix a)
            {
                Vml.Sqr(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            }

            public static void Mul(matrix a, matrix b)
            {
                Vml.Mul(a.Length, a.Array, 0, 1, b.Array, 0, 1, a.Array, 0, 1);
            }

            public static void Fmod(matrix a, matrix b)
            {
                Vml.Fmod(a.Length, a.Array, 0, 1, b.Array, 0, 1, a.Array, 0, 1);
            }

            public static void Remainder(matrix a, matrix b)
            {
                Vml.Remainder(a.Length, a.Array, 0, 1, b.Array, 0, 1, a.Array, 0, 1);
            }

            public static void Inv(matrix a)
            {
                Vml.Inv(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            }

            public static void Sqrt(matrix a)
            {
                Vml.Sqrt(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            }

            public static void InvSqrt(matrix a)
            {
                Vml.InvSqrt(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            }

            public static void Cbrt(matrix a)
            {
                Vml.Cbrt(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            }

            public static void InvCbrt(matrix a)
            {
                Vml.InvCbrt(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            }

            public static void Hypot(matrix a, matrix b)
            {
                Vml.Hypot(a.Length, a.Array, 0, 1, b.Array, 0, 1, a.Array, 0, 1);
            }

            public static void Div(matrix a, matrix b)
            {
                Vml.Div(a.Length, a.Array, 0, 1, b.Array, 0, 1, a.Array, 0, 1);
            }

            public static void Pow2o3(matrix a)
            {
                Vml.Pow2o3(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            }

            public static void Pow3o2(matrix a)
            {
                Vml.Pow3o2(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            }

            public static void Pow(matrix a, matrix b)
            {
                Vml.Pow(a.Length, a.Array, 0, 1, b.Array, 0, 1, a.Array, 0, 1);
            }

            public static void Powr(matrix a, matrix b)
            {
                Vml.Powr(a.Length, a.Array, 0, 1, b.Array, 0, 1, a.Array, 0, 1);
            }

            public static void Exp(matrix a)
            {
                Vml.Exp(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            }

            public static void Exp2(matrix a)
            {
                Vml.Exp2(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            }

            public static void Exp10(matrix a)
            {
                Vml.Exp10(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            }

            public static void Expm1(matrix a)
            {
                Vml.Expm1(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            }

            public static void Ln(matrix a)
            {
                Vml.Ln(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            }

            public static void Log2(matrix a)
            {
                Vml.Log2(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            }

            public static void Log10(matrix a)
            {
                Vml.Log10(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            }

            public static void Log1p(matrix a)
            {
                Vml.Log1p(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            }

            public static void Logb(matrix a)
            {
                Vml.Logb(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            }

            public static void Cos(matrix a)
            {
                Vml.Cos(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            }

            public static void Sin(matrix a)
            {
                Vml.Sin(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            }

            public static void Tan(matrix a)
            {
                Vml.Tan(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            }

            public static void Cospi(matrix a)
            {
                Vml.Cospi(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            }

            public static void Sinpi(matrix a)
            {
                Vml.Sinpi(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            }

            public static void Tanpi(matrix a)
            {
                Vml.Tanpi(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            }

            public static void Cosd(matrix a)
            {
                Vml.Cosd(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            }

            public static void Sind(matrix a)
            {
                Vml.Sind(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            }

            public static void Tand(matrix a)
            {
                Vml.Tand(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            }

            public static void Acos(matrix a)
            {
                Vml.Acos(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            }

            public static void Asin(matrix a)
            {
                Vml.Asin(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            }

            public static void Atan(matrix a)
            {
                Vml.Atan(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            }

            public static void Acospi(matrix a)
            {
                Vml.Acospi(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            }

            public static void Asinpi(matrix a)
            {
                Vml.Asinpi(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            }

            public static void Atanpi(matrix a)
            {
                Vml.Atanpi(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            }

            public static void Atan2(matrix a, matrix b)
            {
                Vml.Atan2(a.Length, a.Array, 0, 1, b.Array, 0, 1, a.Array, 0, 1);
            }

            public static void Atan2pi(matrix a, matrix b)
            {
                Vml.Atan2pi(a.Length, a.Array, 0, 1, b.Array, 0, 1, a.Array, 0, 1);
            }

            public static void Cosh(matrix a)
            {
                Vml.Cosh(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            }

            public static void Sinh(matrix a)
            {
                Vml.Sinh(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            }

            public static void Tanh(matrix a)
            {
                Vml.Tanh(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            }

            public static void Acosh(matrix a)
            {
                Vml.Acosh(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            }

            public static void Asinh(matrix a)
            {
                Vml.Asinh(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            }

            public static void Atanh(matrix a)
            {
                Vml.Atanh(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            }

            public static void Erf(matrix a)
            {
                Vml.Erf(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            }

            public static void Erfc(matrix a)
            {
                Vml.Erfc(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            }

            public static void ErfInv(matrix a)
            {
                Vml.ErfInv(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            }

            public static void ErfcInv(matrix a)
            {
                Vml.ErfcInv(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            }

            public static void CdfNorm(matrix a)
            {
                Vml.CdfNorm(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            }

            public static void CdfNormInv(matrix a)
            {
                Vml.CdfNormInv(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            }

            public static void LGamma(matrix a)
            {
                Vml.LGamma(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            }

            public static void TGamma(matrix a)
            {
                Vml.TGamma(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            }

            public static void ExpInt1(matrix a)
            {
                Vml.ExpInt1(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            }

            public static void Floor(matrix a)
            {
                Vml.Floor(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            }

            public static void Ceil(matrix a)
            {
                Vml.Ceil(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            }

            public static void Trunc(matrix a)
            {
                Vml.Trunc(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            }

            public static void Round(matrix a)
            {
                Vml.Round(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            }

            public static void Frac(matrix a)
            {
                Vml.Frac(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            }

            public static void NearbyInt(matrix a)
            {
                Vml.NearbyInt(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            }

            public static void Rint(matrix a)
            {
                Vml.Rint(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            }

            public static void CopySign(matrix a, matrix b)
            {
                Vml.CopySign(a.Length, a.Array, 0, 1, b.Array, 0, 1, a.Array, 0, 1);
            }

            public static void Fmax(matrix a, matrix b)
            {
                Vml.Fmax(a.Length, a.Array, 0, 1, b.Array, 0, 1, a.Array, 0, 1);
            }

            public static void Fmin(matrix a, matrix b)
            {
                Vml.Fmin(a.Length, a.Array, 0, 1, b.Array, 0, 1, a.Array, 0, 1);
            }

            public static void Fdim(matrix a, matrix b)
            {
                Vml.Fdim(a.Length, a.Array, 0, 1, b.Array, 0, 1, a.Array, 0, 1);
            }

            public static void MaxMag(matrix a, matrix b)
            {
                Vml.MaxMag(a.Length, a.Array, 0, 1, b.Array, 0, 1, a.Array, 0, 1);
            }

            public static void NextAfter(matrix a, matrix b)
            {
                Vml.NextAfter(a.Length, a.Array, 0, 1, b.Array, 0, 1, a.Array, 0, 1);
            }

            public static void Powx(matrix a, double b)
            {
                Vml.Powx(a.Length, a.Array, 0, 1, b, a.Array, 0, 1);
            }

            public static void LinearFrac(matrix a, matrix b, double scalea, double shifta, double scaleb, double shiftb)
            {
                Vml.LinearFrac(a.Length, a.Array, 0, 1, b.Array, 0, 1, scalea, shifta, scaleb, shiftb, a.Array, 0, 1);
            }

            public static matrix SinCos(matrix a)
            {
                var cos = new matrix(a.Rows, a.Cols);
                Vml.SinCos(a.Length, a.Array, 0, 1, a.Array, 0, 1, cos.Array, 0, 1);
                return cos;
            }

            public static matrix Modf(matrix a)
            {
                var rem = new matrix(a.Rows, a.Cols);
                Vml.Modf(a.Length, a.Array, 0, 1, a.Array, 0, 1, rem.Array, 0, 1);
                return rem;
            }

            public static void Scal(matrix a, double s)
            {
                Blas.scal(a.Length, s, a.Array, 0, 1);
            }

            public static void Lower(matrix a)
            {
                for (int c = 1; c < a.Cols; c++)
                    for (int r = 0; r < c; r++)
                        a[r, c] = 0.0;
            }

            public static void Upper(matrix a)
            {
                for (int c = 0; c < a.Cols; c++)
                    for (int r = c + 1; r < a.Rows; r++)
                        a[r, c] = 0.0;
            }

            public static void Cholesky(matrix a)
            {
                if (a.Rows != a.Cols) ThrowHelper.ThrowIncorrectMatrixDimensionsForOperation();
                Lower(a);
                ThrowHelper.Check(Lapack.potrf2(Layout.ColMajor, UpLoChar.Lower, a.Rows, a.Array, a.Rows));
            }

            public static void Solve(matrix a, matrix b)
            {
                if (a.Rows != a.Cols || a.Rows != b.Rows) ThrowHelper.ThrowIncorrectMatrixDimensionsForOperation();
                var ipiv = ArrayPool<int>.Shared.Rent(a.Rows);
                ThrowHelper.Check(Lapack.gesv(Layout.ColMajor, a.Rows, b.Cols, a.Array, a.Rows, ipiv, b.Array, a.Rows));
                ArrayPool<int>.Shared.Return(ipiv);
            }

            public static void Solve(matrix a, vector b)
            {
                if (a.Rows != a.Cols || a.Rows != b.Length) ThrowHelper.ThrowIncorrectMatrixDimensionsForOperation();
                var ipiv = ArrayPool<int>.Shared.Rent(a.Rows);
                ThrowHelper.Check(Lapack.gesv(Layout.ColMajor, a.Rows, 1, a.Array, a.Rows, ipiv, b.Array, a.Rows));
                ArrayPool<int>.Shared.Return(ipiv);
            }

            public static void Inverse(matrix a)
            {
                if (a.Rows != a.Cols) ThrowHelper.ThrowIncorrectMatrixDimensionsForOperation();
                var ipiv = ArrayPool<int>.Shared.Rent(a.Rows);
                ThrowHelper.Check(Lapack.getrf(Layout.ColMajor, a.Rows, a.Rows, a.Array, a.Rows, ipiv));
                ThrowHelper.Check(Lapack.getri(Layout.ColMajor, a.Rows, a.Array, a.Rows, ipiv));
                ArrayPool<int>.Shared.Return(ipiv);
            }

            public static vector Eigens(matrix a)
            {
                if (a.Rows != a.Cols) ThrowHelper.ThrowIncorrectMatrixDimensionsForOperation();
                var w = new vector(a.Rows);
                ThrowHelper.Check(Lapack.syev(Layout.ColMajor, 'V', UpLoChar.Lower, a.Rows, a.Array, a.Rows, w.Array));
                return w;
            }

            public static void LeastSquares(matrix a, matrix b)
            {
                if (a.Rows != b.Rows || a.Cols > a.Rows) ThrowHelper.ThrowIncorrectMatrixDimensionsForOperation();
                Lapack.gels(Layout.RowMajor, TransChar.No, a.Rows, a.Cols, b.Cols, a.Array, a.Cols, b.Array, b.Cols);
            }
        }

        public static matrix Abs(matrix a)
        {
            var r = new matrix(a.Rows, a.Cols);
            Vml.Abs(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrix Abs(matrixS a)
        {
            matrix r = a;
            Inplace.Abs(r);
            return r;
        }

        public static matrix Abs(matrixT a)
        {
            matrix r = a;
            Inplace.Abs(r);
            return r;
        }

        public static matrix Abs(matrixTS a)
        {
            matrix r = a;
            Inplace.Abs(r);
            return r;
        }

        public static matrix Sqr(matrix a)
        {
            var r = new matrix(a.Rows, a.Cols);
            Vml.Sqr(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrix Sqr(matrixS a)
        {
            matrix r = a;
            Inplace.Sqr(r);
            return r;
        }

        public static matrix Sqr(matrixT a)
        {
            matrix r = a;
            Inplace.Sqr(r);
            return r;
        }

        public static matrix Sqr(matrixTS a)
        {
            matrix r = a;
            Inplace.Sqr(r);
            return r;
        }

        public static matrix Mul(matrix a, matrix b)
        {
            if (a.Rows != b.Rows || a.Cols != b.Cols) ThrowHelper.ThrowIncorrectMatrixDimensionsForOperation();
            var r = new matrix(a.Rows, a.Cols);
            Vml.Mul(a.Length, a.Array, 0, 1, b.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrix Mul(matrixS a, matrix b)
        {
            matrix r = a;
            Inplace.Mul(r, b);
            return r;
        }

        public static matrix Mul(matrixT a, matrix b)
        {
            matrix r = a;
            Inplace.Mul(r, b);
            return r;
        }

        public static matrix Mul(matrixTS a, matrix b)
        {
            matrix r = a;
            Inplace.Mul(r, b);
            return r;
        }

        public static matrix Fmod(matrix a, matrix b)
        {
            if (a.Rows != b.Rows || a.Cols != b.Cols) ThrowHelper.ThrowIncorrectMatrixDimensionsForOperation();
            var r = new matrix(a.Rows, a.Cols);
            Vml.Fmod(a.Length, a.Array, 0, 1, b.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrix Fmod(matrixS a, matrix b)
        {
            matrix r = a;
            Inplace.Fmod(r, b);
            return r;
        }

        public static matrix Fmod(matrixT a, matrix b)
        {
            matrix r = a;
            Inplace.Fmod(r, b);
            return r;
        }

        public static matrix Fmod(matrixTS a, matrix b)
        {
            matrix r = a;
            Inplace.Fmod(r, b);
            return r;
        }

        public static matrix Remainder(matrix a, matrix b)
        {
            if (a.Rows != b.Rows || a.Cols != b.Cols) ThrowHelper.ThrowIncorrectMatrixDimensionsForOperation();
            var r = new matrix(a.Rows, a.Cols);
            Vml.Remainder(a.Length, a.Array, 0, 1, b.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrix Remainder(matrixS a, matrix b)
        {
            matrix r = a;
            Inplace.Remainder(r, b);
            return r;
        }

        public static matrix Remainder(matrixT a, matrix b)
        {
            matrix r = a;
            Inplace.Remainder(r, b);
            return r;
        }

        public static matrix Remainder(matrixTS a, matrix b)
        {
            matrix r = a;
            Inplace.Remainder(r, b);
            return r;
        }

        public static matrix Inv(matrix a)
        {
            var r = new matrix(a.Rows, a.Cols);
            Vml.Inv(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrix Inv(matrixS a)
        {
            matrix r = a;
            Inplace.Inv(r);
            return r;
        }

        public static matrix Inv(matrixT a)
        {
            matrix r = a;
            Inplace.Inv(r);
            return r;
        }

        public static matrix Inv(matrixTS a)
        {
            matrix r = a;
            Inplace.Inv(r);
            return r;
        }

        public static matrix Sqrt(matrix a)
        {
            var r = new matrix(a.Rows, a.Cols);
            Vml.Sqrt(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrix Sqrt(matrixS a)
        {
            matrix r = a;
            Inplace.Sqrt(r);
            return r;
        }

        public static matrix Sqrt(matrixT a)
        {
            matrix r = a;
            Inplace.Sqrt(r);
            return r;
        }

        public static matrix Sqrt(matrixTS a)
        {
            matrix r = a;
            Inplace.Sqrt(r);
            return r;
        }

        public static matrix InvSqrt(matrix m)
        {
            var r = new matrix(m.Rows, m.Cols);
            Vml.InvSqrt(m.Length, m.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrix InvSqrt(matrixS a)
        {
            matrix r = a;
            Inplace.InvSqrt(r);
            return r;
        }

        public static matrix InvSqrt(matrixT a)
        {
            matrix r = a;
            Inplace.InvSqrt(r);
            return r;
        }

        public static matrix InvSqrt(matrixTS a)
        {
            matrix r = a;
            Inplace.InvSqrt(r);
            return r;
        }

        public static matrix Cbrt(matrix a)
        {
            var r = new matrix(a.Rows, a.Cols);
            Vml.Cbrt(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrix Cbrt(matrixS a)
        {
            matrix r = a;
            Inplace.Cbrt(r);
            return r;
        }

        public static matrix Cbrt(matrixT a)
        {
            matrix r = a;
            Inplace.Cbrt(r);
            return r;
        }

        public static matrix Cbrt(matrixTS a)
        {
            matrix r = a;
            Inplace.Cbrt(r);
            return r;
        }

        public static matrix InvCbrt(matrix a)
        {
            var r = new matrix(a.Rows, a.Cols);
            Vml.InvCbrt(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrix InvCbrt(matrixS a)
        {
            matrix r = a;
            Inplace.InvCbrt(r);
            return r;
        }

        public static matrix InvCbrt(matrixT a)
        {
            matrix r = a;
            Inplace.InvCbrt(r);
            return r;
        }

        public static matrix InvCbrt(matrixTS a)
        {
            matrix r = a;
            Inplace.InvCbrt(r);
            return r;
        }

        public static matrix Hypot(matrix a, matrix b)
        {
            if (a.Rows != b.Rows || a.Cols != b.Cols) ThrowHelper.ThrowIncorrectMatrixDimensionsForOperation();
            var r = new matrix(a.Rows, a.Cols);
            Vml.Hypot(a.Length, a.Array, 0, 1, b.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrix Hypot(matrixS a, matrix b)
        {
            matrix r = a;
            Inplace.Hypot(r, b);
            return r;
        }

        public static matrix Hypot(matrixT a, matrix b)
        {
            matrix r = a;
            Inplace.Hypot(r, b);
            return r;
        }

        public static matrix Hypot(matrixTS a, matrix b)
        {
            matrix r = a;
            Inplace.Hypot(r, b);
            return r;
        }

        public static matrix Div(matrix a, matrix b)
        {
            if (a.Rows != b.Rows || a.Cols != b.Cols) ThrowHelper.ThrowIncorrectMatrixDimensionsForOperation();
            var r = new matrix(a.Rows, a.Cols);
            Vml.Div(a.Length, a.Array, 0, 1, b.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrix Div(matrixS a, matrix b)
        {
            matrix r = a;
            Inplace.Div(r, b);
            return r;
        }

        public static matrix Div(matrixT a, matrix b)
        {
            matrix r = a;
            Inplace.Div(r, b);
            return r;
        }

        public static matrix Div(matrixTS a, matrix b)
        {
            matrix r = a;
            Inplace.Div(r, b);
            return r;
        }

        public static matrix Pow2o3(matrix a)
        {
            var r = new matrix(a.Rows, a.Cols);
            Vml.Pow2o3(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrix Pow2o3(matrixS a)
        {
            matrix r = a;
            Inplace.Pow2o3(r);
            return r;
        }

        public static matrix Pow2o3(matrixT a)
        {
            matrix r = a;
            Inplace.Pow2o3(r);
            return r;
        }

        public static matrix Pow2o3(matrixTS a)
        {
            matrix r = a;
            Inplace.Pow2o3(r);
            return r;
        }

        public static matrix Pow3o2(matrix a)
        {
            var r = new matrix(a.Rows, a.Cols);
            Vml.Pow3o2(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrix Pow3o2(matrixS a)
        {
            matrix r = a;
            Inplace.Pow3o2(r);
            return r;
        }

        public static matrix Pow3o2(matrixT a)
        {
            matrix r = a;
            Inplace.Pow3o2(r);
            return r;
        }

        public static matrix Pow3o2(matrixTS a)
        {
            matrix r = a;
            Inplace.Pow3o2(r);
            return r;
        }

        public static matrix Pow(matrix a, matrix b)
        {
            if (a.Rows != b.Rows || a.Cols != b.Cols) ThrowHelper.ThrowIncorrectMatrixDimensionsForOperation();
            var r = new matrix(a.Rows, a.Cols);
            Vml.Pow(a.Length, a.Array, 0, 1, b.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrix Pow(matrixS a, matrix b)
        {
            matrix r = a;
            Inplace.Pow(r, b);
            return r;
        }

        public static matrix Pow(matrixT a, matrix b)
        {
            matrix r = a;
            Inplace.Pow(r, b);
            return r;
        }

        public static matrix Pow(matrixTS a, matrix b)
        {
            matrix r = a;
            Inplace.Pow(r, b);
            return r;
        }

        public static matrix Powr(matrix a, matrix b)
        {
            if (a.Rows != b.Rows || a.Cols != b.Cols) ThrowHelper.ThrowIncorrectMatrixDimensionsForOperation();
            var r = new matrix(a.Rows, a.Cols);
            Vml.Powr(a.Length, a.Array, 0, 1, b.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrix Powr(matrixS a, matrix b)
        {
            matrix r = a;
            Inplace.Powr(r, b);
            return r;
        }

        public static matrix Powr(matrixT a, matrix b)
        {
            matrix r = a;
            Inplace.Powr(r, b);
            return r;
        }

        public static matrix Powr(matrixTS a, matrix b)
        {
            matrix r = a;
            Inplace.Powr(r, b);
            return r;
        }

        public static matrix Exp(matrix a)
        {
            var r = new matrix(a.Rows, a.Cols);
            Vml.Exp(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrix Exp(matrixS a)
        {
            matrix r = a;
            Inplace.Exp(r);
            return r;
        }

        public static matrix Exp(matrixT a)
        {
            matrix r = a;
            Inplace.Exp(r);
            return r;
        }

        public static matrix Exp(matrixTS a)
        {
            matrix r = a;
            Inplace.Exp(r);
            return r;
        }

        public static matrix Exp2(matrix a)
        {
            var r = new matrix(a.Rows, a.Cols);
            Vml.Exp2(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrix Exp2(matrixS a)
        {
            matrix r = a;
            Inplace.Exp2(r);
            return r;
        }

        public static matrix Exp2(matrixT a)
        {
            matrix r = a;
            Inplace.Exp2(r);
            return r;
        }

        public static matrix Exp2(matrixTS a)
        {
            matrix r = a;
            Inplace.Exp2(r);
            return r;
        }

        public static matrix Exp10(matrix a)
        {
            var r = new matrix(a.Rows, a.Cols);
            Vml.Exp10(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrix Exp10(matrixS a)
        {
            matrix r = a;
            Inplace.Exp10(r);
            return r;
        }

        public static matrix Exp10(matrixT a)
        {
            matrix r = a;
            Inplace.Exp10(r);
            return r;
        }

        public static matrix Exp10(matrixTS a)
        {
            matrix r = a;
            Inplace.Exp10(r);
            return r;
        }

        public static matrix Expm1(matrix a)
        {
            var r = new matrix(a.Rows, a.Cols);
            Vml.Expm1(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrix Expm1(matrixS a)
        {
            matrix r = a;
            Inplace.Expm1(r);
            return r;
        }

        public static matrix Expm1(matrixT a)
        {
            matrix r = a;
            Inplace.Expm1(r);
            return r;
        }

        public static matrix Expm1(matrixTS a)
        {
            matrix r = a;
            Inplace.Expm1(r);
            return r;
        }

        public static matrix Ln(matrix a)
        {
            var r = new matrix(a.Rows, a.Cols);
            Vml.Ln(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrix Ln(matrixS a)
        {
            matrix r = a;
            Inplace.Ln(r);
            return r;
        }

        public static matrix Ln(matrixT a)
        {
            matrix r = a;
            Inplace.Ln(r);
            return r;
        }

        public static matrix Ln(matrixTS a)
        {
            matrix r = a;
            Inplace.Ln(r);
            return r;
        }

        public static matrix Log2(matrix a)
        {
            var r = new matrix(a.Rows, a.Cols);
            Vml.Log2(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrix Log2(matrixS a)
        {
            matrix r = a;
            Inplace.Log2(r);
            return r;
        }

        public static matrix Log2(matrixT a)
        {
            matrix r = a;
            Inplace.Log2(r);
            return r;
        }

        public static matrix Log2(matrixTS a)
        {
            matrix r = a;
            Inplace.Log2(r);
            return r;
        }

        public static matrix Log10(matrix a)
        {
            var r = new matrix(a.Rows, a.Cols);
            Vml.Log10(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrix Log10(matrixS a)
        {
            matrix r = a;
            Inplace.Log10(r);
            return r;
        }

        public static matrix Log10(matrixT a)
        {
            matrix r = a;
            Inplace.Log10(r);
            return r;
        }

        public static matrix Log10(matrixTS a)
        {
            matrix r = a;
            Inplace.Log10(r);
            return r;
        }

        public static matrix Log1p(matrix a)
        {
            var r = new matrix(a.Rows, a.Cols);
            Vml.Log1p(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrix Log1p(matrixS a)
        {
            matrix r = a;
            Inplace.Log1p(r);
            return r;
        }

        public static matrix Log1p(matrixT a)
        {
            matrix r = a;
            Inplace.Log1p(r);
            return r;
        }

        public static matrix Log1p(matrixTS a)
        {
            matrix r = a;
            Inplace.Log1p(r);
            return r;
        }

        public static matrix Logb(matrix a)
        {
            var r = new matrix(a.Rows, a.Cols);
            Vml.Logb(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrix Logb(matrixS a)
        {
            matrix r = a;
            Inplace.Logb(r);
            return r;
        }

        public static matrix Logb(matrixT a)
        {
            matrix r = a;
            Inplace.Logb(r);
            return r;
        }

        public static matrix Logb(matrixTS a)
        {
            matrix r = a;
            Inplace.Logb(r);
            return r;
        }

        public static matrix Cos(matrix a)
        {
            var r = new matrix(a.Rows, a.Cols);
            Vml.Cos(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrix Cos(matrixS a)
        {
            matrix r = a;
            Inplace.Cos(r);
            return r;
        }

        public static matrix Cos(matrixT a)
        {
            matrix r = a;
            Inplace.Cos(r);
            return r;
        }

        public static matrix Cos(matrixTS a)
        {
            matrix r = a;
            Inplace.Cos(r);
            return r;
        }

        public static matrix Sin(matrix a)
        {
            var r = new matrix(a.Rows, a.Cols);
            Vml.Sin(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrix Sin(matrixS a)
        {
            matrix r = a;
            Inplace.Sin(r);
            return r;
        }

        public static matrix Sin(matrixT a)
        {
            matrix r = a;
            Inplace.Sin(r);
            return r;
        }

        public static matrix Sin(matrixTS a)
        {
            matrix r = a;
            Inplace.Sin(r);
            return r;
        }

        public static matrix Tan(matrix a)
        {
            var r = new matrix(a.Rows, a.Cols);
            Vml.Tan(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrix Tan(matrixS a)
        {
            matrix r = a;
            Inplace.Tan(r);
            return r;
        }

        public static matrix Tan(matrixT a)
        {
            matrix r = a;
            Inplace.Tan(r);
            return r;
        }

        public static matrix Tan(matrixTS a)
        {
            matrix r = a;
            Inplace.Tan(r);
            return r;
        }

        public static matrix Cospi(matrix a)
        {
            var r = new matrix(a.Rows, a.Cols);
            Vml.Cospi(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrix Cospi(matrixS a)
        {
            matrix r = a;
            Inplace.Cospi(r);
            return r;
        }

        public static matrix Cospi(matrixT a)
        {
            matrix r = a;
            Inplace.Cospi(r);
            return r;
        }

        public static matrix Cospi(matrixTS a)
        {
            matrix r = a;
            Inplace.Cospi(r);
            return r;
        }

        public static matrix Sinpi(matrix a)
        {
            var r = new matrix(a.Rows, a.Cols);
            Vml.Sinpi(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrix Sinpi(matrixS a)
        {
            matrix r = a;
            Inplace.Sinpi(r);
            return r;
        }

        public static matrix Sinpi(matrixT a)
        {
            matrix r = a;
            Inplace.Sinpi(r);
            return r;
        }

        public static matrix Sinpi(matrixTS a)
        {
            matrix r = a;
            Inplace.Sinpi(r);
            return r;
        }

        public static matrix Tanpi(matrix a)
        {
            var r = new matrix(a.Rows, a.Cols);
            Vml.Tanpi(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrix Tanpi(matrixS a)
        {
            matrix r = a;
            Inplace.Tanpi(r);
            return r;
        }

        public static matrix Tanpi(matrixT a)
        {
            matrix r = a;
            Inplace.Tanpi(r);
            return r;
        }

        public static matrix Tanpi(matrixTS a)
        {
            matrix r = a;
            Inplace.Tanpi(r);
            return r;
        }

        public static matrix Cosd(matrix a)
        {
            var r = new matrix(a.Rows, a.Cols);
            Vml.Cosd(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrix Cosd(matrixS a)
        {
            matrix r = a;
            Inplace.Cosd(r);
            return r;
        }

        public static matrix Cosd(matrixT a)
        {
            matrix r = a;
            Inplace.Cosd(r);
            return r;
        }

        public static matrix Cosd(matrixTS a)
        {
            matrix r = a;
            Inplace.Cosd(r);
            return r;
        }

        public static matrix Sind(matrix a)
        {
            var r = new matrix(a.Rows, a.Cols);
            Vml.Sind(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrix Sind(matrixS a)
        {
            matrix r = a;
            Inplace.Sind(r);
            return r;
        }

        public static matrix Sind(matrixT a)
        {
            matrix r = a;
            Inplace.Sind(r);
            return r;
        }

        public static matrix Sind(matrixTS a)
        {
            matrix r = a;
            Inplace.Sind(r);
            return r;
        }

        public static matrix Tand(matrix a)
        {
            var r = new matrix(a.Rows, a.Cols);
            Vml.Tand(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrix Tand(matrixS a)
        {
            matrix r = a;
            Inplace.Tand(r);
            return r;
        }

        public static matrix Tand(matrixT a)
        {
            matrix r = a;
            Inplace.Tand(r);
            return r;
        }

        public static matrix Tand(matrixTS a)
        {
            matrix r = a;
            Inplace.Tand(r);
            return r;
        }

        public static matrix Acos(matrix a)
        {
            var r = new matrix(a.Rows, a.Cols);
            Vml.Acos(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrix Acos(matrixS a)
        {
            matrix r = a;
            Inplace.Acos(r);
            return r;
        }

        public static matrix Acos(matrixT a)
        {
            matrix r = a;
            Inplace.Acos(r);
            return r;
        }

        public static matrix Acos(matrixTS a)
        {
            matrix r = a;
            Inplace.Acos(r);
            return r;
        }

        public static matrix Asin(matrix a)
        {
            var r = new matrix(a.Rows, a.Cols);
            Vml.Asin(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrix Asin(matrixS a)
        {
            matrix r = a;
            Inplace.Asin(r);
            return r;
        }

        public static matrix Asin(matrixT a)
        {
            matrix r = a;
            Inplace.Asin(r);
            return r;
        }

        public static matrix Asin(matrixTS a)
        {
            matrix r = a;
            Inplace.Asin(r);
            return r;
        }

        public static matrix Atan(matrix a)
        {
            var r = new matrix(a.Rows, a.Cols);
            Vml.Atan(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrix Atan(matrixS a)
        {
            matrix r = a;
            Inplace.Atan(r);
            return r;
        }

        public static matrix Atan(matrixT a)
        {
            matrix r = a;
            Inplace.Atan(r);
            return r;
        }

        public static matrix Atan(matrixTS a)
        {
            matrix r = a;
            Inplace.Atan(r);
            return r;
        }

        public static matrix Acospi(matrix a)
        {
            var r = new matrix(a.Rows, a.Cols);
            Vml.Acospi(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrix Acospi(matrixS a)
        {
            matrix r = a;
            Inplace.Acospi(r);
            return r;
        }

        public static matrix Acospi(matrixT a)
        {
            matrix r = a;
            Inplace.Acospi(r);
            return r;
        }

        public static matrix Acospi(matrixTS a)
        {
            matrix r = a;
            Inplace.Acospi(r);
            return r;
        }

        public static matrix Asinpi(matrix a)
        {
            var r = new matrix(a.Rows, a.Cols);
            Vml.Asinpi(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrix Asinpi(matrixS a)
        {
            matrix r = a;
            Inplace.Asinpi(r);
            return r;
        }

        public static matrix Asinpi(matrixT a)
        {
            matrix r = a;
            Inplace.Asinpi(r);
            return r;
        }

        public static matrix Asinpi(matrixTS a)
        {
            matrix r = a;
            Inplace.Asinpi(r);
            return r;
        }

        public static matrix Atanpi(matrix a)
        {
            var r = new matrix(a.Rows, a.Cols);
            Vml.Atanpi(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrix Atanpi(matrixS a)
        {
            matrix r = a;
            Inplace.Atanpi(r);
            return r;
        }

        public static matrix Atanpi(matrixT a)
        {
            matrix r = a;
            Inplace.Atanpi(r);
            return r;
        }

        public static matrix Atanpi(matrixTS a)
        {
            matrix r = a;
            Inplace.Atanpi(r);
            return r;
        }

        public static matrix Atan2(matrix a, matrix b)
        {
            if (a.Rows != b.Rows || a.Cols != b.Cols) ThrowHelper.ThrowIncorrectMatrixDimensionsForOperation();
            var r = new matrix(a.Rows, a.Cols);
            Vml.Atan2(a.Length, a.Array, 0, 1, b.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrix Atan2(matrixS a, matrix b)
        {
            matrix r = a;
            Inplace.Atan2(r, b);
            return r;
        }

        public static matrix Atan2(matrixT a, matrix b)
        {
            matrix r = a;
            Inplace.Atan2(r, b);
            return r;
        }

        public static matrix Atan2(matrixTS a, matrix b)
        {
            matrix r = a;
            Inplace.Atan2(r, b);
            return r;
        }

        public static matrix Atan2pi(matrix a, matrix b)
        {
            if (a.Rows != b.Rows || a.Cols != b.Cols) ThrowHelper.ThrowIncorrectMatrixDimensionsForOperation();
            var r = new matrix(a.Rows, a.Cols);
            Vml.Atan2pi(a.Length, a.Array, 0, 1, b.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrix Atan2pi(matrixS a, matrix b)
        {
            matrix r = a;
            Inplace.Atan2pi(r, b);
            return r;
        }

        public static matrix Atan2pi(matrixT a, matrix b)
        {
            matrix r = a;
            Inplace.Atan2pi(r, b);
            return r;
        }

        public static matrix Atan2pi(matrixTS a, matrix b)
        {
            matrix r = a;
            Inplace.Atan2pi(r, b);
            return r;
        }

        public static matrix Cosh(matrix a)
        {
            var r = new matrix(a.Rows, a.Cols);
            Vml.Cosh(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrix Cosh(matrixS a)
        {
            matrix r = a;
            Inplace.Cosh(r);
            return r;
        }

        public static matrix Cosh(matrixT a)
        {
            matrix r = a;
            Inplace.Cosh(r);
            return r;
        }

        public static matrix Cosh(matrixTS a)
        {
            matrix r = a;
            Inplace.Cosh(r);
            return r;
        }

        public static matrix Sinh(matrix a)
        {
            var r = new matrix(a.Rows, a.Cols);
            Vml.Sinh(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrix Sinh(matrixS a)
        {
            matrix r = a;
            Inplace.Sinh(r);
            return r;
        }

        public static matrix Sinh(matrixT a)
        {
            matrix r = a;
            Inplace.Sinh(r);
            return r;
        }

        public static matrix Sinh(matrixTS a)
        {
            matrix r = a;
            Inplace.Sinh(r);
            return r;
        }

        public static matrix Tanh(matrix a)
        {
            var r = new matrix(a.Rows, a.Cols);
            Vml.Tanh(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrix Tanh(matrixS a)
        {
            matrix r = a;
            Inplace.Tanh(r);
            return r;
        }

        public static matrix Tanh(matrixT a)
        {
            matrix r = a;
            Inplace.Tanh(r);
            return r;
        }

        public static matrix Tanh(matrixTS a)
        {
            matrix r = a;
            Inplace.Tanh(r);
            return r;
        }

        public static matrix Acosh(matrix a)
        {
            var r = new matrix(a.Rows, a.Cols);
            Vml.Acosh(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrix Acosh(matrixS a)
        {
            matrix r = a;
            Inplace.Acosh(r);
            return r;
        }

        public static matrix Acosh(matrixT a)
        {
            matrix r = a;
            Inplace.Acosh(r);
            return r;
        }

        public static matrix Acosh(matrixTS a)
        {
            matrix r = a;
            Inplace.Acosh(r);
            return r;
        }

        public static matrix Asinh(matrix a)
        {
            var r = new matrix(a.Rows, a.Cols);
            Vml.Asinh(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrix Asinh(matrixS a)
        {
            matrix r = a;
            Inplace.Asinh(r);
            return r;
        }

        public static matrix Asinh(matrixT a)
        {
            matrix r = a;
            Inplace.Asinh(r);
            return r;
        }

        public static matrix Asinh(matrixTS a)
        {
            matrix r = a;
            Inplace.Asinh(r);
            return r;
        }

        public static matrix Atanh(matrix a)
        {
            var r = new matrix(a.Rows, a.Cols);
            Vml.Atanh(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrix Atanh(matrixS a)
        {
            matrix r = a;
            Inplace.Atanh(r);
            return r;
        }

        public static matrix Atanh(matrixT a)
        {
            matrix r = a;
            Inplace.Atanh(r);
            return r;
        }

        public static matrix Atanh(matrixTS a)
        {
            matrix r = a;
            Inplace.Atanh(r);
            return r;
        }

        public static matrix Erf(matrix a)
        {
            var r = new matrix(a.Rows, a.Cols);
            Vml.Erf(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrix Erf(matrixS a)
        {
            matrix r = a;
            Inplace.Erf(r);
            return r;
        }

        public static matrix Erf(matrixT a)
        {
            matrix r = a;
            Inplace.Erf(r);
            return r;
        }

        public static matrix Erf(matrixTS a)
        {
            matrix r = a;
            Inplace.Erf(r);
            return r;
        }

        public static matrix Erfc(matrix a)
        {
            var r = new matrix(a.Rows, a.Cols);
            Vml.Erfc(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrix Erfc(matrixS a)
        {
            matrix r = a;
            Inplace.Erfc(r);
            return r;
        }

        public static matrix Erfc(matrixT a)
        {
            matrix r = a;
            Inplace.Erfc(r);
            return r;
        }

        public static matrix Erfc(matrixTS a)
        {
            matrix r = a;
            Inplace.Erfc(r);
            return r;
        }

        public static matrix ErfInv(matrix a)
        {
            var r = new matrix(a.Rows, a.Cols);
            Vml.ErfInv(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrix ErfInv(matrixS a)
        {
            matrix r = a;
            Inplace.ErfInv(r);
            return r;
        }

        public static matrix ErfInv(matrixT a)
        {
            matrix r = a;
            Inplace.ErfInv(r);
            return r;
        }

        public static matrix ErfInv(matrixTS a)
        {
            matrix r = a;
            Inplace.ErfInv(r);
            return r;
        }

        public static matrix ErfcInv(matrix a)
        {
            var r = new matrix(a.Rows, a.Cols);
            Vml.ErfcInv(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrix ErfcInv(matrixS a)
        {
            matrix r = a;
            Inplace.ErfcInv(r);
            return r;
        }

        public static matrix ErfcInv(matrixT a)
        {
            matrix r = a;
            Inplace.ErfcInv(r);
            return r;
        }

        public static matrix ErfcInv(matrixTS a)
        {
            matrix r = a;
            Inplace.ErfcInv(r);
            return r;
        }

        public static matrix CdfNorm(matrix a)
        {
            var r = new matrix(a.Rows, a.Cols);
            Vml.CdfNorm(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrix CdfNorm(matrixS a)
        {
            matrix r = a;
            Inplace.CdfNorm(r);
            return r;
        }

        public static matrix CdfNorm(matrixT a)
        {
            matrix r = a;
            Inplace.CdfNorm(r);
            return r;
        }

        public static matrix CdfNorm(matrixTS a)
        {
            matrix r = a;
            Inplace.CdfNorm(r);
            return r;
        }

        public static matrix CdfNormInv(matrix a)
        {
            var r = new matrix(a.Rows, a.Cols);
            Vml.CdfNormInv(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrix CdfNormInv(matrixS a)
        {
            matrix r = a;
            Inplace.CdfNormInv(r);
            return r;
        }

        public static matrix CdfNormInv(matrixT a)
        {
            matrix r = a;
            Inplace.CdfNormInv(r);
            return r;
        }

        public static matrix CdfNormInv(matrixTS a)
        {
            matrix r = a;
            Inplace.CdfNormInv(r);
            return r;
        }

        public static matrix LGamma(matrix a)
        {
            var r = new matrix(a.Rows, a.Cols);
            Vml.LGamma(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrix LGamma(matrixS a)
        {
            matrix r = a;
            Inplace.LGamma(r);
            return r;
        }

        public static matrix LGamma(matrixT a)
        {
            matrix r = a;
            Inplace.LGamma(r);
            return r;
        }

        public static matrix LGamma(matrixTS a)
        {
            matrix r = a;
            Inplace.LGamma(r);
            return r;
        }

        public static matrix TGamma(matrix a)
        {
            var r = new matrix(a.Rows, a.Cols);
            Vml.TGamma(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrix TGamma(matrixS a)
        {
            matrix r = a;
            Inplace.TGamma(r);
            return r;
        }

        public static matrix TGamma(matrixT a)
        {
            matrix r = a;
            Inplace.TGamma(r);
            return r;
        }

        public static matrix TGamma(matrixTS a)
        {
            matrix r = a;
            Inplace.TGamma(r);
            return r;
        }

        public static matrix ExpInt1(matrix a)
        {
            var r = new matrix(a.Rows, a.Cols);
            Vml.ExpInt1(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrix ExpInt1(matrixS a)
        {
            matrix r = a;
            Inplace.ExpInt1(r);
            return r;
        }

        public static matrix ExpInt1(matrixT a)
        {
            matrix r = a;
            Inplace.ExpInt1(r);
            return r;
        }

        public static matrix ExpInt1(matrixTS a)
        {
            matrix r = a;
            Inplace.ExpInt1(r);
            return r;
        }

        public static matrix Floor(matrix a)
        {
            var r = new matrix(a.Rows, a.Cols);
            Vml.Floor(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrix Floor(matrixS a)
        {
            matrix r = a;
            Inplace.Floor(r);
            return r;
        }

        public static matrix Floor(matrixT a)
        {
            matrix r = a;
            Inplace.Floor(r);
            return r;
        }

        public static matrix Floor(matrixTS a)
        {
            matrix r = a;
            Inplace.Floor(r);
            return r;
        }

        public static matrix Ceil(matrix a)
        {
            var r = new matrix(a.Rows, a.Cols);
            Vml.Ceil(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrix Ceil(matrixS a)
        {
            matrix r = a;
            Inplace.Ceil(r);
            return r;
        }

        public static matrix Ceil(matrixT a)
        {
            matrix r = a;
            Inplace.Ceil(r);
            return r;
        }

        public static matrix Ceil(matrixTS a)
        {
            matrix r = a;
            Inplace.Ceil(r);
            return r;
        }

        public static matrix Trunc(matrix a)
        {
            var r = new matrix(a.Rows, a.Cols);
            Vml.Trunc(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrix Trunc(matrixS a)
        {
            matrix r = a;
            Inplace.Trunc(r);
            return r;
        }

        public static matrix Trunc(matrixT a)
        {
            matrix r = a;
            Inplace.Trunc(r);
            return r;
        }

        public static matrix Trunc(matrixTS a)
        {
            matrix r = a;
            Inplace.Trunc(r);
            return r;
        }

        public static matrix Round(matrix a)
        {
            var r = new matrix(a.Rows, a.Cols);
            Vml.Round(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrix Round(matrixS a)
        {
            matrix r = a;
            Inplace.Round(r);
            return r;
        }

        public static matrix Round(matrixT a)
        {
            matrix r = a;
            Inplace.Round(r);
            return r;
        }

        public static matrix Round(matrixTS a)
        {
            matrix r = a;
            Inplace.Round(r);
            return r;
        }

        public static matrix Frac(matrix a)
        {
            var r = new matrix(a.Rows, a.Cols);
            Vml.Frac(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrix Frac(matrixS a)
        {
            matrix r = a;
            Inplace.Frac(r);
            return r;
        }

        public static matrix Frac(matrixT a)
        {
            matrix r = a;
            Inplace.Frac(r);
            return r;
        }

        public static matrix Frac(matrixTS a)
        {
            matrix r = a;
            Inplace.Frac(r);
            return r;
        }

        public static matrix NearbyInt(matrix a)
        {
            var r = new matrix(a.Rows, a.Cols);
            Vml.NearbyInt(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrix NearbyInt(matrixS a)
        {
            matrix r = a;
            Inplace.NearbyInt(r);
            return r;
        }

        public static matrix NearbyInt(matrixT a)
        {
            matrix r = a;
            Inplace.NearbyInt(r);
            return r;
        }

        public static matrix NearbyInt(matrixTS a)
        {
            matrix r = a;
            Inplace.NearbyInt(r);
            return r;
        }

        public static matrix Rint(matrix a)
        {
            var r = new matrix(a.Rows, a.Cols);
            Vml.Rint(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrix Rint(matrixS a)
        {
            matrix r = a;
            Inplace.Rint(r);
            return r;
        }

        public static matrix Rint(matrixT a)
        {
            matrix r = a;
            Inplace.Rint(r);
            return r;
        }

        public static matrix Rint(matrixTS a)
        {
            matrix r = a;
            Inplace.Rint(r);
            return r;
        }

        public static matrix CopySign(matrix a, matrix b)
        {
            if (a.Rows != b.Rows || a.Cols != b.Cols) ThrowHelper.ThrowIncorrectMatrixDimensionsForOperation();
            var r = new matrix(a.Rows, a.Cols);
            Vml.CopySign(a.Length, a.Array, 0, 1, b.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrix CopySign(matrixS a, matrix b)
        {
            matrix r = a;
            Inplace.CopySign(r, b);
            return r;
        }

        public static matrix CopySign(matrixT a, matrix b)
        {
            matrix r = a;
            Inplace.CopySign(r, b);
            return r;
        }

        public static matrix CopySign(matrixTS a, matrix b)
        {
            matrix r = a;
            Inplace.CopySign(r, b);
            return r;
        }

        public static matrix Fmax(matrix a, matrix b)
        {
            if (a.Rows != b.Rows || a.Cols != b.Cols) ThrowHelper.ThrowIncorrectMatrixDimensionsForOperation();
            var r = new matrix(a.Rows, a.Cols);
            Vml.Fmax(a.Length, a.Array, 0, 1, b.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrix Fmax(matrixS a, matrix b)
        {
            matrix r = a;
            Inplace.Fmax(r, b);
            return r;
        }

        public static matrix Fmax(matrixT a, matrix b)
        {
            matrix r = a;
            Inplace.Fmax(r, b);
            return r;
        }

        public static matrix Fmax(matrixTS a, matrix b)
        {
            matrix r = a;
            Inplace.Fmax(r, b);
            return r;
        }

        public static matrix Fmin(matrix a, matrix b)
        {
            if (a.Rows != b.Rows || a.Cols != b.Cols) ThrowHelper.ThrowIncorrectMatrixDimensionsForOperation();
            var r = new matrix(a.Rows, a.Cols);
            Vml.Fmin(a.Length, a.Array, 0, 1, b.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrix Fmin(matrixS a, matrix b)
        {
            matrix r = a;
            Inplace.Fmin(r, b);
            return r;
        }

        public static matrix Fmin(matrixT a, matrix b)
        {
            matrix r = a;
            Inplace.Fmin(r, b);
            return r;
        }

        public static matrix Fmin(matrixTS a, matrix b)
        {
            matrix r = a;
            Inplace.Fmin(r, b);
            return r;
        }

        public static matrix Fdim(matrix a, matrix b)
        {
            if (a.Rows != b.Rows || a.Cols != b.Cols) ThrowHelper.ThrowIncorrectMatrixDimensionsForOperation();
            var r = new matrix(a.Rows, a.Cols);
            Vml.Fdim(a.Length, a.Array, 0, 1, b.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrix Fdim(matrixS a, matrix b)
        {
            matrix r = a;
            Inplace.Fdim(r, b);
            return r;
        }

        public static matrix Fdim(matrixT a, matrix b)
        {
            matrix r = a;
            Inplace.Fdim(r, b);
            return r;
        }

        public static matrix Fdim(matrixTS a, matrix b)
        {
            matrix r = a;
            Inplace.Fdim(r, b);
            return r;
        }

        public static matrix MaxMag(matrix a, matrix b)
        {
            if (a.Rows != b.Rows || a.Cols != b.Cols) ThrowHelper.ThrowIncorrectMatrixDimensionsForOperation();
            var r = new matrix(a.Rows, a.Cols);
            Vml.MaxMag(a.Length, a.Array, 0, 1, b.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrix MaxMag(matrixS a, matrix b)
        {
            matrix r = a;
            Inplace.MaxMag(r, b);
            return r;
        }

        public static matrix MaxMag(matrixT a, matrix b)
        {
            matrix r = a;
            Inplace.MaxMag(r, b);
            return r;
        }

        public static matrix MaxMag(matrixTS a, matrix b)
        {
            matrix r = a;
            Inplace.MaxMag(r, b);
            return r;
        }

        public static matrix NextAfter(matrix a, matrix b)
        {
            if (a.Rows != b.Rows || a.Cols != b.Cols) ThrowHelper.ThrowIncorrectMatrixDimensionsForOperation();
            var r = new matrix(a.Rows, a.Cols);
            Vml.NextAfter(a.Length, a.Array, 0, 1, b.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrix NextAfter(matrixS a, matrix b)
        {
            matrix r = a;
            Inplace.NextAfter(r, b);
            return r;
        }

        public static matrix NextAfter(matrixT a, matrix b)
        {
            matrix r = a;
            Inplace.NextAfter(r, b);
            return r;
        }

        public static matrix NextAfter(matrixTS a, matrix b)
        {
            matrix r = a;
            Inplace.NextAfter(r, b);
            return r;
        }

        public static matrix Powx(matrix a, double b)
        {
            var r = new matrix(a.Rows, a.Cols);
            Vml.Powx(a.Length, a.Array, 0, 1, b, r.Array, 0, 1);
            return r;
        }

        public static matrix Powx(matrixS a, double b)
        {
            matrix r = a;
            Inplace.Powx(r, b);
            return r;
        }

        public static matrix Powx(matrixT a, double b)
        {
            matrix r = a;
            Inplace.Powx(r, b);
            return r;
        }

        public static matrix Powx(matrixTS a, double b)
        {
            matrix r = a;
            Inplace.Powx(r, b);
            return r;
        }

        public static (matrix, matrix) SinCos(matrix a)
        {
            var sin = new matrix(a.Rows, a.Cols);
            var cos = new matrix(a.Rows, a.Cols);
            Vml.SinCos(a.Length, a.Array, 0, 1, sin.Array, 0, 1, cos.Array, 0, 1);
            return (sin, cos);
        }

        public static (matrix, matrix) SinCos(matrixS a)
        {
            matrix sin = a;
            var cos = Inplace.SinCos(sin);
            return (sin, cos);
        }

        public static (matrix, matrix) SinCos(matrixT a)
        {
            matrix sin = a;
            var cos = Inplace.SinCos(sin);
            return (sin, cos);
        }

        public static (matrix, matrix) SinCos(matrixTS a)
        {
            matrix sin = a;
            var cos = Inplace.SinCos(sin);
            return (sin, cos);
        }

        public static (matrix, matrix) Modf(matrix a)
        {
            var tru = new matrix(a.Rows, a.Cols);
            var rem = new matrix(a.Rows, a.Cols);
            Vml.Modf(a.Length, a.Array, 0, 1, tru.Array, 0, 1, rem.Array, 0, 1);
            return (tru, rem);
        }

        public static (matrix, matrix) Modf(matrixS a)
        {
            matrix tru = a;
            var rem = Inplace.Modf(tru);
            return (tru, rem);
        }

        public static (matrix, matrix) Modf(matrixT a)
        {
            matrix tru = a;
            var rem = Inplace.Modf(tru);
            return (tru, rem);
        }

        public static (matrix, matrix) Modf(matrixTS a)
        {
            matrix tru = a;
            var rem = Inplace.Modf(tru);
            return (tru, rem);
        }

        public static matrix LinearFrac(matrix a, matrix b, double scalea, double shifta, double scaleb, double shiftb)
        {
            if (a.Rows != b.Rows || a.Cols != b.Cols) ThrowHelper.ThrowIncorrectMatrixDimensionsForOperation();
            var r = new matrix(a.Rows, a.Cols);
            Vml.LinearFrac(a.Length, a.Array, 0, 1, b.Array, 0, 1, scalea, shifta, scaleb, shiftb, r.Array, 0, 1);
            return r;
        }

        public static matrix LinearFrac(matrixS a, matrix b, double scalea, double shifta, double scaleb, double shiftb)
        {
            matrix r = a;
            Inplace.LinearFrac(r, b, scalea, shifta, scaleb, shiftb);
            return r;
        }

        public static matrix LinearFrac(matrixT a, matrix b, double scalea, double shifta, double scaleb, double shiftb)
        {
            matrix r = a;
            Inplace.LinearFrac(r, b, scalea, shifta, scaleb, shiftb);
            return r;
        }

        public static matrix LinearFrac(matrixTS a, matrix b, double scalea, double shifta, double scaleb, double shiftb)
        {
            matrix r = a;
            Inplace.LinearFrac(r, b, scalea, shifta, scaleb, shiftb);
            return r;
        }

        public static double Asum(matrix a)
        {
            return Blas.asum(a.Length, a.Array, 0, 1);
        }

        public static double Nrm2(matrix a)
        {
            return Blas.nrm2(a.Length, a.Array, 0, 1);
        }

        public static (int, int) Iamax(matrix a)
        {
            int i = Blas.iamax(a.Length, a.Array, 0, 1);
            int col = Math.DivRem(i, a.Rows, out int row);
            return (row, col);
        }

        public static (int, int) Iamin(matrix a)
        {
            int i = Blas.iamin(a.Length, a.Array, 0, 1);
            int col = Math.DivRem(i, a.Rows, out int row);
            return (row, col);
        }

        public static matrix Copy(matrix a)
        {
            var r = new matrix(a.Rows, a.Cols);
            Blas.copy(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrix Cholesky(matrix a)
        {
            var r = Copy(a);
            Inplace.Cholesky(r);
            return r;
        }

        public static matrix Solve(matrix a, matrix b)
        {
            a = Copy(a);
            b = Copy(b);
            Inplace.Solve(a, b);
            return b;
        }

        public static vector Solve(matrix a, vector b)
        {
            a = Copy(a);
            b = Vector.Copy(b);
            Inplace.Solve(a, b);
            return b;
        }

        public static matrix Inverse(matrix a)
        {
            a = Copy(a);
            Inplace.Inverse(a);
            return a;
        }

        public static (matrix, vector) Eigens(matrix a)
        {
            a = Copy(a);
            var w = Inplace.Eigens(a);
            return (a, w);
        }

        public static matrix LeastSquares(matrix a, matrix b)
        {
            a = Copy(a);
            b = Copy(b);
            Inplace.LeastSquares(a, b);
            return b;
        }
    }
}

// TODO
// matrix Vml functions
// test Lapack and Vml functions
// matrixF, vectorF
// bespoke ArrayPool, Pinned Object Heap and pinning optimisations.