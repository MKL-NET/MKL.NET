using System.Security;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;

namespace MKLNET
{
    [SuppressUnmanagedCodeSecurity]
    public static class Lapack
    {
#if LINUX
        const string DLL = "libmkl_rt.so";
#elif OSX
        const string DLL = "libmkl_rt.dylib";
#else
        const string DLL = "mkl_rt.dll";
#endif

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dpotrf(Layout order, UpLo uplo, int n, double[] a, int lda);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dpotrf(Layout order, UpLo uplo, int n, double[] a, int lda)
        {
            return LAPACKE_dpotrf(order, uplo, n, a, lda);
        }
    }
}