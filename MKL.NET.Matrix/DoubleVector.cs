// Copyright 2021 Anthony Lloyd
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

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
        public vector(int length)
        {
            Length = length;
            Array = matrix.Pool.Rent(length);
        }
        public vector(int length, Func<int, double> init)
        {
            Length = length;
            var a = matrix.Pool.Rent(length);
            for (int i = 0; i < length; i++)
                a[i] = init(i);
            Array = a;
        }
        public void Dispose()
        {
            matrix.Pool.Return(Array);
            GC.SuppressFinalize(this);
        }
        public double[] ReuseArray()
        {
            GC.SuppressFinalize(this);
            return Array;
        }
        public VectorExpression Reuse() => new VectorReuse(this);
        public void Set(VectorExpression ve)
        {
            if (ve is MatrixVectorMultiply m) new MatrixVectorMultiply(m.M, m.V, Array).Evaluate().ReuseArray();
            else if (ve is VectorAdd va) new VectorAdd(va.A, va.B, Array).Evaluate().ReuseArray();
            else if (ve is VectorSub vs) new VectorSub(vs.A, vs.B, Array).Evaluate().ReuseArray();
            else throw new NotSupportedException();
        }
        ~vector() => matrix.Pool.Return(Array);
        public double this[int i]
        {
            get => Array[i];
            set => Array[i] = value;
        }
        public VectorTExpression T => new VectorTranspose(this);
        public static VectorExpression operator +(vector a, double s) => new VectorAddScalar(a, s);
        public static VectorExpression operator +(double s, vector a) => new VectorAddScalar(a, s);
        public static VectorExpression operator -(vector a, double s) => new VectorAddScalar(a, -s);
        public static VectorExpression operator -(double s, vector a) => s - (VectorExpression)a;
        public static VectorExpression operator +(vector a, vector b) => new VectorAdd(a, b, null);
        public static VectorExpression operator +(vector a, VectorExpression b) => new VectorAdd(a, b, null);
        public static VectorExpression operator +(VectorExpression a, vector b) => new VectorAdd(a, b, null);
        public static VectorExpression operator -(vector a, vector b) => new VectorSub(a, b, null);
        public static VectorExpression operator -(vector a, VectorExpression b) => new VectorSub(a, b, null);
        public static VectorExpression operator -(VectorExpression a, vector b) => new VectorSub(a, b, null);
        public static VectorExpression operator *(vector a, double s) => new VectorScale(a, s);
        public static VectorExpression operator *(double s, vector a) => new VectorScale(a, s);
        public static VectorExpression operator /(vector a, double s) => new VectorScale(a, 1 / s);
        public static double operator *(vectorT vt, vector v) => (VectorTExpression)vt * (VectorExpression)v;
        public static double operator *(VectorTExpression vt, vector v) => vt * (VectorExpression)v;
        public static MatrixExpression operator *(vector v, vectorT vt) => (VectorExpression)v * (VectorTExpression)vt;
        public static MatrixExpression operator *(vector v, VectorTExpression vt) => (VectorExpression)v * vt;
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
        public vectorT(int length)
        {
            Length = length;
            Array = matrix.Pool.Rent(length);
        }
        public vectorT(int length, Func<int, double> init)
        {
            Length = length;
            var a = matrix.Pool.Rent(length);
            for (int i = 0; i < length; i++)
                a[i] = init(i);
            Array = a;
        }
        public void Dispose()
        {
            matrix.Pool.Return(Array);
            GC.SuppressFinalize(this);
        }
        public double[] ReuseArray()
        {
            GC.SuppressFinalize(this);
            return Array;
        }
        public VectorTExpression Reuse() => new VectorTReuse(this);
        ~vectorT() => matrix.Pool.Return(Array);
        public double this[int i]
        {
            get => Array[i];
            set => Array[i] = value;
        }
        public VectorExpression T => new VectorTTranspose(this);
        public static VectorTExpression operator +(vectorT a, double s) => new VectorTAddScalar(a, s);
        public static VectorTExpression operator +(double s, vectorT a) => new VectorTAddScalar(a, s);
        public static VectorTExpression operator -(vectorT a, double s) => new VectorTAddScalar(a, -s);
        public static VectorTExpression operator -(double s, vectorT a) => s - (VectorTExpression)a;
        public static VectorTExpression operator +(vectorT a, vectorT b) => new VectorTAdd(a, b, null);
        public static VectorTExpression operator +(vectorT a, VectorTExpression b) => new VectorTAdd(a, b, null);
        public static VectorTExpression operator +(VectorTExpression a, vectorT b) => new VectorTAdd(a, b, null);
        public static VectorTExpression operator -(vectorT a, vectorT b) => new VectorTSub(a, b, null);
        public static VectorTExpression operator -(vectorT a, VectorTExpression b) => new VectorTSub(a, b, null);
        public static VectorTExpression operator -(VectorTExpression a, vectorT b) => new VectorTSub(a, b, null);
        public static VectorTExpression operator *(vectorT vt, double s) => new VectorTScale(vt, s);
        public static VectorTExpression operator *(double s, vectorT vt) => new VectorTScale(vt, s);
        public static VectorTExpression operator /(vectorT vt, double s) => new VectorTScale(vt, 1 / s);
        public static double operator *(vectorT vt, vector v) => vt * (VectorExpression)v;
        public static double operator *(vectorT vt, VectorExpression v) => (VectorTExpression)vt * v;
        public static MatrixExpression operator *(VectorExpression v, vectorT vt) => v * (VectorTExpression)vt;
        public static MatrixExpression operator *(vector v, vectorT vt) => (VectorExpression)v * vt;
        public static VectorTExpression operator *(vectorT vt, matrix m) => new VectorTMatrixMultiply(vt, m, null);
        public static VectorTExpression operator *(vectorT vt, MatrixExpression m) => new VectorTMatrixMultiply(vt, m, null);
    }

    public static class Vector
    {
        public static VectorExpression Abs(VectorExpression v) => new MatrixToVector(new MatrixAbs(v.ToMatrix()));
        public static VectorTExpression Abs(VectorTExpression v) => new MatrixToVectorT(new MatrixAbs(v.ToMatrix()));
        public static VectorExpression Sqr(VectorExpression v) => new MatrixToVector(new MatrixSqr(v.ToMatrix()));
        public static VectorTExpression Sqr(VectorTExpression v) => new MatrixToVectorT(new MatrixSqr(v.ToMatrix()));
        public static VectorExpression Sqrt(VectorExpression v) => new MatrixToVector(new MatrixSqrt(v.ToMatrix()));
        public static VectorTExpression Sqrt(VectorTExpression v) => new MatrixToVectorT(new MatrixSqrt(v.ToMatrix()));
        public static VectorExpression Inv(VectorExpression v) => new MatrixToVector(new MatrixInv(v.ToMatrix()));
        public static VectorTExpression Inv(VectorTExpression v) => new MatrixToVectorT(new MatrixInv(v.ToMatrix()));
        public static VectorExpression InvSqrt(VectorExpression v) => new MatrixToVector(new MatrixInvSqrt(v.ToMatrix()));
        public static VectorTExpression InvSqrt(VectorTExpression v) => new MatrixToVectorT(new MatrixInvSqrt(v.ToMatrix()));
        public static VectorExpression Cbrt(VectorExpression v) => new MatrixToVector(new MatrixCbrt(v.ToMatrix()));
        public static VectorTExpression Cbrt(VectorTExpression v) => new MatrixToVectorT(new MatrixCbrt(v.ToMatrix()));
        public static VectorExpression InvCbrt(VectorExpression v) => new MatrixToVector(new MatrixInvCbrt(v.ToMatrix()));
        public static VectorTExpression InvCbrt(VectorTExpression v) => new MatrixToVectorT(new MatrixInvCbrt(v.ToMatrix()));
        public static VectorExpression Pow2o3(VectorExpression v) => new MatrixToVector(new MatrixPow2o3(v.ToMatrix()));
        public static VectorTExpression Pow2o3(VectorTExpression v) => new MatrixToVectorT(new MatrixPow2o3(v.ToMatrix()));
        public static VectorExpression Pow3o2(VectorExpression v) => new MatrixToVector(new MatrixPow3o2(v.ToMatrix()));
        public static VectorTExpression Pow3o2(VectorTExpression v) => new MatrixToVectorT(new MatrixPow3o2(v.ToMatrix()));
        public static VectorExpression Exp(VectorExpression v) => new MatrixToVector(new MatrixExp(v.ToMatrix()));
        public static VectorTExpression Exp(VectorTExpression v) => new MatrixToVectorT(new MatrixExp(v.ToMatrix()));
        public static VectorExpression Exp2(VectorExpression v) => new MatrixToVector(new MatrixExp2(v.ToMatrix()));
        public static VectorTExpression Exp2(VectorTExpression v) => new MatrixToVectorT(new MatrixExp2(v.ToMatrix()));
        public static VectorExpression Exp10(VectorExpression v) => new MatrixToVector(new MatrixExp10(v.ToMatrix()));
        public static VectorTExpression Exp10(VectorTExpression v) => new MatrixToVectorT(new MatrixExp10(v.ToMatrix()));
        public static VectorExpression Expm1(VectorExpression v) => new MatrixToVector(new MatrixExpm1(v.ToMatrix()));
        public static VectorTExpression Expm1(VectorTExpression v) => new MatrixToVectorT(new MatrixExpm1(v.ToMatrix()));
        public static VectorExpression Ln(VectorExpression v) => new MatrixToVector(new MatrixLn(v.ToMatrix()));
        public static VectorTExpression Ln(VectorTExpression v) => new MatrixToVectorT(new MatrixLn(v.ToMatrix()));
        public static VectorExpression Log2(VectorExpression v) => new MatrixToVector(new MatrixLog2(v.ToMatrix()));
        public static VectorTExpression Log2(VectorTExpression v) => new MatrixToVectorT(new MatrixLog2(v.ToMatrix()));
        public static VectorExpression Log10(VectorExpression v) => new MatrixToVector(new MatrixLog10(v.ToMatrix()));
        public static VectorTExpression Log10(VectorTExpression v) => new MatrixToVectorT(new MatrixLog10(v.ToMatrix()));
        public static VectorExpression Log1p(VectorExpression v) => new MatrixToVector(new MatrixLog1p(v.ToMatrix()));
        public static VectorTExpression Log1p(VectorTExpression v) => new MatrixToVectorT(new MatrixLog1p(v.ToMatrix()));
        public static VectorExpression Logb(VectorExpression v) => new MatrixToVector(new MatrixLogb(v.ToMatrix()));
        public static VectorTExpression Logb(VectorTExpression v) => new MatrixToVectorT(new MatrixLogb(v.ToMatrix()));
        public static VectorExpression Cos(VectorExpression v) => new MatrixToVector(new MatrixCos(v.ToMatrix()));
        public static VectorTExpression Cos(VectorTExpression v) => new MatrixToVectorT(new MatrixCos(v.ToMatrix()));
        public static VectorExpression Sin(VectorExpression v) => new MatrixToVector(new MatrixSin(v.ToMatrix()));
        public static VectorTExpression Sin(VectorTExpression v) => new MatrixToVectorT(new MatrixSin(v.ToMatrix()));
        public static VectorExpression Tan(VectorExpression v) => new MatrixToVector(new MatrixTan(v.ToMatrix()));
        public static VectorTExpression Tan(VectorTExpression v) => new MatrixToVectorT(new MatrixTan(v.ToMatrix()));
        public static VectorExpression Cospi(VectorExpression v) => new MatrixToVector(new MatrixCospi(v.ToMatrix()));
        public static VectorTExpression Cospi(VectorTExpression v) => new MatrixToVectorT(new MatrixCospi(v.ToMatrix()));
        public static VectorExpression Sinpi(VectorExpression v) => new MatrixToVector(new MatrixSinpi(v.ToMatrix()));
        public static VectorTExpression Sinpi(VectorTExpression v) => new MatrixToVectorT(new MatrixSinpi(v.ToMatrix()));
        public static VectorExpression Tanpi(VectorExpression v) => new MatrixToVector(new MatrixTanpi(v.ToMatrix()));
        public static VectorTExpression Tanpi(VectorTExpression v) => new MatrixToVectorT(new MatrixTanpi(v.ToMatrix()));
        public static VectorExpression Cosd(VectorExpression v) => new MatrixToVector(new MatrixCosd(v.ToMatrix()));
        public static VectorTExpression Cosd(VectorTExpression v) => new MatrixToVectorT(new MatrixCosd(v.ToMatrix()));
        public static VectorExpression Sind(VectorExpression v) => new MatrixToVector(new MatrixSind(v.ToMatrix()));
        public static VectorTExpression Sind(VectorTExpression v) => new MatrixToVectorT(new MatrixSind(v.ToMatrix()));
        public static VectorExpression Tand(VectorExpression v) => new MatrixToVector(new MatrixTand(v.ToMatrix()));
        public static VectorTExpression Tand(VectorTExpression v) => new MatrixToVectorT(new MatrixTand(v.ToMatrix()));
        public static VectorExpression Acos(VectorExpression v) => new MatrixToVector(new MatrixAcos(v.ToMatrix()));
        public static VectorTExpression Acos(VectorTExpression v) => new MatrixToVectorT(new MatrixAcos(v.ToMatrix()));
        public static VectorExpression Asin(VectorExpression v) => new MatrixToVector(new MatrixAsin(v.ToMatrix()));
        public static VectorTExpression Asin(VectorTExpression v) => new MatrixToVectorT(new MatrixAsin(v.ToMatrix()));
        public static VectorExpression Atan(VectorExpression v) => new MatrixToVector(new MatrixAtan(v.ToMatrix()));
        public static VectorTExpression Atan(VectorTExpression v) => new MatrixToVectorT(new MatrixAtan(v.ToMatrix()));
        public static VectorExpression Acospi(VectorExpression v) => new MatrixToVector(new MatrixAcospi(v.ToMatrix()));
        public static VectorTExpression Acospi(VectorTExpression v) => new MatrixToVectorT(new MatrixAcospi(v.ToMatrix()));
        public static VectorExpression Asinpi(VectorExpression v) => new MatrixToVector(new MatrixAsinpi(v.ToMatrix()));
        public static VectorTExpression Asinpi(VectorTExpression v) => new MatrixToVectorT(new MatrixAsinpi(v.ToMatrix()));
        public static VectorExpression Atanpi(VectorExpression v) => new MatrixToVector(new MatrixAtanpi(v.ToMatrix()));
        public static VectorTExpression Atanpi(VectorTExpression v) => new MatrixToVectorT(new MatrixAtanpi(v.ToMatrix()));
        public static VectorExpression Cosh(VectorExpression v) => new MatrixToVector(new MatrixCosh(v.ToMatrix()));
        public static VectorTExpression Cosh(VectorTExpression v) => new MatrixToVectorT(new MatrixCosh(v.ToMatrix()));
        public static VectorExpression Sinh(VectorExpression v) => new MatrixToVector(new MatrixSinh(v.ToMatrix()));
        public static VectorTExpression Sinh(VectorTExpression v) => new MatrixToVectorT(new MatrixSinh(v.ToMatrix()));
        public static VectorExpression Tanh(VectorExpression v) => new MatrixToVector(new MatrixTanh(v.ToMatrix()));
        public static VectorTExpression Tanh(VectorTExpression v) => new MatrixToVectorT(new MatrixTanh(v.ToMatrix()));
        public static VectorExpression Acosh(VectorExpression v) => new MatrixToVector(new MatrixAcosh(v.ToMatrix()));
        public static VectorTExpression Acosh(VectorTExpression v) => new MatrixToVectorT(new MatrixAcosh(v.ToMatrix()));
        public static VectorExpression Asinh(VectorExpression v) => new MatrixToVector(new MatrixAsinh(v.ToMatrix()));
        public static VectorTExpression Asinh(VectorTExpression v) => new MatrixToVectorT(new MatrixAsinh(v.ToMatrix()));
        public static VectorExpression Atanh(VectorExpression v) => new MatrixToVector(new MatrixAtanh(v.ToMatrix()));
        public static VectorTExpression Atanh(VectorTExpression v) => new MatrixToVectorT(new MatrixAtanh(v.ToMatrix()));
        public static VectorExpression Erf(VectorExpression v) => new MatrixToVector(new MatrixErf(v.ToMatrix()));
        public static VectorTExpression Erf(VectorTExpression v) => new MatrixToVectorT(new MatrixErf(v.ToMatrix()));
        public static VectorExpression Erfc(VectorExpression v) => new MatrixToVector(new MatrixErfc(v.ToMatrix()));
        public static VectorTExpression Erfc(VectorTExpression v) => new MatrixToVectorT(new MatrixErfc(v.ToMatrix()));
        public static VectorExpression ErfInv(VectorExpression v) => new MatrixToVector(new MatrixErfInv(v.ToMatrix()));
        public static VectorTExpression ErfInv(VectorTExpression v) => new MatrixToVectorT(new MatrixErfInv(v.ToMatrix()));
        public static VectorExpression ErfcInv(VectorExpression v) => new MatrixToVector(new MatrixErfcInv(v.ToMatrix()));
        public static VectorTExpression ErfcInv(VectorTExpression v) => new MatrixToVectorT(new MatrixErfcInv(v.ToMatrix()));
        public static VectorExpression CdfNorm(VectorExpression v) => new MatrixToVector(new MatrixCdfNorm(v.ToMatrix()));
        public static VectorTExpression CdfNorm(VectorTExpression v) => new MatrixToVectorT(new MatrixCdfNorm(v.ToMatrix()));
        public static VectorExpression CdfNormInv(VectorExpression v) => new MatrixToVector(new MatrixCdfNormInv(v.ToMatrix()));
        public static VectorTExpression CdfNormInv(VectorTExpression v) => new MatrixToVectorT(new MatrixCdfNormInv(v.ToMatrix()));
        public static VectorExpression LGamma(VectorExpression v) => new MatrixToVector(new MatrixLGamma(v.ToMatrix()));
        public static VectorTExpression LGamma(VectorTExpression v) => new MatrixToVectorT(new MatrixLGamma(v.ToMatrix()));
        public static VectorExpression TGamma(VectorExpression v) => new MatrixToVector(new MatrixTGamma(v.ToMatrix()));
        public static VectorTExpression TGamma(VectorTExpression v) => new MatrixToVectorT(new MatrixTGamma(v.ToMatrix()));
        public static VectorExpression ExpInt1(VectorExpression v) => new MatrixToVector(new MatrixExpInt1(v.ToMatrix()));
        public static VectorTExpression ExpInt1(VectorTExpression v) => new MatrixToVectorT(new MatrixExpInt1(v.ToMatrix()));
        public static VectorExpression Floor(VectorExpression v) => new MatrixToVector(new MatrixFloor(v.ToMatrix()));
        public static VectorTExpression Floor(VectorTExpression v) => new MatrixToVectorT(new MatrixFloor(v.ToMatrix()));
        public static VectorExpression Ceil(VectorExpression v) => new MatrixToVector(new MatrixCeil(v.ToMatrix()));
        public static VectorTExpression Ceil(VectorTExpression v) => new MatrixToVectorT(new MatrixCeil(v.ToMatrix()));
        public static VectorExpression Truncate(VectorExpression v) => new MatrixToVector(new MatrixTrunc(v.ToMatrix()));
        public static VectorTExpression Truncate(VectorTExpression v) => new MatrixToVectorT(new MatrixTrunc(v.ToMatrix()));
        public static VectorExpression Round(VectorExpression v) => new MatrixToVector(new MatrixNearbyInt(v.ToMatrix()));
        public static VectorTExpression Round(VectorTExpression v) => new MatrixToVectorT(new MatrixNearbyInt(v.ToMatrix()));
        public static VectorExpression RoundAwayFromZero(VectorExpression v) => new MatrixToVector(new MatrixRound(v.ToMatrix()));
        public static VectorTExpression RoundAwayFromZero(VectorTExpression v) => new MatrixToVectorT(new MatrixRound(v.ToMatrix()));
        public static VectorExpression Frac(VectorExpression v) => new MatrixToVector(new MatrixFrac(v.ToMatrix()));
        public static VectorTExpression Frac(VectorTExpression v) => new MatrixToVectorT(new MatrixFrac(v.ToMatrix()));
        public static VectorExpression NearbyInt(VectorExpression v) => new MatrixToVector(new MatrixNearbyInt(v.ToMatrix()));
        public static VectorTExpression NearbyInt(VectorTExpression v) => new MatrixToVectorT(new MatrixNearbyInt(v.ToMatrix()));
        public static VectorExpression Rint(VectorExpression v) => new MatrixToVector(new MatrixRint(v.ToMatrix()));
        public static VectorTExpression Rint(VectorTExpression v) => new MatrixToVectorT(new MatrixRint(v.ToMatrix()));
        public static VectorExpression Powx(VectorExpression v, double b) => new MatrixToVector(new MatrixPowx(v.ToMatrix(), b));
        public static VectorTExpression Powx(VectorTExpression v, double b) => new MatrixToVectorT(new MatrixPowx(v.ToMatrix(), b));
        public static VectorExpression CopySign(VectorExpression a, VectorExpression b) => new MatrixToVector(new MatrixCopySign(a.ToMatrix(), b.ToMatrix()));
        public static VectorTExpression CopySign(VectorTExpression a, VectorExpression b) => new MatrixToVectorT(new MatrixCopySign(a.ToMatrix(), b.ToMatrix()));
        public static VectorExpression Max(VectorExpression a, VectorExpression b) => new MatrixToVector(new MatrixFmax(a.ToMatrix(), b.ToMatrix()));
        public static VectorExpression Max(VectorExpression a, double b) => new MatrixToVector(new MatrixMaxScalar(a.ToMatrix(), b));
        public static VectorTExpression Max(VectorTExpression a, VectorExpression b) => new MatrixToVectorT(new MatrixFmax(a.ToMatrix(), b.ToMatrix()));
        public static VectorExpression Min(VectorExpression a, VectorExpression b) => new MatrixToVector(new MatrixFmin(a.ToMatrix(), b.ToMatrix()));
        public static VectorExpression Min(VectorExpression a, double b) => new MatrixToVector(new MatrixMinScalar(a.ToMatrix(), b));
        public static VectorTExpression Min(VectorTExpression a, VectorExpression b) => new MatrixToVectorT(new MatrixFmin(a.ToMatrix(), b.ToMatrix()));
        public static VectorExpression Fdim(VectorExpression a, VectorExpression b) => new MatrixToVector(new MatrixFdim(a.ToMatrix(), b.ToMatrix()));
        public static VectorTExpression Fdim(VectorTExpression a, VectorExpression b) => new MatrixToVectorT(new MatrixFdim(a.ToMatrix(), b.ToMatrix()));
        public static VectorExpression MaxMag(VectorExpression a, VectorExpression b) => new MatrixToVector(new MatrixMaxMag(a.ToMatrix(), b.ToMatrix()));
        public static VectorTExpression MaxMag(VectorTExpression a, VectorExpression b) => new MatrixToVectorT(new MatrixMaxMag(a.ToMatrix(), b.ToMatrix()));
        public static VectorExpression NextAfter(VectorExpression a, VectorExpression b) => new MatrixToVector(new MatrixNextAfter(a.ToMatrix(), b.ToMatrix()));
        public static VectorTExpression NextAfter(VectorTExpression a, VectorTExpression b) => new MatrixToVectorT(new MatrixNextAfter(a.ToMatrix(), b.ToMatrix()));
        public static VectorExpression Mul(VectorExpression a, VectorExpression b) => new MatrixToVector(new MatrixMul(a.ToMatrix(), b.ToMatrix()));
        public static VectorTExpression Mul(VectorTExpression a, VectorTExpression b) => new MatrixToVectorT(new MatrixMul(a.ToMatrix(), b.ToMatrix()));
        public static VectorExpression Fmod(VectorExpression a, VectorExpression b) => new MatrixToVector(new MatrixFmod(a.ToMatrix(), b.ToMatrix()));
        public static VectorTExpression Fmod(VectorTExpression a, VectorTExpression b) => new MatrixToVectorT(new MatrixFmod(a.ToMatrix(), b.ToMatrix()));
        public static VectorExpression Atan2(VectorExpression a, VectorExpression b) => new MatrixToVector(new MatrixAtan2(a.ToMatrix(), b.ToMatrix()));
        public static VectorTExpression Atan2(VectorTExpression a, VectorTExpression b) => new MatrixToVectorT(new MatrixAtan2(a.ToMatrix(), b.ToMatrix()));
        public static VectorExpression Atan2pi(VectorExpression a, VectorExpression b) => new MatrixToVector(new MatrixAtan2pi(a.ToMatrix(), b.ToMatrix()));
        public static VectorTExpression Atan2pi(VectorTExpression a, VectorTExpression b) => new MatrixToVectorT(new MatrixAtan2pi(a.ToMatrix(), b.ToMatrix()));
        public static VectorExpression Powr(VectorExpression a, VectorExpression b) => new MatrixToVector(new MatrixPowr(a.ToMatrix(), b.ToMatrix()));
        public static VectorTExpression Powr(VectorTExpression a, VectorExpression b) => new MatrixToVectorT(new MatrixPowr(a.ToMatrix(), b.ToMatrix()));
        public static VectorExpression Remainder(VectorExpression a, VectorExpression b) => new MatrixToVector(new MatrixRemainder(a.ToMatrix(), b.ToMatrix()));
        public static VectorTExpression Remainder(VectorTExpression a, VectorTExpression b) => new MatrixToVectorT(new MatrixRemainder(a.ToMatrix(), b.ToMatrix()));
        public static VectorExpression Hypot(VectorExpression a, VectorExpression b) => new MatrixToVector(new MatrixHypot(a.ToMatrix(), b.ToMatrix()));
        public static VectorTExpression Hypot(VectorTExpression a, VectorTExpression b) => new MatrixToVectorT(new MatrixHypot(a.ToMatrix(), b.ToMatrix()));
        public static VectorExpression Div(VectorExpression a, VectorExpression b) => new MatrixToVector(new MatrixDiv(a.ToMatrix(), b.ToMatrix()));
        public static VectorTExpression Div(VectorTExpression a, VectorTExpression b) => new MatrixToVectorT(new MatrixDiv(a.ToMatrix(), b.ToMatrix()));
        public static VectorExpression Pow(VectorExpression a, VectorExpression b) => new MatrixToVector(new MatrixPow(a.ToMatrix(), b.ToMatrix()));
        public static VectorTExpression Pow(VectorTExpression a, VectorTExpression b) => new MatrixToVectorT(new MatrixPow(a.ToMatrix(), b.ToMatrix()));
        public static VectorExpression LinearFrac(VectorExpression a, VectorExpression b, double scalea, double shifta, double scaleb, double shiftb)
            => new MatrixToVector(new MatrixLinearFrac(a.ToMatrix(), b.ToMatrix(), scalea, shifta, scaleb, shiftb));
        public static VectorTExpression LinearFrac(VectorTExpression a, VectorTExpression b, double scalea, double shifta, double scaleb, double shiftb)
            => new MatrixToVectorT(new MatrixLinearFrac(a.ToMatrix(), b.ToMatrix(), scalea, shifta, scaleb, shiftb));
        public static double Asum(VectorExpression a) => Matrix.Asum(a.ToMatrix());
        public static double Asum(VectorTExpression a) => Matrix.Asum(a.ToMatrix());
        public static double Nrm2(VectorExpression a) => Matrix.Nrm2(a.ToMatrix());
        public static double Nrm2(VectorTExpression a) => Matrix.Nrm2(a.ToMatrix());

        public static int Iamax(VectorExpression a)
        {
            var v = a.Evaluate();
            int r = Blas.iamax(v.Length, v.Array, 0, 1);
            if (a is not VectorInput) v.Dispose();
            return r;
        }

        public static int Iamax(VectorTExpression a)
        {
            var v = a.Evaluate();
            int r = Blas.iamax(v.Length, v.Array, 0, 1);
            if (a is not VectorTInput) v.Dispose();
            return r;
        }

        public static int Iamin(VectorExpression a)
        {
            var vt = a.Evaluate();
            int r = Blas.iamin(vt.Length, vt.Array, 0, 1);
            if (a is not VectorInput) vt.Dispose();
            return r;
        }

        public static int Iamin(VectorTExpression a)
        {
            var vt = a.Evaluate();
            int r = Blas.iamin(vt.Length, vt.Array, 0, 1);
            if (a is not VectorTInput) vt.Dispose();
            return r;
        }

        public static vector Copy(vector v)
        {
            var r = new vector(v.Length);
            Blas.copy(v.Length, v.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static void Copy(vector a, vector b)
        {
            Blas.copy(a.Length, a.Array, 0, 1, b.Array, 0, 1);
        }

        public static vectorT Copy(vectorT v)
        {
            var r = new vectorT(v.Length);
            Blas.copy(v.Length, v.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static void Copy(vectorT a, vectorT b)
        {
            Blas.copy(a.Length, a.Array, 0, 1, b.Array, 0, 1);
        }

        public static (vector, vector) SinCos(VectorExpression a)
        {
            var sin = a.Evaluate();
            if (a is VectorInput) sin = Copy(sin);
            var cos = new vector(sin.Length);
            Vml.SinCos(sin.Length, sin.Array, sin.Array, cos.Array);
            return (sin, cos);
        }

        public static (vectorT, vectorT) SinCos(VectorTExpression a)
        {
            var sin = a.Evaluate();
            if (a is VectorTInput) sin = Copy(sin);
            var cos = new vectorT(sin.Length);
            Vml.SinCos(sin.Length, sin.Array, sin.Array, cos.Array);
            return (sin, cos);
        }

        public static (vector, vector) Modf(VectorExpression a)
        {
            var tru = a.Evaluate();
            if (a is VectorInput) tru = Copy(tru);
            var rem = new vector(tru.Length);
            Vml.Modf(tru.Length, tru.Array, tru.Array, rem.Array);
            return (tru, rem);
        }

        public static (vectorT, vectorT) Modf(VectorTExpression a)
        {
            var tru = a.Evaluate();
            if (a is VectorTInput) tru = Copy(tru);
            var rem = new vectorT(tru.Length);
            Vml.Modf(tru.Length, tru.Array, tru.Array, rem.Array);
            return (tru, rem);
        }
    }
}