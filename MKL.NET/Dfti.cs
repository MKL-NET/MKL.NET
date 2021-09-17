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
        static extern long DftiCopyDescriptor(DftiDescriptor original, out DftiDescriptor copy);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long CopyDescriptor(DftiDescriptor original, out DftiDescriptor copy)
            => DftiCopyDescriptor(original, out copy);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern long DftiCommitDescriptor(DftiDescriptor handle);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long CommitDescriptor(DftiDescriptor handle)
            => DftiCommitDescriptor(handle);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern long DftiFreeDescriptor(ref DftiDescriptor handle);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long FreeDescriptor(DftiDescriptor handle)
            => DftiFreeDescriptor(ref handle);

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
        static extern long ComputeForwardInplace(int n, [In, Out] Complex[] x);
        public static long ComputeForwardInplace(Complex[] x)
            => ComputeForwardInplace(x.Length, x);

        [DllImport(MKL.NATIVE_DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern long ComputeForwardReal(int n, [In] double[] x, [Out] Complex[] y);
        public static Complex[] ComputeForward(double[] x, out long status)
        {
            var r = new Complex[x.Length];
            status = ComputeForwardReal(x.Length, x, r);
            return r;
        }

        [DllImport(MKL.NATIVE_DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern long ComputeForward(int n, [In] Complex[] x, [Out] Complex[] y);
        public static Complex[] ComputeForward(Complex[] x, out long status)
        {
            var r = new Complex[x.Length];
            status = ComputeForward(x.Length, x, r);
            return r;
        }

        [DllImport(MKL.NATIVE_DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern long ComputeBackward(int n, [In] Complex[] x, [Out] Complex[] y);
        public static Complex[] ComputeBackward(Complex[] x, out long status)
        {
            var r = new Complex[x.Length];
            status = ComputeBackward(x.Length, x, r);
            return r;
        }

        [DllImport(MKL.NATIVE_DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern long ComputeBackwardInplace(int n, [In, Out] Complex[] x);
        public static long ComputeBackwardInplace(Complex[] x)
            => ComputeBackwardInplace(x.Length, x);

        [DllImport(MKL.NATIVE_DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern double test_asum(int n, double[] x, int step);
        public static double Test_asum(double[] x)
            => test_asum(x.Length, x, 1);
    }
}