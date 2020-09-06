using System.Security;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;

namespace MKLNET
{
    [SuppressUnmanagedCodeSecurity]
    public static class Blas
    {
#if LINUX
        const string DLL = "libmkl_rt.so";
#elif OSX
        const string DLL = "libmkl_rt.dylib";
#else
        const string DLL = "mkl_rt.dll";
#endif

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void cblas_dgemm(Order order, Transpose transA, Transpose transB, int m, int n, int k,
            double alpha, double[] a, int lda, double[] b, int ldb,
            double beta, double[] c, int ldc);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void dgemm(Order order, Transpose transA, Transpose transB, int m, int n, int k,
            double alpha, double[] A, int lda, double[] B, int ldb,
            double beta, double[] C, int ldc)
        {
            cblas_dgemm(order, transA, transB, m, n, k, alpha, A, lda, B, ldb, beta, C, ldc);
        }
    }
}
