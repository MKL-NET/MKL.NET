using System;

namespace MKLNET
{
    public static class Matrix
    {
        public static class Inplace
        {
            public static void Abs(matrix m)
            {
                Vml.Abs(m.Length, m.A, 0, 1, m.A, 0, 1);
            }

            public static void Add(matrix a, matrix b)
            {
                Vml.Add(a.Length, a.A, 0, 1, b.A, 0, 1, a.A, 0, 1);
            }

            public static void Sub(matrix a, matrix b)
            {
                Vml.Sub(a.Length, a.A, 0, 1, b.A, 0, 1, a.A, 0, 1);
            }

            public static void Sqr(matrix m)
            {
                Vml.Sqr(m.Length, m.A, 0, 1, m.A, 0, 1);
            }

            public static void Mul(matrix a, matrix b)
            {
                Vml.Mul(a.Length, a.A, 0, 1, b.A, 0, 1, a.A, 0, 1);
            }

            public static void Fmod(matrix a, matrix b)
            {
                Vml.Fmod(a.Length, a.A, 0, 1, b.A, 0, 1, a.A, 0, 1);
            }

            public static void Remainder(matrix a, matrix b)
            {
                Vml.Remainder(a.Length, a.A, 0, 1, b.A, 0, 1, a.A, 0, 1);
            }

            public static void Inv(matrix m)
            {
                Vml.Inv(m.Length, m.A, 0, 1, m.A, 0, 1);
            }

            public static void Sqrt(matrix m)
            {
                Vml.Sqrt(m.Length, m.A, 0, 1, m.A, 0, 1);
            }

            public static void InvSqrt(matrix m)
            {
                Vml.InvSqrt(m.Length, m.A, 0, 1, m.A, 0, 1);
            }

            public static void Cbrt(matrix m)
            {
                Vml.Cbrt(m.Length, m.A, 0, 1, m.A, 0, 1);
            }

            public static void InvCbrt(matrix m)
            {
                Vml.InvCbrt(m.Length, m.A, 0, 1, m.A, 0, 1);
            }

            public static void Hypot(matrix a, matrix b)
            {
                Vml.Hypot(a.Length, a.A, 0, 1, b.A, 0, 1, a.A, 0, 1);
            }

            public static void Div(matrix a, matrix b)
            {
                Vml.Div(a.Length, a.A, 0, 1, b.A, 0, 1, a.A, 0, 1);
            }

            public static void Pow2o3(matrix m)
            {
                Vml.Pow2o3(m.Length, m.A, 0, 1, m.A, 0, 1);
            }

            public static void Pow3o2(matrix m)
            {
                Vml.Pow3o2(m.Length, m.A, 0, 1, m.A, 0, 1);
            }

            public static void Pow(matrix a, matrix b)
            {
                Vml.Pow(a.Length, a.A, 0, 1, b.A, 0, 1, a.A, 0, 1);
            }

            public static void Powr(matrix a, matrix b)
            {
                Vml.Powr(a.Length, a.A, 0, 1, b.A, 0, 1, a.A, 0, 1);
            }

            public static void Exp(matrix m)
            {
                Vml.Exp(m.Length, m.A, 0, 1, m.A, 0, 1);
            }

            public static void Exp2(matrix m)
            {
                Vml.Exp2(m.Length, m.A, 0, 1, m.A, 0, 1);
            }

            public static void Exp10(matrix m)
            {
                Vml.Exp10(m.Length, m.A, 0, 1, m.A, 0, 1);
            }

            public static void Expm1(matrix m)
            {
                Vml.Expm1(m.Length, m.A, 0, 1, m.A, 0, 1);
            }

            public static void Ln(matrix m)
            {
                Vml.Ln(m.Length, m.A, 0, 1, m.A, 0, 1);
            }

            public static void Log2(matrix m)
            {
                Vml.Log2(m.Length, m.A, 0, 1, m.A, 0, 1);
            }

            public static void Log10(matrix m)
            {
                Vml.Log10(m.Length, m.A, 0, 1, m.A, 0, 1);
            }

            public static void Log1p(matrix m)
            {
                Vml.Log1p(m.Length, m.A, 0, 1, m.A, 0, 1);
            }

            public static void Logb(matrix m)
            {
                Vml.Logb(m.Length, m.A, 0, 1, m.A, 0, 1);
            }

            public static void Cos(matrix m)
            {
                Vml.Cos(m.Length, m.A, 0, 1, m.A, 0, 1);
            }

            public static void Sin(matrix m)
            {
                Vml.Sin(m.Length, m.A, 0, 1, m.A, 0, 1);
            }

            public static void Tan(matrix m)
            {
                Vml.Tan(m.Length, m.A, 0, 1, m.A, 0, 1);
            }

            public static void Cospi(matrix m)
            {
                Vml.Cospi(m.Length, m.A, 0, 1, m.A, 0, 1);
            }

            public static void Sinpi(matrix m)
            {
                Vml.Sinpi(m.Length, m.A, 0, 1, m.A, 0, 1);
            }

            public static void Tanpi(matrix m)
            {
                Vml.Tanpi(m.Length, m.A, 0, 1, m.A, 0, 1);
            }

            public static void Cosd(matrix m)
            {
                Vml.Cosd(m.Length, m.A, 0, 1, m.A, 0, 1);
            }

            public static void Sind(matrix m)
            {
                Vml.Sind(m.Length, m.A, 0, 1, m.A, 0, 1);
            }

            public static void Tand(matrix m)
            {
                Vml.Tand(m.Length, m.A, 0, 1, m.A, 0, 1);
            }

            public static void Acos(matrix m)
            {
                Vml.Acos(m.Length, m.A, 0, 1, m.A, 0, 1);
            }

            public static void Asin(matrix m)
            {
                Vml.Asin(m.Length, m.A, 0, 1, m.A, 0, 1);
            }

            public static void Atan(matrix m)
            {
                Vml.Atan(m.Length, m.A, 0, 1, m.A, 0, 1);
            }

            public static void Acospi(matrix m)
            {
                Vml.Acospi(m.Length, m.A, 0, 1, m.A, 0, 1);
            }

            public static void Asinpi(matrix m)
            {
                Vml.Asinpi(m.Length, m.A, 0, 1, m.A, 0, 1);
            }

            public static void Atanpi(matrix m)
            {
                Vml.Atanpi(m.Length, m.A, 0, 1, m.A, 0, 1);
            }

            public static void Atan2(matrix a, matrix b)
            {
                Vml.Atan2(a.Length, a.A, 0, 1, b.A, 0, 1, a.A, 0, 1);
            }

            public static void Atan2pi(matrix a, matrix b)
            {
                Vml.Atan2pi(a.Length, a.A, 0, 1, b.A, 0, 1, a.A, 0, 1);
            }

            public static void Cosh(matrix m)
            {
                Vml.Cosh(m.Length, m.A, 0, 1, m.A, 0, 1);
            }

            public static void Sinh(matrix m)
            {
                Vml.Sinh(m.Length, m.A, 0, 1, m.A, 0, 1);
            }

            public static void Tanh(matrix m)
            {
                Vml.Tanh(m.Length, m.A, 0, 1, m.A, 0, 1);
            }

            public static void Acosh(matrix m)
            {
                Vml.Acosh(m.Length, m.A, 0, 1, m.A, 0, 1);
            }

            public static void Asinh(matrix m)
            {
                Vml.Asinh(m.Length, m.A, 0, 1, m.A, 0, 1);
            }

            public static void Atanh(matrix m)
            {
                Vml.Atanh(m.Length, m.A, 0, 1, m.A, 0, 1);
            }

            public static void Erf(matrix m)
            {
                Vml.Erf(m.Length, m.A, 0, 1, m.A, 0, 1);
            }

            public static void Erfc(matrix m)
            {
                Vml.Erfc(m.Length, m.A, 0, 1, m.A, 0, 1);
            }

            public static void ErfInv(matrix m)
            {
                Vml.ErfInv(m.Length, m.A, 0, 1, m.A, 0, 1);
            }

            public static void ErfcInv(matrix m)
            {
                Vml.ErfcInv(m.Length, m.A, 0, 1, m.A, 0, 1);
            }

            public static void CdfNorm(matrix m)
            {
                Vml.CdfNorm(m.Length, m.A, 0, 1, m.A, 0, 1);
            }

            public static void CdfNormInv(matrix m)
            {
                Vml.CdfNormInv(m.Length, m.A, 0, 1, m.A, 0, 1);
            }

            public static void LGamma(matrix m)
            {
                Vml.LGamma(m.Length, m.A, 0, 1, m.A, 0, 1);
            }

            public static void TGamma(matrix m)
            {
                Vml.TGamma(m.Length, m.A, 0, 1, m.A, 0, 1);
            }

            public static void ExpInt1(matrix m)
            {
                Vml.ExpInt1(m.Length, m.A, 0, 1, m.A, 0, 1);
            }

            public static void Floor(matrix m)
            {
                Vml.Floor(m.Length, m.A, 0, 1, m.A, 0, 1);
            }

            public static void Ceil(matrix m)
            {
                Vml.Ceil(m.Length, m.A, 0, 1, m.A, 0, 1);
            }

            public static void Trunc(matrix m)
            {
                Vml.Trunc(m.Length, m.A, 0, 1, m.A, 0, 1);
            }

            public static void Round(matrix m)
            {
                Vml.Round(m.Length, m.A, 0, 1, m.A, 0, 1);
            }

            public static void Frac(matrix m)
            {
                Vml.Frac(m.Length, m.A, 0, 1, m.A, 0, 1);
            }

            public static void NearbyInt(matrix m)
            {
                Vml.NearbyInt(m.Length, m.A, 0, 1, m.A, 0, 1);
            }

            public static void Rint(matrix m)
            {
                Vml.Rint(m.Length, m.A, 0, 1, m.A, 0, 1);
            }

            public static void CopySign(matrix a, matrix b)
            {
                Vml.CopySign(a.Length, a.A, 0, 1, b.A, 0, 1, a.A, 0, 1);
            }

            public static void Fmax(matrix a, matrix b)
            {
                Vml.Fmax(a.Length, a.A, 0, 1, b.A, 0, 1, a.A, 0, 1);
            }

            public static void Fmin(matrix a, matrix b)
            {
                Vml.Fmin(a.Length, a.A, 0, 1, b.A, 0, 1, a.A, 0, 1);
            }

            public static void Fdim(matrix a, matrix b)
            {
                Vml.Fdim(a.Length, a.A, 0, 1, b.A, 0, 1, a.A, 0, 1);
            }

            public static void MaxMag(matrix a, matrix b)
            {
                Vml.MaxMag(a.Length, a.A, 0, 1, b.A, 0, 1, a.A, 0, 1);
            }

            public static void NextAfter(matrix a, matrix b)
            {
                Vml.NextAfter(a.Length, a.A, 0, 1, b.A, 0, 1, a.A, 0, 1);
            }

            public static void Powx(matrix a, double b)
            {
                Vml.Powx(a.Length, a.A, 0, 1, b, a.A, 0, 1);
            }

            public static void LinearFrac(matrix a, matrix b, double scalea, double shifta, double scaleb, double shiftb)
            {
                Vml.LinearFrac(a.Length, a.A, 0, 1, b.A, 0, 1, scalea, shifta, scaleb, shiftb, a.A, 0, 1);
            }

            public static matrix SinCos(matrix m)
            {
                var cos = new matrix(m.Rows, m.Cols);
                Vml.SinCos(m.Length, m.A, 0, 1, m.A, 0, 1, cos.A, 0, 1);
                return cos;
            }

            public static matrix Modf(matrix m)
            {
                var rem = new matrix(m.Rows, m.Cols);
                Vml.Modf(m.Length, m.A, 0, 1, m.A, 0, 1, rem.A, 0, 1);
                return rem;
            }
        }

        public static matrix Abs(matrix m)
        {
            var r = new matrix(m.Rows, m.Cols);
            Vml.Abs(m.Length, m.A, 0, 1, r.A, 0, 1);
            return r;
        }

        public static matrix Abs(matrixS m)
        {
            matrix r = m;
            Inplace.Abs(r);
            return r;
        }

        public static matrix Abs(matrixT m)
        {
            matrix r = m;
            Inplace.Abs(r);
            return r;
        }

        public static matrix Abs(matrixTS m)
        {
            matrix r = m;
            Inplace.Abs(r);
            return r;
        }

        public static matrix Sqr(matrix m)
        {
            var r = new matrix(m.Rows, m.Cols);
            Vml.Sqr(m.Length, m.A, 0, 1, r.A, 0, 1);
            return r;
        }

        public static matrix Sqr(matrixS m)
        {
            matrix r = m;
            Inplace.Sqr(r);
            return r;
        }

        public static matrix Sqr(matrixT m)
        {
            matrix r = m;
            Inplace.Sqr(r);
            return r;
        }

        public static matrix Sqr(matrixTS m)
        {
            matrix r = m;
            Inplace.Sqr(r);
            return r;
        }

        public static matrix Mul(matrix a, matrix b)
        {
            if (a.Rows != b.Rows || a.Cols != b.Cols) ThrowHelper.ThrowIncorrectMatrixDimesionsForOperation();
            var r = new matrix(a.Rows, a.Cols);
            Vml.Mul(a.Length, a.A, 0, 1, b.A, 0, 1, r.A, 0, 1);
            return r;
        }

        public static matrix Fmod(matrix a, matrix b)
        {
            if (a.Rows != b.Rows || a.Cols != b.Cols) ThrowHelper.ThrowIncorrectMatrixDimesionsForOperation();
            var r = new matrix(a.Rows, a.Cols);
            Vml.Fmod(a.Length, a.A, 0, 1, b.A, 0, 1, r.A, 0, 1);
            return r;
        }

        public static matrix Remainder(matrix a, matrix b)
        {
            if (a.Rows != b.Rows || a.Cols != b.Cols) ThrowHelper.ThrowIncorrectMatrixDimesionsForOperation();
            var r = new matrix(a.Rows, a.Cols);
            Vml.Remainder(a.Length, a.A, 0, 1, b.A, 0, 1, r.A, 0, 1);
            return r;
        }

        public static matrix Inv(matrix m)
        {
            var r = new matrix(m.Rows, m.Cols);
            Vml.Inv(m.Length, m.A, 0, 1, r.A, 0, 1);
            return r;
        }

        public static matrix Inv(matrixS m)
        {
            matrix r = m;
            Inplace.Inv(r);
            return r;
        }

        public static matrix Inv(matrixT m)
        {
            matrix r = m;
            Inplace.Inv(r);
            return r;
        }

        public static matrix Inv(matrixTS m)
        {
            matrix r = m;
            Inplace.Inv(r);
            return r;
        }

        public static matrix Sqrt(matrix m)
        {
            var r = new matrix(m.Rows, m.Cols);
            Vml.Sqrt(m.Length, m.A, 0, 1, r.A, 0, 1);
            return r;
        }

        public static matrix Sqrt(matrixS m)
        {
            matrix r = m;
            Inplace.Sqrt(r);
            return r;
        }

        public static matrix Sqrt(matrixT m)
        {
            matrix r = m;
            Inplace.Sqrt(r);
            return r;
        }

        public static matrix Sqrt(matrixTS m)
        {
            matrix r = m;
            Inplace.Sqrt(r);
            return r;
        }

        public static matrix InvSqrt(matrix m)
        {
            var r = new matrix(m.Rows, m.Cols);
            Vml.InvSqrt(m.Length, m.A, 0, 1, r.A, 0, 1);
            return r;
        }

        public static matrix InvSqrt(matrixS m)
        {
            matrix r = m;
            Inplace.InvSqrt(r);
            return r;
        }

        public static matrix InvSqrt(matrixT m)
        {
            matrix r = m;
            Inplace.InvSqrt(r);
            return r;
        }

        public static matrix InvSqrt(matrixTS m)
        {
            matrix r = m;
            Inplace.InvSqrt(r);
            return r;
        }

        public static matrix Cbrt(matrix m)
        {
            var r = new matrix(m.Rows, m.Cols);
            Vml.Cbrt(m.Length, m.A, 0, 1, r.A, 0, 1);
            return r;
        }

        public static matrix Cbrt(matrixS m)
        {
            matrix r = m;
            Inplace.Cbrt(r);
            return r;
        }

        public static matrix Cbrt(matrixT m)
        {
            matrix r = m;
            Inplace.Cbrt(r);
            return r;
        }

        public static matrix Cbrt(matrixTS m)
        {
            matrix r = m;
            Inplace.Cbrt(r);
            return r;
        }

        public static matrix InvCbrt(matrix m)
        {
            var r = new matrix(m.Rows, m.Cols);
            Vml.InvCbrt(m.Length, m.A, 0, 1, r.A, 0, 1);
            return r;
        }

        public static matrix InvCbrt(matrixS m)
        {
            matrix r = m;
            Inplace.InvCbrt(r);
            return r;
        }

        public static matrix InvCbrt(matrixT m)
        {
            matrix r = m;
            Inplace.InvCbrt(r);
            return r;
        }

        public static matrix InvCbrt(matrixTS m)
        {
            matrix r = m;
            Inplace.InvCbrt(r);
            return r;
        }

        public static matrix Hypot(matrix a, matrix b)
        {
            if (a.Rows != b.Rows || a.Cols != b.Cols) ThrowHelper.ThrowIncorrectMatrixDimesionsForOperation();
            var r = new matrix(a.Rows, a.Cols);
            Vml.Hypot(a.Length, a.A, 0, 1, b.A, 0, 1, r.A, 0, 1);
            return r;
        }

        public static matrix Div(matrix a, matrix b)
        {
            if (a.Rows != b.Rows || a.Cols != b.Cols) ThrowHelper.ThrowIncorrectMatrixDimesionsForOperation();
            var r = new matrix(a.Rows, a.Cols);
            Vml.Div(a.Length, a.A, 0, 1, b.A, 0, 1, r.A, 0, 1);
            return r;
        }

        public static matrix Pow2o3(matrix m)
        {
            var r = new matrix(m.Rows, m.Cols);
            Vml.Pow2o3(m.Length, m.A, 0, 1, r.A, 0, 1);
            return r;
        }

        public static matrix Pow2o3(matrixS m)
        {
            matrix r = m;
            Inplace.Pow2o3(r);
            return r;
        }

        public static matrix Pow2o3(matrixT m)
        {
            matrix r = m;
            Inplace.Pow2o3(r);
            return r;
        }

        public static matrix Pow2o3(matrixTS m)
        {
            matrix r = m;
            Inplace.Pow2o3(r);
            return r;
        }

        public static matrix Pow3o2(matrix m)
        {
            var r = new matrix(m.Rows, m.Cols);
            Vml.Pow3o2(m.Length, m.A, 0, 1, r.A, 0, 1);
            return r;
        }

        public static matrix Pow3o2(matrixS m)
        {
            matrix r = m;
            Inplace.Pow3o2(r);
            return r;
        }

        public static matrix Pow3o2(matrixT m)
        {
            matrix r = m;
            Inplace.Pow3o2(r);
            return r;
        }

        public static matrix Pow3o2(matrixTS m)
        {
            matrix r = m;
            Inplace.Pow3o2(r);
            return r;
        }

        public static matrix Pow(matrix a, matrix b)
        {
            if (a.Rows != b.Rows || a.Cols != b.Cols) ThrowHelper.ThrowIncorrectMatrixDimesionsForOperation();
            var r = new matrix(a.Rows, a.Cols);
            Vml.Pow(a.Length, a.A, 0, 1, b.A, 0, 1, r.A, 0, 1);
            return r;
        }

        public static matrix Powr(matrix a, matrix b)
        {
            if (a.Rows != b.Rows || a.Cols != b.Cols) ThrowHelper.ThrowIncorrectMatrixDimesionsForOperation();
            var r = new matrix(a.Rows, a.Cols);
            Vml.Powr(a.Length, a.A, 0, 1, b.A, 0, 1, r.A, 0, 1);
            return r;
        }

        public static matrix Exp(matrix m)
        {
            var r = new matrix(m.Rows, m.Cols);
            Vml.Exp(m.Length, m.A, 0, 1, r.A, 0, 1);
            return r;
        }

        public static matrix Exp(matrixS m)
        {
            matrix r = m;
            Inplace.Exp(r);
            return r;
        }

        public static matrix Exp(matrixT m)
        {
            matrix r = m;
            Inplace.Exp(r);
            return r;
        }

        public static matrix Exp(matrixTS m)
        {
            matrix r = m;
            Inplace.Exp(r);
            return r;
        }

        public static matrix Exp2(matrix m)
        {
            var r = new matrix(m.Rows, m.Cols);
            Vml.Exp2(m.Length, m.A, 0, 1, r.A, 0, 1);
            return r;
        }

        public static matrix Exp2(matrixS m)
        {
            matrix r = m;
            Inplace.Exp2(r);
            return r;
        }

        public static matrix Exp2(matrixT m)
        {
            matrix r = m;
            Inplace.Exp2(r);
            return r;
        }

        public static matrix Exp2(matrixTS m)
        {
            matrix r = m;
            Inplace.Exp2(r);
            return r;
        }

        public static matrix Exp10(matrix m)
        {
            var r = new matrix(m.Rows, m.Cols);
            Vml.Exp10(m.Length, m.A, 0, 1, r.A, 0, 1);
            return r;
        }

        public static matrix Exp10(matrixS m)
        {
            matrix r = m;
            Inplace.Exp10(r);
            return r;
        }

        public static matrix Exp10(matrixT m)
        {
            matrix r = m;
            Inplace.Exp10(r);
            return r;
        }

        public static matrix Exp10(matrixTS m)
        {
            matrix r = m;
            Inplace.Exp10(r);
            return r;
        }

        public static matrix Expm1(matrix m)
        {
            var r = new matrix(m.Rows, m.Cols);
            Vml.Expm1(m.Length, m.A, 0, 1, r.A, 0, 1);
            return r;
        }

        public static matrix Expm1(matrixS m)
        {
            matrix r = m;
            Inplace.Expm1(r);
            return r;
        }

        public static matrix Expm1(matrixT m)
        {
            matrix r = m;
            Inplace.Expm1(r);
            return r;
        }

        public static matrix Expm1(matrixTS m)
        {
            matrix r = m;
            Inplace.Expm1(r);
            return r;
        }

        public static matrix Ln(matrix m)
        {
            var r = new matrix(m.Rows, m.Cols);
            Vml.Ln(m.Length, m.A, 0, 1, r.A, 0, 1);
            return r;
        }

        public static matrix Ln(matrixS m)
        {
            matrix r = m;
            Inplace.Ln(r);
            return r;
        }

        public static matrix Ln(matrixT m)
        {
            matrix r = m;
            Inplace.Ln(r);
            return r;
        }

        public static matrix Ln(matrixTS m)
        {
            matrix r = m;
            Inplace.Ln(r);
            return r;
        }

        public static matrix Log2(matrix m)
        {
            var r = new matrix(m.Rows, m.Cols);
            Vml.Log2(m.Length, m.A, 0, 1, r.A, 0, 1);
            return r;
        }

        public static matrix Log2(matrixS m)
        {
            matrix r = m;
            Inplace.Log2(r);
            return r;
        }

        public static matrix Log2(matrixT m)
        {
            matrix r = m;
            Inplace.Log2(r);
            return r;
        }

        public static matrix Log2(matrixTS m)
        {
            matrix r = m;
            Inplace.Log2(r);
            return r;
        }

        public static matrix Log10(matrix m)
        {
            var r = new matrix(m.Rows, m.Cols);
            Vml.Log10(m.Length, m.A, 0, 1, r.A, 0, 1);
            return r;
        }

        public static matrix Log10(matrixS m)
        {
            matrix r = m;
            Inplace.Log10(r);
            return r;
        }

        public static matrix Log10(matrixT m)
        {
            matrix r = m;
            Inplace.Log10(r);
            return r;
        }

        public static matrix Log10(matrixTS m)
        {
            matrix r = m;
            Inplace.Log10(r);
            return r;
        }

        public static matrix Log1p(matrix m)
        {
            var r = new matrix(m.Rows, m.Cols);
            Vml.Log1p(m.Length, m.A, 0, 1, r.A, 0, 1);
            return r;
        }

        public static matrix Log1p(matrixS m)
        {
            matrix r = m;
            Inplace.Log1p(r);
            return r;
        }

        public static matrix Log1p(matrixT m)
        {
            matrix r = m;
            Inplace.Log1p(r);
            return r;
        }

        public static matrix Log1p(matrixTS m)
        {
            matrix r = m;
            Inplace.Log1p(r);
            return r;
        }

        public static matrix Logb(matrix m)
        {
            var r = new matrix(m.Rows, m.Cols);
            Vml.Logb(m.Length, m.A, 0, 1, r.A, 0, 1);
            return r;
        }

        public static matrix Logb(matrixS m)
        {
            matrix r = m;
            Inplace.Logb(r);
            return r;
        }

        public static matrix Logb(matrixT m)
        {
            matrix r = m;
            Inplace.Logb(r);
            return r;
        }

        public static matrix Logb(matrixTS m)
        {
            matrix r = m;
            Inplace.Logb(r);
            return r;
        }

        public static matrix Cos(matrix m)
        {
            var r = new matrix(m.Rows, m.Cols);
            Vml.Cos(m.Length, m.A, 0, 1, r.A, 0, 1);
            return r;
        }

        public static matrix Cos(matrixS m)
        {
            matrix r = m;
            Inplace.Cos(r);
            return r;
        }

        public static matrix Cos(matrixT m)
        {
            matrix r = m;
            Inplace.Cos(r);
            return r;
        }

        public static matrix Cos(matrixTS m)
        {
            matrix r = m;
            Inplace.Cos(r);
            return r;
        }

        public static matrix Sin(matrix m)
        {
            var r = new matrix(m.Rows, m.Cols);
            Vml.Sin(m.Length, m.A, 0, 1, r.A, 0, 1);
            return r;
        }

        public static matrix Sin(matrixS m)
        {
            matrix r = m;
            Inplace.Sin(r);
            return r;
        }

        public static matrix Sin(matrixT m)
        {
            matrix r = m;
            Inplace.Sin(r);
            return r;
        }

        public static matrix Sin(matrixTS m)
        {
            matrix r = m;
            Inplace.Sin(r);
            return r;
        }

        public static matrix Tan(matrix m)
        {
            var r = new matrix(m.Rows, m.Cols);
            Vml.Tan(m.Length, m.A, 0, 1, r.A, 0, 1);
            return r;
        }

        public static matrix Tan(matrixS m)
        {
            matrix r = m;
            Inplace.Tan(r);
            return r;
        }

        public static matrix Tan(matrixT m)
        {
            matrix r = m;
            Inplace.Tan(r);
            return r;
        }

        public static matrix Tan(matrixTS m)
        {
            matrix r = m;
            Inplace.Tan(r);
            return r;
        }

        public static matrix Cospi(matrix m)
        {
            var r = new matrix(m.Rows, m.Cols);
            Vml.Cospi(m.Length, m.A, 0, 1, r.A, 0, 1);
            return r;
        }

        public static matrix Cospi(matrixS m)
        {
            matrix r = m;
            Inplace.Cospi(r);
            return r;
        }

        public static matrix Cospi(matrixT m)
        {
            matrix r = m;
            Inplace.Cospi(r);
            return r;
        }

        public static matrix Cospi(matrixTS m)
        {
            matrix r = m;
            Inplace.Cospi(r);
            return r;
        }

        public static matrix Sinpi(matrix m)
        {
            var r = new matrix(m.Rows, m.Cols);
            Vml.Sinpi(m.Length, m.A, 0, 1, r.A, 0, 1);
            return r;
        }

        public static matrix Sinpi(matrixS m)
        {
            matrix r = m;
            Inplace.Sinpi(r);
            return r;
        }

        public static matrix Sinpi(matrixT m)
        {
            matrix r = m;
            Inplace.Sinpi(r);
            return r;
        }

        public static matrix Sinpi(matrixTS m)
        {
            matrix r = m;
            Inplace.Sinpi(r);
            return r;
        }

        public static matrix Tanpi(matrix m)
        {
            var r = new matrix(m.Rows, m.Cols);
            Vml.Tanpi(m.Length, m.A, 0, 1, r.A, 0, 1);
            return r;
        }

        public static matrix Tanpi(matrixS m)
        {
            matrix r = m;
            Inplace.Tanpi(r);
            return r;
        }

        public static matrix Tanpi(matrixT m)
        {
            matrix r = m;
            Inplace.Tanpi(r);
            return r;
        }

        public static matrix Tanpi(matrixTS m)
        {
            matrix r = m;
            Inplace.Tanpi(r);
            return r;
        }

        public static matrix Cosd(matrix m)
        {
            var r = new matrix(m.Rows, m.Cols);
            Vml.Cosd(m.Length, m.A, 0, 1, r.A, 0, 1);
            return r;
        }

        public static matrix Cosd(matrixS m)
        {
            matrix r = m;
            Inplace.Cosd(r);
            return r;
        }

        public static matrix Cosd(matrixT m)
        {
            matrix r = m;
            Inplace.Cosd(r);
            return r;
        }

        public static matrix Cosd(matrixTS m)
        {
            matrix r = m;
            Inplace.Cosd(r);
            return r;
        }

        public static matrix Sind(matrix m)
        {
            var r = new matrix(m.Rows, m.Cols);
            Vml.Sind(m.Length, m.A, 0, 1, r.A, 0, 1);
            return r;
        }

        public static matrix Sind(matrixS m)
        {
            matrix r = m;
            Inplace.Sind(r);
            return r;
        }

        public static matrix Sind(matrixT m)
        {
            matrix r = m;
            Inplace.Sind(r);
            return r;
        }

        public static matrix Sind(matrixTS m)
        {
            matrix r = m;
            Inplace.Sind(r);
            return r;
        }

        public static matrix Tand(matrix m)
        {
            var r = new matrix(m.Rows, m.Cols);
            Vml.Tand(m.Length, m.A, 0, 1, r.A, 0, 1);
            return r;
        }

        public static matrix Tand(matrixS m)
        {
            matrix r = m;
            Inplace.Tand(r);
            return r;
        }

        public static matrix Tand(matrixT m)
        {
            matrix r = m;
            Inplace.Tand(r);
            return r;
        }

        public static matrix Tand(matrixTS m)
        {
            matrix r = m;
            Inplace.Tand(r);
            return r;
        }

        public static matrix Acos(matrix m)
        {
            var r = new matrix(m.Rows, m.Cols);
            Vml.Acos(m.Length, m.A, 0, 1, r.A, 0, 1);
            return r;
        }

        public static matrix Acos(matrixS m)
        {
            matrix r = m;
            Inplace.Acos(r);
            return r;
        }

        public static matrix Acos(matrixT m)
        {
            matrix r = m;
            Inplace.Acos(r);
            return r;
        }

        public static matrix Acos(matrixTS m)
        {
            matrix r = m;
            Inplace.Acos(r);
            return r;
        }

        public static matrix Asin(matrix m)
        {
            var r = new matrix(m.Rows, m.Cols);
            Vml.Asin(m.Length, m.A, 0, 1, r.A, 0, 1);
            return r;
        }

        public static matrix Asin(matrixS m)
        {
            matrix r = m;
            Inplace.Asin(r);
            return r;
        }

        public static matrix Asin(matrixT m)
        {
            matrix r = m;
            Inplace.Asin(r);
            return r;
        }

        public static matrix Asin(matrixTS m)
        {
            matrix r = m;
            Inplace.Asin(r);
            return r;
        }

        public static matrix Atan(matrix m)
        {
            var r = new matrix(m.Rows, m.Cols);
            Vml.Atan(m.Length, m.A, 0, 1, r.A, 0, 1);
            return r;
        }

        public static matrix Atan(matrixS m)
        {
            matrix r = m;
            Inplace.Atan(r);
            return r;
        }

        public static matrix Atan(matrixT m)
        {
            matrix r = m;
            Inplace.Atan(r);
            return r;
        }

        public static matrix Atan(matrixTS m)
        {
            matrix r = m;
            Inplace.Atan(r);
            return r;
        }

        public static matrix Acospi(matrix m)
        {
            var r = new matrix(m.Rows, m.Cols);
            Vml.Acospi(m.Length, m.A, 0, 1, r.A, 0, 1);
            return r;
        }

        public static matrix Acospi(matrixS m)
        {
            matrix r = m;
            Inplace.Acospi(r);
            return r;
        }

        public static matrix Acospi(matrixT m)
        {
            matrix r = m;
            Inplace.Acospi(r);
            return r;
        }

        public static matrix Acospi(matrixTS m)
        {
            matrix r = m;
            Inplace.Acospi(r);
            return r;
        }

        public static matrix Asinpi(matrix m)
        {
            var r = new matrix(m.Rows, m.Cols);
            Vml.Asinpi(m.Length, m.A, 0, 1, r.A, 0, 1);
            return r;
        }

        public static matrix Asinpi(matrixS m)
        {
            matrix r = m;
            Inplace.Asinpi(r);
            return r;
        }

        public static matrix Asinpi(matrixT m)
        {
            matrix r = m;
            Inplace.Asinpi(r);
            return r;
        }

        public static matrix Asinpi(matrixTS m)
        {
            matrix r = m;
            Inplace.Asinpi(r);
            return r;
        }

        public static matrix Atanpi(matrix m)
        {
            var r = new matrix(m.Rows, m.Cols);
            Vml.Atanpi(m.Length, m.A, 0, 1, r.A, 0, 1);
            return r;
        }

        public static matrix Atanpi(matrixS m)
        {
            matrix r = m;
            Inplace.Atanpi(r);
            return r;
        }

        public static matrix Atanpi(matrixT m)
        {
            matrix r = m;
            Inplace.Atanpi(r);
            return r;
        }

        public static matrix Atanpi(matrixTS m)
        {
            matrix r = m;
            Inplace.Atanpi(r);
            return r;
        }

        public static matrix Atan2(matrix a, matrix b)
        {
            if (a.Rows != b.Rows || a.Cols != b.Cols) ThrowHelper.ThrowIncorrectMatrixDimesionsForOperation();
            var r = new matrix(a.Rows, a.Cols);
            Vml.Atan2(a.Length, a.A, 0, 1, b.A, 0, 1, r.A, 0, 1);
            return r;
        }

        public static matrix Atan2pi(matrix a, matrix b)
        {
            if (a.Rows != b.Rows || a.Cols != b.Cols) ThrowHelper.ThrowIncorrectMatrixDimesionsForOperation();
            var r = new matrix(a.Rows, a.Cols);
            Vml.Atan2pi(a.Length, a.A, 0, 1, b.A, 0, 1, r.A, 0, 1);
            return r;
        }

        public static matrix Cosh(matrix m)
        {
            var r = new matrix(m.Rows, m.Cols);
            Vml.Cosh(m.Length, m.A, 0, 1, r.A, 0, 1);
            return r;
        }

        public static matrix Cosh(matrixS m)
        {
            matrix r = m;
            Inplace.Cosh(r);
            return r;
        }

        public static matrix Cosh(matrixT m)
        {
            matrix r = m;
            Inplace.Cosh(r);
            return r;
        }

        public static matrix Cosh(matrixTS m)
        {
            matrix r = m;
            Inplace.Cosh(r);
            return r;
        }

        public static matrix Sinh(matrix m)
        {
            var r = new matrix(m.Rows, m.Cols);
            Vml.Sinh(m.Length, m.A, 0, 1, r.A, 0, 1);
            return r;
        }

        public static matrix Sinh(matrixS m)
        {
            matrix r = m;
            Inplace.Sinh(r);
            return r;
        }

        public static matrix Sinh(matrixT m)
        {
            matrix r = m;
            Inplace.Sinh(r);
            return r;
        }

        public static matrix Sinh(matrixTS m)
        {
            matrix r = m;
            Inplace.Sinh(r);
            return r;
        }

        public static matrix Tanh(matrix m)
        {
            var r = new matrix(m.Rows, m.Cols);
            Vml.Tanh(m.Length, m.A, 0, 1, r.A, 0, 1);
            return r;
        }

        public static matrix Tanh(matrixS m)
        {
            matrix r = m;
            Inplace.Tanh(r);
            return r;
        }

        public static matrix Tanh(matrixT m)
        {
            matrix r = m;
            Inplace.Tanh(r);
            return r;
        }

        public static matrix Tanh(matrixTS m)
        {
            matrix r = m;
            Inplace.Tanh(r);
            return r;
        }

        public static matrix Acosh(matrix m)
        {
            var r = new matrix(m.Rows, m.Cols);
            Vml.Acosh(m.Length, m.A, 0, 1, r.A, 0, 1);
            return r;
        }

        public static matrix Acosh(matrixS m)
        {
            matrix r = m;
            Inplace.Acosh(r);
            return r;
        }

        public static matrix Acosh(matrixT m)
        {
            matrix r = m;
            Inplace.Acosh(r);
            return r;
        }

        public static matrix Acosh(matrixTS m)
        {
            matrix r = m;
            Inplace.Acosh(r);
            return r;
        }

        public static matrix Asinh(matrix m)
        {
            var r = new matrix(m.Rows, m.Cols);
            Vml.Asinh(m.Length, m.A, 0, 1, r.A, 0, 1);
            return r;
        }

        public static matrix Asinh(matrixS m)
        {
            matrix r = m;
            Inplace.Asinh(r);
            return r;
        }

        public static matrix Asinh(matrixT m)
        {
            matrix r = m;
            Inplace.Asinh(r);
            return r;
        }

        public static matrix Asinh(matrixTS m)
        {
            matrix r = m;
            Inplace.Asinh(r);
            return r;
        }

        public static matrix Atanh(matrix m)
        {
            var r = new matrix(m.Rows, m.Cols);
            Vml.Atanh(m.Length, m.A, 0, 1, r.A, 0, 1);
            return r;
        }

        public static matrix Atanh(matrixS m)
        {
            matrix r = m;
            Inplace.Atanh(r);
            return r;
        }

        public static matrix Atanh(matrixT m)
        {
            matrix r = m;
            Inplace.Atanh(r);
            return r;
        }

        public static matrix Atanh(matrixTS m)
        {
            matrix r = m;
            Inplace.Atanh(r);
            return r;
        }

        public static matrix Erf(matrix m)
        {
            var r = new matrix(m.Rows, m.Cols);
            Vml.Erf(m.Length, m.A, 0, 1, r.A, 0, 1);
            return r;
        }

        public static matrix Erf(matrixS m)
        {
            matrix r = m;
            Inplace.Erf(r);
            return r;
        }

        public static matrix Erf(matrixT m)
        {
            matrix r = m;
            Inplace.Erf(r);
            return r;
        }

        public static matrix Erf(matrixTS m)
        {
            matrix r = m;
            Inplace.Erf(r);
            return r;
        }

        public static matrix Erfc(matrix m)
        {
            var r = new matrix(m.Rows, m.Cols);
            Vml.Erfc(m.Length, m.A, 0, 1, r.A, 0, 1);
            return r;
        }

        public static matrix Erfc(matrixS m)
        {
            matrix r = m;
            Inplace.Erfc(r);
            return r;
        }

        public static matrix Erfc(matrixT m)
        {
            matrix r = m;
            Inplace.Erfc(r);
            return r;
        }

        public static matrix Erfc(matrixTS m)
        {
            matrix r = m;
            Inplace.Erfc(r);
            return r;
        }

        public static matrix ErfInv(matrix m)
        {
            var r = new matrix(m.Rows, m.Cols);
            Vml.ErfInv(m.Length, m.A, 0, 1, r.A, 0, 1);
            return r;
        }

        public static matrix ErfInv(matrixS m)
        {
            matrix r = m;
            Inplace.ErfInv(r);
            return r;
        }

        public static matrix ErfInv(matrixT m)
        {
            matrix r = m;
            Inplace.ErfInv(r);
            return r;
        }

        public static matrix ErfInv(matrixTS m)
        {
            matrix r = m;
            Inplace.ErfInv(r);
            return r;
        }

        public static matrix ErfcInv(matrix m)
        {
            var r = new matrix(m.Rows, m.Cols);
            Vml.ErfcInv(m.Length, m.A, 0, 1, r.A, 0, 1);
            return r;
        }

        public static matrix ErfcInv(matrixS m)
        {
            matrix r = m;
            Inplace.ErfcInv(r);
            return r;
        }

        public static matrix ErfcInv(matrixT m)
        {
            matrix r = m;
            Inplace.ErfcInv(r);
            return r;
        }

        public static matrix ErfcInv(matrixTS m)
        {
            matrix r = m;
            Inplace.ErfcInv(r);
            return r;
        }

        public static matrix CdfNorm(matrix m)
        {
            var r = new matrix(m.Rows, m.Cols);
            Vml.CdfNorm(m.Length, m.A, 0, 1, r.A, 0, 1);
            return r;
        }

        public static matrix CdfNorm(matrixS m)
        {
            matrix r = m;
            Inplace.CdfNorm(r);
            return r;
        }

        public static matrix CdfNorm(matrixT m)
        {
            matrix r = m;
            Inplace.CdfNorm(r);
            return r;
        }

        public static matrix CdfNorm(matrixTS m)
        {
            matrix r = m;
            Inplace.CdfNorm(r);
            return r;
        }

        public static matrix CdfNormInv(matrix m)
        {
            var r = new matrix(m.Rows, m.Cols);
            Vml.CdfNormInv(m.Length, m.A, 0, 1, r.A, 0, 1);
            return r;
        }

        public static matrix CdfNormInv(matrixS m)
        {
            matrix r = m;
            Inplace.CdfNormInv(r);
            return r;
        }

        public static matrix CdfNormInv(matrixT m)
        {
            matrix r = m;
            Inplace.CdfNormInv(r);
            return r;
        }

        public static matrix CdfNormInv(matrixTS m)
        {
            matrix r = m;
            Inplace.CdfNormInv(r);
            return r;
        }

        public static matrix LGamma(matrix m)
        {
            var r = new matrix(m.Rows, m.Cols);
            Vml.LGamma(m.Length, m.A, 0, 1, r.A, 0, 1);
            return r;
        }

        public static matrix LGamma(matrixS m)
        {
            matrix r = m;
            Inplace.LGamma(r);
            return r;
        }

        public static matrix LGamma(matrixT m)
        {
            matrix r = m;
            Inplace.LGamma(r);
            return r;
        }

        public static matrix LGamma(matrixTS m)
        {
            matrix r = m;
            Inplace.LGamma(r);
            return r;
        }

        public static matrix TGamma(matrix m)
        {
            var r = new matrix(m.Rows, m.Cols);
            Vml.TGamma(m.Length, m.A, 0, 1, r.A, 0, 1);
            return r;
        }

        public static matrix TGamma(matrixS m)
        {
            matrix r = m;
            Inplace.TGamma(r);
            return r;
        }

        public static matrix TGamma(matrixT m)
        {
            matrix r = m;
            Inplace.TGamma(r);
            return r;
        }

        public static matrix TGamma(matrixTS m)
        {
            matrix r = m;
            Inplace.TGamma(r);
            return r;
        }

        public static matrix ExpInt1(matrix m)
        {
            var r = new matrix(m.Rows, m.Cols);
            Vml.ExpInt1(m.Length, m.A, 0, 1, r.A, 0, 1);
            return r;
        }

        public static matrix ExpInt1(matrixS m)
        {
            matrix r = m;
            Inplace.ExpInt1(r);
            return r;
        }

        public static matrix ExpInt1(matrixT m)
        {
            matrix r = m;
            Inplace.ExpInt1(r);
            return r;
        }

        public static matrix ExpInt1(matrixTS m)
        {
            matrix r = m;
            Inplace.ExpInt1(r);
            return r;
        }

        public static matrix Floor(matrix m)
        {
            var r = new matrix(m.Rows, m.Cols);
            Vml.Floor(m.Length, m.A, 0, 1, r.A, 0, 1);
            return r;
        }

        public static matrix Floor(matrixS m)
        {
            matrix r = m;
            Inplace.Floor(r);
            return r;
        }

        public static matrix Floor(matrixT m)
        {
            matrix r = m;
            Inplace.Floor(r);
            return r;
        }

        public static matrix Floor(matrixTS m)
        {
            matrix r = m;
            Inplace.Floor(r);
            return r;
        }

        public static matrix Ceil(matrix m)
        {
            var r = new matrix(m.Rows, m.Cols);
            Vml.Ceil(m.Length, m.A, 0, 1, r.A, 0, 1);
            return r;
        }

        public static matrix Ceil(matrixS m)
        {
            matrix r = m;
            Inplace.Ceil(r);
            return r;
        }

        public static matrix Ceil(matrixT m)
        {
            matrix r = m;
            Inplace.Ceil(r);
            return r;
        }

        public static matrix Ceil(matrixTS m)
        {
            matrix r = m;
            Inplace.Ceil(r);
            return r;
        }

        public static matrix Trunc(matrix m)
        {
            var r = new matrix(m.Rows, m.Cols);
            Vml.Trunc(m.Length, m.A, 0, 1, r.A, 0, 1);
            return r;
        }

        public static matrix Trunc(matrixS m)
        {
            matrix r = m;
            Inplace.Trunc(r);
            return r;
        }

        public static matrix Trunc(matrixT m)
        {
            matrix r = m;
            Inplace.Trunc(r);
            return r;
        }

        public static matrix Trunc(matrixTS m)
        {
            matrix r = m;
            Inplace.Trunc(r);
            return r;
        }

        public static matrix Round(matrix m)
        {
            var r = new matrix(m.Rows, m.Cols);
            Vml.Round(m.Length, m.A, 0, 1, r.A, 0, 1);
            return r;
        }

        public static matrix Round(matrixS m)
        {
            matrix r = m;
            Inplace.Round(r);
            return r;
        }

        public static matrix Round(matrixT m)
        {
            matrix r = m;
            Inplace.Round(r);
            return r;
        }

        public static matrix Round(matrixTS m)
        {
            matrix r = m;
            Inplace.Round(r);
            return r;
        }

        public static matrix Frac(matrix m)
        {
            var r = new matrix(m.Rows, m.Cols);
            Vml.Frac(m.Length, m.A, 0, 1, r.A, 0, 1);
            return r;
        }

        public static matrix Frac(matrixS m)
        {
            matrix r = m;
            Inplace.Frac(r);
            return r;
        }

        public static matrix Frac(matrixT m)
        {
            matrix r = m;
            Inplace.Frac(r);
            return r;
        }

        public static matrix Frac(matrixTS m)
        {
            matrix r = m;
            Inplace.Frac(r);
            return r;
        }

        public static matrix NearbyInt(matrix m)
        {
            var r = new matrix(m.Rows, m.Cols);
            Vml.NearbyInt(m.Length, m.A, 0, 1, r.A, 0, 1);
            return r;
        }

        public static matrix NearbyInt(matrixS m)
        {
            matrix r = m;
            Inplace.NearbyInt(r);
            return r;
        }

        public static matrix NearbyInt(matrixT m)
        {
            matrix r = m;
            Inplace.NearbyInt(r);
            return r;
        }

        public static matrix NearbyInt(matrixTS m)
        {
            matrix r = m;
            Inplace.NearbyInt(r);
            return r;
        }

        public static matrix Rint(matrix m)
        {
            var r = new matrix(m.Rows, m.Cols);
            Vml.Rint(m.Length, m.A, 0, 1, r.A, 0, 1);
            return r;
        }

        public static matrix Rint(matrixS m)
        {
            matrix r = m;
            Inplace.Rint(r);
            return r;
        }

        public static matrix Rint(matrixT m)
        {
            matrix r = m;
            Inplace.Rint(r);
            return r;
        }

        public static matrix Rint(matrixTS m)
        {
            matrix r = m;
            Inplace.Rint(r);
            return r;
        }

        public static matrix CopySign(matrix a, matrix b)
        {
            if (a.Rows != b.Rows || a.Cols != b.Cols) ThrowHelper.ThrowIncorrectMatrixDimesionsForOperation();
            var r = new matrix(a.Rows, a.Cols);
            Vml.CopySign(a.Length, a.A, 0, 1, b.A, 0, 1, r.A, 0, 1);
            return r;
        }

        public static matrix Fmax(matrix a, matrix b)
        {
            if (a.Rows != b.Rows || a.Cols != b.Cols) ThrowHelper.ThrowIncorrectMatrixDimesionsForOperation();
            var r = new matrix(a.Rows, a.Cols);
            Vml.Fmax(a.Length, a.A, 0, 1, b.A, 0, 1, r.A, 0, 1);
            return r;
        }

        public static matrix Fmin(matrix a, matrix b)
        {
            if (a.Rows != b.Rows || a.Cols != b.Cols) ThrowHelper.ThrowIncorrectMatrixDimesionsForOperation();
            var r = new matrix(a.Rows, a.Cols);
            Vml.Fmin(a.Length, a.A, 0, 1, b.A, 0, 1, r.A, 0, 1);
            return r;
        }

        public static matrix Fdim(matrix a, matrix b)
        {
            if (a.Rows != b.Rows || a.Cols != b.Cols) ThrowHelper.ThrowIncorrectMatrixDimesionsForOperation();
            var r = new matrix(a.Rows, a.Cols);
            Vml.Fdim(a.Length, a.A, 0, 1, b.A, 0, 1, r.A, 0, 1);
            return r;
        }

        public static matrix MaxMag(matrix a, matrix b)
        {
            if (a.Rows != b.Rows || a.Cols != b.Cols) ThrowHelper.ThrowIncorrectMatrixDimesionsForOperation();
            var r = new matrix(a.Rows, a.Cols);
            Vml.MaxMag(a.Length, a.A, 0, 1, b.A, 0, 1, r.A, 0, 1);
            return r;
        }

        public static matrix NextAfter(matrix a, matrix b)
        {
            if (a.Rows != b.Rows || a.Cols != b.Cols) ThrowHelper.ThrowIncorrectMatrixDimesionsForOperation();
            var r = new matrix(a.Rows, a.Cols);
            Vml.NextAfter(a.Length, a.A, 0, 1, b.A, 0, 1, r.A, 0, 1);
            return r;
        }

        public static matrix Powx(matrix a, double b)
        {
            var r = new matrix(a.Rows, a.Cols);
            Vml.Powx(a.Length, a.A, 0, 1, b, r.A, 0, 1);
            return r;
        }

        public static matrix Powx(matrixS m, double b)
        {
            matrix r = m;
            Inplace.Powx(r, b);
            return r;
        }

        public static matrix Powx(matrixT m, double b)
        {
            matrix r = m;
            Inplace.Powx(r, b);
            return r;
        }

        public static matrix Powx(matrixTS m, double b)
        {
            matrix r = m;
            Inplace.Powx(r, b);
            return r;
        }

        public static (matrix, matrix) SinCos(matrix m)
        {
            var sin = new matrix(m.Rows, m.Cols);
            var cos = new matrix(m.Rows, m.Cols);
            Vml.SinCos(m.Length, m.A, 0, 1, sin.A, 0, 1, cos.A, 0, 1);
            return (sin, cos);
        }

        public static (matrix, matrix) SinCos(matrixS m)
        {
            matrix sin = m;
            var cos = Inplace.SinCos(sin);
            return (sin, cos);
        }

        public static (matrix, matrix) SinCos(matrixT m)
        {
            matrix sin = m;
            var cos = Inplace.SinCos(sin);
            return (sin, cos);
        }

        public static (matrix, matrix) SinCos(matrixTS m)
        {
            matrix sin = m;
            var cos = Inplace.SinCos(sin);
            return (sin, cos);
        }

        public static (matrix, matrix) Modf(matrix m)
        {
            var tru = new matrix(m.Rows, m.Cols);
            var rem = new matrix(m.Rows, m.Cols);
            Vml.Modf(m.Length, m.A, 0, 1, tru.A, 0, 1, rem.A, 0, 1);
            return (tru, rem);
        }

        public static (matrix, matrix) Modf(matrixS m)
        {
            matrix tru = m;
            var rem = Inplace.Modf(tru);
            return (tru, rem);
        }

        public static (matrix, matrix) Modf(matrixT m)
        {
            matrix tru = m;
            var rem = Inplace.Modf(tru);
            return (tru, rem);
        }

        public static (matrix, matrix) Modf(matrixTS m)
        {
            matrix tru = m;
            var rem = Inplace.Modf(tru);
            return (tru, rem);
        }

        public static matrix LinearFrac(matrix a, matrix b, double scalea, double shifta, double scaleb, double shiftb)
        {
            if (a.Rows != b.Rows || a.Cols != b.Cols) ThrowHelper.ThrowIncorrectMatrixDimesionsForOperation();
            var r = new matrix(a.Rows, a.Cols);
            Vml.LinearFrac(a.Length, a.A, 0, 1, b.A, 0, 1, scalea, shifta, scaleb, shiftb, r.A, 0, 1);
            return r;
        }
    }
}

// TODO
// matrixT etc for binary functions (15 each!)
// Test for each function
// matrix vector Blas functions
// matrix Lapack functions