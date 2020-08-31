using System.Security;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;

namespace MKLNET
{
    [SuppressUnmanagedCodeSecurity]
    internal class LapackLinux : ILapack
    {
        const string DLL = "libmkl_rt.so";

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dpotrf(Order order, UpLo uplo, int n, double[] a, int lda);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int dpotrf(Order order, UpLo uplo, int n, double[] a, int lda)
        {
            return LAPACKE_dpotrf(order, uplo, n, a, lda);
        }
    }
}