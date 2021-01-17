namespace MKLNET
{
    public static partial class Vector
    {
        public static vector Abs(vector a)
        {
            var r = new vector(a.Length);
            Vml.Abs(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static vector Abs(vectorS a)
        {
            vector r = a;
            VectorInplace.Abs(r);
            return r;
        }

        public static vectorT Abs(vectorT a)
        {
            return new vectorT(Abs(a.Vector));
        }

        public static vectorT Abs(vectorTS a)
        {
            vector r = new vectorS(a.Vector, a.Scale);
            VectorInplace.Abs(r);
            return new vectorT(r);
        }

        public static vector Sqr(vector a)
        {
            var r = new vector(a.Length);
            Vml.Sqr(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static vector Sqr(vectorS a)
        {
            vector r = a;
            VectorInplace.Sqr(r);
            return r;
        }

        public static vectorT Sqr(vectorT a)
        {
            return new vectorT(Sqr(a.Vector));
        }

        public static vectorT Sqr(vectorTS a)
        {
            vector r = new vectorS(a.Vector, a.Scale);
            VectorInplace.Sqr(r);
            return new vectorT(r);
        }

        public static vector Mul(vector a, vector b)
        {
            if (a.Length != b.Length) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new vector(a.Length);
            Vml.Mul(a.Length, a.Array, 0, 1, b.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static vector Mul(vectorS a, vector b)
        {
            vector r = a;
            VectorInplace.Mul(r, b);
            return r;
        }

        public static vectorT Mul(vectorT a, vector b)
        {
            return new vectorT(Mul(a.Vector, b));
        }

        public static vectorT Mul(vectorTS a, vector b)
        {
            vector r = new vectorS(a.Vector, a.Scale);
            VectorInplace.Mul(r, b);
            return new vectorT(r);
        }

        public static vector Fmod(vector a, vector b)
        {
            if (a.Length != b.Length) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new vector(a.Length);
            Vml.Fmod(a.Length, a.Array, 0, 1, b.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static vector Fmod(vectorS a, vector b)
        {
            vector r = a;
            VectorInplace.Fmod(r, b);
            return r;
        }

        public static vectorT Fmod(vectorT a, vector b)
        {
            return new vectorT(Fmod(a.Vector, b));
        }

        public static vectorT Fmod(vectorTS a, vector b)
        {
            vector r = new vectorS(a.Vector, a.Scale);
            VectorInplace.Fmod(r, b);
            return new vectorT(r);
        }

        public static vector Remainder(vector a, vector b)
        {
            if (a.Length != b.Length) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new vector(a.Length);
            Vml.Remainder(a.Length, a.Array, 0, 1, b.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static vector Remainder(vectorS a, vector b)
        {
            vector r = a;
            VectorInplace.Remainder(r, b);
            return r;
        }

        public static vectorT Remainder(vectorT a, vector b)
        {
            return new vectorT(Remainder(a.Vector, b));
        }

        public static vectorT Remainder(vectorTS a, vector b)
        {
            vector r = new vectorS(a.Vector, a.Scale);
            VectorInplace.Remainder(r, b);
            return new vectorT(r);
        }

        public static vector Inv(vector a)
        {
            var r = new vector(a.Length);
            Vml.Inv(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static vector Inv(vectorS a)
        {
            vector r = a;
            VectorInplace.Inv(r);
            return r;
        }

        public static vectorT Inv(vectorT a)
        {
            return new vectorT(Inv(a.Vector));
        }

        public static vectorT Inv(vectorTS a)
        {
            vector r = new vectorS(a.Vector, a.Scale);
            VectorInplace.Inv(r);
            return new vectorT(r);
        }

        public static vector Sqrt(vector a)
        {
            var r = new vector(a.Length);
            Vml.Sqrt(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static vector Sqrt(vectorS a)
        {
            vector r = a;
            VectorInplace.Sqrt(r);
            return r;
        }

        public static vectorT Sqrt(vectorT a)
        {
            return new vectorT(Sqrt(a.Vector));
        }

        public static vectorT Sqrt(vectorTS a)
        {
            vector r = new vectorS(a.Vector, a.Scale);
            VectorInplace.Sqrt(r);
            return new vectorT(r);
        }

        public static vector InvSqrt(vector a)
        {
            var r = new vector(a.Length);
            Vml.InvSqrt(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static vector InvSqrt(vectorS a)
        {
            vector r = a;
            VectorInplace.InvSqrt(r);
            return r;
        }

        public static vectorT InvSqrt(vectorT a)
        {
            return new vectorT(InvSqrt(a.Vector));
        }

        public static vectorT InvSqrt(vectorTS a)
        {
            vector r = new vectorS(a.Vector, a.Scale);
            VectorInplace.InvSqrt(r);
            return new vectorT(r);
        }

        public static vector Cbrt(vector a)
        {
            var r = new vector(a.Length);
            Vml.Cbrt(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static vector Cbrt(vectorS a)
        {
            vector r = a;
            VectorInplace.Cbrt(r);
            return r;
        }

        public static vectorT Cbrt(vectorT a)
        {
            return new vectorT(Cbrt(a.Vector));
        }

        public static vectorT Cbrt(vectorTS a)
        {
            vector r = new vectorS(a.Vector, a.Scale);
            VectorInplace.Cbrt(r);
            return new vectorT(r);
        }

        public static vector InvCbrt(vector a)
        {
            var r = new vector(a.Length);
            Vml.InvCbrt(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static vector InvCbrt(vectorS a)
        {
            vector r = a;
            VectorInplace.InvCbrt(r);
            return r;
        }

        public static vectorT InvCbrt(vectorT a)
        {
            return new vectorT(InvCbrt(a.Vector));
        }

        public static vectorT InvCbrt(vectorTS a)
        {
            vector r = new vectorS(a.Vector, a.Scale);
            VectorInplace.InvCbrt(r);
            return new vectorT(r);
        }

        public static vector Hypot(vector a, vector b)
        {
            if (a.Length != b.Length) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new vector(a.Length);
            Vml.Hypot(a.Length, a.Array, 0, 1, b.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static vector Hypot(vectorS a, vector b)
        {
            vector r = a;
            VectorInplace.Hypot(r, b);
            return r;
        }

        public static vectorT Hypot(vectorT a, vector b)
        {
            return new vectorT(Hypot(a.Vector, b));
        }

        public static vectorT Hypot(vectorTS a, vector b)
        {
            vector r = new vectorS(a.Vector, a.Scale);
            VectorInplace.Hypot(r, b);
            return new vectorT(r);
        }

        public static vector Div(vector a, vector b)
        {
            if (a.Length != b.Length) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new vector(a.Length);
            Vml.Div(a.Length, a.Array, 0, 1, b.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static vector Div(vectorS a, vector b)
        {
            vector r = a;
            VectorInplace.Div(r, b);
            return r;
        }

        public static vectorT Div(vectorT a, vector b)
        {
            return new vectorT(Mul(a.Vector, b));
        }

        public static vectorT Div(vectorTS a, vector b)
        {
            vector r = new vectorS(a.Vector, a.Scale);
            VectorInplace.Div(r, b);
            return new vectorT(r);
        }

        public static vector Pow2o3(vector a)
        {
            var r = new vector(a.Length);
            Vml.Pow2o3(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static vector Pow2o3(vectorS a)
        {
            vector r = a;
            VectorInplace.Pow2o3(r);
            return r;
        }

        public static vectorT Pow2o3(vectorT a)
        {
            return new vectorT(Pow2o3(a.Vector));
        }

        public static vectorT Pow2o3(vectorTS a)
        {
            vector r = new vectorS(a.Vector, a.Scale);
            VectorInplace.Pow2o3(r);
            return new vectorT(r);
        }

        public static vector Pow3o2(vector a)
        {
            var r = new vector(a.Length);
            Vml.Pow3o2(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static vector Pow3o2(vectorS a)
        {
            vector r = a;
            VectorInplace.Pow3o2(r);
            return r;
        }

        public static vectorT Pow3o2(vectorT a)
        {
            return new vectorT(Pow3o2(a.Vector));
        }

        public static vectorT Pow3o2(vectorTS a)
        {
            vector r = new vectorS(a.Vector, a.Scale);
            VectorInplace.Pow3o2(r);
            return new vectorT(r);
        }

        public static vector Pow(vector a, vector b)
        {
            if (a.Length != b.Length) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new vector(a.Length);
            Vml.Pow(a.Length, a.Array, 0, 1, b.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static vector Pow(vectorS a, vector b)
        {
            vector r = a;
            VectorInplace.Pow(r, b);
            return r;
        }

        public static vectorT Pow(vectorT a, vector b)
        {
            return new vectorT(Pow(a.Vector, b));
        }

        public static vectorT Pow(vectorTS a, vector b)
        {
            vector r = new vectorS(a.Vector, a.Scale);
            VectorInplace.Pow(r, b);
            return new vectorT(r);
        }

        public static vector Powr(vector a, vector b)
        {
            if (a.Length != b.Length) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new vector(a.Length);
            Vml.Powr(a.Length, a.Array, 0, 1, b.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static vector Powr(vectorS a, vector b)
        {
            vector r = a;
            VectorInplace.Powr(r, b);
            return r;
        }

        public static vectorT Powr(vectorT a, vector b)
        {
            return new vectorT(Powr(a.Vector, b));
        }

        public static vectorT Powr(vectorTS a, vector b)
        {
            vector r = new vectorS(a.Vector, a.Scale);
            VectorInplace.Powr(r, b);
            return new vectorT(r);
        }

        public static vector Exp(vector a)
        {
            var r = new vector(a.Length);
            Vml.Exp(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static vector Exp(vectorS a)
        {
            vector r = a;
            VectorInplace.Exp(r);
            return r;
        }

        public static vectorT Exp(vectorT a)
        {
            return new vectorT(Exp(a.Vector));
        }

        public static vectorT Exp(vectorTS a)
        {
            vector r = new vectorS(a.Vector, a.Scale);
            VectorInplace.Exp(r);
            return new vectorT(r);
        }

        public static vector Exp2(vector a)
        {
            var r = new vector(a.Length);
            Vml.Exp2(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static vector Exp2(vectorS a)
        {
            vector r = a;
            VectorInplace.Exp2(r);
            return r;
        }

        public static vectorT Exp2(vectorT a)
        {
            return new vectorT(Exp2(a.Vector));
        }

        public static vectorT Exp2(vectorTS a)
        {
            vector r = new vectorS(a.Vector, a.Scale);
            VectorInplace.Exp2(r);
            return new vectorT(r);
        }

        public static vector Exp10(vector a)
        {
            var r = new vector(a.Length);
            Vml.Exp10(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static vector Exp10(vectorS a)
        {
            vector r = a;
            VectorInplace.Exp10(r);
            return r;
        }

        public static vectorT Exp10(vectorT a)
        {
            return new vectorT(Exp10(a.Vector));
        }

        public static vectorT Exp10(vectorTS a)
        {
            vector r = new vectorS(a.Vector, a.Scale);
            VectorInplace.Exp10(r);
            return new vectorT(r);
        }

        public static vector Expm1(vector a)
        {
            var r = new vector(a.Length);
            Vml.Expm1(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static vector Expm1(vectorS a)
        {
            vector r = a;
            VectorInplace.Expm1(r);
            return r;
        }

        public static vectorT Expm1(vectorT a)
        {
            return new vectorT(Expm1(a.Vector));
        }

        public static vectorT Expm1(vectorTS a)
        {
            vector r = new vectorS(a.Vector, a.Scale);
            VectorInplace.Expm1(r);
            return new vectorT(r);
        }

        public static vector Ln(vector a)
        {
            var r = new vector(a.Length);
            Vml.Ln(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static vector Ln(vectorS a)
        {
            vector r = a;
            VectorInplace.Ln(r);
            return r;
        }

        public static vectorT Ln(vectorT a)
        {
            return new vectorT(Ln(a.Vector));
        }

        public static vectorT Ln(vectorTS a)
        {
            vector r = new vectorS(a.Vector, a.Scale);
            VectorInplace.Ln(r);
            return new vectorT(r);
        }

        public static vector Log2(vector a)
        {
            var r = new vector(a.Length);
            Vml.Log2(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static vector Log2(vectorS a)
        {
            vector r = a;
            VectorInplace.Log2(r);
            return r;
        }

        public static vectorT Log2(vectorT a)
        {
            return new vectorT(Log2(a.Vector));
        }

        public static vectorT Log2(vectorTS a)
        {
            vector r = new vectorS(a.Vector, a.Scale);
            VectorInplace.Log2(r);
            return new vectorT(r);
        }

        public static vector Log10(vector a)
        {
            var r = new vector(a.Length);
            Vml.Log10(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static vector Log10(vectorS a)
        {
            vector r = a;
            VectorInplace.Log10(r);
            return r;
        }

        public static vectorT Log10(vectorT a)
        {
            return new vectorT(Log10(a.Vector));
        }

        public static vectorT Log10(vectorTS a)
        {
            vector r = new vectorS(a.Vector, a.Scale);
            VectorInplace.Log10(r);
            return new vectorT(r);
        }

        public static vector Log1p(vector a)
        {
            var r = new vector(a.Length);
            Vml.Log1p(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static vector Log1p(vectorS a)
        {
            vector r = a;
            VectorInplace.Log1p(r);
            return r;
        }

        public static vectorT Log1p(vectorT a)
        {
            return new vectorT(Log1p(a.Vector));
        }

        public static vectorT Log1p(vectorTS a)
        {
            vector r = new vectorS(a.Vector, a.Scale);
            VectorInplace.Log1p(r);
            return new vectorT(r);
        }

        public static vector Logb(vector a)
        {
            var r = new vector(a.Length);
            Vml.Logb(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static vector Logb(vectorS a)
        {
            vector r = a;
            VectorInplace.Logb(r);
            return r;
        }

        public static vectorT Logb(vectorT a)
        {
            return new vectorT(Logb(a.Vector));
        }

        public static vectorT Logb(vectorTS a)
        {
            vector r = new vectorS(a.Vector, a.Scale);
            VectorInplace.Logb(r);
            return new vectorT(r);
        }

        public static vector Cos(vector a)
        {
            var r = new vector(a.Length);
            Vml.Cos(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static vector Cos(vectorS a)
        {
            vector r = a;
            VectorInplace.Cos(r);
            return r;
        }

        public static vectorT Cos(vectorT a)
        {
            return new vectorT(Cos(a.Vector));
        }

        public static vectorT Cos(vectorTS a)
        {
            vector r = new vectorS(a.Vector, a.Scale);
            VectorInplace.Cos(r);
            return new vectorT(r);
        }

        public static vector Sin(vector a)
        {
            var r = new vector(a.Length);
            Vml.Sin(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static vector Sin(vectorS a)
        {
            vector r = a;
            VectorInplace.Sin(r);
            return r;
        }

        public static vectorT Sin(vectorT a)
        {
            return new vectorT(Sin(a.Vector));
        }

        public static vectorT Sin(vectorTS a)
        {
            vector r = new vectorS(a.Vector, a.Scale);
            VectorInplace.Sin(r);
            return new vectorT(r);
        }

        public static vector Tan(vector a)
        {
            var r = new vector(a.Length);
            Vml.Tan(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static vector Tan(vectorS a)
        {
            vector r = a;
            VectorInplace.Tan(r);
            return r;
        }

        public static vectorT Tan(vectorT a)
        {
            return new vectorT(Tan(a.Vector));
        }

        public static vectorT Tan(vectorTS a)
        {
            vector r = new vectorS(a.Vector, a.Scale);
            VectorInplace.Tan(r);
            return new vectorT(r);
        }

        public static vector Cospi(vector a)
        {
            var r = new vector(a.Length);
            Vml.Cospi(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static vector Cospi(vectorS a)
        {
            vector r = a;
            VectorInplace.Cospi(r);
            return r;
        }

        public static vectorT Cospi(vectorT a)
        {
            return new vectorT(Cospi(a.Vector));
        }

        public static vectorT Cospi(vectorTS a)
        {
            vector r = new vectorS(a.Vector, a.Scale);
            VectorInplace.Cospi(r);
            return new vectorT(r);
        }

        public static vector Sinpi(vector a)
        {
            var r = new vector(a.Length);
            Vml.Sinpi(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static vector Sinpi(vectorS a)
        {
            vector r = a;
            VectorInplace.Sinpi(r);
            return r;
        }

        public static vectorT Sinpi(vectorT a)
        {
            return new vectorT(Sinpi(a.Vector));
        }

        public static vectorT Sinpi(vectorTS a)
        {
            vector r = new vectorS(a.Vector, a.Scale);
            VectorInplace.Sinpi(r);
            return new vectorT(r);
        }

        public static vector Tanpi(vector a)
        {
            var r = new vector(a.Length);
            Vml.Tanpi(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static vector Tanpi(vectorS a)
        {
            vector r = a;
            VectorInplace.Tanpi(r);
            return r;
        }

        public static vectorT Tanpi(vectorT a)
        {
            return new vectorT(Tanpi(a.Vector));
        }

        public static vectorT Tanpi(vectorTS a)
        {
            vector r = new vectorS(a.Vector, a.Scale);
            VectorInplace.Tanpi(r);
            return new vectorT(r);
        }

        public static vector Cosd(vector a)
        {
            var r = new vector(a.Length);
            Vml.Cosd(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static vector Cosd(vectorS a)
        {
            vector r = a;
            VectorInplace.Cosd(r);
            return r;
        }

        public static vectorT Cosd(vectorT a)
        {
            return new vectorT(Cosd(a.Vector));
        }

        public static vectorT Cosd(vectorTS a)
        {
            vector r = new vectorS(a.Vector, a.Scale);
            VectorInplace.Cosd(r);
            return new vectorT(r);
        }

        public static vector Sind(vector a)
        {
            var r = new vector(a.Length);
            Vml.Sind(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static vector Sind(vectorS a)
        {
            vector r = a;
            VectorInplace.Sind(r);
            return r;
        }

        public static vectorT Sind(vectorT a)
        {
            return new vectorT(Sind(a.Vector));
        }

        public static vectorT Sind(vectorTS a)
        {
            vector r = new vectorS(a.Vector, a.Scale);
            VectorInplace.Sind(r);
            return new vectorT(r);
        }

        public static vector Tand(vector a)
        {
            var r = new vector(a.Length);
            Vml.Tand(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static vector Tand(vectorS a)
        {
            vector r = a;
            VectorInplace.Tand(r);
            return r;
        }

        public static vectorT Tand(vectorT a)
        {
            return new vectorT(Tand(a.Vector));
        }

        public static vectorT Tand(vectorTS a)
        {
            vector r = new vectorS(a.Vector, a.Scale);
            VectorInplace.Tand(r);
            return new vectorT(r);
        }

        public static vector Acos(vector a)
        {
            var r = new vector(a.Length);
            Vml.Acos(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static vector Acos(vectorS a)
        {
            vector r = a;
            VectorInplace.Acos(r);
            return r;
        }

        public static vectorT Acos(vectorT a)
        {
            return new vectorT(Acos(a.Vector));
        }

        public static vectorT Acos(vectorTS a)
        {
            vector r = new vectorS(a.Vector, a.Scale);
            VectorInplace.Acos(r);
            return new vectorT(r);
        }

        public static vector Asin(vector a)
        {
            var r = new vector(a.Length);
            Vml.Asin(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static vector Asin(vectorS a)
        {
            vector r = a;
            VectorInplace.Asin(r);
            return r;
        }

        public static vectorT Asin(vectorT a)
        {
            return new vectorT(Asin(a.Vector));
        }

        public static vectorT Asin(vectorTS a)
        {
            vector r = new vectorS(a.Vector, a.Scale);
            VectorInplace.Asin(r);
            return new vectorT(r);
        }

        public static vector Atan(vector a)
        {
            var r = new vector(a.Length);
            Vml.Atan(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static vector Atan(vectorS a)
        {
            vector r = a;
            VectorInplace.Atan(r);
            return r;
        }

        public static vectorT Atan(vectorT a)
        {
            return new vectorT(Atan(a.Vector));
        }

        public static vectorT Atan(vectorTS a)
        {
            vector r = new vectorS(a.Vector, a.Scale);
            VectorInplace.Atan(r);
            return new vectorT(r);
        }

        public static vector Acospi(vector a)
        {
            var r = new vector(a.Length);
            Vml.Acospi(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static vector Acospi(vectorS a)
        {
            vector r = a;
            VectorInplace.Acospi(r);
            return r;
        }

        public static vectorT Acospi(vectorT a)
        {
            return new vectorT(Acospi(a.Vector));
        }

        public static vectorT Acospi(vectorTS a)
        {
            vector r = new vectorS(a.Vector, a.Scale);
            VectorInplace.Acospi(r);
            return new vectorT(r);
        }

        public static vector Asinpi(vector a)
        {
            var r = new vector(a.Length);
            Vml.Asinpi(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static vector Asinpi(vectorS a)
        {
            vector r = a;
            VectorInplace.Asinpi(r);
            return r;
        }

        public static vectorT Asinpi(vectorT a)
        {
            return new vectorT(Asinpi(a.Vector));
        }

        public static vectorT Asinpi(vectorTS a)
        {
            vector r = new vectorS(a.Vector, a.Scale);
            VectorInplace.Asinpi(r);
            return new vectorT(r);
        }

        public static vector Atanpi(vector a)
        {
            var r = new vector(a.Length);
            Vml.Atanpi(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static vector Atanpi(vectorS a)
        {
            vector r = a;
            VectorInplace.Atanpi(r);
            return r;
        }

        public static vectorT Atanpi(vectorT a)
        {
            return new vectorT(Atanpi(a.Vector));
        }

        public static vectorT Atanpi(vectorTS a)
        {
            vector r = new vectorS(a.Vector, a.Scale);
            VectorInplace.Atanpi(r);
            return new vectorT(r);
        }

        public static vector Atan2(vector a, vector b)
        {
            if (a.Length != b.Length) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new vector(a.Length);
            Vml.Atan2(a.Length, a.Array, 0, 1, b.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static vector Atan2(vectorS a, vector b)
        {
            vector r = a;
            VectorInplace.Atan2(r, b);
            return r;
        }

        public static vectorT Atan2(vectorT a, vector b)
        {
            return new vectorT(Atan2(a.Vector, b));
        }

        public static vectorT Atan2(vectorTS a, vector b)
        {
            vector r = new vectorS(a.Vector, a.Scale);
            VectorInplace.Atan2(r, b);
            return new vectorT(r);
        }

        public static vector Atan2pi(vector a, vector b)
        {
            if (a.Length != b.Length) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new vector(a.Length);
            Vml.Atan2pi(a.Length, a.Array, 0, 1, b.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static vector Atan2pi(vectorS a, vector b)
        {
            vector r = a;
            VectorInplace.Atan2pi(r, b);
            return r;
        }

        public static vectorT Atan2pi(vectorT a, vector b)
        {
            return new vectorT(Atan2pi(a.Vector, b));
        }

        public static vectorT Atan2pi(vectorTS a, vector b)
        {
            vector r = new vectorS(a.Vector, a.Scale);
            VectorInplace.Atan2pi(r, b);
            return new vectorT(r);
        }

        public static vector Cosh(vector a)
        {
            var r = new vector(a.Length);
            Vml.Cosh(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static vector Cosh(vectorS a)
        {
            vector r = a;
            VectorInplace.Cosh(r);
            return r;
        }

        public static vectorT Cosh(vectorT a)
        {
            return new vectorT(Cosh(a.Vector));
        }

        public static vectorT Cosh(vectorTS a)
        {
            vector r = new vectorS(a.Vector, a.Scale);
            VectorInplace.Cosh(r);
            return new vectorT(r);
        }

        public static vector Sinh(vector a)
        {
            var r = new vector(a.Length);
            Vml.Sinh(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static vector Sinh(vectorS a)
        {
            vector r = a;
            VectorInplace.Sinh(r);
            return r;
        }

        public static vectorT Sinh(vectorT a)
        {
            return new vectorT(Sinh(a.Vector));
        }

        public static vectorT Sinh(vectorTS a)
        {
            vector r = new vectorS(a.Vector, a.Scale);
            VectorInplace.Sinh(r);
            return new vectorT(r);
        }

        public static vector Tanh(vector a)
        {
            var r = new vector(a.Length);
            Vml.Tanh(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static vector Tanh(vectorS a)
        {
            vector r = a;
            VectorInplace.Tanh(r);
            return r;
        }

        public static vectorT Tanh(vectorT a)
        {
            return new vectorT(Tanh(a.Vector));
        }

        public static vectorT Tanh(vectorTS a)
        {
            vector r = new vectorS(a.Vector, a.Scale);
            VectorInplace.Tanh(r);
            return new vectorT(r);
        }

        public static vector Acosh(vector a)
        {
            var r = new vector(a.Length);
            Vml.Acosh(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static vector Acosh(vectorS a)
        {
            vector r = a;
            VectorInplace.Acosh(r);
            return r;
        }

        public static vectorT Acosh(vectorT a)
        {
            return new vectorT(Acosh(a.Vector));
        }

        public static vectorT Acosh(vectorTS a)
        {
            vector r = new vectorS(a.Vector, a.Scale);
            VectorInplace.Acosh(r);
            return new vectorT(r);
        }

        public static vector Asinh(vector a)
        {
            var r = new vector(a.Length);
            Vml.Asinh(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static vector Asinh(vectorS a)
        {
            vector r = a;
            VectorInplace.Asinh(r);
            return r;
        }

        public static vectorT Asinh(vectorT a)
        {
            return new vectorT(Asinh(a.Vector));
        }

        public static vectorT Asinh(vectorTS a)
        {
            vector r = new vectorS(a.Vector, a.Scale);
            VectorInplace.Asinh(r);
            return new vectorT(r);
        }

        public static vector Atanh(vector a)
        {
            var r = new vector(a.Length);
            Vml.Atanh(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static vector Atanh(vectorS a)
        {
            vector r = a;
            VectorInplace.Atanh(r);
            return r;
        }

        public static vectorT Atanh(vectorT a)
        {
            return new vectorT(Atanh(a.Vector));
        }

        public static vectorT Atanh(vectorTS a)
        {
            vector r = new vectorS(a.Vector, a.Scale);
            VectorInplace.Atanh(r);
            return new vectorT(r);
        }

        public static vector Erf(vector a)
        {
            var r = new vector(a.Length);
            Vml.Erf(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static vector Erf(vectorS a)
        {
            vector r = a;
            VectorInplace.Erf(r);
            return r;
        }

        public static vectorT Erf(vectorT a)
        {
            return new vectorT(Erf(a.Vector));
        }

        public static vectorT Erf(vectorTS a)
        {
            vector r = new vectorS(a.Vector, a.Scale);
            VectorInplace.Erf(r);
            return new vectorT(r);
        }

        public static vector Erfc(vector a)
        {
            var r = new vector(a.Length);
            Vml.Erfc(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static vector Erfc(vectorS a)
        {
            vector r = a;
            VectorInplace.Erfc(r);
            return r;
        }

        public static vectorT Erfc(vectorT a)
        {
            return new vectorT(Erfc(a.Vector));
        }

        public static vectorT Erfc(vectorTS a)
        {
            vector r = new vectorS(a.Vector, a.Scale);
            VectorInplace.Erfc(r);
            return new vectorT(r);
        }

        public static vector ErfInv(vector a)
        {
            var r = new vector(a.Length);
            Vml.ErfInv(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static vector ErfInv(vectorS a)
        {
            vector r = a;
            VectorInplace.ErfInv(r);
            return r;
        }

        public static vectorT ErfInv(vectorT a)
        {
            return new vectorT(ErfInv(a.Vector));
        }

        public static vectorT ErfInv(vectorTS a)
        {
            vector r = new vectorS(a.Vector, a.Scale);
            VectorInplace.ErfInv(r);
            return new vectorT(r);
        }

        public static vector ErfcInv(vector a)
        {
            var r = new vector(a.Length);
            Vml.ErfcInv(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static vector ErfcInv(vectorS a)
        {
            vector r = a;
            VectorInplace.ErfcInv(r);
            return r;
        }

        public static vectorT ErfcInv(vectorT a)
        {
            return new vectorT(ErfcInv(a.Vector));
        }

        public static vectorT ErfcInv(vectorTS a)
        {
            vector r = new vectorS(a.Vector, a.Scale);
            VectorInplace.ErfcInv(r);
            return new vectorT(r);
        }

        public static vector CdfNorm(vector a)
        {
            var r = new vector(a.Length);
            Vml.CdfNorm(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static vector CdfNorm(vectorS a)
        {
            vector r = a;
            VectorInplace.CdfNorm(r);
            return r;
        }

        public static vectorT CdfNorm(vectorT a)
        {
            return new vectorT(CdfNorm(a.Vector));
        }

        public static vectorT CdfNorm(vectorTS a)
        {
            vector r = new vectorS(a.Vector, a.Scale);
            VectorInplace.CdfNorm(r);
            return new vectorT(r);
        }

        public static vector CdfNormInv(vector a)
        {
            var r = new vector(a.Length);
            Vml.CdfNormInv(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static vector CdfNormInv(vectorS a)
        {
            vector r = a;
            VectorInplace.CdfNormInv(r);
            return r;
        }

        public static vectorT CdfNormInv(vectorT a)
        {
            return new vectorT(CdfNormInv(a.Vector));
        }

        public static vectorT CdfNormInv(vectorTS a)
        {
            vector r = new vectorS(a.Vector, a.Scale);
            VectorInplace.CdfNormInv(r);
            return new vectorT(r);
        }

        public static vector LGamma(vector a)
        {
            var r = new vector(a.Length);
            Vml.LGamma(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static vector LGamma(vectorS a)
        {
            vector r = a;
            VectorInplace.LGamma(r);
            return r;
        }

        public static vectorT LGamma(vectorT a)
        {
            return new vectorT(LGamma(a.Vector));
        }

        public static vectorT LGamma(vectorTS a)
        {
            vector r = new vectorS(a.Vector, a.Scale);
            VectorInplace.LGamma(r);
            return new vectorT(r);
        }

        public static vector TGamma(vector a)
        {
            var r = new vector(a.Length);
            Vml.TGamma(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static vector TGamma(vectorS a)
        {
            vector r = a;
            VectorInplace.TGamma(r);
            return r;
        }

        public static vectorT TGamma(vectorT a)
        {
            return new vectorT(TGamma(a.Vector));
        }

        public static vectorT TGamma(vectorTS a)
        {
            vector r = new vectorS(a.Vector, a.Scale);
            VectorInplace.TGamma(r);
            return new vectorT(r);
        }

        public static vector ExpInt1(vector a)
        {
            var r = new vector(a.Length);
            Vml.ExpInt1(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static vector ExpInt1(vectorS a)
        {
            vector r = a;
            VectorInplace.ExpInt1(r);
            return r;
        }

        public static vectorT ExpInt1(vectorT a)
        {
            return new vectorT(ExpInt1(a.Vector));
        }

        public static vectorT ExpInt1(vectorTS a)
        {
            vector r = new vectorS(a.Vector, a.Scale);
            VectorInplace.ExpInt1(r);
            return new vectorT(r);
        }

        public static vector Floor(vector a)
        {
            var r = new vector(a.Length);
            Vml.Floor(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static vector Floor(vectorS a)
        {
            vector r = a;
            VectorInplace.Floor(r);
            return r;
        }

        public static vectorT Floor(vectorT a)
        {
            return new vectorT(Floor(a.Vector));
        }

        public static vectorT Floor(vectorTS a)
        {
            vector r = new vectorS(a.Vector, a.Scale);
            VectorInplace.Floor(r);
            return new vectorT(r);
        }

        public static vector Ceil(vector a)
        {
            var r = new vector(a.Length);
            Vml.Ceil(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static vector Ceil(vectorS a)
        {
            vector r = a;
            VectorInplace.Ceil(r);
            return r;
        }

        public static vectorT Ceil(vectorT a)
        {
            return new vectorT(Ceil(a.Vector));
        }

        public static vectorT Ceil(vectorTS a)
        {
            vector r = new vectorS(a.Vector, a.Scale);
            VectorInplace.Ceil(r);
            return new vectorT(r);
        }

        public static vector Trunc(vector a)
        {
            var r = new vector(a.Length);
            Vml.Trunc(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static vector Trunc(vectorS a)
        {
            vector r = a;
            VectorInplace.Trunc(r);
            return r;
        }

        public static vectorT Trunc(vectorT a)
        {
            return new vectorT(Trunc(a.Vector));
        }

        public static vectorT Trunc(vectorTS a)
        {
            vector r = new vectorS(a.Vector, a.Scale);
            VectorInplace.Trunc(r);
            return new vectorT(r);
        }

        public static vector Round(vector a)
        {
            var r = new vector(a.Length);
            Vml.Round(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static vector Round(vectorS a)
        {
            vector r = a;
            VectorInplace.Round(r);
            return r;
        }

        public static vectorT Round(vectorT a)
        {
            return new vectorT(Round(a.Vector));
        }

        public static vectorT Round(vectorTS a)
        {
            vector r = new vectorS(a.Vector, a.Scale);
            VectorInplace.Round(r);
            return new vectorT(r);
        }

        public static vector Frac(vector a)
        {
            var r = new vector(a.Length);
            Vml.Frac(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static vector Frac(vectorS a)
        {
            vector r = a;
            VectorInplace.Frac(r);
            return r;
        }

        public static vectorT Frac(vectorT a)
        {
            return new vectorT(Frac(a.Vector));
        }

        public static vectorT Frac(vectorTS a)
        {
            vector r = new vectorS(a.Vector, a.Scale);
            VectorInplace.Frac(r);
            return new vectorT(r);
        }

        public static vector NearbyInt(vector a)
        {
            var r = new vector(a.Length);
            Vml.NearbyInt(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static vector NearbyInt(vectorS a)
        {
            vector r = a;
            VectorInplace.NearbyInt(r);
            return r;
        }

        public static vectorT NearbyInt(vectorT a)
        {
            return new vectorT(NearbyInt(a.Vector));
        }

        public static vectorT NearbyInt(vectorTS a)
        {
            vector r = new vectorS(a.Vector, a.Scale);
            VectorInplace.NearbyInt(r);
            return new vectorT(r);
        }

        public static vector Rint(vector a)
        {
            var r = new vector(a.Length);
            Vml.Rint(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static vector Rint(vectorS a)
        {
            vector r = a;
            VectorInplace.Rint(r);
            return r;
        }

        public static vectorT Rint(vectorT a)
        {
            return new vectorT(Rint(a.Vector));
        }

        public static vectorT Rint(vectorTS a)
        {
            vector r = new vectorS(a.Vector, a.Scale);
            VectorInplace.Rint(r);
            return new vectorT(r);
        }

        public static vector CopySign(vector a, vector b)
        {
            if (a.Length != b.Length) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new vector(a.Length);
            Vml.CopySign(a.Length, a.Array, 0, 1, b.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static vector CopySign(vectorS a, vector b)
        {
            vector r = a;
            VectorInplace.CopySign(r, b);
            return r;
        }

        public static vectorT CopySign(vectorT a, vector b)
        {
            return new vectorT(CopySign(a.Vector, b));
        }

        public static vectorT CopySign(vectorTS a, vector b)
        {
            vector r = new vectorS(a.Vector, a.Scale);
            VectorInplace.CopySign(r, b);
            return new vectorT(r);
        }

        public static vector Fmax(vector a, vector b)
        {
            if (a.Length != b.Length) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new vector(a.Length);
            Vml.Fmax(a.Length, a.Array, 0, 1, b.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static vector Fmax(vectorS a, vector b)
        {
            vector r = a;
            VectorInplace.Fmax(r, b);
            return r;
        }

        public static vectorT Fmax(vectorT a, vector b)
        {
            return new vectorT(Fmax(a.Vector, b));
        }

        public static vectorT Fmax(vectorTS a, vector b)
        {
            vector r = new vectorS(a.Vector, a.Scale);
            VectorInplace.Fmax(r, b);
            return new vectorT(r);
        }

        public static vector Fmin(vector a, vector b)
        {
            if (a.Length != b.Length) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new vector(a.Length);
            Vml.Fmin(a.Length, a.Array, 0, 1, b.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static vector Fmin(vectorS a, vector b)
        {
            vector r = a;
            VectorInplace.Fmin(r, b);
            return r;
        }

        public static vectorT Fmin(vectorT a, vector b)
        {
            return new vectorT(Fmin(a.Vector, b));
        }

        public static vectorT Fmin(vectorTS a, vector b)
        {
            vector r = new vectorS(a.Vector, a.Scale);
            VectorInplace.Fmin(r, b);
            return new vectorT(r);
        }

        public static vector Fdim(vector a, vector b)
        {
            if (a.Length != b.Length) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new vector(a.Length);
            Vml.Fdim(a.Length, a.Array, 0, 1, b.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static vector Fdim(vectorS a, vector b)
        {
            vector r = a;
            VectorInplace.Fdim(r, b);
            return r;
        }

        public static vectorT Fdim(vectorT a, vector b)
        {
            return new vectorT(Fdim(a.Vector, b));
        }

        public static vectorT Fdim(vectorTS a, vector b)
        {
            vector r = new vectorS(a.Vector, a.Scale);
            VectorInplace.Fdim(r, b);
            return new vectorT(r);
        }

        public static vector MaxMag(vector a, vector b)
        {
            if (a.Length != b.Length) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new vector(a.Length);
            Vml.MaxMag(a.Length, a.Array, 0, 1, b.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static vector MaxMag(vectorS a, vector b)
        {
            vector r = a;
            VectorInplace.MaxMag(r, b);
            return r;
        }

        public static vectorT MaxMag(vectorT a, vector b)
        {
            return new vectorT(MaxMag(a.Vector, b));
        }

        public static vectorT MaxMag(vectorTS a, vector b)
        {
            vector r = new vectorS(a.Vector, a.Scale);
            VectorInplace.MaxMag(r, b);
            return new vectorT(r);
        }

        public static vector NextAfter(vector a, vector b)
        {
            if (a.Length != b.Length) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new vector(a.Length);
            Vml.NextAfter(a.Length, a.Array, 0, 1, b.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static vector NextAfter(vectorS a, vector b)
        {
            vector r = a;
            VectorInplace.NextAfter(r, b);
            return r;
        }

        public static vectorT NextAfter(vectorT a, vector b)
        {
            return new vectorT(NextAfter(a.Vector, b));
        }

        public static vectorT NextAfter(vectorTS a, vector b)
        {
            vector r = new vectorS(a.Vector, a.Scale);
            VectorInplace.NextAfter(r, b);
            return new vectorT(r);
        }

        public static vector Powx(vector a, double b)
        {
            var r = new vector(a.Length);
            Vml.Powx(a.Length, a.Array, 0, 1, b, r.Array, 0, 1);
            return r;
        }

        public static vector Powx(vectorS a, double b)
        {
            vector r = a;
            VectorInplace.Powx(r, b);
            return r;
        }

        public static vectorT Powx(vectorT a, double b)
        {
            return new vectorT(Powx(a.Vector, b));
        }

        public static vectorT Powx(vectorTS a, double b)
        {
            vector r = new vectorS(a.Vector, a.Scale);
            VectorInplace.Powx(r, b);
            return new vectorT(r);
        }

        public static (vector, vector) SinCos(vector a)
        {
            var sin = new vector(a.Length);
            var cos = new vector(a.Length);
            Vml.SinCos(a.Length, a.Array, 0, 1, sin.Array, 0, 1, cos.Array, 0, 1);
            return (sin, cos);
        }

        public static (vector, vector) SinCos(vectorS a)
        {
            vector sin = a;
            var cos = VectorInplace.SinCos(sin);
            return (sin, cos);
        }


        public static (vectorT, vectorT) SinCos(vectorT a)
        {
            var (sin, cos) = SinCos(a.Vector);
            return (new vectorT(sin), new vectorT(cos));
        }

        public static (vectorT, vectorT) SinCos(vectorTS a)
        {
            vector sin = new vectorS(a.Vector, a.Scale);
            var cos = VectorInplace.SinCos(sin);
            return (new vectorT(sin), new vectorT(cos));
        }

        public static (vector, vector) Modf(vector a)
        {
            var tru = new vector(a.Length);
            var rem = new vector(a.Length);
            Vml.Modf(a.Length, a.Array, 0, 1, tru.Array, 0, 1, rem.Array, 0, 1);
            return (tru, rem);
        }

        public static (vector, vector) Modf(vectorS a)
        {
            vector tru = a;
            var rem = VectorInplace.Modf(tru);
            return (tru, rem);
        }

        public static (vectorT, vectorT) Modf(vectorT a)
        {
            var (tru, rem) = Modf(a.Vector);
            return (new vectorT(tru), new vectorT(rem));
        }

        public static (vectorT, vectorT) Modf(vectorTS a)
        {
            vector tru = new vectorS(a.Vector, a.Scale);
            var rem = VectorInplace.Modf(tru);
            return (new vectorT(tru), new vectorT(rem));
        }

        public static vector LinearFrac(vector a, vector b, double scalea, double shifta, double scaleb, double shiftb)
        {
            if (a.Length != b.Length) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new vector(a.Length);
            Vml.LinearFrac(a.Length, a.Array, 0, 1, b.Array, 0, 1, scalea, shifta, scaleb, shiftb, r.Array, 0, 1);
            return r;
        }

        public static vector LinearFrac(vectorS a, vector b, double scalea, double shifta, double scaleb, double shiftb)
        {
            vector r = a;
            VectorInplace.LinearFrac(r, b, scalea, shifta, scaleb, shiftb);
            return r;
        }

        public static vectorT LinearFrac(vectorT a, vector b, double scalea, double shifta, double scaleb, double shiftb)
        {
            return new vectorT(LinearFrac(a.Vector, b, scalea, shifta, scaleb, shiftb));
        }

        public static vectorT LinearFrac(vectorTS a, vector b, double scalea, double shifta, double scaleb, double shiftb)
        {
            vector r = new vectorS(a.Vector, a.Scale);
            VectorInplace.LinearFrac(r, b, scalea, shifta, scaleb, shiftb);
            return new vectorT(r);
        }

        public static double Asum(vector a)
        {
            return Blas.asum(a.Length, a.Array, 0, 1);
        }

        public static double Nrm2(vector a)
        {
            return Blas.nrm2(a.Length, a.Array, 0, 1);
        }

        public static int Iamax(vector a)
        {
            return Blas.iamax(a.Length, a.Array, 0, 1);
        }

        public static int Iamin(vector a)
        {
            return Blas.iamin(a.Length, a.Array, 0, 1);
        }

        public static vector Copy(vector a)
        {
            var r = new vector(a.Length);
            Blas.copy(a.Length, a.Array, 0, 1, r.Array, 0, 1);
            return r;
        }
    }

    public static partial class VectorInplace
    {
        public static vector Abs(this vector a)
        {
            Vml.Abs(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static vector Add(this vector a, vector b)
        {
            Vml.Add(a.Length, a.Array, 0, 1, b.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static vector AddMul(this vector c, matrix a, vector b)
        {
            Blas.gemv(Layout.ColMajor, Trans.No, a.Rows, a.Cols, 1.0, a.Array, a.Rows, b.Array, 0, 1, 1.0, c.Array, 0, 1);
            return c;
        }

        public static vector CopyMul(this vector c, matrix a, vector b)
        {
            Blas.gemv(Layout.ColMajor, Trans.No, a.Rows, a.Cols, 1.0, a.Array, a.Rows, b.Array, 0, 1, 0.0, c.Array, 0, 1);
            return c;
        }

        public static vector CopyMul(this vector c, double s, matrix a, vector b)
        {
            Blas.gemv(Layout.ColMajor, Trans.No, a.Rows, a.Cols, s, a.Array, a.Rows, b.Array, 0, 1, 0.0, c.Array, 0, 1);
            return c;
        }

        public static vector Sub(this vector a, vector b)
        {
            Vml.Sub(a.Length, a.Array, 0, 1, b.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static vector Sqr(this vector a)
        {
            Vml.Sqr(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static vector Mul(this vector a, vector b)
        {
            Vml.Mul(a.Length, a.Array, 0, 1, b.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static vector PreMul(this vector a, matrix b)
        {
            Blas.gemv(Layout.ColMajor, Trans.No, b.Rows, b.Cols, 1.0, b.Array, b.Rows, a.Array, 0, 1, 0.0, a.Array, 0, 1);
            return a;
        }

        public static vector Fmod(this vector a, vector b)
        {
            Vml.Fmod(a.Length, a.Array, 0, 1, b.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static vector Remainder(this vector a, vector b)
        {
            Vml.Remainder(a.Length, a.Array, 0, 1, b.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static vector Inv(this vector a)
        {
            Vml.Inv(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static vector Sqrt(this vector a)
        {
            Vml.Sqrt(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static vector InvSqrt(this vector a)
        {
            Vml.InvSqrt(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static vector Cbrt(this vector a)
        {
            Vml.Cbrt(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static vector InvCbrt(this vector a)
        {
            Vml.InvCbrt(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static vector Hypot(this vector a, vector b)
        {
            Vml.Hypot(a.Length, a.Array, 0, 1, b.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static vector Div(this vector a, vector b)
        {
            Vml.Div(a.Length, a.Array, 0, 1, b.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static vector Pow2o3(this vector a)
        {
            Vml.Pow2o3(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static vector Pow3o2(this vector a)
        {
            Vml.Pow3o2(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static vector Pow(this vector a, vector b)
        {
            Vml.Pow(a.Length, a.Array, 0, 1, b.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static vector Powr(this vector a, vector b)
        {
            Vml.Powr(a.Length, a.Array, 0, 1, b.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static vector Exp(this vector a)
        {
            Vml.Exp(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static vector Exp2(this vector a)
        {
            Vml.Exp2(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static vector Exp10(this vector a)
        {
            Vml.Exp10(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static vector Expm1(this vector a)
        {
            Vml.Expm1(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static vector Ln(this vector a)
        {
            Vml.Ln(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static vector Log2(this vector a)
        {
            Vml.Log2(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static vector Log10(this vector a)
        {
            Vml.Log10(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static vector Log1p(this vector a)
        {
            Vml.Log1p(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static vector Logb(this vector a)
        {
            Vml.Logb(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static vector Cos(this vector a)
        {
            Vml.Cos(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static vector Sin(this vector a)
        {
            Vml.Sin(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static vector Tan(this vector a)
        {
            Vml.Tan(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static vector Cospi(this vector a)
        {
            Vml.Cospi(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static vector Sinpi(this vector a)
        {
            Vml.Sinpi(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static vector Tanpi(this vector a)
        {
            Vml.Tanpi(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static vector Cosd(this vector a)
        {
            Vml.Cosd(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static vector Sind(this vector a)
        {
            Vml.Sind(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static vector Tand(this vector a)
        {
            Vml.Tand(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static vector Acos(this vector a)
        {
            Vml.Acos(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static vector Asin(this vector a)
        {
            Vml.Asin(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static vector Atan(this vector a)
        {
            Vml.Atan(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static vector Acospi(this vector a)
        {
            Vml.Acospi(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static vector Asinpi(this vector a)
        {
            Vml.Asinpi(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static vector Atanpi(this vector a)
        {
            Vml.Atanpi(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static vector Atan2(this vector a, vector b)
        {
            Vml.Atan2(a.Length, a.Array, 0, 1, b.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static vector Atan2pi(this vector a, vector b)
        {
            Vml.Atan2pi(a.Length, a.Array, 0, 1, b.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static vector Cosh(this vector a)
        {
            Vml.Cosh(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static vector Sinh(this vector a)
        {
            Vml.Sinh(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static vector Tanh(this vector a)
        {
            Vml.Tanh(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static vector Acosh(this vector a)
        {
            Vml.Acosh(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static vector Asinh(this vector a)
        {
            Vml.Asinh(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static vector Atanh(this vector a)
        {
            Vml.Atanh(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static vector Erf(this vector a)
        {
            Vml.Erf(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static vector Erfc(this vector a)
        {
            Vml.Erfc(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static vector ErfInv(this vector a)
        {
            Vml.ErfInv(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static vector ErfcInv(this vector a)
        {
            Vml.ErfcInv(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static vector CdfNorm(this vector a)
        {
            Vml.CdfNorm(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static vector CdfNormInv(this vector a)
        {
            Vml.CdfNormInv(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static vector LGamma(this vector a)
        {
            Vml.LGamma(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static vector TGamma(this vector a)
        {
            Vml.TGamma(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static vector ExpInt1(this vector a)
        {
            Vml.ExpInt1(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static vector Floor(this vector a)
        {
            Vml.Floor(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static vector Ceil(this vector a)
        {
            Vml.Ceil(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static vector Trunc(this vector a)
        {
            Vml.Trunc(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static vector Round(this vector a)
        {
            Vml.Round(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static vector Frac(this vector a)
        {
            Vml.Frac(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static vector NearbyInt(this vector a)
        {
            Vml.NearbyInt(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static vector Rint(this vector a)
        {
            Vml.Rint(a.Length, a.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static vector CopySign(this vector a, vector b)
        {
            Vml.CopySign(a.Length, a.Array, 0, 1, b.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static vector Fmax(this vector a, vector b)
        {
            Vml.Fmax(a.Length, a.Array, 0, 1, b.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static vector Fmin(this vector a, vector b)
        {
            Vml.Fmin(a.Length, a.Array, 0, 1, b.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static vector Fdim(this vector a, vector b)
        {
            Vml.Fdim(a.Length, a.Array, 0, 1, b.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static vector MaxMag(this vector a, vector b)
        {
            Vml.MaxMag(a.Length, a.Array, 0, 1, b.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static vector NextAfter(this vector a, vector b)
        {
            Vml.NextAfter(a.Length, a.Array, 0, 1, b.Array, 0, 1, a.Array, 0, 1);
            return a;
        }

        public static vector Powx(this vector a, double b)
        {
            Vml.Powx(a.Length, a.Array, 0, 1, b, a.Array, 0, 1);
            return a;
        }

        public static vector LinearFrac(this vector a, vector b, double scalea, double shifta, double scaleb, double shiftb)
        {
            Vml.LinearFrac(a.Length, a.Array, 0, 1, b.Array, 0, 1, scalea, shifta, scaleb, shiftb, a.Array, 0, 1);
            return a;
        }

        public static vector SinCos(vector a)
        {
            var cos = new vector(a.Length);
            Vml.SinCos(a.Length, a.Array, 0, 1, a.Array, 0, 1, cos.Array, 0, 1);
            return cos;
        }

        public static vector Modf(vector a)
        {
            var rem = new vector(a.Length);
            Vml.Modf(a.Length, a.Array, 0, 1, a.Array, 0, 1, rem.Array, 0, 1);
            return rem;
        }

        public static vector Scal(this vector a, double s)
        {
            Blas.scal(a.Length, s, a.Array, 0, 1);
            return a;
        }

        public static vector Copy(this vector a, vector b)
        {
            Blas.copy(b.Length, b.Array, 0, 1, a.Array, 0, 1);
            return a;
        }
    }
}