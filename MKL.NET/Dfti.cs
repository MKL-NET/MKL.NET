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
using System.Numerics;
using System.Security;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;

namespace MKLNET
{
    [SuppressUnmanagedCodeSecurity]
    public static class Dfti
    {
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static unsafe extern IntPtr DftiErrorMessage(long status);
        public static string ErrorMessage(long status)
            => Marshal.PtrToStringAnsi(DftiErrorMessage(status));

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern long DftiErrorClass(long status, DftiErrorClass error_class);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long ErrorClass(long status, DftiErrorClass error_class)
            => DftiErrorClass(status, error_class);

        [DllImport(MKL.NATIVE_DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern long ComputeForwardInplace(int n, [In, Out] Complex[] x_inout);
        public static long ComputeForward(Complex[] x_inout)
            => ComputeForwardInplace(x_inout.Length, x_inout);

        [DllImport(MKL.NATIVE_DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern long ComputeForwardReal(int n, [In] double[] x_in, [Out] Complex[] y_out);
        public static long ComputeForward(double[] x_in, Complex[] y_out)
            => ComputeForwardReal(x_in.Length, x_in, y_out);

        [DllImport(MKL.NATIVE_DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern long ComputeForward(int n, [In] Complex[] x_in, [Out] Complex[] y_out);
        public static long ComputeForward(Complex[] x_in, Complex[] y_out)
            => ComputeForward(x_in.Length, x_in, y_out);

        [DllImport(MKL.NATIVE_DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern long ComputeForwardScaleInplace(int n, [In, Out] Complex[] x_inout, double scale);
        public static long ComputeForward(Complex[] x_inout, double scale)
            => ComputeForwardScaleInplace(x_inout.Length, x_inout, scale);

        [DllImport(MKL.NATIVE_DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern long ComputeForwardScaleReal(int n, [In] double[] x_in, [Out] Complex[] y_out, double scale);
        public static long ComputeForward(double[] x_in, Complex[] y_out, double scale)
            => ComputeForwardScaleReal(x_in.Length, x_in, y_out, scale);

        [DllImport(MKL.NATIVE_DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern long ComputeForwardScale(int n, [In] Complex[] x_in, [Out] Complex[] y_out, double scale);
        public static long ComputeForward(Complex[] x_in, Complex[] y_out, double scale)
            => ComputeForwardScale(x_in.Length, x_in, y_out, scale);

        [DllImport(MKL.NATIVE_DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern long ComputeBackward(int n, [In] Complex[] x, [Out] Complex[] y);
        public static long ComputeBackward(Complex[] x_in, Complex[] y_out)
            => ComputeBackward(x_in.Length, x_in, y_out);

        [DllImport(MKL.NATIVE_DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern long ComputeBackwardInplace(int n, [In, Out] Complex[] x_inout);
        public static long ComputeBackward(Complex[] x_inout)
            => ComputeBackwardInplace(x_inout.Length, x_inout);

        [DllImport(MKL.NATIVE_DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern long ComputeBackwardScale(int n, [In] Complex[] x, [Out] Complex[] y, double scale);
        public static long ComputeBackward(Complex[] x_in, Complex[] y_out, double scale)
            => ComputeBackwardScale(x_in.Length, x_in, y_out, scale);

        [DllImport(MKL.NATIVE_DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern long ComputeBackwardScaleInplace(int n, [In, Out] Complex[] x_inout, double scale);
        public static long ComputeBackward(Complex[] x_inout, double scale)
            => ComputeBackwardScaleInplace(x_inout.Length, x_inout, scale);
    }
}