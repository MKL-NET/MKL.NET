using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;

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
        static extern double LAPACKE_dlamch(char cmach);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double dlamch(char cmach)
            => LAPACKE_dlamch(cmach);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern double LAPACKE_dlamch_work(char cmach);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double dlamch_work(char cmach)
            => LAPACKE_dlamch_work(cmach);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern double LAPACKE_dlange(Layout layout, Norm norm, int m,
            int n, double[] a, int lda);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double dlange(Layout layout, Norm norm, int m,
            int n, double[] a, int lda)
            => LAPACKE_dlange(layout, norm, m, n, a, lda);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern double LAPACKE_dlange_work(Layout layout, Norm norm, int m,
            int n, double[] a, int lda,
            double[] work);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double dlange_work(Layout layout, Norm norm, int m,
            int n, double[] a, int lda,
            double[] work)
            => LAPACKE_dlange_work(layout, norm, m, n, a, lda, work);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern double LAPACKE_dlansy(Layout layout, Norm norm, UpLo uplo, int n,
            double[] a, int lda);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double dlansy(Layout layout, Norm norm, UpLo uplo, int n,
            double[] a, int lda)
            => LAPACKE_dlansy(layout, norm, uplo, n, a, lda);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern double LAPACKE_dlansy_work(Layout layout, Norm norm, UpLo uplo,
            int n, double[] a, int lda,
            double[] work);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double dlansy_work(Layout layout, Norm norm, UpLo uplo,
            int n, double[] a, int lda,
            double[] work)
            => LAPACKE_dlansy_work(layout, norm, uplo, n, a, lda, work);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern double LAPACKE_dlantr(Layout layout, Norm norm, UpLo uplo, DiagChar diag,
            int m, int n, double[] a,
            int lda);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double dlantr(Layout layout, Norm norm, UpLo uplo, DiagChar diag,
            int m, int n, double[] a,
            int lda)
            => LAPACKE_dlantr(layout, norm, uplo, diag, m, n, a, lda);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern double LAPACKE_dlantr_work(Layout layout, Norm norm, UpLo uplo,
            DiagChar diag, int m, int n,
            double[] a, int lda, double[] work);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double dlantr_work(Layout layout, Norm norm, UpLo uplo,
            DiagChar diag, int m, int n,
            double[] a, int lda, double[] work)
            => LAPACKE_dlantr_work(layout, norm, uplo, diag, m, n, a, lda, work);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern double LAPACKE_dlapy2(double x, double y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double dlapy2(double x, double y)
            => LAPACKE_dlapy2(x, y);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern double LAPACKE_dlapy2_work(double x, double y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double dlapy2_work(double x, double y)
            => LAPACKE_dlapy2_work(x, y);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern double LAPACKE_dlapy3(double x, double y, double z);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double dlapy3(double x, double y, double z)
            => LAPACKE_dlapy3(x, y, z);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern double LAPACKE_dlapy3_work(double x, double y, double z);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double dlapy3_work(double x, double y, double z)
            => LAPACKE_dlapy3_work(x, y, z);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern float LAPACKE_slamch(char cmach);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float slamch(char cmach)
            => LAPACKE_slamch(cmach);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern float LAPACKE_slamch_work(char cmach);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float slamch_work(char cmach)
            => LAPACKE_slamch_work(cmach);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern float LAPACKE_slange(Layout layout, Norm norm, int m,
            int n, float[] a, int lda);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float slange(Layout layout, Norm norm, int m,
            int n, float[] a, int lda)
            => LAPACKE_slange(layout, norm, m, n, a, lda);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern float LAPACKE_slange_work(Layout layout, Norm norm, int m,
            int n, float[] a, int lda,
            float[] work);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float slange_work(Layout layout, Norm norm, int m,
            int n, float[] a, int lda,
            float[] work)
            => LAPACKE_slange_work(layout, norm, m, n, a, lda, work);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern float LAPACKE_slansy(Layout layout, Norm norm, UpLo uplo, int n,
            float[] a, int lda);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float slansy(Layout layout, Norm norm, UpLo uplo, int n,
            float[] a, int lda)
            => LAPACKE_slansy(layout, norm, uplo, n, a, lda);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern float LAPACKE_slansy_work(Layout layout, Norm norm, UpLo uplo,
            int n, float[] a, int lda,
            float[] work);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float slansy_work(Layout layout, Norm norm, UpLo uplo,
            int n, float[] a, int lda,
            float[] work)
            => LAPACKE_slansy_work(layout, norm, uplo, n, a, lda, work);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern float LAPACKE_slantr(Layout layout, Norm norm, UpLo uplo, DiagChar diag,
            int m, int n, float[] a,
            int lda);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float slantr(Layout layout, Norm norm, UpLo uplo, DiagChar diag,
            int m, int n, float[] a,
            int lda)
            => LAPACKE_slantr(layout, norm, uplo, diag, m, n, a, lda);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern float LAPACKE_slantr_work(Layout layout, Norm norm, UpLo uplo,
            DiagChar diag, int m, int n,
            float[] a, int lda, float[] work);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float slantr_work(Layout layout, Norm norm, UpLo uplo,
            DiagChar diag, int m, int n,
            float[] a, int lda, float[] work)
            => LAPACKE_slantr_work(layout, norm, uplo, diag, m, n, a, lda, work);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern float LAPACKE_slapy2(float x, float y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float slapy2(float x, float y)
            => LAPACKE_slapy2(x, y);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern float LAPACKE_slapy2_work(float x, float y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float slapy2_work(float x, float y)
            => LAPACKE_slapy2_work(x, y);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern float LAPACKE_slapy3(float x, float y, float z);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float slapy3(float x, float y, float z)
            => LAPACKE_slapy3(x, y, z);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern float LAPACKE_slapy3_work(float x, float y, float z);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float slapy3_work(float x, float y, float z)
            => LAPACKE_slapy3_work(x, y, z);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dbbcsd(Layout layout, char jobu1, char jobu2,
            char jobv1t, char jobv2t, TransChar trans, int m,
            int p, int q, double[] theta,
            double[] phi, double[] u1, int ldu1, double[] u2,
            int ldu2, double[] v1t, int ldv1t,
            double[] v2t, int ldv2t, double[] b11d,
            double[] b11e, double[] b12d, double[] b12e,
            double[] b21d, double[] b21e, double[] b22d,
            double[] b22e);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dbbcsd(Layout layout, char jobu1, char jobu2,
            char jobv1t, char jobv2t, TransChar trans, int m,
            int p, int q, double[] theta,
            double[] phi, double[] u1, int ldu1, double[] u2,
            int ldu2, double[] v1t, int ldv1t,
            double[] v2t, int ldv2t, double[] b11d,
            double[] b11e, double[] b12d, double[] b12e,
            double[] b21d, double[] b21e, double[] b22d,
            double[] b22e)
            => LAPACKE_dbbcsd(layout, jobu1, jobu2, jobv1t, jobv2t, trans, m,
                p, q, theta,
                phi, u1, ldu1, u2,
                ldu2, v1t, ldv1t,
                v2t, ldv2t, b11d,
                b11e, b12d, b12e,
                b21d, b21e, b22d,
                b22e);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dbbcsd_work(Layout layout, char jobu1, char jobu2,
            char jobv1t, char jobv2t, TransChar trans,
            int m, int p, int q,
            double[] theta, double[] phi, double[] u1,
            int ldu1, double[] u2, int ldu2,
            double[] v1t, int ldv1t, double[] v2t,
            int ldv2t, double[] b11d, double[] b11e,
            double[] b12d, double[] b12e, double[] b21d,
            double[] b21e, double[] b22d, double[] b22e,
            double[] work, int lwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dbbcsd_work(Layout layout, char jobu1, char jobu2,
            char jobv1t, char jobv2t, TransChar trans,
            int m, int p, int q,
            double[] theta, double[] phi, double[] u1,
            int ldu1, double[] u2, int ldu2,
            double[] v1t, int ldv1t, double[] v2t,
            int ldv2t, double[] b11d, double[] b11e,
            double[] b12d, double[] b12e, double[] b21d,
            double[] b21e, double[] b22d, double[] b22e,
            double[] work, int lwork)
            => LAPACKE_dbbcsd_work(layout, jobu1, jobu2,
                jobv1t, jobv2t, trans,
                m, p, q,
                theta, phi, u1,
                ldu1, u2, ldu2,
                v1t, ldv1t, v2t,
                ldv2t, b11d, b11e,
                b12d, b12e, b21d,
                b21e, b22d, b22e,
                work, lwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dbdsdc(Layout layout, UpLo uplo, char compq,
            int n, double[] d, double[] e, double[] u,
            int ldu, double[] vt, int ldvt,
            double[] q, int[] iq);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dbdsdc(Layout layout, UpLo uplo, char compq,
            int n, double[] d, double[] e, double[] u,
            int ldu, double[] vt, int ldvt,
            double[] q, int[] iq)
            => LAPACKE_dbdsdc(layout, uplo, compq,
                n, d, e, u,
                ldu, vt, ldvt,
                q, iq);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dbdsdc_work(Layout layout, UpLo uplo, char compq,
            int n, double[] d, double[] e, double[] u,
            int ldu, double[] vt, int ldvt,
            double[] q, int[] iq, double[] work,
            int[] iwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dbdsdc_work(Layout layout, UpLo uplo, char compq,
            int n, double[] d, double[] e, double[] u,
            int ldu, double[] vt, int ldvt,
            double[] q, int[] iq, double[] work,
            int[] iwork)
            => LAPACKE_dbdsdc_work(layout, uplo, compq,
                n, d, e, u,
                ldu, vt, ldvt,
                q, iq, work,
                iwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dbdsqr(Layout layout, UpLo uplo, int n,
            int ncvt, int nru, int ncc,
            double[] d, double[] e, double[] vt, int ldvt,
            double[] u, int ldu, double[] c,
            int ldc);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dbdsqr(Layout layout, UpLo uplo, int n,
            int ncvt, int nru, int ncc,
            double[] d, double[] e, double[] vt, int ldvt,
            double[] u, int ldu, double[] c,
            int ldc)
            => LAPACKE_dbdsqr(layout, uplo, n, ncvt, nru, ncc, d, e, vt, ldvt, u, ldu, c, ldc);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dbdsqr_work(Layout layout, UpLo uplo, int n,
            int ncvt, int nru, int ncc,
            double[] d, double[] e, double[] vt,
            int ldvt, double[] u, int ldu,
            double[] c, int ldc, double[] work);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dbdsqr_work(Layout layout, UpLo uplo, int n,
            int ncvt, int nru, int ncc,
            double[] d, double[] e, double[] vt,
            int ldvt, double[] u, int ldu,
            double[] c, int ldc, double[] work)
            => LAPACKE_dbdsqr_work(layout, uplo, n, ncvt, nru, ncc, d, e, vt, ldvt, u, ldu, c, ldc, work);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dbdsvdx(Layout layout, UpLo uplo, char jobz, char range,
            int n, double[] d, double[] e,
            double vl, double vu,
            int il, int iu, int[] ns,
            double[] s, double[] z, int ldz,
            int[] superb);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dbdsvdx(Layout layout, UpLo uplo, char jobz, char range,
            int n, double[] d, double[] e,
            double vl, double vu,
            int il, int iu, int[] ns,
            double[] s, double[] z, int ldz,
            int[] superb)
            => LAPACKE_dbdsvdx(layout, uplo, jobz, range, n, d, e, vl, vu, il, iu, ns, s, z, ldz, superb);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dbdsvdx_work(Layout layout, UpLo uplo, char jobz, char range,
            int n, double[] d, double[] e,
            double vl, double vu,
            int il, int iu, int[] ns,
            double[] s, double[] z, int ldz,
            double[] work, int[] iwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dbdsvdx_work(Layout layout, UpLo uplo, char jobz, char range,
            int n, double[] d, double[] e,
            double vl, double vu,
            int il, int iu, int[] ns,
            double[] s, double[] z, int ldz,
            double[] work, int[] iwork)
            => LAPACKE_dbdsvdx_work(layout, uplo, jobz, range, n, d, e, vl, vu, il, iu, ns, s, z, ldz, work, iwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ddisna(char job, int m, int n,
            double[] d, double[] sep);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ddisna(char job, int m, int n,
            double[] d, double[] sep)
            => LAPACKE_ddisna(job, m, n, d, sep);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ddisna_work(char job, int m, int n,
            double[] d, double[] sep);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ddisna_work(char job, int m, int n,
            double[] d, double[] sep)
            => LAPACKE_ddisna_work(job, m, n, d, sep);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgbbrd(Layout layout, char vect, int m,
            int n, int ncc, int kl,
            int ku, double[] ab, int ldab,
            double[] d, double[] e, double[] q, int ldq,
            double[] pt, int ldpt, double[] c,
            int ldc);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dgbbrd(Layout layout, char vect, int m,
            int n, int ncc, int kl,
            int ku, double[] ab, int ldab,
            double[] d, double[] e, double[] q, int ldq,
            double[] pt, int ldpt, double[] c,
            int ldc)
            => LAPACKE_dgbbrd(layout, vect, m,
                n, ncc, kl,
                ku, ab, ldab,
                d, e, q, ldq,
                pt, ldpt, c,
                ldc);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgbbrd_work(Layout layout, char vect, int m,
            int n, int ncc, int kl,
            int ku, double[] ab, int ldab,
            double[] d, double[] e, double[] q, int ldq,
            double[] pt, int ldpt, double[] c,
            int ldc, double[] work);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dgbbrd_work(Layout layout, char vect, int m,
            int n, int ncc, int kl,
            int ku, double[] ab, int ldab,
            double[] d, double[] e, double[] q, int ldq,
            double[] pt, int ldpt, double[] c,
            int ldc, double[] work)
            => LAPACKE_dgbbrd_work(layout, vect, m,
                n, ncc, kl,
                ku, ab, ldab,
                d, e, q, ldq,
                pt, ldpt, c,
                ldc, work);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgbcon(Layout layout, Norm norm, int n,
            int kl, int ku, double[] ab,
            int ldab, int[] ipiv,
            double anorm, double[] rcond);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dgbcon(Layout layout, Norm norm, int n,
            int kl, int ku, double[] ab,
            int ldab, int[] ipiv,
            double anorm, double[] rcond)
            => LAPACKE_dgbcon(layout, norm, n,
                kl, ku, ab,
                ldab, ipiv,
                anorm, rcond);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgbcon_work(Layout layout, Norm norm, int n,
            int kl, int ku, double[] ab,
            int ldab, int[] ipiv,
            double anorm, double[] rcond, double[] work,
            int[] iwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dgbcon_work(Layout layout, Norm norm, int n,
            int kl, int ku, double[] ab,
            int ldab, int[] ipiv,
            double anorm, double[] rcond, double[] work,
            int[] iwork)
            => LAPACKE_dgbcon_work(layout, norm, n,
                kl, ku, ab,
                ldab, ipiv,
                anorm, rcond, work,
                iwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgbequ(Layout layout, int m, int n,
            int kl, int ku, double[] ab,
            int ldab, double[] r, double[] c,
            double[] rowcnd, double[] colcnd, double[] amax);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dgbequ(Layout layout, int m, int n,
            int kl, int ku, double[] ab,
            int ldab, double[] r, double[] c,
            double[] rowcnd, double[] colcnd, double[] amax)
            => LAPACKE_dgbequ(layout, m, n,
                kl, ku, ab,
                ldab, r, c,
                rowcnd, colcnd, amax);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgbequ_work(Layout layout, int m, int n,
            int kl, int ku, double[] ab,
            int ldab, double[] r, double[] c,
            double[] rowcnd, double[] colcnd, double[] amax);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dgbequ_work(Layout layout, int m, int n,
            int kl, int ku, double[] ab,
            int ldab, double[] r, double[] c,
            double[] rowcnd, double[] colcnd, double[] amax)
            => LAPACKE_dgbequ_work(layout, m, n,
                kl, ku, ab,
                ldab, r, c,
                rowcnd, colcnd, amax);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgbequb(Layout layout, int m, int n,
            int kl, int ku, double[] ab,
            int ldab, double[] r, double[] c,
            double[] rowcnd, double[] colcnd, double[] amax);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dgbequb(Layout layout, int m, int n,
            int kl, int ku, double[] ab,
            int ldab, double[] r, double[] c,
            double[] rowcnd, double[] colcnd, double[] amax)
            => LAPACKE_dgbequb(layout, m, n,
                kl, ku, ab,
                ldab, r, c,
                rowcnd, colcnd, amax);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgbequb_work(Layout layout, int m, int n,
            int kl, int ku, double[] ab,
            int ldab, double[] r, double[] c,
            double[] rowcnd, double[] colcnd, double[] amax);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dgbequb_work(Layout layout, int m, int n,
            int kl, int ku, double[] ab,
            int ldab, double[] r, double[] c,
            double[] rowcnd, double[] colcnd, double[] amax)
            => LAPACKE_dgbequb_work(layout, m, n,
                kl, ku, ab,
                ldab, r, c,
                rowcnd, colcnd, amax);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgbrfs(Layout layout, TransChar trans, int n,
            int kl, int ku, int nrhs,
            double[] ab, int ldab, double[] afb,
            int ldafb, int[] ipiv,
            double[] b, int ldb, double[] x,
            int ldx, double[] ferr, double[] berr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dgbrfs(Layout layout, TransChar trans, int n,
            int kl, int ku, int nrhs,
            double[] ab, int ldab, double[] afb,
            int ldafb, int[] ipiv,
            double[] b, int ldb, double[] x,
            int ldx, double[] ferr, double[] berr)
            => LAPACKE_dgbrfs(layout, trans, n,
                kl, ku, nrhs,
                ab, ldab, afb,
                ldafb, ipiv,
                b, ldb, x,
                ldx, ferr, berr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgbrfs_work(Layout layout, TransChar trans, int n,
            int kl, int ku, int nrhs,
            double[] ab, int ldab,
            double[] afb, int ldafb,
            int[] ipiv, double[] b,
            int ldb, double[] x, int ldx,
            double[] ferr, double[] berr, double[] work,
            int[] iwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dgbrfs_work(Layout layout, TransChar trans, int n,
            int kl, int ku, int nrhs,
            double[] ab, int ldab,
            double[] afb, int ldafb,
            int[] ipiv, double[] b,
            int ldb, double[] x, int ldx,
            double[] ferr, double[] berr, double[] work,
            int[] iwork)
            => LAPACKE_dgbrfs_work(layout, trans, n,
                kl, ku, nrhs,
                ab, ldab,
                afb, ldafb,
                ipiv, b,
                ldb, x, ldx,
                ferr, berr, work,
                iwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgbrfsx(Layout layout, TransChar trans, char equed,
            int n, int kl, int ku,
            int nrhs, double[] ab, int ldab,
            double[] afb, int ldafb,
            int[] ipiv, double[] r,
            double[] c, double[] b, int ldb,
            double[] x, int ldx, double[] rcond,
            double[] berr, int n_err_bnds,
            double[] err_bnds_norm, double[] err_bnds_comp,
            int nparams, double[] aparams);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dgbrfsx(Layout layout, TransChar trans, char equed,
            int n, int kl, int ku,
            int nrhs, double[] ab, int ldab,
            double[] afb, int ldafb,
            int[] ipiv, double[] r,
            double[] c, double[] b, int ldb,
            double[] x, int ldx, double[] rcond,
            double[] berr, int n_err_bnds,
            double[] err_bnds_norm, double[] err_bnds_comp,
            int nparams, double[] aparams)
            => LAPACKE_dgbrfsx(layout, trans, equed,
                n, kl, ku,
                nrhs, ab, ldab,
                afb, ldafb,
                ipiv, r,
                c, b, ldb,
                x, ldx, rcond,
                berr, n_err_bnds,
                err_bnds_norm, err_bnds_comp,
                nparams, aparams);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgbrfsx_work(Layout layout, TransChar trans, char equed,
            int n, int kl, int ku,
            int nrhs, double[] ab,
            int ldab, double[] afb,
            int ldafb, int[] ipiv,
            double[] r, double[] c,
            double[] b, int ldb, double[] x,
            int ldx, double[] rcond, double[] berr,
            int n_err_bnds, double[] err_bnds_norm,
            double[] err_bnds_comp, int nparams,
            double[] aparams, double[] work,
            int[] iwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dgbrfsx_work(Layout layout, TransChar trans, char equed,
            int n, int kl, int ku,
            int nrhs, double[] ab,
            int ldab, double[] afb,
            int ldafb, int[] ipiv,
            double[] r, double[] c,
            double[] b, int ldb, double[] x,
            int ldx, double[] rcond, double[] berr,
            int n_err_bnds, double[] err_bnds_norm,
            double[] err_bnds_comp, int nparams,
            double[] aparams, double[] work,
            int[] iwork)
            => LAPACKE_dgbrfsx_work(layout, trans, equed,
                n, kl, ku,
                nrhs, ab,
                ldab, afb,
                ldafb, ipiv,
                r, c,
                b, ldb, x,
                ldx, rcond, berr,
                n_err_bnds, err_bnds_norm,
                err_bnds_comp, nparams,
                aparams, work,
                iwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgbsv(Layout layout, int n, int kl,
            int ku, int nrhs, double[] ab,
            int ldab, int[] ipiv, double[] b,
            int ldb);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dgbsv(Layout layout, int n, int kl,
            int ku, int nrhs, double[] ab,
            int ldab, int[] ipiv, double[] b,
            int ldb)
            => LAPACKE_dgbsv(layout, n, kl,
                ku, nrhs, ab,
                ldab, ipiv, b,
                ldb);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgbsv_work(Layout layout, int n, int kl,
            int ku, int nrhs, double[] ab,
            int ldab, int[] ipiv, double[] b,
            int ldb);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dgbsv_work(Layout layout, int n, int kl,
            int ku, int nrhs, double[] ab,
            int ldab, int[] ipiv, double[] b,
            int ldb)
            => LAPACKE_dgbsv_work(layout, n, kl,
                ku, nrhs, ab,
                ldab, ipiv, b,
                ldb);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgbsvx(Layout layout, char fact, TransChar trans,
            int n, int kl, int ku,
            int nrhs, double[] ab, int ldab,
            double[] afb, int ldafb, int[] ipiv,
            char[] equed, double[] r, double[] c, double[] b,
            int ldb, double[] x, int ldx,
            double[] rcond, double[] ferr, double[] berr,
            double[] rpivot);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dgbsvx(Layout layout, char fact, TransChar trans,
            int n, int kl, int ku,
            int nrhs, double[] ab, int ldab,
            double[] afb, int ldafb, int[] ipiv,
            char[] equed, double[] r, double[] c, double[] b,
            int ldb, double[] x, int ldx,
            double[] rcond, double[] ferr, double[] berr,
            double[] rpivot)
            => LAPACKE_dgbsvx(layout, fact, trans,
                n, kl, ku,
                nrhs, ab, ldab,
                afb, ldafb, ipiv,
                equed, r, c, b,
                ldb, x, ldx,
                rcond, ferr, berr,
                rpivot);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgbsvx_work(Layout layout, char fact, TransChar trans,
            int n, int kl, int ku,
            int nrhs, double[] ab, int ldab,
            double[] afb, int ldafb, int[] ipiv,
            char[] equed, double[] r, double[] c, double[] b,
            int ldb, double[] x, int ldx,
            double[] rcond, double[] ferr, double[] berr,
            double[] work, int[] iwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dgbsvx_work(Layout layout, char fact, TransChar trans,
            int n, int kl, int ku,
            int nrhs, double[] ab, int ldab,
            double[] afb, int ldafb, int[] ipiv,
            char[] equed, double[] r, double[] c, double[] b,
            int ldb, double[] x, int ldx,
            double[] rcond, double[] ferr, double[] berr,
            double[] work, int[] iwork)
            => LAPACKE_dgbsvx_work(layout, fact, trans,
                n, kl, ku,
                nrhs, ab, ldab,
                afb, ldafb, ipiv,
                equed, r, c, b,
                ldb, x, ldx,
                rcond, ferr, berr,
                work, iwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgbsvxx(Layout layout, char fact, TransChar trans,
            int n, int kl, int ku,
            int nrhs, double[] ab, int ldab,
            double[] afb, int ldafb, int[] ipiv,
            char[] equed, double[] r, double[] c, double[] b,
            int ldb, double[] x, int ldx,
            double[] rcond, double[] rpvgrw, double[] berr,
            int n_err_bnds, double[] err_bnds_norm,
            double[] err_bnds_comp, int nparams,
            double[] aparams);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dgbsvxx(Layout layout, char fact, TransChar trans,
            int n, int kl, int ku,
            int nrhs, double[] ab, int ldab,
            double[] afb, int ldafb, int[] ipiv,
            char[] equed, double[] r, double[] c, double[] b,
            int ldb, double[] x, int ldx,
            double[] rcond, double[] rpvgrw, double[] berr,
            int n_err_bnds, double[] err_bnds_norm,
            double[] err_bnds_comp, int nparams,
            double[] aparams)
            => LAPACKE_dgbsvxx(layout, fact, trans,
                n, kl, ku,
                nrhs, ab, ldab,
                afb, ldafb, ipiv,
                equed, r, c, b,
                ldb, x, ldx,
                rcond, rpvgrw, berr,
                n_err_bnds, err_bnds_norm,
                err_bnds_comp, nparams,
                aparams);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgbsvxx_work(Layout layout, char fact, TransChar trans,
            int n, int kl, int ku,
            int nrhs, double[] ab, int ldab,
            double[] afb, int ldafb,
            int[] ipiv, char[] equed, double[] r,
            double[] c, double[] b, int ldb,
            double[] x, int ldx, double[] rcond,
            double[] rpvgrw, double[] berr,
            int n_err_bnds, double[] err_bnds_norm,
            double[] err_bnds_comp, int nparams,
            double[] aparams, double[] work,
            int[] iwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dgbsvxx_work(Layout layout, char fact, TransChar trans,
            int n, int kl, int ku,
            int nrhs, double[] ab, int ldab,
            double[] afb, int ldafb,
            int[] ipiv, char[] equed, double[] r,
            double[] c, double[] b, int ldb,
            double[] x, int ldx, double[] rcond,
            double[] rpvgrw, double[] berr,
            int n_err_bnds, double[] err_bnds_norm,
            double[] err_bnds_comp, int nparams,
            double[] aparams, double[] work,
            int[] iwork)
            => LAPACKE_dgbsvxx_work(layout, fact, trans,
                n, kl, ku,
                nrhs, ab, ldab,
                afb, ldafb,
                ipiv, equed, r,
                c, b, ldb,
                x, ldx, rcond,
                rpvgrw, berr,
                n_err_bnds, err_bnds_norm,
                err_bnds_comp, nparams,
                aparams, work,
                iwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgbtrf(Layout layout, int m, int n,
            int kl, int ku, double[] ab,
            int ldab, int[] ipiv);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dgbtrf(Layout layout, int m, int n,
            int kl, int ku, double[] ab,
            int ldab, int[] ipiv)
            => LAPACKE_dgbtrf(layout, m, n,
                kl, ku, ab,
                ldab, ipiv);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgbtrf_work(Layout layout, int m, int n,
            int kl, int ku, double[] ab,
            int ldab, int[] ipiv);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dgbtrf_work(Layout layout, int m, int n,
            int kl, int ku, double[] ab,
            int ldab, int[] ipiv)
            => LAPACKE_dgbtrf_work(layout, m, n,
                kl, ku, ab,
                ldab, ipiv);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgbtrs(Layout layout, TransChar trans, int n,
            int kl, int ku, int nrhs,
            double[] ab, int ldab,
            int[] ipiv, double[] b, int ldb);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dgbtrs(Layout layout, TransChar trans, int n,
            int kl, int ku, int nrhs,
            double[] ab, int ldab,
            int[] ipiv, double[] b, int ldb)
            => LAPACKE_dgbtrs(layout, trans, n,
                kl, ku, nrhs,
                ab, ldab,
                ipiv, b, ldb);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgbtrs_work(Layout layout, TransChar trans, int n,
            int kl, int ku, int nrhs,
            double[] ab, int ldab,
            int[] ipiv, double[] b,
            int ldb);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dgbtrs_work(Layout layout, TransChar trans, int n,
            int kl, int ku, int nrhs,
            double[] ab, int ldab,
            int[] ipiv, double[] b,
            int ldb)
            => LAPACKE_dgbtrs_work(layout, trans, n,
                kl, ku, nrhs,
                ab, ldab,
                ipiv, b,
                ldb);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgebak(Layout layout, char job, char side, int n,
            int ilo, int ihi, double[] scale,
            int m, double[] v, int ldv);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dgebak(Layout layout, char job, char side, int n,
            int ilo, int ihi, double[] scale,
            int m, double[] v, int ldv)
            => LAPACKE_dgebak(layout, job, side, n,
                ilo, ihi, scale,
                m, v, ldv);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgebak_work(Layout layout, char job, char side,
            int n, int ilo, int ihi,
            double[] scale, int m, double[] v,
            int ldv);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dgebak_work(Layout layout, char job, char side,
            int n, int ilo, int ihi,
            double[] scale, int m, double[] v,
            int ldv)
            => LAPACKE_dgebak_work(layout, job, side,
                n, ilo, ihi,
                scale, m, v,
                ldv);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgebal(Layout layout, char job, int n, double[] a,
            int lda, int[] ilo, int[] ihi,
            double[] scale);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dgebal(Layout layout, char job, int n, double[] a,
            int lda, int[] ilo, int[] ihi,
            double[] scale)
            => LAPACKE_dgebal(layout, job, n, a,
                lda, ilo, ihi,
                scale);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgebal_work(Layout layout, char job, int n,
            double[] a, int lda, int[] ilo,
            int[] ihi, double[] scale);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dgebal_work(Layout layout, char job, int n,
            double[] a, int lda, int[] ilo,
            int[] ihi, double[] scale)
            => LAPACKE_dgebal_work(layout, job, n,
                a, lda, ilo,
                ihi, scale);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgebrd(Layout layout, int m, int n,
            double[] a, int lda, double[] d, double[] e,
            double[] tauq, double[] taup);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dgebrd(Layout layout, int m, int n,
            double[] a, int lda, double[] d, double[] e,
            double[] tauq, double[] taup)
            => LAPACKE_dgebrd(layout, m, n,
                a, lda, d, e,
                tauq, taup);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgebrd_work(Layout layout, int m, int n,
            double[] a, int lda, double[] d, double[] e,
            double[] tauq, double[] taup, double[] work,
            int lwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dgebrd_work(Layout layout, int m, int n,
            double[] a, int lda, double[] d, double[] e,
            double[] tauq, double[] taup, double[] work,
            int lwork)
            => LAPACKE_dgebrd_work(layout, m, n,
                a, lda, d, e,
                tauq, taup, work,
                lwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgecon(Layout layout, Norm norm, int n,
            double[] a, int lda, double anorm,
            double[] rcond);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dgecon(Layout layout, Norm norm, int n,
            double[] a, int lda, double anorm,
            double[] rcond)
            => LAPACKE_dgecon(layout, norm, n,
                a, lda, anorm,
                rcond);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgecon_work(Layout layout, Norm norm, int n,
            double[] a, int lda, double anorm,
            double[] rcond, double[] work, int[] iwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dgecon_work(Layout layout, Norm norm, int n,
            double[] a, int lda, double anorm,
            double[] rcond, double[] work, int[] iwork)
            => LAPACKE_dgecon_work(layout, norm, n,
                a, lda, anorm,
                rcond, work, iwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgeequ(Layout layout, int m, int n,
            double[] a, int lda, double[] r,
            double[] c, double[] rowcnd, double[] colcnd,
            double[] amax);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dgeequ(Layout layout, int m, int n,
            double[] a, int lda, double[] r,
            double[] c, double[] rowcnd, double[] colcnd,
            double[] amax)
            => LAPACKE_dgeequ(layout, m, n,
                a, lda, r,
                c, rowcnd, colcnd,
                amax);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgeequ_work(Layout layout, int m, int n,
            double[] a, int lda, double[] r,
            double[] c, double[] rowcnd, double[] colcnd,
            double[] amax);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dgeequ_work(Layout layout, int m, int n,
            double[] a, int lda, double[] r,
            double[] c, double[] rowcnd, double[] colcnd,
            double[] amax)
            => LAPACKE_dgeequ_work(layout, m, n,
                a, lda, r,
                c, rowcnd, colcnd,
                amax);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgeequb(Layout layout, int m, int n,
            double[] a, int lda, double[] r,
            double[] c, double[] rowcnd, double[] colcnd,
            double[] amax);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dgeequb(Layout layout, int m, int n,
            double[] a, int lda, double[] r,
            double[] c, double[] rowcnd, double[] colcnd,
            double[] amax)
            => LAPACKE_dgeequb(layout, m, n,
                a, lda, r,
                c, rowcnd, colcnd,
                amax);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgeequb_work(Layout layout, int m, int n,
            double[] a, int lda, double[] r,
            double[] c, double[] rowcnd, double[] colcnd,
            double[] amax);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dgeequb_work(Layout layout, int m, int n,
            double[] a, int lda, double[] r,
            double[] c, double[] rowcnd, double[] colcnd,
            double[] amax)
            => LAPACKE_dgeequb_work(layout, m, n,
                a, lda, r,
                c, rowcnd, colcnd,
                amax);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgeev(Layout layout, char jobvl, char jobvr,
            int n, double[] a, int lda, double[] wr,
            double[] wi, double[] vl, int ldvl, double[] vr,
            int ldvr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dgeev(Layout layout, char jobvl, char jobvr,
            int n, double[] a, int lda, double[] wr,
            double[] wi, double[] vl, int ldvl, double[] vr,
            int ldvr)
            => LAPACKE_dgeev(layout, jobvl, jobvr,
                n, a, lda, wr,
                wi, vl, ldvl, vr,
                ldvr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgeev_work(Layout layout, char jobvl, char jobvr,
            int n, double[] a, int lda,
            double[] wr, double[] wi, double[] vl,
            int ldvl, double[] vr, int ldvr,
            double[] work, int lwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dgeev_work(Layout layout, char jobvl, char jobvr,
            int n, double[] a, int lda,
            double[] wr, double[] wi, double[] vl,
            int ldvl, double[] vr, int ldvr,
            double[] work, int lwork)
            => LAPACKE_dgeev_work(layout, jobvl, jobvr,
                n, a, lda,
                wr, wi, vl,
                ldvl, vr, ldvr,
                work, lwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgeevx(Layout layout, char balanc, char jobvl,
            char jobvr, char sense, int n, double[] a,
            int lda, double[] wr, double[] wi, double[] vl,
            int ldvl, double[] vr, int ldvr,
            int[] ilo, int[] ihi, double[] scale,
            double[] abnrm, double[] rconde, double[] rcondv);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dgeevx(Layout layout, char balanc, char jobvl,
            char jobvr, char sense, int n, double[] a,
            int lda, double[] wr, double[] wi, double[] vl,
            int ldvl, double[] vr, int ldvr,
            int[] ilo, int[] ihi, double[] scale,
            double[] abnrm, double[] rconde, double[] rcondv)
            => LAPACKE_dgeevx(layout, balanc, jobvl,
                jobvr, sense, n, a,
                lda, wr, wi, vl,
                ldvl, vr, ldvr,
                ilo, ihi, scale,
                abnrm, rconde, rcondv);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgeevx_work(Layout layout, char balanc, char jobvl,
            char jobvr, char sense, int n, double[] a,
            int lda, double[] wr, double[] wi,
            double[] vl, int ldvl, double[] vr,
            int ldvr, int[] ilo,
            int[] ihi, double[] scale, double[] abnrm,
            double[] rconde, double[] rcondv, double[] work,
            int lwork, int[] iwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dgeevx_work(Layout layout, char balanc, char jobvl,
            char jobvr, char sense, int n, double[] a,
            int lda, double[] wr, double[] wi,
            double[] vl, int ldvl, double[] vr,
            int ldvr, int[] ilo,
            int[] ihi, double[] scale, double[] abnrm,
            double[] rconde, double[] rcondv, double[] work,
            int lwork, int[] iwork)
            => LAPACKE_dgeevx_work(layout, balanc, jobvl,
                jobvr, sense, n, a,
                lda, wr, wi,
                vl, ldvl, vr,
                ldvr, ilo,
                ihi, scale, abnrm,
                rconde, rcondv, work,
                lwork, iwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgehrd(Layout layout, int n, int ilo,
            int ihi, double[] a, int lda,
            double[] tau);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dgehrd(Layout layout, int n, int ilo,
            int ihi, double[] a, int lda,
            double[] tau)
            => LAPACKE_dgehrd(layout, n, ilo,
                ihi, a, lda,
                tau);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgehrd_work(Layout layout, int n, int ilo,
            int ihi, double[] a, int lda,
            double[] tau, double[] work, int lwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dgehrd_work(Layout layout, int n, int ilo,
            int ihi, double[] a, int lda,
            double[] tau, double[] work, int lwork)
            => LAPACKE_dgehrd_work(layout, n, ilo,
                ihi, a, lda,
                tau, work, lwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgejsv(Layout layout, char joba, char jobu, char jobv,
            char jobr, char jobt, char jobp, int m,
            int n, double[] a, int lda, double[] sva,
            double[] u, int ldu, double[] v, int ldv,
            double[] stat, int[] istat);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dgejsv(Layout layout, char joba, char jobu, char jobv,
            char jobr, char jobt, char jobp, int m,
            int n, double[] a, int lda, double[] sva,
            double[] u, int ldu, double[] v, int ldv,
            double[] stat, int[] istat)
            => LAPACKE_dgejsv(layout, joba, jobu, jobv,
                jobr, jobt, jobp, m,
                n, a, lda, sva,
                u, ldu, v, ldv,
                stat, istat);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgejsv_work(Layout layout, char joba, char jobu,
            char jobv, char jobr, char jobt, char jobp,
            int m, int n, double[] a,
            int lda, double[] sva, double[] u,
            int ldu, double[] v, int ldv,
            double[] work, int lwork,
            int[] iwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dgejsv_work(Layout layout, char joba, char jobu,
            char jobv, char jobr, char jobt, char jobp,
            int m, int n, double[] a,
            int lda, double[] sva, double[] u,
            int ldu, double[] v, int ldv,
            double[] work, int lwork,
            int[] iwork)
            => LAPACKE_dgejsv_work(layout, joba, jobu,
                jobv, jobr, jobt, jobp,
                m, n, a,
                lda, sva, u,
                ldu, v, ldv,
                work, lwork,
                iwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgelq2(Layout layout, int m, int n,
            double[] a, int lda, double[] tau);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dgelq2(Layout layout, int m, int n,
            double[] a, int lda, double[] tau)
            => LAPACKE_dgelq2(layout, m, n,
                a, lda, tau);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgelq2_work(Layout layout, int m, int n,
            double[] a, int lda, double[] tau,
            double[] work);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dgelq2_work(Layout layout, int m, int n,
            double[] a, int lda, double[] tau,
            double[] work)
            => LAPACKE_dgelq2_work(layout, m, n,
                a, lda, tau,
                work);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgelqf(Layout layout, int m, int n,
            double[] a, int lda, double[] tau);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dgelqf(Layout layout, int m, int n,
            double[] a, int lda, double[] tau)
            => LAPACKE_dgelqf(layout, m, n,
                a, lda, tau);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgelqf_work(Layout layout, int m, int n,
            double[] a, int lda, double[] tau,
            double[] work, int lwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dgelqf_work(Layout layout, int m, int n,
            double[] a, int lda, double[] tau,
            double[] work, int lwork)
            => LAPACKE_dgelqf_work(layout, m, n,
                a, lda, tau,
                work, lwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgels(Layout layout, TransChar trans, int m,
            int n, int nrhs, double[] a,
            int lda, double[] b, int ldb);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dgels(Layout layout, TransChar trans, int m,
            int n, int nrhs, double[] a,
            int lda, double[] b, int ldb)
            => LAPACKE_dgels(layout, trans, m,
                n, nrhs, a,
                lda, b, ldb);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgels_work(Layout layout, TransChar trans, int m,
            int n, int nrhs, double[] a,
            int lda, double[] b, int ldb,
            double[] work, int lwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dgels_work(Layout layout, TransChar trans, int m,
            int n, int nrhs, double[] a,
            int lda, double[] b, int ldb,
            double[] work, int lwork)
            => LAPACKE_dgels_work(layout, trans, m,
                n, nrhs, a,
                lda, b, ldb,
                work, lwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgelsd(Layout layout, int m, int n,
            int nrhs, double[] a, int lda,
            double[] b, int ldb, double[] s, double rcond,
            int[] rank);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dgelsd(Layout layout, int m, int n,
            int nrhs, double[] a, int lda,
            double[] b, int ldb, double[] s, double rcond,
            int[] rank)
            => LAPACKE_dgelsd(layout, m, n,
                nrhs, a, lda,
                b, ldb, s, rcond,
                rank);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgelsd_work(Layout layout, int m, int n,
            int nrhs, double[] a, int lda,
            double[] b, int ldb, double[] s,
            double rcond, int[] rank, double[] work,
            int lwork, int[] iwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dgelsd_work(Layout layout, int m, int n,
            int nrhs, double[] a, int lda,
            double[] b, int ldb, double[] s,
            double rcond, int[] rank, double[] work,
            int lwork, int[] iwork)
            => LAPACKE_dgelsd_work(layout, m, n,
                nrhs, a, lda,
                b, ldb, s,
                rcond, rank, work,
                lwork, iwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgelss(Layout layout, int m, int n,
            int nrhs, double[] a, int lda,
            double[] b, int ldb, double[] s, double rcond,
            int[] rank);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dgelss(Layout layout, int m, int n,
            int nrhs, double[] a, int lda,
            double[] b, int ldb, double[] s, double rcond,
            int[] rank)
            => LAPACKE_dgelss(layout, m, n,
                nrhs, a, lda,
                b, ldb, s, rcond,
                rank);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgelss_work(Layout layout, int m, int n,
            int nrhs, double[] a, int lda,
            double[] b, int ldb, double[] s,
            double rcond, int[] rank, double[] work,
            int lwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dgelss_work(Layout layout, int m, int n,
            int nrhs, double[] a, int lda,
            double[] b, int ldb, double[] s,
            double rcond, int[] rank, double[] work,
            int lwork)
            => LAPACKE_dgelss_work(layout, m, n,
                nrhs, a, lda,
                b, ldb, s,
                rcond, rank, work,
                lwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgelsy(Layout layout, int m, int n,
            int nrhs, double[] a, int lda,
            double[] b, int ldb, int[] jpvt,
            double rcond, int[] rank);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dgelsy(Layout layout, int m, int n,
            int nrhs, double[] a, int lda,
            double[] b, int ldb, int[] jpvt,
            double rcond, int[] rank)
            => LAPACKE_dgelsy(layout, m, n,
                nrhs, a, lda,
                b, ldb, jpvt,
                rcond, rank);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgelsy_work(Layout layout, int m, int n,
            int nrhs, double[] a, int lda,
            double[] b, int ldb, int[] jpvt,
            double rcond, int[] rank, double[] work,
            int lwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dgelsy_work(Layout layout, int m, int n,
            int nrhs, double[] a, int lda,
            double[] b, int ldb, int[] jpvt,
            double rcond, int[] rank, double[] work,
            int lwork)
            => LAPACKE_dgelsy_work(layout, m, n,
                nrhs, a, lda,
                b, ldb, jpvt,
                rcond, rank, work,
                lwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgemqrt(Layout layout, char side, TransChar trans,
            int m, int n, int k,
            int nb, double[] v, int ldv,
            double[] t, int ldt, double[] c,
            int ldc);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dgemqrt(Layout layout, char side, TransChar trans,
            int m, int n, int k,
            int nb, double[] v, int ldv,
            double[] t, int ldt, double[] c,
            int ldc)
            => LAPACKE_dgemqrt(layout, side, trans,
                m, n, k,
                nb, v, ldv,
                t, ldt, c,
                ldc);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgemqrt_work(Layout layout, char side, TransChar trans,
            int m, int n, int k,
            int nb, double[] v, int ldv,
            double[] t, int ldt, double[] c,
            int ldc, double[] work);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dgemqrt_work(Layout layout, char side, TransChar trans,
            int m, int n, int k,
            int nb, double[] v, int ldv,
            double[] t, int ldt, double[] c,
            int ldc, double[] work)
            => LAPACKE_dgemqrt_work(layout, side, trans,
                m, n, k,
                nb, v, ldv,
                t, ldt, c,
                ldc, work);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgeqlf(Layout layout, int m, int n,
            double[] a, int lda, double[] tau);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dgeqlf(Layout layout, int m, int n,
            double[] a, int lda, double[] tau)
            => LAPACKE_dgeqlf(layout, m, n,
                a, lda, tau);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgeqlf_work(Layout layout, int m, int n,
            double[] a, int lda, double[] tau,
            double[] work, int lwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dgeqlf_work(Layout layout, int m, int n,
            double[] a, int lda, double[] tau,
            double[] work, int lwork)
            => LAPACKE_dgeqlf_work(layout, m, n,
                a, lda, tau,
                work, lwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgeqp3(Layout layout, int m, int n,
            double[] a, int lda, int[] jpvt,
            double[] tau);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dgeqp3(Layout layout, int m, int n,
            double[] a, int lda, int[] jpvt,
            double[] tau)
            => LAPACKE_dgeqp3(layout, m, n,
                a, lda, jpvt,
                tau);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgeqp3_work(Layout layout, int m, int n,
            double[] a, int lda, int[] jpvt,
            double[] tau, double[] work, int lwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dgeqp3_work(Layout layout, int m, int n,
            double[] a, int lda, int[] jpvt,
            double[] tau, double[] work, int lwork)
            => LAPACKE_dgeqp3_work(layout, m, n,
                a, lda, jpvt,
                tau, work, lwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgeqpf(Layout layout, int m, int n,
            double[] a, int lda, int[] jpvt,
            double[] tau);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dgeqpf(Layout layout, int m, int n,
            double[] a, int lda, int[] jpvt,
            double[] tau)
            => LAPACKE_dgeqpf(layout, m, n,
                a, lda, jpvt,
                tau);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgeqpf_work(Layout layout, int m, int n,
            double[] a, int lda, int[] jpvt,
            double[] tau, double[] work);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dgeqpf_work(Layout layout, int m, int n,
            double[] a, int lda, int[] jpvt,
            double[] tau, double[] work)
            => LAPACKE_dgeqpf_work(layout, m, n,
                a, lda, jpvt,
                tau, work);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgeqr2(Layout layout, int m, int n,
            double[] a, int lda, double[] tau);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dgeqr2(Layout layout, int m, int n,
            double[] a, int lda, double[] tau)
            => LAPACKE_dgeqr2(layout, m, n,
                a, lda, tau);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgeqr2_work(Layout layout, int m, int n,
            double[] a, int lda, double[] tau,
            double[] work);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dgeqr2_work(Layout layout, int m, int n,
            double[] a, int lda, double[] tau,
            double[] work)
            => LAPACKE_dgeqr2_work(layout, m, n,
                a, lda, tau,
                work);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgeqrf(Layout layout, int m, int n,
            double[] a, int lda, double[] tau);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dgeqrf(Layout layout, int m, int n,
            double[] a, int lda, double[] tau)
            => LAPACKE_dgeqrf(layout, m, n,
                a, lda, tau);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgeqrf_work(Layout layout, int m, int n,
            double[] a, int lda, double[] tau,
            double[] work, int lwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dgeqrf_work(Layout layout, int m, int n,
            double[] a, int lda, double[] tau,
            double[] work, int lwork)
            => LAPACKE_dgeqrf_work(layout, m, n,
                a, lda, tau,
                work, lwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgeqrfp(Layout layout, int m, int n,
            double[] a, int lda, double[] tau);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dgeqrfp(Layout layout, int m, int n,
            double[] a, int lda, double[] tau)
            => LAPACKE_dgeqrfp(layout, m, n,
                a, lda, tau);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgeqrfp_work(Layout layout, int m, int n,
            double[] a, int lda, double[] tau,
            double[] work, int lwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dgeqrfp_work(Layout layout, int m, int n,
            double[] a, int lda, double[] tau,
            double[] work, int lwork)
            => LAPACKE_dgeqrfp_work(layout, m, n,
                a, lda, tau,
                work, lwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgeqrt(Layout layout, int m, int n,
            int nb, double[] a, int lda, double[] t,
            int ldt);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dgeqrt(Layout layout, int m, int n,
            int nb, double[] a, int lda, double[] t,
            int ldt)
            => LAPACKE_dgeqrt(layout, m, n,
                nb, a, lda, t,
                ldt);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgeqrt2(Layout layout, int m, int n,
            double[] a, int lda, double[] t,
            int ldt);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dgeqrt2(Layout layout, int m, int n,
            double[] a, int lda, double[] t,
            int ldt)
            => LAPACKE_dgeqrt2(layout, m, n,
                a, lda, t,
                ldt);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgeqrt2_work(Layout layout, int m, int n,
            double[] a, int lda, double[] t,
            int ldt);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dgeqrt2_work(Layout layout, int m, int n,
            double[] a, int lda, double[] t,
            int ldt)
            => LAPACKE_dgeqrt2_work(layout, m, n,
                a, lda, t,
                ldt);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgeqrt3(Layout layout, int m, int n,
            double[] a, int lda, double[] t,
            int ldt);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dgeqrt3(Layout layout, int m, int n,
            double[] a, int lda, double[] t,
            int ldt)
            => LAPACKE_dgeqrt3(layout, m, n,
                a, lda, t,
                ldt);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgeqrt3_work(Layout layout, int m, int n,
            double[] a, int lda, double[] t,
            int ldt);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dgeqrt3_work(Layout layout, int m, int n,
            double[] a, int lda, double[] t,
            int ldt)
            => LAPACKE_dgeqrt3_work(layout, m, n,
                a, lda, t,
                ldt);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgeqrt_work(Layout layout, int m, int n,
            int nb, double[] a, int lda,
            double[] t, int ldt, double[] work);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dgeqrt_work(Layout layout, int m, int n,
            int nb, double[] a, int lda,
            double[] t, int ldt, double[] work)
            => LAPACKE_dgeqrt_work(layout, m, n,
                nb, a, lda,
                t, ldt, work);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgerfs(Layout layout, TransChar trans, int n,
            int nrhs, double[] a, int lda,
            double[] af, int ldaf,
            int[] ipiv, double[] b,
            int ldb, double[] x, int ldx,
            double[] ferr, double[] berr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dgerfs(Layout layout, TransChar trans, int n,
            int nrhs, double[] a, int lda,
            double[] af, int ldaf,
            int[] ipiv, double[] b,
            int ldb, double[] x, int ldx,
            double[] ferr, double[] berr)
            => LAPACKE_dgerfs(layout, trans, n,
                nrhs, a, lda,
                af, ldaf,
                ipiv, b,
                ldb, x, ldx,
                ferr, berr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgerfs_work(Layout layout, TransChar trans, int n,
            int nrhs, double[] a,
            int lda, double[] af,
            int ldaf, int[] ipiv,
            double[] b, int ldb, double[] x,
            int ldx, double[] ferr, double[] berr,
            double[] work, int[] iwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dgerfs_work(Layout layout, TransChar trans, int n,
            int nrhs, double[] a,
            int lda, double[] af,
            int ldaf, int[] ipiv,
            double[] b, int ldb, double[] x,
            int ldx, double[] ferr, double[] berr,
            double[] work, int[] iwork)
            => LAPACKE_dgerfs_work(layout, trans, n,
                nrhs, a,
                lda, af,
                ldaf, ipiv,
                b, ldb, x,
                ldx, ferr, berr,
                work, iwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgerfsx(Layout layout, TransChar trans, char equed,
            int n, int nrhs, double[] a,
            int lda, double[] af, int ldaf,
            int[] ipiv, double[] r,
            double[] c, double[] b, int ldb,
            double[] x, int ldx, double[] rcond,
            double[] berr, int n_err_bnds,
            double[] err_bnds_norm, double[] err_bnds_comp,
            int nparams, double[] aparams);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dgerfsx(Layout layout, TransChar trans, char equed,
            int n, int nrhs, double[] a,
            int lda, double[] af, int ldaf,
            int[] ipiv, double[] r,
            double[] c, double[] b, int ldb,
            double[] x, int ldx, double[] rcond,
            double[] berr, int n_err_bnds,
            double[] err_bnds_norm, double[] err_bnds_comp,
            int nparams, double[] aparams)
            => LAPACKE_dgerfsx(layout, trans, equed,
                n, nrhs, a,
                lda, af, ldaf,
                ipiv, r,
                c, b, ldb,
                x, ldx, rcond,
                berr, n_err_bnds,
                err_bnds_norm, err_bnds_comp,
                nparams, aparams);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgerfsx_work(Layout layout, TransChar trans, char equed,
            int n, int nrhs, double[] a,
            int lda, double[] af,
            int ldaf, int[] ipiv,
            double[] r, double[] c,
            double[] b, int ldb, double[] x,
            int ldx, double[] rcond, double[] berr,
            int n_err_bnds, double[] err_bnds_norm,
            double[] err_bnds_comp, int nparams,
            double[] aparams, double[] work,
            int[] iwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dgerfsx_work(Layout layout, TransChar trans, char equed,
            int n, int nrhs, double[] a,
            int lda, double[] af,
            int ldaf, int[] ipiv,
            double[] r, double[] c,
            double[] b, int ldb, double[] x,
            int ldx, double[] rcond, double[] berr,
            int n_err_bnds, double[] err_bnds_norm,
            double[] err_bnds_comp, int nparams,
            double[] aparams, double[] work,
            int[] iwork)
            => LAPACKE_dgerfsx_work(layout, trans, equed,
                n, nrhs, a,
                lda, af,
                ldaf, ipiv,
                r, c,
                b, ldb, x,
                ldx, rcond, berr,
                n_err_bnds, err_bnds_norm,
                err_bnds_comp, nparams,
                aparams, work,
                iwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgerqf(Layout layout, int m, int n,
            double[] a, int lda, double[] tau);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dgerqf(Layout layout, int m, int n,
            double[] a, int lda, double[] tau)
            => LAPACKE_dgerqf(layout, m, n,
                a, lda, tau);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgerqf_work(Layout layout, int m, int n,
            double[] a, int lda, double[] tau,
            double[] work, int lwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dgerqf_work(Layout layout, int m, int n,
            double[] a, int lda, double[] tau,
            double[] work, int lwork)
            => LAPACKE_dgerqf_work(layout, m, n,
                a, lda, tau,
                work, lwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgesdd(Layout layout, char jobz, int m,
            int n, double[] a, int lda, double[] s,
            double[] u, int ldu, double[] vt,
            int ldvt);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dgesdd(Layout layout, char jobz, int m,
            int n, double[] a, int lda, double[] s,
            double[] u, int ldu, double[] vt,
            int ldvt)
            => LAPACKE_dgesdd(layout, jobz, m,
                n, a, lda, s,
                u, ldu, vt,
                ldvt);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgesdd_work(Layout layout, char jobz, int m,
            int n, double[] a, int lda,
            double[] s, double[] u, int ldu,
            double[] vt, int ldvt, double[] work,
            int lwork, int[] iwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dgesdd_work(Layout layout, char jobz, int m,
            int n, double[] a, int lda,
            double[] s, double[] u, int ldu,
            double[] vt, int ldvt, double[] work,
            int lwork, int[] iwork)
            => LAPACKE_dgesdd_work(layout, jobz, m,
                n, a, lda,
                s, u, ldu,
                vt, ldvt, work,
                lwork, iwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgesv(Layout layout, int n, int nrhs,
            double[] a, int lda, int[] ipiv,
            double[] b, int ldb);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dgesv(Layout layout, int n, int nrhs,
            double[] a, int lda, int[] ipiv,
            double[] b, int ldb)
            => LAPACKE_dgesv(layout, n, nrhs,
                a, lda, ipiv,
                b, ldb);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgesv_work(Layout layout, int n, int nrhs,
            double[] a, int lda, int[] ipiv,
            double[] b, int ldb);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dgesv_work(Layout layout, int n, int nrhs,
            double[] a, int lda, int[] ipiv,
            double[] b, int ldb)
            => LAPACKE_dgesv_work(layout, n, nrhs,
                a, lda, ipiv,
                b, ldb);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgesvd(Layout layout, char jobu, char jobvt,
            int m, int n, double[] a,
            int lda, double[] s, double[] u, int ldu,
            double[] vt, int ldvt, double[] superb);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dgesvd(Layout layout, char jobu, char jobvt,
            int m, int n, double[] a,
            int lda, double[] s, double[] u, int ldu,
            double[] vt, int ldvt, double[] superb)
            => LAPACKE_dgesvd(layout, jobu, jobvt,
                m, n, a,
                lda, s, u, ldu,
                vt, ldvt, superb);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgesvd_work(Layout layout, char jobu, char jobvt,
            int m, int n, double[] a,
            int lda, double[] s, double[] u,
            int ldu, double[] vt, int ldvt,
            double[] work, int lwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dgesvd_work(Layout layout, char jobu, char jobvt,
            int m, int n, double[] a,
            int lda, double[] s, double[] u,
            int ldu, double[] vt, int ldvt,
            double[] work, int lwork)
            => LAPACKE_dgesvd_work(layout, jobu, jobvt,
                m, n, a,
                lda, s, u,
                ldu, vt, ldvt,
                work, lwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgesvdx(Layout layout, char jobu, char jobvt, char range,
            int m, int n, double[] a,
            int lda, double vl, double vu,
            int il, int iu, int[] ns,
            double[] s, double[] u, int ldu,
            double[] vt, int ldvt,
            int[] superb);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dgesvdx(Layout layout, char jobu, char jobvt, char range,
            int m, int n, double[] a,
            int lda, double vl, double vu,
            int il, int iu, int[] ns,
            double[] s, double[] u, int ldu,
            double[] vt, int ldvt,
            int[] superb)
            => LAPACKE_dgesvdx(layout, jobu, jobvt, range,
                m, n, a,
                lda, vl, vu,
                il, iu, ns,
                s, u, ldu,
                vt, ldvt,
                superb);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgesvdx_work(Layout layout, char jobu, char jobvt, char range,
            int m, int n, double[] a,
            int lda, double vl, double vu,
            int il, int iu, int[] ns,
            double[] s, double[] u, int ldu,
            double[] vt, int ldvt,
            double[] work, int lwork, int[] iwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dgesvdx_work(Layout layout, char jobu, char jobvt, char range,
            int m, int n, double[] a,
            int lda, double vl, double vu,
            int il, int iu, int[] ns,
            double[] s, double[] u, int ldu,
            double[] vt, int ldvt,
            double[] work, int lwork, int[] iwork)
            => LAPACKE_dgesvdx_work(layout, jobu, jobvt, range,
                m, n, a,
                lda, vl, vu,
                il, iu, ns,
                s, u, ldu,
                vt, ldvt,
                work, lwork, iwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgesvj(Layout layout, char joba, char jobu, char jobv,
            int m, int n, double[] a,
            int lda, double[] sva, int mv,
            double[] v, int ldv, double[] stat);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dgesvj(Layout layout, char joba, char jobu, char jobv,
            int m, int n, double[] a,
            int lda, double[] sva, int mv,
            double[] v, int ldv, double[] stat)
            => LAPACKE_dgesvj(layout, joba, jobu, jobv,
                m, n, a,
                lda, sva, mv,
                v, ldv, stat);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgesvj_work(Layout layout, char joba, char jobu,
            char jobv, int m, int n,
            double[] a, int lda, double[] sva,
            int mv, double[] v, int ldv,
            double[] work, int lwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dgesvj_work(Layout layout, char joba, char jobu,
            char jobv, int m, int n,
            double[] a, int lda, double[] sva,
            int mv, double[] v, int ldv,
            double[] work, int lwork)
            => LAPACKE_dgesvj_work(layout, joba, jobu,
                jobv, m, n,
                a, lda, sva,
                mv, v, ldv,
                work, lwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgesvx(Layout layout, char fact, TransChar trans,
            int n, int nrhs, double[] a,
            int lda, double[] af, int ldaf,
            int[] ipiv, char[] equed, double[] r, double[] c,
            double[] b, int ldb, double[] x, int ldx,
            double[] rcond, double[] ferr, double[] berr,
            double[] rpivot);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dgesvx(Layout layout, char fact, TransChar trans,
            int n, int nrhs, double[] a,
            int lda, double[] af, int ldaf,
            int[] ipiv, char[] equed, double[] r, double[] c,
            double[] b, int ldb, double[] x, int ldx,
            double[] rcond, double[] ferr, double[] berr,
            double[] rpivot)
            => LAPACKE_dgesvx(layout, fact, trans,
                n, nrhs, a,
                lda, af, ldaf,
                ipiv, equed, r, c,
                b, ldb, x, ldx,
                rcond, ferr, berr,
                rpivot);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgesvx_work(Layout layout, char fact, TransChar trans,
            int n, int nrhs, double[] a,
            int lda, double[] af, int ldaf,
            int[] ipiv, char[] equed, double[] r,
            double[] c, double[] b, int ldb, double[] x,
            int ldx, double[] rcond, double[] ferr,
            double[] berr, double[] work, int[] iwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dgesvx_work(Layout layout, char fact, TransChar trans,
            int n, int nrhs, double[] a,
            int lda, double[] af, int ldaf,
            int[] ipiv, char[] equed, double[] r,
            double[] c, double[] b, int ldb, double[] x,
            int ldx, double[] rcond, double[] ferr,
            double[] berr, double[] work, int[] iwork)
            => LAPACKE_dgesvx_work(layout, fact, trans,
                n, nrhs, a,
                lda, af, ldaf,
                ipiv, equed, r,
                c, b, ldb, x,
                ldx, rcond, ferr,
                berr, work, iwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgesvxx(Layout layout, char fact, TransChar trans,
            int n, int nrhs, double[] a,
            int lda, double[] af, int ldaf,
            int[] ipiv, char[] equed, double[] r, double[] c,
            double[] b, int ldb, double[] x,
            int ldx, double[] rcond, double[] rpvgrw,
            double[] berr, int n_err_bnds,
            double[] err_bnds_norm, double[] err_bnds_comp,
            int nparams, double[] aparams);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dgesvxx(Layout layout, char fact, TransChar trans,
            int n, int nrhs, double[] a,
            int lda, double[] af, int ldaf,
            int[] ipiv, char[] equed, double[] r, double[] c,
            double[] b, int ldb, double[] x,
            int ldx, double[] rcond, double[] rpvgrw,
            double[] berr, int n_err_bnds,
            double[] err_bnds_norm, double[] err_bnds_comp,
            int nparams, double[] aparams)
            => LAPACKE_dgesvxx(layout, fact, trans,
                n, nrhs, a,
                lda, af, ldaf,
                ipiv, equed, r, c,
                b, ldb, x,
                ldx, rcond, rpvgrw,
                berr, n_err_bnds,
                err_bnds_norm, err_bnds_comp,
                nparams, aparams);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgesvxx_work(Layout layout, char fact, TransChar trans,
            int n, int nrhs, double[] a,
            int lda, double[] af, int ldaf,
            int[] ipiv, char[] equed, double[] r,
            double[] c, double[] b, int ldb,
            double[] x, int ldx, double[] rcond,
            double[] rpvgrw, double[] berr,
            int n_err_bnds, double[] err_bnds_norm,
            double[] err_bnds_comp, int nparams,
            double[] aparams, double[] work,
            int[] iwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dgesvxx_work(Layout layout, char fact, TransChar trans,
            int n, int nrhs, double[] a,
            int lda, double[] af, int ldaf,
            int[] ipiv, char[] equed, double[] r,
            double[] c, double[] b, int ldb,
            double[] x, int ldx, double[] rcond,
            double[] rpvgrw, double[] berr,
            int n_err_bnds, double[] err_bnds_norm,
            double[] err_bnds_comp, int nparams,
            double[] aparams, double[] work,
            int[] iwork)
            => LAPACKE_dgesvxx_work(layout, fact, trans,
                n, nrhs, a,
                lda, af, ldaf,
                ipiv, equed, r,
                c, b, ldb,
                x, ldx, rcond,
                rpvgrw, berr,
                n_err_bnds, err_bnds_norm,
                err_bnds_comp, nparams,
                aparams, work,
                iwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgetf2(Layout layout, int m, int n,
            double[] a, int lda, int[] ipiv);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dgetf2(Layout layout, int m, int n,
            double[] a, int lda, int[] ipiv)
            => LAPACKE_dgetf2(layout, m, n,
                a, lda, ipiv);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgetf2_work(Layout layout, int m, int n,
            double[] a, int lda, int[] ipiv);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dgetf2_work(Layout layout, int m, int n,
            double[] a, int lda, int[] ipiv)
            => LAPACKE_dgetf2_work(layout, m, n,
                a, lda, ipiv);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgetrf(Layout layout, int m, int n,
            double[] a, int lda, int[] ipiv);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dgetrf(Layout layout, int m, int n,
            double[] a, int lda, int[] ipiv)
            => LAPACKE_dgetrf(layout, m, n,
                a, lda, ipiv);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgetrf2(Layout layout, int m, int n,
            double[] a, int lda, int[] ipiv);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dgetrf2(Layout layout, int m, int n,
            double[] a, int lda, int[] ipiv)
            => LAPACKE_dgetrf2(layout, m, n,
                a, lda, ipiv);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgetrf2_work(Layout layout, int m, int n,
            double[] a, int lda, int[] ipiv);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dgetrf2_work(Layout layout, int m, int n,
            double[] a, int lda, int[] ipiv)
            => LAPACKE_dgetrf2_work(layout, m, n,
                a, lda, ipiv);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgetrf_work(Layout layout, int m, int n,
            double[] a, int lda, int[] ipiv);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dgetrf_work(Layout layout, int m, int n,
            double[] a, int lda, int[] ipiv)
            => LAPACKE_dgetrf_work(layout, m, n,
                a, lda, ipiv);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgetri(Layout layout, int n, double[] a,
            int lda, int[] ipiv);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dgetri(Layout layout, int n, double[] a,
            int lda, int[] ipiv)
            => LAPACKE_dgetri(layout, n, a,
                lda, ipiv);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgetri_work(Layout layout, int n, double[] a,
            int lda, int[] ipiv,
            double[] work, int lwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dgetri_work(Layout layout, int n, double[] a,
            int lda, int[] ipiv,
            double[] work, int lwork)
            => LAPACKE_dgetri_work(layout, n, a,
                lda, ipiv,
                work, lwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgetrs(Layout layout, TransChar trans, int n,
            int nrhs, double[] a, int lda,
            int[] ipiv, double[] b, int ldb);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dgetrs(Layout layout, TransChar trans, int n,
            int nrhs, double[] a, int lda,
            int[] ipiv, double[] b, int ldb)
            => LAPACKE_dgetrs(layout, trans, n,
                nrhs, a, lda,
                ipiv, b, ldb);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgetrs_work(Layout layout, TransChar trans, int n,
            int nrhs, double[] a,
            int lda, int[] ipiv,
            double[] b, int ldb);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dgetrs_work(Layout layout, TransChar trans, int n,
            int nrhs, double[] a,
            int lda, int[] ipiv,
            double[] b, int ldb)
            => LAPACKE_dgetrs_work(layout, trans, n,
                nrhs, a,
                lda, ipiv,
                b, ldb);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dggbak(Layout layout, char job, char side, int n,
            int ilo, int ihi, double[] lscale,
            double[] rscale, int m, double[] v,
            int ldv);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dggbak(Layout layout, char job, char side, int n,
            int ilo, int ihi, double[] lscale,
            double[] rscale, int m, double[] v,
            int ldv)
            => LAPACKE_dggbak(layout, job, side, n,
                ilo, ihi, lscale,
                rscale, m, v,
                ldv);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dggbak_work(Layout layout, char job, char side,
            int n, int ilo, int ihi,
            double[] lscale, double[] rscale,
            int m, double[] v, int ldv);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dggbak_work(Layout layout, char job, char side,
            int n, int ilo, int ihi,
            double[] lscale, double[] rscale,
            int m, double[] v, int ldv)
            => LAPACKE_dggbak_work(layout, job, side,
                n, ilo, ihi,
                lscale, rscale,
                m, v, ldv);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dggbal(Layout layout, char job, int n, double[] a,
            int lda, double[] b, int ldb,
            int[] ilo, int[] ihi, double[] lscale,
            double[] rscale);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dggbal(Layout layout, char job, int n, double[] a,
            int lda, double[] b, int ldb,
            int[] ilo, int[] ihi, double[] lscale,
            double[] rscale)
            => LAPACKE_dggbal(layout, job, n, a,
                lda, b, ldb,
                ilo, ihi, lscale,
                rscale);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dggbal_work(Layout layout, char job, int n,
            double[] a, int lda, double[] b,
            int ldb, int[] ilo,
            int[] ihi, double[] lscale, double[] rscale,
            double[] work);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dggbal_work(Layout layout, char job, int n,
            double[] a, int lda, double[] b,
            int ldb, int[] ilo,
            int[] ihi, double[] lscale, double[] rscale,
            double[] work)
            => LAPACKE_dggbal_work(layout, job, n,
                a, lda, b,
                ldb, ilo,
                ihi, lscale, rscale,
                work);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dggev(Layout layout, char jobvl, char jobvr,
            int n, double[] a, int lda, double[] b,
            int ldb, double[] alphar, double[] alphai,
            double[] beta, double[] vl, int ldvl, double[] vr,
            int ldvr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dggev(Layout layout, char jobvl, char jobvr,
            int n, double[] a, int lda, double[] b,
            int ldb, double[] alphar, double[] alphai,
            double[] beta, double[] vl, int ldvl, double[] vr,
            int ldvr)
            => LAPACKE_dggev(layout, jobvl, jobvr,
                n, a, lda, b,
                ldb, alphar, alphai,
                beta, vl, ldvl, vr,
                ldvr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dggev3(Layout layout,
            char jobvl, char jobvr, int n,
            double[] a, int lda,
            double[] b, int ldb,
            double[] alphar, double[] alphai, double[] beta,
            double[] vl, int ldvl,
            double[] vr, int ldvr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dggev3(Layout layout,
            char jobvl, char jobvr, int n,
            double[] a, int lda,
            double[] b, int ldb,
            double[] alphar, double[] alphai, double[] beta,
            double[] vl, int ldvl,
            double[] vr, int ldvr)
            => LAPACKE_dggev3(layout,
                jobvl, jobvr, n,
                a, lda,
                b, ldb,
                alphar, alphai, beta,
                vl, ldvl,
                vr, ldvr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dggev3_work(Layout layout, char jobvl, char jobvr,
            int n, double[] a, int lda,
            double[] b, int ldb, double[] alphar,
            double[] alphai, double[] beta, double[] vl,
            int ldvl, double[] vr, int ldvr,
            double[] work, int lwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dggev3_work(Layout layout, char jobvl, char jobvr,
            int n, double[] a, int lda,
            double[] b, int ldb, double[] alphar,
            double[] alphai, double[] beta, double[] vl,
            int ldvl, double[] vr, int ldvr,
            double[] work, int lwork)
            => LAPACKE_dggev3_work(layout, jobvl, jobvr,
                n, a, lda,
                b, ldb, alphar,
                alphai, beta, vl,
                ldvl, vr, ldvr,
                work, lwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dggev_work(Layout layout, char jobvl, char jobvr,
            int n, double[] a, int lda,
            double[] b, int ldb, double[] alphar,
            double[] alphai, double[] beta, double[] vl,
            int ldvl, double[] vr, int ldvr,
            double[] work, int lwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dggev_work(Layout layout, char jobvl, char jobvr,
            int n, double[] a, int lda,
            double[] b, int ldb, double[] alphar,
            double[] alphai, double[] beta, double[] vl,
            int ldvl, double[] vr, int ldvr,
            double[] work, int lwork)
            => LAPACKE_dggev_work(layout, jobvl, jobvr,
                n, a, lda,
                b, ldb, alphar,
                alphai, beta, vl,
                ldvl, vr, ldvr,
                work, lwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dggevx(Layout layout, char balanc, char jobvl,
            char jobvr, char sense, int n, double[] a,
            int lda, double[] b, int ldb,
            double[] alphar, double[] alphai, double[] beta,
            double[] vl, int ldvl, double[] vr,
            int ldvr, int[] ilo, int[] ihi,
            double[] lscale, double[] rscale, double[] abnrm,
            double[] bbnrm, double[] rconde, double[] rcondv);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dggevx(Layout layout, char balanc, char jobvl,
            char jobvr, char sense, int n, double[] a,
            int lda, double[] b, int ldb,
            double[] alphar, double[] alphai, double[] beta,
            double[] vl, int ldvl, double[] vr,
            int ldvr, int[] ilo, int[] ihi,
            double[] lscale, double[] rscale, double[] abnrm,
            double[] bbnrm, double[] rconde, double[] rcondv)
            => LAPACKE_dggevx(layout, balanc, jobvl,
                jobvr, sense, n, a,
                lda, b, ldb,
                alphar, alphai, beta,
                vl, ldvl, vr,
                ldvr, ilo, ihi,
                lscale, rscale, abnrm,
                bbnrm, rconde, rcondv);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dggevx_work(Layout layout, char balanc, char jobvl,
            char jobvr, char sense, int n, double[] a,
            int lda, double[] b, int ldb,
            double[] alphar, double[] alphai, double[] beta,
            double[] vl, int ldvl, double[] vr,
            int ldvr, int[] ilo,
            int[] ihi, double[] lscale, double[] rscale,
            double[] abnrm, double[] bbnrm, double[] rconde,
            double[] rcondv, double[] work, int lwork,
            int[] iwork, int[] bwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dggevx_work(Layout layout, char balanc, char jobvl,
            char jobvr, char sense, int n, double[] a,
            int lda, double[] b, int ldb,
            double[] alphar, double[] alphai, double[] beta,
            double[] vl, int ldvl, double[] vr,
            int ldvr, int[] ilo,
            int[] ihi, double[] lscale, double[] rscale,
            double[] abnrm, double[] bbnrm, double[] rconde,
            double[] rcondv, double[] work, int lwork,
            int[] iwork, int[] bwork)
            => LAPACKE_dggevx_work(layout, balanc, jobvl,
                jobvr, sense, n, a,
                lda, b, ldb,
                alphar, alphai, beta,
                vl, ldvl, vr,
                ldvr, ilo,
                ihi, lscale, rscale,
                abnrm, bbnrm, rconde,
                rcondv, work, lwork,
                iwork, bwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dggglm(Layout layout, int n, int m,
            int p, double[] a, int lda, double[] b,
            int ldb, double[] d, double[] x, double[] y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dggglm(Layout layout, int n, int m,
            int p, double[] a, int lda, double[] b,
            int ldb, double[] d, double[] x, double[] y)
            => LAPACKE_dggglm(layout, n, m,
                p, a, lda, b,
                ldb, d, x, y);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dggglm_work(Layout layout, int n, int m,
            int p, double[] a, int lda,
            double[] b, int ldb, double[] d, double[] x,
            double[] y, double[] work, int lwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dggglm_work(Layout layout, int n, int m,
            int p, double[] a, int lda,
            double[] b, int ldb, double[] d, double[] x,
            double[] y, double[] work, int lwork)
            => LAPACKE_dggglm_work(layout, n, m,
                p, a, lda,
                b, ldb, d, x,
                y, work, lwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgghd3(Layout layout, char compq, char compz,
            int n, int ilo, int ihi,
            double[] a, int lda,
            double[] b, int ldb,
            double[] q, int ldq,
            double[] z, int ldz);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dgghd3(Layout layout, char compq, char compz,
            int n, int ilo, int ihi,
            double[] a, int lda,
            double[] b, int ldb,
            double[] q, int ldq,
            double[] z, int ldz)
            => LAPACKE_dgghd3(layout, compq, compz,
                n, ilo, ihi,
                a, lda,
                b, ldb,
                q, ldq,
                z, ldz);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgghd3_work(Layout layout, char compq, char compz,
            int n, int ilo, int ihi,
            double[] a, int lda, double[] b,
            int ldb, double[] q, int ldq,
            double[] z, int ldz, double[] work,
            int lwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dgghd3_work(Layout layout, char compq, char compz,
            int n, int ilo, int ihi,
            double[] a, int lda, double[] b,
            int ldb, double[] q, int ldq,
            double[] z, int ldz, double[] work,
            int lwork)
            => LAPACKE_dgghd3_work(layout, compq, compz,
                n, ilo, ihi,
                a, lda, b,
                ldb, q, ldq,
                z, ldz, work,
                lwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgghrd(Layout layout, char compq, char compz,
            int n, int ilo, int ihi,
            double[] a, int lda, double[] b, int ldb,
            double[] q, int ldq, double[] z,
            int ldz);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dgghrd(Layout layout, char compq, char compz,
            int n, int ilo, int ihi,
            double[] a, int lda, double[] b, int ldb,
            double[] q, int ldq, double[] z,
            int ldz)
            => LAPACKE_dgghrd(layout, compq, compz,
                n, ilo, ihi,
                a, lda, b, ldb,
                q, ldq, z,
                ldz);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgghrd_work(Layout layout, char compq, char compz,
            int n, int ilo, int ihi,
            double[] a, int lda, double[] b,
            int ldb, double[] q, int ldq,
            double[] z, int ldz);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dgghrd_work(Layout layout, char compq, char compz,
            int n, int ilo, int ihi,
            double[] a, int lda, double[] b,
            int ldb, double[] q, int ldq,
            double[] z, int ldz)
            => LAPACKE_dgghrd_work(layout, compq, compz,
                n, ilo, ihi,
                a, lda, b,
                ldb, q, ldq,
                z, ldz);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgglse(Layout layout, int m, int n,
            int p, double[] a, int lda, double[] b,
            int ldb, double[] c, double[] d, double[] x);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dgglse(Layout layout, int m, int n,
            int p, double[] a, int lda, double[] b,
            int ldb, double[] c, double[] d, double[] x)
            => LAPACKE_dgglse(layout, m, n,
                p, a, lda, b,
                ldb, c, d, x);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgglse_work(Layout layout, int m, int n,
            int p, double[] a, int lda,
            double[] b, int ldb, double[] c, double[] d,
            double[] x, double[] work, int lwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dgglse_work(Layout layout, int m, int n,
            int p, double[] a, int lda,
            double[] b, int ldb, double[] c, double[] d,
            double[] x, double[] work, int lwork)
            => LAPACKE_dgglse_work(layout, m, n,
                p, a, lda,
                b, ldb, c, d,
                x, work, lwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dggqrf(Layout layout, int n, int m,
            int p, double[] a, int lda,
            double[] taua, double[] b, int ldb,
            double[] taub);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dggqrf(Layout layout, int n, int m,
            int p, double[] a, int lda,
            double[] taua, double[] b, int ldb,
            double[] taub)
            => LAPACKE_dggqrf(layout, n, m,
                p, a, lda,
                taua, b, ldb,
                taub);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dggqrf_work(Layout layout, int n, int m,
            int p, double[] a, int lda,
            double[] taua, double[] b, int ldb,
            double[] taub, double[] work, int lwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dggqrf_work(Layout layout, int n, int m,
            int p, double[] a, int lda,
            double[] taua, double[] b, int ldb,
            double[] taub, double[] work, int lwork)
            => LAPACKE_dggqrf_work(layout, n, m,
                p, a, lda,
                taua, b, ldb,
                taub, work, lwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dggrqf(Layout layout, int m, int p,
            int n, double[] a, int lda,
            double[] taua, double[] b, int ldb,
            double[] taub);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dggrqf(Layout layout, int m, int p,
            int n, double[] a, int lda,
            double[] taua, double[] b, int ldb,
            double[] taub)
            => LAPACKE_dggrqf(layout, m, p,
                n, a, lda,
                taua, b, ldb,
                taub);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dggrqf_work(Layout layout, int m, int p,
            int n, double[] a, int lda,
            double[] taua, double[] b, int ldb,
            double[] taub, double[] work, int lwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dggrqf_work(Layout layout, int m, int p,
            int n, double[] a, int lda,
            double[] taua, double[] b, int ldb,
            double[] taub, double[] work, int lwork)
            => LAPACKE_dggrqf_work(layout, m, p,
                n, a, lda,
                taua, b, ldb,
                taub, work, lwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dggsvd(Layout layout, char jobu, char jobv, char jobq,
            int m, int n, int p,
            int[] k, int[] l, double[] a,
            int lda, double[] b, int ldb,
            double[] alpha, double[] beta, double[] u,
            int ldu, double[] v, int ldv, double[] q,
            int ldq, int[] iwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dggsvd(Layout layout, char jobu, char jobv, char jobq,
            int m, int n, int p,
            int[] k, int[] l, double[] a,
            int lda, double[] b, int ldb,
            double[] alpha, double[] beta, double[] u,
            int ldu, double[] v, int ldv, double[] q,
            int ldq, int[] iwork)
            => LAPACKE_dggsvd(layout, jobu, jobv, jobq,
                m, n, p,
                k, l, a,
                lda, b, ldb,
                alpha, beta, u,
                ldu, v, ldv, q,
                ldq, iwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dggsvd3(Layout layout, char jobu, char jobv, char jobq,
            int m, int n, int p,
            int[] k, int[] l, double[] a,
            int lda, double[] b, int ldb,
            double[] alpha, double[] beta, double[] u,
            int ldu, double[] v, int ldv, double[] q,
            int ldq, int[] iwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dggsvd3(Layout layout, char jobu, char jobv, char jobq,
            int m, int n, int p,
            int[] k, int[] l, double[] a,
            int lda, double[] b, int ldb,
            double[] alpha, double[] beta, double[] u,
            int ldu, double[] v, int ldv, double[] q,
            int ldq, int[] iwork)
            => LAPACKE_dggsvd3(layout, jobu, jobv, jobq,
                m, n, p,
                k, l, a,
                lda, b, ldb,
                alpha, beta, u,
                ldu, v, ldv, q,
                ldq, iwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dggsvd3_work(Layout layout, char jobu, char jobv,
            char jobq, int m, int n,
            int p, int[] k, int[] l,
            double[] a, int lda, double[] b,
            int ldb, double[] alpha, double[] beta,
            double[] u, int ldu, double[] v,
            int ldv, double[] q, int ldq,
            double[] work, int lwork,
            int[] iwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dggsvd3_work(Layout layout, char jobu, char jobv,
            char jobq, int m, int n,
            int p, int[] k, int[] l,
            double[] a, int lda, double[] b,
            int ldb, double[] alpha, double[] beta,
            double[] u, int ldu, double[] v,
            int ldv, double[] q, int ldq,
            double[] work, int lwork,
            int[] iwork)
            => LAPACKE_dggsvd3_work(layout, jobu, jobv,
                jobq, m, n,
                p, k, l,
                a, lda, b,
                ldb, alpha, beta,
                u, ldu, v,
                ldv, q, ldq,
                work, lwork,
                iwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dggsvd_work(Layout layout, char jobu, char jobv,
            char jobq, int m, int n,
            int p, int[] k, int[] l,
            double[] a, int lda, double[] b,
            int ldb, double[] alpha, double[] beta,
            double[] u, int ldu, double[] v,
            int ldv, double[] q, int ldq,
            double[] work, int[] iwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dggsvd_work(Layout layout, char jobu, char jobv,
            char jobq, int m, int n,
            int p, int[] k, int[] l,
            double[] a, int lda, double[] b,
            int ldb, double[] alpha, double[] beta,
            double[] u, int ldu, double[] v,
            int ldv, double[] q, int ldq,
            double[] work, int[] iwork)
            => LAPACKE_dggsvd_work(layout, jobu, jobv,
                jobq, m, n,
                p, k, l,
                a, lda, b,
                ldb, alpha, beta,
                u, ldu, v,
                ldv, q, ldq,
                work, iwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dggsvp(Layout layout, char jobu, char jobv, char jobq,
            int m, int p, int n, double[] a,
            int lda, double[] b, int ldb,
            double tola, double tolb, int[] k,
            int[] l, double[] u, int ldu, double[] v,
            int ldv, double[] q, int ldq);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dggsvp(Layout layout, char jobu, char jobv, char jobq,
            int m, int p, int n, double[] a,
            int lda, double[] b, int ldb,
            double tola, double tolb, int[] k,
            int[] l, double[] u, int ldu, double[] v,
            int ldv, double[] q, int ldq)
            => LAPACKE_dggsvp(layout, jobu, jobv, jobq,
                m, p, n, a,
                lda, b, ldb,
                tola, tolb, k,
                l, u, ldu, v,
                ldv, q, ldq);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dggsvp3(Layout layout, char jobu, char jobv, char jobq,
            int m, int p, int n, double[] a,
            int lda, double[] b, int ldb,
            double tola, double tolb, int[] k,
            int[] l, double[] u, int ldu, double[] v,
            int ldv, double[] q, int ldq);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dggsvp3(Layout layout, char jobu, char jobv, char jobq,
            int m, int p, int n, double[] a,
            int lda, double[] b, int ldb,
            double tola, double tolb, int[] k,
            int[] l, double[] u, int ldu, double[] v,
            int ldv, double[] q, int ldq)
            => LAPACKE_dggsvp3(layout, jobu, jobv, jobq,
                m, p, n, a,
                lda, b, ldb,
                tola, tolb, k,
                l, u, ldu, v,
                ldv, q, ldq);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dggsvp3_work(Layout layout, char jobu, char jobv,
            char jobq, int m, int p,
            int n, double[] a, int lda,
            double[] b, int ldb, double tola,
            double tolb, int[] k, int[] l,
            double[] u, int ldu, double[] v,
            int ldv, double[] q, int ldq,
            int[] iwork, double[] tau, double[] work,
            int lwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dggsvp3_work(Layout layout, char jobu, char jobv,
            char jobq, int m, int p,
            int n, double[] a, int lda,
            double[] b, int ldb, double tola,
            double tolb, int[] k, int[] l,
            double[] u, int ldu, double[] v,
            int ldv, double[] q, int ldq,
            int[] iwork, double[] tau, double[] work,
            int lwork)
            => LAPACKE_dggsvp3_work(layout, jobu, jobv,
                jobq, m, p,
                n, a, lda,
                b, ldb, tola,
                tolb, k, l,
                u, ldu, v,
                ldv, q, ldq,
                iwork, tau, work,
                lwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dggsvp_work(Layout layout, char jobu, char jobv,
            char jobq, int m, int p,
            int n, double[] a, int lda,
            double[] b, int ldb, double tola,
            double tolb, int[] k, int[] l,
            double[] u, int ldu, double[] v,
            int ldv, double[] q, int ldq,
            int[] iwork, double[] tau, double[] work);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dggsvp_work(Layout layout, char jobu, char jobv,
            char jobq, int m, int p,
            int n, double[] a, int lda,
            double[] b, int ldb, double tola,
            double tolb, int[] k, int[] l,
            double[] u, int ldu, double[] v,
            int ldv, double[] q, int ldq,
            int[] iwork, double[] tau, double[] work)
            => LAPACKE_dggsvp_work(layout, jobu, jobv,
                jobq, m, p,
                n, a, lda,
                b, ldb, tola,
                tolb, k, l,
                u, ldu, v,
                ldv, q, ldq,
                iwork, tau, work);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgtcon(Norm norm, int n, double[] dl,
            double[] d, double[] du, double[] du2,
            int[] ipiv, double anorm, double[] rcond);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dgtcon(Norm norm, int n, double[] dl,
            double[] d, double[] du, double[] du2,
            int[] ipiv, double anorm, double[] rcond)
            => LAPACKE_dgtcon(norm, n, dl,
                d, du, du2,
                ipiv, anorm, rcond);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgtcon_work(Norm norm, int n, double[] dl,
            double[] d, double[] du,
            double[] du2, int[] ipiv,
            double anorm, double[] rcond, double[] work,
            int[] iwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dgtcon_work(Norm norm, int n, double[] dl,
            double[] d, double[] du,
            double[] du2, int[] ipiv,
            double anorm, double[] rcond, double[] work,
            int[] iwork)
            => LAPACKE_dgtcon_work(norm, n, dl,
                d, du,
                du2, ipiv,
                anorm, rcond, work,
                iwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgtrfs(Layout layout, TransChar trans, int n,
            int nrhs, double[] dl, double[] d,
            double[] du, double[] dlf,
            double[] df, double[] duf,
            double[] du2, int[] ipiv,
            double[] b, int ldb, double[] x,
            int ldx, double[] ferr, double[] berr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dgtrfs(Layout layout, TransChar trans, int n,
            int nrhs, double[] dl, double[] d,
            double[] du, double[] dlf,
            double[] df, double[] duf,
            double[] du2, int[] ipiv,
            double[] b, int ldb, double[] x,
            int ldx, double[] ferr, double[] berr)
            => LAPACKE_dgtrfs(layout, trans, n,
                nrhs, dl, d,
                du, dlf,
                df, duf,
                du2, ipiv,
                b, ldb, x,
                ldx, ferr, berr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgtrfs_work(Layout layout, TransChar trans, int n,
            int nrhs, double[] dl,
            double[] d, double[] du,
            double[] dlf, double[] df,
            double[] duf, double[] du2,
            int[] ipiv, double[] b,
            int ldb, double[] x, int ldx,
            double[] ferr, double[] berr, double[] work,
            int[] iwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dgtrfs_work(Layout layout, TransChar trans, int n,
            int nrhs, double[] dl,
            double[] d, double[] du,
            double[] dlf, double[] df,
            double[] duf, double[] du2,
            int[] ipiv, double[] b,
            int ldb, double[] x, int ldx,
            double[] ferr, double[] berr, double[] work,
            int[] iwork)
            => LAPACKE_dgtrfs_work(layout, trans, n,
                nrhs, dl,
                d, du,
                dlf, df,
                duf, du2,
                ipiv, b,
                ldb, x, ldx,
                ferr, berr, work,
                iwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgtsv(Layout layout, int n, int nrhs,
            double[] dl, double[] d, double[] du, double[] b,
            int ldb);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dgtsv(Layout layout, int n, int nrhs,
            double[] dl, double[] d, double[] du, double[] b,
            int ldb)
            => LAPACKE_dgtsv(layout, n, nrhs,
                dl, d, du, b,
                ldb);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgtsv_work(Layout layout, int n, int nrhs,
            double[] dl, double[] d, double[] du, double[] b,
            int ldb);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dgtsv_work(Layout layout, int n, int nrhs,
            double[] dl, double[] d, double[] du, double[] b,
            int ldb)
            => LAPACKE_dgtsv_work(layout, n, nrhs,
                dl, d, du, b,
                ldb);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgtsvx(Layout layout, char fact, TransChar trans,
            int n, int nrhs, double[] dl,
            double[] d, double[] du, double[] dlf,
            double[] df, double[] duf, double[] du2,
            int[] ipiv, double[] b, int ldb,
            double[] x, int ldx, double[] rcond,
            double[] ferr, double[] berr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dgtsvx(Layout layout, char fact, TransChar trans,
            int n, int nrhs, double[] dl,
            double[] d, double[] du, double[] dlf,
            double[] df, double[] duf, double[] du2,
            int[] ipiv, double[] b, int ldb,
            double[] x, int ldx, double[] rcond,
            double[] ferr, double[] berr)
            => LAPACKE_dgtsvx(layout, fact, trans,
                n, nrhs, dl,
                d, du, dlf,
                df, duf, du2,
                ipiv, b, ldb,
                x, ldx, rcond,
                ferr, berr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgtsvx_work(Layout layout, char fact, TransChar trans,
            int n, int nrhs, double[] dl,
            double[] d, double[] du, double[] dlf,
            double[] df, double[] duf, double[] du2,
            int[] ipiv, double[] b,
            int ldb, double[] x, int ldx,
            double[] rcond, double[] ferr, double[] berr,
            double[] work, int[] iwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dgtsvx_work(Layout layout, char fact, TransChar trans,
            int n, int nrhs, double[] dl,
            double[] d, double[] du, double[] dlf,
            double[] df, double[] duf, double[] du2,
            int[] ipiv, double[] b,
            int ldb, double[] x, int ldx,
            double[] rcond, double[] ferr, double[] berr,
            double[] work, int[] iwork)
            => LAPACKE_dgtsvx_work(layout, fact, trans,
                n, nrhs, dl,
                d, du, dlf,
                df, duf, du2,
                ipiv, b,
                ldb, x, ldx,
                rcond, ferr, berr,
                work, iwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgttrf(int n, double[] dl, double[] d, double[] du,
            double[] du2, int[] ipiv);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dgttrf(int n, double[] dl, double[] d, double[] du,
            double[] du2, int[] ipiv)
            => LAPACKE_dgttrf(n, dl, d, du,
                du2, ipiv);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgttrf_work(int n, double[] dl, double[] d, double[] du,
            double[] du2, int[] ipiv);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dgttrf_work(int n, double[] dl, double[] d, double[] du,
            double[] du2, int[] ipiv)
            => LAPACKE_dgttrf_work(n, dl, d, du,
                du2, ipiv);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgttrs(Layout layout, TransChar trans, int n,
            int nrhs, double[] dl, double[] d,
            double[] du, double[] du2,
            int[] ipiv, double[] b, int ldb);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dgttrs(Layout layout, TransChar trans, int n,
            int nrhs, double[] dl, double[] d,
            double[] du, double[] du2,
            int[] ipiv, double[] b, int ldb)
            => LAPACKE_dgttrs(layout, trans, n,
                nrhs, dl, d,
                du, du2,
                ipiv, b, ldb);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgttrs_work(Layout layout, TransChar trans, int n,
            int nrhs, double[] dl,
            double[] d, double[] du,
            double[] du2, int[] ipiv,
            double[] b, int ldb);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dgttrs_work(Layout layout, TransChar trans, int n,
            int nrhs, double[] dl,
            double[] d, double[] du,
            double[] du2, int[] ipiv,
            double[] b, int ldb)
            => LAPACKE_dgttrs_work(layout, trans, n,
                nrhs, dl,
                d, du,
                du2, ipiv,
                b, ldb);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dhgeqz(Layout layout, char job, char compq, char compz,
            int n, int ilo, int ihi,
            double[] h, int ldh, double[] t, int ldt,
            double[] alphar, double[] alphai, double[] beta,
            double[] q, int ldq, double[] z,
            int ldz);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dhgeqz(Layout layout, char job, char compq, char compz,
            int n, int ilo, int ihi,
            double[] h, int ldh, double[] t, int ldt,
            double[] alphar, double[] alphai, double[] beta,
            double[] q, int ldq, double[] z,
            int ldz)
            => LAPACKE_dhgeqz(layout, job, compq, compz,
                n, ilo, ihi,
                h, ldh, t, ldt,
                alphar, alphai, beta,
                q, ldq, z,
                ldz);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dhgeqz_work(Layout layout, char job, char compq,
            char compz, int n, int ilo,
            int ihi, double[] h, int ldh,
            double[] t, int ldt, double[] alphar,
            double[] alphai, double[] beta, double[] q,
            int ldq, double[] z, int ldz,
            double[] work, int lwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dhgeqz_work(Layout layout, char job, char compq,
            char compz, int n, int ilo,
            int ihi, double[] h, int ldh,
            double[] t, int ldt, double[] alphar,
            double[] alphai, double[] beta, double[] q,
            int ldq, double[] z, int ldz,
            double[] work, int lwork)
            => LAPACKE_dhgeqz_work(layout, job, compq,
                compz, n, ilo,
                ihi, h, ldh,
                t, ldt, alphar,
                alphai, beta, q,
                ldq, z, ldz,
                work, lwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dhsein(Layout layout, char job, char eigsrc, char initv,
            int[] select, int n,
            double[] h, int ldh, double[] wr,
            double[] wi, double[] vl, int ldvl,
            double[] vr, int ldvr, int mm,
            int[] m, int[] ifaill,
            int[] ifailr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dhsein(Layout layout, char job, char eigsrc, char initv,
            int[] select, int n,
            double[] h, int ldh, double[] wr,
            double[] wi, double[] vl, int ldvl,
            double[] vr, int ldvr, int mm,
            int[] m, int[] ifaill,
            int[] ifailr)
            => LAPACKE_dhsein(layout, job, eigsrc, initv,
                select, n,
                h, ldh, wr,
                wi, vl, ldvl,
                vr, ldvr, mm,
                m, ifaill,
                ifailr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dhsein_work(Layout layout, char job, char eigsrc,
            char initv, int[] select,
            int n, double[] h, int ldh,
            double[] wr, double[] wi, double[] vl,
            int ldvl, double[] vr, int ldvr,
            int mm, int[] m, double[] work,
            int[] ifaill, int[] ifailr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dhsein_work(Layout layout, char job, char eigsrc,
            char initv, int[] select,
            int n, double[] h, int ldh,
            double[] wr, double[] wi, double[] vl,
            int ldvl, double[] vr, int ldvr,
            int mm, int[] m, double[] work,
            int[] ifaill, int[] ifailr)
            => LAPACKE_dhsein_work(layout, job, eigsrc,
                initv, select,
                n, h, ldh,
                wr, wi, vl,
                ldvl, vr, ldvr,
                mm, m, work,
                ifaill, ifailr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dhseqr(Layout layout, char job, char compz, int n,
            int ilo, int ihi, double[] h,
            int ldh, double[] wr, double[] wi, double[] z,
            int ldz);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dhseqr(Layout layout, char job, char compz, int n,
            int ilo, int ihi, double[] h,
            int ldh, double[] wr, double[] wi, double[] z,
            int ldz)
            => LAPACKE_dhseqr(layout, job, compz, n,
                ilo, ihi, h,
                ldh, wr, wi, z,
                ldz);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dhseqr_work(Layout layout, char job, char compz,
            int n, int ilo, int ihi,
            double[] h, int ldh, double[] wr,
            double[] wi, double[] z, int ldz,
            double[] work, int lwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dhseqr_work(Layout layout, char job, char compz,
            int n, int ilo, int ihi,
            double[] h, int ldh, double[] wr,
            double[] wi, double[] z, int ldz,
            double[] work, int lwork)
            => LAPACKE_dhseqr_work(layout, job, compz,
                n, ilo, ihi,
                h, ldh, wr,
                wi, z, ldz,
                work, lwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dlacn2(int n, double[] v, double[] x, int[] isgn,
            double[] est, int[] kase, int[] isave);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dlacn2(int n, double[] v, double[] x, int[] isgn,
            double[] est, int[] kase, int[] isave)
            => LAPACKE_dlacn2(n, v, x, isgn,
                est, kase, isave);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dlacn2_work(int n, double[] v, double[] x,
            int[] isgn, double[] est, int[] kase,
            int[] isave);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dlacn2_work(int n, double[] v, double[] x,
            int[] isgn, double[] est, int[] kase,
            int[] isave)
            => LAPACKE_dlacn2_work(n, v, x,
                isgn, est, kase,
                isave);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dlacpy(Layout layout, UpLo uplo, int m,
            int n, double[] a, int lda,
            double[] b, int ldb);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dlacpy(Layout layout, UpLo uplo, int m,
            int n, double[] a, int lda,
            double[] b, int ldb)
            => LAPACKE_dlacpy(layout, uplo, m,
                n, a, lda,
                b, ldb);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dlacpy_work(Layout layout, UpLo uplo, int m,
            int n, double[] a, int lda,
            double[] b, int ldb);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dlacpy_work(Layout layout, UpLo uplo, int m,
            int n, double[] a, int lda,
            double[] b, int ldb)
            => LAPACKE_dlacpy_work(layout, uplo, m,
                n, a, lda,
                b, ldb);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dlag2s(Layout layout, int m, int n,
            double[] a, int lda, float[] sa,
            int ldsa);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dlag2s(Layout layout, int m, int n,
            double[] a, int lda, float[] sa,
            int ldsa)
            => LAPACKE_dlag2s(layout, m, n,
                a, lda, sa,
                ldsa);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dlag2s_work(Layout layout, int m, int n,
            double[] a, int lda, float[] sa,
            int ldsa);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dlag2s_work(Layout layout, int m, int n,
            double[] a, int lda, float[] sa,
            int ldsa)
            => LAPACKE_dlag2s_work(layout, m, n,
                a, lda, sa,
                ldsa);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dlagge(Layout layout, int m, int n,
            int kl, int ku, double[] d,
            double[] a, int lda, int[] iseed);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dlagge(Layout layout, int m, int n,
            int kl, int ku, double[] d,
            double[] a, int lda, int[] iseed)
            => LAPACKE_dlagge(layout, m, n,
                kl, ku, d,
                a, lda, iseed);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dlagge_work(Layout layout, int m, int n,
            int kl, int ku, double[] d,
            double[] a, int lda, int[] iseed,
            double[] work);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dlagge_work(Layout layout, int m, int n,
            int kl, int ku, double[] d,
            double[] a, int lda, int[] iseed,
            double[] work)
            => LAPACKE_dlagge_work(layout, m, n,
                kl, ku, d,
                a, lda, iseed,
                work);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dlagsy(Layout layout, int n, int k,
            double[] d, double[] a, int lda,
            int[] iseed);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dlagsy(Layout layout, int n, int k,
            double[] d, double[] a, int lda,
            int[] iseed)
            => LAPACKE_dlagsy(layout, n, k,
                d, a, lda,
                iseed);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dlagsy_work(Layout layout, int n, int k,
            double[] d, double[] a, int lda,
            int[] iseed, double[] work);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dlagsy_work(Layout layout, int n, int k,
            double[] d, double[] a, int lda,
            int[] iseed, double[] work)
            => LAPACKE_dlagsy_work(layout, n, k,
                d, a, lda,
                iseed, work);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dlapmr(Layout layout, int forwrd,
            int m, int n, double[] x,
            int ldx, int[] k);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dlapmr(Layout layout, int forwrd,
            int m, int n, double[] x,
            int ldx, int[] k)
            => LAPACKE_dlapmr(layout, forwrd,
                m, n, x,
                ldx, k);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dlapmr_work(Layout layout, int forwrd,
            int m, int n, double[] x,
            int ldx, int[] k);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dlapmr_work(Layout layout, int forwrd,
            int m, int n, double[] x,
            int ldx, int[] k)
            => LAPACKE_dlapmr_work(layout, forwrd,
                m, n, x,
                ldx, k);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dlapmt(Layout layout, int forwrd,
            int m, int n, double[] x,
            int ldx, int[] k);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dlapmt(Layout layout, int forwrd,
            int m, int n, double[] x,
            int ldx, int[] k)
            => LAPACKE_dlapmt(layout, forwrd,
                m, n, x,
                ldx, k);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dlapmt_work(Layout layout, int forwrd,
            int m, int n, double[] x,
            int ldx, int[] k);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dlapmt_work(Layout layout, int forwrd,
            int m, int n, double[] x,
            int ldx, int[] k)
            => LAPACKE_dlapmt_work(layout, forwrd,
                m, n, x,
                ldx, k);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dlarfb(Layout layout, char side, TransChar trans, char direct,
            char storev, int m, int n,
            int k, double[] v, int ldv,
            double[] t, int ldt, double[] c,
            int ldc);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dlarfb(Layout layout, char side, TransChar trans, char direct,
            char storev, int m, int n,
            int k, double[] v, int ldv,
            double[] t, int ldt, double[] c,
            int ldc)
            => LAPACKE_dlarfb(layout, side, trans, direct,
                storev, m, n,
                k, v, ldv,
                t, ldt, c,
                ldc);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dlarfb_work(Layout layout, char side, TransChar trans,
            char direct, char storev, int m,
            int n, int k, double[] v,
            int ldv, double[] t, int ldt,
            double[] c, int ldc, double[] work,
            int ldwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dlarfb_work(Layout layout, char side, TransChar trans,
            char direct, char storev, int m,
            int n, int k, double[] v,
            int ldv, double[] t, int ldt,
            double[] c, int ldc, double[] work,
            int ldwork)
            => LAPACKE_dlarfb_work(layout, side, trans,
                direct, storev, m,
                n, k, v,
                ldv, t, ldt,
                c, ldc, work,
                ldwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dlarfg(int n, double[] alpha, double[] x,
            int incx, double[] tau);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dlarfg(int n, double[] alpha, double[] x,
            int incx, double[] tau)
            => LAPACKE_dlarfg(n, alpha, x,
                incx, tau);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dlarfg_work(int n, double[] alpha, double[] x,
            int incx, double[] tau);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dlarfg_work(int n, double[] alpha, double[] x,
            int incx, double[] tau)
            => LAPACKE_dlarfg_work(n, alpha, x,
                incx, tau);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dlarft(Layout layout, char direct, char storev,
            int n, int k, double[] v,
            int ldv, double[] tau, double[] t,
            int ldt);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dlarft(Layout layout, char direct, char storev,
            int n, int k, double[] v,
            int ldv, double[] tau, double[] t,
            int ldt)
            => LAPACKE_dlarft(layout, direct, storev,
                n, k, v,
                ldv, tau, t,
                ldt);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dlarft_work(Layout layout, char direct, char storev,
            int n, int k, double[] v,
            int ldv, double[] tau, double[] t,
            int ldt);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dlarft_work(Layout layout, char direct, char storev,
            int n, int k, double[] v,
            int ldv, double[] tau, double[] t,
            int ldt)
            => LAPACKE_dlarft_work(layout, direct, storev,
                n, k, v,
                ldv, tau, t,
                ldt);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dlarfx(Layout layout, char side, int m,
            int n, double[] v, double tau, double[] c,
            int ldc, double[] work);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dlarfx(Layout layout, char side, int m,
            int n, double[] v, double tau, double[] c,
            int ldc, double[] work)
            => LAPACKE_dlarfx(layout, side, m,
                n, v, tau, c,
                ldc, work);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dlarfx_work(Layout layout, char side, int m,
            int n, double[] v, double tau,
            double[] c, int ldc, double[] work);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dlarfx_work(Layout layout, char side, int m,
            int n, double[] v, double tau,
            double[] c, int ldc, double[] work)
            => LAPACKE_dlarfx_work(layout, side, m,
                n, v, tau,
                c, ldc, work);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dlarnv(int idist, int[] iseed, int n,
            double[] x);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dlarnv(int idist, int[] iseed, int n,
            double[] x)
            => LAPACKE_dlarnv(idist, iseed, n,
                x);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dlarnv_work(int idist, int[] iseed,
            int n, double[] x);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dlarnv_work(int idist, int[] iseed,
            int n, double[] x)
            => LAPACKE_dlarnv_work(idist, iseed,
                n, x);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dlartgp(double f, double g, double[] cs, double[] sn,
            double[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dlartgp(double f, double g, double[] cs, double[] sn,
            double[] r)
            => LAPACKE_dlartgp(f, g, cs, sn,
                r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dlartgp_work(double f, double g, double[] cs, double[] sn,
            double[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dlartgp_work(double f, double g, double[] cs, double[] sn,
            double[] r)
            => LAPACKE_dlartgp_work(f, g, cs, sn,
                r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dlartgs(double x, double y, double sigma, double[] cs,
            double[] sn);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dlartgs(double x, double y, double sigma, double[] cs,
            double[] sn)
            => LAPACKE_dlartgs(x, y, sigma, cs,
                sn);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dlartgs_work(double x, double y, double sigma, double[] cs,
            double[] sn);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dlartgs_work(double x, double y, double sigma, double[] cs,
            double[] sn)
            => LAPACKE_dlartgs_work(x, y, sigma, cs,
                sn);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dlascl(Layout layout, char type, int kl,
            int ku, double cfrom, double cto,
            int m, int n, double[] a,
            int lda);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dlascl(Layout layout, char type, int kl,
            int ku, double cfrom, double cto,
            int m, int n, double[] a,
            int lda)
            => LAPACKE_dlascl(layout, type, kl,
                ku, cfrom, cto,
                m, n, a,
                lda);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dlascl_work(Layout layout, char type, int kl,
            int ku, double cfrom, double cto,
            int m, int n, double[] a,
            int lda);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dlascl_work(Layout layout, char type, int kl,
            int ku, double cfrom, double cto,
            int m, int n, double[] a,
            int lda)
            => LAPACKE_dlascl_work(layout, type, kl,
                ku, cfrom, cto,
                m, n, a,
                lda);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dlaset(Layout layout, UpLo uplo, int m,
            int n, double alpha, double beta, double[] a,
            int lda);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dlaset(Layout layout, UpLo uplo, int m,
            int n, double alpha, double beta, double[] a,
            int lda)
            => LAPACKE_dlaset(layout, uplo, m,
                n, alpha, beta, a,
                lda);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dlaset_work(Layout layout, UpLo uplo, int m,
            int n, double alpha, double beta,
            double[] a, int lda);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dlaset_work(Layout layout, UpLo uplo, int m,
            int n, double alpha, double beta,
            double[] a, int lda)
            => LAPACKE_dlaset_work(layout, uplo, m,
                n, alpha, beta,
                a, lda);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dlasrt(char id, int n, double[] d);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dlasrt(char id, int n, double[] d)
            => LAPACKE_dlasrt(id, n, d);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dlasrt_work(char id, int n, double[] d);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dlasrt_work(char id, int n, double[] d)
            => LAPACKE_dlasrt_work(id, n, d);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dlaswp(Layout layout, int n, double[] a,
            int lda, int k1, int k2,
            int[] ipiv, int incx);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dlaswp(Layout layout, int n, double[] a,
            int lda, int k1, int k2,
            int[] ipiv, int incx)
            => LAPACKE_dlaswp(layout, n, a,
                lda, k1, k2,
                ipiv, incx);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dlaswp_work(Layout layout, int n, double[] a,
            int lda, int k1, int k2,
            int[] ipiv, int incx);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dlaswp_work(Layout layout, int n, double[] a,
            int lda, int k1, int k2,
            int[] ipiv, int incx)
            => LAPACKE_dlaswp_work(layout, n, a,
                lda, k1, k2,
                ipiv, incx);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dlatms(Layout layout, int m, int n,
            char dist, int[] iseed, char sym, double[] d,
            int mode, double cond, double dmax,
            int kl, int ku, char pack, double[] a,
            int lda);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dlatms(Layout layout, int m, int n,
            char dist, int[] iseed, char sym, double[] d,
            int mode, double cond, double dmax,
            int kl, int ku, char pack, double[] a,
            int lda)
            => LAPACKE_dlatms(layout, m, n,
                dist, iseed, sym, d,
                mode, cond, dmax,
                kl, ku, pack, a,
                lda);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dlatms_work(Layout layout, int m, int n,
            char dist, int[] iseed, char sym,
            double[] d, int mode, double cond,
            double dmax, int kl, int ku,
            char pack, double[] a, int lda,
            double[] work);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dlatms_work(Layout layout, int m, int n,
            char dist, int[] iseed, char sym,
            double[] d, int mode, double cond,
            double dmax, int kl, int ku,
            char pack, double[] a, int lda,
            double[] work)
            => LAPACKE_dlatms_work(layout, m, n,
                dist, iseed, sym,
                d, mode, cond,
                dmax, kl, ku,
                pack, a, lda,
                work);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dlauum(Layout layout, UpLo uplo, int n, double[] a,
            int lda);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dlauum(Layout layout, UpLo uplo, int n, double[] a,
            int lda)
            => LAPACKE_dlauum(layout, uplo, n, a,
                lda);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dlauum_work(Layout layout, UpLo uplo, int n,
            double[] a, int lda);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dlauum_work(Layout layout, UpLo uplo, int n,
            double[] a, int lda)
            => LAPACKE_dlauum_work(layout, uplo, n,
                a, lda);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dopgtr(Layout layout, UpLo uplo, int n,
            double[] ap, double[] tau, double[] q,
            int ldq);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dopgtr(Layout layout, UpLo uplo, int n,
            double[] ap, double[] tau, double[] q,
            int ldq)
            => LAPACKE_dopgtr(layout, uplo, n,
                ap, tau, q,
                ldq);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dopgtr_work(Layout layout, UpLo uplo, int n,
            double[] ap, double[] tau, double[] q,
            int ldq, double[] work);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dopgtr_work(Layout layout, UpLo uplo, int n,
            double[] ap, double[] tau, double[] q,
            int ldq, double[] work)
            => LAPACKE_dopgtr_work(layout, uplo, n,
                ap, tau, q,
                ldq, work);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dopmtr(Layout layout, char side, UpLo uplo, TransChar trans,
            int m, int n, double[] ap,
            double[] tau, double[] c, int ldc);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dopmtr(Layout layout, char side, UpLo uplo, TransChar trans,
            int m, int n, double[] ap,
            double[] tau, double[] c, int ldc)
            => LAPACKE_dopmtr(layout, side, uplo, trans,
                m, n, ap,
                tau, c, ldc);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dopmtr_work(Layout layout, char side, UpLo uplo,
            TransChar trans, int m, int n,
            double[] ap, double[] tau, double[] c,
            int ldc, double[] work);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dopmtr_work(Layout layout, char side, UpLo uplo,
            TransChar trans, int m, int n,
            double[] ap, double[] tau, double[] c,
            int ldc, double[] work)
            => LAPACKE_dopmtr_work(layout, side, uplo,
                trans, m, n,
                ap, tau, c,
                ldc, work);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dorbdb(Layout layout, TransChar trans, char signs,
            int m, int p, int q,
            double[] x11, int ldx11, double[] x12,
            int ldx12, double[] x21, int ldx21,
            double[] x22, int ldx22, double[] theta,
            double[] phi, double[] taup1, double[] taup2,
            double[] tauq1, double[] tauq2);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dorbdb(Layout layout, TransChar trans, char signs,
            int m, int p, int q,
            double[] x11, int ldx11, double[] x12,
            int ldx12, double[] x21, int ldx21,
            double[] x22, int ldx22, double[] theta,
            double[] phi, double[] taup1, double[] taup2,
            double[] tauq1, double[] tauq2)
            => LAPACKE_dorbdb(layout, trans, signs,
                m, p, q,
                x11, ldx11, x12,
                ldx12, x21, ldx21,
                x22, ldx22, theta,
                phi, taup1, taup2,
                tauq1, tauq2);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dorbdb_work(Layout layout, TransChar trans, char signs,
            int m, int p, int q,
            double[] x11, int ldx11, double[] x12,
            int ldx12, double[] x21, int ldx21,
            double[] x22, int ldx22, double[] theta,
            double[] phi, double[] taup1, double[] taup2,
            double[] tauq1, double[] tauq2, double[] work,
            int lwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dorbdb_work(Layout layout, TransChar trans, char signs,
            int m, int p, int q,
            double[] x11, int ldx11, double[] x12,
            int ldx12, double[] x21, int ldx21,
            double[] x22, int ldx22, double[] theta,
            double[] phi, double[] taup1, double[] taup2,
            double[] tauq1, double[] tauq2, double[] work,
            int lwork)
            => LAPACKE_dorbdb_work(layout, trans, signs,
                m, p, q,
                x11, ldx11, x12,
                ldx12, x21, ldx21,
                x22, ldx22, theta,
                phi, taup1, taup2,
                tauq1, tauq2, work,
                lwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dorcsd(Layout layout, char jobu1, char jobu2,
            char jobv1t, char jobv2t, TransChar trans, char signs,
            int m, int p, int q,
            double[] x11, int ldx11, double[] x12,
            int ldx12, double[] x21, int ldx21,
            double[] x22, int ldx22, double[] theta,
            double[] u1, int ldu1, double[] u2,
            int ldu2, double[] v1t, int ldv1t,
            double[] v2t, int ldv2t);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dorcsd(Layout layout, char jobu1, char jobu2,
            char jobv1t, char jobv2t, TransChar trans, char signs,
            int m, int p, int q,
            double[] x11, int ldx11, double[] x12,
            int ldx12, double[] x21, int ldx21,
            double[] x22, int ldx22, double[] theta,
            double[] u1, int ldu1, double[] u2,
            int ldu2, double[] v1t, int ldv1t,
            double[] v2t, int ldv2t)
            => LAPACKE_dorcsd(layout, jobu1, jobu2,
                jobv1t, jobv2t, trans, signs,
                m, p, q,
                x11, ldx11, x12,
                ldx12, x21, ldx21,
                x22, ldx22, theta,
                u1, ldu1, u2,
                ldu2, v1t, ldv1t,
                v2t, ldv2t);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dorcsd2by1(Layout layout, char jobu1, char jobu2,
            char jobv1t, int m, int p, int q,
            double[] x11, int ldx11, double[] x21, int ldx21,
            double[] theta, double[] u1, int ldu1, double[] u2,
            int ldu2, double[] v1t, int ldv1t);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dorcsd2by1(Layout layout, char jobu1, char jobu2,
            char jobv1t, int m, int p, int q,
            double[] x11, int ldx11, double[] x21, int ldx21,
            double[] theta, double[] u1, int ldu1, double[] u2,
            int ldu2, double[] v1t, int ldv1t)
            => LAPACKE_dorcsd2by1(layout, jobu1, jobu2,
                jobv1t, m, p, q,
                x11, ldx11, x21, ldx21,
                theta, u1, ldu1, u2,
                ldu2, v1t, ldv1t);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dorcsd2by1_work(Layout layout, char jobu1, char jobu2,
            char jobv1t, int m, int p,
            int q, double[] x11, int ldx11,
            double[] x21, int ldx21,
            double[] theta, double[] u1, int ldu1,
            double[] u2, int ldu2, double[] v1t,
            int ldv1t, double[] work, int lwork,
            int[] iwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dorcsd2by1_work(Layout layout, char jobu1, char jobu2,
            char jobv1t, int m, int p,
            int q, double[] x11, int ldx11,
            double[] x21, int ldx21,
            double[] theta, double[] u1, int ldu1,
            double[] u2, int ldu2, double[] v1t,
            int ldv1t, double[] work, int lwork,
            int[] iwork)
            => LAPACKE_dorcsd2by1_work(layout, jobu1, jobu2,
                jobv1t, m, p,
                q, x11, ldx11,
                x21, ldx21,
                theta, u1, ldu1,
                u2, ldu2, v1t,
                ldv1t, work, lwork,
                iwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dorcsd_work(Layout layout, char jobu1, char jobu2,
            char jobv1t, char jobv2t, TransChar trans,
            char signs, int m, int p,
            int q, double[] x11, int ldx11,
            double[] x12, int ldx12, double[] x21,
            int ldx21, double[] x22, int ldx22,
            double[] theta, double[] u1, int ldu1,
            double[] u2, int ldu2, double[] v1t,
            int ldv1t, double[] v2t, int ldv2t,
            double[] work, int lwork,
            int[] iwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dorcsd_work(Layout layout, char jobu1, char jobu2,
            char jobv1t, char jobv2t, TransChar trans,
            char signs, int m, int p,
            int q, double[] x11, int ldx11,
            double[] x12, int ldx12, double[] x21,
            int ldx21, double[] x22, int ldx22,
            double[] theta, double[] u1, int ldu1,
            double[] u2, int ldu2, double[] v1t,
            int ldv1t, double[] v2t, int ldv2t,
            double[] work, int lwork,
            int[] iwork)
            => LAPACKE_dorcsd_work(layout, jobu1, jobu2,
                jobv1t, jobv2t, trans,
                signs, m, p,
                q, x11, ldx11,
                x12, ldx12, x21,
                ldx21, x22, ldx22,
                theta, u1, ldu1,
                u2, ldu2, v1t,
                ldv1t, v2t, ldv2t,
                work, lwork,
                iwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dorgbr(Layout layout, char vect, int m,
            int n, int k, double[] a,
            int lda, double[] tau);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dorgbr(Layout layout, char vect, int m,
            int n, int k, double[] a,
            int lda, double[] tau)
            => LAPACKE_dorgbr(layout, vect, m,
                n, k, a,
                lda, tau);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dorgbr_work(Layout layout, char vect, int m,
            int n, int k, double[] a,
            int lda, double[] tau, double[] work,
            int lwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dorgbr_work(Layout layout, char vect, int m,
            int n, int k, double[] a,
            int lda, double[] tau, double[] work,
            int lwork)
            => LAPACKE_dorgbr_work(layout, vect, m,
                n, k, a,
                lda, tau, work,
                lwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dorghr(Layout layout, int n, int ilo,
            int ihi, double[] a, int lda,
            double[] tau);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dorghr(Layout layout, int n, int ilo,
            int ihi, double[] a, int lda,
            double[] tau)
            => LAPACKE_dorghr(layout, n, ilo,
                ihi, a, lda,
                tau);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dorghr_work(Layout layout, int n, int ilo,
            int ihi, double[] a, int lda,
            double[] tau, double[] work,
            int lwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dorghr_work(Layout layout, int n, int ilo,
            int ihi, double[] a, int lda,
            double[] tau, double[] work,
            int lwork)
            => LAPACKE_dorghr_work(layout, n, ilo,
                ihi, a, lda,
                tau, work,
                lwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dorglq(Layout layout, int m, int n,
            int k, double[] a, int lda,
            double[] tau);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dorglq(Layout layout, int m, int n,
            int k, double[] a, int lda,
            double[] tau)
            => LAPACKE_dorglq(layout, m, n,
                k, a, lda,
                tau);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dorglq_work(Layout layout, int m, int n,
            int k, double[] a, int lda,
            double[] tau, double[] work,
            int lwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dorglq_work(Layout layout, int m, int n,
            int k, double[] a, int lda,
            double[] tau, double[] work,
            int lwork)
            => LAPACKE_dorglq_work(layout, m, n,
                k, a, lda,
                tau, work,
                lwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dorgql(Layout layout, int m, int n,
            int k, double[] a, int lda,
            double[] tau);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dorgql(Layout layout, int m, int n,
            int k, double[] a, int lda,
            double[] tau)
            => LAPACKE_dorgql(layout, m, n,
                k, a, lda,
                tau);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dorgql_work(Layout layout, int m, int n,
            int k, double[] a, int lda,
            double[] tau, double[] work,
            int lwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dorgql_work(Layout layout, int m, int n,
            int k, double[] a, int lda,
            double[] tau, double[] work,
            int lwork)
            => LAPACKE_dorgql_work(layout, m, n,
                k, a, lda,
                tau, work,
                lwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dorgqr(Layout layout, int m, int n,
            int k, double[] a, int lda,
            double[] tau);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dorgqr(Layout layout, int m, int n,
            int k, double[] a, int lda,
            double[] tau)
            => LAPACKE_dorgqr(layout, m, n,
                k, a, lda,
                tau);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dorgqr_work(Layout layout, int m, int n,
            int k, double[] a, int lda,
            double[] tau, double[] work,
            int lwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dorgqr_work(Layout layout, int m, int n,
            int k, double[] a, int lda,
            double[] tau, double[] work,
            int lwork)
            => LAPACKE_dorgqr_work(layout, m, n,
                k, a, lda,
                tau, work,
                lwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dorgrq(Layout layout, int m, int n,
            int k, double[] a, int lda,
            double[] tau);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dorgrq(Layout layout, int m, int n,
            int k, double[] a, int lda,
            double[] tau)
            => LAPACKE_dorgrq(layout, m, n,
                k, a, lda,
                tau);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dorgrq_work(Layout layout, int m, int n,
            int k, double[] a, int lda,
            double[] tau, double[] work,
            int lwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dorgrq_work(Layout layout, int m, int n,
            int k, double[] a, int lda,
            double[] tau, double[] work,
            int lwork)
            => LAPACKE_dorgrq_work(layout, m, n,
                k, a, lda,
                tau, work,
                lwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dorgtr(Layout layout, UpLo uplo, int n, double[] a,
            int lda, double[] tau);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dorgtr(Layout layout, UpLo uplo, int n, double[] a,
            int lda, double[] tau)
            => LAPACKE_dorgtr(layout, uplo, n, a,
                lda, tau);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dorgtr_work(Layout layout, UpLo uplo, int n,
            double[] a, int lda, double[] tau,
            double[] work, int lwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dorgtr_work(Layout layout, UpLo uplo, int n,
            double[] a, int lda, double[] tau,
            double[] work, int lwork)
            => LAPACKE_dorgtr_work(layout, uplo, n,
                a, lda, tau,
                work, lwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dormbr(Layout layout, char vect, char side, TransChar trans,
            int m, int n, int k,
            double[] a, int lda, double[] tau,
            double[] c, int ldc);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dormbr(Layout layout, char vect, char side, TransChar trans,
            int m, int n, int k,
            double[] a, int lda, double[] tau,
            double[] c, int ldc)
            => LAPACKE_dormbr(layout, vect, side, trans,
                m, n, k,
                a, lda, tau,
                c, ldc);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dormbr_work(Layout layout, char vect, char side,
            TransChar trans, int m, int n,
            int k, double[] a, int lda,
            double[] tau, double[] c, int ldc,
            double[] work, int lwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dormbr_work(Layout layout, char vect, char side,
            TransChar trans, int m, int n,
            int k, double[] a, int lda,
            double[] tau, double[] c, int ldc,
            double[] work, int lwork)
            => LAPACKE_dormbr_work(layout, vect, side,
                trans, m, n,
                k, a, lda,
                tau, c, ldc,
                work, lwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dormhr(Layout layout, char side, TransChar trans,
            int m, int n, int ilo,
            int ihi, double[] a, int lda,
            double[] tau, double[] c, int ldc);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dormhr(Layout layout, char side, TransChar trans,
            int m, int n, int ilo,
            int ihi, double[] a, int lda,
            double[] tau, double[] c, int ldc)
            => LAPACKE_dormhr(layout, side, trans,
                m, n, ilo,
                ihi, a, lda,
                tau, c, ldc);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dormhr_work(Layout layout, char side, TransChar trans,
            int m, int n, int ilo,
            int ihi, double[] a, int lda,
            double[] tau, double[] c, int ldc,
            double[] work, int lwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dormhr_work(Layout layout, char side, TransChar trans,
            int m, int n, int ilo,
            int ihi, double[] a, int lda,
            double[] tau, double[] c, int ldc,
            double[] work, int lwork)
            => LAPACKE_dormhr_work(layout, side, trans,
                m, n, ilo,
                ihi, a, lda,
                tau, c, ldc,
                work, lwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dormlq(Layout layout, char side, TransChar trans,
            int m, int n, int k,
            double[] a, int lda, double[] tau,
            double[] c, int ldc);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dormlq(Layout layout, char side, TransChar trans,
            int m, int n, int k,
            double[] a, int lda, double[] tau,
            double[] c, int ldc)
            => LAPACKE_dormlq(layout, side, trans,
                m, n, k,
                a, lda, tau,
                c, ldc);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dormlq_work(Layout layout, char side, TransChar trans,
            int m, int n, int k,
            double[] a, int lda,
            double[] tau, double[] c, int ldc,
            double[] work, int lwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dormlq_work(Layout layout, char side, TransChar trans,
            int m, int n, int k,
            double[] a, int lda,
            double[] tau, double[] c, int ldc,
            double[] work, int lwork)
            => LAPACKE_dormlq_work(layout, side, trans,
                m, n, k,
                a, lda,
                tau, c, ldc,
                work, lwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dormql(Layout layout, char side, TransChar trans,
            int m, int n, int k,
            double[] a, int lda, double[] tau,
            double[] c, int ldc);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dormql(Layout layout, char side, TransChar trans,
            int m, int n, int k,
            double[] a, int lda, double[] tau,
            double[] c, int ldc)
            => LAPACKE_dormql(layout, side, trans,
                m, n, k,
                a, lda, tau,
                c, ldc);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dormql_work(Layout layout, char side, TransChar trans,
            int m, int n, int k,
            double[] a, int lda,
            double[] tau, double[] c, int ldc,
            double[] work, int lwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dormql_work(Layout layout, char side, TransChar trans,
            int m, int n, int k,
            double[] a, int lda,
            double[] tau, double[] c, int ldc,
            double[] work, int lwork)
            => LAPACKE_dormql_work(layout, side, trans,
                m, n, k,
                a, lda,
                tau, c, ldc,
                work, lwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dormqr(Layout layout, char side, TransChar trans,
            int m, int n, int k,
            double[] a, int lda, double[] tau,
            double[] c, int ldc);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dormqr(Layout layout, char side, TransChar trans,
            int m, int n, int k,
            double[] a, int lda, double[] tau,
            double[] c, int ldc)
            => LAPACKE_dormqr(layout, side, trans,
                m, n, k,
                a, lda, tau,
                c, ldc);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dormqr_work(Layout layout, char side, TransChar trans,
            int m, int n, int k,
            double[] a, int lda,
            double[] tau, double[] c, int ldc,
            double[] work, int lwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dormqr_work(Layout layout, char side, TransChar trans,
            int m, int n, int k,
            double[] a, int lda,
            double[] tau, double[] c, int ldc,
            double[] work, int lwork)
            => LAPACKE_dormqr_work(layout, side, trans,
                m, n, k,
                a, lda,
                tau, c, ldc,
                work, lwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dormrq(Layout layout, char side, TransChar trans,
            int m, int n, int k,
            double[] a, int lda, double[] tau,
            double[] c, int ldc);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dormrq(Layout layout, char side, TransChar trans,
            int m, int n, int k,
            double[] a, int lda, double[] tau,
            double[] c, int ldc)
            => LAPACKE_dormrq(layout, side, trans,
                m, n, k,
                a, lda, tau,
                c, ldc);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dormrq_work(Layout layout, char side, TransChar trans,
            int m, int n, int k,
            double[] a, int lda,
            double[] tau, double[] c, int ldc,
            double[] work, int lwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dormrq_work(Layout layout, char side, TransChar trans,
            int m, int n, int k,
            double[] a, int lda,
            double[] tau, double[] c, int ldc,
            double[] work, int lwork)
            => LAPACKE_dormrq_work(layout, side, trans,
                m, n, k,
                a, lda,
                tau, c, ldc,
                work, lwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dormrz(Layout layout, char side, TransChar trans,
            int m, int n, int k,
            int l, double[] a, int lda,
            double[] tau, double[] c, int ldc);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dormrz(Layout layout, char side, TransChar trans,
            int m, int n, int k,
            int l, double[] a, int lda,
            double[] tau, double[] c, int ldc)
            => LAPACKE_dormrz(layout, side, trans,
                m, n, k,
                l, a, lda,
                tau, c, ldc);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dormrz_work(Layout layout, char side, TransChar trans,
            int m, int n, int k,
            int l, double[] a, int lda,
            double[] tau, double[] c, int ldc,
            double[] work, int lwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dormrz_work(Layout layout, char side, TransChar trans,
            int m, int n, int k,
            int l, double[] a, int lda,
            double[] tau, double[] c, int ldc,
            double[] work, int lwork)
            => LAPACKE_dormrz_work(layout, side, trans,
                m, n, k,
                l, a, lda,
                tau, c, ldc,
                work, lwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dormtr(Layout layout, char side, UpLo uplo, TransChar trans,
            int m, int n, double[] a,
            int lda, double[] tau, double[] c,
            int ldc);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dormtr(Layout layout, char side, UpLo uplo, TransChar trans,
            int m, int n, double[] a,
            int lda, double[] tau, double[] c,
            int ldc)
            => LAPACKE_dormtr(layout, side, uplo, trans,
                m, n, a,
                lda, tau, c,
                ldc);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dormtr_work(Layout layout, char side, UpLo uplo,
            TransChar trans, int m, int n,
            double[] a, int lda,
            double[] tau, double[] c, int ldc,
            double[] work, int lwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dormtr_work(Layout layout, char side, UpLo uplo,
            TransChar trans, int m, int n,
            double[] a, int lda,
            double[] tau, double[] c, int ldc,
            double[] work, int lwork)
            => LAPACKE_dormtr_work(layout, side, uplo,
                trans, m, n,
                a, lda,
                tau, c, ldc,
                work, lwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dpbcon(Layout layout, UpLo uplo, int n,
            int kd, double[] ab, int ldab,
            double anorm, double[] rcond);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dpbcon(Layout layout, UpLo uplo, int n,
            int kd, double[] ab, int ldab,
            double anorm, double[] rcond)
            => LAPACKE_dpbcon(layout, uplo, n,
                kd, ab, ldab,
                anorm, rcond);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dpbcon_work(Layout layout, UpLo uplo, int n,
            int kd, double[] ab,
            int ldab, double anorm, double[] rcond,
            double[] work, int[] iwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dpbcon_work(Layout layout, UpLo uplo, int n,
            int kd, double[] ab,
            int ldab, double anorm, double[] rcond,
            double[] work, int[] iwork)
            => LAPACKE_dpbcon_work(layout, uplo, n,
                kd, ab,
                ldab, anorm, rcond,
                work, iwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dpbequ(Layout layout, UpLo uplo, int n,
            int kd, double[] ab, int ldab,
            double[] s, double[] scond, double[] amax);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dpbequ(Layout layout, UpLo uplo, int n,
            int kd, double[] ab, int ldab,
            double[] s, double[] scond, double[] amax)
            => LAPACKE_dpbequ(layout, uplo, n,
                kd, ab, ldab,
                s, scond, amax);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dpbequ_work(Layout layout, UpLo uplo, int n,
            int kd, double[] ab,
            int ldab, double[] s, double[] scond,
            double[] amax);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dpbequ_work(Layout layout, UpLo uplo, int n,
            int kd, double[] ab,
            int ldab, double[] s, double[] scond,
            double[] amax)
            => LAPACKE_dpbequ_work(layout, uplo, n,
                kd, ab,
                ldab, s, scond,
                amax);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dpbrfs(Layout layout, UpLo uplo, int n,
            int kd, int nrhs, double[] ab,
            int ldab, double[] afb, int ldafb,
            double[] b, int ldb, double[] x,
            int ldx, double[] ferr, double[] berr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dpbrfs(Layout layout, UpLo uplo, int n,
            int kd, int nrhs, double[] ab,
            int ldab, double[] afb, int ldafb,
            double[] b, int ldb, double[] x,
            int ldx, double[] ferr, double[] berr)
            => LAPACKE_dpbrfs(layout, uplo, n,
                kd, nrhs, ab,
                ldab, afb, ldafb,
                b, ldb, x,
                ldx, ferr, berr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dpbrfs_work(Layout layout, UpLo uplo, int n,
            int kd, int nrhs,
            double[] ab, int ldab,
            double[] afb, int ldafb,
            double[] b, int ldb, double[] x,
            int ldx, double[] ferr, double[] berr,
            double[] work, int[] iwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dpbrfs_work(Layout layout, UpLo uplo, int n,
            int kd, int nrhs,
            double[] ab, int ldab,
            double[] afb, int ldafb,
            double[] b, int ldb, double[] x,
            int ldx, double[] ferr, double[] berr,
            double[] work, int[] iwork)
            => LAPACKE_dpbrfs_work(layout, uplo, n,
                kd, nrhs,
                ab, ldab,
                afb, ldafb,
                b, ldb, x,
                ldx, ferr, berr,
                work, iwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dpbstf(Layout layout, UpLo uplo, int n,
            int kb, double[] bb, int ldbb);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dpbstf(Layout layout, UpLo uplo, int n,
            int kb, double[] bb, int ldbb)
            => LAPACKE_dpbstf(layout, uplo, n,
                kb, bb, ldbb);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dpbstf_work(Layout layout, UpLo uplo, int n,
            int kb, double[] bb, int ldbb);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dpbstf_work(Layout layout, UpLo uplo, int n,
            int kb, double[] bb, int ldbb)
            => LAPACKE_dpbstf_work(layout, uplo, n,
                kb, bb, ldbb);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dpbsv(Layout layout, UpLo uplo, int n,
            int kd, int nrhs, double[] ab,
            int ldab, double[] b, int ldb);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dpbsv(Layout layout, UpLo uplo, int n,
            int kd, int nrhs, double[] ab,
            int ldab, double[] b, int ldb)
            => LAPACKE_dpbsv(layout, uplo, n,
                kd, nrhs, ab,
                ldab, b, ldb);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dpbsv_work(Layout layout, UpLo uplo, int n,
            int kd, int nrhs, double[] ab,
            int ldab, double[] b, int ldb);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dpbsv_work(Layout layout, UpLo uplo, int n,
            int kd, int nrhs, double[] ab,
            int ldab, double[] b, int ldb)
            => LAPACKE_dpbsv_work(layout, uplo, n,
                kd, nrhs, ab,
                ldab, b, ldb);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dpbsvx(Layout layout, char fact, UpLo uplo, int n,
            int kd, int nrhs, double[] ab,
            int ldab, double[] afb, int ldafb,
            char[] equed, double[] s, double[] b, int ldb,
            double[] x, int ldx, double[] rcond,
            double[] ferr, double[] berr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dpbsvx(Layout layout, char fact, UpLo uplo, int n,
            int kd, int nrhs, double[] ab,
            int ldab, double[] afb, int ldafb,
            char[] equed, double[] s, double[] b, int ldb,
            double[] x, int ldx, double[] rcond,
            double[] ferr, double[] berr)
            => LAPACKE_dpbsvx(layout, fact, uplo, n,
                kd, nrhs, ab,
                ldab, afb, ldafb,
                equed, s, b, ldb,
                x, ldx, rcond,
                ferr, berr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dpbsvx_work(Layout layout, char fact, UpLo uplo,
            int n, int kd, int nrhs,
            double[] ab, int ldab, double[] afb,
            int ldafb, char[] equed, double[] s,
            double[] b, int ldb, double[] x,
            int ldx, double[] rcond, double[] ferr,
            double[] berr, double[] work, int[] iwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dpbsvx_work(Layout layout, char fact, UpLo uplo,
            int n, int kd, int nrhs,
            double[] ab, int ldab, double[] afb,
            int ldafb, char[] equed, double[] s,
            double[] b, int ldb, double[] x,
            int ldx, double[] rcond, double[] ferr,
            double[] berr, double[] work, int[] iwork)
            => LAPACKE_dpbsvx_work(layout, fact, uplo,
                n, kd, nrhs,
                ab, ldab, afb,
                ldafb, equed, s,
                b, ldb, x,
                ldx, rcond, ferr,
                berr, work, iwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dpbtrf(Layout layout, UpLo uplo, int n,
            int kd, double[] ab, int ldab);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dpbtrf(Layout layout, UpLo uplo, int n,
            int kd, double[] ab, int ldab)
            => LAPACKE_dpbtrf(layout, uplo, n,
                kd, ab, ldab);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dpbtrf_work(Layout layout, UpLo uplo, int n,
            int kd, double[] ab, int ldab);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dpbtrf_work(Layout layout, UpLo uplo, int n,
            int kd, double[] ab, int ldab)
            => LAPACKE_dpbtrf_work(layout, uplo, n,
                kd, ab, ldab);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dpbtrs(Layout layout, UpLo uplo, int n,
            int kd, int nrhs, double[] ab,
            int ldab, double[] b, int ldb);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dpbtrs(Layout layout, UpLo uplo, int n,
            int kd, int nrhs, double[] ab,
            int ldab, double[] b, int ldb)
            => LAPACKE_dpbtrs(layout, uplo, n,
                kd, nrhs, ab,
                ldab, b, ldb);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dpbtrs_work(Layout layout, UpLo uplo, int n,
            int kd, int nrhs,
            double[] ab, int ldab, double[] b,
            int ldb);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dpbtrs_work(Layout layout, UpLo uplo, int n,
            int kd, int nrhs,
            double[] ab, int ldab, double[] b,
            int ldb)
            => LAPACKE_dpbtrs_work(layout, uplo, n,
                kd, nrhs,
                ab, ldab, b,
                ldb);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dpftrf(Layout layout, TransChar transr, UpLo uplo,
            int n, double[] a);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dpftrf(Layout layout, TransChar transr, UpLo uplo,
            int n, double[] a)
            => LAPACKE_dpftrf(layout, transr, uplo,
                n, a);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dpftrf_work(Layout layout, TransChar transr, UpLo uplo,
            int n, double[] a);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dpftrf_work(Layout layout, TransChar transr, UpLo uplo,
            int n, double[] a)
            => LAPACKE_dpftrf_work(layout, transr, uplo,
                n, a);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dpftri(Layout layout, TransChar transr, UpLo uplo,
            int n, double[] a);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dpftri(Layout layout, TransChar transr, UpLo uplo,
            int n, double[] a)
            => LAPACKE_dpftri(layout, transr, uplo,
                n, a);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dpftri_work(Layout layout, TransChar transr, UpLo uplo,
            int n, double[] a);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dpftri_work(Layout layout, TransChar transr, UpLo uplo,
            int n, double[] a)
            => LAPACKE_dpftri_work(layout, transr, uplo,
                n, a);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dpftrs(Layout layout, TransChar transr, UpLo uplo,
            int n, int nrhs, double[] a,
            double[] b, int ldb);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dpftrs(Layout layout, TransChar transr, UpLo uplo,
            int n, int nrhs, double[] a,
            double[] b, int ldb)
            => LAPACKE_dpftrs(layout, transr, uplo,
                n, nrhs, a,
                b, ldb);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dpftrs_work(Layout layout, TransChar transr, UpLo uplo,
            int n, int nrhs, double[] a,
            double[] b, int ldb);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dpftrs_work(Layout layout, TransChar transr, UpLo uplo,
            int n, int nrhs, double[] a,
            double[] b, int ldb)
            => LAPACKE_dpftrs_work(layout, transr, uplo,
                n, nrhs, a,
                b, ldb);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dpocon(Layout layout, UpLo uplo, int n,
            double[] a, int lda, double anorm,
            double[] rcond);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dpocon(Layout layout, UpLo uplo, int n,
            double[] a, int lda, double anorm,
            double[] rcond)
            => LAPACKE_dpocon(layout, uplo, n,
                a, lda, anorm,
                rcond);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dpocon_work(Layout layout, UpLo uplo, int n,
            double[] a, int lda, double anorm,
            double[] rcond, double[] work, int[] iwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dpocon_work(Layout layout, UpLo uplo, int n,
            double[] a, int lda, double anorm,
            double[] rcond, double[] work, int[] iwork)
            => LAPACKE_dpocon_work(layout, uplo, n,
                a, lda, anorm,
                rcond, work, iwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dpoequ(Layout layout, int n, double[] a,
            int lda, double[] s, double[] scond,
            double[] amax);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dpoequ(Layout layout, int n, double[] a,
            int lda, double[] s, double[] scond,
            double[] amax)
            => LAPACKE_dpoequ(layout, n, a,
                lda, s, scond,
                amax);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dpoequ_work(Layout layout, int n, double[] a,
            int lda, double[] s, double[] scond,
            double[] amax);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dpoequ_work(Layout layout, int n, double[] a,
            int lda, double[] s, double[] scond,
            double[] amax)
            => LAPACKE_dpoequ_work(layout, n, a,
                lda, s, scond,
                amax);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dpoequb(Layout layout, int n, double[] a,
            int lda, double[] s, double[] scond,
            double[] amax);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dpoequb(Layout layout, int n, double[] a,
            int lda, double[] s, double[] scond,
            double[] amax)
            => LAPACKE_dpoequb(layout, n, a,
                lda, s, scond,
                amax);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dpoequb_work(Layout layout, int n,
            double[] a, int lda, double[] s,
            double[] scond, double[] amax);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dpoequb_work(Layout layout, int n,
            double[] a, int lda, double[] s,
            double[] scond, double[] amax)
            => LAPACKE_dpoequb_work(layout, n,
                a, lda, s,
                scond, amax);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dporfs(Layout layout, UpLo uplo, int n,
            int nrhs, double[] a, int lda,
            double[] af, int ldaf, double[] b,
            int ldb, double[] x, int ldx,
            double[] ferr, double[] berr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dporfs(Layout layout, UpLo uplo, int n,
            int nrhs, double[] a, int lda,
            double[] af, int ldaf, double[] b,
            int ldb, double[] x, int ldx,
            double[] ferr, double[] berr)
            => LAPACKE_dporfs(layout, uplo, n,
                nrhs, a, lda,
                af, ldaf, b,
                ldb, x, ldx,
                ferr, berr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dporfs_work(Layout layout, UpLo uplo, int n,
            int nrhs, double[] a,
            int lda, double[] af,
            int ldaf, double[] b,
            int ldb, double[] x, int ldx,
            double[] ferr, double[] berr, double[] work,
            int[] iwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dporfs_work(Layout layout, UpLo uplo, int n,
            int nrhs, double[] a,
            int lda, double[] af,
            int ldaf, double[] b,
            int ldb, double[] x, int ldx,
            double[] ferr, double[] berr, double[] work,
            int[] iwork)
            => LAPACKE_dporfs_work(layout, uplo, n,
                nrhs, a,
                lda, af,
                ldaf, b,
                ldb, x, ldx,
                ferr, berr, work,
                iwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dporfsx(Layout layout, UpLo uplo, char equed,
            int n, int nrhs, double[] a,
            int lda, double[] af, int ldaf,
            double[] s, double[] b, int ldb,
            double[] x, int ldx, double[] rcond,
            double[] berr, int n_err_bnds,
            double[] err_bnds_norm, double[] err_bnds_comp,
            int nparams, double[] aparams);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dporfsx(Layout layout, UpLo uplo, char equed,
            int n, int nrhs, double[] a,
            int lda, double[] af, int ldaf,
            double[] s, double[] b, int ldb,
            double[] x, int ldx, double[] rcond,
            double[] berr, int n_err_bnds,
            double[] err_bnds_norm, double[] err_bnds_comp,
            int nparams, double[] aparams)
            => LAPACKE_dporfsx(layout, uplo, equed,
                n, nrhs, a,
                lda, af, ldaf,
                s, b, ldb,
                x, ldx, rcond,
                berr, n_err_bnds,
                err_bnds_norm, err_bnds_comp,
                nparams, aparams);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dporfsx_work(Layout layout, UpLo uplo, char equed,
            int n, int nrhs, double[] a,
            int lda, double[] af,
            int ldaf, double[] s,
            double[] b, int ldb, double[] x,
            int ldx, double[] rcond, double[] berr,
            int n_err_bnds, double[] err_bnds_norm,
            double[] err_bnds_comp, int nparams,
            double[] aparams, double[] work,
            int[] iwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dporfsx_work(Layout layout, UpLo uplo, char equed,
            int n, int nrhs, double[] a,
            int lda, double[] af,
            int ldaf, double[] s,
            double[] b, int ldb, double[] x,
            int ldx, double[] rcond, double[] berr,
            int n_err_bnds, double[] err_bnds_norm,
            double[] err_bnds_comp, int nparams,
            double[] aparams, double[] work,
            int[] iwork)
            => LAPACKE_dporfsx_work(layout, uplo, equed,
                n, nrhs, a,
                lda, af,
                ldaf, s,
                b, ldb, x,
                ldx, rcond, berr,
                n_err_bnds, err_bnds_norm,
                err_bnds_comp, nparams,
                aparams, work,
                iwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dposv(Layout layout, UpLo uplo, int n,
            int nrhs, double[] a, int lda, double[] b,
            int ldb);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dposv(Layout layout, UpLo uplo, int n,
            int nrhs, double[] a, int lda, double[] b,
            int ldb)
            => LAPACKE_dposv(layout, uplo, n,
                nrhs, a, lda, b,
                ldb);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dposv_work(Layout layout, UpLo uplo, int n,
            int nrhs, double[] a, int lda,
            double[] b, int ldb);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dposv_work(Layout layout, UpLo uplo, int n,
            int nrhs, double[] a, int lda,
            double[] b, int ldb)
            => LAPACKE_dposv_work(layout, uplo, n,
                nrhs, a, lda,
                b, ldb);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dposvx(Layout layout, char fact, UpLo uplo, int n,
            int nrhs, double[] a, int lda,
            double[] af, int ldaf, char[] equed, double[] s,
            double[] b, int ldb, double[] x, int ldx,
            double[] rcond, double[] ferr, double[] berr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dposvx(Layout layout, char fact, UpLo uplo, int n,
            int nrhs, double[] a, int lda,
            double[] af, int ldaf, char[] equed, double[] s,
            double[] b, int ldb, double[] x, int ldx,
            double[] rcond, double[] ferr, double[] berr)
            => LAPACKE_dposvx(layout, fact, uplo, n,
                nrhs, a, lda,
                af, ldaf, equed, s,
                b, ldb, x, ldx,
                rcond, ferr, berr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dposvx_work(Layout layout, char fact, UpLo uplo,
            int n, int nrhs, double[] a,
            int lda, double[] af, int ldaf,
            char[] equed, double[] s, double[] b,
            int ldb, double[] x, int ldx,
            double[] rcond, double[] ferr, double[] berr,
            double[] work, int[] iwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dposvx_work(Layout layout, char fact, UpLo uplo,
            int n, int nrhs, double[] a,
            int lda, double[] af, int ldaf,
            char[] equed, double[] s, double[] b,
            int ldb, double[] x, int ldx,
            double[] rcond, double[] ferr, double[] berr,
            double[] work, int[] iwork)
            => LAPACKE_dposvx_work(layout, fact, uplo,
                n, nrhs, a,
                lda, af, ldaf,
                equed, s, b,
                ldb, x, ldx,
                rcond, ferr, berr,
                work, iwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dposvxx(Layout layout, char fact, UpLo uplo,
            int n, int nrhs, double[] a,
            int lda, double[] af, int ldaf,
            char[] equed, double[] s, double[] b, int ldb,
            double[] x, int ldx, double[] rcond,
            double[] rpvgrw, double[] berr, int n_err_bnds,
            double[] err_bnds_norm, double[] err_bnds_comp,
            int nparams, double[] aparams);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dposvxx(Layout layout, char fact, UpLo uplo,
            int n, int nrhs, double[] a,
            int lda, double[] af, int ldaf,
            char[] equed, double[] s, double[] b, int ldb,
            double[] x, int ldx, double[] rcond,
            double[] rpvgrw, double[] berr, int n_err_bnds,
            double[] err_bnds_norm, double[] err_bnds_comp,
            int nparams, double[] aparams)
            => LAPACKE_dposvxx(layout, fact, uplo,
                n, nrhs, a,
                lda, af, ldaf,
                equed, s, b, ldb,
                x, ldx, rcond,
                rpvgrw, berr, n_err_bnds,
                err_bnds_norm, err_bnds_comp,
                nparams, aparams);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dposvxx_work(Layout layout, char fact, UpLo uplo,
            int n, int nrhs, double[] a,
            int lda, double[] af, int ldaf,
            char[] equed, double[] s, double[] b,
            int ldb, double[] x, int ldx,
            double[] rcond, double[] rpvgrw, double[] berr,
            int n_err_bnds, double[] err_bnds_norm,
            double[] err_bnds_comp, int nparams,
            double[] aparams, double[] work,
            int[] iwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dposvxx_work(Layout layout, char fact, UpLo uplo,
            int n, int nrhs, double[] a,
            int lda, double[] af, int ldaf,
            char[] equed, double[] s, double[] b,
            int ldb, double[] x, int ldx,
            double[] rcond, double[] rpvgrw, double[] berr,
            int n_err_bnds, double[] err_bnds_norm,
            double[] err_bnds_comp, int nparams,
            double[] aparams, double[] work,
            int[] iwork)
            => LAPACKE_dposvxx_work(layout, fact, uplo,
                n, nrhs, a,
                lda, af, ldaf,
                equed, s, b,
                ldb, x, ldx,
                rcond, rpvgrw, berr,
                n_err_bnds, err_bnds_norm,
                err_bnds_comp, nparams,
                aparams, work,
                iwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dpotrf(Layout layout, UpLo uplo, int n, double[] a,
            int lda);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dpotrf(Layout layout, UpLo uplo, int n, double[] a,
            int lda)
            => LAPACKE_dpotrf(layout, uplo, n, a, lda);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dpotrf2(Layout layout, UpLo uplo, int n, double[] a,
            int lda);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dpotrf2(Layout layout, UpLo uplo, int n, double[] a,
            int lda)
            => LAPACKE_dpotrf2(layout, uplo, n, a,
                lda);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dpotrf2_work(Layout layout, UpLo uplo, int n,
            double[] a, int lda);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dpotrf2_work(Layout layout, UpLo uplo, int n,
            double[] a, int lda)
            => LAPACKE_dpotrf2_work(layout, uplo, n,
                a, lda);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dpotrf_work(Layout layout, UpLo uplo, int n,
            double[] a, int lda);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dpotrf_work(Layout layout, UpLo uplo, int n,
            double[] a, int lda)
            => LAPACKE_dpotrf_work(layout, uplo, n,
                a, lda);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dpotri(Layout layout, UpLo uplo, int n, double[] a,
            int lda);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dpotri(Layout layout, UpLo uplo, int n, double[] a,
            int lda)
            => LAPACKE_dpotri(layout, uplo, n, a,
                lda);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dpotri_work(Layout layout, UpLo uplo, int n,
            double[] a, int lda);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dpotri_work(Layout layout, UpLo uplo, int n,
            double[] a, int lda)
            => LAPACKE_dpotri_work(layout, uplo, n,
                a, lda);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dpotrs(Layout layout, UpLo uplo, int n,
            int nrhs, double[] a, int lda,
            double[] b, int ldb);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dpotrs(Layout layout, UpLo uplo, int n,
            int nrhs, double[] a, int lda,
            double[] b, int ldb)
            => LAPACKE_dpotrs(layout, uplo, n,
                nrhs, a, lda,
                b, ldb);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dpotrs_work(Layout layout, UpLo uplo, int n,
            int nrhs, double[] a,
            int lda, double[] b, int ldb);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dpotrs_work(Layout layout, UpLo uplo, int n,
            int nrhs, double[] a,
            int lda, double[] b, int ldb)
            => LAPACKE_dpotrs_work(layout, uplo, n,
                nrhs, a,
                lda, b, ldb);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dppcon(Layout layout, UpLo uplo, int n,
            double[] ap, double anorm, double[] rcond);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dppcon(Layout layout, UpLo uplo, int n,
            double[] ap, double anorm, double[] rcond)
            => LAPACKE_dppcon(layout, uplo, n,
                ap, anorm, rcond);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dppcon_work(Layout layout, UpLo uplo, int n,
            double[] ap, double anorm, double[] rcond,
            double[] work, int[] iwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dppcon_work(Layout layout, UpLo uplo, int n,
            double[] ap, double anorm, double[] rcond,
            double[] work, int[] iwork)
            => LAPACKE_dppcon_work(layout, uplo, n,
                ap, anorm, rcond,
                work, iwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dppequ(Layout layout, UpLo uplo, int n,
            double[] ap, double[] s, double[] scond,
            double[] amax);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dppequ(Layout layout, UpLo uplo, int n,
            double[] ap, double[] s, double[] scond,
            double[] amax)
            => LAPACKE_dppequ(layout, uplo, n,
                ap, s, scond,
                amax);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dppequ_work(Layout layout, UpLo uplo, int n,
            double[] ap, double[] s, double[] scond,
            double[] amax);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dppequ_work(Layout layout, UpLo uplo, int n,
            double[] ap, double[] s, double[] scond,
            double[] amax)
            => LAPACKE_dppequ_work(layout, uplo, n,
                ap, s, scond,
                amax);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dpprfs(Layout layout, UpLo uplo, int n,
            int nrhs, double[] ap, double[] afp,
            double[] b, int ldb, double[] x,
            int ldx, double[] ferr, double[] berr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dpprfs(Layout layout, UpLo uplo, int n,
            int nrhs, double[] ap, double[] afp,
            double[] b, int ldb, double[] x,
            int ldx, double[] ferr, double[] berr)
            => LAPACKE_dpprfs(layout, uplo, n,
                nrhs, ap, afp,
                b, ldb, x,
                ldx, ferr, berr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dpprfs_work(Layout layout, UpLo uplo, int n,
            int nrhs, double[] ap,
            double[] afp, double[] b,
            int ldb, double[] x, int ldx,
            double[] ferr, double[] berr, double[] work,
            int[] iwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dpprfs_work(Layout layout, UpLo uplo, int n,
            int nrhs, double[] ap,
            double[] afp, double[] b,
            int ldb, double[] x, int ldx,
            double[] ferr, double[] berr, double[] work,
            int[] iwork)
            => LAPACKE_dpprfs_work(layout, uplo, n,
                nrhs, ap,
                afp, b,
                ldb, x, ldx,
                ferr, berr, work,
                iwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dppsv(Layout layout, UpLo uplo, int n,
            int nrhs, double[] ap, double[] b,
            int ldb);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dppsv(Layout layout, UpLo uplo, int n,
            int nrhs, double[] ap, double[] b,
            int ldb)
            => LAPACKE_dppsv(layout, uplo, n,
                nrhs, ap, b,
                ldb);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dppsv_work(Layout layout, UpLo uplo, int n,
            int nrhs, double[] ap, double[] b,
            int ldb);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dppsv_work(Layout layout, UpLo uplo, int n,
            int nrhs, double[] ap, double[] b,
            int ldb)
            => LAPACKE_dppsv_work(layout, uplo, n,
                nrhs, ap, b,
                ldb);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dppsvx(Layout layout, char fact, UpLo uplo, int n,
            int nrhs, double[] ap, double[] afp,
            char[] equed, double[] s, double[] b, int ldb,
            double[] x, int ldx, double[] rcond,
            double[] ferr, double[] berr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dppsvx(Layout layout, char fact, UpLo uplo, int n,
            int nrhs, double[] ap, double[] afp,
            char[] equed, double[] s, double[] b, int ldb,
            double[] x, int ldx, double[] rcond,
            double[] ferr, double[] berr)
            => LAPACKE_dppsvx(layout, fact, uplo, n,
                nrhs, ap, afp,
                equed, s, b, ldb,
                x, ldx, rcond,
                ferr, berr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dppsvx_work(Layout layout, char fact, UpLo uplo,
            int n, int nrhs, double[] ap,
            double[] afp, char[] equed, double[] s, double[] b,
            int ldb, double[] x, int ldx,
            double[] rcond, double[] ferr, double[] berr,
            double[] work, int[] iwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dppsvx_work(Layout layout, char fact, UpLo uplo,
            int n, int nrhs, double[] ap,
            double[] afp, char[] equed, double[] s, double[] b,
            int ldb, double[] x, int ldx,
            double[] rcond, double[] ferr, double[] berr,
            double[] work, int[] iwork)
            => LAPACKE_dppsvx_work(layout, fact, uplo,
                n, nrhs, ap,
                afp, equed, s, b,
                ldb, x, ldx,
                rcond, ferr, berr,
                work, iwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dpptrf(Layout layout, UpLo uplo, int n,
            double[] ap);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dpptrf(Layout layout, UpLo uplo, int n,
            double[] ap)
            => LAPACKE_dpptrf(layout, uplo, n,
                ap);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dpptrf_work(Layout layout, UpLo uplo, int n,
            double[] ap);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dpptrf_work(Layout layout, UpLo uplo, int n,
            double[] ap)
            => LAPACKE_dpptrf_work(layout, uplo, n,
                ap);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dpptri(Layout layout, UpLo uplo, int n,
            double[] ap);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dpptri(Layout layout, UpLo uplo, int n,
            double[] ap)
            => LAPACKE_dpptri(layout, uplo, n,
                ap);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dpptri_work(Layout layout, UpLo uplo, int n,
            double[] ap);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dpptri_work(Layout layout, UpLo uplo, int n,
            double[] ap)
            => LAPACKE_dpptri_work(layout, uplo, n,
                ap);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dpptrs(Layout layout, UpLo uplo, int n,
            int nrhs, double[] ap, double[] b,
            int ldb);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dpptrs(Layout layout, UpLo uplo, int n,
            int nrhs, double[] ap, double[] b,
            int ldb)
            => LAPACKE_dpptrs(layout, uplo, n,
                nrhs, ap, b,
                ldb);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dpptrs_work(Layout layout, UpLo uplo, int n,
            int nrhs, double[] ap, double[] b,
            int ldb);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dpptrs_work(Layout layout, UpLo uplo, int n,
            int nrhs, double[] ap, double[] b,
            int ldb)
            => LAPACKE_dpptrs_work(layout, uplo, n,
                nrhs, ap, b,
                ldb);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dpstrf(Layout layout, UpLo uplo, int n, double[] a,
            int lda, int[] piv, int[] rank,
            double tol);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dpstrf(Layout layout, UpLo uplo, int n, double[] a,
            int lda, int[] piv, int[] rank,
            double tol)
            => LAPACKE_dpstrf(layout, uplo, n, a,
                lda, piv, rank,
                tol);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dpstrf_work(Layout layout, UpLo uplo, int n,
            double[] a, int lda, int[] piv,
            int[] rank, double tol, double[] work);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dpstrf_work(Layout layout, UpLo uplo, int n,
            double[] a, int lda, int[] piv,
            int[] rank, double tol, double[] work)
            => LAPACKE_dpstrf_work(layout, uplo, n,
                a, lda, piv,
                rank, tol, work);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dptcon(int n, double[] d, double[] e,
            double anorm, double[] rcond);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dptcon(int n, double[] d, double[] e,
            double anorm, double[] rcond)
            => LAPACKE_dptcon(n, d, e,
                anorm, rcond);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dptcon_work(int n, double[] d, double[] e,
            double anorm, double[] rcond, double[] work);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dptcon_work(int n, double[] d, double[] e,
            double anorm, double[] rcond, double[] work)
            => LAPACKE_dptcon_work(n, d, e,
                anorm, rcond, work);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dpteqr(Layout layout, char compz, int n,
            double[] d, double[] e, double[] z, int ldz);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dpteqr(Layout layout, char compz, int n,
            double[] d, double[] e, double[] z, int ldz)
            => LAPACKE_dpteqr(layout, compz, n,
                d, e, z, ldz);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dpteqr_work(Layout layout, char compz, int n,
            double[] d, double[] e, double[] z, int ldz,
            double[] work);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dpteqr_work(Layout layout, char compz, int n,
            double[] d, double[] e, double[] z, int ldz,
            double[] work)
            => LAPACKE_dpteqr_work(layout, compz, n,
                d, e, z, ldz,
                work);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dptrfs(Layout layout, int n, int nrhs,
            double[] d, double[] e, double[] df,
            double[] ef, double[] b, int ldb,
            double[] x, int ldx, double[] ferr,
            double[] berr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dptrfs(Layout layout, int n, int nrhs,
            double[] d, double[] e, double[] df,
            double[] ef, double[] b, int ldb,
            double[] x, int ldx, double[] ferr,
            double[] berr)
            => LAPACKE_dptrfs(layout, n, nrhs,
                d, e, df,
                ef, b, ldb,
                x, ldx, ferr,
                berr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dptrfs_work(Layout layout, int n, int nrhs,
            double[] d, double[] e,
            double[] df, double[] ef,
            double[] b, int ldb, double[] x,
            int ldx, double[] ferr, double[] berr,
            double[] work);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dptrfs_work(Layout layout, int n, int nrhs,
            double[] d, double[] e,
            double[] df, double[] ef,
            double[] b, int ldb, double[] x,
            int ldx, double[] ferr, double[] berr,
            double[] work)
            => LAPACKE_dptrfs_work(layout, n, nrhs,
                d, e,
                df, ef,
                b, ldb, x,
                ldx, ferr, berr,
                work);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dptsv(Layout layout, int n, int nrhs,
            double[] d, double[] e, double[] b, int ldb);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dptsv(Layout layout, int n, int nrhs,
            double[] d, double[] e, double[] b, int ldb)
            => LAPACKE_dptsv(layout, n, nrhs,
                d, e, b, ldb);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dptsv_work(Layout layout, int n, int nrhs,
            double[] d, double[] e, double[] b, int ldb);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dptsv_work(Layout layout, int n, int nrhs,
            double[] d, double[] e, double[] b, int ldb)
            => LAPACKE_dptsv_work(layout, n, nrhs,
                d, e, b, ldb);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dptsvx(Layout layout, char fact, int n,
            int nrhs, double[] d, double[] e,
            double[] df, double[] ef, double[] b,
            int ldb, double[] x, int ldx,
            double[] rcond, double[] ferr, double[] berr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dptsvx(Layout layout, char fact, int n,
            int nrhs, double[] d, double[] e,
            double[] df, double[] ef, double[] b,
            int ldb, double[] x, int ldx,
            double[] rcond, double[] ferr, double[] berr)
            => LAPACKE_dptsvx(layout, fact, n,
                nrhs, d, e,
                df, ef, b,
                ldb, x, ldx,
                rcond, ferr, berr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dptsvx_work(Layout layout, char fact, int n,
            int nrhs, double[] d,
            double[] e, double[] df, double[] ef,
            double[] b, int ldb, double[] x,
            int ldx, double[] rcond, double[] ferr,
            double[] berr, double[] work);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dptsvx_work(Layout layout, char fact, int n,
            int nrhs, double[] d,
            double[] e, double[] df, double[] ef,
            double[] b, int ldb, double[] x,
            int ldx, double[] rcond, double[] ferr,
            double[] berr, double[] work)
            => LAPACKE_dptsvx_work(layout, fact, n,
                nrhs, d,
                e, df, ef,
                b, ldb, x,
                ldx, rcond, ferr,
                berr, work);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dpttrf(int n, double[] d, double[] e);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dpttrf(int n, double[] d, double[] e)
            => LAPACKE_dpttrf(n, d, e);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dpttrf_work(int n, double[] d, double[] e);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dpttrf_work(int n, double[] d, double[] e)
            => LAPACKE_dpttrf_work(n, d, e);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dpttrs(Layout layout, int n, int nrhs,
            double[] d, double[] e, double[] b,
            int ldb);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dpttrs(Layout layout, int n, int nrhs,
            double[] d, double[] e, double[] b,
            int ldb)
            => LAPACKE_dpttrs(layout, n, nrhs,
                d, e, b,
                ldb);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dpttrs_work(Layout layout, int n, int nrhs,
            double[] d, double[] e, double[] b,
            int ldb);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dpttrs_work(Layout layout, int n, int nrhs,
            double[] d, double[] e, double[] b,
            int ldb)
            => LAPACKE_dpttrs_work(layout, n, nrhs,
                d, e, b,
                ldb);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsbev(Layout layout, char jobz, UpLo uplo, int n,
            int kd, double[] ab, int ldab, double[] w,
            double[] z, int ldz);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dsbev(Layout layout, char jobz, UpLo uplo, int n,
            int kd, double[] ab, int ldab, double[] w,
            double[] z, int ldz)
            => LAPACKE_dsbev(layout, jobz, uplo, n,
                kd, ab, ldab, w,
                z, ldz);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsbev_work(Layout layout, char jobz, UpLo uplo,
            int n, int kd, double[] ab,
            int ldab, double[] w, double[] z,
            int ldz, double[] work);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dsbev_work(Layout layout, char jobz, UpLo uplo,
            int n, int kd, double[] ab,
            int ldab, double[] w, double[] z,
            int ldz, double[] work)
            => LAPACKE_dsbev_work(layout, jobz, uplo,
                n, kd, ab,
                ldab, w, z,
                ldz, work);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsbevd(Layout layout, char jobz, UpLo uplo, int n,
            int kd, double[] ab, int ldab,
            double[] w, double[] z, int ldz);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dsbevd(Layout layout, char jobz, UpLo uplo, int n,
            int kd, double[] ab, int ldab,
            double[] w, double[] z, int ldz)
            => LAPACKE_dsbevd(layout, jobz, uplo, n,
                kd, ab, ldab,
                w, z, ldz);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsbevd_work(Layout layout, char jobz, UpLo uplo,
            int n, int kd, double[] ab,
            int ldab, double[] w, double[] z,
            int ldz, double[] work, int lwork,
            int[] iwork, int liwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dsbevd_work(Layout layout, char jobz, UpLo uplo,
            int n, int kd, double[] ab,
            int ldab, double[] w, double[] z,
            int ldz, double[] work, int lwork,
            int[] iwork, int liwork)
            => LAPACKE_dsbevd_work(layout, jobz, uplo,
                n, kd, ab,
                ldab, w, z,
                ldz, work, lwork,
                iwork, liwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsbevx(Layout layout, char jobz, char range, UpLo uplo,
            int n, int kd, double[] ab,
            int ldab, double[] q, int ldq,
            double vl, double vu, int il, int iu,
            double abstol, int[] m, double[] w, double[] z,
            int ldz, int[] ifail);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dsbevx(Layout layout, char jobz, char range, UpLo uplo,
            int n, int kd, double[] ab,
            int ldab, double[] q, int ldq,
            double vl, double vu, int il, int iu,
            double abstol, int[] m, double[] w, double[] z,
            int ldz, int[] ifail)
            => LAPACKE_dsbevx(layout, jobz, range, uplo,
                n, kd, ab,
                ldab, q, ldq,
                vl, vu, il, iu,
                abstol, m, w, z,
                ldz, ifail);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsbevx_work(Layout layout, char jobz, char range,
            UpLo uplo, int n, int kd,
            double[] ab, int ldab, double[] q,
            int ldq, double vl, double vu,
            int il, int iu, double abstol,
            int[] m, double[] w, double[] z,
            int ldz, double[] work, int[] iwork,
            int[] ifail);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dsbevx_work(Layout layout, char jobz, char range,
            UpLo uplo, int n, int kd,
            double[] ab, int ldab, double[] q,
            int ldq, double vl, double vu,
            int il, int iu, double abstol,
            int[] m, double[] w, double[] z,
            int ldz, double[] work, int[] iwork,
            int[] ifail)
            => LAPACKE_dsbevx_work(layout, jobz, range,
                uplo, n, kd,
                ab, ldab, q,
                ldq, vl, vu,
                il, iu, abstol,
                m, w, z,
                ldz, work, iwork,
                ifail);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsbgst(Layout layout, char vect, UpLo uplo, int n,
            int ka, int kb, double[] ab,
            int ldab, double[] bb, int ldbb,
            double[] x, int ldx);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dsbgst(Layout layout, char vect, UpLo uplo, int n,
            int ka, int kb, double[] ab,
            int ldab, double[] bb, int ldbb,
            double[] x, int ldx)
            => LAPACKE_dsbgst(layout, vect, uplo, n,
                ka, kb, ab,
                ldab, bb, ldbb,
                x, ldx);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsbgst_work(Layout layout, char vect, UpLo uplo,
            int n, int ka, int kb,
            double[] ab, int ldab, double[] bb,
            int ldbb, double[] x, int ldx,
            double[] work);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dsbgst_work(Layout layout, char vect, UpLo uplo,
            int n, int ka, int kb,
            double[] ab, int ldab, double[] bb,
            int ldbb, double[] x, int ldx,
            double[] work)
            => LAPACKE_dsbgst_work(layout, vect, uplo,
                n, ka, kb,
                ab, ldab, bb,
                ldbb, x, ldx,
                work);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsbgv(Layout layout, char jobz, UpLo uplo, int n,
            int ka, int kb, double[] ab,
            int ldab, double[] bb, int ldbb,
            double[] w, double[] z, int ldz);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dsbgv(Layout layout, char jobz, UpLo uplo, int n,
            int ka, int kb, double[] ab,
            int ldab, double[] bb, int ldbb,
            double[] w, double[] z, int ldz)
            => LAPACKE_dsbgv(layout, jobz, uplo, n,
                ka, kb, ab,
                ldab, bb, ldbb,
                w, z, ldz);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsbgv_work(Layout layout, char jobz, UpLo uplo,
            int n, int ka, int kb,
            double[] ab, int ldab, double[] bb,
            int ldbb, double[] w, double[] z,
            int ldz, double[] work);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dsbgv_work(Layout layout, char jobz, UpLo uplo,
            int n, int ka, int kb,
            double[] ab, int ldab, double[] bb,
            int ldbb, double[] w, double[] z,
            int ldz, double[] work)
            => LAPACKE_dsbgv_work(layout, jobz, uplo,
                n, ka, kb,
                ab, ldab, bb,
                ldbb, w, z,
                ldz, work);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsbgvd(Layout layout, char jobz, UpLo uplo, int n,
            int ka, int kb, double[] ab,
            int ldab, double[] bb, int ldbb,
            double[] w, double[] z, int ldz);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dsbgvd(Layout layout, char jobz, UpLo uplo, int n,
            int ka, int kb, double[] ab,
            int ldab, double[] bb, int ldbb,
            double[] w, double[] z, int ldz)
            => LAPACKE_dsbgvd(layout, jobz, uplo, n,
                ka, kb, ab,
                ldab, bb, ldbb,
                w, z, ldz);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsbgvd_work(Layout layout, char jobz, UpLo uplo,
            int n, int ka, int kb,
            double[] ab, int ldab, double[] bb,
            int ldbb, double[] w, double[] z,
            int ldz, double[] work, int lwork,
            int[] iwork, int liwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dsbgvd_work(Layout layout, char jobz, UpLo uplo,
            int n, int ka, int kb,
            double[] ab, int ldab, double[] bb,
            int ldbb, double[] w, double[] z,
            int ldz, double[] work, int lwork,
            int[] iwork, int liwork)
            => LAPACKE_dsbgvd_work(layout, jobz, uplo,
                n, ka, kb,
                ab, ldab, bb,
                ldbb, w, z,
                ldz, work, lwork,
                iwork, liwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsbgvx(Layout layout, char jobz, char range, UpLo uplo,
            int n, int ka, int kb,
            double[] ab, int ldab, double[] bb,
            int ldbb, double[] q, int ldq,
            double vl, double vu, int il, int iu,
            double abstol, int[] m, double[] w, double[] z,
            int ldz, int[] ifail);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dsbgvx(Layout layout, char jobz, char range, UpLo uplo,
            int n, int ka, int kb,
            double[] ab, int ldab, double[] bb,
            int ldbb, double[] q, int ldq,
            double vl, double vu, int il, int iu,
            double abstol, int[] m, double[] w, double[] z,
            int ldz, int[] ifail)
            => LAPACKE_dsbgvx(layout, jobz, range, uplo,
                n, ka, kb,
                ab, ldab, bb,
                ldbb, q, ldq,
                vl, vu, il, iu,
                abstol, m, w, z,
                ldz, ifail);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsbgvx_work(Layout layout, char jobz, char range,
            UpLo uplo, int n, int ka,
            int kb, double[] ab, int ldab,
            double[] bb, int ldbb, double[] q,
            int ldq, double vl, double vu,
            int il, int iu, double abstol,
            int[] m, double[] w, double[] z,
            int ldz, double[] work, int[] iwork,
            int[] ifail);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dsbgvx_work(Layout layout, char jobz, char range,
            UpLo uplo, int n, int ka,
            int kb, double[] ab, int ldab,
            double[] bb, int ldbb, double[] q,
            int ldq, double vl, double vu,
            int il, int iu, double abstol,
            int[] m, double[] w, double[] z,
            int ldz, double[] work, int[] iwork,
            int[] ifail)
            => LAPACKE_dsbgvx_work(layout, jobz, range,
                uplo, n, ka,
                kb, ab, ldab,
                bb, ldbb, q,
                ldq, vl, vu,
                il, iu, abstol,
                m, w, z,
                ldz, work, iwork,
                ifail);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsbtrd(Layout layout, char vect, UpLo uplo, int n,
            int kd, double[] ab, int ldab,
            double[] d, double[] e, double[] q, int ldq);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dsbtrd(Layout layout, char vect, UpLo uplo, int n,
            int kd, double[] ab, int ldab,
            double[] d, double[] e, double[] q, int ldq)
            => LAPACKE_dsbtrd(layout, vect, uplo, n,
                kd, ab, ldab,
                d, e, q, ldq);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsbtrd_work(Layout layout, char vect, UpLo uplo,
            int n, int kd, double[] ab,
            int ldab, double[] d, double[] e,
            double[] q, int ldq, double[] work);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dsbtrd_work(Layout layout, char vect, UpLo uplo,
            int n, int kd, double[] ab,
            int ldab, double[] d, double[] e,
            double[] q, int ldq, double[] work)
            => LAPACKE_dsbtrd_work(layout, vect, uplo,
                n, kd, ab,
                ldab, d, e,
                q, ldq, work);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsfrk(Layout layout, TransChar transr, UpLo uplo, TransChar trans,
            int n, int k, double alpha,
            double[] a, int lda, double beta,
            double[] c);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dsfrk(Layout layout, TransChar transr, UpLo uplo, TransChar trans,
            int n, int k, double alpha,
            double[] a, int lda, double beta,
            double[] c)
            => LAPACKE_dsfrk(layout, transr, uplo, trans,
                n, k, alpha,
                a, lda, beta,
                c);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsfrk_work(Layout layout, TransChar transr, UpLo uplo,
            TransChar trans, int n, int k,
            double alpha, double[] a, int lda,
            double beta, double[] c);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dsfrk_work(Layout layout, TransChar transr, UpLo uplo,
            TransChar trans, int n, int k,
            double alpha, double[] a, int lda,
            double beta, double[] c)
            => LAPACKE_dsfrk_work(layout, transr, uplo,
                trans, n, k,
                alpha, a, lda,
                beta, c);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsgesv(Layout layout, int n, int nrhs,
            double[] a, int lda, int[] ipiv,
            double[] b, int ldb, double[] x, int ldx,
            int[] iter);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dsgesv(Layout layout, int n, int nrhs,
            double[] a, int lda, int[] ipiv,
            double[] b, int ldb, double[] x, int ldx,
            int[] iter)
            => LAPACKE_dsgesv(layout, n, nrhs,
                a, lda, ipiv,
                b, ldb, x, ldx,
                iter);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsgesv_work(Layout layout, int n, int nrhs,
            double[] a, int lda, int[] ipiv,
            double[] b, int ldb, double[] x,
            int ldx, double[] work, float[] swork,
            int[] iter);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dsgesv_work(Layout layout, int n, int nrhs,
            double[] a, int lda, int[] ipiv,
            double[] b, int ldb, double[] x,
            int ldx, double[] work, float[] swork,
            int[] iter)
            => LAPACKE_dsgesv_work(layout, n, nrhs,
                a, lda, ipiv,
                b, ldb, x,
                ldx, work, swork,
                iter);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dspcon(Layout layout, UpLo uplo, int n,
            double[] ap, int[] ipiv,
            double anorm, double[] rcond);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dspcon(Layout layout, UpLo uplo, int n,
            double[] ap, int[] ipiv,
            double anorm, double[] rcond)
            => LAPACKE_dspcon(layout, uplo, n,
                ap, ipiv,
                anorm, rcond);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dspcon_work(Layout layout, UpLo uplo, int n,
            double[] ap, int[] ipiv,
            double anorm, double[] rcond, double[] work,
            int[] iwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dspcon_work(Layout layout, UpLo uplo, int n,
            double[] ap, int[] ipiv,
            double anorm, double[] rcond, double[] work,
            int[] iwork)
            => LAPACKE_dspcon_work(layout, uplo, n,
                ap, ipiv,
                anorm, rcond, work,
                iwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dspev(Layout layout, char jobz, UpLo uplo, int n,
            double[] ap, double[] w, double[] z, int ldz);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dspev(Layout layout, char jobz, UpLo uplo, int n,
            double[] ap, double[] w, double[] z, int ldz)
            => LAPACKE_dspev(layout, jobz, uplo, n,
                ap, w, z, ldz);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dspev_work(Layout layout, char jobz, UpLo uplo,
            int n, double[] ap, double[] w, double[] z,
            int ldz, double[] work);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dspev_work(Layout layout, char jobz, UpLo uplo,
            int n, double[] ap, double[] w, double[] z,
            int ldz, double[] work)
            => LAPACKE_dspev_work(layout, jobz, uplo,
                n, ap, w, z,
                ldz, work);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dspevd(Layout layout, char jobz, UpLo uplo, int n,
            double[] ap, double[] w, double[] z, int ldz);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dspevd(Layout layout, char jobz, UpLo uplo, int n,
            double[] ap, double[] w, double[] z, int ldz)
            => LAPACKE_dspevd(layout, jobz, uplo, n,
                ap, w, z, ldz);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dspevd_work(Layout layout, char jobz, UpLo uplo,
            int n, double[] ap, double[] w, double[] z,
            int ldz, double[] work, int lwork,
            int[] iwork, int liwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dspevd_work(Layout layout, char jobz, UpLo uplo,
            int n, double[] ap, double[] w, double[] z,
            int ldz, double[] work, int lwork,
            int[] iwork, int liwork)
            => LAPACKE_dspevd_work(layout, jobz, uplo,
                n, ap, w, z,
                ldz, work, lwork,
                iwork, liwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dspevx(Layout layout, char jobz, char range, UpLo uplo,
            int n, double[] ap, double vl, double vu,
            int il, int iu, double abstol,
            int[] m, double[] w, double[] z, int ldz,
            int[] ifail);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dspevx(Layout layout, char jobz, char range, UpLo uplo,
            int n, double[] ap, double vl, double vu,
            int il, int iu, double abstol,
            int[] m, double[] w, double[] z, int ldz,
            int[] ifail)
            => LAPACKE_dspevx(layout, jobz, range, uplo,
                n, ap, vl, vu,
                il, iu, abstol,
                m, w, z, ldz,
                ifail);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dspevx_work(Layout layout, char jobz, char range,
            UpLo uplo, int n, double[] ap, double vl,
            double vu, int il, int iu,
            double abstol, int[] m, double[] w,
            double[] z, int ldz, double[] work,
            int[] iwork, int[] ifail);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dspevx_work(Layout layout, char jobz, char range,
            UpLo uplo, int n, double[] ap, double vl,
            double vu, int il, int iu,
            double abstol, int[] m, double[] w,
            double[] z, int ldz, double[] work,
            int[] iwork, int[] ifail)
            => LAPACKE_dspevx_work(layout, jobz, range,
                uplo, n, ap, vl,
                vu, il, iu,
                abstol, m, w,
                z, ldz, work,
                iwork, ifail);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dspgst(Layout layout, int itype, UpLo uplo,
            int n, double[] ap, double[] bp);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dspgst(Layout layout, int itype, UpLo uplo,
            int n, double[] ap, double[] bp)
            => LAPACKE_dspgst(layout, itype, uplo,
                n, ap, bp);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dspgst_work(Layout layout, int itype, UpLo uplo,
            int n, double[] ap, double[] bp);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dspgst_work(Layout layout, int itype, UpLo uplo,
            int n, double[] ap, double[] bp)
            => LAPACKE_dspgst_work(layout, itype, uplo,
                n, ap, bp);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dspgv(Layout layout, int itype, char jobz,
            UpLo uplo, int n, double[] ap, double[] bp,
            double[] w, double[] z, int ldz);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dspgv(Layout layout, int itype, char jobz,
            UpLo uplo, int n, double[] ap, double[] bp,
            double[] w, double[] z, int ldz)
            => LAPACKE_dspgv(layout, itype, jobz,
                uplo, n, ap, bp,
                w, z, ldz);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dspgv_work(Layout layout, int itype, char jobz,
            UpLo uplo, int n, double[] ap, double[] bp,
            double[] w, double[] z, int ldz,
            double[] work);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dspgv_work(Layout layout, int itype, char jobz,
            UpLo uplo, int n, double[] ap, double[] bp,
            double[] w, double[] z, int ldz,
            double[] work)
            => LAPACKE_dspgv_work(layout, itype, jobz,
                uplo, n, ap, bp,
                w, z, ldz,
                work);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dspgvd(Layout layout, int itype, char jobz,
            UpLo uplo, int n, double[] ap, double[] bp,
            double[] w, double[] z, int ldz);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dspgvd(Layout layout, int itype, char jobz,
            UpLo uplo, int n, double[] ap, double[] bp,
            double[] w, double[] z, int ldz)
            => LAPACKE_dspgvd(layout, itype, jobz,
                uplo, n, ap, bp,
                w, z, ldz);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dspgvd_work(Layout layout, int itype, char jobz,
            UpLo uplo, int n, double[] ap, double[] bp,
            double[] w, double[] z, int ldz,
            double[] work, int lwork,
            int[] iwork, int liwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dspgvd_work(Layout layout, int itype, char jobz,
            UpLo uplo, int n, double[] ap, double[] bp,
            double[] w, double[] z, int ldz,
            double[] work, int lwork,
            int[] iwork, int liwork)
            => LAPACKE_dspgvd_work(layout, itype, jobz,
                uplo, n, ap, bp,
                w, z, ldz,
                work, lwork,
                iwork, liwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dspgvx(Layout layout, int itype, char jobz,
            char range, UpLo uplo, int n, double[] ap,
            double[] bp, double vl, double vu, int il,
            int iu, double abstol, int[] m,
            double[] w, double[] z, int ldz,
            int[] ifail);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dspgvx(Layout layout, int itype, char jobz,
            char range, UpLo uplo, int n, double[] ap,
            double[] bp, double vl, double vu, int il,
            int iu, double abstol, int[] m,
            double[] w, double[] z, int ldz,
            int[] ifail)
            => LAPACKE_dspgvx(layout, itype, jobz,
                range, uplo, n, ap,
                bp, vl, vu, il,
                iu, abstol, m,
                w, z, ldz,
                ifail);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dspgvx_work(Layout layout, int itype, char jobz,
            char range, UpLo uplo, int n, double[] ap,
            double[] bp, double vl, double vu, int il,
            int iu, double abstol, int[] m,
            double[] w, double[] z, int ldz,
            double[] work, int[] iwork,
            int[] ifail);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dspgvx_work(Layout layout, int itype, char jobz,
            char range, UpLo uplo, int n, double[] ap,
            double[] bp, double vl, double vu, int il,
            int iu, double abstol, int[] m,
            double[] w, double[] z, int ldz,
            double[] work, int[] iwork,
            int[] ifail)
            => LAPACKE_dspgvx_work(layout, itype, jobz,
                range, uplo, n, ap,
                bp, vl, vu, il,
                iu, abstol, m,
                w, z, ldz,
                work, iwork,
                ifail);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsposv(Layout layout, UpLo uplo, int n,
            int nrhs, double[] a, int lda,
            double[] b, int ldb, double[] x, int ldx,
            int[] iter);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dsposv(Layout layout, UpLo uplo, int n,
            int nrhs, double[] a, int lda,
            double[] b, int ldb, double[] x, int ldx,
            int[] iter)
            => LAPACKE_dsposv(layout, uplo, n,
                nrhs, a, lda,
                b, ldb, x, ldx,
                iter);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsposv_work(Layout layout, UpLo uplo, int n,
            int nrhs, double[] a, int lda,
            double[] b, int ldb, double[] x,
            int ldx, double[] work, float[] swork,
            int[] iter);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dsposv_work(Layout layout, UpLo uplo, int n,
            int nrhs, double[] a, int lda,
            double[] b, int ldb, double[] x,
            int ldx, double[] work, float[] swork,
            int[] iter)
            => LAPACKE_dsposv_work(layout, uplo, n,
                nrhs, a, lda,
                b, ldb, x,
                ldx, work, swork,
                iter);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsprfs(Layout layout, UpLo uplo, int n,
            int nrhs, double[] ap, double[] afp,
            int[] ipiv, double[] b,
            int ldb, double[] x, int ldx,
            double[] ferr, double[] berr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dsprfs(Layout layout, UpLo uplo, int n,
            int nrhs, double[] ap, double[] afp,
            int[] ipiv, double[] b,
            int ldb, double[] x, int ldx,
            double[] ferr, double[] berr)
            => LAPACKE_dsprfs(layout, uplo, n,
                nrhs, ap, afp,
                ipiv, b,
                ldb, x, ldx,
                ferr, berr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsprfs_work(Layout layout, UpLo uplo, int n,
            int nrhs, double[] ap,
            double[] afp, int[] ipiv,
            double[] b, int ldb, double[] x,
            int ldx, double[] ferr, double[] berr,
            double[] work, int[] iwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dsprfs_work(Layout layout, UpLo uplo, int n,
            int nrhs, double[] ap,
            double[] afp, int[] ipiv,
            double[] b, int ldb, double[] x,
            int ldx, double[] ferr, double[] berr,
            double[] work, int[] iwork)
            => LAPACKE_dsprfs_work(layout, uplo, n,
                nrhs, ap,
                afp, ipiv,
                b, ldb, x,
                ldx, ferr, berr,
                work, iwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dspsv(Layout layout, UpLo uplo, int n,
            int nrhs, double[] ap, int[] ipiv,
            double[] b, int ldb);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dspsv(Layout layout, UpLo uplo, int n,
            int nrhs, double[] ap, int[] ipiv,
            double[] b, int ldb)
            => LAPACKE_dspsv(layout, uplo, n,
                nrhs, ap, ipiv,
                b, ldb);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dspsv_work(Layout layout, UpLo uplo, int n,
            int nrhs, double[] ap, int[] ipiv,
            double[] b, int ldb);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dspsv_work(Layout layout, UpLo uplo, int n,
            int nrhs, double[] ap, int[] ipiv,
            double[] b, int ldb)
            => LAPACKE_dspsv_work(layout, uplo, n,
                nrhs, ap, ipiv,
                b, ldb);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dspsvx(Layout layout, char fact, UpLo uplo, int n,
            int nrhs, double[] ap, double[] afp,
            int[] ipiv, double[] b, int ldb,
            double[] x, int ldx, double[] rcond,
            double[] ferr, double[] berr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dspsvx(Layout layout, char fact, UpLo uplo, int n,
            int nrhs, double[] ap, double[] afp,
            int[] ipiv, double[] b, int ldb,
            double[] x, int ldx, double[] rcond,
            double[] ferr, double[] berr)
            => LAPACKE_dspsvx(layout, fact, uplo, n,
                nrhs, ap, afp,
                ipiv, b, ldb,
                x, ldx, rcond,
                ferr, berr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dspsvx_work(Layout layout, char fact, UpLo uplo,
            int n, int nrhs, double[] ap,
            double[] afp, int[] ipiv, double[] b,
            int ldb, double[] x, int ldx,
            double[] rcond, double[] ferr, double[] berr,
            double[] work, int[] iwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dspsvx_work(Layout layout, char fact, UpLo uplo,
            int n, int nrhs, double[] ap,
            double[] afp, int[] ipiv, double[] b,
            int ldb, double[] x, int ldx,
            double[] rcond, double[] ferr, double[] berr,
            double[] work, int[] iwork)
            => LAPACKE_dspsvx_work(layout, fact, uplo,
                n, nrhs, ap,
                afp, ipiv, b,
                ldb, x, ldx,
                rcond, ferr, berr,
                work, iwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsptrd(Layout layout, UpLo uplo, int n,
            double[] ap, double[] d, double[] e, double[] tau);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dsptrd(Layout layout, UpLo uplo, int n,
            double[] ap, double[] d, double[] e, double[] tau)
            => LAPACKE_dsptrd(layout, uplo, n,
                ap, d, e, tau);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsptrd_work(Layout layout, UpLo uplo, int n,
            double[] ap, double[] d, double[] e, double[] tau);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dsptrd_work(Layout layout, UpLo uplo, int n,
            double[] ap, double[] d, double[] e, double[] tau)
            => LAPACKE_dsptrd_work(layout, uplo, n,
                ap, d, e, tau);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsptrf(Layout layout, UpLo uplo, int n,
            double[] ap, int[] ipiv);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dsptrf(Layout layout, UpLo uplo, int n,
            double[] ap, int[] ipiv)
            => LAPACKE_dsptrf(layout, uplo, n,
                ap, ipiv);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsptrf_work(Layout layout, UpLo uplo, int n,
            double[] ap, int[] ipiv);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dsptrf_work(Layout layout, UpLo uplo, int n,
            double[] ap, int[] ipiv)
            => LAPACKE_dsptrf_work(layout, uplo, n,
                ap, ipiv);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsptri(Layout layout, UpLo uplo, int n,
            double[] ap, int[] ipiv);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dsptri(Layout layout, UpLo uplo, int n,
            double[] ap, int[] ipiv)
            => LAPACKE_dsptri(layout, uplo, n,
                ap, ipiv);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsptri_work(Layout layout, UpLo uplo, int n,
            double[] ap, int[] ipiv,
            double[] work);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dsptri_work(Layout layout, UpLo uplo, int n,
            double[] ap, int[] ipiv,
            double[] work)
            => LAPACKE_dsptri_work(layout, uplo, n,
                ap, ipiv,
                work);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsptrs(Layout layout, UpLo uplo, int n,
            int nrhs, double[] ap,
            int[] ipiv, double[] b, int ldb);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dsptrs(Layout layout, UpLo uplo, int n,
            int nrhs, double[] ap,
            int[] ipiv, double[] b, int ldb)
            => LAPACKE_dsptrs(layout, uplo, n,
                nrhs, ap,
                ipiv, b, ldb);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsptrs_work(Layout layout, UpLo uplo, int n,
            int nrhs, double[] ap,
            int[] ipiv, double[] b,
            int ldb);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dsptrs_work(Layout layout, UpLo uplo, int n,
            int nrhs, double[] ap,
            int[] ipiv, double[] b,
            int ldb)
            => LAPACKE_dsptrs_work(layout, uplo, n,
                nrhs, ap,
                ipiv, b,
                ldb);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dstebz(char range, char order, int n, double vl,
            double vu, int il, int iu,
            double abstol, double[] d, double[] e,
            int[] m, int[] nsplit, double[] w,
            int[] iblock, int[] isplit);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dstebz(char range, char order, int n, double vl,
            double vu, int il, int iu,
            double abstol, double[] d, double[] e,
            int[] m, int[] nsplit, double[] w,
            int[] iblock, int[] isplit)
            => LAPACKE_dstebz(range, order, n, vl,
                vu, il, iu,
                abstol, d, e,
                m, nsplit, w,
                iblock, isplit);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dstebz_work(char range, char order, int n, double vl,
            double vu, int il, int iu,
            double abstol, double[] d, double[] e,
            int[] m, int[] nsplit, double[] w,
            int[] iblock, int[] isplit,
            double[] work, int[] iwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dstebz_work(char range, char order, int n, double vl,
            double vu, int il, int iu,
            double abstol, double[] d, double[] e,
            int[] m, int[] nsplit, double[] w,
            int[] iblock, int[] isplit,
            double[] work, int[] iwork)
            => LAPACKE_dstebz_work(range, order, n, vl,
                vu, il, iu,
                abstol, d, e,
                m, nsplit, w,
                iblock, isplit,
                work, iwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dstedc(Layout layout, char compz, int n,
            double[] d, double[] e, double[] z, int ldz);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dstedc(Layout layout, char compz, int n,
            double[] d, double[] e, double[] z, int ldz)
            => LAPACKE_dstedc(layout, compz, n,
                d, e, z, ldz);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dstedc_work(Layout layout, char compz, int n,
            double[] d, double[] e, double[] z, int ldz,
            double[] work, int lwork,
            int[] iwork, int liwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dstedc_work(Layout layout, char compz, int n,
            double[] d, double[] e, double[] z, int ldz,
            double[] work, int lwork,
            int[] iwork, int liwork)
            => LAPACKE_dstedc_work(layout, compz, n,
                d, e, z, ldz,
                work, lwork,
                iwork, liwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dstegr(Layout layout, char jobz, char range,
            int n, double[] d, double[] e, double vl,
            double vu, int il, int iu,
            double abstol, int[] m, double[] w, double[] z,
            int ldz, int[] isuppz);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dstegr(Layout layout, char jobz, char range,
            int n, double[] d, double[] e, double vl,
            double vu, int il, int iu,
            double abstol, int[] m, double[] w, double[] z,
            int ldz, int[] isuppz)
            => LAPACKE_dstegr(layout, jobz, range,
                n, d, e, vl,
                vu, il, iu,
                abstol, m, w, z,
                ldz, isuppz);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dstegr_work(Layout layout, char jobz, char range,
            int n, double[] d, double[] e, double vl,
            double vu, int il, int iu,
            double abstol, int[] m, double[] w,
            double[] z, int ldz, int[] isuppz,
            double[] work, int lwork,
            int[] iwork, int liwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dstegr_work(Layout layout, char jobz, char range,
            int n, double[] d, double[] e, double vl,
            double vu, int il, int iu,
            double abstol, int[] m, double[] w,
            double[] z, int ldz, int[] isuppz,
            double[] work, int lwork,
            int[] iwork, int liwork)
            => LAPACKE_dstegr_work(layout, jobz, range,
                n, d, e, vl,
                vu, il, iu,
                abstol, m, w,
                z, ldz, isuppz,
                work, lwork,
                iwork, liwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dstein(Layout layout, int n, double[] d,
            double[] e, int m, double[] w,
            int[] iblock, int[] isplit,
            double[] z, int ldz, int[] ifailv);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dstein(Layout layout, int n, double[] d,
            double[] e, int m, double[] w,
            int[] iblock, int[] isplit,
            double[] z, int ldz, int[] ifailv)
            => LAPACKE_dstein(layout, n, d,
                e, m, w,
                iblock, isplit,
                z, ldz, ifailv);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dstein_work(Layout layout, int n, double[] d,
            double[] e, int m, double[] w,
            int[] iblock,
            int[] isplit, double[] z,
            int ldz, double[] work, int[] iwork,
            int[] ifailv);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dstein_work(Layout layout, int n, double[] d,
            double[] e, int m, double[] w,
            int[] iblock,
            int[] isplit, double[] z,
            int ldz, double[] work, int[] iwork,
            int[] ifailv)
            => LAPACKE_dstein_work(layout, n, d,
                e, m, w,
                iblock,
                isplit, z,
                ldz, work, iwork,
                ifailv);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dstemr(Layout layout, char jobz, char range,
            int n, double[] d, double[] e, double vl,
            double vu, int il, int iu,
            int[] m, double[] w, double[] z, int ldz,
            int nzc, int[] isuppz,
            int[] tryrac);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dstemr(Layout layout, char jobz, char range,
            int n, double[] d, double[] e, double vl,
            double vu, int il, int iu,
            int[] m, double[] w, double[] z, int ldz,
            int nzc, int[] isuppz,
            int[] tryrac)
            => LAPACKE_dstemr(layout, jobz, range,
                n, d, e, vl,
                vu, il, iu,
                m, w, z, ldz,
                nzc, isuppz,
                tryrac);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dstemr_work(Layout layout, char jobz, char range,
            int n, double[] d, double[] e, double vl,
            double vu, int il, int iu,
            int[] m, double[] w, double[] z,
            int ldz, int nzc,
            int[] isuppz, int[] tryrac,
            double[] work, int lwork,
            int[] iwork, int liwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dstemr_work(Layout layout, char jobz, char range,
            int n, double[] d, double[] e, double vl,
            double vu, int il, int iu,
            int[] m, double[] w, double[] z,
            int ldz, int nzc,
            int[] isuppz, int[] tryrac,
            double[] work, int lwork,
            int[] iwork, int liwork)
            => LAPACKE_dstemr_work(layout, jobz, range,
                n, d, e, vl,
                vu, il, iu,
                m, w, z,
                ldz, nzc,
                isuppz, tryrac,
                work, lwork,
                iwork, liwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsteqr(Layout layout, char compz, int n,
            double[] d, double[] e, double[] z, int ldz);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dsteqr(Layout layout, char compz, int n,
            double[] d, double[] e, double[] z, int ldz)
            => LAPACKE_dsteqr(layout, compz, n,
                d, e, z, ldz);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsteqr_work(Layout layout, char compz, int n,
            double[] d, double[] e, double[] z, int ldz,
            double[] work);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dsteqr_work(Layout layout, char compz, int n,
            double[] d, double[] e, double[] z, int ldz,
            double[] work)
            => LAPACKE_dsteqr_work(layout, compz, n,
                d, e, z, ldz,
                work);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsterf(int n, double[] d, double[] e);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dsterf(int n, double[] d, double[] e)
            => LAPACKE_dsterf(n, d, e);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsterf_work(int n, double[] d, double[] e);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dsterf_work(int n, double[] d, double[] e)
            => LAPACKE_dsterf_work(n, d, e);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dstev(Layout layout, char jobz, int n, double[] d,
            double[] e, double[] z, int ldz);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dstev(Layout layout, char jobz, int n, double[] d,
            double[] e, double[] z, int ldz)
            => LAPACKE_dstev(layout, jobz, n, d,
                e, z, ldz);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dstev_work(Layout layout, char jobz, int n,
            double[] d, double[] e, double[] z, int ldz,
            double[] work);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dstev_work(Layout layout, char jobz, int n,
            double[] d, double[] e, double[] z, int ldz,
            double[] work)
            => LAPACKE_dstev_work(layout, jobz, n,
                d, e, z, ldz,
                work);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dstevd(Layout layout, char jobz, int n, double[] d,
            double[] e, double[] z, int ldz);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dstevd(Layout layout, char jobz, int n, double[] d,
            double[] e, double[] z, int ldz)
            => LAPACKE_dstevd(layout, jobz, n, d,
                e, z, ldz);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dstevd_work(Layout layout, char jobz, int n,
            double[] d, double[] e, double[] z, int ldz,
            double[] work, int lwork,
            int[] iwork, int liwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dstevd_work(Layout layout, char jobz, int n,
            double[] d, double[] e, double[] z, int ldz,
            double[] work, int lwork,
            int[] iwork, int liwork)
            => LAPACKE_dstevd_work(layout, jobz, n,
                d, e, z, ldz,
                work, lwork,
                iwork, liwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dstevr(Layout layout, char jobz, char range,
            int n, double[] d, double[] e, double vl,
            double vu, int il, int iu,
            double abstol, int[] m, double[] w, double[] z,
            int ldz, int[] isuppz);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dstevr(Layout layout, char jobz, char range,
            int n, double[] d, double[] e, double vl,
            double vu, int il, int iu,
            double abstol, int[] m, double[] w, double[] z,
            int ldz, int[] isuppz)
            => LAPACKE_dstevr(layout, jobz, range,
                n, d, e, vl,
                vu, il, iu,
                abstol, m, w, z,
                ldz, isuppz);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dstevr_work(Layout layout, char jobz, char range,
            int n, double[] d, double[] e, double vl,
            double vu, int il, int iu,
            double abstol, int[] m, double[] w,
            double[] z, int ldz, int[] isuppz,
            double[] work, int lwork,
            int[] iwork, int liwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dstevr_work(Layout layout, char jobz, char range,
            int n, double[] d, double[] e, double vl,
            double vu, int il, int iu,
            double abstol, int[] m, double[] w,
            double[] z, int ldz, int[] isuppz,
            double[] work, int lwork,
            int[] iwork, int liwork)
            => LAPACKE_dstevr_work(layout, jobz, range,
                n, d, e, vl,
                vu, il, iu,
                abstol, m, w,
                z, ldz, isuppz,
                work, lwork,
                iwork, liwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dstevx(Layout layout, char jobz, char range,
            int n, double[] d, double[] e, double vl,
            double vu, int il, int iu,
            double abstol, int[] m, double[] w, double[] z,
            int ldz, int[] ifail);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dstevx(Layout layout, char jobz, char range,
            int n, double[] d, double[] e, double vl,
            double vu, int il, int iu,
            double abstol, int[] m, double[] w, double[] z,
            int ldz, int[] ifail)
            => LAPACKE_dstevx(layout, jobz, range,
                n, d, e, vl,
                vu, il, iu,
                abstol, m, w, z,
                ldz, ifail);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dstevx_work(Layout layout, char jobz, char range,
            int n, double[] d, double[] e, double vl,
            double vu, int il, int iu,
            double abstol, int[] m, double[] w,
            double[] z, int ldz, double[] work,
            int[] iwork, int[] ifail);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dstevx_work(Layout layout, char jobz, char range,
            int n, double[] d, double[] e, double vl,
            double vu, int il, int iu,
            double abstol, int[] m, double[] w,
            double[] z, int ldz, double[] work,
            int[] iwork, int[] ifail)
            => LAPACKE_dstevx_work(layout, jobz, range,
                n, d, e, vl,
                vu, il, iu,
                abstol, m, w,
                z, ldz, work,
                iwork, ifail);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsycon(Layout layout, UpLo uplo, int n,
            double[] a, int lda,
            int[] ipiv, double anorm, double[] rcond);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dsycon(Layout layout, UpLo uplo, int n,
            double[] a, int lda,
            int[] ipiv, double anorm, double[] rcond)
            => LAPACKE_dsycon(layout, uplo, n,
                a, lda,
                ipiv, anorm, rcond);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsycon_work(Layout layout, UpLo uplo, int n,
            double[] a, int lda,
            int[] ipiv, double anorm,
            double[] rcond, double[] work, int[] iwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dsycon_work(Layout layout, UpLo uplo, int n,
            double[] a, int lda,
            int[] ipiv, double anorm,
            double[] rcond, double[] work, int[] iwork)
            => LAPACKE_dsycon_work(layout, uplo, n,
                a, lda,
                ipiv, anorm,
                rcond, work, iwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsyconv(Layout layout, UpLo uplo, char way, int n,
            double[] a, int lda, int[] ipiv,
            double[] e);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dsyconv(Layout layout, UpLo uplo, char way, int n,
            double[] a, int lda, int[] ipiv,
            double[] e)
            => LAPACKE_dsyconv(layout, uplo, way, n,
                a, lda, ipiv,
                e);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsyconv_work(Layout layout, UpLo uplo, char way,
            int n, double[] a, int lda,
            int[] ipiv, double[] e);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dsyconv_work(Layout layout, UpLo uplo, char way,
            int n, double[] a, int lda,
            int[] ipiv, double[] e)
            => LAPACKE_dsyconv_work(layout, uplo, way,
                n, a, lda,
                ipiv, e);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsyequb(Layout layout, UpLo uplo, int n,
            double[] a, int lda, double[] s,
            double[] scond, double[] amax);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dsyequb(Layout layout, UpLo uplo, int n,
            double[] a, int lda, double[] s,
            double[] scond, double[] amax)
            => LAPACKE_dsyequb(layout, uplo, n,
                a, lda, s,
                scond, amax);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsyequb_work(Layout layout, UpLo uplo, int n,
            double[] a, int lda, double[] s,
            double[] scond, double[] amax, double[] work);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dsyequb_work(Layout layout, UpLo uplo, int n,
            double[] a, int lda, double[] s,
            double[] scond, double[] amax, double[] work)
            => LAPACKE_dsyequb_work(layout, uplo, n,
                a, lda, s,
                scond, amax, work);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsyev(Layout layout, char jobz, UpLo uplo, int n,
            double[] a, int lda, double[] w);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dsyev(Layout layout, char jobz, UpLo uplo, int n,
            double[] a, int lda, double[] w)
            => LAPACKE_dsyev(layout, jobz, uplo, n,
                a, lda, w);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsyev_work(Layout layout, char jobz, UpLo uplo,
            int n, double[] a, int lda,
            double[] w, double[] work, int lwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dsyev_work(Layout layout, char jobz, UpLo uplo,
            int n, double[] a, int lda,
            double[] w, double[] work, int lwork)
            => LAPACKE_dsyev_work(layout, jobz, uplo,
                n, a, lda,
                w, work, lwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsyevd(Layout layout, char jobz, UpLo uplo, int n,
            double[] a, int lda, double[] w);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dsyevd(Layout layout, char jobz, UpLo uplo, int n,
            double[] a, int lda, double[] w)
            => LAPACKE_dsyevd(layout, jobz, uplo, n,
                a, lda, w);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsyevd_work(Layout layout, char jobz, UpLo uplo,
            int n, double[] a, int lda,
            double[] w, double[] work, int lwork,
            int[] iwork, int liwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dsyevd_work(Layout layout, char jobz, UpLo uplo,
            int n, double[] a, int lda,
            double[] w, double[] work, int lwork,
            int[] iwork, int liwork)
            => LAPACKE_dsyevd_work(layout, jobz, uplo,
                n, a, lda,
                w, work, lwork,
                iwork, liwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsyevr(Layout layout, char jobz, char range, UpLo uplo,
            int n, double[] a, int lda, double vl,
            double vu, int il, int iu,
            double abstol, int[] m, double[] w, double[] z,
            int ldz, int[] isuppz);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dsyevr(Layout layout, char jobz, char range, UpLo uplo,
            int n, double[] a, int lda, double vl,
            double vu, int il, int iu,
            double abstol, int[] m, double[] w, double[] z,
            int ldz, int[] isuppz)
            => LAPACKE_dsyevr(layout, jobz, range, uplo,
                n, a, lda, vl,
                vu, il, iu,
                abstol, m, w, z,
                ldz, isuppz);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsyevr_work(Layout layout, char jobz, char range,
            UpLo uplo, int n, double[] a,
            int lda, double vl, double vu,
            int il, int iu, double abstol,
            int[] m, double[] w, double[] z,
            int ldz, int[] isuppz,
            double[] work, int lwork,
            int[] iwork, int liwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dsyevr_work(Layout layout, char jobz, char range,
            UpLo uplo, int n, double[] a,
            int lda, double vl, double vu,
            int il, int iu, double abstol,
            int[] m, double[] w, double[] z,
            int ldz, int[] isuppz,
            double[] work, int lwork,
            int[] iwork, int liwork)
            => LAPACKE_dsyevr_work(layout, jobz, range,
                uplo, n, a,
                lda, vl, vu,
                il, iu, abstol,
                m, w, z,
                ldz, isuppz,
                work, lwork,
                iwork, liwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsyevx(Layout layout, char jobz, char range, UpLo uplo,
            int n, double[] a, int lda, double vl,
            double vu, int il, int iu,
            double abstol, int[] m, double[] w, double[] z,
            int ldz, int[] ifail);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dsyevx(Layout layout, char jobz, char range, UpLo uplo,
            int n, double[] a, int lda, double vl,
            double vu, int il, int iu,
            double abstol, int[] m, double[] w, double[] z,
            int ldz, int[] ifail)
            => LAPACKE_dsyevx(layout, jobz, range, uplo,
                n, a, lda, vl,
                vu, il, iu,
                abstol, m, w, z,
                ldz, ifail);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsyevx_work(Layout layout, char jobz, char range,
            UpLo uplo, int n, double[] a,
            int lda, double vl, double vu,
            int il, int iu, double abstol,
            int[] m, double[] w, double[] z,
            int ldz, double[] work, int lwork,
            int[] iwork, int[] ifail);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dsyevx_work(Layout layout, char jobz, char range,
            UpLo uplo, int n, double[] a,
            int lda, double vl, double vu,
            int il, int iu, double abstol,
            int[] m, double[] w, double[] z,
            int ldz, double[] work, int lwork,
            int[] iwork, int[] ifail)
            => LAPACKE_dsyevx_work(layout, jobz, range,
                uplo, n, a,
                lda, vl, vu,
                il, iu, abstol,
                m, w, z,
                ldz, work, lwork,
                iwork, ifail);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsygst(Layout layout, int itype, UpLo uplo,
            int n, double[] a, int lda,
            double[] b, int ldb);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dsygst(Layout layout, int itype, UpLo uplo,
            int n, double[] a, int lda,
            double[] b, int ldb)
            => LAPACKE_dsygst(layout, itype, uplo,
                n, a, lda,
                b, ldb);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsygst_work(Layout layout, int itype, UpLo uplo,
            int n, double[] a, int lda,
            double[] b, int ldb);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dsygst_work(Layout layout, int itype, UpLo uplo,
            int n, double[] a, int lda,
            double[] b, int ldb)
            => LAPACKE_dsygst_work(layout, itype, uplo,
                n, a, lda,
                b, ldb);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsygv(Layout layout, int itype, char jobz,
            UpLo uplo, int n, double[] a, int lda,
            double[] b, int ldb, double[] w);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dsygv(Layout layout, int itype, char jobz,
            UpLo uplo, int n, double[] a, int lda,
            double[] b, int ldb, double[] w)
            => LAPACKE_dsygv(layout, itype, jobz,
                uplo, n, a, lda,
                b, ldb, w);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsygv_work(Layout layout, int itype, char jobz,
            UpLo uplo, int n, double[] a,
            int lda, double[] b, int ldb,
            double[] w, double[] work, int lwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dsygv_work(Layout layout, int itype, char jobz,
            UpLo uplo, int n, double[] a,
            int lda, double[] b, int ldb,
            double[] w, double[] work, int lwork)
            => LAPACKE_dsygv_work(layout, itype, jobz,
                uplo, n, a,
                lda, b, ldb,
                w, work, lwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsygvd(Layout layout, int itype, char jobz,
            UpLo uplo, int n, double[] a, int lda,
            double[] b, int ldb, double[] w);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dsygvd(Layout layout, int itype, char jobz,
            UpLo uplo, int n, double[] a, int lda,
            double[] b, int ldb, double[] w)
            => LAPACKE_dsygvd(layout, itype, jobz,
                uplo, n, a, lda,
                b, ldb, w);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsygvd_work(Layout layout, int itype, char jobz,
            UpLo uplo, int n, double[] a,
            int lda, double[] b, int ldb,
            double[] w, double[] work, int lwork,
            int[] iwork, int liwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dsygvd_work(Layout layout, int itype, char jobz,
            UpLo uplo, int n, double[] a,
            int lda, double[] b, int ldb,
            double[] w, double[] work, int lwork,
            int[] iwork, int liwork)
            => LAPACKE_dsygvd_work(layout, itype, jobz,
                uplo, n, a,
                lda, b, ldb,
                w, work, lwork,
                iwork, liwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsygvx(Layout layout, int itype, char jobz,
            char range, UpLo uplo, int n, double[] a,
            int lda, double[] b, int ldb, double vl,
            double vu, int il, int iu,
            double abstol, int[] m, double[] w, double[] z,
            int ldz, int[] ifail);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dsygvx(Layout layout, int itype, char jobz,
            char range, UpLo uplo, int n, double[] a,
            int lda, double[] b, int ldb, double vl,
            double vu, int il, int iu,
            double abstol, int[] m, double[] w, double[] z,
            int ldz, int[] ifail)
            => LAPACKE_dsygvx(layout, itype, jobz,
                range, uplo, n, a,
                lda, b, ldb, vl,
                vu, il, iu,
                abstol, m, w, z,
                ldz, ifail);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsygvx_work(Layout layout, int itype, char jobz,
            char range, UpLo uplo, int n, double[] a,
            int lda, double[] b, int ldb,
            double vl, double vu, int il,
            int iu, double abstol, int[] m,
            double[] w, double[] z, int ldz,
            double[] work, int lwork,
            int[] iwork, int[] ifail);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dsygvx_work(Layout layout, int itype, char jobz,
            char range, UpLo uplo, int n, double[] a,
            int lda, double[] b, int ldb,
            double vl, double vu, int il,
            int iu, double abstol, int[] m,
            double[] w, double[] z, int ldz,
            double[] work, int lwork,
            int[] iwork, int[] ifail)
            => LAPACKE_dsygvx_work(layout, itype, jobz,
                range, uplo, n, a,
                lda, b, ldb,
                vl, vu, il,
                iu, abstol, m,
                w, z, ldz,
                work, lwork,
                iwork, ifail);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsyrfs(Layout layout, UpLo uplo, int n,
            int nrhs, double[] a, int lda,
            double[] af, int ldaf,
            int[] ipiv, double[] b,
            int ldb, double[] x, int ldx,
            double[] ferr, double[] berr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dsyrfs(Layout layout, UpLo uplo, int n,
            int nrhs, double[] a, int lda,
            double[] af, int ldaf,
            int[] ipiv, double[] b,
            int ldb, double[] x, int ldx,
            double[] ferr, double[] berr)
            => LAPACKE_dsyrfs(layout, uplo, n,
                nrhs, a, lda,
                af, ldaf,
                ipiv, b,
                ldb, x, ldx,
                ferr, berr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsyrfs_work(Layout layout, UpLo uplo, int n,
            int nrhs, double[] a,
            int lda, double[] af,
            int ldaf, int[] ipiv,
            double[] b, int ldb, double[] x,
            int ldx, double[] ferr, double[] berr,
            double[] work, int[] iwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dsyrfs_work(Layout layout, UpLo uplo, int n,
            int nrhs, double[] a,
            int lda, double[] af,
            int ldaf, int[] ipiv,
            double[] b, int ldb, double[] x,
            int ldx, double[] ferr, double[] berr,
            double[] work, int[] iwork)
            => LAPACKE_dsyrfs_work(layout, uplo, n,
                nrhs, a,
                lda, af,
                ldaf, ipiv,
                b, ldb, x,
                ldx, ferr, berr,
                work, iwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsyrfsx(Layout layout, UpLo uplo, char equed,
            int n, int nrhs, double[] a,
            int lda, double[] af, int ldaf,
            int[] ipiv, double[] s,
            double[] b, int ldb, double[] x,
            int ldx, double[] rcond, double[] berr,
            int n_err_bnds, double[] err_bnds_norm,
            double[] err_bnds_comp, int nparams,
            double[] aparams);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dsyrfsx(Layout layout, UpLo uplo, char equed,
            int n, int nrhs, double[] a,
            int lda, double[] af, int ldaf,
            int[] ipiv, double[] s,
            double[] b, int ldb, double[] x,
            int ldx, double[] rcond, double[] berr,
            int n_err_bnds, double[] err_bnds_norm,
            double[] err_bnds_comp, int nparams,
            double[] aparams)
            => LAPACKE_dsyrfsx(layout, uplo, equed,
                n, nrhs, a,
                lda, af, ldaf,
                ipiv, s,
                b, ldb, x,
                ldx, rcond, berr,
                n_err_bnds, err_bnds_norm,
                err_bnds_comp, nparams,
                aparams);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsyrfsx_work(Layout layout, UpLo uplo, char equed,
            int n, int nrhs, double[] a,
            int lda, double[] af,
            int ldaf, int[] ipiv,
            double[] s, double[] b,
            int ldb, double[] x, int ldx,
            double[] rcond, double[] berr,
            int n_err_bnds, double[] err_bnds_norm,
            double[] err_bnds_comp, int nparams,
            double[] aparams, double[] work,
            int[] iwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dsyrfsx_work(Layout layout, UpLo uplo, char equed,
            int n, int nrhs, double[] a,
            int lda, double[] af,
            int ldaf, int[] ipiv,
            double[] s, double[] b,
            int ldb, double[] x, int ldx,
            double[] rcond, double[] berr,
            int n_err_bnds, double[] err_bnds_norm,
            double[] err_bnds_comp, int nparams,
            double[] aparams, double[] work,
            int[] iwork)
            => LAPACKE_dsyrfsx_work(layout, uplo, equed,
                n, nrhs, a,
                lda, af,
                ldaf, ipiv,
                s, b,
                ldb, x, ldx,
                rcond, berr,
                n_err_bnds, err_bnds_norm,
                err_bnds_comp, nparams,
                aparams, work,
                iwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsysv(Layout layout, UpLo uplo, int n,
            int nrhs, double[] a, int lda,
            int[] ipiv, double[] b, int ldb);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dsysv(Layout layout, UpLo uplo, int n,
            int nrhs, double[] a, int lda,
            int[] ipiv, double[] b, int ldb)
            => LAPACKE_dsysv(layout, uplo, n,
                nrhs, a, lda,
                ipiv, b, ldb);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsysv_rook(Layout layout, UpLo uplo, int n,
            int nrhs, double[] a, int lda,
            int[] ipiv, double[] b, int ldb);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dsysv_rook(Layout layout, UpLo uplo, int n,
            int nrhs, double[] a, int lda,
            int[] ipiv, double[] b, int ldb)
            => LAPACKE_dsysv_rook(layout, uplo, n,
                nrhs, a, lda,
                ipiv, b, ldb);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsysv_rook_work(Layout layout, UpLo uplo, int n,
            int nrhs, double[] a, int lda,
            int[] ipiv, double[] b, int ldb,
            double[] work, int lwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dsysv_rook_work(Layout layout, UpLo uplo, int n,
            int nrhs, double[] a, int lda,
            int[] ipiv, double[] b, int ldb,
            double[] work, int lwork)
            => LAPACKE_dsysv_rook_work(layout, uplo, n,
                nrhs, a, lda,
                ipiv, b, ldb,
                work, lwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsysv_work(Layout layout, UpLo uplo, int n,
            int nrhs, double[] a, int lda,
            int[] ipiv, double[] b, int ldb,
            double[] work, int lwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dsysv_work(Layout layout, UpLo uplo, int n,
            int nrhs, double[] a, int lda,
            int[] ipiv, double[] b, int ldb,
            double[] work, int lwork)
            => LAPACKE_dsysv_work(layout, uplo, n,
                nrhs, a, lda,
                ipiv, b, ldb,
                work, lwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsysvx(Layout layout, char fact, UpLo uplo, int n,
            int nrhs, double[] a, int lda,
            double[] af, int ldaf, int[] ipiv,
            double[] b, int ldb, double[] x,
            int ldx, double[] rcond, double[] ferr,
            double[] berr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dsysvx(Layout layout, char fact, UpLo uplo, int n,
            int nrhs, double[] a, int lda,
            double[] af, int ldaf, int[] ipiv,
            double[] b, int ldb, double[] x,
            int ldx, double[] rcond, double[] ferr,
            double[] berr)
            => LAPACKE_dsysvx(layout, fact, uplo, n,
                nrhs, a, lda,
                af, ldaf, ipiv,
                b, ldb, x,
                ldx, rcond, ferr,
                berr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsysvx_work(Layout layout, char fact, UpLo uplo,
            int n, int nrhs, double[] a,
            int lda, double[] af, int ldaf,
            int[] ipiv, double[] b,
            int ldb, double[] x, int ldx,
            double[] rcond, double[] ferr, double[] berr,
            double[] work, int lwork,
            int[] iwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dsysvx_work(Layout layout, char fact, UpLo uplo,
            int n, int nrhs, double[] a,
            int lda, double[] af, int ldaf,
            int[] ipiv, double[] b,
            int ldb, double[] x, int ldx,
            double[] rcond, double[] ferr, double[] berr,
            double[] work, int lwork,
            int[] iwork)
            => LAPACKE_dsysvx_work(layout, fact, uplo,
                n, nrhs, a,
                lda, af, ldaf,
                ipiv, b,
                ldb, x, ldx,
                rcond, ferr, berr,
                work, lwork,
                iwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsysvxx(Layout layout, char fact, UpLo uplo,
            int n, int nrhs, double[] a,
            int lda, double[] af, int ldaf,
            int[] ipiv, char[] equed, double[] s, double[] b,
            int ldb, double[] x, int ldx,
            double[] rcond, double[] rpvgrw, double[] berr,
            int n_err_bnds, double[] err_bnds_norm,
            double[] err_bnds_comp, int nparams,
            double[] aparams);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dsysvxx(Layout layout, char fact, UpLo uplo,
            int n, int nrhs, double[] a,
            int lda, double[] af, int ldaf,
            int[] ipiv, char[] equed, double[] s, double[] b,
            int ldb, double[] x, int ldx,
            double[] rcond, double[] rpvgrw, double[] berr,
            int n_err_bnds, double[] err_bnds_norm,
            double[] err_bnds_comp, int nparams,
            double[] aparams)
            => LAPACKE_dsysvxx(layout, fact, uplo,
                n, nrhs, a,
                lda, af, ldaf,
                ipiv, equed, s, b,
                ldb, x, ldx,
                rcond, rpvgrw, berr,
                n_err_bnds, err_bnds_norm,
                err_bnds_comp, nparams,
                aparams);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsysvxx_work(Layout layout, char fact, UpLo uplo,
            int n, int nrhs, double[] a,
            int lda, double[] af, int ldaf,
            int[] ipiv, char[] equed, double[] s,
            double[] b, int ldb, double[] x,
            int ldx, double[] rcond, double[] rpvgrw,
            double[] berr, int n_err_bnds,
            double[] err_bnds_norm, double[] err_bnds_comp,
            int nparams, double[] aparams,
            double[] work, int[] iwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dsysvxx_work(Layout layout, char fact, UpLo uplo,
            int n, int nrhs, double[] a,
            int lda, double[] af, int ldaf,
            int[] ipiv, char[] equed, double[] s,
            double[] b, int ldb, double[] x,
            int ldx, double[] rcond, double[] rpvgrw,
            double[] berr, int n_err_bnds,
            double[] err_bnds_norm, double[] err_bnds_comp,
            int nparams, double[] aparams,
            double[] work, int[] iwork)
            => LAPACKE_dsysvxx_work(layout, fact, uplo,
                n, nrhs, a,
                lda, af, ldaf,
                ipiv, equed, s,
                b, ldb, x,
                ldx, rcond, rpvgrw,
                berr, n_err_bnds,
                err_bnds_norm, err_bnds_comp,
                nparams, aparams,
                work, iwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsyswapr(Layout layout, UpLo uplo, int n,
            double[] a, int lda, int i1, int i2);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dsyswapr(Layout layout, UpLo uplo, int n,
            double[] a, int lda, int i1, int i2)
            => LAPACKE_dsyswapr(layout, uplo, n,
                a, lda, i1, i2);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsyswapr_work(Layout layout, UpLo uplo, int n,
            double[] a, int lda,
            int i1, int i2);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dsyswapr_work(Layout layout, UpLo uplo, int n,
            double[] a, int lda,
            int i1, int i2)
            => LAPACKE_dsyswapr_work(layout, uplo, n,
                a, lda,
                i1, i2);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsytrd(Layout layout, UpLo uplo, int n, double[] a,
            int lda, double[] d, double[] e, double[] tau);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dsytrd(Layout layout, UpLo uplo, int n, double[] a,
            int lda, double[] d, double[] e, double[] tau)
            => LAPACKE_dsytrd(layout, uplo, n, a,
                lda, d, e, tau);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsytrd_work(Layout layout, UpLo uplo, int n,
            double[] a, int lda, double[] d, double[] e,
            double[] tau, double[] work, int lwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dsytrd_work(Layout layout, UpLo uplo, int n,
            double[] a, int lda, double[] d, double[] e,
            double[] tau, double[] work, int lwork)
            => LAPACKE_dsytrd_work(layout, uplo, n,
                a, lda, d, e,
                tau, work, lwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsytrf(Layout layout, UpLo uplo, int n, double[] a,
            int lda, int[] ipiv);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dsytrf(Layout layout, UpLo uplo, int n, double[] a,
            int lda, int[] ipiv)
            => LAPACKE_dsytrf(layout, uplo, n, a,
                lda, ipiv);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsytrf_rook(Layout layout, UpLo uplo, int n, double[] a,
            int lda, int[] ipiv);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dsytrf_rook(Layout layout, UpLo uplo, int n, double[] a,
            int lda, int[] ipiv)
            => LAPACKE_dsytrf_rook(layout, uplo, n, a,
                lda, ipiv);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsytrf_rook_work(Layout layout, UpLo uplo, int n,
            double[] a, int lda, int[] ipiv,
            double[] work, int lwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dsytrf_rook_work(Layout layout, UpLo uplo, int n,
            double[] a, int lda, int[] ipiv,
            double[] work, int lwork)
            => LAPACKE_dsytrf_rook_work(layout, uplo, n,
                a, lda, ipiv,
                work, lwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsytrf_work(Layout layout, UpLo uplo, int n,
            double[] a, int lda, int[] ipiv,
            double[] work, int lwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dsytrf_work(Layout layout, UpLo uplo, int n,
            double[] a, int lda, int[] ipiv,
            double[] work, int lwork)
            => LAPACKE_dsytrf_work(layout, uplo, n,
                a, lda, ipiv,
                work, lwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsytri(Layout layout, UpLo uplo, int n, double[] a,
            int lda, int[] ipiv);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dsytri(Layout layout, UpLo uplo, int n, double[] a,
            int lda, int[] ipiv)
            => LAPACKE_dsytri(layout, uplo, n, a,
                lda, ipiv);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsytri2(Layout layout, UpLo uplo, int n,
            double[] a, int lda, int[] ipiv);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dsytri2(Layout layout, UpLo uplo, int n,
            double[] a, int lda, int[] ipiv)
            => LAPACKE_dsytri2(layout, uplo, n,
                a, lda, ipiv);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsytri2_work(Layout layout, UpLo uplo, int n,
            double[] a, int lda,
            int[] ipiv,
            double[] work, int lwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dsytri2_work(Layout layout, UpLo uplo, int n,
            double[] a, int lda,
            int[] ipiv,
            double[] work, int lwork)
            => LAPACKE_dsytri2_work(layout, uplo, n,
                a, lda,
                ipiv,
                work, lwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsytri2x(Layout layout, UpLo uplo, int n,
            double[] a, int lda, int[] ipiv,
            int nb);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dsytri2x(Layout layout, UpLo uplo, int n,
            double[] a, int lda, int[] ipiv,
            int nb)
            => LAPACKE_dsytri2x(layout, uplo, n,
                a, lda, ipiv,
                nb);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsytri2x_work(Layout layout, UpLo uplo, int n,
            double[] a, int lda,
            int[] ipiv, double[] work,
            int nb);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dsytri2x_work(Layout layout, UpLo uplo, int n,
            double[] a, int lda,
            int[] ipiv, double[] work,
            int nb)
            => LAPACKE_dsytri2x_work(layout, uplo, n,
                a, lda,
                ipiv, work,
                nb);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsytri_work(Layout layout, UpLo uplo, int n,
            double[] a, int lda,
            int[] ipiv, double[] work);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dsytri_work(Layout layout, UpLo uplo, int n,
            double[] a, int lda,
            int[] ipiv, double[] work)
            => LAPACKE_dsytri_work(layout, uplo, n,
                a, lda,
                ipiv, work);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsytrs(Layout layout, UpLo uplo, int n,
            int nrhs, double[] a, int lda,
            int[] ipiv, double[] b, int ldb);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dsytrs(Layout layout, UpLo uplo, int n,
            int nrhs, double[] a, int lda,
            int[] ipiv, double[] b, int ldb)
            => LAPACKE_dsytrs(layout, uplo, n,
                nrhs, a, lda,
                ipiv, b, ldb);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsytrs2(Layout layout, UpLo uplo, int n,
            int nrhs, double[] a, int lda,
            int[] ipiv, double[] b, int ldb);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dsytrs2(Layout layout, UpLo uplo, int n,
            int nrhs, double[] a, int lda,
            int[] ipiv, double[] b, int ldb)
            => LAPACKE_dsytrs2(layout, uplo, n,
                nrhs, a, lda,
                ipiv, b, ldb);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsytrs2_work(Layout layout, UpLo uplo, int n,
            int nrhs, double[] a,
            int lda, int[] ipiv,
            double[] b, int ldb, double[] work);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dsytrs2_work(Layout layout, UpLo uplo, int n,
            int nrhs, double[] a,
            int lda, int[] ipiv,
            double[] b, int ldb, double[] work)
            => LAPACKE_dsytrs2_work(layout, uplo, n,
                nrhs, a,
                lda, ipiv,
                b, ldb, work);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsytrs_rook(Layout layout, UpLo uplo, int n,
            int nrhs, double[] a, int lda,
            int[] ipiv, double[] b, int ldb);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dsytrs_rook(Layout layout, UpLo uplo, int n,
            int nrhs, double[] a, int lda,
            int[] ipiv, double[] b, int ldb)
            => LAPACKE_dsytrs_rook(layout, uplo, n,
                nrhs, a, lda,
                ipiv, b, ldb);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsytrs_rook_work(Layout layout, UpLo uplo, int n,
            int nrhs, double[] a,
            int lda, int[] ipiv,
            double[] b, int ldb);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dsytrs_rook_work(Layout layout, UpLo uplo, int n,
            int nrhs, double[] a,
            int lda, int[] ipiv,
            double[] b, int ldb)
            => LAPACKE_dsytrs_rook_work(layout, uplo, n,
                nrhs, a,
                lda, ipiv,
                b, ldb);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsytrs_work(Layout layout, UpLo uplo, int n,
            int nrhs, double[] a,
            int lda, int[] ipiv,
            double[] b, int ldb);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dsytrs_work(Layout layout, UpLo uplo, int n,
            int nrhs, double[] a,
            int lda, int[] ipiv,
            double[] b, int ldb)
            => LAPACKE_dsytrs_work(layout, uplo, n,
                nrhs, a,
                lda, ipiv,
                b, ldb);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dtbcon(Layout layout, Norm norm, UpLo uplo, DiagChar diag,
            int n, int kd, double[] ab,
            int ldab, double[] rcond);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dtbcon(Layout layout, Norm norm, UpLo uplo, DiagChar diag,
            int n, int kd, double[] ab,
            int ldab, double[] rcond)
            => LAPACKE_dtbcon(layout, norm, uplo, diag,
                n, kd, ab,
                ldab, rcond);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dtbcon_work(Layout layout, Norm norm, UpLo uplo,
            DiagChar diag, int n, int kd,
            double[] ab, int ldab,
            double[] rcond, double[] work, int[] iwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dtbcon_work(Layout layout, Norm norm, UpLo uplo,
            DiagChar diag, int n, int kd,
            double[] ab, int ldab,
            double[] rcond, double[] work, int[] iwork)
            => LAPACKE_dtbcon_work(layout, norm, uplo,
                diag, n, kd,
                ab, ldab,
                rcond, work, iwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dtbrfs(Layout layout, UpLo uplo, TransChar trans, DiagChar diag,
            int n, int kd, int nrhs,
            double[] ab, int ldab, double[] b,
            int ldb, double[] x, int ldx,
            double[] ferr, double[] berr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dtbrfs(Layout layout, UpLo uplo, TransChar trans, DiagChar diag,
            int n, int kd, int nrhs,
            double[] ab, int ldab, double[] b,
            int ldb, double[] x, int ldx,
            double[] ferr, double[] berr)
            => LAPACKE_dtbrfs(layout, uplo, trans, diag,
                n, kd, nrhs,
                ab, ldab, b,
                ldb, x, ldx,
                ferr, berr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dtbrfs_work(Layout layout, UpLo uplo, TransChar trans,
            DiagChar diag, int n, int kd,
            int nrhs, double[] ab,
            int ldab, double[] b,
            int ldb, double[] x, int ldx,
            double[] ferr, double[] berr, double[] work,
            int[] iwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dtbrfs_work(Layout layout, UpLo uplo, TransChar trans,
            DiagChar diag, int n, int kd,
            int nrhs, double[] ab,
            int ldab, double[] b,
            int ldb, double[] x, int ldx,
            double[] ferr, double[] berr, double[] work,
            int[] iwork)
            => LAPACKE_dtbrfs_work(layout, uplo, trans,
                diag, n, kd,
                nrhs, ab,
                ldab, b,
                ldb, x, ldx,
                ferr, berr, work,
                iwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dtbtrs(Layout layout, UpLo uplo, TransChar trans, DiagChar diag,
            int n, int kd, int nrhs,
            double[] ab, int ldab, double[] b,
            int ldb);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dtbtrs(Layout layout, UpLo uplo, TransChar trans, DiagChar diag,
            int n, int kd, int nrhs,
            double[] ab, int ldab, double[] b,
            int ldb)
            => LAPACKE_dtbtrs(layout, uplo, trans, diag,
                n, kd, nrhs,
                ab, ldab, b,
                ldb);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dtbtrs_work(Layout layout, UpLo uplo, TransChar trans,
            DiagChar diag, int n, int kd,
            int nrhs, double[] ab,
            int ldab, double[] b, int ldb);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dtbtrs_work(Layout layout, UpLo uplo, TransChar trans,
            DiagChar diag, int n, int kd,
            int nrhs, double[] ab,
            int ldab, double[] b, int ldb)
            => LAPACKE_dtbtrs_work(layout, uplo, trans,
                diag, n, kd,
                nrhs, ab,
                ldab, b, ldb);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dtfsm(Layout layout, TransChar transr, char side, UpLo uplo,
            TransChar trans, DiagChar diag, int m, int n,
            double alpha, double[] a, double[] b,
            int ldb);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dtfsm(Layout layout, TransChar transr, char side, UpLo uplo,
            TransChar trans, DiagChar diag, int m, int n,
            double alpha, double[] a, double[] b,
            int ldb)
            => LAPACKE_dtfsm(layout, transr, side, uplo,
                trans, diag, m, n,
                alpha, a, b,
                ldb);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dtfsm_work(Layout layout, TransChar transr, char side,
            UpLo uplo, TransChar trans, DiagChar diag, int m,
            int n, double alpha, double[] a,
            double[] b, int ldb);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dtfsm_work(Layout layout, TransChar transr, char side,
            UpLo uplo, TransChar trans, DiagChar diag, int m,
            int n, double alpha, double[] a,
            double[] b, int ldb)
            => LAPACKE_dtfsm_work(layout, transr, side,
                uplo, trans, diag, m,
                n, alpha, a,
                b, ldb);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dtftri(Layout layout, TransChar transr, UpLo uplo, DiagChar diag,
            int n, double[] a);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dtftri(Layout layout, TransChar transr, UpLo uplo, DiagChar diag,
            int n, double[] a)
            => LAPACKE_dtftri(layout, transr, uplo, diag,
                n, a);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dtftri_work(Layout layout, TransChar transr, UpLo uplo,
            DiagChar diag, int n, double[] a);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dtftri_work(Layout layout, TransChar transr, UpLo uplo,
            DiagChar diag, int n, double[] a)
            => LAPACKE_dtftri_work(layout, transr, uplo,
                diag, n, a);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dtfttp(Layout layout, TransChar transr, UpLo uplo,
            int n, double[] arf, double[] ap);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dtfttp(Layout layout, TransChar transr, UpLo uplo,
            int n, double[] arf, double[] ap)
            => LAPACKE_dtfttp(layout, transr, uplo,
                n, arf, ap);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dtfttp_work(Layout layout, TransChar transr, UpLo uplo,
            int n, double[] arf, double[] ap);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dtfttp_work(Layout layout, TransChar transr, UpLo uplo,
            int n, double[] arf, double[] ap)
            => LAPACKE_dtfttp_work(layout, transr, uplo,
                n, arf, ap);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dtfttr(Layout layout, TransChar transr, UpLo uplo,
            int n, double[] arf, double[] a,
            int lda);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dtfttr(Layout layout, TransChar transr, UpLo uplo,
            int n, double[] arf, double[] a,
            int lda)
            => LAPACKE_dtfttr(layout, transr, uplo,
                n, arf, a,
                lda);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dtfttr_work(Layout layout, TransChar transr, UpLo uplo,
            int n, double[] arf, double[] a,
            int lda);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dtfttr_work(Layout layout, TransChar transr, UpLo uplo,
            int n, double[] arf, double[] a,
            int lda)
            => LAPACKE_dtfttr_work(layout, transr, uplo,
                n, arf, a,
                lda);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dtgevc(Layout layout, char side, char howmny,
            int[] select, int n,
            double[] s, int lds, double[] p,
            int ldp, double[] vl, int ldvl,
            double[] vr, int ldvr, int mm,
            int[] m);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dtgevc(Layout layout, char side, char howmny,
            int[] select, int n,
            double[] s, int lds, double[] p,
            int ldp, double[] vl, int ldvl,
            double[] vr, int ldvr, int mm,
            int[] m)
            => LAPACKE_dtgevc(layout, side, howmny,
                select, n,
                s, lds, p,
                ldp, vl, ldvl,
                vr, ldvr, mm,
                m);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dtgevc_work(Layout layout, char side, char howmny,
            int[] select, int n,
            double[] s, int lds,
            double[] p, int ldp, double[] vl,
            int ldvl, double[] vr, int ldvr,
            int mm, int[] m, double[] work);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dtgevc_work(Layout layout, char side, char howmny,
            int[] select, int n,
            double[] s, int lds,
            double[] p, int ldp, double[] vl,
            int ldvl, double[] vr, int ldvr,
            int mm, int[] m, double[] work)
            => LAPACKE_dtgevc_work(layout, side, howmny,
                select, n,
                s, lds,
                p, ldp, vl,
                ldvl, vr, ldvr,
                mm, m, work);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dtgexc(Layout layout, int wantq,
            int wantz, int n, double[] a,
            int lda, double[] b, int ldb, double[] q,
            int ldq, double[] z, int ldz,
            int[] ifst, int[] ilst);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dtgexc(Layout layout, int wantq,
            int wantz, int n, double[] a,
            int lda, double[] b, int ldb, double[] q,
            int ldq, double[] z, int ldz,
            int[] ifst, int[] ilst)
            => LAPACKE_dtgexc(layout, wantq,
                wantz, n, a,
                lda, b, ldb, q,
                ldq, z, ldz,
                ifst, ilst);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dtgexc_work(Layout layout, int wantq,
            int wantz, int n, double[] a,
            int lda, double[] b, int ldb,
            double[] q, int ldq, double[] z,
            int ldz, int[] ifst,
            int[] ilst, double[] work,
            int lwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dtgexc_work(Layout layout, int wantq,
            int wantz, int n, double[] a,
            int lda, double[] b, int ldb,
            double[] q, int ldq, double[] z,
            int ldz, int[] ifst,
            int[] ilst, double[] work,
            int lwork)
            => LAPACKE_dtgexc_work(layout, wantq,
                wantz, n, a,
                lda, b, ldb,
                q, ldq, z,
                ldz, ifst,
                ilst, work,
                lwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dtgsen(Layout layout, int ijob,
            int wantq, int wantz,
            int[] select, int n,
            double[] a, int lda, double[] b, int ldb,
            double[] alphar, double[] alphai, double[] beta,
            double[] q, int ldq, double[] z, int ldz,
            int[] m, double[] pl, double[] pr, double[] dif);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dtgsen(Layout layout, int ijob,
            int wantq, int wantz,
            int[] select, int n,
            double[] a, int lda, double[] b, int ldb,
            double[] alphar, double[] alphai, double[] beta,
            double[] q, int ldq, double[] z, int ldz,
            int[] m, double[] pl, double[] pr, double[] dif)
            => LAPACKE_dtgsen(layout, ijob,
                wantq, wantz,
                select, n,
                a, lda, b, ldb,
                alphar, alphai, beta,
                q, ldq, z, ldz,
                m, pl, pr, dif);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dtgsen_work(Layout layout, int ijob,
            int wantq, int wantz,
            int[] select, int n,
            double[] a, int lda, double[] b,
            int ldb, double[] alphar, double[] alphai,
            double[] beta, double[] q, int ldq,
            double[] z, int ldz, int[] m,
            double[] pl, double[] pr, double[] dif,
            double[] work, int lwork,
            int[] iwork, int liwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dtgsen_work(Layout layout, int ijob,
            int wantq, int wantz,
            int[] select, int n,
            double[] a, int lda, double[] b,
            int ldb, double[] alphar, double[] alphai,
            double[] beta, double[] q, int ldq,
            double[] z, int ldz, int[] m,
            double[] pl, double[] pr, double[] dif,
            double[] work, int lwork,
            int[] iwork, int liwork)
            => LAPACKE_dtgsen_work(layout, ijob,
                wantq, wantz,
                select, n,
                a, lda, b,
                ldb, alphar, alphai,
                beta, q, ldq,
                z, ldz, m,
                pl, pr, dif,
                work, lwork,
                iwork, liwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dtgsja(Layout layout, char jobu, char jobv, char jobq,
            int m, int p, int n,
            int k, int l, double[] a,
            int lda, double[] b, int ldb,
            double tola, double tolb, double[] alpha,
            double[] beta, double[] u, int ldu, double[] v,
            int ldv, double[] q, int ldq,
            int[] ncycle);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dtgsja(Layout layout, char jobu, char jobv, char jobq,
            int m, int p, int n,
            int k, int l, double[] a,
            int lda, double[] b, int ldb,
            double tola, double tolb, double[] alpha,
            double[] beta, double[] u, int ldu, double[] v,
            int ldv, double[] q, int ldq,
            int[] ncycle)
            => LAPACKE_dtgsja(layout, jobu, jobv, jobq,
                m, p, n,
                k, l, a,
                lda, b, ldb,
                tola, tolb, alpha,
                beta, u, ldu, v,
                ldv, q, ldq,
                ncycle);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dtgsja_work(Layout layout, char jobu, char jobv,
            char jobq, int m, int p,
            int n, int k, int l,
            double[] a, int lda, double[] b,
            int ldb, double tola, double tolb,
            double[] alpha, double[] beta, double[] u,
            int ldu, double[] v, int ldv,
            double[] q, int ldq, double[] work,
            int[] ncycle);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dtgsja_work(Layout layout, char jobu, char jobv,
            char jobq, int m, int p,
            int n, int k, int l,
            double[] a, int lda, double[] b,
            int ldb, double tola, double tolb,
            double[] alpha, double[] beta, double[] u,
            int ldu, double[] v, int ldv,
            double[] q, int ldq, double[] work,
            int[] ncycle)
            => LAPACKE_dtgsja_work(layout, jobu, jobv,
                jobq, m, p,
                n, k, l,
                a, lda, b,
                ldb, tola, tolb,
                alpha, beta, u,
                ldu, v, ldv,
                q, ldq, work,
                ncycle);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dtgsna(Layout layout, char job, char howmny,
            int[] select, int n,
            double[] a, int lda, double[] b,
            int ldb, double[] vl, int ldvl,
            double[] vr, int ldvr, double[] s,
            double[] dif, int mm, int[] m);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dtgsna(Layout layout, char job, char howmny,
            int[] select, int n,
            double[] a, int lda, double[] b,
            int ldb, double[] vl, int ldvl,
            double[] vr, int ldvr, double[] s,
            double[] dif, int mm, int[] m)
            => LAPACKE_dtgsna(layout, job, howmny,
                select, n,
                a, lda, b,
                ldb, vl, ldvl,
                vr, ldvr, s,
                dif, mm, m);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dtgsna_work(Layout layout, char job, char howmny,
            int[] select, int n,
            double[] a, int lda,
            double[] b, int ldb,
            double[] vl, int ldvl,
            double[] vr, int ldvr, double[] s,
            double[] dif, int mm, int[] m,
            double[] work, int lwork,
            int[] iwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dtgsna_work(Layout layout, char job, char howmny,
            int[] select, int n,
            double[] a, int lda,
            double[] b, int ldb,
            double[] vl, int ldvl,
            double[] vr, int ldvr, double[] s,
            double[] dif, int mm, int[] m,
            double[] work, int lwork,
            int[] iwork)
            => LAPACKE_dtgsna_work(layout, job, howmny,
                select, n,
                a, lda,
                b, ldb,
                vl, ldvl,
                vr, ldvr, s,
                dif, mm, m,
                work, lwork,
                iwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dtgsyl(Layout layout, TransChar trans, int ijob,
            int m, int n, double[] a,
            int lda, double[] b, int ldb,
            double[] c, int ldc, double[] d,
            int ldd, double[] e, int lde,
            double[] f, int ldf, double[] scale,
            double[] dif);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dtgsyl(Layout layout, TransChar trans, int ijob,
            int m, int n, double[] a,
            int lda, double[] b, int ldb,
            double[] c, int ldc, double[] d,
            int ldd, double[] e, int lde,
            double[] f, int ldf, double[] scale,
            double[] dif)
            => LAPACKE_dtgsyl(layout, trans, ijob,
                m, n, a,
                lda, b, ldb,
                c, ldc, d,
                ldd, e, lde,
                f, ldf, scale,
                dif);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dtgsyl_work(Layout layout, TransChar trans, int ijob,
            int m, int n, double[] a,
            int lda, double[] b, int ldb,
            double[] c, int ldc, double[] d,
            int ldd, double[] e, int lde,
            double[] f, int ldf, double[] scale,
            double[] dif, double[] work, int lwork,
            int[] iwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dtgsyl_work(Layout layout, TransChar trans, int ijob,
            int m, int n, double[] a,
            int lda, double[] b, int ldb,
            double[] c, int ldc, double[] d,
            int ldd, double[] e, int lde,
            double[] f, int ldf, double[] scale,
            double[] dif, double[] work, int lwork,
            int[] iwork)
            => LAPACKE_dtgsyl_work(layout, trans, ijob,
                m, n, a,
                lda, b, ldb,
                c, ldc, d,
                ldd, e, lde,
                f, ldf, scale,
                dif, work, lwork,
                iwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dtpcon(Layout layout, Norm norm, UpLo uplo, DiagChar diag,
            int n, double[] ap, double[] rcond);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dtpcon(Layout layout, Norm norm, UpLo uplo, DiagChar diag,
            int n, double[] ap, double[] rcond)
            => LAPACKE_dtpcon(layout, norm, uplo, diag,
                n, ap, rcond);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dtpcon_work(Layout layout, Norm norm, UpLo uplo,
            DiagChar diag, int n, double[] ap,
            double[] rcond, double[] work, int[] iwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dtpcon_work(Layout layout, Norm norm, UpLo uplo,
            DiagChar diag, int n, double[] ap,
            double[] rcond, double[] work, int[] iwork)
            => LAPACKE_dtpcon_work(layout, norm, uplo,
                diag, n, ap,
                rcond, work, iwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dtpmqrt(Layout layout, char side, TransChar trans,
            int m, int n, int k,
            int l, int nb, double[] v,
            int ldv, double[] t, int ldt,
            double[] a, int lda, double[] b,
            int ldb);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dtpmqrt(Layout layout, char side, TransChar trans,
            int m, int n, int k,
            int l, int nb, double[] v,
            int ldv, double[] t, int ldt,
            double[] a, int lda, double[] b,
            int ldb)
            => LAPACKE_dtpmqrt(layout, side, trans,
                m, n, k,
                l, nb, v,
                ldv, t, ldt,
                a, lda, b,
                ldb);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dtpmqrt_work(Layout layout, char side, TransChar trans,
            int m, int n, int k,
            int l, int nb, double[] v,
            int ldv, double[] t,
            int ldt, double[] a, int lda,
            double[] b, int ldb, double[] work);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dtpmqrt_work(Layout layout, char side, TransChar trans,
            int m, int n, int k,
            int l, int nb, double[] v,
            int ldv, double[] t,
            int ldt, double[] a, int lda,
            double[] b, int ldb, double[] work)
            => LAPACKE_dtpmqrt_work(layout, side, trans,
                m, n, k,
                l, nb, v,
                ldv, t,
                ldt, a, lda,
                b, ldb, work);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dtpqrt(Layout layout, int m, int n,
            int l, int nb, double[] a,
            int lda, double[] b, int ldb, double[] t,
            int ldt);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dtpqrt(Layout layout, int m, int n,
            int l, int nb, double[] a,
            int lda, double[] b, int ldb, double[] t,
            int ldt)
            => LAPACKE_dtpqrt(layout, m, n,
                l, nb, a,
                lda, b, ldb, t,
                ldt);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dtpqrt2(Layout layout, int m, int n,
            int l, double[] a, int lda, double[] b,
            int ldb, double[] t, int ldt);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dtpqrt2(Layout layout, int m, int n,
            int l, double[] a, int lda, double[] b,
            int ldb, double[] t, int ldt)
            => LAPACKE_dtpqrt2(layout, m, n,
                l, a, lda, b,
                ldb, t, ldt);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dtpqrt2_work(Layout layout, int m, int n,
            int l, double[] a, int lda, double[] b,
            int ldb, double[] t, int ldt);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dtpqrt2_work(Layout layout, int m, int n,
            int l, double[] a, int lda, double[] b,
            int ldb, double[] t, int ldt)
            => LAPACKE_dtpqrt2_work(layout, m, n,
                l, a, lda, b,
                ldb, t, ldt);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dtpqrt_work(Layout layout, int m, int n,
            int l, int nb, double[] a,
            int lda, double[] b, int ldb,
            double[] t, int ldt, double[] work);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dtpqrt_work(Layout layout, int m, int n,
            int l, int nb, double[] a,
            int lda, double[] b, int ldb,
            double[] t, int ldt, double[] work)
            => LAPACKE_dtpqrt_work(layout, m, n,
                l, nb, a,
                lda, b, ldb,
                t, ldt, work);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dtprfb(Layout layout, char side, TransChar trans, char direct,
            char storev, int m, int n,
            int k, int l, double[] v,
            int ldv, double[] t, int ldt,
            double[] a, int lda, double[] b, int ldb);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dtprfb(Layout layout, char side, TransChar trans, char direct,
            char storev, int m, int n,
            int k, int l, double[] v,
            int ldv, double[] t, int ldt,
            double[] a, int lda, double[] b, int ldb)
            => LAPACKE_dtprfb(layout, side, trans, direct,
                storev, m, n,
                k, l, v,
                ldv, t, ldt,
                a, lda, b, ldb);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dtprfb_work(Layout layout, char side, TransChar trans,
            char direct, char storev, int m,
            int n, int k, int l,
            double[] v, int ldv,
            double[] t, int ldt, double[] a,
            int lda, double[] b, int ldb,
            double[] work, int ldwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dtprfb_work(Layout layout, char side, TransChar trans,
            char direct, char storev, int m,
            int n, int k, int l,
            double[] v, int ldv,
            double[] t, int ldt, double[] a,
            int lda, double[] b, int ldb,
            double[] work, int ldwork)
            => LAPACKE_dtprfb_work(layout, side, trans,
                direct, storev, m,
                n, k, l,
                v, ldv,
                t, ldt, a,
                lda, b, ldb,
                work, ldwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dtprfs(Layout layout, UpLo uplo, TransChar trans, DiagChar diag,
            int n, int nrhs, double[] ap,
            double[] b, int ldb, double[] x,
            int ldx, double[] ferr, double[] berr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dtprfs(Layout layout, UpLo uplo, TransChar trans, DiagChar diag,
            int n, int nrhs, double[] ap,
            double[] b, int ldb, double[] x,
            int ldx, double[] ferr, double[] berr)
            => LAPACKE_dtprfs(layout, uplo, trans, diag,
                n, nrhs, ap,
                b, ldb, x,
                ldx, ferr, berr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dtprfs_work(Layout layout, UpLo uplo, TransChar trans,
            DiagChar diag, int n, int nrhs,
            double[] ap, double[] b,
            int ldb, double[] x, int ldx,
            double[] ferr, double[] berr, double[] work,
            int[] iwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dtprfs_work(Layout layout, UpLo uplo, TransChar trans,
            DiagChar diag, int n, int nrhs,
            double[] ap, double[] b,
            int ldb, double[] x, int ldx,
            double[] ferr, double[] berr, double[] work,
            int[] iwork)
            => LAPACKE_dtprfs_work(layout, uplo, trans,
                diag, n, nrhs,
                ap, b,
                ldb, x, ldx,
                ferr, berr, work,
                iwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dtptri(Layout layout, UpLo uplo, DiagChar diag, int n,
            double[] ap);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dtptri(Layout layout, UpLo uplo, DiagChar diag, int n,
            double[] ap)
            => LAPACKE_dtptri(layout, uplo, diag, n,
                ap);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dtptri_work(Layout layout, UpLo uplo, DiagChar diag,
            int n, double[] ap);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dtptri_work(Layout layout, UpLo uplo, DiagChar diag,
            int n, double[] ap)
            => LAPACKE_dtptri_work(layout, uplo, diag,
                n, ap);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dtptrs(Layout layout, UpLo uplo, TransChar trans, DiagChar diag,
            int n, int nrhs, double[] ap,
            double[] b, int ldb);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dtptrs(Layout layout, UpLo uplo, TransChar trans, DiagChar diag,
            int n, int nrhs, double[] ap,
            double[] b, int ldb)
            => LAPACKE_dtptrs(layout, uplo, trans, diag,
                n, nrhs, ap,
                b, ldb);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dtptrs_work(Layout layout, UpLo uplo, TransChar trans,
            DiagChar diag, int n, int nrhs,
            double[] ap, double[] b, int ldb);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dtptrs_work(Layout layout, UpLo uplo, TransChar trans,
            DiagChar diag, int n, int nrhs,
            double[] ap, double[] b, int ldb)
            => LAPACKE_dtptrs_work(layout, uplo, trans,
                diag, n, nrhs,
                ap, b, ldb);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dtpttf(Layout layout, TransChar transr, UpLo uplo,
            int n, double[] ap, double[] arf);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dtpttf(Layout layout, TransChar transr, UpLo uplo,
            int n, double[] ap, double[] arf)
            => LAPACKE_dtpttf(layout, transr, uplo,
                n, ap, arf);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dtpttf_work(Layout layout, TransChar transr, UpLo uplo,
            int n, double[] ap, double[] arf);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dtpttf_work(Layout layout, TransChar transr, UpLo uplo,
            int n, double[] ap, double[] arf)
            => LAPACKE_dtpttf_work(layout, transr, uplo,
                n, ap, arf);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dtpttr(Layout layout, UpLo uplo, int n,
            double[] ap, double[] a, int lda);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dtpttr(Layout layout, UpLo uplo, int n,
            double[] ap, double[] a, int lda)
            => LAPACKE_dtpttr(layout, uplo, n,
                ap, a, lda);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dtpttr_work(Layout layout, UpLo uplo, int n,
            double[] ap, double[] a, int lda);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dtpttr_work(Layout layout, UpLo uplo, int n,
            double[] ap, double[] a, int lda)
            => LAPACKE_dtpttr_work(layout, uplo, n,
                ap, a, lda);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dtrcon(Layout layout, Norm norm, UpLo uplo, DiagChar diag,
            int n, double[] a, int lda,
            double[] rcond);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dtrcon(Layout layout, Norm norm, UpLo uplo, DiagChar diag,
            int n, double[] a, int lda,
            double[] rcond)
            => LAPACKE_dtrcon(layout, norm, uplo, diag,
                n, a, lda,
                rcond);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dtrcon_work(Layout layout, Norm norm, UpLo uplo,
            DiagChar diag, int n, double[] a,
            int lda, double[] rcond, double[] work,
            int[] iwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dtrcon_work(Layout layout, Norm norm, UpLo uplo,
            DiagChar diag, int n, double[] a,
            int lda, double[] rcond, double[] work,
            int[] iwork)
            => LAPACKE_dtrcon_work(layout, norm, uplo,
                diag, n, a,
                lda, rcond, work,
                iwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dtrevc(Layout layout, char side, char howmny,
            int[] select, int n,
            double[] t, int ldt, double[] vl,
            int ldvl, double[] vr, int ldvr,
            int mm, int[] m);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dtrevc(Layout layout, char side, char howmny,
            int[] select, int n,
            double[] t, int ldt, double[] vl,
            int ldvl, double[] vr, int ldvr,
            int mm, int[] m)
            => LAPACKE_dtrevc(layout, side, howmny,
                select, n,
                t, ldt, vl,
                ldvl, vr, ldvr,
                mm, m);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dtrevc_work(Layout layout, char side, char howmny,
            int[] select, int n,
            double[] t, int ldt, double[] vl,
            int ldvl, double[] vr, int ldvr,
            int mm, int[] m, double[] work);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dtrevc_work(Layout layout, char side, char howmny,
            int[] select, int n,
            double[] t, int ldt, double[] vl,
            int ldvl, double[] vr, int ldvr,
            int mm, int[] m, double[] work)
            => LAPACKE_dtrevc_work(layout, side, howmny,
                select, n,
                t, ldt, vl,
                ldvl, vr, ldvr,
                mm, m, work);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dtrexc(Layout layout, char compq, int n,
            double[] t, int ldt, double[] q, int ldq,
            int[] ifst, int[] ilst);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dtrexc(Layout layout, char compq, int n,
            double[] t, int ldt, double[] q, int ldq,
            int[] ifst, int[] ilst)
            => LAPACKE_dtrexc(layout, compq, n,
                t, ldt, q, ldq,
                ifst, ilst);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dtrexc_work(Layout layout, char compq, int n,
            double[] t, int ldt, double[] q,
            int ldq, int[] ifst,
            int[] ilst, double[] work);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dtrexc_work(Layout layout, char compq, int n,
            double[] t, int ldt, double[] q,
            int ldq, int[] ifst,
            int[] ilst, double[] work)
            => LAPACKE_dtrexc_work(layout, compq, n,
                t, ldt, q,
                ldq, ifst,
                ilst, work);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dtrrfs(Layout layout, UpLo uplo, TransChar trans, DiagChar diag,
            int n, int nrhs, double[] a,
            int lda, double[] b, int ldb,
            double[] x, int ldx, double[] ferr,
            double[] berr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dtrrfs(Layout layout, UpLo uplo, TransChar trans, DiagChar diag,
            int n, int nrhs, double[] a,
            int lda, double[] b, int ldb,
            double[] x, int ldx, double[] ferr,
            double[] berr)
            => LAPACKE_dtrrfs(layout, uplo, trans, diag,
                n, nrhs, a,
                lda, b, ldb,
                x, ldx, ferr,
                berr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dtrrfs_work(Layout layout, UpLo uplo, TransChar trans,
            DiagChar diag, int n, int nrhs,
            double[] a, int lda,
            double[] b, int ldb,
            double[] x, int ldx, double[] ferr,
            double[] berr, double[] work, int[] iwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dtrrfs_work(Layout layout, UpLo uplo, TransChar trans,
            DiagChar diag, int n, int nrhs,
            double[] a, int lda,
            double[] b, int ldb,
            double[] x, int ldx, double[] ferr,
            double[] berr, double[] work, int[] iwork)
            => LAPACKE_dtrrfs_work(layout, uplo, trans,
                diag, n, nrhs,
                a, lda,
                b, ldb,
                x, ldx, ferr,
                berr, work, iwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dtrsen(Layout layout, char job, char compq,
            int[] select, int n,
            double[] t, int ldt, double[] q, int ldq,
            double[] wr, double[] wi, int[] m, double[] s,
            double[] sep);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dtrsen(Layout layout, char job, char compq,
            int[] select, int n,
            double[] t, int ldt, double[] q, int ldq,
            double[] wr, double[] wi, int[] m, double[] s,
            double[] sep)
            => LAPACKE_dtrsen(layout, job, compq,
                select, n,
                t, ldt, q, ldq,
                wr, wi, m, s,
                sep);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dtrsen_work(Layout layout, char job, char compq,
            int[] select, int n,
            double[] t, int ldt, double[] q,
            int ldq, double[] wr, double[] wi,
            int[] m, double[] s, double[] sep,
            double[] work, int lwork,
            int[] iwork, int liwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dtrsen_work(Layout layout, char job, char compq,
            int[] select, int n,
            double[] t, int ldt, double[] q,
            int ldq, double[] wr, double[] wi,
            int[] m, double[] s, double[] sep,
            double[] work, int lwork,
            int[] iwork, int liwork)
            => LAPACKE_dtrsen_work(layout, job, compq,
                select, n,
                t, ldt, q,
                ldq, wr, wi,
                m, s, sep,
                work, lwork,
                iwork, liwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dtrsna(Layout layout, char job, char howmny,
            int[] select, int n,
            double[] t, int ldt, double[] vl,
            int ldvl, double[] vr, int ldvr,
            double[] s, double[] sep, int mm,
            int[] m);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dtrsna(Layout layout, char job, char howmny,
            int[] select, int n,
            double[] t, int ldt, double[] vl,
            int ldvl, double[] vr, int ldvr,
            double[] s, double[] sep, int mm,
            int[] m)
            => LAPACKE_dtrsna(layout, job, howmny,
                select, n,
                t, ldt, vl,
                ldvl, vr, ldvr,
                s, sep, mm,
                m);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dtrsna_work(Layout layout, char job, char howmny,
            int[] select, int n,
            double[] t, int ldt,
            double[] vl, int ldvl,
            double[] vr, int ldvr, double[] s,
            double[] sep, int mm, int[] m,
            double[] work, int ldwork,
            int[] iwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dtrsna_work(Layout layout, char job, char howmny,
            int[] select, int n,
            double[] t, int ldt,
            double[] vl, int ldvl,
            double[] vr, int ldvr, double[] s,
            double[] sep, int mm, int[] m,
            double[] work, int ldwork,
            int[] iwork)
            => LAPACKE_dtrsna_work(layout, job, howmny,
                select, n,
                t, ldt,
                vl, ldvl,
                vr, ldvr, s,
                sep, mm, m,
                work, ldwork,
                iwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dtrsyl(Layout layout, char trana, char tranb,
            int isgn, int m, int n,
            double[] a, int lda, double[] b,
            int ldb, double[] c, int ldc,
            double[] scale);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dtrsyl(Layout layout, char trana, char tranb,
            int isgn, int m, int n,
            double[] a, int lda, double[] b,
            int ldb, double[] c, int ldc,
            double[] scale)
            => LAPACKE_dtrsyl(layout, trana, tranb,
                isgn, m, n,
                a, lda, b,
                ldb, c, ldc,
                scale);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dtrsyl_work(Layout layout, char trana, char tranb,
            int isgn, int m, int n,
            double[] a, int lda,
            double[] b, int ldb, double[] c,
            int ldc, double[] scale);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dtrsyl_work(Layout layout, char trana, char tranb,
            int isgn, int m, int n,
            double[] a, int lda,
            double[] b, int ldb, double[] c,
            int ldc, double[] scale)
            => LAPACKE_dtrsyl_work(layout, trana, tranb,
                isgn, m, n,
                a, lda,
                b, ldb, c,
                ldc, scale);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dtrtri(Layout layout, UpLo uplo, DiagChar diag, int n,
            double[] a, int lda);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dtrtri(Layout layout, UpLo uplo, DiagChar diag, int n,
            double[] a, int lda)
            => LAPACKE_dtrtri(layout, uplo, diag, n,
                a, lda);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dtrtri_work(Layout layout, UpLo uplo, DiagChar diag,
            int n, double[] a, int lda);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dtrtri_work(Layout layout, UpLo uplo, DiagChar diag,
            int n, double[] a, int lda)
            => LAPACKE_dtrtri_work(layout, uplo, diag,
                n, a, lda);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dtrtrs(Layout layout, UpLo uplo, TransChar trans, DiagChar diag,
            int n, int nrhs, double[] a,
            int lda, double[] b, int ldb);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dtrtrs(Layout layout, UpLo uplo, TransChar trans, DiagChar diag,
            int n, int nrhs, double[] a,
            int lda, double[] b, int ldb)
            => LAPACKE_dtrtrs(layout, uplo, trans, diag,
                n, nrhs, a,
                lda, b, ldb);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dtrtrs_work(Layout layout, UpLo uplo, TransChar trans,
            DiagChar diag, int n, int nrhs,
            double[] a, int lda, double[] b,
            int ldb);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dtrtrs_work(Layout layout, UpLo uplo, TransChar trans,
            DiagChar diag, int n, int nrhs,
            double[] a, int lda, double[] b,
            int ldb)
            => LAPACKE_dtrtrs_work(layout, uplo, trans,
                diag, n, nrhs,
                a, lda, b,
                ldb);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dtrttf(Layout layout, TransChar transr, UpLo uplo,
            int n, double[] a, int lda,
            double[] arf);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dtrttf(Layout layout, TransChar transr, UpLo uplo,
            int n, double[] a, int lda,
            double[] arf)
            => LAPACKE_dtrttf(layout, transr, uplo,
                n, a, lda,
                arf);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dtrttf_work(Layout layout, TransChar transr, UpLo uplo,
            int n, double[] a, int lda,
            double[] arf);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dtrttf_work(Layout layout, TransChar transr, UpLo uplo,
            int n, double[] a, int lda,
            double[] arf)
            => LAPACKE_dtrttf_work(layout, transr, uplo,
                n, a, lda,
                arf);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dtrttp(Layout layout, UpLo uplo, int n,
            double[] a, int lda, double[] ap);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dtrttp(Layout layout, UpLo uplo, int n,
            double[] a, int lda, double[] ap)
            => LAPACKE_dtrttp(layout, uplo, n,
                a, lda, ap);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dtrttp_work(Layout layout, UpLo uplo, int n,
            double[] a, int lda, double[] ap);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dtrttp_work(Layout layout, UpLo uplo, int n,
            double[] a, int lda, double[] ap)
            => LAPACKE_dtrttp_work(layout, uplo, n,
                a, lda, ap);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dtzrzf(Layout layout, int m, int n,
            double[] a, int lda, double[] tau);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dtzrzf(Layout layout, int m, int n,
            double[] a, int lda, double[] tau)
            => LAPACKE_dtzrzf(layout, m, n,
                a, lda, tau);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dtzrzf_work(Layout layout, int m, int n,
            double[] a, int lda, double[] tau,
            double[] work, int lwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dtzrzf_work(Layout layout, int m, int n,
            double[] a, int lda, double[] tau,
            double[] work, int lwork)
            => LAPACKE_dtzrzf_work(layout, m, n,
                a, lda, tau,
                work, lwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_mkl_dgetrfnpi(Layout layout, int m, int n,
            int nfact, double[] a, int lda);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int mkl_dgetrfnpi(Layout layout, int m, int n,
            int nfact, double[] a, int lda)
            => LAPACKE_mkl_dgetrfnpi(layout, m, n,
                nfact, a, lda);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_mkl_dgetrfnpi_work(Layout layout, int m, int n,
            int nfact, double[] a, int lda);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int mkl_dgetrfnpi_work(Layout layout, int m, int n,
            int nfact, double[] a, int lda)
            => LAPACKE_mkl_dgetrfnpi_work(layout, m, n,
                nfact, a, lda);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_mkl_dtppack(Layout layout, UpLo uplo, TransChar trans, int n,
            double[] ap, int i, int j, int rows,
            int cols, double[] a, int lda);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int mkl_dtppack(Layout layout, UpLo uplo, TransChar trans, int n,
            double[] ap, int i, int j, int rows,
            int cols, double[] a, int lda)
            => LAPACKE_mkl_dtppack(layout, uplo, trans, n,
                ap, i, j, rows,
                cols, a, lda);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_mkl_dtppack_work(Layout layout, UpLo uplo, TransChar trans, int n,
            double[] ap, int i, int j, int rows,
            int cols, double[] a, int lda);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int mkl_dtppack_work(Layout layout, UpLo uplo, TransChar trans, int n,
            double[] ap, int i, int j, int rows,
            int cols, double[] a, int lda)
            => LAPACKE_mkl_dtppack_work(layout, uplo, trans, n,
                ap, i, j, rows,
                cols, a, lda);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_mkl_dtpunpack(Layout layout, UpLo uplo, TransChar trans, int n,
            double[] ap, int i, int j, int rows,
            int cols, double[] a, int lda);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int mkl_dtpunpack(Layout layout, UpLo uplo, TransChar trans, int n,
            double[] ap, int i, int j, int rows,
            int cols, double[] a, int lda)
            => LAPACKE_mkl_dtpunpack(layout, uplo, trans, n,
                ap, i, j, rows,
                cols, a, lda);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_mkl_dtpunpack_work(Layout layout, UpLo uplo, TransChar trans, int n,
            double[] ap, int i, int j, int rows,
            int cols, double[] a, int lda);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int mkl_dtpunpack_work(Layout layout, UpLo uplo, TransChar trans, int n,
            double[] ap, int i, int j, int rows,
            int cols, double[] a, int lda)
            => LAPACKE_mkl_dtpunpack_work(layout, uplo, trans, n,
                ap, i, j, rows,
                cols, a, lda);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_mkl_sgetrfnpi(Layout layout, int m, int n,
            int nfact, float[] a, int lda);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int mkl_sgetrfnpi(Layout layout, int m, int n,
            int nfact, float[] a, int lda)
            => LAPACKE_mkl_sgetrfnpi(layout, m, n,
                nfact, a, lda);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_mkl_sgetrfnpi_work(Layout layout, int m, int n,
            int nfact, float[] a, int lda);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int mkl_sgetrfnpi_work(Layout layout, int m, int n,
            int nfact, float[] a, int lda)
            => LAPACKE_mkl_sgetrfnpi_work(layout, m, n,
                nfact, a, lda);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_mkl_stppack(Layout layout, UpLo uplo, TransChar trans, int n,
            float[] ap, int i, int j, int rows,
            int cols, float[] a, int lda);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int mkl_stppack(Layout layout, UpLo uplo, TransChar trans, int n,
            float[] ap, int i, int j, int rows,
            int cols, float[] a, int lda)
            => LAPACKE_mkl_stppack(layout, uplo, trans, n,
                ap, i, j, rows,
                cols, a, lda);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_mkl_stppack_work(Layout layout, UpLo uplo, TransChar trans, int n,
            float[] ap, int i, int j, int rows,
            int cols, float[] a, int lda);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int mkl_stppack_work(Layout layout, UpLo uplo, TransChar trans, int n,
            float[] ap, int i, int j, int rows,
            int cols, float[] a, int lda)
            => LAPACKE_mkl_stppack_work(layout, uplo, trans, n,
                ap, i, j, rows,
                cols, a, lda);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_mkl_stpunpack(Layout layout, UpLo uplo, TransChar trans, int n,
            float[] ap, int i, int j, int rows,
            int cols, float[] a, int lda);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int mkl_stpunpack(Layout layout, UpLo uplo, TransChar trans, int n,
            float[] ap, int i, int j, int rows,
            int cols, float[] a, int lda)
            => LAPACKE_mkl_stpunpack(layout, uplo, trans, n,
                ap, i, j, rows,
                cols, a, lda);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_mkl_stpunpack_work(Layout layout, UpLo uplo, TransChar trans, int n,
            float[] ap, int i, int j, int rows,
            int cols, float[] a, int lda);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int mkl_stpunpack_work(Layout layout, UpLo uplo, TransChar trans, int n,
            float[] ap, int i, int j, int rows,
            int cols, float[] a, int lda)
            => LAPACKE_mkl_stpunpack_work(layout, uplo, trans, n,
                ap, i, j, rows,
                cols, a, lda);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sbbcsd(Layout layout, char jobu1, char jobu2,
            char jobv1t, char jobv2t, TransChar trans, int m,
            int p, int q, float[] theta, float[] phi,
            float[] u1, int ldu1, float[] u2,
            int ldu2, float[] v1t, int ldv1t,
            float[] v2t, int ldv2t, float[] b11d,
            float[] b11e, float[] b12d, float[] b12e, float[] b21d,
            float[] b21e, float[] b22d, float[] b22e);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sbbcsd(Layout layout, char jobu1, char jobu2,
            char jobv1t, char jobv2t, TransChar trans, int m,
            int p, int q, float[] theta, float[] phi,
            float[] u1, int ldu1, float[] u2,
            int ldu2, float[] v1t, int ldv1t,
            float[] v2t, int ldv2t, float[] b11d,
            float[] b11e, float[] b12d, float[] b12e, float[] b21d,
            float[] b21e, float[] b22d, float[] b22e)
            => LAPACKE_sbbcsd(layout, jobu1, jobu2,
                jobv1t, jobv2t, trans, m,
                p, q, theta, phi,
                u1, ldu1, u2,
                ldu2, v1t, ldv1t,
                v2t, ldv2t, b11d,
                b11e, b12d, b12e, b21d,
                b21e, b22d, b22e);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sbbcsd_work(Layout layout, char jobu1, char jobu2,
            char jobv1t, char jobv2t, TransChar trans,
            int m, int p, int q,
            float[] theta, float[] phi, float[] u1,
            int ldu1, float[] u2, int ldu2,
            float[] v1t, int ldv1t, float[] v2t,
            int ldv2t, float[] b11d, float[] b11e,
            float[] b12d, float[] b12e, float[] b21d,
            float[] b21e, float[] b22d, float[] b22e,
            float[] work, int lwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sbbcsd_work(Layout layout, char jobu1, char jobu2,
            char jobv1t, char jobv2t, TransChar trans,
            int m, int p, int q,
            float[] theta, float[] phi, float[] u1,
            int ldu1, float[] u2, int ldu2,
            float[] v1t, int ldv1t, float[] v2t,
            int ldv2t, float[] b11d, float[] b11e,
            float[] b12d, float[] b12e, float[] b21d,
            float[] b21e, float[] b22d, float[] b22e,
            float[] work, int lwork)
            => LAPACKE_sbbcsd_work(layout, jobu1, jobu2,
                jobv1t, jobv2t, trans,
                m, p, q,
                theta, phi, u1,
                ldu1, u2, ldu2,
                v1t, ldv1t, v2t,
                ldv2t, b11d, b11e,
                b12d, b12e, b21d,
                b21e, b22d, b22e,
                work, lwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sbdsdc(Layout layout, UpLo uplo, char compq,
            int n, float[] d, float[] e, float[] u,
            int ldu, float[] vt, int ldvt, float[] q,
            int[] iq);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sbdsdc(Layout layout, UpLo uplo, char compq,
            int n, float[] d, float[] e, float[] u,
            int ldu, float[] vt, int ldvt, float[] q,
            int[] iq)
            => LAPACKE_sbdsdc(layout, uplo, compq,
                n, d, e, u,
                ldu, vt, ldvt, q,
                iq);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sbdsdc_work(Layout layout, UpLo uplo, char compq,
            int n, float[] d, float[] e, float[] u,
            int ldu, float[] vt, int ldvt,
            float[] q, int[] iq, float[] work,
            int[] iwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sbdsdc_work(Layout layout, UpLo uplo, char compq,
            int n, float[] d, float[] e, float[] u,
            int ldu, float[] vt, int ldvt,
            float[] q, int[] iq, float[] work,
            int[] iwork)
            => LAPACKE_sbdsdc_work(layout, uplo, compq,
                n, d, e, u,
                ldu, vt, ldvt,
                q, iq, work,
                iwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sbdsqr(Layout layout, UpLo uplo, int n,
            int ncvt, int nru, int ncc,
            float[] d, float[] e, float[] vt, int ldvt,
            float[] u, int ldu, float[] c, int ldc);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sbdsqr(Layout layout, UpLo uplo, int n,
            int ncvt, int nru, int ncc,
            float[] d, float[] e, float[] vt, int ldvt,
            float[] u, int ldu, float[] c, int ldc)
            => LAPACKE_sbdsqr(layout, uplo, n,
                ncvt, nru, ncc,
                d, e, vt, ldvt,
                u, ldu, c, ldc);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sbdsqr_work(Layout layout, UpLo uplo, int n,
            int ncvt, int nru, int ncc,
            float[] d, float[] e, float[] vt, int ldvt,
            float[] u, int ldu, float[] c,
            int ldc, float[] work);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sbdsqr_work(Layout layout, UpLo uplo, int n,
            int ncvt, int nru, int ncc,
            float[] d, float[] e, float[] vt, int ldvt,
            float[] u, int ldu, float[] c,
            int ldc, float[] work)
            => LAPACKE_sbdsqr_work(layout, uplo, n,
                ncvt, nru, ncc,
                d, e, vt, ldvt,
                u, ldu, c,
                ldc, work);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sbdsvdx(Layout layout, UpLo uplo, char jobz, char range,
            int n, float[] d, float[] e,
            float vl, float vu,
            int il, int iu, int[] ns,
            float[] s, float[] z, int ldz,
            int[] superb);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sbdsvdx(Layout layout, UpLo uplo, char jobz, char range,
            int n, float[] d, float[] e,
            float vl, float vu,
            int il, int iu, int[] ns,
            float[] s, float[] z, int ldz,
            int[] superb)
            => LAPACKE_sbdsvdx(layout, uplo, jobz, range,
                n, d, e,
                vl, vu,
                il, iu, ns,
                s, z, ldz,
                superb);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sbdsvdx_work(Layout layout, UpLo uplo, char jobz, char range,
            int n, float[] d, float[] e,
            float vl, float vu,
            int il, int iu, int[] ns,
            float[] s, float[] z, int ldz,
            float[] work, int[] iwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sbdsvdx_work(Layout layout, UpLo uplo, char jobz, char range,
            int n, float[] d, float[] e,
            float vl, float vu,
            int il, int iu, int[] ns,
            float[] s, float[] z, int ldz,
            float[] work, int[] iwork)
            => LAPACKE_sbdsvdx_work(layout, uplo, jobz, range,
                n, d, e,
                vl, vu,
                il, iu, ns,
                s, z, ldz,
                work, iwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sdisna(char job, int m, int n, float[] d,
            float[] sep);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sdisna(char job, int m, int n, float[] d,
            float[] sep)
            => LAPACKE_sdisna(job, m, n, d,
                sep);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sdisna_work(char job, int m, int n,
            float[] d, float[] sep);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sdisna_work(char job, int m, int n,
            float[] d, float[] sep)
            => LAPACKE_sdisna_work(job, m, n,
                d, sep);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgbbrd(Layout layout, char vect, int m,
            int n, int ncc, int kl,
            int ku, float[] ab, int ldab, float[] d,
            float[] e, float[] q, int ldq, float[] pt,
            int ldpt, float[] c, int ldc);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sgbbrd(Layout layout, char vect, int m,
            int n, int ncc, int kl,
            int ku, float[] ab, int ldab, float[] d,
            float[] e, float[] q, int ldq, float[] pt,
            int ldpt, float[] c, int ldc)
            => LAPACKE_sgbbrd(layout, vect, m,
                n, ncc, kl,
                ku, ab, ldab, d,
                e, q, ldq, pt,
                ldpt, c, ldc);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgbbrd_work(Layout layout, char vect, int m,
            int n, int ncc, int kl,
            int ku, float[] ab, int ldab,
            float[] d, float[] e, float[] q, int ldq,
            float[] pt, int ldpt, float[] c,
            int ldc, float[] work);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sgbbrd_work(Layout layout, char vect, int m,
            int n, int ncc, int kl,
            int ku, float[] ab, int ldab,
            float[] d, float[] e, float[] q, int ldq,
            float[] pt, int ldpt, float[] c,
            int ldc, float[] work)
            => LAPACKE_sgbbrd_work(layout, vect, m,
                n, ncc, kl,
                ku, ab, ldab,
                d, e, q, ldq,
                pt, ldpt, c,
                ldc, work);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgbcon(Layout layout, Norm norm, int n,
            int kl, int ku, float[] ab,
            int ldab, int[] ipiv, float anorm,
            float[] rcond);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sgbcon(Layout layout, Norm norm, int n,
            int kl, int ku, float[] ab,
            int ldab, int[] ipiv, float anorm,
            float[] rcond)
            => LAPACKE_sgbcon(layout, norm, n,
                kl, ku, ab,
                ldab, ipiv, anorm,
                rcond);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgbcon_work(Layout layout, Norm norm, int n,
            int kl, int ku, float[] ab,
            int ldab, int[] ipiv,
            float anorm, float[] rcond, float[] work,
            int[] iwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sgbcon_work(Layout layout, Norm norm, int n,
            int kl, int ku, float[] ab,
            int ldab, int[] ipiv,
            float anorm, float[] rcond, float[] work,
            int[] iwork)
            => LAPACKE_sgbcon_work(layout, norm, n,
                kl, ku, ab,
                ldab, ipiv,
                anorm, rcond, work,
                iwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgbequ(Layout layout, int m, int n,
            int kl, int ku, float[] ab,
            int ldab, float[] r, float[] c, float[] rowcnd,
            float[] colcnd, float[] amax);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sgbequ(Layout layout, int m, int n,
            int kl, int ku, float[] ab,
            int ldab, float[] r, float[] c, float[] rowcnd,
            float[] colcnd, float[] amax)
            => LAPACKE_sgbequ(layout, m, n,
                kl, ku, ab,
                ldab, r, c, rowcnd,
                colcnd, amax);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgbequ_work(Layout layout, int m, int n,
            int kl, int ku, float[] ab,
            int ldab, float[] r, float[] c,
            float[] rowcnd, float[] colcnd, float[] amax);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sgbequ_work(Layout layout, int m, int n,
            int kl, int ku, float[] ab,
            int ldab, float[] r, float[] c,
            float[] rowcnd, float[] colcnd, float[] amax)
            => LAPACKE_sgbequ_work(layout, m, n,
                kl, ku, ab,
                ldab, r, c,
                rowcnd, colcnd, amax);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgbequb(Layout layout, int m, int n,
            int kl, int ku, float[] ab,
            int ldab, float[] r, float[] c, float[] rowcnd,
            float[] colcnd, float[] amax);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sgbequb(Layout layout, int m, int n,
            int kl, int ku, float[] ab,
            int ldab, float[] r, float[] c, float[] rowcnd,
            float[] colcnd, float[] amax)
            => LAPACKE_sgbequb(layout, m, n,
                kl, ku, ab,
                ldab, r, c, rowcnd,
                colcnd, amax);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgbequb_work(Layout layout, int m, int n,
            int kl, int ku, float[] ab,
            int ldab, float[] r, float[] c,
            float[] rowcnd, float[] colcnd, float[] amax);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sgbequb_work(Layout layout, int m, int n,
            int kl, int ku, float[] ab,
            int ldab, float[] r, float[] c,
            float[] rowcnd, float[] colcnd, float[] amax)
            => LAPACKE_sgbequb_work(layout, m, n,
                kl, ku, ab,
                ldab, r, c,
                rowcnd, colcnd, amax);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgbrfs(Layout layout, TransChar trans, int n,
            int kl, int ku, int nrhs,
            float[] ab, int ldab, float[] afb,
            int ldafb, int[] ipiv,
            float[] b, int ldb, float[] x,
            int ldx, float[] ferr, float[] berr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sgbrfs(Layout layout, TransChar trans, int n,
            int kl, int ku, int nrhs,
            float[] ab, int ldab, float[] afb,
            int ldafb, int[] ipiv,
            float[] b, int ldb, float[] x,
            int ldx, float[] ferr, float[] berr)
            => LAPACKE_sgbrfs(layout, trans, n,
                kl, ku, nrhs,
                ab, ldab, afb,
                ldafb, ipiv,
                b, ldb, x,
                ldx, ferr, berr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgbrfs_work(Layout layout, TransChar trans, int n,
            int kl, int ku, int nrhs,
            float[] ab, int ldab,
            float[] afb, int ldafb,
            int[] ipiv, float[] b,
            int ldb, float[] x, int ldx,
            float[] ferr, float[] berr, float[] work,
            int[] iwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sgbrfs_work(Layout layout, TransChar trans, int n,
            int kl, int ku, int nrhs,
            float[] ab, int ldab,
            float[] afb, int ldafb,
            int[] ipiv, float[] b,
            int ldb, float[] x, int ldx,
            float[] ferr, float[] berr, float[] work,
            int[] iwork)
            => LAPACKE_sgbrfs_work(layout, trans, n,
                kl, ku, nrhs,
                ab, ldab,
                afb, ldafb,
                ipiv, b,
                ldb, x, ldx,
                ferr, berr, work,
                iwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgbrfsx(Layout layout, TransChar trans, char equed,
            int n, int kl, int ku,
            int nrhs, float[] ab, int ldab,
            float[] afb, int ldafb,
            int[] ipiv, float[] r,
            float[] c, float[] b, int ldb,
            float[] x, int ldx, float[] rcond, float[] berr,
            int n_err_bnds, float[] err_bnds_norm,
            float[] err_bnds_comp, int nparams,
            float[] aparams);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sgbrfsx(Layout layout, TransChar trans, char equed,
            int n, int kl, int ku,
            int nrhs, float[] ab, int ldab,
            float[] afb, int ldafb,
            int[] ipiv, float[] r,
            float[] c, float[] b, int ldb,
            float[] x, int ldx, float[] rcond, float[] berr,
            int n_err_bnds, float[] err_bnds_norm,
            float[] err_bnds_comp, int nparams,
            float[] aparams)
            => LAPACKE_sgbrfsx(layout, trans, equed,
                n, kl, ku,
                nrhs, ab, ldab,
                afb, ldafb,
                ipiv, r,
                c, b, ldb,
                x, ldx, rcond, berr,
                n_err_bnds, err_bnds_norm,
                err_bnds_comp, nparams,
                aparams);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgbrfsx_work(Layout layout, TransChar trans, char equed,
            int n, int kl, int ku,
            int nrhs, float[] ab,
            int ldab, float[] afb,
            int ldafb, int[] ipiv,
            float[] r, float[] c, float[] b,
            int ldb, float[] x, int ldx,
            float[] rcond, float[] berr,
            int n_err_bnds, float[] err_bnds_norm,
            float[] err_bnds_comp, int nparams,
            float[] aparams, float[] work, int[] iwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sgbrfsx_work(Layout layout, TransChar trans, char equed,
            int n, int kl, int ku,
            int nrhs, float[] ab,
            int ldab, float[] afb,
            int ldafb, int[] ipiv,
            float[] r, float[] c, float[] b,
            int ldb, float[] x, int ldx,
            float[] rcond, float[] berr,
            int n_err_bnds, float[] err_bnds_norm,
            float[] err_bnds_comp, int nparams,
            float[] aparams, float[] work, int[] iwork)
            => LAPACKE_sgbrfsx_work(layout, trans, equed,
                n, kl, ku,
                nrhs, ab,
                ldab, afb,
                ldafb, ipiv,
                r, c, b,
                ldb, x, ldx,
                rcond, berr,
                n_err_bnds, err_bnds_norm,
                err_bnds_comp, nparams,
                aparams, work, iwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgbsv(Layout layout, int n, int kl,
            int ku, int nrhs, float[] ab,
            int ldab, int[] ipiv, float[] b,
            int ldb);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sgbsv(Layout layout, int n, int kl,
            int ku, int nrhs, float[] ab,
            int ldab, int[] ipiv, float[] b,
            int ldb)
            => LAPACKE_sgbsv(layout, n, kl,
                ku, nrhs, ab,
                ldab, ipiv, b,
                ldb);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgbsv_work(Layout layout, int n, int kl,
            int ku, int nrhs, float[] ab,
            int ldab, int[] ipiv, float[] b,
            int ldb);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sgbsv_work(Layout layout, int n, int kl,
            int ku, int nrhs, float[] ab,
            int ldab, int[] ipiv, float[] b,
            int ldb)
            => LAPACKE_sgbsv_work(layout, n, kl,
                ku, nrhs, ab,
                ldab, ipiv, b,
                ldb);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgbsvx(Layout layout, char fact, TransChar trans,
            int n, int kl, int ku,
            int nrhs, float[] ab, int ldab,
            float[] afb, int ldafb, int[] ipiv,
            char[] equed, float[] r, float[] c, float[] b,
            int ldb, float[] x, int ldx,
            float[] rcond, float[] ferr, float[] berr,
            float[] rpivot);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sgbsvx(Layout layout, char fact, TransChar trans,
            int n, int kl, int ku,
            int nrhs, float[] ab, int ldab,
            float[] afb, int ldafb, int[] ipiv,
            char[] equed, float[] r, float[] c, float[] b,
            int ldb, float[] x, int ldx,
            float[] rcond, float[] ferr, float[] berr,
            float[] rpivot)
            => LAPACKE_sgbsvx(layout, fact, trans,
                n, kl, ku,
                nrhs, ab, ldab,
                afb, ldafb, ipiv,
                equed, r, c, b,
                ldb, x, ldx,
                rcond, ferr, berr,
                rpivot);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgbsvx_work(Layout layout, char fact, TransChar trans,
            int n, int kl, int ku,
            int nrhs, float[] ab, int ldab,
            float[] afb, int ldafb, int[] ipiv,
            char[] equed, float[] r, float[] c, float[] b,
            int ldb, float[] x, int ldx,
            float[] rcond, float[] ferr, float[] berr,
            float[] work, int[] iwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sgbsvx_work(Layout layout, char fact, TransChar trans,
            int n, int kl, int ku,
            int nrhs, float[] ab, int ldab,
            float[] afb, int ldafb, int[] ipiv,
            char[] equed, float[] r, float[] c, float[] b,
            int ldb, float[] x, int ldx,
            float[] rcond, float[] ferr, float[] berr,
            float[] work, int[] iwork)
            => LAPACKE_sgbsvx_work(layout, fact, trans,
                n, kl, ku,
                nrhs, ab, ldab,
                afb, ldafb, ipiv,
                equed, r, c, b,
                ldb, x, ldx,
                rcond, ferr, berr,
                work, iwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgbsvxx(Layout layout, char fact, TransChar trans,
            int n, int kl, int ku,
            int nrhs, float[] ab, int ldab,
            float[] afb, int ldafb, int[] ipiv,
            char[] equed, float[] r, float[] c, float[] b,
            int ldb, float[] x, int ldx,
            float[] rcond, float[] rpvgrw, float[] berr,
            int n_err_bnds, float[] err_bnds_norm,
            float[] err_bnds_comp, int nparams,
            float[] aparams);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sgbsvxx(Layout layout, char fact, TransChar trans,
            int n, int kl, int ku,
            int nrhs, float[] ab, int ldab,
            float[] afb, int ldafb, int[] ipiv,
            char[] equed, float[] r, float[] c, float[] b,
            int ldb, float[] x, int ldx,
            float[] rcond, float[] rpvgrw, float[] berr,
            int n_err_bnds, float[] err_bnds_norm,
            float[] err_bnds_comp, int nparams,
            float[] aparams)
            => LAPACKE_sgbsvxx(layout, fact, trans,
                n, kl, ku,
                nrhs, ab, ldab,
                afb, ldafb, ipiv,
                equed, r, c, b,
                ldb, x, ldx,
                rcond, rpvgrw, berr,
                n_err_bnds, err_bnds_norm,
                err_bnds_comp, nparams,
                aparams);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgbsvxx_work(Layout layout, char fact, TransChar trans,
            int n, int kl, int ku,
            int nrhs, float[] ab, int ldab,
            float[] afb, int ldafb, int[] ipiv,
            char[] equed, float[] r, float[] c, float[] b,
            int ldb, float[] x, int ldx,
            float[] rcond, float[] rpvgrw, float[] berr,
            int n_err_bnds, float[] err_bnds_norm,
            float[] err_bnds_comp, int nparams,
            float[] aparams, float[] work, int[] iwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sgbsvxx_work(Layout layout, char fact, TransChar trans,
            int n, int kl, int ku,
            int nrhs, float[] ab, int ldab,
            float[] afb, int ldafb, int[] ipiv,
            char[] equed, float[] r, float[] c, float[] b,
            int ldb, float[] x, int ldx,
            float[] rcond, float[] rpvgrw, float[] berr,
            int n_err_bnds, float[] err_bnds_norm,
            float[] err_bnds_comp, int nparams,
            float[] aparams, float[] work, int[] iwork)
            => LAPACKE_sgbsvxx_work(layout, fact, trans,
                n, kl, ku,
                nrhs, ab, ldab,
                afb, ldafb, ipiv,
                equed, r, c, b,
                ldb, x, ldx,
                rcond, rpvgrw, berr,
                n_err_bnds, err_bnds_norm,
                err_bnds_comp, nparams,
                aparams, work, iwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgbtrf(Layout layout, int m, int n,
            int kl, int ku, float[] ab,
            int ldab, int[] ipiv);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sgbtrf(Layout layout, int m, int n,
            int kl, int ku, float[] ab,
            int ldab, int[] ipiv)
            => LAPACKE_sgbtrf(layout, m, n,
                kl, ku, ab,
                ldab, ipiv);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgbtrf_work(Layout layout, int m, int n,
            int kl, int ku, float[] ab,
            int ldab, int[] ipiv);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sgbtrf_work(Layout layout, int m, int n,
            int kl, int ku, float[] ab,
            int ldab, int[] ipiv)
            => LAPACKE_sgbtrf_work(layout, m, n,
                kl, ku, ab,
                ldab, ipiv);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgbtrs(Layout layout, TransChar trans, int n,
            int kl, int ku, int nrhs,
            float[] ab, int ldab,
            int[] ipiv, float[] b, int ldb);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sgbtrs(Layout layout, TransChar trans, int n,
            int kl, int ku, int nrhs,
            float[] ab, int ldab,
            int[] ipiv, float[] b, int ldb)
            => LAPACKE_sgbtrs(layout, trans, n,
                kl, ku, nrhs,
                ab, ldab,
                ipiv, b, ldb);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgbtrs_work(Layout layout, TransChar trans, int n,
            int kl, int ku, int nrhs,
            float[] ab, int ldab,
            int[] ipiv, float[] b,
            int ldb);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sgbtrs_work(Layout layout, TransChar trans, int n,
            int kl, int ku, int nrhs,
            float[] ab, int ldab,
            int[] ipiv, float[] b,
            int ldb)
            => LAPACKE_sgbtrs_work(layout, trans, n,
                kl, ku, nrhs,
                ab, ldab,
                ipiv, b,
                ldb);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgebak(Layout layout, char job, char side, int n,
            int ilo, int ihi, float[] scale,
            int m, float[] v, int ldv);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sgebak(Layout layout, char job, char side, int n,
            int ilo, int ihi, float[] scale,
            int m, float[] v, int ldv)
            => LAPACKE_sgebak(layout, job, side, n,
                ilo, ihi, scale,
                m, v, ldv);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgebak_work(Layout layout, char job, char side,
            int n, int ilo, int ihi,
            float[] scale, int m, float[] v,
            int ldv);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sgebak_work(Layout layout, char job, char side,
            int n, int ilo, int ihi,
            float[] scale, int m, float[] v,
            int ldv)
            => LAPACKE_sgebak_work(layout, job, side,
                n, ilo, ihi,
                scale, m, v,
                ldv);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgebal(Layout layout, char job, int n, float[] a,
            int lda, int[] ilo, int[] ihi,
            float[] scale);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sgebal(Layout layout, char job, int n, float[] a,
            int lda, int[] ilo, int[] ihi,
            float[] scale)
            => LAPACKE_sgebal(layout, job, n, a,
                lda, ilo, ihi,
                scale);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgebal_work(Layout layout, char job, int n,
            float[] a, int lda, int[] ilo,
            int[] ihi, float[] scale);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sgebal_work(Layout layout, char job, int n,
            float[] a, int lda, int[] ilo,
            int[] ihi, float[] scale)
            => LAPACKE_sgebal_work(layout, job, n,
                a, lda, ilo,
                ihi, scale);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgebrd(Layout layout, int m, int n,
            float[] a, int lda, float[] d, float[] e,
            float[] tauq, float[] taup);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sgebrd(Layout layout, int m, int n,
            float[] a, int lda, float[] d, float[] e,
            float[] tauq, float[] taup)
            => LAPACKE_sgebrd(layout, m, n,
                a, lda, d, e,
                tauq, taup);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgebrd_work(Layout layout, int m, int n,
            float[] a, int lda, float[] d, float[] e,
            float[] tauq, float[] taup, float[] work,
            int lwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sgebrd_work(Layout layout, int m, int n,
            float[] a, int lda, float[] d, float[] e,
            float[] tauq, float[] taup, float[] work,
            int lwork)
            => LAPACKE_sgebrd_work(layout, m, n,
                a, lda, d, e,
                tauq, taup, work,
                lwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgecon(Layout layout, Norm norm, int n,
            float[] a, int lda, float anorm,
            float[] rcond);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sgecon(Layout layout, Norm norm, int n,
            float[] a, int lda, float anorm,
            float[] rcond)
            => LAPACKE_sgecon(layout, norm, n,
                a, lda, anorm,
                rcond);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgecon_work(Layout layout, Norm norm, int n,
            float[] a, int lda, float anorm,
            float[] rcond, float[] work, int[] iwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sgecon_work(Layout layout, Norm norm, int n,
            float[] a, int lda, float anorm,
            float[] rcond, float[] work, int[] iwork)
            => LAPACKE_sgecon_work(layout, norm, n,
                a, lda, anorm,
                rcond, work, iwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgeequ(Layout layout, int m, int n,
            float[] a, int lda, float[] r, float[] c,
            float[] rowcnd, float[] colcnd, float[] amax);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sgeequ(Layout layout, int m, int n,
            float[] a, int lda, float[] r, float[] c,
            float[] rowcnd, float[] colcnd, float[] amax)
            => LAPACKE_sgeequ(layout, m, n,
                a, lda, r, c,
                rowcnd, colcnd, amax);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgeequ_work(Layout layout, int m, int n,
            float[] a, int lda, float[] r,
            float[] c, float[] rowcnd, float[] colcnd,
            float[] amax);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sgeequ_work(Layout layout, int m, int n,
            float[] a, int lda, float[] r,
            float[] c, float[] rowcnd, float[] colcnd,
            float[] amax)
            => LAPACKE_sgeequ_work(layout, m, n,
                a, lda, r,
                c, rowcnd, colcnd,
                amax);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgeequb(Layout layout, int m, int n,
            float[] a, int lda, float[] r, float[] c,
            float[] rowcnd, float[] colcnd, float[] amax);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sgeequb(Layout layout, int m, int n,
            float[] a, int lda, float[] r, float[] c,
            float[] rowcnd, float[] colcnd, float[] amax)
            => LAPACKE_sgeequb(layout, m, n,
                a, lda, r, c,
                rowcnd, colcnd, amax);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgeequb_work(Layout layout, int m, int n,
            float[] a, int lda, float[] r,
            float[] c, float[] rowcnd, float[] colcnd,
            float[] amax);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sgeequb_work(Layout layout, int m, int n,
            float[] a, int lda, float[] r,
            float[] c, float[] rowcnd, float[] colcnd,
            float[] amax)
            => LAPACKE_sgeequb_work(layout, m, n,
                a, lda, r,
                c, rowcnd, colcnd,
                amax);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgeev(Layout layout, char jobvl, char jobvr,
            int n, float[] a, int lda, float[] wr,
            float[] wi, float[] vl, int ldvl, float[] vr,
            int ldvr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sgeev(Layout layout, char jobvl, char jobvr,
            int n, float[] a, int lda, float[] wr,
            float[] wi, float[] vl, int ldvl, float[] vr,
            int ldvr)
            => LAPACKE_sgeev(layout, jobvl, jobvr,
                n, a, lda, wr,
                wi, vl, ldvl, vr,
                ldvr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgeev_work(Layout layout, char jobvl, char jobvr,
            int n, float[] a, int lda,
            float[] wr, float[] wi, float[] vl, int ldvl,
            float[] vr, int ldvr, float[] work,
            int lwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sgeev_work(Layout layout, char jobvl, char jobvr,
            int n, float[] a, int lda,
            float[] wr, float[] wi, float[] vl, int ldvl,
            float[] vr, int ldvr, float[] work,
            int lwork)
            => LAPACKE_sgeev_work(layout, jobvl, jobvr,
                n, a, lda,
                wr, wi, vl, ldvl,
                vr, ldvr, work,
                lwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgeevx(Layout layout, char balanc, char jobvl,
            char jobvr, char sense, int n, float[] a,
            int lda, float[] wr, float[] wi, float[] vl,
            int ldvl, float[] vr, int ldvr,
            int[] ilo, int[] ihi, float[] scale,
            float[] abnrm, float[] rconde, float[] rcondv);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sgeevx(Layout layout, char balanc, char jobvl,
            char jobvr, char sense, int n, float[] a,
            int lda, float[] wr, float[] wi, float[] vl,
            int ldvl, float[] vr, int ldvr,
            int[] ilo, int[] ihi, float[] scale,
            float[] abnrm, float[] rconde, float[] rcondv)
            => LAPACKE_sgeevx(layout, balanc, jobvl,
                jobvr, sense, n, a,
                lda, wr, wi, vl,
                ldvl, vr, ldvr,
                ilo, ihi, scale,
                abnrm, rconde, rcondv);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgeevx_work(Layout layout, char balanc, char jobvl,
            char jobvr, char sense, int n, float[] a,
            int lda, float[] wr, float[] wi, float[] vl,
            int ldvl, float[] vr, int ldvr,
            int[] ilo, int[] ihi, float[] scale,
            float[] abnrm, float[] rconde, float[] rcondv,
            float[] work, int lwork,
            int[] iwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sgeevx_work(Layout layout, char balanc, char jobvl,
            char jobvr, char sense, int n, float[] a,
            int lda, float[] wr, float[] wi, float[] vl,
            int ldvl, float[] vr, int ldvr,
            int[] ilo, int[] ihi, float[] scale,
            float[] abnrm, float[] rconde, float[] rcondv,
            float[] work, int lwork,
            int[] iwork)
            => LAPACKE_sgeevx_work(layout, balanc, jobvl,
                jobvr, sense, n, a,
                lda, wr, wi, vl,
                ldvl, vr, ldvr,
                ilo, ihi, scale,
                abnrm, rconde, rcondv,
                work, lwork,
                iwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgehrd(Layout layout, int n, int ilo,
            int ihi, float[] a, int lda,
            float[] tau);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sgehrd(Layout layout, int n, int ilo,
            int ihi, float[] a, int lda,
            float[] tau)
            => LAPACKE_sgehrd(layout, n, ilo,
                ihi, a, lda,
                tau);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgehrd_work(Layout layout, int n, int ilo,
            int ihi, float[] a, int lda,
            float[] tau, float[] work, int lwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sgehrd_work(Layout layout, int n, int ilo,
            int ihi, float[] a, int lda,
            float[] tau, float[] work, int lwork)
            => LAPACKE_sgehrd_work(layout, n, ilo,
                ihi, a, lda,
                tau, work, lwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgejsv(Layout layout, char joba, char jobu, char jobv,
            char jobr, char jobt, char jobp, int m,
            int n, float[] a, int lda, float[] sva,
            float[] u, int ldu, float[] v, int ldv,
            float[] stat, int[] istat);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sgejsv(Layout layout, char joba, char jobu, char jobv,
            char jobr, char jobt, char jobp, int m,
            int n, float[] a, int lda, float[] sva,
            float[] u, int ldu, float[] v, int ldv,
            float[] stat, int[] istat)
            => LAPACKE_sgejsv(layout, joba, jobu, jobv,
                jobr, jobt, jobp, m,
                n, a, lda, sva,
                u, ldu, v, ldv,
                stat, istat);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgejsv_work(Layout layout, char joba, char jobu,
            char jobv, char jobr, char jobt, char jobp,
            int m, int n, float[] a,
            int lda, float[] sva, float[] u,
            int ldu, float[] v, int ldv,
            float[] work, int lwork,
            int[] iwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sgejsv_work(Layout layout, char joba, char jobu,
            char jobv, char jobr, char jobt, char jobp,
            int m, int n, float[] a,
            int lda, float[] sva, float[] u,
            int ldu, float[] v, int ldv,
            float[] work, int lwork,
            int[] iwork)
            => LAPACKE_sgejsv_work(layout, joba, jobu,
                jobv, jobr, jobt, jobp,
                m, n, a,
                lda, sva, u,
                ldu, v, ldv,
                work, lwork,
                iwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgelq2(Layout layout, int m, int n,
            float[] a, int lda, float[] tau);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sgelq2(Layout layout, int m, int n,
            float[] a, int lda, float[] tau)
            => LAPACKE_sgelq2(layout, m, n,
                a, lda, tau);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgelq2_work(Layout layout, int m, int n,
            float[] a, int lda, float[] tau,
            float[] work);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sgelq2_work(Layout layout, int m, int n,
            float[] a, int lda, float[] tau,
            float[] work)
            => LAPACKE_sgelq2_work(layout, m, n,
                a, lda, tau,
                work);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgelqf(Layout layout, int m, int n,
            float[] a, int lda, float[] tau);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sgelqf(Layout layout, int m, int n,
            float[] a, int lda, float[] tau)
            => LAPACKE_sgelqf(layout, m, n,
                a, lda, tau);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgelqf_work(Layout layout, int m, int n,
            float[] a, int lda, float[] tau,
            float[] work, int lwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sgelqf_work(Layout layout, int m, int n,
            float[] a, int lda, float[] tau,
            float[] work, int lwork)
            => LAPACKE_sgelqf_work(layout, m, n,
                a, lda, tau,
                work, lwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgels(Layout layout, TransChar trans, int m,
            int n, int nrhs, float[] a,
            int lda, float[] b, int ldb);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sgels(Layout layout, TransChar trans, int m,
            int n, int nrhs, float[] a,
            int lda, float[] b, int ldb)
            => LAPACKE_sgels(layout, trans, m,
                n, nrhs, a,
                lda, b, ldb);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgels_work(Layout layout, TransChar trans, int m,
            int n, int nrhs, float[] a,
            int lda, float[] b, int ldb,
            float[] work, int lwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sgels_work(Layout layout, TransChar trans, int m,
            int n, int nrhs, float[] a,
            int lda, float[] b, int ldb,
            float[] work, int lwork)
            => LAPACKE_sgels_work(layout, trans, m,
                n, nrhs, a,
                lda, b, ldb,
                work, lwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgelsd(Layout layout, int m, int n,
            int nrhs, float[] a, int lda, float[] b,
            int ldb, float[] s, float rcond,
            int[] rank);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sgelsd(Layout layout, int m, int n,
            int nrhs, float[] a, int lda, float[] b,
            int ldb, float[] s, float rcond,
            int[] rank)
            => LAPACKE_sgelsd(layout, m, n,
                nrhs, a, lda, b,
                ldb, s, rcond,
                rank);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgelsd_work(Layout layout, int m, int n,
            int nrhs, float[] a, int lda,
            float[] b, int ldb, float[] s, float rcond,
            int[] rank, float[] work, int lwork,
            int[] iwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sgelsd_work(Layout layout, int m, int n,
            int nrhs, float[] a, int lda,
            float[] b, int ldb, float[] s, float rcond,
            int[] rank, float[] work, int lwork,
            int[] iwork)
            => LAPACKE_sgelsd_work(layout, m, n,
                nrhs, a, lda,
                b, ldb, s, rcond,
                rank, work, lwork,
                iwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgelss(Layout layout, int m, int n,
            int nrhs, float[] a, int lda, float[] b,
            int ldb, float[] s, float rcond,
            int[] rank);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sgelss(Layout layout, int m, int n,
            int nrhs, float[] a, int lda, float[] b,
            int ldb, float[] s, float rcond,
            int[] rank)
            => LAPACKE_sgelss(layout, m, n,
                nrhs, a, lda, b,
                ldb, s, rcond,
                rank);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgelss_work(Layout layout, int m, int n,
            int nrhs, float[] a, int lda,
            float[] b, int ldb, float[] s, float rcond,
            int[] rank, float[] work,
            int lwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sgelss_work(Layout layout, int m, int n,
            int nrhs, float[] a, int lda,
            float[] b, int ldb, float[] s, float rcond,
            int[] rank, float[] work,
            int lwork)
            => LAPACKE_sgelss_work(layout, m, n,
                nrhs, a, lda,
                b, ldb, s, rcond,
                rank, work,
                lwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgelsy(Layout layout, int m, int n,
            int nrhs, float[] a, int lda, float[] b,
            int ldb, int[] jpvt, float rcond,
            int[] rank);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sgelsy(Layout layout, int m, int n,
            int nrhs, float[] a, int lda, float[] b,
            int ldb, int[] jpvt, float rcond,
            int[] rank)
            => LAPACKE_sgelsy(layout, m, n,
                nrhs, a, lda, b,
                ldb, jpvt, rcond,
                rank);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgelsy_work(Layout layout, int m, int n,
            int nrhs, float[] a, int lda,
            float[] b, int ldb, int[] jpvt,
            float rcond, int[] rank, float[] work,
            int lwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sgelsy_work(Layout layout, int m, int n,
            int nrhs, float[] a, int lda,
            float[] b, int ldb, int[] jpvt,
            float rcond, int[] rank, float[] work,
            int lwork)
            => LAPACKE_sgelsy_work(layout, m, n,
                nrhs, a, lda,
                b, ldb, jpvt,
                rcond, rank, work,
                lwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgemqrt(Layout layout, char side, TransChar trans,
            int m, int n, int k,
            int nb, float[] v, int ldv,
            float[] t, int ldt, float[] c,
            int ldc);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sgemqrt(Layout layout, char side, TransChar trans,
            int m, int n, int k,
            int nb, float[] v, int ldv,
            float[] t, int ldt, float[] c,
            int ldc)
            => LAPACKE_sgemqrt(layout, side, trans,
                m, n, k,
                nb, v, ldv,
                t, ldt, c,
                ldc);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgemqrt_work(Layout layout, char side, TransChar trans,
            int m, int n, int k,
            int nb, float[] v, int ldv,
            float[] t, int ldt, float[] c,
            int ldc, float[] work);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sgemqrt_work(Layout layout, char side, TransChar trans,
            int m, int n, int k,
            int nb, float[] v, int ldv,
            float[] t, int ldt, float[] c,
            int ldc, float[] work)
            => LAPACKE_sgemqrt_work(layout, side, trans,
                m, n, k,
                nb, v, ldv,
                t, ldt, c,
                ldc, work);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgeqlf(Layout layout, int m, int n,
            float[] a, int lda, float[] tau);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sgeqlf(Layout layout, int m, int n,
            float[] a, int lda, float[] tau)
            => LAPACKE_sgeqlf(layout, m, n,
                a, lda, tau);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgeqlf_work(Layout layout, int m, int n,
            float[] a, int lda, float[] tau,
            float[] work, int lwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sgeqlf_work(Layout layout, int m, int n,
            float[] a, int lda, float[] tau,
            float[] work, int lwork)
            => LAPACKE_sgeqlf_work(layout, m, n,
                a, lda, tau,
                work, lwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgeqp3(Layout layout, int m, int n,
            float[] a, int lda, int[] jpvt,
            float[] tau);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sgeqp3(Layout layout, int m, int n,
            float[] a, int lda, int[] jpvt,
            float[] tau)
            => LAPACKE_sgeqp3(layout, m, n,
                a, lda, jpvt,
                tau);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgeqp3_work(Layout layout, int m, int n,
            float[] a, int lda, int[] jpvt,
            float[] tau, float[] work, int lwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sgeqp3_work(Layout layout, int m, int n,
            float[] a, int lda, int[] jpvt,
            float[] tau, float[] work, int lwork)
            => LAPACKE_sgeqp3_work(layout, m, n,
                a, lda, jpvt,
                tau, work, lwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgeqpf(Layout layout, int m, int n,
            float[] a, int lda, int[] jpvt,
            float[] tau);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sgeqpf(Layout layout, int m, int n,
            float[] a, int lda, int[] jpvt,
            float[] tau)
            => LAPACKE_sgeqpf(layout, m, n,
                a, lda, jpvt,
                tau);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgeqpf_work(Layout layout, int m, int n,
            float[] a, int lda, int[] jpvt,
            float[] tau, float[] work);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sgeqpf_work(Layout layout, int m, int n,
            float[] a, int lda, int[] jpvt,
            float[] tau, float[] work)
            => LAPACKE_sgeqpf_work(layout, m, n,
                a, lda, jpvt,
                tau, work);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgeqr2(Layout layout, int m, int n,
            float[] a, int lda, float[] tau);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sgeqr2(Layout layout, int m, int n,
            float[] a, int lda, float[] tau)
            => LAPACKE_sgeqr2(layout, m, n,
                a, lda, tau);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgeqr2_work(Layout layout, int m, int n,
            float[] a, int lda, float[] tau,
            float[] work);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sgeqr2_work(Layout layout, int m, int n,
            float[] a, int lda, float[] tau,
            float[] work)
            => LAPACKE_sgeqr2_work(layout, m, n,
                a, lda, tau,
                work);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgeqrf(Layout layout, int m, int n,
            float[] a, int lda, float[] tau);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sgeqrf(Layout layout, int m, int n,
            float[] a, int lda, float[] tau)
            => LAPACKE_sgeqrf(layout, m, n,
                a, lda, tau);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgeqrf_work(Layout layout, int m, int n,
            float[] a, int lda, float[] tau,
            float[] work, int lwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sgeqrf_work(Layout layout, int m, int n,
            float[] a, int lda, float[] tau,
            float[] work, int lwork)
            => LAPACKE_sgeqrf_work(layout, m, n,
                a, lda, tau,
                work, lwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgeqrfp(Layout layout, int m, int n,
            float[] a, int lda, float[] tau);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sgeqrfp(Layout layout, int m, int n,
            float[] a, int lda, float[] tau)
            => LAPACKE_sgeqrfp(layout, m, n,
                a, lda, tau);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgeqrfp_work(Layout layout, int m, int n,
            float[] a, int lda, float[] tau,
            float[] work, int lwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sgeqrfp_work(Layout layout, int m, int n,
            float[] a, int lda, float[] tau,
            float[] work, int lwork)
            => LAPACKE_sgeqrfp_work(layout, m, n,
                a, lda, tau,
                work, lwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgeqrt(Layout layout, int m, int n,
            int nb, float[] a, int lda, float[] t,
            int ldt);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sgeqrt(Layout layout, int m, int n,
            int nb, float[] a, int lda, float[] t,
            int ldt)
            => LAPACKE_sgeqrt(layout, m, n,
                nb, a, lda, t,
                ldt);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgeqrt2(Layout layout, int m, int n,
            float[] a, int lda, float[] t, int ldt);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sgeqrt2(Layout layout, int m, int n,
            float[] a, int lda, float[] t, int ldt)
            => LAPACKE_sgeqrt2(layout, m, n,
                a, lda, t, ldt);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgeqrt2_work(Layout layout, int m, int n,
            float[] a, int lda, float[] t,
            int ldt);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sgeqrt2_work(Layout layout, int m, int n,
            float[] a, int lda, float[] t,
            int ldt)
            => LAPACKE_sgeqrt2_work(layout, m, n,
                a, lda, t,
                ldt);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgeqrt3(Layout layout, int m, int n,
            float[] a, int lda, float[] t, int ldt);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sgeqrt3(Layout layout, int m, int n,
            float[] a, int lda, float[] t, int ldt)
            => LAPACKE_sgeqrt3(layout, m, n,
                a, lda, t, ldt);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgeqrt3_work(Layout layout, int m, int n,
            float[] a, int lda, float[] t,
            int ldt);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sgeqrt3_work(Layout layout, int m, int n,
            float[] a, int lda, float[] t,
            int ldt)
            => LAPACKE_sgeqrt3_work(layout, m, n,
                a, lda, t,
                ldt);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgeqrt_work(Layout layout, int m, int n,
            int nb, float[] a, int lda,
            float[] t, int ldt, float[] work);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sgeqrt_work(Layout layout, int m, int n,
            int nb, float[] a, int lda,
            float[] t, int ldt, float[] work)
            => LAPACKE_sgeqrt_work(layout, m, n,
                nb, a, lda,
                t, ldt, work);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgerfs(Layout layout, TransChar trans, int n,
            int nrhs, float[] a, int lda,
            float[] af, int ldaf,
            int[] ipiv, float[] b,
            int ldb, float[] x, int ldx,
            float[] ferr, float[] berr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sgerfs(Layout layout, TransChar trans, int n,
            int nrhs, float[] a, int lda,
            float[] af, int ldaf,
            int[] ipiv, float[] b,
            int ldb, float[] x, int ldx,
            float[] ferr, float[] berr)
            => LAPACKE_sgerfs(layout, trans, n,
                nrhs, a, lda,
                af, ldaf,
                ipiv, b,
                ldb, x, ldx,
                ferr, berr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgerfs_work(Layout layout, TransChar trans, int n,
            int nrhs, float[] a, int lda,
            float[] af, int ldaf,
            int[] ipiv, float[] b,
            int ldb, float[] x, int ldx,
            float[] ferr, float[] berr, float[] work,
            int[] iwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sgerfs_work(Layout layout, TransChar trans, int n,
            int nrhs, float[] a, int lda,
            float[] af, int ldaf,
            int[] ipiv, float[] b,
            int ldb, float[] x, int ldx,
            float[] ferr, float[] berr, float[] work,
            int[] iwork)
            => LAPACKE_sgerfs_work(layout, trans, n,
                nrhs, a, lda,
                af, ldaf,
                ipiv, b,
                ldb, x, ldx,
                ferr, berr, work,
                iwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgerfsx(Layout layout, TransChar trans, char equed,
            int n, int nrhs, float[] a,
            int lda, float[] af, int ldaf,
            int[] ipiv, float[] r,
            float[] c, float[] b, int ldb,
            float[] x, int ldx, float[] rcond, float[] berr,
            int n_err_bnds, float[] err_bnds_norm,
            float[] err_bnds_comp, int nparams,
            float[] aparams);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sgerfsx(Layout layout, TransChar trans, char equed,
            int n, int nrhs, float[] a,
            int lda, float[] af, int ldaf,
            int[] ipiv, float[] r,
            float[] c, float[] b, int ldb,
            float[] x, int ldx, float[] rcond, float[] berr,
            int n_err_bnds, float[] err_bnds_norm,
            float[] err_bnds_comp, int nparams,
            float[] aparams)
            => LAPACKE_sgerfsx(layout, trans, equed,
                n, nrhs, a,
                lda, af, ldaf,
                ipiv, r,
                c, b, ldb,
                x, ldx, rcond, berr,
                n_err_bnds, err_bnds_norm,
                err_bnds_comp, nparams,
                aparams);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgerfsx_work(Layout layout, TransChar trans, char equed,
            int n, int nrhs, float[] a,
            int lda, float[] af,
            int ldaf, int[] ipiv,
            float[] r, float[] c, float[] b,
            int ldb, float[] x, int ldx,
            float[] rcond, float[] berr,
            int n_err_bnds, float[] err_bnds_norm,
            float[] err_bnds_comp, int nparams,
            float[] aparams, float[] work, int[] iwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sgerfsx_work(Layout layout, TransChar trans, char equed,
            int n, int nrhs, float[] a,
            int lda, float[] af,
            int ldaf, int[] ipiv,
            float[] r, float[] c, float[] b,
            int ldb, float[] x, int ldx,
            float[] rcond, float[] berr,
            int n_err_bnds, float[] err_bnds_norm,
            float[] err_bnds_comp, int nparams,
            float[] aparams, float[] work, int[] iwork)
            => LAPACKE_sgerfsx_work(layout, trans, equed,
                n, nrhs, a,
                lda, af,
                ldaf, ipiv,
                r, c, b,
                ldb, x, ldx,
                rcond, berr,
                n_err_bnds, err_bnds_norm,
                err_bnds_comp, nparams,
                aparams, work, iwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgerqf(Layout layout, int m, int n,
            float[] a, int lda, float[] tau);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sgerqf(Layout layout, int m, int n,
            float[] a, int lda, float[] tau)
            => LAPACKE_sgerqf(layout, m, n,
                a, lda, tau);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgerqf_work(Layout layout, int m, int n,
            float[] a, int lda, float[] tau,
            float[] work, int lwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sgerqf_work(Layout layout, int m, int n,
            float[] a, int lda, float[] tau,
            float[] work, int lwork)
            => LAPACKE_sgerqf_work(layout, m, n,
                a, lda, tau,
                work, lwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgesdd(Layout layout, char jobz, int m,
            int n, float[] a, int lda, float[] s,
            float[] u, int ldu, float[] vt,
            int ldvt);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sgesdd(Layout layout, char jobz, int m,
            int n, float[] a, int lda, float[] s,
            float[] u, int ldu, float[] vt,
            int ldvt)
            => LAPACKE_sgesdd(layout, jobz, m,
                n, a, lda, s,
                u, ldu, vt,
                ldvt);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgesdd_work(Layout layout, char jobz, int m,
            int n, float[] a, int lda,
            float[] s, float[] u, int ldu, float[] vt,
            int ldvt, float[] work, int lwork,
            int[] iwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sgesdd_work(Layout layout, char jobz, int m,
            int n, float[] a, int lda,
            float[] s, float[] u, int ldu, float[] vt,
            int ldvt, float[] work, int lwork,
            int[] iwork)
            => LAPACKE_sgesdd_work(layout, jobz, m,
                n, a, lda,
                s, u, ldu, vt,
                ldvt, work, lwork,
                iwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgesv(Layout layout, int n, int nrhs,
            float[] a, int lda, int[] ipiv, float[] b,
            int ldb);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sgesv(Layout layout, int n, int nrhs,
            float[] a, int lda, int[] ipiv, float[] b,
            int ldb)
            => LAPACKE_sgesv(layout, n, nrhs,
                a, lda, ipiv, b,
                ldb);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgesv_work(Layout layout, int n, int nrhs,
            float[] a, int lda, int[] ipiv,
            float[] b, int ldb);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sgesv_work(Layout layout, int n, int nrhs,
            float[] a, int lda, int[] ipiv,
            float[] b, int ldb)
            => LAPACKE_sgesv_work(layout, n, nrhs,
                a, lda, ipiv,
                b, ldb);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgesvd(Layout layout, char jobu, char jobvt,
            int m, int n, float[] a, int lda,
            float[] s, float[] u, int ldu, float[] vt,
            int ldvt, float[] superb);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sgesvd(Layout layout, char jobu, char jobvt,
            int m, int n, float[] a, int lda,
            float[] s, float[] u, int ldu, float[] vt,
            int ldvt, float[] superb)
            => LAPACKE_sgesvd(layout, jobu, jobvt,
                m, n, a, lda,
                s, u, ldu, vt,
                ldvt, superb);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgesvd_work(Layout layout, char jobu, char jobvt,
            int m, int n, float[] a,
            int lda, float[] s, float[] u,
            int ldu, float[] vt, int ldvt,
            float[] work, int lwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sgesvd_work(Layout layout, char jobu, char jobvt,
            int m, int n, float[] a,
            int lda, float[] s, float[] u,
            int ldu, float[] vt, int ldvt,
            float[] work, int lwork)
            => LAPACKE_sgesvd_work(layout, jobu, jobvt,
                m, n, a,
                lda, s, u,
                ldu, vt, ldvt,
                work, lwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgesvdx(Layout layout, char jobu, char jobvt, char range,
            int m, int n, float[] a,
            int lda, float vl, float vu,
            int il, int iu, int[] ns,
            float[] s, float[] u, int ldu,
            float[] vt, int ldvt,
            int[] superb);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sgesvdx(Layout layout, char jobu, char jobvt, char range,
            int m, int n, float[] a,
            int lda, float vl, float vu,
            int il, int iu, int[] ns,
            float[] s, float[] u, int ldu,
            float[] vt, int ldvt,
            int[] superb)
            => LAPACKE_sgesvdx(layout, jobu, jobvt, range,
                m, n, a,
                lda, vl, vu,
                il, iu, ns,
                s, u, ldu,
                vt, ldvt,
                superb);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgesvdx_work(Layout layout, char jobu, char jobvt, char range,
            int m, int n, float[] a,
            int lda, float vl, float vu,
            int il, int iu, int[] ns,
            float[] s, float[] u, int ldu,
            float[] vt, int ldvt,
            float[] work, int lwork, int[] iwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sgesvdx_work(Layout layout, char jobu, char jobvt, char range,
            int m, int n, float[] a,
            int lda, float vl, float vu,
            int il, int iu, int[] ns,
            float[] s, float[] u, int ldu,
            float[] vt, int ldvt,
            float[] work, int lwork, int[] iwork)
            => LAPACKE_sgesvdx_work(layout, jobu, jobvt, range,
                m, n, a,
                lda, vl, vu,
                il, iu, ns,
                s, u, ldu,
                vt, ldvt,
                work, lwork, iwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgesvj(Layout layout, char joba, char jobu, char jobv,
            int m, int n, float[] a, int lda,
            float[] sva, int mv, float[] v, int ldv,
            float[] stat);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sgesvj(Layout layout, char joba, char jobu, char jobv,
            int m, int n, float[] a, int lda,
            float[] sva, int mv, float[] v, int ldv,
            float[] stat)
            => LAPACKE_sgesvj(layout, joba, jobu, jobv,
                m, n, a, lda,
                sva, mv, v, ldv,
                stat);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgesvj_work(Layout layout, char joba, char jobu,
            char jobv, int m, int n, float[] a,
            int lda, float[] sva, int mv,
            float[] v, int ldv, float[] work,
            int lwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sgesvj_work(Layout layout, char joba, char jobu,
            char jobv, int m, int n, float[] a,
            int lda, float[] sva, int mv,
            float[] v, int ldv, float[] work,
            int lwork)
            => LAPACKE_sgesvj_work(layout, joba, jobu,
                jobv, m, n, a,
                lda, sva, mv,
                v, ldv, work,
                lwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgesvx(Layout layout, char fact, TransChar trans,
            int n, int nrhs, float[] a,
            int lda, float[] af, int ldaf,
            int[] ipiv, char[] equed, float[] r, float[] c,
            float[] b, int ldb, float[] x, int ldx,
            float[] rcond, float[] ferr, float[] berr,
            float[] rpivot);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sgesvx(Layout layout, char fact, TransChar trans,
            int n, int nrhs, float[] a,
            int lda, float[] af, int ldaf,
            int[] ipiv, char[] equed, float[] r, float[] c,
            float[] b, int ldb, float[] x, int ldx,
            float[] rcond, float[] ferr, float[] berr,
            float[] rpivot)
            => LAPACKE_sgesvx(layout, fact, trans,
                n, nrhs, a,
                lda, af, ldaf,
                ipiv, equed, r, c,
                b, ldb, x, ldx,
                rcond, ferr, berr,
                rpivot);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgesvx_work(Layout layout, char fact, TransChar trans,
            int n, int nrhs, float[] a,
            int lda, float[] af, int ldaf,
            int[] ipiv, char[] equed, float[] r,
            float[] c, float[] b, int ldb, float[] x,
            int ldx, float[] rcond, float[] ferr,
            float[] berr, float[] work, int[] iwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sgesvx_work(Layout layout, char fact, TransChar trans,
            int n, int nrhs, float[] a,
            int lda, float[] af, int ldaf,
            int[] ipiv, char[] equed, float[] r,
            float[] c, float[] b, int ldb, float[] x,
            int ldx, float[] rcond, float[] ferr,
            float[] berr, float[] work, int[] iwork)
            => LAPACKE_sgesvx_work(layout, fact, trans,
                n, nrhs, a,
                lda, af, ldaf,
                ipiv, equed, r,
                c, b, ldb, x,
                ldx, rcond, ferr,
                berr, work, iwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgesvxx(Layout layout, char fact, TransChar trans,
            int n, int nrhs, float[] a,
            int lda, float[] af, int ldaf,
            int[] ipiv, char[] equed, float[] r, float[] c,
            float[] b, int ldb, float[] x, int ldx,
            float[] rcond, float[] rpvgrw, float[] berr,
            int n_err_bnds, float[] err_bnds_norm,
            float[] err_bnds_comp, int nparams,
            float[] aparams);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sgesvxx(Layout layout, char fact, TransChar trans,
            int n, int nrhs, float[] a,
            int lda, float[] af, int ldaf,
            int[] ipiv, char[] equed, float[] r, float[] c,
            float[] b, int ldb, float[] x, int ldx,
            float[] rcond, float[] rpvgrw, float[] berr,
            int n_err_bnds, float[] err_bnds_norm,
            float[] err_bnds_comp, int nparams,
            float[] aparams)
            => LAPACKE_sgesvxx(layout, fact, trans,
                n, nrhs, a,
                lda, af, ldaf,
                ipiv, equed, r, c,
                b, ldb, x, ldx,
                rcond, rpvgrw, berr,
                n_err_bnds, err_bnds_norm,
                err_bnds_comp, nparams,
                aparams);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgesvxx_work(Layout layout, char fact, TransChar trans,
            int n, int nrhs, float[] a,
            int lda, float[] af, int ldaf,
            int[] ipiv, char[] equed, float[] r,
            float[] c, float[] b, int ldb, float[] x,
            int ldx, float[] rcond, float[] rpvgrw,
            float[] berr, int n_err_bnds,
            float[] err_bnds_norm, float[] err_bnds_comp,
            int nparams, float[] aparams, float[] work,
            int[] iwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sgesvxx_work(Layout layout, char fact, TransChar trans,
            int n, int nrhs, float[] a,
            int lda, float[] af, int ldaf,
            int[] ipiv, char[] equed, float[] r,
            float[] c, float[] b, int ldb, float[] x,
            int ldx, float[] rcond, float[] rpvgrw,
            float[] berr, int n_err_bnds,
            float[] err_bnds_norm, float[] err_bnds_comp,
            int nparams, float[] aparams, float[] work,
            int[] iwork)
            => LAPACKE_sgesvxx_work(layout, fact, trans,
                n, nrhs, a,
                lda, af, ldaf,
                ipiv, equed, r,
                c, b, ldb, x,
                ldx, rcond, rpvgrw,
                berr, n_err_bnds,
                err_bnds_norm, err_bnds_comp,
                nparams, aparams, work,
                iwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgetf2(Layout layout, int m, int n,
            float[] a, int lda, int[] ipiv);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sgetf2(Layout layout, int m, int n,
            float[] a, int lda, int[] ipiv)
            => LAPACKE_sgetf2(layout, m, n,
                a, lda, ipiv);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgetf2_work(Layout layout, int m, int n,
            float[] a, int lda, int[] ipiv);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sgetf2_work(Layout layout, int m, int n,
            float[] a, int lda, int[] ipiv)
            => LAPACKE_sgetf2_work(layout, m, n,
                a, lda, ipiv);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgetrf(Layout layout, int m, int n,
            float[] a, int lda, int[] ipiv);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sgetrf(Layout layout, int m, int n,
            float[] a, int lda, int[] ipiv)
            => LAPACKE_sgetrf(layout, m, n,
                a, lda, ipiv);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgetrf2(Layout layout, int m, int n,
            float[] a, int lda, int[] ipiv);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sgetrf2(Layout layout, int m, int n,
            float[] a, int lda, int[] ipiv)
            => LAPACKE_sgetrf2(layout, m, n,
                a, lda, ipiv);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgetrf2_work(Layout layout, int m, int n,
            float[] a, int lda, int[] ipiv);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sgetrf2_work(Layout layout, int m, int n,
            float[] a, int lda, int[] ipiv)
            => LAPACKE_sgetrf2_work(layout, m, n,
                a, lda, ipiv);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgetrf_work(Layout layout, int m, int n,
            float[] a, int lda, int[] ipiv);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sgetrf_work(Layout layout, int m, int n,
            float[] a, int lda, int[] ipiv)
            => LAPACKE_sgetrf_work(layout, m, n,
                a, lda, ipiv);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgetri(Layout layout, int n, float[] a,
            int lda, int[] ipiv);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sgetri(Layout layout, int n, float[] a,
            int lda, int[] ipiv)
            => LAPACKE_sgetri(layout, n, a,
                lda, ipiv);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgetri_work(Layout layout, int n, float[] a,
            int lda, int[] ipiv,
            float[] work, int lwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sgetri_work(Layout layout, int n, float[] a,
            int lda, int[] ipiv,
            float[] work, int lwork)
            => LAPACKE_sgetri_work(layout, n, a,
                lda, ipiv,
                work, lwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgetrs(Layout layout, TransChar trans, int n,
            int nrhs, float[] a, int lda,
            int[] ipiv, float[] b, int ldb);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sgetrs(Layout layout, TransChar trans, int n,
            int nrhs, float[] a, int lda,
            int[] ipiv, float[] b, int ldb)
            => LAPACKE_sgetrs(layout, trans, n,
                nrhs, a, lda,
                ipiv, b, ldb);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgetrs_work(Layout layout, TransChar trans, int n,
            int nrhs, float[] a, int lda,
            int[] ipiv, float[] b,
            int ldb);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sgetrs_work(Layout layout, TransChar trans, int n,
            int nrhs, float[] a, int lda,
            int[] ipiv, float[] b,
            int ldb)
            => LAPACKE_sgetrs_work(layout, trans, n,
                nrhs, a, lda,
                ipiv, b,
                ldb);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sggbak(Layout layout, char job, char side, int n,
            int ilo, int ihi, float[] lscale,
            float[] rscale, int m, float[] v,
            int ldv);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sggbak(Layout layout, char job, char side, int n,
            int ilo, int ihi, float[] lscale,
            float[] rscale, int m, float[] v,
            int ldv)
            => LAPACKE_sggbak(layout, job, side, n,
                ilo, ihi, lscale,
                rscale, m, v,
                ldv);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sggbak_work(Layout layout, char job, char side,
            int n, int ilo, int ihi,
            float[] lscale, float[] rscale,
            int m, float[] v, int ldv);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sggbak_work(Layout layout, char job, char side,
            int n, int ilo, int ihi,
            float[] lscale, float[] rscale,
            int m, float[] v, int ldv)
            => LAPACKE_sggbak_work(layout, job, side,
                n, ilo, ihi,
                lscale, rscale,
                m, v, ldv);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sggbal(Layout layout, char job, int n, float[] a,
            int lda, float[] b, int ldb,
            int[] ilo, int[] ihi, float[] lscale,
            float[] rscale);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sggbal(Layout layout, char job, int n, float[] a,
            int lda, float[] b, int ldb,
            int[] ilo, int[] ihi, float[] lscale,
            float[] rscale)
            => LAPACKE_sggbal(layout, job, n, a,
                lda, b, ldb,
                ilo, ihi, lscale,
                rscale);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sggbal_work(Layout layout, char job, int n,
            float[] a, int lda, float[] b,
            int ldb, int[] ilo,
            int[] ihi, float[] lscale, float[] rscale,
            float[] work);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sggbal_work(Layout layout, char job, int n,
            float[] a, int lda, float[] b,
            int ldb, int[] ilo,
            int[] ihi, float[] lscale, float[] rscale,
            float[] work)
            => LAPACKE_sggbal_work(layout, job, n,
                a, lda, b,
                ldb, ilo,
                ihi, lscale, rscale,
                work);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sggev(Layout layout, char jobvl, char jobvr,
            int n, float[] a, int lda, float[] b,
            int ldb, float[] alphar, float[] alphai,
            float[] beta, float[] vl, int ldvl, float[] vr,
            int ldvr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sggev(Layout layout, char jobvl, char jobvr,
            int n, float[] a, int lda, float[] b,
            int ldb, float[] alphar, float[] alphai,
            float[] beta, float[] vl, int ldvl, float[] vr,
            int ldvr)
            => LAPACKE_sggev(layout, jobvl, jobvr,
                n, a, lda, b,
                ldb, alphar, alphai,
                beta, vl, ldvl, vr,
                ldvr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sggev3(Layout layout, char jobvl, char jobvr,
            int n, float[] a, int lda, float[] b,
            int ldb, float[] alphar, float[] alphai,
            float[] beta, float[] vl, int ldvl, float[] vr,
            int ldvr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sggev3(Layout layout, char jobvl, char jobvr,
            int n, float[] a, int lda, float[] b,
            int ldb, float[] alphar, float[] alphai,
            float[] beta, float[] vl, int ldvl, float[] vr,
            int ldvr)
            => LAPACKE_sggev3(layout, jobvl, jobvr,
                n, a, lda, b,
                ldb, alphar, alphai,
                beta, vl, ldvl, vr,
                ldvr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sggev3_work(Layout layout,
            char jobvl, char jobvr, int n,
            float[] a, int lda,
            float[] b, int ldb,
            float[] alphar, float[] alphai, float[] beta,
            float[] vl, int ldvl,
            float[] vr, int ldvr,
            float[] work, int lwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sggev3_work(Layout layout,
            char jobvl, char jobvr, int n,
            float[] a, int lda,
            float[] b, int ldb,
            float[] alphar, float[] alphai, float[] beta,
            float[] vl, int ldvl,
            float[] vr, int ldvr,
            float[] work, int lwork)
            => LAPACKE_sggev3_work(layout,
                jobvl, jobvr, n,
                a, lda,
                b, ldb,
                alphar, alphai, beta,
                vl, ldvl,
                vr, ldvr,
                work, lwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sggev_work(Layout layout, char jobvl, char jobvr,
            int n, float[] a, int lda, float[] b,
            int ldb, float[] alphar, float[] alphai,
            float[] beta, float[] vl, int ldvl,
            float[] vr, int ldvr, float[] work,
            int lwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sggev_work(Layout layout, char jobvl, char jobvr,
            int n, float[] a, int lda, float[] b,
            int ldb, float[] alphar, float[] alphai,
            float[] beta, float[] vl, int ldvl,
            float[] vr, int ldvr, float[] work,
            int lwork)
            => LAPACKE_sggev_work(layout, jobvl, jobvr,
                n, a, lda, b,
                ldb, alphar, alphai,
                beta, vl, ldvl,
                vr, ldvr, work,
                lwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sggevx(Layout layout, char balanc, char jobvl,
            char jobvr, char sense, int n, float[] a,
            int lda, float[] b, int ldb,
            float[] alphar, float[] alphai, float[] beta, float[] vl,
            int ldvl, float[] vr, int ldvr,
            int[] ilo, int[] ihi, float[] lscale,
            float[] rscale, float[] abnrm, float[] bbnrm,
            float[] rconde, float[] rcondv);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sggevx(Layout layout, char balanc, char jobvl,
            char jobvr, char sense, int n, float[] a,
            int lda, float[] b, int ldb,
            float[] alphar, float[] alphai, float[] beta, float[] vl,
            int ldvl, float[] vr, int ldvr,
            int[] ilo, int[] ihi, float[] lscale,
            float[] rscale, float[] abnrm, float[] bbnrm,
            float[] rconde, float[] rcondv)
            => LAPACKE_sggevx(layout, balanc, jobvl,
                jobvr, sense, n, a,
                lda, b, ldb,
                alphar, alphai, beta, vl,
                ldvl, vr, ldvr,
                ilo, ihi, lscale,
                rscale, abnrm, bbnrm,
                rconde, rcondv);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sggevx_work(Layout layout, char balanc, char jobvl,
            char jobvr, char sense, int n, float[] a,
            int lda, float[] b, int ldb,
            float[] alphar, float[] alphai, float[] beta,
            float[] vl, int ldvl, float[] vr,
            int ldvr, int[] ilo,
            int[] ihi, float[] lscale, float[] rscale,
            float[] abnrm, float[] bbnrm, float[] rconde,
            float[] rcondv, float[] work, int lwork,
            int[] iwork, int[] bwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sggevx_work(Layout layout, char balanc, char jobvl,
            char jobvr, char sense, int n, float[] a,
            int lda, float[] b, int ldb,
            float[] alphar, float[] alphai, float[] beta,
            float[] vl, int ldvl, float[] vr,
            int ldvr, int[] ilo,
            int[] ihi, float[] lscale, float[] rscale,
            float[] abnrm, float[] bbnrm, float[] rconde,
            float[] rcondv, float[] work, int lwork,
            int[] iwork, int[] bwork)
            => LAPACKE_sggevx_work(layout, balanc, jobvl,
                jobvr, sense, n, a,
                lda, b, ldb,
                alphar, alphai, beta,
                vl, ldvl, vr,
                ldvr, ilo,
                ihi, lscale, rscale,
                abnrm, bbnrm, rconde,
                rcondv, work, lwork,
                iwork, bwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sggglm(Layout layout, int n, int m,
            int p, float[] a, int lda, float[] b,
            int ldb, float[] d, float[] x, float[] y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sggglm(Layout layout, int n, int m,
            int p, float[] a, int lda, float[] b,
            int ldb, float[] d, float[] x, float[] y)
            => LAPACKE_sggglm(layout, n, m,
                p, a, lda, b,
                ldb, d, x, y);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sggglm_work(Layout layout, int n, int m,
            int p, float[] a, int lda,
            float[] b, int ldb, float[] d, float[] x,
            float[] y, float[] work, int lwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sggglm_work(Layout layout, int n, int m,
            int p, float[] a, int lda,
            float[] b, int ldb, float[] d, float[] x,
            float[] y, float[] work, int lwork)
            => LAPACKE_sggglm_work(layout, n, m,
                p, a, lda,
                b, ldb, d, x,
                y, work, lwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgghd3(Layout layout, char compq, char compz,
            int n, int ilo, int ihi,
            float[] a, int lda, float[] b, int ldb,
            float[] q, int ldq, float[] z, int ldz);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sgghd3(Layout layout, char compq, char compz,
            int n, int ilo, int ihi,
            float[] a, int lda, float[] b, int ldb,
            float[] q, int ldq, float[] z, int ldz)
            => LAPACKE_sgghd3(layout, compq, compz,
                n, ilo, ihi,
                a, lda, b, ldb,
                q, ldq, z, ldz);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgghd3_work(Layout layout, char compq, char compz,
            int n, int ilo, int ihi,
            float[] a, int lda, float[] b,
            int ldb, float[] q, int ldq,
            float[] z, int ldz, float[] work,
            int lwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sgghd3_work(Layout layout, char compq, char compz,
            int n, int ilo, int ihi,
            float[] a, int lda, float[] b,
            int ldb, float[] q, int ldq,
            float[] z, int ldz, float[] work,
            int lwork)
            => LAPACKE_sgghd3_work(layout, compq, compz,
                n, ilo, ihi,
                a, lda, b,
                ldb, q, ldq,
                z, ldz, work,
                lwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgghrd(Layout layout, char compq, char compz,
            int n, int ilo, int ihi,
            float[] a, int lda, float[] b, int ldb,
            float[] q, int ldq, float[] z, int ldz);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sgghrd(Layout layout, char compq, char compz,
            int n, int ilo, int ihi,
            float[] a, int lda, float[] b, int ldb,
            float[] q, int ldq, float[] z, int ldz)
            => LAPACKE_sgghrd(layout, compq, compz,
                n, ilo, ihi,
                a, lda, b, ldb,
                q, ldq, z, ldz);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgghrd_work(Layout layout, char compq, char compz,
            int n, int ilo, int ihi,
            float[] a, int lda, float[] b,
            int ldb, float[] q, int ldq,
            float[] z, int ldz);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sgghrd_work(Layout layout, char compq, char compz,
            int n, int ilo, int ihi,
            float[] a, int lda, float[] b,
            int ldb, float[] q, int ldq,
            float[] z, int ldz)
            => LAPACKE_sgghrd_work(layout, compq, compz,
                n, ilo, ihi,
                a, lda, b,
                ldb, q, ldq,
                z, ldz);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgglse(Layout layout, int m, int n,
            int p, float[] a, int lda, float[] b,
            int ldb, float[] c, float[] d, float[] x);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sgglse(Layout layout, int m, int n,
            int p, float[] a, int lda, float[] b,
            int ldb, float[] c, float[] d, float[] x)
            => LAPACKE_sgglse(layout, m, n,
                p, a, lda, b,
                ldb, c, d, x);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgglse_work(Layout layout, int m, int n,
            int p, float[] a, int lda,
            float[] b, int ldb, float[] c, float[] d,
            float[] x, float[] work, int lwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sgglse_work(Layout layout, int m, int n,
            int p, float[] a, int lda,
            float[] b, int ldb, float[] c, float[] d,
            float[] x, float[] work, int lwork)
            => LAPACKE_sgglse_work(layout, m, n,
                p, a, lda,
                b, ldb, c, d,
                x, work, lwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sggqrf(Layout layout, int n, int m,
            int p, float[] a, int lda, float[] taua,
            float[] b, int ldb, float[] taub);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sggqrf(Layout layout, int n, int m,
            int p, float[] a, int lda, float[] taua,
            float[] b, int ldb, float[] taub)
            => LAPACKE_sggqrf(layout, n, m,
                p, a, lda, taua,
                b, ldb, taub);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sggqrf_work(Layout layout, int n, int m,
            int p, float[] a, int lda,
            float[] taua, float[] b, int ldb,
            float[] taub, float[] work, int lwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sggqrf_work(Layout layout, int n, int m,
            int p, float[] a, int lda,
            float[] taua, float[] b, int ldb,
            float[] taub, float[] work, int lwork)
            => LAPACKE_sggqrf_work(layout, n, m,
                p, a, lda,
                taua, b, ldb,
                taub, work, lwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sggrqf(Layout layout, int m, int p,
            int n, float[] a, int lda, float[] taua,
            float[] b, int ldb, float[] taub);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sggrqf(Layout layout, int m, int p,
            int n, float[] a, int lda, float[] taua,
            float[] b, int ldb, float[] taub)
            => LAPACKE_sggrqf(layout, m, p,
                n, a, lda, taua,
                b, ldb, taub);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sggrqf_work(Layout layout, int m, int p,
            int n, float[] a, int lda,
            float[] taua, float[] b, int ldb,
            float[] taub, float[] work, int lwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sggrqf_work(Layout layout, int m, int p,
            int n, float[] a, int lda,
            float[] taua, float[] b, int ldb,
            float[] taub, float[] work, int lwork)
            => LAPACKE_sggrqf_work(layout, m, p,
                n, a, lda,
                taua, b, ldb,
                taub, work, lwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sggsvd(Layout layout, char jobu, char jobv, char jobq,
            int m, int n, int p,
            int[] k, int[] l, float[] a,
            int lda, float[] b, int ldb,
            float[] alpha, float[] beta, float[] u, int ldu,
            float[] v, int ldv, float[] q, int ldq,
            int[] iwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sggsvd(Layout layout, char jobu, char jobv, char jobq,
            int m, int n, int p,
            int[] k, int[] l, float[] a,
            int lda, float[] b, int ldb,
            float[] alpha, float[] beta, float[] u, int ldu,
            float[] v, int ldv, float[] q, int ldq,
            int[] iwork)
            => LAPACKE_sggsvd(layout, jobu, jobv, jobq,
                m, n, p,
                k, l, a,
                lda, b, ldb,
                alpha, beta, u, ldu,
                v, ldv, q, ldq,
                iwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sggsvd3(Layout layout, char jobu, char jobv, char jobq,
            int m, int n, int p,
            int[] k, int[] l, float[] a,
            int lda, float[] b, int ldb,
            float[] alpha, float[] beta, float[] u, int ldu,
            float[] v, int ldv, float[] q, int ldq,
            int[] iwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sggsvd3(Layout layout, char jobu, char jobv, char jobq,
            int m, int n, int p,
            int[] k, int[] l, float[] a,
            int lda, float[] b, int ldb,
            float[] alpha, float[] beta, float[] u, int ldu,
            float[] v, int ldv, float[] q, int ldq,
            int[] iwork)
            => LAPACKE_sggsvd3(layout, jobu, jobv, jobq,
                m, n, p,
                k, l, a,
                lda, b, ldb,
                alpha, beta, u, ldu,
                v, ldv, q, ldq,
                iwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sggsvd3_work(Layout layout, char jobu, char jobv,
            char jobq, int m, int n,
            int p, int[] k, int[] l,
            float[] a, int lda, float[] b,
            int ldb, float[] alpha, float[] beta,
            float[] u, int ldu, float[] v,
            int ldv, float[] q, int ldq,
            float[] work, int lwork,
            int[] iwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sggsvd3_work(Layout layout, char jobu, char jobv,
            char jobq, int m, int n,
            int p, int[] k, int[] l,
            float[] a, int lda, float[] b,
            int ldb, float[] alpha, float[] beta,
            float[] u, int ldu, float[] v,
            int ldv, float[] q, int ldq,
            float[] work, int lwork,
            int[] iwork)
            => LAPACKE_sggsvd3_work(layout, jobu, jobv,
                jobq, m, n,
                p, k, l,
                a, lda, b,
                ldb, alpha, beta,
                u, ldu, v,
                ldv, q, ldq,
                work, lwork,
                iwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sggsvd_work(Layout layout, char jobu, char jobv,
            char jobq, int m, int n,
            int p, int[] k, int[] l,
            float[] a, int lda, float[] b,
            int ldb, float[] alpha, float[] beta,
            float[] u, int ldu, float[] v,
            int ldv, float[] q, int ldq,
            float[] work, int[] iwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sggsvd_work(Layout layout, char jobu, char jobv,
            char jobq, int m, int n,
            int p, int[] k, int[] l,
            float[] a, int lda, float[] b,
            int ldb, float[] alpha, float[] beta,
            float[] u, int ldu, float[] v,
            int ldv, float[] q, int ldq,
            float[] work, int[] iwork)
            => LAPACKE_sggsvd_work(layout, jobu, jobv,
                jobq, m, n,
                p, k, l,
                a, lda, b,
                ldb, alpha, beta,
                u, ldu, v,
                ldv, q, ldq,
                work, iwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sggsvp(Layout layout, char jobu, char jobv, char jobq,
            int m, int p, int n, float[] a,
            int lda, float[] b, int ldb, float tola,
            float tolb, int[] k, int[] l, float[] u,
            int ldu, float[] v, int ldv, float[] q,
            int ldq);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sggsvp(Layout layout, char jobu, char jobv, char jobq,
            int m, int p, int n, float[] a,
            int lda, float[] b, int ldb, float tola,
            float tolb, int[] k, int[] l, float[] u,
            int ldu, float[] v, int ldv, float[] q,
            int ldq)
            => LAPACKE_sggsvp(layout, jobu, jobv, jobq,
                m, p, n, a,
                lda, b, ldb, tola,
                tolb, k, l, u,
                ldu, v, ldv, q,
                ldq);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sggsvp3(Layout layout, char jobu, char jobv, char jobq,
            int m, int p, int n, float[] a,
            int lda, float[] b, int ldb, float tola,
            float tolb, int[] k, int[] l, float[] u,
            int ldu, float[] v, int ldv, float[] q,
            int ldq);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sggsvp3(Layout layout, char jobu, char jobv, char jobq,
            int m, int p, int n, float[] a,
            int lda, float[] b, int ldb, float tola,
            float tolb, int[] k, int[] l, float[] u,
            int ldu, float[] v, int ldv, float[] q,
            int ldq)
            => LAPACKE_sggsvp3(layout, jobu, jobv, jobq,
                m, p, n, a,
                lda, b, ldb, tola,
                tolb, k, l, u,
                ldu, v, ldv, q,
                ldq);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sggsvp3_work(Layout layout, char jobu, char jobv,
            char jobq, int m, int p,
            int n, float[] a, int lda,
            float[] b, int ldb, float tola,
            float tolb, int[] k, int[] l,
            float[] u, int ldu, float[] v,
            int ldv, float[] q, int ldq,
            int[] iwork, float[] tau, float[] work,
            int lwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sggsvp3_work(Layout layout, char jobu, char jobv,
            char jobq, int m, int p,
            int n, float[] a, int lda,
            float[] b, int ldb, float tola,
            float tolb, int[] k, int[] l,
            float[] u, int ldu, float[] v,
            int ldv, float[] q, int ldq,
            int[] iwork, float[] tau, float[] work,
            int lwork)
            => LAPACKE_sggsvp3_work(layout, jobu, jobv,
                jobq, m, p,
                n, a, lda,
                b, ldb, tola,
                tolb, k, l,
                u, ldu, v,
                ldv, q, ldq,
                iwork, tau, work,
                lwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sggsvp_work(Layout layout, char jobu, char jobv,
            char jobq, int m, int p,
            int n, float[] a, int lda,
            float[] b, int ldb, float tola,
            float tolb, int[] k, int[] l,
            float[] u, int ldu, float[] v,
            int ldv, float[] q, int ldq,
            int[] iwork, float[] tau, float[] work);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sggsvp_work(Layout layout, char jobu, char jobv,
            char jobq, int m, int p,
            int n, float[] a, int lda,
            float[] b, int ldb, float tola,
            float tolb, int[] k, int[] l,
            float[] u, int ldu, float[] v,
            int ldv, float[] q, int ldq,
            int[] iwork, float[] tau, float[] work)
            => LAPACKE_sggsvp_work(layout, jobu, jobv,
                jobq, m, p,
                n, a, lda,
                b, ldb, tola,
                tolb, k, l,
                u, ldu, v,
                ldv, q, ldq,
                iwork, tau, work);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgtcon(Norm norm, int n, float[] dl,
            float[] d, float[] du, float[] du2,
            int[] ipiv, float anorm, float[] rcond);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sgtcon(Norm norm, int n, float[] dl,
            float[] d, float[] du, float[] du2,
            int[] ipiv, float anorm, float[] rcond)
            => LAPACKE_sgtcon(norm, n, dl,
                d, du, du2,
                ipiv, anorm, rcond);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgtcon_work(Norm norm, int n, float[] dl,
            float[] d, float[] du,
            float[] du2, int[] ipiv,
            float anorm, float[] rcond, float[] work,
            int[] iwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sgtcon_work(Norm norm, int n, float[] dl,
            float[] d, float[] du,
            float[] du2, int[] ipiv,
            float anorm, float[] rcond, float[] work,
            int[] iwork)
            => LAPACKE_sgtcon_work(norm, n, dl,
                d, du,
                du2, ipiv,
                anorm, rcond, work,
                iwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgtrfs(Layout layout, TransChar trans, int n,
            int nrhs, float[] dl, float[] d,
            float[] du, float[] dlf, float[] df,
            float[] duf, float[] du2,
            int[] ipiv, float[] b,
            int ldb, float[] x, int ldx,
            float[] ferr, float[] berr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sgtrfs(Layout layout, TransChar trans, int n,
            int nrhs, float[] dl, float[] d,
            float[] du, float[] dlf, float[] df,
            float[] duf, float[] du2,
            int[] ipiv, float[] b,
            int ldb, float[] x, int ldx,
            float[] ferr, float[] berr)
            => LAPACKE_sgtrfs(layout, trans, n,
                nrhs, dl, d,
                du, dlf, df,
                duf, du2,
                ipiv, b,
                ldb, x, ldx,
                ferr, berr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgtrfs_work(Layout layout, TransChar trans, int n,
            int nrhs, float[] dl,
            float[] d, float[] du,
            float[] dlf, float[] df,
            float[] duf, float[] du2,
            int[] ipiv, float[] b,
            int ldb, float[] x, int ldx,
            float[] ferr, float[] berr, float[] work,
            int[] iwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sgtrfs_work(Layout layout, TransChar trans, int n,
            int nrhs, float[] dl,
            float[] d, float[] du,
            float[] dlf, float[] df,
            float[] duf, float[] du2,
            int[] ipiv, float[] b,
            int ldb, float[] x, int ldx,
            float[] ferr, float[] berr, float[] work,
            int[] iwork)
            => LAPACKE_sgtrfs_work(layout, trans, n,
                nrhs, dl,
                d, du,
                dlf, df,
                duf, du2,
                ipiv, b,
                ldb, x, ldx,
                ferr, berr, work,
                iwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgtsv(Layout layout, int n, int nrhs,
            float[] dl, float[] d, float[] du, float[] b,
            int ldb);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sgtsv(Layout layout, int n, int nrhs,
            float[] dl, float[] d, float[] du, float[] b,
            int ldb)
            => LAPACKE_sgtsv(layout, n, nrhs,
                dl, d, du, b,
                ldb);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgtsv_work(Layout layout, int n, int nrhs,
            float[] dl, float[] d, float[] du, float[] b,
            int ldb);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sgtsv_work(Layout layout, int n, int nrhs,
            float[] dl, float[] d, float[] du, float[] b,
            int ldb)
            => LAPACKE_sgtsv_work(layout, n, nrhs,
                dl, d, du, b,
                ldb);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgtsvx(Layout layout, char fact, TransChar trans,
            int n, int nrhs, float[] dl,
            float[] d, float[] du, float[] dlf,
            float[] df, float[] duf, float[] du2, int[] ipiv,
            float[] b, int ldb, float[] x,
            int ldx, float[] rcond, float[] ferr,
            float[] berr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sgtsvx(Layout layout, char fact, TransChar trans,
            int n, int nrhs, float[] dl,
            float[] d, float[] du, float[] dlf,
            float[] df, float[] duf, float[] du2, int[] ipiv,
            float[] b, int ldb, float[] x,
            int ldx, float[] rcond, float[] ferr,
            float[] berr)
            => LAPACKE_sgtsvx(layout, fact, trans,
                n, nrhs, dl,
                d, du, dlf,
                df, duf, du2, ipiv,
                b, ldb, x,
                ldx, rcond, ferr,
                berr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgtsvx_work(Layout layout, char fact, TransChar trans,
            int n, int nrhs, float[] dl,
            float[] d, float[] du, float[] dlf,
            float[] df, float[] duf, float[] du2,
            int[] ipiv, float[] b,
            int ldb, float[] x, int ldx,
            float[] rcond, float[] ferr, float[] berr,
            float[] work, int[] iwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sgtsvx_work(Layout layout, char fact, TransChar trans,
            int n, int nrhs, float[] dl,
            float[] d, float[] du, float[] dlf,
            float[] df, float[] duf, float[] du2,
            int[] ipiv, float[] b,
            int ldb, float[] x, int ldx,
            float[] rcond, float[] ferr, float[] berr,
            float[] work, int[] iwork)
            => LAPACKE_sgtsvx_work(layout, fact, trans,
                n, nrhs, dl,
                d, du, dlf,
                df, duf, du2,
                ipiv, b,
                ldb, x, ldx,
                rcond, ferr, berr,
                work, iwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgttrf(int n, float[] dl, float[] d, float[] du,
            float[] du2, int[] ipiv);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sgttrf(int n, float[] dl, float[] d, float[] du,
            float[] du2, int[] ipiv)
            => LAPACKE_sgttrf(n, dl, d, du,
                du2, ipiv);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgttrf_work(int n, float[] dl, float[] d, float[] du,
            float[] du2, int[] ipiv);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sgttrf_work(int n, float[] dl, float[] d, float[] du,
            float[] du2, int[] ipiv)
            => LAPACKE_sgttrf_work(n, dl, d, du,
                du2, ipiv);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgttrs(Layout layout, TransChar trans, int n,
            int nrhs, float[] dl, float[] d,
            float[] du, float[] du2,
            int[] ipiv, float[] b, int ldb);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sgttrs(Layout layout, TransChar trans, int n,
            int nrhs, float[] dl, float[] d,
            float[] du, float[] du2,
            int[] ipiv, float[] b, int ldb)
            => LAPACKE_sgttrs(layout, trans, n,
                nrhs, dl, d,
                du, du2,
                ipiv, b, ldb);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgttrs_work(Layout layout, TransChar trans, int n,
            int nrhs, float[] dl,
            float[] d, float[] du,
            float[] du2, int[] ipiv,
            float[] b, int ldb);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sgttrs_work(Layout layout, TransChar trans, int n,
            int nrhs, float[] dl,
            float[] d, float[] du,
            float[] du2, int[] ipiv,
            float[] b, int ldb)
            => LAPACKE_sgttrs_work(layout, trans, n,
                nrhs, dl,
                d, du,
                du2, ipiv,
                b, ldb);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_shgeqz(Layout layout, char job, char compq, char compz,
            int n, int ilo, int ihi,
            float[] h, int ldh, float[] t, int ldt,
            float[] alphar, float[] alphai, float[] beta, float[] q,
            int ldq, float[] z, int ldz);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int shgeqz(Layout layout, char job, char compq, char compz,
            int n, int ilo, int ihi,
            float[] h, int ldh, float[] t, int ldt,
            float[] alphar, float[] alphai, float[] beta, float[] q,
            int ldq, float[] z, int ldz)
            => LAPACKE_shgeqz(layout, job, compq, compz,
                n, ilo, ihi,
                h, ldh, t, ldt,
                alphar, alphai, beta, q,
                ldq, z, ldz);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_shgeqz_work(Layout layout, char job, char compq,
            char compz, int n, int ilo,
            int ihi, float[] h, int ldh,
            float[] t, int ldt, float[] alphar,
            float[] alphai, float[] beta, float[] q,
            int ldq, float[] z, int ldz,
            float[] work, int lwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int shgeqz_work(Layout layout, char job, char compq,
            char compz, int n, int ilo,
            int ihi, float[] h, int ldh,
            float[] t, int ldt, float[] alphar,
            float[] alphai, float[] beta, float[] q,
            int ldq, float[] z, int ldz,
            float[] work, int lwork)
            => LAPACKE_shgeqz_work(layout, job, compq,
                compz, n, ilo,
                ihi, h, ldh,
                t, ldt, alphar,
                alphai, beta, q,
                ldq, z, ldz,
                work, lwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_shsein(Layout layout, char job, char eigsrc, char initv,
            int[] select, int n, float[] h,
            int ldh, float[] wr, float[] wi,
            float[] vl, int ldvl, float[] vr,
            int ldvr, int mm, int[] m,
            int[] ifaill, int[] ifailr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int shsein(Layout layout, char job, char eigsrc, char initv,
            int[] select, int n, float[] h,
            int ldh, float[] wr, float[] wi,
            float[] vl, int ldvl, float[] vr,
            int ldvr, int mm, int[] m,
            int[] ifaill, int[] ifailr)
            => LAPACKE_shsein(layout, job, eigsrc, initv,
                select, n, h,
                ldh, wr, wi,
                vl, ldvl, vr,
                ldvr, mm, m,
                ifaill, ifailr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_shsein_work(Layout layout, char job, char eigsrc,
            char initv, int[] select,
            int n, float[] h, int ldh,
            float[] wr, float[] wi, float[] vl,
            int ldvl, float[] vr, int ldvr,
            int mm, int[] m, float[] work,
            int[] ifaill, int[] ifailr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int shsein_work(Layout layout, char job, char eigsrc,
            char initv, int[] select,
            int n, float[] h, int ldh,
            float[] wr, float[] wi, float[] vl,
            int ldvl, float[] vr, int ldvr,
            int mm, int[] m, float[] work,
            int[] ifaill, int[] ifailr)
            => LAPACKE_shsein_work(layout, job, eigsrc,
                initv, select,
                n, h, ldh,
                wr, wi, vl,
                ldvl, vr, ldvr,
                mm, m, work,
                ifaill, ifailr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_shseqr(Layout layout, char job, char compz, int n,
            int ilo, int ihi, float[] h,
            int ldh, float[] wr, float[] wi, float[] z,
            int ldz);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int shseqr(Layout layout, char job, char compz, int n,
            int ilo, int ihi, float[] h,
            int ldh, float[] wr, float[] wi, float[] z,
            int ldz)
            => LAPACKE_shseqr(layout, job, compz, n,
                ilo, ihi, h,
                ldh, wr, wi, z,
                ldz);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_shseqr_work(Layout layout, char job, char compz,
            int n, int ilo, int ihi,
            float[] h, int ldh, float[] wr, float[] wi,
            float[] z, int ldz, float[] work,
            int lwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int shseqr_work(Layout layout, char job, char compz,
            int n, int ilo, int ihi,
            float[] h, int ldh, float[] wr, float[] wi,
            float[] z, int ldz, float[] work,
            int lwork)
            => LAPACKE_shseqr_work(layout, job, compz,
                n, ilo, ihi,
                h, ldh, wr, wi,
                z, ldz, work,
                lwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_slacn2(int n, float[] v, float[] x, int[] isgn,
            float[] est, int[] kase, int[] isave);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int slacn2(int n, float[] v, float[] x, int[] isgn,
            float[] est, int[] kase, int[] isave)
            => LAPACKE_slacn2(n, v, x, isgn,
                est, kase, isave);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_slacn2_work(int n, float[] v, float[] x,
            int[] isgn, float[] est, int[] kase,
            int[] isave);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int slacn2_work(int n, float[] v, float[] x,
            int[] isgn, float[] est, int[] kase,
            int[] isave)
            => LAPACKE_slacn2_work(n, v, x,
                isgn, est, kase,
                isave);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_slacpy(Layout layout, UpLo uplo, int m,
            int n, float[] a, int lda,
            float[] b, int ldb);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int slacpy(Layout layout, UpLo uplo, int m,
            int n, float[] a, int lda,
            float[] b, int ldb)
            => LAPACKE_slacpy(layout, uplo, m,
                n, a, lda,
                b, ldb);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_slacpy_work(Layout layout, UpLo uplo, int m,
            int n, float[] a, int lda,
            float[] b, int ldb);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int slacpy_work(Layout layout, UpLo uplo, int m,
            int n, float[] a, int lda,
            float[] b, int ldb)
            => LAPACKE_slacpy_work(layout, uplo, m,
                n, a, lda,
                b, ldb);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_slag2d(Layout layout, int m, int n,
            float[] sa, int ldsa, double[] a,
            int lda);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int slag2d(Layout layout, int m, int n,
            float[] sa, int ldsa, double[] a,
            int lda)
            => LAPACKE_slag2d(layout, m, n,
                sa, ldsa, a,
                lda);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_slag2d_work(Layout layout, int m, int n,
            float[] sa, int ldsa, double[] a,
            int lda);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int slag2d_work(Layout layout, int m, int n,
            float[] sa, int ldsa, double[] a,
            int lda)
            => LAPACKE_slag2d_work(layout, m, n,
                sa, ldsa, a,
                lda);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_slagge(Layout layout, int m, int n,
            int kl, int ku, float[] d,
            float[] a, int lda, int[] iseed);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int slagge(Layout layout, int m, int n,
            int kl, int ku, float[] d,
            float[] a, int lda, int[] iseed)
            => LAPACKE_slagge(layout, m, n,
                kl, ku, d,
                a, lda, iseed);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_slagge_work(Layout layout, int m, int n,
            int kl, int ku, float[] d,
            float[] a, int lda, int[] iseed,
            float[] work);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int slagge_work(Layout layout, int m, int n,
            int kl, int ku, float[] d,
            float[] a, int lda, int[] iseed,
            float[] work)
            => LAPACKE_slagge_work(layout, m, n,
                kl, ku, d,
                a, lda, iseed,
                work);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_slagsy(Layout layout, int n, int k,
            float[] d, float[] a, int lda,
            int[] iseed);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int slagsy(Layout layout, int n, int k,
            float[] d, float[] a, int lda,
            int[] iseed)
            => LAPACKE_slagsy(layout, n, k,
                d, a, lda,
                iseed);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_slagsy_work(Layout layout, int n, int k,
            float[] d, float[] a, int lda,
            int[] iseed, float[] work);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int slagsy_work(Layout layout, int n, int k,
            float[] d, float[] a, int lda,
            int[] iseed, float[] work)
            => LAPACKE_slagsy_work(layout, n, k,
                d, a, lda,
                iseed, work);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_slapmr(Layout layout, int forwrd,
            int m, int n, float[] x, int ldx,
            int[] k);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int slapmr(Layout layout, int forwrd,
            int m, int n, float[] x, int ldx,
            int[] k)
            => LAPACKE_slapmr(layout, forwrd,
                m, n, x, ldx,
                k);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_slapmr_work(Layout layout, int forwrd,
            int m, int n, float[] x,
            int ldx, int[] k);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int slapmr_work(Layout layout, int forwrd,
            int m, int n, float[] x,
            int ldx, int[] k)
            => LAPACKE_slapmr_work(layout, forwrd,
                m, n, x,
                ldx, k);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_slapmt(Layout layout, int forwrd,
            int m, int n, float[] x, int ldx,
            int[] k);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int slapmt(Layout layout, int forwrd,
            int m, int n, float[] x, int ldx,
            int[] k)
            => LAPACKE_slapmt(layout, forwrd,
                m, n, x, ldx,
                k);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_slapmt_work(Layout layout, int forwrd,
            int m, int n, float[] x,
            int ldx, int[] k);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int slapmt_work(Layout layout, int forwrd,
            int m, int n, float[] x,
            int ldx, int[] k)
            => LAPACKE_slapmt_work(layout, forwrd,
                m, n, x,
                ldx, k);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_slarfb(Layout layout, char side, TransChar trans, char direct,
            char storev, int m, int n,
            int k, float[] v, int ldv,
            float[] t, int ldt, float[] c,
            int ldc);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int slarfb(Layout layout, char side, TransChar trans, char direct,
            char storev, int m, int n,
            int k, float[] v, int ldv,
            float[] t, int ldt, float[] c,
            int ldc)
            => LAPACKE_slarfb(layout, side, trans, direct,
                storev, m, n,
                k, v, ldv,
                t, ldt, c,
                ldc);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_slarfb_work(Layout layout, char side, TransChar trans,
            char direct, char storev, int m,
            int n, int k, float[] v,
            int ldv, float[] t, int ldt,
            float[] c, int ldc, float[] work,
            int ldwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int slarfb_work(Layout layout, char side, TransChar trans,
            char direct, char storev, int m,
            int n, int k, float[] v,
            int ldv, float[] t, int ldt,
            float[] c, int ldc, float[] work,
            int ldwork)
            => LAPACKE_slarfb_work(layout, side, trans,
                direct, storev, m,
                n, k, v,
                ldv, t, ldt,
                c, ldc, work,
                ldwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_slarfg(int n, float[] alpha, float[] x,
            int incx, float[] tau);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int slarfg(int n, float[] alpha, float[] x,
            int incx, float[] tau)
            => LAPACKE_slarfg(n, alpha, x,
                incx, tau);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_slarfg_work(int n, float[] alpha, float[] x,
            int incx, float[] tau);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int slarfg_work(int n, float[] alpha, float[] x,
            int incx, float[] tau)
            => LAPACKE_slarfg_work(n, alpha, x,
                incx, tau);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_slarft(Layout layout, char direct, char storev,
            int n, int k, float[] v,
            int ldv, float[] tau, float[] t,
            int ldt);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int slarft(Layout layout, char direct, char storev,
            int n, int k, float[] v,
            int ldv, float[] tau, float[] t,
            int ldt)
            => LAPACKE_slarft(layout, direct, storev,
                n, k, v,
                ldv, tau, t,
                ldt);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_slarft_work(Layout layout, char direct, char storev,
            int n, int k, float[] v,
            int ldv, float[] tau, float[] t,
            int ldt);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int slarft_work(Layout layout, char direct, char storev,
            int n, int k, float[] v,
            int ldv, float[] tau, float[] t,
            int ldt)
            => LAPACKE_slarft_work(layout, direct, storev,
                n, k, v,
                ldv, tau, t,
                ldt);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_slarfx(Layout layout, char side, int m,
            int n, float[] v, float tau, float[] c,
            int ldc, float[] work);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int slarfx(Layout layout, char side, int m,
            int n, float[] v, float tau, float[] c,
            int ldc, float[] work)
            => LAPACKE_slarfx(layout, side, m,
                n, v, tau, c,
                ldc, work);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_slarfx_work(Layout layout, char side, int m,
            int n, float[] v, float tau,
            float[] c, int ldc, float[] work);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int slarfx_work(Layout layout, char side, int m,
            int n, float[] v, float tau,
            float[] c, int ldc, float[] work)
            => LAPACKE_slarfx_work(layout, side, m,
                n, v, tau,
                c, ldc, work);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_slarnv(int idist, int[] iseed, int n,
            float[] x);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int slarnv(int idist, int[] iseed, int n,
            float[] x)
            => LAPACKE_slarnv(idist, iseed, n,
                x);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_slarnv_work(int idist, int[] iseed,
            int n, float[] x);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int slarnv_work(int idist, int[] iseed,
            int n, float[] x)
            => LAPACKE_slarnv_work(idist, iseed,
                n, x);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_slartgp(float f, float g, float[] cs, float[] sn, float[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int slartgp(float f, float g, float[] cs, float[] sn, float[] r)
            => LAPACKE_slartgp(f, g, cs, sn, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_slartgp_work(float f, float g, float[] cs, float[] sn,
            float[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int slartgp_work(float f, float g, float[] cs, float[] sn,
            float[] r)
            => LAPACKE_slartgp_work(f, g, cs, sn,
                r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_slartgs(float x, float y, float sigma, float[] cs,
            float[] sn);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int slartgs(float x, float y, float sigma, float[] cs,
            float[] sn)
            => LAPACKE_slartgs(x, y, sigma, cs,
                sn);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_slartgs_work(float x, float y, float sigma, float[] cs,
            float[] sn);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int slartgs_work(float x, float y, float sigma, float[] cs,
            float[] sn)
            => LAPACKE_slartgs_work(x, y, sigma, cs,
                sn);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_slascl(Layout layout, char type, int kl,
            int ku, float cfrom, float cto,
            int m, int n, float[] a,
            int lda);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int slascl(Layout layout, char type, int kl,
            int ku, float cfrom, float cto,
            int m, int n, float[] a,
            int lda)
            => LAPACKE_slascl(layout, type, kl,
                ku, cfrom, cto,
                m, n, a,
                lda);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_slascl_work(Layout layout, char type, int kl,
            int ku, float cfrom, float cto,
            int m, int n, float[] a,
            int lda);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int slascl_work(Layout layout, char type, int kl,
            int ku, float cfrom, float cto,
            int m, int n, float[] a,
            int lda)
            => LAPACKE_slascl_work(layout, type, kl,
                ku, cfrom, cto,
                m, n, a,
                lda);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_slaset(Layout layout, UpLo uplo, int m,
            int n, float alpha, float beta, float[] a,
            int lda);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int slaset(Layout layout, UpLo uplo, int m,
            int n, float alpha, float beta, float[] a,
            int lda)
            => LAPACKE_slaset(layout, uplo, m,
                n, alpha, beta, a,
                lda);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_slaset_work(Layout layout, UpLo uplo, int m,
            int n, float alpha, float beta, float[] a,
            int lda);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int slaset_work(Layout layout, UpLo uplo, int m,
            int n, float alpha, float beta, float[] a,
            int lda)
            => LAPACKE_slaset_work(layout, uplo, m,
                n, alpha, beta, a,
                lda);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_slasrt(char id, int n, float[] d);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int slasrt(char id, int n, float[] d)
            => LAPACKE_slasrt(id, n, d);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_slasrt_work(char id, int n, float[] d);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int slasrt_work(char id, int n, float[] d)
            => LAPACKE_slasrt_work(id, n, d);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_slaswp(Layout layout, int n, float[] a,
            int lda, int k1, int k2,
            int[] ipiv, int incx);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int slaswp(Layout layout, int n, float[] a,
            int lda, int k1, int k2,
            int[] ipiv, int incx)
            => LAPACKE_slaswp(layout, n, a,
                lda, k1, k2,
                ipiv, incx);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_slaswp_work(Layout layout, int n, float[] a,
            int lda, int k1, int k2,
            int[] ipiv, int incx);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int slaswp_work(Layout layout, int n, float[] a,
            int lda, int k1, int k2,
            int[] ipiv, int incx)
            => LAPACKE_slaswp_work(layout, n, a,
                lda, k1, k2,
                ipiv, incx);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_slatms(Layout layout, int m, int n,
            char dist, int[] iseed, char sym, float[] d,
            int mode, float cond, float dmax,
            int kl, int ku, char pack, float[] a,
            int lda);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int slatms(Layout layout, int m, int n,
            char dist, int[] iseed, char sym, float[] d,
            int mode, float cond, float dmax,
            int kl, int ku, char pack, float[] a,
            int lda)
            => LAPACKE_slatms(layout, m, n,
                dist, iseed, sym, d,
                mode, cond, dmax,
                kl, ku, pack, a,
                lda);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_slatms_work(Layout layout, int m, int n,
            char dist, int[] iseed, char sym,
            float[] d, int mode, float cond,
            float dmax, int kl, int ku,
            char pack, float[] a, int lda,
            float[] work);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int slatms_work(Layout layout, int m, int n,
            char dist, int[] iseed, char sym,
            float[] d, int mode, float cond,
            float dmax, int kl, int ku,
            char pack, float[] a, int lda,
            float[] work)
            => LAPACKE_slatms_work(layout, m, n,
                dist, iseed, sym,
                d, mode, cond,
                dmax, kl, ku,
                pack, a, lda,
                work);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_slauum(Layout layout, UpLo uplo, int n, float[] a,
            int lda);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int slauum(Layout layout, UpLo uplo, int n, float[] a,
            int lda)
            => LAPACKE_slauum(layout, uplo, n, a,
                lda);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_slauum_work(Layout layout, UpLo uplo, int n,
            float[] a, int lda);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int slauum_work(Layout layout, UpLo uplo, int n,
            float[] a, int lda)
            => LAPACKE_slauum_work(layout, uplo, n,
                a, lda);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sopgtr(Layout layout, UpLo uplo, int n,
            float[] ap, float[] tau, float[] q,
            int ldq);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sopgtr(Layout layout, UpLo uplo, int n,
            float[] ap, float[] tau, float[] q,
            int ldq)
            => LAPACKE_sopgtr(layout, uplo, n,
                ap, tau, q,
                ldq);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sopgtr_work(Layout layout, UpLo uplo, int n,
            float[] ap, float[] tau, float[] q,
            int ldq, float[] work);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sopgtr_work(Layout layout, UpLo uplo, int n,
            float[] ap, float[] tau, float[] q,
            int ldq, float[] work)
            => LAPACKE_sopgtr_work(layout, uplo, n,
                ap, tau, q,
                ldq, work);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sopmtr(Layout layout, char side, UpLo uplo, TransChar trans,
            int m, int n, float[] ap,
            float[] tau, float[] c, int ldc);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sopmtr(Layout layout, char side, UpLo uplo, TransChar trans,
            int m, int n, float[] ap,
            float[] tau, float[] c, int ldc)
            => LAPACKE_sopmtr(layout, side, uplo, trans,
                m, n, ap,
                tau, c, ldc);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sopmtr_work(Layout layout, char side, UpLo uplo,
            TransChar trans, int m, int n,
            float[] ap, float[] tau, float[] c,
            int ldc, float[] work);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sopmtr_work(Layout layout, char side, UpLo uplo,
            TransChar trans, int m, int n,
            float[] ap, float[] tau, float[] c,
            int ldc, float[] work)
            => LAPACKE_sopmtr_work(layout, side, uplo,
                trans, m, n,
                ap, tau, c,
                ldc, work);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sorbdb(Layout layout, TransChar trans, char signs,
            int m, int p, int q, float[] x11,
            int ldx11, float[] x12, int ldx12,
            float[] x21, int ldx21, float[] x22,
            int ldx22, float[] theta, float[] phi,
            float[] taup1, float[] taup2, float[] tauq1,
            float[] tauq2);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sorbdb(Layout layout, TransChar trans, char signs,
            int m, int p, int q, float[] x11,
            int ldx11, float[] x12, int ldx12,
            float[] x21, int ldx21, float[] x22,
            int ldx22, float[] theta, float[] phi,
            float[] taup1, float[] taup2, float[] tauq1,
            float[] tauq2)
            => LAPACKE_sorbdb(layout, trans, signs,
                m, p, q, x11,
                ldx11, x12, ldx12,
                x21, ldx21, x22,
                ldx22, theta, phi,
                taup1, taup2, tauq1,
                tauq2);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sorbdb_work(Layout layout, TransChar trans, char signs,
            int m, int p, int q,
            float[] x11, int ldx11, float[] x12,
            int ldx12, float[] x21, int ldx21,
            float[] x22, int ldx22, float[] theta,
            float[] phi, float[] taup1, float[] taup2,
            float[] tauq1, float[] tauq2, float[] work,
            int lwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sorbdb_work(Layout layout, TransChar trans, char signs,
            int m, int p, int q,
            float[] x11, int ldx11, float[] x12,
            int ldx12, float[] x21, int ldx21,
            float[] x22, int ldx22, float[] theta,
            float[] phi, float[] taup1, float[] taup2,
            float[] tauq1, float[] tauq2, float[] work,
            int lwork)
            => LAPACKE_sorbdb_work(layout, trans, signs,
                m, p, q,
                x11, ldx11, x12,
                ldx12, x21, ldx21,
                x22, ldx22, theta,
                phi, taup1, taup2,
                tauq1, tauq2, work,
                lwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sorcsd(Layout layout, char jobu1, char jobu2,
            char jobv1t, char jobv2t, TransChar trans, char signs,
            int m, int p, int q, float[] x11,
            int ldx11, float[] x12, int ldx12,
            float[] x21, int ldx21, float[] x22,
            int ldx22, float[] theta, float[] u1,
            int ldu1, float[] u2, int ldu2,
            float[] v1t, int ldv1t, float[] v2t,
            int ldv2t);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sorcsd(Layout layout, char jobu1, char jobu2,
            char jobv1t, char jobv2t, TransChar trans, char signs,
            int m, int p, int q, float[] x11,
            int ldx11, float[] x12, int ldx12,
            float[] x21, int ldx21, float[] x22,
            int ldx22, float[] theta, float[] u1,
            int ldu1, float[] u2, int ldu2,
            float[] v1t, int ldv1t, float[] v2t,
            int ldv2t)
            => LAPACKE_sorcsd(layout, jobu1, jobu2,
                jobv1t, jobv2t, trans, signs,
                m, p, q, x11,
                ldx11, x12, ldx12,
                x21, ldx21, x22,
                ldx22, theta, u1,
                ldu1, u2, ldu2,
                v1t, ldv1t, v2t,
                ldv2t);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sorcsd2by1(Layout layout, char jobu1, char jobu2,
            char jobv1t, int m, int p, int q,
            float[] x11, int ldx11, float[] x21, int ldx21,
            float[] theta, float[] u1, int ldu1, float[] u2,
            int ldu2, float[] v1t, int ldv1t);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sorcsd2by1(Layout layout, char jobu1, char jobu2,
            char jobv1t, int m, int p, int q,
            float[] x11, int ldx11, float[] x21, int ldx21,
            float[] theta, float[] u1, int ldu1, float[] u2,
            int ldu2, float[] v1t, int ldv1t)
            => LAPACKE_sorcsd2by1(layout, jobu1, jobu2,
                jobv1t, m, p, q,
                x11, ldx11, x21, ldx21,
                theta, u1, ldu1, u2,
                ldu2, v1t, ldv1t);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sorcsd2by1_work(Layout layout, char jobu1, char jobu2,
            char jobv1t, int m, int p,
            int q, float[] x11, int ldx11,
            float[] x21, int ldx21,
            float[] theta, float[] u1, int ldu1,
            float[] u2, int ldu2, float[] v1t,
            int ldv1t, float[] work, int lwork,
            int[] iwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sorcsd2by1_work(Layout layout, char jobu1, char jobu2,
            char jobv1t, int m, int p,
            int q, float[] x11, int ldx11,
            float[] x21, int ldx21,
            float[] theta, float[] u1, int ldu1,
            float[] u2, int ldu2, float[] v1t,
            int ldv1t, float[] work, int lwork,
            int[] iwork)
            => LAPACKE_sorcsd2by1_work(layout, jobu1, jobu2,
                jobv1t, m, p,
                q, x11, ldx11,
                x21, ldx21,
                theta, u1, ldu1,
                u2, ldu2, v1t,
                ldv1t, work, lwork,
                iwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sorcsd_work(Layout layout, char jobu1, char jobu2,
            char jobv1t, char jobv2t, TransChar trans,
            char signs, int m, int p,
            int q, float[] x11, int ldx11,
            float[] x12, int ldx12, float[] x21,
            int ldx21, float[] x22, int ldx22,
            float[] theta, float[] u1, int ldu1,
            float[] u2, int ldu2, float[] v1t,
            int ldv1t, float[] v2t, int ldv2t,
            float[] work, int lwork,
            int[] iwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sorcsd_work(Layout layout, char jobu1, char jobu2,
            char jobv1t, char jobv2t, TransChar trans,
            char signs, int m, int p,
            int q, float[] x11, int ldx11,
            float[] x12, int ldx12, float[] x21,
            int ldx21, float[] x22, int ldx22,
            float[] theta, float[] u1, int ldu1,
            float[] u2, int ldu2, float[] v1t,
            int ldv1t, float[] v2t, int ldv2t,
            float[] work, int lwork,
            int[] iwork)
            => LAPACKE_sorcsd_work(layout, jobu1, jobu2,
                jobv1t, jobv2t, trans,
                signs, m, p,
                q, x11, ldx11,
                x12, ldx12, x21,
                ldx21, x22, ldx22,
                theta, u1, ldu1,
                u2, ldu2, v1t,
                ldv1t, v2t, ldv2t,
                work, lwork,
                iwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sorgbr(Layout layout, char vect, int m,
            int n, int k, float[] a, int lda,
            float[] tau);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sorgbr(Layout layout, char vect, int m,
            int n, int k, float[] a, int lda,
            float[] tau)
            => LAPACKE_sorgbr(layout, vect, m,
                n, k, a, lda,
                tau);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sorgbr_work(Layout layout, char vect, int m,
            int n, int k, float[] a,
            int lda, float[] tau, float[] work,
            int lwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sorgbr_work(Layout layout, char vect, int m,
            int n, int k, float[] a,
            int lda, float[] tau, float[] work,
            int lwork)
            => LAPACKE_sorgbr_work(layout, vect, m,
                n, k, a,
                lda, tau, work,
                lwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sorghr(Layout layout, int n, int ilo,
            int ihi, float[] a, int lda,
            float[] tau);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sorghr(Layout layout, int n, int ilo,
            int ihi, float[] a, int lda,
            float[] tau)
            => LAPACKE_sorghr(layout, n, ilo,
                ihi, a, lda,
                tau);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sorghr_work(Layout layout, int n, int ilo,
            int ihi, float[] a, int lda,
            float[] tau, float[] work,
            int lwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sorghr_work(Layout layout, int n, int ilo,
            int ihi, float[] a, int lda,
            float[] tau, float[] work,
            int lwork)
            => LAPACKE_sorghr_work(layout, n, ilo,
                ihi, a, lda,
                tau, work,
                lwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sorglq(Layout layout, int m, int n,
            int k, float[] a, int lda,
            float[] tau);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sorglq(Layout layout, int m, int n,
            int k, float[] a, int lda,
            float[] tau)
            => LAPACKE_sorglq(layout, m, n,
                k, a, lda,
                tau);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sorglq_work(Layout layout, int m, int n,
            int k, float[] a, int lda,
            float[] tau, float[] work,
            int lwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sorglq_work(Layout layout, int m, int n,
            int k, float[] a, int lda,
            float[] tau, float[] work,
            int lwork)
            => LAPACKE_sorglq_work(layout, m, n,
                k, a, lda,
                tau, work,
                lwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sorgql(Layout layout, int m, int n,
            int k, float[] a, int lda,
            float[] tau);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sorgql(Layout layout, int m, int n,
            int k, float[] a, int lda,
            float[] tau)
            => LAPACKE_sorgql(layout, m, n,
                k, a, lda,
                tau);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sorgql_work(Layout layout, int m, int n,
            int k, float[] a, int lda,
            float[] tau, float[] work,
            int lwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sorgql_work(Layout layout, int m, int n,
            int k, float[] a, int lda,
            float[] tau, float[] work,
            int lwork)
            => LAPACKE_sorgql_work(layout, m, n,
                k, a, lda,
                tau, work,
                lwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sorgqr(Layout layout, int m, int n,
            int k, float[] a, int lda,
            float[] tau);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sorgqr(Layout layout, int m, int n,
            int k, float[] a, int lda,
            float[] tau)
            => LAPACKE_sorgqr(layout, m, n,
                k, a, lda,
                tau);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sorgqr_work(Layout layout, int m, int n,
            int k, float[] a, int lda,
            float[] tau, float[] work,
            int lwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sorgqr_work(Layout layout, int m, int n,
            int k, float[] a, int lda,
            float[] tau, float[] work,
            int lwork)
            => LAPACKE_sorgqr_work(layout, m, n,
                k, a, lda,
                tau, work,
                lwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sorgrq(Layout layout, int m, int n,
            int k, float[] a, int lda,
            float[] tau);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sorgrq(Layout layout, int m, int n,
            int k, float[] a, int lda,
            float[] tau)
            => LAPACKE_sorgrq(layout, m, n,
                k, a, lda,
                tau);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sorgrq_work(Layout layout, int m, int n,
            int k, float[] a, int lda,
            float[] tau, float[] work,
            int lwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sorgrq_work(Layout layout, int m, int n,
            int k, float[] a, int lda,
            float[] tau, float[] work,
            int lwork)
            => LAPACKE_sorgrq_work(layout, m, n,
                k, a, lda,
                tau, work,
                lwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sorgtr(Layout layout, UpLo uplo, int n, float[] a,
            int lda, float[] tau);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sorgtr(Layout layout, UpLo uplo, int n, float[] a,
            int lda, float[] tau)
            => LAPACKE_sorgtr(layout, uplo, n, a,
                lda, tau);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sorgtr_work(Layout layout, UpLo uplo, int n,
            float[] a, int lda, float[] tau,
            float[] work, int lwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sorgtr_work(Layout layout, UpLo uplo, int n,
            float[] a, int lda, float[] tau,
            float[] work, int lwork)
            => LAPACKE_sorgtr_work(layout, uplo, n,
                a, lda, tau,
                work, lwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sormbr(Layout layout, char vect, char side, TransChar trans,
            int m, int n, int k,
            float[] a, int lda, float[] tau,
            float[] c, int ldc);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sormbr(Layout layout, char vect, char side, TransChar trans,
            int m, int n, int k,
            float[] a, int lda, float[] tau,
            float[] c, int ldc)
            => LAPACKE_sormbr(layout, vect, side, trans,
                m, n, k,
                a, lda, tau,
                c, ldc);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sormbr_work(Layout layout, char vect, char side,
            TransChar trans, int m, int n,
            int k, float[] a, int lda,
            float[] tau, float[] c, int ldc,
            float[] work, int lwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sormbr_work(Layout layout, char vect, char side,
            TransChar trans, int m, int n,
            int k, float[] a, int lda,
            float[] tau, float[] c, int ldc,
            float[] work, int lwork)
            => LAPACKE_sormbr_work(layout, vect, side,
                trans, m, n,
                k, a, lda,
                tau, c, ldc,
                work, lwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sormhr(Layout layout, char side, TransChar trans,
            int m, int n, int ilo,
            int ihi, float[] a, int lda,
            float[] tau, float[] c, int ldc);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sormhr(Layout layout, char side, TransChar trans,
            int m, int n, int ilo,
            int ihi, float[] a, int lda,
            float[] tau, float[] c, int ldc)
            => LAPACKE_sormhr(layout, side, trans,
                m, n, ilo,
                ihi, a, lda,
                tau, c, ldc);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sormhr_work(Layout layout, char side, TransChar trans,
            int m, int n, int ilo,
            int ihi, float[] a, int lda,
            float[] tau, float[] c, int ldc,
            float[] work, int lwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sormhr_work(Layout layout, char side, TransChar trans,
            int m, int n, int ilo,
            int ihi, float[] a, int lda,
            float[] tau, float[] c, int ldc,
            float[] work, int lwork)
            => LAPACKE_sormhr_work(layout, side, trans,
                m, n, ilo,
                ihi, a, lda,
                tau, c, ldc,
                work, lwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sormlq(Layout layout, char side, TransChar trans,
            int m, int n, int k,
            float[] a, int lda, float[] tau,
            float[] c, int ldc);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sormlq(Layout layout, char side, TransChar trans,
            int m, int n, int k,
            float[] a, int lda, float[] tau,
            float[] c, int ldc)
            => LAPACKE_sormlq(layout, side, trans,
                m, n, k,
                a, lda, tau,
                c, ldc);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sormlq_work(Layout layout, char side, TransChar trans,
            int m, int n, int k,
            float[] a, int lda,
            float[] tau, float[] c, int ldc,
            float[] work, int lwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sormlq_work(Layout layout, char side, TransChar trans,
            int m, int n, int k,
            float[] a, int lda,
            float[] tau, float[] c, int ldc,
            float[] work, int lwork)
            => LAPACKE_sormlq_work(layout, side, trans,
                m, n, k,
                a, lda,
                tau, c, ldc,
                work, lwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sormql(Layout layout, char side, TransChar trans,
            int m, int n, int k,
            float[] a, int lda, float[] tau,
            float[] c, int ldc);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sormql(Layout layout, char side, TransChar trans,
            int m, int n, int k,
            float[] a, int lda, float[] tau,
            float[] c, int ldc)
            => LAPACKE_sormql(layout, side, trans,
                m, n, k,
                a, lda, tau,
                c, ldc);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sormql_work(Layout layout, char side, TransChar trans,
            int m, int n, int k,
            float[] a, int lda,
            float[] tau, float[] c, int ldc,
            float[] work, int lwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sormql_work(Layout layout, char side, TransChar trans,
            int m, int n, int k,
            float[] a, int lda,
            float[] tau, float[] c, int ldc,
            float[] work, int lwork)
            => LAPACKE_sormql_work(layout, side, trans,
                m, n, k,
                a, lda,
                tau, c, ldc,
                work, lwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sormqr(Layout layout, char side, TransChar trans,
            int m, int n, int k,
            float[] a, int lda, float[] tau,
            float[] c, int ldc);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sormqr(Layout layout, char side, TransChar trans,
            int m, int n, int k,
            float[] a, int lda, float[] tau,
            float[] c, int ldc)
            => LAPACKE_sormqr(layout, side, trans,
                m, n, k,
                a, lda, tau,
                c, ldc);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sormqr_work(Layout layout, char side, TransChar trans,
            int m, int n, int k,
            float[] a, int lda,
            float[] tau, float[] c, int ldc,
            float[] work, int lwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sormqr_work(Layout layout, char side, TransChar trans,
            int m, int n, int k,
            float[] a, int lda,
            float[] tau, float[] c, int ldc,
            float[] work, int lwork)
            => LAPACKE_sormqr_work(layout, side, trans,
                m, n, k,
                a, lda,
                tau, c, ldc,
                work, lwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sormrq(Layout layout, char side, TransChar trans,
            int m, int n, int k,
            float[] a, int lda, float[] tau,
            float[] c, int ldc);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sormrq(Layout layout, char side, TransChar trans,
            int m, int n, int k,
            float[] a, int lda, float[] tau,
            float[] c, int ldc)
            => LAPACKE_sormrq(layout, side, trans,
                m, n, k,
                a, lda, tau,
                c, ldc);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sormrq_work(Layout layout, char side, TransChar trans,
            int m, int n, int k,
            float[] a, int lda,
            float[] tau, float[] c, int ldc,
            float[] work, int lwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sormrq_work(Layout layout, char side, TransChar trans,
            int m, int n, int k,
            float[] a, int lda,
            float[] tau, float[] c, int ldc,
            float[] work, int lwork)
            => LAPACKE_sormrq_work(layout, side, trans,
                m, n, k,
                a, lda,
                tau, c, ldc,
                work, lwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sormrz(Layout layout, char side, TransChar trans,
            int m, int n, int k,
            int l, float[] a, int lda,
            float[] tau, float[] c, int ldc);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sormrz(Layout layout, char side, TransChar trans,
            int m, int n, int k,
            int l, float[] a, int lda,
            float[] tau, float[] c, int ldc)
            => LAPACKE_sormrz(layout, side, trans,
                m, n, k,
                l, a, lda,
                tau, c, ldc);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sormrz_work(Layout layout, char side, TransChar trans,
            int m, int n, int k,
            int l, float[] a, int lda,
            float[] tau, float[] c, int ldc,
            float[] work, int lwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sormrz_work(Layout layout, char side, TransChar trans,
            int m, int n, int k,
            int l, float[] a, int lda,
            float[] tau, float[] c, int ldc,
            float[] work, int lwork)
            => LAPACKE_sormrz_work(layout, side, trans,
                m, n, k,
                l, a, lda,
                tau, c, ldc,
                work, lwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sormtr(Layout layout, char side, UpLo uplo, TransChar trans,
            int m, int n, float[] a,
            int lda, float[] tau, float[] c,
            int ldc);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sormtr(Layout layout, char side, UpLo uplo, TransChar trans,
            int m, int n, float[] a,
            int lda, float[] tau, float[] c,
            int ldc)
            => LAPACKE_sormtr(layout, side, uplo, trans,
                m, n, a,
                lda, tau, c,
                ldc);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sormtr_work(Layout layout, char side, UpLo uplo,
            TransChar trans, int m, int n,
            float[] a, int lda,
            float[] tau, float[] c, int ldc,
            float[] work, int lwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sormtr_work(Layout layout, char side, UpLo uplo,
            TransChar trans, int m, int n,
            float[] a, int lda,
            float[] tau, float[] c, int ldc,
            float[] work, int lwork)
            => LAPACKE_sormtr_work(layout, side, uplo,
                trans, m, n,
                a, lda,
                tau, c, ldc,
                work, lwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_spbcon(Layout layout, UpLo uplo, int n,
            int kd, float[] ab, int ldab,
            float anorm, float[] rcond);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int spbcon(Layout layout, UpLo uplo, int n,
            int kd, float[] ab, int ldab,
            float anorm, float[] rcond)
            => LAPACKE_spbcon(layout, uplo, n,
                kd, ab, ldab,
                anorm, rcond);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_spbcon_work(Layout layout, UpLo uplo, int n,
            int kd, float[] ab, int ldab,
            float anorm, float[] rcond, float[] work,
            int[] iwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int spbcon_work(Layout layout, UpLo uplo, int n,
            int kd, float[] ab, int ldab,
            float anorm, float[] rcond, float[] work,
            int[] iwork)
            => LAPACKE_spbcon_work(layout, uplo, n,
                kd, ab, ldab,
                anorm, rcond, work,
                iwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_spbequ(Layout layout, UpLo uplo, int n,
            int kd, float[] ab, int ldab,
            float[] s, float[] scond, float[] amax);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int spbequ(Layout layout, UpLo uplo, int n,
            int kd, float[] ab, int ldab,
            float[] s, float[] scond, float[] amax)
            => LAPACKE_spbequ(layout, uplo, n,
                kd, ab, ldab,
                s, scond, amax);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_spbequ_work(Layout layout, UpLo uplo, int n,
            int kd, float[] ab, int ldab,
            float[] s, float[] scond, float[] amax);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int spbequ_work(Layout layout, UpLo uplo, int n,
            int kd, float[] ab, int ldab,
            float[] s, float[] scond, float[] amax)
            => LAPACKE_spbequ_work(layout, uplo, n,
                kd, ab, ldab,
                s, scond, amax);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_spbrfs(Layout layout, UpLo uplo, int n,
            int kd, int nrhs, float[] ab,
            int ldab, float[] afb, int ldafb,
            float[] b, int ldb, float[] x,
            int ldx, float[] ferr, float[] berr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int spbrfs(Layout layout, UpLo uplo, int n,
            int kd, int nrhs, float[] ab,
            int ldab, float[] afb, int ldafb,
            float[] b, int ldb, float[] x,
            int ldx, float[] ferr, float[] berr)
            => LAPACKE_spbrfs(layout, uplo, n,
                kd, nrhs, ab,
                ldab, afb, ldafb,
                b, ldb, x,
                ldx, ferr, berr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_spbrfs_work(Layout layout, UpLo uplo, int n,
            int kd, int nrhs, float[] ab,
            int ldab, float[] afb,
            int ldafb, float[] b,
            int ldb, float[] x, int ldx,
            float[] ferr, float[] berr, float[] work,
            int[] iwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int spbrfs_work(Layout layout, UpLo uplo, int n,
            int kd, int nrhs, float[] ab,
            int ldab, float[] afb,
            int ldafb, float[] b,
            int ldb, float[] x, int ldx,
            float[] ferr, float[] berr, float[] work,
            int[] iwork)
            => LAPACKE_spbrfs_work(layout, uplo, n,
                kd, nrhs, ab,
                ldab, afb,
                ldafb, b,
                ldb, x, ldx,
                ferr, berr, work,
                iwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_spbstf(Layout layout, UpLo uplo, int n,
            int kb, float[] bb, int ldbb);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int spbstf(Layout layout, UpLo uplo, int n,
            int kb, float[] bb, int ldbb)
            => LAPACKE_spbstf(layout, uplo, n,
                kb, bb, ldbb);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_spbstf_work(Layout layout, UpLo uplo, int n,
            int kb, float[] bb, int ldbb);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int spbstf_work(Layout layout, UpLo uplo, int n,
            int kb, float[] bb, int ldbb)
            => LAPACKE_spbstf_work(layout, uplo, n,
                kb, bb, ldbb);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_spbsv(Layout layout, UpLo uplo, int n,
            int kd, int nrhs, float[] ab,
            int ldab, float[] b, int ldb);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int spbsv(Layout layout, UpLo uplo, int n,
            int kd, int nrhs, float[] ab,
            int ldab, float[] b, int ldb)
            => LAPACKE_spbsv(layout, uplo, n,
                kd, nrhs, ab,
                ldab, b, ldb);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_spbsv_work(Layout layout, UpLo uplo, int n,
            int kd, int nrhs, float[] ab,
            int ldab, float[] b, int ldb);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int spbsv_work(Layout layout, UpLo uplo, int n,
            int kd, int nrhs, float[] ab,
            int ldab, float[] b, int ldb)
            => LAPACKE_spbsv_work(layout, uplo, n,
                kd, nrhs, ab,
                ldab, b, ldb);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_spbsvx(Layout layout, char fact, UpLo uplo, int n,
            int kd, int nrhs, float[] ab,
            int ldab, float[] afb, int ldafb,
            char[] equed, float[] s, float[] b, int ldb,
            float[] x, int ldx, float[] rcond, float[] ferr,
            float[] berr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int spbsvx(Layout layout, char fact, UpLo uplo, int n,
            int kd, int nrhs, float[] ab,
            int ldab, float[] afb, int ldafb,
            char[] equed, float[] s, float[] b, int ldb,
            float[] x, int ldx, float[] rcond, float[] ferr,
            float[] berr)
            => LAPACKE_spbsvx(layout, fact, uplo, n,
                kd, nrhs, ab,
                ldab, afb, ldafb,
                equed, s, b, ldb,
                x, ldx, rcond, ferr,
                berr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_spbsvx_work(Layout layout, char fact, UpLo uplo,
            int n, int kd, int nrhs,
            float[] ab, int ldab, float[] afb,
            int ldafb, char[] equed, float[] s,
            float[] b, int ldb, float[] x,
            int ldx, float[] rcond, float[] ferr,
            float[] berr, float[] work, int[] iwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int spbsvx_work(Layout layout, char fact, UpLo uplo,
            int n, int kd, int nrhs,
            float[] ab, int ldab, float[] afb,
            int ldafb, char[] equed, float[] s,
            float[] b, int ldb, float[] x,
            int ldx, float[] rcond, float[] ferr,
            float[] berr, float[] work, int[] iwork)
            => LAPACKE_spbsvx_work(layout, fact, uplo,
                n, kd, nrhs,
                ab, ldab, afb,
                ldafb, equed, s,
                b, ldb, x,
                ldx, rcond, ferr,
                berr, work, iwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_spbtrf(Layout layout, UpLo uplo, int n,
            int kd, float[] ab, int ldab);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int spbtrf(Layout layout, UpLo uplo, int n,
            int kd, float[] ab, int ldab)
            => LAPACKE_spbtrf(layout, uplo, n,
                kd, ab, ldab);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_spbtrf_work(Layout layout, UpLo uplo, int n,
            int kd, float[] ab, int ldab);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int spbtrf_work(Layout layout, UpLo uplo, int n,
            int kd, float[] ab, int ldab)
            => LAPACKE_spbtrf_work(layout, uplo, n,
                kd, ab, ldab);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_spbtrs(Layout layout, UpLo uplo, int n,
            int kd, int nrhs, float[] ab,
            int ldab, float[] b, int ldb);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int spbtrs(Layout layout, UpLo uplo, int n,
            int kd, int nrhs, float[] ab,
            int ldab, float[] b, int ldb)
            => LAPACKE_spbtrs(layout, uplo, n,
                kd, nrhs, ab,
                ldab, b, ldb);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_spbtrs_work(Layout layout, UpLo uplo, int n,
            int kd, int nrhs, float[] ab,
            int ldab, float[] b, int ldb);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int spbtrs_work(Layout layout, UpLo uplo, int n,
            int kd, int nrhs, float[] ab,
            int ldab, float[] b, int ldb)
            => LAPACKE_spbtrs_work(layout, uplo, n,
                kd, nrhs, ab,
                ldab, b, ldb);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_spftrf(Layout layout, TransChar transr, UpLo uplo,
            int n, float[] a);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int spftrf(Layout layout, TransChar transr, UpLo uplo,
            int n, float[] a)
            => LAPACKE_spftrf(layout, transr, uplo,
                n, a);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_spftrf_work(Layout layout, TransChar transr, UpLo uplo,
            int n, float[] a);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int spftrf_work(Layout layout, TransChar transr, UpLo uplo,
            int n, float[] a)
            => LAPACKE_spftrf_work(layout, transr, uplo,
                n, a);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_spftri(Layout layout, TransChar transr, UpLo uplo,
            int n, float[] a);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int spftri(Layout layout, TransChar transr, UpLo uplo,
            int n, float[] a)
            => LAPACKE_spftri(layout, transr, uplo,
                n, a);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_spftri_work(Layout layout, TransChar transr, UpLo uplo,
            int n, float[] a);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int spftri_work(Layout layout, TransChar transr, UpLo uplo,
            int n, float[] a)
            => LAPACKE_spftri_work(layout, transr, uplo,
                n, a);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_spftrs(Layout layout, TransChar transr, UpLo uplo,
            int n, int nrhs, float[] a,
            float[] b, int ldb);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int spftrs(Layout layout, TransChar transr, UpLo uplo,
            int n, int nrhs, float[] a,
            float[] b, int ldb)
            => LAPACKE_spftrs(layout, transr, uplo,
                n, nrhs, a,
                b, ldb);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_spftrs_work(Layout layout, TransChar transr, UpLo uplo,
            int n, int nrhs, float[] a,
            float[] b, int ldb);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int spftrs_work(Layout layout, TransChar transr, UpLo uplo,
            int n, int nrhs, float[] a,
            float[] b, int ldb)
            => LAPACKE_spftrs_work(layout, transr, uplo,
                n, nrhs, a,
                b, ldb);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_spocon(Layout layout, UpLo uplo, int n,
            float[] a, int lda, float anorm,
            float[] rcond);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int spocon(Layout layout, UpLo uplo, int n,
            float[] a, int lda, float anorm,
            float[] rcond)
            => LAPACKE_spocon(layout, uplo, n,
                a, lda, anorm,
                rcond);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_spocon_work(Layout layout, UpLo uplo, int n,
            float[] a, int lda, float anorm,
            float[] rcond, float[] work, int[] iwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int spocon_work(Layout layout, UpLo uplo, int n,
            float[] a, int lda, float anorm,
            float[] rcond, float[] work, int[] iwork)
            => LAPACKE_spocon_work(layout, uplo, n,
                a, lda, anorm,
                rcond, work, iwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_spoequ(Layout layout, int n, float[] a,
            int lda, float[] s, float[] scond, float[] amax);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int spoequ(Layout layout, int n, float[] a,
            int lda, float[] s, float[] scond, float[] amax)
            => LAPACKE_spoequ(layout, n, a,
                lda, s, scond, amax);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_spoequ_work(Layout layout, int n, float[] a,
            int lda, float[] s, float[] scond,
            float[] amax);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int spoequ_work(Layout layout, int n, float[] a,
            int lda, float[] s, float[] scond,
            float[] amax)
            => LAPACKE_spoequ_work(layout, n, a,
                lda, s, scond,
                amax);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_spoequb(Layout layout, int n, float[] a,
            int lda, float[] s, float[] scond,
            float[] amax);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int spoequb(Layout layout, int n, float[] a,
            int lda, float[] s, float[] scond,
            float[] amax)
            => LAPACKE_spoequb(layout, n, a,
                lda, s, scond,
                amax);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_spoequb_work(Layout layout, int n,
            float[] a, int lda, float[] s,
            float[] scond, float[] amax);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int spoequb_work(Layout layout, int n,
            float[] a, int lda, float[] s,
            float[] scond, float[] amax)
            => LAPACKE_spoequb_work(layout, n,
                a, lda, s,
                scond, amax);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sporfs(Layout layout, UpLo uplo, int n,
            int nrhs, float[] a, int lda,
            float[] af, int ldaf, float[] b,
            int ldb, float[] x, int ldx,
            float[] ferr, float[] berr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sporfs(Layout layout, UpLo uplo, int n,
            int nrhs, float[] a, int lda,
            float[] af, int ldaf, float[] b,
            int ldb, float[] x, int ldx,
            float[] ferr, float[] berr)
            => LAPACKE_sporfs(layout, uplo, n,
                nrhs, a, lda,
                af, ldaf, b,
                ldb, x, ldx,
                ferr, berr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sporfs_work(Layout layout, UpLo uplo, int n,
            int nrhs, float[] a,
            int lda, float[] af,
            int ldaf, float[] b,
            int ldb, float[] x, int ldx,
            float[] ferr, float[] berr, float[] work,
            int[] iwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sporfs_work(Layout layout, UpLo uplo, int n,
            int nrhs, float[] a,
            int lda, float[] af,
            int ldaf, float[] b,
            int ldb, float[] x, int ldx,
            float[] ferr, float[] berr, float[] work,
            int[] iwork)
            => LAPACKE_sporfs_work(layout, uplo, n,
                nrhs, a,
                lda, af,
                ldaf, b,
                ldb, x, ldx,
                ferr, berr, work,
                iwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sporfsx(Layout layout, UpLo uplo, char equed,
            int n, int nrhs, float[] a,
            int lda, float[] af, int ldaf,
            float[] s, float[] b, int ldb,
            float[] x, int ldx, float[] rcond, float[] berr,
            int n_err_bnds, float[] err_bnds_norm,
            float[] err_bnds_comp, int nparams,
            float[] aparams);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sporfsx(Layout layout, UpLo uplo, char equed,
            int n, int nrhs, float[] a,
            int lda, float[] af, int ldaf,
            float[] s, float[] b, int ldb,
            float[] x, int ldx, float[] rcond, float[] berr,
            int n_err_bnds, float[] err_bnds_norm,
            float[] err_bnds_comp, int nparams,
            float[] aparams)
            => LAPACKE_sporfsx(layout, uplo, equed,
                n, nrhs, a,
                lda, af, ldaf,
                s, b, ldb,
                x, ldx, rcond, berr,
                n_err_bnds, err_bnds_norm,
                err_bnds_comp, nparams,
                aparams);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sporfsx_work(Layout layout, UpLo uplo, char equed,
            int n, int nrhs, float[] a,
            int lda, float[] af,
            int ldaf, float[] s,
            float[] b, int ldb, float[] x,
            int ldx, float[] rcond, float[] berr,
            int n_err_bnds, float[] err_bnds_norm,
            float[] err_bnds_comp, int nparams,
            float[] aparams, float[] work,
            int[] iwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sporfsx_work(Layout layout, UpLo uplo, char equed,
            int n, int nrhs, float[] a,
            int lda, float[] af,
            int ldaf, float[] s,
            float[] b, int ldb, float[] x,
            int ldx, float[] rcond, float[] berr,
            int n_err_bnds, float[] err_bnds_norm,
            float[] err_bnds_comp, int nparams,
            float[] aparams, float[] work,
            int[] iwork)
            => LAPACKE_sporfsx_work(layout, uplo, equed,
                n, nrhs, a,
                lda, af,
                ldaf, s,
                b, ldb, x,
                ldx, rcond, berr,
                n_err_bnds, err_bnds_norm,
                err_bnds_comp, nparams,
                aparams, work,
                iwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sposv(Layout layout, UpLo uplo, int n,
            int nrhs, float[] a, int lda, float[] b,
            int ldb);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sposv(Layout layout, UpLo uplo, int n,
            int nrhs, float[] a, int lda, float[] b,
            int ldb)
            => LAPACKE_sposv(layout, uplo, n,
                nrhs, a, lda, b,
                ldb);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sposv_work(Layout layout, UpLo uplo, int n,
            int nrhs, float[] a, int lda,
            float[] b, int ldb);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sposv_work(Layout layout, UpLo uplo, int n,
            int nrhs, float[] a, int lda,
            float[] b, int ldb)
            => LAPACKE_sposv_work(layout, uplo, n,
                nrhs, a, lda,
                b, ldb);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sposvx(Layout layout, char fact, UpLo uplo, int n,
            int nrhs, float[] a, int lda, float[] af,
            int ldaf, char[] equed, float[] s, float[] b,
            int ldb, float[] x, int ldx,
            float[] rcond, float[] ferr, float[] berr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sposvx(Layout layout, char fact, UpLo uplo, int n,
            int nrhs, float[] a, int lda, float[] af,
            int ldaf, char[] equed, float[] s, float[] b,
            int ldb, float[] x, int ldx,
            float[] rcond, float[] ferr, float[] berr)
            => LAPACKE_sposvx(layout, fact, uplo, n,
                nrhs, a, lda, af,
                ldaf, equed, s, b,
                ldb, x, ldx,
                rcond, ferr, berr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sposvx_work(Layout layout, char fact, UpLo uplo,
            int n, int nrhs, float[] a,
            int lda, float[] af, int ldaf,
            char[] equed, float[] s, float[] b,
            int ldb, float[] x, int ldx,
            float[] rcond, float[] ferr, float[] berr,
            float[] work, int[] iwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sposvx_work(Layout layout, char fact, UpLo uplo,
            int n, int nrhs, float[] a,
            int lda, float[] af, int ldaf,
            char[] equed, float[] s, float[] b,
            int ldb, float[] x, int ldx,
            float[] rcond, float[] ferr, float[] berr,
            float[] work, int[] iwork)
            => LAPACKE_sposvx_work(layout, fact, uplo,
                n, nrhs, a,
                lda, af, ldaf,
                equed, s, b,
                ldb, x, ldx,
                rcond, ferr, berr,
                work, iwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sposvxx(Layout layout, char fact, UpLo uplo,
            int n, int nrhs, float[] a,
            int lda, float[] af, int ldaf,
            char[] equed, float[] s, float[] b, int ldb,
            float[] x, int ldx, float[] rcond,
            float[] rpvgrw, float[] berr, int n_err_bnds,
            float[] err_bnds_norm, float[] err_bnds_comp,
            int nparams, float[] aparams);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sposvxx(Layout layout, char fact, UpLo uplo,
            int n, int nrhs, float[] a,
            int lda, float[] af, int ldaf,
            char[] equed, float[] s, float[] b, int ldb,
            float[] x, int ldx, float[] rcond,
            float[] rpvgrw, float[] berr, int n_err_bnds,
            float[] err_bnds_norm, float[] err_bnds_comp,
            int nparams, float[] aparams)
            => LAPACKE_sposvxx(layout, fact, uplo,
                n, nrhs, a,
                lda, af, ldaf,
                equed, s, b, ldb,
                x, ldx, rcond,
                rpvgrw, berr, n_err_bnds,
                err_bnds_norm, err_bnds_comp,
                nparams, aparams);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sposvxx_work(Layout layout, char fact, UpLo uplo,
            int n, int nrhs, float[] a,
            int lda, float[] af, int ldaf,
            char[] equed, float[] s, float[] b,
            int ldb, float[] x, int ldx,
            float[] rcond, float[] rpvgrw, float[] berr,
            int n_err_bnds, float[] err_bnds_norm,
            float[] err_bnds_comp, int nparams,
            float[] aparams, float[] work,
            int[] iwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sposvxx_work(Layout layout, char fact, UpLo uplo,
            int n, int nrhs, float[] a,
            int lda, float[] af, int ldaf,
            char[] equed, float[] s, float[] b,
            int ldb, float[] x, int ldx,
            float[] rcond, float[] rpvgrw, float[] berr,
            int n_err_bnds, float[] err_bnds_norm,
            float[] err_bnds_comp, int nparams,
            float[] aparams, float[] work,
            int[] iwork)
            => LAPACKE_sposvxx_work(layout, fact, uplo,
                n, nrhs, a,
                lda, af, ldaf,
                equed, s, b,
                ldb, x, ldx,
                rcond, rpvgrw, berr,
                n_err_bnds, err_bnds_norm,
                err_bnds_comp, nparams,
                aparams, work,
                iwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_spotrf(Layout layout, UpLo uplo, int n, float[] a,
            int lda);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int spotrf(Layout layout, UpLo uplo, int n, float[] a,
            int lda)
            => LAPACKE_spotrf(layout, uplo, n, a,
                lda);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_spotrf2(Layout layout, UpLo uplo, int n, float[] a,
            int lda);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int spotrf2(Layout layout, UpLo uplo, int n, float[] a,
            int lda)
            => LAPACKE_spotrf2(layout, uplo, n, a,
                lda);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_spotrf2_work(Layout layout, UpLo uplo, int n,
            float[] a, int lda);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int spotrf2_work(Layout layout, UpLo uplo, int n,
            float[] a, int lda)
            => LAPACKE_spotrf2_work(layout, uplo, n,
                a, lda);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_spotrf_work(Layout layout, UpLo uplo, int n,
            float[] a, int lda);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int spotrf_work(Layout layout, UpLo uplo, int n,
            float[] a, int lda)
            => LAPACKE_spotrf_work(layout, uplo, n,
                a, lda);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_spotri(Layout layout, UpLo uplo, int n, float[] a,
            int lda);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int spotri(Layout layout, UpLo uplo, int n, float[] a,
            int lda)
            => LAPACKE_spotri(layout, uplo, n, a,
                lda);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_spotri_work(Layout layout, UpLo uplo, int n,
            float[] a, int lda);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int spotri_work(Layout layout, UpLo uplo, int n,
            float[] a, int lda)
            => LAPACKE_spotri_work(layout, uplo, n,
                a, lda);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_spotrs(Layout layout, UpLo uplo, int n,
            int nrhs, float[] a, int lda,
            float[] b, int ldb);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int spotrs(Layout layout, UpLo uplo, int n,
            int nrhs, float[] a, int lda,
            float[] b, int ldb)
            => LAPACKE_spotrs(layout, uplo, n,
                nrhs, a, lda,
                b, ldb);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_spotrs_work(Layout layout, UpLo uplo, int n,
            int nrhs, float[] a,
            int lda, float[] b, int ldb);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int spotrs_work(Layout layout, UpLo uplo, int n,
            int nrhs, float[] a,
            int lda, float[] b, int ldb)
            => LAPACKE_spotrs_work(layout, uplo, n,
                nrhs, a,
                lda, b, ldb);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sppcon(Layout layout, UpLo uplo, int n,
            float[] ap, float anorm, float[] rcond);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sppcon(Layout layout, UpLo uplo, int n,
            float[] ap, float anorm, float[] rcond)
            => LAPACKE_sppcon(layout, uplo, n,
                ap, anorm, rcond);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sppcon_work(Layout layout, UpLo uplo, int n,
            float[] ap, float anorm, float[] rcond,
            float[] work, int[] iwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sppcon_work(Layout layout, UpLo uplo, int n,
            float[] ap, float anorm, float[] rcond,
            float[] work, int[] iwork)
            => LAPACKE_sppcon_work(layout, uplo, n,
                ap, anorm, rcond,
                work, iwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sppequ(Layout layout, UpLo uplo, int n,
            float[] ap, float[] s, float[] scond,
            float[] amax);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sppequ(Layout layout, UpLo uplo, int n,
            float[] ap, float[] s, float[] scond,
            float[] amax)
            => LAPACKE_sppequ(layout, uplo, n,
                ap, s, scond,
                amax);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sppequ_work(Layout layout, UpLo uplo, int n,
            float[] ap, float[] s, float[] scond,
            float[] amax);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sppequ_work(Layout layout, UpLo uplo, int n,
            float[] ap, float[] s, float[] scond,
            float[] amax)
            => LAPACKE_sppequ_work(layout, uplo, n,
                ap, s, scond,
                amax);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_spprfs(Layout layout, UpLo uplo, int n,
            int nrhs, float[] ap, float[] afp,
            float[] b, int ldb, float[] x,
            int ldx, float[] ferr, float[] berr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int spprfs(Layout layout, UpLo uplo, int n,
            int nrhs, float[] ap, float[] afp,
            float[] b, int ldb, float[] x,
            int ldx, float[] ferr, float[] berr)
            => LAPACKE_spprfs(layout, uplo, n,
                nrhs, ap, afp,
                b, ldb, x,
                ldx, ferr, berr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_spprfs_work(Layout layout, UpLo uplo, int n,
            int nrhs, float[] ap,
            float[] afp, float[] b,
            int ldb, float[] x, int ldx,
            float[] ferr, float[] berr, float[] work,
            int[] iwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int spprfs_work(Layout layout, UpLo uplo, int n,
            int nrhs, float[] ap,
            float[] afp, float[] b,
            int ldb, float[] x, int ldx,
            float[] ferr, float[] berr, float[] work,
            int[] iwork)
            => LAPACKE_spprfs_work(layout, uplo, n,
                nrhs, ap,
                afp, b,
                ldb, x, ldx,
                ferr, berr, work,
                iwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sppsv(Layout layout, UpLo uplo, int n,
            int nrhs, float[] ap, float[] b, int ldb);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sppsv(Layout layout, UpLo uplo, int n,
            int nrhs, float[] ap, float[] b, int ldb)
            => LAPACKE_sppsv(layout, uplo, n,
                nrhs, ap, b, ldb);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sppsv_work(Layout layout, UpLo uplo, int n,
            int nrhs, float[] ap, float[] b,
            int ldb);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sppsv_work(Layout layout, UpLo uplo, int n,
            int nrhs, float[] ap, float[] b,
            int ldb)
            => LAPACKE_sppsv_work(layout, uplo, n,
                nrhs, ap, b,
                ldb);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sppsvx(Layout layout, char fact, UpLo uplo, int n,
            int nrhs, float[] ap, float[] afp, char[] equed,
            float[] s, float[] b, int ldb, float[] x,
            int ldx, float[] rcond, float[] ferr,
            float[] berr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sppsvx(Layout layout, char fact, UpLo uplo, int n,
            int nrhs, float[] ap, float[] afp, char[] equed,
            float[] s, float[] b, int ldb, float[] x,
            int ldx, float[] rcond, float[] ferr,
            float[] berr)
            => LAPACKE_sppsvx(layout, fact, uplo, n,
                nrhs, ap, afp, equed,
                s, b, ldb, x,
                ldx, rcond, ferr,
                berr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sppsvx_work(Layout layout, char fact, UpLo uplo,
            int n, int nrhs, float[] ap,
            float[] afp, char[] equed, float[] s, float[] b,
            int ldb, float[] x, int ldx,
            float[] rcond, float[] ferr, float[] berr,
            float[] work, int[] iwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sppsvx_work(Layout layout, char fact, UpLo uplo,
            int n, int nrhs, float[] ap,
            float[] afp, char[] equed, float[] s, float[] b,
            int ldb, float[] x, int ldx,
            float[] rcond, float[] ferr, float[] berr,
            float[] work, int[] iwork)
            => LAPACKE_sppsvx_work(layout, fact, uplo,
                n, nrhs, ap,
                afp, equed, s, b,
                ldb, x, ldx,
                rcond, ferr, berr,
                work, iwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_spptrf(Layout layout, UpLo uplo, int n,
            float[] ap);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int spptrf(Layout layout, UpLo uplo, int n,
            float[] ap)
            => LAPACKE_spptrf(layout, uplo, n,
                ap);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_spptrf_work(Layout layout, UpLo uplo, int n,
            float[] ap);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int spptrf_work(Layout layout, UpLo uplo, int n,
            float[] ap)
            => LAPACKE_spptrf_work(layout, uplo, n,
                ap);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_spptri(Layout layout, UpLo uplo, int n,
            float[] ap);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int spptri(Layout layout, UpLo uplo, int n,
            float[] ap)
            => LAPACKE_spptri(layout, uplo, n,
                ap);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_spptri_work(Layout layout, UpLo uplo, int n,
            float[] ap);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int spptri_work(Layout layout, UpLo uplo, int n,
            float[] ap)
            => LAPACKE_spptri_work(layout, uplo, n,
                ap);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_spptrs(Layout layout, UpLo uplo, int n,
            int nrhs, float[] ap, float[] b,
            int ldb);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int spptrs(Layout layout, UpLo uplo, int n,
            int nrhs, float[] ap, float[] b,
            int ldb)
            => LAPACKE_spptrs(layout, uplo, n,
                nrhs, ap, b,
                ldb);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_spptrs_work(Layout layout, UpLo uplo, int n,
            int nrhs, float[] ap, float[] b,
            int ldb);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int spptrs_work(Layout layout, UpLo uplo, int n,
            int nrhs, float[] ap, float[] b,
            int ldb)
            => LAPACKE_spptrs_work(layout, uplo, n,
                nrhs, ap, b,
                ldb);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_spstrf(Layout layout, UpLo uplo, int n, float[] a,
            int lda, int[] piv, int[] rank,
            float tol);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int spstrf(Layout layout, UpLo uplo, int n, float[] a,
            int lda, int[] piv, int[] rank,
            float tol)
            => LAPACKE_spstrf(layout, uplo, n, a,
                lda, piv, rank,
                tol);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_spstrf_work(Layout layout, UpLo uplo, int n,
            float[] a, int lda, int[] piv,
            int[] rank, float tol, float[] work);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int spstrf_work(Layout layout, UpLo uplo, int n,
            float[] a, int lda, int[] piv,
            int[] rank, float tol, float[] work)
            => LAPACKE_spstrf_work(layout, uplo, n,
                a, lda, piv,
                rank, tol, work);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sptcon(int n, float[] d, float[] e,
            float anorm, float[] rcond);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sptcon(int n, float[] d, float[] e,
            float anorm, float[] rcond)
            => LAPACKE_sptcon(n, d, e,
                anorm, rcond);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sptcon_work(int n, float[] d, float[] e,
            float anorm, float[] rcond, float[] work);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sptcon_work(int n, float[] d, float[] e,
            float anorm, float[] rcond, float[] work)
            => LAPACKE_sptcon_work(n, d, e,
                anorm, rcond, work);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_spteqr(Layout layout, char compz, int n, float[] d,
            float[] e, float[] z, int ldz);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int spteqr(Layout layout, char compz, int n, float[] d,
            float[] e, float[] z, int ldz)
            => LAPACKE_spteqr(layout, compz, n, d,
                e, z, ldz);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_spteqr_work(Layout layout, char compz, int n,
            float[] d, float[] e, float[] z, int ldz,
            float[] work);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int spteqr_work(Layout layout, char compz, int n,
            float[] d, float[] e, float[] z, int ldz,
            float[] work)
            => LAPACKE_spteqr_work(layout, compz, n,
                d, e, z, ldz,
                work);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sptrfs(Layout layout, int n, int nrhs,
            float[] d, float[] e, float[] df,
            float[] ef, float[] b, int ldb,
            float[] x, int ldx, float[] ferr, float[] berr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sptrfs(Layout layout, int n, int nrhs,
            float[] d, float[] e, float[] df,
            float[] ef, float[] b, int ldb,
            float[] x, int ldx, float[] ferr, float[] berr)
            => LAPACKE_sptrfs(layout, n, nrhs,
                d, e, df,
                ef, b, ldb,
                x, ldx, ferr, berr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sptrfs_work(Layout layout, int n, int nrhs,
            float[] d, float[] e, float[] df,
            float[] ef, float[] b, int ldb,
            float[] x, int ldx, float[] ferr,
            float[] berr, float[] work);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sptrfs_work(Layout layout, int n, int nrhs,
            float[] d, float[] e, float[] df,
            float[] ef, float[] b, int ldb,
            float[] x, int ldx, float[] ferr,
            float[] berr, float[] work)
            => LAPACKE_sptrfs_work(layout, n, nrhs,
                d, e, df,
                ef, b, ldb,
                x, ldx, ferr,
                berr, work);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sptsv(Layout layout, int n, int nrhs,
            float[] d, float[] e, float[] b, int ldb);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sptsv(Layout layout, int n, int nrhs,
            float[] d, float[] e, float[] b, int ldb)
            => LAPACKE_sptsv(layout, n, nrhs,
                d, e, b, ldb);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sptsv_work(Layout layout, int n, int nrhs,
            float[] d, float[] e, float[] b, int ldb);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sptsv_work(Layout layout, int n, int nrhs,
            float[] d, float[] e, float[] b, int ldb)
            => LAPACKE_sptsv_work(layout, n, nrhs,
                d, e, b, ldb);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sptsvx(Layout layout, char fact, int n,
            int nrhs, float[] d, float[] e,
            float[] df, float[] ef, float[] b, int ldb,
            float[] x, int ldx, float[] rcond, float[] ferr,
            float[] berr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sptsvx(Layout layout, char fact, int n,
            int nrhs, float[] d, float[] e,
            float[] df, float[] ef, float[] b, int ldb,
            float[] x, int ldx, float[] rcond, float[] ferr,
            float[] berr)
            => LAPACKE_sptsvx(layout, fact, n,
                nrhs, d, e,
                df, ef, b, ldb,
                x, ldx, rcond, ferr,
                berr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sptsvx_work(Layout layout, char fact, int n,
            int nrhs, float[] d, float[] e,
            float[] df, float[] ef, float[] b,
            int ldb, float[] x, int ldx,
            float[] rcond, float[] ferr, float[] berr,
            float[] work);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sptsvx_work(Layout layout, char fact, int n,
            int nrhs, float[] d, float[] e,
            float[] df, float[] ef, float[] b,
            int ldb, float[] x, int ldx,
            float[] rcond, float[] ferr, float[] berr,
            float[] work)
            => LAPACKE_sptsvx_work(layout, fact, n,
                nrhs, d, e,
                df, ef, b,
                ldb, x, ldx,
                rcond, ferr, berr,
                work);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_spttrf(int n, float[] d, float[] e);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int spttrf(int n, float[] d, float[] e)
            => LAPACKE_spttrf(n, d, e);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_spttrf_work(int n, float[] d, float[] e);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int spttrf_work(int n, float[] d, float[] e)
            => LAPACKE_spttrf_work(n, d, e);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_spttrs(Layout layout, int n, int nrhs,
            float[] d, float[] e, float[] b,
            int ldb);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int spttrs(Layout layout, int n, int nrhs,
            float[] d, float[] e, float[] b,
            int ldb)
            => LAPACKE_spttrs(layout, n, nrhs,
                d, e, b,
                ldb);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_spttrs_work(Layout layout, int n, int nrhs,
            float[] d, float[] e, float[] b,
            int ldb);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int spttrs_work(Layout layout, int n, int nrhs,
            float[] d, float[] e, float[] b,
            int ldb)
            => LAPACKE_spttrs_work(layout, n, nrhs,
                d, e, b,
                ldb);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssbev(Layout layout, char jobz, UpLo uplo, int n,
            int kd, float[] ab, int ldab, float[] w,
            float[] z, int ldz);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ssbev(Layout layout, char jobz, UpLo uplo, int n,
            int kd, float[] ab, int ldab, float[] w,
            float[] z, int ldz)
            => LAPACKE_ssbev(layout, jobz, uplo, n,
                kd, ab, ldab, w,
                z, ldz);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssbev_work(Layout layout, char jobz, UpLo uplo,
            int n, int kd, float[] ab,
            int ldab, float[] w, float[] z,
            int ldz, float[] work);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ssbev_work(Layout layout, char jobz, UpLo uplo,
            int n, int kd, float[] ab,
            int ldab, float[] w, float[] z,
            int ldz, float[] work)
            => LAPACKE_ssbev_work(layout, jobz, uplo,
                n, kd, ab,
                ldab, w, z,
                ldz, work);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssbevd(Layout layout, char jobz, UpLo uplo, int n,
            int kd, float[] ab, int ldab, float[] w,
            float[] z, int ldz);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ssbevd(Layout layout, char jobz, UpLo uplo, int n,
            int kd, float[] ab, int ldab, float[] w,
            float[] z, int ldz)
            => LAPACKE_ssbevd(layout, jobz, uplo, n,
                kd, ab, ldab, w,
                z, ldz);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssbevd_work(Layout layout, char jobz, UpLo uplo,
            int n, int kd, float[] ab,
            int ldab, float[] w, float[] z,
            int ldz, float[] work, int lwork,
            int[] iwork, int liwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ssbevd_work(Layout layout, char jobz, UpLo uplo,
            int n, int kd, float[] ab,
            int ldab, float[] w, float[] z,
            int ldz, float[] work, int lwork,
            int[] iwork, int liwork)
            => LAPACKE_ssbevd_work(layout, jobz, uplo,
                n, kd, ab,
                ldab, w, z,
                ldz, work, lwork,
                iwork, liwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssbevx(Layout layout, char jobz, char range, UpLo uplo,
            int n, int kd, float[] ab,
            int ldab, float[] q, int ldq, float vl,
            float vu, int il, int iu, float abstol,
            int[] m, float[] w, float[] z, int ldz,
            int[] ifail);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ssbevx(Layout layout, char jobz, char range, UpLo uplo,
            int n, int kd, float[] ab,
            int ldab, float[] q, int ldq, float vl,
            float vu, int il, int iu, float abstol,
            int[] m, float[] w, float[] z, int ldz,
            int[] ifail)
            => LAPACKE_ssbevx(layout, jobz, range, uplo,
                n, kd, ab,
                ldab, q, ldq, vl,
                vu, il, iu, abstol,
                m, w, z, ldz,
                ifail);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssbevx_work(Layout layout, char jobz, char range,
            UpLo uplo, int n, int kd,
            float[] ab, int ldab, float[] q,
            int ldq, float vl, float vu,
            int il, int iu, float abstol,
            int[] m, float[] w, float[] z,
            int ldz, float[] work, int[] iwork,
            int[] ifail);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ssbevx_work(Layout layout, char jobz, char range,
            UpLo uplo, int n, int kd,
            float[] ab, int ldab, float[] q,
            int ldq, float vl, float vu,
            int il, int iu, float abstol,
            int[] m, float[] w, float[] z,
            int ldz, float[] work, int[] iwork,
            int[] ifail)
            => LAPACKE_ssbevx_work(layout, jobz, range,
                uplo, n, kd,
                ab, ldab, q,
                ldq, vl, vu,
                il, iu, abstol,
                m, w, z,
                ldz, work, iwork,
                ifail);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssbgst(Layout layout, char vect, UpLo uplo, int n,
            int ka, int kb, float[] ab,
            int ldab, float[] bb, int ldbb,
            float[] x, int ldx);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ssbgst(Layout layout, char vect, UpLo uplo, int n,
            int ka, int kb, float[] ab,
            int ldab, float[] bb, int ldbb,
            float[] x, int ldx)
            => LAPACKE_ssbgst(layout, vect, uplo, n,
                ka, kb, ab,
                ldab, bb, ldbb,
                x, ldx);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssbgst_work(Layout layout, char vect, UpLo uplo,
            int n, int ka, int kb,
            float[] ab, int ldab, float[] bb,
            int ldbb, float[] x, int ldx,
            float[] work);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ssbgst_work(Layout layout, char vect, UpLo uplo,
            int n, int ka, int kb,
            float[] ab, int ldab, float[] bb,
            int ldbb, float[] x, int ldx,
            float[] work)
            => LAPACKE_ssbgst_work(layout, vect, uplo,
                n, ka, kb,
                ab, ldab, bb,
                ldbb, x, ldx,
                work);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssbgv(Layout layout, char jobz, UpLo uplo, int n,
            int ka, int kb, float[] ab,
            int ldab, float[] bb, int ldbb, float[] w,
            float[] z, int ldz);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ssbgv(Layout layout, char jobz, UpLo uplo, int n,
            int ka, int kb, float[] ab,
            int ldab, float[] bb, int ldbb, float[] w,
            float[] z, int ldz)
            => LAPACKE_ssbgv(layout, jobz, uplo, n,
                ka, kb, ab,
                ldab, bb, ldbb, w,
                z, ldz);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssbgv_work(Layout layout, char jobz, UpLo uplo,
            int n, int ka, int kb,
            float[] ab, int ldab, float[] bb,
            int ldbb, float[] w, float[] z,
            int ldz, float[] work);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ssbgv_work(Layout layout, char jobz, UpLo uplo,
            int n, int ka, int kb,
            float[] ab, int ldab, float[] bb,
            int ldbb, float[] w, float[] z,
            int ldz, float[] work)
            => LAPACKE_ssbgv_work(layout, jobz, uplo,
                n, ka, kb,
                ab, ldab, bb,
                ldbb, w, z,
                ldz, work);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssbgvd(Layout layout, char jobz, UpLo uplo, int n,
            int ka, int kb, float[] ab,
            int ldab, float[] bb, int ldbb,
            float[] w, float[] z, int ldz);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ssbgvd(Layout layout, char jobz, UpLo uplo, int n,
            int ka, int kb, float[] ab,
            int ldab, float[] bb, int ldbb,
            float[] w, float[] z, int ldz)
            => LAPACKE_ssbgvd(layout, jobz, uplo, n,
                ka, kb, ab,
                ldab, bb, ldbb,
                w, z, ldz);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssbgvd_work(Layout layout, char jobz, UpLo uplo,
            int n, int ka, int kb,
            float[] ab, int ldab, float[] bb,
            int ldbb, float[] w, float[] z,
            int ldz, float[] work, int lwork,
            int[] iwork, int liwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ssbgvd_work(Layout layout, char jobz, UpLo uplo,
            int n, int ka, int kb,
            float[] ab, int ldab, float[] bb,
            int ldbb, float[] w, float[] z,
            int ldz, float[] work, int lwork,
            int[] iwork, int liwork)
            => LAPACKE_ssbgvd_work(layout, jobz, uplo,
                n, ka, kb,
                ab, ldab, bb,
                ldbb, w, z,
                ldz, work, lwork,
                iwork, liwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssbgvx(Layout layout, char jobz, char range, UpLo uplo,
            int n, int ka, int kb,
            float[] ab, int ldab, float[] bb,
            int ldbb, float[] q, int ldq, float vl,
            float vu, int il, int iu, float abstol,
            int[] m, float[] w, float[] z, int ldz,
            int[] ifail);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ssbgvx(Layout layout, char jobz, char range, UpLo uplo,
            int n, int ka, int kb,
            float[] ab, int ldab, float[] bb,
            int ldbb, float[] q, int ldq, float vl,
            float vu, int il, int iu, float abstol,
            int[] m, float[] w, float[] z, int ldz,
            int[] ifail)
            => LAPACKE_ssbgvx(layout, jobz, range, uplo,
                n, ka, kb,
                ab, ldab, bb,
                ldbb, q, ldq, vl,
                vu, il, iu, abstol,
                m, w, z, ldz,
                ifail);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssbgvx_work(Layout layout, char jobz, char range,
            UpLo uplo, int n, int ka,
            int kb, float[] ab, int ldab,
            float[] bb, int ldbb, float[] q,
            int ldq, float vl, float vu,
            int il, int iu, float abstol,
            int[] m, float[] w, float[] z,
            int ldz, float[] work, int[] iwork,
            int[] ifail);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ssbgvx_work(Layout layout, char jobz, char range,
            UpLo uplo, int n, int ka,
            int kb, float[] ab, int ldab,
            float[] bb, int ldbb, float[] q,
            int ldq, float vl, float vu,
            int il, int iu, float abstol,
            int[] m, float[] w, float[] z,
            int ldz, float[] work, int[] iwork,
            int[] ifail)
            => LAPACKE_ssbgvx_work(layout, jobz, range,
                uplo, n, ka,
                kb, ab, ldab,
                bb, ldbb, q,
                ldq, vl, vu,
                il, iu, abstol,
                m, w, z,
                ldz, work, iwork,
                ifail);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssbtrd(Layout layout, char vect, UpLo uplo, int n,
            int kd, float[] ab, int ldab, float[] d,
            float[] e, float[] q, int ldq);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ssbtrd(Layout layout, char vect, UpLo uplo, int n,
            int kd, float[] ab, int ldab, float[] d,
            float[] e, float[] q, int ldq)
            => LAPACKE_ssbtrd(layout, vect, uplo, n,
                kd, ab, ldab, d,
                e, q, ldq);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssbtrd_work(Layout layout, char vect, UpLo uplo,
            int n, int kd, float[] ab,
            int ldab, float[] d, float[] e, float[] q,
            int ldq, float[] work);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ssbtrd_work(Layout layout, char vect, UpLo uplo,
            int n, int kd, float[] ab,
            int ldab, float[] d, float[] e, float[] q,
            int ldq, float[] work)
            => LAPACKE_ssbtrd_work(layout, vect, uplo,
                n, kd, ab,
                ldab, d, e, q,
                ldq, work);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssfrk(Layout layout, TransChar transr, UpLo uplo, TransChar trans,
            int n, int k, float alpha,
            float[] a, int lda, float beta, float[] c);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ssfrk(Layout layout, TransChar transr, UpLo uplo, TransChar trans,
            int n, int k, float alpha,
            float[] a, int lda, float beta, float[] c)
            => LAPACKE_ssfrk(layout, transr, uplo, trans,
                n, k, alpha,
                a, lda, beta, c);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssfrk_work(Layout layout, TransChar transr, UpLo uplo,
            TransChar trans, int n, int k,
            float alpha, float[] a, int lda,
            float beta, float[] c);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ssfrk_work(Layout layout, TransChar transr, UpLo uplo,
            TransChar trans, int n, int k,
            float alpha, float[] a, int lda,
            float beta, float[] c)
            => LAPACKE_ssfrk_work(layout, transr, uplo,
                trans, n, k,
                alpha, a, lda,
                beta, c);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sspcon(Layout layout, UpLo uplo, int n,
            float[] ap, int[] ipiv, float anorm,
            float[] rcond);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sspcon(Layout layout, UpLo uplo, int n,
            float[] ap, int[] ipiv, float anorm,
            float[] rcond)
            => LAPACKE_sspcon(layout, uplo, n,
                ap, ipiv, anorm,
                rcond);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sspcon_work(Layout layout, UpLo uplo, int n,
            float[] ap, int[] ipiv,
            float anorm, float[] rcond, float[] work,
            int[] iwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sspcon_work(Layout layout, UpLo uplo, int n,
            float[] ap, int[] ipiv,
            float anorm, float[] rcond, float[] work,
            int[] iwork)
            => LAPACKE_sspcon_work(layout, uplo, n,
                ap, ipiv,
                anorm, rcond, work,
                iwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sspev(Layout layout, char jobz, UpLo uplo, int n,
            float[] ap, float[] w, float[] z, int ldz);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sspev(Layout layout, char jobz, UpLo uplo, int n,
            float[] ap, float[] w, float[] z, int ldz)
            => LAPACKE_sspev(layout, jobz, uplo, n,
                ap, w, z, ldz);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sspev_work(Layout layout, char jobz, UpLo uplo,
            int n, float[] ap, float[] w, float[] z,
            int ldz, float[] work);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sspev_work(Layout layout, char jobz, UpLo uplo,
            int n, float[] ap, float[] w, float[] z,
            int ldz, float[] work)
            => LAPACKE_sspev_work(layout, jobz, uplo,
                n, ap, w, z,
                ldz, work);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sspevd(Layout layout, char jobz, UpLo uplo, int n,
            float[] ap, float[] w, float[] z, int ldz);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sspevd(Layout layout, char jobz, UpLo uplo, int n,
            float[] ap, float[] w, float[] z, int ldz)
            => LAPACKE_sspevd(layout, jobz, uplo, n,
                ap, w, z, ldz);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sspevd_work(Layout layout, char jobz, UpLo uplo,
            int n, float[] ap, float[] w, float[] z,
            int ldz, float[] work, int lwork,
            int[] iwork, int liwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sspevd_work(Layout layout, char jobz, UpLo uplo,
            int n, float[] ap, float[] w, float[] z,
            int ldz, float[] work, int lwork,
            int[] iwork, int liwork)
            => LAPACKE_sspevd_work(layout, jobz, uplo,
                n, ap, w, z,
                ldz, work, lwork,
                iwork, liwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sspevx(Layout layout, char jobz, char range, UpLo uplo,
            int n, float[] ap, float vl, float vu,
            int il, int iu, float abstol,
            int[] m, float[] w, float[] z, int ldz,
            int[] ifail);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sspevx(Layout layout, char jobz, char range, UpLo uplo,
            int n, float[] ap, float vl, float vu,
            int il, int iu, float abstol,
            int[] m, float[] w, float[] z, int ldz,
            int[] ifail)
            => LAPACKE_sspevx(layout, jobz, range, uplo,
                n, ap, vl, vu,
                il, iu, abstol,
                m, w, z, ldz,
                ifail);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sspevx_work(Layout layout, char jobz, char range,
            UpLo uplo, int n, float[] ap, float vl,
            float vu, int il, int iu,
            float abstol, int[] m, float[] w, float[] z,
            int ldz, float[] work, int[] iwork,
            int[] ifail);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sspevx_work(Layout layout, char jobz, char range,
            UpLo uplo, int n, float[] ap, float vl,
            float vu, int il, int iu,
            float abstol, int[] m, float[] w, float[] z,
            int ldz, float[] work, int[] iwork,
            int[] ifail)
            => LAPACKE_sspevx_work(layout, jobz, range,
                uplo, n, ap, vl,
                vu, il, iu,
                abstol, m, w, z,
                ldz, work, iwork,
                ifail);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sspgst(Layout layout, int itype, UpLo uplo,
            int n, float[] ap, float[] bp);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sspgst(Layout layout, int itype, UpLo uplo,
            int n, float[] ap, float[] bp)
            => LAPACKE_sspgst(layout, itype, uplo,
                n, ap, bp);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sspgst_work(Layout layout, int itype, UpLo uplo,
            int n, float[] ap, float[] bp);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sspgst_work(Layout layout, int itype, UpLo uplo,
            int n, float[] ap, float[] bp)
            => LAPACKE_sspgst_work(layout, itype, uplo,
                n, ap, bp);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sspgv(Layout layout, int itype, char jobz,
            UpLo uplo, int n, float[] ap, float[] bp,
            float[] w, float[] z, int ldz);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sspgv(Layout layout, int itype, char jobz,
            UpLo uplo, int n, float[] ap, float[] bp,
            float[] w, float[] z, int ldz)
            => LAPACKE_sspgv(layout, itype, jobz,
                uplo, n, ap, bp,
                w, z, ldz);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sspgv_work(Layout layout, int itype, char jobz,
            UpLo uplo, int n, float[] ap, float[] bp,
            float[] w, float[] z, int ldz, float[] work);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sspgv_work(Layout layout, int itype, char jobz,
            UpLo uplo, int n, float[] ap, float[] bp,
            float[] w, float[] z, int ldz, float[] work)
            => LAPACKE_sspgv_work(layout, itype, jobz,
                uplo, n, ap, bp,
                w, z, ldz, work);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sspgvd(Layout layout, int itype, char jobz,
            UpLo uplo, int n, float[] ap, float[] bp,
            float[] w, float[] z, int ldz);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sspgvd(Layout layout, int itype, char jobz,
            UpLo uplo, int n, float[] ap, float[] bp,
            float[] w, float[] z, int ldz)
            => LAPACKE_sspgvd(layout, itype, jobz,
                uplo, n, ap, bp,
                w, z, ldz);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sspgvd_work(Layout layout, int itype, char jobz,
            UpLo uplo, int n, float[] ap, float[] bp,
            float[] w, float[] z, int ldz, float[] work,
            int lwork, int[] iwork,
            int liwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sspgvd_work(Layout layout, int itype, char jobz,
            UpLo uplo, int n, float[] ap, float[] bp,
            float[] w, float[] z, int ldz, float[] work,
            int lwork, int[] iwork,
            int liwork)
            => LAPACKE_sspgvd_work(layout, itype, jobz,
                uplo, n, ap, bp,
                w, z, ldz, work,
                lwork, iwork,
                liwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sspgvx(Layout layout, int itype, char jobz,
            char range, UpLo uplo, int n, float[] ap,
            float[] bp, float vl, float vu, int il,
            int iu, float abstol, int[] m, float[] w,
            float[] z, int ldz, int[] ifail);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sspgvx(Layout layout, int itype, char jobz,
            char range, UpLo uplo, int n, float[] ap,
            float[] bp, float vl, float vu, int il,
            int iu, float abstol, int[] m, float[] w,
            float[] z, int ldz, int[] ifail)
            => LAPACKE_sspgvx(layout, itype, jobz,
                range, uplo, n, ap,
                bp, vl, vu, il,
                iu, abstol, m, w,
                z, ldz, ifail);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sspgvx_work(Layout layout, int itype, char jobz,
            char range, UpLo uplo, int n, float[] ap,
            float[] bp, float vl, float vu, int il,
            int iu, float abstol, int[] m,
            float[] w, float[] z, int ldz, float[] work,
            int[] iwork, int[] ifail);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sspgvx_work(Layout layout, int itype, char jobz,
            char range, UpLo uplo, int n, float[] ap,
            float[] bp, float vl, float vu, int il,
            int iu, float abstol, int[] m,
            float[] w, float[] z, int ldz, float[] work,
            int[] iwork, int[] ifail)
            => LAPACKE_sspgvx_work(layout, itype, jobz,
                range, uplo, n, ap,
                bp, vl, vu, il,
                iu, abstol, m,
                w, z, ldz, work,
                iwork, ifail);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssprfs(Layout layout, UpLo uplo, int n,
            int nrhs, float[] ap, float[] afp,
            int[] ipiv, float[] b,
            int ldb, float[] x, int ldx,
            float[] ferr, float[] berr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ssprfs(Layout layout, UpLo uplo, int n,
            int nrhs, float[] ap, float[] afp,
            int[] ipiv, float[] b,
            int ldb, float[] x, int ldx,
            float[] ferr, float[] berr)
            => LAPACKE_ssprfs(layout, uplo, n,
                nrhs, ap, afp,
                ipiv, b,
                ldb, x, ldx,
                ferr, berr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssprfs_work(Layout layout, UpLo uplo, int n,
            int nrhs, float[] ap,
            float[] afp, int[] ipiv,
            float[] b, int ldb, float[] x,
            int ldx, float[] ferr, float[] berr,
            float[] work, int[] iwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ssprfs_work(Layout layout, UpLo uplo, int n,
            int nrhs, float[] ap,
            float[] afp, int[] ipiv,
            float[] b, int ldb, float[] x,
            int ldx, float[] ferr, float[] berr,
            float[] work, int[] iwork)
            => LAPACKE_ssprfs_work(layout, uplo, n,
                nrhs, ap,
                afp, ipiv,
                b, ldb, x,
                ldx, ferr, berr,
                work, iwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sspsv(Layout layout, UpLo uplo, int n,
            int nrhs, float[] ap, int[] ipiv,
            float[] b, int ldb);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sspsv(Layout layout, UpLo uplo, int n,
            int nrhs, float[] ap, int[] ipiv,
            float[] b, int ldb)
            => LAPACKE_sspsv(layout, uplo, n,
                nrhs, ap, ipiv,
                b, ldb);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sspsv_work(Layout layout, UpLo uplo, int n,
            int nrhs, float[] ap, int[] ipiv,
            float[] b, int ldb);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sspsv_work(Layout layout, UpLo uplo, int n,
            int nrhs, float[] ap, int[] ipiv,
            float[] b, int ldb)
            => LAPACKE_sspsv_work(layout, uplo, n,
                nrhs, ap, ipiv,
                b, ldb);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sspsvx(Layout layout, char fact, UpLo uplo, int n,
            int nrhs, float[] ap, float[] afp,
            int[] ipiv, float[] b, int ldb,
            float[] x, int ldx, float[] rcond, float[] ferr,
            float[] berr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sspsvx(Layout layout, char fact, UpLo uplo, int n,
            int nrhs, float[] ap, float[] afp,
            int[] ipiv, float[] b, int ldb,
            float[] x, int ldx, float[] rcond, float[] ferr,
            float[] berr)
            => LAPACKE_sspsvx(layout, fact, uplo, n,
                nrhs, ap, afp,
                ipiv, b, ldb,
                x, ldx, rcond, ferr,
                berr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sspsvx_work(Layout layout, char fact, UpLo uplo,
            int n, int nrhs, float[] ap,
            float[] afp, int[] ipiv, float[] b,
            int ldb, float[] x, int ldx,
            float[] rcond, float[] ferr, float[] berr,
            float[] work, int[] iwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sspsvx_work(Layout layout, char fact, UpLo uplo,
            int n, int nrhs, float[] ap,
            float[] afp, int[] ipiv, float[] b,
            int ldb, float[] x, int ldx,
            float[] rcond, float[] ferr, float[] berr,
            float[] work, int[] iwork)
            => LAPACKE_sspsvx_work(layout, fact, uplo,
                n, nrhs, ap,
                afp, ipiv, b,
                ldb, x, ldx,
                rcond, ferr, berr,
                work, iwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssptrd(Layout layout, UpLo uplo, int n, float[] ap,
            float[] d, float[] e, float[] tau);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ssptrd(Layout layout, UpLo uplo, int n, float[] ap,
            float[] d, float[] e, float[] tau)
            => LAPACKE_ssptrd(layout, uplo, n, ap,
                d, e, tau);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssptrd_work(Layout layout, UpLo uplo, int n,
            float[] ap, float[] d, float[] e, float[] tau);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ssptrd_work(Layout layout, UpLo uplo, int n,
            float[] ap, float[] d, float[] e, float[] tau)
            => LAPACKE_ssptrd_work(layout, uplo, n,
                ap, d, e, tau);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssptrf(Layout layout, UpLo uplo, int n, float[] ap,
            int[] ipiv);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ssptrf(Layout layout, UpLo uplo, int n, float[] ap,
            int[] ipiv)
            => LAPACKE_ssptrf(layout, uplo, n, ap,
                ipiv);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssptrf_work(Layout layout, UpLo uplo, int n,
            float[] ap, int[] ipiv);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ssptrf_work(Layout layout, UpLo uplo, int n,
            float[] ap, int[] ipiv)
            => LAPACKE_ssptrf_work(layout, uplo, n,
                ap, ipiv);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssptri(Layout layout, UpLo uplo, int n, float[] ap,
            int[] ipiv);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ssptri(Layout layout, UpLo uplo, int n, float[] ap,
            int[] ipiv)
            => LAPACKE_ssptri(layout, uplo, n, ap,
                ipiv);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssptri_work(Layout layout, UpLo uplo, int n,
            float[] ap, int[] ipiv, float[] work);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ssptri_work(Layout layout, UpLo uplo, int n,
            float[] ap, int[] ipiv, float[] work)
            => LAPACKE_ssptri_work(layout, uplo, n,
                ap, ipiv, work);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssptrs(Layout layout, UpLo uplo, int n,
            int nrhs, float[] ap,
            int[] ipiv, float[] b, int ldb);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ssptrs(Layout layout, UpLo uplo, int n,
            int nrhs, float[] ap,
            int[] ipiv, float[] b, int ldb)
            => LAPACKE_ssptrs(layout, uplo, n,
                nrhs, ap,
                ipiv, b, ldb);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssptrs_work(Layout layout, UpLo uplo, int n,
            int nrhs, float[] ap,
            int[] ipiv, float[] b,
            int ldb);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ssptrs_work(Layout layout, UpLo uplo, int n,
            int nrhs, float[] ap,
            int[] ipiv, float[] b,
            int ldb)
            => LAPACKE_ssptrs_work(layout, uplo, n,
                nrhs, ap,
                ipiv, b,
                ldb);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sstebz(char range, char order, int n, float vl,
            float vu, int il, int iu, float abstol,
            float[] d, float[] e, int[] m,
            int[] nsplit, float[] w, int[] iblock,
            int[] isplit);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sstebz(char range, char order, int n, float vl,
            float vu, int il, int iu, float abstol,
            float[] d, float[] e, int[] m,
            int[] nsplit, float[] w, int[] iblock,
            int[] isplit)
            => LAPACKE_sstebz(range, order, n, vl,
                vu, il, iu, abstol,
                d, e, m,
                nsplit, w, iblock,
                isplit);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sstebz_work(char range, char order, int n, float vl,
            float vu, int il, int iu,
            float abstol, float[] d, float[] e,
            int[] m, int[] nsplit, float[] w,
            int[] iblock, int[] isplit,
            float[] work, int[] iwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sstebz_work(char range, char order, int n, float vl,
            float vu, int il, int iu,
            float abstol, float[] d, float[] e,
            int[] m, int[] nsplit, float[] w,
            int[] iblock, int[] isplit,
            float[] work, int[] iwork)
            => LAPACKE_sstebz_work(range, order, n, vl,
                vu, il, iu,
                abstol, d, e,
                m, nsplit, w,
                iblock, isplit,
                work, iwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sstedc(Layout layout, char compz, int n, float[] d,
            float[] e, float[] z, int ldz);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sstedc(Layout layout, char compz, int n, float[] d,
            float[] e, float[] z, int ldz)
            => LAPACKE_sstedc(layout, compz, n, d,
                e, z, ldz);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sstedc_work(Layout layout, char compz, int n,
            float[] d, float[] e, float[] z, int ldz,
            float[] work, int lwork,
            int[] iwork, int liwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sstedc_work(Layout layout, char compz, int n,
            float[] d, float[] e, float[] z, int ldz,
            float[] work, int lwork,
            int[] iwork, int liwork)
            => LAPACKE_sstedc_work(layout, compz, n,
                d, e, z, ldz,
                work, lwork,
                iwork, liwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sstegr(Layout layout, char jobz, char range,
            int n, float[] d, float[] e, float vl, float vu,
            int il, int iu, float abstol,
            int[] m, float[] w, float[] z, int ldz,
            int[] isuppz);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sstegr(Layout layout, char jobz, char range,
            int n, float[] d, float[] e, float vl, float vu,
            int il, int iu, float abstol,
            int[] m, float[] w, float[] z, int ldz,
            int[] isuppz)
            => LAPACKE_sstegr(layout, jobz, range,
                n, d, e, vl, vu,
                il, iu, abstol,
                m, w, z, ldz,
                isuppz);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sstegr_work(Layout layout, char jobz, char range,
            int n, float[] d, float[] e, float vl,
            float vu, int il, int iu,
            float abstol, int[] m, float[] w, float[] z,
            int ldz, int[] isuppz, float[] work,
            int lwork, int[] iwork,
            int liwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sstegr_work(Layout layout, char jobz, char range,
            int n, float[] d, float[] e, float vl,
            float vu, int il, int iu,
            float abstol, int[] m, float[] w, float[] z,
            int ldz, int[] isuppz, float[] work,
            int lwork, int[] iwork,
            int liwork)
            => LAPACKE_sstegr_work(layout, jobz, range,
                n, d, e, vl,
                vu, il, iu,
                abstol, m, w, z,
                ldz, isuppz, work,
                lwork, iwork,
                liwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sstein(Layout layout, int n, float[] d,
            float[] e, int m, float[] w,
            int[] iblock, int[] isplit,
            float[] z, int ldz, int[] ifailv);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sstein(Layout layout, int n, float[] d,
            float[] e, int m, float[] w,
            int[] iblock, int[] isplit,
            float[] z, int ldz, int[] ifailv)
            => LAPACKE_sstein(layout, n, d,
                e, m, w,
                iblock, isplit,
                z, ldz, ifailv);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sstein_work(Layout layout, int n, float[] d,
            float[] e, int m, float[] w,
            int[] iblock,
            int[] isplit, float[] z,
            int ldz, float[] work, int[] iwork,
            int[] ifailv);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sstein_work(Layout layout, int n, float[] d,
            float[] e, int m, float[] w,
            int[] iblock,
            int[] isplit, float[] z,
            int ldz, float[] work, int[] iwork,
            int[] ifailv)
            => LAPACKE_sstein_work(layout, n, d,
                e, m, w,
                iblock,
                isplit, z,
                ldz, work, iwork,
                ifailv);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sstemr(Layout layout, char jobz, char range,
            int n, float[] d, float[] e, float vl, float vu,
            int il, int iu, int[] m,
            float[] w, float[] z, int ldz, int nzc,
            int[] isuppz, int[] tryrac);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sstemr(Layout layout, char jobz, char range,
            int n, float[] d, float[] e, float vl, float vu,
            int il, int iu, int[] m,
            float[] w, float[] z, int ldz, int nzc,
            int[] isuppz, int[] tryrac)
            => LAPACKE_sstemr(layout, jobz, range,
                n, d, e, vl, vu,
                il, iu, m,
                w, z, ldz, nzc,
                isuppz, tryrac);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sstemr_work(Layout layout, char jobz, char range,
            int n, float[] d, float[] e, float vl,
            float vu, int il, int iu,
            int[] m, float[] w, float[] z,
            int ldz, int nzc,
            int[] isuppz, int[] tryrac,
            float[] work, int lwork,
            int[] iwork, int liwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sstemr_work(Layout layout, char jobz, char range,
            int n, float[] d, float[] e, float vl,
            float vu, int il, int iu,
            int[] m, float[] w, float[] z,
            int ldz, int nzc,
            int[] isuppz, int[] tryrac,
            float[] work, int lwork,
            int[] iwork, int liwork)
            => LAPACKE_sstemr_work(layout, jobz, range,
                n, d, e, vl,
                vu, il, iu,
                m, w, z,
                ldz, nzc,
                isuppz, tryrac,
                work, lwork,
                iwork, liwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssteqr(Layout layout, char compz, int n, float[] d,
            float[] e, float[] z, int ldz);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ssteqr(Layout layout, char compz, int n, float[] d,
            float[] e, float[] z, int ldz)
            => LAPACKE_ssteqr(layout, compz, n, d,
                e, z, ldz);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssteqr_work(Layout layout, char compz, int n,
            float[] d, float[] e, float[] z, int ldz,
            float[] work);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ssteqr_work(Layout layout, char compz, int n,
            float[] d, float[] e, float[] z, int ldz,
            float[] work)
            => LAPACKE_ssteqr_work(layout, compz, n,
                d, e, z, ldz,
                work);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssterf(int n, float[] d, float[] e);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ssterf(int n, float[] d, float[] e)
            => LAPACKE_ssterf(n, d, e);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssterf_work(int n, float[] d, float[] e);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ssterf_work(int n, float[] d, float[] e)
            => LAPACKE_ssterf_work(n, d, e);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sstev(Layout layout, char jobz, int n, float[] d,
            float[] e, float[] z, int ldz);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sstev(Layout layout, char jobz, int n, float[] d,
            float[] e, float[] z, int ldz)
            => LAPACKE_sstev(layout, jobz, n, d,
                e, z, ldz);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sstev_work(Layout layout, char jobz, int n,
            float[] d, float[] e, float[] z, int ldz,
            float[] work);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sstev_work(Layout layout, char jobz, int n,
            float[] d, float[] e, float[] z, int ldz,
            float[] work)
            => LAPACKE_sstev_work(layout, jobz, n,
                d, e, z, ldz,
                work);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sstevd(Layout layout, char jobz, int n, float[] d,
            float[] e, float[] z, int ldz);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sstevd(Layout layout, char jobz, int n, float[] d,
            float[] e, float[] z, int ldz)
            => LAPACKE_sstevd(layout, jobz, n, d,
                e, z, ldz);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sstevd_work(Layout layout, char jobz, int n,
            float[] d, float[] e, float[] z, int ldz,
            float[] work, int lwork,
            int[] iwork, int liwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sstevd_work(Layout layout, char jobz, int n,
            float[] d, float[] e, float[] z, int ldz,
            float[] work, int lwork,
            int[] iwork, int liwork)
            => LAPACKE_sstevd_work(layout, jobz, n,
                d, e, z, ldz,
                work, lwork,
                iwork, liwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sstevr(Layout layout, char jobz, char range,
            int n, float[] d, float[] e, float vl, float vu,
            int il, int iu, float abstol,
            int[] m, float[] w, float[] z, int ldz,
            int[] isuppz);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sstevr(Layout layout, char jobz, char range,
            int n, float[] d, float[] e, float vl, float vu,
            int il, int iu, float abstol,
            int[] m, float[] w, float[] z, int ldz,
            int[] isuppz)
            => LAPACKE_sstevr(layout, jobz, range,
                n, d, e, vl, vu,
                il, iu, abstol,
                m, w, z, ldz,
                isuppz);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sstevr_work(Layout layout, char jobz, char range,
            int n, float[] d, float[] e, float vl,
            float vu, int il, int iu,
            float abstol, int[] m, float[] w, float[] z,
            int ldz, int[] isuppz, float[] work,
            int lwork, int[] iwork,
            int liwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sstevr_work(Layout layout, char jobz, char range,
            int n, float[] d, float[] e, float vl,
            float vu, int il, int iu,
            float abstol, int[] m, float[] w, float[] z,
            int ldz, int[] isuppz, float[] work,
            int lwork, int[] iwork,
            int liwork)
            => LAPACKE_sstevr_work(layout, jobz, range,
                n, d, e, vl,
                vu, il, iu,
                abstol, m, w, z,
                ldz, isuppz, work,
                lwork, iwork,
                liwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sstevx(Layout layout, char jobz, char range,
            int n, float[] d, float[] e, float vl, float vu,
            int il, int iu, float abstol,
            int[] m, float[] w, float[] z, int ldz,
            int[] ifail);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sstevx(Layout layout, char jobz, char range,
            int n, float[] d, float[] e, float vl, float vu,
            int il, int iu, float abstol,
            int[] m, float[] w, float[] z, int ldz,
            int[] ifail)
            => LAPACKE_sstevx(layout, jobz, range,
                n, d, e, vl, vu,
                il, iu, abstol,
                m, w, z, ldz,
                ifail);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sstevx_work(Layout layout, char jobz, char range,
            int n, float[] d, float[] e, float vl,
            float vu, int il, int iu,
            float abstol, int[] m, float[] w, float[] z,
            int ldz, float[] work, int[] iwork,
            int[] ifail);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sstevx_work(Layout layout, char jobz, char range,
            int n, float[] d, float[] e, float vl,
            float vu, int il, int iu,
            float abstol, int[] m, float[] w, float[] z,
            int ldz, float[] work, int[] iwork,
            int[] ifail)
            => LAPACKE_sstevx_work(layout, jobz, range,
                n, d, e, vl,
                vu, il, iu,
                abstol, m, w, z,
                ldz, work, iwork,
                ifail);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssycon(Layout layout, UpLo uplo, int n,
            float[] a, int lda,
            int[] ipiv, float anorm, float[] rcond);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ssycon(Layout layout, UpLo uplo, int n,
            float[] a, int lda,
            int[] ipiv, float anorm, float[] rcond)
            => LAPACKE_ssycon(layout, uplo, n,
                a, lda,
                ipiv, anorm, rcond);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssycon_work(Layout layout, UpLo uplo, int n,
            float[] a, int lda,
            int[] ipiv, float anorm,
            float[] rcond, float[] work, int[] iwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ssycon_work(Layout layout, UpLo uplo, int n,
            float[] a, int lda,
            int[] ipiv, float anorm,
            float[] rcond, float[] work, int[] iwork)
            => LAPACKE_ssycon_work(layout, uplo, n,
                a, lda,
                ipiv, anorm,
                rcond, work, iwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssyconv(Layout layout, UpLo uplo, char way, int n,
            float[] a, int lda, int[] ipiv,
            float[] e);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ssyconv(Layout layout, UpLo uplo, char way, int n,
            float[] a, int lda, int[] ipiv,
            float[] e)
            => LAPACKE_ssyconv(layout, uplo, way, n,
                a, lda, ipiv,
                e);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssyconv_work(Layout layout, UpLo uplo, char way,
            int n, float[] a, int lda,
            int[] ipiv, float[] e);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ssyconv_work(Layout layout, UpLo uplo, char way,
            int n, float[] a, int lda,
            int[] ipiv, float[] e)
            => LAPACKE_ssyconv_work(layout, uplo, way,
                n, a, lda,
                ipiv, e);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssyequb(Layout layout, UpLo uplo, int n,
            float[] a, int lda, float[] s,
            float[] scond, float[] amax);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ssyequb(Layout layout, UpLo uplo, int n,
            float[] a, int lda, float[] s,
            float[] scond, float[] amax)
            => LAPACKE_ssyequb(layout, uplo, n,
                a, lda, s,
                scond, amax);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssyequb_work(Layout layout, UpLo uplo, int n,
            float[] a, int lda, float[] s,
            float[] scond, float[] amax, float[] work);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ssyequb_work(Layout layout, UpLo uplo, int n,
            float[] a, int lda, float[] s,
            float[] scond, float[] amax, float[] work)
            => LAPACKE_ssyequb_work(layout, uplo, n,
                a, lda, s,
                scond, amax, work);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssyev(Layout layout, char jobz, UpLo uplo, int n,
            float[] a, int lda, float[] w);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ssyev(Layout layout, char jobz, UpLo uplo, int n,
            float[] a, int lda, float[] w)
            => LAPACKE_ssyev(layout, jobz, uplo, n,
                a, lda, w);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssyev_work(Layout layout, char jobz, UpLo uplo,
            int n, float[] a, int lda, float[] w,
            float[] work, int lwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ssyev_work(Layout layout, char jobz, UpLo uplo,
            int n, float[] a, int lda, float[] w,
            float[] work, int lwork)
            => LAPACKE_ssyev_work(layout, jobz, uplo,
                n, a, lda, w,
                work, lwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssyevd(Layout layout, char jobz, UpLo uplo, int n,
            float[] a, int lda, float[] w);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ssyevd(Layout layout, char jobz, UpLo uplo, int n,
            float[] a, int lda, float[] w)
            => LAPACKE_ssyevd(layout, jobz, uplo, n,
                a, lda, w);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssyevd_work(Layout layout, char jobz, UpLo uplo,
            int n, float[] a, int lda,
            float[] w, float[] work, int lwork,
            int[] iwork, int liwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ssyevd_work(Layout layout, char jobz, UpLo uplo,
            int n, float[] a, int lda,
            float[] w, float[] work, int lwork,
            int[] iwork, int liwork)
            => LAPACKE_ssyevd_work(layout, jobz, uplo,
                n, a, lda,
                w, work, lwork,
                iwork, liwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssyevr(Layout layout, char jobz, char range, UpLo uplo,
            int n, float[] a, int lda, float vl,
            float vu, int il, int iu, float abstol,
            int[] m, float[] w, float[] z, int ldz,
            int[] isuppz);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ssyevr(Layout layout, char jobz, char range, UpLo uplo,
            int n, float[] a, int lda, float vl,
            float vu, int il, int iu, float abstol,
            int[] m, float[] w, float[] z, int ldz,
            int[] isuppz)
            => LAPACKE_ssyevr(layout, jobz, range, uplo,
                n, a, lda, vl,
                vu, il, iu, abstol,
                m, w, z, ldz,
                isuppz);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssyevr_work(Layout layout, char jobz, char range,
            UpLo uplo, int n, float[] a,
            int lda, float vl, float vu,
            int il, int iu, float abstol,
            int[] m, float[] w, float[] z,
            int ldz, int[] isuppz, float[] work,
            int lwork, int[] iwork,
            int liwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ssyevr_work(Layout layout, char jobz, char range,
            UpLo uplo, int n, float[] a,
            int lda, float vl, float vu,
            int il, int iu, float abstol,
            int[] m, float[] w, float[] z,
            int ldz, int[] isuppz, float[] work,
            int lwork, int[] iwork,
            int liwork)
            => LAPACKE_ssyevr_work(layout, jobz, range,
                uplo, n, a,
                lda, vl, vu,
                il, iu, abstol,
                m, w, z,
                ldz, isuppz, work,
                lwork, iwork,
                liwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssyevx(Layout layout, char jobz, char range, UpLo uplo,
            int n, float[] a, int lda, float vl,
            float vu, int il, int iu, float abstol,
            int[] m, float[] w, float[] z, int ldz,
            int[] ifail);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ssyevx(Layout layout, char jobz, char range, UpLo uplo,
            int n, float[] a, int lda, float vl,
            float vu, int il, int iu, float abstol,
            int[] m, float[] w, float[] z, int ldz,
            int[] ifail)
            => LAPACKE_ssyevx(layout, jobz, range, uplo,
                n, a, lda, vl,
                vu, il, iu, abstol,
                m, w, z, ldz,
                ifail);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssyevx_work(Layout layout, char jobz, char range,
            UpLo uplo, int n, float[] a,
            int lda, float vl, float vu,
            int il, int iu, float abstol,
            int[] m, float[] w, float[] z,
            int ldz, float[] work, int lwork,
            int[] iwork, int[] ifail);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ssyevx_work(Layout layout, char jobz, char range,
            UpLo uplo, int n, float[] a,
            int lda, float vl, float vu,
            int il, int iu, float abstol,
            int[] m, float[] w, float[] z,
            int ldz, float[] work, int lwork,
            int[] iwork, int[] ifail)
            => LAPACKE_ssyevx_work(layout, jobz, range,
                uplo, n, a,
                lda, vl, vu,
                il, iu, abstol,
                m, w, z,
                ldz, work, lwork,
                iwork, ifail);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssygst(Layout layout, int itype, UpLo uplo,
            int n, float[] a, int lda,
            float[] b, int ldb);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ssygst(Layout layout, int itype, UpLo uplo,
            int n, float[] a, int lda,
            float[] b, int ldb)
            => LAPACKE_ssygst(layout, itype, uplo,
                n, a, lda,
                b, ldb);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssygst_work(Layout layout, int itype, UpLo uplo,
            int n, float[] a, int lda,
            float[] b, int ldb);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ssygst_work(Layout layout, int itype, UpLo uplo,
            int n, float[] a, int lda,
            float[] b, int ldb)
            => LAPACKE_ssygst_work(layout, itype, uplo,
                n, a, lda,
                b, ldb);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssygv(Layout layout, int itype, char jobz,
            UpLo uplo, int n, float[] a, int lda,
            float[] b, int ldb, float[] w);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ssygv(Layout layout, int itype, char jobz,
            UpLo uplo, int n, float[] a, int lda,
            float[] b, int ldb, float[] w)
            => LAPACKE_ssygv(layout, itype, jobz,
                uplo, n, a, lda,
                b, ldb, w);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssygv_work(Layout layout, int itype, char jobz,
            UpLo uplo, int n, float[] a,
            int lda, float[] b, int ldb,
            float[] w, float[] work, int lwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ssygv_work(Layout layout, int itype, char jobz,
            UpLo uplo, int n, float[] a,
            int lda, float[] b, int ldb,
            float[] w, float[] work, int lwork)
            => LAPACKE_ssygv_work(layout, itype, jobz,
                uplo, n, a,
                lda, b, ldb,
                w, work, lwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssygvd(Layout layout, int itype, char jobz,
            UpLo uplo, int n, float[] a, int lda,
            float[] b, int ldb, float[] w);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ssygvd(Layout layout, int itype, char jobz,
            UpLo uplo, int n, float[] a, int lda,
            float[] b, int ldb, float[] w)
            => LAPACKE_ssygvd(layout, itype, jobz,
                uplo, n, a, lda,
                b, ldb, w);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssygvd_work(Layout layout, int itype, char jobz,
            UpLo uplo, int n, float[] a,
            int lda, float[] b, int ldb,
            float[] w, float[] work, int lwork,
            int[] iwork, int liwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ssygvd_work(Layout layout, int itype, char jobz,
            UpLo uplo, int n, float[] a,
            int lda, float[] b, int ldb,
            float[] w, float[] work, int lwork,
            int[] iwork, int liwork)
            => LAPACKE_ssygvd_work(layout, itype, jobz,
                uplo, n, a,
                lda, b, ldb,
                w, work, lwork,
                iwork, liwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssygvx(Layout layout, int itype, char jobz,
            char range, UpLo uplo, int n, float[] a,
            int lda, float[] b, int ldb, float vl,
            float vu, int il, int iu, float abstol,
            int[] m, float[] w, float[] z, int ldz,
            int[] ifail);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ssygvx(Layout layout, int itype, char jobz,
            char range, UpLo uplo, int n, float[] a,
            int lda, float[] b, int ldb, float vl,
            float vu, int il, int iu, float abstol,
            int[] m, float[] w, float[] z, int ldz,
            int[] ifail)
            => LAPACKE_ssygvx(layout, itype, jobz,
                range, uplo, n, a,
                lda, b, ldb, vl,
                vu, il, iu, abstol,
                m, w, z, ldz,
                ifail);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssygvx_work(Layout layout, int itype, char jobz,
            char range, UpLo uplo, int n, float[] a,
            int lda, float[] b, int ldb,
            float vl, float vu, int il,
            int iu, float abstol, int[] m,
            float[] w, float[] z, int ldz, float[] work,
            int lwork, int[] iwork,
            int[] ifail);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ssygvx_work(Layout layout, int itype, char jobz,
            char range, UpLo uplo, int n, float[] a,
            int lda, float[] b, int ldb,
            float vl, float vu, int il,
            int iu, float abstol, int[] m,
            float[] w, float[] z, int ldz, float[] work,
            int lwork, int[] iwork,
            int[] ifail)
            => LAPACKE_ssygvx_work(layout, itype, jobz,
                range, uplo, n, a,
                lda, b, ldb,
                vl, vu, il,
                iu, abstol, m,
                w, z, ldz, work,
                lwork, iwork,
                ifail);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssyrfs(Layout layout, UpLo uplo, int n,
            int nrhs, float[] a, int lda,
            float[] af, int ldaf,
            int[] ipiv, float[] b,
            int ldb, float[] x, int ldx,
            float[] ferr, float[] berr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ssyrfs(Layout layout, UpLo uplo, int n,
            int nrhs, float[] a, int lda,
            float[] af, int ldaf,
            int[] ipiv, float[] b,
            int ldb, float[] x, int ldx,
            float[] ferr, float[] berr)
            => LAPACKE_ssyrfs(layout, uplo, n,
                nrhs, a, lda,
                af, ldaf,
                ipiv, b,
                ldb, x, ldx,
                ferr, berr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssyrfs_work(Layout layout, UpLo uplo, int n,
            int nrhs, float[] a, int lda,
            float[] af, int ldaf,
            int[] ipiv, float[] b,
            int ldb, float[] x, int ldx,
            float[] ferr, float[] berr, float[] work,
            int[] iwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ssyrfs_work(Layout layout, UpLo uplo, int n,
            int nrhs, float[] a, int lda,
            float[] af, int ldaf,
            int[] ipiv, float[] b,
            int ldb, float[] x, int ldx,
            float[] ferr, float[] berr, float[] work,
            int[] iwork)
            => LAPACKE_ssyrfs_work(layout, uplo, n,
                nrhs, a, lda,
                af, ldaf,
                ipiv, b,
                ldb, x, ldx,
                ferr, berr, work,
                iwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssyrfsx(Layout layout, UpLo uplo, char equed,
            int n, int nrhs, float[] a,
            int lda, float[] af, int ldaf,
            int[] ipiv, float[] s,
            float[] b, int ldb, float[] x,
            int ldx, float[] rcond, float[] berr,
            int n_err_bnds, float[] err_bnds_norm,
            float[] err_bnds_comp, int nparams,
            float[] aparams);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ssyrfsx(Layout layout, UpLo uplo, char equed,
            int n, int nrhs, float[] a,
            int lda, float[] af, int ldaf,
            int[] ipiv, float[] s,
            float[] b, int ldb, float[] x,
            int ldx, float[] rcond, float[] berr,
            int n_err_bnds, float[] err_bnds_norm,
            float[] err_bnds_comp, int nparams,
            float[] aparams)
            => LAPACKE_ssyrfsx(layout, uplo, equed,
                n, nrhs, a,
                lda, af, ldaf,
                ipiv, s,
                b, ldb, x,
                ldx, rcond, berr,
                n_err_bnds, err_bnds_norm,
                err_bnds_comp, nparams,
                aparams);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssyrfsx_work(Layout layout, UpLo uplo, char equed,
            int n, int nrhs, float[] a,
            int lda, float[] af,
            int ldaf, int[] ipiv,
            float[] s, float[] b, int ldb,
            float[] x, int ldx, float[] rcond,
            float[] berr, int n_err_bnds,
            float[] err_bnds_norm, float[] err_bnds_comp,
            int nparams, float[] aparams, float[] work,
            int[] iwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ssyrfsx_work(Layout layout, UpLo uplo, char equed,
            int n, int nrhs, float[] a,
            int lda, float[] af,
            int ldaf, int[] ipiv,
            float[] s, float[] b, int ldb,
            float[] x, int ldx, float[] rcond,
            float[] berr, int n_err_bnds,
            float[] err_bnds_norm, float[] err_bnds_comp,
            int nparams, float[] aparams, float[] work,
            int[] iwork)
            => LAPACKE_ssyrfsx_work(layout, uplo, equed,
                n, nrhs, a,
                lda, af,
                ldaf, ipiv,
                s, b, ldb,
                x, ldx, rcond,
                berr, n_err_bnds,
                err_bnds_norm, err_bnds_comp,
                nparams, aparams, work,
                iwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssysv(Layout layout, UpLo uplo, int n,
            int nrhs, float[] a, int lda,
            int[] ipiv, float[] b, int ldb);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ssysv(Layout layout, UpLo uplo, int n,
            int nrhs, float[] a, int lda,
            int[] ipiv, float[] b, int ldb)
            => LAPACKE_ssysv(layout, uplo, n,
                nrhs, a, lda,
                ipiv, b, ldb);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssysv_rook(Layout layout, UpLo uplo, int n,
            int nrhs, float[] a, int lda,
            int[] ipiv, float[] b, int ldb);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ssysv_rook(Layout layout, UpLo uplo, int n,
            int nrhs, float[] a, int lda,
            int[] ipiv, float[] b, int ldb)
            => LAPACKE_ssysv_rook(layout, uplo, n,
                nrhs, a, lda,
                ipiv, b, ldb);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssysv_rook_work(Layout layout, UpLo uplo, int n,
            int nrhs, float[] a, int lda,
            int[] ipiv, float[] b, int ldb,
            float[] work, int lwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ssysv_rook_work(Layout layout, UpLo uplo, int n,
            int nrhs, float[] a, int lda,
            int[] ipiv, float[] b, int ldb,
            float[] work, int lwork)
            => LAPACKE_ssysv_rook_work(layout, uplo, n,
                nrhs, a, lda,
                ipiv, b, ldb,
                work, lwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssysv_work(Layout layout, UpLo uplo, int n,
            int nrhs, float[] a, int lda,
            int[] ipiv, float[] b, int ldb,
            float[] work, int lwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ssysv_work(Layout layout, UpLo uplo, int n,
            int nrhs, float[] a, int lda,
            int[] ipiv, float[] b, int ldb,
            float[] work, int lwork)
            => LAPACKE_ssysv_work(layout, uplo, n,
                nrhs, a, lda,
                ipiv, b, ldb,
                work, lwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssysvx(Layout layout, char fact, UpLo uplo, int n,
            int nrhs, float[] a, int lda,
            float[] af, int ldaf, int[] ipiv,
            float[] b, int ldb, float[] x,
            int ldx, float[] rcond, float[] ferr,
            float[] berr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ssysvx(Layout layout, char fact, UpLo uplo, int n,
            int nrhs, float[] a, int lda,
            float[] af, int ldaf, int[] ipiv,
            float[] b, int ldb, float[] x,
            int ldx, float[] rcond, float[] ferr,
            float[] berr)
            => LAPACKE_ssysvx(layout, fact, uplo, n,
                nrhs, a, lda,
                af, ldaf, ipiv,
                b, ldb, x,
                ldx, rcond, ferr,
                berr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssysvx_work(Layout layout, char fact, UpLo uplo,
            int n, int nrhs, float[] a,
            int lda, float[] af, int ldaf,
            int[] ipiv, float[] b,
            int ldb, float[] x, int ldx,
            float[] rcond, float[] ferr, float[] berr,
            float[] work, int lwork,
            int[] iwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ssysvx_work(Layout layout, char fact, UpLo uplo,
            int n, int nrhs, float[] a,
            int lda, float[] af, int ldaf,
            int[] ipiv, float[] b,
            int ldb, float[] x, int ldx,
            float[] rcond, float[] ferr, float[] berr,
            float[] work, int lwork,
            int[] iwork)
            => LAPACKE_ssysvx_work(layout, fact, uplo,
                n, nrhs, a,
                lda, af, ldaf,
                ipiv, b,
                ldb, x, ldx,
                rcond, ferr, berr,
                work, lwork,
                iwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssysvxx(Layout layout, char fact, UpLo uplo,
            int n, int nrhs, float[] a,
            int lda, float[] af, int ldaf,
            int[] ipiv, char[] equed, float[] s, float[] b,
            int ldb, float[] x, int ldx,
            float[] rcond, float[] rpvgrw, float[] berr,
            int n_err_bnds, float[] err_bnds_norm,
            float[] err_bnds_comp, int nparams,
            float[] aparams);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ssysvxx(Layout layout, char fact, UpLo uplo,
            int n, int nrhs, float[] a,
            int lda, float[] af, int ldaf,
            int[] ipiv, char[] equed, float[] s, float[] b,
            int ldb, float[] x, int ldx,
            float[] rcond, float[] rpvgrw, float[] berr,
            int n_err_bnds, float[] err_bnds_norm,
            float[] err_bnds_comp, int nparams,
            float[] aparams)
            => LAPACKE_ssysvxx(layout, fact, uplo,
                n, nrhs, a,
                lda, af, ldaf,
                ipiv, equed, s, b,
                ldb, x, ldx,
                rcond, rpvgrw, berr,
                n_err_bnds, err_bnds_norm,
                err_bnds_comp, nparams,
                aparams);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssysvxx_work(Layout layout, char fact, UpLo uplo,
            int n, int nrhs, float[] a,
            int lda, float[] af, int ldaf,
            int[] ipiv, char[] equed, float[] s,
            float[] b, int ldb, float[] x,
            int ldx, float[] rcond, float[] rpvgrw,
            float[] berr, int n_err_bnds,
            float[] err_bnds_norm, float[] err_bnds_comp,
            int nparams, float[] aparams, float[] work,
            int[] iwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ssysvxx_work(Layout layout, char fact, UpLo uplo,
            int n, int nrhs, float[] a,
            int lda, float[] af, int ldaf,
            int[] ipiv, char[] equed, float[] s,
            float[] b, int ldb, float[] x,
            int ldx, float[] rcond, float[] rpvgrw,
            float[] berr, int n_err_bnds,
            float[] err_bnds_norm, float[] err_bnds_comp,
            int nparams, float[] aparams, float[] work,
            int[] iwork)
            => LAPACKE_ssysvxx_work(layout, fact, uplo,
                n, nrhs, a,
                lda, af, ldaf,
                ipiv, equed, s,
                b, ldb, x,
                ldx, rcond, rpvgrw,
                berr, n_err_bnds,
                err_bnds_norm, err_bnds_comp,
                nparams, aparams, work,
                iwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssyswapr(Layout layout, UpLo uplo, int n,
            float[] a, int lda, int i1, int i2);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ssyswapr(Layout layout, UpLo uplo, int n,
            float[] a, int lda, int i1, int i2)
            => LAPACKE_ssyswapr(layout, uplo, n,
                a, lda, i1, i2);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssyswapr_work(Layout layout, UpLo uplo, int n,
            float[] a, int lda,
            int i1, int i2);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ssyswapr_work(Layout layout, UpLo uplo, int n,
            float[] a, int lda,
            int i1, int i2)
            => LAPACKE_ssyswapr_work(layout, uplo, n,
                a, lda,
                i1, i2);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssytrd(Layout layout, UpLo uplo, int n, float[] a,
            int lda, float[] d, float[] e, float[] tau);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ssytrd(Layout layout, UpLo uplo, int n, float[] a,
            int lda, float[] d, float[] e, float[] tau)
            => LAPACKE_ssytrd(layout, uplo, n, a,
                lda, d, e, tau);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssytrd_work(Layout layout, UpLo uplo, int n,
            float[] a, int lda, float[] d, float[] e,
            float[] tau, float[] work, int lwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ssytrd_work(Layout layout, UpLo uplo, int n,
            float[] a, int lda, float[] d, float[] e,
            float[] tau, float[] work, int lwork)
            => LAPACKE_ssytrd_work(layout, uplo, n,
                a, lda, d, e,
                tau, work, lwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssytrf(Layout layout, UpLo uplo, int n, float[] a,
            int lda, int[] ipiv);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ssytrf(Layout layout, UpLo uplo, int n, float[] a,
            int lda, int[] ipiv)
            => LAPACKE_ssytrf(layout, uplo, n, a,
                lda, ipiv);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssytrf_rook(Layout layout, UpLo uplo, int n, float[] a,
            int lda, int[] ipiv);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ssytrf_rook(Layout layout, UpLo uplo, int n, float[] a,
            int lda, int[] ipiv)
            => LAPACKE_ssytrf_rook(layout, uplo, n, a,
                lda, ipiv);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssytrf_rook_work(Layout layout, UpLo uplo, int n,
            float[] a, int lda, int[] ipiv,
            float[] work, int lwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ssytrf_rook_work(Layout layout, UpLo uplo, int n,
            float[] a, int lda, int[] ipiv,
            float[] work, int lwork)
            => LAPACKE_ssytrf_rook_work(layout, uplo, n,
                a, lda, ipiv,
                work, lwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssytrf_work(Layout layout, UpLo uplo, int n,
            float[] a, int lda, int[] ipiv,
            float[] work, int lwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ssytrf_work(Layout layout, UpLo uplo, int n,
            float[] a, int lda, int[] ipiv,
            float[] work, int lwork)
            => LAPACKE_ssytrf_work(layout, uplo, n,
                a, lda, ipiv,
                work, lwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssytri(Layout layout, UpLo uplo, int n, float[] a,
            int lda, int[] ipiv);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ssytri(Layout layout, UpLo uplo, int n, float[] a,
            int lda, int[] ipiv)
            => LAPACKE_ssytri(layout, uplo, n, a,
                lda, ipiv);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssytri2(Layout layout, UpLo uplo, int n, float[] a,
            int lda, int[] ipiv);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ssytri2(Layout layout, UpLo uplo, int n, float[] a,
            int lda, int[] ipiv)
            => LAPACKE_ssytri2(layout, uplo, n, a,
                lda, ipiv);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssytri2_work(Layout layout, UpLo uplo, int n,
            float[] a, int lda,
            int[] ipiv,
            float[] work, int lwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ssytri2_work(Layout layout, UpLo uplo, int n,
            float[] a, int lda,
            int[] ipiv,
            float[] work, int lwork)
            => LAPACKE_ssytri2_work(layout, uplo, n,
                a, lda,
                ipiv,
                work, lwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssytri2x(Layout layout, UpLo uplo, int n,
            float[] a, int lda, int[] ipiv,
            int nb);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ssytri2x(Layout layout, UpLo uplo, int n,
            float[] a, int lda, int[] ipiv,
            int nb)
            => LAPACKE_ssytri2x(layout, uplo, n,
                a, lda, ipiv,
                nb);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssytri2x_work(Layout layout, UpLo uplo, int n,
            float[] a, int lda,
            int[] ipiv, float[] work,
            int nb);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ssytri2x_work(Layout layout, UpLo uplo, int n,
            float[] a, int lda,
            int[] ipiv, float[] work,
            int nb)
            => LAPACKE_ssytri2x_work(layout, uplo, n,
                a, lda,
                ipiv, work,
                nb);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssytri_work(Layout layout, UpLo uplo, int n,
            float[] a, int lda,
            int[] ipiv, float[] work);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ssytri_work(Layout layout, UpLo uplo, int n,
            float[] a, int lda,
            int[] ipiv, float[] work)
            => LAPACKE_ssytri_work(layout, uplo, n,
                a, lda,
                ipiv, work);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssytrs(Layout layout, UpLo uplo, int n,
            int nrhs, float[] a, int lda,
            int[] ipiv, float[] b, int ldb);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ssytrs(Layout layout, UpLo uplo, int n,
            int nrhs, float[] a, int lda,
            int[] ipiv, float[] b, int ldb)
            => LAPACKE_ssytrs(layout, uplo, n,
                nrhs, a, lda,
                ipiv, b, ldb);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssytrs2(Layout layout, UpLo uplo, int n,
            int nrhs, float[] a, int lda,
            int[] ipiv, float[] b, int ldb);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ssytrs2(Layout layout, UpLo uplo, int n,
            int nrhs, float[] a, int lda,
            int[] ipiv, float[] b, int ldb)
            => LAPACKE_ssytrs2(layout, uplo, n,
                nrhs, a, lda,
                ipiv, b, ldb);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssytrs2_work(Layout layout, UpLo uplo, int n,
            int nrhs, float[] a,
            int lda, int[] ipiv,
            float[] b, int ldb, float[] work);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ssytrs2_work(Layout layout, UpLo uplo, int n,
            int nrhs, float[] a,
            int lda, int[] ipiv,
            float[] b, int ldb, float[] work)
            => LAPACKE_ssytrs2_work(layout, uplo, n,
                nrhs, a,
                lda, ipiv,
                b, ldb, work);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssytrs_rook(Layout layout, UpLo uplo, int n,
            int nrhs, float[] a, int lda,
            int[] ipiv, float[] b, int ldb);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ssytrs_rook(Layout layout, UpLo uplo, int n,
            int nrhs, float[] a, int lda,
            int[] ipiv, float[] b, int ldb)
            => LAPACKE_ssytrs_rook(layout, uplo, n,
                nrhs, a, lda,
                ipiv, b, ldb);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssytrs_rook_work(Layout layout, UpLo uplo, int n,
            int nrhs, float[] a, int lda,
            int[] ipiv, float[] b,
            int ldb);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ssytrs_rook_work(Layout layout, UpLo uplo, int n,
            int nrhs, float[] a, int lda,
            int[] ipiv, float[] b,
            int ldb)
            => LAPACKE_ssytrs_rook_work(layout, uplo, n,
                nrhs, a, lda,
                ipiv, b,
                ldb);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssytrs_work(Layout layout, UpLo uplo, int n,
            int nrhs, float[] a, int lda,
            int[] ipiv, float[] b,
            int ldb);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ssytrs_work(Layout layout, UpLo uplo, int n,
            int nrhs, float[] a, int lda,
            int[] ipiv, float[] b,
            int ldb)
            => LAPACKE_ssytrs_work(layout, uplo, n,
                nrhs, a, lda,
                ipiv, b,
                ldb);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_stbcon(Layout layout, Norm norm, UpLo uplo, DiagChar diag,
            int n, int kd, float[] ab,
            int ldab, float[] rcond);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int stbcon(Layout layout, Norm norm, UpLo uplo, DiagChar diag,
            int n, int kd, float[] ab,
            int ldab, float[] rcond)
            => LAPACKE_stbcon(layout, norm, uplo, diag,
                n, kd, ab,
                ldab, rcond);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_stbcon_work(Layout layout, Norm norm, UpLo uplo,
            DiagChar diag, int n, int kd,
            float[] ab, int ldab, float[] rcond,
            float[] work, int[] iwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int stbcon_work(Layout layout, Norm norm, UpLo uplo,
            DiagChar diag, int n, int kd,
            float[] ab, int ldab, float[] rcond,
            float[] work, int[] iwork)
            => LAPACKE_stbcon_work(layout, norm, uplo,
                diag, n, kd,
                ab, ldab, rcond,
                work, iwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_stbrfs(Layout layout, UpLo uplo, TransChar trans, DiagChar diag,
            int n, int kd, int nrhs,
            float[] ab, int ldab, float[] b,
            int ldb, float[] x, int ldx,
            float[] ferr, float[] berr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int stbrfs(Layout layout, UpLo uplo, TransChar trans, DiagChar diag,
            int n, int kd, int nrhs,
            float[] ab, int ldab, float[] b,
            int ldb, float[] x, int ldx,
            float[] ferr, float[] berr)
            => LAPACKE_stbrfs(layout, uplo, trans, diag,
                n, kd, nrhs,
                ab, ldab, b,
                ldb, x, ldx,
                ferr, berr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_stbrfs_work(Layout layout, UpLo uplo, TransChar trans,
            DiagChar diag, int n, int kd,
            int nrhs, float[] ab,
            int ldab, float[] b, int ldb,
            float[] x, int ldx, float[] ferr,
            float[] berr, float[] work, int[] iwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int stbrfs_work(Layout layout, UpLo uplo, TransChar trans,
            DiagChar diag, int n, int kd,
            int nrhs, float[] ab,
            int ldab, float[] b, int ldb,
            float[] x, int ldx, float[] ferr,
            float[] berr, float[] work, int[] iwork)
            => LAPACKE_stbrfs_work(layout, uplo, trans,
                diag, n, kd,
                nrhs, ab,
                ldab, b, ldb,
                x, ldx, ferr,
                berr, work, iwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_stbtrs(Layout layout, UpLo uplo, TransChar trans, DiagChar diag,
            int n, int kd, int nrhs,
            float[] ab, int ldab, float[] b,
            int ldb);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int stbtrs(Layout layout, UpLo uplo, TransChar trans, DiagChar diag,
            int n, int kd, int nrhs,
            float[] ab, int ldab, float[] b,
            int ldb)
            => LAPACKE_stbtrs(layout, uplo, trans, diag,
                n, kd, nrhs,
                ab, ldab, b,
                ldb);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_stbtrs_work(Layout layout, UpLo uplo, TransChar trans,
            DiagChar diag, int n, int kd,
            int nrhs, float[] ab,
            int ldab, float[] b, int ldb);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int stbtrs_work(Layout layout, UpLo uplo, TransChar trans,
            DiagChar diag, int n, int kd,
            int nrhs, float[] ab,
            int ldab, float[] b, int ldb)
            => LAPACKE_stbtrs_work(layout, uplo, trans,
                diag, n, kd,
                nrhs, ab,
                ldab, b, ldb);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_stfsm(Layout layout, TransChar transr, char side, UpLo uplo,
            TransChar trans, DiagChar diag, int m, int n,
            float alpha, float[] a, float[] b,
            int ldb);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int stfsm(Layout layout, TransChar transr, char side, UpLo uplo,
            TransChar trans, DiagChar diag, int m, int n,
            float alpha, float[] a, float[] b,
            int ldb)
            => LAPACKE_stfsm(layout, transr, side, uplo,
                trans, diag, m, n,
                alpha, a, b,
                ldb);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_stfsm_work(Layout layout, TransChar transr, char side,
            UpLo uplo, TransChar trans, DiagChar diag, int m,
            int n, float alpha, float[] a,
            float[] b, int ldb);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int stfsm_work(Layout layout, TransChar transr, char side,
            UpLo uplo, TransChar trans, DiagChar diag, int m,
            int n, float alpha, float[] a,
            float[] b, int ldb)
            => LAPACKE_stfsm_work(layout, transr, side,
                uplo, trans, diag, m,
                n, alpha, a,
                b, ldb);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_stftri(Layout layout, TransChar transr, UpLo uplo, DiagChar diag,
            int n, float[] a);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int stftri(Layout layout, TransChar transr, UpLo uplo, DiagChar diag,
            int n, float[] a)
            => LAPACKE_stftri(layout, transr, uplo, diag,
                n, a);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_stftri_work(Layout layout, TransChar transr, UpLo uplo,
            DiagChar diag, int n, float[] a);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int stftri_work(Layout layout, TransChar transr, UpLo uplo,
            DiagChar diag, int n, float[] a)
            => LAPACKE_stftri_work(layout, transr, uplo,
                diag, n, a);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_stfttp(Layout layout, TransChar transr, UpLo uplo,
            int n, float[] arf, float[] ap);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int stfttp(Layout layout, TransChar transr, UpLo uplo,
            int n, float[] arf, float[] ap)
            => LAPACKE_stfttp(layout, transr, uplo,
                n, arf, ap);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_stfttp_work(Layout layout, TransChar transr, UpLo uplo,
            int n, float[] arf, float[] ap);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int stfttp_work(Layout layout, TransChar transr, UpLo uplo,
            int n, float[] arf, float[] ap)
            => LAPACKE_stfttp_work(layout, transr, uplo,
                n, arf, ap);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_stfttr(Layout layout, TransChar transr, UpLo uplo,
            int n, float[] arf, float[] a,
            int lda);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int stfttr(Layout layout, TransChar transr, UpLo uplo,
            int n, float[] arf, float[] a,
            int lda)
            => LAPACKE_stfttr(layout, transr, uplo,
                n, arf, a,
                lda);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_stfttr_work(Layout layout, TransChar transr, UpLo uplo,
            int n, float[] arf, float[] a,
            int lda);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int stfttr_work(Layout layout, TransChar transr, UpLo uplo,
            int n, float[] arf, float[] a,
            int lda)
            => LAPACKE_stfttr_work(layout, transr, uplo,
                n, arf, a,
                lda);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_stgevc(Layout layout, char side, char howmny,
            int[] select, int n,
            float[] s, int lds, float[] p,
            int ldp, float[] vl, int ldvl,
            float[] vr, int ldvr, int mm,
            int[] m);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int stgevc(Layout layout, char side, char howmny,
            int[] select, int n,
            float[] s, int lds, float[] p,
            int ldp, float[] vl, int ldvl,
            float[] vr, int ldvr, int mm,
            int[] m)
            => LAPACKE_stgevc(layout, side, howmny,
                select, n,
                s, lds, p,
                ldp, vl, ldvl,
                vr, ldvr, mm,
                m);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_stgevc_work(Layout layout, char side, char howmny,
            int[] select, int n,
            float[] s, int lds, float[] p,
            int ldp, float[] vl, int ldvl,
            float[] vr, int ldvr, int mm,
            int[] m, float[] work);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int stgevc_work(Layout layout, char side, char howmny,
            int[] select, int n,
            float[] s, int lds, float[] p,
            int ldp, float[] vl, int ldvl,
            float[] vr, int ldvr, int mm,
            int[] m, float[] work)
            => LAPACKE_stgevc_work(layout, side, howmny,
                select, n,
                s, lds, p,
                ldp, vl, ldvl,
                vr, ldvr, mm,
                m, work);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_stgexc(Layout layout, int wantq,
            int wantz, int n, float[] a,
            int lda, float[] b, int ldb, float[] q,
            int ldq, float[] z, int ldz,
            int[] ifst, int[] ilst);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int stgexc(Layout layout, int wantq,
            int wantz, int n, float[] a,
            int lda, float[] b, int ldb, float[] q,
            int ldq, float[] z, int ldz,
            int[] ifst, int[] ilst)
            => LAPACKE_stgexc(layout, wantq,
                wantz, n, a,
                lda, b, ldb, q,
                ldq, z, ldz,
                ifst, ilst);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_stgexc_work(Layout layout, int wantq,
            int wantz, int n, float[] a,
            int lda, float[] b, int ldb,
            float[] q, int ldq, float[] z,
            int ldz, int[] ifst,
            int[] ilst, float[] work,
            int lwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int stgexc_work(Layout layout, int wantq,
            int wantz, int n, float[] a,
            int lda, float[] b, int ldb,
            float[] q, int ldq, float[] z,
            int ldz, int[] ifst,
            int[] ilst, float[] work,
            int lwork)
            => LAPACKE_stgexc_work(layout, wantq,
                wantz, n, a,
                lda, b, ldb,
                q, ldq, z,
                ldz, ifst,
                ilst, work,
                lwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_stgsen(Layout layout, int ijob,
            int wantq, int wantz,
            int[] select, int n, float[] a,
            int lda, float[] b, int ldb,
            float[] alphar, float[] alphai, float[] beta, float[] q,
            int ldq, float[] z, int ldz,
            int[] m, float[] pl, float[] pr, float[] dif);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int stgsen(Layout layout, int ijob,
            int wantq, int wantz,
            int[] select, int n, float[] a,
            int lda, float[] b, int ldb,
            float[] alphar, float[] alphai, float[] beta, float[] q,
            int ldq, float[] z, int ldz,
            int[] m, float[] pl, float[] pr, float[] dif)
            => LAPACKE_stgsen(layout, ijob,
                wantq, wantz,
                select, n, a,
                lda, b, ldb,
                alphar, alphai, beta, q,
                ldq, z, ldz,
                m, pl, pr, dif);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_stgsen_work(Layout layout, int ijob,
            int wantq, int wantz,
            int[] select, int n,
            float[] a, int lda, float[] b,
            int ldb, float[] alphar, float[] alphai,
            float[] beta, float[] q, int ldq, float[] z,
            int ldz, int[] m, float[] pl,
            float[] pr, float[] dif, float[] work,
            int lwork, int[] iwork,
            int liwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int stgsen_work(Layout layout, int ijob,
            int wantq, int wantz,
            int[] select, int n,
            float[] a, int lda, float[] b,
            int ldb, float[] alphar, float[] alphai,
            float[] beta, float[] q, int ldq, float[] z,
            int ldz, int[] m, float[] pl,
            float[] pr, float[] dif, float[] work,
            int lwork, int[] iwork,
            int liwork)
            => LAPACKE_stgsen_work(layout, ijob,
                wantq, wantz,
                select, n,
                a, lda, b,
                ldb, alphar, alphai,
                beta, q, ldq, z,
                ldz, m, pl,
                pr, dif, work,
                lwork, iwork,
                liwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_stgsja(Layout layout, char jobu, char jobv, char jobq,
            int m, int p, int n,
            int k, int l, float[] a, int lda,
            float[] b, int ldb, float tola, float tolb,
            float[] alpha, float[] beta, float[] u, int ldu,
            float[] v, int ldv, float[] q, int ldq,
            int[] ncycle);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int stgsja(Layout layout, char jobu, char jobv, char jobq,
            int m, int p, int n,
            int k, int l, float[] a, int lda,
            float[] b, int ldb, float tola, float tolb,
            float[] alpha, float[] beta, float[] u, int ldu,
            float[] v, int ldv, float[] q, int ldq,
            int[] ncycle)
            => LAPACKE_stgsja(layout, jobu, jobv, jobq,
                m, p, n,
                k, l, a, lda,
                b, ldb, tola, tolb,
                alpha, beta, u, ldu,
                v, ldv, q, ldq,
                ncycle);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_stgsja_work(Layout layout, char jobu, char jobv,
            char jobq, int m, int p,
            int n, int k, int l,
            float[] a, int lda, float[] b,
            int ldb, float tola, float tolb,
            float[] alpha, float[] beta, float[] u,
            int ldu, float[] v, int ldv,
            float[] q, int ldq, float[] work,
            int[] ncycle);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int stgsja_work(Layout layout, char jobu, char jobv,
            char jobq, int m, int p,
            int n, int k, int l,
            float[] a, int lda, float[] b,
            int ldb, float tola, float tolb,
            float[] alpha, float[] beta, float[] u,
            int ldu, float[] v, int ldv,
            float[] q, int ldq, float[] work,
            int[] ncycle)
            => LAPACKE_stgsja_work(layout, jobu, jobv,
                jobq, m, p,
                n, k, l,
                a, lda, b,
                ldb, tola, tolb,
                alpha, beta, u,
                ldu, v, ldv,
                q, ldq, work,
                ncycle);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_stgsna(Layout layout, char job, char howmny,
            int[] select, int n,
            float[] a, int lda, float[] b,
            int ldb, float[] vl, int ldvl,
            float[] vr, int ldvr, float[] s,
            float[] dif, int mm, int[] m);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int stgsna(Layout layout, char job, char howmny,
            int[] select, int n,
            float[] a, int lda, float[] b,
            int ldb, float[] vl, int ldvl,
            float[] vr, int ldvr, float[] s,
            float[] dif, int mm, int[] m)
            => LAPACKE_stgsna(layout, job, howmny,
                select, n,
                a, lda, b,
                ldb, vl, ldvl,
                vr, ldvr, s,
                dif, mm, m);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_stgsna_work(Layout layout, char job, char howmny,
            int[] select, int n,
            float[] a, int lda, float[] b,
            int ldb, float[] vl,
            int ldvl, float[] vr,
            int ldvr, float[] s, float[] dif,
            int mm, int[] m, float[] work,
            int lwork, int[] iwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int stgsna_work(Layout layout, char job, char howmny,
            int[] select, int n,
            float[] a, int lda, float[] b,
            int ldb, float[] vl,
            int ldvl, float[] vr,
            int ldvr, float[] s, float[] dif,
            int mm, int[] m, float[] work,
            int lwork, int[] iwork)
            => LAPACKE_stgsna_work(layout, job, howmny,
                select, n,
                a, lda, b,
                ldb, vl,
                ldvl, vr,
                ldvr, s, dif,
                mm, m, work,
                lwork, iwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_stgsyl(Layout layout, TransChar trans, int ijob,
            int m, int n, float[] a,
            int lda, float[] b, int ldb,
            float[] c, int ldc, float[] d,
            int ldd, float[] e, int lde,
            float[] f, int ldf, float[] scale, float[] dif);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int stgsyl(Layout layout, TransChar trans, int ijob,
            int m, int n, float[] a,
            int lda, float[] b, int ldb,
            float[] c, int ldc, float[] d,
            int ldd, float[] e, int lde,
            float[] f, int ldf, float[] scale, float[] dif)
            => LAPACKE_stgsyl(layout, trans, ijob,
                m, n, a,
                lda, b, ldb,
                c, ldc, d,
                ldd, e, lde,
                f, ldf, scale, dif);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_stgsyl_work(Layout layout, TransChar trans, int ijob,
            int m, int n, float[] a,
            int lda, float[] b, int ldb,
            float[] c, int ldc, float[] d,
            int ldd, float[] e, int lde,
            float[] f, int ldf, float[] scale,
            float[] dif, float[] work, int lwork,
            int[] iwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int stgsyl_work(Layout layout, TransChar trans, int ijob,
            int m, int n, float[] a,
            int lda, float[] b, int ldb,
            float[] c, int ldc, float[] d,
            int ldd, float[] e, int lde,
            float[] f, int ldf, float[] scale,
            float[] dif, float[] work, int lwork,
            int[] iwork)
            => LAPACKE_stgsyl_work(layout, trans, ijob,
                m, n, a,
                lda, b, ldb,
                c, ldc, d,
                ldd, e, lde,
                f, ldf, scale,
                dif, work, lwork,
                iwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_stpcon(Layout layout, Norm norm, UpLo uplo, DiagChar diag,
            int n, float[] ap, float[] rcond);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int stpcon(Layout layout, Norm norm, UpLo uplo, DiagChar diag,
            int n, float[] ap, float[] rcond)
            => LAPACKE_stpcon(layout, norm, uplo, diag,
                n, ap, rcond);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_stpcon_work(Layout layout, Norm norm, UpLo uplo,
            DiagChar diag, int n, float[] ap,
            float[] rcond, float[] work, int[] iwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int stpcon_work(Layout layout, Norm norm, UpLo uplo,
            DiagChar diag, int n, float[] ap,
            float[] rcond, float[] work, int[] iwork)
            => LAPACKE_stpcon_work(layout, norm, uplo,
                diag, n, ap,
                rcond, work, iwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_stpmqrt(Layout layout, char side, TransChar trans,
            int m, int n, int k,
            int l, int nb, float[] v,
            int ldv, float[] t, int ldt,
            float[] a, int lda, float[] b, int ldb);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int stpmqrt(Layout layout, char side, TransChar trans,
            int m, int n, int k,
            int l, int nb, float[] v,
            int ldv, float[] t, int ldt,
            float[] a, int lda, float[] b, int ldb)
            => LAPACKE_stpmqrt(layout, side, trans,
                m, n, k,
                l, nb, v,
                ldv, t, ldt,
                a, lda, b, ldb);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_stpmqrt_work(Layout layout, char side, TransChar trans,
            int m, int n, int k,
            int l, int nb, float[] v,
            int ldv, float[] t, int ldt,
            float[] a, int lda, float[] b,
            int ldb, float[] work);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int stpmqrt_work(Layout layout, char side, TransChar trans,
            int m, int n, int k,
            int l, int nb, float[] v,
            int ldv, float[] t, int ldt,
            float[] a, int lda, float[] b,
            int ldb, float[] work)
            => LAPACKE_stpmqrt_work(layout, side, trans,
                m, n, k,
                l, nb, v,
                ldv, t, ldt,
                a, lda, b,
                ldb, work);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_stpqrt(Layout layout, int m, int n,
            int l, int nb, float[] a,
            int lda, float[] b, int ldb, float[] t,
            int ldt);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int stpqrt(Layout layout, int m, int n,
            int l, int nb, float[] a,
            int lda, float[] b, int ldb, float[] t,
            int ldt)
            => LAPACKE_stpqrt(layout, m, n,
                l, nb, a,
                lda, b, ldb, t,
                ldt);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_stpqrt2(Layout layout, int m, int n,
            int l,
            float[] a, int lda, float[] b, int ldb,
            float[] t, int ldt);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int stpqrt2(Layout layout, int m, int n,
            int l,
            float[] a, int lda, float[] b, int ldb,
            float[] t, int ldt)
            => LAPACKE_stpqrt2(layout, m, n,
                l,
                a, lda, b, ldb,
                t, ldt);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_stpqrt2_work(Layout layout, int m, int n,
            int l, float[] a, int lda, float[] b,
            int ldb, float[] t, int ldt);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int stpqrt2_work(Layout layout, int m, int n,
            int l, float[] a, int lda, float[] b,
            int ldb, float[] t, int ldt)
            => LAPACKE_stpqrt2_work(layout, m, n,
                l, a, lda, b,
                ldb, t, ldt);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_stpqrt_work(Layout layout, int m, int n,
            int l, int nb, float[] a,
            int lda, float[] b, int ldb,
            float[] t, int ldt, float[] work);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int stpqrt_work(Layout layout, int m, int n,
            int l, int nb, float[] a,
            int lda, float[] b, int ldb,
            float[] t, int ldt, float[] work)
            => LAPACKE_stpqrt_work(layout, m, n,
                l, nb, a,
                lda, b, ldb,
                t, ldt, work);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_stprfb(Layout layout, char side, TransChar trans, char direct,
            char storev, int m, int n,
            int k, int l, float[] v,
            int ldv, float[] t, int ldt,
            float[] a, int lda, float[] b, int ldb);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int stprfb(Layout layout, char side, TransChar trans, char direct,
            char storev, int m, int n,
            int k, int l, float[] v,
            int ldv, float[] t, int ldt,
            float[] a, int lda, float[] b, int ldb)
            => LAPACKE_stprfb(layout, side, trans, direct,
                storev, m, n,
                k, l, v,
                ldv, t, ldt,
                a, lda, b, ldb);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_stprfb_work(Layout layout, char side, TransChar trans,
            char direct, char storev, int m,
            int n, int k, int l,
            float[] v, int ldv, float[] t,
            int ldt, float[] a, int lda,
            float[] b, int ldb, float[] work,
            int ldwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int stprfb_work(Layout layout, char side, TransChar trans,
            char direct, char storev, int m,
            int n, int k, int l,
            float[] v, int ldv, float[] t,
            int ldt, float[] a, int lda,
            float[] b, int ldb, float[] work,
            int ldwork)
            => LAPACKE_stprfb_work(layout, side, trans,
                direct, storev, m,
                n, k, l,
                v, ldv, t,
                ldt, a, lda,
                b, ldb, work,
                ldwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_stprfs(Layout layout, UpLo uplo, TransChar trans, DiagChar diag,
            int n, int nrhs, float[] ap,
            float[] b, int ldb, float[] x,
            int ldx, float[] ferr, float[] berr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int stprfs(Layout layout, UpLo uplo, TransChar trans, DiagChar diag,
            int n, int nrhs, float[] ap,
            float[] b, int ldb, float[] x,
            int ldx, float[] ferr, float[] berr)
            => LAPACKE_stprfs(layout, uplo, trans, diag,
                n, nrhs, ap,
                b, ldb, x,
                ldx, ferr, berr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_stprfs_work(Layout layout, UpLo uplo, TransChar trans,
            DiagChar diag, int n, int nrhs,
            float[] ap, float[] b, int ldb,
            float[] x, int ldx, float[] ferr,
            float[] berr, float[] work, int[] iwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int stprfs_work(Layout layout, UpLo uplo, TransChar trans,
            DiagChar diag, int n, int nrhs,
            float[] ap, float[] b, int ldb,
            float[] x, int ldx, float[] ferr,
            float[] berr, float[] work, int[] iwork)
            => LAPACKE_stprfs_work(layout, uplo, trans,
                diag, n, nrhs,
                ap, b, ldb,
                x, ldx, ferr,
                berr, work, iwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_stptri(Layout layout, UpLo uplo, DiagChar diag, int n,
            float[] ap);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int stptri(Layout layout, UpLo uplo, DiagChar diag, int n,
            float[] ap)
            => LAPACKE_stptri(layout, uplo, diag, n,
                ap);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_stptri_work(Layout layout, UpLo uplo, DiagChar diag,
            int n, float[] ap);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int stptri_work(Layout layout, UpLo uplo, DiagChar diag,
            int n, float[] ap)
            => LAPACKE_stptri_work(layout, uplo, diag,
                n, ap);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_stptrs(Layout layout, UpLo uplo, TransChar trans, DiagChar diag,
            int n, int nrhs, float[] ap,
            float[] b, int ldb);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int stptrs(Layout layout, UpLo uplo, TransChar trans, DiagChar diag,
            int n, int nrhs, float[] ap,
            float[] b, int ldb)
            => LAPACKE_stptrs(layout, uplo, trans, diag,
                n, nrhs, ap,
                b, ldb);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_stptrs_work(Layout layout, UpLo uplo, TransChar trans,
            DiagChar diag, int n, int nrhs,
            float[] ap, float[] b, int ldb);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int stptrs_work(Layout layout, UpLo uplo, TransChar trans,
            DiagChar diag, int n, int nrhs,
            float[] ap, float[] b, int ldb)
            => LAPACKE_stptrs_work(layout, uplo, trans,
                diag, n, nrhs,
                ap, b, ldb);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_stpttf(Layout layout, TransChar transr, UpLo uplo,
            int n, float[] ap, float[] arf);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int stpttf(Layout layout, TransChar transr, UpLo uplo,
            int n, float[] ap, float[] arf)
            => LAPACKE_stpttf(layout, transr, uplo,
                n, ap, arf);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_stpttf_work(Layout layout, TransChar transr, UpLo uplo,
            int n, float[] ap, float[] arf);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int stpttf_work(Layout layout, TransChar transr, UpLo uplo,
            int n, float[] ap, float[] arf)
            => LAPACKE_stpttf_work(layout, transr, uplo,
                n, ap, arf);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_stpttr(Layout layout, UpLo uplo, int n,
            float[] ap, float[] a, int lda);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int stpttr(Layout layout, UpLo uplo, int n,
            float[] ap, float[] a, int lda)
            => LAPACKE_stpttr(layout, uplo, n,
                ap, a, lda);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_stpttr_work(Layout layout, UpLo uplo, int n,
            float[] ap, float[] a, int lda);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int stpttr_work(Layout layout, UpLo uplo, int n,
            float[] ap, float[] a, int lda)
            => LAPACKE_stpttr_work(layout, uplo, n,
                ap, a, lda);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_strcon(Layout layout, Norm norm, UpLo uplo, DiagChar diag,
            int n, float[] a, int lda,
            float[] rcond);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int strcon(Layout layout, Norm norm, UpLo uplo, DiagChar diag,
            int n, float[] a, int lda,
            float[] rcond)
            => LAPACKE_strcon(layout, norm, uplo, diag,
                n, a, lda,
                rcond);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_strcon_work(Layout layout, Norm norm, UpLo uplo,
            DiagChar diag, int n, float[] a,
            int lda, float[] rcond, float[] work,
            int[] iwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int strcon_work(Layout layout, Norm norm, UpLo uplo,
            DiagChar diag, int n, float[] a,
            int lda, float[] rcond, float[] work,
            int[] iwork)
            => LAPACKE_strcon_work(layout, norm, uplo,
                diag, n, a,
                lda, rcond, work,
                iwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_strevc(Layout layout, char side, char howmny,
            int[] select, int n, float[] t,
            int ldt, float[] vl, int ldvl,
            float[] vr, int ldvr, int mm,
            int[] m);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int strevc(Layout layout, char side, char howmny,
            int[] select, int n, float[] t,
            int ldt, float[] vl, int ldvl,
            float[] vr, int ldvr, int mm,
            int[] m)
            => LAPACKE_strevc(layout, side, howmny,
                select, n, t,
                ldt, vl, ldvl,
                vr, ldvr, mm,
                m);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_strevc_work(Layout layout, char side, char howmny,
            int[] select, int n,
            float[] t, int ldt, float[] vl,
            int ldvl, float[] vr, int ldvr,
            int mm, int[] m, float[] work);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int strevc_work(Layout layout, char side, char howmny,
            int[] select, int n,
            float[] t, int ldt, float[] vl,
            int ldvl, float[] vr, int ldvr,
            int mm, int[] m, float[] work)
            => LAPACKE_strevc_work(layout, side, howmny,
                select, n,
                t, ldt, vl,
                ldvl, vr, ldvr,
                mm, m, work);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_strexc(Layout layout, char compq, int n, float[] t,
            int ldt, float[] q, int ldq,
            int[] ifst, int[] ilst);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int strexc(Layout layout, char compq, int n, float[] t,
            int ldt, float[] q, int ldq,
            int[] ifst, int[] ilst)
            => LAPACKE_strexc(layout, compq, n, t,
                ldt, q, ldq,
                ifst, ilst);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_strexc_work(Layout layout, char compq, int n,
            float[] t, int ldt, float[] q,
            int ldq, int[] ifst,
            int[] ilst, float[] work);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int strexc_work(Layout layout, char compq, int n,
            float[] t, int ldt, float[] q,
            int ldq, int[] ifst,
            int[] ilst, float[] work)
            => LAPACKE_strexc_work(layout, compq, n,
                t, ldt, q,
                ldq, ifst,
                ilst, work);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_strrfs(Layout layout, UpLo uplo, TransChar trans, DiagChar diag,
            int n, int nrhs, float[] a,
            int lda, float[] b, int ldb,
            float[] x, int ldx, float[] ferr,
            float[] berr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int strrfs(Layout layout, UpLo uplo, TransChar trans, DiagChar diag,
            int n, int nrhs, float[] a,
            int lda, float[] b, int ldb,
            float[] x, int ldx, float[] ferr,
            float[] berr)
            => LAPACKE_strrfs(layout, uplo, trans, diag,
                n, nrhs, a,
                lda, b, ldb,
                x, ldx, ferr,
                berr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_strrfs_work(Layout layout, UpLo uplo, TransChar trans,
            DiagChar diag, int n, int nrhs,
            float[] a, int lda, float[] b,
            int ldb, float[] x, int ldx,
            float[] ferr, float[] berr, float[] work,
            int[] iwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int strrfs_work(Layout layout, UpLo uplo, TransChar trans,
            DiagChar diag, int n, int nrhs,
            float[] a, int lda, float[] b,
            int ldb, float[] x, int ldx,
            float[] ferr, float[] berr, float[] work,
            int[] iwork)
            => LAPACKE_strrfs_work(layout, uplo, trans,
                diag, n, nrhs,
                a, lda, b,
                ldb, x, ldx,
                ferr, berr, work,
                iwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_strsen(Layout layout, char job, char compq,
            int[] select, int n, float[] t,
            int ldt, float[] q, int ldq, float[] wr,
            float[] wi, int[] m, float[] s, float[] sep);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int strsen(Layout layout, char job, char compq,
            int[] select, int n, float[] t,
            int ldt, float[] q, int ldq, float[] wr,
            float[] wi, int[] m, float[] s, float[] sep)
            => LAPACKE_strsen(layout, job, compq,
                select, n, t,
                ldt, q, ldq, wr,
                wi, m, s, sep);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_strsen_work(Layout layout, char job, char compq,
            int[] select, int n,
            float[] t, int ldt, float[] q,
            int ldq, float[] wr, float[] wi,
            int[] m, float[] s, float[] sep,
            float[] work, int lwork,
            int[] iwork, int liwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int strsen_work(Layout layout, char job, char compq,
            int[] select, int n,
            float[] t, int ldt, float[] q,
            int ldq, float[] wr, float[] wi,
            int[] m, float[] s, float[] sep,
            float[] work, int lwork,
            int[] iwork, int liwork)
            => LAPACKE_strsen_work(layout, job, compq,
                select, n,
                t, ldt, q,
                ldq, wr, wi,
                m, s, sep,
                work, lwork,
                iwork, liwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_strsna(Layout layout, char job, char howmny,
            int[] select, int n,
            float[] t, int ldt, float[] vl,
            int ldvl, float[] vr, int ldvr,
            float[] s, float[] sep, int mm, int[] m);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int strsna(Layout layout, char job, char howmny,
            int[] select, int n,
            float[] t, int ldt, float[] vl,
            int ldvl, float[] vr, int ldvr,
            float[] s, float[] sep, int mm, int[] m)
            => LAPACKE_strsna(layout, job, howmny,
                select, n,
                t, ldt, vl,
                ldvl, vr, ldvr,
                s, sep, mm, m);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_strsna_work(Layout layout, char job, char howmny,
            int[] select, int n,
            float[] t, int ldt, float[] vl,
            int ldvl, float[] vr,
            int ldvr, float[] s, float[] sep,
            int mm, int[] m, float[] work,
            int ldwork, int[] iwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int strsna_work(Layout layout, char job, char howmny,
            int[] select, int n,
            float[] t, int ldt, float[] vl,
            int ldvl, float[] vr,
            int ldvr, float[] s, float[] sep,
            int mm, int[] m, float[] work,
            int ldwork, int[] iwork)
            => LAPACKE_strsna_work(layout, job, howmny,
                select, n,
                t, ldt, vl,
                ldvl, vr,
                ldvr, s, sep,
                mm, m, work,
                ldwork, iwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_strsyl(Layout layout, char trana, char tranb,
            int isgn, int m, int n,
            float[] a, int lda, float[] b,
            int ldb, float[] c, int ldc,
            float[] scale);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int strsyl(Layout layout, char trana, char tranb,
            int isgn, int m, int n,
            float[] a, int lda, float[] b,
            int ldb, float[] c, int ldc,
            float[] scale)
            => LAPACKE_strsyl(layout, trana, tranb,
                isgn, m, n,
                a, lda, b,
                ldb, c, ldc,
                scale);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_strsyl_work(Layout layout, char trana, char tranb,
            int isgn, int m, int n,
            float[] a, int lda, float[] b,
            int ldb, float[] c, int ldc,
            float[] scale);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int strsyl_work(Layout layout, char trana, char tranb,
            int isgn, int m, int n,
            float[] a, int lda, float[] b,
            int ldb, float[] c, int ldc,
            float[] scale)
            => LAPACKE_strsyl_work(layout, trana, tranb,
                isgn, m, n,
                a, lda, b,
                ldb, c, ldc,
                scale);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_strtri(Layout layout, UpLo uplo, DiagChar diag, int n,
            float[] a, int lda);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int strtri(Layout layout, UpLo uplo, DiagChar diag, int n,
            float[] a, int lda)
            => LAPACKE_strtri(layout, uplo, diag, n,
                a, lda);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_strtri_work(Layout layout, UpLo uplo, DiagChar diag,
            int n, float[] a, int lda);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int strtri_work(Layout layout, UpLo uplo, DiagChar diag,
            int n, float[] a, int lda)
            => LAPACKE_strtri_work(layout, uplo, diag,
                n, a, lda);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_strtrs(Layout layout, UpLo uplo, TransChar trans, DiagChar diag,
            int n, int nrhs, float[] a,
            int lda, float[] b, int ldb);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int strtrs(Layout layout, UpLo uplo, TransChar trans, DiagChar diag,
            int n, int nrhs, float[] a,
            int lda, float[] b, int ldb)
            => LAPACKE_strtrs(layout, uplo, trans, diag,
                n, nrhs, a,
                lda, b, ldb);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_strtrs_work(Layout layout, UpLo uplo, TransChar trans,
            DiagChar diag, int n, int nrhs,
            float[] a, int lda, float[] b,
            int ldb);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int strtrs_work(Layout layout, UpLo uplo, TransChar trans,
            DiagChar diag, int n, int nrhs,
            float[] a, int lda, float[] b,
            int ldb)
            => LAPACKE_strtrs_work(layout, uplo, trans,
                diag, n, nrhs,
                a, lda, b,
                ldb);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_strttf(Layout layout, TransChar transr, UpLo uplo,
            int n, float[] a, int lda,
            float[] arf);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int strttf(Layout layout, TransChar transr, UpLo uplo,
            int n, float[] a, int lda,
            float[] arf)
            => LAPACKE_strttf(layout, transr, uplo,
                n, a, lda,
                arf);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_strttf_work(Layout layout, TransChar transr, UpLo uplo,
            int n, float[] a, int lda,
            float[] arf);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int strttf_work(Layout layout, TransChar transr, UpLo uplo,
            int n, float[] a, int lda,
            float[] arf)
            => LAPACKE_strttf_work(layout, transr, uplo,
                n, a, lda,
                arf);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_strttp(Layout layout, UpLo uplo, int n,
            float[] a, int lda, float[] ap);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int strttp(Layout layout, UpLo uplo, int n,
            float[] a, int lda, float[] ap)
            => LAPACKE_strttp(layout, uplo, n,
                a, lda, ap);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_strttp_work(Layout layout, UpLo uplo, int n,
            float[] a, int lda, float[] ap);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int strttp_work(Layout layout, UpLo uplo, int n,
            float[] a, int lda, float[] ap)
            => LAPACKE_strttp_work(layout, uplo, n,
                a, lda, ap);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_stzrzf(Layout layout, int m, int n,
            float[] a, int lda, float[] tau);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int stzrzf(Layout layout, int m, int n,
            float[] a, int lda, float[] tau)
            => LAPACKE_stzrzf(layout, m, n,
                a, lda, tau);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_stzrzf_work(Layout layout, int m, int n,
            float[] a, int lda, float[] tau,
            float[] work, int lwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int stzrzf_work(Layout layout, int m, int n,
            float[] a, int lda, float[] tau,
            float[] work, int lwork)
            => LAPACKE_stzrzf_work(layout, m, n,
                a, lda, tau,
                work, lwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsysv_aa(Layout layout, UpLo uplo, int n,
            int nrhs, double[] a, int lda,
            int[] ipiv, double[] b, int ldb);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dsysv_aa(Layout layout, UpLo uplo, int n,
            int nrhs, double[] a, int lda,
            int[] ipiv, double[] b, int ldb)
            => LAPACKE_dsysv_aa(layout, uplo, n,
                nrhs, a, lda,
                ipiv, b, ldb);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsysv_aa_work(Layout layout, UpLo uplo, int n,
            int nrhs, double[] a, int lda,
            int[] ipiv, double[] b, int ldb,
            double[] work, int lwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dsysv_aa_work(Layout layout, UpLo uplo, int n,
            int nrhs, double[] a, int lda,
            int[] ipiv, double[] b, int ldb,
            double[] work, int lwork)
            => LAPACKE_dsysv_aa_work(layout, uplo, n,
                nrhs, a, lda,
                ipiv, b, ldb,
                work, lwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsytrf_aa(Layout layout, UpLo uplo, int n,
            double[] a, int lda, int[] ipiv);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dsytrf_aa(Layout layout, UpLo uplo, int n,
            double[] a, int lda, int[] ipiv)
            => LAPACKE_dsytrf_aa(layout, uplo, n,
                a, lda, ipiv);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsytrf_aa_work(Layout layout, UpLo uplo, int n,
            double[] a, int lda, int[] ipiv,
            double[] work, int lwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dsytrf_aa_work(Layout layout, UpLo uplo, int n,
            double[] a, int lda, int[] ipiv,
            double[] work, int lwork)
            => LAPACKE_dsytrf_aa_work(layout, uplo, n,
                a, lda, ipiv,
                work, lwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsytrs_aa(Layout layout, UpLo uplo, int n,
            int nrhs, double[] a, int lda,
            int[] ipiv, double[] b,
            int ldb);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dsytrs_aa(Layout layout, UpLo uplo, int n,
            int nrhs, double[] a, int lda,
            int[] ipiv, double[] b,
            int ldb)
            => LAPACKE_dsytrs_aa(layout, uplo, n,
                nrhs, a, lda,
                ipiv, b,
                ldb);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsytrs_aa_work(Layout layout, UpLo uplo, int n,
            int nrhs, double[] a,
            int lda, int[] ipiv,
            double[] b, int ldb, double[] work,
            int lwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dsytrs_aa_work(Layout layout, UpLo uplo, int n,
            int nrhs, double[] a,
            int lda, int[] ipiv,
            double[] b, int ldb, double[] work,
            int lwork)
            => LAPACKE_dsytrs_aa_work(layout, uplo, n,
                nrhs, a,
                lda, ipiv,
                b, ldb, work,
                lwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssysv_aa(Layout layout, UpLo uplo, int n,
            int nrhs, float[] a, int lda,
            int[] ipiv, float[] b, int ldb);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ssysv_aa(Layout layout, UpLo uplo, int n,
            int nrhs, float[] a, int lda,
            int[] ipiv, float[] b, int ldb)
            => LAPACKE_ssysv_aa(layout, uplo, n,
                nrhs, a, lda,
                ipiv, b, ldb);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssysv_aa_work(Layout layout, UpLo uplo, int n,
            int nrhs, float[] a, int lda,
            int[] ipiv, float[] b, int ldb,
            float[] work, int lwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ssysv_aa_work(Layout layout, UpLo uplo, int n,
            int nrhs, float[] a, int lda,
            int[] ipiv, float[] b, int ldb,
            float[] work, int lwork)
            => LAPACKE_ssysv_aa_work(layout, uplo, n,
                nrhs, a, lda,
                ipiv, b, ldb,
                work, lwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssytrf_aa(Layout layout, UpLo uplo, int n,
            float[] a, int lda, int[] ipiv);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ssytrf_aa(Layout layout, UpLo uplo, int n,
            float[] a, int lda, int[] ipiv)
            => LAPACKE_ssytrf_aa(layout, uplo, n,
                a, lda, ipiv);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssytrf_aa_work(Layout layout, UpLo uplo, int n,
            float[] a, int lda, int[] ipiv,
            float[] work, int lwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ssytrf_aa_work(Layout layout, UpLo uplo, int n,
            float[] a, int lda, int[] ipiv,
            float[] work, int lwork)
            => LAPACKE_ssytrf_aa_work(layout, uplo, n,
                a, lda, ipiv,
                work, lwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssytrs_aa(Layout layout, UpLo uplo, int n,
            int nrhs, float[] a, int lda,
            int[] ipiv, float[] b,
            int ldb);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ssytrs_aa(Layout layout, UpLo uplo, int n,
            int nrhs, float[] a, int lda,
            int[] ipiv, float[] b,
            int ldb)
            => LAPACKE_ssytrs_aa(layout, uplo, n,
                nrhs, a, lda,
                ipiv, b,
                ldb);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssytrs_aa_work(Layout layout, UpLo uplo, int n,
            int nrhs, float[] a,
            int lda, int[] ipiv,
            float[] b, int ldb, float[] work,
            int lwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ssytrs_aa_work(Layout layout, UpLo uplo, int n,
            int nrhs, float[] a,
            int lda, int[] ipiv,
            float[] b, int ldb, float[] work,
            int lwork)
            => LAPACKE_ssytrs_aa_work(layout, uplo, n,
                nrhs, a,
                lda, ipiv,
                b, ldb, work,
                lwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgemqr(Layout layout, char side, TransChar trans,
            int m, int n, int k,
            double[] a, int lda,
            double[] t, int tsize, double[] c,
            int ldc);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dgemqr(Layout layout, char side, TransChar trans,
            int m, int n, int k,
            double[] a, int lda,
            double[] t, int tsize, double[] c,
            int ldc)
            => LAPACKE_dgemqr(layout, side, trans,
                m, n, k,
                a, lda,
                t, tsize, c,
                ldc);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgemqr_work(Layout layout, char side, TransChar trans,
            int m, int n, int k,
            double[] a, int lda,
            double[] t, int tsize,
            double[] c, int ldc, double[] work,
            int lwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dgemqr_work(Layout layout, char side, TransChar trans,
            int m, int n, int k,
            double[] a, int lda,
            double[] t, int tsize,
            double[] c, int ldc, double[] work,
            int lwork)
            => LAPACKE_dgemqr_work(layout, side, trans,
                m, n, k,
                a, lda,
                t, tsize,
                c, ldc, work,
                lwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgeqr(Layout layout, int m, int n,
            double[] a, int lda, double[] t,
            int tsize);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dgeqr(Layout layout, int m, int n,
            double[] a, int lda, double[] t,
            int tsize)
            => LAPACKE_dgeqr(layout, m, n,
                a, lda, t,
                tsize);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgeqr_work(Layout layout, int m, int n,
            double[] a, int lda, double[] t,
            int tsize, double[] work,
            int lwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dgeqr_work(Layout layout, int m, int n,
            double[] a, int lda, double[] t,
            int tsize, double[] work,
            int lwork)
            => LAPACKE_dgeqr_work(layout, m, n,
                a, lda, t,
                tsize, work,
                lwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgemqr(Layout layout, char side, TransChar trans,
            int m, int n, int k,
            float[] a, int lda, float[] t,
            int tsize, float[] c, int ldc);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sgemqr(Layout layout, char side, TransChar trans,
            int m, int n, int k,
            float[] a, int lda, float[] t,
            int tsize, float[] c, int ldc)
            => LAPACKE_sgemqr(layout, side, trans,
                m, n, k,
                a, lda, t,
                tsize, c, ldc);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgemqr_work(Layout layout, char side, TransChar trans,
            int m, int n, int k,
            float[] a, int lda,
            float[] t, int tsize,
            float[] c, int ldc, float[] work,
            int lwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sgemqr_work(Layout layout, char side, TransChar trans,
            int m, int n, int k,
            float[] a, int lda,
            float[] t, int tsize,
            float[] c, int ldc, float[] work,
            int lwork)
            => LAPACKE_sgemqr_work(layout, side, trans,
                m, n, k,
                a, lda,
                t, tsize,
                c, ldc, work,
                lwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgeqr(Layout layout, int m, int n,
            float[] a, int lda, float[] t,
            int tsize);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sgeqr(Layout layout, int m, int n,
            float[] a, int lda, float[] t,
            int tsize)
            => LAPACKE_sgeqr(layout, m, n,
                a, lda, t,
                tsize);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgeqr_work(Layout layout, int m, int n,
            float[] a, int lda, float[] t,
            int tsize, float[] work,
            int lwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sgeqr_work(Layout layout, int m, int n,
            float[] a, int lda, float[] t,
            int tsize, float[] work,
            int lwork)
            => LAPACKE_sgeqr_work(layout, m, n,
                a, lda, t,
                tsize, work,
                lwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgelq(Layout layout, int m, int n,
            double[] a, int lda, double[] t,
            int tsize);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dgelq(Layout layout, int m, int n,
            double[] a, int lda, double[] t,
            int tsize)
            => LAPACKE_dgelq(layout, m, n,
                a, lda, t,
                tsize);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgelq_work(Layout layout, int m, int n,
            double[] a, int lda, double[] t,
            int tsize, double[] work,
            int lwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dgelq_work(Layout layout, int m, int n,
            double[] a, int lda, double[] t,
            int tsize, double[] work,
            int lwork)
            => LAPACKE_dgelq_work(layout, m, n,
                a, lda, t,
                tsize, work,
                lwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgemlq(Layout layout, char side, TransChar trans,
            int m, int n, int k,
            double[] a, int lda, double[] t,
            int tsize, double[] c, int ldc);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dgemlq(Layout layout, char side, TransChar trans,
            int m, int n, int k,
            double[] a, int lda, double[] t,
            int tsize, double[] c, int ldc)
            => LAPACKE_dgemlq(layout, side, trans,
                m, n, k,
                a, lda, t,
                tsize, c, ldc);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgemlq_work(Layout layout, char side, TransChar trans,
            int m, int n, int k,
            double[] a, int lda,
            double[] t, int tsize, double[] c,
            int ldc, double[] work,
            int lwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dgemlq_work(Layout layout, char side, TransChar trans,
            int m, int n, int k,
            double[] a, int lda,
            double[] t, int tsize, double[] c,
            int ldc, double[] work,
            int lwork)
            => LAPACKE_dgemlq_work(layout, side, trans,
                m, n, k,
                a, lda,
                t, tsize, c,
                ldc, work,
                lwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgelq(Layout layout, int m, int n,
            float[] a, int lda, float[] t,
            int tsize);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sgelq(Layout layout, int m, int n,
            float[] a, int lda, float[] t,
            int tsize)
            => LAPACKE_sgelq(layout, m, n,
                a, lda, t,
                tsize);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgelq_work(Layout layout, int m, int n,
            float[] a, int lda, float[] t,
            int tsize, float[] work,
            int lwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sgelq_work(Layout layout, int m, int n,
            float[] a, int lda, float[] t,
            int tsize, float[] work,
            int lwork)
            => LAPACKE_sgelq_work(layout, m, n,
                a, lda, t,
                tsize, work,
                lwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgemlq(Layout layout, char side, TransChar trans,
            int m, int n, int k,
            float[] a, int lda, float[] t,
            int tsize, float[] c, int ldc);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sgemlq(Layout layout, char side, TransChar trans,
            int m, int n, int k,
            float[] a, int lda, float[] t,
            int tsize, float[] c, int ldc)
            => LAPACKE_sgemlq(layout, side, trans,
                m, n, k,
                a, lda, t,
                tsize, c, ldc);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgemlq_work(Layout layout, char side, TransChar trans,
            int m, int n, int k,
            float[] a, int lda, float[] t,
            int tsize, float[] c, int ldc,
            float[] work, int lwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sgemlq_work(Layout layout, char side, TransChar trans,
            int m, int n, int k,
            float[] a, int lda, float[] t,
            int tsize, float[] c, int ldc,
            float[] work, int lwork)
            => LAPACKE_sgemlq_work(layout, side, trans,
                m, n, k,
                a, lda, t,
                tsize, c, ldc,
                work, lwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgetsls(Layout layout, TransChar trans, int m,
            int n, int nrhs, double[] a,
            int lda, double[] b, int ldb);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dgetsls(Layout layout, TransChar trans, int m,
            int n, int nrhs, double[] a,
            int lda, double[] b, int ldb)
            => LAPACKE_dgetsls(layout, trans, m,
                n, nrhs, a,
                lda, b, ldb);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgetsls_work(Layout layout, TransChar trans, int m,
            int n, int nrhs, double[] a,
            int lda, double[] b, int ldb,
            double[] work, int lwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dgetsls_work(Layout layout, TransChar trans, int m,
            int n, int nrhs, double[] a,
            int lda, double[] b, int ldb,
            double[] work, int lwork)
            => LAPACKE_dgetsls_work(layout, trans, m,
                n, nrhs, a,
                lda, b, ldb,
                work, lwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgetsls(Layout layout, TransChar trans, int m,
            int n, int nrhs, float[] a,
            int lda, float[] b, int ldb);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sgetsls(Layout layout, TransChar trans, int m,
            int n, int nrhs, float[] a,
            int lda, float[] b, int ldb)
            => LAPACKE_sgetsls(layout, trans, m,
                n, nrhs, a,
                lda, b, ldb);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgetsls_work(Layout layout, TransChar trans, int m,
            int n, int nrhs, float[] a,
            int lda, float[] b, int ldb,
            float[] work, int lwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sgetsls_work(Layout layout, TransChar trans, int m,
            int n, int nrhs, float[] a,
            int lda, float[] b, int ldb,
            float[] work, int lwork)
            => LAPACKE_sgetsls_work(layout, trans, m,
                n, nrhs, a,
                lda, b, ldb,
                work, lwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsycon_3(Layout layout, UpLo uplo, int n,
            double[] a, int lda, double[] e,
            int[] ipiv, double anorm,
            double[] rcond);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dsycon_3(Layout layout, UpLo uplo, int n,
            double[] a, int lda, double[] e,
            int[] ipiv, double anorm,
            double[] rcond)
            => LAPACKE_dsycon_3(layout, uplo, n,
                a, lda, e,
                ipiv, anorm,
                rcond);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsycon_3_work(Layout layout, UpLo uplo, int n,
            double[] a, int lda,
            double[] e, int[] ipiv,
            double anorm, double[] rcond, double[] work,
            int[] iwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dsycon_3_work(Layout layout, UpLo uplo, int n,
            double[] a, int lda,
            double[] e, int[] ipiv,
            double anorm, double[] rcond, double[] work,
            int[] iwork)
            => LAPACKE_dsycon_3_work(layout, uplo, n,
                a, lda,
                e, ipiv,
                anorm, rcond, work,
                iwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsysv_rk(Layout layout, UpLo uplo, int n,
            int nrhs, double[] a, int lda,
            double[] e, int[] ipiv, double[] b,
            int ldb);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dsysv_rk(Layout layout, UpLo uplo, int n,
            int nrhs, double[] a, int lda,
            double[] e, int[] ipiv, double[] b,
            int ldb)
            => LAPACKE_dsysv_rk(layout, uplo, n,
                nrhs, a, lda,
                e, ipiv, b,
                ldb);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsysv_rk_work(Layout layout, UpLo uplo, int n,
            int nrhs, double[] a, int lda,
            double[] e, int[] ipiv, double[] b,
            int ldb, double[] work,
            int lwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dsysv_rk_work(Layout layout, UpLo uplo, int n,
            int nrhs, double[] a, int lda,
            double[] e, int[] ipiv, double[] b,
            int ldb, double[] work,
            int lwork)
            => LAPACKE_dsysv_rk_work(layout, uplo, n,
                nrhs, a, lda,
                e, ipiv, b,
                ldb, work,
                lwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsytrf_rk(Layout layout, UpLo uplo, int n,
            double[] a, int lda, double[] e,
            int[] ipiv);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dsytrf_rk(Layout layout, UpLo uplo, int n,
            double[] a, int lda, double[] e,
            int[] ipiv)
            => LAPACKE_dsytrf_rk(layout, uplo, n,
                a, lda, e,
                ipiv);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsytrf_rk_work(Layout layout, UpLo uplo, int n,
            double[] a, int lda, double[] e,
            int[] ipiv, double[] work,
            int lwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dsytrf_rk_work(Layout layout, UpLo uplo, int n,
            double[] a, int lda, double[] e,
            int[] ipiv, double[] work,
            int lwork)
            => LAPACKE_dsytrf_rk_work(layout, uplo, n,
                a, lda, e,
                ipiv, work,
                lwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsytri_3(Layout layout, UpLo uplo, int n,
            double[] a, int lda, double[] e,
            int[] ipiv);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dsytri_3(Layout layout, UpLo uplo, int n,
            double[] a, int lda, double[] e,
            int[] ipiv)
            => LAPACKE_dsytri_3(layout, uplo, n,
                a, lda, e,
                ipiv);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsytri_3_work(Layout layout, UpLo uplo, int n,
            double[] a, int lda, double[] e,
            int[] ipiv, double[] work,
            int lwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dsytri_3_work(Layout layout, UpLo uplo, int n,
            double[] a, int lda, double[] e,
            int[] ipiv, double[] work,
            int lwork)
            => LAPACKE_dsytri_3_work(layout, uplo, n,
                a, lda, e,
                ipiv, work,
                lwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsytrs_3(Layout layout, UpLo uplo, int n,
            int nrhs, double[] a, int lda,
            double[] e, int[] ipiv,
            double[] b, int ldb);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dsytrs_3(Layout layout, UpLo uplo, int n,
            int nrhs, double[] a, int lda,
            double[] e, int[] ipiv,
            double[] b, int ldb)
            => LAPACKE_dsytrs_3(layout, uplo, n,
                nrhs, a, lda,
                e, ipiv,
                b, ldb);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsytrs_3_work(Layout layout, UpLo uplo, int n,
            int nrhs, double[] a,
            int lda, double[] e,
            int[] ipiv, double[] b,
            int ldb);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dsytrs_3_work(Layout layout, UpLo uplo, int n,
            int nrhs, double[] a,
            int lda, double[] e,
            int[] ipiv, double[] b,
            int ldb)
            => LAPACKE_dsytrs_3_work(layout, uplo, n,
                nrhs, a,
                lda, e,
                ipiv, b,
                ldb);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssycon_3(Layout layout, UpLo uplo, int n,
            float[] a, int lda, float[] e,
            int[] ipiv, float anorm,
            float[] rcond);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ssycon_3(Layout layout, UpLo uplo, int n,
            float[] a, int lda, float[] e,
            int[] ipiv, float anorm,
            float[] rcond)
            => LAPACKE_ssycon_3(layout, uplo, n,
                a, lda, e,
                ipiv, anorm,
                rcond);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssycon_3_work(Layout layout, UpLo uplo, int n,
            float[] a, int lda,
            float[] e, int[] ipiv,
            float anorm, float[] rcond, float[] work,
            int[] iwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ssycon_3_work(Layout layout, UpLo uplo, int n,
            float[] a, int lda,
            float[] e, int[] ipiv,
            float anorm, float[] rcond, float[] work,
            int[] iwork)
            => LAPACKE_ssycon_3_work(layout, uplo, n,
                a, lda,
                e, ipiv,
                anorm, rcond, work,
                iwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssysv_rk(Layout layout, UpLo uplo, int n,
            int nrhs, float[] a, int lda,
            float[] e, int[] ipiv, float[] b,
            int ldb);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ssysv_rk(Layout layout, UpLo uplo, int n,
            int nrhs, float[] a, int lda,
            float[] e, int[] ipiv, float[] b,
            int ldb)
            => LAPACKE_ssysv_rk(layout, uplo, n,
                nrhs, a, lda,
                e, ipiv, b,
                ldb);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssysv_rk_work(Layout layout, UpLo uplo, int n,
            int nrhs, float[] a, int lda,
            float[] e, int[] ipiv, float[] b,
            int ldb, float[] work,
            int lwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ssysv_rk_work(Layout layout, UpLo uplo, int n,
            int nrhs, float[] a, int lda,
            float[] e, int[] ipiv, float[] b,
            int ldb, float[] work,
            int lwork)
            => LAPACKE_ssysv_rk_work(layout, uplo, n,
                nrhs, a, lda,
                e, ipiv, b,
                ldb, work,
                lwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssytrf_rk(Layout layout, UpLo uplo, int n,
            float[] a, int lda, float[] e,
            int[] ipiv);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ssytrf_rk(Layout layout, UpLo uplo, int n,
            float[] a, int lda, float[] e,
            int[] ipiv)
            => LAPACKE_ssytrf_rk(layout, uplo, n,
                a, lda, e,
                ipiv);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssytrf_rk_work(Layout layout, UpLo uplo, int n,
            float[] a, int lda, float[] e,
            int[] ipiv, float[] work,
            int lwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ssytrf_rk_work(Layout layout, UpLo uplo, int n,
            float[] a, int lda, float[] e,
            int[] ipiv, float[] work,
            int lwork)
            => LAPACKE_ssytrf_rk_work(layout, uplo, n,
                a, lda, e,
                ipiv, work,
                lwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssytri_3(Layout layout, UpLo uplo, int n,
            float[] a, int lda, float[] e,
            int[] ipiv);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ssytri_3(Layout layout, UpLo uplo, int n,
            float[] a, int lda, float[] e,
            int[] ipiv)
            => LAPACKE_ssytri_3(layout, uplo, n,
                a, lda, e,
                ipiv);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssytri_3_work(Layout layout, UpLo uplo, int n,
            float[] a, int lda, float[] e,
            int[] ipiv, float[] work,
            int lwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ssytri_3_work(Layout layout, UpLo uplo, int n,
            float[] a, int lda, float[] e,
            int[] ipiv, float[] work,
            int lwork)
            => LAPACKE_ssytri_3_work(layout, uplo, n,
                a, lda, e,
                ipiv, work,
                lwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssytrs_3(Layout layout, UpLo uplo, int n,
            int nrhs, float[] a, int lda,
            float[] e, int[] ipiv, float[] b,
            int ldb);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ssytrs_3(Layout layout, UpLo uplo, int n,
            int nrhs, float[] a, int lda,
            float[] e, int[] ipiv, float[] b,
            int ldb)
            => LAPACKE_ssytrs_3(layout, uplo, n,
                nrhs, a, lda,
                e, ipiv, b,
                ldb);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssytrs_3_work(Layout layout, UpLo uplo, int n,
            int nrhs, float[] a,
            int lda, float[] e,
            int[] ipiv, float[] b,
            int ldb);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ssytrs_3_work(Layout layout, UpLo uplo, int n,
            int nrhs, float[] a,
            int lda, float[] e,
            int[] ipiv, float[] b,
            int ldb)
            => LAPACKE_ssytrs_3_work(layout, uplo, n,
                nrhs, a,
                lda, e,
                ipiv, b,
                ldb);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsbev_2stage(Layout layout, char jobz, UpLo uplo,
            int n, int kd, double[] ab,
            int ldab, double[] w, double[] z,
            int ldz);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dsbev_2stage(Layout layout, char jobz, UpLo uplo,
            int n, int kd, double[] ab,
            int ldab, double[] w, double[] z,
            int ldz)
            => LAPACKE_dsbev_2stage(layout, jobz, uplo,
                n, kd, ab,
                ldab, w, z,
                ldz);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsbev_2stage_work(Layout layout, char jobz, UpLo uplo,
            int n, int kd, double[] ab,
            int ldab, double[] w, double[] z,
            int ldz, double[] work,
            int lwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dsbev_2stage_work(Layout layout, char jobz, UpLo uplo,
            int n, int kd, double[] ab,
            int ldab, double[] w, double[] z,
            int ldz, double[] work,
            int lwork)
            => LAPACKE_dsbev_2stage_work(layout, jobz, uplo,
                n, kd, ab,
                ldab, w, z,
                ldz, work,
                lwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsbevd_2stage(Layout layout, char jobz, UpLo uplo,
            int n, int kd, double[] ab,
            int ldab, double[] w, double[] z,
            int ldz);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dsbevd_2stage(Layout layout, char jobz, UpLo uplo,
            int n, int kd, double[] ab,
            int ldab, double[] w, double[] z,
            int ldz)
            => LAPACKE_dsbevd_2stage(layout, jobz, uplo,
                n, kd, ab,
                ldab, w, z,
                ldz);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsbevd_2stage_work(Layout layout, char jobz, UpLo uplo,
            int n, int kd, double[] ab,
            int ldab, double[] w, double[] z,
            int ldz, double[] work,
            int lwork, int[] iwork,
            int liwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dsbevd_2stage_work(Layout layout, char jobz, UpLo uplo,
            int n, int kd, double[] ab,
            int ldab, double[] w, double[] z,
            int ldz, double[] work,
            int lwork, int[] iwork,
            int liwork)
            => LAPACKE_dsbevd_2stage_work(layout, jobz, uplo,
                n, kd, ab,
                ldab, w, z,
                ldz, work,
                lwork, iwork,
                liwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsbevx_2stage(Layout layout, char jobz, char range,
            UpLo uplo, int n, int kd,
            double[] ab, int ldab, double[] q,
            int ldq, double vl, double vu,
            int il, int iu, double abstol,
            int[] m, double[] w, double[] z,
            int ldz, int[] ifail);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dsbevx_2stage(Layout layout, char jobz, char range,
            UpLo uplo, int n, int kd,
            double[] ab, int ldab, double[] q,
            int ldq, double vl, double vu,
            int il, int iu, double abstol,
            int[] m, double[] w, double[] z,
            int ldz, int[] ifail)
            => LAPACKE_dsbevx_2stage(layout, jobz, range,
                uplo, n, kd,
                ab, ldab, q,
                ldq, vl, vu,
                il, iu, abstol,
                m, w, z,
                ldz, ifail);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsbevx_2stage_work(Layout layout, char jobz,
            char range, UpLo uplo, int n,
            int kd, double[] ab,
            int ldab, double[] q,
            int ldq, double vl, double vu,
            int il, int iu,
            double abstol, int[] m, double[] w,
            double[] z, int ldz, double[] work,
            int lwork, int[] iwork,
            int[] ifail);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dsbevx_2stage_work(Layout layout, char jobz,
            char range, UpLo uplo, int n,
            int kd, double[] ab,
            int ldab, double[] q,
            int ldq, double vl, double vu,
            int il, int iu,
            double abstol, int[] m, double[] w,
            double[] z, int ldz, double[] work,
            int lwork, int[] iwork,
            int[] ifail)
            => LAPACKE_dsbevx_2stage_work(layout, jobz,
                range, uplo, n,
                kd, ab,
                ldab, q,
                ldq, vl, vu,
                il, iu,
                abstol, m, w,
                z, ldz, work,
                lwork, iwork,
                ifail);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsyev_2stage(Layout layout, char jobz, UpLo uplo,
            int n, double[] a, int lda,
            double[] w);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dsyev_2stage(Layout layout, char jobz, UpLo uplo,
            int n, double[] a, int lda,
            double[] w)
            => LAPACKE_dsyev_2stage(layout, jobz, uplo,
                n, a, lda,
                w);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsyev_2stage_work(Layout layout, char jobz, UpLo uplo,
            int n, double[] a, int lda,
            double[] w, double[] work,
            int lwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dsyev_2stage_work(Layout layout, char jobz, UpLo uplo,
            int n, double[] a, int lda,
            double[] w, double[] work,
            int lwork)
            => LAPACKE_dsyev_2stage_work(layout, jobz, uplo,
                n, a, lda,
                w, work,
                lwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsyevd_2stage(Layout layout, char jobz, UpLo uplo,
            int n, double[] a, int lda,
            double[] w);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dsyevd_2stage(Layout layout, char jobz, UpLo uplo,
            int n, double[] a, int lda,
            double[] w)
            => LAPACKE_dsyevd_2stage(layout, jobz, uplo,
                n, a, lda,
                w);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsyevd_2stage_work(Layout layout, char jobz, UpLo uplo,
            int n, double[] a, int lda,
            double[] w, double[] work,
            int lwork, int[] iwork,
            int liwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dsyevd_2stage_work(Layout layout, char jobz, UpLo uplo,
            int n, double[] a, int lda,
            double[] w, double[] work,
            int lwork, int[] iwork,
            int liwork)
            => LAPACKE_dsyevd_2stage_work(layout, jobz, uplo,
                n, a, lda,
                w, work,
                lwork, iwork,
                liwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsyevr_2stage(Layout layout, char jobz, char range,
            UpLo uplo, int n, double[] a,
            int lda, double vl, double vu,
            int il, int iu, double abstol,
            int[] m, double[] w, double[] z,
            int ldz, int[] isuppz);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dsyevr_2stage(Layout layout, char jobz, char range,
            UpLo uplo, int n, double[] a,
            int lda, double vl, double vu,
            int il, int iu, double abstol,
            int[] m, double[] w, double[] z,
            int ldz, int[] isuppz)
            => LAPACKE_dsyevr_2stage(layout, jobz, range,
                uplo, n, a,
                lda, vl, vu,
                il, iu, abstol,
                m, w, z,
                ldz, isuppz);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsyevr_2stage_work(Layout layout, char jobz,
            char range, UpLo uplo, int n,
            double[] a, int lda, double vl,
            double vu, int il, int iu,
            double abstol, int[] m, double[] w,
            double[] z, int ldz,
            int[] isuppz, double[] work,
            int lwork, int[] iwork,
            int liwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dsyevr_2stage_work(Layout layout, char jobz,
            char range, UpLo uplo, int n,
            double[] a, int lda, double vl,
            double vu, int il, int iu,
            double abstol, int[] m, double[] w,
            double[] z, int ldz,
            int[] isuppz, double[] work,
            int lwork, int[] iwork,
            int liwork)
            => LAPACKE_dsyevr_2stage_work(layout, jobz,
                range, uplo, n,
                a, lda, vl,
                vu, il, iu,
                abstol, m, w,
                z, ldz,
                isuppz, work,
                lwork, iwork,
                liwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsyevx_2stage(Layout layout, char jobz, char range,
            UpLo uplo, int n, double[] a,
            int lda, double vl, double vu,
            int il, int iu, double abstol,
            int[] m, double[] w, double[] z,
            int ldz, int[] ifail);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dsyevx_2stage(Layout layout, char jobz, char range,
            UpLo uplo, int n, double[] a,
            int lda, double vl, double vu,
            int il, int iu, double abstol,
            int[] m, double[] w, double[] z,
            int ldz, int[] ifail)
            => LAPACKE_dsyevx_2stage(layout, jobz, range,
                uplo, n, a,
                lda, vl, vu,
                il, iu, abstol,
                m, w, z,
                ldz, ifail);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsyevx_2stage_work(Layout layout, char jobz,
            char range, UpLo uplo, int n,
            double[] a, int lda, double vl,
            double vu, int il, int iu,
            double abstol, int[] m, double[] w,
            double[] z, int ldz, double[] work,
            int lwork, int[] iwork,
            int[] ifail);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dsyevx_2stage_work(Layout layout, char jobz,
            char range, UpLo uplo, int n,
            double[] a, int lda, double vl,
            double vu, int il, int iu,
            double abstol, int[] m, double[] w,
            double[] z, int ldz, double[] work,
            int lwork, int[] iwork,
            int[] ifail)
            => LAPACKE_dsyevx_2stage_work(layout, jobz,
                range, uplo, n,
                a, lda, vl,
                vu, il, iu,
                abstol, m, w,
                z, ldz, work,
                lwork, iwork,
                ifail);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsygv_2stage(Layout layout, int itype,
            char jobz, UpLo uplo, int n, double[] a,
            int lda, double[] b, int ldb,
            double[] w);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dsygv_2stage(Layout layout, int itype,
            char jobz, UpLo uplo, int n, double[] a,
            int lda, double[] b, int ldb,
            double[] w)
            => LAPACKE_dsygv_2stage(layout, itype,
                jobz, uplo, n, a,
                lda, b, ldb,
                w);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsygv_2stage_work(Layout layout, int itype,
            char jobz, UpLo uplo, int n,
            double[] a, int lda, double[] b,
            int ldb, double[] w, double[] work,
            int lwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dsygv_2stage_work(Layout layout, int itype,
            char jobz, UpLo uplo, int n,
            double[] a, int lda, double[] b,
            int ldb, double[] w, double[] work,
            int lwork)
            => LAPACKE_dsygv_2stage_work(layout, itype,
                jobz, uplo, n,
                a, lda, b,
                ldb, w, work,
                lwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssbev_2stage(Layout layout, char jobz, UpLo uplo,
            int n, int kd, float[] ab,
            int ldab, float[] w, float[] z,
            int ldz);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ssbev_2stage(Layout layout, char jobz, UpLo uplo,
            int n, int kd, float[] ab,
            int ldab, float[] w, float[] z,
            int ldz)
            => LAPACKE_ssbev_2stage(layout, jobz, uplo,
                n, kd, ab,
                ldab, w, z,
                ldz);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssbev_2stage_work(Layout layout, char jobz, UpLo uplo,
            int n, int kd, float[] ab,
            int ldab, float[] w, float[] z,
            int ldz, float[] work,
            int lwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ssbev_2stage_work(Layout layout, char jobz, UpLo uplo,
            int n, int kd, float[] ab,
            int ldab, float[] w, float[] z,
            int ldz, float[] work,
            int lwork)
            => LAPACKE_ssbev_2stage_work(layout, jobz, uplo,
                n, kd, ab,
                ldab, w, z,
                ldz, work,
                lwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssbevd_2stage(Layout layout, char jobz, UpLo uplo,
            int n, int kd, float[] ab,
            int ldab, float[] w, float[] z,
            int ldz);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ssbevd_2stage(Layout layout, char jobz, UpLo uplo,
            int n, int kd, float[] ab,
            int ldab, float[] w, float[] z,
            int ldz)
            => LAPACKE_ssbevd_2stage(layout, jobz, uplo,
                n, kd, ab,
                ldab, w, z,
                ldz);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssbevd_2stage_work(Layout layout, char jobz, UpLo uplo,
            int n, int kd, float[] ab,
            int ldab, float[] w, float[] z,
            int ldz, float[] work,
            int lwork, int[] iwork,
            int liwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ssbevd_2stage_work(Layout layout, char jobz, UpLo uplo,
            int n, int kd, float[] ab,
            int ldab, float[] w, float[] z,
            int ldz, float[] work,
            int lwork, int[] iwork,
            int liwork)
            => LAPACKE_ssbevd_2stage_work(layout, jobz, uplo,
                n, kd, ab,
                ldab, w, z,
                ldz, work,
                lwork, iwork,
                liwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssbevx_2stage(Layout layout, char jobz, char range,
            UpLo uplo, int n, int kd,
            float[] ab, int ldab, float[] q,
            int ldq, float vl, float vu,
            int il, int iu, float abstol,
            int[] m, float[] w, float[] z,
            int ldz, int[] ifail);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ssbevx_2stage(Layout layout, char jobz, char range,
            UpLo uplo, int n, int kd,
            float[] ab, int ldab, float[] q,
            int ldq, float vl, float vu,
            int il, int iu, float abstol,
            int[] m, float[] w, float[] z,
            int ldz, int[] ifail)
            => LAPACKE_ssbevx_2stage(layout, jobz, range,
                uplo, n, kd,
                ab, ldab, q,
                ldq, vl, vu,
                il, iu, abstol,
                m, w, z,
                ldz, ifail);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssbevx_2stage_work(Layout layout, char jobz,
            char range, UpLo uplo, int n,
            int kd, float[] ab,
            int ldab, float[] q,
            int ldq, float vl, float vu,
            int il, int iu,
            float abstol, int[] m, float[] w,
            float[] z, int ldz, float[] work,
            int lwork, int[] iwork,
            int[] ifail);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ssbevx_2stage_work(Layout layout, char jobz,
            char range, UpLo uplo, int n,
            int kd, float[] ab,
            int ldab, float[] q,
            int ldq, float vl, float vu,
            int il, int iu,
            float abstol, int[] m, float[] w,
            float[] z, int ldz, float[] work,
            int lwork, int[] iwork,
            int[] ifail)
            => LAPACKE_ssbevx_2stage_work(layout, jobz,
                range, uplo, n,
                kd, ab,
                ldab, q,
                ldq, vl, vu,
                il, iu,
                abstol, m, w,
                z, ldz, work,
                lwork, iwork,
                ifail);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssyev_2stage(Layout layout, char jobz, UpLo uplo,
            int n, float[] a, int lda,
            float[] w);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ssyev_2stage(Layout layout, char jobz, UpLo uplo,
            int n, float[] a, int lda,
            float[] w)
            => LAPACKE_ssyev_2stage(layout, jobz, uplo,
                n, a, lda,
                w);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssyev_2stage_work(Layout layout, char jobz, UpLo uplo,
            int n, float[] a, int lda,
            float[] w, float[] work, int lwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ssyev_2stage_work(Layout layout, char jobz, UpLo uplo,
            int n, float[] a, int lda,
            float[] w, float[] work, int lwork)
            => LAPACKE_ssyev_2stage_work(layout, jobz, uplo,
                n, a, lda,
                w, work, lwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssyevd_2stage(Layout layout, char jobz, UpLo uplo,
            int n, float[] a, int lda,
            float[] w);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ssyevd_2stage(Layout layout, char jobz, UpLo uplo,
            int n, float[] a, int lda,
            float[] w)
            => LAPACKE_ssyevd_2stage(layout, jobz, uplo,
                n, a, lda,
                w);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssyevd_2stage_work(Layout layout, char jobz, UpLo uplo,
            int n, float[] a, int lda,
            float[] w, float[] work, int lwork,
            int[] iwork, int liwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ssyevd_2stage_work(Layout layout, char jobz, UpLo uplo,
            int n, float[] a, int lda,
            float[] w, float[] work, int lwork,
            int[] iwork, int liwork)
            => LAPACKE_ssyevd_2stage_work(layout, jobz, uplo,
                n, a, lda,
                w, work, lwork,
                iwork, liwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssyevr_2stage(Layout layout, char jobz, char range,
            UpLo uplo, int n, float[] a,
            int lda, float vl, float vu,
            int il, int iu, float abstol,
            int[] m, float[] w, float[] z,
            int ldz, int[] isuppz);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ssyevr_2stage(Layout layout, char jobz, char range,
            UpLo uplo, int n, float[] a,
            int lda, float vl, float vu,
            int il, int iu, float abstol,
            int[] m, float[] w, float[] z,
            int ldz, int[] isuppz)
            => LAPACKE_ssyevr_2stage(layout, jobz, range,
                uplo, n, a,
                lda, vl, vu,
                il, iu, abstol,
                m, w, z,
                ldz, isuppz);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssyevr_2stage_work(Layout layout, char jobz,
            char range, UpLo uplo, int n,
            float[] a, int lda, float vl,
            float vu, int il, int iu,
            float abstol, int[] m, float[] w,
            float[] z, int ldz,
            int[] isuppz, float[] work,
            int lwork, int[] iwork,
            int liwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ssyevr_2stage_work(Layout layout, char jobz,
            char range, UpLo uplo, int n,
            float[] a, int lda, float vl,
            float vu, int il, int iu,
            float abstol, int[] m, float[] w,
            float[] z, int ldz,
            int[] isuppz, float[] work,
            int lwork, int[] iwork,
            int liwork)
            => LAPACKE_ssyevr_2stage_work(layout, jobz,
                range, uplo, n,
                a, lda, vl,
                vu, il, iu,
                abstol, m, w,
                z, ldz,
                isuppz, work,
                lwork, iwork,
                liwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssyevx_2stage(Layout layout, char jobz, char range,
            UpLo uplo, int n, float[] a,
            int lda, float vl, float vu,
            int il, int iu, float abstol,
            int[] m, float[] w, float[] z,
            int ldz, int[] ifail);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ssyevx_2stage(Layout layout, char jobz, char range,
            UpLo uplo, int n, float[] a,
            int lda, float vl, float vu,
            int il, int iu, float abstol,
            int[] m, float[] w, float[] z,
            int ldz, int[] ifail)
            => LAPACKE_ssyevx_2stage(layout, jobz, range,
                uplo, n, a,
                lda, vl, vu,
                il, iu, abstol,
                m, w, z,
                ldz, ifail);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssyevx_2stage_work(Layout layout, char jobz,
            char range, UpLo uplo, int n,
            float[] a, int lda, float vl,
            float vu, int il, int iu,
            float abstol, int[] m, float[] w,
            float[] z, int ldz, float[] work,
            int lwork, int[] iwork,
            int[] ifail);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ssyevx_2stage_work(Layout layout, char jobz,
            char range, UpLo uplo, int n,
            float[] a, int lda, float vl,
            float vu, int il, int iu,
            float abstol, int[] m, float[] w,
            float[] z, int ldz, float[] work,
            int lwork, int[] iwork,
            int[] ifail)
            => LAPACKE_ssyevx_2stage_work(layout, jobz,
                range, uplo, n,
                a, lda, vl,
                vu, il, iu,
                abstol, m, w,
                z, ldz, work,
                lwork, iwork,
                ifail);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssygv_2stage(Layout layout, int itype,
            char jobz, UpLo uplo, int n, float[] a,
            int lda, float[] b, int ldb,
            float[] w);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ssygv_2stage(Layout layout, int itype,
            char jobz, UpLo uplo, int n, float[] a,
            int lda, float[] b, int ldb,
            float[] w)
            => LAPACKE_ssygv_2stage(layout, itype,
                jobz, uplo, n, a,
                lda, b, ldb,
                w);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssygv_2stage_work(Layout layout, int itype,
            char jobz, UpLo uplo, int n,
            float[] a, int lda, float[] b,
            int ldb, float[] w, float[] work,
            int lwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ssygv_2stage_work(Layout layout, int itype,
            char jobz, UpLo uplo, int n,
            float[] a, int lda, float[] b,
            int ldb, float[] w, float[] work,
            int lwork)
            => LAPACKE_ssygv_2stage_work(layout, itype,
                jobz, uplo, n,
                a, lda, b,
                ldb, w, work,
                lwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_mkl_dgetrfnp(Layout layout, int m, int n,
            double[] a, int lda);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int mkl_dgetrfnp(Layout layout, int m, int n,
            double[] a, int lda)
            => LAPACKE_mkl_dgetrfnp(layout, m, n,
                a, lda);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_mkl_dgetrfnp_work(Layout layout, int m,
            int n, double[] a, int lda);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int mkl_dgetrfnp_work(Layout layout, int m,
            int n, double[] a, int lda)
            => LAPACKE_mkl_dgetrfnp_work(layout, m,
                n, a, lda);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_mkl_sgetrfnp(Layout layout, int m, int n,
            float[] a, int lda);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int mkl_sgetrfnp(Layout layout, int m, int n,
            float[] a, int lda)
            => LAPACKE_mkl_sgetrfnp(layout, m, n,
                a, lda);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_mkl_sgetrfnp_work(Layout layout, int m,
            int n, float[] a, int lda);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int mkl_sgetrfnp_work(Layout layout, int m,
            int n, float[] a, int lda)
            => LAPACKE_mkl_sgetrfnp_work(layout, m,
                n, a, lda);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_mkl_dgetrinp(Layout layout, int n, double[] a,
            int lda);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int mkl_dgetrinp(Layout layout, int n, double[] a,
            int lda)
            => LAPACKE_mkl_dgetrinp(layout, n, a,
                lda);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_mkl_dgetrinp_work(Layout layout, int n,
            double[] a, int lda, double[] work,
            int lwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int mkl_dgetrinp_work(Layout layout, int n,
            double[] a, int lda, double[] work,
            int lwork)
            => LAPACKE_mkl_dgetrinp_work(layout, n,
                a, lda, work,
                lwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_mkl_sgetrinp(Layout layout, int n, float[] a,
            int lda);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int mkl_sgetrinp(Layout layout, int n, float[] a,
            int lda)
            => LAPACKE_mkl_sgetrinp(layout, n, a,
                lda);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_mkl_sgetrinp_work(Layout layout, int n,
            float[] a, int lda, float[] work,
            int lwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int mkl_sgetrinp_work(Layout layout, int n,
            float[] a, int lda, float[] work,
            int lwork)
            => LAPACKE_mkl_sgetrinp_work(layout, n,
                a, lda, work,
                lwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void LAPACKE_set_nancheck(int flag);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void set_nancheck(int flag)
            => LAPACKE_set_nancheck(flag);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_get_nancheck();
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int get_nancheck()
            => LAPACKE_get_nancheck();

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsysv_aa_2stage(Layout layout, UpLo uplo,
            int n, int nrhs, double[] a,
            int lda, double[] tb, int ltb,
            int[] ipiv, int[] ipiv2,
            double[] b, int ldb);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dsysv_aa_2stage(Layout layout, UpLo uplo,
            int n, int nrhs, double[] a,
            int lda, double[] tb, int ltb,
            int[] ipiv, int[] ipiv2,
            double[] b, int ldb)
            => LAPACKE_dsysv_aa_2stage(layout, uplo,
                n, nrhs, a,
                lda, tb, ltb,
                ipiv, ipiv2,
                b, ldb);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsysv_aa_2stage_work(Layout layout, UpLo uplo,
            int n, int nrhs,
            double[] a, int lda, double[] tb,
            int ltb, int[] ipiv,
            int[] ipiv2, double[] b,
            int ldb, double[] work,
            int lwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dsysv_aa_2stage_work(Layout layout, UpLo uplo,
            int n, int nrhs,
            double[] a, int lda, double[] tb,
            int ltb, int[] ipiv,
            int[] ipiv2, double[] b,
            int ldb, double[] work,
            int lwork)
            => LAPACKE_dsysv_aa_2stage_work(layout, uplo,
                n, nrhs,
                a, lda, tb,
                ltb, ipiv,
                ipiv2, b,
                ldb, work,
                lwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsytrf_aa_2stage(Layout layout, UpLo uplo,
            int n, double[] a, int lda,
            double[] tb, int ltb,
            int[] ipiv, int[] ipiv2);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dsytrf_aa_2stage(Layout layout, UpLo uplo,
            int n, double[] a, int lda,
            double[] tb, int ltb,
            int[] ipiv, int[] ipiv2)
            => LAPACKE_dsytrf_aa_2stage(layout, uplo,
                n, a, lda,
                tb, ltb,
                ipiv, ipiv2);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsytrf_aa_2stage_work(Layout layout, UpLo uplo,
            int n, double[] a,
            int lda, double[] tb,
            int ltb, int[] ipiv,
            int[] ipiv2, double[] work,
            int lwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dsytrf_aa_2stage_work(Layout layout, UpLo uplo,
            int n, double[] a,
            int lda, double[] tb,
            int ltb, int[] ipiv,
            int[] ipiv2, double[] work,
            int lwork)
            => LAPACKE_dsytrf_aa_2stage_work(layout, uplo,
                n, a,
                lda, tb,
                ltb, ipiv,
                ipiv2, work,
                lwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsytrs_aa_2stage(Layout layout, UpLo uplo,
            int n, int nrhs, double[] a,
            int lda, double[] tb,
            int ltb, int[] ipiv,
            int[] ipiv2, double[] b,
            int ldb);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dsytrs_aa_2stage(Layout layout, UpLo uplo,
            int n, int nrhs, double[] a,
            int lda, double[] tb,
            int ltb, int[] ipiv,
            int[] ipiv2, double[] b,
            int ldb)
            => LAPACKE_dsytrs_aa_2stage(layout, uplo,
                n, nrhs, a,
                lda, tb,
                ltb, ipiv,
                ipiv2, b,
                ldb);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsytrs_aa_2stage_work(Layout layout, UpLo uplo,
            int n, int nrhs,
            double[] a, int lda,
            double[] tb, int ltb,
            int[] ipiv, int[] ipiv2,
            double[] b, int ldb);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dsytrs_aa_2stage_work(Layout layout, UpLo uplo,
            int n, int nrhs,
            double[] a, int lda,
            double[] tb, int ltb,
            int[] ipiv, int[] ipiv2,
            double[] b, int ldb)
            => LAPACKE_dsytrs_aa_2stage_work(layout, uplo,
                n, nrhs,
                a, lda,
                tb, ltb,
                ipiv, ipiv2,
                b, ldb);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssysv_aa_2stage(Layout layout, UpLo uplo,
            int n, int nrhs, float[] a,
            int lda, float[] tb, int ltb,
            int[] ipiv, int[] ipiv2,
            float[] b, int ldb);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ssysv_aa_2stage(Layout layout, UpLo uplo,
            int n, int nrhs, float[] a,
            int lda, float[] tb, int ltb,
            int[] ipiv, int[] ipiv2,
            float[] b, int ldb)
            => LAPACKE_ssysv_aa_2stage(layout, uplo,
                n, nrhs, a,
                lda, tb, ltb,
                ipiv, ipiv2,
                b, ldb);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssysv_aa_2stage_work(Layout layout, UpLo uplo,
            int n, int nrhs,
            float[] a, int lda, float[] tb,
            int ltb, int[] ipiv,
            int[] ipiv2, float[] b,
            int ldb, float[] work,
            int lwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ssysv_aa_2stage_work(Layout layout, UpLo uplo,
            int n, int nrhs,
            float[] a, int lda, float[] tb,
            int ltb, int[] ipiv,
            int[] ipiv2, float[] b,
            int ldb, float[] work,
            int lwork)
            => LAPACKE_ssysv_aa_2stage_work(layout, uplo,
                n, nrhs,
                a, lda, tb,
                ltb, ipiv,
                ipiv2, b,
                ldb, work,
                lwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssytrf_aa_2stage(Layout layout, UpLo uplo,
            int n, float[] a, int lda,
            float[] tb, int ltb,
            int[] ipiv, int[] ipiv2);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ssytrf_aa_2stage(Layout layout, UpLo uplo,
            int n, float[] a, int lda,
            float[] tb, int ltb,
            int[] ipiv, int[] ipiv2)
            => LAPACKE_ssytrf_aa_2stage(layout, uplo,
                n, a, lda,
                tb, ltb,
                ipiv, ipiv2);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssytrf_aa_2stage_work(Layout layout, UpLo uplo,
            int n, float[] a,
            int lda, float[] tb,
            int ltb, int[] ipiv,
            int[] ipiv2, float[] work,
            int lwork);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ssytrf_aa_2stage_work(Layout layout, UpLo uplo,
            int n, float[] a,
            int lda, float[] tb,
            int ltb, int[] ipiv,
            int[] ipiv2, float[] work,
            int lwork)
            => LAPACKE_ssytrf_aa_2stage_work(layout, uplo,
                n, a,
                lda, tb,
                ltb, ipiv,
                ipiv2, work,
                lwork);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssytrs_aa_2stage(Layout layout, UpLo uplo,
            int n, int nrhs, float[] a,
            int lda, float[] tb, int ltb,
            int[] ipiv, int[] ipiv2,
            float[] b, int ldb);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ssytrs_aa_2stage(Layout layout, UpLo uplo,
            int n, int nrhs, float[] a,
            int lda, float[] tb, int ltb,
            int[] ipiv, int[] ipiv2,
            float[] b, int ldb)
            => LAPACKE_ssytrs_aa_2stage(layout, uplo,
                n, nrhs, a,
                lda, tb, ltb,
                ipiv, ipiv2,
                b, ldb);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssytrs_aa_2stage_work(Layout layout, UpLo uplo,
            int n, int nrhs,
            float[] a, int lda, float[] tb,
            int ltb, int[] ipiv,
            int[] ipiv2, float[] b,
            int ldb);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ssytrs_aa_2stage_work(Layout layout, UpLo uplo,
            int n, int nrhs,
            float[] a, int lda, float[] tb,
            int ltb, int[] ipiv,
            int[] ipiv2, float[] b,
            int ldb)
            => LAPACKE_ssytrs_aa_2stage_work(layout, uplo,
                n, nrhs,
                a, lda, tb,
                ltb, ipiv,
                ipiv2, b,
                ldb);
    }
}