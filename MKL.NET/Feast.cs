// Copyright 2022 Anthony Lloyd
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

using System.Security;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;

namespace MKLNET
{
    [SuppressUnmanagedCodeSecurity]
    public unsafe static class Feast
    {
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void feastinit(int[] fpm);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void init(int[] fpm)
            => feastinit(fpm);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void dfeast_syev(ref char uplo, ref int n, double[] a, ref int lda, int[] fpm, ref double epsout, ref int loop, ref double emin, ref double emax, ref int m0, double[] e, double[] x, ref int m, double[] res, ref int info);
        public static void syev(ref char uplo, ref int n, double[] a, ref int lda, int[] fpm, ref double epsout, ref int loop, ref double emin, ref double emax, ref int m0, double[] e, double[] x, ref int m, double[] res, ref int info)
            => dfeast_syev(ref uplo, ref n, a, ref lda, fpm, ref epsout, ref loop, ref emin, ref emax, ref m0, e, x, ref m, res, ref info);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void sfeast_syev(ref char uplo, ref int n, float[] a, ref int lda, int[] fpm, ref float epsout, ref int loop, ref float emin, ref float emax, ref int m0, float[] e, float[] x, ref int m, float[] res, ref int info);
        public static void syev(ref char uplo, ref int n, float[] a, ref int lda, int[] fpm, ref float epsout, ref int loop, ref float emin, ref float emax, ref int m0, float[] e, float[] x, ref int m, float[] res, ref int info)
            => sfeast_syev(ref uplo, ref n, a, ref lda, fpm, ref epsout, ref loop, ref emin, ref emax, ref m0, e, x, ref m, res, ref info);
    }
}