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
        static extern DfdiStatus DftiCopyDescriptor(DftiDescriptor original, out DftiDescriptor copy);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DfdiStatus CopyDescriptor(DftiDescriptor original, out DftiDescriptor copy)
            => DftiCopyDescriptor(original, out copy);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern DfdiStatus DftiCommitDescriptor(DftiDescriptor handle);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DfdiStatus CommitDescriptor(DftiDescriptor handle)
            => DftiCommitDescriptor(handle);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern DfdiStatus DftiFreeDescriptor(ref DftiDescriptor handle);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DfdiStatus FreeDescriptor(DftiDescriptor handle)
            => DftiFreeDescriptor(ref handle);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static unsafe extern IntPtr DftiErrorMessage(long status);
        public static string ErrorMessage(long status) => Marshal.PtrToStringAnsi(DftiErrorMessage(status));

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern DfdiStatus DftiErrorClass(DfdiStatus status, DftiErrorClass error_class);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DfdiStatus ErrorClass(DfdiStatus status, DftiErrorClass error_class)
            => DftiErrorClass(status, error_class);

        [DllImport(MKL.NATIVE_DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern long ComputeForwardInplace(long n, [In, Out] Complex[] x);
        public static long ComputeForwardInplace(Complex[] x) => ComputeForwardInplace(x.Length, x);

        [DllImport(MKL.NATIVE_DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern long ComputeForwardReal(long n, [In] double[] x, [Out] Complex[] y);
        public static Complex[] ComputeForward(double[] x)
        {
            var r = new Complex[x.Length];
            var status = ComputeForwardReal(x.Length, x, r);
            if (0 != status) throw new Exception("status = " + status);
            return r;
        }

        [DllImport(MKL.NATIVE_DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern long ComputeForward(long n, [In] Complex[] x, [Out] Complex[] y);
        public static Complex[] ComputeForward(Complex[] x)
        {
            var r = new Complex[x.Length];
            var status = ComputeForward(x.Length, x, r);
            if (0 != status) throw new System.Exception("status = " + status);
            return r;
        }

        [DllImport(MKL.NATIVE_DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern long ComputeBackward(long n, [In] Complex[] x, [Out] Complex[] y);
        public static Complex[] ComputeBackward(Complex[] x)
        {
            var r = new Complex[x.Length];
            var status = ComputeBackward(x.Length, x, r);
            if (0 != status) throw new System.Exception("status = " + status);
            return r;
        }

        [DllImport(MKL.NATIVE_DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern long ComputeBackwardInplace(long n, [In, Out] Complex[] x);
        public static long ComputeBackwardInplace(Complex[] x) => ComputeBackwardInplace(x.Length, x);

        [DllImport(MKL.NATIVE_DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern double test_asum(int n, double[] x, int step);
        public static double Test_asum(double[] x) => test_asum(x.Length, x, 1);
    }
}