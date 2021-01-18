using System;

namespace MKLNET
{
    public static partial class Matrix
    {
        public static matrixF Abs(matrixF a)
        {
            var r = new matrixF(a.Rows, a.Cols);
            Vml.Abs(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrixF Abs(matrixFS a)
        {
            matrixF r = a;
            MatrixInplace.Abs(r);
            return r;
        }

        public static matrixF Abs(matrixFT a)
        {
            matrixF r = a;
            MatrixInplace.Abs(r);
            return r;
        }

        public static matrixF Abs(matrixFTS a)
        {
            matrixF r = a;
            MatrixInplace.Abs(r);
            return r;
        }

        public static matrixF Sqr(matrixF a)
        {
            var r = new matrixF(a.Rows, a.Cols);
            Vml.Sqr(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrixF Sqr(matrixFS a)
        {
            matrixF r = a;
            MatrixInplace.Sqr(r);
            return r;
        }

        public static matrixF Sqr(matrixFT a)
        {
            matrixF r = a;
            MatrixInplace.Sqr(r);
            return r;
        }

        public static matrixF Sqr(matrixFTS a)
        {
            matrixF r = a;
            MatrixInplace.Sqr(r);
            return r;
        }

        public static matrixF Dot(matrixF a, matrixF b)
        {
            if (a.Rows != b.Rows || a.Cols != b.Cols) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new matrixF(a.Rows, a.Cols);
            Vml.Mul(a.Length, a.Array, 0, 1, b.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrixF Mul(matrixFS a, matrixF b)
        {
            matrixF r = a;
            MatrixInplace.Dot(r, b);
            return r;
        }

        public static matrixF Mul(matrixFT a, matrixF b)
        {
            matrixF r = a;
            MatrixInplace.Dot(r, b);
            return r;
        }

        public static matrixF Mul(matrixFTS a, matrixF b)
        {
            matrixF r = a;
            MatrixInplace.Dot(r, b);
            return r;
        }

        public static matrixF Fmod(matrixF a, matrixF b)
        {
            if (a.Rows != b.Rows || a.Cols != b.Cols) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new matrixF(a.Rows, a.Cols);
            Vml.Fmod(a.Length, a.Array, 0, 1, b.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrixF Fmod(matrixFS a, matrixF b)
        {
            matrixF r = a;
            MatrixInplace.Fmod(r, b);
            return r;
        }

        public static matrixF Fmod(matrixFT a, matrixF b)
        {
            matrixF r = a;
            MatrixInplace.Fmod(r, b);
            return r;
        }

        public static matrixF Fmod(matrixFTS a, matrixF b)
        {
            matrixF r = a;
            MatrixInplace.Fmod(r, b);
            return r;
        }

        public static matrixF Remainder(matrixF a, matrixF b)
        {
            if (a.Rows != b.Rows || a.Cols != b.Cols) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new matrixF(a.Rows, a.Cols);
            Vml.Remainder(a.Length, a.Array, 0, 1, b.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrixF Remainder(matrixFS a, matrixF b)
        {
            matrixF r = a;
            MatrixInplace.Remainder(r, b);
            return r;
        }

        public static matrixF Remainder(matrixFT a, matrixF b)
        {
            matrixF r = a;
            MatrixInplace.Remainder(r, b);
            return r;
        }

        public static matrixF Remainder(matrixFTS a, matrixF b)
        {
            matrixF r = a;
            MatrixInplace.Remainder(r, b);
            return r;
        }

        public static matrixF Inv(matrixF a)
        {
            var r = new matrixF(a.Rows, a.Cols);
            Vml.Inv(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrixF Inv(matrixFS a)
        {
            matrixF r = a;
            MatrixInplace.Inv(r);
            return r;
        }

        public static matrixF Inv(matrixFT a)
        {
            matrixF r = a;
            MatrixInplace.Inv(r);
            return r;
        }

        public static matrixF Inv(matrixFTS a)
        {
            matrixF r = a;
            MatrixInplace.Inv(r);
            return r;
        }

        public static matrixF Sqrt(matrixF a)
        {
            var r = new matrixF(a.Rows, a.Cols);
            Vml.Sqrt(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrixF Sqrt(matrixFS a)
        {
            matrixF r = a;
            MatrixInplace.Sqrt(r);
            return r;
        }

        public static matrixF Sqrt(matrixFT a)
        {
            matrixF r = a;
            MatrixInplace.Sqrt(r);
            return r;
        }

        public static matrixF Sqrt(matrixFTS a)
        {
            matrixF r = a;
            MatrixInplace.Sqrt(r);
            return r;
        }

        public static matrixF InvSqrt(matrixF m)
        {
            var r = new matrixF(m.Rows, m.Cols);
            Vml.InvSqrt(m.Length, m.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrixF InvSqrt(matrixFS a)
        {
            matrixF r = a;
            MatrixInplace.InvSqrt(r);
            return r;
        }

        public static matrixF InvSqrt(matrixFT a)
        {
            matrixF r = a;
            MatrixInplace.InvSqrt(r);
            return r;
        }

        public static matrixF InvSqrt(matrixFTS a)
        {
            matrixF r = a;
            MatrixInplace.InvSqrt(r);
            return r;
        }

        public static matrixF Cbrt(matrixF a)
        {
            var r = new matrixF(a.Rows, a.Cols);
            Vml.Cbrt(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrixF Cbrt(matrixFS a)
        {
            matrixF r = a;
            MatrixInplace.Cbrt(r);
            return r;
        }

        public static matrixF Cbrt(matrixFT a)
        {
            matrixF r = a;
            MatrixInplace.Cbrt(r);
            return r;
        }

        public static matrixF Cbrt(matrixFTS a)
        {
            matrixF r = a;
            MatrixInplace.Cbrt(r);
            return r;
        }

        public static matrixF InvCbrt(matrixF a)
        {
            var r = new matrixF(a.Rows, a.Cols);
            Vml.InvCbrt(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrixF InvCbrt(matrixFS a)
        {
            matrixF r = a;
            MatrixInplace.InvCbrt(r);
            return r;
        }

        public static matrixF InvCbrt(matrixFT a)
        {
            matrixF r = a;
            MatrixInplace.InvCbrt(r);
            return r;
        }

        public static matrixF InvCbrt(matrixFTS a)
        {
            matrixF r = a;
            MatrixInplace.InvCbrt(r);
            return r;
        }

        public static matrixF Hypot(matrixF a, matrixF b)
        {
            if (a.Rows != b.Rows || a.Cols != b.Cols) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new matrixF(a.Rows, a.Cols);
            Vml.Hypot(a.Length, a.Array, 0, 1, b.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrixF Hypot(matrixFS a, matrixF b)
        {
            matrixF r = a;
            MatrixInplace.Hypot(r, b);
            return r;
        }

        public static matrixF Hypot(matrixFT a, matrixF b)
        {
            matrixF r = a;
            MatrixInplace.Hypot(r, b);
            return r;
        }

        public static matrixF Hypot(matrixFTS a, matrixF b)
        {
            matrixF r = a;
            MatrixInplace.Hypot(r, b);
            return r;
        }

        public static matrixF Div(matrixF a, matrixF b)
        {
            if (a.Rows != b.Rows || a.Cols != b.Cols) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new matrixF(a.Rows, a.Cols);
            Vml.Div(a.Length, a.Array, 0, 1, b.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrixF Div(matrixFS a, matrixF b)
        {
            matrixF r = a;
            MatrixInplace.Div(r, b);
            return r;
        }

        public static matrixF Div(matrixFT a, matrixF b)
        {
            matrixF r = a;
            MatrixInplace.Div(r, b);
            return r;
        }

        public static matrixF Div(matrixFTS a, matrixF b)
        {
            matrixF r = a;
            MatrixInplace.Div(r, b);
            return r;
        }

        public static matrixF Pow2o3(matrixF a)
        {
            var r = new matrixF(a.Rows, a.Cols);
            Vml.Pow2o3(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrixF Pow2o3(matrixFS a)
        {
            matrixF r = a;
            MatrixInplace.Pow2o3(r);
            return r;
        }

        public static matrixF Pow2o3(matrixFT a)
        {
            matrixF r = a;
            MatrixInplace.Pow2o3(r);
            return r;
        }

        public static matrixF Pow2o3(matrixFTS a)
        {
            matrixF r = a;
            MatrixInplace.Pow2o3(r);
            return r;
        }

        public static matrixF Pow3o2(matrixF a)
        {
            var r = new matrixF(a.Rows, a.Cols);
            Vml.Pow3o2(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrixF Pow3o2(matrixFS a)
        {
            matrixF r = a;
            MatrixInplace.Pow3o2(r);
            return r;
        }

        public static matrixF Pow3o2(matrixFT a)
        {
            matrixF r = a;
            MatrixInplace.Pow3o2(r);
            return r;
        }

        public static matrixF Pow3o2(matrixFTS a)
        {
            matrixF r = a;
            MatrixInplace.Pow3o2(r);
            return r;
        }

        public static matrixF Pow(matrixF a, matrixF b)
        {
            if (a.Rows != b.Rows || a.Cols != b.Cols) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new matrixF(a.Rows, a.Cols);
            Vml.Pow(a.Length, a.Array, 0, 1, b.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrixF Pow(matrixFS a, matrixF b)
        {
            matrixF r = a;
            MatrixInplace.Pow(r, b);
            return r;
        }

        public static matrixF Pow(matrixFT a, matrixF b)
        {
            matrixF r = a;
            MatrixInplace.Pow(r, b);
            return r;
        }

        public static matrixF Pow(matrixFTS a, matrixF b)
        {
            matrixF r = a;
            MatrixInplace.Pow(r, b);
            return r;
        }

        public static matrixF Powr(matrixF a, matrixF b)
        {
            if (a.Rows != b.Rows || a.Cols != b.Cols) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new matrixF(a.Rows, a.Cols);
            Vml.Powr(a.Length, a.Array, 0, 1, b.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrixF Powr(matrixFS a, matrixF b)
        {
            matrixF r = a;
            MatrixInplace.Powr(r, b);
            return r;
        }

        public static matrixF Powr(matrixFT a, matrixF b)
        {
            matrixF r = a;
            MatrixInplace.Powr(r, b);
            return r;
        }

        public static matrixF Powr(matrixFTS a, matrixF b)
        {
            matrixF r = a;
            MatrixInplace.Powr(r, b);
            return r;
        }

        public static matrixF Exp(matrixF a)
        {
            var r = new matrixF(a.Rows, a.Cols);
            Vml.Exp(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrixF Exp(matrixFS a)
        {
            matrixF r = a;
            MatrixInplace.Exp(r);
            return r;
        }

        public static matrixF Exp(matrixFT a)
        {
            matrixF r = a;
            MatrixInplace.Exp(r);
            return r;
        }

        public static matrixF Exp(matrixFTS a)
        {
            matrixF r = a;
            MatrixInplace.Exp(r);
            return r;
        }

        public static matrixF Exp2(matrixF a)
        {
            var r = new matrixF(a.Rows, a.Cols);
            Vml.Exp2(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrixF Exp2(matrixFS a)
        {
            matrixF r = a;
            MatrixInplace.Exp2(r);
            return r;
        }

        public static matrixF Exp2(matrixFT a)
        {
            matrixF r = a;
            MatrixInplace.Exp2(r);
            return r;
        }

        public static matrixF Exp2(matrixFTS a)
        {
            matrixF r = a;
            MatrixInplace.Exp2(r);
            return r;
        }

        public static matrixF Exp10(matrixF a)
        {
            var r = new matrixF(a.Rows, a.Cols);
            Vml.Exp10(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrixF Exp10(matrixFS a)
        {
            matrixF r = a;
            MatrixInplace.Exp10(r);
            return r;
        }

        public static matrixF Exp10(matrixFT a)
        {
            matrixF r = a;
            MatrixInplace.Exp10(r);
            return r;
        }

        public static matrixF Exp10(matrixFTS a)
        {
            matrixF r = a;
            MatrixInplace.Exp10(r);
            return r;
        }

        public static matrixF Expm1(matrixF a)
        {
            var r = new matrixF(a.Rows, a.Cols);
            Vml.Expm1(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrixF Expm1(matrixFS a)
        {
            matrixF r = a;
            MatrixInplace.Expm1(r);
            return r;
        }

        public static matrixF Expm1(matrixFT a)
        {
            matrixF r = a;
            MatrixInplace.Expm1(r);
            return r;
        }

        public static matrixF Expm1(matrixFTS a)
        {
            matrixF r = a;
            MatrixInplace.Expm1(r);
            return r;
        }

        public static matrixF Ln(matrixF a)
        {
            var r = new matrixF(a.Rows, a.Cols);
            Vml.Ln(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrixF Ln(matrixFS a)
        {
            matrixF r = a;
            MatrixInplace.Ln(r);
            return r;
        }

        public static matrixF Ln(matrixFT a)
        {
            matrixF r = a;
            MatrixInplace.Ln(r);
            return r;
        }

        public static matrixF Ln(matrixFTS a)
        {
            matrixF r = a;
            MatrixInplace.Ln(r);
            return r;
        }

        public static matrixF Log2(matrixF a)
        {
            var r = new matrixF(a.Rows, a.Cols);
            Vml.Log2(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrixF Log2(matrixFS a)
        {
            matrixF r = a;
            MatrixInplace.Log2(r);
            return r;
        }

        public static matrixF Log2(matrixFT a)
        {
            matrixF r = a;
            MatrixInplace.Log2(r);
            return r;
        }

        public static matrixF Log2(matrixFTS a)
        {
            matrixF r = a;
            MatrixInplace.Log2(r);
            return r;
        }

        public static matrixF Log10(matrixF a)
        {
            var r = new matrixF(a.Rows, a.Cols);
            Vml.Log10(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrixF Log10(matrixFS a)
        {
            matrixF r = a;
            MatrixInplace.Log10(r);
            return r;
        }

        public static matrixF Log10(matrixFT a)
        {
            matrixF r = a;
            MatrixInplace.Log10(r);
            return r;
        }

        public static matrixF Log10(matrixFTS a)
        {
            matrixF r = a;
            MatrixInplace.Log10(r);
            return r;
        }

        public static matrixF Log1p(matrixF a)
        {
            var r = new matrixF(a.Rows, a.Cols);
            Vml.Log1p(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrixF Log1p(matrixFS a)
        {
            matrixF r = a;
            MatrixInplace.Log1p(r);
            return r;
        }

        public static matrixF Log1p(matrixFT a)
        {
            matrixF r = a;
            MatrixInplace.Log1p(r);
            return r;
        }

        public static matrixF Log1p(matrixFTS a)
        {
            matrixF r = a;
            MatrixInplace.Log1p(r);
            return r;
        }

        public static matrixF Logb(matrixF a)
        {
            var r = new matrixF(a.Rows, a.Cols);
            Vml.Logb(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrixF Logb(matrixFS a)
        {
            matrixF r = a;
            MatrixInplace.Logb(r);
            return r;
        }

        public static matrixF Logb(matrixFT a)
        {
            matrixF r = a;
            MatrixInplace.Logb(r);
            return r;
        }

        public static matrixF Logb(matrixFTS a)
        {
            matrixF r = a;
            MatrixInplace.Logb(r);
            return r;
        }

        public static matrixF Cos(matrixF a)
        {
            var r = new matrixF(a.Rows, a.Cols);
            Vml.Cos(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrixF Cos(matrixFS a)
        {
            matrixF r = a;
            MatrixInplace.Cos(r);
            return r;
        }

        public static matrixF Cos(matrixFT a)
        {
            matrixF r = a;
            MatrixInplace.Cos(r);
            return r;
        }

        public static matrixF Cos(matrixFTS a)
        {
            matrixF r = a;
            MatrixInplace.Cos(r);
            return r;
        }

        public static matrixF Sin(matrixF a)
        {
            var r = new matrixF(a.Rows, a.Cols);
            Vml.Sin(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrixF Sin(matrixFS a)
        {
            matrixF r = a;
            MatrixInplace.Sin(r);
            return r;
        }

        public static matrixF Sin(matrixFT a)
        {
            matrixF r = a;
            MatrixInplace.Sin(r);
            return r;
        }

        public static matrixF Sin(matrixFTS a)
        {
            matrixF r = a;
            MatrixInplace.Sin(r);
            return r;
        }

        public static matrixF Tan(matrixF a)
        {
            var r = new matrixF(a.Rows, a.Cols);
            Vml.Tan(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrixF Tan(matrixFS a)
        {
            matrixF r = a;
            MatrixInplace.Tan(r);
            return r;
        }

        public static matrixF Tan(matrixFT a)
        {
            matrixF r = a;
            MatrixInplace.Tan(r);
            return r;
        }

        public static matrixF Tan(matrixFTS a)
        {
            matrixF r = a;
            MatrixInplace.Tan(r);
            return r;
        }

        public static matrixF Cospi(matrixF a)
        {
            var r = new matrixF(a.Rows, a.Cols);
            Vml.Cospi(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrixF Cospi(matrixFS a)
        {
            matrixF r = a;
            MatrixInplace.Cospi(r);
            return r;
        }

        public static matrixF Cospi(matrixFT a)
        {
            matrixF r = a;
            MatrixInplace.Cospi(r);
            return r;
        }

        public static matrixF Cospi(matrixFTS a)
        {
            matrixF r = a;
            MatrixInplace.Cospi(r);
            return r;
        }

        public static matrixF Sinpi(matrixF a)
        {
            var r = new matrixF(a.Rows, a.Cols);
            Vml.Sinpi(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrixF Sinpi(matrixFS a)
        {
            matrixF r = a;
            MatrixInplace.Sinpi(r);
            return r;
        }

        public static matrixF Sinpi(matrixFT a)
        {
            matrixF r = a;
            MatrixInplace.Sinpi(r);
            return r;
        }

        public static matrixF Sinpi(matrixFTS a)
        {
            matrixF r = a;
            MatrixInplace.Sinpi(r);
            return r;
        }

        public static matrixF Tanpi(matrixF a)
        {
            var r = new matrixF(a.Rows, a.Cols);
            Vml.Tanpi(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrixF Tanpi(matrixFS a)
        {
            matrixF r = a;
            MatrixInplace.Tanpi(r);
            return r;
        }

        public static matrixF Tanpi(matrixFT a)
        {
            matrixF r = a;
            MatrixInplace.Tanpi(r);
            return r;
        }

        public static matrixF Tanpi(matrixFTS a)
        {
            matrixF r = a;
            MatrixInplace.Tanpi(r);
            return r;
        }

        public static matrixF Cosd(matrixF a)
        {
            var r = new matrixF(a.Rows, a.Cols);
            Vml.Cosd(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrixF Cosd(matrixFS a)
        {
            matrixF r = a;
            MatrixInplace.Cosd(r);
            return r;
        }

        public static matrixF Cosd(matrixFT a)
        {
            matrixF r = a;
            MatrixInplace.Cosd(r);
            return r;
        }

        public static matrixF Cosd(matrixFTS a)
        {
            matrixF r = a;
            MatrixInplace.Cosd(r);
            return r;
        }

        public static matrixF Sind(matrixF a)
        {
            var r = new matrixF(a.Rows, a.Cols);
            Vml.Sind(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrixF Sind(matrixFS a)
        {
            matrixF r = a;
            MatrixInplace.Sind(r);
            return r;
        }

        public static matrixF Sind(matrixFT a)
        {
            matrixF r = a;
            MatrixInplace.Sind(r);
            return r;
        }

        public static matrixF Sind(matrixFTS a)
        {
            matrixF r = a;
            MatrixInplace.Sind(r);
            return r;
        }

        public static matrixF Tand(matrixF a)
        {
            var r = new matrixF(a.Rows, a.Cols);
            Vml.Tand(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrixF Tand(matrixFS a)
        {
            matrixF r = a;
            MatrixInplace.Tand(r);
            return r;
        }

        public static matrixF Tand(matrixFT a)
        {
            matrixF r = a;
            MatrixInplace.Tand(r);
            return r;
        }

        public static matrixF Tand(matrixFTS a)
        {
            matrixF r = a;
            MatrixInplace.Tand(r);
            return r;
        }

        public static matrixF Acos(matrixF a)
        {
            var r = new matrixF(a.Rows, a.Cols);
            Vml.Acos(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrixF Acos(matrixFS a)
        {
            matrixF r = a;
            MatrixInplace.Acos(r);
            return r;
        }

        public static matrixF Acos(matrixFT a)
        {
            matrixF r = a;
            MatrixInplace.Acos(r);
            return r;
        }

        public static matrixF Acos(matrixFTS a)
        {
            matrixF r = a;
            MatrixInplace.Acos(r);
            return r;
        }

        public static matrixF Asin(matrixF a)
        {
            var r = new matrixF(a.Rows, a.Cols);
            Vml.Asin(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrixF Asin(matrixFS a)
        {
            matrixF r = a;
            MatrixInplace.Asin(r);
            return r;
        }

        public static matrixF Asin(matrixFT a)
        {
            matrixF r = a;
            MatrixInplace.Asin(r);
            return r;
        }

        public static matrixF Asin(matrixFTS a)
        {
            matrixF r = a;
            MatrixInplace.Asin(r);
            return r;
        }

        public static matrixF Atan(matrixF a)
        {
            var r = new matrixF(a.Rows, a.Cols);
            Vml.Atan(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrixF Atan(matrixFS a)
        {
            matrixF r = a;
            MatrixInplace.Atan(r);
            return r;
        }

        public static matrixF Atan(matrixFT a)
        {
            matrixF r = a;
            MatrixInplace.Atan(r);
            return r;
        }

        public static matrixF Atan(matrixFTS a)
        {
            matrixF r = a;
            MatrixInplace.Atan(r);
            return r;
        }

        public static matrixF Acospi(matrixF a)
        {
            var r = new matrixF(a.Rows, a.Cols);
            Vml.Acospi(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrixF Acospi(matrixFS a)
        {
            matrixF r = a;
            MatrixInplace.Acospi(r);
            return r;
        }

        public static matrixF Acospi(matrixFT a)
        {
            matrixF r = a;
            MatrixInplace.Acospi(r);
            return r;
        }

        public static matrixF Acospi(matrixFTS a)
        {
            matrixF r = a;
            MatrixInplace.Acospi(r);
            return r;
        }

        public static matrixF Asinpi(matrixF a)
        {
            var r = new matrixF(a.Rows, a.Cols);
            Vml.Asinpi(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrixF Asinpi(matrixFS a)
        {
            matrixF r = a;
            MatrixInplace.Asinpi(r);
            return r;
        }

        public static matrixF Asinpi(matrixFT a)
        {
            matrixF r = a;
            MatrixInplace.Asinpi(r);
            return r;
        }

        public static matrixF Asinpi(matrixFTS a)
        {
            matrixF r = a;
            MatrixInplace.Asinpi(r);
            return r;
        }

        public static matrixF Atanpi(matrixF a)
        {
            var r = new matrixF(a.Rows, a.Cols);
            Vml.Atanpi(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrixF Atanpi(matrixFS a)
        {
            matrixF r = a;
            MatrixInplace.Atanpi(r);
            return r;
        }

        public static matrixF Atanpi(matrixFT a)
        {
            matrixF r = a;
            MatrixInplace.Atanpi(r);
            return r;
        }

        public static matrixF Atanpi(matrixFTS a)
        {
            matrixF r = a;
            MatrixInplace.Atanpi(r);
            return r;
        }

        public static matrixF Atan2(matrixF a, matrixF b)
        {
            if (a.Rows != b.Rows || a.Cols != b.Cols) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new matrixF(a.Rows, a.Cols);
            Vml.Atan2(a.Length, a.Array, 0, 1, b.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrixF Atan2(matrixFS a, matrixF b)
        {
            matrixF r = a;
            MatrixInplace.Atan2(r, b);
            return r;
        }

        public static matrixF Atan2(matrixFT a, matrixF b)
        {
            matrixF r = a;
            MatrixInplace.Atan2(r, b);
            return r;
        }

        public static matrixF Atan2(matrixFTS a, matrixF b)
        {
            matrixF r = a;
            MatrixInplace.Atan2(r, b);
            return r;
        }

        public static matrixF Atan2pi(matrixF a, matrixF b)
        {
            if (a.Rows != b.Rows || a.Cols != b.Cols) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new matrixF(a.Rows, a.Cols);
            Vml.Atan2pi(a.Length, a.Array, 0, 1, b.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrixF Atan2pi(matrixFS a, matrixF b)
        {
            matrixF r = a;
            MatrixInplace.Atan2pi(r, b);
            return r;
        }

        public static matrixF Atan2pi(matrixFT a, matrixF b)
        {
            matrixF r = a;
            MatrixInplace.Atan2pi(r, b);
            return r;
        }

        public static matrixF Atan2pi(matrixFTS a, matrixF b)
        {
            matrixF r = a;
            MatrixInplace.Atan2pi(r, b);
            return r;
        }

        public static matrixF Cosh(matrixF a)
        {
            var r = new matrixF(a.Rows, a.Cols);
            Vml.Cosh(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrixF Cosh(matrixFS a)
        {
            matrixF r = a;
            MatrixInplace.Cosh(r);
            return r;
        }

        public static matrixF Cosh(matrixFT a)
        {
            matrixF r = a;
            MatrixInplace.Cosh(r);
            return r;
        }

        public static matrixF Cosh(matrixFTS a)
        {
            matrixF r = a;
            MatrixInplace.Cosh(r);
            return r;
        }

        public static matrixF Sinh(matrixF a)
        {
            var r = new matrixF(a.Rows, a.Cols);
            Vml.Sinh(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrixF Sinh(matrixFS a)
        {
            matrixF r = a;
            MatrixInplace.Sinh(r);
            return r;
        }

        public static matrixF Sinh(matrixFT a)
        {
            matrixF r = a;
            MatrixInplace.Sinh(r);
            return r;
        }

        public static matrixF Sinh(matrixFTS a)
        {
            matrixF r = a;
            MatrixInplace.Sinh(r);
            return r;
        }

        public static matrixF Tanh(matrixF a)
        {
            var r = new matrixF(a.Rows, a.Cols);
            Vml.Tanh(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrixF Tanh(matrixFS a)
        {
            matrixF r = a;
            MatrixInplace.Tanh(r);
            return r;
        }

        public static matrixF Tanh(matrixFT a)
        {
            matrixF r = a;
            MatrixInplace.Tanh(r);
            return r;
        }

        public static matrixF Tanh(matrixFTS a)
        {
            matrixF r = a;
            MatrixInplace.Tanh(r);
            return r;
        }

        public static matrixF Acosh(matrixF a)
        {
            var r = new matrixF(a.Rows, a.Cols);
            Vml.Acosh(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrixF Acosh(matrixFS a)
        {
            matrixF r = a;
            MatrixInplace.Acosh(r);
            return r;
        }

        public static matrixF Acosh(matrixFT a)
        {
            matrixF r = a;
            MatrixInplace.Acosh(r);
            return r;
        }

        public static matrixF Acosh(matrixFTS a)
        {
            matrixF r = a;
            MatrixInplace.Acosh(r);
            return r;
        }

        public static matrixF Asinh(matrixF a)
        {
            var r = new matrixF(a.Rows, a.Cols);
            Vml.Asinh(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrixF Asinh(matrixFS a)
        {
            matrixF r = a;
            MatrixInplace.Asinh(r);
            return r;
        }

        public static matrixF Asinh(matrixFT a)
        {
            matrixF r = a;
            MatrixInplace.Asinh(r);
            return r;
        }

        public static matrixF Asinh(matrixFTS a)
        {
            matrixF r = a;
            MatrixInplace.Asinh(r);
            return r;
        }

        public static matrixF Atanh(matrixF a)
        {
            var r = new matrixF(a.Rows, a.Cols);
            Vml.Atanh(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrixF Atanh(matrixFS a)
        {
            matrixF r = a;
            MatrixInplace.Atanh(r);
            return r;
        }

        public static matrixF Atanh(matrixFT a)
        {
            matrixF r = a;
            MatrixInplace.Atanh(r);
            return r;
        }

        public static matrixF Atanh(matrixFTS a)
        {
            matrixF r = a;
            MatrixInplace.Atanh(r);
            return r;
        }

        public static matrixF Erf(matrixF a)
        {
            var r = new matrixF(a.Rows, a.Cols);
            Vml.Erf(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrixF Erf(matrixFS a)
        {
            matrixF r = a;
            MatrixInplace.Erf(r);
            return r;
        }

        public static matrixF Erf(matrixFT a)
        {
            matrixF r = a;
            MatrixInplace.Erf(r);
            return r;
        }

        public static matrixF Erf(matrixFTS a)
        {
            matrixF r = a;
            MatrixInplace.Erf(r);
            return r;
        }

        public static matrixF Erfc(matrixF a)
        {
            var r = new matrixF(a.Rows, a.Cols);
            Vml.Erfc(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrixF Erfc(matrixFS a)
        {
            matrixF r = a;
            MatrixInplace.Erfc(r);
            return r;
        }

        public static matrixF Erfc(matrixFT a)
        {
            matrixF r = a;
            MatrixInplace.Erfc(r);
            return r;
        }

        public static matrixF Erfc(matrixFTS a)
        {
            matrixF r = a;
            MatrixInplace.Erfc(r);
            return r;
        }

        public static matrixF ErfInv(matrixF a)
        {
            var r = new matrixF(a.Rows, a.Cols);
            Vml.ErfInv(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrixF ErfInv(matrixFS a)
        {
            matrixF r = a;
            MatrixInplace.ErfInv(r);
            return r;
        }

        public static matrixF ErfInv(matrixFT a)
        {
            matrixF r = a;
            MatrixInplace.ErfInv(r);
            return r;
        }

        public static matrixF ErfInv(matrixFTS a)
        {
            matrixF r = a;
            MatrixInplace.ErfInv(r);
            return r;
        }

        public static matrixF ErfcInv(matrixF a)
        {
            var r = new matrixF(a.Rows, a.Cols);
            Vml.ErfcInv(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrixF ErfcInv(matrixFS a)
        {
            matrixF r = a;
            MatrixInplace.ErfcInv(r);
            return r;
        }

        public static matrixF ErfcInv(matrixFT a)
        {
            matrixF r = a;
            MatrixInplace.ErfcInv(r);
            return r;
        }

        public static matrixF ErfcInv(matrixFTS a)
        {
            matrixF r = a;
            MatrixInplace.ErfcInv(r);
            return r;
        }

        public static matrixF CdfNorm(matrixF a)
        {
            var r = new matrixF(a.Rows, a.Cols);
            Vml.CdfNorm(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrixF CdfNorm(matrixFS a)
        {
            matrixF r = a;
            MatrixInplace.CdfNorm(r);
            return r;
        }

        public static matrixF CdfNorm(matrixFT a)
        {
            matrixF r = a;
            MatrixInplace.CdfNorm(r);
            return r;
        }

        public static matrixF CdfNorm(matrixFTS a)
        {
            matrixF r = a;
            MatrixInplace.CdfNorm(r);
            return r;
        }

        public static matrixF CdfNormInv(matrixF a)
        {
            var r = new matrixF(a.Rows, a.Cols);
            Vml.CdfNormInv(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrixF CdfNormInv(matrixFS a)
        {
            matrixF r = a;
            MatrixInplace.CdfNormInv(r);
            return r;
        }

        public static matrixF CdfNormInv(matrixFT a)
        {
            matrixF r = a;
            MatrixInplace.CdfNormInv(r);
            return r;
        }

        public static matrixF CdfNormInv(matrixFTS a)
        {
            matrixF r = a;
            MatrixInplace.CdfNormInv(r);
            return r;
        }

        public static matrixF LGamma(matrixF a)
        {
            var r = new matrixF(a.Rows, a.Cols);
            Vml.LGamma(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrixF LGamma(matrixFS a)
        {
            matrixF r = a;
            MatrixInplace.LGamma(r);
            return r;
        }

        public static matrixF LGamma(matrixFT a)
        {
            matrixF r = a;
            MatrixInplace.LGamma(r);
            return r;
        }

        public static matrixF LGamma(matrixFTS a)
        {
            matrixF r = a;
            MatrixInplace.LGamma(r);
            return r;
        }

        public static matrixF TGamma(matrixF a)
        {
            var r = new matrixF(a.Rows, a.Cols);
            Vml.TGamma(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrixF TGamma(matrixFS a)
        {
            matrixF r = a;
            MatrixInplace.TGamma(r);
            return r;
        }

        public static matrixF TGamma(matrixFT a)
        {
            matrixF r = a;
            MatrixInplace.TGamma(r);
            return r;
        }

        public static matrixF TGamma(matrixFTS a)
        {
            matrixF r = a;
            MatrixInplace.TGamma(r);
            return r;
        }

        public static matrixF ExpInt1(matrixF a)
        {
            var r = new matrixF(a.Rows, a.Cols);
            Vml.ExpInt1(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrixF ExpInt1(matrixFS a)
        {
            matrixF r = a;
            MatrixInplace.ExpInt1(r);
            return r;
        }

        public static matrixF ExpInt1(matrixFT a)
        {
            matrixF r = a;
            MatrixInplace.ExpInt1(r);
            return r;
        }

        public static matrixF ExpInt1(matrixFTS a)
        {
            matrixF r = a;
            MatrixInplace.ExpInt1(r);
            return r;
        }

        public static matrixF Floor(matrixF a)
        {
            var r = new matrixF(a.Rows, a.Cols);
            Vml.Floor(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrixF Floor(matrixFS a)
        {
            matrixF r = a;
            MatrixInplace.Floor(r);
            return r;
        }

        public static matrixF Floor(matrixFT a)
        {
            matrixF r = a;
            MatrixInplace.Floor(r);
            return r;
        }

        public static matrixF Floor(matrixFTS a)
        {
            matrixF r = a;
            MatrixInplace.Floor(r);
            return r;
        }

        public static matrixF Ceil(matrixF a)
        {
            var r = new matrixF(a.Rows, a.Cols);
            Vml.Ceil(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrixF Ceil(matrixFS a)
        {
            matrixF r = a;
            MatrixInplace.Ceil(r);
            return r;
        }

        public static matrixF Ceil(matrixFT a)
        {
            matrixF r = a;
            MatrixInplace.Ceil(r);
            return r;
        }

        public static matrixF Ceil(matrixFTS a)
        {
            matrixF r = a;
            MatrixInplace.Ceil(r);
            return r;
        }

        public static matrixF Trunc(matrixF a)
        {
            var r = new matrixF(a.Rows, a.Cols);
            Vml.Trunc(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrixF Trunc(matrixFS a)
        {
            matrixF r = a;
            MatrixInplace.Trunc(r);
            return r;
        }

        public static matrixF Trunc(matrixFT a)
        {
            matrixF r = a;
            MatrixInplace.Trunc(r);
            return r;
        }

        public static matrixF Trunc(matrixFTS a)
        {
            matrixF r = a;
            MatrixInplace.Trunc(r);
            return r;
        }

        public static matrixF Round(matrixF a)
        {
            var r = new matrixF(a.Rows, a.Cols);
            Vml.Round(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrixF Round(matrixFS a)
        {
            matrixF r = a;
            MatrixInplace.Round(r);
            return r;
        }

        public static matrixF Round(matrixFT a)
        {
            matrixF r = a;
            MatrixInplace.Round(r);
            return r;
        }

        public static matrixF Round(matrixFTS a)
        {
            matrixF r = a;
            MatrixInplace.Round(r);
            return r;
        }

        public static matrixF Frac(matrixF a)
        {
            var r = new matrixF(a.Rows, a.Cols);
            Vml.Frac(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrixF Frac(matrixFS a)
        {
            matrixF r = a;
            MatrixInplace.Frac(r);
            return r;
        }

        public static matrixF Frac(matrixFT a)
        {
            matrixF r = a;
            MatrixInplace.Frac(r);
            return r;
        }

        public static matrixF Frac(matrixFTS a)
        {
            matrixF r = a;
            MatrixInplace.Frac(r);
            return r;
        }

        public static matrixF NearbyInt(matrixF a)
        {
            var r = new matrixF(a.Rows, a.Cols);
            Vml.NearbyInt(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrixF NearbyInt(matrixFS a)
        {
            matrixF r = a;
            MatrixInplace.NearbyInt(r);
            return r;
        }

        public static matrixF NearbyInt(matrixFT a)
        {
            matrixF r = a;
            MatrixInplace.NearbyInt(r);
            return r;
        }

        public static matrixF NearbyInt(matrixFTS a)
        {
            matrixF r = a;
            MatrixInplace.NearbyInt(r);
            return r;
        }

        public static matrixF Rint(matrixF a)
        {
            var r = new matrixF(a.Rows, a.Cols);
            Vml.Rint(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrixF Rint(matrixFS a)
        {
            matrixF r = a;
            MatrixInplace.Rint(r);
            return r;
        }

        public static matrixF Rint(matrixFT a)
        {
            matrixF r = a;
            MatrixInplace.Rint(r);
            return r;
        }

        public static matrixF Rint(matrixFTS a)
        {
            matrixF r = a;
            MatrixInplace.Rint(r);
            return r;
        }

        public static matrixF CopySign(matrixF a, matrixF b)
        {
            if (a.Rows != b.Rows || a.Cols != b.Cols) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new matrixF(a.Rows, a.Cols);
            Vml.CopySign(a.Length, a.Array, 0, 1, b.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrixF CopySign(matrixFS a, matrixF b)
        {
            matrixF r = a;
            MatrixInplace.CopySign(r, b);
            return r;
        }

        public static matrixF CopySign(matrixFT a, matrixF b)
        {
            matrixF r = a;
            MatrixInplace.CopySign(r, b);
            return r;
        }

        public static matrixF CopySign(matrixFTS a, matrixF b)
        {
            matrixF r = a;
            MatrixInplace.CopySign(r, b);
            return r;
        }

        public static matrixF Fmax(matrixF a, matrixF b)
        {
            if (a.Rows != b.Rows || a.Cols != b.Cols) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new matrixF(a.Rows, a.Cols);
            Vml.Fmax(a.Length, a.Array, 0, 1, b.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrixF Fmax(matrixFS a, matrixF b)
        {
            matrixF r = a;
            MatrixInplace.Fmax(r, b);
            return r;
        }

        public static matrixF Fmax(matrixFT a, matrixF b)
        {
            matrixF r = a;
            MatrixInplace.Fmax(r, b);
            return r;
        }

        public static matrixF Fmax(matrixFTS a, matrixF b)
        {
            matrixF r = a;
            MatrixInplace.Fmax(r, b);
            return r;
        }

        public static matrixF Fmin(matrixF a, matrixF b)
        {
            if (a.Rows != b.Rows || a.Cols != b.Cols) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new matrixF(a.Rows, a.Cols);
            Vml.Fmin(a.Length, a.Array, 0, 1, b.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrixF Fmin(matrixFS a, matrixF b)
        {
            matrixF r = a;
            MatrixInplace.Fmin(r, b);
            return r;
        }

        public static matrixF Fmin(matrixFT a, matrixF b)
        {
            matrixF r = a;
            MatrixInplace.Fmin(r, b);
            return r;
        }

        public static matrixF Fmin(matrixFTS a, matrixF b)
        {
            matrixF r = a;
            MatrixInplace.Fmin(r, b);
            return r;
        }

        public static matrixF Fdim(matrixF a, matrixF b)
        {
            if (a.Rows != b.Rows || a.Cols != b.Cols) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new matrixF(a.Rows, a.Cols);
            Vml.Fdim(a.Length, a.Array, 0, 1, b.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrixF Fdim(matrixFS a, matrixF b)
        {
            matrixF r = a;
            MatrixInplace.Fdim(r, b);
            return r;
        }

        public static matrixF Fdim(matrixFT a, matrixF b)
        {
            matrixF r = a;
            MatrixInplace.Fdim(r, b);
            return r;
        }

        public static matrixF Fdim(matrixFTS a, matrixF b)
        {
            matrixF r = a;
            MatrixInplace.Fdim(r, b);
            return r;
        }

        public static matrixF MaxMag(matrixF a, matrixF b)
        {
            if (a.Rows != b.Rows || a.Cols != b.Cols) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new matrixF(a.Rows, a.Cols);
            Vml.MaxMag(a.Length, a.Array, 0, 1, b.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrixF MaxMag(matrixFS a, matrixF b)
        {
            matrixF r = a;
            MatrixInplace.MaxMag(r, b);
            return r;
        }

        public static matrixF MaxMag(matrixFT a, matrixF b)
        {
            matrixF r = a;
            MatrixInplace.MaxMag(r, b);
            return r;
        }

        public static matrixF MaxMag(matrixFTS a, matrixF b)
        {
            matrixF r = a;
            MatrixInplace.MaxMag(r, b);
            return r;
        }

        public static matrixF NextAfter(matrixF a, matrixF b)
        {
            if (a.Rows != b.Rows || a.Cols != b.Cols) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new matrixF(a.Rows, a.Cols);
            Vml.NextAfter(a.Length, a.Array, 0, 1, b.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrixF NextAfter(matrixFS a, matrixF b)
        {
            matrixF r = a;
            MatrixInplace.NextAfter(r, b);
            return r;
        }

        public static matrixF NextAfter(matrixFT a, matrixF b)
        {
            matrixF r = a;
            MatrixInplace.NextAfter(r, b);
            return r;
        }

        public static matrixF NextAfter(matrixFTS a, matrixF b)
        {
            matrixF r = a;
            MatrixInplace.NextAfter(r, b);
            return r;
        }

        public static matrixF Powx(matrixF a, float b)
        {
            var r = new matrixF(a.Rows, a.Cols);
            Vml.Powx(a.Length, a.Array, 0, 1, b, r.Array, 0, 1);
            return r;
        }

        public static matrixF Powx(matrixFS a, float b)
        {
            matrixF r = a;
            MatrixInplace.Powx(r, b);
            return r;
        }

        public static matrixF Powx(matrixFT a, float b)
        {
            matrixF r = a;
            MatrixInplace.Powx(r, b);
            return r;
        }

        public static matrixF Powx(matrixFTS a, float b)
        {
            matrixF r = a;
            MatrixInplace.Powx(r, b);
            return r;
        }

        public static (matrixF, matrixF) SinCos(matrixF a)
        {
            var sin = new matrixF(a.Rows, a.Cols);
            var cos = new matrixF(a.Rows, a.Cols);
            Vml.SinCos(a.Length, a.Array, 0, 1, sin.Array, 0, 1, cos.Array, 0, 1);
            return (sin, cos);
        }

        public static (matrixF, matrixF) SinCos(matrixFS a)
        {
            matrixF sin = a;
            var cos = MatrixInplace.SinCos(sin);
            return (sin, cos);
        }

        public static (matrixF, matrixF) SinCos(matrixFT a)
        {
            matrixF sin = a;
            var cos = MatrixInplace.SinCos(sin);
            return (sin, cos);
        }

        public static (matrixF, matrixF) SinCos(matrixFTS a)
        {
            matrixF sin = a;
            var cos = MatrixInplace.SinCos(sin);
            return (sin, cos);
        }

        public static (matrixF, matrixF) Modf(matrixF a)
        {
            var tru = new matrixF(a.Rows, a.Cols);
            var rem = new matrixF(a.Rows, a.Cols);
            Vml.Modf(a.Length, a.Array, 0, 1, tru.Array, 0, 1, rem.Array, 0, 1);
            return (tru, rem);
        }

        public static (matrixF, matrixF) Modf(matrixFS a)
        {
            matrixF tru = a;
            var rem = MatrixInplace.Modf(tru);
            return (tru, rem);
        }

        public static (matrixF, matrixF) Modf(matrixFT a)
        {
            matrixF tru = a;
            var rem = MatrixInplace.Modf(tru);
            return (tru, rem);
        }

        public static (matrixF, matrixF) Modf(matrixFTS a)
        {
            matrixF tru = a;
            var rem = MatrixInplace.Modf(tru);
            return (tru, rem);
        }

        public static matrixF LinearFrac(matrixF a, matrixF b, float scalea, float shifta, float scaleb, float shiftb)
        {
            if (a.Rows != b.Rows || a.Cols != b.Cols) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new matrixF(a.Rows, a.Cols);
            Vml.LinearFrac(a.Length, a.Array, 0, 1, b.Array, 0, 1, scalea, shifta, scaleb, shiftb, r.Array, 0, 1);
            return r;
        }

        public static matrixF LinearFrac(matrixFS a, matrixF b, float scalea, float shifta, float scaleb, float shiftb)
        {
            matrixF r = a;
            MatrixInplace.LinearFrac(r, b, scalea, shifta, scaleb, shiftb);
            return r;
        }

        public static matrixF LinearFrac(matrixFT a, matrixF b, float scalea, float shifta, float scaleb, float shiftb)
        {
            matrixF r = a;
            MatrixInplace.LinearFrac(r, b, scalea, shifta, scaleb, shiftb);
            return r;
        }

        public static matrixF LinearFrac(matrixFTS a, matrixF b, float scalea, float shifta, float scaleb, float shiftb)
        {
            matrixF r = a;
            MatrixInplace.LinearFrac(r, b, scalea, shifta, scaleb, shiftb);
            return r;
        }

        public static float Asum(matrixF a)
        {
            return Blas.asum(a.Length, a.Array, 0, 1);
        }

        public static float Nrm2(matrixF a)
        {
            return Blas.nrm2(a.Length, a.Array, 0, 1);
        }

        public static (int, int) Iamax(matrixF a)
        {
            int i = Blas.iamax(a.Length, a.Array, 0, 1);
            int col = Math.DivRem(i, a.Rows, out int row);
            return (row, col);
        }

        public static (int, int) Iamin(matrixF a)
        {
            int i = Blas.iamin(a.Length, a.Array, 0, 1);
            int col = Math.DivRem(i, a.Rows, out int row);
            return (row, col);
        }

        public static matrixF Copy(matrixF a)
        {
            var r = new matrixF(a.Rows, a.Cols);
            Blas.copy(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrixF Cholesky(matrixF a)
        {
            var r = Copy(a);
            MatrixInplace.Cholesky(r);
            return r;
        }

        public static matrixF Solve(matrixF a, matrixF b)
        {
            a = Copy(a);
            b = Copy(b);
            MatrixInplace.Solve(a, b);
            return b;
        }

        public static vectorF Solve(matrixF a, vectorF b)
        {
            a = Copy(a);
            b = Vector.Copy(b);
            MatrixInplace.Solve(a, b);
            return b;
        }

        public static matrixF Inverse(matrixF a)
        {
            a = Copy(a);
            MatrixInplace.Inverse(a);
            return a;
        }

        public static (matrixF, vectorF) Eigens(matrixF a)
        {
            a = Copy(a);
            var w = MatrixInplace.Eigens(a);
            return (a, w);
        }

        public static matrixF LeastSquares(matrixF a, matrixF b)
        {
            a = Copy(a);
            b = Copy(b);
            MatrixInplace.LeastSquares(a, b);
            return b;
        }

        public static partial class Examples
        {
            public static matrixF RngGaussian(int rows, int cols, uint seed, float mean, float sigma)
            {
                var r = new matrixF(rows, cols);
                var stream = Vsl.NewStream(VslBrng.MT19937, seed);
                ThrowHelper.Check(Vsl.RngGaussian(VslMethodGaussian.ICDF, stream, r.Length, r.Array, mean, sigma));
                ThrowHelper.Check(Vsl.DeleteStream(stream));
                return r;
            }

            public static (vectorF, matrixF) MeanAndCovariance(matrixF samples, vectorF weights)
            {
                if (samples.Rows != weights.Length) ThrowHelper.ThrowIncorrectDimensionsForOperation();
                var mean = new vectorF(samples.Cols);
                var cov = new matrixF(samples.Cols, samples.Cols);
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
        public static matrixF Abs(this matrixF a)
        {
            Vml.Abs(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static matrixF Add(this matrixF a, matrixF b)
        {
            Vml.Add(a.Length, a.Array, 0, 1, b.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static matrixF Sub(this matrixF a, matrixF b)
        {
            Vml.Sub(a.Length, a.Array, 0, 1, b.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static matrixF Sqr(this matrixF a)
        {
            Vml.Sqr(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static matrixF Dot(this matrixF a, matrixF b)
        {
            Vml.Mul(a.Length, a.Array, 0, 1, b.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static matrixF Mul(this matrixF a, matrixF b)
        {
            Blas.gemm(Layout.ColMajor, Trans.No, Trans.No, a.Rows, b.Cols, a.Cols, 1.0f, a.Array, a.Rows, b.Array, b.Rows, 0.0f, a.Array, a.Rows);
            return a;
        }

        public static matrixF AddMul(this matrixF a, float s, matrixF b)
        {
            Vml.LinearFrac(a.Length, a.Array, 0, 1, b.Array, 0, 1, 1.0f, 0.0f, s, 0.0f, a.Array, 0, 1);
            return a;
        }

        public static matrixF AddMul(this matrixF c, matrixF a, matrixF b)
        {
            Blas.gemm(Layout.ColMajor, Trans.No, Trans.No, a.Rows, b.Cols, a.Cols, 1.0f, a.Array, a.Rows, b.Array, b.Rows, 1.0f, c.Array, a.Rows);
            return c;
        }

        public static matrixF AddMul(this matrixF c, float s, matrixF a, matrixF b)
        {
            Blas.gemm(Layout.ColMajor, Trans.No, Trans.No, a.Rows, b.Cols, a.Cols, s, a.Array, a.Rows, b.Array, b.Rows, 1.0f, c.Array, a.Rows);
            return c;
        }

        public static matrixF PreMul(this matrixF a, matrixF b)
        {
            Blas.gemm(Layout.ColMajor, Trans.No, Trans.No, b.Rows, a.Cols, b.Cols, 1.0f, b.Array, b.Rows, a.Array, a.Rows, 0.0f, a.Array, b.Rows);
            return a;
        }

        public static matrixF Fmod(this matrixF a, matrixF b)
        {
            Vml.Fmod(a.Length, a.Array, 0, 1, b.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static matrixF Remainder(this matrixF a, matrixF b)
        {
            Vml.Remainder(a.Length, a.Array, 0, 1, b.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static matrixF Inv(this matrixF a)
        {
            Vml.Inv(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static matrixF Sqrt(this matrixF a)
        {
            Vml.Sqrt(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static matrixF InvSqrt(this matrixF a)
        {
            Vml.InvSqrt(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static matrixF Cbrt(this matrixF a)
        {
            Vml.Cbrt(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static matrixF InvCbrt(this matrixF a)
        {
            Vml.InvCbrt(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static matrixF Hypot(this matrixF a, matrixF b)
        {
            Vml.Hypot(a.Length, a.Array, 0, 1, b.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static matrixF Div(this matrixF a, matrixF b)
        {
            Vml.Div(a.Length, a.Array, 0, 1, b.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static matrixF Pow2o3(this matrixF a)
        {
            Vml.Pow2o3(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static matrixF Pow3o2(this matrixF a)
        {
            Vml.Pow3o2(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static matrixF Pow(this matrixF a, matrixF b)
        {
            Vml.Pow(a.Length, a.Array, 0, 1, b.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static matrixF Powr(this matrixF a, matrixF b)
        {
            Vml.Powr(a.Length, a.Array, 0, 1, b.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static matrixF Exp(this matrixF a)
        {
            Vml.Exp(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static matrixF Exp2(this matrixF a)
        {
            Vml.Exp2(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static matrixF Exp10(this matrixF a)
        {
            Vml.Exp10(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static matrixF Expm1(this matrixF a)
        {
            Vml.Expm1(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static matrixF Ln(this matrixF a)
        {
            Vml.Ln(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static matrixF Log2(this matrixF a)
        {
            Vml.Log2(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static matrixF Log10(this matrixF a)
        {
            Vml.Log10(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static matrixF Log1p(this matrixF a)
        {
            Vml.Log1p(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static matrixF Logb(this matrixF a)
        {
            Vml.Logb(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static matrixF Cos(this matrixF a)
        {
            Vml.Cos(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static matrixF Sin(this matrixF a)
        {
            Vml.Sin(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static matrixF Tan(this matrixF a)
        {
            Vml.Tan(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static matrixF Cospi(this matrixF a)
        {
            Vml.Cospi(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static matrixF Sinpi(this matrixF a)
        {
            Vml.Sinpi(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static matrixF Tanpi(this matrixF a)
        {
            Vml.Tanpi(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static matrixF Cosd(this matrixF a)
        {
            Vml.Cosd(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static matrixF Sind(this matrixF a)
        {
            Vml.Sind(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static matrixF Tand(this matrixF a)
        {
            Vml.Tand(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static matrixF Acos(this matrixF a)
        {
            Vml.Acos(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static matrixF Asin(this matrixF a)
        {
            Vml.Asin(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static matrixF Atan(this matrixF a)
        {
            Vml.Atan(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static matrixF Acospi(this matrixF a)
        {
            Vml.Acospi(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static matrixF Asinpi(this matrixF a)
        {
            Vml.Asinpi(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static matrixF Atanpi(this matrixF a)
        {
            Vml.Atanpi(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static matrixF Atan2(this matrixF a, matrixF b)
        {
            Vml.Atan2(a.Length, a.Array, 0, 1, b.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static matrixF Atan2pi(this matrixF a, matrixF b)
        {
            Vml.Atan2pi(a.Length, a.Array, 0, 1, b.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static matrixF Cosh(this matrixF a)
        {
            Vml.Cosh(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static matrixF Sinh(this matrixF a)
        {
            Vml.Sinh(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static matrixF Tanh(this matrixF a)
        {
            Vml.Tanh(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static matrixF Acosh(this matrixF a)
        {
            Vml.Acosh(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static matrixF Asinh(this matrixF a)
        {
            Vml.Asinh(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static matrixF Atanh(this matrixF a)
        {
            Vml.Atanh(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static matrixF Erf(this matrixF a)
        {
            Vml.Erf(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static matrixF Erfc(this matrixF a)
        {
            Vml.Erfc(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static matrixF ErfInv(this matrixF a)
        {
            Vml.ErfInv(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static matrixF ErfcInv(this matrixF a)
        {
            Vml.ErfcInv(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static matrixF CdfNorm(this matrixF a)
        {
            Vml.CdfNorm(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static matrixF CdfNormInv(this matrixF a)
        {
            Vml.CdfNormInv(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static matrixF LGamma(this matrixF a)
        {
            Vml.LGamma(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static matrixF TGamma(this matrixF a)
        {
            Vml.TGamma(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static matrixF ExpInt1(this matrixF a)
        {
            Vml.ExpInt1(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static matrixF Floor(this matrixF a)
        {
            Vml.Floor(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static matrixF Ceil(this matrixF a)
        {
            Vml.Ceil(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static matrixF Trunc(this matrixF a)
        {
            Vml.Trunc(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static matrixF Round(this matrixF a)
        {
            Vml.Round(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static matrixF Frac(this matrixF a)
        {
            Vml.Frac(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static matrixF NearbyInt(this matrixF a)
        {
            Vml.NearbyInt(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static matrixF Rint(this matrixF a)
        {
            Vml.Rint(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static matrixF CopySign(this matrixF a, matrixF b)
        {
            Vml.CopySign(a.Length, a.Array, 0, 1, b.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static matrixF Fmax(this matrixF a, matrixF b)
        {
            Vml.Fmax(a.Length, a.Array, 0, 1, b.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static matrixF Fmin(this matrixF a, matrixF b)
        {
            Vml.Fmin(a.Length, a.Array, 0, 1, b.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static matrixF Fdim(this matrixF a, matrixF b)
        {
            Vml.Fdim(a.Length, a.Array, 0, 1, b.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static matrixF MaxMag(this matrixF a, matrixF b)
        {
            Vml.MaxMag(a.Length, a.Array, 0, 1, b.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static matrixF NextAfter(this matrixF a, matrixF b)
        {
            Vml.NextAfter(a.Length, a.Array, 0, 1, b.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static matrixF Powx(this matrixF a, float b)
        {
            Vml.Powx(a.Length, a.Array, 0, 1, b, a.Array, 0, 1);
            return a;
        }

        public static matrixF LinearFrac(this matrixF a, matrixF b, float scalea, float shifta, float scaleb, float shiftb)
        {
            Vml.LinearFrac(a.Length, a.Array, 0, 1, b.Array, 0, 1, scalea, shifta, scaleb, shiftb, a.Array, 0, 1);
            return a;
        }

        public static matrixF SinCos(matrixF a)
        {
            var cos = new matrixF(a.Rows, a.Cols);
            Vml.SinCos(a.Length, a.Array, 0, 1, a.Array, 0, 1, cos.Array, 0, 1);
            return cos;
        }

        public static matrixF Modf(matrixF a)
        {
            var rem = new matrixF(a.Rows, a.Cols);
            Vml.Modf(a.Length, a.Array, 0, 1, a.Array, 0, 1, rem.Array, 0, 1);
            return rem;
        }

        public static matrixF Scal(this matrixF a, float s)
        {
            Blas.scal(a.Length, s, a.Array, 0, 1);
            return a;
        }

        public static matrixF Lower(this matrixF a)
        {
            for (int c = 1; c < a.Cols; c++)
                for (int r = 0; r < c; r++)
                    a[r, c] = 0.0f;
            return a;
        }

        public static matrixF Upper(this matrixF a)
        {
            for (int c = 0; c < a.Cols; c++)
                for (int r = c + 1; r < a.Rows; r++)
                    a[r, c] = 0.0f;
            return a;
        }

        public static matrixF Cholesky(this matrixF a)
        {
            if (a.Rows != a.Cols) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            Lower(a);
            ThrowHelper.Check(Lapack.potrf2(Layout.ColMajor, UpLoChar.Lower, a.Rows, a.Array, a.Rows));
            return a;
        }

        public static matrixF Solve(this matrixF a, matrixF b)
        {
            if (a.Rows != a.Cols || a.Rows != b.Rows) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var ipiv = Matrix.IntPool.Rent(a.Rows);
            ThrowHelper.Check(Lapack.gesv(Layout.ColMajor, a.Rows, b.Cols, a.Array, a.Rows, ipiv, b.Array, a.Rows));
            Matrix.IntPool.Return(ipiv);
            return a;
        }

        public static matrixF Solve(this matrixF a, vectorF b)
        {
            if (a.Rows != a.Cols || a.Rows != b.Length) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var ipiv = Matrix.IntPool.Rent(a.Rows);
            ThrowHelper.Check(Lapack.gesv(Layout.ColMajor, a.Rows, 1, a.Array, a.Rows, ipiv, b.Array, a.Rows));
            Matrix.IntPool.Return(ipiv);
            return a;
        }

        public static matrixF Inverse(this matrixF a)
        {
            if (a.Rows != a.Cols) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var ipiv = Matrix.IntPool.Rent(a.Rows);
            ThrowHelper.Check(Lapack.getrf(Layout.ColMajor, a.Rows, a.Rows, a.Array, a.Rows, ipiv));
            ThrowHelper.Check(Lapack.getri(Layout.ColMajor, a.Rows, a.Array, a.Rows, ipiv));
            Matrix.IntPool.Return(ipiv);
            return a;
        }

        public static vectorF Eigens(matrixF a)
        {
            if (a.Rows != a.Cols) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var w = new vectorF(a.Rows);
            ThrowHelper.Check(Lapack.syev(Layout.ColMajor, 'V', UpLoChar.Lower, a.Rows, a.Array, a.Rows, w.Array));
            return w;
        }

        public static matrixF LeastSquares(this matrixF a, matrixF b)
        {
            if (a.Rows != b.Rows || a.Cols > a.Rows) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            Lapack.gels(Layout.RowMajor, TransChar.No, a.Rows, a.Cols, b.Cols, a.Array, a.Cols, b.Array, b.Cols);
            return a;
        }

        public static matrixF Copy(this matrixF a, matrixF b)
        {
            Blas.copy(b.Length, b.Array, 0, 1, a.Array, 0, 1);
            return a;
        }
    }
}