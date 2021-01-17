using System;

namespace MKLNET
{
    public static partial class Matrix
    {
        internal static ArrayPool<int> IntPool = new(ArrayPool<int>.DefaultMaxNumberOfArraysPerBucket, Environment.Is64BitProcess ? 20 : 10);
        public static void ResetPools(int maxArrayLength, int maxArraysPerBucket)
        {
            IntPool = new(maxArrayLength, maxArraysPerBucket);
            matrix.Pool = new(maxArrayLength, maxArraysPerBucket);
            matrixF.Pool = new(maxArrayLength, maxArraysPerBucket);
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
            MatrixInplace.Abs(r);
            return r;
        }

        public static matrix Abs(matrixT a)
        {
            matrix r = a;
            MatrixInplace.Abs(r);
            return r;
        }

        public static matrix Abs(matrixTS a)
        {
            matrix r = a;
            MatrixInplace.Abs(r);
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
            MatrixInplace.Sqr(r);
            return r;
        }

        public static matrix Sqr(matrixT a)
        {
            matrix r = a;
            MatrixInplace.Sqr(r);
            return r;
        }

        public static matrix Sqr(matrixTS a)
        {
            matrix r = a;
            MatrixInplace.Sqr(r);
            return r;
        }

        public static matrix Mul(matrix a, matrix b)
        {
            if (a.Rows != b.Rows || a.Cols != b.Cols) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new matrix(a.Rows, a.Cols);
            Vml.Mul(a.Length, a.Array, 0, 1, b.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrix Mul(matrixS a, matrix b)
        {
            matrix r = a;
            MatrixInplace.Mul(r, b);
            return r;
        }

        public static matrix Mul(matrixT a, matrix b)
        {
            matrix r = a;
            MatrixInplace.Mul(r, b);
            return r;
        }

        public static matrix Mul(matrixTS a, matrix b)
        {
            matrix r = a;
            MatrixInplace.Mul(r, b);
            return r;
        }

        public static matrix Fmod(matrix a, matrix b)
        {
            if (a.Rows != b.Rows || a.Cols != b.Cols) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new matrix(a.Rows, a.Cols);
            Vml.Fmod(a.Length, a.Array, 0, 1, b.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrix Fmod(matrixS a, matrix b)
        {
            matrix r = a;
            MatrixInplace.Fmod(r, b);
            return r;
        }

        public static matrix Fmod(matrixT a, matrix b)
        {
            matrix r = a;
            MatrixInplace.Fmod(r, b);
            return r;
        }

        public static matrix Fmod(matrixTS a, matrix b)
        {
            matrix r = a;
            MatrixInplace.Fmod(r, b);
            return r;
        }

        public static matrix Remainder(matrix a, matrix b)
        {
            if (a.Rows != b.Rows || a.Cols != b.Cols) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new matrix(a.Rows, a.Cols);
            Vml.Remainder(a.Length, a.Array, 0, 1, b.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrix Remainder(matrixS a, matrix b)
        {
            matrix r = a;
            MatrixInplace.Remainder(r, b);
            return r;
        }

        public static matrix Remainder(matrixT a, matrix b)
        {
            matrix r = a;
            MatrixInplace.Remainder(r, b);
            return r;
        }

        public static matrix Remainder(matrixTS a, matrix b)
        {
            matrix r = a;
            MatrixInplace.Remainder(r, b);
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
            MatrixInplace.Inv(r);
            return r;
        }

        public static matrix Inv(matrixT a)
        {
            matrix r = a;
            MatrixInplace.Inv(r);
            return r;
        }

        public static matrix Inv(matrixTS a)
        {
            matrix r = a;
            MatrixInplace.Inv(r);
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
            MatrixInplace.Sqrt(r);
            return r;
        }

        public static matrix Sqrt(matrixT a)
        {
            matrix r = a;
            MatrixInplace.Sqrt(r);
            return r;
        }

        public static matrix Sqrt(matrixTS a)
        {
            matrix r = a;
            MatrixInplace.Sqrt(r);
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
            MatrixInplace.InvSqrt(r);
            return r;
        }

        public static matrix InvSqrt(matrixT a)
        {
            matrix r = a;
            MatrixInplace.InvSqrt(r);
            return r;
        }

        public static matrix InvSqrt(matrixTS a)
        {
            matrix r = a;
            MatrixInplace.InvSqrt(r);
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
            MatrixInplace.Cbrt(r);
            return r;
        }

        public static matrix Cbrt(matrixT a)
        {
            matrix r = a;
            MatrixInplace.Cbrt(r);
            return r;
        }

        public static matrix Cbrt(matrixTS a)
        {
            matrix r = a;
            MatrixInplace.Cbrt(r);
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
            MatrixInplace.InvCbrt(r);
            return r;
        }

        public static matrix InvCbrt(matrixT a)
        {
            matrix r = a;
            MatrixInplace.InvCbrt(r);
            return r;
        }

        public static matrix InvCbrt(matrixTS a)
        {
            matrix r = a;
            MatrixInplace.InvCbrt(r);
            return r;
        }

        public static matrix Hypot(matrix a, matrix b)
        {
            if (a.Rows != b.Rows || a.Cols != b.Cols) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new matrix(a.Rows, a.Cols);
            Vml.Hypot(a.Length, a.Array, 0, 1, b.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrix Hypot(matrixS a, matrix b)
        {
            matrix r = a;
            MatrixInplace.Hypot(r, b);
            return r;
        }

        public static matrix Hypot(matrixT a, matrix b)
        {
            matrix r = a;
            MatrixInplace.Hypot(r, b);
            return r;
        }

        public static matrix Hypot(matrixTS a, matrix b)
        {
            matrix r = a;
            MatrixInplace.Hypot(r, b);
            return r;
        }

        public static matrix Div(matrix a, matrix b)
        {
            if (a.Rows != b.Rows || a.Cols != b.Cols) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new matrix(a.Rows, a.Cols);
            Vml.Div(a.Length, a.Array, 0, 1, b.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrix Div(matrixS a, matrix b)
        {
            matrix r = a;
            MatrixInplace.Div(r, b);
            return r;
        }

        public static matrix Div(matrixT a, matrix b)
        {
            matrix r = a;
            MatrixInplace.Div(r, b);
            return r;
        }

        public static matrix Div(matrixTS a, matrix b)
        {
            matrix r = a;
            MatrixInplace.Div(r, b);
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
            MatrixInplace.Pow2o3(r);
            return r;
        }

        public static matrix Pow2o3(matrixT a)
        {
            matrix r = a;
            MatrixInplace.Pow2o3(r);
            return r;
        }

        public static matrix Pow2o3(matrixTS a)
        {
            matrix r = a;
            MatrixInplace.Pow2o3(r);
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
            MatrixInplace.Pow3o2(r);
            return r;
        }

        public static matrix Pow3o2(matrixT a)
        {
            matrix r = a;
            MatrixInplace.Pow3o2(r);
            return r;
        }

        public static matrix Pow3o2(matrixTS a)
        {
            matrix r = a;
            MatrixInplace.Pow3o2(r);
            return r;
        }

        public static matrix Pow(matrix a, matrix b)
        {
            if (a.Rows != b.Rows || a.Cols != b.Cols) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new matrix(a.Rows, a.Cols);
            Vml.Pow(a.Length, a.Array, 0, 1, b.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrix Pow(matrixS a, matrix b)
        {
            matrix r = a;
            MatrixInplace.Pow(r, b);
            return r;
        }

        public static matrix Pow(matrixT a, matrix b)
        {
            matrix r = a;
            MatrixInplace.Pow(r, b);
            return r;
        }

        public static matrix Pow(matrixTS a, matrix b)
        {
            matrix r = a;
            MatrixInplace.Pow(r, b);
            return r;
        }

        public static matrix Powr(matrix a, matrix b)
        {
            if (a.Rows != b.Rows || a.Cols != b.Cols) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new matrix(a.Rows, a.Cols);
            Vml.Powr(a.Length, a.Array, 0, 1, b.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrix Powr(matrixS a, matrix b)
        {
            matrix r = a;
            MatrixInplace.Powr(r, b);
            return r;
        }

        public static matrix Powr(matrixT a, matrix b)
        {
            matrix r = a;
            MatrixInplace.Powr(r, b);
            return r;
        }

        public static matrix Powr(matrixTS a, matrix b)
        {
            matrix r = a;
            MatrixInplace.Powr(r, b);
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
            MatrixInplace.Exp(r);
            return r;
        }

        public static matrix Exp(matrixT a)
        {
            matrix r = a;
            MatrixInplace.Exp(r);
            return r;
        }

        public static matrix Exp(matrixTS a)
        {
            matrix r = a;
            MatrixInplace.Exp(r);
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
            MatrixInplace.Exp2(r);
            return r;
        }

        public static matrix Exp2(matrixT a)
        {
            matrix r = a;
            MatrixInplace.Exp2(r);
            return r;
        }

        public static matrix Exp2(matrixTS a)
        {
            matrix r = a;
            MatrixInplace.Exp2(r);
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
            MatrixInplace.Exp10(r);
            return r;
        }

        public static matrix Exp10(matrixT a)
        {
            matrix r = a;
            MatrixInplace.Exp10(r);
            return r;
        }

        public static matrix Exp10(matrixTS a)
        {
            matrix r = a;
            MatrixInplace.Exp10(r);
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
            MatrixInplace.Expm1(r);
            return r;
        }

        public static matrix Expm1(matrixT a)
        {
            matrix r = a;
            MatrixInplace.Expm1(r);
            return r;
        }

        public static matrix Expm1(matrixTS a)
        {
            matrix r = a;
            MatrixInplace.Expm1(r);
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
            MatrixInplace.Ln(r);
            return r;
        }

        public static matrix Ln(matrixT a)
        {
            matrix r = a;
            MatrixInplace.Ln(r);
            return r;
        }

        public static matrix Ln(matrixTS a)
        {
            matrix r = a;
            MatrixInplace.Ln(r);
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
            MatrixInplace.Log2(r);
            return r;
        }

        public static matrix Log2(matrixT a)
        {
            matrix r = a;
            MatrixInplace.Log2(r);
            return r;
        }

        public static matrix Log2(matrixTS a)
        {
            matrix r = a;
            MatrixInplace.Log2(r);
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
            MatrixInplace.Log10(r);
            return r;
        }

        public static matrix Log10(matrixT a)
        {
            matrix r = a;
            MatrixInplace.Log10(r);
            return r;
        }

        public static matrix Log10(matrixTS a)
        {
            matrix r = a;
            MatrixInplace.Log10(r);
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
            MatrixInplace.Log1p(r);
            return r;
        }

        public static matrix Log1p(matrixT a)
        {
            matrix r = a;
            MatrixInplace.Log1p(r);
            return r;
        }

        public static matrix Log1p(matrixTS a)
        {
            matrix r = a;
            MatrixInplace.Log1p(r);
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
            MatrixInplace.Logb(r);
            return r;
        }

        public static matrix Logb(matrixT a)
        {
            matrix r = a;
            MatrixInplace.Logb(r);
            return r;
        }

        public static matrix Logb(matrixTS a)
        {
            matrix r = a;
            MatrixInplace.Logb(r);
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
            MatrixInplace.Cos(r);
            return r;
        }

        public static matrix Cos(matrixT a)
        {
            matrix r = a;
            MatrixInplace.Cos(r);
            return r;
        }

        public static matrix Cos(matrixTS a)
        {
            matrix r = a;
            MatrixInplace.Cos(r);
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
            MatrixInplace.Sin(r);
            return r;
        }

        public static matrix Sin(matrixT a)
        {
            matrix r = a;
            MatrixInplace.Sin(r);
            return r;
        }

        public static matrix Sin(matrixTS a)
        {
            matrix r = a;
            MatrixInplace.Sin(r);
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
            MatrixInplace.Tan(r);
            return r;
        }

        public static matrix Tan(matrixT a)
        {
            matrix r = a;
            MatrixInplace.Tan(r);
            return r;
        }

        public static matrix Tan(matrixTS a)
        {
            matrix r = a;
            MatrixInplace.Tan(r);
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
            MatrixInplace.Cospi(r);
            return r;
        }

        public static matrix Cospi(matrixT a)
        {
            matrix r = a;
            MatrixInplace.Cospi(r);
            return r;
        }

        public static matrix Cospi(matrixTS a)
        {
            matrix r = a;
            MatrixInplace.Cospi(r);
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
            MatrixInplace.Sinpi(r);
            return r;
        }

        public static matrix Sinpi(matrixT a)
        {
            matrix r = a;
            MatrixInplace.Sinpi(r);
            return r;
        }

        public static matrix Sinpi(matrixTS a)
        {
            matrix r = a;
            MatrixInplace.Sinpi(r);
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
            MatrixInplace.Tanpi(r);
            return r;
        }

        public static matrix Tanpi(matrixT a)
        {
            matrix r = a;
            MatrixInplace.Tanpi(r);
            return r;
        }

        public static matrix Tanpi(matrixTS a)
        {
            matrix r = a;
            MatrixInplace.Tanpi(r);
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
            MatrixInplace.Cosd(r);
            return r;
        }

        public static matrix Cosd(matrixT a)
        {
            matrix r = a;
            MatrixInplace.Cosd(r);
            return r;
        }

        public static matrix Cosd(matrixTS a)
        {
            matrix r = a;
            MatrixInplace.Cosd(r);
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
            MatrixInplace.Sind(r);
            return r;
        }

        public static matrix Sind(matrixT a)
        {
            matrix r = a;
            MatrixInplace.Sind(r);
            return r;
        }

        public static matrix Sind(matrixTS a)
        {
            matrix r = a;
            MatrixInplace.Sind(r);
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
            MatrixInplace.Tand(r);
            return r;
        }

        public static matrix Tand(matrixT a)
        {
            matrix r = a;
            MatrixInplace.Tand(r);
            return r;
        }

        public static matrix Tand(matrixTS a)
        {
            matrix r = a;
            MatrixInplace.Tand(r);
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
            MatrixInplace.Acos(r);
            return r;
        }

        public static matrix Acos(matrixT a)
        {
            matrix r = a;
            MatrixInplace.Acos(r);
            return r;
        }

        public static matrix Acos(matrixTS a)
        {
            matrix r = a;
            MatrixInplace.Acos(r);
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
            MatrixInplace.Asin(r);
            return r;
        }

        public static matrix Asin(matrixT a)
        {
            matrix r = a;
            MatrixInplace.Asin(r);
            return r;
        }

        public static matrix Asin(matrixTS a)
        {
            matrix r = a;
            MatrixInplace.Asin(r);
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
            MatrixInplace.Atan(r);
            return r;
        }

        public static matrix Atan(matrixT a)
        {
            matrix r = a;
            MatrixInplace.Atan(r);
            return r;
        }

        public static matrix Atan(matrixTS a)
        {
            matrix r = a;
            MatrixInplace.Atan(r);
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
            MatrixInplace.Acospi(r);
            return r;
        }

        public static matrix Acospi(matrixT a)
        {
            matrix r = a;
            MatrixInplace.Acospi(r);
            return r;
        }

        public static matrix Acospi(matrixTS a)
        {
            matrix r = a;
            MatrixInplace.Acospi(r);
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
            MatrixInplace.Asinpi(r);
            return r;
        }

        public static matrix Asinpi(matrixT a)
        {
            matrix r = a;
            MatrixInplace.Asinpi(r);
            return r;
        }

        public static matrix Asinpi(matrixTS a)
        {
            matrix r = a;
            MatrixInplace.Asinpi(r);
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
            MatrixInplace.Atanpi(r);
            return r;
        }

        public static matrix Atanpi(matrixT a)
        {
            matrix r = a;
            MatrixInplace.Atanpi(r);
            return r;
        }

        public static matrix Atanpi(matrixTS a)
        {
            matrix r = a;
            MatrixInplace.Atanpi(r);
            return r;
        }

        public static matrix Atan2(matrix a, matrix b)
        {
            if (a.Rows != b.Rows || a.Cols != b.Cols) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new matrix(a.Rows, a.Cols);
            Vml.Atan2(a.Length, a.Array, 0, 1, b.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrix Atan2(matrixS a, matrix b)
        {
            matrix r = a;
            MatrixInplace.Atan2(r, b);
            return r;
        }

        public static matrix Atan2(matrixT a, matrix b)
        {
            matrix r = a;
            MatrixInplace.Atan2(r, b);
            return r;
        }

        public static matrix Atan2(matrixTS a, matrix b)
        {
            matrix r = a;
            MatrixInplace.Atan2(r, b);
            return r;
        }

        public static matrix Atan2pi(matrix a, matrix b)
        {
            if (a.Rows != b.Rows || a.Cols != b.Cols) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new matrix(a.Rows, a.Cols);
            Vml.Atan2pi(a.Length, a.Array, 0, 1, b.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrix Atan2pi(matrixS a, matrix b)
        {
            matrix r = a;
            MatrixInplace.Atan2pi(r, b);
            return r;
        }

        public static matrix Atan2pi(matrixT a, matrix b)
        {
            matrix r = a;
            MatrixInplace.Atan2pi(r, b);
            return r;
        }

        public static matrix Atan2pi(matrixTS a, matrix b)
        {
            matrix r = a;
            MatrixInplace.Atan2pi(r, b);
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
            MatrixInplace.Cosh(r);
            return r;
        }

        public static matrix Cosh(matrixT a)
        {
            matrix r = a;
            MatrixInplace.Cosh(r);
            return r;
        }

        public static matrix Cosh(matrixTS a)
        {
            matrix r = a;
            MatrixInplace.Cosh(r);
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
            MatrixInplace.Sinh(r);
            return r;
        }

        public static matrix Sinh(matrixT a)
        {
            matrix r = a;
            MatrixInplace.Sinh(r);
            return r;
        }

        public static matrix Sinh(matrixTS a)
        {
            matrix r = a;
            MatrixInplace.Sinh(r);
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
            MatrixInplace.Tanh(r);
            return r;
        }

        public static matrix Tanh(matrixT a)
        {
            matrix r = a;
            MatrixInplace.Tanh(r);
            return r;
        }

        public static matrix Tanh(matrixTS a)
        {
            matrix r = a;
            MatrixInplace.Tanh(r);
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
            MatrixInplace.Acosh(r);
            return r;
        }

        public static matrix Acosh(matrixT a)
        {
            matrix r = a;
            MatrixInplace.Acosh(r);
            return r;
        }

        public static matrix Acosh(matrixTS a)
        {
            matrix r = a;
            MatrixInplace.Acosh(r);
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
            MatrixInplace.Asinh(r);
            return r;
        }

        public static matrix Asinh(matrixT a)
        {
            matrix r = a;
            MatrixInplace.Asinh(r);
            return r;
        }

        public static matrix Asinh(matrixTS a)
        {
            matrix r = a;
            MatrixInplace.Asinh(r);
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
            MatrixInplace.Atanh(r);
            return r;
        }

        public static matrix Atanh(matrixT a)
        {
            matrix r = a;
            MatrixInplace.Atanh(r);
            return r;
        }

        public static matrix Atanh(matrixTS a)
        {
            matrix r = a;
            MatrixInplace.Atanh(r);
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
            MatrixInplace.Erf(r);
            return r;
        }

        public static matrix Erf(matrixT a)
        {
            matrix r = a;
            MatrixInplace.Erf(r);
            return r;
        }

        public static matrix Erf(matrixTS a)
        {
            matrix r = a;
            MatrixInplace.Erf(r);
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
            MatrixInplace.Erfc(r);
            return r;
        }

        public static matrix Erfc(matrixT a)
        {
            matrix r = a;
            MatrixInplace.Erfc(r);
            return r;
        }

        public static matrix Erfc(matrixTS a)
        {
            matrix r = a;
            MatrixInplace.Erfc(r);
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
            MatrixInplace.ErfInv(r);
            return r;
        }

        public static matrix ErfInv(matrixT a)
        {
            matrix r = a;
            MatrixInplace.ErfInv(r);
            return r;
        }

        public static matrix ErfInv(matrixTS a)
        {
            matrix r = a;
            MatrixInplace.ErfInv(r);
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
            MatrixInplace.ErfcInv(r);
            return r;
        }

        public static matrix ErfcInv(matrixT a)
        {
            matrix r = a;
            MatrixInplace.ErfcInv(r);
            return r;
        }

        public static matrix ErfcInv(matrixTS a)
        {
            matrix r = a;
            MatrixInplace.ErfcInv(r);
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
            MatrixInplace.CdfNorm(r);
            return r;
        }

        public static matrix CdfNorm(matrixT a)
        {
            matrix r = a;
            MatrixInplace.CdfNorm(r);
            return r;
        }

        public static matrix CdfNorm(matrixTS a)
        {
            matrix r = a;
            MatrixInplace.CdfNorm(r);
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
            MatrixInplace.CdfNormInv(r);
            return r;
        }

        public static matrix CdfNormInv(matrixT a)
        {
            matrix r = a;
            MatrixInplace.CdfNormInv(r);
            return r;
        }

        public static matrix CdfNormInv(matrixTS a)
        {
            matrix r = a;
            MatrixInplace.CdfNormInv(r);
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
            MatrixInplace.LGamma(r);
            return r;
        }

        public static matrix LGamma(matrixT a)
        {
            matrix r = a;
            MatrixInplace.LGamma(r);
            return r;
        }

        public static matrix LGamma(matrixTS a)
        {
            matrix r = a;
            MatrixInplace.LGamma(r);
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
            MatrixInplace.TGamma(r);
            return r;
        }

        public static matrix TGamma(matrixT a)
        {
            matrix r = a;
            MatrixInplace.TGamma(r);
            return r;
        }

        public static matrix TGamma(matrixTS a)
        {
            matrix r = a;
            MatrixInplace.TGamma(r);
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
            MatrixInplace.ExpInt1(r);
            return r;
        }

        public static matrix ExpInt1(matrixT a)
        {
            matrix r = a;
            MatrixInplace.ExpInt1(r);
            return r;
        }

        public static matrix ExpInt1(matrixTS a)
        {
            matrix r = a;
            MatrixInplace.ExpInt1(r);
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
            MatrixInplace.Floor(r);
            return r;
        }

        public static matrix Floor(matrixT a)
        {
            matrix r = a;
            MatrixInplace.Floor(r);
            return r;
        }

        public static matrix Floor(matrixTS a)
        {
            matrix r = a;
            MatrixInplace.Floor(r);
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
            MatrixInplace.Ceil(r);
            return r;
        }

        public static matrix Ceil(matrixT a)
        {
            matrix r = a;
            MatrixInplace.Ceil(r);
            return r;
        }

        public static matrix Ceil(matrixTS a)
        {
            matrix r = a;
            MatrixInplace.Ceil(r);
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
            MatrixInplace.Trunc(r);
            return r;
        }

        public static matrix Trunc(matrixT a)
        {
            matrix r = a;
            MatrixInplace.Trunc(r);
            return r;
        }

        public static matrix Trunc(matrixTS a)
        {
            matrix r = a;
            MatrixInplace.Trunc(r);
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
            MatrixInplace.Round(r);
            return r;
        }

        public static matrix Round(matrixT a)
        {
            matrix r = a;
            MatrixInplace.Round(r);
            return r;
        }

        public static matrix Round(matrixTS a)
        {
            matrix r = a;
            MatrixInplace.Round(r);
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
            MatrixInplace.Frac(r);
            return r;
        }

        public static matrix Frac(matrixT a)
        {
            matrix r = a;
            MatrixInplace.Frac(r);
            return r;
        }

        public static matrix Frac(matrixTS a)
        {
            matrix r = a;
            MatrixInplace.Frac(r);
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
            MatrixInplace.NearbyInt(r);
            return r;
        }

        public static matrix NearbyInt(matrixT a)
        {
            matrix r = a;
            MatrixInplace.NearbyInt(r);
            return r;
        }

        public static matrix NearbyInt(matrixTS a)
        {
            matrix r = a;
            MatrixInplace.NearbyInt(r);
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
            MatrixInplace.Rint(r);
            return r;
        }

        public static matrix Rint(matrixT a)
        {
            matrix r = a;
            MatrixInplace.Rint(r);
            return r;
        }

        public static matrix Rint(matrixTS a)
        {
            matrix r = a;
            MatrixInplace.Rint(r);
            return r;
        }

        public static matrix CopySign(matrix a, matrix b)
        {
            if (a.Rows != b.Rows || a.Cols != b.Cols) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new matrix(a.Rows, a.Cols);
            Vml.CopySign(a.Length, a.Array, 0, 1, b.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrix CopySign(matrixS a, matrix b)
        {
            matrix r = a;
            MatrixInplace.CopySign(r, b);
            return r;
        }

        public static matrix CopySign(matrixT a, matrix b)
        {
            matrix r = a;
            MatrixInplace.CopySign(r, b);
            return r;
        }

        public static matrix CopySign(matrixTS a, matrix b)
        {
            matrix r = a;
            MatrixInplace.CopySign(r, b);
            return r;
        }

        public static matrix Fmax(matrix a, matrix b)
        {
            if (a.Rows != b.Rows || a.Cols != b.Cols) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new matrix(a.Rows, a.Cols);
            Vml.Fmax(a.Length, a.Array, 0, 1, b.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrix Fmax(matrixS a, matrix b)
        {
            matrix r = a;
            MatrixInplace.Fmax(r, b);
            return r;
        }

        public static matrix Fmax(matrixT a, matrix b)
        {
            matrix r = a;
            MatrixInplace.Fmax(r, b);
            return r;
        }

        public static matrix Fmax(matrixTS a, matrix b)
        {
            matrix r = a;
            MatrixInplace.Fmax(r, b);
            return r;
        }

        public static matrix Fmin(matrix a, matrix b)
        {
            if (a.Rows != b.Rows || a.Cols != b.Cols) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new matrix(a.Rows, a.Cols);
            Vml.Fmin(a.Length, a.Array, 0, 1, b.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrix Fmin(matrixS a, matrix b)
        {
            matrix r = a;
            MatrixInplace.Fmin(r, b);
            return r;
        }

        public static matrix Fmin(matrixT a, matrix b)
        {
            matrix r = a;
            MatrixInplace.Fmin(r, b);
            return r;
        }

        public static matrix Fmin(matrixTS a, matrix b)
        {
            matrix r = a;
            MatrixInplace.Fmin(r, b);
            return r;
        }

        public static matrix Fdim(matrix a, matrix b)
        {
            if (a.Rows != b.Rows || a.Cols != b.Cols) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new matrix(a.Rows, a.Cols);
            Vml.Fdim(a.Length, a.Array, 0, 1, b.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrix Fdim(matrixS a, matrix b)
        {
            matrix r = a;
            MatrixInplace.Fdim(r, b);
            return r;
        }

        public static matrix Fdim(matrixT a, matrix b)
        {
            matrix r = a;
            MatrixInplace.Fdim(r, b);
            return r;
        }

        public static matrix Fdim(matrixTS a, matrix b)
        {
            matrix r = a;
            MatrixInplace.Fdim(r, b);
            return r;
        }

        public static matrix MaxMag(matrix a, matrix b)
        {
            if (a.Rows != b.Rows || a.Cols != b.Cols) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new matrix(a.Rows, a.Cols);
            Vml.MaxMag(a.Length, a.Array, 0, 1, b.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrix MaxMag(matrixS a, matrix b)
        {
            matrix r = a;
            MatrixInplace.MaxMag(r, b);
            return r;
        }

        public static matrix MaxMag(matrixT a, matrix b)
        {
            matrix r = a;
            MatrixInplace.MaxMag(r, b);
            return r;
        }

        public static matrix MaxMag(matrixTS a, matrix b)
        {
            matrix r = a;
            MatrixInplace.MaxMag(r, b);
            return r;
        }

        public static matrix NextAfter(matrix a, matrix b)
        {
            if (a.Rows != b.Rows || a.Cols != b.Cols) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new matrix(a.Rows, a.Cols);
            Vml.NextAfter(a.Length, a.Array, 0, 1, b.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrix NextAfter(matrixS a, matrix b)
        {
            matrix r = a;
            MatrixInplace.NextAfter(r, b);
            return r;
        }

        public static matrix NextAfter(matrixT a, matrix b)
        {
            matrix r = a;
            MatrixInplace.NextAfter(r, b);
            return r;
        }

        public static matrix NextAfter(matrixTS a, matrix b)
        {
            matrix r = a;
            MatrixInplace.NextAfter(r, b);
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
            MatrixInplace.Powx(r, b);
            return r;
        }

        public static matrix Powx(matrixT a, double b)
        {
            matrix r = a;
            MatrixInplace.Powx(r, b);
            return r;
        }

        public static matrix Powx(matrixTS a, double b)
        {
            matrix r = a;
            MatrixInplace.Powx(r, b);
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
            var cos = MatrixInplace.SinCos(sin);
            return (sin, cos);
        }

        public static (matrix, matrix) SinCos(matrixT a)
        {
            matrix sin = a;
            var cos = MatrixInplace.SinCos(sin);
            return (sin, cos);
        }

        public static (matrix, matrix) SinCos(matrixTS a)
        {
            matrix sin = a;
            var cos = MatrixInplace.SinCos(sin);
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
            var rem = MatrixInplace.Modf(tru);
            return (tru, rem);
        }

        public static (matrix, matrix) Modf(matrixT a)
        {
            matrix tru = a;
            var rem = MatrixInplace.Modf(tru);
            return (tru, rem);
        }

        public static (matrix, matrix) Modf(matrixTS a)
        {
            matrix tru = a;
            var rem = MatrixInplace.Modf(tru);
            return (tru, rem);
        }

        public static matrix LinearFrac(matrix a, matrix b, double scalea, double shifta, double scaleb, double shiftb)
        {
            if (a.Rows != b.Rows || a.Cols != b.Cols) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new matrix(a.Rows, a.Cols);
            Vml.LinearFrac(a.Length, a.Array, 0, 1, b.Array, 0, 1, scalea, shifta, scaleb, shiftb, r.Array, 0, 1);
            return r;
        }

        public static matrix LinearFrac(matrixS a, double scalea, double shifta, matrix b, double scaleb, double shiftb)
        {
            matrix r = a;
            MatrixInplace.LinearFrac(r, scalea, shifta, b, scaleb, shiftb);
            return r;
        }

        public static matrix LinearFrac(matrixT a, double scalea, double shifta, matrix b, double scaleb, double shiftb)
        {
            matrix r = a;
            MatrixInplace.LinearFrac(r, scalea, shifta, b, scaleb, shiftb);
            return r;
        }

        public static matrix LinearFrac(matrixTS a, double scalea, double shifta, matrix b, double scaleb, double shiftb)
        {
            matrix r = a;
            MatrixInplace.LinearFrac(r, scalea, shifta, b, scaleb, shiftb);
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
            MatrixInplace.Cholesky(r);
            return r;
        }

        public static matrix Solve(matrix a, matrix b)
        {
            a = Copy(a);
            b = Copy(b);
            MatrixInplace.Solve(a, b);
            return b;
        }

        public static vector Solve(matrix a, vector b)
        {
            a = Copy(a);
            b = Vector.Copy(b);
            MatrixInplace.Solve(a, b);
            return b;
        }

        public static matrix Inverse(matrix a)
        {
            a = Copy(a);
            MatrixInplace.Inverse(a);
            return a;
        }

        public static (matrix, vector) Eigens(matrix a)
        {
            a = Copy(a);
            var w = MatrixInplace.Eigens(a);
            return (a, w);
        }

        public static matrix LeastSquares(matrix a, matrix b)
        {
            a = Copy(a);
            b = Copy(b);
            MatrixInplace.LeastSquares(a, b);
            return b;
        }

        public static partial class Examples
        {
            public static matrix RngGaussian(int rows, int cols, uint seed, double mean, double sigma)
            {
                var r = new matrix(rows, cols);
                var stream = Vsl.NewStream(VslBrng.MT19937, seed);
                ThrowHelper.Check(Vsl.RngGaussian(VslMethodGaussian.ICDF, stream, r.Length, r.Array, mean, sigma));
                ThrowHelper.Check(Vsl.DeleteStream(stream));
                return r;
            }

            public static (vector, matrix) MeanAndCovariance(matrix samples, vector weights)
            {
                if (samples.Rows != weights.Length) ThrowHelper.ThrowIncorrectDimensionsForOperation();
                var mean = new vector(samples.Cols);
                var cov = new matrix(samples.Cols, samples.Cols);
                var task = Vsl.SSNewTask(samples.Cols, samples.Rows, VslStorage.ROWS, samples.Array, weights.Array);
                ThrowHelper.Check(Vsl.SSEditCovCor(task, mean.Array, cov.Array, VslFormat.FULL, null, VslFormat.FULL));
                ThrowHelper.Check(Vsl.SSCompute(task, VslEstimate.COV, VslMethod.FAST));
                ThrowHelper.Check(Vsl.SSDeleteTask(task));
                return (mean, cov);
            }
        }
    }

    public static partial class MatrixInplace
    {
        public static matrix Abs(this matrix a)
        {
            Vml.Abs(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static matrix Add(this matrix a, matrix b)
        {
            Vml.Add(a.Length, a.Array, 0, 1, b.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static matrix AddMul(this matrix a, double s, matrix b)
        {
            Vml.LinearFrac(a.Length, a.Array, 0, 1, b.Array, 0, 1, 1.0, 0.0, s, 0.0, a.Array, 0, 1);
            return a;
        }

        public static matrix Sub(this matrix a, matrix b)
        {
            Vml.Sub(a.Length, a.Array, 0, 1, b.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static matrix Sqr(this matrix a)
        {
            Vml.Sqr(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static matrix Mul(this matrix a, matrix b)
        {
            Vml.Mul(a.Length, a.Array, 0, 1, b.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static matrix PreMul(this matrix a, matrix b)
        {
            Vml.Mul(b.Length, b.Array, 0, 1, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static matrix Fmod(this matrix a, matrix b)
        {
            Vml.Fmod(a.Length, a.Array, 0, 1, b.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static matrix Remainder(this matrix a, matrix b)
        {
            Vml.Remainder(a.Length, a.Array, 0, 1, b.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static matrix Inv(this matrix a)
        {
            Vml.Inv(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static matrix Sqrt(this matrix a)
        {
            Vml.Sqrt(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static matrix InvSqrt(this matrix a)
        {
            Vml.InvSqrt(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static matrix Cbrt(this matrix a)
        {
            Vml.Cbrt(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static matrix InvCbrt(this matrix a)
        {
            Vml.InvCbrt(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static matrix Hypot(this matrix a, matrix b)
        {
            Vml.Hypot(a.Length, a.Array, 0, 1, b.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static matrix Div(this matrix a, matrix b)
        {
            Vml.Div(a.Length, a.Array, 0, 1, b.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static matrix Pow2o3(this matrix a)
        {
            Vml.Pow2o3(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static matrix Pow3o2(this matrix a)
        {
            Vml.Pow3o2(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static matrix Pow(this matrix a, matrix b)
        {
            Vml.Pow(a.Length, a.Array, 0, 1, b.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static matrix Powr(this matrix a, matrix b)
        {
            Vml.Powr(a.Length, a.Array, 0, 1, b.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static matrix Exp(this matrix a)
        {
            Vml.Exp(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static matrix Exp2(this matrix a)
        {
            Vml.Exp2(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static matrix Exp10(this matrix a)
        {
            Vml.Exp10(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static matrix Expm1(this matrix a)
        {
            Vml.Expm1(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static matrix Ln(this matrix a)
        {
            Vml.Ln(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static matrix Log2(this matrix a)
        {
            Vml.Log2(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static matrix Log10(this matrix a)
        {
            Vml.Log10(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static matrix Log1p(this matrix a)
        {
            Vml.Log1p(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static matrix Logb(this matrix a)
        {
            Vml.Logb(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static matrix Cos(this matrix a)
        {
            Vml.Cos(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static matrix Sin(this matrix a)
        {
            Vml.Sin(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static matrix Tan(this matrix a)
        {
            Vml.Tan(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static matrix Cospi(this matrix a)
        {
            Vml.Cospi(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static matrix Sinpi(this matrix a)
        {
            Vml.Sinpi(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static matrix Tanpi(this matrix a)
        {
            Vml.Tanpi(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static matrix Cosd(this matrix a)
        {
            Vml.Cosd(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static matrix Sind(this matrix a)
        {
            Vml.Sind(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static matrix Tand(this matrix a)
        {
            Vml.Tand(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static matrix Acos(this matrix a)
        {
            Vml.Acos(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static matrix Asin(this matrix a)
        {
            Vml.Asin(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static matrix Atan(this matrix a)
        {
            Vml.Atan(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static matrix Acospi(this matrix a)
        {
            Vml.Acospi(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static matrix Asinpi(this matrix a)
        {
            Vml.Asinpi(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static matrix Atanpi(this matrix a)
        {
            Vml.Atanpi(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static matrix Atan2(this matrix a, matrix b)
        {
            Vml.Atan2(a.Length, a.Array, 0, 1, b.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static matrix Atan2pi(this matrix a, matrix b)
        {
            Vml.Atan2pi(a.Length, a.Array, 0, 1, b.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static matrix Cosh(this matrix a)
        {
            Vml.Cosh(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static matrix Sinh(this matrix a)
        {
            Vml.Sinh(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static matrix Tanh(this matrix a)
        {
            Vml.Tanh(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static matrix Acosh(this matrix a)
        {
            Vml.Acosh(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static matrix Asinh(this matrix a)
        {
            Vml.Asinh(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static matrix Atanh(this matrix a)
        {
            Vml.Atanh(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static matrix Erf(this matrix a)
        {
            Vml.Erf(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static matrix Erfc(this matrix a)
        {
            Vml.Erfc(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static matrix ErfInv(this matrix a)
        {
            Vml.ErfInv(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static matrix ErfcInv(this matrix a)
        {
            Vml.ErfcInv(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static matrix CdfNorm(this matrix a)
        {
            Vml.CdfNorm(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static matrix CdfNormInv(this matrix a)
        {
            Vml.CdfNormInv(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static matrix LGamma(this matrix a)
        {
            Vml.LGamma(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static matrix TGamma(this matrix a)
        {
            Vml.TGamma(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static matrix ExpInt1(this matrix a)
        {
            Vml.ExpInt1(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static matrix Floor(this matrix a)
        {
            Vml.Floor(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static matrix Ceil(this matrix a)
        {
            Vml.Ceil(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static matrix Trunc(this matrix a)
        {
            Vml.Trunc(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static matrix Round(this matrix a)
        {
            Vml.Round(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static matrix Frac(this matrix a)
        {
            Vml.Frac(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static matrix NearbyInt(this matrix a)
        {
            Vml.NearbyInt(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static matrix Rint(this matrix a)
        {
            Vml.Rint(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static matrix CopySign(this matrix a, matrix b)
        {
            Vml.CopySign(a.Length, a.Array, 0, 1, b.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static matrix Fmax(this matrix a, matrix b)
        {
            Vml.Fmax(a.Length, a.Array, 0, 1, b.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static matrix Fmin(this matrix a, matrix b)
        {
            Vml.Fmin(a.Length, a.Array, 0, 1, b.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static matrix Fdim(this matrix a, matrix b)
        {
            Vml.Fdim(a.Length, a.Array, 0, 1, b.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static matrix MaxMag(this matrix a, matrix b)
        {
            Vml.MaxMag(a.Length, a.Array, 0, 1, b.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static matrix NextAfter(this matrix a, matrix b)
        {
            Vml.NextAfter(a.Length, a.Array, 0, 1, b.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static matrix Powx(this matrix a, double b)
        {
            Vml.Powx(a.Length, a.Array, 0, 1, b, a.Array, 0, 1);
            return a;
        }

        public static matrix LinearFrac(this matrix a, double scalea, double shifta, matrix b, double scaleb, double shiftb)
        {
            Vml.LinearFrac(a.Length, a.Array, 0, 1, b.Array, 0, 1, scalea, shifta, scaleb, shiftb, a.Array, 0, 1);
            return a;
        }

        public static matrix LinearFrac(this matrix a, double scalea, matrix b, double scaleb)
        {
            Vml.LinearFrac(a.Length, a.Array, 0, 1, b.Array, 0, 1, scalea, 0.0, scaleb, 0.0, a.Array, 0, 1);
            return a;
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

        public static matrix Scal(this matrix a, double s)
        {
            Blas.scal(a.Length, s, a.Array, 0, 1);
            return a;
        }

        public static matrix Lower(this matrix a)
        {
            for (int c = 1; c < a.Cols; c++)
                for (int r = 0; r < c; r++)
                    a[r, c] = 0.0;
            return a;
        }

        public static matrix Upper(this matrix a)
        {
            for (int c = 0; c < a.Cols; c++)
                for (int r = c + 1; r < a.Rows; r++)
                    a[r, c] = 0.0;
            return a;
        }

        public static matrix Cholesky(this matrix a)
        {
            if (a.Rows != a.Cols) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            Lower(a);
            ThrowHelper.Check(Lapack.potrf2(Layout.ColMajor, UpLoChar.Lower, a.Rows, a.Array, a.Rows));
            return a;
        }

        public static matrix Solve(this matrix a, matrix b)
        {
            if (a.Rows != a.Cols || a.Rows != b.Rows) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var ipiv = Matrix.IntPool.Rent(a.Rows);
            ThrowHelper.Check(Lapack.gesv(Layout.ColMajor, a.Rows, b.Cols, a.Array, a.Rows, ipiv, b.Array, a.Rows));
            Matrix.IntPool.Return(ipiv);
            return a;
        }

        public static matrix Solve(this matrix a, vector b)
        {
            if (a.Rows != a.Cols || a.Rows != b.Length) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var ipiv = Matrix.IntPool.Rent(a.Rows);
            ThrowHelper.Check(Lapack.gesv(Layout.ColMajor, a.Rows, 1, a.Array, a.Rows, ipiv, b.Array, a.Rows));
            Matrix.IntPool.Return(ipiv);
            return a;
        }

        public static matrix Inverse(this matrix a)
        {
            if (a.Rows != a.Cols) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var ipiv = Matrix.IntPool.Rent(a.Rows);
            ThrowHelper.Check(Lapack.getrf(Layout.ColMajor, a.Rows, a.Rows, a.Array, a.Rows, ipiv));
            ThrowHelper.Check(Lapack.getri(Layout.ColMajor, a.Rows, a.Array, a.Rows, ipiv));
            Matrix.IntPool.Return(ipiv);
            return a;
        }

        public static vector Eigens(matrix a)
        {
            if (a.Rows != a.Cols) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var w = new vector(a.Rows);
            ThrowHelper.Check(Lapack.syev(Layout.ColMajor, 'V', UpLoChar.Lower, a.Rows, a.Array, a.Rows, w.Array));
            return w;
        }

        public static matrix LeastSquares(this matrix a, matrix b)
        {
            if (a.Rows != b.Rows || a.Cols > a.Rows) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            Lapack.gels(Layout.RowMajor, TransChar.No, a.Rows, a.Cols, b.Cols, a.Array, a.Cols, b.Array, b.Cols);
            return a;
        }

        public static matrix Copy(this matrix a, matrix b)
        {
            Blas.copy(b.Length, b.Array, 0, 1, a.Array, 0, 1);
            return a;
        }
    }
}