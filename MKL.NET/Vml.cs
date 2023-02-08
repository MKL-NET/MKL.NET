// Copyright 2023 Anthony Lloyd
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

namespace MKLNET;

using System.Security;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;

[SuppressUnmanagedCodeSecurity]
public static partial class Vml
{
    public unsafe static class Unsafe
    {
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsAbs")]
        public static extern void Abs(int n, /* const */ [In] float* a, float* r);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdAbs")]
        public static extern void Abs(int n, /* const */ [In] double* a, double* r);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsAbs")]
        public static extern void Abs(int n, /* const */ [In] float* a, float* r, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdAbs")]
        public static extern void Abs(int n, /* const */ [In] double* a, double* r, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsAdd")]
        public static extern void Add(int n, /* const */ [In] float* a, /* const */ [In] float* b, float* r);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdAdd")]
        public static extern void Add(int n, /* const */ [In] double* a, /* const */ [In] double* b, double* r);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsAdd")]
        public static extern void Add(int n, /* const */ [In] float* a, /* const */ [In] float* b, float* r, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdAdd")]
        public static extern void Add(int n, /* const */ [In] double* a, /* const */ [In] double* b, double* r, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsSub")]
        public static extern void Sub(int n, /* const */ [In] float* a, /* const */ [In] float* b, float* r);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdSub")]
        public static extern void Sub(int n, /* const */ [In] double* a, /* const */ [In] double* b, double* r);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsSub")]
        public static extern void Sub(int n, /* const */ [In] float* a, /* const */ [In] float* b, float* r, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdSub")]
        public static extern void Sub(int n, /* const */ [In] double* a, /* const */ [In] double* b, double* r, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsInv")]
        public static extern void Inv(int n, /* const */ [In] float* a, float* r);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdInv")]
        public static extern void Inv(int n, /* const */ [In] double* a, double* r);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsInv")]
        public static extern void Inv(int n, /* const */ [In] float* a, float* r, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdInv")]
        public static extern void Inv(int n, /* const */ [In] double* a, double* r, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsSqrt")]
        public static extern void Sqrt(int n, /* const */ [In] float* a, float* r);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdSqrt")]
        public static extern void Sqrt(int n, /* const */ [In] double* a, double* r);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsSqrt")]
        public static extern void Sqrt(int n, /* const */ [In] float* a, float* r, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdSqrt")]
        public static extern void Sqrt(int n, /* const */ [In] double* a, double* r, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsInvSqrt")]
        public static extern void InvSqrt(int n, /* const */ [In] float* a, float* r);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdInvSqrt")]
        public static extern void InvSqrt(int n, /* const */ [In] double* a, double* r);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsInvSqrt")]
        public static extern void InvSqrt(int n, /* const */ [In] float* a, float* r, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdInvSqrt")]
        public static extern void InvSqrt(int n, /* const */ [In] double* a, double* r, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsCbrt")]
        public static extern void Cbrt(int n, /* const */ [In] float* a, float* r);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdCbrt")]
        public static extern void Cbrt(int n, /* const */ [In] double* a, double* r);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsCbrt")]
        public static extern void Cbrt(int n, /* const */ [In] float* a, float* r, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdCbrt")]
        public static extern void Cbrt(int n, /* const */ [In] double* a, double* r, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsInvCbrt")]
        public static extern void InvCbrt(int n, /* const */ [In] float* a, float* r);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdInvCbrt")]
        public static extern void InvCbrt(int n, /* const */ [In] double* a, double* r);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsInvCbrt")]
        public static extern void InvCbrt(int n, /* const */ [In] float* a, float* r, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdInvCbrt")]
        public static extern void InvCbrt(int n, /* const */ [In] double* a, double* r, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsSqr")]
        public static extern void Sqr(int n, /* const */ [In] float* a, float* r);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdSqr")]
        public static extern void Sqr(int n, /* const */ [In] double* a, double* r);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsSqr")]
        public static extern void Sqr(int n, /* const */ [In] float* a, float* r, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdSqr")]
        public static extern void Sqr(int n, /* const */ [In] double* a, double* r, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsExp")]
        public static extern void Exp(int n, /* const */ [In] float* a, float* r);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdExp")]
        public static extern void Exp(int n, /* const */ [In] double* a, double* r);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsExp")]
        public static extern void Exp(int n, /* const */ [In] float* a, float* r, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdExp")]
        public static extern void Exp(int n, /* const */ [In] double* a, double* r, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsExp2")]
        public static extern void Exp2(int n, /* const */ [In] float* a, float* r);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdExp2")]
        public static extern void Exp2(int n, /* const */ [In] double* a, double* r);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsExp2")]
        public static extern void Exp2(int n, /* const */ [In] float* a, float* r, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdExp2")]
        public static extern void Exp2(int n, /* const */ [In] double* a, double* r, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsExp10")]
        public static extern void Exp10(int n, /* const */ [In] float* a, float* r);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdExp10")]
        public static extern void Exp10(int n, /* const */ [In] double* a, double* r);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsExp10")]
        public static extern void Exp10(int n, /* const */ [In] float* a, float* r, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdExp10")]
        public static extern void Exp10(int n, /* const */ [In] double* a, double* r, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsExpm1")]
        public static extern void Expm1(int n, /* const */ [In] float* a, float* r);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdExpm1")]
        public static extern void Expm1(int n, /* const */ [In] double* a, double* r);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsExpm1")]
        public static extern void Expm1(int n, /* const */ [In] float* a, float* r, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdExpm1")]
        public static extern void Expm1(int n, /* const */ [In] double* a, double* r, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsLn")]
        public static extern void Ln(int n, /* const */ [In] float* a, float* r);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdLn")]
        public static extern void Ln(int n, /* const */ [In] double* a, double* r);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsLn")]
        public static extern void Ln(int n, /* const */ [In] float* a, float* r, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdLn")]
        public static extern void Ln(int n, /* const */ [In] double* a, double* r, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsLog2")]
        public static extern void Log2(int n, /* const */ [In] float* a, float* r);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdLog2")]
        public static extern void Log2(int n, /* const */ [In] double* a, double* r);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsLog2")]
        public static extern void Log2(int n, /* const */ [In] float* a, float* r, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdLog2")]
        public static extern void Log2(int n, /* const */ [In] double* a, double* r, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsLog10")]
        public static extern void Log10(int n, /* const */ [In] float* a, float* r);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdLog10")]
        public static extern void Log10(int n, /* const */ [In] double* a, double* r);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsLog10")]
        public static extern void Log10(int n, /* const */ [In] float* a, float* r, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdLog10")]
        public static extern void Log10(int n, /* const */ [In] double* a, double* r, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsLog1p")]
        public static extern void Log1p(int n, /* const */ [In] float* a, float* r);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdLog1p")]
        public static extern void Log1p(int n, /* const */ [In] double* a, double* r);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsLog1p")]
        public static extern void Log1p(int n, /* const */ [In] float* a, float* r, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdLog1p")]
        public static extern void Log1p(int n, /* const */ [In] double* a, double* r, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsLogb")]
        public static extern void Logb(int n, /* const */ [In] float* a, float* r);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdLogb")]
        public static extern void Logb(int n, /* const */ [In] double* a, double* r);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsLogb")]
        public static extern void Logb(int n, /* const */ [In] float* a, float* r, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdLogb")]
        public static extern void Logb(int n, /* const */ [In] double* a, double* r, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsCos")]
        public static extern void Cos(int n, /* const */ [In] float* a, float* r);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdCos")]
        public static extern void Cos(int n, /* const */ [In] double* a, double* r);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsCos")]
        public static extern void Cos(int n, /* const */ [In] float* a, float* r, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdCos")]
        public static extern void Cos(int n, /* const */ [In] double* a, double* r, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsSin")]
        public static extern void Sin(int n, /* const */ [In] float* a, float* r);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdSin")]
        public static extern void Sin(int n, /* const */ [In] double* a, double* r);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsSin")]
        public static extern void Sin(int n, /* const */ [In] float* a, float* r, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdSin")]
        public static extern void Sin(int n, /* const */ [In] double* a, double* r, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsTan")]
        public static extern void Tan(int n, /* const */ [In] float* a, float* r);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdTan")]
        public static extern void Tan(int n, /* const */ [In] double* a, double* r);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsTan")]
        public static extern void Tan(int n, /* const */ [In] float* a, float* r, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdTan")]
        public static extern void Tan(int n, /* const */ [In] double* a, double* r, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsCospi")]
        public static extern void Cospi(int n, /* const */ [In] float* a, float* r);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdCospi")]
        public static extern void Cospi(int n, /* const */ [In] double* a, double* r);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsCospi")]
        public static extern void Cospi(int n, /* const */ [In] float* a, float* r, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdCospi")]
        public static extern void Cospi(int n, /* const */ [In] double* a, double* r, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsSinpi")]
        public static extern void Sinpi(int n, /* const */ [In] float* a, float* r);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdSinpi")]
        public static extern void Sinpi(int n, /* const */ [In] double* a, double* r);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsSinpi")]
        public static extern void Sinpi(int n, /* const */ [In] float* a, float* r, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdSinpi")]
        public static extern void Sinpi(int n, /* const */ [In] double* a, double* r, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsTanpi")]
        public static extern void Tanpi(int n, /* const */ [In] float* a, float* r);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdTanpi")]
        public static extern void Tanpi(int n, /* const */ [In] double* a, double* r);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsTanpi")]
        public static extern void Tanpi(int n, /* const */ [In] float* a, float* r, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdTanpi")]
        public static extern void Tanpi(int n, /* const */ [In] double* a, double* r, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsCosd")]
        public static extern void Cosd(int n, /* const */ [In] float* a, float* r);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdCosd")]
        public static extern void Cosd(int n, /* const */ [In] double* a, double* r);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsCosd")]
        public static extern void Cosd(int n, /* const */ [In] float* a, float* r, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdCosd")]
        public static extern void Cosd(int n, /* const */ [In] double* a, double* r, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsSind")]
        public static extern void Sind(int n, /* const */ [In] float* a, float* r);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdSind")]
        public static extern void Sind(int n, /* const */ [In] double* a, double* r);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsSind")]
        public static extern void Sind(int n, /* const */ [In] float* a, float* r, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdSind")]
        public static extern void Sind(int n, /* const */ [In] double* a, double* r, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsTand")]
        public static extern void Tand(int n, /* const */ [In] float* a, float* r);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdTand")]
        public static extern void Tand(int n, /* const */ [In] double* a, double* r);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsTand")]
        public static extern void Tand(int n, /* const */ [In] float* a, float* r, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdTand")]
        public static extern void Tand(int n, /* const */ [In] double* a, double* r, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsCosh")]
        public static extern void Cosh(int n, /* const */ [In] float* a, float* r);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdCosh")]
        public static extern void Cosh(int n, /* const */ [In] double* a, double* r);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsCosh")]
        public static extern void Cosh(int n, /* const */ [In] float* a, float* r, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdCosh")]
        public static extern void Cosh(int n, /* const */ [In] double* a, double* r, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsSinh")]
        public static extern void Sinh(int n, /* const */ [In] float* a, float* r);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdSinh")]
        public static extern void Sinh(int n, /* const */ [In] double* a, double* r);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsSinh")]
        public static extern void Sinh(int n, /* const */ [In] float* a, float* r, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdSinh")]
        public static extern void Sinh(int n, /* const */ [In] double* a, double* r, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsTanh")]
        public static extern void Tanh(int n, /* const */ [In] float* a, float* r);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdTanh")]
        public static extern void Tanh(int n, /* const */ [In] double* a, double* r);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsTanh")]
        public static extern void Tanh(int n, /* const */ [In] float* a, float* r, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdTanh")]
        public static extern void Tanh(int n, /* const */ [In] double* a, double* r, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsAcos")]
        public static extern void Acos(int n, /* const */ [In] float* a, float* r);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdAcos")]
        public static extern void Acos(int n, /* const */ [In] double* a, double* r);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsAcos")]
        public static extern void Acos(int n, /* const */ [In] float* a, float* r, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdAcos")]
        public static extern void Acos(int n, /* const */ [In] double* a, double* r, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsAsin")]
        public static extern void Asin(int n, /* const */ [In] float* a, float* r);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdAsin")]
        public static extern void Asin(int n, /* const */ [In] double* a, double* r);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsAsin")]
        public static extern void Asin(int n, /* const */ [In] float* a, float* r, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdAsin")]
        public static extern void Asin(int n, /* const */ [In] double* a, double* r, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsAtan")]
        public static extern void Atan(int n, /* const */ [In] float* a, float* r);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdAtan")]
        public static extern void Atan(int n, /* const */ [In] double* a, double* r);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsAtan")]
        public static extern void Atan(int n, /* const */ [In] float* a, float* r, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdAtan")]
        public static extern void Atan(int n, /* const */ [In] double* a, double* r, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsAcospi")]
        public static extern void Acospi(int n, /* const */ [In] float* a, float* r);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdAcospi")]
        public static extern void Acospi(int n, /* const */ [In] double* a, double* r);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsAcospi")]
        public static extern void Acospi(int n, /* const */ [In] float* a, float* r, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdAcospi")]
        public static extern void Acospi(int n, /* const */ [In] double* a, double* r, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsAsinpi")]
        public static extern void Asinpi(int n, /* const */ [In] float* a, float* r);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdAsinpi")]
        public static extern void Asinpi(int n, /* const */ [In] double* a, double* r);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsAsinpi")]
        public static extern void Asinpi(int n, /* const */ [In] float* a, float* r, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdAsinpi")]
        public static extern void Asinpi(int n, /* const */ [In] double* a, double* r, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsAtanpi")]
        public static extern void Atanpi(int n, /* const */ [In] float* a, float* r);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdAtanpi")]
        public static extern void Atanpi(int n, /* const */ [In] double* a, double* r);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsAtanpi")]
        public static extern void Atanpi(int n, /* const */ [In] float* a, float* r, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdAtanpi")]
        public static extern void Atanpi(int n, /* const */ [In] double* a, double* r, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsAcosh")]
        public static extern void Acosh(int n, /* const */ [In] float* a, float* r);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdAcosh")]
        public static extern void Acosh(int n, /* const */ [In] double* a, double* r);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsAcosh")]
        public static extern void Acosh(int n, /* const */ [In] float* a, float* r, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdAcosh")]
        public static extern void Acosh(int n, /* const */ [In] double* a, double* r, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsAsinh")]
        public static extern void Asinh(int n, /* const */ [In] float* a, float* r);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdAsinh")]
        public static extern void Asinh(int n, /* const */ [In] double* a, double* r);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsAsinh")]
        public static extern void Asinh(int n, /* const */ [In] float* a, float* r, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdAsinh")]
        public static extern void Asinh(int n, /* const */ [In] double* a, double* r, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsAtanh")]
        public static extern void Atanh(int n, /* const */ [In] float* a, float* r);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdAtanh")]
        public static extern void Atanh(int n, /* const */ [In] double* a, double* r);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsAtanh")]
        public static extern void Atanh(int n, /* const */ [In] float* a, float* r, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdAtanh")]
        public static extern void Atanh(int n, /* const */ [In] double* a, double* r, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsErf")]
        public static extern void Erf(int n, /* const */ [In] float* a, float* r);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdErf")]
        public static extern void Erf(int n, /* const */ [In] double* a, double* r);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsErf")]
        public static extern void Erf(int n, /* const */ [In] float* a, float* r, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdErf")]
        public static extern void Erf(int n, /* const */ [In] double* a, double* r, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsErfInv")]
        public static extern void ErfInv(int n, /* const */ [In] float* a, float* r);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdErfInv")]
        public static extern void ErfInv(int n, /* const */ [In] double* a, double* r);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsErfInv")]
        public static extern void ErfInv(int n, /* const */ [In] float* a, float* r, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdErfInv")]
        public static extern void ErfInv(int n, /* const */ [In] double* a, double* r, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsHypot")]
        public static extern void Hypot(int n, /* const */ [In] float* a, /* const */ [In] float* b, float* r);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdHypot")]
        public static extern void Hypot(int n, /* const */ [In] double* a, /* const */ [In] double* b, double* r);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsHypot")]
        public static extern void Hypot(int n, /* const */ [In] float* a, /* const */ [In] float* b, float* r, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdHypot")]
        public static extern void Hypot(int n, /* const */ [In] double* a, /* const */ [In] double* b, double* r, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsErfc")]
        public static extern void Erfc(int n, /* const */ [In] float* a, float* r);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdErfc")]
        public static extern void Erfc(int n, /* const */ [In] double* a, double* r);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsErfc")]
        public static extern void Erfc(int n, /* const */ [In] float* a, float* r, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdErfc")]
        public static extern void Erfc(int n, /* const */ [In] double* a, double* r, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsErfcInv")]
        public static extern void ErfcInv(int n, /* const */ [In] float* a, float* r);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdErfcInv")]
        public static extern void ErfcInv(int n, /* const */ [In] double* a, double* r);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsErfcInv")]
        public static extern void ErfcInv(int n, /* const */ [In] float* a, float* r, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdErfcInv")]
        public static extern void ErfcInv(int n, /* const */ [In] double* a, double* r, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsCdfNorm")]
        public static extern void CdfNorm(int n, /* const */ [In] float* a, float* r);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdCdfNorm")]
        public static extern void CdfNorm(int n, /* const */ [In] double* a, double* r);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsCdfNorm")]
        public static extern void CdfNorm(int n, /* const */ [In] float* a, float* r, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdCdfNorm")]
        public static extern void CdfNorm(int n, /* const */ [In] double* a, double* r, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsCdfNormInv")]
        public static extern void CdfNormInv(int n, /* const */ [In] float* a, float* r);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdCdfNormInv")]
        public static extern void CdfNormInv(int n, /* const */ [In] double* a, double* r);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsCdfNormInv")]
        public static extern void CdfNormInv(int n, /* const */ [In] float* a, float* r, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdCdfNormInv")]
        public static extern void CdfNormInv(int n, /* const */ [In] double* a, double* r, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsLGamma")]
        public static extern void LGamma(int n, /* const */ [In] float* a, float* r);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdLGamma")]
        public static extern void LGamma(int n, /* const */ [In] double* a, double* r);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsLGamma")]
        public static extern void LGamma(int n, /* const */ [In] float* a, float* r, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdLGamma")]
        public static extern void LGamma(int n, /* const */ [In] double* a, double* r, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsTGamma")]
        public static extern void TGamma(int n, /* const */ [In] float* a, float* r);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdTGamma")]
        public static extern void TGamma(int n, /* const */ [In] double* a, double* r);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsTGamma")]
        public static extern void TGamma(int n, /* const */ [In] float* a, float* r, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdTGamma")]
        public static extern void TGamma(int n, /* const */ [In] double* a, double* r, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsAtan2")]
        public static extern void Atan2(int n, /* const */ [In] float* a, /* const */ [In] float* b, float* r);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdAtan2")]
        public static extern void Atan2(int n, /* const */ [In] double* a, /* const */ [In] double* b, double* r);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsAtan2")]
        public static extern void Atan2(int n, /* const */ [In] float* a, /* const */ [In] float* b, float* r, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdAtan2")]
        public static extern void Atan2(int n, /* const */ [In] double* a, /* const */ [In] double* b, double* r, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsAtan2pi")]
        public static extern void Atan2pi(int n, /* const */ [In] float* a, /* const */ [In] float* b, float* r);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdAtan2pi")]
        public static extern void Atan2pi(int n, /* const */ [In] double* a, /* const */ [In] double* b, double* r);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsAtan2pi")]
        public static extern void Atan2pi(int n, /* const */ [In] float* a, /* const */ [In] float* b, float* r, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdAtan2pi")]
        public static extern void Atan2pi(int n, /* const */ [In] double* a, /* const */ [In] double* b, double* r, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsMul")]
        public static extern void Mul(int n, /* const */ [In] float* a, /* const */ [In] float* b, float* r);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdMul")]
        public static extern void Mul(int n, /* const */ [In] double* a, /* const */ [In] double* b, double* r);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsMul")]
        public static extern void Mul(int n, /* const */ [In] float* a, /* const */ [In] float* b, float* r, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdMul")]
        public static extern void Mul(int n, /* const */ [In] double* a, /* const */ [In] double* b, double* r, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsDiv")]
        public static extern void Div(int n, /* const */ [In] float* a, /* const */ [In] float* b, float* r);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdDiv")]
        public static extern void Div(int n, /* const */ [In] double* a, /* const */ [In] double* b, double* r);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsDiv")]
        public static extern void Div(int n, /* const */ [In] float* a, /* const */ [In] float* b, float* r, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdDiv")]
        public static extern void Div(int n, /* const */ [In] double* a, /* const */ [In] double* b, double* r, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsPow")]
        public static extern void Pow(int n, /* const */ [In] float* a, /* const */ [In] float* b, float* r);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdPow")]
        public static extern void Pow(int n, /* const */ [In] double* a, /* const */ [In] double* b, double* r);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsPow")]
        public static extern void Pow(int n, /* const */ [In] float* a, /* const */ [In] float* b, float* r, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdPow")]
        public static extern void Pow(int n, /* const */ [In] double* a, /* const */ [In] double* b, double* r, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsPow3o2")]
        public static extern void Pow3o2(int n, /* const */ [In] float* a, float* r);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdPow3o2")]
        public static extern void Pow3o2(int n, /* const */ [In] double* a, double* r);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsPow3o2")]
        public static extern void Pow3o2(int n, /* const */ [In] float* a, float* r, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdPow3o2")]
        public static extern void Pow3o2(int n, /* const */ [In] double* a, double* r, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsPow2o3")]
        public static extern void Pow2o3(int n, /* const */ [In] float* a, float* r);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdPow2o3")]
        public static extern void Pow2o3(int n, /* const */ [In] double* a, double* r);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsPow2o3")]
        public static extern void Pow2o3(int n, /* const */ [In] float* a, float* r, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdPow2o3")]
        public static extern void Pow2o3(int n, /* const */ [In] double* a, double* r, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsPowx")]
        public static extern void Powx(int n, /* const */ [In] float* a, float b, float* r);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdPowx")]
        public static extern void Powx(int n, /* const */ [In] double* a, double b, double* r);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsPowx")]
        public static extern void Powx(int n, /* const */ [In] float* a, float b, float* r, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdPowx")]
        public static extern void Powx(int n, /* const */ [In] double* a, double b, double* r, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsPowr")]
        public static extern void Powr(int n, /* const */ [In] float* a, /* const */ [In] float* b, float* r);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdPowr")]
        public static extern void Powr(int n, /* const */ [In] double* a, /* const */ [In] double* b, double* r);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsPowr")]
        public static extern void Powr(int n, /* const */ [In] float* a, /* const */ [In] float* b, float* r, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdPowr")]
        public static extern void Powr(int n, /* const */ [In] double* a, /* const */ [In] double* b, double* r, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsSinCos")]
        public static extern void SinCos(int n, /* const */ [In] float* a, float* r1, float* r2);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdSinCos")]
        public static extern void SinCos(int n, /* const */ [In] double* a, double* r1, double* r2);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsSinCos")]
        public static extern void SinCos(int n, /* const */ [In] float* a, float* r1, float* r2, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdSinCos")]
        public static extern void SinCos(int n, /* const */ [In] double* a, double* r1, double* r2, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsLinearFrac")]
        public static extern void LinearFrac(int n, /* const */ [In] float* a, /* const */ [In] float* b, float scalea, float shifta, float scaleb, float shiftb, float* r);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdLinearFrac")]
        public static extern void LinearFrac(int n, /* const */ [In] double* a, /* const */ [In] double* b, double scalea, double shifta, double scaleb, double shiftb, double* r);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsLinearFrac")]
        public static extern void LinearFrac(int n, /* const */ [In] float* a, /* const */ [In] float* b, float scalea, float shifta, float scaleb, float shiftb, float* r, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdLinearFrac")]
        public static extern void LinearFrac(int n, /* const */ [In] double* a, /* const */ [In] double* b, double scalea, double shifta, double scaleb, double shiftb, double* r, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsCeil")]
        public static extern void Ceil(int n, /* const */ [In] float* a, float* r);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdCeil")]
        public static extern void Ceil(int n, /* const */ [In] double* a, double* r);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsCeil")]
        public static extern void Ceil(int n, /* const */ [In] float* a, float* r, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdCeil")]
        public static extern void Ceil(int n, /* const */ [In] double* a, double* r, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsFloor")]
        public static extern void Floor(int n, /* const */ [In] float* a, float* r);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdFloor")]
        public static extern void Floor(int n, /* const */ [In] double* a, double* r);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsFloor")]
        public static extern void Floor(int n, /* const */ [In] float* a, float* r, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdFloor")]
        public static extern void Floor(int n, /* const */ [In] double* a, double* r, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsFrac")]
        public static extern void Frac(int n, /* const */ [In] float* a, float* r);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdFrac")]
        public static extern void Frac(int n, /* const */ [In] double* a, double* r);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsFrac")]
        public static extern void Frac(int n, /* const */ [In] float* a, float* r, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdFrac")]
        public static extern void Frac(int n, /* const */ [In] double* a, double* r, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsModf")]
        public static extern void Modf(int n, /* const */ [In] float* a, float* r1, float* r2);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdModf")]
        public static extern void Modf(int n, /* const */ [In] double* a, double* r1, double* r2);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsModf")]
        public static extern void Modf(int n, /* const */ [In] float* a, float* r1, float* r2, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdModf")]
        public static extern void Modf(int n, /* const */ [In] double* a, double* r1, double* r2, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsFmod")]
        public static extern void Fmod(int n, /* const */ [In] float* a, /* const */ [In] float* b, float* r);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdFmod")]
        public static extern void Fmod(int n, /* const */ [In] double* a, /* const */ [In] double* b, double* r);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsFmod")]
        public static extern void Fmod(int n, /* const */ [In] float* a, /* const */ [In] float* b, float* r, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdFmod")]
        public static extern void Fmod(int n, /* const */ [In] double* a, /* const */ [In] double* b, double* r, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsRemainder")]
        public static extern void Remainder(int n, /* const */ [In] float* a, /* const */ [In] float* b, float* r);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdRemainder")]
        public static extern void Remainder(int n, /* const */ [In] double* a, /* const */ [In] double* b, double* r);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsRemainder")]
        public static extern void Remainder(int n, /* const */ [In] float* a, /* const */ [In] float* b, float* r, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdRemainder")]
        public static extern void Remainder(int n, /* const */ [In] double* a, /* const */ [In] double* b, double* r, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsNextAfter")]
        public static extern void NextAfter(int n, /* const */ [In] float* a, /* const */ [In] float* b, float* r);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdNextAfter")]
        public static extern void NextAfter(int n, /* const */ [In] double* a, /* const */ [In] double* b, double* r);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsNextAfter")]
        public static extern void NextAfter(int n, /* const */ [In] float* a, /* const */ [In] float* b, float* r, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdNextAfter")]
        public static extern void NextAfter(int n, /* const */ [In] double* a, /* const */ [In] double* b, double* r, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsCopySign")]
        public static extern void CopySign(int n, /* const */ [In] float* a, /* const */ [In] float* b, float* r);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdCopySign")]
        public static extern void CopySign(int n, /* const */ [In] double* a, /* const */ [In] double* b, double* r);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsCopySign")]
        public static extern void CopySign(int n, /* const */ [In] float* a, /* const */ [In] float* b, float* r, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdCopySign")]
        public static extern void CopySign(int n, /* const */ [In] double* a, /* const */ [In] double* b, double* r, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsFdim")]
        public static extern void Fdim(int n, /* const */ [In] float* a, /* const */ [In] float* b, float* r);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdFdim")]
        public static extern void Fdim(int n, /* const */ [In] double* a, /* const */ [In] double* b, double* r);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsFdim")]
        public static extern void Fdim(int n, /* const */ [In] float* a, /* const */ [In] float* b, float* r, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdFdim")]
        public static extern void Fdim(int n, /* const */ [In] double* a, /* const */ [In] double* b, double* r, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsFmax")]
        public static extern void Fmax(int n, /* const */ [In] float* a, /* const */ [In] float* b, float* r);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdFmax")]
        public static extern void Fmax(int n, /* const */ [In] double* a, /* const */ [In] double* b, double* r);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsFmax")]
        public static extern void Fmax(int n, /* const */ [In] float* a, /* const */ [In] float* b, float* r, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdFmax")]
        public static extern void Fmax(int n, /* const */ [In] double* a, /* const */ [In] double* b, double* r, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsFmin")]
        public static extern void Fmin(int n, /* const */ [In] float* a, /* const */ [In] float* b, float* r);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdFmin")]
        public static extern void Fmin(int n, /* const */ [In] double* a, /* const */ [In] double* b, double* r);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsFmin")]
        public static extern void Fmin(int n, /* const */ [In] float* a, /* const */ [In] float* b, float* r, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdFmin")]
        public static extern void Fmin(int n, /* const */ [In] double* a, /* const */ [In] double* b, double* r, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsMaxMag")]
        public static extern void MaxMag(int n, /* const */ [In] float* a, /* const */ [In] float* b, float* r);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdMaxMag")]
        public static extern void MaxMag(int n, /* const */ [In] double* a, /* const */ [In] double* b, double* r);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsMaxMag")]
        public static extern void MaxMag(int n, /* const */ [In] float* a, /* const */ [In] float* b, float* r, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdMaxMag")]
        public static extern void MaxMag(int n, /* const */ [In] double* a, /* const */ [In] double* b, double* r, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsMinMag")]
        public static extern void MinMag(int n, /* const */ [In] float* a, /* const */ [In] float* b, float* r);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdMinMag")]
        public static extern void MinMag(int n, /* const */ [In] double* a, /* const */ [In] double* b, double* r);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsMinMag")]
        public static extern void MinMag(int n, /* const */ [In] float* a, /* const */ [In] float* b, float* r, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdMinMag")]
        public static extern void MinMag(int n, /* const */ [In] double* a, /* const */ [In] double* b, double* r, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsNearbyInt")]
        public static extern void NearbyInt(int n, /* const */ [In] float* a, float* r);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdNearbyInt")]
        public static extern void NearbyInt(int n, /* const */ [In] double* a, double* r);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsNearbyInt")]
        public static extern void NearbyInt(int n, /* const */ [In] float* a, float* r, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdNearbyInt")]
        public static extern void NearbyInt(int n, /* const */ [In] double* a, double* r, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsRint")]
        public static extern void Rint(int n, /* const */ [In] float* a, float* r);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdRint")]
        public static extern void Rint(int n, /* const */ [In] double* a, double* r);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsRint")]
        public static extern void Rint(int n, /* const */ [In] float* a, float* r, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdRint")]
        public static extern void Rint(int n, /* const */ [In] double* a, double* r, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsRound")]
        public static extern void Round(int n, /* const */ [In] float* a, float* r);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdRound")]
        public static extern void Round(int n, /* const */ [In] double* a, double* r);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsRound")]
        public static extern void Round(int n, /* const */ [In] float* a, float* r, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdRound")]
        public static extern void Round(int n, /* const */ [In] double* a, double* r, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsTrunc")]
        public static extern void Trunc(int n, /* const */ [In] float* a, float* r);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdTrunc")]
        public static extern void Trunc(int n, /* const */ [In] double* a, double* r);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsTrunc")]
        public static extern void Trunc(int n, /* const */ [In] float* a, float* r, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdTrunc")]
        public static extern void Trunc(int n, /* const */ [In] double* a, double* r, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsExpInt1")]
        public static extern void ExpInt1(int n, /* const */ [In] float* a, float* r);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdExpInt1")]
        public static extern void ExpInt1(int n, /* const */ [In] double* a, double* r);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsExpInt1")]
        public static extern void ExpInt1(int n, /* const */ [In] float* a, float* r, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdExpInt1")]
        public static extern void ExpInt1(int n, /* const */ [In] double* a, double* r, VmlMode mode);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsAbsI")]
        public static extern void AbsI(int n, /* const */ [In] float* a, int inca, float* r, int incr);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdAbsI")]
        public static extern void AbsI(int n, /* const */ [In] double* a, int inca, double* r, int incr);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsAbsI")]
        public static extern void AbsI(int n, /* const */ [In] float* a, int inca, float* r, int incr, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdAbsI")]
        public static extern void AbsI(int n, /* const */ [In] double* a, int inca, double* r, int incr, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsAddI")]
        public static extern void AddI(int n, /* const */ [In] float* a, int inca, /* const */ [In] float* b, int incb, float* r, int incr);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdAddI")]
        public static extern void AddI(int n, /* const */ [In] double* a, int inca, /* const */ [In] double* b, int incb, double* r, int incr);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsAddI")]
        public static extern void AddI(int n, /* const */ [In] float* a, int inca, /* const */ [In] float* b, int incb, float* r, int incr, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdAddI")]
        public static extern void AddI(int n, /* const */ [In] double* a, int inca, /* const */ [In] double* b, int incb, double* r, int incr, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsSubI")]
        public static extern void SubI(int n, /* const */ [In] float* a, int inca, /* const */ [In] float* b, int incb, float* r, int incr);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdSubI")]
        public static extern void SubI(int n, /* const */ [In] double* a, int inca, /* const */ [In] double* b, int incb, double* r, int incr);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsSubI")]
        public static extern void SubI(int n, /* const */ [In] float* a, int inca, /* const */ [In] float* b, int incb, float* r, int incr, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdSubI")]
        public static extern void SubI(int n, /* const */ [In] double* a, int inca, /* const */ [In] double* b, int incb, double* r, int incr, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsInvI")]
        public static extern void InvI(int n, /* const */ [In] float* a, int inca, float* r, int incr);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdInvI")]
        public static extern void InvI(int n, /* const */ [In] double* a, int inca, double* r, int incr);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsInvI")]
        public static extern void InvI(int n, /* const */ [In] float* a, int inca, float* r, int incr, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdInvI")]
        public static extern void InvI(int n, /* const */ [In] double* a, int inca, double* r, int incr, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsSqrtI")]
        public static extern void SqrtI(int n, /* const */ [In] float* a, int inca, float* r, int incr);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdSqrtI")]
        public static extern void SqrtI(int n, /* const */ [In] double* a, int inca, double* r, int incr);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsSqrtI")]
        public static extern void SqrtI(int n, /* const */ [In] float* a, int inca, float* r, int incr, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdSqrtI")]
        public static extern void SqrtI(int n, /* const */ [In] double* a, int inca, double* r, int incr, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsInvSqrtI")]
        public static extern void InvSqrtI(int n, /* const */ [In] float* a, int inca, float* r, int incr);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdInvSqrtI")]
        public static extern void InvSqrtI(int n, /* const */ [In] double* a, int inca, double* r, int incr);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsInvSqrtI")]
        public static extern void InvSqrtI(int n, /* const */ [In] float* a, int inca, float* r, int incr, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdInvSqrtI")]
        public static extern void InvSqrtI(int n, /* const */ [In] double* a, int inca, double* r, int incr, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsCbrtI")]
        public static extern void CbrtI(int n, /* const */ [In] float* a, int inca, float* r, int incr);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdCbrtI")]
        public static extern void CbrtI(int n, /* const */ [In] double* a, int inca, double* r, int incr);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsCbrtI")]
        public static extern void CbrtI(int n, /* const */ [In] float* a, int inca, float* r, int incr, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdCbrtI")]
        public static extern void CbrtI(int n, /* const */ [In] double* a, int inca, double* r, int incr, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsInvCbrtI")]
        public static extern void InvCbrtI(int n, /* const */ [In] float* a, int inca, float* r, int incr);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdInvCbrtI")]
        public static extern void InvCbrtI(int n, /* const */ [In] double* a, int inca, double* r, int incr);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsInvCbrtI")]
        public static extern void InvCbrtI(int n, /* const */ [In] float* a, int inca, float* r, int incr, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdInvCbrtI")]
        public static extern void InvCbrtI(int n, /* const */ [In] double* a, int inca, double* r, int incr, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsSqrI")]
        public static extern void SqrI(int n, /* const */ [In] float* a, int inca, float* r, int incr);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdSqrI")]
        public static extern void SqrI(int n, /* const */ [In] double* a, int inca, double* r, int incr);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsSqrI")]
        public static extern void SqrI(int n, /* const */ [In] float* a, int inca, float* r, int incr, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdSqrI")]
        public static extern void SqrI(int n, /* const */ [In] double* a, int inca, double* r, int incr, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsExpI")]
        public static extern void ExpI(int n, /* const */ [In] float* a, int inca, float* r, int incr);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdExpI")]
        public static extern void ExpI(int n, /* const */ [In] double* a, int inca, double* r, int incr);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsExpI")]
        public static extern void ExpI(int n, /* const */ [In] float* a, int inca, float* r, int incr, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdExpI")]
        public static extern void ExpI(int n, /* const */ [In] double* a, int inca, double* r, int incr, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsExp2I")]
        public static extern void Exp2I(int n, /* const */ [In] float* a, int inca, float* r, int incr);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdExp2I")]
        public static extern void Exp2I(int n, /* const */ [In] double* a, int inca, double* r, int incr);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsExp2I")]
        public static extern void Exp2I(int n, /* const */ [In] float* a, int inca, float* r, int incr, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdExp2I")]
        public static extern void Exp2I(int n, /* const */ [In] double* a, int inca, double* r, int incr, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsExp10I")]
        public static extern void Exp10I(int n, /* const */ [In] float* a, int inca, float* r, int incr);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdExp10I")]
        public static extern void Exp10I(int n, /* const */ [In] double* a, int inca, double* r, int incr);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsExp10I")]
        public static extern void Exp10I(int n, /* const */ [In] float* a, int inca, float* r, int incr, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdExp10I")]
        public static extern void Exp10I(int n, /* const */ [In] double* a, int inca, double* r, int incr, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsExpm1I")]
        public static extern void Expm1I(int n, /* const */ [In] float* a, int inca, float* r, int incr);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdExpm1I")]
        public static extern void Expm1I(int n, /* const */ [In] double* a, int inca, double* r, int incr);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsExpm1I")]
        public static extern void Expm1I(int n, /* const */ [In] float* a, int inca, float* r, int incr, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdExpm1I")]
        public static extern void Expm1I(int n, /* const */ [In] double* a, int inca, double* r, int incr, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsLnI")]
        public static extern void LnI(int n, /* const */ [In] float* a, int inca, float* r, int incr);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdLnI")]
        public static extern void LnI(int n, /* const */ [In] double* a, int inca, double* r, int incr);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsLnI")]
        public static extern void LnI(int n, /* const */ [In] float* a, int inca, float* r, int incr, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdLnI")]
        public static extern void LnI(int n, /* const */ [In] double* a, int inca, double* r, int incr, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsLog10I")]
        public static extern void Log10I(int n, /* const */ [In] float* a, int inca, float* r, int incr);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdLog10I")]
        public static extern void Log10I(int n, /* const */ [In] double* a, int inca, double* r, int incr);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsLog10I")]
        public static extern void Log10I(int n, /* const */ [In] float* a, int inca, float* r, int incr, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdLog10I")]
        public static extern void Log10I(int n, /* const */ [In] double* a, int inca, double* r, int incr, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsLog2I")]
        public static extern void Log2I(int n, /* const */ [In] float* a, int inca, float* r, int incr);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdLog2I")]
        public static extern void Log2I(int n, /* const */ [In] double* a, int inca, double* r, int incr);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsLog2I")]
        public static extern void Log2I(int n, /* const */ [In] float* a, int inca, float* r, int incr, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdLog2I")]
        public static extern void Log2I(int n, /* const */ [In] double* a, int inca, double* r, int incr, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsLog1pI")]
        public static extern void Log1pI(int n, /* const */ [In] float* a, int inca, float* r, int incr);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdLog1pI")]
        public static extern void Log1pI(int n, /* const */ [In] double* a, int inca, double* r, int incr);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsLog1pI")]
        public static extern void Log1pI(int n, /* const */ [In] float* a, int inca, float* r, int incr, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdLog1pI")]
        public static extern void Log1pI(int n, /* const */ [In] double* a, int inca, double* r, int incr, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsLogbI")]
        public static extern void LogbI(int n, /* const */ [In] float* a, int inca, float* r, int incr);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdLogbI")]
        public static extern void LogbI(int n, /* const */ [In] double* a, int inca, double* r, int incr);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsLogbI")]
        public static extern void LogbI(int n, /* const */ [In] float* a, int inca, float* r, int incr, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdLogbI")]
        public static extern void LogbI(int n, /* const */ [In] double* a, int inca, double* r, int incr, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsCosI")]
        public static extern void CosI(int n, /* const */ [In] float* a, int inca, float* r, int incr);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdCosI")]
        public static extern void CosI(int n, /* const */ [In] double* a, int inca, double* r, int incr);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsCosI")]
        public static extern void CosI(int n, /* const */ [In] float* a, int inca, float* r, int incr, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdCosI")]
        public static extern void CosI(int n, /* const */ [In] double* a, int inca, double* r, int incr, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsSinI")]
        public static extern void SinI(int n, /* const */ [In] float* a, int inca, float* r, int incr);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdSinI")]
        public static extern void SinI(int n, /* const */ [In] double* a, int inca, double* r, int incr);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsSinI")]
        public static extern void SinI(int n, /* const */ [In] float* a, int inca, float* r, int incr, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdSinI")]
        public static extern void SinI(int n, /* const */ [In] double* a, int inca, double* r, int incr, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsTanI")]
        public static extern void TanI(int n, /* const */ [In] float* a, int inca, float* r, int incr);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdTanI")]
        public static extern void TanI(int n, /* const */ [In] double* a, int inca, double* r, int incr);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsTanI")]
        public static extern void TanI(int n, /* const */ [In] float* a, int inca, float* r, int incr, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdTanI")]
        public static extern void TanI(int n, /* const */ [In] double* a, int inca, double* r, int incr, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsCoshI")]
        public static extern void CoshI(int n, /* const */ [In] float* a, int inca, float* r, int incr);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdCoshI")]
        public static extern void CoshI(int n, /* const */ [In] double* a, int inca, double* r, int incr);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsCoshI")]
        public static extern void CoshI(int n, /* const */ [In] float* a, int inca, float* r, int incr, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdCoshI")]
        public static extern void CoshI(int n, /* const */ [In] double* a, int inca, double* r, int incr, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsCosdI")]
        public static extern void CosdI(int n, /* const */ [In] float* a, int inca, float* r, int incr);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdCosdI")]
        public static extern void CosdI(int n, /* const */ [In] double* a, int inca, double* r, int incr);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsCosdI")]
        public static extern void CosdI(int n, /* const */ [In] float* a, int inca, float* r, int incr, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdCosdI")]
        public static extern void CosdI(int n, /* const */ [In] double* a, int inca, double* r, int incr, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsCospiI")]
        public static extern void CospiI(int n, /* const */ [In] float* a, int inca, float* r, int incr);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdCospiI")]
        public static extern void CospiI(int n, /* const */ [In] double* a, int inca, double* r, int incr);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsCospiI")]
        public static extern void CospiI(int n, /* const */ [In] float* a, int inca, float* r, int incr, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdCospiI")]
        public static extern void CospiI(int n, /* const */ [In] double* a, int inca, double* r, int incr, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsSinhI")]
        public static extern void SinhI(int n, /* const */ [In] float* a, int inca, float* r, int incr);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdSinhI")]
        public static extern void SinhI(int n, /* const */ [In] double* a, int inca, double* r, int incr);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsSinhI")]
        public static extern void SinhI(int n, /* const */ [In] float* a, int inca, float* r, int incr, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdSinhI")]
        public static extern void SinhI(int n, /* const */ [In] double* a, int inca, double* r, int incr, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsSindI")]
        public static extern void SindI(int n, /* const */ [In] float* a, int inca, float* r, int incr);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdSindI")]
        public static extern void SindI(int n, /* const */ [In] double* a, int inca, double* r, int incr);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsSindI")]
        public static extern void SindI(int n, /* const */ [In] float* a, int inca, float* r, int incr, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdSindI")]
        public static extern void SindI(int n, /* const */ [In] double* a, int inca, double* r, int incr, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsSinpiI")]
        public static extern void SinpiI(int n, /* const */ [In] float* a, int inca, float* r, int incr);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdSinpiI")]
        public static extern void SinpiI(int n, /* const */ [In] double* a, int inca, double* r, int incr);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsSinpiI")]
        public static extern void SinpiI(int n, /* const */ [In] float* a, int inca, float* r, int incr, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdSinpiI")]
        public static extern void SinpiI(int n, /* const */ [In] double* a, int inca, double* r, int incr, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsTanhI")]
        public static extern void TanhI(int n, /* const */ [In] float* a, int inca, float* r, int incr);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdTanhI")]
        public static extern void TanhI(int n, /* const */ [In] double* a, int inca, double* r, int incr);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsTanhI")]
        public static extern void TanhI(int n, /* const */ [In] float* a, int inca, float* r, int incr, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdTanhI")]
        public static extern void TanhI(int n, /* const */ [In] double* a, int inca, double* r, int incr, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsTandI")]
        public static extern void TandI(int n, /* const */ [In] float* a, int inca, float* r, int incr);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdTandI")]
        public static extern void TandI(int n, /* const */ [In] double* a, int inca, double* r, int incr);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsTandI")]
        public static extern void TandI(int n, /* const */ [In] float* a, int inca, float* r, int incr, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdTandI")]
        public static extern void TandI(int n, /* const */ [In] double* a, int inca, double* r, int incr, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsTanpiI")]
        public static extern void TanpiI(int n, /* const */ [In] float* a, int inca, float* r, int incr);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdTanpiI")]
        public static extern void TanpiI(int n, /* const */ [In] double* a, int inca, double* r, int incr);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsTanpiI")]
        public static extern void TanpiI(int n, /* const */ [In] float* a, int inca, float* r, int incr, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdTanpiI")]
        public static extern void TanpiI(int n, /* const */ [In] double* a, int inca, double* r, int incr, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsAcosI")]
        public static extern void AcosI(int n, /* const */ [In] float* a, int inca, float* r, int incr);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdAcosI")]
        public static extern void AcosI(int n, /* const */ [In] double* a, int inca, double* r, int incr);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsAcosI")]
        public static extern void AcosI(int n, /* const */ [In] float* a, int inca, float* r, int incr, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdAcosI")]
        public static extern void AcosI(int n, /* const */ [In] double* a, int inca, double* r, int incr, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsAcospiI")]
        public static extern void AcospiI(int n, /* const */ [In] float* a, int inca, float* r, int incr);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdAcospiI")]
        public static extern void AcospiI(int n, /* const */ [In] double* a, int inca, double* r, int incr);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsAcospiI")]
        public static extern void AcospiI(int n, /* const */ [In] float* a, int inca, float* r, int incr, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdAcospiI")]
        public static extern void AcospiI(int n, /* const */ [In] double* a, int inca, double* r, int incr, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsAsinI")]
        public static extern void AsinI(int n, /* const */ [In] float* a, int inca, float* r, int incr);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdAsinI")]
        public static extern void AsinI(int n, /* const */ [In] double* a, int inca, double* r, int incr);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsAsinI")]
        public static extern void AsinI(int n, /* const */ [In] float* a, int inca, float* r, int incr, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdAsinI")]
        public static extern void AsinI(int n, /* const */ [In] double* a, int inca, double* r, int incr, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsAsinpiI")]
        public static extern void AsinpiI(int n, /* const */ [In] float* a, int inca, float* r, int incr);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdAsinpiI")]
        public static extern void AsinpiI(int n, /* const */ [In] double* a, int inca, double* r, int incr);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsAsinpiI")]
        public static extern void AsinpiI(int n, /* const */ [In] float* a, int inca, float* r, int incr, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdAsinpiI")]
        public static extern void AsinpiI(int n, /* const */ [In] double* a, int inca, double* r, int incr, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsAtanI")]
        public static extern void AtanI(int n, /* const */ [In] float* a, int inca, float* r, int incr);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdAtanI")]
        public static extern void AtanI(int n, /* const */ [In] double* a, int inca, double* r, int incr);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsAtanI")]
        public static extern void AtanI(int n, /* const */ [In] float* a, int inca, float* r, int incr, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdAtanI")]
        public static extern void AtanI(int n, /* const */ [In] double* a, int inca, double* r, int incr, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsAtanpiI")]
        public static extern void AtanpiI(int n, /* const */ [In] float* a, int inca, float* r, int incr);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdAtanpiI")]
        public static extern void AtanpiI(int n, /* const */ [In] double* a, int inca, double* r, int incr);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsAtanpiI")]
        public static extern void AtanpiI(int n, /* const */ [In] float* a, int inca, float* r, int incr, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdAtanpiI")]
        public static extern void AtanpiI(int n, /* const */ [In] double* a, int inca, double* r, int incr, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsAcoshI")]
        public static extern void AcoshI(int n, /* const */ [In] float* a, int inca, float* r, int incr);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdAcoshI")]
        public static extern void AcoshI(int n, /* const */ [In] double* a, int inca, double* r, int incr);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsAcoshI")]
        public static extern void AcoshI(int n, /* const */ [In] float* a, int inca, float* r, int incr, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdAcoshI")]
        public static extern void AcoshI(int n, /* const */ [In] double* a, int inca, double* r, int incr, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsAsinhI")]
        public static extern void AsinhI(int n, /* const */ [In] float* a, int inca, float* r, int incr);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdAsinhI")]
        public static extern void AsinhI(int n, /* const */ [In] double* a, int inca, double* r, int incr);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsAsinhI")]
        public static extern void AsinhI(int n, /* const */ [In] float* a, int inca, float* r, int incr, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdAsinhI")]
        public static extern void AsinhI(int n, /* const */ [In] double* a, int inca, double* r, int incr, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsAtanhI")]
        public static extern void AtanhI(int n, /* const */ [In] float* a, int inca, float* r, int incr);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdAtanhI")]
        public static extern void AtanhI(int n, /* const */ [In] double* a, int inca, double* r, int incr);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsAtanhI")]
        public static extern void AtanhI(int n, /* const */ [In] float* a, int inca, float* r, int incr, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdAtanhI")]
        public static extern void AtanhI(int n, /* const */ [In] double* a, int inca, double* r, int incr, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsErfI")]
        public static extern void ErfI(int n, /* const */ [In] float* a, int inca, float* r, int incr);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdErfI")]
        public static extern void ErfI(int n, /* const */ [In] double* a, int inca, double* r, int incr);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsErfI")]
        public static extern void ErfI(int n, /* const */ [In] float* a, int inca, float* r, int incr, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdErfI")]
        public static extern void ErfI(int n, /* const */ [In] double* a, int inca, double* r, int incr, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsErfInvI")]
        public static extern void ErfInvI(int n, /* const */ [In] float* a, int inca, float* r, int incr);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdErfInvI")]
        public static extern void ErfInvI(int n, /* const */ [In] double* a, int inca, double* r, int incr);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsErfInvI")]
        public static extern void ErfInvI(int n, /* const */ [In] float* a, int inca, float* r, int incr, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdErfInvI")]
        public static extern void ErfInvI(int n, /* const */ [In] double* a, int inca, double* r, int incr, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsHypotI")]
        public static extern void HypotI(int n, /* const */ [In] float* a, int inca, /* const */ [In] float* b, int incb, float* r, int incr);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdHypotI")]
        public static extern void HypotI(int n, /* const */ [In] double* a, int inca, /* const */ [In] double* b, int incb, double* r, int incr);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsHypotI")]
        public static extern void HypotI(int n, /* const */ [In] float* a, int inca, /* const */ [In] float* b, int incb, float* r, int incr, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdHypotI")]
        public static extern void HypotI(int n, /* const */ [In] double* a, int inca, /* const */ [In] double* b, int incb, double* r, int incr, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsErfcI")]
        public static extern void ErfcI(int n, /* const */ [In] float* a, int inca, float* r, int incr);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdErfcI")]
        public static extern void ErfcI(int n, /* const */ [In] double* a, int inca, double* r, int incr);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsErfcI")]
        public static extern void ErfcI(int n, /* const */ [In] float* a, int inca, float* r, int incr, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdErfcI")]
        public static extern void ErfcI(int n, /* const */ [In] double* a, int inca, double* r, int incr, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsErfcInvI")]
        public static extern void ErfcInvI(int n, /* const */ [In] float* a, int inca, float* r, int incr);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdErfcInvI")]
        public static extern void ErfcInvI(int n, /* const */ [In] double* a, int inca, double* r, int incr);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsErfcInvI")]
        public static extern void ErfcInvI(int n, /* const */ [In] float* a, int inca, float* r, int incr, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdErfcInvI")]
        public static extern void ErfcInvI(int n, /* const */ [In] double* a, int inca, double* r, int incr, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsCdfNormI")]
        public static extern void CdfNormI(int n, /* const */ [In] float* a, int inca, float* r, int incr);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdCdfNormI")]
        public static extern void CdfNormI(int n, /* const */ [In] double* a, int inca, double* r, int incr);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsCdfNormI")]
        public static extern void CdfNormI(int n, /* const */ [In] float* a, int inca, float* r, int incr, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdCdfNormI")]
        public static extern void CdfNormI(int n, /* const */ [In] double* a, int inca, double* r, int incr, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsCdfNormInvI")]
        public static extern void CdfNormInvI(int n, /* const */ [In] float* a, int inca, float* r, int incr);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdCdfNormInvI")]
        public static extern void CdfNormInvI(int n, /* const */ [In] double* a, int inca, double* r, int incr);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsCdfNormInvI")]
        public static extern void CdfNormInvI(int n, /* const */ [In] float* a, int inca, float* r, int incr, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdCdfNormInvI")]
        public static extern void CdfNormInvI(int n, /* const */ [In] double* a, int inca, double* r, int incr, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsLGammaI")]
        public static extern void LGammaI(int n, /* const */ [In] float* a, int inca, float* r, int incr);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdLGammaI")]
        public static extern void LGammaI(int n, /* const */ [In] double* a, int inca, double* r, int incr);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsLGammaI")]
        public static extern void LGammaI(int n, /* const */ [In] float* a, int inca, float* r, int incr, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdLGammaI")]
        public static extern void LGammaI(int n, /* const */ [In] double* a, int inca, double* r, int incr, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsTGammaI")]
        public static extern void TGammaI(int n, /* const */ [In] float* a, int inca, float* r, int incr);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdTGammaI")]
        public static extern void TGammaI(int n, /* const */ [In] double* a, int inca, double* r, int incr);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsTGammaI")]
        public static extern void TGammaI(int n, /* const */ [In] float* a, int inca, float* r, int incr, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdTGammaI")]
        public static extern void TGammaI(int n, /* const */ [In] double* a, int inca, double* r, int incr, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsAtan2I")]
        public static extern void Atan2I(int n, /* const */ [In] float* a, int inca, /* const */ [In] float* b, int incb, float* r, int incr);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdAtan2I")]
        public static extern void Atan2I(int n, /* const */ [In] double* a, int inca, /* const */ [In] double* b, int incb, double* r, int incr);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsAtan2I")]
        public static extern void Atan2I(int n, /* const */ [In] float* a, int inca, /* const */ [In] float* b, int incb, float* r, int incr, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdAtan2I")]
        public static extern void Atan2I(int n, /* const */ [In] double* a, int inca, /* const */ [In] double* b, int incb, double* r, int incr, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsAtan2piI")]
        public static extern void Atan2piI(int n, /* const */ [In] float* a, int inca, /* const */ [In] float* b, int incb, float* r, int incr);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdAtan2piI")]
        public static extern void Atan2piI(int n, /* const */ [In] double* a, int inca, /* const */ [In] double* b, int incb, double* r, int incr);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsAtan2piI")]
        public static extern void Atan2piI(int n, /* const */ [In] float* a, int inca, /* const */ [In] float* b, int incb, float* r, int incr, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdAtan2piI")]
        public static extern void Atan2piI(int n, /* const */ [In] double* a, int inca, /* const */ [In] double* b, int incb, double* r, int incr, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsMulI")]
        public static extern void MulI(int n, /* const */ [In] float* a, int inca, /* const */ [In] float* b, int incb, float* r, int incr);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdMulI")]
        public static extern void MulI(int n, /* const */ [In] double* a, int inca, /* const */ [In] double* b, int incb, double* r, int incr);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsMulI")]
        public static extern void MulI(int n, /* const */ [In] float* a, int inca, /* const */ [In] float* b, int incb, float* r, int incr, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdMulI")]
        public static extern void MulI(int n, /* const */ [In] double* a, int inca, /* const */ [In] double* b, int incb, double* r, int incr, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsDivI")]
        public static extern void DivI(int n, /* const */ [In] float* a, int inca, /* const */ [In] float* b, int incb, float* r, int incr);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdDivI")]
        public static extern void DivI(int n, /* const */ [In] double* a, int inca, /* const */ [In] double* b, int incb, double* r, int incr);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsDivI")]
        public static extern void DivI(int n, /* const */ [In] float* a, int inca, /* const */ [In] float* b, int incb, float* r, int incr, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdDivI")]
        public static extern void DivI(int n, /* const */ [In] double* a, int inca, /* const */ [In] double* b, int incb, double* r, int incr, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsFdimI")]
        public static extern void FdimI(int n, /* const */ [In] float* a, int inca, /* const */ [In] float* b, int incb, float* r, int incr);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdFdimI")]
        public static extern void FdimI(int n, /* const */ [In] double* a, int inca, /* const */ [In] double* b, int incb, double* r, int incr);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsFdimI")]
        public static extern void FdimI(int n, /* const */ [In] float* a, int inca, /* const */ [In] float* b, int incb, float* r, int incr, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdFdimI")]
        public static extern void FdimI(int n, /* const */ [In] double* a, int inca, /* const */ [In] double* b, int incb, double* r, int incr, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsFmodI")]
        public static extern void FmodI(int n, /* const */ [In] float* a, int inca, /* const */ [In] float* b, int incb, float* r, int incr);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdFmodI")]
        public static extern void FmodI(int n, /* const */ [In] double* a, int inca, /* const */ [In] double* b, int incb, double* r, int incr);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsFmodI")]
        public static extern void FmodI(int n, /* const */ [In] float* a, int inca, /* const */ [In] float* b, int incb, float* r, int incr, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdFmodI")]
        public static extern void FmodI(int n, /* const */ [In] double* a, int inca, /* const */ [In] double* b, int incb, double* r, int incr, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsFmaxI")]
        public static extern void FmaxI(int n, /* const */ [In] float* a, int inca, /* const */ [In] float* b, int incb, float* r, int incr);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdFmaxI")]
        public static extern void FmaxI(int n, /* const */ [In] double* a, int inca, /* const */ [In] double* b, int incb, double* r, int incr);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsFmaxI")]
        public static extern void FmaxI(int n, /* const */ [In] float* a, int inca, /* const */ [In] float* b, int incb, float* r, int incr, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdFmaxI")]
        public static extern void FmaxI(int n, /* const */ [In] double* a, int inca, /* const */ [In] double* b, int incb, double* r, int incr, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsFminI")]
        public static extern void FminI(int n, /* const */ [In] float* a, int inca, /* const */ [In] float* b, int incb, float* r, int incr);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdFminI")]
        public static extern void FminI(int n, /* const */ [In] double* a, int inca, /* const */ [In] double* b, int incb, double* r, int incr);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsFminI")]
        public static extern void FminI(int n, /* const */ [In] float* a, int inca, /* const */ [In] float* b, int incb, float* r, int incr, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdFminI")]
        public static extern void FminI(int n, /* const */ [In] double* a, int inca, /* const */ [In] double* b, int incb, double* r, int incr, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsPowI")]
        public static extern void PowI(int n, /* const */ [In] float* a, int inca, /* const */ [In] float* b, int incb, float* r, int incr);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdPowI")]
        public static extern void PowI(int n, /* const */ [In] double* a, int inca, /* const */ [In] double* b, int incb, double* r, int incr);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsPowI")]
        public static extern void PowI(int n, /* const */ [In] float* a, int inca, /* const */ [In] float* b, int incb, float* r, int incr, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdPowI")]
        public static extern void PowI(int n, /* const */ [In] double* a, int inca, /* const */ [In] double* b, int incb, double* r, int incr, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsPowrI")]
        public static extern void PowrI(int n, /* const */ [In] float* a, int inca, /* const */ [In] float* b, int incb, float* r, int incr);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdPowrI")]
        public static extern void PowrI(int n, /* const */ [In] double* a, int inca, /* const */ [In] double* b, int incb, double* r, int incr);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsPowrI")]
        public static extern void PowrI(int n, /* const */ [In] float* a, int inca, /* const */ [In] float* b, int incb, float* r, int incr, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdPowrI")]
        public static extern void PowrI(int n, /* const */ [In] double* a, int inca, /* const */ [In] double* b, int incb, double* r, int incr, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsPow3o2I")]
        public static extern void Pow3o2I(int n, /* const */ [In] float* a, int inca, float* r, int incr);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdPow3o2I")]
        public static extern void Pow3o2I(int n, /* const */ [In] double* a, int inca, double* r, int incr);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsPow3o2I")]
        public static extern void Pow3o2I(int n, /* const */ [In] float* a, int inca, float* r, int incr, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdPow3o2I")]
        public static extern void Pow3o2I(int n, /* const */ [In] double* a, int inca, double* r, int incr, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsPow2o3I")]
        public static extern void Pow2o3I(int n, /* const */ [In] float* a, int inca, float* r, int incr);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdPow2o3I")]
        public static extern void Pow2o3I(int n, /* const */ [In] double* a, int inca, double* r, int incr);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsPow2o3I")]
        public static extern void Pow2o3I(int n, /* const */ [In] float* a, int inca, float* r, int incr, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdPow2o3I")]
        public static extern void Pow2o3I(int n, /* const */ [In] double* a, int inca, double* r, int incr, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsPowxI")]
        public static extern void PowxI(int n, /* const */ [In] float* a, int inca, float b, float* r, int incr);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdPowxI")]
        public static extern void PowxI(int n, /* const */ [In] double* a, int inca, double b, double* r, int incr);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsPowxI")]
        public static extern void PowxI(int n, /* const */ [In] float* a, int inca, float b, float* r, int incr, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdPowxI")]
        public static extern void PowxI(int n, /* const */ [In] double* a, int inca, double b, double* r, int incr, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsSinCosI")]
        public static extern void SinCosI(int n, /* const */ [In] float* a, int inca, float* r1, int incr1, float* r2, int incr2);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdSinCosI")]
        public static extern void SinCosI(int n, /* const */ [In] double* a, int inca, double* r1, int incr1, double* r2, int incr2);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsSinCosI")]
        public static extern void SinCosI(int n, /* const */ [In] float* a, int inca, float* r1, int incr1, float* r2, int incr2, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdSinCosI")]
        public static extern void SinCosI(int n, /* const */ [In] double* a, int inca, double* r1, int incr1, double* r2, int incr2, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsLinearFracI")]
        public static extern void LinearFracI(int n, /* const */ [In] float* a, int inca, /* const */ [In] float* b, int incb, float scalea, float shifta, float scaleb, float shiftb, float* r, int incr);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdLinearFracI")]
        public static extern void LinearFracI(int n, /* const */ [In] double* a, int inca, /* const */ [In] double* b, int incb, double scalea, double shifta, double scaleb, double shiftb, double* r, int incr);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsLinearFracI")]
        public static extern void LinearFracI(int n, /* const */ [In] float* a, int inca, /* const */ [In] float* b, int incb, float scalea, float shifta, float scaleb, float shiftb, float* r, int incr, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdLinearFracI")]
        public static extern void LinearFracI(int n, /* const */ [In] double* a, int inca, /* const */ [In] double* b, int incb, double scalea, double shifta, double scaleb, double shiftb, double* r, int incr, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsCeilI")]
        public static extern void CeilI(int n, /* const */ [In] float* a, int inca, float* r, int incr);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdCeilI")]
        public static extern void CeilI(int n, /* const */ [In] double* a, int inca, double* r, int incr);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsCeilI")]
        public static extern void CeilI(int n, /* const */ [In] float* a, int inca, float* r, int incr, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdCeilI")]
        public static extern void CeilI(int n, /* const */ [In] double* a, int inca, double* r, int incr, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsFloorI")]
        public static extern void FloorI(int n, /* const */ [In] float* a, int inca, float* r, int incr);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdFloorI")]
        public static extern void FloorI(int n, /* const */ [In] double* a, int inca, double* r, int incr);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsFloorI")]
        public static extern void FloorI(int n, /* const */ [In] float* a, int inca, float* r, int incr, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdFloorI")]
        public static extern void FloorI(int n, /* const */ [In] double* a, int inca, double* r, int incr, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsFracI")]
        public static extern void FracI(int n, /* const */ [In] float* a, int inca, float* r, int incr);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdFracI")]
        public static extern void FracI(int n, /* const */ [In] double* a, int inca, double* r, int incr);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsFracI")]
        public static extern void FracI(int n, /* const */ [In] float* a, int inca, float* r, int incr, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdFracI")]
        public static extern void FracI(int n, /* const */ [In] double* a, int inca, double* r, int incr, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsModfI")]
        public static extern void ModfI(int n, /* const */ [In] float* a, int inca, float* r1, int incr1, float* r2, int incr2);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdModfI")]
        public static extern void ModfI(int n, /* const */ [In] double* a, int inca, double* r1, int incr1, double* r2, int incr2);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsModfI")]
        public static extern void ModfI(int n, /* const */ [In] float* a, int inca, float* r1, int incr1, float* r2, int incr2, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdModfI")]
        public static extern void ModfI(int n, /* const */ [In] double* a, int inca, double* r1, int incr1, double* r2, int incr2, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsNearbyIntI")]
        public static extern void NearbyIntI(int n, /* const */ [In] float* a, int inca, float* r, int incr);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdNearbyIntI")]
        public static extern void NearbyIntI(int n, /* const */ [In] double* a, int inca, double* r, int incr);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsNearbyIntI")]
        public static extern void NearbyIntI(int n, /* const */ [In] float* a, int inca, float* r, int incr, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdNearbyIntI")]
        public static extern void NearbyIntI(int n, /* const */ [In] double* a, int inca, double* r, int incr, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsNextAfterI")]
        public static extern void NextAfterI(int n, /* const */ [In] float* a, int inca, /* const */ [In] float* b, int incb, float* r, int incr);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdNextAfterI")]
        public static extern void NextAfterI(int n, /* const */ [In] double* a, int inca, /* const */ [In] double* b, int incb, double* r, int incr);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsNextAfterI")]
        public static extern void NextAfterI(int n, /* const */ [In] float* a, int inca, /* const */ [In] float* b, int incb, float* r, int incr, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdNextAfterI")]
        public static extern void NextAfterI(int n, /* const */ [In] double* a, int inca, /* const */ [In] double* b, int incb, double* r, int incr, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsMinMagI")]
        public static extern void MinMagI(int n, /* const */ [In] float* a, int inca, /* const */ [In] float* b, int incb, float* r, int incr);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdMinMagI")]
        public static extern void MinMagI(int n, /* const */ [In] double* a, int inca, /* const */ [In] double* b, int incb, double* r, int incr);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsMinMagI")]
        public static extern void MinMagI(int n, /* const */ [In] float* a, int inca, /* const */ [In] float* b, int incb, float* r, int incr, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdMinMagI")]
        public static extern void MinMagI(int n, /* const */ [In] double* a, int inca, /* const */ [In] double* b, int incb, double* r, int incr, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsMaxMagI")]
        public static extern void MaxMagI(int n, /* const */ [In] float* a, int inca, /* const */ [In] float* b, int incb, float* r, int incr);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdMaxMagI")]
        public static extern void MaxMagI(int n, /* const */ [In] double* a, int inca, /* const */ [In] double* b, int incb, double* r, int incr);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsMaxMagI")]
        public static extern void MaxMagI(int n, /* const */ [In] float* a, int inca, /* const */ [In] float* b, int incb, float* r, int incr, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdMaxMagI")]
        public static extern void MaxMagI(int n, /* const */ [In] double* a, int inca, /* const */ [In] double* b, int incb, double* r, int incr, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsRintI")]
        public static extern void RintI(int n, /* const */ [In] float* a, int inca, float* r, int incr);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdRintI")]
        public static extern void RintI(int n, /* const */ [In] double* a, int inca, double* r, int incr);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsRintI")]
        public static extern void RintI(int n, /* const */ [In] float* a, int inca, float* r, int incr, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdRintI")]
        public static extern void RintI(int n, /* const */ [In] double* a, int inca, double* r, int incr, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsRoundI")]
        public static extern void RoundI(int n, /* const */ [In] float* a, int inca, float* r, int incr);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdRoundI")]
        public static extern void RoundI(int n, /* const */ [In] double* a, int inca, double* r, int incr);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsRoundI")]
        public static extern void RoundI(int n, /* const */ [In] float* a, int inca, float* r, int incr, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdRoundI")]
        public static extern void RoundI(int n, /* const */ [In] double* a, int inca, double* r, int incr, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsTruncI")]
        public static extern void TruncI(int n, /* const */ [In] float* a, int inca, float* r, int incr);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdTruncI")]
        public static extern void TruncI(int n, /* const */ [In] double* a, int inca, double* r, int incr);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsTruncI")]
        public static extern void TruncI(int n, /* const */ [In] float* a, int inca, float* r, int incr, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdTruncI")]
        public static extern void TruncI(int n, /* const */ [In] double* a, int inca, double* r, int incr, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsExpInt1I")]
        public static extern void ExpInt1I(int n, /* const */ [In] float* a, int inca, float* r, int incr);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdExpInt1I")]
        public static extern void ExpInt1I(int n, /* const */ [In] double* a, int inca, double* r, int incr);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsExpInt1I")]
        public static extern void ExpInt1I(int n, /* const */ [In] float* a, int inca, float* r, int incr, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdExpInt1I")]
        public static extern void ExpInt1I(int n, /* const */ [In] double* a, int inca, double* r, int incr, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsCopySignI")]
        public static extern void CopySignI(int n, /* const */ [In] float* a, int inca, /* const */ [In] float* b, int incb, float* r, int incr);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdCopySignI")]
        public static extern void CopySignI(int n, /* const */ [In] double* a, int inca, /* const */ [In] double* b, int incb, double* r, int incr);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsCopySignI")]
        public static extern void CopySignI(int n, /* const */ [In] float* a, int inca, /* const */ [In] float* b, int incb, float* r, int incr, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdCopySignI")]
        public static extern void CopySignI(int n, /* const */ [In] double* a, int inca, /* const */ [In] double* b, int incb, double* r, int incr, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsRemainderI")]
        public static extern void RemainderI(int n, /* const */ [In] float* a, int inca, /* const */ [In] float* b, int incb, float* r, int incr);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdRemainderI")]
        public static extern void RemainderI(int n, /* const */ [In] double* a, int inca, /* const */ [In] double* b, int incb, double* r, int incr);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmsRemainderI")]
        public static extern void RemainderI(int n, /* const */ [In] float* a, int inca, /* const */ [In] float* b, int incb, float* r, int incr, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmdRemainderI")]
        public static extern void RemainderI(int n, /* const */ [In] double* a, int inca, /* const */ [In] double* b, int incb, double* r, int incr, VmlMode mode);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsPackI")]
        public static extern void PackI(int n, /* const */ [In] float* a, int incra, float* y);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdPackI")]
        public static extern void PackI(int n, /* const */ [In] double* a, int incra, double* y);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsPackV")]
        public static extern void PackV(int n, /* const */ [In] float* a, int* ia, float* y);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdPackV")]
        public static extern void PackV(int n, /* const */ [In] double* a, int* ia, double* y);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsPackM")]
        public static extern void PackM(int n, /* const */ [In] float* a, int* ma, float* y);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdPackM")]
        public static extern void PackM(int n, /* const */ [In] double* a, int* ma, double* y);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsUnpackI")]
        public static extern void UnpackI(int n, /* const */ [In] float* a, float* y, int incry);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdUnpackI")]
        public static extern void UnpackI(int n, /* const */ [In] double* a, double* y, int incry);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsUnpackV")]
        public static extern void UnpackV(int n, /* const */ [In] float* a, float* y, int* iy);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdUnpackV")]
        public static extern void UnpackV(int n, /* const */ [In] double* a, double* y, int* iy);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vsUnpackM")]
        public static extern void UnpackM(int n, /* const */ [In] float* a, float* y, int* my);
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vdUnpackM")]
        public static extern void UnpackM(int n, /* const */ [In] double* a, double* y, int* my);
    }

    // These are not unsafe

    [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmlSetErrStatus")]
    public static extern VmlStatus SetErrStatus(VmlStatus status);
    [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmlGetErrStatus")]
    public static extern VmlStatus GetErrStatus();
    [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmlClearErrStatus")]
    public static extern VmlStatus ClearErrStatus();
    [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmlSetMode")]
    public static extern VmlMode SetMode(VmlMode newmode);
    [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "vmlGetMode")]
    public static extern VmlMode GetMode();

    // Special versions that take a scalar b
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Fmax(int n, double[] a, int inia, int inca, double b, double[] r, int inir, int incr)
    {
        unsafe
        {
            fixed (double* ap = &a[inia])
            fixed (double* rp = &r[inir])
                Unsafe.FmaxI(n, ap, inca, &b, 0, rp, incr);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Fmin(int n, double[] a, int inia, int inca, double b, double[] r, int inir, int incr)
    {
        unsafe
        {
            fixed (double* ap = &a[inia])
            fixed (double* rp = &r[inir])
                Unsafe.FminI(n, ap, inca, &b, 0, rp, incr);
        }
    }
}