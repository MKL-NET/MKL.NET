using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;

namespace MKLNET
{
    [SuppressUnmanagedCodeSecurity]
    internal class BlasLinux : IBlas
    {
        const string DLL = "libmkl_rt.so";

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, SetLastError = true)]
        public static extern void cblas_dgemm(Order order, Transpose transA, Transpose transB, int m, int n, int k,
                                   double alpha, double[] a, int lda, double[] b, int ldb,
                                   double beta, double[] c, int ldc);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void dgemm(Order order, Transpose transA, Transpose transB, int m, int n, int k,
            double alpha, double[] A, int lda, double[] B, int ldb,
            double beta, double[] C, int ldc)
        {
            cblas_dgemm(order, transA, transB, m, n, k, alpha, A, lda, B, ldb, beta, C, ldc);
        }
    }
}
