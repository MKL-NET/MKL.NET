using System.Security;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;

namespace MKLNET
{
    [SuppressUnmanagedCodeSecurity]
    public unsafe static class Blas
    {
#if LINUX
        const string DLL = "libmkl_rt.so";
#elif OSX
        const string DLL = "libmkl_rt.dylib";
#else
        const string DLL = "mkl_rt.dll";
#endif

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern float cblas_sdot(int N, float* X, int incX, float* Y, int incY);
        public static float dot(int N, float[] X, int iniX, int incX, float[] Y, int iniY, int incY)
        {
            fixed (float* xp = &X[iniX])
            fixed (float* yp = &Y[iniY])
                return cblas_sdot(N, xp, incX, yp, incY);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float dot(float[] X, float[] Y)
            => dot(X.Length, X, 0, 1, Y, 0, 1);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern float cblas_sdoti(int N, float[] X, int[] indx, float[] Y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float sdoti(int N, float[] X, int[] indx, float[] Y)
            => cblas_sdoti(N, X, indx, Y);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern double cblas_ddot(int N, double* X, int incX, double* Y, int incY);
        public static double dot(int N, double[] X, int iniX, int incX, double[] Y, int iniY, int incY)
        {
            fixed (double* xp = &X[iniX])
            fixed (double* yp = &Y[iniY])
                return cblas_ddot(N, xp, incX, yp, incY);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double dot(double[] X, double[] Y)
            => dot(X.Length, X, 0, 1, Y, 0, 1);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern double cblas_ddoti(int N, double[] X, int[] indx, double[] Y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double ddoti(int N, double[] X, int[] indx, double[] Y)
            => cblas_ddoti(N, X, indx, Y);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern double cblas_dsdot(int N, float[] X, int incX, float[] Y, int incY);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double dsdot(int N, float[] X, int incX, float[] Y, int incY)
            => cblas_dsdot(N, X, incX, Y, incY);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern float cblas_sdsdot(int N, float sb, float[] X, int incX, float[] Y, int incY);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float sdsdot(int N, float sb, float[] X, int incX, float[] Y, int incY)
            => cblas_sdsdot(N, sb, X, incX, Y, incY);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern float cblas_snrm2(int N, float[] X, int incX);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float snrm2(int N, float[] X, int incX)
            => cblas_snrm2(N, X, incX);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern float cblas_sasum(int N, float* X, int incX);
        public static float asum(int N, float[] X, int iniX, int incX)
        {
            fixed (float* xp = &X[iniX])
            {
                return cblas_sasum(N, xp, incX);
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float asum(float[] X)
            => asum(X.Length, X, 0, 1);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern double cblas_dnrm2(int N, double[] X, int incX);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double dnrm2(int N, double[] X, int incX)
            => cblas_dnrm2(N, X, incX);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern double cblas_dasum(int N, double* X, int incX);
        public static double asum(int N, double[] X, int iniX, int incX)
        {
            fixed (double* xp = &X[iniX])
            {
                return cblas_dasum(N, xp, incX);
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double asum(double[] X)
            => asum(X.Length, X, 0, 1);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int cblas_isamax(int N, float[] X, int incX);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int isamax(int N, float[] X, int incX)
            => cblas_isamax(N, X, incX);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int cblas_idamax(int N, double[] X, int incX);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int idamax(int N, double[] X, int incX)
            => cblas_idamax(N, X, incX);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int cblas_isamin(int N, float[] X, int incX);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int isamin(int N, float[] X, int incX)
            => cblas_isamin(N, X, incX);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int cblas_idamin(int N, double[] X, int incX);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int idamin(int N, double[] X, int incX)
            => cblas_idamin(N, X, incX);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void cblas_sswap(int N, float[] X, int incX, float[] Y, int incY);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void sswap(int N, float[] X, int incX, float[] Y, int incY)
            => cblas_sswap(N, X, incX, Y, incY);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void cblas_scopy(int N, float* X, int incX, float* Y, int incY);
        public static void copy(int N, float[] X, int iniX, int incX, float[] Y, int iniY, int incY)
        {
            fixed (float* xp = &X[iniX])
            fixed (float* yp = &Y[iniY])
                cblas_scopy(N, xp, incX, yp, incY);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void copy(float[] X, float[] Y)
            => copy(X.Length, X, 0, 1, Y, 0, 1);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void cblas_saxpy(int N, float a, float* X, int incX, float* Y, int incY);
        public static void axpy(int N, float a, float[] X, int iniX, int incX, float[] Y, int iniY, int incY)
        {
            fixed (float* xp = &X[iniX])
            fixed (float* yp = &Y[iniY])
                cblas_saxpy(N, a, xp, incX, yp, incY);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void axpy(float a, float[] X, float[] Y)
            => axpy(X.Length, a, X, 0, 1, Y, 0, 1);


        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void cblas_saxpby(int N, float alpha, float[] X, int incX, float beta, float[] Y, int incY);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void saxpby(int N, float alpha, float[] X, int incX, float beta, float[] Y, int incY)
            => cblas_saxpby(N, alpha, X, incX, beta, Y, incY);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void cblas_saxpyi(int N, float alpha, float[] X, int[] indx, float[] Y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void saxpyi(int N, float alpha, float[] X, int[] indx, float[] Y)
            => cblas_saxpyi(N, alpha, X, indx, Y);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void cblas_sgthr(int N, float[] Y, float[] X, int[] indx);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void sgthr(int N, float[] Y, float[] X, int[] indx)
            => cblas_sgthr(N, Y, X, indx);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void cblas_sgthrz(int N, float[] Y, float[] X, int[] indx);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void sgthrz(int N, float[] Y, float[] X, int[] indx)
            => cblas_sgthrz(N, Y, X, indx);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void cblas_ssctr(int N, float[] X, int[] indx, float[] Y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ssctr(int N, float[] X, int[] indx, float[] Y)
            => cblas_ssctr(N, X, indx, Y);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void cblas_srotg(float[] a, float[] b, float[] c, float[] s);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void srotg(float[] a, float[] b, float[] c, float[] s)
            => cblas_srotg(a, b, c, s);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void cblas_dswap(int N, double[] X, int incX, double[] Y, int incY);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void dswap(int N, double[] X, int incX, double[] Y, int incY)
            => cblas_dswap(N, X, incX, Y, incY);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void cblas_dcopy(int N, double* X, int incX, double* Y, int incY);
        public static void copy(int N, double[] X, int iniX, int incX, double[] Y, int iniY, int incY)
        {
            fixed (double* xp = &X[iniX])
            fixed (double* yp = &Y[iniY])
                cblas_dcopy(N, xp, incX, yp, incY);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void copy(double[] X, double[] Y)
            => copy(X.Length, X, 0, 1, Y, 0, 1);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void cblas_daxpy(int N, double a, double* X, int incX, double* Y, int incY);
        public static void axpy(int N, double a, double[] X, int iniX, int incX, double[] Y, int iniY, int incY)
        {
            fixed (double* xp = &X[iniX])
            fixed (double* yp = &Y[iniY])
                cblas_daxpy(N, a, xp, incX, yp, incY);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void axpy(double a, double[] X, double[] Y)
            => axpy(X.Length, a, X, 0, 1, Y, 0, 1);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void cblas_daxpby(int N, double alpha, double[] X, int incX, double beta, double[] Y, int incY);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void daxpby(int N, double alpha, double[] X, int incX, double beta, double[] Y, int incY)
            => cblas_daxpby(N, alpha, X, incX, beta, Y, incY);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void cblas_daxpyi(int N, double alpha, double[] X, int[] indx, double[] Y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void daxpyi(int N, double alpha, double[] X, int[] indx, double[] Y)
            => cblas_daxpyi(N, alpha, X, indx, Y);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void cblas_dgthr(int N, double[] Y, double[] X, int[] indx);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void dgthr(int N, double[] Y, double[] X, int[] indx)
            => cblas_dgthr(N, Y, X, indx);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void cblas_dgthrz(int N, double[] Y, double[] X, int[] indx);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void dgthrz(int N, double[] Y, double[] X, int[] indx)
            => cblas_dgthrz(N, Y, X, indx);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void cblas_dsctr(int N, double[] X, int[] indx, double[] Y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void dsctr(int N, double[] X, int[] indx, double[] Y)
            => cblas_dsctr(N, X, indx, Y);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void cblas_drotg(double[] a, double[] b, double[] c, double[] s);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void drotg(double[] a, double[] b, double[] c, double[] s)
            => cblas_drotg(a, b, c, s);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void cblas_srotmg(float[] d1, float[] d2, float[] b1, float b2, float[] P);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void srotmg(float[] d1, float[] d2, float[] b1, float b2, float[] P)
            => cblas_srotmg(d1, d2, b1, b2, P);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void cblas_srot(int N, float[] X, int incX, float[] Y, int incY, float c, float s);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void srot(int N, float[] X, int incX, float[] Y, int incY, float c, float s)
            => cblas_srot(N, X, incX, Y, incY, c, s);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void cblas_sroti(int N, float[] X, int[] indx, float[] Y, float c, float s);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void sroti(int N, float[] X, int[] indx, float[] Y, float c, float s)
            => cblas_sroti(N, X, indx, Y, c, s);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void cblas_srotm(int N, float[] X, int incX, float[] Y, int incY, float[] P);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void srotm(int N, float[] X, int incX, float[] Y, int incY, float[] P)
            => cblas_srotm(N, X, incX, Y, incY, P);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void cblas_drotmg(double[] d1, double[] d2, double[] b1, double b2, double[] P);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void drotmg(double[] d1, double[] d2, double[] b1, double b2, double[] P)
            => cblas_drotmg(d1, d2, b1, b2, P);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void cblas_drot(int N, double[] X, int incX, double[] Y, int incY, double c, double s);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void drot(int N, double[] X, int incX, double[] Y, int incY, double c, double s)
            => cblas_drot(N, X, incX, Y, incY, c, s);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void cblas_drotm(int N, double[] X, int incX, double[] Y, int incY, double[] P);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void drotm(int N, double[] X, int incX, double[] Y, int incY, double[] P)
            => cblas_drotm(N, X, incX, Y, incY, P);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void cblas_droti(int N, double[] X, int[] indx, double[] Y, double c, double s);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void droti(int N, double[] X, int[] indx, double[] Y, double c, double s)
            => cblas_droti(N, X, indx, Y, c, s);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void cblas_sscal(int N, float alpha, float[] X, int incX);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void sscal(int N, float alpha, float[] X, int incX)
            => cblas_sscal(N, alpha, X, incX);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void cblas_dscal(int N, double alpha, double[] X, int incX);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void dscal(int N, double alpha, double[] X, int incX)
            => cblas_dscal(N, alpha, X, incX);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void cblas_sgemv(Layout Layout,
            Transpose TransA, int M, int N,
            float alpha, float[] A, int lda,
            float[] X, int incX, float beta,
            float[] Y, int incY);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void sgemv(Layout Layout,
            Transpose TransA, int M, int N,
            float alpha, float[] A, int lda,
            float[] X, int incX, float beta,
            float[] Y, int incY)
            => cblas_sgemv(Layout, TransA, M, N, alpha, A, lda, X, incX, beta, Y, incY);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void cblas_sgbmv(Layout Layout,
            Transpose TransA, int M, int N,
            int KL, int KU, float alpha,
            float[] A, int lda, float[] X,
            int incX, float beta, float[] Y, int incY);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void sgbmv(Layout Layout,
            Transpose TransA, int M, int N,
            int KL, int KU, float alpha,
            float[] A, int lda, float[] X,
            int incX, float beta, float[] Y, int incY)
            => cblas_sgbmv(Layout, TransA, M, N, KL, KU, alpha, A, lda, X, incX, beta, Y, incY);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void cblas_strmv(Layout Layout, UpLo Uplo,
            Transpose TransA, Diag Diag,
            int N, float[] A, int lda,
            float[] X, int incX);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void strmv(Layout Layout, UpLo Uplo,
            Transpose TransA, Diag Diag,
            int N, float[] A, int lda,
            float[] X, int incX)
            => cblas_strmv(Layout, Uplo, TransA, Diag, N, A, lda, X, incX);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void cblas_stbmv(Layout Layout, UpLo Uplo,
            Transpose TransA, Diag Diag,
            int N, int K, float[] A, int lda,
            float[] X, int incX);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void stbmv(Layout Layout, UpLo Uplo,
            Transpose TransA, Diag Diag,
            int N, int K, float[] A, int lda,
            float[] X, int incX)
            => cblas_stbmv(Layout, Uplo, TransA, Diag, N, K, A, lda, X, incX);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void cblas_stpmv(Layout Layout, UpLo Uplo,
            Transpose TransA, Diag Diag,
            int N, float[] Ap, float[] X, int incX);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void stpmv(Layout Layout, UpLo Uplo,
            Transpose TransA, Diag Diag,
            int N, float[] Ap, float[] X, int incX)
            => cblas_stpmv(Layout, Uplo, TransA, Diag, N, Ap, X, incX);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void cblas_strsv(Layout Layout, UpLo Uplo,
            Transpose TransA, Diag Diag,
            int N, float[] A, int lda, float[] X,
            int incX);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void strsv(Layout Layout, UpLo Uplo,
            Transpose TransA, Diag Diag,
            int N, float[] A, int lda, float[] X,
            int incX)
            => cblas_strsv(Layout, Uplo, TransA, Diag, N, A, lda, X, incX);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void cblas_stbsv(Layout Layout, UpLo Uplo,
            Transpose TransA, Diag Diag,
            int N, int K, float[] A, int lda,
            float[] X, int incX);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void stbsv(Layout Layout, UpLo Uplo,
            Transpose TransA, Diag Diag,
            int N, int K, float[] A, int lda,
            float[] X, int incX)
            => cblas_stbsv(Layout, Uplo, TransA, Diag, N, K, A, lda, X, incX);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void cblas_stpsv(Layout Layout, UpLo Uplo,
            Transpose TransA, Diag Diag,
            int N, float[] Ap, float[] X, int incX);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void stpsv(Layout Layout, UpLo Uplo,
            Transpose TransA, Diag Diag,
            int N, float[] Ap, float[] X, int incX)
            => cblas_stpsv(Layout, Uplo, TransA, Diag, N, Ap, X, incX);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void cblas_dgemv(Layout Layout,
            Transpose TransA, int M, int N,
            double alpha, double[] A, int lda,
            double[] X, int incX, double beta,
            double[] Y, int incY);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void dgemv(Layout Layout,
            Transpose TransA, int M, int N,
            double alpha, double[] A, int lda,
            double[] X, int incX, double beta,
            double[] Y, int incY)
            => cblas_dgemv(Layout, TransA, M, N, alpha, A, lda, X, incX, beta, Y, incY);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void cblas_dgbmv(Layout Layout,
            Transpose TransA, int M, int N,
            int KL, int KU, double alpha,
            double[] A, int lda, double[] X,
            int incX, double beta, double[] Y, int incY);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void dgbmv(Layout Layout,
            Transpose TransA, int M, int N,
            int KL, int KU, double alpha,
            double[] A, int lda, double[] X,
            int incX, double beta, double[] Y, int incY)
            => cblas_dgbmv(Layout, TransA, M, N, KL, KU, alpha, A, lda, X, incX, beta, Y, incY);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void cblas_dtrmv(Layout Layout, UpLo Uplo,
            Transpose TransA, Diag Diag,
            int N, double[] A, int lda,
            double[] X, int incX);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void dtrmv(Layout Layout, UpLo Uplo,
            Transpose TransA, Diag Diag,
            int N, double[] A, int lda,
            double[] X, int incX)
            => cblas_dtrmv(Layout, Uplo, TransA, Diag, N, A, lda, X, incX);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void cblas_dtbmv(Layout Layout, UpLo Uplo,
            Transpose TransA, Diag Diag,
            int N, int K, double[] A, int lda,
            double[] X, int incX);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void dtbmv(Layout Layout, UpLo Uplo,
            Transpose TransA, Diag Diag,
            int N, int K, double[] A, int lda,
            double[] X, int incX)
            => cblas_dtbmv(Layout, Uplo, TransA, Diag, N, K, A, lda, X, incX);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void cblas_dtpmv(Layout Layout, UpLo Uplo,
            Transpose TransA, Diag Diag,
            int N, double[] Ap, double[] X, int incX);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void dtpmv(Layout Layout, UpLo Uplo,
            Transpose TransA, Diag Diag,
            int N, double[] Ap, double[] X, int incX)
            => cblas_dtpmv(Layout, Uplo, TransA, Diag, N, Ap, X, incX);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void cblas_dtrsv(Layout Layout, UpLo Uplo,
            Transpose TransA, Diag Diag,
            int N, double[] A, int lda, double[] X,
            int incX);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void dtrsv(Layout Layout, UpLo Uplo,
            Transpose TransA, Diag Diag,
            int N, double[] A, int lda, double[] X,
            int incX)
            => cblas_dtrsv(Layout, Uplo, TransA, Diag, N, A, lda, X, incX);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void cblas_dtbsv(Layout Layout, UpLo Uplo,
            Transpose TransA, Diag Diag,
            int N, int K, double[] A, int lda,
            double[] X, int incX);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void dtbsv(Layout Layout, UpLo Uplo,
            Transpose TransA, Diag Diag,
            int N, int K, double[] A, int lda,
            double[] X, int incX)
            => cblas_dtbsv(Layout, Uplo, TransA, Diag, N, K, A, lda, X, incX);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void cblas_dtpsv(Layout Layout, UpLo Uplo,
            Transpose TransA, Diag Diag,
            int N, double[] Ap, double[] X, int incX);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void dtpsv(Layout Layout, UpLo Uplo,
            Transpose TransA, Diag Diag,
            int N, double[] Ap, double[] X, int incX)
            => cblas_dtpsv(Layout, Uplo, TransA, Diag, N, Ap, X, incX);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void cblas_ssymv(Layout Layout, UpLo Uplo,
            int N, float alpha, float[] A,
            int lda, float[] X, int incX,
            float beta, float[] Y, int incY);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ssymv(Layout Layout, UpLo Uplo,
            int N, float alpha, float[] A,
            int lda, float[] X, int incX,
            float beta, float[] Y, int incY)
            => cblas_ssymv(Layout, Uplo, N, alpha, A, lda, X, incX, beta, Y, incY);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void cblas_ssbmv(Layout Layout, UpLo Uplo,
            int N, int K, float alpha, float[] A,
            int lda, float[] X, int incX,
            float beta, float[] Y, int incY);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ssbmv(Layout Layout, UpLo Uplo,
            int N, int K, float alpha, float[] A,
            int lda, float[] X, int incX,
            float beta, float[] Y, int incY)
            => cblas_ssbmv(Layout, Uplo, N, K, alpha, A, lda, X, incX, beta, Y, incY);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void cblas_sspmv(Layout Layout, UpLo Uplo,
            int N, float alpha, float[] Ap,
            float[] X, int incX,
            float beta, float[] Y, int incY);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void sspmv(Layout Layout, UpLo Uplo,
            int N, float alpha, float[] Ap,
            float[] X, int incX,
            float beta, float[] Y, int incY)
            => cblas_sspmv(Layout, Uplo, N, alpha, Ap, X, incX, beta, Y, incY);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void cblas_sger(Layout Layout, int M, int N,
            float alpha, float[] X, int incX,
            float[] Y, int incY, float[] A, int lda);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void sger(Layout Layout, int M, int N,
            float alpha, float[] X, int incX,
            float[] Y, int incY, float[] A, int lda)
            => cblas_sger(Layout, M, N, alpha, X, incX, Y, incY, A, lda);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void cblas_ssyr(Layout Layout, UpLo Uplo,
            int N, float alpha, float[] X,
            int incX, float[] A, int lda);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ssyr(Layout Layout, UpLo Uplo,
            int N, float alpha, float[] X,
            int incX, float[] A, int lda)
            => cblas_ssyr(Layout, Uplo, N, alpha, X, incX, A, lda);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void cblas_sspr(Layout Layout, UpLo Uplo,
            int N, float alpha, float[] X,
            int incX, float[] Ap);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void sspr(Layout Layout, UpLo Uplo,
            int N, float alpha, float[] X,
            int incX, float[] Ap)
            => cblas_sspr(Layout, Uplo, N, alpha, X, incX, Ap);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void cblas_ssyr2(Layout Layout, UpLo Uplo,
            int N, float alpha, float[] X,
            int incX, float[] Y, int incY, float[] A,
            int lda);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ssyr2(Layout Layout, UpLo Uplo,
            int N, float alpha, float[] X,
            int incX, float[] Y, int incY, float[] A,
            int lda)
            => cblas_ssyr2(Layout, Uplo, N, alpha, X, incX, Y, incY, A, lda);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void cblas_sspr2(Layout Layout, UpLo Uplo,
            int N, float alpha, float[] X,
            int incX, float[] Y, int incY, float[] A);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void sspr2(Layout Layout, UpLo Uplo,
            int N, float alpha, float[] X,
            int incX, float[] Y, int incY, float[] A)
            => cblas_sspr2(Layout, Uplo, N, alpha, X, incX, Y, incY, A);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void cblas_dsymv(Layout Layout, UpLo Uplo,
            int N, double alpha, double[] A,
            int lda, double[] X, int incX,
            double beta, double[] Y, int incY);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void dsymv(Layout Layout, UpLo Uplo,
            int N, double alpha, double[] A,
            int lda, double[] X, int incX,
            double beta, double[] Y, int incY)
            => cblas_dsymv(Layout, Uplo, N, alpha, A, lda, X, incX, beta, Y, incY);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void cblas_dsbmv(Layout Layout, UpLo Uplo,
            int N, int K, double alpha, double[] A,
            int lda, double[] X, int incX,
            double beta, double[] Y, int incY);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void dsbmv(Layout Layout, UpLo Uplo,
            int N, int K, double alpha, double[] A,
            int lda, double[] X, int incX,
            double beta, double[] Y, int incY)
            => cblas_dsbmv(Layout, Uplo, N, K, alpha, A, lda, X, incX, beta, Y, incY);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void cblas_dspmv(Layout Layout, UpLo Uplo,
            int N, double alpha, double[] Ap,
            double[] X, int incX,
            double beta, double[] Y, int incY);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void dspmv(Layout Layout, UpLo Uplo,
            int N, double alpha, double[] Ap,
            double[] X, int incX,
            double beta, double[] Y, int incY)
            => cblas_dspmv(Layout, Uplo, N, alpha, Ap, X, incX, beta, Y, incY);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void cblas_dger(Layout Layout, int M, int N,
            double alpha, double[] X, int incX,
            double[] Y, int incY, double[] A, int lda);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void dger(Layout Layout, int M, int N,
            double alpha, double[] X, int incX,
            double[] Y, int incY, double[] A, int lda)
            => cblas_dger(Layout, M, N, alpha, X, incX, Y, incY, A, lda);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void cblas_dsyr(Layout Layout, UpLo Uplo,
                int N, double alpha, double[] X,
                int incX, double[] A, int lda);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void dsyr(Layout Layout, UpLo Uplo,
                int N, double alpha, double[] X,
                int incX, double[] A, int lda)
            => cblas_dsyr(Layout, Uplo,
               N, alpha, X,
               incX, A, lda);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void cblas_dspr(Layout Layout, UpLo Uplo,
            int N, double alpha, double[] X,
            int incX, double[] Ap);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void dspr(Layout Layout, UpLo Uplo,
            int N, double alpha, double[] X,
            int incX, double[] Ap)
            => cblas_dspr(Layout, Uplo, N, alpha, X, incX, Ap);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void cblas_dsyr2(Layout Layout, UpLo Uplo,
            int N, double alpha, double[] X,
            int incX, double[] Y, int incY, double[] A,
            int lda);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void dsyr2(Layout Layout, UpLo Uplo,
            int N, double alpha, double[] X,
            int incX, double[] Y, int incY, double[] A,
            int lda)
            => cblas_dsyr2(Layout, Uplo, N, alpha, X, incX, Y, incY, A, lda);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void cblas_dspr2(Layout Layout, UpLo Uplo,
            int N, double alpha, double[] X,
            int incX, double[] Y, int incY, double[] A);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void dspr2(Layout Layout, UpLo Uplo,
            int N, double alpha, double[] X,
            int incX, double[] Y, int incY, double[] A)
            => cblas_dspr2(Layout, Uplo, N, alpha, X, incX, Y, incY, A);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void cblas_sgemm(Layout Layout, Transpose TransA,
            Transpose TransB, int M, int N,
            int K, float alpha, float[] A,
            int lda, float[] B, int ldb,
            float beta, float[] C, int ldc);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void sgemm(Layout Layout, Transpose TransA,
            Transpose TransB, int M, int N,
            int K, float alpha, float[] A,
            int lda, float[] B, int ldb,
            float beta, float[] C, int ldc)
            => cblas_sgemm(Layout, TransA, TransB, M, N, K, alpha, A, lda, B, ldb, beta, C, ldc);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void cblas_sgemmt(Layout Layout, UpLo Uplo,
            Transpose TransA, Transpose TransB,
            int N, int K,
            float alpha, float[] A, int lda,
            float[] B, int ldb, float beta,
            float[] C, int ldc);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void sgemmt(Layout Layout, UpLo Uplo,
            Transpose TransA, Transpose TransB,
            int N, int K,
            float alpha, float[] A, int lda,
            float[] B, int ldb, float beta,
            float[] C, int ldc)
            => cblas_sgemmt(Layout, Uplo, TransA, TransB, N, K, alpha, A, lda, B, ldb, beta, C, ldc);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void cblas_ssymm(Layout Layout, Side Side,
            UpLo Uplo, int M, int N,
            float alpha, float[] A, int lda,
            float[] B, int ldb, float beta,
            float[] C, int ldc);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ssymm(Layout Layout, Side Side,
            UpLo Uplo, int M, int N,
            float alpha, float[] A, int lda,
            float[] B, int ldb, float beta,
            float[] C, int ldc)
            => cblas_ssymm(Layout, Side, Uplo, M, N, alpha, A, lda, B, ldb, beta, C, ldc);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void cblas_ssyrk(Layout Layout, UpLo Uplo,
            Transpose Trans, int N, int K,
            float alpha, float[] A, int lda,
            float beta, float[] C, int ldc);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ssyrk(Layout Layout, UpLo Uplo,
            Transpose Trans, int N, int K,
            float alpha, float[] A, int lda,
            float beta, float[] C, int ldc)
            => cblas_ssyrk(Layout, Uplo, Trans, N, K, alpha, A, lda, beta, C, ldc);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void cblas_ssyr2k(Layout Layout, UpLo Uplo,
            Transpose Trans, int N, int K,
            float alpha, float[] A, int lda,
            float[] B, int ldb, float beta,
            float[] C, int ldc);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ssyr2k(Layout Layout, UpLo Uplo,
            Transpose Trans, int N, int K,
            float alpha, float[] A, int lda,
            float[] B, int ldb, float beta,
            float[] C, int ldc)
            => cblas_ssyr2k(Layout, Uplo, Trans, N, K, alpha, A, lda, B, ldb, beta, C, ldc);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void cblas_strmm(Layout Layout, Side Side,
            UpLo Uplo, Transpose TransA,
            Diag Diag, int M, int N,
            float alpha, float[] A, int lda,
            float[] B, int ldb);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void strmm(Layout Layout, Side Side,
            UpLo Uplo, Transpose TransA,
            Diag Diag, int M, int N,
            float alpha, float[] A, int lda,
            float[] B, int ldb)
            => cblas_strmm(Layout, Side, Uplo, TransA, Diag, M, N, alpha, A, lda, B, ldb);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void cblas_strsm(Layout Layout, Side Side,
            UpLo Uplo, Transpose TransA,
            Diag Diag, int M, int N,
            float alpha, float[] A, int lda,
            float[] B, int ldb);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void strsm(Layout Layout, Side Side,
            UpLo Uplo, Transpose TransA,
            Diag Diag, int M, int N,
            float alpha, float[] A, int lda,
            float[] B, int ldb)
            => cblas_strsm(Layout, Side, Uplo, TransA, Diag, M, N, alpha, A, lda, B, ldb);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void cblas_dgemm(Layout Layout, Transpose TransA,
            Transpose TransB, int M, int N,
            int K, double alpha, double[] A,
            int lda, double[] B, int ldb,
            double beta, double[] C, int ldc);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void dgemm(Layout Layout, Transpose TransA,
            Transpose TransB, int M, int N,
            int K, double alpha, double[] A,
            int lda, double[] B, int ldb,
            double beta, double[] C, int ldc)
            => cblas_dgemm(Layout, TransA, TransB, M, N, K, alpha, A, lda, B, ldb, beta, C, ldc);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void cblas_dgemmt(Layout Layout, UpLo Uplo,
            Transpose TransA, Transpose TransB,
            int N, int K,
            double alpha, double[] A, int lda,
            double[] B, int ldb, double beta,
            double[] C, int ldc);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void dgemmt(Layout Layout, UpLo Uplo,
            Transpose TransA, Transpose TransB,
            int N, int K,
            double alpha, double[] A, int lda,
            double[] B, int ldb, double beta,
            double[] C, int ldc)
            => cblas_dgemmt(Layout, Uplo, TransA, TransB, N, K, alpha, A, lda, B, ldb, beta, C, ldc);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void cblas_dsymm(Layout Layout, Side Side,
            UpLo Uplo, int M, int N,
            double alpha, double[] A, int lda,
            double[] B, int ldb, double beta,
            double[] C, int ldc);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void dsymm(Layout Layout, Side Side,
            UpLo Uplo, int M, int N,
            double alpha, double[] A, int lda,
            double[] B, int ldb, double beta,
            double[] C, int ldc)
            => cblas_dsymm(Layout, Side, Uplo, M, N, alpha, A, lda, B, ldb, beta, C, ldc);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void cblas_dsyrk(Layout Layout, UpLo Uplo,
            Transpose Trans, int N, int K,
            double alpha, double[] A, int lda,
            double beta, double[] C, int ldc);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void dsyrk(Layout Layout, UpLo Uplo,
            Transpose Trans, int N, int K,
            double alpha, double[] A, int lda,
            double beta, double[] C, int ldc)
            => cblas_dsyrk(Layout, Uplo, Trans, N, K, alpha, A, lda, beta, C, ldc);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void cblas_dsyr2k(Layout Layout, UpLo Uplo,
            Transpose Trans, int N, int K,
            double alpha, double[] A, int lda,
            double[] B, int ldb, double beta,
            double[] C, int ldc);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void dsyr2k(Layout Layout, UpLo Uplo,
            Transpose Trans, int N, int K,
            double alpha, double[] A, int lda,
            double[] B, int ldb, double beta,
            double[] C, int ldc)
            => cblas_dsyr2k(Layout, Uplo, Trans, N, K, alpha, A, lda, B, ldb, beta, C, ldc);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void cblas_dtrmm(Layout Layout, Side Side,
            UpLo Uplo, Transpose TransA,
            Diag Diag, int M, int N,
            double alpha, double[] A, int lda,
            double[] B, int ldb);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void dtrmm(Layout Layout, Side Side,
            UpLo Uplo, Transpose TransA,
            Diag Diag, int M, int N,
            double alpha, double[] A, int lda,
            double[] B, int ldb)
            => cblas_dtrmm(Layout, Side, Uplo, TransA, Diag, M, N, alpha, A, lda, B, ldb);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void cblas_dtrsm(Layout Layout, Side Side,
            UpLo Uplo, Transpose TransA,
            Diag Diag, int M, int N,
            double alpha, double[] A, int lda,
            double[] B, int ldb);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void dtrsm(Layout Layout, Side Side,
            UpLo Uplo, Transpose TransA,
            Diag Diag, int M, int N,
            double alpha, double[] A, int lda,
            double[] B, int ldb)
            => cblas_dtrsm(Layout, Side, Uplo, TransA, Diag, M, N, alpha, A, lda, B, ldb);
    }
}