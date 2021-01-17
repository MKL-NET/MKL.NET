namespace MKLNET
{
    public static partial class Vector
    {
        public static vectorF Abs(vectorF a)
        {
            var r = new vectorF(a.Length);
            Vml.Abs(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static vectorF Abs(vectorFS a)
        {
            vectorF r = a;
            VectorInplace.Abs(r);
            return r;
        }

        public static vectorFT Abs(vectorFT a)
        {
            return new vectorFT(Abs(a.Vector));
        }

        public static vectorFT Abs(vectorFTS a)
        {
            vectorF r = new vectorFS(a.Vector, a.Scale);
            VectorInplace.Abs(r);
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
            VectorInplace.Sqr(r);
            return r;
        }

        public static vectorFT Sqr(vectorFT a)
        {
            return new vectorFT(Sqr(a.Vector));
        }

        public static vectorFT Sqr(vectorFTS a)
        {
            vectorF r = new vectorFS(a.Vector, a.Scale);
            VectorInplace.Sqr(r);
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
            VectorInplace.Mul(r, b);
            return r;
        }

        public static vectorFT Mul(vectorFT a, vectorF b)
        {
            return new vectorFT(Mul(a.Vector, b));
        }

        public static vectorFT Mul(vectorFTS a, vectorF b)
        {
            vectorF r = new vectorFS(a.Vector, a.Scale);
            VectorInplace.Mul(r, b);
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
            VectorInplace.Fmod(r, b);
            return r;
        }

        public static vectorFT Fmod(vectorFT a, vectorF b)
        {
            return new vectorFT(Fmod(a.Vector, b));
        }

        public static vectorFT Fmod(vectorFTS a, vectorF b)
        {
            vectorF r = new vectorFS(a.Vector, a.Scale);
            VectorInplace.Fmod(r, b);
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
            VectorInplace.Remainder(r, b);
            return r;
        }

        public static vectorFT Remainder(vectorFT a, vectorF b)
        {
            return new vectorFT(Remainder(a.Vector, b));
        }

        public static vectorFT Remainder(vectorFTS a, vectorF b)
        {
            vectorF r = new vectorFS(a.Vector, a.Scale);
            VectorInplace.Remainder(r, b);
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
            VectorInplace.Inv(r);
            return r;
        }

        public static vectorFT Inv(vectorFT a)
        {
            return new vectorFT(Inv(a.Vector));
        }

        public static vectorFT Inv(vectorFTS a)
        {
            vectorF r = new vectorFS(a.Vector, a.Scale);
            VectorInplace.Inv(r);
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
            VectorInplace.Sqrt(r);
            return r;
        }

        public static vectorFT Sqrt(vectorFT a)
        {
            return new vectorFT(Sqrt(a.Vector));
        }

        public static vectorFT Sqrt(vectorFTS a)
        {
            vectorF r = new vectorFS(a.Vector, a.Scale);
            VectorInplace.Sqrt(r);
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
            VectorInplace.InvSqrt(r);
            return r;
        }

        public static vectorFT InvSqrt(vectorFT a)
        {
            return new vectorFT(InvSqrt(a.Vector));
        }

        public static vectorFT InvSqrt(vectorFTS a)
        {
            vectorF r = new vectorFS(a.Vector, a.Scale);
            VectorInplace.InvSqrt(r);
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
            VectorInplace.Cbrt(r);
            return r;
        }

        public static vectorFT Cbrt(vectorFT a)
        {
            return new vectorFT(Cbrt(a.Vector));
        }

        public static vectorFT Cbrt(vectorFTS a)
        {
            vectorF r = new vectorFS(a.Vector, a.Scale);
            VectorInplace.Cbrt(r);
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
            VectorInplace.InvCbrt(r);
            return r;
        }

        public static vectorFT InvCbrt(vectorFT a)
        {
            return new vectorFT(InvCbrt(a.Vector));
        }

        public static vectorFT InvCbrt(vectorFTS a)
        {
            vectorF r = new vectorFS(a.Vector, a.Scale);
            VectorInplace.InvCbrt(r);
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
            VectorInplace.Hypot(r, b);
            return r;
        }

        public static vectorFT Hypot(vectorFT a, vectorF b)
        {
            return new vectorFT(Hypot(a.Vector, b));
        }

        public static vectorFT Hypot(vectorFTS a, vectorF b)
        {
            vectorF r = new vectorFS(a.Vector, a.Scale);
            VectorInplace.Hypot(r, b);
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
            VectorInplace.Div(r, b);
            return r;
        }

        public static vectorFT Div(vectorFT a, vectorF b)
        {
            return new vectorFT(Mul(a.Vector, b));
        }

        public static vectorFT Div(vectorFTS a, vectorF b)
        {
            vectorF r = new vectorFS(a.Vector, a.Scale);
            VectorInplace.Div(r, b);
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
            VectorInplace.Pow2o3(r);
            return r;
        }

        public static vectorFT Pow2o3(vectorFT a)
        {
            return new vectorFT(Pow2o3(a.Vector));
        }

        public static vectorFT Pow2o3(vectorFTS a)
        {
            vectorF r = new vectorFS(a.Vector, a.Scale);
            VectorInplace.Pow2o3(r);
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
            VectorInplace.Pow3o2(r);
            return r;
        }

        public static vectorFT Pow3o2(vectorFT a)
        {
            return new vectorFT(Pow3o2(a.Vector));
        }

        public static vectorFT Pow3o2(vectorFTS a)
        {
            vectorF r = new vectorFS(a.Vector, a.Scale);
            VectorInplace.Pow3o2(r);
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
            VectorInplace.Pow(r, b);
            return r;
        }

        public static vectorFT Pow(vectorFT a, vectorF b)
        {
            return new vectorFT(Pow(a.Vector, b));
        }

        public static vectorFT Pow(vectorFTS a, vectorF b)
        {
            vectorF r = new vectorFS(a.Vector, a.Scale);
            VectorInplace.Pow(r, b);
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
            VectorInplace.Powr(r, b);
            return r;
        }

        public static vectorFT Powr(vectorFT a, vectorF b)
        {
            return new vectorFT(Powr(a.Vector, b));
        }

        public static vectorFT Powr(vectorFTS a, vectorF b)
        {
            vectorF r = new vectorFS(a.Vector, a.Scale);
            VectorInplace.Powr(r, b);
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
            VectorInplace.Exp(r);
            return r;
        }

        public static vectorFT Exp(vectorFT a)
        {
            return new vectorFT(Exp(a.Vector));
        }

        public static vectorFT Exp(vectorFTS a)
        {
            vectorF r = new vectorFS(a.Vector, a.Scale);
            VectorInplace.Exp(r);
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
            VectorInplace.Exp2(r);
            return r;
        }

        public static vectorFT Exp2(vectorFT a)
        {
            return new vectorFT(Exp2(a.Vector));
        }

        public static vectorFT Exp2(vectorFTS a)
        {
            vectorF r = new vectorFS(a.Vector, a.Scale);
            VectorInplace.Exp2(r);
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
            VectorInplace.Exp10(r);
            return r;
        }

        public static vectorFT Exp10(vectorFT a)
        {
            return new vectorFT(Exp10(a.Vector));
        }

        public static vectorFT Exp10(vectorFTS a)
        {
            vectorF r = new vectorFS(a.Vector, a.Scale);
            VectorInplace.Exp10(r);
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
            VectorInplace.Expm1(r);
            return r;
        }

        public static vectorFT Expm1(vectorFT a)
        {
            return new vectorFT(Expm1(a.Vector));
        }

        public static vectorFT Expm1(vectorFTS a)
        {
            vectorF r = new vectorFS(a.Vector, a.Scale);
            VectorInplace.Expm1(r);
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
            VectorInplace.Ln(r);
            return r;
        }

        public static vectorFT Ln(vectorFT a)
        {
            return new vectorFT(Ln(a.Vector));
        }

        public static vectorFT Ln(vectorFTS a)
        {
            vectorF r = new vectorFS(a.Vector, a.Scale);
            VectorInplace.Ln(r);
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
            VectorInplace.Log2(r);
            return r;
        }

        public static vectorFT Log2(vectorFT a)
        {
            return new vectorFT(Log2(a.Vector));
        }

        public static vectorFT Log2(vectorFTS a)
        {
            vectorF r = new vectorFS(a.Vector, a.Scale);
            VectorInplace.Log2(r);
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
            VectorInplace.Log10(r);
            return r;
        }

        public static vectorFT Log10(vectorFT a)
        {
            return new vectorFT(Log10(a.Vector));
        }

        public static vectorFT Log10(vectorFTS a)
        {
            vectorF r = new vectorFS(a.Vector, a.Scale);
            VectorInplace.Log10(r);
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
            VectorInplace.Log1p(r);
            return r;
        }

        public static vectorFT Log1p(vectorFT a)
        {
            return new vectorFT(Log1p(a.Vector));
        }

        public static vectorFT Log1p(vectorFTS a)
        {
            vectorF r = new vectorFS(a.Vector, a.Scale);
            VectorInplace.Log1p(r);
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
            VectorInplace.Logb(r);
            return r;
        }

        public static vectorFT Logb(vectorFT a)
        {
            return new vectorFT(Logb(a.Vector));
        }

        public static vectorFT Logb(vectorFTS a)
        {
            vectorF r = new vectorFS(a.Vector, a.Scale);
            VectorInplace.Logb(r);
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
            VectorInplace.Cos(r);
            return r;
        }

        public static vectorFT Cos(vectorFT a)
        {
            return new vectorFT(Cos(a.Vector));
        }

        public static vectorFT Cos(vectorFTS a)
        {
            vectorF r = new vectorFS(a.Vector, a.Scale);
            VectorInplace.Cos(r);
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
            VectorInplace.Sin(r);
            return r;
        }

        public static vectorFT Sin(vectorFT a)
        {
            return new vectorFT(Sin(a.Vector));
        }

        public static vectorFT Sin(vectorFTS a)
        {
            vectorF r = new vectorFS(a.Vector, a.Scale);
            VectorInplace.Sin(r);
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
            VectorInplace.Tan(r);
            return r;
        }

        public static vectorFT Tan(vectorFT a)
        {
            return new vectorFT(Tan(a.Vector));
        }

        public static vectorFT Tan(vectorFTS a)
        {
            vectorF r = new vectorFS(a.Vector, a.Scale);
            VectorInplace.Tan(r);
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
            VectorInplace.Cospi(r);
            return r;
        }

        public static vectorFT Cospi(vectorFT a)
        {
            return new vectorFT(Cospi(a.Vector));
        }

        public static vectorFT Cospi(vectorFTS a)
        {
            vectorF r = new vectorFS(a.Vector, a.Scale);
            VectorInplace.Cospi(r);
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
            VectorInplace.Sinpi(r);
            return r;
        }

        public static vectorFT Sinpi(vectorFT a)
        {
            return new vectorFT(Sinpi(a.Vector));
        }

        public static vectorFT Sinpi(vectorFTS a)
        {
            vectorF r = new vectorFS(a.Vector, a.Scale);
            VectorInplace.Sinpi(r);
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
            VectorInplace.Tanpi(r);
            return r;
        }

        public static vectorFT Tanpi(vectorFT a)
        {
            return new vectorFT(Tanpi(a.Vector));
        }

        public static vectorFT Tanpi(vectorFTS a)
        {
            vectorF r = new vectorFS(a.Vector, a.Scale);
            VectorInplace.Tanpi(r);
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
            VectorInplace.Cosd(r);
            return r;
        }

        public static vectorFT Cosd(vectorFT a)
        {
            return new vectorFT(Cosd(a.Vector));
        }

        public static vectorFT Cosd(vectorFTS a)
        {
            vectorF r = new vectorFS(a.Vector, a.Scale);
            VectorInplace.Cosd(r);
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
            VectorInplace.Sind(r);
            return r;
        }

        public static vectorFT Sind(vectorFT a)
        {
            return new vectorFT(Sind(a.Vector));
        }

        public static vectorFT Sind(vectorFTS a)
        {
            vectorF r = new vectorFS(a.Vector, a.Scale);
            VectorInplace.Sind(r);
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
            VectorInplace.Tand(r);
            return r;
        }

        public static vectorFT Tand(vectorFT a)
        {
            return new vectorFT(Tand(a.Vector));
        }

        public static vectorFT Tand(vectorFTS a)
        {
            vectorF r = new vectorFS(a.Vector, a.Scale);
            VectorInplace.Tand(r);
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
            VectorInplace.Acos(r);
            return r;
        }

        public static vectorFT Acos(vectorFT a)
        {
            return new vectorFT(Acos(a.Vector));
        }

        public static vectorFT Acos(vectorFTS a)
        {
            vectorF r = new vectorFS(a.Vector, a.Scale);
            VectorInplace.Acos(r);
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
            VectorInplace.Asin(r);
            return r;
        }

        public static vectorFT Asin(vectorFT a)
        {
            return new vectorFT(Asin(a.Vector));
        }

        public static vectorFT Asin(vectorFTS a)
        {
            vectorF r = new vectorFS(a.Vector, a.Scale);
            VectorInplace.Asin(r);
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
            VectorInplace.Atan(r);
            return r;
        }

        public static vectorFT Atan(vectorFT a)
        {
            return new vectorFT(Atan(a.Vector));
        }

        public static vectorFT Atan(vectorFTS a)
        {
            vectorF r = new vectorFS(a.Vector, a.Scale);
            VectorInplace.Atan(r);
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
            VectorInplace.Acospi(r);
            return r;
        }

        public static vectorFT Acospi(vectorFT a)
        {
            return new vectorFT(Acospi(a.Vector));
        }

        public static vectorFT Acospi(vectorFTS a)
        {
            vectorF r = new vectorFS(a.Vector, a.Scale);
            VectorInplace.Acospi(r);
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
            VectorInplace.Asinpi(r);
            return r;
        }

        public static vectorFT Asinpi(vectorFT a)
        {
            return new vectorFT(Asinpi(a.Vector));
        }

        public static vectorFT Asinpi(vectorFTS a)
        {
            vectorF r = new vectorFS(a.Vector, a.Scale);
            VectorInplace.Asinpi(r);
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
            VectorInplace.Atanpi(r);
            return r;
        }

        public static vectorFT Atanpi(vectorFT a)
        {
            return new vectorFT(Atanpi(a.Vector));
        }

        public static vectorFT Atanpi(vectorFTS a)
        {
            vectorF r = new vectorFS(a.Vector, a.Scale);
            VectorInplace.Atanpi(r);
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
            VectorInplace.Atan2(r, b);
            return r;
        }

        public static vectorFT Atan2(vectorFT a, vectorF b)
        {
            return new vectorFT(Atan2(a.Vector, b));
        }

        public static vectorFT Atan2(vectorFTS a, vectorF b)
        {
            vectorF r = new vectorFS(a.Vector, a.Scale);
            VectorInplace.Atan2(r, b);
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
            VectorInplace.Atan2pi(r, b);
            return r;
        }

        public static vectorFT Atan2pi(vectorFT a, vectorF b)
        {
            return new vectorFT(Atan2pi(a.Vector, b));
        }

        public static vectorFT Atan2pi(vectorFTS a, vectorF b)
        {
            vectorF r = new vectorFS(a.Vector, a.Scale);
            VectorInplace.Atan2pi(r, b);
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
            VectorInplace.Cosh(r);
            return r;
        }

        public static vectorFT Cosh(vectorFT a)
        {
            return new vectorFT(Cosh(a.Vector));
        }

        public static vectorFT Cosh(vectorFTS a)
        {
            vectorF r = new vectorFS(a.Vector, a.Scale);
            VectorInplace.Cosh(r);
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
            VectorInplace.Sinh(r);
            return r;
        }

        public static vectorFT Sinh(vectorFT a)
        {
            return new vectorFT(Sinh(a.Vector));
        }

        public static vectorFT Sinh(vectorFTS a)
        {
            vectorF r = new vectorFS(a.Vector, a.Scale);
            VectorInplace.Sinh(r);
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
            VectorInplace.Tanh(r);
            return r;
        }

        public static vectorFT Tanh(vectorFT a)
        {
            return new vectorFT(Tanh(a.Vector));
        }

        public static vectorFT Tanh(vectorFTS a)
        {
            vectorF r = new vectorFS(a.Vector, a.Scale);
            VectorInplace.Tanh(r);
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
            VectorInplace.Acosh(r);
            return r;
        }

        public static vectorFT Acosh(vectorFT a)
        {
            return new vectorFT(Acosh(a.Vector));
        }

        public static vectorFT Acosh(vectorFTS a)
        {
            vectorF r = new vectorFS(a.Vector, a.Scale);
            VectorInplace.Acosh(r);
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
            VectorInplace.Asinh(r);
            return r;
        }

        public static vectorFT Asinh(vectorFT a)
        {
            return new vectorFT(Asinh(a.Vector));
        }

        public static vectorFT Asinh(vectorFTS a)
        {
            vectorF r = new vectorFS(a.Vector, a.Scale);
            VectorInplace.Asinh(r);
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
            VectorInplace.Atanh(r);
            return r;
        }

        public static vectorFT Atanh(vectorFT a)
        {
            return new vectorFT(Atanh(a.Vector));
        }

        public static vectorFT Atanh(vectorFTS a)
        {
            vectorF r = new vectorFS(a.Vector, a.Scale);
            VectorInplace.Atanh(r);
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
            VectorInplace.Erf(r);
            return r;
        }

        public static vectorFT Erf(vectorFT a)
        {
            return new vectorFT(Erf(a.Vector));
        }

        public static vectorFT Erf(vectorFTS a)
        {
            vectorF r = new vectorFS(a.Vector, a.Scale);
            VectorInplace.Erf(r);
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
            VectorInplace.Erfc(r);
            return r;
        }

        public static vectorFT Erfc(vectorFT a)
        {
            return new vectorFT(Erfc(a.Vector));
        }

        public static vectorFT Erfc(vectorFTS a)
        {
            vectorF r = new vectorFS(a.Vector, a.Scale);
            VectorInplace.Erfc(r);
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
            VectorInplace.ErfInv(r);
            return r;
        }

        public static vectorFT ErfInv(vectorFT a)
        {
            return new vectorFT(ErfInv(a.Vector));
        }

        public static vectorFT ErfInv(vectorFTS a)
        {
            vectorF r = new vectorFS(a.Vector, a.Scale);
            VectorInplace.ErfInv(r);
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
            VectorInplace.ErfcInv(r);
            return r;
        }

        public static vectorFT ErfcInv(vectorFT a)
        {
            return new vectorFT(ErfcInv(a.Vector));
        }

        public static vectorFT ErfcInv(vectorFTS a)
        {
            vectorF r = new vectorFS(a.Vector, a.Scale);
            VectorInplace.ErfcInv(r);
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
            VectorInplace.CdfNorm(r);
            return r;
        }

        public static vectorFT CdfNorm(vectorFT a)
        {
            return new vectorFT(CdfNorm(a.Vector));
        }

        public static vectorFT CdfNorm(vectorFTS a)
        {
            vectorF r = new vectorFS(a.Vector, a.Scale);
            VectorInplace.CdfNorm(r);
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
            VectorInplace.CdfNormInv(r);
            return r;
        }

        public static vectorFT CdfNormInv(vectorFT a)
        {
            return new vectorFT(CdfNormInv(a.Vector));
        }

        public static vectorFT CdfNormInv(vectorFTS a)
        {
            vectorF r = new vectorFS(a.Vector, a.Scale);
            VectorInplace.CdfNormInv(r);
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
            VectorInplace.LGamma(r);
            return r;
        }

        public static vectorFT LGamma(vectorFT a)
        {
            return new vectorFT(LGamma(a.Vector));
        }

        public static vectorFT LGamma(vectorFTS a)
        {
            vectorF r = new vectorFS(a.Vector, a.Scale);
            VectorInplace.LGamma(r);
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
            VectorInplace.TGamma(r);
            return r;
        }

        public static vectorFT TGamma(vectorFT a)
        {
            return new vectorFT(TGamma(a.Vector));
        }

        public static vectorFT TGamma(vectorFTS a)
        {
            vectorF r = new vectorFS(a.Vector, a.Scale);
            VectorInplace.TGamma(r);
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
            VectorInplace.ExpInt1(r);
            return r;
        }

        public static vectorFT ExpInt1(vectorFT a)
        {
            return new vectorFT(ExpInt1(a.Vector));
        }

        public static vectorFT ExpInt1(vectorFTS a)
        {
            vectorF r = new vectorFS(a.Vector, a.Scale);
            VectorInplace.ExpInt1(r);
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
            VectorInplace.Floor(r);
            return r;
        }

        public static vectorFT Floor(vectorFT a)
        {
            return new vectorFT(Floor(a.Vector));
        }

        public static vectorFT Floor(vectorFTS a)
        {
            vectorF r = new vectorFS(a.Vector, a.Scale);
            VectorInplace.Floor(r);
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
            VectorInplace.Ceil(r);
            return r;
        }

        public static vectorFT Ceil(vectorFT a)
        {
            return new vectorFT(Ceil(a.Vector));
        }

        public static vectorFT Ceil(vectorFTS a)
        {
            vectorF r = new vectorFS(a.Vector, a.Scale);
            VectorInplace.Ceil(r);
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
            VectorInplace.Trunc(r);
            return r;
        }

        public static vectorFT Trunc(vectorFT a)
        {
            return new vectorFT(Trunc(a.Vector));
        }

        public static vectorFT Trunc(vectorFTS a)
        {
            vectorF r = new vectorFS(a.Vector, a.Scale);
            VectorInplace.Trunc(r);
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
            VectorInplace.Round(r);
            return r;
        }

        public static vectorFT Round(vectorFT a)
        {
            return new vectorFT(Round(a.Vector));
        }

        public static vectorFT Round(vectorFTS a)
        {
            vectorF r = new vectorFS(a.Vector, a.Scale);
            VectorInplace.Round(r);
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
            VectorInplace.Frac(r);
            return r;
        }

        public static vectorFT Frac(vectorFT a)
        {
            return new vectorFT(Frac(a.Vector));
        }

        public static vectorFT Frac(vectorFTS a)
        {
            vectorF r = new vectorFS(a.Vector, a.Scale);
            VectorInplace.Frac(r);
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
            VectorInplace.NearbyInt(r);
            return r;
        }

        public static vectorFT NearbyInt(vectorFT a)
        {
            return new vectorFT(NearbyInt(a.Vector));
        }

        public static vectorFT NearbyInt(vectorFTS a)
        {
            vectorF r = new vectorFS(a.Vector, a.Scale);
            VectorInplace.NearbyInt(r);
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
            VectorInplace.Rint(r);
            return r;
        }

        public static vectorFT Rint(vectorFT a)
        {
            return new vectorFT(Rint(a.Vector));
        }

        public static vectorFT Rint(vectorFTS a)
        {
            vectorF r = new vectorFS(a.Vector, a.Scale);
            VectorInplace.Rint(r);
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
            VectorInplace.CopySign(r, b);
            return r;
        }

        public static vectorFT CopySign(vectorFT a, vectorF b)
        {
            return new vectorFT(CopySign(a.Vector, b));
        }

        public static vectorFT CopySign(vectorFTS a, vectorF b)
        {
            vectorF r = new vectorFS(a.Vector, a.Scale);
            VectorInplace.CopySign(r, b);
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
            VectorInplace.Fmax(r, b);
            return r;
        }

        public static vectorFT Fmax(vectorFT a, vectorF b)
        {
            return new vectorFT(Fmax(a.Vector, b));
        }

        public static vectorFT Fmax(vectorFTS a, vectorF b)
        {
            vectorF r = new vectorFS(a.Vector, a.Scale);
            VectorInplace.Fmax(r, b);
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
            VectorInplace.Fmin(r, b);
            return r;
        }

        public static vectorFT Fmin(vectorFT a, vectorF b)
        {
            return new vectorFT(Fmin(a.Vector, b));
        }

        public static vectorFT Fmin(vectorFTS a, vectorF b)
        {
            vectorF r = new vectorFS(a.Vector, a.Scale);
            VectorInplace.Fmin(r, b);
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
            VectorInplace.Fdim(r, b);
            return r;
        }

        public static vectorFT Fdim(vectorFT a, vectorF b)
        {
            return new vectorFT(Fdim(a.Vector, b));
        }

        public static vectorFT Fdim(vectorFTS a, vectorF b)
        {
            vectorF r = new vectorFS(a.Vector, a.Scale);
            VectorInplace.Fdim(r, b);
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
            VectorInplace.MaxMag(r, b);
            return r;
        }

        public static vectorFT MaxMag(vectorFT a, vectorF b)
        {
            return new vectorFT(MaxMag(a.Vector, b));
        }

        public static vectorFT MaxMag(vectorFTS a, vectorF b)
        {
            vectorF r = new vectorFS(a.Vector, a.Scale);
            VectorInplace.MaxMag(r, b);
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
            VectorInplace.NextAfter(r, b);
            return r;
        }

        public static vectorFT NextAfter(vectorFT a, vectorF b)
        {
            return new vectorFT(NextAfter(a.Vector, b));
        }

        public static vectorFT NextAfter(vectorFTS a, vectorF b)
        {
            vectorF r = new vectorFS(a.Vector, a.Scale);
            VectorInplace.NextAfter(r, b);
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
            VectorInplace.Powx(r, b);
            return r;
        }

        public static vectorFT Powx(vectorFT a, float b)
        {
            return new vectorFT(Powx(a.Vector, b));
        }

        public static vectorFT Powx(vectorFTS a, float b)
        {
            vectorF r = new vectorFS(a.Vector, a.Scale);
            VectorInplace.Powx(r, b);
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
            var cos = VectorInplace.SinCos(sin);
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
            var cos = VectorInplace.SinCos(sin);
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
            var rem = VectorInplace.Modf(tru);
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
            var rem = VectorInplace.Modf(tru);
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
            VectorInplace.LinearFrac(r, b, scalea, shifta, scaleb, shiftb);
            return r;
        }

        public static vectorFT LinearFrac(vectorFT a, vectorF b, float scalea, float shifta, float scaleb, float shiftb)
        {
            return new vectorFT(LinearFrac(a.Vector, b, scalea, shifta, scaleb, shiftb));
        }

        public static vectorFT LinearFrac(vectorFTS a, vectorF b, float scalea, float shifta, float scaleb, float shiftb)
        {
            vectorF r = new vectorFS(a.Vector, a.Scale);
            VectorInplace.LinearFrac(r, b, scalea, shifta, scaleb, shiftb);
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

    public static partial class VectorInplace
    {
        public static vectorF Abs(this vectorF a)
        {
            Vml.Abs(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static vectorF Add(this vectorF a, vectorF b)
        {
            Vml.Add(a.Length, a.Array, 0, 1, b.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static vectorF Sub(this vectorF a, vectorF b)
        {
            Vml.Sub(a.Length, a.Array, 0, 1, b.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static vectorF Sqr(this vectorF a)
        {
            Vml.Sqr(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static vectorF Mul(this vectorF a, vectorF b)
        {
            Vml.Mul(a.Length, a.Array, 0, 1, b.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static vectorF Fmod(this vectorF a, vectorF b)
        {
            Vml.Fmod(a.Length, a.Array, 0, 1, b.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static vectorF Remainder(this vectorF a, vectorF b)
        {
            Vml.Remainder(a.Length, a.Array, 0, 1, b.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static vectorF Inv(this vectorF a)
        {
            Vml.Inv(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static vectorF Sqrt(this vectorF a)
        {
            Vml.Sqrt(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static vectorF InvSqrt(this vectorF a)
        {
            Vml.InvSqrt(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static vectorF Cbrt(this vectorF a)
        {
            Vml.Cbrt(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static vectorF InvCbrt(this vectorF a)
        {
            Vml.InvCbrt(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static vectorF Hypot(this vectorF a, vectorF b)
        {
            Vml.Hypot(a.Length, a.Array, 0, 1, b.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static vectorF Div(this vectorF a, vectorF b)
        {
            Vml.Div(a.Length, a.Array, 0, 1, b.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static vectorF Pow2o3(this vectorF a)
        {
            Vml.Pow2o3(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static vectorF Pow3o2(this vectorF a)
        {
            Vml.Pow3o2(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static vectorF Pow(this vectorF a, vectorF b)
        {
            Vml.Pow(a.Length, a.Array, 0, 1, b.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static vectorF Powr(this vectorF a, vectorF b)
        {
            Vml.Powr(a.Length, a.Array, 0, 1, b.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static vectorF Exp(this vectorF a)
        {
            Vml.Exp(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static vectorF Exp2(this vectorF a)
        {
            Vml.Exp2(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static vectorF Exp10(this vectorF a)
        {
            Vml.Exp10(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static vectorF Expm1(this vectorF a)
        {
            Vml.Expm1(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static vectorF Ln(this vectorF a)
        {
            Vml.Ln(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static vectorF Log2(this vectorF a)
        {
            Vml.Log2(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static vectorF Log10(this vectorF a)
        {
            Vml.Log10(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static vectorF Log1p(this vectorF a)
        {
            Vml.Log1p(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static vectorF Logb(this vectorF a)
        {
            Vml.Logb(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static vectorF Cos(this vectorF a)
        {
            Vml.Cos(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static vectorF Sin(this vectorF a)
        {
            Vml.Sin(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static vectorF Tan(this vectorF a)
        {
            Vml.Tan(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static vectorF Cospi(this vectorF a)
        {
            Vml.Cospi(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static vectorF Sinpi(this vectorF a)
        {
            Vml.Sinpi(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static vectorF Tanpi(this vectorF a)
        {
            Vml.Tanpi(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static vectorF Cosd(this vectorF a)
        {
            Vml.Cosd(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static vectorF Sind(this vectorF a)
        {
            Vml.Sind(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static vectorF Tand(this vectorF a)
        {
            Vml.Tand(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static vectorF Acos(this vectorF a)
        {
            Vml.Acos(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static vectorF Asin(this vectorF a)
        {
            Vml.Asin(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static vectorF Atan(this vectorF a)
        {
            Vml.Atan(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static vectorF Acospi(this vectorF a)
        {
            Vml.Acospi(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static vectorF Asinpi(this vectorF a)
        {
            Vml.Asinpi(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static vectorF Atanpi(this vectorF a)
        {
            Vml.Atanpi(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static vectorF Atan2(this vectorF a, vectorF b)
        {
            Vml.Atan2(a.Length, a.Array, 0, 1, b.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static vectorF Atan2pi(this vectorF a, vectorF b)
        {
            Vml.Atan2pi(a.Length, a.Array, 0, 1, b.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static vectorF Cosh(this vectorF a)
        {
            Vml.Cosh(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static vectorF Sinh(this vectorF a)
        {
            Vml.Sinh(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static vectorF Tanh(this vectorF a)
        {
            Vml.Tanh(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static vectorF Acosh(this vectorF a)
        {
            Vml.Acosh(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static vectorF Asinh(this vectorF a)
        {
            Vml.Asinh(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static vectorF Atanh(this vectorF a)
        {
            Vml.Atanh(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static vectorF Erf(this vectorF a)
        {
            Vml.Erf(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static vectorF Erfc(this vectorF a)
        {
            Vml.Erfc(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static vectorF ErfInv(this vectorF a)
        {
            Vml.ErfInv(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static vectorF ErfcInv(this vectorF a)
        {
            Vml.ErfcInv(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static vectorF CdfNorm(this vectorF a)
        {
            Vml.CdfNorm(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static vectorF CdfNormInv(this vectorF a)
        {
            Vml.CdfNormInv(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static vectorF LGamma(this vectorF a)
        {
            Vml.LGamma(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static vectorF TGamma(this vectorF a)
        {
            Vml.TGamma(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static vectorF ExpInt1(this vectorF a)
        {
            Vml.ExpInt1(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static vectorF Floor(this vectorF a)
        {
            Vml.Floor(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static vectorF Ceil(this vectorF a)
        {
            Vml.Ceil(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static vectorF Trunc(this vectorF a)
        {
            Vml.Trunc(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static vectorF Round(this vectorF a)
        {
            Vml.Round(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static vectorF Frac(this vectorF a)
        {
            Vml.Frac(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static vectorF NearbyInt(this vectorF a)
        {
            Vml.NearbyInt(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static vectorF Rint(this vectorF a)
        {
            Vml.Rint(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static vectorF CopySign(this vectorF a, vectorF b)
        {
            Vml.CopySign(a.Length, a.Array, 0, 1, b.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static vectorF Fmax(this vectorF a, vectorF b)
        {
            Vml.Fmax(a.Length, a.Array, 0, 1, b.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static vectorF Fmin(this vectorF a, vectorF b)
        {
            Vml.Fmin(a.Length, a.Array, 0, 1, b.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static vectorF Fdim(this vectorF a, vectorF b)
        {
            Vml.Fdim(a.Length, a.Array, 0, 1, b.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static vectorF MaxMag(this vectorF a, vectorF b)
        {
            Vml.MaxMag(a.Length, a.Array, 0, 1, b.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static vectorF NextAfter(this vectorF a, vectorF b)
        {
            Vml.NextAfter(a.Length, a.Array, 0, 1, b.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static vectorF Powx(this vectorF a, float b)
        {
            Vml.Powx(a.Length, a.Array, 0, 1, b, a.Array, 0, 1);
            return a;
        }

        public static vectorF LinearFrac(this vectorF a, vectorF b, float scalea, float shifta, float scaleb, float shiftb)
        {
            Vml.LinearFrac(a.Length, a.Array, 0, 1, b.Array, 0, 1, scalea, shifta, scaleb, shiftb, a.Array, 0, 1);
            return a;
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

        public static vectorF Scal(this vectorF a, float s)
        {
            Blas.scal(a.Length, s, a.Array, 0, 1);
            return a;
        }

        public static vectorF Copy(this vectorF a, vectorF b)
        {
            Blas.copy(b.Length, b.Array, 0, 1, a.Array, 0, 1);
            return a;
        }
    }
}