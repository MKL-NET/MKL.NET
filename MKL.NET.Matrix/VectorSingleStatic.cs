namespace MKLNET
{
    public static partial class Vector
    {
        public static partial class Inplace
        {
            public static void Abs(vectorF a)
            {
                Vml.Abs(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            }

            public static void Add(vectorF a, vectorF b)
            {
                Vml.Add(a.Length, a.Array, 0, 1, b.Array, 0, 1, a.Array, 0, 1);
            }

            public static void Sub(vectorF a, vectorF b)
            {
                Vml.Sub(a.Length, a.Array, 0, 1, b.Array, 0, 1, a.Array, 0, 1);
            }

            public static void Sqr(vectorF a)
            {
                Vml.Sqr(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            }

            public static void Mul(vectorF a, vectorF b)
            {
                Vml.Mul(a.Length, a.Array, 0, 1, b.Array, 0, 1, a.Array, 0, 1);
            }

            public static void Fmod(vectorF a, vectorF b)
            {
                Vml.Fmod(a.Length, a.Array, 0, 1, b.Array, 0, 1, a.Array, 0, 1);
            }

            public static void Remainder(vectorF a, vectorF b)
            {
                Vml.Remainder(a.Length, a.Array, 0, 1, b.Array, 0, 1, a.Array, 0, 1);
            }

            public static void Inv(vectorF a)
            {
                Vml.Inv(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            }

            public static void Sqrt(vectorF a)
            {
                Vml.Sqrt(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            }

            public static void InvSqrt(vectorF a)
            {
                Vml.InvSqrt(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            }

            public static void Cbrt(vectorF a)
            {
                Vml.Cbrt(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            }

            public static void InvCbrt(vectorF a)
            {
                Vml.InvCbrt(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            }

            public static void Hypot(vectorF a, vectorF b)
            {
                Vml.Hypot(a.Length, a.Array, 0, 1, b.Array, 0, 1, a.Array, 0, 1);
            }

            public static void Div(vectorF a, vectorF b)
            {
                Vml.Div(a.Length, a.Array, 0, 1, b.Array, 0, 1, a.Array, 0, 1);
            }

            public static void Pow2o3(vectorF a)
            {
                Vml.Pow2o3(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            }

            public static void Pow3o2(vectorF a)
            {
                Vml.Pow3o2(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            }

            public static void Pow(vectorF a, vectorF b)
            {
                Vml.Pow(a.Length, a.Array, 0, 1, b.Array, 0, 1, a.Array, 0, 1);
            }

            public static void Powr(vectorF a, vectorF b)
            {
                Vml.Powr(a.Length, a.Array, 0, 1, b.Array, 0, 1, a.Array, 0, 1);
            }

            public static void Exp(vectorF a)
            {
                Vml.Exp(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            }

            public static void Exp2(vectorF a)
            {
                Vml.Exp2(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            }

            public static void Exp10(vectorF a)
            {
                Vml.Exp10(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            }

            public static void Expm1(vectorF a)
            {
                Vml.Expm1(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            }

            public static void Ln(vectorF a)
            {
                Vml.Ln(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            }

            public static void Log2(vectorF a)
            {
                Vml.Log2(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            }

            public static void Log10(vectorF a)
            {
                Vml.Log10(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            }

            public static void Log1p(vectorF a)
            {
                Vml.Log1p(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            }

            public static void Logb(vectorF a)
            {
                Vml.Logb(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            }

            public static void Cos(vectorF a)
            {
                Vml.Cos(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            }

            public static void Sin(vectorF a)
            {
                Vml.Sin(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            }

            public static void Tan(vectorF a)
            {
                Vml.Tan(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            }

            public static void Cospi(vectorF a)
            {
                Vml.Cospi(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            }

            public static void Sinpi(vectorF a)
            {
                Vml.Sinpi(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            }

            public static void Tanpi(vectorF a)
            {
                Vml.Tanpi(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            }

            public static void Cosd(vectorF a)
            {
                Vml.Cosd(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            }

            public static void Sind(vectorF a)
            {
                Vml.Sind(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            }

            public static void Tand(vectorF a)
            {
                Vml.Tand(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            }

            public static void Acos(vectorF a)
            {
                Vml.Acos(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            }

            public static void Asin(vectorF a)
            {
                Vml.Asin(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            }

            public static void Atan(vectorF a)
            {
                Vml.Atan(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            }

            public static void Acospi(vectorF a)
            {
                Vml.Acospi(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            }

            public static void Asinpi(vectorF a)
            {
                Vml.Asinpi(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            }

            public static void Atanpi(vectorF a)
            {
                Vml.Atanpi(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            }

            public static void Atan2(vectorF a, vectorF b)
            {
                Vml.Atan2(a.Length, a.Array, 0, 1, b.Array, 0, 1, a.Array, 0, 1);
            }

            public static void Atan2pi(vectorF a, vectorF b)
            {
                Vml.Atan2pi(a.Length, a.Array, 0, 1, b.Array, 0, 1, a.Array, 0, 1);
            }

            public static void Cosh(vectorF a)
            {
                Vml.Cosh(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            }

            public static void Sinh(vectorF a)
            {
                Vml.Sinh(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            }

            public static void Tanh(vectorF a)
            {
                Vml.Tanh(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            }

            public static void Acosh(vectorF a)
            {
                Vml.Acosh(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            }

            public static void Asinh(vectorF a)
            {
                Vml.Asinh(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            }

            public static void Atanh(vectorF a)
            {
                Vml.Atanh(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            }

            public static void Erf(vectorF a)
            {
                Vml.Erf(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            }

            public static void Erfc(vectorF a)
            {
                Vml.Erfc(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            }

            public static void ErfInv(vectorF a)
            {
                Vml.ErfInv(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            }

            public static void ErfcInv(vectorF a)
            {
                Vml.ErfcInv(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            }

            public static void CdfNorm(vectorF a)
            {
                Vml.CdfNorm(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            }

            public static void CdfNormInv(vectorF a)
            {
                Vml.CdfNormInv(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            }

            public static void LGamma(vectorF a)
            {
                Vml.LGamma(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            }

            public static void TGamma(vectorF a)
            {
                Vml.TGamma(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            }

            public static void ExpInt1(vectorF a)
            {
                Vml.ExpInt1(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            }

            public static void Floor(vectorF a)
            {
                Vml.Floor(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            }

            public static void Ceil(vectorF a)
            {
                Vml.Ceil(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            }

            public static void Trunc(vectorF a)
            {
                Vml.Trunc(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            }

            public static void Round(vectorF a)
            {
                Vml.Round(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            }

            public static void Frac(vectorF a)
            {
                Vml.Frac(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            }

            public static void NearbyInt(vectorF a)
            {
                Vml.NearbyInt(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            }

            public static void Rint(vectorF a)
            {
                Vml.Rint(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            }

            public static void CopySign(vectorF a, vectorF b)
            {
                Vml.CopySign(a.Length, a.Array, 0, 1, b.Array, 0, 1, a.Array, 0, 1);
            }

            public static void Fmax(vectorF a, vectorF b)
            {
                Vml.Fmax(a.Length, a.Array, 0, 1, b.Array, 0, 1, a.Array, 0, 1);
            }

            public static void Fmin(vectorF a, vectorF b)
            {
                Vml.Fmin(a.Length, a.Array, 0, 1, b.Array, 0, 1, a.Array, 0, 1);
            }

            public static void Fdim(vectorF a, vectorF b)
            {
                Vml.Fdim(a.Length, a.Array, 0, 1, b.Array, 0, 1, a.Array, 0, 1);
            }

            public static void MaxMag(vectorF a, vectorF b)
            {
                Vml.MaxMag(a.Length, a.Array, 0, 1, b.Array, 0, 1, a.Array, 0, 1);
            }

            public static void NextAfter(vectorF a, vectorF b)
            {
                Vml.NextAfter(a.Length, a.Array, 0, 1, b.Array, 0, 1, a.Array, 0, 1);
            }

            public static void Powx(vectorF a, float b)
            {
                Vml.Powx(a.Length, a.Array, 0, 1, b, a.Array, 0, 1);
            }

            public static void LinearFrac(vectorF a, vectorF b, float scalea, float shifta, float scaleb, float shiftb)
            {
                Vml.LinearFrac(a.Length, a.Array, 0, 1, b.Array, 0, 1, scalea, shifta, scaleb, shiftb, a.Array, 0, 1);
            }

            public static vectorF SinCos(vectorF a)
            {
                var cos = new vectorF(a.Length);
                Vml.SinCos(a.Length, a.Array, 0, 1, a.Array, 0, 1, cos.Array, 0, 1);
                return cos;
            }

            public static vectorF Modf(vectorF a)
            {
                var rem = new vectorF(a.Length);
                Vml.Modf(a.Length, a.Array, 0, 1, a.Array, 0, 1, rem.Array, 0, 1);
                return rem;
            }

            public static void Scal(vectorF a, float s)
            {
                Blas.scal(a.Length, s, a.Array, 0, 1);
            }
        }

        public static vectorF Abs(vectorF a)
        {
            var r = new vectorF(a.Length);
            Vml.Abs(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static vectorF Abs(vectorFS a)
        {
            vectorF r = a;
            Inplace.Abs(r);
            return r;
        }

        public static vectorFT Abs(vectorFT a)
        {
            return new vectorFT(Abs(a.Vector));
        }

        public static vectorFT Abs(vectorFTS a)
        {
            vectorF r = new vectorFS(a.Vector, a.Scale);
            Inplace.Abs(r);
            return new vectorFT(r);
        }

        public static vectorF Sqr(vectorF a)
        {
            var r = new vectorF(a.Length);
            Vml.Sqr(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static vectorF Sqr(vectorFS a)
        {
            vectorF r = a;
            Inplace.Sqr(r);
            return r;
        }

        public static vectorFT Sqr(vectorFT a)
        {
            return new vectorFT(Sqr(a.Vector));
        }

        public static vectorFT Sqr(vectorFTS a)
        {
            vectorF r = new vectorFS(a.Vector, a.Scale);
            Inplace.Sqr(r);
            return new vectorFT(r);
        }

        public static vectorF Mul(vectorF a, vectorF b)
        {
            if (a.Length != b.Length) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new vectorF(a.Length);
            Vml.Mul(a.Length, a.Array, 0, 1, b.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static vectorF Mul(vectorFS a, vectorF b)
        {
            vectorF r = a;
            Inplace.Mul(r, b);
            return r;
        }

        public static vectorFT Mul(vectorFT a, vectorF b)
        {
            return new vectorFT(Mul(a.Vector, b));
        }

        public static vectorFT Mul(vectorFTS a, vectorF b)
        {
            vectorF r = new vectorFS(a.Vector, a.Scale);
            Inplace.Mul(r, b);
            return new vectorFT(r);
        }

        public static vectorF Fmod(vectorF a, vectorF b)
        {
            if (a.Length != b.Length) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new vectorF(a.Length);
            Vml.Fmod(a.Length, a.Array, 0, 1, b.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static vectorF Fmod(vectorFS a, vectorF b)
        {
            vectorF r = a;
            Inplace.Fmod(r, b);
            return r;
        }

        public static vectorFT Fmod(vectorFT a, vectorF b)
        {
            return new vectorFT(Fmod(a.Vector, b));
        }

        public static vectorFT Fmod(vectorFTS a, vectorF b)
        {
            vectorF r = new vectorFS(a.Vector, a.Scale);
            Inplace.Fmod(r, b);
            return new vectorFT(r);
        }

        public static vectorF Remainder(vectorF a, vectorF b)
        {
            if (a.Length != b.Length) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new vectorF(a.Length);
            Vml.Remainder(a.Length, a.Array, 0, 1, b.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static vectorF Remainder(vectorFS a, vectorF b)
        {
            vectorF r = a;
            Inplace.Remainder(r, b);
            return r;
        }

        public static vectorFT Remainder(vectorFT a, vectorF b)
        {
            return new vectorFT(Remainder(a.Vector, b));
        }

        public static vectorFT Remainder(vectorFTS a, vectorF b)
        {
            vectorF r = new vectorFS(a.Vector, a.Scale);
            Inplace.Remainder(r, b);
            return new vectorFT(r);
        }

        public static vectorF Inv(vectorF a)
        {
            var r = new vectorF(a.Length);
            Vml.Inv(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static vectorF Inv(vectorFS a)
        {
            vectorF r = a;
            Inplace.Inv(r);
            return r;
        }

        public static vectorFT Inv(vectorFT a)
        {
            return new vectorFT(Inv(a.Vector));
        }

        public static vectorFT Inv(vectorFTS a)
        {
            vectorF r = new vectorFS(a.Vector, a.Scale);
            Inplace.Inv(r);
            return new vectorFT(r);
        }

        public static vectorF Sqrt(vectorF a)
        {
            var r = new vectorF(a.Length);
            Vml.Sqrt(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static vectorF Sqrt(vectorFS a)
        {
            vectorF r = a;
            Inplace.Sqrt(r);
            return r;
        }

        public static vectorFT Sqrt(vectorFT a)
        {
            return new vectorFT(Sqrt(a.Vector));
        }

        public static vectorFT Sqrt(vectorFTS a)
        {
            vectorF r = new vectorFS(a.Vector, a.Scale);
            Inplace.Sqrt(r);
            return new vectorFT(r);
        }

        public static vectorF InvSqrt(vectorF a)
        {
            var r = new vectorF(a.Length);
            Vml.InvSqrt(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static vectorF InvSqrt(vectorFS a)
        {
            vectorF r = a;
            Inplace.InvSqrt(r);
            return r;
        }

        public static vectorFT InvSqrt(vectorFT a)
        {
            return new vectorFT(InvSqrt(a.Vector));
        }

        public static vectorFT InvSqrt(vectorFTS a)
        {
            vectorF r = new vectorFS(a.Vector, a.Scale);
            Inplace.InvSqrt(r);
            return new vectorFT(r);
        }

        public static vectorF Cbrt(vectorF a)
        {
            var r = new vectorF(a.Length);
            Vml.Cbrt(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static vectorF Cbrt(vectorFS a)
        {
            vectorF r = a;
            Inplace.Cbrt(r);
            return r;
        }

        public static vectorFT Cbrt(vectorFT a)
        {
            return new vectorFT(Cbrt(a.Vector));
        }

        public static vectorFT Cbrt(vectorFTS a)
        {
            vectorF r = new vectorFS(a.Vector, a.Scale);
            Inplace.Cbrt(r);
            return new vectorFT(r);
        }

        public static vectorF InvCbrt(vectorF a)
        {
            var r = new vectorF(a.Length);
            Vml.InvCbrt(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static vectorF InvCbrt(vectorFS a)
        {
            vectorF r = a;
            Inplace.InvCbrt(r);
            return r;
        }

        public static vectorFT InvCbrt(vectorFT a)
        {
            return new vectorFT(InvCbrt(a.Vector));
        }

        public static vectorFT InvCbrt(vectorFTS a)
        {
            vectorF r = new vectorFS(a.Vector, a.Scale);
            Inplace.InvCbrt(r);
            return new vectorFT(r);
        }

        public static vectorF Hypot(vectorF a, vectorF b)
        {
            if (a.Length != b.Length) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new vectorF(a.Length);
            Vml.Hypot(a.Length, a.Array, 0, 1, b.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static vectorF Hypot(vectorFS a, vectorF b)
        {
            vectorF r = a;
            Inplace.Hypot(r, b);
            return r;
        }

        public static vectorFT Hypot(vectorFT a, vectorF b)
        {
            return new vectorFT(Hypot(a.Vector, b));
        }

        public static vectorFT Hypot(vectorFTS a, vectorF b)
        {
            vectorF r = new vectorFS(a.Vector, a.Scale);
            Inplace.Hypot(r, b);
            return new vectorFT(r);
        }

        public static vectorF Div(vectorF a, vectorF b)
        {
            if (a.Length != b.Length) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new vectorF(a.Length);
            Vml.Div(a.Length, a.Array, 0, 1, b.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static vectorF Div(vectorFS a, vectorF b)
        {
            vectorF r = a;
            Inplace.Div(r, b);
            return r;
        }

        public static vectorFT Div(vectorFT a, vectorF b)
        {
            return new vectorFT(Mul(a.Vector, b));
        }

        public static vectorFT Div(vectorFTS a, vectorF b)
        {
            vectorF r = new vectorFS(a.Vector, a.Scale);
            Inplace.Div(r, b);
            return new vectorFT(r);
        }

        public static vectorF Pow2o3(vectorF a)
        {
            var r = new vectorF(a.Length);
            Vml.Pow2o3(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static vectorF Pow2o3(vectorFS a)
        {
            vectorF r = a;
            Inplace.Pow2o3(r);
            return r;
        }

        public static vectorFT Pow2o3(vectorFT a)
        {
            return new vectorFT(Pow2o3(a.Vector));
        }

        public static vectorFT Pow2o3(vectorFTS a)
        {
            vectorF r = new vectorFS(a.Vector, a.Scale);
            Inplace.Pow2o3(r);
            return new vectorFT(r);
        }

        public static vectorF Pow3o2(vectorF a)
        {
            var r = new vectorF(a.Length);
            Vml.Pow3o2(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static vectorF Pow3o2(vectorFS a)
        {
            vectorF r = a;
            Inplace.Pow3o2(r);
            return r;
        }

        public static vectorFT Pow3o2(vectorFT a)
        {
            return new vectorFT(Pow3o2(a.Vector));
        }

        public static vectorFT Pow3o2(vectorFTS a)
        {
            vectorF r = new vectorFS(a.Vector, a.Scale);
            Inplace.Pow3o2(r);
            return new vectorFT(r);
        }

        public static vectorF Pow(vectorF a, vectorF b)
        {
            if (a.Length != b.Length) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new vectorF(a.Length);
            Vml.Pow(a.Length, a.Array, 0, 1, b.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static vectorF Pow(vectorFS a, vectorF b)
        {
            vectorF r = a;
            Inplace.Pow(r, b);
            return r;
        }

        public static vectorFT Pow(vectorFT a, vectorF b)
        {
            return new vectorFT(Pow(a.Vector, b));
        }

        public static vectorFT Pow(vectorFTS a, vectorF b)
        {
            vectorF r = new vectorFS(a.Vector, a.Scale);
            Inplace.Pow(r, b);
            return new vectorFT(r);
        }

        public static vectorF Powr(vectorF a, vectorF b)
        {
            if (a.Length != b.Length) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new vectorF(a.Length);
            Vml.Powr(a.Length, a.Array, 0, 1, b.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static vectorF Powr(vectorFS a, vectorF b)
        {
            vectorF r = a;
            Inplace.Powr(r, b);
            return r;
        }

        public static vectorFT Powr(vectorFT a, vectorF b)
        {
            return new vectorFT(Powr(a.Vector, b));
        }

        public static vectorFT Powr(vectorFTS a, vectorF b)
        {
            vectorF r = new vectorFS(a.Vector, a.Scale);
            Inplace.Powr(r, b);
            return new vectorFT(r);
        }

        public static vectorF Exp(vectorF a)
        {
            var r = new vectorF(a.Length);
            Vml.Exp(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static vectorF Exp(vectorFS a)
        {
            vectorF r = a;
            Inplace.Exp(r);
            return r;
        }

        public static vectorFT Exp(vectorFT a)
        {
            return new vectorFT(Exp(a.Vector));
        }

        public static vectorFT Exp(vectorFTS a)
        {
            vectorF r = new vectorFS(a.Vector, a.Scale);
            Inplace.Exp(r);
            return new vectorFT(r);
        }

        public static vectorF Exp2(vectorF a)
        {
            var r = new vectorF(a.Length);
            Vml.Exp2(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static vectorF Exp2(vectorFS a)
        {
            vectorF r = a;
            Inplace.Exp2(r);
            return r;
        }

        public static vectorFT Exp2(vectorFT a)
        {
            return new vectorFT(Exp2(a.Vector));
        }

        public static vectorFT Exp2(vectorFTS a)
        {
            vectorF r = new vectorFS(a.Vector, a.Scale);
            Inplace.Exp2(r);
            return new vectorFT(r);
        }

        public static vectorF Exp10(vectorF a)
        {
            var r = new vectorF(a.Length);
            Vml.Exp10(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static vectorF Exp10(vectorFS a)
        {
            vectorF r = a;
            Inplace.Exp10(r);
            return r;
        }

        public static vectorFT Exp10(vectorFT a)
        {
            return new vectorFT(Exp10(a.Vector));
        }

        public static vectorFT Exp10(vectorFTS a)
        {
            vectorF r = new vectorFS(a.Vector, a.Scale);
            Inplace.Exp10(r);
            return new vectorFT(r);
        }

        public static vectorF Expm1(vectorF a)
        {
            var r = new vectorF(a.Length);
            Vml.Expm1(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static vectorF Expm1(vectorFS a)
        {
            vectorF r = a;
            Inplace.Expm1(r);
            return r;
        }

        public static vectorFT Expm1(vectorFT a)
        {
            return new vectorFT(Expm1(a.Vector));
        }

        public static vectorFT Expm1(vectorFTS a)
        {
            vectorF r = new vectorFS(a.Vector, a.Scale);
            Inplace.Expm1(r);
            return new vectorFT(r);
        }

        public static vectorF Ln(vectorF a)
        {
            var r = new vectorF(a.Length);
            Vml.Ln(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static vectorF Ln(vectorFS a)
        {
            vectorF r = a;
            Inplace.Ln(r);
            return r;
        }

        public static vectorFT Ln(vectorFT a)
        {
            return new vectorFT(Ln(a.Vector));
        }

        public static vectorFT Ln(vectorFTS a)
        {
            vectorF r = new vectorFS(a.Vector, a.Scale);
            Inplace.Ln(r);
            return new vectorFT(r);
        }

        public static vectorF Log2(vectorF a)
        {
            var r = new vectorF(a.Length);
            Vml.Log2(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static vectorF Log2(vectorFS a)
        {
            vectorF r = a;
            Inplace.Log2(r);
            return r;
        }

        public static vectorFT Log2(vectorFT a)
        {
            return new vectorFT(Log2(a.Vector));
        }

        public static vectorFT Log2(vectorFTS a)
        {
            vectorF r = new vectorFS(a.Vector, a.Scale);
            Inplace.Log2(r);
            return new vectorFT(r);
        }

        public static vectorF Log10(vectorF a)
        {
            var r = new vectorF(a.Length);
            Vml.Log10(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static vectorF Log10(vectorFS a)
        {
            vectorF r = a;
            Inplace.Log10(r);
            return r;
        }

        public static vectorFT Log10(vectorFT a)
        {
            return new vectorFT(Log10(a.Vector));
        }

        public static vectorFT Log10(vectorFTS a)
        {
            vectorF r = new vectorFS(a.Vector, a.Scale);
            Inplace.Log10(r);
            return new vectorFT(r);
        }

        public static vectorF Log1p(vectorF a)
        {
            var r = new vectorF(a.Length);
            Vml.Log1p(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static vectorF Log1p(vectorFS a)
        {
            vectorF r = a;
            Inplace.Log1p(r);
            return r;
        }

        public static vectorFT Log1p(vectorFT a)
        {
            return new vectorFT(Log1p(a.Vector));
        }

        public static vectorFT Log1p(vectorFTS a)
        {
            vectorF r = new vectorFS(a.Vector, a.Scale);
            Inplace.Log1p(r);
            return new vectorFT(r);
        }

        public static vectorF Logb(vectorF a)
        {
            var r = new vectorF(a.Length);
            Vml.Logb(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static vectorF Logb(vectorFS a)
        {
            vectorF r = a;
            Inplace.Logb(r);
            return r;
        }

        public static vectorFT Logb(vectorFT a)
        {
            return new vectorFT(Logb(a.Vector));
        }

        public static vectorFT Logb(vectorFTS a)
        {
            vectorF r = new vectorFS(a.Vector, a.Scale);
            Inplace.Logb(r);
            return new vectorFT(r);
        }

        public static vectorF Cos(vectorF a)
        {
            var r = new vectorF(a.Length);
            Vml.Cos(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static vectorF Cos(vectorFS a)
        {
            vectorF r = a;
            Inplace.Cos(r);
            return r;
        }

        public static vectorFT Cos(vectorFT a)
        {
            return new vectorFT(Cos(a.Vector));
        }

        public static vectorFT Cos(vectorFTS a)
        {
            vectorF r = new vectorFS(a.Vector, a.Scale);
            Inplace.Cos(r);
            return new vectorFT(r);
        }

        public static vectorF Sin(vectorF a)
        {
            var r = new vectorF(a.Length);
            Vml.Sin(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static vectorF Sin(vectorFS a)
        {
            vectorF r = a;
            Inplace.Sin(r);
            return r;
        }

        public static vectorFT Sin(vectorFT a)
        {
            return new vectorFT(Sin(a.Vector));
        }

        public static vectorFT Sin(vectorFTS a)
        {
            vectorF r = new vectorFS(a.Vector, a.Scale);
            Inplace.Sin(r);
            return new vectorFT(r);
        }

        public static vectorF Tan(vectorF a)
        {
            var r = new vectorF(a.Length);
            Vml.Tan(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static vectorF Tan(vectorFS a)
        {
            vectorF r = a;
            Inplace.Tan(r);
            return r;
        }

        public static vectorFT Tan(vectorFT a)
        {
            return new vectorFT(Tan(a.Vector));
        }

        public static vectorFT Tan(vectorFTS a)
        {
            vectorF r = new vectorFS(a.Vector, a.Scale);
            Inplace.Tan(r);
            return new vectorFT(r);
        }

        public static vectorF Cospi(vectorF a)
        {
            var r = new vectorF(a.Length);
            Vml.Cospi(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static vectorF Cospi(vectorFS a)
        {
            vectorF r = a;
            Inplace.Cospi(r);
            return r;
        }

        public static vectorFT Cospi(vectorFT a)
        {
            return new vectorFT(Cospi(a.Vector));
        }

        public static vectorFT Cospi(vectorFTS a)
        {
            vectorF r = new vectorFS(a.Vector, a.Scale);
            Inplace.Cospi(r);
            return new vectorFT(r);
        }

        public static vectorF Sinpi(vectorF a)
        {
            var r = new vectorF(a.Length);
            Vml.Sinpi(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static vectorF Sinpi(vectorFS a)
        {
            vectorF r = a;
            Inplace.Sinpi(r);
            return r;
        }

        public static vectorFT Sinpi(vectorFT a)
        {
            return new vectorFT(Sinpi(a.Vector));
        }

        public static vectorFT Sinpi(vectorFTS a)
        {
            vectorF r = new vectorFS(a.Vector, a.Scale);
            Inplace.Sinpi(r);
            return new vectorFT(r);
        }

        public static vectorF Tanpi(vectorF a)
        {
            var r = new vectorF(a.Length);
            Vml.Tanpi(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static vectorF Tanpi(vectorFS a)
        {
            vectorF r = a;
            Inplace.Tanpi(r);
            return r;
        }

        public static vectorFT Tanpi(vectorFT a)
        {
            return new vectorFT(Tanpi(a.Vector));
        }

        public static vectorFT Tanpi(vectorFTS a)
        {
            vectorF r = new vectorFS(a.Vector, a.Scale);
            Inplace.Tanpi(r);
            return new vectorFT(r);
        }

        public static vectorF Cosd(vectorF a)
        {
            var r = new vectorF(a.Length);
            Vml.Cosd(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static vectorF Cosd(vectorFS a)
        {
            vectorF r = a;
            Inplace.Cosd(r);
            return r;
        }

        public static vectorFT Cosd(vectorFT a)
        {
            return new vectorFT(Cosd(a.Vector));
        }

        public static vectorFT Cosd(vectorFTS a)
        {
            vectorF r = new vectorFS(a.Vector, a.Scale);
            Inplace.Cosd(r);
            return new vectorFT(r);
        }

        public static vectorF Sind(vectorF a)
        {
            var r = new vectorF(a.Length);
            Vml.Sind(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static vectorF Sind(vectorFS a)
        {
            vectorF r = a;
            Inplace.Sind(r);
            return r;
        }

        public static vectorFT Sind(vectorFT a)
        {
            return new vectorFT(Sind(a.Vector));
        }

        public static vectorFT Sind(vectorFTS a)
        {
            vectorF r = new vectorFS(a.Vector, a.Scale);
            Inplace.Sind(r);
            return new vectorFT(r);
        }

        public static vectorF Tand(vectorF a)
        {
            var r = new vectorF(a.Length);
            Vml.Tand(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static vectorF Tand(vectorFS a)
        {
            vectorF r = a;
            Inplace.Tand(r);
            return r;
        }

        public static vectorFT Tand(vectorFT a)
        {
            return new vectorFT(Tand(a.Vector));
        }

        public static vectorFT Tand(vectorFTS a)
        {
            vectorF r = new vectorFS(a.Vector, a.Scale);
            Inplace.Tand(r);
            return new vectorFT(r);
        }

        public static vectorF Acos(vectorF a)
        {
            var r = new vectorF(a.Length);
            Vml.Acos(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static vectorF Acos(vectorFS a)
        {
            vectorF r = a;
            Inplace.Acos(r);
            return r;
        }

        public static vectorFT Acos(vectorFT a)
        {
            return new vectorFT(Acos(a.Vector));
        }

        public static vectorFT Acos(vectorFTS a)
        {
            vectorF r = new vectorFS(a.Vector, a.Scale);
            Inplace.Acos(r);
            return new vectorFT(r);
        }

        public static vectorF Asin(vectorF a)
        {
            var r = new vectorF(a.Length);
            Vml.Asin(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static vectorF Asin(vectorFS a)
        {
            vectorF r = a;
            Inplace.Asin(r);
            return r;
        }

        public static vectorFT Asin(vectorFT a)
        {
            return new vectorFT(Asin(a.Vector));
        }

        public static vectorFT Asin(vectorFTS a)
        {
            vectorF r = new vectorFS(a.Vector, a.Scale);
            Inplace.Asin(r);
            return new vectorFT(r);
        }

        public static vectorF Atan(vectorF a)
        {
            var r = new vectorF(a.Length);
            Vml.Atan(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static vectorF Atan(vectorFS a)
        {
            vectorF r = a;
            Inplace.Atan(r);
            return r;
        }

        public static vectorFT Atan(vectorFT a)
        {
            return new vectorFT(Atan(a.Vector));
        }

        public static vectorFT Atan(vectorFTS a)
        {
            vectorF r = new vectorFS(a.Vector, a.Scale);
            Inplace.Atan(r);
            return new vectorFT(r);
        }

        public static vectorF Acospi(vectorF a)
        {
            var r = new vectorF(a.Length);
            Vml.Acospi(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static vectorF Acospi(vectorFS a)
        {
            vectorF r = a;
            Inplace.Acospi(r);
            return r;
        }

        public static vectorFT Acospi(vectorFT a)
        {
            return new vectorFT(Acospi(a.Vector));
        }

        public static vectorFT Acospi(vectorFTS a)
        {
            vectorF r = new vectorFS(a.Vector, a.Scale);
            Inplace.Acospi(r);
            return new vectorFT(r);
        }

        public static vectorF Asinpi(vectorF a)
        {
            var r = new vectorF(a.Length);
            Vml.Asinpi(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static vectorF Asinpi(vectorFS a)
        {
            vectorF r = a;
            Inplace.Asinpi(r);
            return r;
        }

        public static vectorFT Asinpi(vectorFT a)
        {
            return new vectorFT(Asinpi(a.Vector));
        }

        public static vectorFT Asinpi(vectorFTS a)
        {
            vectorF r = new vectorFS(a.Vector, a.Scale);
            Inplace.Asinpi(r);
            return new vectorFT(r);
        }

        public static vectorF Atanpi(vectorF a)
        {
            var r = new vectorF(a.Length);
            Vml.Atanpi(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static vectorF Atanpi(vectorFS a)
        {
            vectorF r = a;
            Inplace.Atanpi(r);
            return r;
        }

        public static vectorFT Atanpi(vectorFT a)
        {
            return new vectorFT(Atanpi(a.Vector));
        }

        public static vectorFT Atanpi(vectorFTS a)
        {
            vectorF r = new vectorFS(a.Vector, a.Scale);
            Inplace.Atanpi(r);
            return new vectorFT(r);
        }

        public static vectorF Atan2(vectorF a, vectorF b)
        {
            if (a.Length != b.Length) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new vectorF(a.Length);
            Vml.Atan2(a.Length, a.Array, 0, 1, b.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static vectorF Atan2(vectorFS a, vectorF b)
        {
            vectorF r = a;
            Inplace.Atan2(r, b);
            return r;
        }

        public static vectorFT Atan2(vectorFT a, vectorF b)
        {
            return new vectorFT(Atan2(a.Vector, b));
        }

        public static vectorFT Atan2(vectorFTS a, vectorF b)
        {
            vectorF r = new vectorFS(a.Vector, a.Scale);
            Inplace.Atan2(r, b);
            return new vectorFT(r);
        }

        public static vectorF Atan2pi(vectorF a, vectorF b)
        {
            if (a.Length != b.Length) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new vectorF(a.Length);
            Vml.Atan2pi(a.Length, a.Array, 0, 1, b.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static vectorF Atan2pi(vectorFS a, vectorF b)
        {
            vectorF r = a;
            Inplace.Atan2pi(r, b);
            return r;
        }

        public static vectorFT Atan2pi(vectorFT a, vectorF b)
        {
            return new vectorFT(Atan2pi(a.Vector, b));
        }

        public static vectorFT Atan2pi(vectorFTS a, vectorF b)
        {
            vectorF r = new vectorFS(a.Vector, a.Scale);
            Inplace.Atan2pi(r, b);
            return new vectorFT(r);
        }

        public static vectorF Cosh(vectorF a)
        {
            var r = new vectorF(a.Length);
            Vml.Cosh(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static vectorF Cosh(vectorFS a)
        {
            vectorF r = a;
            Inplace.Cosh(r);
            return r;
        }

        public static vectorFT Cosh(vectorFT a)
        {
            return new vectorFT(Cosh(a.Vector));
        }

        public static vectorFT Cosh(vectorFTS a)
        {
            vectorF r = new vectorFS(a.Vector, a.Scale);
            Inplace.Cosh(r);
            return new vectorFT(r);
        }

        public static vectorF Sinh(vectorF a)
        {
            var r = new vectorF(a.Length);
            Vml.Sinh(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static vectorF Sinh(vectorFS a)
        {
            vectorF r = a;
            Inplace.Sinh(r);
            return r;
        }

        public static vectorFT Sinh(vectorFT a)
        {
            return new vectorFT(Sinh(a.Vector));
        }

        public static vectorFT Sinh(vectorFTS a)
        {
            vectorF r = new vectorFS(a.Vector, a.Scale);
            Inplace.Sinh(r);
            return new vectorFT(r);
        }

        public static vectorF Tanh(vectorF a)
        {
            var r = new vectorF(a.Length);
            Vml.Tanh(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static vectorF Tanh(vectorFS a)
        {
            vectorF r = a;
            Inplace.Tanh(r);
            return r;
        }

        public static vectorFT Tanh(vectorFT a)
        {
            return new vectorFT(Tanh(a.Vector));
        }

        public static vectorFT Tanh(vectorFTS a)
        {
            vectorF r = new vectorFS(a.Vector, a.Scale);
            Inplace.Tanh(r);
            return new vectorFT(r);
        }

        public static vectorF Acosh(vectorF a)
        {
            var r = new vectorF(a.Length);
            Vml.Acosh(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static vectorF Acosh(vectorFS a)
        {
            vectorF r = a;
            Inplace.Acosh(r);
            return r;
        }

        public static vectorFT Acosh(vectorFT a)
        {
            return new vectorFT(Acosh(a.Vector));
        }

        public static vectorFT Acosh(vectorFTS a)
        {
            vectorF r = new vectorFS(a.Vector, a.Scale);
            Inplace.Acosh(r);
            return new vectorFT(r);
        }

        public static vectorF Asinh(vectorF a)
        {
            var r = new vectorF(a.Length);
            Vml.Asinh(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static vectorF Asinh(vectorFS a)
        {
            vectorF r = a;
            Inplace.Asinh(r);
            return r;
        }

        public static vectorFT Asinh(vectorFT a)
        {
            return new vectorFT(Asinh(a.Vector));
        }

        public static vectorFT Asinh(vectorFTS a)
        {
            vectorF r = new vectorFS(a.Vector, a.Scale);
            Inplace.Asinh(r);
            return new vectorFT(r);
        }

        public static vectorF Atanh(vectorF a)
        {
            var r = new vectorF(a.Length);
            Vml.Atanh(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static vectorF Atanh(vectorFS a)
        {
            vectorF r = a;
            Inplace.Atanh(r);
            return r;
        }

        public static vectorFT Atanh(vectorFT a)
        {
            return new vectorFT(Atanh(a.Vector));
        }

        public static vectorFT Atanh(vectorFTS a)
        {
            vectorF r = new vectorFS(a.Vector, a.Scale);
            Inplace.Atanh(r);
            return new vectorFT(r);
        }

        public static vectorF Erf(vectorF a)
        {
            var r = new vectorF(a.Length);
            Vml.Erf(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static vectorF Erf(vectorFS a)
        {
            vectorF r = a;
            Inplace.Erf(r);
            return r;
        }

        public static vectorFT Erf(vectorFT a)
        {
            return new vectorFT(Erf(a.Vector));
        }

        public static vectorFT Erf(vectorFTS a)
        {
            vectorF r = new vectorFS(a.Vector, a.Scale);
            Inplace.Erf(r);
            return new vectorFT(r);
        }

        public static vectorF Erfc(vectorF a)
        {
            var r = new vectorF(a.Length);
            Vml.Erfc(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static vectorF Erfc(vectorFS a)
        {
            vectorF r = a;
            Inplace.Erfc(r);
            return r;
        }

        public static vectorFT Erfc(vectorFT a)
        {
            return new vectorFT(Erfc(a.Vector));
        }

        public static vectorFT Erfc(vectorFTS a)
        {
            vectorF r = new vectorFS(a.Vector, a.Scale);
            Inplace.Erfc(r);
            return new vectorFT(r);
        }

        public static vectorF ErfInv(vectorF a)
        {
            var r = new vectorF(a.Length);
            Vml.ErfInv(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static vectorF ErfInv(vectorFS a)
        {
            vectorF r = a;
            Inplace.ErfInv(r);
            return r;
        }

        public static vectorFT ErfInv(vectorFT a)
        {
            return new vectorFT(ErfInv(a.Vector));
        }

        public static vectorFT ErfInv(vectorFTS a)
        {
            vectorF r = new vectorFS(a.Vector, a.Scale);
            Inplace.ErfInv(r);
            return new vectorFT(r);
        }

        public static vectorF ErfcInv(vectorF a)
        {
            var r = new vectorF(a.Length);
            Vml.ErfcInv(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static vectorF ErfcInv(vectorFS a)
        {
            vectorF r = a;
            Inplace.ErfcInv(r);
            return r;
        }

        public static vectorFT ErfcInv(vectorFT a)
        {
            return new vectorFT(ErfcInv(a.Vector));
        }

        public static vectorFT ErfcInv(vectorFTS a)
        {
            vectorF r = new vectorFS(a.Vector, a.Scale);
            Inplace.ErfcInv(r);
            return new vectorFT(r);
        }

        public static vectorF CdfNorm(vectorF a)
        {
            var r = new vectorF(a.Length);
            Vml.CdfNorm(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static vectorF CdfNorm(vectorFS a)
        {
            vectorF r = a;
            Inplace.CdfNorm(r);
            return r;
        }

        public static vectorFT CdfNorm(vectorFT a)
        {
            return new vectorFT(CdfNorm(a.Vector));
        }

        public static vectorFT CdfNorm(vectorFTS a)
        {
            vectorF r = new vectorFS(a.Vector, a.Scale);
            Inplace.CdfNorm(r);
            return new vectorFT(r);
        }

        public static vectorF CdfNormInv(vectorF a)
        {
            var r = new vectorF(a.Length);
            Vml.CdfNormInv(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static vectorF CdfNormInv(vectorFS a)
        {
            vectorF r = a;
            Inplace.CdfNormInv(r);
            return r;
        }

        public static vectorFT CdfNormInv(vectorFT a)
        {
            return new vectorFT(CdfNormInv(a.Vector));
        }

        public static vectorFT CdfNormInv(vectorFTS a)
        {
            vectorF r = new vectorFS(a.Vector, a.Scale);
            Inplace.CdfNormInv(r);
            return new vectorFT(r);
        }

        public static vectorF LGamma(vectorF a)
        {
            var r = new vectorF(a.Length);
            Vml.LGamma(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static vectorF LGamma(vectorFS a)
        {
            vectorF r = a;
            Inplace.LGamma(r);
            return r;
        }

        public static vectorFT LGamma(vectorFT a)
        {
            return new vectorFT(LGamma(a.Vector));
        }

        public static vectorFT LGamma(vectorFTS a)
        {
            vectorF r = new vectorFS(a.Vector, a.Scale);
            Inplace.LGamma(r);
            return new vectorFT(r);
        }

        public static vectorF TGamma(vectorF a)
        {
            var r = new vectorF(a.Length);
            Vml.TGamma(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static vectorF TGamma(vectorFS a)
        {
            vectorF r = a;
            Inplace.TGamma(r);
            return r;
        }

        public static vectorFT TGamma(vectorFT a)
        {
            return new vectorFT(TGamma(a.Vector));
        }

        public static vectorFT TGamma(vectorFTS a)
        {
            vectorF r = new vectorFS(a.Vector, a.Scale);
            Inplace.TGamma(r);
            return new vectorFT(r);
        }

        public static vectorF ExpInt1(vectorF a)
        {
            var r = new vectorF(a.Length);
            Vml.ExpInt1(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static vectorF ExpInt1(vectorFS a)
        {
            vectorF r = a;
            Inplace.ExpInt1(r);
            return r;
        }

        public static vectorFT ExpInt1(vectorFT a)
        {
            return new vectorFT(ExpInt1(a.Vector));
        }

        public static vectorFT ExpInt1(vectorFTS a)
        {
            vectorF r = new vectorFS(a.Vector, a.Scale);
            Inplace.ExpInt1(r);
            return new vectorFT(r);
        }

        public static vectorF Floor(vectorF a)
        {
            var r = new vectorF(a.Length);
            Vml.Floor(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static vectorF Floor(vectorFS a)
        {
            vectorF r = a;
            Inplace.Floor(r);
            return r;
        }

        public static vectorFT Floor(vectorFT a)
        {
            return new vectorFT(Floor(a.Vector));
        }

        public static vectorFT Floor(vectorFTS a)
        {
            vectorF r = new vectorFS(a.Vector, a.Scale);
            Inplace.Floor(r);
            return new vectorFT(r);
        }

        public static vectorF Ceil(vectorF a)
        {
            var r = new vectorF(a.Length);
            Vml.Ceil(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static vectorF Ceil(vectorFS a)
        {
            vectorF r = a;
            Inplace.Ceil(r);
            return r;
        }

        public static vectorFT Ceil(vectorFT a)
        {
            return new vectorFT(Ceil(a.Vector));
        }

        public static vectorFT Ceil(vectorFTS a)
        {
            vectorF r = new vectorFS(a.Vector, a.Scale);
            Inplace.Ceil(r);
            return new vectorFT(r);
        }

        public static vectorF Trunc(vectorF a)
        {
            var r = new vectorF(a.Length);
            Vml.Trunc(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static vectorF Trunc(vectorFS a)
        {
            vectorF r = a;
            Inplace.Trunc(r);
            return r;
        }

        public static vectorFT Trunc(vectorFT a)
        {
            return new vectorFT(Trunc(a.Vector));
        }

        public static vectorFT Trunc(vectorFTS a)
        {
            vectorF r = new vectorFS(a.Vector, a.Scale);
            Inplace.Trunc(r);
            return new vectorFT(r);
        }

        public static vectorF Round(vectorF a)
        {
            var r = new vectorF(a.Length);
            Vml.Round(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static vectorF Round(vectorFS a)
        {
            vectorF r = a;
            Inplace.Round(r);
            return r;
        }

        public static vectorFT Round(vectorFT a)
        {
            return new vectorFT(Round(a.Vector));
        }

        public static vectorFT Round(vectorFTS a)
        {
            vectorF r = new vectorFS(a.Vector, a.Scale);
            Inplace.Round(r);
            return new vectorFT(r);
        }

        public static vectorF Frac(vectorF a)
        {
            var r = new vectorF(a.Length);
            Vml.Frac(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static vectorF Frac(vectorFS a)
        {
            vectorF r = a;
            Inplace.Frac(r);
            return r;
        }

        public static vectorFT Frac(vectorFT a)
        {
            return new vectorFT(Frac(a.Vector));
        }

        public static vectorFT Frac(vectorFTS a)
        {
            vectorF r = new vectorFS(a.Vector, a.Scale);
            Inplace.Frac(r);
            return new vectorFT(r);
        }

        public static vectorF NearbyInt(vectorF a)
        {
            var r = new vectorF(a.Length);
            Vml.NearbyInt(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static vectorF NearbyInt(vectorFS a)
        {
            vectorF r = a;
            Inplace.NearbyInt(r);
            return r;
        }

        public static vectorFT NearbyInt(vectorFT a)
        {
            return new vectorFT(NearbyInt(a.Vector));
        }

        public static vectorFT NearbyInt(vectorFTS a)
        {
            vectorF r = new vectorFS(a.Vector, a.Scale);
            Inplace.NearbyInt(r);
            return new vectorFT(r);
        }

        public static vectorF Rint(vectorF a)
        {
            var r = new vectorF(a.Length);
            Vml.Rint(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static vectorF Rint(vectorFS a)
        {
            vectorF r = a;
            Inplace.Rint(r);
            return r;
        }

        public static vectorFT Rint(vectorFT a)
        {
            return new vectorFT(Rint(a.Vector));
        }

        public static vectorFT Rint(vectorFTS a)
        {
            vectorF r = new vectorFS(a.Vector, a.Scale);
            Inplace.Rint(r);
            return new vectorFT(r);
        }

        public static vectorF CopySign(vectorF a, vectorF b)
        {
            if (a.Length != b.Length) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new vectorF(a.Length);
            Vml.CopySign(a.Length, a.Array, 0, 1, b.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static vectorF CopySign(vectorFS a, vectorF b)
        {
            vectorF r = a;
            Inplace.CopySign(r, b);
            return r;
        }

        public static vectorFT CopySign(vectorFT a, vectorF b)
        {
            return new vectorFT(CopySign(a.Vector, b));
        }

        public static vectorFT CopySign(vectorFTS a, vectorF b)
        {
            vectorF r = new vectorFS(a.Vector, a.Scale);
            Inplace.CopySign(r, b);
            return new vectorFT(r);
        }

        public static vectorF Fmax(vectorF a, vectorF b)
        {
            if (a.Length != b.Length) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new vectorF(a.Length);
            Vml.Fmax(a.Length, a.Array, 0, 1, b.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static vectorF Fmax(vectorFS a, vectorF b)
        {
            vectorF r = a;
            Inplace.Fmax(r, b);
            return r;
        }

        public static vectorFT Fmax(vectorFT a, vectorF b)
        {
            return new vectorFT(Fmax(a.Vector, b));
        }

        public static vectorFT Fmax(vectorFTS a, vectorF b)
        {
            vectorF r = new vectorFS(a.Vector, a.Scale);
            Inplace.Fmax(r, b);
            return new vectorFT(r);
        }

        public static vectorF Fmin(vectorF a, vectorF b)
        {
            if (a.Length != b.Length) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new vectorF(a.Length);
            Vml.Fmin(a.Length, a.Array, 0, 1, b.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static vectorF Fmin(vectorFS a, vectorF b)
        {
            vectorF r = a;
            Inplace.Fmin(r, b);
            return r;
        }

        public static vectorFT Fmin(vectorFT a, vectorF b)
        {
            return new vectorFT(Fmin(a.Vector, b));
        }

        public static vectorFT Fmin(vectorFTS a, vectorF b)
        {
            vectorF r = new vectorFS(a.Vector, a.Scale);
            Inplace.Fmin(r, b);
            return new vectorFT(r);
        }

        public static vectorF Fdim(vectorF a, vectorF b)
        {
            if (a.Length != b.Length) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new vectorF(a.Length);
            Vml.Fdim(a.Length, a.Array, 0, 1, b.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static vectorF Fdim(vectorFS a, vectorF b)
        {
            vectorF r = a;
            Inplace.Fdim(r, b);
            return r;
        }

        public static vectorFT Fdim(vectorFT a, vectorF b)
        {
            return new vectorFT(Fdim(a.Vector, b));
        }

        public static vectorFT Fdim(vectorFTS a, vectorF b)
        {
            vectorF r = new vectorFS(a.Vector, a.Scale);
            Inplace.Fdim(r, b);
            return new vectorFT(r);
        }

        public static vectorF MaxMag(vectorF a, vectorF b)
        {
            if (a.Length != b.Length) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new vectorF(a.Length);
            Vml.MaxMag(a.Length, a.Array, 0, 1, b.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static vectorF MaxMag(vectorFS a, vectorF b)
        {
            vectorF r = a;
            Inplace.MaxMag(r, b);
            return r;
        }

        public static vectorFT MaxMag(vectorFT a, vectorF b)
        {
            return new vectorFT(MaxMag(a.Vector, b));
        }

        public static vectorFT MaxMag(vectorFTS a, vectorF b)
        {
            vectorF r = new vectorFS(a.Vector, a.Scale);
            Inplace.MaxMag(r, b);
            return new vectorFT(r);
        }

        public static vectorF NextAfter(vectorF a, vectorF b)
        {
            if (a.Length != b.Length) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new vectorF(a.Length);
            Vml.NextAfter(a.Length, a.Array, 0, 1, b.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static vectorF NextAfter(vectorFS a, vectorF b)
        {
            vectorF r = a;
            Inplace.NextAfter(r, b);
            return r;
        }

        public static vectorFT NextAfter(vectorFT a, vectorF b)
        {
            return new vectorFT(NextAfter(a.Vector, b));
        }

        public static vectorFT NextAfter(vectorFTS a, vectorF b)
        {
            vectorF r = new vectorFS(a.Vector, a.Scale);
            Inplace.NextAfter(r, b);
            return new vectorFT(r);
        }

        public static vectorF Powx(vectorF a, float b)
        {
            var r = new vectorF(a.Length);
            Vml.Powx(a.Length, a.Array, 0, 1, b, r.Array, 0, 1);
            return r;
        }

        public static vectorF Powx(vectorFS a, float b)
        {
            vectorF r = a;
            Inplace.Powx(r, b);
            return r;
        }

        public static vectorFT Powx(vectorFT a, float b)
        {
            return new vectorFT(Powx(a.Vector, b));
        }

        public static vectorFT Powx(vectorFTS a, float b)
        {
            vectorF r = new vectorFS(a.Vector, a.Scale);
            Inplace.Powx(r, b);
            return new vectorFT(r);
        }

        public static (vectorF, vectorF) SinCos(vectorF a)
        {
            var sin = new vectorF(a.Length);
            var cos = new vectorF(a.Length);
            Vml.SinCos(a.Length, a.Array, 0, 1, sin.Array, 0, 1, cos.Array, 0, 1);
            return (sin, cos);
        }

        public static (vectorF, vectorF) SinCos(vectorFS a)
        {
            vectorF sin = a;
            var cos = Inplace.SinCos(sin);
            return (sin, cos);
        }


        public static (vectorFT, vectorFT) SinCos(vectorFT a)
        {
            var (sin, cos) = SinCos(a.Vector);
            return (new vectorFT(sin), new vectorFT(cos));
        }

        public static (vectorFT, vectorFT) SinCos(vectorFTS a)
        {
            vectorF sin = new vectorFS(a.Vector, a.Scale);
            var cos = Inplace.SinCos(sin);
            return (new vectorFT(sin), new vectorFT(cos));
        }

        public static (vectorF, vectorF) Modf(vectorF a)
        {
            var tru = new vectorF(a.Length);
            var rem = new vectorF(a.Length);
            Vml.Modf(a.Length, a.Array, 0, 1, tru.Array, 0, 1, rem.Array, 0, 1);
            return (tru, rem);
        }

        public static (vectorF, vectorF) Modf(vectorFS a)
        {
            vectorF tru = a;
            var rem = Inplace.Modf(tru);
            return (tru, rem);
        }

        public static (vectorFT, vectorFT) Modf(vectorFT a)
        {
            var (tru, rem) = Modf(a.Vector);
            return (new vectorFT(tru), new vectorFT(rem));
        }

        public static (vectorFT, vectorFT) Modf(vectorFTS a)
        {
            vectorF tru = new vectorFS(a.Vector, a.Scale);
            var rem = Inplace.Modf(tru);
            return (new vectorFT(tru), new vectorFT(rem));
        }

        public static vectorF LinearFrac(vectorF a, vectorF b, float scalea, float shifta, float scaleb, float shiftb)
        {
            if (a.Length != b.Length) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new vectorF(a.Length);
            Vml.LinearFrac(a.Length, a.Array, 0, 1, b.Array, 0, 1, scalea, shifta, scaleb, shiftb, r.Array, 0, 1);
            return r;
        }

        public static vectorF LinearFrac(vectorFS a, vectorF b, float scalea, float shifta, float scaleb, float shiftb)
        {
            vectorF r = a;
            Inplace.LinearFrac(r, b, scalea, shifta, scaleb, shiftb);
            return r;
        }

        public static vectorFT LinearFrac(vectorFT a, vectorF b, float scalea, float shifta, float scaleb, float shiftb)
        {
            return new vectorFT(LinearFrac(a.Vector, b, scalea, shifta, scaleb, shiftb));
        }

        public static vectorFT LinearFrac(vectorFTS a, vectorF b, float scalea, float shifta, float scaleb, float shiftb)
        {
            vectorF r = new vectorFS(a.Vector, a.Scale);
            Inplace.LinearFrac(r, b, scalea, shifta, scaleb, shiftb);
            return new vectorFT(r);
        }

        public static float Asum(vectorF a)
        {
            return Blas.asum(a.Length, a.Array, 0, 1);
        }

        public static float Nrm2(vectorF a)
        {
            return Blas.nrm2(a.Length, a.Array, 0, 1);
        }

        public static int Iamax(vectorF a)
        {
            return Blas.iamax(a.Length, a.Array, 0, 1);
        }

        public static int Iamin(vectorF a)
        {
            return Blas.iamin(a.Length, a.Array, 0, 1);
        }

        public static vectorF Copy(vectorF a)
        {
            var r = new vectorF(a.Length);
            Blas.copy(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }
    }
}