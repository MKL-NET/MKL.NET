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

[SuppressUnmanagedCodeSecurity]
public static partial class Feast
{
    public unsafe static class Unsafe
    {
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "feastinit")]
        public static extern void init(int* fpm);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "dfeast_syev")]
        public static extern void syev(ref char uplo, ref int n, /* const */ [In] double* a, ref int lda, int* fpm, ref double epsout, ref int loop, ref double emin, ref double emax, ref int m0, double* e, double* x, ref int m, double* res, ref int info);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "sfeast_syev")]
        public static extern void syev(ref char uplo, ref int n, /* const */ [In] float* a, ref int lda, int* fpm, ref float epsout, ref int loop, ref float emin, ref float emax, ref int m0, float* e, float* x, ref int m, float* res, ref int info);
    }
}