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

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dpotrf(Layout order, UpLo uplo, int n, double[] a, int lda)
        {
            return LAPACKE_dpotrf(order, uplo, n, a, lda);
        }

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern double LAPACKE_dlamch(char cmach);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern double LAPACKE_dlamch_work(char cmach);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern double LAPACKE_dlange(Layout layout, Norm norm, int m,
            int n, double[] a, int lda);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern double LAPACKE_dlange_work(Layout layout, Norm norm, int m,
            int n, double[] a, int lda,
            double[] work);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern double LAPACKE_dlansy(Layout layout, Norm norm, UpLo uplo, int n,
            double[] a, int lda);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern double LAPACKE_dlansy_work(Layout layout, Norm norm, UpLo uplo,
            int n, double[] a, int lda,
            double[] work);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern double LAPACKE_dlantr(Layout layout, Norm norm, UpLo uplo, DiagChar diag,
            int m, int n, double[] a,
            int lda);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern double LAPACKE_dlantr_work(Layout layout, Norm norm, UpLo uplo,
            DiagChar diag, int m, int n,
            double[] a, int lda, double[] work);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern double LAPACKE_dlapy2(double x, double y);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern double LAPACKE_dlapy2_work(double x, double y);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern double LAPACKE_dlapy3(double x, double y, double z);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern double LAPACKE_dlapy3_work(double x, double y, double z);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern float LAPACKE_slamch(char cmach);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern float LAPACKE_slamch_work(char cmach);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern float LAPACKE_slange(Layout layout, Norm norm, int m,
            int n, float[] a, int lda);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern float LAPACKE_slange_work(Layout layout, Norm norm, int m,
            int n, float[] a, int lda,
            float[] work);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern float LAPACKE_slansy(Layout layout, Norm norm, UpLo uplo, int n,
            float[] a, int lda);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern float LAPACKE_slansy_work(Layout layout, Norm norm, UpLo uplo,
            int n, float[] a, int lda,
            float[] work);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern float LAPACKE_slantr(Layout layout, Norm norm, UpLo uplo, DiagChar diag,
            int m, int n, float[] a,
            int lda);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern float LAPACKE_slantr_work(Layout layout, Norm norm, UpLo uplo,
            DiagChar diag, int m, int n,
            float[] a, int lda, float[] work);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern float LAPACKE_slapy2(float x, float y);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern float LAPACKE_slapy2_work(float x, float y);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern float LAPACKE_slapy3(float x, float y, float z);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern float LAPACKE_slapy3_work(float x, float y, float z);
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
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dbdsdc(Layout layout, UpLo uplo, char compq,
            int n, double[] d, double[] e, double[] u,
            int ldu, double[] vt, int ldvt,
            double[] q, int[] iq);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dbdsdc_work(Layout layout, UpLo uplo, char compq,
            int n, double[] d, double[] e, double[] u,
            int ldu, double[] vt, int ldvt,
            double[] q, int[] iq, double[] work,
            int[] iwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dbdsqr(Layout layout, UpLo uplo, int n,
            int ncvt, int nru, int ncc,
            double[] d, double[] e, double[] vt, int ldvt,
            double[] u, int ldu, double[] c,
            int ldc);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dbdsqr_work(Layout layout, UpLo uplo, int n,
            int ncvt, int nru, int ncc,
            double[] d, double[] e, double[] vt,
            int ldvt, double[] u, int ldu,
            double[] c, int ldc, double[] work);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dbdsvdx(Layout layout, UpLo uplo, char jobz, char range,
            int n, double[] d, double[] e,
            double vl, double vu,
            int il, int iu, int[] ns,
            double[] s, double[] z, int ldz,
            int[] superb);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dbdsvdx_work(Layout layout, UpLo uplo, char jobz, char range,
            int n, double[] d, double[] e,
            double vl, double vu,
            int il, int iu, int[] ns,
            double[] s, double[] z, int ldz,
            double[] work, int[] iwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ddisna(char job, int m, int n,
            double[] d, double[] sep);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ddisna_work(char job, int m, int n,
            double[] d, double[] sep);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgbbrd(Layout layout, char vect, int m,
            int n, int ncc, int kl,
            int ku, double[] ab, int ldab,
            double[] d, double[] e, double[] q, int ldq,
            double[] pt, int ldpt, double[] c,
            int ldc);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgbbrd_work(Layout layout, char vect, int m,
            int n, int ncc, int kl,
            int ku, double[] ab, int ldab,
            double[] d, double[] e, double[] q, int ldq,
            double[] pt, int ldpt, double[] c,
            int ldc, double[] work);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgbcon(Layout layout, Norm norm, int n,
            int kl, int ku, double[] ab,
            int ldab, int[] ipiv,
            double anorm, double[] rcond);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgbcon_work(Layout layout, Norm norm, int n,
            int kl, int ku, double[] ab,
            int ldab, int[] ipiv,
            double anorm, double[] rcond, double[] work,
            int[] iwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgbequ(Layout layout, int m, int n,
            int kl, int ku, double[] ab,
            int ldab, double[] r, double[] c,
            double[] rowcnd, double[] colcnd, double[] amax);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgbequ_work(Layout layout, int m, int n,
            int kl, int ku, double[] ab,
            int ldab, double[] r, double[] c,
            double[] rowcnd, double[] colcnd, double[] amax);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgbequb(Layout layout, int m, int n,
            int kl, int ku, double[] ab,
            int ldab, double[] r, double[] c,
            double[] rowcnd, double[] colcnd, double[] amax);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgbequb_work(Layout layout, int m, int n,
            int kl, int ku, double[] ab,
            int ldab, double[] r, double[] c,
            double[] rowcnd, double[] colcnd, double[] amax);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgbrfs(Layout layout, TransChar trans, int n,
            int kl, int ku, int nrhs,
            double[] ab, int ldab, double[] afb,
            int ldafb, int[] ipiv,
            double[] b, int ldb, double[] x,
            int ldx, double[] ferr, double[] berr);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgbrfs_work(Layout layout, TransChar trans, int n,
            int kl, int ku, int nrhs,
            double[] ab, int ldab,
            double[] afb, int ldafb,
            int[] ipiv, double[] b,
            int ldb, double[] x, int ldx,
            double[] ferr, double[] berr, double[] work,
            int[] iwork);
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
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgbsv(Layout layout, int n, int kl,
            int ku, int nrhs, double[] ab,
            int ldab, int[] ipiv, double[] b,
            int ldb);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgbsv_work(Layout layout, int n, int kl,
            int ku, int nrhs, double[] ab,
            int ldab, int[] ipiv, double[] b,
            int ldb);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgbsvx(Layout layout, char fact, TransChar trans,
            int n, int kl, int ku,
            int nrhs, double[] ab, int ldab,
            double[] afb, int ldafb, int[] ipiv,
            char[] equed, double[] r, double[] c, double[] b,
            int ldb, double[] x, int ldx,
            double[] rcond, double[] ferr, double[] berr,
            double[] rpivot);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgbsvx_work(Layout layout, char fact, TransChar trans,
            int n, int kl, int ku,
            int nrhs, double[] ab, int ldab,
            double[] afb, int ldafb, int[] ipiv,
            char[] equed, double[] r, double[] c, double[] b,
            int ldb, double[] x, int ldx,
            double[] rcond, double[] ferr, double[] berr,
            double[] work, int[] iwork);
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
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgbtrf(Layout layout, int m, int n,
            int kl, int ku, double[] ab,
            int ldab, int[] ipiv);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgbtrf_work(Layout layout, int m, int n,
            int kl, int ku, double[] ab,
            int ldab, int[] ipiv);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgbtrs(Layout layout, TransChar trans, int n,
            int kl, int ku, int nrhs,
            double[] ab, int ldab,
            int[] ipiv, double[] b, int ldb);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgbtrs_work(Layout layout, TransChar trans, int n,
            int kl, int ku, int nrhs,
            double[] ab, int ldab,
            int[] ipiv, double[] b,
            int ldb);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgebak(Layout layout, char job, char side, int n,
            int ilo, int ihi, double[] scale,
            int m, double[] v, int ldv);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgebak_work(Layout layout, char job, char side,
            int n, int ilo, int ihi,
            double[] scale, int m, double[] v,
            int ldv);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgebal(Layout layout, char job, int n, double[] a,
            int lda, int[] ilo, int[] ihi,
            double[] scale);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgebal_work(Layout layout, char job, int n,
            double[] a, int lda, int[] ilo,
            int[] ihi, double[] scale);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgebrd(Layout layout, int m, int n,
            double[] a, int lda, double[] d, double[] e,
            double[] tauq, double[] taup);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgebrd_work(Layout layout, int m, int n,
            double[] a, int lda, double[] d, double[] e,
            double[] tauq, double[] taup, double[] work,
            int lwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgecon(Layout layout, Norm norm, int n,
            double[] a, int lda, double anorm,
            double[] rcond);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgecon_work(Layout layout, Norm norm, int n,
            double[] a, int lda, double anorm,
            double[] rcond, double[] work, int[] iwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgeequ(Layout layout, int m, int n,
            double[] a, int lda, double[] r,
            double[] c, double[] rowcnd, double[] colcnd,
            double[] amax);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgeequ_work(Layout layout, int m, int n,
            double[] a, int lda, double[] r,
            double[] c, double[] rowcnd, double[] colcnd,
            double[] amax);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgeequb(Layout layout, int m, int n,
            double[] a, int lda, double[] r,
            double[] c, double[] rowcnd, double[] colcnd,
            double[] amax);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgeequb_work(Layout layout, int m, int n,
            double[] a, int lda, double[] r,
            double[] c, double[] rowcnd, double[] colcnd,
            double[] amax);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgeev(Layout layout, char jobvl, char jobvr,
            int n, double[] a, int lda, double[] wr,
            double[] wi, double[] vl, int ldvl, double[] vr,
            int ldvr);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgeev_work(Layout layout, char jobvl, char jobvr,
            int n, double[] a, int lda,
            double[] wr, double[] wi, double[] vl,
            int ldvl, double[] vr, int ldvr,
            double[] work, int lwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgeevx(Layout layout, char balanc, char jobvl,
            char jobvr, char sense, int n, double[] a,
            int lda, double[] wr, double[] wi, double[] vl,
            int ldvl, double[] vr, int ldvr,
            int[] ilo, int[] ihi, double[] scale,
            double[] abnrm, double[] rconde, double[] rcondv);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgeevx_work(Layout layout, char balanc, char jobvl,
            char jobvr, char sense, int n, double[] a,
            int lda, double[] wr, double[] wi,
            double[] vl, int ldvl, double[] vr,
            int ldvr, int[] ilo,
            int[] ihi, double[] scale, double[] abnrm,
            double[] rconde, double[] rcondv, double[] work,
            int lwork, int[] iwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgehrd(Layout layout, int n, int ilo,
            int ihi, double[] a, int lda,
            double[] tau);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgehrd_work(Layout layout, int n, int ilo,
            int ihi, double[] a, int lda,
            double[] tau, double[] work, int lwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgejsv(Layout layout, char joba, char jobu, char jobv,
            char jobr, char jobt, char jobp, int m,
            int n, double[] a, int lda, double[] sva,
            double[] u, int ldu, double[] v, int ldv,
            double[] stat, int[] istat);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgejsv_work(Layout layout, char joba, char jobu,
            char jobv, char jobr, char jobt, char jobp,
            int m, int n, double[] a,
            int lda, double[] sva, double[] u,
            int ldu, double[] v, int ldv,
            double[] work, int lwork,
            int[] iwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgelq2(Layout layout, int m, int n,
            double[] a, int lda, double[] tau);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgelq2_work(Layout layout, int m, int n,
            double[] a, int lda, double[] tau,
            double[] work);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgelqf(Layout layout, int m, int n,
            double[] a, int lda, double[] tau);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgelqf_work(Layout layout, int m, int n,
            double[] a, int lda, double[] tau,
            double[] work, int lwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgels(Layout layout, TransChar trans, int m,
            int n, int nrhs, double[] a,
            int lda, double[] b, int ldb);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgels_work(Layout layout, TransChar trans, int m,
            int n, int nrhs, double[] a,
            int lda, double[] b, int ldb,
            double[] work, int lwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgelsd(Layout layout, int m, int n,
            int nrhs, double[] a, int lda,
            double[] b, int ldb, double[] s, double rcond,
            int[] rank);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgelsd_work(Layout layout, int m, int n,
            int nrhs, double[] a, int lda,
            double[] b, int ldb, double[] s,
            double rcond, int[] rank, double[] work,
            int lwork, int[] iwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgelss(Layout layout, int m, int n,
            int nrhs, double[] a, int lda,
            double[] b, int ldb, double[] s, double rcond,
            int[] rank);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgelss_work(Layout layout, int m, int n,
            int nrhs, double[] a, int lda,
            double[] b, int ldb, double[] s,
            double rcond, int[] rank, double[] work,
            int lwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgelsy(Layout layout, int m, int n,
            int nrhs, double[] a, int lda,
            double[] b, int ldb, int[] jpvt,
            double rcond, int[] rank);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgelsy_work(Layout layout, int m, int n,
            int nrhs, double[] a, int lda,
            double[] b, int ldb, int[] jpvt,
            double rcond, int[] rank, double[] work,
            int lwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgemqrt(Layout layout, char side, TransChar trans,
            int m, int n, int k,
            int nb, double[] v, int ldv,
            double[] t, int ldt, double[] c,
            int ldc);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgemqrt_work(Layout layout, char side, TransChar trans,
            int m, int n, int k,
            int nb, double[] v, int ldv,
            double[] t, int ldt, double[] c,
            int ldc, double[] work);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgeqlf(Layout layout, int m, int n,
            double[] a, int lda, double[] tau);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgeqlf_work(Layout layout, int m, int n,
            double[] a, int lda, double[] tau,
            double[] work, int lwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgeqp3(Layout layout, int m, int n,
            double[] a, int lda, int[] jpvt,
            double[] tau);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgeqp3_work(Layout layout, int m, int n,
            double[] a, int lda, int[] jpvt,
            double[] tau, double[] work, int lwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgeqpf(Layout layout, int m, int n,
            double[] a, int lda, int[] jpvt,
            double[] tau);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgeqpf_work(Layout layout, int m, int n,
            double[] a, int lda, int[] jpvt,
            double[] tau, double[] work);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgeqr2(Layout layout, int m, int n,
            double[] a, int lda, double[] tau);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgeqr2_work(Layout layout, int m, int n,
            double[] a, int lda, double[] tau,
            double[] work);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgeqrf(Layout layout, int m, int n,
            double[] a, int lda, double[] tau);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgeqrf_work(Layout layout, int m, int n,
            double[] a, int lda, double[] tau,
            double[] work, int lwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgeqrfp(Layout layout, int m, int n,
            double[] a, int lda, double[] tau);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgeqrfp_work(Layout layout, int m, int n,
            double[] a, int lda, double[] tau,
            double[] work, int lwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgeqrt(Layout layout, int m, int n,
            int nb, double[] a, int lda, double[] t,
            int ldt);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgeqrt2(Layout layout, int m, int n,
            double[] a, int lda, double[] t,
            int ldt);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgeqrt2_work(Layout layout, int m, int n,
            double[] a, int lda, double[] t,
            int ldt);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgeqrt3(Layout layout, int m, int n,
            double[] a, int lda, double[] t,
            int ldt);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgeqrt3_work(Layout layout, int m, int n,
            double[] a, int lda, double[] t,
            int ldt);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgeqrt_work(Layout layout, int m, int n,
            int nb, double[] a, int lda,
            double[] t, int ldt, double[] work);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgerfs(Layout layout, TransChar trans, int n,
            int nrhs, double[] a, int lda,
            double[] af, int ldaf,
            int[] ipiv, double[] b,
            int ldb, double[] x, int ldx,
            double[] ferr, double[] berr);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgerfs_work(Layout layout, TransChar trans, int n,
            int nrhs, double[] a,
            int lda, double[] af,
            int ldaf, int[] ipiv,
            double[] b, int ldb, double[] x,
            int ldx, double[] ferr, double[] berr,
            double[] work, int[] iwork);
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
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgerqf(Layout layout, int m, int n,
            double[] a, int lda, double[] tau);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgerqf_work(Layout layout, int m, int n,
            double[] a, int lda, double[] tau,
            double[] work, int lwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgesdd(Layout layout, char jobz, int m,
            int n, double[] a, int lda, double[] s,
            double[] u, int ldu, double[] vt,
            int ldvt);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgesdd_work(Layout layout, char jobz, int m,
            int n, double[] a, int lda,
            double[] s, double[] u, int ldu,
            double[] vt, int ldvt, double[] work,
            int lwork, int[] iwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgesv(Layout layout, int n, int nrhs,
            double[] a, int lda, int[] ipiv,
            double[] b, int ldb);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgesv_work(Layout layout, int n, int nrhs,
            double[] a, int lda, int[] ipiv,
            double[] b, int ldb);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgesvd(Layout layout, char jobu, char jobvt,
            int m, int n, double[] a,
            int lda, double[] s, double[] u, int ldu,
            double[] vt, int ldvt, double[] superb);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgesvd_work(Layout layout, char jobu, char jobvt,
            int m, int n, double[] a,
            int lda, double[] s, double[] u,
            int ldu, double[] vt, int ldvt,
            double[] work, int lwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgesvdx(Layout layout, char jobu, char jobvt, char range,
            int m, int n, double[] a,
            int lda, double vl, double vu,
            int il, int iu, int[] ns,
            double[] s, double[] u, int ldu,
            double[] vt, int ldvt,
            int[] superb);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgesvdx_work(Layout layout, char jobu, char jobvt, char range,
            int m, int n, double[] a,
            int lda, double vl, double vu,
            int il, int iu, int[] ns,
            double[] s, double[] u, int ldu,
            double[] vt, int ldvt,
            double[] work, int lwork, int[] iwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgesvj(Layout layout, char joba, char jobu, char jobv,
            int m, int n, double[] a,
            int lda, double[] sva, int mv,
            double[] v, int ldv, double[] stat);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgesvj_work(Layout layout, char joba, char jobu,
            char jobv, int m, int n,
            double[] a, int lda, double[] sva,
            int mv, double[] v, int ldv,
            double[] work, int lwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgesvx(Layout layout, char fact, TransChar trans,
            int n, int nrhs, double[] a,
            int lda, double[] af, int ldaf,
            int[] ipiv, char[] equed, double[] r, double[] c,
            double[] b, int ldb, double[] x, int ldx,
            double[] rcond, double[] ferr, double[] berr,
            double[] rpivot);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgesvx_work(Layout layout, char fact, TransChar trans,
            int n, int nrhs, double[] a,
            int lda, double[] af, int ldaf,
            int[] ipiv, char[] equed, double[] r,
            double[] c, double[] b, int ldb, double[] x,
            int ldx, double[] rcond, double[] ferr,
            double[] berr, double[] work, int[] iwork);
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
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgetf2(Layout layout, int m, int n,
            double[] a, int lda, int[] ipiv);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgetf2_work(Layout layout, int m, int n,
            double[] a, int lda, int[] ipiv);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgetrf(Layout layout, int m, int n,
            double[] a, int lda, int[] ipiv);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgetrf2(Layout layout, int m, int n,
            double[] a, int lda, int[] ipiv);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgetrf2_work(Layout layout, int m, int n,
            double[] a, int lda, int[] ipiv);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgetrf_work(Layout layout, int m, int n,
            double[] a, int lda, int[] ipiv);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgetri(Layout layout, int n, double[] a,
            int lda, int[] ipiv);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgetri_work(Layout layout, int n, double[] a,
            int lda, int[] ipiv,
            double[] work, int lwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgetrs(Layout layout, TransChar trans, int n,
            int nrhs, double[] a, int lda,
            int[] ipiv, double[] b, int ldb);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgetrs_work(Layout layout, TransChar trans, int n,
            int nrhs, double[] a,
            int lda, int[] ipiv,
            double[] b, int ldb);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dggbak(Layout layout, char job, char side, int n,
            int ilo, int ihi, double[] lscale,
            double[] rscale, int m, double[] v,
            int ldv);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dggbak_work(Layout layout, char job, char side,
            int n, int ilo, int ihi,
            double[] lscale, double[] rscale,
            int m, double[] v, int ldv);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dggbal(Layout layout, char job, int n, double[] a,
            int lda, double[] b, int ldb,
            int[] ilo, int[] ihi, double[] lscale,
            double[] rscale);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dggbal_work(Layout layout, char job, int n,
            double[] a, int lda, double[] b,
            int ldb, int[] ilo,
            int[] ihi, double[] lscale, double[] rscale,
            double[] work);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dggev(Layout layout, char jobvl, char jobvr,
            int n, double[] a, int lda, double[] b,
            int ldb, double[] alphar, double[] alphai,
            double[] beta, double[] vl, int ldvl, double[] vr,
            int ldvr);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dggev3(Layout layout,
            char jobvl, char jobvr, int n,
            double[] a, int lda,
            double[] b, int ldb,
            double[] alphar, double[] alphai, double[] beta,
            double[] vl, int ldvl,
            double[] vr, int ldvr);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dggev3_work(Layout layout, char jobvl, char jobvr,
            int n, double[] a, int lda,
            double[] b, int ldb, double[] alphar,
            double[] alphai, double[] beta, double[] vl,
            int ldvl, double[] vr, int ldvr,
            double[] work, int lwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dggev_work(Layout layout, char jobvl, char jobvr,
            int n, double[] a, int lda,
            double[] b, int ldb, double[] alphar,
            double[] alphai, double[] beta, double[] vl,
            int ldvl, double[] vr, int ldvr,
            double[] work, int lwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dggevx(Layout layout, char balanc, char jobvl,
            char jobvr, char sense, int n, double[] a,
            int lda, double[] b, int ldb,
            double[] alphar, double[] alphai, double[] beta,
            double[] vl, int ldvl, double[] vr,
            int ldvr, int[] ilo, int[] ihi,
            double[] lscale, double[] rscale, double[] abnrm,
            double[] bbnrm, double[] rconde, double[] rcondv);
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
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dggglm(Layout layout, int n, int m,
            int p, double[] a, int lda, double[] b,
            int ldb, double[] d, double[] x, double[] y);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dggglm_work(Layout layout, int n, int m,
            int p, double[] a, int lda,
            double[] b, int ldb, double[] d, double[] x,
            double[] y, double[] work, int lwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgghd3(Layout layout, char compq, char compz,
            int n, int ilo, int ihi,
            double[] a, int lda,
            double[] b, int ldb,
            double[] q, int ldq,
            double[] z, int ldz);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgghd3_work(Layout layout, char compq, char compz,
            int n, int ilo, int ihi,
            double[] a, int lda, double[] b,
            int ldb, double[] q, int ldq,
            double[] z, int ldz, double[] work,
            int lwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgghrd(Layout layout, char compq, char compz,
            int n, int ilo, int ihi,
            double[] a, int lda, double[] b, int ldb,
            double[] q, int ldq, double[] z,
            int ldz);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgghrd_work(Layout layout, char compq, char compz,
            int n, int ilo, int ihi,
            double[] a, int lda, double[] b,
            int ldb, double[] q, int ldq,
            double[] z, int ldz);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgglse(Layout layout, int m, int n,
            int p, double[] a, int lda, double[] b,
            int ldb, double[] c, double[] d, double[] x);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgglse_work(Layout layout, int m, int n,
            int p, double[] a, int lda,
            double[] b, int ldb, double[] c, double[] d,
            double[] x, double[] work, int lwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dggqrf(Layout layout, int n, int m,
            int p, double[] a, int lda,
            double[] taua, double[] b, int ldb,
            double[] taub);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dggqrf_work(Layout layout, int n, int m,
            int p, double[] a, int lda,
            double[] taua, double[] b, int ldb,
            double[] taub, double[] work, int lwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dggrqf(Layout layout, int m, int p,
            int n, double[] a, int lda,
            double[] taua, double[] b, int ldb,
            double[] taub);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dggrqf_work(Layout layout, int m, int p,
            int n, double[] a, int lda,
            double[] taua, double[] b, int ldb,
            double[] taub, double[] work, int lwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dggsvd(Layout layout, char jobu, char jobv, char jobq,
            int m, int n, int p,
            int[] k, int[] l, double[] a,
            int lda, double[] b, int ldb,
            double[] alpha, double[] beta, double[] u,
            int ldu, double[] v, int ldv, double[] q,
            int ldq, int[] iwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dggsvd3(Layout layout, char jobu, char jobv, char jobq,
            int m, int n, int p,
            int[] k, int[] l, double[] a,
            int lda, double[] b, int ldb,
            double[] alpha, double[] beta, double[] u,
            int ldu, double[] v, int ldv, double[] q,
            int ldq, int[] iwork);
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
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dggsvd_work(Layout layout, char jobu, char jobv,
            char jobq, int m, int n,
            int p, int[] k, int[] l,
            double[] a, int lda, double[] b,
            int ldb, double[] alpha, double[] beta,
            double[] u, int ldu, double[] v,
            int ldv, double[] q, int ldq,
            double[] work, int[] iwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dggsvp(Layout layout, char jobu, char jobv, char jobq,
            int m, int p, int n, double[] a,
            int lda, double[] b, int ldb,
            double tola, double tolb, int[] k,
            int[] l, double[] u, int ldu, double[] v,
            int ldv, double[] q, int ldq);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dggsvp3(Layout layout, char jobu, char jobv, char jobq,
            int m, int p, int n, double[] a,
            int lda, double[] b, int ldb,
            double tola, double tolb, int[] k,
            int[] l, double[] u, int ldu, double[] v,
            int ldv, double[] q, int ldq);
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
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dggsvp_work(Layout layout, char jobu, char jobv,
            char jobq, int m, int p,
            int n, double[] a, int lda,
            double[] b, int ldb, double tola,
            double tolb, int[] k, int[] l,
            double[] u, int ldu, double[] v,
            int ldv, double[] q, int ldq,
            int[] iwork, double[] tau, double[] work);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgtcon(Norm norm, int n, double[] dl,
            double[] d, double[] du, double[] du2,
            int[] ipiv, double anorm, double[] rcond);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgtcon_work(Norm norm, int n, double[] dl,
            double[] d, double[] du,
            double[] du2, int[] ipiv,
            double anorm, double[] rcond, double[] work,
            int[] iwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgtrfs(Layout layout, TransChar trans, int n,
            int nrhs, double[] dl, double[] d,
            double[] du, double[] dlf,
            double[] df, double[] duf,
            double[] du2, int[] ipiv,
            double[] b, int ldb, double[] x,
            int ldx, double[] ferr, double[] berr);
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
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgtsv(Layout layout, int n, int nrhs,
            double[] dl, double[] d, double[] du, double[] b,
            int ldb);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgtsv_work(Layout layout, int n, int nrhs,
            double[] dl, double[] d, double[] du, double[] b,
            int ldb);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgtsvx(Layout layout, char fact, TransChar trans,
            int n, int nrhs, double[] dl,
            double[] d, double[] du, double[] dlf,
            double[] df, double[] duf, double[] du2,
            int[] ipiv, double[] b, int ldb,
            double[] x, int ldx, double[] rcond,
            double[] ferr, double[] berr);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgtsvx_work(Layout layout, char fact, TransChar trans,
            int n, int nrhs, double[] dl,
            double[] d, double[] du, double[] dlf,
            double[] df, double[] duf, double[] du2,
            int[] ipiv, double[] b,
            int ldb, double[] x, int ldx,
            double[] rcond, double[] ferr, double[] berr,
            double[] work, int[] iwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgttrf(int n, double[] dl, double[] d, double[] du,
            double[] du2, int[] ipiv);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgttrf_work(int n, double[] dl, double[] d, double[] du,
            double[] du2, int[] ipiv);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgttrs(Layout layout, TransChar trans, int n,
            int nrhs, double[] dl, double[] d,
            double[] du, double[] du2,
            int[] ipiv, double[] b, int ldb);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgttrs_work(Layout layout, TransChar trans, int n,
            int nrhs, double[] dl,
            double[] d, double[] du,
            double[] du2, int[] ipiv,
            double[] b, int ldb);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dhgeqz(Layout layout, char job, char compq, char compz,
            int n, int ilo, int ihi,
            double[] h, int ldh, double[] t, int ldt,
            double[] alphar, double[] alphai, double[] beta,
            double[] q, int ldq, double[] z,
            int ldz);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dhgeqz_work(Layout layout, char job, char compq,
            char compz, int n, int ilo,
            int ihi, double[] h, int ldh,
            double[] t, int ldt, double[] alphar,
            double[] alphai, double[] beta, double[] q,
            int ldq, double[] z, int ldz,
            double[] work, int lwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dhsein(Layout layout, char job, char eigsrc, char initv,
            int[] select, int n,
            double[] h, int ldh, double[] wr,
            double[] wi, double[] vl, int ldvl,
            double[] vr, int ldvr, int mm,
            int[] m, int[] ifaill,
            int[] ifailr);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dhsein_work(Layout layout, char job, char eigsrc,
            char initv, int[] select,
            int n, double[] h, int ldh,
            double[] wr, double[] wi, double[] vl,
            int ldvl, double[] vr, int ldvr,
            int mm, int[] m, double[] work,
            int[] ifaill, int[] ifailr);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dhseqr(Layout layout, char job, char compz, int n,
            int ilo, int ihi, double[] h,
            int ldh, double[] wr, double[] wi, double[] z,
            int ldz);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dhseqr_work(Layout layout, char job, char compz,
            int n, int ilo, int ihi,
            double[] h, int ldh, double[] wr,
            double[] wi, double[] z, int ldz,
            double[] work, int lwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dlacn2(int n, double[] v, double[] x, int[] isgn,
            double[] est, int[] kase, int[] isave);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dlacn2_work(int n, double[] v, double[] x,
            int[] isgn, double[] est, int[] kase,
            int[] isave);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dlacpy(Layout layout, UpLo uplo, int m,
            int n, double[] a, int lda,
            double[] b, int ldb);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dlacpy_work(Layout layout, UpLo uplo, int m,
            int n, double[] a, int lda,
            double[] b, int ldb);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dlag2s(Layout layout, int m, int n,
            double[] a, int lda, float[] sa,
            int ldsa);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dlag2s_work(Layout layout, int m, int n,
            double[] a, int lda, float[] sa,
            int ldsa);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dlagge(Layout layout, int m, int n,
            int kl, int ku, double[] d,
            double[] a, int lda, int[] iseed);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dlagge_work(Layout layout, int m, int n,
            int kl, int ku, double[] d,
            double[] a, int lda, int[] iseed,
            double[] work);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dlagsy(Layout layout, int n, int k,
            double[] d, double[] a, int lda,
            int[] iseed);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dlagsy_work(Layout layout, int n, int k,
            double[] d, double[] a, int lda,
            int[] iseed, double[] work);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dlapmr(Layout layout, int forwrd,
            int m, int n, double[] x,
            int ldx, int[] k);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dlapmr_work(Layout layout, int forwrd,
            int m, int n, double[] x,
            int ldx, int[] k);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dlapmt(Layout layout, int forwrd,
            int m, int n, double[] x,
            int ldx, int[] k);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dlapmt_work(Layout layout, int forwrd,
            int m, int n, double[] x,
            int ldx, int[] k);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dlarfb(Layout layout, char side, TransChar trans, char direct,
            char storev, int m, int n,
            int k, double[] v, int ldv,
            double[] t, int ldt, double[] c,
            int ldc);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dlarfb_work(Layout layout, char side, TransChar trans,
            char direct, char storev, int m,
            int n, int k, double[] v,
            int ldv, double[] t, int ldt,
            double[] c, int ldc, double[] work,
            int ldwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dlarfg(int n, double[] alpha, double[] x,
            int incx, double[] tau);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dlarfg_work(int n, double[] alpha, double[] x,
            int incx, double[] tau);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dlarft(Layout layout, char direct, char storev,
            int n, int k, double[] v,
            int ldv, double[] tau, double[] t,
            int ldt);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dlarft_work(Layout layout, char direct, char storev,
            int n, int k, double[] v,
            int ldv, double[] tau, double[] t,
            int ldt);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dlarfx(Layout layout, char side, int m,
            int n, double[] v, double tau, double[] c,
            int ldc, double[] work);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dlarfx_work(Layout layout, char side, int m,
            int n, double[] v, double tau,
            double[] c, int ldc, double[] work);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dlarnv(int idist, int[] iseed, int n,
            double[] x);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dlarnv_work(int idist, int[] iseed,
            int n, double[] x);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dlartgp(double f, double g, double[] cs, double[] sn,
            double[] r);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dlartgp_work(double f, double g, double[] cs, double[] sn,
            double[] r);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dlartgs(double x, double y, double sigma, double[] cs,
            double[] sn);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dlartgs_work(double x, double y, double sigma, double[] cs,
            double[] sn);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dlascl(Layout layout, char type, int kl,
            int ku, double cfrom, double cto,
            int m, int n, double[] a,
            int lda);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dlascl_work(Layout layout, char type, int kl,
            int ku, double cfrom, double cto,
            int m, int n, double[] a,
            int lda);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dlaset(Layout layout, UpLo uplo, int m,
            int n, double alpha, double beta, double[] a,
            int lda);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dlaset_work(Layout layout, UpLo uplo, int m,
            int n, double alpha, double beta,
            double[] a, int lda);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dlasrt(char id, int n, double[] d);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dlasrt_work(char id, int n, double[] d);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dlaswp(Layout layout, int n, double[] a,
            int lda, int k1, int k2,
            int[] ipiv, int incx);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dlaswp_work(Layout layout, int n, double[] a,
            int lda, int k1, int k2,
            int[] ipiv, int incx);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dlatms(Layout layout, int m, int n,
            char dist, int[] iseed, char sym, double[] d,
            int mode, double cond, double dmax,
            int kl, int ku, char pack, double[] a,
            int lda);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dlatms_work(Layout layout, int m, int n,
            char dist, int[] iseed, char sym,
            double[] d, int mode, double cond,
            double dmax, int kl, int ku,
            char pack, double[] a, int lda,
            double[] work);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dlauum(Layout layout, UpLo uplo, int n, double[] a,
            int lda);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dlauum_work(Layout layout, UpLo uplo, int n,
            double[] a, int lda);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dopgtr(Layout layout, UpLo uplo, int n,
            double[] ap, double[] tau, double[] q,
            int ldq);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dopgtr_work(Layout layout, UpLo uplo, int n,
            double[] ap, double[] tau, double[] q,
            int ldq, double[] work);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dopmtr(Layout layout, char side, UpLo uplo, TransChar trans,
            int m, int n, double[] ap,
            double[] tau, double[] c, int ldc);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dopmtr_work(Layout layout, char side, UpLo uplo,
            TransChar trans, int m, int n,
            double[] ap, double[] tau, double[] c,
            int ldc, double[] work);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dorbdb(Layout layout, TransChar trans, char signs,
            int m, int p, int q,
            double[] x11, int ldx11, double[] x12,
            int ldx12, double[] x21, int ldx21,
            double[] x22, int ldx22, double[] theta,
            double[] phi, double[] taup1, double[] taup2,
            double[] tauq1, double[] tauq2);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dorbdb_work(Layout layout, TransChar trans, char signs,
            int m, int p, int q,
            double[] x11, int ldx11, double[] x12,
            int ldx12, double[] x21, int ldx21,
            double[] x22, int ldx22, double[] theta,
            double[] phi, double[] taup1, double[] taup2,
            double[] tauq1, double[] tauq2, double[] work,
            int lwork);
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
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dorcsd2by1(Layout layout, char jobu1, char jobu2,
            char jobv1t, int m, int p, int q,
            double[] x11, int ldx11, double[] x21, int ldx21,
            double[] theta, double[] u1, int ldu1, double[] u2,
            int ldu2, double[] v1t, int ldv1t);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dorcsd2by1_work(Layout layout, char jobu1, char jobu2,
            char jobv1t, int m, int p,
            int q, double[] x11, int ldx11,
            double[] x21, int ldx21,
            double[] theta, double[] u1, int ldu1,
            double[] u2, int ldu2, double[] v1t,
            int ldv1t, double[] work, int lwork,
            int[] iwork);
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
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dorgbr(Layout layout, char vect, int m,
            int n, int k, double[] a,
            int lda, double[] tau);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dorgbr_work(Layout layout, char vect, int m,
            int n, int k, double[] a,
            int lda, double[] tau, double[] work,
            int lwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dorghr(Layout layout, int n, int ilo,
            int ihi, double[] a, int lda,
            double[] tau);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dorghr_work(Layout layout, int n, int ilo,
            int ihi, double[] a, int lda,
            double[] tau, double[] work,
            int lwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dorglq(Layout layout, int m, int n,
            int k, double[] a, int lda,
            double[] tau);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dorglq_work(Layout layout, int m, int n,
            int k, double[] a, int lda,
            double[] tau, double[] work,
            int lwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dorgql(Layout layout, int m, int n,
            int k, double[] a, int lda,
            double[] tau);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dorgql_work(Layout layout, int m, int n,
            int k, double[] a, int lda,
            double[] tau, double[] work,
            int lwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dorgqr(Layout layout, int m, int n,
            int k, double[] a, int lda,
            double[] tau);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dorgqr_work(Layout layout, int m, int n,
            int k, double[] a, int lda,
            double[] tau, double[] work,
            int lwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dorgrq(Layout layout, int m, int n,
            int k, double[] a, int lda,
            double[] tau);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dorgrq_work(Layout layout, int m, int n,
            int k, double[] a, int lda,
            double[] tau, double[] work,
            int lwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dorgtr(Layout layout, UpLo uplo, int n, double[] a,
            int lda, double[] tau);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dorgtr_work(Layout layout, UpLo uplo, int n,
            double[] a, int lda, double[] tau,
            double[] work, int lwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dormbr(Layout layout, char vect, char side, TransChar trans,
            int m, int n, int k,
            double[] a, int lda, double[] tau,
            double[] c, int ldc);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dormbr_work(Layout layout, char vect, char side,
            TransChar trans, int m, int n,
            int k, double[] a, int lda,
            double[] tau, double[] c, int ldc,
            double[] work, int lwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dormhr(Layout layout, char side, TransChar trans,
            int m, int n, int ilo,
            int ihi, double[] a, int lda,
            double[] tau, double[] c, int ldc);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dormhr_work(Layout layout, char side, TransChar trans,
            int m, int n, int ilo,
            int ihi, double[] a, int lda,
            double[] tau, double[] c, int ldc,
            double[] work, int lwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dormlq(Layout layout, char side, TransChar trans,
            int m, int n, int k,
            double[] a, int lda, double[] tau,
            double[] c, int ldc);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dormlq_work(Layout layout, char side, TransChar trans,
            int m, int n, int k,
            double[] a, int lda,
            double[] tau, double[] c, int ldc,
            double[] work, int lwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dormql(Layout layout, char side, TransChar trans,
            int m, int n, int k,
            double[] a, int lda, double[] tau,
            double[] c, int ldc);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dormql_work(Layout layout, char side, TransChar trans,
            int m, int n, int k,
            double[] a, int lda,
            double[] tau, double[] c, int ldc,
            double[] work, int lwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dormqr(Layout layout, char side, TransChar trans,
            int m, int n, int k,
            double[] a, int lda, double[] tau,
            double[] c, int ldc);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dormqr_work(Layout layout, char side, TransChar trans,
            int m, int n, int k,
            double[] a, int lda,
            double[] tau, double[] c, int ldc,
            double[] work, int lwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dormrq(Layout layout, char side, TransChar trans,
            int m, int n, int k,
            double[] a, int lda, double[] tau,
            double[] c, int ldc);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dormrq_work(Layout layout, char side, TransChar trans,
            int m, int n, int k,
            double[] a, int lda,
            double[] tau, double[] c, int ldc,
            double[] work, int lwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dormrz(Layout layout, char side, TransChar trans,
            int m, int n, int k,
            int l, double[] a, int lda,
            double[] tau, double[] c, int ldc);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dormrz_work(Layout layout, char side, TransChar trans,
            int m, int n, int k,
            int l, double[] a, int lda,
            double[] tau, double[] c, int ldc,
            double[] work, int lwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dormtr(Layout layout, char side, UpLo uplo, TransChar trans,
            int m, int n, double[] a,
            int lda, double[] tau, double[] c,
            int ldc);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dormtr_work(Layout layout, char side, UpLo uplo,
            TransChar trans, int m, int n,
            double[] a, int lda,
            double[] tau, double[] c, int ldc,
            double[] work, int lwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dpbcon(Layout layout, UpLo uplo, int n,
            int kd, double[] ab, int ldab,
            double anorm, double[] rcond);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dpbcon_work(Layout layout, UpLo uplo, int n,
            int kd, double[] ab,
            int ldab, double anorm, double[] rcond,
            double[] work, int[] iwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dpbequ(Layout layout, UpLo uplo, int n,
            int kd, double[] ab, int ldab,
            double[] s, double[] scond, double[] amax);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dpbequ_work(Layout layout, UpLo uplo, int n,
            int kd, double[] ab,
            int ldab, double[] s, double[] scond,
            double[] amax);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dpbrfs(Layout layout, UpLo uplo, int n,
            int kd, int nrhs, double[] ab,
            int ldab, double[] afb, int ldafb,
            double[] b, int ldb, double[] x,
            int ldx, double[] ferr, double[] berr);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dpbrfs_work(Layout layout, UpLo uplo, int n,
            int kd, int nrhs,
            double[] ab, int ldab,
            double[] afb, int ldafb,
            double[] b, int ldb, double[] x,
            int ldx, double[] ferr, double[] berr,
            double[] work, int[] iwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dpbstf(Layout layout, UpLo uplo, int n,
            int kb, double[] bb, int ldbb);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dpbstf_work(Layout layout, UpLo uplo, int n,
            int kb, double[] bb, int ldbb);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dpbsv(Layout layout, UpLo uplo, int n,
            int kd, int nrhs, double[] ab,
            int ldab, double[] b, int ldb);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dpbsv_work(Layout layout, UpLo uplo, int n,
            int kd, int nrhs, double[] ab,
            int ldab, double[] b, int ldb);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dpbsvx(Layout layout, char fact, UpLo uplo, int n,
            int kd, int nrhs, double[] ab,
            int ldab, double[] afb, int ldafb,
            char[] equed, double[] s, double[] b, int ldb,
            double[] x, int ldx, double[] rcond,
            double[] ferr, double[] berr);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dpbsvx_work(Layout layout, char fact, UpLo uplo,
            int n, int kd, int nrhs,
            double[] ab, int ldab, double[] afb,
            int ldafb, char[] equed, double[] s,
            double[] b, int ldb, double[] x,
            int ldx, double[] rcond, double[] ferr,
            double[] berr, double[] work, int[] iwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dpbtrf(Layout layout, UpLo uplo, int n,
            int kd, double[] ab, int ldab);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dpbtrf_work(Layout layout, UpLo uplo, int n,
            int kd, double[] ab, int ldab);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dpbtrs(Layout layout, UpLo uplo, int n,
            int kd, int nrhs, double[] ab,
            int ldab, double[] b, int ldb);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dpbtrs_work(Layout layout, UpLo uplo, int n,
            int kd, int nrhs,
            double[] ab, int ldab, double[] b,
            int ldb);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dpftrf(Layout layout, TransChar transr, UpLo uplo,
            int n, double[] a);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dpftrf_work(Layout layout, TransChar transr, UpLo uplo,
            int n, double[] a);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dpftri(Layout layout, TransChar transr, UpLo uplo,
            int n, double[] a);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dpftri_work(Layout layout, TransChar transr, UpLo uplo,
            int n, double[] a);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dpftrs(Layout layout, TransChar transr, UpLo uplo,
            int n, int nrhs, double[] a,
            double[] b, int ldb);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dpftrs_work(Layout layout, TransChar transr, UpLo uplo,
            int n, int nrhs, double[] a,
            double[] b, int ldb);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dpocon(Layout layout, UpLo uplo, int n,
            double[] a, int lda, double anorm,
            double[] rcond);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dpocon_work(Layout layout, UpLo uplo, int n,
            double[] a, int lda, double anorm,
            double[] rcond, double[] work, int[] iwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dpoequ(Layout layout, int n, double[] a,
            int lda, double[] s, double[] scond,
            double[] amax);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dpoequ_work(Layout layout, int n, double[] a,
            int lda, double[] s, double[] scond,
            double[] amax);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dpoequb(Layout layout, int n, double[] a,
            int lda, double[] s, double[] scond,
            double[] amax);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dpoequb_work(Layout layout, int n,
            double[] a, int lda, double[] s,
            double[] scond, double[] amax);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dporfs(Layout layout, UpLo uplo, int n,
            int nrhs, double[] a, int lda,
            double[] af, int ldaf, double[] b,
            int ldb, double[] x, int ldx,
            double[] ferr, double[] berr);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dporfs_work(Layout layout, UpLo uplo, int n,
            int nrhs, double[] a,
            int lda, double[] af,
            int ldaf, double[] b,
            int ldb, double[] x, int ldx,
            double[] ferr, double[] berr, double[] work,
            int[] iwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dporfsx(Layout layout, UpLo uplo, char equed,
            int n, int nrhs, double[] a,
            int lda, double[] af, int ldaf,
            double[] s, double[] b, int ldb,
            double[] x, int ldx, double[] rcond,
            double[] berr, int n_err_bnds,
            double[] err_bnds_norm, double[] err_bnds_comp,
            int nparams, double[] aparams);
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
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dposv(Layout layout, UpLo uplo, int n,
            int nrhs, double[] a, int lda, double[] b,
            int ldb);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dposv_work(Layout layout, UpLo uplo, int n,
            int nrhs, double[] a, int lda,
            double[] b, int ldb);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dposvx(Layout layout, char fact, UpLo uplo, int n,
            int nrhs, double[] a, int lda,
            double[] af, int ldaf, char[] equed, double[] s,
            double[] b, int ldb, double[] x, int ldx,
            double[] rcond, double[] ferr, double[] berr);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dposvx_work(Layout layout, char fact, UpLo uplo,
            int n, int nrhs, double[] a,
            int lda, double[] af, int ldaf,
            char[] equed, double[] s, double[] b,
            int ldb, double[] x, int ldx,
            double[] rcond, double[] ferr, double[] berr,
            double[] work, int[] iwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dposvxx(Layout layout, char fact, UpLo uplo,
            int n, int nrhs, double[] a,
            int lda, double[] af, int ldaf,
            char[] equed, double[] s, double[] b, int ldb,
            double[] x, int ldx, double[] rcond,
            double[] rpvgrw, double[] berr, int n_err_bnds,
            double[] err_bnds_norm, double[] err_bnds_comp,
            int nparams, double[] aparams);
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
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dpotrf(Layout layout, UpLo uplo, int n, double[] a,
            int lda);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dpotrf2(Layout layout, UpLo uplo, int n, double[] a,
            int lda);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dpotrf2_work(Layout layout, UpLo uplo, int n,
            double[] a, int lda);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dpotrf_work(Layout layout, UpLo uplo, int n,
            double[] a, int lda);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dpotri(Layout layout, UpLo uplo, int n, double[] a,
            int lda);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dpotri_work(Layout layout, UpLo uplo, int n,
            double[] a, int lda);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dpotrs(Layout layout, UpLo uplo, int n,
            int nrhs, double[] a, int lda,
            double[] b, int ldb);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dpotrs_work(Layout layout, UpLo uplo, int n,
            int nrhs, double[] a,
            int lda, double[] b, int ldb);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dppcon(Layout layout, UpLo uplo, int n,
            double[] ap, double anorm, double[] rcond);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dppcon_work(Layout layout, UpLo uplo, int n,
            double[] ap, double anorm, double[] rcond,
            double[] work, int[] iwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dppequ(Layout layout, UpLo uplo, int n,
            double[] ap, double[] s, double[] scond,
            double[] amax);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dppequ_work(Layout layout, UpLo uplo, int n,
            double[] ap, double[] s, double[] scond,
            double[] amax);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dpprfs(Layout layout, UpLo uplo, int n,
            int nrhs, double[] ap, double[] afp,
            double[] b, int ldb, double[] x,
            int ldx, double[] ferr, double[] berr);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dpprfs_work(Layout layout, UpLo uplo, int n,
            int nrhs, double[] ap,
            double[] afp, double[] b,
            int ldb, double[] x, int ldx,
            double[] ferr, double[] berr, double[] work,
            int[] iwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dppsv(Layout layout, UpLo uplo, int n,
            int nrhs, double[] ap, double[] b,
            int ldb);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dppsv_work(Layout layout, UpLo uplo, int n,
            int nrhs, double[] ap, double[] b,
            int ldb);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dppsvx(Layout layout, char fact, UpLo uplo, int n,
            int nrhs, double[] ap, double[] afp,
            char[] equed, double[] s, double[] b, int ldb,
            double[] x, int ldx, double[] rcond,
            double[] ferr, double[] berr);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dppsvx_work(Layout layout, char fact, UpLo uplo,
            int n, int nrhs, double[] ap,
            double[] afp, char[] equed, double[] s, double[] b,
            int ldb, double[] x, int ldx,
            double[] rcond, double[] ferr, double[] berr,
            double[] work, int[] iwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dpptrf(Layout layout, UpLo uplo, int n,
            double[] ap);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dpptrf_work(Layout layout, UpLo uplo, int n,
            double[] ap);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dpptri(Layout layout, UpLo uplo, int n,
            double[] ap);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dpptri_work(Layout layout, UpLo uplo, int n,
            double[] ap);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dpptrs(Layout layout, UpLo uplo, int n,
            int nrhs, double[] ap, double[] b,
            int ldb);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dpptrs_work(Layout layout, UpLo uplo, int n,
            int nrhs, double[] ap, double[] b,
            int ldb);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dpstrf(Layout layout, UpLo uplo, int n, double[] a,
            int lda, int[] piv, int[] rank,
            double tol);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dpstrf_work(Layout layout, UpLo uplo, int n,
            double[] a, int lda, int[] piv,
            int[] rank, double tol, double[] work);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dptcon(int n, double[] d, double[] e,
            double anorm, double[] rcond);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dptcon_work(int n, double[] d, double[] e,
            double anorm, double[] rcond, double[] work);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dpteqr(Layout layout, char compz, int n,
            double[] d, double[] e, double[] z, int ldz);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dpteqr_work(Layout layout, char compz, int n,
            double[] d, double[] e, double[] z, int ldz,
            double[] work);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dptrfs(Layout layout, int n, int nrhs,
            double[] d, double[] e, double[] df,
            double[] ef, double[] b, int ldb,
            double[] x, int ldx, double[] ferr,
            double[] berr);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dptrfs_work(Layout layout, int n, int nrhs,
            double[] d, double[] e,
            double[] df, double[] ef,
            double[] b, int ldb, double[] x,
            int ldx, double[] ferr, double[] berr,
            double[] work);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dptsv(Layout layout, int n, int nrhs,
            double[] d, double[] e, double[] b, int ldb);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dptsv_work(Layout layout, int n, int nrhs,
            double[] d, double[] e, double[] b, int ldb);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dptsvx(Layout layout, char fact, int n,
            int nrhs, double[] d, double[] e,
            double[] df, double[] ef, double[] b,
            int ldb, double[] x, int ldx,
            double[] rcond, double[] ferr, double[] berr);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dptsvx_work(Layout layout, char fact, int n,
            int nrhs, double[] d,
            double[] e, double[] df, double[] ef,
            double[] b, int ldb, double[] x,
            int ldx, double[] rcond, double[] ferr,
            double[] berr, double[] work);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dpttrf(int n, double[] d, double[] e);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dpttrf_work(int n, double[] d, double[] e);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dpttrs(Layout layout, int n, int nrhs,
            double[] d, double[] e, double[] b,
            int ldb);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dpttrs_work(Layout layout, int n, int nrhs,
            double[] d, double[] e, double[] b,
            int ldb);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsbev(Layout layout, char jobz, UpLo uplo, int n,
            int kd, double[] ab, int ldab, double[] w,
            double[] z, int ldz);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsbev_work(Layout layout, char jobz, UpLo uplo,
            int n, int kd, double[] ab,
            int ldab, double[] w, double[] z,
            int ldz, double[] work);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsbevd(Layout layout, char jobz, UpLo uplo, int n,
            int kd, double[] ab, int ldab,
            double[] w, double[] z, int ldz);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsbevd_work(Layout layout, char jobz, UpLo uplo,
            int n, int kd, double[] ab,
            int ldab, double[] w, double[] z,
            int ldz, double[] work, int lwork,
            int[] iwork, int liwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsbevx(Layout layout, char jobz, char range, UpLo uplo,
            int n, int kd, double[] ab,
            int ldab, double[] q, int ldq,
            double vl, double vu, int il, int iu,
            double abstol, int[] m, double[] w, double[] z,
            int ldz, int[] ifail);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsbevx_work(Layout layout, char jobz, char range,
            UpLo uplo, int n, int kd,
            double[] ab, int ldab, double[] q,
            int ldq, double vl, double vu,
            int il, int iu, double abstol,
            int[] m, double[] w, double[] z,
            int ldz, double[] work, int[] iwork,
            int[] ifail);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsbgst(Layout layout, char vect, UpLo uplo, int n,
            int ka, int kb, double[] ab,
            int ldab, double[] bb, int ldbb,
            double[] x, int ldx);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsbgst_work(Layout layout, char vect, UpLo uplo,
            int n, int ka, int kb,
            double[] ab, int ldab, double[] bb,
            int ldbb, double[] x, int ldx,
            double[] work);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsbgv(Layout layout, char jobz, UpLo uplo, int n,
            int ka, int kb, double[] ab,
            int ldab, double[] bb, int ldbb,
            double[] w, double[] z, int ldz);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsbgv_work(Layout layout, char jobz, UpLo uplo,
            int n, int ka, int kb,
            double[] ab, int ldab, double[] bb,
            int ldbb, double[] w, double[] z,
            int ldz, double[] work);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsbgvd(Layout layout, char jobz, UpLo uplo, int n,
            int ka, int kb, double[] ab,
            int ldab, double[] bb, int ldbb,
            double[] w, double[] z, int ldz);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsbgvd_work(Layout layout, char jobz, UpLo uplo,
            int n, int ka, int kb,
            double[] ab, int ldab, double[] bb,
            int ldbb, double[] w, double[] z,
            int ldz, double[] work, int lwork,
            int[] iwork, int liwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsbgvx(Layout layout, char jobz, char range, UpLo uplo,
            int n, int ka, int kb,
            double[] ab, int ldab, double[] bb,
            int ldbb, double[] q, int ldq,
            double vl, double vu, int il, int iu,
            double abstol, int[] m, double[] w, double[] z,
            int ldz, int[] ifail);
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
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsbtrd(Layout layout, char vect, UpLo uplo, int n,
            int kd, double[] ab, int ldab,
            double[] d, double[] e, double[] q, int ldq);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsbtrd_work(Layout layout, char vect, UpLo uplo,
            int n, int kd, double[] ab,
            int ldab, double[] d, double[] e,
            double[] q, int ldq, double[] work);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsfrk(Layout layout, TransChar transr, UpLo uplo, TransChar trans,
            int n, int k, double alpha,
            double[] a, int lda, double beta,
            double[] c);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsfrk_work(Layout layout, TransChar transr, UpLo uplo,
            TransChar trans, int n, int k,
            double alpha, double[] a, int lda,
            double beta, double[] c);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsgesv(Layout layout, int n, int nrhs,
            double[] a, int lda, int[] ipiv,
            double[] b, int ldb, double[] x, int ldx,
            int[] iter);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsgesv_work(Layout layout, int n, int nrhs,
            double[] a, int lda, int[] ipiv,
            double[] b, int ldb, double[] x,
            int ldx, double[] work, float[] swork,
            int[] iter);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dspcon(Layout layout, UpLo uplo, int n,
            double[] ap, int[] ipiv,
            double anorm, double[] rcond);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dspcon_work(Layout layout, UpLo uplo, int n,
            double[] ap, int[] ipiv,
            double anorm, double[] rcond, double[] work,
            int[] iwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dspev(Layout layout, char jobz, UpLo uplo, int n,
            double[] ap, double[] w, double[] z, int ldz);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dspev_work(Layout layout, char jobz, UpLo uplo,
            int n, double[] ap, double[] w, double[] z,
            int ldz, double[] work);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dspevd(Layout layout, char jobz, UpLo uplo, int n,
            double[] ap, double[] w, double[] z, int ldz);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dspevd_work(Layout layout, char jobz, UpLo uplo,
            int n, double[] ap, double[] w, double[] z,
            int ldz, double[] work, int lwork,
            int[] iwork, int liwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dspevx(Layout layout, char jobz, char range, UpLo uplo,
            int n, double[] ap, double vl, double vu,
            int il, int iu, double abstol,
            int[] m, double[] w, double[] z, int ldz,
            int[] ifail);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dspevx_work(Layout layout, char jobz, char range,
            UpLo uplo, int n, double[] ap, double vl,
            double vu, int il, int iu,
            double abstol, int[] m, double[] w,
            double[] z, int ldz, double[] work,
            int[] iwork, int[] ifail);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dspgst(Layout layout, int itype, UpLo uplo,
            int n, double[] ap, double[] bp);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dspgst_work(Layout layout, int itype, UpLo uplo,
            int n, double[] ap, double[] bp);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dspgv(Layout layout, int itype, char jobz,
            UpLo uplo, int n, double[] ap, double[] bp,
            double[] w, double[] z, int ldz);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dspgv_work(Layout layout, int itype, char jobz,
            UpLo uplo, int n, double[] ap, double[] bp,
            double[] w, double[] z, int ldz,
            double[] work);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dspgvd(Layout layout, int itype, char jobz,
            UpLo uplo, int n, double[] ap, double[] bp,
            double[] w, double[] z, int ldz);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dspgvd_work(Layout layout, int itype, char jobz,
            UpLo uplo, int n, double[] ap, double[] bp,
            double[] w, double[] z, int ldz,
            double[] work, int lwork,
            int[] iwork, int liwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dspgvx(Layout layout, int itype, char jobz,
            char range, UpLo uplo, int n, double[] ap,
            double[] bp, double vl, double vu, int il,
            int iu, double abstol, int[] m,
            double[] w, double[] z, int ldz,
            int[] ifail);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dspgvx_work(Layout layout, int itype, char jobz,
            char range, UpLo uplo, int n, double[] ap,
            double[] bp, double vl, double vu, int il,
            int iu, double abstol, int[] m,
            double[] w, double[] z, int ldz,
            double[] work, int[] iwork,
            int[] ifail);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsposv(Layout layout, UpLo uplo, int n,
            int nrhs, double[] a, int lda,
            double[] b, int ldb, double[] x, int ldx,
            int[] iter);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsposv_work(Layout layout, UpLo uplo, int n,
            int nrhs, double[] a, int lda,
            double[] b, int ldb, double[] x,
            int ldx, double[] work, float[] swork,
            int[] iter);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsprfs(Layout layout, UpLo uplo, int n,
            int nrhs, double[] ap, double[] afp,
            int[] ipiv, double[] b,
            int ldb, double[] x, int ldx,
            double[] ferr, double[] berr);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsprfs_work(Layout layout, UpLo uplo, int n,
            int nrhs, double[] ap,
            double[] afp, int[] ipiv,
            double[] b, int ldb, double[] x,
            int ldx, double[] ferr, double[] berr,
            double[] work, int[] iwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dspsv(Layout layout, UpLo uplo, int n,
            int nrhs, double[] ap, int[] ipiv,
            double[] b, int ldb);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dspsv_work(Layout layout, UpLo uplo, int n,
            int nrhs, double[] ap, int[] ipiv,
            double[] b, int ldb);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dspsvx(Layout layout, char fact, UpLo uplo, int n,
            int nrhs, double[] ap, double[] afp,
            int[] ipiv, double[] b, int ldb,
            double[] x, int ldx, double[] rcond,
            double[] ferr, double[] berr);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dspsvx_work(Layout layout, char fact, UpLo uplo,
            int n, int nrhs, double[] ap,
            double[] afp, int[] ipiv, double[] b,
            int ldb, double[] x, int ldx,
            double[] rcond, double[] ferr, double[] berr,
            double[] work, int[] iwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsptrd(Layout layout, UpLo uplo, int n,
            double[] ap, double[] d, double[] e, double[] tau);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsptrd_work(Layout layout, UpLo uplo, int n,
            double[] ap, double[] d, double[] e, double[] tau);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsptrf(Layout layout, UpLo uplo, int n,
            double[] ap, int[] ipiv);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsptrf_work(Layout layout, UpLo uplo, int n,
            double[] ap, int[] ipiv);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsptri(Layout layout, UpLo uplo, int n,
            double[] ap, int[] ipiv);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsptri_work(Layout layout, UpLo uplo, int n,
            double[] ap, int[] ipiv,
            double[] work);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsptrs(Layout layout, UpLo uplo, int n,
            int nrhs, double[] ap,
            int[] ipiv, double[] b, int ldb);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsptrs_work(Layout layout, UpLo uplo, int n,
            int nrhs, double[] ap,
            int[] ipiv, double[] b,
            int ldb);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dstebz(char range, char order, int n, double vl,
            double vu, int il, int iu,
            double abstol, double[] d, double[] e,
            int[] m, int[] nsplit, double[] w,
            int[] iblock, int[] isplit);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dstebz_work(char range, char order, int n, double vl,
            double vu, int il, int iu,
            double abstol, double[] d, double[] e,
            int[] m, int[] nsplit, double[] w,
            int[] iblock, int[] isplit,
            double[] work, int[] iwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dstedc(Layout layout, char compz, int n,
            double[] d, double[] e, double[] z, int ldz);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dstedc_work(Layout layout, char compz, int n,
            double[] d, double[] e, double[] z, int ldz,
            double[] work, int lwork,
            int[] iwork, int liwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dstegr(Layout layout, char jobz, char range,
            int n, double[] d, double[] e, double vl,
            double vu, int il, int iu,
            double abstol, int[] m, double[] w, double[] z,
            int ldz, int[] isuppz);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dstegr_work(Layout layout, char jobz, char range,
            int n, double[] d, double[] e, double vl,
            double vu, int il, int iu,
            double abstol, int[] m, double[] w,
            double[] z, int ldz, int[] isuppz,
            double[] work, int lwork,
            int[] iwork, int liwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dstein(Layout layout, int n, double[] d,
            double[] e, int m, double[] w,
            int[] iblock, int[] isplit,
            double[] z, int ldz, int[] ifailv);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dstein_work(Layout layout, int n, double[] d,
            double[] e, int m, double[] w,
            int[] iblock,
            int[] isplit, double[] z,
            int ldz, double[] work, int[] iwork,
            int[] ifailv);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dstemr(Layout layout, char jobz, char range,
            int n, double[] d, double[] e, double vl,
            double vu, int il, int iu,
            int[] m, double[] w, double[] z, int ldz,
            int nzc, int[] isuppz,
            int[] tryrac);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dstemr_work(Layout layout, char jobz, char range,
            int n, double[] d, double[] e, double vl,
            double vu, int il, int iu,
            int[] m, double[] w, double[] z,
            int ldz, int nzc,
            int[] isuppz, int[] tryrac,
            double[] work, int lwork,
            int[] iwork, int liwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsteqr(Layout layout, char compz, int n,
            double[] d, double[] e, double[] z, int ldz);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsteqr_work(Layout layout, char compz, int n,
            double[] d, double[] e, double[] z, int ldz,
            double[] work);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsterf(int n, double[] d, double[] e);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsterf_work(int n, double[] d, double[] e);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dstev(Layout layout, char jobz, int n, double[] d,
            double[] e, double[] z, int ldz);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dstev_work(Layout layout, char jobz, int n,
            double[] d, double[] e, double[] z, int ldz,
            double[] work);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dstevd(Layout layout, char jobz, int n, double[] d,
            double[] e, double[] z, int ldz);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dstevd_work(Layout layout, char jobz, int n,
            double[] d, double[] e, double[] z, int ldz,
            double[] work, int lwork,
            int[] iwork, int liwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dstevr(Layout layout, char jobz, char range,
            int n, double[] d, double[] e, double vl,
            double vu, int il, int iu,
            double abstol, int[] m, double[] w, double[] z,
            int ldz, int[] isuppz);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dstevr_work(Layout layout, char jobz, char range,
            int n, double[] d, double[] e, double vl,
            double vu, int il, int iu,
            double abstol, int[] m, double[] w,
            double[] z, int ldz, int[] isuppz,
            double[] work, int lwork,
            int[] iwork, int liwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dstevx(Layout layout, char jobz, char range,
            int n, double[] d, double[] e, double vl,
            double vu, int il, int iu,
            double abstol, int[] m, double[] w, double[] z,
            int ldz, int[] ifail);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dstevx_work(Layout layout, char jobz, char range,
            int n, double[] d, double[] e, double vl,
            double vu, int il, int iu,
            double abstol, int[] m, double[] w,
            double[] z, int ldz, double[] work,
            int[] iwork, int[] ifail);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsycon(Layout layout, UpLo uplo, int n,
            double[] a, int lda,
            int[] ipiv, double anorm, double[] rcond);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsycon_work(Layout layout, UpLo uplo, int n,
            double[] a, int lda,
            int[] ipiv, double anorm,
            double[] rcond, double[] work, int[] iwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsyconv(Layout layout, UpLo uplo, char way, int n,
            double[] a, int lda, int[] ipiv,
            double[] e);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsyconv_work(Layout layout, UpLo uplo, char way,
            int n, double[] a, int lda,
            int[] ipiv, double[] e);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsyequb(Layout layout, UpLo uplo, int n,
            double[] a, int lda, double[] s,
            double[] scond, double[] amax);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsyequb_work(Layout layout, UpLo uplo, int n,
            double[] a, int lda, double[] s,
            double[] scond, double[] amax, double[] work);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsyev(Layout layout, char jobz, UpLo uplo, int n,
            double[] a, int lda, double[] w);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsyev_work(Layout layout, char jobz, UpLo uplo,
            int n, double[] a, int lda,
            double[] w, double[] work, int lwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsyevd(Layout layout, char jobz, UpLo uplo, int n,
            double[] a, int lda, double[] w);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsyevd_work(Layout layout, char jobz, UpLo uplo,
            int n, double[] a, int lda,
            double[] w, double[] work, int lwork,
            int[] iwork, int liwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsyevr(Layout layout, char jobz, char range, UpLo uplo,
            int n, double[] a, int lda, double vl,
            double vu, int il, int iu,
            double abstol, int[] m, double[] w, double[] z,
            int ldz, int[] isuppz);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsyevr_work(Layout layout, char jobz, char range,
            UpLo uplo, int n, double[] a,
            int lda, double vl, double vu,
            int il, int iu, double abstol,
            int[] m, double[] w, double[] z,
            int ldz, int[] isuppz,
            double[] work, int lwork,
            int[] iwork, int liwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsyevx(Layout layout, char jobz, char range, UpLo uplo,
            int n, double[] a, int lda, double vl,
            double vu, int il, int iu,
            double abstol, int[] m, double[] w, double[] z,
            int ldz, int[] ifail);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsyevx_work(Layout layout, char jobz, char range,
            UpLo uplo, int n, double[] a,
            int lda, double vl, double vu,
            int il, int iu, double abstol,
            int[] m, double[] w, double[] z,
            int ldz, double[] work, int lwork,
            int[] iwork, int[] ifail);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsygst(Layout layout, int itype, UpLo uplo,
            int n, double[] a, int lda,
            double[] b, int ldb);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsygst_work(Layout layout, int itype, UpLo uplo,
            int n, double[] a, int lda,
            double[] b, int ldb);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsygv(Layout layout, int itype, char jobz,
            UpLo uplo, int n, double[] a, int lda,
            double[] b, int ldb, double[] w);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsygv_work(Layout layout, int itype, char jobz,
            UpLo uplo, int n, double[] a,
            int lda, double[] b, int ldb,
            double[] w, double[] work, int lwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsygvd(Layout layout, int itype, char jobz,
            UpLo uplo, int n, double[] a, int lda,
            double[] b, int ldb, double[] w);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsygvd_work(Layout layout, int itype, char jobz,
            UpLo uplo, int n, double[] a,
            int lda, double[] b, int ldb,
            double[] w, double[] work, int lwork,
            int[] iwork, int liwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsygvx(Layout layout, int itype, char jobz,
            char range, UpLo uplo, int n, double[] a,
            int lda, double[] b, int ldb, double vl,
            double vu, int il, int iu,
            double abstol, int[] m, double[] w, double[] z,
            int ldz, int[] ifail);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsygvx_work(Layout layout, int itype, char jobz,
            char range, UpLo uplo, int n, double[] a,
            int lda, double[] b, int ldb,
            double vl, double vu, int il,
            int iu, double abstol, int[] m,
            double[] w, double[] z, int ldz,
            double[] work, int lwork,
            int[] iwork, int[] ifail);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsyrfs(Layout layout, UpLo uplo, int n,
            int nrhs, double[] a, int lda,
            double[] af, int ldaf,
            int[] ipiv, double[] b,
            int ldb, double[] x, int ldx,
            double[] ferr, double[] berr);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsyrfs_work(Layout layout, UpLo uplo, int n,
            int nrhs, double[] a,
            int lda, double[] af,
            int ldaf, int[] ipiv,
            double[] b, int ldb, double[] x,
            int ldx, double[] ferr, double[] berr,
            double[] work, int[] iwork);
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
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsysv(Layout layout, UpLo uplo, int n,
            int nrhs, double[] a, int lda,
            int[] ipiv, double[] b, int ldb);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsysv_rook(Layout layout, UpLo uplo, int n,
            int nrhs, double[] a, int lda,
            int[] ipiv, double[] b, int ldb);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsysv_rook_work(Layout layout, UpLo uplo, int n,
            int nrhs, double[] a, int lda,
            int[] ipiv, double[] b, int ldb,
            double[] work, int lwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsysv_work(Layout layout, UpLo uplo, int n,
            int nrhs, double[] a, int lda,
            int[] ipiv, double[] b, int ldb,
            double[] work, int lwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsysvx(Layout layout, char fact, UpLo uplo, int n,
            int nrhs, double[] a, int lda,
            double[] af, int ldaf, int[] ipiv,
            double[] b, int ldb, double[] x,
            int ldx, double[] rcond, double[] ferr,
            double[] berr);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsysvx_work(Layout layout, char fact, UpLo uplo,
            int n, int nrhs, double[] a,
            int lda, double[] af, int ldaf,
            int[] ipiv, double[] b,
            int ldb, double[] x, int ldx,
            double[] rcond, double[] ferr, double[] berr,
            double[] work, int lwork,
            int[] iwork);
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
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsyswapr(Layout layout, UpLo uplo, int n,
            double[] a, int lda, int i1, int i2);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsyswapr_work(Layout layout, UpLo uplo, int n,
            double[] a, int lda,
            int i1, int i2);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsytrd(Layout layout, UpLo uplo, int n, double[] a,
            int lda, double[] d, double[] e, double[] tau);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsytrd_work(Layout layout, UpLo uplo, int n,
            double[] a, int lda, double[] d, double[] e,
            double[] tau, double[] work, int lwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsytrf(Layout layout, UpLo uplo, int n, double[] a,
            int lda, int[] ipiv);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsytrf_rook(Layout layout, UpLo uplo, int n, double[] a,
            int lda, int[] ipiv);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsytrf_rook_work(Layout layout, UpLo uplo, int n,
            double[] a, int lda, int[] ipiv,
            double[] work, int lwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsytrf_work(Layout layout, UpLo uplo, int n,
            double[] a, int lda, int[] ipiv,
            double[] work, int lwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsytri(Layout layout, UpLo uplo, int n, double[] a,
            int lda, int[] ipiv);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsytri2(Layout layout, UpLo uplo, int n,
            double[] a, int lda, int[] ipiv);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsytri2_work(Layout layout, UpLo uplo, int n,
            double[] a, int lda,
            int[] ipiv,
            double[] work, int lwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsytri2x(Layout layout, UpLo uplo, int n,
            double[] a, int lda, int[] ipiv,
            int nb);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsytri2x_work(Layout layout, UpLo uplo, int n,
            double[] a, int lda,
            int[] ipiv, double[] work,
            int nb);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsytri_work(Layout layout, UpLo uplo, int n,
            double[] a, int lda,
            int[] ipiv, double[] work);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsytrs(Layout layout, UpLo uplo, int n,
            int nrhs, double[] a, int lda,
            int[] ipiv, double[] b, int ldb);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsytrs2(Layout layout, UpLo uplo, int n,
            int nrhs, double[] a, int lda,
            int[] ipiv, double[] b, int ldb);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsytrs2_work(Layout layout, UpLo uplo, int n,
            int nrhs, double[] a,
            int lda, int[] ipiv,
            double[] b, int ldb, double[] work);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsytrs_rook(Layout layout, UpLo uplo, int n,
            int nrhs, double[] a, int lda,
            int[] ipiv, double[] b, int ldb);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsytrs_rook_work(Layout layout, UpLo uplo, int n,
            int nrhs, double[] a,
            int lda, int[] ipiv,
            double[] b, int ldb);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsytrs_work(Layout layout, UpLo uplo, int n,
            int nrhs, double[] a,
            int lda, int[] ipiv,
            double[] b, int ldb);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dtbcon(Layout layout, Norm norm, UpLo uplo, DiagChar diag,
            int n, int kd, double[] ab,
            int ldab, double[] rcond);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dtbcon_work(Layout layout, Norm norm, UpLo uplo,
            DiagChar diag, int n, int kd,
            double[] ab, int ldab,
            double[] rcond, double[] work, int[] iwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dtbrfs(Layout layout, UpLo uplo, TransChar trans, DiagChar diag,
            int n, int kd, int nrhs,
            double[] ab, int ldab, double[] b,
            int ldb, double[] x, int ldx,
            double[] ferr, double[] berr);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dtbrfs_work(Layout layout, UpLo uplo, TransChar trans,
            DiagChar diag, int n, int kd,
            int nrhs, double[] ab,
            int ldab, double[] b,
            int ldb, double[] x, int ldx,
            double[] ferr, double[] berr, double[] work,
            int[] iwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dtbtrs(Layout layout, UpLo uplo, TransChar trans, DiagChar diag,
            int n, int kd, int nrhs,
            double[] ab, int ldab, double[] b,
            int ldb);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dtbtrs_work(Layout layout, UpLo uplo, TransChar trans,
            DiagChar diag, int n, int kd,
            int nrhs, double[] ab,
            int ldab, double[] b, int ldb);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dtfsm(Layout layout, TransChar transr, char side, UpLo uplo,
            TransChar trans, DiagChar diag, int m, int n,
            double alpha, double[] a, double[] b,
            int ldb);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dtfsm_work(Layout layout, TransChar transr, char side,
            UpLo uplo, TransChar trans, DiagChar diag, int m,
            int n, double alpha, double[] a,
            double[] b, int ldb);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dtftri(Layout layout, TransChar transr, UpLo uplo, DiagChar diag,
            int n, double[] a);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dtftri_work(Layout layout, TransChar transr, UpLo uplo,
            DiagChar diag, int n, double[] a);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dtfttp(Layout layout, TransChar transr, UpLo uplo,
            int n, double[] arf, double[] ap);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dtfttp_work(Layout layout, TransChar transr, UpLo uplo,
            int n, double[] arf, double[] ap);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dtfttr(Layout layout, TransChar transr, UpLo uplo,
            int n, double[] arf, double[] a,
            int lda);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dtfttr_work(Layout layout, TransChar transr, UpLo uplo,
            int n, double[] arf, double[] a,
            int lda);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dtgevc(Layout layout, char side, char howmny,
            int[] select, int n,
            double[] s, int lds, double[] p,
            int ldp, double[] vl, int ldvl,
            double[] vr, int ldvr, int mm,
            int[] m);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dtgevc_work(Layout layout, char side, char howmny,
            int[] select, int n,
            double[] s, int lds,
            double[] p, int ldp, double[] vl,
            int ldvl, double[] vr, int ldvr,
            int mm, int[] m, double[] work);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dtgexc(Layout layout, int wantq,
            int wantz, int n, double[] a,
            int lda, double[] b, int ldb, double[] q,
            int ldq, double[] z, int ldz,
            int[] ifst, int[] ilst);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dtgexc_work(Layout layout, int wantq,
            int wantz, int n, double[] a,
            int lda, double[] b, int ldb,
            double[] q, int ldq, double[] z,
            int ldz, int[] ifst,
            int[] ilst, double[] work,
            int lwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dtgsen(Layout layout, int ijob,
            int wantq, int wantz,
            int[] select, int n,
            double[] a, int lda, double[] b, int ldb,
            double[] alphar, double[] alphai, double[] beta,
            double[] q, int ldq, double[] z, int ldz,
            int[] m, double[] pl, double[] pr, double[] dif);
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
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dtgsja(Layout layout, char jobu, char jobv, char jobq,
            int m, int p, int n,
            int k, int l, double[] a,
            int lda, double[] b, int ldb,
            double tola, double tolb, double[] alpha,
            double[] beta, double[] u, int ldu, double[] v,
            int ldv, double[] q, int ldq,
            int[] ncycle);
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
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dtgsna(Layout layout, char job, char howmny,
            int[] select, int n,
            double[] a, int lda, double[] b,
            int ldb, double[] vl, int ldvl,
            double[] vr, int ldvr, double[] s,
            double[] dif, int mm, int[] m);
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
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dtgsyl(Layout layout, TransChar trans, int ijob,
            int m, int n, double[] a,
            int lda, double[] b, int ldb,
            double[] c, int ldc, double[] d,
            int ldd, double[] e, int lde,
            double[] f, int ldf, double[] scale,
            double[] dif);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dtgsyl_work(Layout layout, TransChar trans, int ijob,
            int m, int n, double[] a,
            int lda, double[] b, int ldb,
            double[] c, int ldc, double[] d,
            int ldd, double[] e, int lde,
            double[] f, int ldf, double[] scale,
            double[] dif, double[] work, int lwork,
            int[] iwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dtpcon(Layout layout, Norm norm, UpLo uplo, DiagChar diag,
            int n, double[] ap, double[] rcond);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dtpcon_work(Layout layout, Norm norm, UpLo uplo,
            DiagChar diag, int n, double[] ap,
            double[] rcond, double[] work, int[] iwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dtpmqrt(Layout layout, char side, TransChar trans,
            int m, int n, int k,
            int l, int nb, double[] v,
            int ldv, double[] t, int ldt,
            double[] a, int lda, double[] b,
            int ldb);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dtpmqrt_work(Layout layout, char side, TransChar trans,
            int m, int n, int k,
            int l, int nb, double[] v,
            int ldv, double[] t,
            int ldt, double[] a, int lda,
            double[] b, int ldb, double[] work);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dtpqrt(Layout layout, int m, int n,
            int l, int nb, double[] a,
            int lda, double[] b, int ldb, double[] t,
            int ldt);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dtpqrt2(Layout layout, int m, int n,
            int l, double[] a, int lda, double[] b,
            int ldb, double[] t, int ldt);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dtpqrt2_work(Layout layout, int m, int n,
            int l, double[] a, int lda, double[] b,
            int ldb, double[] t, int ldt);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dtpqrt_work(Layout layout, int m, int n,
            int l, int nb, double[] a,
            int lda, double[] b, int ldb,
            double[] t, int ldt, double[] work);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dtprfb(Layout layout, char side, TransChar trans, char direct,
            char storev, int m, int n,
            int k, int l, double[] v,
            int ldv, double[] t, int ldt,
            double[] a, int lda, double[] b, int ldb);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dtprfb_work(Layout layout, char side, TransChar trans,
            char direct, char storev, int m,
            int n, int k, int l,
            double[] v, int ldv,
            double[] t, int ldt, double[] a,
            int lda, double[] b, int ldb,
            double[] work, int ldwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dtprfs(Layout layout, UpLo uplo, TransChar trans, DiagChar diag,
            int n, int nrhs, double[] ap,
            double[] b, int ldb, double[] x,
            int ldx, double[] ferr, double[] berr);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dtprfs_work(Layout layout, UpLo uplo, TransChar trans,
            DiagChar diag, int n, int nrhs,
            double[] ap, double[] b,
            int ldb, double[] x, int ldx,
            double[] ferr, double[] berr, double[] work,
            int[] iwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dtptri(Layout layout, UpLo uplo, DiagChar diag, int n,
            double[] ap);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dtptri_work(Layout layout, UpLo uplo, DiagChar diag,
            int n, double[] ap);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dtptrs(Layout layout, UpLo uplo, TransChar trans, DiagChar diag,
            int n, int nrhs, double[] ap,
            double[] b, int ldb);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dtptrs_work(Layout layout, UpLo uplo, TransChar trans,
            DiagChar diag, int n, int nrhs,
            double[] ap, double[] b, int ldb);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dtpttf(Layout layout, TransChar transr, UpLo uplo,
            int n, double[] ap, double[] arf);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dtpttf_work(Layout layout, TransChar transr, UpLo uplo,
            int n, double[] ap, double[] arf);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dtpttr(Layout layout, UpLo uplo, int n,
            double[] ap, double[] a, int lda);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dtpttr_work(Layout layout, UpLo uplo, int n,
            double[] ap, double[] a, int lda);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dtrcon(Layout layout, Norm norm, UpLo uplo, DiagChar diag,
            int n, double[] a, int lda,
            double[] rcond);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dtrcon_work(Layout layout, Norm norm, UpLo uplo,
            DiagChar diag, int n, double[] a,
            int lda, double[] rcond, double[] work,
            int[] iwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dtrevc(Layout layout, char side, char howmny,
            int[] select, int n,
            double[] t, int ldt, double[] vl,
            int ldvl, double[] vr, int ldvr,
            int mm, int[] m);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dtrevc_work(Layout layout, char side, char howmny,
            int[] select, int n,
            double[] t, int ldt, double[] vl,
            int ldvl, double[] vr, int ldvr,
            int mm, int[] m, double[] work);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dtrexc(Layout layout, char compq, int n,
            double[] t, int ldt, double[] q, int ldq,
            int[] ifst, int[] ilst);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dtrexc_work(Layout layout, char compq, int n,
            double[] t, int ldt, double[] q,
            int ldq, int[] ifst,
            int[] ilst, double[] work);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dtrrfs(Layout layout, UpLo uplo, TransChar trans, DiagChar diag,
            int n, int nrhs, double[] a,
            int lda, double[] b, int ldb,
            double[] x, int ldx, double[] ferr,
            double[] berr);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dtrrfs_work(Layout layout, UpLo uplo, TransChar trans,
            DiagChar diag, int n, int nrhs,
            double[] a, int lda,
            double[] b, int ldb,
            double[] x, int ldx, double[] ferr,
            double[] berr, double[] work, int[] iwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dtrsen(Layout layout, char job, char compq,
            int[] select, int n,
            double[] t, int ldt, double[] q, int ldq,
            double[] wr, double[] wi, int[] m, double[] s,
            double[] sep);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dtrsen_work(Layout layout, char job, char compq,
            int[] select, int n,
            double[] t, int ldt, double[] q,
            int ldq, double[] wr, double[] wi,
            int[] m, double[] s, double[] sep,
            double[] work, int lwork,
            int[] iwork, int liwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dtrsna(Layout layout, char job, char howmny,
            int[] select, int n,
            double[] t, int ldt, double[] vl,
            int ldvl, double[] vr, int ldvr,
            double[] s, double[] sep, int mm,
            int[] m);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dtrsna_work(Layout layout, char job, char howmny,
            int[] select, int n,
            double[] t, int ldt,
            double[] vl, int ldvl,
            double[] vr, int ldvr, double[] s,
            double[] sep, int mm, int[] m,
            double[] work, int ldwork,
            int[] iwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dtrsyl(Layout layout, char trana, char tranb,
            int isgn, int m, int n,
            double[] a, int lda, double[] b,
            int ldb, double[] c, int ldc,
            double[] scale);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dtrsyl_work(Layout layout, char trana, char tranb,
            int isgn, int m, int n,
            double[] a, int lda,
            double[] b, int ldb, double[] c,
            int ldc, double[] scale);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dtrtri(Layout layout, UpLo uplo, DiagChar diag, int n,
            double[] a, int lda);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dtrtri_work(Layout layout, UpLo uplo, DiagChar diag,
            int n, double[] a, int lda);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dtrtrs(Layout layout, UpLo uplo, TransChar trans, DiagChar diag,
            int n, int nrhs, double[] a,
            int lda, double[] b, int ldb);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dtrtrs_work(Layout layout, UpLo uplo, TransChar trans,
            DiagChar diag, int n, int nrhs,
            double[] a, int lda, double[] b,
            int ldb);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dtrttf(Layout layout, TransChar transr, UpLo uplo,
            int n, double[] a, int lda,
            double[] arf);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dtrttf_work(Layout layout, TransChar transr, UpLo uplo,
            int n, double[] a, int lda,
            double[] arf);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dtrttp(Layout layout, UpLo uplo, int n,
            double[] a, int lda, double[] ap);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dtrttp_work(Layout layout, UpLo uplo, int n,
            double[] a, int lda, double[] ap);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dtzrzf(Layout layout, int m, int n,
            double[] a, int lda, double[] tau);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dtzrzf_work(Layout layout, int m, int n,
            double[] a, int lda, double[] tau,
            double[] work, int lwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_mkl_dgetrfnpi(Layout layout, int m, int n,
            int nfact, double[] a, int lda);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_mkl_dgetrfnpi_work(Layout layout, int m, int n,
            int nfact, double[] a, int lda);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_mkl_dtppack(Layout layout, UpLo uplo, TransChar trans, int n,
            double[] ap, int i, int j, int rows,
            int cols, double[] a, int lda);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_mkl_dtppack_work(Layout layout, UpLo uplo, TransChar trans, int n,
            double[] ap, int i, int j, int rows,
            int cols, double[] a, int lda);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_mkl_dtpunpack(Layout layout, UpLo uplo, TransChar trans, int n,
            double[] ap, int i, int j, int rows,
            int cols, double[] a, int lda);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_mkl_dtpunpack_work(Layout layout, UpLo uplo, TransChar trans, int n,
            double[] ap, int i, int j, int rows,
            int cols, double[] a, int lda);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_mkl_sgetrfnpi(Layout layout, int m, int n,
            int nfact, float[] a, int lda);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_mkl_sgetrfnpi_work(Layout layout, int m, int n,
            int nfact, float[] a, int lda);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_mkl_stppack(Layout layout, UpLo uplo, TransChar trans, int n,
            float[] ap, int i, int j, int rows,
            int cols, float[] a, int lda);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_mkl_stppack_work(Layout layout, UpLo uplo, TransChar trans, int n,
            float[] ap, int i, int j, int rows,
            int cols, float[] a, int lda);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_mkl_stpunpack(Layout layout, UpLo uplo, TransChar trans, int n,
            float[] ap, int i, int j, int rows,
            int cols, float[] a, int lda);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_mkl_stpunpack_work(Layout layout, UpLo uplo, TransChar trans, int n,
            float[] ap, int i, int j, int rows,
            int cols, float[] a, int lda);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sbbcsd(Layout layout, char jobu1, char jobu2,
            char jobv1t, char jobv2t, TransChar trans, int m,
            int p, int q, float[] theta, float[] phi,
            float[] u1, int ldu1, float[] u2,
            int ldu2, float[] v1t, int ldv1t,
            float[] v2t, int ldv2t, float[] b11d,
            float[] b11e, float[] b12d, float[] b12e, float[] b21d,
            float[] b21e, float[] b22d, float[] b22e);
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
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sbdsdc(Layout layout, UpLo uplo, char compq,
            int n, float[] d, float[] e, float[] u,
            int ldu, float[] vt, int ldvt, float[] q,
            int[] iq);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sbdsdc_work(Layout layout, UpLo uplo, char compq,
            int n, float[] d, float[] e, float[] u,
            int ldu, float[] vt, int ldvt,
            float[] q, int[] iq, float[] work,
            int[] iwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sbdsqr(Layout layout, UpLo uplo, int n,
            int ncvt, int nru, int ncc,
            float[] d, float[] e, float[] vt, int ldvt,
            float[] u, int ldu, float[] c, int ldc);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sbdsqr_work(Layout layout, UpLo uplo, int n,
            int ncvt, int nru, int ncc,
            float[] d, float[] e, float[] vt, int ldvt,
            float[] u, int ldu, float[] c,
            int ldc, float[] work);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sbdsvdx(Layout layout, UpLo uplo, char jobz, char range,
            int n, float[] d, float[] e,
            float vl, float vu,
            int il, int iu, int[] ns,
            float[] s, float[] z, int ldz,
            int[] superb);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sbdsvdx_work(Layout layout, UpLo uplo, char jobz, char range,
            int n, float[] d, float[] e,
            float vl, float vu,
            int il, int iu, int[] ns,
            float[] s, float[] z, int ldz,
            float[] work, int[] iwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sdisna(char job, int m, int n, float[] d,
            float[] sep);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sdisna_work(char job, int m, int n,
            float[] d, float[] sep);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgbbrd(Layout layout, char vect, int m,
            int n, int ncc, int kl,
            int ku, float[] ab, int ldab, float[] d,
            float[] e, float[] q, int ldq, float[] pt,
            int ldpt, float[] c, int ldc);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgbbrd_work(Layout layout, char vect, int m,
            int n, int ncc, int kl,
            int ku, float[] ab, int ldab,
            float[] d, float[] e, float[] q, int ldq,
            float[] pt, int ldpt, float[] c,
            int ldc, float[] work);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgbcon(Layout layout, Norm norm, int n,
            int kl, int ku, float[] ab,
            int ldab, int[] ipiv, float anorm,
            float[] rcond);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgbcon_work(Layout layout, Norm norm, int n,
            int kl, int ku, float[] ab,
            int ldab, int[] ipiv,
            float anorm, float[] rcond, float[] work,
            int[] iwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgbequ(Layout layout, int m, int n,
            int kl, int ku, float[] ab,
            int ldab, float[] r, float[] c, float[] rowcnd,
            float[] colcnd, float[] amax);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgbequ_work(Layout layout, int m, int n,
            int kl, int ku, float[] ab,
            int ldab, float[] r, float[] c,
            float[] rowcnd, float[] colcnd, float[] amax);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgbequb(Layout layout, int m, int n,
            int kl, int ku, float[] ab,
            int ldab, float[] r, float[] c, float[] rowcnd,
            float[] colcnd, float[] amax);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgbequb_work(Layout layout, int m, int n,
            int kl, int ku, float[] ab,
            int ldab, float[] r, float[] c,
            float[] rowcnd, float[] colcnd, float[] amax);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgbrfs(Layout layout, TransChar trans, int n,
            int kl, int ku, int nrhs,
            float[] ab, int ldab, float[] afb,
            int ldafb, int[] ipiv,
            float[] b, int ldb, float[] x,
            int ldx, float[] ferr, float[] berr);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgbrfs_work(Layout layout, TransChar trans, int n,
            int kl, int ku, int nrhs,
            float[] ab, int ldab,
            float[] afb, int ldafb,
            int[] ipiv, float[] b,
            int ldb, float[] x, int ldx,
            float[] ferr, float[] berr, float[] work,
            int[] iwork);
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
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgbsv(Layout layout, int n, int kl,
            int ku, int nrhs, float[] ab,
            int ldab, int[] ipiv, float[] b,
            int ldb);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgbsv_work(Layout layout, int n, int kl,
            int ku, int nrhs, float[] ab,
            int ldab, int[] ipiv, float[] b,
            int ldb);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgbsvx(Layout layout, char fact, TransChar trans,
            int n, int kl, int ku,
            int nrhs, float[] ab, int ldab,
            float[] afb, int ldafb, int[] ipiv,
            char[] equed, float[] r, float[] c, float[] b,
            int ldb, float[] x, int ldx,
            float[] rcond, float[] ferr, float[] berr,
            float[] rpivot);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgbsvx_work(Layout layout, char fact, TransChar trans,
            int n, int kl, int ku,
            int nrhs, float[] ab, int ldab,
            float[] afb, int ldafb, int[] ipiv,
            char[] equed, float[] r, float[] c, float[] b,
            int ldb, float[] x, int ldx,
            float[] rcond, float[] ferr, float[] berr,
            float[] work, int[] iwork);
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
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgbtrf(Layout layout, int m, int n,
            int kl, int ku, float[] ab,
            int ldab, int[] ipiv);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgbtrf_work(Layout layout, int m, int n,
            int kl, int ku, float[] ab,
            int ldab, int[] ipiv);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgbtrs(Layout layout, TransChar trans, int n,
            int kl, int ku, int nrhs,
            float[] ab, int ldab,
            int[] ipiv, float[] b, int ldb);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgbtrs_work(Layout layout, TransChar trans, int n,
            int kl, int ku, int nrhs,
            float[] ab, int ldab,
            int[] ipiv, float[] b,
            int ldb);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgebak(Layout layout, char job, char side, int n,
            int ilo, int ihi, float[] scale,
            int m, float[] v, int ldv);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgebak_work(Layout layout, char job, char side,
            int n, int ilo, int ihi,
            float[] scale, int m, float[] v,
            int ldv);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgebal(Layout layout, char job, int n, float[] a,
            int lda, int[] ilo, int[] ihi,
            float[] scale);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgebal_work(Layout layout, char job, int n,
            float[] a, int lda, int[] ilo,
            int[] ihi, float[] scale);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgebrd(Layout layout, int m, int n,
            float[] a, int lda, float[] d, float[] e,
            float[] tauq, float[] taup);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgebrd_work(Layout layout, int m, int n,
            float[] a, int lda, float[] d, float[] e,
            float[] tauq, float[] taup, float[] work,
            int lwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgecon(Layout layout, Norm norm, int n,
            float[] a, int lda, float anorm,
            float[] rcond);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgecon_work(Layout layout, Norm norm, int n,
            float[] a, int lda, float anorm,
            float[] rcond, float[] work, int[] iwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgeequ(Layout layout, int m, int n,
            float[] a, int lda, float[] r, float[] c,
            float[] rowcnd, float[] colcnd, float[] amax);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgeequ_work(Layout layout, int m, int n,
            float[] a, int lda, float[] r,
            float[] c, float[] rowcnd, float[] colcnd,
            float[] amax);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgeequb(Layout layout, int m, int n,
            float[] a, int lda, float[] r, float[] c,
            float[] rowcnd, float[] colcnd, float[] amax);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgeequb_work(Layout layout, int m, int n,
            float[] a, int lda, float[] r,
            float[] c, float[] rowcnd, float[] colcnd,
            float[] amax);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgeev(Layout layout, char jobvl, char jobvr,
            int n, float[] a, int lda, float[] wr,
            float[] wi, float[] vl, int ldvl, float[] vr,
            int ldvr);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgeev_work(Layout layout, char jobvl, char jobvr,
            int n, float[] a, int lda,
            float[] wr, float[] wi, float[] vl, int ldvl,
            float[] vr, int ldvr, float[] work,
            int lwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgeevx(Layout layout, char balanc, char jobvl,
            char jobvr, char sense, int n, float[] a,
            int lda, float[] wr, float[] wi, float[] vl,
            int ldvl, float[] vr, int ldvr,
            int[] ilo, int[] ihi, float[] scale,
            float[] abnrm, float[] rconde, float[] rcondv);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgeevx_work(Layout layout, char balanc, char jobvl,
            char jobvr, char sense, int n, float[] a,
            int lda, float[] wr, float[] wi, float[] vl,
            int ldvl, float[] vr, int ldvr,
            int[] ilo, int[] ihi, float[] scale,
            float[] abnrm, float[] rconde, float[] rcondv,
            float[] work, int lwork,
            int[] iwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgehrd(Layout layout, int n, int ilo,
            int ihi, float[] a, int lda,
            float[] tau);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgehrd_work(Layout layout, int n, int ilo,
            int ihi, float[] a, int lda,
            float[] tau, float[] work, int lwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgejsv(Layout layout, char joba, char jobu, char jobv,
            char jobr, char jobt, char jobp, int m,
            int n, float[] a, int lda, float[] sva,
            float[] u, int ldu, float[] v, int ldv,
            float[] stat, int[] istat);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgejsv_work(Layout layout, char joba, char jobu,
            char jobv, char jobr, char jobt, char jobp,
            int m, int n, float[] a,
            int lda, float[] sva, float[] u,
            int ldu, float[] v, int ldv,
            float[] work, int lwork,
            int[] iwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgelq2(Layout layout, int m, int n,
            float[] a, int lda, float[] tau);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgelq2_work(Layout layout, int m, int n,
            float[] a, int lda, float[] tau,
            float[] work);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgelqf(Layout layout, int m, int n,
            float[] a, int lda, float[] tau);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgelqf_work(Layout layout, int m, int n,
            float[] a, int lda, float[] tau,
            float[] work, int lwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgels(Layout layout, TransChar trans, int m,
            int n, int nrhs, float[] a,
            int lda, float[] b, int ldb);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgels_work(Layout layout, TransChar trans, int m,
            int n, int nrhs, float[] a,
            int lda, float[] b, int ldb,
            float[] work, int lwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgelsd(Layout layout, int m, int n,
            int nrhs, float[] a, int lda, float[] b,
            int ldb, float[] s, float rcond,
            int[] rank);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgelsd_work(Layout layout, int m, int n,
            int nrhs, float[] a, int lda,
            float[] b, int ldb, float[] s, float rcond,
            int[] rank, float[] work, int lwork,
            int[] iwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgelss(Layout layout, int m, int n,
            int nrhs, float[] a, int lda, float[] b,
            int ldb, float[] s, float rcond,
            int[] rank);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgelss_work(Layout layout, int m, int n,
            int nrhs, float[] a, int lda,
            float[] b, int ldb, float[] s, float rcond,
            int[] rank, float[] work,
            int lwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgelsy(Layout layout, int m, int n,
            int nrhs, float[] a, int lda, float[] b,
            int ldb, int[] jpvt, float rcond,
            int[] rank);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgelsy_work(Layout layout, int m, int n,
            int nrhs, float[] a, int lda,
            float[] b, int ldb, int[] jpvt,
            float rcond, int[] rank, float[] work,
            int lwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgemqrt(Layout layout, char side, TransChar trans,
            int m, int n, int k,
            int nb, float[] v, int ldv,
            float[] t, int ldt, float[] c,
            int ldc);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgemqrt_work(Layout layout, char side, TransChar trans,
            int m, int n, int k,
            int nb, float[] v, int ldv,
            float[] t, int ldt, float[] c,
            int ldc, float[] work);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgeqlf(Layout layout, int m, int n,
            float[] a, int lda, float[] tau);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgeqlf_work(Layout layout, int m, int n,
            float[] a, int lda, float[] tau,
            float[] work, int lwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgeqp3(Layout layout, int m, int n,
            float[] a, int lda, int[] jpvt,
            float[] tau);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgeqp3_work(Layout layout, int m, int n,
            float[] a, int lda, int[] jpvt,
            float[] tau, float[] work, int lwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgeqpf(Layout layout, int m, int n,
            float[] a, int lda, int[] jpvt,
            float[] tau);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgeqpf_work(Layout layout, int m, int n,
            float[] a, int lda, int[] jpvt,
            float[] tau, float[] work);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgeqr2(Layout layout, int m, int n,
            float[] a, int lda, float[] tau);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgeqr2_work(Layout layout, int m, int n,
            float[] a, int lda, float[] tau,
            float[] work);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgeqrf(Layout layout, int m, int n,
            float[] a, int lda, float[] tau);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgeqrf_work(Layout layout, int m, int n,
            float[] a, int lda, float[] tau,
            float[] work, int lwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgeqrfp(Layout layout, int m, int n,
            float[] a, int lda, float[] tau);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgeqrfp_work(Layout layout, int m, int n,
            float[] a, int lda, float[] tau,
            float[] work, int lwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgeqrt(Layout layout, int m, int n,
            int nb, float[] a, int lda, float[] t,
            int ldt);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgeqrt2(Layout layout, int m, int n,
            float[] a, int lda, float[] t, int ldt);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgeqrt2_work(Layout layout, int m, int n,
            float[] a, int lda, float[] t,
            int ldt);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgeqrt3(Layout layout, int m, int n,
            float[] a, int lda, float[] t, int ldt);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgeqrt3_work(Layout layout, int m, int n,
            float[] a, int lda, float[] t,
            int ldt);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgeqrt_work(Layout layout, int m, int n,
            int nb, float[] a, int lda,
            float[] t, int ldt, float[] work);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgerfs(Layout layout, TransChar trans, int n,
            int nrhs, float[] a, int lda,
            float[] af, int ldaf,
            int[] ipiv, float[] b,
            int ldb, float[] x, int ldx,
            float[] ferr, float[] berr);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgerfs_work(Layout layout, TransChar trans, int n,
            int nrhs, float[] a, int lda,
            float[] af, int ldaf,
            int[] ipiv, float[] b,
            int ldb, float[] x, int ldx,
            float[] ferr, float[] berr, float[] work,
            int[] iwork);
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
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgerqf(Layout layout, int m, int n,
            float[] a, int lda, float[] tau);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgerqf_work(Layout layout, int m, int n,
            float[] a, int lda, float[] tau,
            float[] work, int lwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgesdd(Layout layout, char jobz, int m,
            int n, float[] a, int lda, float[] s,
            float[] u, int ldu, float[] vt,
            int ldvt);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgesdd_work(Layout layout, char jobz, int m,
            int n, float[] a, int lda,
            float[] s, float[] u, int ldu, float[] vt,
            int ldvt, float[] work, int lwork,
            int[] iwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgesv(Layout layout, int n, int nrhs,
            float[] a, int lda, int[] ipiv, float[] b,
            int ldb);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgesv_work(Layout layout, int n, int nrhs,
            float[] a, int lda, int[] ipiv,
            float[] b, int ldb);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgesvd(Layout layout, char jobu, char jobvt,
            int m, int n, float[] a, int lda,
            float[] s, float[] u, int ldu, float[] vt,
            int ldvt, float[] superb);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgesvd_work(Layout layout, char jobu, char jobvt,
            int m, int n, float[] a,
            int lda, float[] s, float[] u,
            int ldu, float[] vt, int ldvt,
            float[] work, int lwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgesvdx(Layout layout, char jobu, char jobvt, char range,
            int m, int n, float[] a,
            int lda, float vl, float vu,
            int il, int iu, int[] ns,
            float[] s, float[] u, int ldu,
            float[] vt, int ldvt,
            int[] superb);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgesvdx_work(Layout layout, char jobu, char jobvt, char range,
            int m, int n, float[] a,
            int lda, float vl, float vu,
            int il, int iu, int[] ns,
            float[] s, float[] u, int ldu,
            float[] vt, int ldvt,
            float[] work, int lwork, int[] iwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgesvj(Layout layout, char joba, char jobu, char jobv,
            int m, int n, float[] a, int lda,
            float[] sva, int mv, float[] v, int ldv,
            float[] stat);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgesvj_work(Layout layout, char joba, char jobu,
            char jobv, int m, int n, float[] a,
            int lda, float[] sva, int mv,
            float[] v, int ldv, float[] work,
            int lwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgesvx(Layout layout, char fact, TransChar trans,
            int n, int nrhs, float[] a,
            int lda, float[] af, int ldaf,
            int[] ipiv, char[] equed, float[] r, float[] c,
            float[] b, int ldb, float[] x, int ldx,
            float[] rcond, float[] ferr, float[] berr,
            float[] rpivot);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgesvx_work(Layout layout, char fact, TransChar trans,
            int n, int nrhs, float[] a,
            int lda, float[] af, int ldaf,
            int[] ipiv, char[] equed, float[] r,
            float[] c, float[] b, int ldb, float[] x,
            int ldx, float[] rcond, float[] ferr,
            float[] berr, float[] work, int[] iwork);
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
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgetf2(Layout layout, int m, int n,
            float[] a, int lda, int[] ipiv);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgetf2_work(Layout layout, int m, int n,
            float[] a, int lda, int[] ipiv);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgetrf(Layout layout, int m, int n,
            float[] a, int lda, int[] ipiv);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgetrf2(Layout layout, int m, int n,
            float[] a, int lda, int[] ipiv);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgetrf2_work(Layout layout, int m, int n,
            float[] a, int lda, int[] ipiv);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgetrf_work(Layout layout, int m, int n,
            float[] a, int lda, int[] ipiv);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgetri(Layout layout, int n, float[] a,
            int lda, int[] ipiv);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgetri_work(Layout layout, int n, float[] a,
            int lda, int[] ipiv,
            float[] work, int lwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgetrs(Layout layout, TransChar trans, int n,
            int nrhs, float[] a, int lda,
            int[] ipiv, float[] b, int ldb);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgetrs_work(Layout layout, TransChar trans, int n,
            int nrhs, float[] a, int lda,
            int[] ipiv, float[] b,
            int ldb);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sggbak(Layout layout, char job, char side, int n,
            int ilo, int ihi, float[] lscale,
            float[] rscale, int m, float[] v,
            int ldv);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sggbak_work(Layout layout, char job, char side,
            int n, int ilo, int ihi,
            float[] lscale, float[] rscale,
            int m, float[] v, int ldv);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sggbal(Layout layout, char job, int n, float[] a,
            int lda, float[] b, int ldb,
            int[] ilo, int[] ihi, float[] lscale,
            float[] rscale);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sggbal_work(Layout layout, char job, int n,
            float[] a, int lda, float[] b,
            int ldb, int[] ilo,
            int[] ihi, float[] lscale, float[] rscale,
            float[] work);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sggev(Layout layout, char jobvl, char jobvr,
            int n, float[] a, int lda, float[] b,
            int ldb, float[] alphar, float[] alphai,
            float[] beta, float[] vl, int ldvl, float[] vr,
            int ldvr);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sggev3(Layout layout, char jobvl, char jobvr,
            int n, float[] a, int lda, float[] b,
            int ldb, float[] alphar, float[] alphai,
            float[] beta, float[] vl, int ldvl, float[] vr,
            int ldvr);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sggev3_work(Layout layout,
            char jobvl, char jobvr, int n,
            float[] a, int lda,
            float[] b, int ldb,
            float[] alphar, float[] alphai, float[] beta,
            float[] vl, int ldvl,
            float[] vr, int ldvr,
            float[] work, int lwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sggev_work(Layout layout, char jobvl, char jobvr,
            int n, float[] a, int lda, float[] b,
            int ldb, float[] alphar, float[] alphai,
            float[] beta, float[] vl, int ldvl,
            float[] vr, int ldvr, float[] work,
            int lwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sggevx(Layout layout, char balanc, char jobvl,
            char jobvr, char sense, int n, float[] a,
            int lda, float[] b, int ldb,
            float[] alphar, float[] alphai, float[] beta, float[] vl,
            int ldvl, float[] vr, int ldvr,
            int[] ilo, int[] ihi, float[] lscale,
            float[] rscale, float[] abnrm, float[] bbnrm,
            float[] rconde, float[] rcondv);
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
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sggglm(Layout layout, int n, int m,
            int p, float[] a, int lda, float[] b,
            int ldb, float[] d, float[] x, float[] y);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sggglm_work(Layout layout, int n, int m,
            int p, float[] a, int lda,
            float[] b, int ldb, float[] d, float[] x,
            float[] y, float[] work, int lwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgghd3(Layout layout, char compq, char compz,
            int n, int ilo, int ihi,
            float[] a, int lda, float[] b, int ldb,
            float[] q, int ldq, float[] z, int ldz);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgghd3_work(Layout layout, char compq, char compz,
            int n, int ilo, int ihi,
            float[] a, int lda, float[] b,
            int ldb, float[] q, int ldq,
            float[] z, int ldz, float[] work,
            int lwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgghrd(Layout layout, char compq, char compz,
            int n, int ilo, int ihi,
            float[] a, int lda, float[] b, int ldb,
            float[] q, int ldq, float[] z, int ldz);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgghrd_work(Layout layout, char compq, char compz,
            int n, int ilo, int ihi,
            float[] a, int lda, float[] b,
            int ldb, float[] q, int ldq,
            float[] z, int ldz);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgglse(Layout layout, int m, int n,
            int p, float[] a, int lda, float[] b,
            int ldb, float[] c, float[] d, float[] x);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgglse_work(Layout layout, int m, int n,
            int p, float[] a, int lda,
            float[] b, int ldb, float[] c, float[] d,
            float[] x, float[] work, int lwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sggqrf(Layout layout, int n, int m,
            int p, float[] a, int lda, float[] taua,
            float[] b, int ldb, float[] taub);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sggqrf_work(Layout layout, int n, int m,
            int p, float[] a, int lda,
            float[] taua, float[] b, int ldb,
            float[] taub, float[] work, int lwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sggrqf(Layout layout, int m, int p,
            int n, float[] a, int lda, float[] taua,
            float[] b, int ldb, float[] taub);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sggrqf_work(Layout layout, int m, int p,
            int n, float[] a, int lda,
            float[] taua, float[] b, int ldb,
            float[] taub, float[] work, int lwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sggsvd(Layout layout, char jobu, char jobv, char jobq,
            int m, int n, int p,
            int[] k, int[] l, float[] a,
            int lda, float[] b, int ldb,
            float[] alpha, float[] beta, float[] u, int ldu,
            float[] v, int ldv, float[] q, int ldq,
            int[] iwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sggsvd3(Layout layout, char jobu, char jobv, char jobq,
            int m, int n, int p,
            int[] k, int[] l, float[] a,
            int lda, float[] b, int ldb,
            float[] alpha, float[] beta, float[] u, int ldu,
            float[] v, int ldv, float[] q, int ldq,
            int[] iwork);
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
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sggsvd_work(Layout layout, char jobu, char jobv,
            char jobq, int m, int n,
            int p, int[] k, int[] l,
            float[] a, int lda, float[] b,
            int ldb, float[] alpha, float[] beta,
            float[] u, int ldu, float[] v,
            int ldv, float[] q, int ldq,
            float[] work, int[] iwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sggsvp(Layout layout, char jobu, char jobv, char jobq,
            int m, int p, int n, float[] a,
            int lda, float[] b, int ldb, float tola,
            float tolb, int[] k, int[] l, float[] u,
            int ldu, float[] v, int ldv, float[] q,
            int ldq);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sggsvp3(Layout layout, char jobu, char jobv, char jobq,
            int m, int p, int n, float[] a,
            int lda, float[] b, int ldb, float tola,
            float tolb, int[] k, int[] l, float[] u,
            int ldu, float[] v, int ldv, float[] q,
            int ldq);
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
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sggsvp_work(Layout layout, char jobu, char jobv,
            char jobq, int m, int p,
            int n, float[] a, int lda,
            float[] b, int ldb, float tola,
            float tolb, int[] k, int[] l,
            float[] u, int ldu, float[] v,
            int ldv, float[] q, int ldq,
            int[] iwork, float[] tau, float[] work);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgtcon(Norm norm, int n, float[] dl,
            float[] d, float[] du, float[] du2,
            int[] ipiv, float anorm, float[] rcond);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgtcon_work(Norm norm, int n, float[] dl,
            float[] d, float[] du,
            float[] du2, int[] ipiv,
            float anorm, float[] rcond, float[] work,
            int[] iwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgtrfs(Layout layout, TransChar trans, int n,
            int nrhs, float[] dl, float[] d,
            float[] du, float[] dlf, float[] df,
            float[] duf, float[] du2,
            int[] ipiv, float[] b,
            int ldb, float[] x, int ldx,
            float[] ferr, float[] berr);
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
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgtsv(Layout layout, int n, int nrhs,
            float[] dl, float[] d, float[] du, float[] b,
            int ldb);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgtsv_work(Layout layout, int n, int nrhs,
            float[] dl, float[] d, float[] du, float[] b,
            int ldb);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgtsvx(Layout layout, char fact, TransChar trans,
            int n, int nrhs, float[] dl,
            float[] d, float[] du, float[] dlf,
            float[] df, float[] duf, float[] du2, int[] ipiv,
            float[] b, int ldb, float[] x,
            int ldx, float[] rcond, float[] ferr,
            float[] berr);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgtsvx_work(Layout layout, char fact, TransChar trans,
            int n, int nrhs, float[] dl,
            float[] d, float[] du, float[] dlf,
            float[] df, float[] duf, float[] du2,
            int[] ipiv, float[] b,
            int ldb, float[] x, int ldx,
            float[] rcond, float[] ferr, float[] berr,
            float[] work, int[] iwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgttrf(int n, float[] dl, float[] d, float[] du,
            float[] du2, int[] ipiv);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgttrf_work(int n, float[] dl, float[] d, float[] du,
            float[] du2, int[] ipiv);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgttrs(Layout layout, TransChar trans, int n,
            int nrhs, float[] dl, float[] d,
            float[] du, float[] du2,
            int[] ipiv, float[] b, int ldb);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgttrs_work(Layout layout, TransChar trans, int n,
            int nrhs, float[] dl,
            float[] d, float[] du,
            float[] du2, int[] ipiv,
            float[] b, int ldb);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_shgeqz(Layout layout, char job, char compq, char compz,
            int n, int ilo, int ihi,
            float[] h, int ldh, float[] t, int ldt,
            float[] alphar, float[] alphai, float[] beta, float[] q,
            int ldq, float[] z, int ldz);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_shgeqz_work(Layout layout, char job, char compq,
            char compz, int n, int ilo,
            int ihi, float[] h, int ldh,
            float[] t, int ldt, float[] alphar,
            float[] alphai, float[] beta, float[] q,
            int ldq, float[] z, int ldz,
            float[] work, int lwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_shsein(Layout layout, char job, char eigsrc, char initv,
            int[] select, int n, float[] h,
            int ldh, float[] wr, float[] wi,
            float[] vl, int ldvl, float[] vr,
            int ldvr, int mm, int[] m,
            int[] ifaill, int[] ifailr);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_shsein_work(Layout layout, char job, char eigsrc,
            char initv, int[] select,
            int n, float[] h, int ldh,
            float[] wr, float[] wi, float[] vl,
            int ldvl, float[] vr, int ldvr,
            int mm, int[] m, float[] work,
            int[] ifaill, int[] ifailr);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_shseqr(Layout layout, char job, char compz, int n,
            int ilo, int ihi, float[] h,
            int ldh, float[] wr, float[] wi, float[] z,
            int ldz);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_shseqr_work(Layout layout, char job, char compz,
            int n, int ilo, int ihi,
            float[] h, int ldh, float[] wr, float[] wi,
            float[] z, int ldz, float[] work,
            int lwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_slacn2(int n, float[] v, float[] x, int[] isgn,
            float[] est, int[] kase, int[] isave);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_slacn2_work(int n, float[] v, float[] x,
            int[] isgn, float[] est, int[] kase,
            int[] isave);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_slacpy(Layout layout, UpLo uplo, int m,
            int n, float[] a, int lda,
            float[] b, int ldb);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_slacpy_work(Layout layout, UpLo uplo, int m,
            int n, float[] a, int lda,
            float[] b, int ldb);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_slag2d(Layout layout, int m, int n,
            float[] sa, int ldsa, double[] a,
            int lda);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_slag2d_work(Layout layout, int m, int n,
            float[] sa, int ldsa, double[] a,
            int lda);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_slagge(Layout layout, int m, int n,
            int kl, int ku, float[] d,
            float[] a, int lda, int[] iseed);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_slagge_work(Layout layout, int m, int n,
            int kl, int ku, float[] d,
            float[] a, int lda, int[] iseed,
            float[] work);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_slagsy(Layout layout, int n, int k,
            float[] d, float[] a, int lda,
            int[] iseed);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_slagsy_work(Layout layout, int n, int k,
            float[] d, float[] a, int lda,
            int[] iseed, float[] work);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_slapmr(Layout layout, int forwrd,
            int m, int n, float[] x, int ldx,
            int[] k);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_slapmr_work(Layout layout, int forwrd,
            int m, int n, float[] x,
            int ldx, int[] k);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_slapmt(Layout layout, int forwrd,
            int m, int n, float[] x, int ldx,
            int[] k);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_slapmt_work(Layout layout, int forwrd,
            int m, int n, float[] x,
            int ldx, int[] k);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_slarfb(Layout layout, char side, TransChar trans, char direct,
            char storev, int m, int n,
            int k, float[] v, int ldv,
            float[] t, int ldt, float[] c,
            int ldc);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_slarfb_work(Layout layout, char side, TransChar trans,
            char direct, char storev, int m,
            int n, int k, float[] v,
            int ldv, float[] t, int ldt,
            float[] c, int ldc, float[] work,
            int ldwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_slarfg(int n, float[] alpha, float[] x,
            int incx, float[] tau);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_slarfg_work(int n, float[] alpha, float[] x,
            int incx, float[] tau);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_slarft(Layout layout, char direct, char storev,
            int n, int k, float[] v,
            int ldv, float[] tau, float[] t,
            int ldt);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_slarft_work(Layout layout, char direct, char storev,
            int n, int k, float[] v,
            int ldv, float[] tau, float[] t,
            int ldt);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_slarfx(Layout layout, char side, int m,
            int n, float[] v, float tau, float[] c,
            int ldc, float[] work);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_slarfx_work(Layout layout, char side, int m,
            int n, float[] v, float tau,
            float[] c, int ldc, float[] work);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_slarnv(int idist, int[] iseed, int n,
            float[] x);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_slarnv_work(int idist, int[] iseed,
            int n, float[] x);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_slartgp(float f, float g, float[] cs, float[] sn, float[] r);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_slartgp_work(float f, float g, float[] cs, float[] sn,
            float[] r);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_slartgs(float x, float y, float sigma, float[] cs,
            float[] sn);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_slartgs_work(float x, float y, float sigma, float[] cs,
            float[] sn);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_slascl(Layout layout, char type, int kl,
            int ku, float cfrom, float cto,
            int m, int n, float[] a,
            int lda);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_slascl_work(Layout layout, char type, int kl,
            int ku, float cfrom, float cto,
            int m, int n, float[] a,
            int lda);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_slaset(Layout layout, UpLo uplo, int m,
            int n, float alpha, float beta, float[] a,
            int lda);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_slaset_work(Layout layout, UpLo uplo, int m,
            int n, float alpha, float beta, float[] a,
            int lda);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_slasrt(char id, int n, float[] d);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_slasrt_work(char id, int n, float[] d);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_slaswp(Layout layout, int n, float[] a,
            int lda, int k1, int k2,
            int[] ipiv, int incx);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_slaswp_work(Layout layout, int n, float[] a,
            int lda, int k1, int k2,
            int[] ipiv, int incx);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_slatms(Layout layout, int m, int n,
            char dist, int[] iseed, char sym, float[] d,
            int mode, float cond, float dmax,
            int kl, int ku, char pack, float[] a,
            int lda);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_slatms_work(Layout layout, int m, int n,
            char dist, int[] iseed, char sym,
            float[] d, int mode, float cond,
            float dmax, int kl, int ku,
            char pack, float[] a, int lda,
            float[] work);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_slauum(Layout layout, UpLo uplo, int n, float[] a,
            int lda);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_slauum_work(Layout layout, UpLo uplo, int n,
            float[] a, int lda);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sopgtr(Layout layout, UpLo uplo, int n,
            float[] ap, float[] tau, float[] q,
            int ldq);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sopgtr_work(Layout layout, UpLo uplo, int n,
            float[] ap, float[] tau, float[] q,
            int ldq, float[] work);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sopmtr(Layout layout, char side, UpLo uplo, TransChar trans,
            int m, int n, float[] ap,
            float[] tau, float[] c, int ldc);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sopmtr_work(Layout layout, char side, UpLo uplo,
            TransChar trans, int m, int n,
            float[] ap, float[] tau, float[] c,
            int ldc, float[] work);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sorbdb(Layout layout, TransChar trans, char signs,
            int m, int p, int q, float[] x11,
            int ldx11, float[] x12, int ldx12,
            float[] x21, int ldx21, float[] x22,
            int ldx22, float[] theta, float[] phi,
            float[] taup1, float[] taup2, float[] tauq1,
            float[] tauq2);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sorbdb_work(Layout layout, TransChar trans, char signs,
            int m, int p, int q,
            float[] x11, int ldx11, float[] x12,
            int ldx12, float[] x21, int ldx21,
            float[] x22, int ldx22, float[] theta,
            float[] phi, float[] taup1, float[] taup2,
            float[] tauq1, float[] tauq2, float[] work,
            int lwork);
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
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sorcsd2by1(Layout layout, char jobu1, char jobu2,
            char jobv1t, int m, int p, int q,
            float[] x11, int ldx11, float[] x21, int ldx21,
            float[] theta, float[] u1, int ldu1, float[] u2,
            int ldu2, float[] v1t, int ldv1t);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sorcsd2by1_work(Layout layout, char jobu1, char jobu2,
            char jobv1t, int m, int p,
            int q, float[] x11, int ldx11,
            float[] x21, int ldx21,
            float[] theta, float[] u1, int ldu1,
            float[] u2, int ldu2, float[] v1t,
            int ldv1t, float[] work, int lwork,
            int[] iwork);
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
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sorgbr(Layout layout, char vect, int m,
            int n, int k, float[] a, int lda,
            float[] tau);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sorgbr_work(Layout layout, char vect, int m,
            int n, int k, float[] a,
            int lda, float[] tau, float[] work,
            int lwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sorghr(Layout layout, int n, int ilo,
            int ihi, float[] a, int lda,
            float[] tau);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sorghr_work(Layout layout, int n, int ilo,
            int ihi, float[] a, int lda,
            float[] tau, float[] work,
            int lwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sorglq(Layout layout, int m, int n,
            int k, float[] a, int lda,
            float[] tau);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sorglq_work(Layout layout, int m, int n,
            int k, float[] a, int lda,
            float[] tau, float[] work,
            int lwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sorgql(Layout layout, int m, int n,
            int k, float[] a, int lda,
            float[] tau);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sorgql_work(Layout layout, int m, int n,
            int k, float[] a, int lda,
            float[] tau, float[] work,
            int lwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sorgqr(Layout layout, int m, int n,
            int k, float[] a, int lda,
            float[] tau);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sorgqr_work(Layout layout, int m, int n,
            int k, float[] a, int lda,
            float[] tau, float[] work,
            int lwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sorgrq(Layout layout, int m, int n,
            int k, float[] a, int lda,
            float[] tau);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sorgrq_work(Layout layout, int m, int n,
            int k, float[] a, int lda,
            float[] tau, float[] work,
            int lwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sorgtr(Layout layout, UpLo uplo, int n, float[] a,
            int lda, float[] tau);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sorgtr_work(Layout layout, UpLo uplo, int n,
            float[] a, int lda, float[] tau,
            float[] work, int lwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sormbr(Layout layout, char vect, char side, TransChar trans,
            int m, int n, int k,
            float[] a, int lda, float[] tau,
            float[] c, int ldc);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sormbr_work(Layout layout, char vect, char side,
            TransChar trans, int m, int n,
            int k, float[] a, int lda,
            float[] tau, float[] c, int ldc,
            float[] work, int lwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sormhr(Layout layout, char side, TransChar trans,
            int m, int n, int ilo,
            int ihi, float[] a, int lda,
            float[] tau, float[] c, int ldc);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sormhr_work(Layout layout, char side, TransChar trans,
            int m, int n, int ilo,
            int ihi, float[] a, int lda,
            float[] tau, float[] c, int ldc,
            float[] work, int lwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sormlq(Layout layout, char side, TransChar trans,
            int m, int n, int k,
            float[] a, int lda, float[] tau,
            float[] c, int ldc);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sormlq_work(Layout layout, char side, TransChar trans,
            int m, int n, int k,
            float[] a, int lda,
            float[] tau, float[] c, int ldc,
            float[] work, int lwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sormql(Layout layout, char side, TransChar trans,
            int m, int n, int k,
            float[] a, int lda, float[] tau,
            float[] c, int ldc);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sormql_work(Layout layout, char side, TransChar trans,
            int m, int n, int k,
            float[] a, int lda,
            float[] tau, float[] c, int ldc,
            float[] work, int lwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sormqr(Layout layout, char side, TransChar trans,
            int m, int n, int k,
            float[] a, int lda, float[] tau,
            float[] c, int ldc);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sormqr_work(Layout layout, char side, TransChar trans,
            int m, int n, int k,
            float[] a, int lda,
            float[] tau, float[] c, int ldc,
            float[] work, int lwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sormrq(Layout layout, char side, TransChar trans,
            int m, int n, int k,
            float[] a, int lda, float[] tau,
            float[] c, int ldc);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sormrq_work(Layout layout, char side, TransChar trans,
            int m, int n, int k,
            float[] a, int lda,
            float[] tau, float[] c, int ldc,
            float[] work, int lwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sormrz(Layout layout, char side, TransChar trans,
            int m, int n, int k,
            int l, float[] a, int lda,
            float[] tau, float[] c, int ldc);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sormrz_work(Layout layout, char side, TransChar trans,
            int m, int n, int k,
            int l, float[] a, int lda,
            float[] tau, float[] c, int ldc,
            float[] work, int lwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sormtr(Layout layout, char side, UpLo uplo, TransChar trans,
            int m, int n, float[] a,
            int lda, float[] tau, float[] c,
            int ldc);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sormtr_work(Layout layout, char side, UpLo uplo,
            TransChar trans, int m, int n,
            float[] a, int lda,
            float[] tau, float[] c, int ldc,
            float[] work, int lwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_spbcon(Layout layout, UpLo uplo, int n,
            int kd, float[] ab, int ldab,
            float anorm, float[] rcond);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_spbcon_work(Layout layout, UpLo uplo, int n,
            int kd, float[] ab, int ldab,
            float anorm, float[] rcond, float[] work,
            int[] iwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_spbequ(Layout layout, UpLo uplo, int n,
            int kd, float[] ab, int ldab,
            float[] s, float[] scond, float[] amax);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_spbequ_work(Layout layout, UpLo uplo, int n,
            int kd, float[] ab, int ldab,
            float[] s, float[] scond, float[] amax);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_spbrfs(Layout layout, UpLo uplo, int n,
            int kd, int nrhs, float[] ab,
            int ldab, float[] afb, int ldafb,
            float[] b, int ldb, float[] x,
            int ldx, float[] ferr, float[] berr);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_spbrfs_work(Layout layout, UpLo uplo, int n,
            int kd, int nrhs, float[] ab,
            int ldab, float[] afb,
            int ldafb, float[] b,
            int ldb, float[] x, int ldx,
            float[] ferr, float[] berr, float[] work,
            int[] iwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_spbstf(Layout layout, UpLo uplo, int n,
            int kb, float[] bb, int ldbb);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_spbstf_work(Layout layout, UpLo uplo, int n,
            int kb, float[] bb, int ldbb);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_spbsv(Layout layout, UpLo uplo, int n,
            int kd, int nrhs, float[] ab,
            int ldab, float[] b, int ldb);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_spbsv_work(Layout layout, UpLo uplo, int n,
            int kd, int nrhs, float[] ab,
            int ldab, float[] b, int ldb);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_spbsvx(Layout layout, char fact, UpLo uplo, int n,
            int kd, int nrhs, float[] ab,
            int ldab, float[] afb, int ldafb,
            char[] equed, float[] s, float[] b, int ldb,
            float[] x, int ldx, float[] rcond, float[] ferr,
            float[] berr);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_spbsvx_work(Layout layout, char fact, UpLo uplo,
            int n, int kd, int nrhs,
            float[] ab, int ldab, float[] afb,
            int ldafb, char[] equed, float[] s,
            float[] b, int ldb, float[] x,
            int ldx, float[] rcond, float[] ferr,
            float[] berr, float[] work, int[] iwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_spbtrf(Layout layout, UpLo uplo, int n,
            int kd, float[] ab, int ldab);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_spbtrf_work(Layout layout, UpLo uplo, int n,
            int kd, float[] ab, int ldab);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_spbtrs(Layout layout, UpLo uplo, int n,
            int kd, int nrhs, float[] ab,
            int ldab, float[] b, int ldb);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_spbtrs_work(Layout layout, UpLo uplo, int n,
            int kd, int nrhs, float[] ab,
            int ldab, float[] b, int ldb);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_spftrf(Layout layout, TransChar transr, UpLo uplo,
            int n, float[] a);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_spftrf_work(Layout layout, TransChar transr, UpLo uplo,
            int n, float[] a);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_spftri(Layout layout, TransChar transr, UpLo uplo,
            int n, float[] a);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_spftri_work(Layout layout, TransChar transr, UpLo uplo,
            int n, float[] a);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_spftrs(Layout layout, TransChar transr, UpLo uplo,
            int n, int nrhs, float[] a,
            float[] b, int ldb);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_spftrs_work(Layout layout, TransChar transr, UpLo uplo,
            int n, int nrhs, float[] a,
            float[] b, int ldb);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_spocon(Layout layout, UpLo uplo, int n,
            float[] a, int lda, float anorm,
            float[] rcond);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_spocon_work(Layout layout, UpLo uplo, int n,
            float[] a, int lda, float anorm,
            float[] rcond, float[] work, int[] iwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_spoequ(Layout layout, int n, float[] a,
            int lda, float[] s, float[] scond, float[] amax);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_spoequ_work(Layout layout, int n, float[] a,
            int lda, float[] s, float[] scond,
            float[] amax);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_spoequb(Layout layout, int n, float[] a,
            int lda, float[] s, float[] scond,
            float[] amax);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_spoequb_work(Layout layout, int n,
            float[] a, int lda, float[] s,
            float[] scond, float[] amax);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sporfs(Layout layout, UpLo uplo, int n,
            int nrhs, float[] a, int lda,
            float[] af, int ldaf, float[] b,
            int ldb, float[] x, int ldx,
            float[] ferr, float[] berr);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sporfs_work(Layout layout, UpLo uplo, int n,
            int nrhs, float[] a,
            int lda, float[] af,
            int ldaf, float[] b,
            int ldb, float[] x, int ldx,
            float[] ferr, float[] berr, float[] work,
            int[] iwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sporfsx(Layout layout, UpLo uplo, char equed,
            int n, int nrhs, float[] a,
            int lda, float[] af, int ldaf,
            float[] s, float[] b, int ldb,
            float[] x, int ldx, float[] rcond, float[] berr,
            int n_err_bnds, float[] err_bnds_norm,
            float[] err_bnds_comp, int nparams,
            float[] aparams);
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
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sposv(Layout layout, UpLo uplo, int n,
            int nrhs, float[] a, int lda, float[] b,
            int ldb);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sposv_work(Layout layout, UpLo uplo, int n,
            int nrhs, float[] a, int lda,
            float[] b, int ldb);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sposvx(Layout layout, char fact, UpLo uplo, int n,
            int nrhs, float[] a, int lda, float[] af,
            int ldaf, char[] equed, float[] s, float[] b,
            int ldb, float[] x, int ldx,
            float[] rcond, float[] ferr, float[] berr);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sposvx_work(Layout layout, char fact, UpLo uplo,
            int n, int nrhs, float[] a,
            int lda, float[] af, int ldaf,
            char[] equed, float[] s, float[] b,
            int ldb, float[] x, int ldx,
            float[] rcond, float[] ferr, float[] berr,
            float[] work, int[] iwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sposvxx(Layout layout, char fact, UpLo uplo,
            int n, int nrhs, float[] a,
            int lda, float[] af, int ldaf,
            char[] equed, float[] s, float[] b, int ldb,
            float[] x, int ldx, float[] rcond,
            float[] rpvgrw, float[] berr, int n_err_bnds,
            float[] err_bnds_norm, float[] err_bnds_comp,
            int nparams, float[] aparams);
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
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_spotrf(Layout layout, UpLo uplo, int n, float[] a,
            int lda);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_spotrf2(Layout layout, UpLo uplo, int n, float[] a,
            int lda);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_spotrf2_work(Layout layout, UpLo uplo, int n,
            float[] a, int lda);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_spotrf_work(Layout layout, UpLo uplo, int n,
            float[] a, int lda);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_spotri(Layout layout, UpLo uplo, int n, float[] a,
            int lda);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_spotri_work(Layout layout, UpLo uplo, int n,
            float[] a, int lda);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_spotrs(Layout layout, UpLo uplo, int n,
            int nrhs, float[] a, int lda,
            float[] b, int ldb);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_spotrs_work(Layout layout, UpLo uplo, int n,
            int nrhs, float[] a,
            int lda, float[] b, int ldb);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sppcon(Layout layout, UpLo uplo, int n,
            float[] ap, float anorm, float[] rcond);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sppcon_work(Layout layout, UpLo uplo, int n,
            float[] ap, float anorm, float[] rcond,
            float[] work, int[] iwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sppequ(Layout layout, UpLo uplo, int n,
            float[] ap, float[] s, float[] scond,
            float[] amax);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sppequ_work(Layout layout, UpLo uplo, int n,
            float[] ap, float[] s, float[] scond,
            float[] amax);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_spprfs(Layout layout, UpLo uplo, int n,
            int nrhs, float[] ap, float[] afp,
            float[] b, int ldb, float[] x,
            int ldx, float[] ferr, float[] berr);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_spprfs_work(Layout layout, UpLo uplo, int n,
            int nrhs, float[] ap,
            float[] afp, float[] b,
            int ldb, float[] x, int ldx,
            float[] ferr, float[] berr, float[] work,
            int[] iwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sppsv(Layout layout, UpLo uplo, int n,
            int nrhs, float[] ap, float[] b, int ldb);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sppsv_work(Layout layout, UpLo uplo, int n,
            int nrhs, float[] ap, float[] b,
            int ldb);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sppsvx(Layout layout, char fact, UpLo uplo, int n,
            int nrhs, float[] ap, float[] afp, char[] equed,
            float[] s, float[] b, int ldb, float[] x,
            int ldx, float[] rcond, float[] ferr,
            float[] berr);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sppsvx_work(Layout layout, char fact, UpLo uplo,
            int n, int nrhs, float[] ap,
            float[] afp, char[] equed, float[] s, float[] b,
            int ldb, float[] x, int ldx,
            float[] rcond, float[] ferr, float[] berr,
            float[] work, int[] iwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_spptrf(Layout layout, UpLo uplo, int n,
            float[] ap);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_spptrf_work(Layout layout, UpLo uplo, int n,
            float[] ap);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_spptri(Layout layout, UpLo uplo, int n,
            float[] ap);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_spptri_work(Layout layout, UpLo uplo, int n,
            float[] ap);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_spptrs(Layout layout, UpLo uplo, int n,
            int nrhs, float[] ap, float[] b,
            int ldb);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_spptrs_work(Layout layout, UpLo uplo, int n,
            int nrhs, float[] ap, float[] b,
            int ldb);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_spstrf(Layout layout, UpLo uplo, int n, float[] a,
            int lda, int[] piv, int[] rank,
            float tol);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_spstrf_work(Layout layout, UpLo uplo, int n,
            float[] a, int lda, int[] piv,
            int[] rank, float tol, float[] work);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sptcon(int n, float[] d, float[] e,
            float anorm, float[] rcond);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sptcon_work(int n, float[] d, float[] e,
            float anorm, float[] rcond, float[] work);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_spteqr(Layout layout, char compz, int n, float[] d,
            float[] e, float[] z, int ldz);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_spteqr_work(Layout layout, char compz, int n,
            float[] d, float[] e, float[] z, int ldz,
            float[] work);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sptrfs(Layout layout, int n, int nrhs,
            float[] d, float[] e, float[] df,
            float[] ef, float[] b, int ldb,
            float[] x, int ldx, float[] ferr, float[] berr);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sptrfs_work(Layout layout, int n, int nrhs,
            float[] d, float[] e, float[] df,
            float[] ef, float[] b, int ldb,
            float[] x, int ldx, float[] ferr,
            float[] berr, float[] work);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sptsv(Layout layout, int n, int nrhs,
            float[] d, float[] e, float[] b, int ldb);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sptsv_work(Layout layout, int n, int nrhs,
            float[] d, float[] e, float[] b, int ldb);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sptsvx(Layout layout, char fact, int n,
            int nrhs, float[] d, float[] e,
            float[] df, float[] ef, float[] b, int ldb,
            float[] x, int ldx, float[] rcond, float[] ferr,
            float[] berr);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sptsvx_work(Layout layout, char fact, int n,
            int nrhs, float[] d, float[] e,
            float[] df, float[] ef, float[] b,
            int ldb, float[] x, int ldx,
            float[] rcond, float[] ferr, float[] berr,
            float[] work);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_spttrf(int n, float[] d, float[] e);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_spttrf_work(int n, float[] d, float[] e);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_spttrs(Layout layout, int n, int nrhs,
            float[] d, float[] e, float[] b,
            int ldb);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_spttrs_work(Layout layout, int n, int nrhs,
            float[] d, float[] e, float[] b,
            int ldb);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssbev(Layout layout, char jobz, UpLo uplo, int n,
            int kd, float[] ab, int ldab, float[] w,
            float[] z, int ldz);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssbev_work(Layout layout, char jobz, UpLo uplo,
            int n, int kd, float[] ab,
            int ldab, float[] w, float[] z,
            int ldz, float[] work);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssbevd(Layout layout, char jobz, UpLo uplo, int n,
            int kd, float[] ab, int ldab, float[] w,
            float[] z, int ldz);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssbevd_work(Layout layout, char jobz, UpLo uplo,
            int n, int kd, float[] ab,
            int ldab, float[] w, float[] z,
            int ldz, float[] work, int lwork,
            int[] iwork, int liwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssbevx(Layout layout, char jobz, char range, UpLo uplo,
            int n, int kd, float[] ab,
            int ldab, float[] q, int ldq, float vl,
            float vu, int il, int iu, float abstol,
            int[] m, float[] w, float[] z, int ldz,
            int[] ifail);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssbevx_work(Layout layout, char jobz, char range,
            UpLo uplo, int n, int kd,
            float[] ab, int ldab, float[] q,
            int ldq, float vl, float vu,
            int il, int iu, float abstol,
            int[] m, float[] w, float[] z,
            int ldz, float[] work, int[] iwork,
            int[] ifail);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssbgst(Layout layout, char vect, UpLo uplo, int n,
            int ka, int kb, float[] ab,
            int ldab, float[] bb, int ldbb,
            float[] x, int ldx);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssbgst_work(Layout layout, char vect, UpLo uplo,
            int n, int ka, int kb,
            float[] ab, int ldab, float[] bb,
            int ldbb, float[] x, int ldx,
            float[] work);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssbgv(Layout layout, char jobz, UpLo uplo, int n,
            int ka, int kb, float[] ab,
            int ldab, float[] bb, int ldbb, float[] w,
            float[] z, int ldz);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssbgv_work(Layout layout, char jobz, UpLo uplo,
            int n, int ka, int kb,
            float[] ab, int ldab, float[] bb,
            int ldbb, float[] w, float[] z,
            int ldz, float[] work);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssbgvd(Layout layout, char jobz, UpLo uplo, int n,
            int ka, int kb, float[] ab,
            int ldab, float[] bb, int ldbb,
            float[] w, float[] z, int ldz);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssbgvd_work(Layout layout, char jobz, UpLo uplo,
            int n, int ka, int kb,
            float[] ab, int ldab, float[] bb,
            int ldbb, float[] w, float[] z,
            int ldz, float[] work, int lwork,
            int[] iwork, int liwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssbgvx(Layout layout, char jobz, char range, UpLo uplo,
            int n, int ka, int kb,
            float[] ab, int ldab, float[] bb,
            int ldbb, float[] q, int ldq, float vl,
            float vu, int il, int iu, float abstol,
            int[] m, float[] w, float[] z, int ldz,
            int[] ifail);
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
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssbtrd(Layout layout, char vect, UpLo uplo, int n,
            int kd, float[] ab, int ldab, float[] d,
            float[] e, float[] q, int ldq);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssbtrd_work(Layout layout, char vect, UpLo uplo,
            int n, int kd, float[] ab,
            int ldab, float[] d, float[] e, float[] q,
            int ldq, float[] work);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssfrk(Layout layout, TransChar transr, UpLo uplo, TransChar trans,
            int n, int k, float alpha,
            float[] a, int lda, float beta, float[] c);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssfrk_work(Layout layout, TransChar transr, UpLo uplo,
            TransChar trans, int n, int k,
            float alpha, float[] a, int lda,
            float beta, float[] c);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sspcon(Layout layout, UpLo uplo, int n,
            float[] ap, int[] ipiv, float anorm,
            float[] rcond);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sspcon_work(Layout layout, UpLo uplo, int n,
            float[] ap, int[] ipiv,
            float anorm, float[] rcond, float[] work,
            int[] iwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sspev(Layout layout, char jobz, UpLo uplo, int n,
            float[] ap, float[] w, float[] z, int ldz);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sspev_work(Layout layout, char jobz, UpLo uplo,
            int n, float[] ap, float[] w, float[] z,
            int ldz, float[] work);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sspevd(Layout layout, char jobz, UpLo uplo, int n,
            float[] ap, float[] w, float[] z, int ldz);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sspevd_work(Layout layout, char jobz, UpLo uplo,
            int n, float[] ap, float[] w, float[] z,
            int ldz, float[] work, int lwork,
            int[] iwork, int liwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sspevx(Layout layout, char jobz, char range, UpLo uplo,
            int n, float[] ap, float vl, float vu,
            int il, int iu, float abstol,
            int[] m, float[] w, float[] z, int ldz,
            int[] ifail);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sspevx_work(Layout layout, char jobz, char range,
            UpLo uplo, int n, float[] ap, float vl,
            float vu, int il, int iu,
            float abstol, int[] m, float[] w, float[] z,
            int ldz, float[] work, int[] iwork,
            int[] ifail);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sspgst(Layout layout, int itype, UpLo uplo,
            int n, float[] ap, float[] bp);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sspgst_work(Layout layout, int itype, UpLo uplo,
            int n, float[] ap, float[] bp);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sspgv(Layout layout, int itype, char jobz,
            UpLo uplo, int n, float[] ap, float[] bp,
            float[] w, float[] z, int ldz);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sspgv_work(Layout layout, int itype, char jobz,
            UpLo uplo, int n, float[] ap, float[] bp,
            float[] w, float[] z, int ldz, float[] work);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sspgvd(Layout layout, int itype, char jobz,
            UpLo uplo, int n, float[] ap, float[] bp,
            float[] w, float[] z, int ldz);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sspgvd_work(Layout layout, int itype, char jobz,
            UpLo uplo, int n, float[] ap, float[] bp,
            float[] w, float[] z, int ldz, float[] work,
            int lwork, int[] iwork,
            int liwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sspgvx(Layout layout, int itype, char jobz,
            char range, UpLo uplo, int n, float[] ap,
            float[] bp, float vl, float vu, int il,
            int iu, float abstol, int[] m, float[] w,
            float[] z, int ldz, int[] ifail);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sspgvx_work(Layout layout, int itype, char jobz,
            char range, UpLo uplo, int n, float[] ap,
            float[] bp, float vl, float vu, int il,
            int iu, float abstol, int[] m,
            float[] w, float[] z, int ldz, float[] work,
            int[] iwork, int[] ifail);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssprfs(Layout layout, UpLo uplo, int n,
            int nrhs, float[] ap, float[] afp,
            int[] ipiv, float[] b,
            int ldb, float[] x, int ldx,
            float[] ferr, float[] berr);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssprfs_work(Layout layout, UpLo uplo, int n,
            int nrhs, float[] ap,
            float[] afp, int[] ipiv,
            float[] b, int ldb, float[] x,
            int ldx, float[] ferr, float[] berr,
            float[] work, int[] iwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sspsv(Layout layout, UpLo uplo, int n,
            int nrhs, float[] ap, int[] ipiv,
            float[] b, int ldb);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sspsv_work(Layout layout, UpLo uplo, int n,
            int nrhs, float[] ap, int[] ipiv,
            float[] b, int ldb);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sspsvx(Layout layout, char fact, UpLo uplo, int n,
            int nrhs, float[] ap, float[] afp,
            int[] ipiv, float[] b, int ldb,
            float[] x, int ldx, float[] rcond, float[] ferr,
            float[] berr);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sspsvx_work(Layout layout, char fact, UpLo uplo,
            int n, int nrhs, float[] ap,
            float[] afp, int[] ipiv, float[] b,
            int ldb, float[] x, int ldx,
            float[] rcond, float[] ferr, float[] berr,
            float[] work, int[] iwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssptrd(Layout layout, UpLo uplo, int n, float[] ap,
            float[] d, float[] e, float[] tau);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssptrd_work(Layout layout, UpLo uplo, int n,
            float[] ap, float[] d, float[] e, float[] tau);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssptrf(Layout layout, UpLo uplo, int n, float[] ap,
            int[] ipiv);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssptrf_work(Layout layout, UpLo uplo, int n,
            float[] ap, int[] ipiv);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssptri(Layout layout, UpLo uplo, int n, float[] ap,
            int[] ipiv);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssptri_work(Layout layout, UpLo uplo, int n,
            float[] ap, int[] ipiv, float[] work);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssptrs(Layout layout, UpLo uplo, int n,
            int nrhs, float[] ap,
            int[] ipiv, float[] b, int ldb);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssptrs_work(Layout layout, UpLo uplo, int n,
            int nrhs, float[] ap,
            int[] ipiv, float[] b,
            int ldb);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sstebz(char range, char order, int n, float vl,
            float vu, int il, int iu, float abstol,
            float[] d, float[] e, int[] m,
            int[] nsplit, float[] w, int[] iblock,
            int[] isplit);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sstebz_work(char range, char order, int n, float vl,
            float vu, int il, int iu,
            float abstol, float[] d, float[] e,
            int[] m, int[] nsplit, float[] w,
            int[] iblock, int[] isplit,
            float[] work, int[] iwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sstedc(Layout layout, char compz, int n, float[] d,
            float[] e, float[] z, int ldz);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sstedc_work(Layout layout, char compz, int n,
            float[] d, float[] e, float[] z, int ldz,
            float[] work, int lwork,
            int[] iwork, int liwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sstegr(Layout layout, char jobz, char range,
            int n, float[] d, float[] e, float vl, float vu,
            int il, int iu, float abstol,
            int[] m, float[] w, float[] z, int ldz,
            int[] isuppz);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sstegr_work(Layout layout, char jobz, char range,
            int n, float[] d, float[] e, float vl,
            float vu, int il, int iu,
            float abstol, int[] m, float[] w, float[] z,
            int ldz, int[] isuppz, float[] work,
            int lwork, int[] iwork,
            int liwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sstein(Layout layout, int n, float[] d,
            float[] e, int m, float[] w,
            int[] iblock, int[] isplit,
            float[] z, int ldz, int[] ifailv);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sstein_work(Layout layout, int n, float[] d,
            float[] e, int m, float[] w,
            int[] iblock,
            int[] isplit, float[] z,
            int ldz, float[] work, int[] iwork,
            int[] ifailv);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sstemr(Layout layout, char jobz, char range,
            int n, float[] d, float[] e, float vl, float vu,
            int il, int iu, int[] m,
            float[] w, float[] z, int ldz, int nzc,
            int[] isuppz, int[] tryrac);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sstemr_work(Layout layout, char jobz, char range,
            int n, float[] d, float[] e, float vl,
            float vu, int il, int iu,
            int[] m, float[] w, float[] z,
            int ldz, int nzc,
            int[] isuppz, int[] tryrac,
            float[] work, int lwork,
            int[] iwork, int liwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssteqr(Layout layout, char compz, int n, float[] d,
            float[] e, float[] z, int ldz);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssteqr_work(Layout layout, char compz, int n,
            float[] d, float[] e, float[] z, int ldz,
            float[] work);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssterf(int n, float[] d, float[] e);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssterf_work(int n, float[] d, float[] e);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sstev(Layout layout, char jobz, int n, float[] d,
            float[] e, float[] z, int ldz);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sstev_work(Layout layout, char jobz, int n,
            float[] d, float[] e, float[] z, int ldz,
            float[] work);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sstevd(Layout layout, char jobz, int n, float[] d,
            float[] e, float[] z, int ldz);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sstevd_work(Layout layout, char jobz, int n,
            float[] d, float[] e, float[] z, int ldz,
            float[] work, int lwork,
            int[] iwork, int liwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sstevr(Layout layout, char jobz, char range,
            int n, float[] d, float[] e, float vl, float vu,
            int il, int iu, float abstol,
            int[] m, float[] w, float[] z, int ldz,
            int[] isuppz);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sstevr_work(Layout layout, char jobz, char range,
            int n, float[] d, float[] e, float vl,
            float vu, int il, int iu,
            float abstol, int[] m, float[] w, float[] z,
            int ldz, int[] isuppz, float[] work,
            int lwork, int[] iwork,
            int liwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sstevx(Layout layout, char jobz, char range,
            int n, float[] d, float[] e, float vl, float vu,
            int il, int iu, float abstol,
            int[] m, float[] w, float[] z, int ldz,
            int[] ifail);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sstevx_work(Layout layout, char jobz, char range,
            int n, float[] d, float[] e, float vl,
            float vu, int il, int iu,
            float abstol, int[] m, float[] w, float[] z,
            int ldz, float[] work, int[] iwork,
            int[] ifail);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssycon(Layout layout, UpLo uplo, int n,
            float[] a, int lda,
            int[] ipiv, float anorm, float[] rcond);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssycon_work(Layout layout, UpLo uplo, int n,
            float[] a, int lda,
            int[] ipiv, float anorm,
            float[] rcond, float[] work, int[] iwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssyconv(Layout layout, UpLo uplo, char way, int n,
            float[] a, int lda, int[] ipiv,
            float[] e);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssyconv_work(Layout layout, UpLo uplo, char way,
            int n, float[] a, int lda,
            int[] ipiv, float[] e);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssyequb(Layout layout, UpLo uplo, int n,
            float[] a, int lda, float[] s,
            float[] scond, float[] amax);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssyequb_work(Layout layout, UpLo uplo, int n,
            float[] a, int lda, float[] s,
            float[] scond, float[] amax, float[] work);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssyev(Layout layout, char jobz, UpLo uplo, int n,
            float[] a, int lda, float[] w);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssyev_work(Layout layout, char jobz, UpLo uplo,
            int n, float[] a, int lda, float[] w,
            float[] work, int lwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssyevd(Layout layout, char jobz, UpLo uplo, int n,
            float[] a, int lda, float[] w);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssyevd_work(Layout layout, char jobz, UpLo uplo,
            int n, float[] a, int lda,
            float[] w, float[] work, int lwork,
            int[] iwork, int liwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssyevr(Layout layout, char jobz, char range, UpLo uplo,
            int n, float[] a, int lda, float vl,
            float vu, int il, int iu, float abstol,
            int[] m, float[] w, float[] z, int ldz,
            int[] isuppz);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssyevr_work(Layout layout, char jobz, char range,
            UpLo uplo, int n, float[] a,
            int lda, float vl, float vu,
            int il, int iu, float abstol,
            int[] m, float[] w, float[] z,
            int ldz, int[] isuppz, float[] work,
            int lwork, int[] iwork,
            int liwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssyevx(Layout layout, char jobz, char range, UpLo uplo,
            int n, float[] a, int lda, float vl,
            float vu, int il, int iu, float abstol,
            int[] m, float[] w, float[] z, int ldz,
            int[] ifail);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssyevx_work(Layout layout, char jobz, char range,
            UpLo uplo, int n, float[] a,
            int lda, float vl, float vu,
            int il, int iu, float abstol,
            int[] m, float[] w, float[] z,
            int ldz, float[] work, int lwork,
            int[] iwork, int[] ifail);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssygst(Layout layout, int itype, UpLo uplo,
            int n, float[] a, int lda,
            float[] b, int ldb);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssygst_work(Layout layout, int itype, UpLo uplo,
            int n, float[] a, int lda,
            float[] b, int ldb);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssygv(Layout layout, int itype, char jobz,
            UpLo uplo, int n, float[] a, int lda,
            float[] b, int ldb, float[] w);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssygv_work(Layout layout, int itype, char jobz,
            UpLo uplo, int n, float[] a,
            int lda, float[] b, int ldb,
            float[] w, float[] work, int lwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssygvd(Layout layout, int itype, char jobz,
            UpLo uplo, int n, float[] a, int lda,
            float[] b, int ldb, float[] w);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssygvd_work(Layout layout, int itype, char jobz,
            UpLo uplo, int n, float[] a,
            int lda, float[] b, int ldb,
            float[] w, float[] work, int lwork,
            int[] iwork, int liwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssygvx(Layout layout, int itype, char jobz,
            char range, UpLo uplo, int n, float[] a,
            int lda, float[] b, int ldb, float vl,
            float vu, int il, int iu, float abstol,
            int[] m, float[] w, float[] z, int ldz,
            int[] ifail);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssygvx_work(Layout layout, int itype, char jobz,
            char range, UpLo uplo, int n, float[] a,
            int lda, float[] b, int ldb,
            float vl, float vu, int il,
            int iu, float abstol, int[] m,
            float[] w, float[] z, int ldz, float[] work,
            int lwork, int[] iwork,
            int[] ifail);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssyrfs(Layout layout, UpLo uplo, int n,
            int nrhs, float[] a, int lda,
            float[] af, int ldaf,
            int[] ipiv, float[] b,
            int ldb, float[] x, int ldx,
            float[] ferr, float[] berr);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssyrfs_work(Layout layout, UpLo uplo, int n,
            int nrhs, float[] a, int lda,
            float[] af, int ldaf,
            int[] ipiv, float[] b,
            int ldb, float[] x, int ldx,
            float[] ferr, float[] berr, float[] work,
            int[] iwork);
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
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssysv(Layout layout, UpLo uplo, int n,
            int nrhs, float[] a, int lda,
            int[] ipiv, float[] b, int ldb);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssysv_rook(Layout layout, UpLo uplo, int n,
            int nrhs, float[] a, int lda,
            int[] ipiv, float[] b, int ldb);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssysv_rook_work(Layout layout, UpLo uplo, int n,
            int nrhs, float[] a, int lda,
            int[] ipiv, float[] b, int ldb,
            float[] work, int lwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssysv_work(Layout layout, UpLo uplo, int n,
            int nrhs, float[] a, int lda,
            int[] ipiv, float[] b, int ldb,
            float[] work, int lwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssysvx(Layout layout, char fact, UpLo uplo, int n,
            int nrhs, float[] a, int lda,
            float[] af, int ldaf, int[] ipiv,
            float[] b, int ldb, float[] x,
            int ldx, float[] rcond, float[] ferr,
            float[] berr);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssysvx_work(Layout layout, char fact, UpLo uplo,
            int n, int nrhs, float[] a,
            int lda, float[] af, int ldaf,
            int[] ipiv, float[] b,
            int ldb, float[] x, int ldx,
            float[] rcond, float[] ferr, float[] berr,
            float[] work, int lwork,
            int[] iwork);
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
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssyswapr(Layout layout, UpLo uplo, int n,
            float[] a, int lda, int i1, int i2);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssyswapr_work(Layout layout, UpLo uplo, int n,
            float[] a, int lda,
            int i1, int i2);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssytrd(Layout layout, UpLo uplo, int n, float[] a,
            int lda, float[] d, float[] e, float[] tau);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssytrd_work(Layout layout, UpLo uplo, int n,
            float[] a, int lda, float[] d, float[] e,
            float[] tau, float[] work, int lwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssytrf(Layout layout, UpLo uplo, int n, float[] a,
            int lda, int[] ipiv);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssytrf_rook(Layout layout, UpLo uplo, int n, float[] a,
            int lda, int[] ipiv);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssytrf_rook_work(Layout layout, UpLo uplo, int n,
            float[] a, int lda, int[] ipiv,
            float[] work, int lwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssytrf_work(Layout layout, UpLo uplo, int n,
            float[] a, int lda, int[] ipiv,
            float[] work, int lwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssytri(Layout layout, UpLo uplo, int n, float[] a,
            int lda, int[] ipiv);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssytri2(Layout layout, UpLo uplo, int n, float[] a,
            int lda, int[] ipiv);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssytri2_work(Layout layout, UpLo uplo, int n,
            float[] a, int lda,
            int[] ipiv,
            float[] work, int lwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssytri2x(Layout layout, UpLo uplo, int n,
            float[] a, int lda, int[] ipiv,
            int nb);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssytri2x_work(Layout layout, UpLo uplo, int n,
            float[] a, int lda,
            int[] ipiv, float[] work,
            int nb);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssytri_work(Layout layout, UpLo uplo, int n,
            float[] a, int lda,
            int[] ipiv, float[] work);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssytrs(Layout layout, UpLo uplo, int n,
            int nrhs, float[] a, int lda,
            int[] ipiv, float[] b, int ldb);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssytrs2(Layout layout, UpLo uplo, int n,
            int nrhs, float[] a, int lda,
            int[] ipiv, float[] b, int ldb);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssytrs2_work(Layout layout, UpLo uplo, int n,
            int nrhs, float[] a,
            int lda, int[] ipiv,
            float[] b, int ldb, float[] work);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssytrs_rook(Layout layout, UpLo uplo, int n,
            int nrhs, float[] a, int lda,
            int[] ipiv, float[] b, int ldb);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssytrs_rook_work(Layout layout, UpLo uplo, int n,
            int nrhs, float[] a, int lda,
            int[] ipiv, float[] b,
            int ldb);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssytrs_work(Layout layout, UpLo uplo, int n,
            int nrhs, float[] a, int lda,
            int[] ipiv, float[] b,
            int ldb);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_stbcon(Layout layout, Norm norm, UpLo uplo, DiagChar diag,
            int n, int kd, float[] ab,
            int ldab, float[] rcond);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_stbcon_work(Layout layout, Norm norm, UpLo uplo,
            DiagChar diag, int n, int kd,
            float[] ab, int ldab, float[] rcond,
            float[] work, int[] iwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_stbrfs(Layout layout, UpLo uplo, TransChar trans, DiagChar diag,
            int n, int kd, int nrhs,
            float[] ab, int ldab, float[] b,
            int ldb, float[] x, int ldx,
            float[] ferr, float[] berr);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_stbrfs_work(Layout layout, UpLo uplo, TransChar trans,
            DiagChar diag, int n, int kd,
            int nrhs, float[] ab,
            int ldab, float[] b, int ldb,
            float[] x, int ldx, float[] ferr,
            float[] berr, float[] work, int[] iwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_stbtrs(Layout layout, UpLo uplo, TransChar trans, DiagChar diag,
            int n, int kd, int nrhs,
            float[] ab, int ldab, float[] b,
            int ldb);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_stbtrs_work(Layout layout, UpLo uplo, TransChar trans,
            DiagChar diag, int n, int kd,
            int nrhs, float[] ab,
            int ldab, float[] b, int ldb);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_stfsm(Layout layout, TransChar transr, char side, UpLo uplo,
            TransChar trans, DiagChar diag, int m, int n,
            float alpha, float[] a, float[] b,
            int ldb);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_stfsm_work(Layout layout, TransChar transr, char side,
            UpLo uplo, TransChar trans, DiagChar diag, int m,
            int n, float alpha, float[] a,
            float[] b, int ldb);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_stftri(Layout layout, TransChar transr, UpLo uplo, DiagChar diag,
            int n, float[] a);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_stftri_work(Layout layout, TransChar transr, UpLo uplo,
            DiagChar diag, int n, float[] a);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_stfttp(Layout layout, TransChar transr, UpLo uplo,
            int n, float[] arf, float[] ap);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_stfttp_work(Layout layout, TransChar transr, UpLo uplo,
            int n, float[] arf, float[] ap);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_stfttr(Layout layout, TransChar transr, UpLo uplo,
            int n, float[] arf, float[] a,
            int lda);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_stfttr_work(Layout layout, TransChar transr, UpLo uplo,
            int n, float[] arf, float[] a,
            int lda);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_stgevc(Layout layout, char side, char howmny,
            int[] select, int n,
            float[] s, int lds, float[] p,
            int ldp, float[] vl, int ldvl,
            float[] vr, int ldvr, int mm,
            int[] m);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_stgevc_work(Layout layout, char side, char howmny,
            int[] select, int n,
            float[] s, int lds, float[] p,
            int ldp, float[] vl, int ldvl,
            float[] vr, int ldvr, int mm,
            int[] m, float[] work);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_stgexc(Layout layout, int wantq,
            int wantz, int n, float[] a,
            int lda, float[] b, int ldb, float[] q,
            int ldq, float[] z, int ldz,
            int[] ifst, int[] ilst);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_stgexc_work(Layout layout, int wantq,
            int wantz, int n, float[] a,
            int lda, float[] b, int ldb,
            float[] q, int ldq, float[] z,
            int ldz, int[] ifst,
            int[] ilst, float[] work,
            int lwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_stgsen(Layout layout, int ijob,
            int wantq, int wantz,
            int[] select, int n, float[] a,
            int lda, float[] b, int ldb,
            float[] alphar, float[] alphai, float[] beta, float[] q,
            int ldq, float[] z, int ldz,
            int[] m, float[] pl, float[] pr, float[] dif);
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
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_stgsja(Layout layout, char jobu, char jobv, char jobq,
            int m, int p, int n,
            int k, int l, float[] a, int lda,
            float[] b, int ldb, float tola, float tolb,
            float[] alpha, float[] beta, float[] u, int ldu,
            float[] v, int ldv, float[] q, int ldq,
            int[] ncycle);
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
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_stgsna(Layout layout, char job, char howmny,
            int[] select, int n,
            float[] a, int lda, float[] b,
            int ldb, float[] vl, int ldvl,
            float[] vr, int ldvr, float[] s,
            float[] dif, int mm, int[] m);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_stgsna_work(Layout layout, char job, char howmny,
            int[] select, int n,
            float[] a, int lda, float[] b,
            int ldb, float[] vl,
            int ldvl, float[] vr,
            int ldvr, float[] s, float[] dif,
            int mm, int[] m, float[] work,
            int lwork, int[] iwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_stgsyl(Layout layout, TransChar trans, int ijob,
            int m, int n, float[] a,
            int lda, float[] b, int ldb,
            float[] c, int ldc, float[] d,
            int ldd, float[] e, int lde,
            float[] f, int ldf, float[] scale, float[] dif);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_stgsyl_work(Layout layout, TransChar trans, int ijob,
            int m, int n, float[] a,
            int lda, float[] b, int ldb,
            float[] c, int ldc, float[] d,
            int ldd, float[] e, int lde,
            float[] f, int ldf, float[] scale,
            float[] dif, float[] work, int lwork,
            int[] iwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_stpcon(Layout layout, Norm norm, UpLo uplo, DiagChar diag,
            int n, float[] ap, float[] rcond);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_stpcon_work(Layout layout, Norm norm, UpLo uplo,
            DiagChar diag, int n, float[] ap,
            float[] rcond, float[] work, int[] iwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_stpmqrt(Layout layout, char side, TransChar trans,
            int m, int n, int k,
            int l, int nb, float[] v,
            int ldv, float[] t, int ldt,
            float[] a, int lda, float[] b, int ldb);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_stpmqrt_work(Layout layout, char side, TransChar trans,
            int m, int n, int k,
            int l, int nb, float[] v,
            int ldv, float[] t, int ldt,
            float[] a, int lda, float[] b,
            int ldb, float[] work);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_stpqrt(Layout layout, int m, int n,
            int l, int nb, float[] a,
            int lda, float[] b, int ldb, float[] t,
            int ldt);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_stpqrt2(Layout layout, int m, int n,
            int l,
            float[] a, int lda, float[] b, int ldb,
            float[] t, int ldt);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_stpqrt2_work(Layout layout, int m, int n,
            int l, float[] a, int lda, float[] b,
            int ldb, float[] t, int ldt);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_stpqrt_work(Layout layout, int m, int n,
            int l, int nb, float[] a,
            int lda, float[] b, int ldb,
            float[] t, int ldt, float[] work);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_stprfb(Layout layout, char side, TransChar trans, char direct,
            char storev, int m, int n,
            int k, int l, float[] v,
            int ldv, float[] t, int ldt,
            float[] a, int lda, float[] b, int ldb);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_stprfb_work(Layout layout, char side, TransChar trans,
            char direct, char storev, int m,
            int n, int k, int l,
            float[] v, int ldv, float[] t,
            int ldt, float[] a, int lda,
            float[] b, int ldb, float[] work,
            int ldwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_stprfs(Layout layout, UpLo uplo, TransChar trans, DiagChar diag,
            int n, int nrhs, float[] ap,
            float[] b, int ldb, float[] x,
            int ldx, float[] ferr, float[] berr);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_stprfs_work(Layout layout, UpLo uplo, TransChar trans,
            DiagChar diag, int n, int nrhs,
            float[] ap, float[] b, int ldb,
            float[] x, int ldx, float[] ferr,
            float[] berr, float[] work, int[] iwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_stptri(Layout layout, UpLo uplo, DiagChar diag, int n,
            float[] ap);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_stptri_work(Layout layout, UpLo uplo, DiagChar diag,
            int n, float[] ap);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_stptrs(Layout layout, UpLo uplo, TransChar trans, DiagChar diag,
            int n, int nrhs, float[] ap,
            float[] b, int ldb);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_stptrs_work(Layout layout, UpLo uplo, TransChar trans,
            DiagChar diag, int n, int nrhs,
            float[] ap, float[] b, int ldb);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_stpttf(Layout layout, TransChar transr, UpLo uplo,
            int n, float[] ap, float[] arf);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_stpttf_work(Layout layout, TransChar transr, UpLo uplo,
            int n, float[] ap, float[] arf);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_stpttr(Layout layout, UpLo uplo, int n,
            float[] ap, float[] a, int lda);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_stpttr_work(Layout layout, UpLo uplo, int n,
            float[] ap, float[] a, int lda);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_strcon(Layout layout, Norm norm, UpLo uplo, DiagChar diag,
            int n, float[] a, int lda,
            float[] rcond);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_strcon_work(Layout layout, Norm norm, UpLo uplo,
            DiagChar diag, int n, float[] a,
            int lda, float[] rcond, float[] work,
            int[] iwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_strevc(Layout layout, char side, char howmny,
            int[] select, int n, float[] t,
            int ldt, float[] vl, int ldvl,
            float[] vr, int ldvr, int mm,
            int[] m);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_strevc_work(Layout layout, char side, char howmny,
            int[] select, int n,
            float[] t, int ldt, float[] vl,
            int ldvl, float[] vr, int ldvr,
            int mm, int[] m, float[] work);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_strexc(Layout layout, char compq, int n, float[] t,
            int ldt, float[] q, int ldq,
            int[] ifst, int[] ilst);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_strexc_work(Layout layout, char compq, int n,
            float[] t, int ldt, float[] q,
            int ldq, int[] ifst,
            int[] ilst, float[] work);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_strrfs(Layout layout, UpLo uplo, TransChar trans, DiagChar diag,
            int n, int nrhs, float[] a,
            int lda, float[] b, int ldb,
            float[] x, int ldx, float[] ferr,
            float[] berr);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_strrfs_work(Layout layout, UpLo uplo, TransChar trans,
            DiagChar diag, int n, int nrhs,
            float[] a, int lda, float[] b,
            int ldb, float[] x, int ldx,
            float[] ferr, float[] berr, float[] work,
            int[] iwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_strsen(Layout layout, char job, char compq,
            int[] select, int n, float[] t,
            int ldt, float[] q, int ldq, float[] wr,
            float[] wi, int[] m, float[] s, float[] sep);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_strsen_work(Layout layout, char job, char compq,
            int[] select, int n,
            float[] t, int ldt, float[] q,
            int ldq, float[] wr, float[] wi,
            int[] m, float[] s, float[] sep,
            float[] work, int lwork,
            int[] iwork, int liwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_strsna(Layout layout, char job, char howmny,
            int[] select, int n,
            float[] t, int ldt, float[] vl,
            int ldvl, float[] vr, int ldvr,
            float[] s, float[] sep, int mm, int[] m);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_strsna_work(Layout layout, char job, char howmny,
            int[] select, int n,
            float[] t, int ldt, float[] vl,
            int ldvl, float[] vr,
            int ldvr, float[] s, float[] sep,
            int mm, int[] m, float[] work,
            int ldwork, int[] iwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_strsyl(Layout layout, char trana, char tranb,
            int isgn, int m, int n,
            float[] a, int lda, float[] b,
            int ldb, float[] c, int ldc,
            float[] scale);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_strsyl_work(Layout layout, char trana, char tranb,
            int isgn, int m, int n,
            float[] a, int lda, float[] b,
            int ldb, float[] c, int ldc,
            float[] scale);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_strtri(Layout layout, UpLo uplo, DiagChar diag, int n,
            float[] a, int lda);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_strtri_work(Layout layout, UpLo uplo, DiagChar diag,
            int n, float[] a, int lda);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_strtrs(Layout layout, UpLo uplo, TransChar trans, DiagChar diag,
            int n, int nrhs, float[] a,
            int lda, float[] b, int ldb);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_strtrs_work(Layout layout, UpLo uplo, TransChar trans,
            DiagChar diag, int n, int nrhs,
            float[] a, int lda, float[] b,
            int ldb);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_strttf(Layout layout, TransChar transr, UpLo uplo,
            int n, float[] a, int lda,
            float[] arf);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_strttf_work(Layout layout, TransChar transr, UpLo uplo,
            int n, float[] a, int lda,
            float[] arf);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_strttp(Layout layout, UpLo uplo, int n,
            float[] a, int lda, float[] ap);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_strttp_work(Layout layout, UpLo uplo, int n,
            float[] a, int lda, float[] ap);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_stzrzf(Layout layout, int m, int n,
            float[] a, int lda, float[] tau);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_stzrzf_work(Layout layout, int m, int n,
            float[] a, int lda, float[] tau,
            float[] work, int lwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsysv_aa(Layout layout, UpLo uplo, int n,
            int nrhs, double[] a, int lda,
            int[] ipiv, double[] b, int ldb);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsysv_aa_work(Layout layout, UpLo uplo, int n,
            int nrhs, double[] a, int lda,
            int[] ipiv, double[] b, int ldb,
            double[] work, int lwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsytrf_aa(Layout layout, UpLo uplo, int n,
            double[] a, int lda, int[] ipiv);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsytrf_aa_work(Layout layout, UpLo uplo, int n,
            double[] a, int lda, int[] ipiv,
            double[] work, int lwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsytrs_aa(Layout layout, UpLo uplo, int n,
            int nrhs, double[] a, int lda,
            int[] ipiv, double[] b,
            int ldb);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsytrs_aa_work(Layout layout, UpLo uplo, int n,
            int nrhs, double[] a,
            int lda, int[] ipiv,
            double[] b, int ldb, double[] work,
            int lwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssysv_aa(Layout layout, UpLo uplo, int n,
            int nrhs, float[] a, int lda,
            int[] ipiv, float[] b, int ldb);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssysv_aa_work(Layout layout, UpLo uplo, int n,
            int nrhs, float[] a, int lda,
            int[] ipiv, float[] b, int ldb,
            float[] work, int lwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssytrf_aa(Layout layout, UpLo uplo, int n,
            float[] a, int lda, int[] ipiv);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssytrf_aa_work(Layout layout, UpLo uplo, int n,
            float[] a, int lda, int[] ipiv,
            float[] work, int lwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssytrs_aa(Layout layout, UpLo uplo, int n,
            int nrhs, float[] a, int lda,
            int[] ipiv, float[] b,
            int ldb);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssytrs_aa_work(Layout layout, UpLo uplo, int n,
            int nrhs, float[] a,
            int lda, int[] ipiv,
            float[] b, int ldb, float[] work,
            int lwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgemqr(Layout layout, char side, TransChar trans,
            int m, int n, int k,
            double[] a, int lda,
            double[] t, int tsize, double[] c,
            int ldc);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgemqr_work(Layout layout, char side, TransChar trans,
            int m, int n, int k,
            double[] a, int lda,
            double[] t, int tsize,
            double[] c, int ldc, double[] work,
            int lwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgeqr(Layout layout, int m, int n,
            double[] a, int lda, double[] t,
            int tsize);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgeqr_work(Layout layout, int m, int n,
            double[] a, int lda, double[] t,
            int tsize, double[] work,
            int lwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgemqr(Layout layout, char side, TransChar trans,
            int m, int n, int k,
            float[] a, int lda, float[] t,
            int tsize, float[] c, int ldc);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgemqr_work(Layout layout, char side, TransChar trans,
            int m, int n, int k,
            float[] a, int lda,
            float[] t, int tsize,
            float[] c, int ldc, float[] work,
            int lwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgeqr(Layout layout, int m, int n,
            float[] a, int lda, float[] t,
            int tsize);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgeqr_work(Layout layout, int m, int n,
            float[] a, int lda, float[] t,
            int tsize, float[] work,
            int lwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgelq(Layout layout, int m, int n,
            double[] a, int lda, double[] t,
            int tsize);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgelq_work(Layout layout, int m, int n,
            double[] a, int lda, double[] t,
            int tsize, double[] work,
            int lwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgemlq(Layout layout, char side, TransChar trans,
            int m, int n, int k,
            double[] a, int lda, double[] t,
            int tsize, double[] c, int ldc);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgemlq_work(Layout layout, char side, TransChar trans,
            int m, int n, int k,
            double[] a, int lda,
            double[] t, int tsize, double[] c,
            int ldc, double[] work,
            int lwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgelq(Layout layout, int m, int n,
            float[] a, int lda, float[] t,
            int tsize);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgelq_work(Layout layout, int m, int n,
            float[] a, int lda, float[] t,
            int tsize, float[] work,
            int lwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgemlq(Layout layout, char side, TransChar trans,
            int m, int n, int k,
            float[] a, int lda, float[] t,
            int tsize, float[] c, int ldc);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgemlq_work(Layout layout, char side, TransChar trans,
            int m, int n, int k,
            float[] a, int lda, float[] t,
            int tsize, float[] c, int ldc,
            float[] work, int lwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgetsls(Layout layout, TransChar trans, int m,
            int n, int nrhs, double[] a,
            int lda, double[] b, int ldb);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dgetsls_work(Layout layout, TransChar trans, int m,
            int n, int nrhs, double[] a,
            int lda, double[] b, int ldb,
            double[] work, int lwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgetsls(Layout layout, TransChar trans, int m,
            int n, int nrhs, float[] a,
            int lda, float[] b, int ldb);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_sgetsls_work(Layout layout, TransChar trans, int m,
            int n, int nrhs, float[] a,
            int lda, float[] b, int ldb,
            float[] work, int lwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsycon_3(Layout layout, UpLo uplo, int n,
            double[] a, int lda, double[] e,
            int[] ipiv, double anorm,
            double[] rcond);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsycon_3_work(Layout layout, UpLo uplo, int n,
            double[] a, int lda,
            double[] e, int[] ipiv,
            double anorm, double[] rcond, double[] work,
            int[] iwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsysv_rk(Layout layout, UpLo uplo, int n,
            int nrhs, double[] a, int lda,
            double[] e, int[] ipiv, double[] b,
            int ldb);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsysv_rk_work(Layout layout, UpLo uplo, int n,
            int nrhs, double[] a, int lda,
            double[] e, int[] ipiv, double[] b,
            int ldb, double[] work,
            int lwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsytrf_rk(Layout layout, UpLo uplo, int n,
            double[] a, int lda, double[] e,
            int[] ipiv);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsytrf_rk_work(Layout layout, UpLo uplo, int n,
            double[] a, int lda, double[] e,
            int[] ipiv, double[] work,
            int lwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsytri_3(Layout layout, UpLo uplo, int n,
            double[] a, int lda, double[] e,
            int[] ipiv);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsytri_3_work(Layout layout, UpLo uplo, int n,
            double[] a, int lda, double[] e,
            int[] ipiv, double[] work,
            int lwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsytrs_3(Layout layout, UpLo uplo, int n,
            int nrhs, double[] a, int lda,
            double[] e, int[] ipiv,
            double[] b, int ldb);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsytrs_3_work(Layout layout, UpLo uplo, int n,
            int nrhs, double[] a,
            int lda, double[] e,
            int[] ipiv, double[] b,
            int ldb);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssycon_3(Layout layout, UpLo uplo, int n,
            float[] a, int lda, float[] e,
            int[] ipiv, float anorm,
            float[] rcond);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssycon_3_work(Layout layout, UpLo uplo, int n,
            float[] a, int lda,
            float[] e, int[] ipiv,
            float anorm, float[] rcond, float[] work,
            int[] iwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssysv_rk(Layout layout, UpLo uplo, int n,
            int nrhs, float[] a, int lda,
            float[] e, int[] ipiv, float[] b,
            int ldb);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssysv_rk_work(Layout layout, UpLo uplo, int n,
            int nrhs, float[] a, int lda,
            float[] e, int[] ipiv, float[] b,
            int ldb, float[] work,
            int lwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssytrf_rk(Layout layout, UpLo uplo, int n,
            float[] a, int lda, float[] e,
            int[] ipiv);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssytrf_rk_work(Layout layout, UpLo uplo, int n,
            float[] a, int lda, float[] e,
            int[] ipiv, float[] work,
            int lwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssytri_3(Layout layout, UpLo uplo, int n,
            float[] a, int lda, float[] e,
            int[] ipiv);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssytri_3_work(Layout layout, UpLo uplo, int n,
            float[] a, int lda, float[] e,
            int[] ipiv, float[] work,
            int lwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssytrs_3(Layout layout, UpLo uplo, int n,
            int nrhs, float[] a, int lda,
            float[] e, int[] ipiv, float[] b,
            int ldb);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssytrs_3_work(Layout layout, UpLo uplo, int n,
            int nrhs, float[] a,
            int lda, float[] e,
            int[] ipiv, float[] b,
            int ldb);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsbev_2stage(Layout layout, char jobz, UpLo uplo,
            int n, int kd, double[] ab,
            int ldab, double[] w, double[] z,
            int ldz);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsbev_2stage_work(Layout layout, char jobz, UpLo uplo,
            int n, int kd, double[] ab,
            int ldab, double[] w, double[] z,
            int ldz, double[] work,
            int lwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsbevd_2stage(Layout layout, char jobz, UpLo uplo,
            int n, int kd, double[] ab,
            int ldab, double[] w, double[] z,
            int ldz);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsbevd_2stage_work(Layout layout, char jobz, UpLo uplo,
            int n, int kd, double[] ab,
            int ldab, double[] w, double[] z,
            int ldz, double[] work,
            int lwork, int[] iwork,
            int liwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsbevx_2stage(Layout layout, char jobz, char range,
            UpLo uplo, int n, int kd,
            double[] ab, int ldab, double[] q,
            int ldq, double vl, double vu,
            int il, int iu, double abstol,
            int[] m, double[] w, double[] z,
            int ldz, int[] ifail);
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
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsyev_2stage(Layout layout, char jobz, UpLo uplo,
            int n, double[] a, int lda,
            double[] w);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsyev_2stage_work(Layout layout, char jobz, UpLo uplo,
            int n, double[] a, int lda,
            double[] w, double[] work,
            int lwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsyevd_2stage(Layout layout, char jobz, UpLo uplo,
            int n, double[] a, int lda,
            double[] w);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsyevd_2stage_work(Layout layout, char jobz, UpLo uplo,
            int n, double[] a, int lda,
            double[] w, double[] work,
            int lwork, int[] iwork,
            int liwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsyevr_2stage(Layout layout, char jobz, char range,
            UpLo uplo, int n, double[] a,
            int lda, double vl, double vu,
            int il, int iu, double abstol,
            int[] m, double[] w, double[] z,
            int ldz, int[] isuppz);
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
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsyevx_2stage(Layout layout, char jobz, char range,
            UpLo uplo, int n, double[] a,
            int lda, double vl, double vu,
            int il, int iu, double abstol,
            int[] m, double[] w, double[] z,
            int ldz, int[] ifail);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsyevx_2stage_work(Layout layout, char jobz,
            char range, UpLo uplo, int n,
            double[] a, int lda, double vl,
            double vu, int il, int iu,
            double abstol, int[] m, double[] w,
            double[] z, int ldz, double[] work,
            int lwork, int[] iwork,
            int[] ifail);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsygv_2stage(Layout layout, int itype,
            char jobz, UpLo uplo, int n, double[] a,
            int lda, double[] b, int ldb,
            double[] w);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsygv_2stage_work(Layout layout, int itype,
            char jobz, UpLo uplo, int n,
            double[] a, int lda, double[] b,
            int ldb, double[] w, double[] work,
            int lwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssbev_2stage(Layout layout, char jobz, UpLo uplo,
            int n, int kd, float[] ab,
            int ldab, float[] w, float[] z,
            int ldz);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssbev_2stage_work(Layout layout, char jobz, UpLo uplo,
            int n, int kd, float[] ab,
            int ldab, float[] w, float[] z,
            int ldz, float[] work,
            int lwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssbevd_2stage(Layout layout, char jobz, UpLo uplo,
            int n, int kd, float[] ab,
            int ldab, float[] w, float[] z,
            int ldz);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssbevd_2stage_work(Layout layout, char jobz, UpLo uplo,
            int n, int kd, float[] ab,
            int ldab, float[] w, float[] z,
            int ldz, float[] work,
            int lwork, int[] iwork,
            int liwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssbevx_2stage(Layout layout, char jobz, char range,
            UpLo uplo, int n, int kd,
            float[] ab, int ldab, float[] q,
            int ldq, float vl, float vu,
            int il, int iu, float abstol,
            int[] m, float[] w, float[] z,
            int ldz, int[] ifail);
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
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssyev_2stage(Layout layout, char jobz, UpLo uplo,
            int n, float[] a, int lda,
            float[] w);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssyev_2stage_work(Layout layout, char jobz, UpLo uplo,
            int n, float[] a, int lda,
            float[] w, float[] work, int lwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssyevd_2stage(Layout layout, char jobz, UpLo uplo,
            int n, float[] a, int lda,
            float[] w);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssyevd_2stage_work(Layout layout, char jobz, UpLo uplo,
            int n, float[] a, int lda,
            float[] w, float[] work, int lwork,
            int[] iwork, int liwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssyevr_2stage(Layout layout, char jobz, char range,
            UpLo uplo, int n, float[] a,
            int lda, float vl, float vu,
            int il, int iu, float abstol,
            int[] m, float[] w, float[] z,
            int ldz, int[] isuppz);
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
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssyevx_2stage(Layout layout, char jobz, char range,
            UpLo uplo, int n, float[] a,
            int lda, float vl, float vu,
            int il, int iu, float abstol,
            int[] m, float[] w, float[] z,
            int ldz, int[] ifail);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssyevx_2stage_work(Layout layout, char jobz,
            char range, UpLo uplo, int n,
            float[] a, int lda, float vl,
            float vu, int il, int iu,
            float abstol, int[] m, float[] w,
            float[] z, int ldz, float[] work,
            int lwork, int[] iwork,
            int[] ifail);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssygv_2stage(Layout layout, int itype,
            char jobz, UpLo uplo, int n, float[] a,
            int lda, float[] b, int ldb,
            float[] w);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssygv_2stage_work(Layout layout, int itype,
            char jobz, UpLo uplo, int n,
            float[] a, int lda, float[] b,
            int ldb, float[] w, float[] work,
            int lwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_mkl_dgetrfnp(Layout layout, int m, int n,
            double[] a, int lda);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_mkl_dgetrfnp_work(Layout layout, int m,
            int n, double[] a, int lda);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_mkl_sgetrfnp(Layout layout, int m, int n,
            float[] a, int lda);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_mkl_sgetrfnp_work(Layout layout, int m,
            int n, float[] a, int lda);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_mkl_dgetrinp(Layout layout, int n, double[] a,
            int lda);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_mkl_dgetrinp_work(Layout layout, int n,
            double[] a, int lda, double[] work,
            int lwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_mkl_sgetrinp(Layout layout, int n, float[] a,
            int lda);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_mkl_sgetrinp_work(Layout layout, int n,
            float[] a, int lda, float[] work,
            int lwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void LAPACKE_set_nancheck(int flag);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_get_nancheck();
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsysv_aa_2stage(Layout layout, UpLo uplo,
            int n, int nrhs, double[] a,
            int lda, double[] tb, int ltb,
            int[] ipiv, int[] ipiv2,
            double[] b, int ldb);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsysv_aa_2stage_work(Layout layout, UpLo uplo,
            int n, int nrhs,
            double[] a, int lda, double[] tb,
            int ltb, int[] ipiv,
            int[] ipiv2, double[] b,
            int ldb, double[] work,
            int lwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsytrf_aa_2stage(Layout layout, UpLo uplo,
            int n, double[] a, int lda,
            double[] tb, int ltb,
            int[] ipiv, int[] ipiv2);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsytrf_aa_2stage_work(Layout layout, UpLo uplo,
            int n, double[] a,
            int lda, double[] tb,
            int ltb, int[] ipiv,
            int[] ipiv2, double[] work,
            int lwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsytrs_aa_2stage(Layout layout, UpLo uplo,
            int n, int nrhs, double[] a,
            int lda, double[] tb,
            int ltb, int[] ipiv,
            int[] ipiv2, double[] b,
            int ldb);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_dsytrs_aa_2stage_work(Layout layout, UpLo uplo,
            int n, int nrhs,
            double[] a, int lda,
            double[] tb, int ltb,
            int[] ipiv, int[] ipiv2,
            double[] b, int ldb);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssysv_aa_2stage(Layout layout, UpLo uplo,
            int n, int nrhs, float[] a,
            int lda, float[] tb, int ltb,
            int[] ipiv, int[] ipiv2,
            float[] b, int ldb);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssysv_aa_2stage_work(Layout layout, UpLo uplo,
            int n, int nrhs,
            float[] a, int lda, float[] tb,
            int ltb, int[] ipiv,
            int[] ipiv2, float[] b,
            int ldb, float[] work,
            int lwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssytrf_aa_2stage(Layout layout, UpLo uplo,
            int n, float[] a, int lda,
            float[] tb, int ltb,
            int[] ipiv, int[] ipiv2);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssytrf_aa_2stage_work(Layout layout, UpLo uplo,
            int n, float[] a,
            int lda, float[] tb,
            int ltb, int[] ipiv,
            int[] ipiv2, float[] work,
            int lwork);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssytrs_aa_2stage(Layout layout, UpLo uplo,
            int n, int nrhs, float[] a,
            int lda, float[] tb, int ltb,
            int[] ipiv, int[] ipiv2,
            float[] b, int ldb);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int LAPACKE_ssytrs_aa_2stage_work(Layout layout, UpLo uplo,
            int n, int nrhs,
            float[] a, int lda, float[] tb,
            int ltb, int[] ipiv,
            int[] ipiv2, float[] b,
            int ldb);
    }
}