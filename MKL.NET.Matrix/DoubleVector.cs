using System;
using MKLNET.Expression;

namespace MKLNET
{
    public class vector : IDisposable
    {
        public int Length;
        public double[] Array;
        public vector(int length, double[] reuse)
        {
            Length = length;
            Array = reuse;
        }
        public vector(int length) : this(length, matrix.Pool.Rent(length)) { }
        public void Dispose()
        {
            matrix.Pool.Return(Array);
            GC.SuppressFinalize(this);
        }
        public double[] Reuse()
        {
            GC.SuppressFinalize(this);
            return Array;
        }
        ~vector() => matrix.Pool.Return(Array);
        public double this[int i]
        {
            get => Array[i];
            set => Array[i] = value;
        }
        public VectorTranspose T => new(this);
        public static VectorAddScalar operator +(vector m, double s) => new(m, s);
        public static VectorAddScalar operator +(double s, vector m) => new(m, s);
        public static VectorAddScalar operator -(vector m, double s) => new(m, -s);
        public static VectorScalarSub operator -(double s, vector m) => new(m, s);
        public static VectorAdd operator +(vector a, vector b) => new(a, b);
        public static VectorSub operator -(vector a, vector b) => new(a, b);
        public static MatrixMultiply operator *(vector v, VectorTExpression vt) => new(new InputVectorToMatrix(v), vt.ToMatrix());
    }
    public class vectorT : IDisposable
    {
        public int Length;
        public double[] Array;
        public vectorT(int length, double[] reuse)
        {
            Length = length;
            Array = reuse;
        }
        public vectorT(int length) : this(length, matrix.Pool.Rent(length)) { }
        public void Dispose()
        {
            matrix.Pool.Return(Array);
            GC.SuppressFinalize(this);
        }
        public double[] Reuse()
        {
            GC.SuppressFinalize(this);
            return Array;
        }
        ~vectorT() => matrix.Pool.Return(Array);
        public double this[int i]
        {
            get => Array[i];
            set => Array[i] = value;
        }
        public VectorTTranspose T => new(this);
        public static VectorTAddScalar operator +(vectorT m, double s) => new(m, s);
        public static VectorTAddScalar operator +(double s, vectorT m) => new(m, s);
        public static VectorTAddScalar operator -(vectorT m, double s) => new(m, -s);
        public static VectorTScalarSub operator -(double s, vectorT m) => new(m, s);
        public static VectorTAdd operator +(vectorT a, vectorT b) => new(a, b);
        public static VectorTSub operator -(vectorT a, vectorT b) => new(a, b);
        public static double operator *(vectorT vt, VectorExpression v)
        {
            var m = new MatrixMultiply(new InputVectorTToMatrix(vt), v.ToMatrix()).EvaluateMatrix();
            var r = m[0, 0];
            m.Dispose();
            return r;
        }
        public static MatrixMultiply operator *(VectorExpression v, vectorT vt) => new(v.ToMatrix(), new InputVectorTToMatrix(vt));
        public static VectorTMatrixMultiply operator *(vectorT vt, MatrixExpression m) => new(vt, m);
    }

    public static class Vector
    {
        public static MatrixToVector Abs(VectorExpression v) => new(new MatrixAbs(v.ToMatrix()));
        public static MatrixToVectorT Abs(VectorTExpression v) => new(new MatrixAbs(v.ToMatrix()));


        public static MatrixToVector Sqr(VectorExpression v) => new(new MatrixSqr(v.ToMatrix()));
        public static MatrixToVectorT Sqr(VectorTExpression v) => new(new MatrixSqr(v.ToMatrix()));
        public static MatrixToVector Inv(VectorExpression v) => new(new MatrixInv(v.ToMatrix()));
        public static MatrixToVectorT Inv(VectorTExpression v) => new(new MatrixInv(v.ToMatrix()));
        public static MatrixToVector InvSqrt(VectorExpression v) => new(new MatrixInvSqrt(v.ToMatrix()));
        public static MatrixToVectorT InvSqrt(VectorTExpression v) => new(new MatrixInvSqrt(v.ToMatrix()));
        public static MatrixToVector Cbrt(VectorExpression v) => new(new MatrixCbrt(v.ToMatrix()));
        public static MatrixToVectorT Cbrt(VectorTExpression v) => new(new MatrixCbrt(v.ToMatrix()));
        public static MatrixToVector InvCbrt(VectorExpression v) => new(new MatrixInvCbrt(v.ToMatrix()));
        public static MatrixToVectorT InvCbrt(VectorTExpression v) => new(new MatrixInvCbrt(v.ToMatrix()));
        public static MatrixToVector Pow2o3(VectorExpression v) => new(new MatrixPow2o3(v.ToMatrix()));
        public static MatrixToVectorT Pow2o3(VectorTExpression v) => new(new MatrixPow2o3(v.ToMatrix()));
        public static MatrixToVector Pow3o2(VectorExpression v) => new(new MatrixPow3o2(v.ToMatrix()));
        public static MatrixToVectorT Pow3o2(VectorTExpression v) => new(new MatrixPow3o2(v.ToMatrix()));
        public static MatrixToVector Exp(VectorExpression v) => new(new MatrixExp(v.ToMatrix()));
        public static MatrixToVectorT Exp(VectorTExpression v) => new(new MatrixExp(v.ToMatrix()));
        public static MatrixToVector Exp2(VectorExpression v) => new(new MatrixExp2(v.ToMatrix()));
        public static MatrixToVectorT Exp2(VectorTExpression v) => new(new MatrixExp2(v.ToMatrix()));
        public static MatrixToVector Exp10(VectorExpression v) => new(new MatrixExp10(v.ToMatrix()));
        public static MatrixToVectorT Exp10(VectorTExpression v) => new(new MatrixExp10(v.ToMatrix()));
        public static MatrixToVector Expm1(VectorExpression v) => new(new MatrixExpm1(v.ToMatrix()));
        public static MatrixToVectorT Expm1(VectorTExpression v) => new(new MatrixExpm1(v.ToMatrix()));
        public static MatrixToVector Ln(VectorExpression v) => new(new MatrixLn(v.ToMatrix()));
        public static MatrixToVectorT Ln(VectorTExpression v) => new(new MatrixLn(v.ToMatrix()));
        public static MatrixToVector Log2(VectorExpression v) => new(new MatrixLog2(v.ToMatrix()));
        public static MatrixToVectorT Log2(VectorTExpression v) => new(new MatrixLog2(v.ToMatrix()));
        public static MatrixToVector Log10(VectorExpression v) => new(new MatrixLog10(v.ToMatrix()));
        public static MatrixToVectorT Log10(VectorTExpression v) => new(new MatrixLog10(v.ToMatrix()));
        public static MatrixToVector Log1p(VectorExpression v) => new(new MatrixLog1p(v.ToMatrix()));
        public static MatrixToVectorT Log1p(VectorTExpression v) => new(new MatrixLog1p(v.ToMatrix()));
        public static MatrixToVector Logb(VectorExpression v) => new(new MatrixLogb(v.ToMatrix()));
        public static MatrixToVectorT Logb(VectorTExpression v) => new(new MatrixLogb(v.ToMatrix()));
        public static MatrixToVector Cos(VectorExpression v) => new(new MatrixCos(v.ToMatrix()));
        public static MatrixToVectorT Cos(VectorTExpression v) => new(new MatrixCos(v.ToMatrix()));
        public static MatrixToVector Sin(VectorExpression v) => new(new MatrixSin(v.ToMatrix()));
        public static MatrixToVectorT Sin(VectorTExpression v) => new(new MatrixSin(v.ToMatrix()));
        public static MatrixToVector Tan(VectorExpression v) => new(new MatrixTan(v.ToMatrix()));
        public static MatrixToVectorT Tan(VectorTExpression v) => new(new MatrixTan(v.ToMatrix()));
        public static MatrixToVector Cospi(VectorExpression v) => new(new MatrixCospi(v.ToMatrix()));
        public static MatrixToVectorT Cospi(VectorTExpression v) => new(new MatrixCospi(v.ToMatrix()));
        public static MatrixToVector Sinpi(VectorExpression v) => new(new MatrixSinpi(v.ToMatrix()));
        public static MatrixToVectorT Sinpi(VectorTExpression v) => new(new MatrixSinpi(v.ToMatrix()));
        public static MatrixToVector Tanpi(VectorExpression v) => new(new MatrixTanpi(v.ToMatrix()));
        public static MatrixToVectorT Tanpi(VectorTExpression v) => new(new MatrixTanpi(v.ToMatrix()));
        public static MatrixToVector Cosd(VectorExpression v) => new(new MatrixCosd(v.ToMatrix()));
        public static MatrixToVectorT Cosd(VectorTExpression v) => new(new MatrixCosd(v.ToMatrix()));
        public static MatrixToVector Sind(VectorExpression v) => new(new MatrixSind(v.ToMatrix()));
        public static MatrixToVectorT Sind(VectorTExpression v) => new(new MatrixSind(v.ToMatrix()));
        public static MatrixToVector Tand(VectorExpression v) => new(new MatrixTand(v.ToMatrix()));
        public static MatrixToVectorT Tand(VectorTExpression v) => new(new MatrixTand(v.ToMatrix()));
        public static MatrixToVector Acos(VectorExpression v) => new(new MatrixAcos(v.ToMatrix()));
        public static MatrixToVectorT Acos(VectorTExpression v) => new(new MatrixAcos(v.ToMatrix()));
        public static MatrixToVector Asin(VectorExpression v) => new(new MatrixAsin(v.ToMatrix()));
        public static MatrixToVectorT Asin(VectorTExpression v) => new(new MatrixAsin(v.ToMatrix()));
        public static MatrixToVector Atan(VectorExpression v) => new(new MatrixAtan(v.ToMatrix()));
        public static MatrixToVectorT Atan(VectorTExpression v) => new(new MatrixAtan(v.ToMatrix()));
        public static MatrixToVector Acospi(VectorExpression v) => new(new MatrixAcospi(v.ToMatrix()));
        public static MatrixToVectorT Acospi(VectorTExpression v) => new(new MatrixAcospi(v.ToMatrix()));
        public static MatrixToVector Asinpi(VectorExpression v) => new(new MatrixAsinpi(v.ToMatrix()));
        public static MatrixToVectorT Asinpi(VectorTExpression v) => new(new MatrixAsinpi(v.ToMatrix()));
        public static MatrixToVector Atanpi(VectorExpression v) => new(new MatrixAtanpi(v.ToMatrix()));
        public static MatrixToVectorT Atanpi(VectorTExpression v) => new(new MatrixAtanpi(v.ToMatrix()));
        public static MatrixToVector Cosh(VectorExpression v) => new(new MatrixCosh(v.ToMatrix()));
        public static MatrixToVectorT Cosh(VectorTExpression v) => new(new MatrixCosh(v.ToMatrix()));
        public static MatrixToVector Sinh(VectorExpression v) => new(new MatrixSinh(v.ToMatrix()));
        public static MatrixToVectorT Sinh(VectorTExpression v) => new(new MatrixSinh(v.ToMatrix()));
        public static MatrixToVector Tanh(VectorExpression v) => new(new MatrixTanh(v.ToMatrix()));
        public static MatrixToVectorT Tanh(VectorTExpression v) => new(new MatrixTanh(v.ToMatrix()));
        public static MatrixToVector Acosh(VectorExpression v) => new(new MatrixAcosh(v.ToMatrix()));
        public static MatrixToVectorT Acosh(VectorTExpression v) => new(new MatrixAcosh(v.ToMatrix()));
        public static MatrixToVector Asinh(VectorExpression v) => new(new MatrixAsinh(v.ToMatrix()));
        public static MatrixToVectorT Asinh(VectorTExpression v) => new(new MatrixAsinh(v.ToMatrix()));
        public static MatrixToVector Atanh(VectorExpression v) => new(new MatrixAtanh(v.ToMatrix()));
        public static MatrixToVectorT Atanh(VectorTExpression v) => new(new MatrixAtanh(v.ToMatrix()));
        public static MatrixToVector Erf(VectorExpression v) => new(new MatrixErf(v.ToMatrix()));
        public static MatrixToVectorT Erf(VectorTExpression v) => new(new MatrixErf(v.ToMatrix()));
        public static MatrixToVector Erfc(VectorExpression v) => new(new MatrixErfc(v.ToMatrix()));
        public static MatrixToVectorT Erfc(VectorTExpression v) => new(new MatrixErfc(v.ToMatrix()));
        public static MatrixToVector ErfInv(VectorExpression v) => new(new MatrixErfInv(v.ToMatrix()));
        public static MatrixToVectorT ErfInv(VectorTExpression v) => new(new MatrixErfInv(v.ToMatrix()));
        public static MatrixToVector ErfcInv(VectorExpression v) => new(new MatrixErfcInv(v.ToMatrix()));
        public static MatrixToVectorT ErfcInv(VectorTExpression v) => new(new MatrixErfcInv(v.ToMatrix()));
        public static MatrixToVector CdfNorm(VectorExpression v) => new(new MatrixCdfNorm(v.ToMatrix()));
        public static MatrixToVectorT CdfNorm(VectorTExpression v) => new(new MatrixCdfNorm(v.ToMatrix()));
        public static MatrixToVector CdfNormInv(VectorExpression v) => new(new MatrixCdfNormInv(v.ToMatrix()));
        public static MatrixToVectorT CdfNormInv(VectorTExpression v) => new(new MatrixCdfNormInv(v.ToMatrix()));
        public static MatrixToVector LGamma(VectorExpression v) => new(new MatrixLGamma(v.ToMatrix()));
        public static MatrixToVectorT LGamma(VectorTExpression v) => new(new MatrixLGamma(v.ToMatrix()));
        public static MatrixToVector TGamma(VectorExpression v) => new(new MatrixTGamma(v.ToMatrix()));
        public static MatrixToVectorT TGamma(VectorTExpression v) => new(new MatrixTGamma(v.ToMatrix()));
        public static MatrixToVector ExpInt1(VectorExpression v) => new(new MatrixExpInt1(v.ToMatrix()));
        public static MatrixToVectorT ExpInt1(VectorTExpression v) => new(new MatrixExpInt1(v.ToMatrix()));
        public static MatrixToVector Floor(VectorExpression v) => new(new MatrixFloor(v.ToMatrix()));
        public static MatrixToVectorT Floor(VectorTExpression v) => new(new MatrixFloor(v.ToMatrix()));
        public static MatrixToVector Ceil(VectorExpression v) => new(new MatrixCeil(v.ToMatrix()));
        public static MatrixToVectorT Ceil(VectorTExpression v) => new(new MatrixCeil(v.ToMatrix()));
        public static MatrixToVector Trunc(VectorExpression v) => new(new MatrixTrunc(v.ToMatrix()));
        public static MatrixToVectorT Trunc(VectorTExpression v) => new(new MatrixTrunc(v.ToMatrix()));
        public static MatrixToVector Round(VectorExpression v) => new(new MatrixRound(v.ToMatrix()));
        public static MatrixToVectorT Round(VectorTExpression v) => new(new MatrixRound(v.ToMatrix()));
        public static MatrixToVector Frac(VectorExpression v) => new(new MatrixFrac(v.ToMatrix()));
        public static MatrixToVectorT Frac(VectorTExpression v) => new(new MatrixFrac(v.ToMatrix()));
        public static MatrixToVector NearbyInt(VectorExpression v) => new(new MatrixNearbyInt(v.ToMatrix()));
        public static MatrixToVectorT NearbyInt(VectorTExpression v) => new(new MatrixNearbyInt(v.ToMatrix()));
        public static MatrixToVector Rint(VectorExpression v) => new(new MatrixRint(v.ToMatrix()));
        public static MatrixToVectorT Rint(VectorTExpression v) => new(new MatrixRint(v.ToMatrix()));
        public static MatrixToVector Powx(VectorExpression v, double b) => new(new MatrixPowx(v.ToMatrix(), b));
        public static MatrixToVectorT Powx(VectorTExpression v, double b) => new(new MatrixPowx(v.ToMatrix(), b));
        public static MatrixToVector CopySign(VectorExpression a, VectorExpression b) => new(new MatrixCopySign(a.ToMatrix(), b.ToMatrix()));
        public static MatrixToVectorT CopySign(VectorTExpression a, VectorExpression b) => new(new MatrixCopySign(a.ToMatrix(), b.ToMatrix()));
        public static MatrixToVector Fmax(VectorExpression a, VectorExpression b) => new(new MatrixFmax(a.ToMatrix(), b.ToMatrix()));
        public static MatrixToVectorT Fmax(VectorTExpression a, VectorExpression b) => new(new MatrixFmax(a.ToMatrix(), b.ToMatrix()));
        public static MatrixToVector Fmin(VectorExpression a, VectorExpression b) => new(new MatrixFmin(a.ToMatrix(), b.ToMatrix()));
        public static MatrixToVectorT Fmin(VectorTExpression a, VectorExpression b) => new(new MatrixFmin(a.ToMatrix(), b.ToMatrix()));
        public static MatrixToVector Fdim(VectorExpression a, VectorExpression b) => new(new MatrixFdim(a.ToMatrix(), b.ToMatrix()));
        public static MatrixToVectorT Fdim(VectorTExpression a, VectorExpression b) => new(new MatrixFdim(a.ToMatrix(), b.ToMatrix()));
        public static MatrixToVector MaxMag(VectorExpression a, VectorExpression b) => new(new MatrixMaxMag(a.ToMatrix(), b.ToMatrix()));
        public static MatrixToVectorT MaxMag(VectorTExpression a, VectorExpression b) => new(new MatrixMaxMag(a.ToMatrix(), b.ToMatrix()));
        public static MatrixToVector NextAfter(VectorExpression a, VectorExpression b) => new(new MatrixNextAfter(a.ToMatrix(), b.ToMatrix()));
        public static MatrixToVectorT NextAfter(VectorTExpression a, VectorTExpression b) => new(new MatrixNextAfter(a.ToMatrix(), b.ToMatrix()));
        public static MatrixToVector Dot(VectorExpression a, VectorExpression b) => new(new MatrixDot(a.ToMatrix(), b.ToMatrix()));
        public static MatrixToVectorT Dot(VectorTExpression a, VectorTExpression b) => new(new MatrixDot(a.ToMatrix(), b.ToMatrix()));
        public static MatrixToVector Fmod(VectorExpression a, VectorExpression b) => new(new MatrixFmod(a.ToMatrix(), b.ToMatrix()));
        public static MatrixToVectorT Fmod(VectorTExpression a, VectorTExpression b) => new(new MatrixFmod(a.ToMatrix(), b.ToMatrix()));
        public static MatrixToVector Atan2(VectorExpression a, VectorExpression b) => new(new MatrixAtan2(a.ToMatrix(), b.ToMatrix()));
        public static MatrixToVectorT Atan2(VectorTExpression a, VectorTExpression b) => new(new MatrixAtan2(a.ToMatrix(), b.ToMatrix()));
        public static MatrixToVector Atan2pi(VectorExpression a, VectorExpression b) => new(new MatrixAtan2pi(a.ToMatrix(), b.ToMatrix()));
        public static MatrixToVectorT Atan2pi(VectorTExpression a, VectorTExpression b) => new(new MatrixAtan2pi(a.ToMatrix(), b.ToMatrix()));
        public static MatrixToVector Powr(VectorExpression a, VectorExpression b) => new(new MatrixPowr(a.ToMatrix(), b.ToMatrix()));
        public static MatrixToVectorT Powr(VectorTExpression a, VectorExpression b) => new(new MatrixPowr(a.ToMatrix(), b.ToMatrix()));
        public static MatrixToVector Remainder(VectorExpression a, VectorExpression b) => new(new MatrixRemainder(a.ToMatrix(), b.ToMatrix()));
        public static MatrixToVectorT Remainder(VectorTExpression a, VectorTExpression b) => new(new MatrixRemainder(a.ToMatrix(), b.ToMatrix()));
        public static MatrixToVector Hypot(VectorExpression a, VectorExpression b) => new(new MatrixHypot(a.ToMatrix(), b.ToMatrix()));
        public static MatrixToVectorT Hypot(VectorTExpression a, VectorTExpression b) => new(new MatrixHypot(a.ToMatrix(), b.ToMatrix()));
        public static MatrixToVector Div(VectorExpression a, VectorExpression b) => new(new MatrixDiv(a.ToMatrix(), b.ToMatrix()));
        public static MatrixToVectorT Div(VectorTExpression a, VectorTExpression b) => new(new MatrixDiv(a.ToMatrix(), b.ToMatrix()));
        public static MatrixToVector Pow(VectorExpression a, VectorExpression b) => new(new MatrixPow(a.ToMatrix(), b.ToMatrix()));
        public static MatrixToVectorT Pow(VectorTExpression a, VectorTExpression b) => new(new MatrixPow(a.ToMatrix(), b.ToMatrix()));
        public static MatrixToVector LinearFrac(VectorExpression a, VectorExpression b, double scalea, double shifta, double scaleb, double shiftb)
            => new(new MatrixLinearFrac(a.ToMatrix(), b.ToMatrix(), scalea, shifta, scaleb, shiftb));
        public static MatrixToVectorT LinearFrac(VectorTExpression a, VectorTExpression b, double scalea, double shifta, double scaleb, double shiftb)
            => new(new MatrixLinearFrac(a.ToMatrix(), b.ToMatrix(), scalea, shifta, scaleb, shiftb));
        public static double Asum(VectorExpression a) => Matrix.Asum(a.ToMatrix());
        public static double Asum(VectorTExpression a) => Matrix.Asum(a.ToMatrix());
        public static double Nrm2(VectorExpression a) => Matrix.Nrm2(a.ToMatrix());
        public static double Nrm2(VectorTExpression a) => Matrix.Nrm2(a.ToMatrix());
        public static int Iamax(VectorExpression a)
        {
            var i = a.EvaluateVector();
            int r = Blas.iamax(i.Length, i.Array, 0, 1);
            if (a is not Input) i.Dispose();
            return r;
        }
        public static int Iamax(VectorTExpression a) => Iamax(a);
        public static int Iamin(VectorExpression a)
        {
            var i = a.EvaluateVector();
            int r = Blas.iamin(i.Length, i.Array, 0, 1);
            if (a is not Input) i.Dispose();
            return r;
        }
        public static int Iamin(VectorTExpression a) => Iamin(a);
        public static (vector, vector) SinCos(VectorExpression a)
        {
            var i = a.EvaluateVector();
            var sin = a is Input ? new vector(i.Length) : i;
            var cos = new vector(i.Length);
            Vml.SinCos(i.Length, i.Array, 0, 1, sin.Array, 0, 1, cos.Array, 0, 1);
            return (sin, cos);
        }
        public static (vectorT, vectorT) SinCos(VectorTExpression a)
        {
            var i = a.EvaluateVector();
            var sin = a is Input ? new vectorT(i.Length) : i;
            var cos = new vectorT(i.Length);
            Vml.SinCos(i.Length, i.Array, 0, 1, sin.Array, 0, 1, cos.Array, 0, 1);
            return (sin, cos);
        }
        public static (vectorT, vectorT) Modf(VectorTExpression a)
        {
            var i = a.EvaluateVector();
            var tru = a is Input ? new vectorT(i.Length) : i;
            var rem = new vectorT(i.Length);
            Vml.Modf(i.Length, i.Array, 0, 1, tru.Array, 0, 1, rem.Array, 0, 1);
            return (tru, rem);
        }
        public static matrix CopyToMatrix(vector v)
        {
            var r = new matrix(1, v.Length);
            Blas.copy(v.Length, v.Array, 0, 1, r.Array, 0, 1);
            return r;
        }
        public static matrix CopyToMatrix(vectorT v)
        {
            var r = new matrix(1, v.Length);
            Blas.copy(v.Length, v.Array, 0, 1, r.Array, 0, 1);
            return r;
        }
    }
}