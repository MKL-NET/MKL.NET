// Copyright 2022 Anthony Lloyd
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

namespace MKLNET;

using System.Security;
using System.Runtime.InteropServices;

[SuppressUnmanagedCodeSecurity]
public static partial class Lapack
{
    [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dlamch")]
    public static extern double dlamch(char cmach);

    [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dlapy2")]
    public static extern double lapy2(double x, double y);

    [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dlapy3")]
    public static extern double lapy3(double x, double y, double z);

    [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_slamch")]
    public static extern float slamch(char cmach);

    [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_slapy2")]
    public static extern float lapy2(float x, float y);

    [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_slapy3")]
    public static extern float lapy3(float x, float y, float z);

    [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_set_nancheck")]
    public static extern void set_nancheck(int flag);

    [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_get_nancheck")]
    public static extern int get_nancheck();

    public unsafe static class Unsafe
    {
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dlange")]
        public static extern double lange(Layout layout, Norm norm, int m,
            int n, /* const */ [In] double* a, int lda);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dlange_work")]
        public static extern double lange(Layout layout, Norm norm, int m,
            int n, /* const */ [In] double* a, int lda,
            double* work);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dlansy")]
        public static extern double lansy(Layout layout, Norm norm, UpLoChar uplo, int n,
            /* const */ [In] double* a, int lda);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dlansy_work")]
        public static extern double lansy(Layout layout, Norm norm, UpLoChar uplo,
            int n, /* const */ [In] double* a, int lda,
            double* work);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dlantr")]
        public static extern double lantr(Layout layout, Norm norm, UpLoChar uplo, DiagChar diag,
            int m, int n, /* const */ [In] double* a,
            int lda);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dlantr_work")]
        public static extern double lantr(Layout layout, Norm norm, UpLoChar uplo,
            DiagChar diag, int m, int n,
            /* const */ [In] double* a, int lda, double* work);

        

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_slange")]
        public static extern float lange(Layout layout, Norm norm, int m,
            int n, /* const */ [In] float* a, int lda);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_slange_work")]
        public static extern float lange(Layout layout, Norm norm, int m,
            int n, /* const */ [In] float* a, int lda,
            float* work);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_slansy")]
        public static extern float lansy(Layout layout, Norm norm, UpLoChar uplo, int n,
            /* const */ [In] float* a, int lda);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_slansy_work")]
        public static extern float lansy(Layout layout, Norm norm, UpLoChar uplo,
            int n, /* const */ [In] float* a, int lda,
            float* work);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_slantr")]
        public static extern float lantr(Layout layout, Norm norm, UpLoChar uplo, DiagChar diag,
            int m, int n, /* const */ [In] float* a,
            int lda);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_slantr_work")]
        public static extern float lantr(Layout layout, Norm norm, UpLoChar uplo,
            DiagChar diag, int m, int n,
            /* const */ [In] float* a, int lda, float* work);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dbbcsd")]
        public static extern int bbcsd(Layout layout, char jobu1, char jobu2,
            char jobv1t, char jobv2t, TransChar trans, int m,
            int p, int q, double* theta,
            double* phi, double* u1, int ldu1, double* u2,
            int ldu2, double* v1t, int ldv1t,
            double* v2t, int ldv2t, double* b11d,
            double* b11e, double* b12d, double* b12e,
            double* b21d, double* b21e, double* b22d,
            double* b22e);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dbbcsd_work")]
        public static extern int bbcsd(Layout layout, char jobu1, char jobu2,
            char jobv1t, char jobv2t, TransChar trans,
            int m, int p, int q,
            double* theta, double* phi, double* u1,
            int ldu1, double* u2, int ldu2,
            double* v1t, int ldv1t, double* v2t,
            int ldv2t, double* b11d, double* b11e,
            double* b12d, double* b12e, double* b21d,
            double* b21e, double* b22d, double* b22e,
            double* work, int lwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dbdsdc")]
        public static extern int bdsdc(Layout layout, UpLoChar uplo, char compq,
            int n, double* d, double* e, double* u,
            int ldu, double* vt, int ldvt,
            double* q, int* iq);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dbdsdc_work")]
        public static extern int bdsdc(Layout layout, UpLoChar uplo, char compq,
            int n, double* d, double* e, double* u,
            int ldu, double* vt, int ldvt,
            double* q, int* iq, double* work,
            int* iwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dbdsqr")]
        public static extern int bdsqr(Layout layout, UpLoChar uplo, int n,
            int ncvt, int nru, int ncc,
            double* d, double* e, double* vt, int ldvt,
            double* u, int ldu, double* c,
            int ldc);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dbdsqr_work")]
        public static extern int bdsqr(Layout layout, UpLoChar uplo, int n,
            int ncvt, int nru, int ncc,
            double* d, double* e, double* vt,
            int ldvt, double* u, int ldu,
            double* c, int ldc, double* work);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dbdsvdx")]
        public static extern int bdsvdx(Layout layout, UpLoChar uplo, char jobz, char range,
            int n, double* d, double* e,
            double vl, double vu,
            int il, int iu, int* ns,
            double* s, double* z, int ldz,
            int* superb);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dbdsvdx_work")]
        public static extern int bdsvdx(Layout layout, UpLoChar uplo, char jobz, char range,
            int n, double* d, double* e,
            double vl, double vu,
            int il, int iu, int* ns,
            double* s, double* z, int ldz,
            double* work, int* iwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_ddisna")]
        public static extern int disna(char job, int m, int n,
            /* const */ [In] double* d, double* sep);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dgbbrd")]
        public static extern int gbbrd(Layout layout, char vect, int m,
            int n, int ncc, int kl,
            int ku, double* ab, int ldab,
            double* d, double* e, double* q, int ldq,
            double* pt, int ldpt, double* c,
            int ldc);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dgbbrd_work")]
        public static extern int gbbrd(Layout layout, char vect, int m,
            int n, int ncc, int kl,
            int ku, double* ab, int ldab,
            double* d, double* e, double* q, int ldq,
            double* pt, int ldpt, double* c,
            int ldc, double* work);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dgbcon")]
        public static extern int gbcon(Layout layout, Norm norm, int n,
            int kl, int ku, /* const */ [In] double* ab,
            int ldab, int* ipiv,
            double anorm, double* rcond);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dgbcon_work")]
        public static extern int gbcon(Layout layout, Norm norm, int n,
            int kl, int ku, /* const */ [In] double* ab,
            int ldab, int* ipiv,
            double anorm, double* rcond, double* work,
            int* iwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dgbequ")]
        public static extern int gbequ(Layout layout, int m, int n,
            int kl, int ku, /* const */ [In] double* ab,
            int ldab, double* r, double* c,
            double* rowcnd, double* colcnd, double* amax);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dgbequb")]
        public static extern int gbequb(Layout layout, int m, int n,
            int kl, int ku, /* const */ [In] double* ab,
            int ldab, double* r, double* c,
            double* rowcnd, double* colcnd, double* amax);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dgbrfs")]
        public static extern int gbrfs(Layout layout, TransChar trans, int n,
            int kl, int ku, int nrhs,
            /* const */ [In] double* ab, int ldab, /* const */ [In] double* afb,
            int ldafb, int* ipiv,
            /* const */ [In] double* b, int ldb, double* x,
            int ldx, double* ferr, double* berr);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dgbrfs_work")]
        public static extern int gbrfs(Layout layout, TransChar trans, int n,
            int kl, int ku, int nrhs,
            /* const */ [In] double* ab, int ldab,
            /* const */ [In] double* afb, int ldafb,
            int* ipiv, /* const */ [In] double* b,
            int ldb, double* x, int ldx,
            double* ferr, double* berr, double* work,
            int* iwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dgbrfsx")]
        public static extern int gbrfsx(Layout layout, TransChar trans, char equed,
            int n, int kl, int ku,
            int nrhs, /* const */ [In] double* ab, int ldab,
            /* const */ [In] double* afb, int ldafb,
            int* ipiv, /* const */ [In] double* r,
            /* const */ [In] double* c, /* const */ [In] double* b, int ldb,
            double* x, int ldx, double* rcond,
            double* berr, int n_err_bnds,
            double* err_bnds_norm, double* err_bnds_comp,
            int nparams, double* aparams);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dgbrfsx_work")]
        public static extern int gbrfsx(Layout layout, TransChar trans, char equed,
            int n, int kl, int ku,
            int nrhs, /* const */ [In] double* ab,
            int ldab, /* const */ [In] double* afb,
            int ldafb, int* ipiv,
            /* const */ [In] double* r, /* const */ [In] double* c,
            /* const */ [In] double* b, int ldb, double* x,
            int ldx, double* rcond, double* berr,
            int n_err_bnds, double* err_bnds_norm,
            double* err_bnds_comp, int nparams,
            double* aparams, double* work,
            int* iwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dgbsv")]
        public static extern int gbsv(Layout layout, int n, int kl,
            int ku, int nrhs, double* ab,
            int ldab, int* ipiv, double* b,
            int ldb);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dgbsvx")]
        public static extern int gbsvx(Layout layout, char fact, TransChar trans,
            int n, int kl, int ku,
            int nrhs, double* ab, int ldab,
            double* afb, int ldafb, int* ipiv,
            char[] equed, double* r, double* c, double* b,
            int ldb, double* x, int ldx,
            double* rcond, double* ferr, double* berr,
            double* rpivot);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dgbsvx_work")]
        public static extern int gbsvx(Layout layout, char fact, TransChar trans,
            int n, int kl, int ku,
            int nrhs, double* ab, int ldab,
            double* afb, int ldafb, int* ipiv,
            char[] equed, double* r, double* c, double* b,
            int ldb, double* x, int ldx,
            double* rcond, double* ferr, double* berr,
            double* work, int* iwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dgbsvxx")]
        public static extern int gbsvxx(Layout layout, char fact, TransChar trans,
            int n, int kl, int ku,
            int nrhs, double* ab, int ldab,
            double* afb, int ldafb, int* ipiv,
            char[] equed, double* r, double* c, double* b,
            int ldb, double* x, int ldx,
            double* rcond, double* rpvgrw, double* berr,
            int n_err_bnds, double* err_bnds_norm,
            double* err_bnds_comp, int nparams,
            double* aparams);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dgbsvxx_work")]
        public static extern int gbsvxx(Layout layout, char fact, TransChar trans,
            int n, int kl, int ku,
            int nrhs, double* ab, int ldab,
            double* afb, int ldafb,
            int* ipiv, char[] equed, double* r,
            double* c, double* b, int ldb,
            double* x, int ldx, double* rcond,
            double* rpvgrw, double* berr,
            int n_err_bnds, double* err_bnds_norm,
            double* err_bnds_comp, int nparams,
            double* aparams, double* work,
            int* iwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dgbtrf")]
        public static extern int gbtrf(Layout layout, int m, int n,
            int kl, int ku, double* ab,
            int ldab, int* ipiv);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dgbtrs")]
        public static extern int gbtrs(Layout layout, TransChar trans, int n,
            int kl, int ku, int nrhs,
            /* const */ [In] double* ab, int ldab,
            int* ipiv, double* b, int ldb);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dgebak")]
        public static extern int gebak(Layout layout, char job, char side, int n,
            int ilo, int ihi, /* const */ [In] double* scale,
            int m, double* v, int ldv);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dgebal")]
        public static extern int gebal(Layout layout, char job, int n, double* a,
            int lda, int* ilo, int* ihi,
            double* scale);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dgebrd")]
        public static extern int gebrd(Layout layout, int m, int n,
            double* a, int lda, double* d, double* e,
            double* tauq, double* taup);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dgebrd_work")]
        public static extern int gebrd(Layout layout, int m, int n,
            double* a, int lda, double* d, double* e,
            double* tauq, double* taup, double* work,
            int lwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dgecon")]
        public static extern int gecon(Layout layout, Norm norm, int n,
            /* const */ [In] double* a, int lda, double anorm,
            double* rcond);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dgecon_work")]
        public static extern int gecon(Layout layout, Norm norm, int n,
            /* const */ [In] double* a, int lda, double anorm,
            double* rcond, double* work, int* iwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dgeequ")]
        public static extern int geequ(Layout layout, int m, int n,
            /* const */ [In] double* a, int lda, double* r,
            double* c, double* rowcnd, double* colcnd,
            double* amax);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dgeequb")]
        public static extern int geequb(Layout layout, int m, int n,
            /* const */ [In] double* a, int lda, double* r,
            double* c, double* rowcnd, double* colcnd,
            double* amax);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dgeev")]
        public static extern int geev(Layout layout, char jobvl, char jobvr,
            int n, double* a, int lda, double* wr,
            double* wi, double* vl, int ldvl, double* vr,
            int ldvr);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dgeev_work")]
        public static extern int geev(Layout layout, char jobvl, char jobvr,
            int n, double* a, int lda,
            double* wr, double* wi, double* vl,
            int ldvl, double* vr, int ldvr,
            double* work, int lwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dgeevx")]
        public static extern int geevx(Layout layout, char balanc, char jobvl,
            char jobvr, char sense, int n, double* a,
            int lda, double* wr, double* wi, double* vl,
            int ldvl, double* vr, int ldvr,
            int* ilo, int* ihi, double* scale,
            double* abnrm, double* rconde, double* rcondv);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dgeevx_work")]
        public static extern int geevx(Layout layout, char balanc, char jobvl,
            char jobvr, char sense, int n, double* a,
            int lda, double* wr, double* wi,
            double* vl, int ldvl, double* vr,
            int ldvr, int* ilo,
            int* ihi, double* scale, double* abnrm,
            double* rconde, double* rcondv, double* work,
            int lwork, int* iwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dgehrd")]
        public static extern int gehrd(Layout layout, int n, int ilo,
            int ihi, double* a, int lda,
            double* tau);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dgehrd_work")]
        public static extern int gehrd(Layout layout, int n, int ilo,
            int ihi, double* a, int lda,
            double* tau, double* work, int lwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dgejsv")]
        public static extern int gejsv(Layout layout, char joba, char jobu, char jobv,
            char jobr, char jobt, char jobp, int m,
            int n, double* a, int lda, double* sva,
            double* u, int ldu, double* v, int ldv,
            double* stat, int* istat);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dgejsv_work")]
        public static extern int gejsv(Layout layout, char joba, char jobu,
            char jobv, char jobr, char jobt, char jobp,
            int m, int n, double* a,
            int lda, double* sva, double* u,
            int ldu, double* v, int ldv,
            double* work, int lwork,
            int* iwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dgelq2")]
        public static extern int gelq2(Layout layout, int m, int n,
            double* a, int lda, double* tau);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dgelq2_work")]
        public static extern int gelq2(Layout layout, int m, int n,
            double* a, int lda, double* tau,
            double* work);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dgelqf")]
        public static extern int gelqf(Layout layout, int m, int n,
            double* a, int lda, double* tau);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dgelqf_work")]
        public static extern int gelqf(Layout layout, int m, int n,
            double* a, int lda, double* tau,
            double* work, int lwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dgels")]
        public static extern int gels(Layout layout, TransChar trans, int m,
            int n, int nrhs, double* a,
            int lda, double* b, int ldb);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dgels_work")]
        public static extern int gels(Layout layout, TransChar trans, int m,
            int n, int nrhs, double* a,
            int lda, double* b, int ldb,
            double* work, int lwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dgelsd")]
        public static extern int gelsd(Layout layout, int m, int n,
            int nrhs, double* a, int lda,
            double* b, int ldb, double* s, double rcond,
            ref int rank);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dgelsd_work")]
        public static extern int gelsd(Layout layout, int m, int n,
            int nrhs, double* a, int lda,
            double* b, int ldb, double* s,
            double rcond, ref int rank, double* work,
            int lwork, int* iwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dgelss")]
        public static extern int gelss(Layout layout, int m, int n,
            int nrhs, double* a, int lda,
            double* b, int ldb, double* s, double rcond,
            ref int rank);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dgelss_work")]
        public static extern int gelss(Layout layout, int m, int n,
            int nrhs, double* a, int lda,
            double* b, int ldb, double* s,
            double rcond, ref int rank, double* work,
            int lwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dgelsy")]
        public static extern int gelsy(Layout layout, int m, int n,
            int nrhs, double* a, int lda,
            double* b, int ldb, int* jpvt,
            double rcond, ref int rank);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dgelsy_work")]
        public static extern int gelsy(Layout layout, int m, int n,
            int nrhs, double* a, int lda,
            double* b, int ldb, int* jpvt,
            double rcond, ref int rank, double* work,
            int lwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dgemqrt")]
        public static extern int gemqrt(Layout layout, char side, TransChar trans,
            int m, int n, int k,
            int nb, /* const */ [In] double* v, int ldv,
            /* const */ [In] double* t, int ldt, double* c,
            int ldc);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dgemqrt_work")]
        public static extern int gemqrt(Layout layout, char side, TransChar trans,
            int m, int n, int k,
            int nb, /* const */ [In] double* v, int ldv,
            /* const */ [In] double* t, int ldt, double* c,
            int ldc, double* work);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dgeqlf")]
        public static extern int geqlf(Layout layout, int m, int n,
            double* a, int lda, double* tau);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dgeqlf_work")]
        public static extern int geqlf(Layout layout, int m, int n,
            double* a, int lda, double* tau,
            double* work, int lwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dgeqp3")]
        public static extern int geqp3(Layout layout, int m, int n,
            double* a, int lda, int* jpvt,
            double* tau);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dgeqp3_work")]
        public static extern int geqp3(Layout layout, int m, int n,
            double* a, int lda, int* jpvt,
            double* tau, double* work, int lwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dgeqpf")]
        public static extern int geqpf(Layout layout, int m, int n,
            double* a, int lda, int* jpvt,
            double* tau);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dgeqpf_work")]
        public static extern int geqpf(Layout layout, int m, int n,
            double* a, int lda, int* jpvt,
            double* tau, double* work);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dgeqr2")]
        public static extern int geqr2(Layout layout, int m, int n,
            double* a, int lda, double* tau);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dgeqr2_work")]
        public static extern int geqr2(Layout layout, int m, int n,
            double* a, int lda, double* tau,
            double* work);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dgeqrf")]
        public static extern int geqrf(Layout layout, int m, int n,
            double* a, int lda, double* tau);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dgeqrf_work")]
        public static extern int geqrf(Layout layout, int m, int n,
            double* a, int lda, double* tau,
            double* work, int lwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dgeqrfp")]
        public static extern int geqrfp(Layout layout, int m, int n,
            double* a, int lda, double* tau);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dgeqrfp_work")]
        public static extern int geqrfp(Layout layout, int m, int n,
            double* a, int lda, double* tau,
            double* work, int lwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dgeqrt")]
        public static extern int geqrt(Layout layout, int m, int n,
            int nb, double* a, int lda, double* t,
            int ldt);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dgeqrt2")]
        public static extern int geqrt2(Layout layout, int m, int n,
            double* a, int lda, double* t,
            int ldt);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dgeqrt3")]
        public static extern int geqrt3(Layout layout, int m, int n,
            double* a, int lda, double* t,
            int ldt);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dgeqrt_work")]
        public static extern int geqrt(Layout layout, int m, int n,
            int nb, double* a, int lda,
            double* t, int ldt, double* work);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dgerfs")]
        public static extern int gerfs(Layout layout, TransChar trans, int n,
            int nrhs, /* const */ [In] double* a, int lda,
            /* const */ [In] double* af, int ldaf,
            int* ipiv, /* const */ [In] double* b,
            int ldb, double* x, int ldx,
            double* ferr, double* berr);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dgerfs_work")]
        public static extern int gerfs(Layout layout, TransChar trans, int n,
            int nrhs, /* const */ [In] double* a,
            int lda, /* const */ [In] double* af,
            int ldaf, int* ipiv,
            /* const */ [In] double* b, int ldb, double* x,
            int ldx, double* ferr, double* berr,
            double* work, int* iwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dgerfsx")]
        public static extern int gerfsx(Layout layout, TransChar trans, char equed,
            int n, int nrhs, /* const */ [In] double* a,
            int lda, /* const */ [In] double* af, int ldaf,
            int* ipiv, /* const */ [In] double* r,
            /* const */ [In] double* c, /* const */ [In] double* b, int ldb,
            double* x, int ldx, double* rcond,
            double* berr, int n_err_bnds,
            double* err_bnds_norm, double* err_bnds_comp,
            int nparams, double* aparams);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dgerfsx_work")]
        public static extern int gerfsx(Layout layout, TransChar trans, char equed,
            int n, int nrhs, /* const */ [In] double* a,
            int lda, /* const */ [In] double* af,
            int ldaf, int* ipiv,
            /* const */ [In] double* r, /* const */ [In] double* c,
            /* const */ [In] double* b, int ldb, double* x,
            int ldx, double* rcond, double* berr,
            int n_err_bnds, double* err_bnds_norm,
            double* err_bnds_comp, int nparams,
            double* aparams, double* work,
            int* iwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dgerqf")]
        public static extern int gerqf(Layout layout, int m, int n,
            double* a, int lda, double* tau);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dgerqf_work")]
        public static extern int gerqf(Layout layout, int m, int n,
            double* a, int lda, double* tau,
            double* work, int lwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dgesdd")]
        public static extern int gesdd(Layout layout, char jobz, int m,
            int n, double* a, int lda, double* s,
            double* u, int ldu, double* vt,
            int ldvt);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dgesdd_work")]
        public static extern int gesdd(Layout layout, char jobz, int m,
            int n, double* a, int lda,
            double* s, double* u, int ldu,
            double* vt, int ldvt, double* work,
            int lwork, int* iwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dgesv")]
        public static extern int gesv(Layout layout, int n, int nrhs,
            double* a, int lda, int* ipiv,
            double* b, int ldb);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dgesvd")]
        public static extern int gesvd(Layout layout, char jobu, char jobvt,
            int m, int n, double* a,
            int lda, double* s, double* u, int ldu,
            double* vt, int ldvt, double* superb);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dgesvd_work")]
        public static extern int gesvd(Layout layout, char jobu, char jobvt,
            int m, int n, double* a,
            int lda, double* s, double* u,
            int ldu, double* vt, int ldvt,
            double* work, int lwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dgesvdx")]
        public static extern int gesvdx(Layout layout, char jobu, char jobvt, char range,
            int m, int n, double* a,
            int lda, double vl, double vu,
            int il, int iu, int* ns,
            double* s, double* u, int ldu,
            double* vt, int ldvt,
            int* superb);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dgesvdx_work")]
        public static extern int gesvdx(Layout layout, char jobu, char jobvt, char range,
            int m, int n, double* a,
            int lda, double vl, double vu,
            int il, int iu, int* ns,
            double* s, double* u, int ldu,
            double* vt, int ldvt,
            double* work, int lwork, int* iwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dgesvj")]
        public static extern int gesvj(Layout layout, char joba, char jobu, char jobv,
            int m, int n, double* a,
            int lda, double* sva, int mv,
            double* v, int ldv, double* stat);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dgesvj_work")]
        public static extern int gesvj(Layout layout, char joba, char jobu,
            char jobv, int m, int n,
            double* a, int lda, double* sva,
            int mv, double* v, int ldv,
            double* work, int lwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dgesvx")]
        public static extern int gesvx(Layout layout, char fact, TransChar trans,
            int n, int nrhs, double* a,
            int lda, double* af, int ldaf,
            int* ipiv, char[] equed, double* r, double* c,
            double* b, int ldb, double* x, int ldx,
            double* rcond, double* ferr, double* berr,
            double* rpivot);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dgesvx_work")]
        public static extern int gesvx(Layout layout, char fact, TransChar trans,
            int n, int nrhs, double* a,
            int lda, double* af, int ldaf,
            int* ipiv, char[] equed, double* r,
            double* c, double* b, int ldb, double* x,
            int ldx, double* rcond, double* ferr,
            double* berr, double* work, int* iwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dgesvxx")]
        public static extern int gesvxx(Layout layout, char fact, TransChar trans,
            int n, int nrhs, double* a,
            int lda, double* af, int ldaf,
            int* ipiv, char[] equed, double* r, double* c,
            double* b, int ldb, double* x,
            int ldx, double* rcond, double* rpvgrw,
            double* berr, int n_err_bnds,
            double* err_bnds_norm, double* err_bnds_comp,
            int nparams, double* aparams);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dgesvxx_work")]
        public static extern int gesvxx(Layout layout, char fact, TransChar trans,
            int n, int nrhs, double* a,
            int lda, double* af, int ldaf,
            int* ipiv, char[] equed, double* r,
            double* c, double* b, int ldb,
            double* x, int ldx, double* rcond,
            double* rpvgrw, double* berr,
            int n_err_bnds, double* err_bnds_norm,
            double* err_bnds_comp, int nparams,
            double* aparams, double* work,
            int* iwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dgetf2")]
        public static extern int getf2(Layout layout, int m, int n,
            double* a, int lda, int* ipiv);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dgetrf")]
        public static extern int getrf(Layout layout, int m, int n,
            double* a, int lda, int* ipiv);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dgetrf2")]
        public static extern int getrf2(Layout layout, int m, int n,
            double* a, int lda, int* ipiv);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dgetri")]
        public static extern int getri(Layout layout, int n, double* a,
            int lda, int* ipiv);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dgetri_work")]
        public static extern int getri(Layout layout, int n, double* a,
            int lda, int* ipiv,
            double* work, int lwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dgetrs")]
        public static extern int getrs(Layout layout, TransChar trans, int n,
            int nrhs, /* const */ [In] double* a, int lda,
            int* ipiv, double* b, int ldb);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dggbak")]
        public static extern int ggbak(Layout layout, char job, char side, int n,
            int ilo, int ihi, /* const */ [In] double* lscale,
            /* const */ [In] double* rscale, int m, double* v,
            int ldv);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dggbal")]
        public static extern int ggbal(Layout layout, char job, int n, double* a,
            int lda, double* b, int ldb,
            int* ilo, int* ihi, double* lscale,
            double* rscale);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dggbal_work")]
        public static extern int ggbal(Layout layout, char job, int n,
            double* a, int lda, double* b,
            int ldb, int* ilo,
            int* ihi, double* lscale, double* rscale,
            double* work);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dggev")]
        public static extern int ggev(Layout layout, char jobvl, char jobvr,
            int n, double* a, int lda, double* b,
            int ldb, double* alphar, double* alphai,
            double* beta, double* vl, int ldvl, double* vr,
            int ldvr);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dggev3")]
        public static extern int ggev3(Layout layout,
            char jobvl, char jobvr, int n,
            double* a, int lda,
            double* b, int ldb,
            double* alphar, double* alphai, double* beta,
            double* vl, int ldvl,
            double* vr, int ldvr);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dggev3_work")]
        public static extern int ggev3(Layout layout, char jobvl, char jobvr,
            int n, double* a, int lda,
            double* b, int ldb, double* alphar,
            double* alphai, double* beta, double* vl,
            int ldvl, double* vr, int ldvr,
            double* work, int lwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dggev_work")]
        public static extern int ggev(Layout layout, char jobvl, char jobvr,
            int n, double* a, int lda,
            double* b, int ldb, double* alphar,
            double* alphai, double* beta, double* vl,
            int ldvl, double* vr, int ldvr,
            double* work, int lwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dggevx")]
        public static extern int ggevx(Layout layout, char balanc, char jobvl,
            char jobvr, char sense, int n, double* a,
            int lda, double* b, int ldb,
            double* alphar, double* alphai, double* beta,
            double* vl, int ldvl, double* vr,
            int ldvr, int* ilo, int* ihi,
            double* lscale, double* rscale, double* abnrm,
            double* bbnrm, double* rconde, double* rcondv);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dggevx_work")]
        public static extern int ggevx(Layout layout, char balanc, char jobvl,
            char jobvr, char sense, int n, double* a,
            int lda, double* b, int ldb,
            double* alphar, double* alphai, double* beta,
            double* vl, int ldvl, double* vr,
            int ldvr, int* ilo,
            int* ihi, double* lscale, double* rscale,
            double* abnrm, double* bbnrm, double* rconde,
            double* rcondv, double* work, int lwork,
            int* iwork, int* bwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dggglm")]
        public static extern int ggglm(Layout layout, int n, int m,
            int p, double* a, int lda, double* b,
            int ldb, double* d, double* x, double* y);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dggglm_work")]
        public static extern int ggglm(Layout layout, int n, int m,
            int p, double* a, int lda,
            double* b, int ldb, double* d, double* x,
            double* y, double* work, int lwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dgghd3")]
        public static extern int gghd3(Layout layout, char compq, char compz,
            int n, int ilo, int ihi,
            double* a, int lda,
            double* b, int ldb,
            double* q, int ldq,
            double* z, int ldz);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dgghd3_work")]
        public static extern int gghd3(Layout layout, char compq, char compz,
            int n, int ilo, int ihi,
            double* a, int lda, double* b,
            int ldb, double* q, int ldq,
            double* z, int ldz, double* work,
            int lwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dgghrd")]
        public static extern int gghrd(Layout layout, char compq, char compz,
            int n, int ilo, int ihi,
            double* a, int lda, double* b, int ldb,
            double* q, int ldq, double* z,
            int ldz);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dgglse")]
        public static extern int gglse(Layout layout, int m, int n,
            int p, double* a, int lda, double* b,
            int ldb, double* c, double* d, double* x);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dgglse_work")]
        public static extern int gglse(Layout layout, int m, int n,
            int p, double* a, int lda,
            double* b, int ldb, double* c, double* d,
            double* x, double* work, int lwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dggqrf")]
        public static extern int ggqrf(Layout layout, int n, int m,
            int p, double* a, int lda,
            double* taua, double* b, int ldb,
            double* taub);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dggqrf_work")]
        public static extern int ggqrf(Layout layout, int n, int m,
            int p, double* a, int lda,
            double* taua, double* b, int ldb,
            double* taub, double* work, int lwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dggrqf")]
        public static extern int ggrqf(Layout layout, int m, int p,
            int n, double* a, int lda,
            double* taua, double* b, int ldb,
            double* taub);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dggrqf_work")]
        public static extern int ggrqf(Layout layout, int m, int p,
            int n, double* a, int lda,
            double* taua, double* b, int ldb,
            double* taub, double* work, int lwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dggsvd")]
        public static extern int ggsvd(Layout layout, char jobu, char jobv, char jobq,
            int m, int n, int p,
            int* k, int* l, double* a,
            int lda, double* b, int ldb,
            double* alpha, double* beta, double* u,
            int ldu, double* v, int ldv, double* q,
            int ldq, int* iwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dggsvd3")]
        public static extern int ggsvd3(Layout layout, char jobu, char jobv, char jobq,
            int m, int n, int p,
            int* k, int* l, double* a,
            int lda, double* b, int ldb,
            double* alpha, double* beta, double* u,
            int ldu, double* v, int ldv, double* q,
            int ldq, int* iwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dggsvd3_work")]
        public static extern int ggsvd3(Layout layout, char jobu, char jobv,
            char jobq, int m, int n,
            int p, int* k, int* l,
            double* a, int lda, double* b,
            int ldb, double* alpha, double* beta,
            double* u, int ldu, double* v,
            int ldv, double* q, int ldq,
            double* work, int lwork,
            int* iwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dggsvd_work")]
        public static extern int ggsvd(Layout layout, char jobu, char jobv,
            char jobq, int m, int n,
            int p, int* k, int* l,
            double* a, int lda, double* b,
            int ldb, double* alpha, double* beta,
            double* u, int ldu, double* v,
            int ldv, double* q, int ldq,
            double* work, int* iwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dggsvp")]
        public static extern int ggsvp(Layout layout, char jobu, char jobv, char jobq,
            int m, int p, int n, double* a,
            int lda, double* b, int ldb,
            double tola, double tolb, int* k,
            int* l, double* u, int ldu, double* v,
            int ldv, double* q, int ldq);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dggsvp3")]
        public static extern int ggsvp3(Layout layout, char jobu, char jobv, char jobq,
            int m, int p, int n, double* a,
            int lda, double* b, int ldb,
            double tola, double tolb, int* k,
            int* l, double* u, int ldu, double* v,
            int ldv, double* q, int ldq);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dggsvp3_work")]
        public static extern int ggsvp3(Layout layout, char jobu, char jobv,
            char jobq, int m, int p,
            int n, double* a, int lda,
            double* b, int ldb, double tola,
            double tolb, int* k, int* l,
            double* u, int ldu, double* v,
            int ldv, double* q, int ldq,
            int* iwork, double* tau, double* work,
            int lwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dggsvp_work")]
        public static extern int ggsvp(Layout layout, char jobu, char jobv,
            char jobq, int m, int p,
            int n, double* a, int lda,
            double* b, int ldb, double tola,
            double tolb, int* k, int* l,
            double* u, int ldu, double* v,
            int ldv, double* q, int ldq,
            int* iwork, double* tau, double* work);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dgtcon")]
        public static extern int gtcon(Norm norm, int n, /* const */ [In] double* dl,
            /* const */ [In] double* d, /* const */ [In] double* du, /* const */ [In] double* du2,
            int* ipiv, double anorm, double* rcond);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dgtcon_work")]
        public static extern int gtcon(Norm norm, int n, /* const */ [In] double* dl,
            /* const */ [In] double* d, /* const */ [In] double* du,
            /* const */ [In] double* du2, int* ipiv,
            double anorm, double* rcond, double* work,
            int* iwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dgtrfs")]
        public static extern int gtrfs(Layout layout, TransChar trans, int n,
            int nrhs, /* const */ [In] double* dl, /* const */ [In] double* d,
            /* const */ [In] double* du, /* const */ [In] double* dlf,
            /* const */ [In] double* df, /* const */ [In] double* duf,
            /* const */ [In] double* du2, int* ipiv,
            /* const */ [In] double* b, int ldb, double* x,
            int ldx, double* ferr, double* berr);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dgtrfs_work")]
        public static extern int gtrfs(Layout layout, TransChar trans, int n,
            int nrhs, /* const */ [In] double* dl,
            /* const */ [In] double* d, /* const */ [In] double* du,
            /* const */ [In] double* dlf, /* const */ [In] double* df,
            /* const */ [In] double* duf, /* const */ [In] double* du2,
            int* ipiv, /* const */ [In] double* b,
            int ldb, double* x, int ldx,
            double* ferr, double* berr, double* work,
            int* iwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dgtsv")]
        public static extern int gtsv(Layout layout, int n, int nrhs,
            double* dl, double* d, double* du, double* b,
            int ldb);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dgtsvx")]
        public static extern int gtsvx(Layout layout, char fact, TransChar trans,
            int n, int nrhs, /* const */ [In] double* dl,
            /* const */ [In] double* d, /* const */ [In] double* du, double* dlf,
            double* df, double* duf, double* du2,
            int* ipiv, /* const */ [In] double* b, int ldb,
            double* x, int ldx, double* rcond,
            double* ferr, double* berr);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dgtsvx_work")]
        public static extern int gtsvx(Layout layout, char fact, TransChar trans,
            int n, int nrhs, /* const */ [In] double* dl,
            /* const */ [In] double* d, /* const */ [In] double* du, double* dlf,
            double* df, double* duf, double* du2,
            int* ipiv, /* const */ [In] double* b,
            int ldb, double* x, int ldx,
            double* rcond, double* ferr, double* berr,
            double* work, int* iwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dgttrf")]
        public static extern int gttrf(int n, double* dl, double* d, double* du,
            double* du2, int* ipiv);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dgttrs")]
        public static extern int gttrs(Layout layout, TransChar trans, int n,
            int nrhs, /* const */ [In] double* dl, /* const */ [In] double* d,
            /* const */ [In] double* du, /* const */ [In] double* du2,
            int* ipiv, double* b, int ldb);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dhgeqz")]
        public static extern int hgeqz(Layout layout, char job, char compq, char compz,
            int n, int ilo, int ihi,
            double* h, int ldh, double* t, int ldt,
            double* alphar, double* alphai, double* beta,
            double* q, int ldq, double* z,
            int ldz);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dhgeqz_work")]
        public static extern int hgeqz(Layout layout, char job, char compq,
            char compz, int n, int ilo,
            int ihi, double* h, int ldh,
            double* t, int ldt, double* alphar,
            double* alphai, double* beta, double* q,
            int ldq, double* z, int ldz,
            double* work, int lwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dhsein")]
        public static extern int hsein(Layout layout, char job, char eigsrc, char initv,
            int* select, int n,
            /* const */ [In] double* h, int ldh, double* wr,
            /* const */ [In] double* wi, double* vl, int ldvl,
            double* vr, int ldvr, int mm,
            int* m, int* ifaill,
            int* ifailr);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dhsein_work")]
        public static extern int hsein(Layout layout, char job, char eigsrc,
            char initv, int* select,
            int n, /* const */ [In] double* h, int ldh,
            double* wr, /* const */ [In] double* wi, double* vl,
            int ldvl, double* vr, int ldvr,
            int mm, int* m, double* work,
            int* ifaill, int* ifailr);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dhseqr")]
        public static extern int hseqr(Layout layout, char job, char compz, int n,
            int ilo, int ihi, double* h,
            int ldh, double* wr, double* wi, double* z,
            int ldz);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dhseqr_work")]
        public static extern int hseqr(Layout layout, char job, char compz,
            int n, int ilo, int ihi,
            double* h, int ldh, double* wr,
            double* wi, double* z, int ldz,
            double* work, int lwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dlacn2")]
        public static extern int lacn2(int n, double* v, double* x, int* isgn,
            double* est, int* kase, int* isave);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dlacpy")]
        public static extern int lacpy(Layout layout, UpLoChar uplo, int m,
            int n, /* const */ [In] double* a, int lda,
            double* b, int ldb);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dlag2s")]
        public static extern int lag2s(Layout layout, int m, int n,
            /* const */ [In] double* a, int lda, float* sa,
            int ldsa);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dlagge")]
        public static extern int lagge(Layout layout, int m, int n,
            int kl, int ku, /* const */ [In] double* d,
            double* a, int lda, int* iseed);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dlagge_work")]
        public static extern int lagge(Layout layout, int m, int n,
            int kl, int ku, /* const */ [In] double* d,
            double* a, int lda, int* iseed,
            double* work);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dlagsy")]
        public static extern int lagsy(Layout layout, int n, int k,
            /* const */ [In] double* d, double* a, int lda,
            int* iseed);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dlagsy_work")]
        public static extern int lagsy(Layout layout, int n, int k,
            /* const */ [In] double* d, double* a, int lda,
            int* iseed, double* work);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dlapmr")]
        public static extern int lapmr(Layout layout, int forwrd,
            int m, int n, double* x,
            int ldx, int* k);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dlapmt")]
        public static extern int lapmt(Layout layout, int forwrd,
            int m, int n, double* x,
            int ldx, int* k);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dlarfb")]
        public static extern int larfb(Layout layout, char side, TransChar trans, char direct,
            char storev, int m, int n,
            int k, /* const */ [In] double* v, int ldv,
            /* const */ [In] double* t, int ldt, double* c,
            int ldc);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dlarfb_work")]
        public static extern int larfb(Layout layout, char side, TransChar trans,
            char direct, char storev, int m,
            int n, int k, /* const */ [In] double* v,
            int ldv, /* const */ [In] double* t, int ldt,
            double* c, int ldc, double* work,
            int ldwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dlarfg")]
        public static extern int larfg(int n, double* alpha, double* x,
            int incx, double* tau);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dlarft")]
        public static extern int larft(Layout layout, char direct, char storev,
            int n, int k, /* const */ [In] double* v,
            int ldv, /* const */ [In] double* tau, double* t,
            int ldt);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dlarfx")]
        public static extern int larfx(Layout layout, char side, int m,
            int n, /* const */ [In] double* v, double tau, double* c,
            int ldc, double* work);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dlarnv")]
        public static extern int larnv(int idist, int* iseed, int n,
            double* x);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dlartgp")]
        public static extern int lartgp(double f, double g, double* cs, double* sn,
            double* r);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dlartgs")]
        public static extern int lartgs(double x, double y, double sigma, double* cs,
            double* sn);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dlascl")]
        public static extern int lascl(Layout layout, char type, int kl,
            int ku, double cfrom, double cto,
            int m, int n, double* a,
            int lda);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dlaset")]
        public static extern int laset(Layout layout, UpLoChar uplo, int m,
            int n, double alpha, double beta, double* a,
            int lda);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dlasrt")]
        public static extern int lasrt(char id, int n, double* d);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dlaswp")]
        public static extern int laswp(Layout layout, int n, double* a,
            int lda, int k1, int k2,
            int* ipiv, int incx);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dlatms")]
        public static extern int latms(Layout layout, int m, int n,
            char dist, int* iseed, char sym, double* d,
            int mode, double cond, double dmax,
            int kl, int ku, char pack, double* a,
            int lda);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dlatms_work")]
        public static extern int latms(Layout layout, int m, int n,
            char dist, int* iseed, char sym,
            double* d, int mode, double cond,
            double dmax, int kl, int ku,
            char pack, double* a, int lda,
            double* work);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dlauum")]
        public static extern int lauum(Layout layout, UpLoChar uplo, int n, double* a,
            int lda);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dopgtr")]
        public static extern int opgtr(Layout layout, UpLoChar uplo, int n,
            /* const */ [In] double* ap, /* const */ [In] double* tau, double* q,
            int ldq);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dopgtr_work")]
        public static extern int opgtr(Layout layout, UpLoChar uplo, int n,
            /* const */ [In] double* ap, /* const */ [In] double* tau, double* q,
            int ldq, double* work);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dopmtr")]
        public static extern int opmtr(Layout layout, char side, UpLoChar uplo, TransChar trans,
            int m, int n, /* const */ [In] double* ap,
            /* const */ [In] double* tau, double* c, int ldc);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dopmtr_work")]
        public static extern int opmtr(Layout layout, char side, UpLoChar uplo,
            TransChar trans, int m, int n,
            /* const */ [In] double* ap, /* const */ [In] double* tau, double* c,
            int ldc, double* work);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dorbdb")]
        public static extern int orbdb(Layout layout, TransChar trans, char signs,
            int m, int p, int q,
            double* x11, int ldx11, double* x12,
            int ldx12, double* x21, int ldx21,
            double* x22, int ldx22, double* theta,
            double* phi, double* taup1, double* taup2,
            double* tauq1, double* tauq2);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dorbdb_work")]
        public static extern int orbdb(Layout layout, TransChar trans, char signs,
            int m, int p, int q,
            double* x11, int ldx11, double* x12,
            int ldx12, double* x21, int ldx21,
            double* x22, int ldx22, double* theta,
            double* phi, double* taup1, double* taup2,
            double* tauq1, double* tauq2, double* work,
            int lwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dorcsd")]
        public static extern int orcsd(Layout layout, char jobu1, char jobu2,
            char jobv1t, char jobv2t, TransChar trans, char signs,
            int m, int p, int q,
            double* x11, int ldx11, double* x12,
            int ldx12, double* x21, int ldx21,
            double* x22, int ldx22, double* theta,
            double* u1, int ldu1, double* u2,
            int ldu2, double* v1t, int ldv1t,
            double* v2t, int ldv2t);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dorcsd2by1")]
        public static extern int orcsd2by1(Layout layout, char jobu1, char jobu2,
            char jobv1t, int m, int p, int q,
            double* x11, int ldx11, double* x21, int ldx21,
            double* theta, double* u1, int ldu1, double* u2,
            int ldu2, double* v1t, int ldv1t);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dorcsd2by1_work")]
        public static extern int orcsd2by1(Layout layout, char jobu1, char jobu2,
            char jobv1t, int m, int p,
            int q, double* x11, int ldx11,
            double* x21, int ldx21,
            double* theta, double* u1, int ldu1,
            double* u2, int ldu2, double* v1t,
            int ldv1t, double* work, int lwork,
            int* iwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dorcsd_work")]
        public static extern int orcsd(Layout layout, char jobu1, char jobu2,
            char jobv1t, char jobv2t, TransChar trans,
            char signs, int m, int p,
            int q, double* x11, int ldx11,
            double* x12, int ldx12, double* x21,
            int ldx21, double* x22, int ldx22,
            double* theta, double* u1, int ldu1,
            double* u2, int ldu2, double* v1t,
            int ldv1t, double* v2t, int ldv2t,
            double* work, int lwork,
            int* iwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dorgbr")]
        public static extern int orgbr(Layout layout, char vect, int m,
            int n, int k, double* a,
            int lda, double* tau);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dorgbr_work")]
        public static extern int orgbr(Layout layout, char vect, int m,
            int n, int k, double* a,
            int lda, /* const */ [In] double* tau, double* work,
            int lwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dorghr")]
        public static extern int orghr(Layout layout, int n, int ilo,
            int ihi, double* a, int lda,
            double* tau);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dorghr_work")]
        public static extern int orghr(Layout layout, int n, int ilo,
            int ihi, double* a, int lda,
            /* const */ [In] double* tau, double* work,
            int lwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dorglq")]
        public static extern int orglq(Layout layout, int m, int n,
            int k, double* a, int lda,
            double* tau);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dorglq_work")]
        public static extern int orglq(Layout layout, int m, int n,
            int k, double* a, int lda,
            /* const */ [In] double* tau, double* work,
            int lwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dorgql")]
        public static extern int orgql(Layout layout, int m, int n,
            int k, double* a, int lda,
            double* tau);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dorgql_work")]
        public static extern int orgql(Layout layout, int m, int n,
            int k, double* a, int lda,
            /* const */ [In] double* tau, double* work,
            int lwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dorgqr")]
        public static extern int orgqr(Layout layout, int m, int n,
            int k, double* a, int lda,
            double* tau);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dorgqr_work")]
        public static extern int orgqr(Layout layout, int m, int n,
            int k, double* a, int lda,
            /* const */ [In] double* tau, double* work,
            int lwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dorgrq")]
        public static extern int orgrq(Layout layout, int m, int n,
            int k, double* a, int lda,
            double* tau);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dorgrq_work")]
        public static extern int orgrq(Layout layout, int m, int n,
            int k, double* a, int lda,
            /* const */ [In] double* tau, double* work,
            int lwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dorgtr")]
        public static extern int orgtr(Layout layout, UpLoChar uplo, int n, double* a,
            int lda, double* tau);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dorgtr_work")]
        public static extern int orgtr(Layout layout, UpLoChar uplo, int n,
            double* a, int lda, /* const */ [In] double* tau,
            double* work, int lwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dormbr")]
        public static extern int ormbr(Layout layout, char vect, char side, TransChar trans,
            int m, int n, int k,
            /* const */ [In] double* a, int lda, /* const */ [In] double* tau,
            double* c, int ldc);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dormbr_work")]
        public static extern int ormbr(Layout layout, char vect, char side,
            TransChar trans, int m, int n,
            int k, /* const */ [In] double* a, int lda,
            /* const */ [In] double* tau, double* c, int ldc,
            double* work, int lwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dormhr")]
        public static extern int ormhr(Layout layout, char side, TransChar trans,
            int m, int n, int ilo,
            int ihi, /* const */ [In] double* a, int lda,
            /* const */ [In] double* tau, double* c, int ldc);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dormhr_work")]
        public static extern int ormhr(Layout layout, char side, TransChar trans,
            int m, int n, int ilo,
            int ihi, /* const */ [In] double* a, int lda,
            /* const */ [In] double* tau, double* c, int ldc,
            double* work, int lwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dormlq")]
        public static extern int ormlq(Layout layout, char side, TransChar trans,
            int m, int n, int k,
            /* const */ [In] double* a, int lda, /* const */ [In] double* tau,
            double* c, int ldc);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dormlq_work")]
        public static extern int ormlq(Layout layout, char side, TransChar trans,
            int m, int n, int k,
            /* const */ [In] double* a, int lda,
            /* const */ [In] double* tau, double* c, int ldc,
            double* work, int lwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dormql")]
        public static extern int ormql(Layout layout, char side, TransChar trans,
            int m, int n, int k,
            /* const */ [In] double* a, int lda, /* const */ [In] double* tau,
            double* c, int ldc);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dormql_work")]
        public static extern int ormql(Layout layout, char side, TransChar trans,
            int m, int n, int k,
            /* const */ [In] double* a, int lda,
            /* const */ [In] double* tau, double* c, int ldc,
            double* work, int lwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dormqr")]
        public static extern int ormqr(Layout layout, char side, TransChar trans,
            int m, int n, int k,
            /* const */ [In] double* a, int lda, /* const */ [In] double* tau,
            double* c, int ldc);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dormqr_work")]
        public static extern int ormqr(Layout layout, char side, TransChar trans,
            int m, int n, int k,
            /* const */ [In] double* a, int lda,
            /* const */ [In] double* tau, double* c, int ldc,
            double* work, int lwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dormrq")]
        public static extern int ormrq(Layout layout, char side, TransChar trans,
            int m, int n, int k,
            /* const */ [In] double* a, int lda, /* const */ [In] double* tau,
            double* c, int ldc);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dormrq_work")]
        public static extern int ormrq(Layout layout, char side, TransChar trans,
            int m, int n, int k,
            /* const */ [In] double* a, int lda,
            /* const */ [In] double* tau, double* c, int ldc,
            double* work, int lwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dormrz")]
        public static extern int ormrz(Layout layout, char side, TransChar trans,
            int m, int n, int k,
            int l, /* const */ [In] double* a, int lda,
            /* const */ [In] double* tau, double* c, int ldc);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dormrz_work")]
        public static extern int ormrz(Layout layout, char side, TransChar trans,
            int m, int n, int k,
            int l, /* const */ [In] double* a, int lda,
            /* const */ [In] double* tau, double* c, int ldc,
            double* work, int lwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dormtr")]
        public static extern int ormtr(Layout layout, char side, UpLoChar uplo, TransChar trans,
            int m, int n, /* const */ [In] double* a,
            int lda, /* const */ [In] double* tau, double* c,
            int ldc);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dormtr_work")]
        public static extern int ormtr(Layout layout, char side, UpLoChar uplo,
            TransChar trans, int m, int n,
            /* const */ [In] double* a, int lda,
            /* const */ [In] double* tau, double* c, int ldc,
            double* work, int lwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dpbcon")]
        public static extern int pbcon(Layout layout, UpLoChar uplo, int n,
            int kd, /* const */ [In] double* ab, int ldab,
            double anorm, double* rcond);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dpbcon_work")]
        public static extern int pbcon(Layout layout, UpLoChar uplo, int n,
            int kd, /* const */ [In] double* ab,
            int ldab, double anorm, double* rcond,
            double* work, int* iwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dpbequ")]
        public static extern int pbequ(Layout layout, UpLoChar uplo, int n,
            int kd, /* const */ [In] double* ab, int ldab,
            double* s, double* scond, double* amax);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dpbrfs")]
        public static extern int pbrfs(Layout layout, UpLoChar uplo, int n,
            int kd, int nrhs, /* const */ [In] double* ab,
            int ldab, /* const */ [In] double* afb, int ldafb,
            /* const */ [In] double* b, int ldb, double* x,
            int ldx, double* ferr, double* berr);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dpbrfs_work")]
        public static extern int pbrfs(Layout layout, UpLoChar uplo, int n,
            int kd, int nrhs,
            /* const */ [In] double* ab, int ldab,
            /* const */ [In] double* afb, int ldafb,
            /* const */ [In] double* b, int ldb, double* x,
            int ldx, double* ferr, double* berr,
            double* work, int* iwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dpbstf")]
        public static extern int pbstf(Layout layout, UpLoChar uplo, int n,
            int kb, double* bb, int ldbb);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dpbsv")]
        public static extern int pbsv(Layout layout, UpLoChar uplo, int n,
            int kd, int nrhs, double* ab,
            int ldab, double* b, int ldb);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dpbsvx")]
        public static extern int pbsvx(Layout layout, char fact, UpLoChar uplo, int n,
            int kd, int nrhs, double* ab,
            int ldab, double* afb, int ldafb,
            char[] equed, double* s, double* b, int ldb,
            double* x, int ldx, double* rcond,
            double* ferr, double* berr);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dpbsvx_work")]
        public static extern int pbsvx(Layout layout, char fact, UpLoChar uplo,
            int n, int kd, int nrhs,
            double* ab, int ldab, double* afb,
            int ldafb, char[] equed, double* s,
            double* b, int ldb, double* x,
            int ldx, double* rcond, double* ferr,
            double* berr, double* work, int* iwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dpbtrf")]
        public static extern int pbtrf(Layout layout, UpLoChar uplo, int n,
            int kd, double* ab, int ldab);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dpbtrs")]
        public static extern int pbtrs(Layout layout, UpLoChar uplo, int n,
            int kd, int nrhs, /* const */ [In] double* ab,
            int ldab, double* b, int ldb);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dpftrf")]
        public static extern int pftrf(Layout layout, TransChar transr, UpLoChar uplo,
            int n, double* a);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dpftri")]
        public static extern int pftri(Layout layout, TransChar transr, UpLoChar uplo,
            int n, double* a);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dpftrs")]
        public static extern int pftrs(Layout layout, TransChar transr, UpLoChar uplo,
            int n, int nrhs, /* const */ [In] double* a,
            double* b, int ldb);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dpocon")]
        public static extern int pocon(Layout layout, UpLoChar uplo, int n,
            /* const */ [In] double* a, int lda, double anorm,
            double* rcond);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dpocon_work")]
        public static extern int pocon(Layout layout, UpLoChar uplo, int n,
            /* const */ [In] double* a, int lda, double anorm,
            double* rcond, double* work, int* iwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dpoequ")]
        public static extern int poequ(Layout layout, int n, /* const */ [In] double* a,
            int lda, double* s, double* scond,
            double* amax);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dpoequb")]
        public static extern int poequb(Layout layout, int n, /* const */ [In] double* a,
            int lda, double* s, double* scond,
            double* amax);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dporfs")]
        public static extern int porfs(Layout layout, UpLoChar uplo, int n,
            int nrhs, /* const */ [In] double* a, int lda,
            /* const */ [In] double* af, int ldaf, /* const */ [In] double* b,
            int ldb, double* x, int ldx,
            double* ferr, double* berr);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dporfs_work")]
        public static extern int porfs(Layout layout, UpLoChar uplo, int n,
            int nrhs, /* const */ [In] double* a,
            int lda, /* const */ [In] double* af,
            int ldaf, /* const */ [In] double* b,
            int ldb, double* x, int ldx,
            double* ferr, double* berr, double* work,
            int* iwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dporfsx")]
        public static extern int porfsx(Layout layout, UpLoChar uplo, char equed,
            int n, int nrhs, /* const */ [In] double* a,
            int lda, /* const */ [In] double* af, int ldaf,
            /* const */ [In] double* s, /* const */ [In] double* b, int ldb,
            double* x, int ldx, double* rcond,
            double* berr, int n_err_bnds,
            double* err_bnds_norm, double* err_bnds_comp,
            int nparams, double* aparams);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dporfsx_work")]
        public static extern int porfsx(Layout layout, UpLoChar uplo, char equed,
            int n, int nrhs, /* const */ [In] double* a,
            int lda, /* const */ [In] double* af,
            int ldaf, /* const */ [In] double* s,
            /* const */ [In] double* b, int ldb, double* x,
            int ldx, double* rcond, double* berr,
            int n_err_bnds, double* err_bnds_norm,
            double* err_bnds_comp, int nparams,
            double* aparams, double* work,
            int* iwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dposv")]
        public static extern int posv(Layout layout, UpLoChar uplo, int n,
            int nrhs, double* a, int lda, double* b,
            int ldb);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dposvx")]
        public static extern int posvx(Layout layout, char fact, UpLoChar uplo, int n,
            int nrhs, double* a, int lda,
            double* af, int ldaf, char[] equed, double* s,
            double* b, int ldb, double* x, int ldx,
            double* rcond, double* ferr, double* berr);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dposvx_work")]
        public static extern int posvx(Layout layout, char fact, UpLoChar uplo,
            int n, int nrhs, double* a,
            int lda, double* af, int ldaf,
            char[] equed, double* s, double* b,
            int ldb, double* x, int ldx,
            double* rcond, double* ferr, double* berr,
            double* work, int* iwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dposvxx")]
        public static extern int posvxx(Layout layout, char fact, UpLoChar uplo,
            int n, int nrhs, double* a,
            int lda, double* af, int ldaf,
            char[] equed, double* s, double* b, int ldb,
            double* x, int ldx, double* rcond,
            double* rpvgrw, double* berr, int n_err_bnds,
            double* err_bnds_norm, double* err_bnds_comp,
            int nparams, double* aparams);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dposvxx_work")]
        public static extern int posvxx(Layout layout, char fact, UpLoChar uplo,
            int n, int nrhs, double* a,
            int lda, double* af, int ldaf,
            char[] equed, double* s, double* b,
            int ldb, double* x, int ldx,
            double* rcond, double* rpvgrw, double* berr,
            int n_err_bnds, double* err_bnds_norm,
            double* err_bnds_comp, int nparams,
            double* aparams, double* work,
            int* iwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dpotrf")]
        public static extern int potrf(Layout layout, UpLoChar uplo, int n, double* a,
            int lda);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dpotrf2")]
        public static extern int potrf2(Layout layout, UpLoChar uplo, int n, double* a,
            int lda);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dpotri")]
        public static extern int potri(Layout layout, UpLoChar uplo, int n, double* a,
            int lda);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dpotrs")]
        public static extern int potrs(Layout layout, UpLoChar uplo, int n,
            int nrhs, /* const */ [In] double* a, int lda,
            double* b, int ldb);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dppcon")]
        public static extern int ppcon(Layout layout, UpLoChar uplo, int n,
            /* const */ [In] double* ap, double anorm, double* rcond);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dppcon_work")]
        public static extern int ppcon(Layout layout, UpLoChar uplo, int n,
            /* const */ [In] double* ap, double anorm, double* rcond,
            double* work, int* iwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dppequ")]
        public static extern int ppequ(Layout layout, UpLoChar uplo, int n,
            /* const */ [In] double* ap, double* s, double* scond,
            double* amax);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dpprfs")]
        public static extern int pprfs(Layout layout, UpLoChar uplo, int n,
            int nrhs, /* const */ [In] double* ap, /* const */ [In] double* afp,
            /* const */ [In] double* b, int ldb, double* x,
            int ldx, double* ferr, double* berr);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dpprfs_work")]
        public static extern int pprfs(Layout layout, UpLoChar uplo, int n,
            int nrhs, /* const */ [In] double* ap,
            /* const */ [In] double* afp, /* const */ [In] double* b,
            int ldb, double* x, int ldx,
            double* ferr, double* berr, double* work,
            int* iwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dppsv")]
        public static extern int ppsv(Layout layout, UpLoChar uplo, int n,
            int nrhs, double* ap, double* b,
            int ldb);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dppsvx")]
        public static extern int ppsvx(Layout layout, char fact, UpLoChar uplo, int n,
            int nrhs, double* ap, double* afp,
            char[] equed, double* s, double* b, int ldb,
            double* x, int ldx, double* rcond,
            double* ferr, double* berr);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dppsvx_work")]
        public static extern int ppsvx(Layout layout, char fact, UpLoChar uplo,
            int n, int nrhs, double* ap,
            double* afp, char[] equed, double* s, double* b,
            int ldb, double* x, int ldx,
            double* rcond, double* ferr, double* berr,
            double* work, int* iwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dpptrf")]
        public static extern int pptrf(Layout layout, UpLoChar uplo, int n,
            double* ap);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dpptri")]
        public static extern int pptri(Layout layout, UpLoChar uplo, int n,
            double* ap);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dpptrs")]
        public static extern int pptrs(Layout layout, UpLoChar uplo, int n,
            int nrhs, /* const */ [In] double* ap, double* b,
            int ldb);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dpstrf")]
        public static extern int pstrf(Layout layout, UpLoChar uplo, int n, double* a,
            int lda, int* piv, ref int rank,
            double tol);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dpstrf_work")]
        public static extern int pstrf(Layout layout, UpLoChar uplo, int n,
            double* a, int lda, int* piv,
            ref int rank, double tol, double* work);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dptcon")]
        public static extern int ptcon(int n, /* const */ [In] double* d, /* const */ [In] double* e,
            double anorm, double* rcond);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dptcon_work")]
        public static extern int ptcon(int n, /* const */ [In] double* d, /* const */ [In] double* e,
            double anorm, double* rcond, double* work);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dpteqr")]
        public static extern int pteqr(Layout layout, char compz, int n,
            double* d, double* e, double* z, int ldz);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dpteqr_work")]
        public static extern int pteqr(Layout layout, char compz, int n,
            double* d, double* e, double* z, int ldz,
            double* work);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dptrfs")]
        public static extern int ptrfs(Layout layout, int n, int nrhs,
            /* const */ [In] double* d, /* const */ [In] double* e, /* const */ [In] double* df,
            /* const */ [In] double* ef, /* const */ [In] double* b, int ldb,
            double* x, int ldx, double* ferr,
            double* berr);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dptrfs_work")]
        public static extern int ptrfs(Layout layout, int n, int nrhs,
            /* const */ [In] double* d, /* const */ [In] double* e,
            /* const */ [In] double* df, /* const */ [In] double* ef,
            /* const */ [In] double* b, int ldb, double* x,
            int ldx, double* ferr, double* berr,
            double* work);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dptsv")]
        public static extern int ptsv(Layout layout, int n, int nrhs,
            double* d, double* e, double* b, int ldb);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dptsvx")]
        public static extern int ptsvx(Layout layout, char fact, int n,
            int nrhs, /* const */ [In] double* d, /* const */ [In] double* e,
            double* df, double* ef, /* const */ [In] double* b,
            int ldb, double* x, int ldx,
            double* rcond, double* ferr, double* berr);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dptsvx_work")]
        public static extern int ptsvx(Layout layout, char fact, int n,
            int nrhs, /* const */ [In] double* d,
            /* const */ [In] double* e, double* df, double* ef,
            /* const */ [In] double* b, int ldb, double* x,
            int ldx, double* rcond, double* ferr,
            double* berr, double* work);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dpttrf")]
        public static extern int pttrf(int n, double* d, double* e);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dpttrs")]
        public static extern int pttrs(Layout layout, int n, int nrhs,
            /* const */ [In] double* d, /* const */ [In] double* e, double* b,
            int ldb);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dsbev")]
        public static extern int sbev(Layout layout, char jobz, UpLoChar uplo, int n,
            int kd, double* ab, int ldab, double* w,
            double* z, int ldz);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dsbev_work")]
        public static extern int sbev(Layout layout, char jobz, UpLoChar uplo,
            int n, int kd, double* ab,
            int ldab, double* w, double* z,
            int ldz, double* work);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dsbevd")]
        public static extern int sbevd(Layout layout, char jobz, UpLoChar uplo, int n,
            int kd, double* ab, int ldab,
            double* w, double* z, int ldz);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dsbevd_work")]
        public static extern int sbevd(Layout layout, char jobz, UpLoChar uplo,
            int n, int kd, double* ab,
            int ldab, double* w, double* z,
            int ldz, double* work, int lwork,
            int* iwork, int liwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dsbevx")]
        public static extern int sbevx(Layout layout, char jobz, char range, UpLoChar uplo,
            int n, int kd, double* ab,
            int ldab, double* q, int ldq,
            double vl, double vu, int il, int iu,
            double abstol, int* m, double* w, double* z,
            int ldz, int* ifail);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dsbevx_work")]
        public static extern int sbevx(Layout layout, char jobz, char range,
            UpLoChar uplo, int n, int kd,
            double* ab, int ldab, double* q,
            int ldq, double vl, double vu,
            int il, int iu, double abstol,
            int* m, double* w, double* z,
            int ldz, double* work, int* iwork,
            int* ifail);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dsbgst")]
        public static extern int sbgst(Layout layout, char vect, UpLoChar uplo, int n,
            int ka, int kb, double* ab,
            int ldab, /* const */ [In] double* bb, int ldbb,
            double* x, int ldx);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dsbgst_work")]
        public static extern int sbgst(Layout layout, char vect, UpLoChar uplo,
            int n, int ka, int kb,
            double* ab, int ldab, /* const */ [In] double* bb,
            int ldbb, double* x, int ldx,
            double* work);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dsbgv")]
        public static extern int sbgv(Layout layout, char jobz, UpLoChar uplo, int n,
            int ka, int kb, double* ab,
            int ldab, double* bb, int ldbb,
            double* w, double* z, int ldz);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dsbgv_work")]
        public static extern int sbgv(Layout layout, char jobz, UpLoChar uplo,
            int n, int ka, int kb,
            double* ab, int ldab, double* bb,
            int ldbb, double* w, double* z,
            int ldz, double* work);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dsbgvd")]
        public static extern int sbgvd(Layout layout, char jobz, UpLoChar uplo, int n,
            int ka, int kb, double* ab,
            int ldab, double* bb, int ldbb,
            double* w, double* z, int ldz);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dsbgvd_work")]
        public static extern int sbgvd(Layout layout, char jobz, UpLoChar uplo,
            int n, int ka, int kb,
            double* ab, int ldab, double* bb,
            int ldbb, double* w, double* z,
            int ldz, double* work, int lwork,
            int* iwork, int liwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dsbgvx")]
        public static extern int sbgvx(Layout layout, char jobz, char range, UpLoChar uplo,
            int n, int ka, int kb,
            double* ab, int ldab, double* bb,
            int ldbb, double* q, int ldq,
            double vl, double vu, int il, int iu,
            double abstol, int* m, double* w, double* z,
            int ldz, int* ifail);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dsbgvx_work")]
        public static extern int sbgvx(Layout layout, char jobz, char range,
            UpLoChar uplo, int n, int ka,
            int kb, double* ab, int ldab,
            double* bb, int ldbb, double* q,
            int ldq, double vl, double vu,
            int il, int iu, double abstol,
            int* m, double* w, double* z,
            int ldz, double* work, int* iwork,
            int* ifail);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dsbtrd")]
        public static extern int sbtrd(Layout layout, char vect, UpLoChar uplo, int n,
            int kd, double* ab, int ldab,
            double* d, double* e, double* q, int ldq);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dsbtrd_work")]
        public static extern int sbtrd(Layout layout, char vect, UpLoChar uplo,
            int n, int kd, double* ab,
            int ldab, double* d, double* e,
            double* q, int ldq, double* work);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dsfrk")]
        public static extern int sfrk(Layout layout, TransChar transr, UpLoChar uplo, TransChar trans,
            int n, int k, double alpha,
            /* const */ [In] double* a, int lda, double beta,
            double* c);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dsgesv")]
        public static extern int sgesv(Layout layout, int n, int nrhs,
            double* a, int lda, int* ipiv,
            double* b, int ldb, double* x, int ldx,
            int* iter);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dsgesv_work")]
        public static extern int sgesv(Layout layout, int n, int nrhs,
            double* a, int lda, int* ipiv,
            double* b, int ldb, double* x,
            int ldx, double* work, float* swork,
            int* iter);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dspcon")]
        public static extern int spcon(Layout layout, UpLoChar uplo, int n,
            /* const */ [In] double* ap, int* ipiv,
            double anorm, double* rcond);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dspcon_work")]
        public static extern int spcon(Layout layout, UpLoChar uplo, int n,
            /* const */ [In] double* ap, int* ipiv,
            double anorm, double* rcond, double* work,
            int* iwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dspev")]
        public static extern int spev(Layout layout, char jobz, UpLoChar uplo, int n,
            double* ap, double* w, double* z, int ldz);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dspev_work")]
        public static extern int spev(Layout layout, char jobz, UpLoChar uplo,
            int n, double* ap, double* w, double* z,
            int ldz, double* work);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dspevd")]
        public static extern int spevd(Layout layout, char jobz, UpLoChar uplo, int n,
            double* ap, double* w, double* z, int ldz);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dspevd_work")]
        public static extern int spevd(Layout layout, char jobz, UpLoChar uplo,
            int n, double* ap, double* w, double* z,
            int ldz, double* work, int lwork,
            int* iwork, int liwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dspevx")]
        public static extern int spevx(Layout layout, char jobz, char range, UpLoChar uplo,
            int n, double* ap, double vl, double vu,
            int il, int iu, double abstol,
            int* m, double* w, double* z, int ldz,
            int* ifail);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dspevx_work")]
        public static extern int spevx(Layout layout, char jobz, char range,
            UpLoChar uplo, int n, double* ap, double vl,
            double vu, int il, int iu,
            double abstol, int* m, double* w,
            double* z, int ldz, double* work,
            int* iwork, int* ifail);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dspgst")]
        public static extern int spgst(Layout layout, int itype, UpLoChar uplo,
            int n, double* ap, double* bp);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dspgv")]
        public static extern int spgv(Layout layout, int itype, char jobz,
            UpLoChar uplo, int n, double* ap, double* bp,
            double* w, double* z, int ldz);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dspgv_work")]
        public static extern int spgv(Layout layout, int itype, char jobz,
            UpLoChar uplo, int n, double* ap, double* bp,
            double* w, double* z, int ldz,
            double* work);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dspgvd")]
        public static extern int spgvd(Layout layout, int itype, char jobz,
            UpLoChar uplo, int n, double* ap, double* bp,
            double* w, double* z, int ldz);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dspgvd_work")]
        public static extern int spgvd(Layout layout, int itype, char jobz,
            UpLoChar uplo, int n, double* ap, double* bp,
            double* w, double* z, int ldz,
            double* work, int lwork,
            int* iwork, int liwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dspgvx")]
        public static extern int spgvx(Layout layout, int itype, char jobz,
            char range, UpLoChar uplo, int n, double* ap,
            double* bp, double vl, double vu, int il,
            int iu, double abstol, int* m,
            double* w, double* z, int ldz,
            int* ifail);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dspgvx_work")]
        public static extern int spgvx(Layout layout, int itype, char jobz,
            char range, UpLoChar uplo, int n, double* ap,
            double* bp, double vl, double vu, int il,
            int iu, double abstol, int* m,
            double* w, double* z, int ldz,
            double* work, int* iwork,
            int* ifail);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dsposv")]
        public static extern int sposv(Layout layout, UpLoChar uplo, int n,
            int nrhs, double* a, int lda,
            double* b, int ldb, double* x, int ldx,
            int* iter);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dsposv_work")]
        public static extern int sposv(Layout layout, UpLoChar uplo, int n,
            int nrhs, double* a, int lda,
            double* b, int ldb, double* x,
            int ldx, double* work, float* swork,
            int* iter);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dsprfs")]
        public static extern int sprfs(Layout layout, UpLoChar uplo, int n,
            int nrhs, /* const */ [In] double* ap, /* const */ [In] double* afp,
            int* ipiv, /* const */ [In] double* b,
            int ldb, double* x, int ldx,
            double* ferr, double* berr);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dsprfs_work")]
        public static extern int sprfs(Layout layout, UpLoChar uplo, int n,
            int nrhs, /* const */ [In] double* ap,
            /* const */ [In] double* afp, int* ipiv,
            /* const */ [In] double* b, int ldb, double* x,
            int ldx, double* ferr, double* berr,
            double* work, int* iwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dspsv")]
        public static extern int spsv(Layout layout, UpLoChar uplo, int n,
            int nrhs, double* ap, int* ipiv,
            double* b, int ldb);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dspsvx")]
        public static extern int spsvx(Layout layout, char fact, UpLoChar uplo, int n,
            int nrhs, /* const */ [In] double* ap, double* afp,
            int* ipiv, /* const */ [In] double* b, int ldb,
            double* x, int ldx, double* rcond,
            double* ferr, double* berr);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dspsvx_work")]
        public static extern int spsvx(Layout layout, char fact, UpLoChar uplo,
            int n, int nrhs, /* const */ [In] double* ap,
            double* afp, int* ipiv, /* const */ [In] double* b,
            int ldb, double* x, int ldx,
            double* rcond, double* ferr, double* berr,
            double* work, int* iwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dsptrd")]
        public static extern int sptrd(Layout layout, UpLoChar uplo, int n,
            double* ap, double* d, double* e, double* tau);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dsptrf")]
        public static extern int sptrf(Layout layout, UpLoChar uplo, int n,
            double* ap, int* ipiv);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dsptri")]
        public static extern int sptri(Layout layout, UpLoChar uplo, int n,
            double* ap, int* ipiv);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dsptri_work")]
        public static extern int sptri(Layout layout, UpLoChar uplo, int n,
            double* ap, int* ipiv,
            double* work);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dsptrs")]
        public static extern int sptrs(Layout layout, UpLoChar uplo, int n,
            int nrhs, /* const */ [In] double* ap,
            int* ipiv, double* b, int ldb);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dstebz")]
        public static extern int stebz(char range, char order, int n, double vl,
            double vu, int il, int iu,
            double abstol, /* const */ [In] double* d, /* const */ [In] double* e,
            int* m, int* nsplit, double* w,
            int* iblock, int* isplit);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dstebz_work")]
        public static extern int stebz(char range, char order, int n, double vl,
            double vu, int il, int iu,
            double abstol, /* const */ [In] double* d, /* const */ [In] double* e,
            int* m, int* nsplit, double* w,
            int* iblock, int* isplit,
            double* work, int* iwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dstedc")]
        public static extern int stedc(Layout layout, char compz, int n,
            double* d, double* e, double* z, int ldz);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dstedc_work")]
        public static extern int stedc(Layout layout, char compz, int n,
            double* d, double* e, double* z, int ldz,
            double* work, int lwork,
            int* iwork, int liwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dstegr")]
        public static extern int stegr(Layout layout, char jobz, char range,
            int n, double* d, double* e, double vl,
            double vu, int il, int iu,
            double abstol, int* m, double* w, double* z,
            int ldz, int* isuppz);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dstegr_work")]
        public static extern int stegr(Layout layout, char jobz, char range,
            int n, double* d, double* e, double vl,
            double vu, int il, int iu,
            double abstol, int* m, double* w,
            double* z, int ldz, int* isuppz,
            double* work, int lwork,
            int* iwork, int liwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dstein")]
        public static extern int stein(Layout layout, int n, /* const */ [In] double* d,
            /* const */ [In] double* e, int m, /* const */ [In] double* w,
            int* iblock, int* isplit,
            double* z, int ldz, int* ifailv);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dstein_work")]
        public static extern int stein(Layout layout, int n, /* const */ [In] double* d,
            /* const */ [In] double* e, int m, /* const */ [In] double* w,
            int* iblock,
            int* isplit, double* z,
            int ldz, double* work, int* iwork,
            int* ifailv);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dstemr")]
        public static extern int stemr(Layout layout, char jobz, char range,
            int n, double* d, double* e, double vl,
            double vu, int il, int iu,
            int* m, double* w, double* z, int ldz,
            int nzc, int* isuppz,
            int* tryrac);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dstemr_work")]
        public static extern int stemr(Layout layout, char jobz, char range,
            int n, double* d, double* e, double vl,
            double vu, int il, int iu,
            int* m, double* w, double* z,
            int ldz, int nzc,
            int* isuppz, int* tryrac,
            double* work, int lwork,
            int* iwork, int liwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dsteqr")]
        public static extern int steqr(Layout layout, char compz, int n,
            double* d, double* e, double* z, int ldz);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dsteqr_work")]
        public static extern int steqr(Layout layout, char compz, int n,
            double* d, double* e, double* z, int ldz,
            double* work);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dsterf")]
        public static extern int sterf(int n, double* d, double* e);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dstev")]
        public static extern int stev(Layout layout, char jobz, int n, double* d,
            double* e, double* z, int ldz);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dstev_work")]
        public static extern int stev(Layout layout, char jobz, int n,
            double* d, double* e, double* z, int ldz,
            double* work);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dstevd")]
        public static extern int stevd(Layout layout, char jobz, int n, double* d,
            double* e, double* z, int ldz);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dstevd_work")]
        public static extern int stevd(Layout layout, char jobz, int n,
            double* d, double* e, double* z, int ldz,
            double* work, int lwork,
            int* iwork, int liwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dstevr")]
        public static extern int stevr(Layout layout, char jobz, char range,
            int n, double* d, double* e, double vl,
            double vu, int il, int iu,
            double abstol, int* m, double* w, double* z,
            int ldz, int* isuppz);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dstevr_work")]
        public static extern int stevr(Layout layout, char jobz, char range,
            int n, double* d, double* e, double vl,
            double vu, int il, int iu,
            double abstol, int* m, double* w,
            double* z, int ldz, int* isuppz,
            double* work, int lwork,
            int* iwork, int liwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dstevx")]
        public static extern int stevx(Layout layout, char jobz, char range,
            int n, double* d, double* e, double vl,
            double vu, int il, int iu,
            double abstol, int* m, double* w, double* z,
            int ldz, int* ifail);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dstevx_work")]
        public static extern int stevx(Layout layout, char jobz, char range,
            int n, double* d, double* e, double vl,
            double vu, int il, int iu,
            double abstol, int* m, double* w,
            double* z, int ldz, double* work,
            int* iwork, int* ifail);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dsycon")]
        public static extern int sycon(Layout layout, UpLoChar uplo, int n,
            /* const */ [In] double* a, int lda,
            int* ipiv, double anorm, double* rcond);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dsycon_work")]
        public static extern int sycon(Layout layout, UpLoChar uplo, int n,
            /* const */ [In] double* a, int lda,
            int* ipiv, double anorm,
            double* rcond, double* work, int* iwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dsyconv")]
        public static extern int syconv(Layout layout, UpLoChar uplo, char way, int n,
            double* a, int lda, int* ipiv,
            double* e);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dsyequb")]
        public static extern int syequb(Layout layout, UpLoChar uplo, int n,
            /* const */ [In] double* a, int lda, double* s,
            double* scond, double* amax);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dsyequb_work")]
        public static extern int syequb(Layout layout, UpLoChar uplo, int n,
            /* const */ [In] double* a, int lda, double* s,
            double* scond, double* amax, double* work);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dsyev")]
        public static extern int syev(Layout layout, char jobz, UpLoChar uplo, int n,
            double* a, int lda, double* w);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dsyev_work")]
        public static extern int syev(Layout layout, char jobz, UpLoChar uplo,
            int n, double* a, int lda,
            double* w, double* work, int lwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dsyevd")]
        public static extern int syevd(Layout layout, char jobz, UpLoChar uplo, int n,
            double* a, int lda, double* w);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dsyevd_work")]
        public static extern int syevd(Layout layout, char jobz, UpLoChar uplo,
            int n, double* a, int lda,
            double* w, double* work, int lwork,
            int* iwork, int liwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dsyevr")]
        public static extern int syevr(Layout layout, char jobz, char range, UpLoChar uplo,
            int n, double* a, int lda, double vl,
            double vu, int il, int iu,
            double abstol, out int m, double* w, double* z,
            int ldz, int* isuppz);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dsyevr_work")]
        public static extern int syevr(Layout layout, char jobz, char range,
            UpLoChar uplo, int n, double* a,
            int lda, double vl, double vu,
            int il, int iu, double abstol,
            out int m, double* w, double* z,
            int ldz, int* isuppz,
            double* work, int lwork,
            int* iwork, int liwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dsyevx")]
        public static extern int syevx(Layout layout, char jobz, char range, UpLoChar uplo,
            int n, double* a, int lda, double vl,
            double vu, int il, int iu,
            double abstol, int* m, double* w, double* z,
            int ldz, int* ifail);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dsyevx_work")]
        public static extern int syevx(Layout layout, char jobz, char range,
            UpLoChar uplo, int n, double* a,
            int lda, double vl, double vu,
            int il, int iu, double abstol,
            int* m, double* w, double* z,
            int ldz, double* work, int lwork,
            int* iwork, int* ifail);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dsygst")]
        public static extern int sygst(Layout layout, int itype, UpLoChar uplo,
            int n, double* a, int lda,
            /* const */ [In] double* b, int ldb);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dsygv")]
        public static extern int sygv(Layout layout, int itype, char jobz,
            UpLoChar uplo, int n, double* a, int lda,
            double* b, int ldb, double* w);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dsygv_work")]
        public static extern int sygv(Layout layout, int itype, char jobz,
            UpLoChar uplo, int n, double* a,
            int lda, double* b, int ldb,
            double* w, double* work, int lwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dsygvd")]
        public static extern int sygvd(Layout layout, int itype, char jobz,
            UpLoChar uplo, int n, double* a, int lda,
            double* b, int ldb, double* w);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dsygvd_work")]
        public static extern int sygvd(Layout layout, int itype, char jobz,
            UpLoChar uplo, int n, double* a,
            int lda, double* b, int ldb,
            double* w, double* work, int lwork,
            int* iwork, int liwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dsygvx")]
        public static extern int sygvx(Layout layout, int itype, char jobz,
            char range, UpLoChar uplo, int n, double* a,
            int lda, double* b, int ldb, double vl,
            double vu, int il, int iu,
            double abstol, int* m, double* w, double* z,
            int ldz, int* ifail);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dsygvx_work")]
        public static extern int sygvx(Layout layout, int itype, char jobz,
            char range, UpLoChar uplo, int n, double* a,
            int lda, double* b, int ldb,
            double vl, double vu, int il,
            int iu, double abstol, int* m,
            double* w, double* z, int ldz,
            double* work, int lwork,
            int* iwork, int* ifail);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dsyrfs")]
        public static extern int syrfs(Layout layout, UpLoChar uplo, int n,
            int nrhs, /* const */ [In] double* a, int lda,
            /* const */ [In] double* af, int ldaf,
            int* ipiv, /* const */ [In] double* b,
            int ldb, double* x, int ldx,
            double* ferr, double* berr);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dsyrfs_work")]
        public static extern int syrfs(Layout layout, UpLoChar uplo, int n,
            int nrhs, /* const */ [In] double* a,
            int lda, /* const */ [In] double* af,
            int ldaf, int* ipiv,
            /* const */ [In] double* b, int ldb, double* x,
            int ldx, double* ferr, double* berr,
            double* work, int* iwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dsyrfsx")]
        public static extern int syrfsx(Layout layout, UpLoChar uplo, char equed,
            int n, int nrhs, /* const */ [In] double* a,
            int lda, /* const */ [In] double* af, int ldaf,
            int* ipiv, /* const */ [In] double* s,
            /* const */ [In] double* b, int ldb, double* x,
            int ldx, double* rcond, double* berr,
            int n_err_bnds, double* err_bnds_norm,
            double* err_bnds_comp, int nparams,
            double* aparams);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dsyrfsx_work")]
        public static extern int syrfsx(Layout layout, UpLoChar uplo, char equed,
            int n, int nrhs, /* const */ [In] double* a,
            int lda, /* const */ [In] double* af,
            int ldaf, int* ipiv,
            /* const */ [In] double* s, /* const */ [In] double* b,
            int ldb, double* x, int ldx,
            double* rcond, double* berr,
            int n_err_bnds, double* err_bnds_norm,
            double* err_bnds_comp, int nparams,
            double* aparams, double* work,
            int* iwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dsysv")]
        public static extern int sysv(Layout layout, UpLoChar uplo, int n,
            int nrhs, double* a, int lda,
            int* ipiv, double* b, int ldb);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dsysv_rook")]
        public static extern int sysv_rook(Layout layout, UpLoChar uplo, int n,
            int nrhs, double* a, int lda,
            int* ipiv, double* b, int ldb);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dsysv_rook_work")]
        public static extern int sysv_rook(Layout layout, UpLoChar uplo, int n,
            int nrhs, double* a, int lda,
            int* ipiv, double* b, int ldb,
            double* work, int lwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dsysv_work")]
        public static extern int sysv(Layout layout, UpLoChar uplo, int n,
            int nrhs, double* a, int lda,
            int* ipiv, double* b, int ldb,
            double* work, int lwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dsysvx")]
        public static extern int sysvx(Layout layout, char fact, UpLoChar uplo, int n,
            int nrhs, /* const */ [In] double* a, int lda,
            double* af, int ldaf, int* ipiv,
            /* const */ [In] double* b, int ldb, double* x,
            int ldx, double* rcond, double* ferr,
            double* berr);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dsysvx_work")]
        public static extern int sysvx(Layout layout, char fact, UpLoChar uplo,
            int n, int nrhs, /* const */ [In] double* a,
            int lda, double* af, int ldaf,
            int* ipiv, /* const */ [In] double* b,
            int ldb, double* x, int ldx,
            double* rcond, double* ferr, double* berr,
            double* work, int lwork,
            int* iwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dsysvxx")]
        public static extern int sysvxx(Layout layout, char fact, UpLoChar uplo,
            int n, int nrhs, double* a,
            int lda, double* af, int ldaf,
            int* ipiv, char[] equed, double* s, double* b,
            int ldb, double* x, int ldx,
            double* rcond, double* rpvgrw, double* berr,
            int n_err_bnds, double* err_bnds_norm,
            double* err_bnds_comp, int nparams,
            double* aparams);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dsysvxx_work")]
        public static extern int sysvxx(Layout layout, char fact, UpLoChar uplo,
            int n, int nrhs, double* a,
            int lda, double* af, int ldaf,
            int* ipiv, char[] equed, double* s,
            double* b, int ldb, double* x,
            int ldx, double* rcond, double* rpvgrw,
            double* berr, int n_err_bnds,
            double* err_bnds_norm, double* err_bnds_comp,
            int nparams, double* aparams,
            double* work, int* iwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dsyswapr")]
        public static extern int syswapr(Layout layout, UpLoChar uplo, int n,
            double* a, int lda, int i1, int i2);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dsytrd")]
        public static extern int sytrd(Layout layout, UpLoChar uplo, int n, double* a,
            int lda, double* d, double* e, double* tau);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dsytrd_work")]
        public static extern int sytrd(Layout layout, UpLoChar uplo, int n,
            double* a, int lda, double* d, double* e,
            double* tau, double* work, int lwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dsytrf")]
        public static extern int sytrf(Layout layout, UpLoChar uplo, int n, double* a,
            int lda, int* ipiv);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dsytrf_rook")]
        public static extern int sytrf_rook(Layout layout, UpLoChar uplo, int n, double* a,
            int lda, int* ipiv);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dsytrf_rook_work")]
        public static extern int sytrf_rook(Layout layout, UpLoChar uplo, int n,
            double* a, int lda, int* ipiv,
            double* work, int lwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dsytrf_work")]
        public static extern int sytrf(Layout layout, UpLoChar uplo, int n,
            double* a, int lda, int* ipiv,
            double* work, int lwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dsytri")]
        public static extern int sytri(Layout layout, UpLoChar uplo, int n, double* a,
            int lda, int* ipiv);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dsytri2")]
        public static extern int sytri2(Layout layout, UpLoChar uplo, int n,
            double* a, int lda, int* ipiv);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dsytri2_work")]
        public static extern int sytri2(Layout layout, UpLoChar uplo, int n,
            double* a, int lda,
            int* ipiv,
            double* work, int lwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dsytri2x")]
        public static extern int sytri2x(Layout layout, UpLoChar uplo, int n,
            double* a, int lda, int* ipiv,
            int nb);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dsytri2x_work")]
        public static extern int sytri2x(Layout layout, UpLoChar uplo, int n,
            double* a, int lda,
            int* ipiv, double* work,
            int nb);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dsytri_work")]
        public static extern int sytri(Layout layout, UpLoChar uplo, int n,
            double* a, int lda,
            int* ipiv, double* work);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dsytrs")]
        public static extern int sytrs(Layout layout, UpLoChar uplo, int n,
            int nrhs, /* const */ [In] double* a, int lda,
            int* ipiv, double* b, int ldb);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dsytrs2")]
        public static extern int sytrs2(Layout layout, UpLoChar uplo, int n,
            int nrhs, /* const */ [In] double* a, int lda,
            int* ipiv, double* b, int ldb);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dsytrs2_work")]
        public static extern int sytrs2(Layout layout, UpLoChar uplo, int n,
            int nrhs, /* const */ [In] double* a,
            int lda, int* ipiv,
            double* b, int ldb, double* work);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dsytrs_rook")]
        public static extern int sytrs_rook(Layout layout, UpLoChar uplo, int n,
            int nrhs, /* const */ [In] double* a, int lda,
            int* ipiv, double* b, int ldb);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dtbcon")]
        public static extern int tbcon(Layout layout, Norm norm, UpLoChar uplo, DiagChar diag,
            int n, int kd, /* const */ [In] double* ab,
            int ldab, double* rcond);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dtbcon_work")]
        public static extern int tbcon(Layout layout, Norm norm, UpLoChar uplo,
            DiagChar diag, int n, int kd,
            /* const */ [In] double* ab, int ldab,
            double* rcond, double* work, int* iwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dtbrfs")]
        public static extern int tbrfs(Layout layout, UpLoChar uplo, TransChar trans, DiagChar diag,
            int n, int kd, int nrhs,
            /* const */ [In] double* ab, int ldab, /* const */ [In] double* b,
            int ldb, /* const */ [In] double* x, int ldx,
            double* ferr, double* berr);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dtbrfs_work")]
        public static extern int tbrfs(Layout layout, UpLoChar uplo, TransChar trans,
            DiagChar diag, int n, int kd,
            int nrhs, /* const */ [In] double* ab,
            int ldab, /* const */ [In] double* b,
            int ldb, /* const */ [In] double* x, int ldx,
            double* ferr, double* berr, double* work,
            int* iwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dtbtrs")]
        public static extern int tbtrs(Layout layout, UpLoChar uplo, TransChar trans, DiagChar diag,
            int n, int kd, int nrhs,
            /* const */ [In] double* ab, int ldab, double* b,
            int ldb);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dtfsm")]
        public static extern int tfsm(Layout layout, TransChar transr, char side, UpLoChar uplo,
            TransChar trans, DiagChar diag, int m, int n,
            double alpha, /* const */ [In] double* a, double* b,
            int ldb);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dtftri")]
        public static extern int tftri(Layout layout, TransChar transr, UpLoChar uplo, DiagChar diag,
            int n, double* a);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dtfttp")]
        public static extern int tfttp(Layout layout, TransChar transr, UpLoChar uplo,
            int n, /* const */ [In] double* arf, double* ap);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dtfttr")]
        public static extern int tfttr(Layout layout, TransChar transr, UpLoChar uplo,
            int n, /* const */ [In] double* arf, double* a,
            int lda);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dtgevc")]
        public static extern int tgevc(Layout layout, char side, char howmny,
            int* select, int n,
            /* const */ [In] double* s, int lds, /* const */ [In] double* p,
            int ldp, double* vl, int ldvl,
            double* vr, int ldvr, int mm,
            int* m);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dtgevc_work")]
        public static extern int tgevc(Layout layout, char side, char howmny,
            int* select, int n,
            /* const */ [In] double* s, int lds,
            /* const */ [In] double* p, int ldp, double* vl,
            int ldvl, double* vr, int ldvr,
            int mm, int* m, double* work);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dtgexc")]
        public static extern int tgexc(Layout layout, int wantq,
            int wantz, int n, double* a,
            int lda, double* b, int ldb, double* q,
            int ldq, double* z, int ldz,
            int* ifst, int* ilst);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dtgexc_work")]
        public static extern int tgexc(Layout layout, int wantq,
            int wantz, int n, double* a,
            int lda, double* b, int ldb,
            double* q, int ldq, double* z,
            int ldz, int* ifst,
            int* ilst, double* work,
            int lwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dtgsen")]
        public static extern int tgsen(Layout layout, int ijob,
            int wantq, int wantz,
            int* select, int n,
            double* a, int lda, double* b, int ldb,
            double* alphar, double* alphai, double* beta,
            double* q, int ldq, double* z, int ldz,
            int* m, double* pl, double* pr, double* dif);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dtgsen_work")]
        public static extern int tgsen(Layout layout, int ijob,
            int wantq, int wantz,
            int* select, int n,
            double* a, int lda, double* b,
            int ldb, double* alphar, double* alphai,
            double* beta, double* q, int ldq,
            double* z, int ldz, int* m,
            double* pl, double* pr, double* dif,
            double* work, int lwork,
            int* iwork, int liwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dtgsja")]
        public static extern int tgsja(Layout layout, char jobu, char jobv, char jobq,
            int m, int p, int n,
            int k, int l, double* a,
            int lda, double* b, int ldb,
            double tola, double tolb, double* alpha,
            double* beta, double* u, int ldu, double* v,
            int ldv, double* q, int ldq,
            int* ncycle);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dtgsja_work")]
        public static extern int tgsja(Layout layout, char jobu, char jobv,
            char jobq, int m, int p,
            int n, int k, int l,
            double* a, int lda, double* b,
            int ldb, double tola, double tolb,
            double* alpha, double* beta, double* u,
            int ldu, double* v, int ldv,
            double* q, int ldq, double* work,
            int* ncycle);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dtgsna")]
        public static extern int tgsna(Layout layout, char job, char howmny,
            int* select, int n,
            /* const */ [In] double* a, int lda, /* const */ [In] double* b,
            int ldb, /* const */ [In] double* vl, int ldvl,
            /* const */ [In] double* vr, int ldvr, double* s,
            double* dif, int mm, int* m);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dtgsna_work")]
        public static extern int tgsna(Layout layout, char job, char howmny,
            int* select, int n,
            /* const */ [In] double* a, int lda,
            /* const */ [In] double* b, int ldb,
            /* const */ [In] double* vl, int ldvl,
            /* const */ [In] double* vr, int ldvr, double* s,
            double* dif, int mm, int* m,
            double* work, int lwork,
            int* iwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dtgsyl")]
        public static extern int tgsyl(Layout layout, TransChar trans, int ijob,
            int m, int n, /* const */ [In] double* a,
            int lda, /* const */ [In] double* b, int ldb,
            double* c, int ldc, /* const */ [In] double* d,
            int ldd, /* const */ [In] double* e, int lde,
            double* f, int ldf, double* scale,
            double* dif);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dtgsyl_work")]
        public static extern int tgsyl(Layout layout, TransChar trans, int ijob,
            int m, int n, /* const */ [In] double* a,
            int lda, /* const */ [In] double* b, int ldb,
            double* c, int ldc, /* const */ [In] double* d,
            int ldd, /* const */ [In] double* e, int lde,
            double* f, int ldf, double* scale,
            double* dif, double* work, int lwork,
            int* iwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dtpcon")]
        public static extern int tpcon(Layout layout, Norm norm, UpLoChar uplo, DiagChar diag,
            int n, /* const */ [In] double* ap, double* rcond);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dtpcon_work")]
        public static extern int tpcon(Layout layout, Norm norm, UpLoChar uplo,
            DiagChar diag, int n, /* const */ [In] double* ap,
            double* rcond, double* work, int* iwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dtpmqrt")]
        public static extern int tpmqrt(Layout layout, char side, TransChar trans,
            int m, int n, int k,
            int l, int nb, /* const */ [In] double* v,
            int ldv, /* const */ [In] double* t, int ldt,
            double* a, int lda, double* b,
            int ldb);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dtpmqrt_work")]
        public static extern int tpmqrt(Layout layout, char side, TransChar trans,
            int m, int n, int k,
            int l, int nb, /* const */ [In] double* v,
            int ldv, /* const */ [In] double* t,
            int ldt, double* a, int lda,
            double* b, int ldb, double* work);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dtpqrt")]
        public static extern int tpqrt(Layout layout, int m, int n,
            int l, int nb, double* a,
            int lda, double* b, int ldb, double* t,
            int ldt);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dtpqrt2")]
        public static extern int tpqrt2(Layout layout, int m, int n,
            int l, double* a, int lda, double* b,
            int ldb, double* t, int ldt);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dtpqrt_work")]
        public static extern int tpqrt(Layout layout, int m, int n,
            int l, int nb, double* a,
            int lda, double* b, int ldb,
            double* t, int ldt, double* work);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dtprfb")]
        public static extern int tprfb(Layout layout, char side, TransChar trans, char direct,
            char storev, int m, int n,
            int k, int l, /* const */ [In] double* v,
            int ldv, /* const */ [In] double* t, int ldt,
            double* a, int lda, double* b, int ldb);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dtprfb_work")]
        public static extern int tprfb(Layout layout, char side, TransChar trans,
            char direct, char storev, int m,
            int n, int k, int l,
            /* const */ [In] double* v, int ldv,
            /* const */ [In] double* t, int ldt, double* a,
            int lda, double* b, int ldb,
            double* work, int ldwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dtprfs")]
        public static extern int tprfs(Layout layout, UpLoChar uplo, TransChar trans, DiagChar diag,
            int n, int nrhs, /* const */ [In] double* ap,
            /* const */ [In] double* b, int ldb, /* const */ [In] double* x,
            int ldx, double* ferr, double* berr);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dtprfs_work")]
        public static extern int tprfs(Layout layout, UpLoChar uplo, TransChar trans,
            DiagChar diag, int n, int nrhs,
            /* const */ [In] double* ap, /* const */ [In] double* b,
            int ldb, /* const */ [In] double* x, int ldx,
            double* ferr, double* berr, double* work,
            int* iwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dtptri")]
        public static extern int tptri(Layout layout, UpLoChar uplo, DiagChar diag, int n,
            double* ap);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dtptrs")]
        public static extern int tptrs(Layout layout, UpLoChar uplo, TransChar trans, DiagChar diag,
            int n, int nrhs, /* const */ [In] double* ap,
            double* b, int ldb);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dtpttf")]
        public static extern int tpttf(Layout layout, TransChar transr, UpLoChar uplo,
            int n, /* const */ [In] double* ap, double* arf);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dtpttr")]
        public static extern int tpttr(Layout layout, UpLoChar uplo, int n,
            /* const */ [In] double* ap, double* a, int lda);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dtrcon")]
        public static extern int trcon(Layout layout, Norm norm, UpLoChar uplo, DiagChar diag,
            int n, /* const */ [In] double* a, int lda,
            double* rcond);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dtrcon_work")]
        public static extern int trcon(Layout layout, Norm norm, UpLoChar uplo,
            DiagChar diag, int n, /* const */ [In] double* a,
            int lda, double* rcond, double* work,
            int* iwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dtrevc")]
        public static extern int trevc(Layout layout, char side, char howmny,
            int* select, int n,
            /* const */ [In] double* t, int ldt, double* vl,
            int ldvl, double* vr, int ldvr,
            int mm, int* m);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dtrevc_work")]
        public static extern int trevc(Layout layout, char side, char howmny,
            int* select, int n,
            /* const */ [In] double* t, int ldt, double* vl,
            int ldvl, double* vr, int ldvr,
            int mm, int* m, double* work);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dtrexc")]
        public static extern int trexc(Layout layout, char compq, int n,
            double* t, int ldt, double* q, int ldq,
            int* ifst, int* ilst);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dtrexc_work")]
        public static extern int trexc(Layout layout, char compq, int n,
            double* t, int ldt, double* q,
            int ldq, int* ifst,
            int* ilst, double* work);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dtrrfs")]
        public static extern int trrfs(Layout layout, UpLoChar uplo, TransChar trans, DiagChar diag,
            int n, int nrhs, /* const */ [In] double* a,
            int lda, /* const */ [In] double* b, int ldb,
            /* const */ [In] double* x, int ldx, double* ferr,
            double* berr);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dtrrfs_work")]
        public static extern int trrfs(Layout layout, UpLoChar uplo, TransChar trans,
            DiagChar diag, int n, int nrhs,
            /* const */ [In] double* a, int lda,
            /* const */ [In] double* b, int ldb,
            /* const */ [In] double* x, int ldx, double* ferr,
            double* berr, double* work, int* iwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dtrsen")]
        public static extern int trsen(Layout layout, char job, char compq,
            int* select, int n,
            double* t, int ldt, double* q, int ldq,
            double* wr, double* wi, int* m, double* s,
            double* sep);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dtrsen_work")]
        public static extern int trsen(Layout layout, char job, char compq,
            int* select, int n,
            double* t, int ldt, double* q,
            int ldq, double* wr, double* wi,
            int* m, double* s, double* sep,
            double* work, int lwork,
            int* iwork, int liwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dtrsna")]
        public static extern int trsna(Layout layout, char job, char howmny,
            int* select, int n,
            /* const */ [In] double* t, int ldt, /* const */ [In] double* vl,
            int ldvl, /* const */ [In] double* vr, int ldvr,
            double* s, double* sep, int mm,
            int* m);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dtrsna_work")]
        public static extern int trsna(Layout layout, char job, char howmny,
            int* select, int n,
            /* const */ [In] double* t, int ldt,
            /* const */ [In] double* vl, int ldvl,
            /* const */ [In] double* vr, int ldvr, double* s,
            double* sep, int mm, int* m,
            double* work, int ldwork,
            int* iwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dtrsyl")]
        public static extern int trsyl(Layout layout, char trana, char tranb,
            int isgn, int m, int n,
            /* const */ [In] double* a, int lda, /* const */ [In] double* b,
            int ldb, double* c, int ldc,
            double* scale);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dtrtri")]
        public static extern int trtri(Layout layout, UpLoChar uplo, DiagChar diag, int n,
            double* a, int lda);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dtrtrs")]
        public static extern int trtrs(Layout layout, UpLoChar uplo, TransChar trans, DiagChar diag,
            int n, int nrhs, /* const */ [In] double* a,
            int lda, double* b, int ldb);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dtrttf")]
        public static extern int trttf(Layout layout, TransChar transr, UpLoChar uplo,
            int n, /* const */ [In] double* a, int lda,
            double* arf);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dtrttp")]
        public static extern int trttp(Layout layout, UpLoChar uplo, int n,
            /* const */ [In] double* a, int lda, double* ap);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dtzrzf")]
        public static extern int tzrzf(Layout layout, int m, int n,
            double* a, int lda, double* tau);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dtzrzf_work")]
        public static extern int tzrzf(Layout layout, int m, int n,
            double* a, int lda, double* tau,
            double* work, int lwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_mkl_dgetrfnpi")]
        public static extern int getrfnpi(Layout layout, int m, int n,
            int nfact, double* a, int lda);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_mkl_dtppack")]
        public static extern int tppack(Layout layout, UpLoChar uplo, TransChar trans, int n,
            double* ap, int i, int j, int rows,
            int cols, double* a, int lda);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_mkl_dtpunpack")]
        public static extern int tpunpack(Layout layout, UpLoChar uplo, TransChar trans, int n,
            double* ap, int i, int j, int rows,
            int cols, double* a, int lda);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_mkl_sgetrfnpi")]
        public static extern int getrfnpi(Layout layout, int m, int n,
            int nfact, float* a, int lda);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_mkl_stppack")]
        public static extern int tppack(Layout layout, UpLoChar uplo, TransChar trans, int n,
            float* ap, int i, int j, int rows,
            int cols, float* a, int lda);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_mkl_stpunpack")]
        public static extern int tpunpack(Layout layout, UpLoChar uplo, TransChar trans, int n,
            float* ap, int i, int j, int rows,
            int cols, float* a, int lda);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sbbcsd")]
        public static extern int bbcsd(Layout layout, char jobu1, char jobu2,
            char jobv1t, char jobv2t, TransChar trans, int m,
            int p, int q, float* theta, float* phi,
            float* u1, int ldu1, float* u2,
            int ldu2, float* v1t, int ldv1t,
            float* v2t, int ldv2t, float* b11d,
            float* b11e, float* b12d, float* b12e, float* b21d,
            float* b21e, float* b22d, float* b22e);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sbbcsd_work")]
        public static extern int bbcsd(Layout layout, char jobu1, char jobu2,
            char jobv1t, char jobv2t, TransChar trans,
            int m, int p, int q,
            float* theta, float* phi, float* u1,
            int ldu1, float* u2, int ldu2,
            float* v1t, int ldv1t, float* v2t,
            int ldv2t, float* b11d, float* b11e,
            float* b12d, float* b12e, float* b21d,
            float* b21e, float* b22d, float* b22e,
            float* work, int lwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sbdsdc")]
        public static extern int bdsdc(Layout layout, UpLoChar uplo, char compq,
            int n, float* d, float* e, float* u,
            int ldu, float* vt, int ldvt, float* q,
            int* iq);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sbdsdc_work")]
        public static extern int bdsdc(Layout layout, UpLoChar uplo, char compq,
            int n, float* d, float* e, float* u,
            int ldu, float* vt, int ldvt,
            float* q, int* iq, float* work,
            int* iwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sbdsqr")]
        public static extern int bdsqr(Layout layout, UpLoChar uplo, int n,
            int ncvt, int nru, int ncc,
            float* d, float* e, float* vt, int ldvt,
            float* u, int ldu, float* c, int ldc);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sbdsqr_work")]
        public static extern int bdsqr(Layout layout, UpLoChar uplo, int n,
            int ncvt, int nru, int ncc,
            float* d, float* e, float* vt, int ldvt,
            float* u, int ldu, float* c,
            int ldc, float* work);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sbdsvdx")]
        public static extern int bdsvdx(Layout layout, UpLoChar uplo, char jobz, char range,
            int n, float* d, float* e,
            float vl, float vu,
            int il, int iu, int* ns,
            float* s, float* z, int ldz,
            int* superb);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sbdsvdx_work")]
        public static extern int bdsvdx(Layout layout, UpLoChar uplo, char jobz, char range,
            int n, float* d, float* e,
            float vl, float vu,
            int il, int iu, int* ns,
            float* s, float* z, int ldz,
            float* work, int* iwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sdisna")]
        public static extern int disna(char job, int m, int n, /* const */ [In] float* d,
            float* sep);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sgbbrd")]
        public static extern int gbbrd(Layout layout, char vect, int m,
            int n, int ncc, int kl,
            int ku, float* ab, int ldab, float* d,
            float* e, float* q, int ldq, float* pt,
            int ldpt, float* c, int ldc);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sgbbrd_work")]
        public static extern int gbbrd(Layout layout, char vect, int m,
            int n, int ncc, int kl,
            int ku, float* ab, int ldab,
            float* d, float* e, float* q, int ldq,
            float* pt, int ldpt, float* c,
            int ldc, float* work);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sgbcon")]
        public static extern int gbcon(Layout layout, Norm norm, int n,
            int kl, int ku, /* const */ [In] float* ab,
            int ldab, int* ipiv, float anorm,
            float* rcond);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sgbcon_work")]
        public static extern int gbcon(Layout layout, Norm norm, int n,
            int kl, int ku, /* const */ [In] float* ab,
            int ldab, int* ipiv,
            float anorm, float* rcond, float* work,
            int* iwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sgbequ")]
        public static extern int gbequ(Layout layout, int m, int n,
            int kl, int ku, /* const */ [In] float* ab,
            int ldab, float* r, float* c, float* rowcnd,
            float* colcnd, float* amax);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sgbequb")]
        public static extern int gbequb(Layout layout, int m, int n,
            int kl, int ku, /* const */ [In] float* ab,
            int ldab, float* r, float* c, float* rowcnd,
            float* colcnd, float* amax);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sgbrfs")]
        public static extern int gbrfs(Layout layout, TransChar trans, int n,
            int kl, int ku, int nrhs,
            /* const */ [In] float* ab, int ldab, /* const */ [In] float* afb,
            int ldafb, int* ipiv,
            /* const */ [In] float* b, int ldb, float* x,
            int ldx, float* ferr, float* berr);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sgbrfs_work")]
        public static extern int gbrfs(Layout layout, TransChar trans, int n,
            int kl, int ku, int nrhs,
            /* const */ [In] float* ab, int ldab,
            /* const */ [In] float* afb, int ldafb,
            int* ipiv, /* const */ [In] float* b,
            int ldb, float* x, int ldx,
            float* ferr, float* berr, float* work,
            int* iwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sgbrfsx")]
        public static extern int gbrfsx(Layout layout, TransChar trans, char equed,
            int n, int kl, int ku,
            int nrhs, /* const */ [In] float* ab, int ldab,
            /* const */ [In] float* afb, int ldafb,
            int* ipiv, /* const */ [In] float* r,
            /* const */ [In] float* c, /* const */ [In] float* b, int ldb,
            float* x, int ldx, float* rcond, float* berr,
            int n_err_bnds, float* err_bnds_norm,
            float* err_bnds_comp, int nparams,
            float* aparams);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sgbrfsx_work")]
        public static extern int gbrfsx(Layout layout, TransChar trans, char equed,
            int n, int kl, int ku,
            int nrhs, /* const */ [In] float* ab,
            int ldab, /* const */ [In] float* afb,
            int ldafb, int* ipiv,
            /* const */ [In] float* r, /* const */ [In] float* c, /* const */ [In] float* b,
            int ldb, float* x, int ldx,
            float* rcond, float* berr,
            int n_err_bnds, float* err_bnds_norm,
            float* err_bnds_comp, int nparams,
            float* aparams, float* work, int* iwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sgbsv")]
        public static extern int gbsv(Layout layout, int n, int kl,
            int ku, int nrhs, float* ab,
            int ldab, int* ipiv, float* b,
            int ldb);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sgbsvx")]
        public static extern int gbsvx(Layout layout, char fact, TransChar trans,
            int n, int kl, int ku,
            int nrhs, float* ab, int ldab,
            float* afb, int ldafb, int* ipiv,
            char[] equed, float* r, float* c, float* b,
            int ldb, float* x, int ldx,
            float* rcond, float* ferr, float* berr,
            float* rpivot);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sgbsvx_work")]
        public static extern int gbsvx(Layout layout, char fact, TransChar trans,
            int n, int kl, int ku,
            int nrhs, float* ab, int ldab,
            float* afb, int ldafb, int* ipiv,
            char[] equed, float* r, float* c, float* b,
            int ldb, float* x, int ldx,
            float* rcond, float* ferr, float* berr,
            float* work, int* iwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sgbsvxx")]
        public static extern int gbsvxx(Layout layout, char fact, TransChar trans,
            int n, int kl, int ku,
            int nrhs, float* ab, int ldab,
            float* afb, int ldafb, int* ipiv,
            char[] equed, float* r, float* c, float* b,
            int ldb, float* x, int ldx,
            float* rcond, float* rpvgrw, float* berr,
            int n_err_bnds, float* err_bnds_norm,
            float* err_bnds_comp, int nparams,
            float* aparams);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sgbsvxx_work")]
        public static extern int gbsvxx(Layout layout, char fact, TransChar trans,
            int n, int kl, int ku,
            int nrhs, float* ab, int ldab,
            float* afb, int ldafb, int* ipiv,
            char[] equed, float* r, float* c, float* b,
            int ldb, float* x, int ldx,
            float* rcond, float* rpvgrw, float* berr,
            int n_err_bnds, float* err_bnds_norm,
            float* err_bnds_comp, int nparams,
            float* aparams, float* work, int* iwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sgbtrf")]
        public static extern int gbtrf(Layout layout, int m, int n,
            int kl, int ku, float* ab,
            int ldab, int* ipiv);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sgbtrs")]
        public static extern int gbtrs(Layout layout, TransChar trans, int n,
            int kl, int ku, int nrhs,
            /* const */ [In] float* ab, int ldab,
            int* ipiv, float* b, int ldb);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sgebak")]
        public static extern int gebak(Layout layout, char job, char side, int n,
            int ilo, int ihi, /* const */ [In] float* scale,
            int m, float* v, int ldv);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sgebal")]
        public static extern int gebal(Layout layout, char job, int n, float* a,
            int lda, int* ilo, int* ihi,
            float* scale);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sgebrd")]
        public static extern int gebrd(Layout layout, int m, int n,
            float* a, int lda, float* d, float* e,
            float* tauq, float* taup);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sgebrd_work")]
        public static extern int gebrd(Layout layout, int m, int n,
            float* a, int lda, float* d, float* e,
            float* tauq, float* taup, float* work,
            int lwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sgecon")]
        public static extern int gecon(Layout layout, Norm norm, int n,
            /* const */ [In] float* a, int lda, float anorm,
            float* rcond);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sgecon_work")]
        public static extern int gecon(Layout layout, Norm norm, int n,
            /* const */ [In] float* a, int lda, float anorm,
            float* rcond, float* work, int* iwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sgeequ")]
        public static extern int geequ(Layout layout, int m, int n,
            /* const */ [In] float* a, int lda, float* r, float* c,
            float* rowcnd, float* colcnd, float* amax);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sgeequb")]
        public static extern int geequb(Layout layout, int m, int n,
            /* const */ [In] float* a, int lda, float* r, float* c,
            float* rowcnd, float* colcnd, float* amax);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sgeev")]
        public static extern int geev(Layout layout, char jobvl, char jobvr,
            int n, float* a, int lda, float* wr,
            float* wi, float* vl, int ldvl, float* vr,
            int ldvr);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sgeev_work")]
        public static extern int geev(Layout layout, char jobvl, char jobvr,
            int n, float* a, int lda,
            float* wr, float* wi, float* vl, int ldvl,
            float* vr, int ldvr, float* work,
            int lwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sgeevx")]
        public static extern int geevx(Layout layout, char balanc, char jobvl,
            char jobvr, char sense, int n, float* a,
            int lda, float* wr, float* wi, float* vl,
            int ldvl, float* vr, int ldvr,
            int* ilo, int* ihi, float* scale,
            float* abnrm, float* rconde, float* rcondv);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sgeevx_work")]
        public static extern int geevx(Layout layout, char balanc, char jobvl,
            char jobvr, char sense, int n, float* a,
            int lda, float* wr, float* wi, float* vl,
            int ldvl, float* vr, int ldvr,
            int* ilo, int* ihi, float* scale,
            float* abnrm, float* rconde, float* rcondv,
            float* work, int lwork,
            int* iwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sgehrd")]
        public static extern int gehrd(Layout layout, int n, int ilo,
            int ihi, float* a, int lda,
            float* tau);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sgehrd_work")]
        public static extern int gehrd(Layout layout, int n, int ilo,
            int ihi, float* a, int lda,
            float* tau, float* work, int lwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sgejsv")]
        public static extern int gejsv(Layout layout, char joba, char jobu, char jobv,
            char jobr, char jobt, char jobp, int m,
            int n, float* a, int lda, float* sva,
            float* u, int ldu, float* v, int ldv,
            float* stat, int* istat);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sgejsv_work")]
        public static extern int gejsv(Layout layout, char joba, char jobu,
            char jobv, char jobr, char jobt, char jobp,
            int m, int n, float* a,
            int lda, float* sva, float* u,
            int ldu, float* v, int ldv,
            float* work, int lwork,
            int* iwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sgelq2")]
        public static extern int gelq2(Layout layout, int m, int n,
            float* a, int lda, float* tau);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sgelq2_work")]
        public static extern int gelq2(Layout layout, int m, int n,
            float* a, int lda, float* tau,
            float* work);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sgelqf")]
        public static extern int gelqf(Layout layout, int m, int n,
            float* a, int lda, float* tau);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sgelqf_work")]
        public static extern int gelqf(Layout layout, int m, int n,
            float* a, int lda, float* tau,
            float* work, int lwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sgels")]
        public static extern int gels(Layout layout, TransChar trans, int m,
            int n, int nrhs, float* a,
            int lda, float* b, int ldb);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sgels_work")]
        public static extern int gels(Layout layout, TransChar trans, int m,
            int n, int nrhs, float* a,
            int lda, float* b, int ldb,
            float* work, int lwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sgelsd")]
        public static extern int gelsd(Layout layout, int m, int n,
            int nrhs, float* a, int lda, float* b,
            int ldb, float* s, float rcond,
            ref int rank);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sgelsd_work")]
        public static extern int gelsd(Layout layout, int m, int n,
            int nrhs, float* a, int lda,
            float* b, int ldb, float* s, float rcond,
            ref int rank, float* work, int lwork,
            int* iwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sgelss")]
        public static extern int gelss(Layout layout, int m, int n,
            int nrhs, float* a, int lda, float* b,
            int ldb, float* s, float rcond,
            ref int rank);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sgelss_work")]
        public static extern int gelss(Layout layout, int m, int n,
            int nrhs, float* a, int lda,
            float* b, int ldb, float* s, float rcond,
            ref int rank, float* work,
            int lwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sgelsy")]
        public static extern int gelsy(Layout layout, int m, int n,
            int nrhs, float* a, int lda, float* b,
            int ldb, int* jpvt, float rcond,
            ref int rank);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sgelsy_work")]
        public static extern int gelsy(Layout layout, int m, int n,
            int nrhs, float* a, int lda,
            float* b, int ldb, int* jpvt,
            float rcond, ref int rank, float* work,
            int lwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sgemqrt")]
        public static extern int gemqrt(Layout layout, char side, TransChar trans,
            int m, int n, int k,
            int nb, /* const */ [In] float* v, int ldv,
            /* const */ [In] float* t, int ldt, float* c,
            int ldc);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sgemqrt_work")]
        public static extern int gemqrt(Layout layout, char side, TransChar trans,
            int m, int n, int k,
            int nb, /* const */ [In] float* v, int ldv,
            /* const */ [In] float* t, int ldt, float* c,
            int ldc, float* work);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sgeqlf")]
        public static extern int geqlf(Layout layout, int m, int n,
            float* a, int lda, float* tau);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sgeqlf_work")]
        public static extern int geqlf(Layout layout, int m, int n,
            float* a, int lda, float* tau,
            float* work, int lwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sgeqp3")]
        public static extern int geqp3(Layout layout, int m, int n,
            float* a, int lda, int* jpvt,
            float* tau);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sgeqp3_work")]
        public static extern int geqp3(Layout layout, int m, int n,
            float* a, int lda, int* jpvt,
            float* tau, float* work, int lwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sgeqpf")]
        public static extern int geqpf(Layout layout, int m, int n,
            float* a, int lda, int* jpvt,
            float* tau);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sgeqpf_work")]
        public static extern int geqpf(Layout layout, int m, int n,
            float* a, int lda, int* jpvt,
            float* tau, float* work);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sgeqr2")]
        public static extern int geqr2(Layout layout, int m, int n,
            float* a, int lda, float* tau);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sgeqr2_work")]
        public static extern int geqr2(Layout layout, int m, int n,
            float* a, int lda, float* tau,
            float* work);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sgeqrf")]
        public static extern int geqrf(Layout layout, int m, int n,
            float* a, int lda, float* tau);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sgeqrf_work")]
        public static extern int geqrf(Layout layout, int m, int n,
            float* a, int lda, float* tau,
            float* work, int lwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sgeqrfp")]
        public static extern int geqrfp(Layout layout, int m, int n,
            float* a, int lda, float* tau);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sgeqrfp_work")]
        public static extern int geqrfp(Layout layout, int m, int n,
            float* a, int lda, float* tau,
            float* work, int lwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sgeqrt")]
        public static extern int geqrt(Layout layout, int m, int n,
            int nb, float* a, int lda, float* t,
            int ldt);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sgeqrt2")]
        public static extern int geqrt2(Layout layout, int m, int n,
            float* a, int lda, float* t, int ldt);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sgeqrt3")]
        public static extern int geqrt3(Layout layout, int m, int n,
            float* a, int lda, float* t, int ldt);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sgeqrt_work")]
        public static extern int geqrt(Layout layout, int m, int n,
            int nb, float* a, int lda,
            float* t, int ldt, float* work);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sgerfs")]
        public static extern int gerfs(Layout layout, TransChar trans, int n,
            int nrhs, /* const */ [In] float* a, int lda,
            /* const */ [In] float* af, int ldaf,
            int* ipiv, /* const */ [In] float* b,
            int ldb, float* x, int ldx,
            float* ferr, float* berr);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sgerfs_work")]
        public static extern int gerfs(Layout layout, TransChar trans, int n,
            int nrhs, /* const */ [In] float* a, int lda,
            /* const */ [In] float* af, int ldaf,
            int* ipiv, /* const */ [In] float* b,
            int ldb, float* x, int ldx,
            float* ferr, float* berr, float* work,
            int* iwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sgerfsx")]
        public static extern int gerfsx(Layout layout, TransChar trans, char equed,
            int n, int nrhs, /* const */ [In] float* a,
            int lda, /* const */ [In] float* af, int ldaf,
            int* ipiv, /* const */ [In] float* r,
            /* const */ [In] float* c, /* const */ [In] float* b, int ldb,
            float* x, int ldx, float* rcond, float* berr,
            int n_err_bnds, float* err_bnds_norm,
            float* err_bnds_comp, int nparams,
            float* aparams);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sgerfsx_work")]
        public static extern int gerfsx(Layout layout, TransChar trans, char equed,
            int n, int nrhs, /* const */ [In] float* a,
            int lda, /* const */ [In] float* af,
            int ldaf, int* ipiv,
            /* const */ [In] float* r, /* const */ [In] float* c, /* const */ [In] float* b,
            int ldb, float* x, int ldx,
            float* rcond, float* berr,
            int n_err_bnds, float* err_bnds_norm,
            float* err_bnds_comp, int nparams,
            float* aparams, float* work, int* iwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sgerqf")]
        public static extern int gerqf(Layout layout, int m, int n,
            float* a, int lda, float* tau);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sgerqf_work")]
        public static extern int gerqf(Layout layout, int m, int n,
            float* a, int lda, float* tau,
            float* work, int lwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sgesdd")]
        public static extern int gesdd(Layout layout, char jobz, int m,
            int n, float* a, int lda, float* s,
            float* u, int ldu, float* vt,
            int ldvt);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sgesdd_work")]
        public static extern int gesdd(Layout layout, char jobz, int m,
            int n, float* a, int lda,
            float* s, float* u, int ldu, float* vt,
            int ldvt, float* work, int lwork,
            int* iwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sgesv")]
        public static extern int gesv(Layout layout, int n, int nrhs,
            float* a, int lda, int* ipiv, float* b,
            int ldb);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sgesvd")]
        public static extern int gesvd(Layout layout, char jobu, char jobvt,
            int m, int n, float* a, int lda,
            float* s, float* u, int ldu, float* vt,
            int ldvt, float* superb);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sgesvd_work")]
        public static extern int gesvd(Layout layout, char jobu, char jobvt,
            int m, int n, float* a,
            int lda, float* s, float* u,
            int ldu, float* vt, int ldvt,
            float* work, int lwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sgesvdx")]
        public static extern int gesvdx(Layout layout, char jobu, char jobvt, char range,
            int m, int n, float* a,
            int lda, float vl, float vu,
            int il, int iu, int* ns,
            float* s, float* u, int ldu,
            float* vt, int ldvt,
            int* superb);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sgesvdx_work")]
        public static extern int gesvdx(Layout layout, char jobu, char jobvt, char range,
            int m, int n, float* a,
            int lda, float vl, float vu,
            int il, int iu, int* ns,
            float* s, float* u, int ldu,
            float* vt, int ldvt,
            float* work, int lwork, int* iwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sgesvj")]
        public static extern int gesvj(Layout layout, char joba, char jobu, char jobv,
            int m, int n, float* a, int lda,
            float* sva, int mv, float* v, int ldv,
            float* stat);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sgesvj_work")]
        public static extern int gesvj(Layout layout, char joba, char jobu,
            char jobv, int m, int n, float* a,
            int lda, float* sva, int mv,
            float* v, int ldv, float* work,
            int lwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sgesvx")]
        public static extern int gesvx(Layout layout, char fact, TransChar trans,
            int n, int nrhs, float* a,
            int lda, float* af, int ldaf,
            int* ipiv, char[] equed, float* r, float* c,
            float* b, int ldb, float* x, int ldx,
            float* rcond, float* ferr, float* berr,
            float* rpivot);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sgesvx_work")]
        public static extern int gesvx(Layout layout, char fact, TransChar trans,
            int n, int nrhs, float* a,
            int lda, float* af, int ldaf,
            int* ipiv, char[] equed, float* r,
            float* c, float* b, int ldb, float* x,
            int ldx, float* rcond, float* ferr,
            float* berr, float* work, int* iwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sgesvxx")]
        public static extern int gesvxx(Layout layout, char fact, TransChar trans,
            int n, int nrhs, float* a,
            int lda, float* af, int ldaf,
            int* ipiv, char[] equed, float* r, float* c,
            float* b, int ldb, float* x, int ldx,
            float* rcond, float* rpvgrw, float* berr,
            int n_err_bnds, float* err_bnds_norm,
            float* err_bnds_comp, int nparams,
            float* aparams);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sgesvxx_work")]
        public static extern int gesvxx(Layout layout, char fact, TransChar trans,
            int n, int nrhs, float* a,
            int lda, float* af, int ldaf,
            int* ipiv, char[] equed, float* r,
            float* c, float* b, int ldb, float* x,
            int ldx, float* rcond, float* rpvgrw,
            float* berr, int n_err_bnds,
            float* err_bnds_norm, float* err_bnds_comp,
            int nparams, float* aparams, float* work,
            int* iwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sgetf2")]
        public static extern int getf2(Layout layout, int m, int n,
            float* a, int lda, int* ipiv);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sgetrf")]
        public static extern int getrf(Layout layout, int m, int n,
            float* a, int lda, int* ipiv);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sgetrf2")]
        public static extern int getrf2(Layout layout, int m, int n,
            float* a, int lda, int* ipiv);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sgetri")]
        public static extern int getri(Layout layout, int n, float* a,
            int lda, int* ipiv);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sgetri_work")]
        public static extern int getri(Layout layout, int n, float* a,
            int lda, int* ipiv,
            float* work, int lwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sgetrs")]
        public static extern int getrs(Layout layout, TransChar trans, int n,
            int nrhs, /* const */ [In] float* a, int lda,
            int* ipiv, float* b, int ldb);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sggbak")]
        public static extern int ggbak(Layout layout, char job, char side, int n,
            int ilo, int ihi, /* const */ [In] float* lscale,
            /* const */ [In] float* rscale, int m, float* v,
            int ldv);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sggbal")]
        public static extern int ggbal(Layout layout, char job, int n, float* a,
            int lda, float* b, int ldb,
            int* ilo, int* ihi, float* lscale,
            float* rscale);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sggbal_work")]
        public static extern int ggbal(Layout layout, char job, int n,
            float* a, int lda, float* b,
            int ldb, int* ilo,
            int* ihi, float* lscale, float* rscale,
            float* work);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sggev")]
        public static extern int ggev(Layout layout, char jobvl, char jobvr,
            int n, float* a, int lda, float* b,
            int ldb, float* alphar, float* alphai,
            float* beta, float* vl, int ldvl, float* vr,
            int ldvr);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sggev3")]
        public static extern int ggev3(Layout layout, char jobvl, char jobvr,
            int n, float* a, int lda, float* b,
            int ldb, float* alphar, float* alphai,
            float* beta, float* vl, int ldvl, float* vr,
            int ldvr);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sggev3_work")]
        public static extern int ggev3(Layout layout,
            char jobvl, char jobvr, int n,
            float* a, int lda,
            float* b, int ldb,
            float* alphar, float* alphai, float* beta,
            float* vl, int ldvl,
            float* vr, int ldvr,
            float* work, int lwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sggev_work")]
        public static extern int ggev(Layout layout, char jobvl, char jobvr,
            int n, float* a, int lda, float* b,
            int ldb, float* alphar, float* alphai,
            float* beta, float* vl, int ldvl,
            float* vr, int ldvr, float* work,
            int lwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sggevx")]
        public static extern int ggevx(Layout layout, char balanc, char jobvl,
            char jobvr, char sense, int n, float* a,
            int lda, float* b, int ldb,
            float* alphar, float* alphai, float* beta, float* vl,
            int ldvl, float* vr, int ldvr,
            int* ilo, int* ihi, float* lscale,
            float* rscale, float* abnrm, float* bbnrm,
            float* rconde, float* rcondv);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sggevx_work")]
        public static extern int ggevx(Layout layout, char balanc, char jobvl,
            char jobvr, char sense, int n, float* a,
            int lda, float* b, int ldb,
            float* alphar, float* alphai, float* beta,
            float* vl, int ldvl, float* vr,
            int ldvr, int* ilo,
            int* ihi, float* lscale, float* rscale,
            float* abnrm, float* bbnrm, float* rconde,
            float* rcondv, float* work, int lwork,
            int* iwork, int* bwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sggglm")]
        public static extern int ggglm(Layout layout, int n, int m,
            int p, float* a, int lda, float* b,
            int ldb, float* d, float* x, float* y);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sggglm_work")]
        public static extern int ggglm(Layout layout, int n, int m,
            int p, float* a, int lda,
            float* b, int ldb, float* d, float* x,
            float* y, float* work, int lwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sgghd3")]
        public static extern int gghd3(Layout layout, char compq, char compz,
            int n, int ilo, int ihi,
            float* a, int lda, float* b, int ldb,
            float* q, int ldq, float* z, int ldz);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sgghd3_work")]
        public static extern int gghd3(Layout layout, char compq, char compz,
            int n, int ilo, int ihi,
            float* a, int lda, float* b,
            int ldb, float* q, int ldq,
            float* z, int ldz, float* work,
            int lwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sgghrd")]
        public static extern int gghrd(Layout layout, char compq, char compz,
            int n, int ilo, int ihi,
            float* a, int lda, float* b, int ldb,
            float* q, int ldq, float* z, int ldz);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sgglse")]
        public static extern int gglse(Layout layout, int m, int n,
            int p, float* a, int lda, float* b,
            int ldb, float* c, float* d, float* x);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sgglse_work")]
        public static extern int gglse(Layout layout, int m, int n,
            int p, float* a, int lda,
            float* b, int ldb, float* c, float* d,
            float* x, float* work, int lwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sggqrf")]
        public static extern int ggqrf(Layout layout, int n, int m,
            int p, float* a, int lda, float* taua,
            float* b, int ldb, float* taub);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sggqrf_work")]
        public static extern int ggqrf(Layout layout, int n, int m,
            int p, float* a, int lda,
            float* taua, float* b, int ldb,
            float* taub, float* work, int lwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sggrqf")]
        public static extern int ggrqf(Layout layout, int m, int p,
            int n, float* a, int lda, float* taua,
            float* b, int ldb, float* taub);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sggrqf_work")]
        public static extern int ggrqf(Layout layout, int m, int p,
            int n, float* a, int lda,
            float* taua, float* b, int ldb,
            float* taub, float* work, int lwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sggsvd")]
        public static extern int ggsvd(Layout layout, char jobu, char jobv, char jobq,
            int m, int n, int p,
            int* k, int* l, float* a,
            int lda, float* b, int ldb,
            float* alpha, float* beta, float* u, int ldu,
            float* v, int ldv, float* q, int ldq,
            int* iwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sggsvd3")]
        public static extern int ggsvd3(Layout layout, char jobu, char jobv, char jobq,
            int m, int n, int p,
            int* k, int* l, float* a,
            int lda, float* b, int ldb,
            float* alpha, float* beta, float* u, int ldu,
            float* v, int ldv, float* q, int ldq,
            int* iwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sggsvd3_work")]
        public static extern int ggsvd3(Layout layout, char jobu, char jobv,
            char jobq, int m, int n,
            int p, int* k, int* l,
            float* a, int lda, float* b,
            int ldb, float* alpha, float* beta,
            float* u, int ldu, float* v,
            int ldv, float* q, int ldq,
            float* work, int lwork,
            int* iwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sggsvd_work")]
        public static extern int ggsvd(Layout layout, char jobu, char jobv,
            char jobq, int m, int n,
            int p, int* k, int* l,
            float* a, int lda, float* b,
            int ldb, float* alpha, float* beta,
            float* u, int ldu, float* v,
            int ldv, float* q, int ldq,
            float* work, int* iwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sggsvp")]
        public static extern int ggsvp(Layout layout, char jobu, char jobv, char jobq,
            int m, int p, int n, float* a,
            int lda, float* b, int ldb, float tola,
            float tolb, int* k, int* l, float* u,
            int ldu, float* v, int ldv, float* q,
            int ldq);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sggsvp3")]
        public static extern int ggsvp3(Layout layout, char jobu, char jobv, char jobq,
            int m, int p, int n, float* a,
            int lda, float* b, int ldb, float tola,
            float tolb, int* k, int* l, float* u,
            int ldu, float* v, int ldv, float* q,
            int ldq);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sggsvp3_work")]
        public static extern int ggsvp3(Layout layout, char jobu, char jobv,
            char jobq, int m, int p,
            int n, float* a, int lda,
            float* b, int ldb, float tola,
            float tolb, int* k, int* l,
            float* u, int ldu, float* v,
            int ldv, float* q, int ldq,
            int* iwork, float* tau, float* work,
            int lwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sggsvp_work")]
        public static extern int ggsvp(Layout layout, char jobu, char jobv,
            char jobq, int m, int p,
            int n, float* a, int lda,
            float* b, int ldb, float tola,
            float tolb, int* k, int* l,
            float* u, int ldu, float* v,
            int ldv, float* q, int ldq,
            int* iwork, float* tau, float* work);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sgtcon")]
        public static extern int gtcon(Norm norm, int n, /* const */ [In] float* dl,
            /* const */ [In] float* d, /* const */ [In] float* du, /* const */ [In] float* du2,
            int* ipiv, float anorm, float* rcond);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sgtcon_work")]
        public static extern int gtcon(Norm norm, int n, /* const */ [In] float* dl,
            /* const */ [In] float* d, /* const */ [In] float* du,
            /* const */ [In] float* du2, int* ipiv,
            float anorm, float* rcond, float* work,
            int* iwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sgtrfs")]
        public static extern int gtrfs(Layout layout, TransChar trans, int n,
            int nrhs, /* const */ [In] float* dl, /* const */ [In] float* d,
            /* const */ [In] float* du, /* const */ [In] float* dlf, /* const */ [In] float* df,
            /* const */ [In] float* duf, /* const */ [In] float* du2,
            int* ipiv, /* const */ [In] float* b,
            int ldb, float* x, int ldx,
            float* ferr, float* berr);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sgtrfs_work")]
        public static extern int gtrfs(Layout layout, TransChar trans, int n,
            int nrhs, /* const */ [In] float* dl,
            /* const */ [In] float* d, /* const */ [In] float* du,
            /* const */ [In] float* dlf, /* const */ [In] float* df,
            /* const */ [In] float* duf, /* const */ [In] float* du2,
            int* ipiv, /* const */ [In] float* b,
            int ldb, float* x, int ldx,
            float* ferr, float* berr, float* work,
            int* iwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sgtsv")]
        public static extern int gtsv(Layout layout, int n, int nrhs,
            float* dl, float* d, float* du, float* b,
            int ldb);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sgtsvx")]
        public static extern int gtsvx(Layout layout, char fact, TransChar trans,
            int n, int nrhs, /* const */ [In] float* dl,
            /* const */ [In] float* d, /* const */ [In] float* du, float* dlf,
            float* df, float* duf, float* du2, int* ipiv,
            /* const */ [In] float* b, int ldb, float* x,
            int ldx, float* rcond, float* ferr,
            float* berr);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sgtsvx_work")]
        public static extern int gtsvx(Layout layout, char fact, TransChar trans,
            int n, int nrhs, /* const */ [In] float* dl,
            /* const */ [In] float* d, /* const */ [In] float* du, float* dlf,
            float* df, float* duf, float* du2,
            int* ipiv, /* const */ [In] float* b,
            int ldb, float* x, int ldx,
            float* rcond, float* ferr, float* berr,
            float* work, int* iwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sgttrf")]
        public static extern int gttrf(int n, float* dl, float* d, float* du,
            float* du2, int* ipiv);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sgttrs")]
        public static extern int gttrs(Layout layout, TransChar trans, int n,
            int nrhs, /* const */ [In] float* dl, /* const */ [In] float* d,
            /* const */ [In] float* du, /* const */ [In] float* du2,
            int* ipiv, float* b, int ldb);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_shgeqz")]
        public static extern int hgeqz(Layout layout, char job, char compq, char compz,
            int n, int ilo, int ihi,
            float* h, int ldh, float* t, int ldt,
            float* alphar, float* alphai, float* beta, float* q,
            int ldq, float* z, int ldz);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_shgeqz_work")]
        public static extern int hgeqz(Layout layout, char job, char compq,
            char compz, int n, int ilo,
            int ihi, float* h, int ldh,
            float* t, int ldt, float* alphar,
            float* alphai, float* beta, float* q,
            int ldq, float* z, int ldz,
            float* work, int lwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_shsein")]
        public static extern int hsein(Layout layout, char job, char eigsrc, char initv,
            int* select, int n, /* const */ [In] float* h,
            int ldh, float* wr, /* const */ [In] float* wi,
            float* vl, int ldvl, float* vr,
            int ldvr, int mm, int* m,
            int* ifaill, int* ifailr);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_shsein_work")]
        public static extern int hsein(Layout layout, char job, char eigsrc,
            char initv, int* select,
            int n, /* const */ [In] float* h, int ldh,
            float* wr, /* const */ [In] float* wi, float* vl,
            int ldvl, float* vr, int ldvr,
            int mm, int* m, float* work,
            int* ifaill, int* ifailr);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_shseqr")]
        public static extern int hseqr(Layout layout, char job, char compz, int n,
            int ilo, int ihi, float* h,
            int ldh, float* wr, float* wi, float* z,
            int ldz);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_shseqr_work")]
        public static extern int hseqr(Layout layout, char job, char compz,
            int n, int ilo, int ihi,
            float* h, int ldh, float* wr, float* wi,
            float* z, int ldz, float* work,
            int lwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_slacn2")]
        public static extern int lacn2(int n, float* v, float* x, int* isgn,
            float* est, int* kase, int* isave);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_slacpy")]
        public static extern int lacpy(Layout layout, UpLoChar uplo, int m,
            int n, /* const */ [In] float* a, int lda,
            float* b, int ldb);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_slag2d")]
        public static extern int lag2d(Layout layout, int m, int n,
            /* const */ [In] float* sa, int ldsa, double* a,
            int lda);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_slagge")]
        public static extern int lagge(Layout layout, int m, int n,
            int kl, int ku, /* const */ [In] float* d,
            float* a, int lda, int* iseed);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_slagge_work")]
        public static extern int lagge(Layout layout, int m, int n,
            int kl, int ku, /* const */ [In] float* d,
            float* a, int lda, int* iseed,
            float* work);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_slagsy")]
        public static extern int lagsy(Layout layout, int n, int k,
            /* const */ [In] float* d, float* a, int lda,
            int* iseed);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_slagsy_work")]
        public static extern int lagsy(Layout layout, int n, int k,
            /* const */ [In] float* d, float* a, int lda,
            int* iseed, float* work);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_slapmr")]
        public static extern int lapmr(Layout layout, int forwrd,
            int m, int n, float* x, int ldx,
            int* k);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_slapmt")]
        public static extern int lapmt(Layout layout, int forwrd,
            int m, int n, float* x, int ldx,
            int* k);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_slarfb")]
        public static extern int larfb(Layout layout, char side, TransChar trans, char direct,
            char storev, int m, int n,
            int k, /* const */ [In] float* v, int ldv,
            /* const */ [In] float* t, int ldt, float* c,
            int ldc);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_slarfb_work")]
        public static extern int larfb(Layout layout, char side, TransChar trans,
            char direct, char storev, int m,
            int n, int k, /* const */ [In] float* v,
            int ldv, /* const */ [In] float* t, int ldt,
            float* c, int ldc, float* work,
            int ldwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_slarfg")]
        public static extern int larfg(int n, float* alpha, float* x,
            int incx, float* tau);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_slarft")]
        public static extern int larft(Layout layout, char direct, char storev,
            int n, int k, /* const */ [In] float* v,
            int ldv, /* const */ [In] float* tau, float* t,
            int ldt);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_slarfx")]
        public static extern int larfx(Layout layout, char side, int m,
            int n, /* const */ [In] float* v, float tau, float* c,
            int ldc, float* work);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_slarnv")]
        public static extern int larnv(int idist, int* iseed, int n,
            float* x);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_slartgp")]
        public static extern int lartgp(float f, float g, float* cs, float* sn, float* r);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_slartgs")]
        public static extern int lartgs(float x, float y, float sigma, float* cs,
            float* sn);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_slascl")]
        public static extern int lascl(Layout layout, char type, int kl,
            int ku, float cfrom, float cto,
            int m, int n, float* a,
            int lda);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_slaset")]
        public static extern int laset(Layout layout, UpLoChar uplo, int m,
            int n, float alpha, float beta, float* a,
            int lda);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_slasrt")]
        public static extern int lasrt(char id, int n, float* d);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_slaswp")]
        public static extern int laswp(Layout layout, int n, float* a,
            int lda, int k1, int k2,
            int* ipiv, int incx);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_slatms")]
        public static extern int latms(Layout layout, int m, int n,
            char dist, int* iseed, char sym, float* d,
            int mode, float cond, float dmax,
            int kl, int ku, char pack, float* a,
            int lda);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_slatms_work")]
        public static extern int latms(Layout layout, int m, int n,
            char dist, int* iseed, char sym,
            float* d, int mode, float cond,
            float dmax, int kl, int ku,
            char pack, float* a, int lda,
            float* work);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_slauum")]
        public static extern int lauum(Layout layout, UpLoChar uplo, int n, float* a,
            int lda);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sopgtr")]
        public static extern int opgtr(Layout layout, UpLoChar uplo, int n,
            /* const */ [In] float* ap, /* const */ [In] float* tau, float* q,
            int ldq);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sopgtr_work")]
        public static extern int opgtr(Layout layout, UpLoChar uplo, int n,
            /* const */ [In] float* ap, /* const */ [In] float* tau, float* q,
            int ldq, float* work);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sopmtr")]
        public static extern int opmtr(Layout layout, char side, UpLoChar uplo, TransChar trans,
            int m, int n, /* const */ [In] float* ap,
            /* const */ [In] float* tau, float* c, int ldc);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sopmtr_work")]
        public static extern int opmtr(Layout layout, char side, UpLoChar uplo,
            TransChar trans, int m, int n,
            /* const */ [In] float* ap, /* const */ [In] float* tau, float* c,
            int ldc, float* work);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sorbdb")]
        public static extern int orbdb(Layout layout, TransChar trans, char signs,
            int m, int p, int q, float* x11,
            int ldx11, float* x12, int ldx12,
            float* x21, int ldx21, float* x22,
            int ldx22, float* theta, float* phi,
            float* taup1, float* taup2, float* tauq1,
            float* tauq2);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sorbdb_work")]
        public static extern int orbdb(Layout layout, TransChar trans, char signs,
            int m, int p, int q,
            float* x11, int ldx11, float* x12,
            int ldx12, float* x21, int ldx21,
            float* x22, int ldx22, float* theta,
            float* phi, float* taup1, float* taup2,
            float* tauq1, float* tauq2, float* work,
            int lwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sorcsd")]
        public static extern int orcsd(Layout layout, char jobu1, char jobu2,
            char jobv1t, char jobv2t, TransChar trans, char signs,
            int m, int p, int q, float* x11,
            int ldx11, float* x12, int ldx12,
            float* x21, int ldx21, float* x22,
            int ldx22, float* theta, float* u1,
            int ldu1, float* u2, int ldu2,
            float* v1t, int ldv1t, float* v2t,
            int ldv2t);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sorcsd2by1")]
        public static extern int orcsd2by1(Layout layout, char jobu1, char jobu2,
            char jobv1t, int m, int p, int q,
            float* x11, int ldx11, float* x21, int ldx21,
            float* theta, float* u1, int ldu1, float* u2,
            int ldu2, float* v1t, int ldv1t);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sorcsd2by1_work")]
        public static extern int orcsd2by1(Layout layout, char jobu1, char jobu2,
            char jobv1t, int m, int p,
            int q, float* x11, int ldx11,
            float* x21, int ldx21,
            float* theta, float* u1, int ldu1,
            float* u2, int ldu2, float* v1t,
            int ldv1t, float* work, int lwork,
            int* iwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sorcsd_work")]
        public static extern int orcsd(Layout layout, char jobu1, char jobu2,
            char jobv1t, char jobv2t, TransChar trans,
            char signs, int m, int p,
            int q, float* x11, int ldx11,
            float* x12, int ldx12, float* x21,
            int ldx21, float* x22, int ldx22,
            float* theta, float* u1, int ldu1,
            float* u2, int ldu2, float* v1t,
            int ldv1t, float* v2t, int ldv2t,
            float* work, int lwork,
            int* iwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sorgbr")]
        public static extern int orgbr(Layout layout, char vect, int m,
            int n, int k, float* a, int lda,
            float* tau);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sorgbr_work")]
        public static extern int orgbr(Layout layout, char vect, int m,
            int n, int k, float* a,
            int lda, /* const */ [In] float* tau, float* work,
            int lwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sorghr")]
        public static extern int orghr(Layout layout, int n, int ilo,
            int ihi, float* a, int lda,
            float* tau);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sorghr_work")]
        public static extern int orghr(Layout layout, int n, int ilo,
            int ihi, float* a, int lda,
            /* const */ [In] float* tau, float* work,
            int lwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sorglq")]
        public static extern int orglq(Layout layout, int m, int n,
            int k, float* a, int lda,
            float* tau);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sorglq_work")]
        public static extern int orglq(Layout layout, int m, int n,
            int k, float* a, int lda,
            /* const */ [In] float* tau, float* work,
            int lwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sorgql")]
        public static extern int orgql(Layout layout, int m, int n,
            int k, float* a, int lda,
            float* tau);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sorgql_work")]
        public static extern int orgql(Layout layout, int m, int n,
            int k, float* a, int lda,
            /* const */ [In] float* tau, float* work,
            int lwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sorgqr")]
        public static extern int orgqr(Layout layout, int m, int n,
            int k, float* a, int lda,
            float* tau);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sorgqr_work")]
        public static extern int orgqr(Layout layout, int m, int n,
            int k, float* a, int lda,
            /* const */ [In] float* tau, float* work,
            int lwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sorgrq")]
        public static extern int orgrq(Layout layout, int m, int n,
            int k, float* a, int lda,
            float* tau);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sorgrq_work")]
        public static extern int orgrq(Layout layout, int m, int n,
            int k, float* a, int lda,
            /* const */ [In] float* tau, float* work,
            int lwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sorgtr")]
        public static extern int orgtr(Layout layout, UpLoChar uplo, int n, float* a,
            int lda, float* tau);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sorgtr_work")]
        public static extern int orgtr(Layout layout, UpLoChar uplo, int n,
            float* a, int lda, /* const */ [In] float* tau,
            float* work, int lwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sormbr")]
        public static extern int ormbr(Layout layout, char vect, char side, TransChar trans,
            int m, int n, int k,
            /* const */ [In] float* a, int lda, /* const */ [In] float* tau,
            float* c, int ldc);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sormbr_work")]
        public static extern int ormbr(Layout layout, char vect, char side,
            TransChar trans, int m, int n,
            int k, /* const */ [In] float* a, int lda,
            /* const */ [In] float* tau, float* c, int ldc,
            float* work, int lwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sormhr")]
        public static extern int ormhr(Layout layout, char side, TransChar trans,
            int m, int n, int ilo,
            int ihi, /* const */ [In] float* a, int lda,
            /* const */ [In] float* tau, float* c, int ldc);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sormhr_work")]
        public static extern int ormhr(Layout layout, char side, TransChar trans,
            int m, int n, int ilo,
            int ihi, /* const */ [In] float* a, int lda,
            /* const */ [In] float* tau, float* c, int ldc,
            float* work, int lwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sormlq")]
        public static extern int ormlq(Layout layout, char side, TransChar trans,
            int m, int n, int k,
            /* const */ [In] float* a, int lda, /* const */ [In] float* tau,
            float* c, int ldc);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sormlq_work")]
        public static extern int ormlq(Layout layout, char side, TransChar trans,
            int m, int n, int k,
            /* const */ [In] float* a, int lda,
            /* const */ [In] float* tau, float* c, int ldc,
            float* work, int lwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sormql")]
        public static extern int ormql(Layout layout, char side, TransChar trans,
            int m, int n, int k,
            /* const */ [In] float* a, int lda, /* const */ [In] float* tau,
            float* c, int ldc);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sormql_work")]
        public static extern int ormql(Layout layout, char side, TransChar trans,
            int m, int n, int k,
            /* const */ [In] float* a, int lda,
            /* const */ [In] float* tau, float* c, int ldc,
            float* work, int lwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sormqr")]
        public static extern int ormqr(Layout layout, char side, TransChar trans,
            int m, int n, int k,
            /* const */ [In] float* a, int lda, /* const */ [In] float* tau,
            float* c, int ldc);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sormqr_work")]
        public static extern int ormqr(Layout layout, char side, TransChar trans,
            int m, int n, int k,
            /* const */ [In] float* a, int lda,
            /* const */ [In] float* tau, float* c, int ldc,
            float* work, int lwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sormrq")]
        public static extern int ormrq(Layout layout, char side, TransChar trans,
            int m, int n, int k,
            /* const */ [In] float* a, int lda, /* const */ [In] float* tau,
            float* c, int ldc);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sormrq_work")]
        public static extern int ormrq(Layout layout, char side, TransChar trans,
            int m, int n, int k,
            /* const */ [In] float* a, int lda,
            /* const */ [In] float* tau, float* c, int ldc,
            float* work, int lwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sormrz")]
        public static extern int ormrz(Layout layout, char side, TransChar trans,
            int m, int n, int k,
            int l, /* const */ [In] float* a, int lda,
            /* const */ [In] float* tau, float* c, int ldc);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sormrz_work")]
        public static extern int ormrz(Layout layout, char side, TransChar trans,
            int m, int n, int k,
            int l, /* const */ [In] float* a, int lda,
            /* const */ [In] float* tau, float* c, int ldc,
            float* work, int lwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sormtr")]
        public static extern int ormtr(Layout layout, char side, UpLoChar uplo, TransChar trans,
            int m, int n, /* const */ [In] float* a,
            int lda, /* const */ [In] float* tau, float* c,
            int ldc);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sormtr_work")]
        public static extern int ormtr(Layout layout, char side, UpLoChar uplo,
            TransChar trans, int m, int n,
            /* const */ [In] float* a, int lda,
            /* const */ [In] float* tau, float* c, int ldc,
            float* work, int lwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_spbcon")]
        public static extern int pbcon(Layout layout, UpLoChar uplo, int n,
            int kd, /* const */ [In] float* ab, int ldab,
            float anorm, float* rcond);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_spbcon_work")]
        public static extern int pbcon(Layout layout, UpLoChar uplo, int n,
            int kd, /* const */ [In] float* ab, int ldab,
            float anorm, float* rcond, float* work,
            int* iwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_spbequ")]
        public static extern int pbequ(Layout layout, UpLoChar uplo, int n,
            int kd, /* const */ [In] float* ab, int ldab,
            float* s, float* scond, float* amax);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_spbrfs")]
        public static extern int pbrfs(Layout layout, UpLoChar uplo, int n,
            int kd, int nrhs, /* const */ [In] float* ab,
            int ldab, /* const */ [In] float* afb, int ldafb,
            /* const */ [In] float* b, int ldb, float* x,
            int ldx, float* ferr, float* berr);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_spbrfs_work")]
        public static extern int pbrfs(Layout layout, UpLoChar uplo, int n,
            int kd, int nrhs, /* const */ [In] float* ab,
            int ldab, /* const */ [In] float* afb,
            int ldafb, /* const */ [In] float* b,
            int ldb, float* x, int ldx,
            float* ferr, float* berr, float* work,
            int* iwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_spbstf")]
        public static extern int pbstf(Layout layout, UpLoChar uplo, int n,
            int kb, float* bb, int ldbb);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_spbsv")]
        public static extern int pbsv(Layout layout, UpLoChar uplo, int n,
            int kd, int nrhs, float* ab,
            int ldab, float* b, int ldb);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_spbsvx")]
        public static extern int pbsvx(Layout layout, char fact, UpLoChar uplo, int n,
            int kd, int nrhs, float* ab,
            int ldab, float* afb, int ldafb,
            char[] equed, float* s, float* b, int ldb,
            float* x, int ldx, float* rcond, float* ferr,
            float* berr);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_spbsvx_work")]
        public static extern int pbsvx(Layout layout, char fact, UpLoChar uplo,
            int n, int kd, int nrhs,
            float* ab, int ldab, float* afb,
            int ldafb, char[] equed, float* s,
            float* b, int ldb, float* x,
            int ldx, float* rcond, float* ferr,
            float* berr, float* work, int* iwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_spbtrf")]
        public static extern int pbtrf(Layout layout, UpLoChar uplo, int n,
            int kd, float* ab, int ldab);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_spbtrs")]
        public static extern int pbtrs(Layout layout, UpLoChar uplo, int n,
            int kd, int nrhs, /* const */ [In] float* ab,
            int ldab, float* b, int ldb);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_spftrf")]
        public static extern int pftrf(Layout layout, TransChar transr, UpLoChar uplo,
            int n, float* a);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_spftri")]
        public static extern int pftri(Layout layout, TransChar transr, UpLoChar uplo,
            int n, float* a);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_spftrs")]
        public static extern int pftrs(Layout layout, TransChar transr, UpLoChar uplo,
            int n, int nrhs, /* const */ [In] float* a,
            float* b, int ldb);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_spocon")]
        public static extern int pocon(Layout layout, UpLoChar uplo, int n,
            /* const */ [In] float* a, int lda, float anorm,
            float* rcond);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_spocon_work")]
        public static extern int pocon(Layout layout, UpLoChar uplo, int n,
            /* const */ [In] float* a, int lda, float anorm,
            float* rcond, float* work, int* iwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_spoequ")]
        public static extern int poequ(Layout layout, int n, /* const */ [In] float* a,
            int lda, float* s, float* scond, float* amax);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_spoequb")]
        public static extern int poequb(Layout layout, int n, /* const */ [In] float* a,
            int lda, float* s, float* scond,
            float* amax);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sporfs")]
        public static extern int porfs(Layout layout, UpLoChar uplo, int n,
            int nrhs, /* const */ [In] float* a, int lda,
            /* const */ [In] float* af, int ldaf, /* const */ [In] float* b,
            int ldb, float* x, int ldx,
            float* ferr, float* berr);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sporfs_work")]
        public static extern int porfs(Layout layout, UpLoChar uplo, int n,
            int nrhs, /* const */ [In] float* a,
            int lda, /* const */ [In] float* af,
            int ldaf, /* const */ [In] float* b,
            int ldb, float* x, int ldx,
            float* ferr, float* berr, float* work,
            int* iwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sporfsx")]
        public static extern int porfsx(Layout layout, UpLoChar uplo, char equed,
            int n, int nrhs, /* const */ [In] float* a,
            int lda, /* const */ [In] float* af, int ldaf,
            /* const */ [In] float* s, /* const */ [In] float* b, int ldb,
            float* x, int ldx, float* rcond, float* berr,
            int n_err_bnds, float* err_bnds_norm,
            float* err_bnds_comp, int nparams,
            float* aparams);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sporfsx_work")]
        public static extern int porfsx(Layout layout, UpLoChar uplo, char equed,
            int n, int nrhs, /* const */ [In] float* a,
            int lda, /* const */ [In] float* af,
            int ldaf, /* const */ [In] float* s,
            /* const */ [In] float* b, int ldb, float* x,
            int ldx, float* rcond, float* berr,
            int n_err_bnds, float* err_bnds_norm,
            float* err_bnds_comp, int nparams,
            float* aparams, float* work,
            int* iwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sposv")]
        public static extern int posv(Layout layout, UpLoChar uplo, int n,
            int nrhs, float* a, int lda, float* b,
            int ldb);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sposvx")]
        public static extern int posvx(Layout layout, char fact, UpLoChar uplo, int n,
            int nrhs, float* a, int lda, float* af,
            int ldaf, char[] equed, float* s, float* b,
            int ldb, float* x, int ldx,
            float* rcond, float* ferr, float* berr);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sposvx_work")]
        public static extern int posvx(Layout layout, char fact, UpLoChar uplo,
            int n, int nrhs, float* a,
            int lda, float* af, int ldaf,
            char[] equed, float* s, float* b,
            int ldb, float* x, int ldx,
            float* rcond, float* ferr, float* berr,
            float* work, int* iwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sposvxx")]
        public static extern int posvxx(Layout layout, char fact, UpLoChar uplo,
            int n, int nrhs, float* a,
            int lda, float* af, int ldaf,
            char[] equed, float* s, float* b, int ldb,
            float* x, int ldx, float* rcond,
            float* rpvgrw, float* berr, int n_err_bnds,
            float* err_bnds_norm, float* err_bnds_comp,
            int nparams, float* aparams);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sposvxx_work")]
        public static extern int posvxx(Layout layout, char fact, UpLoChar uplo,
            int n, int nrhs, float* a,
            int lda, float* af, int ldaf,
            char[] equed, float* s, float* b,
            int ldb, float* x, int ldx,
            float* rcond, float* rpvgrw, float* berr,
            int n_err_bnds, float* err_bnds_norm,
            float* err_bnds_comp, int nparams,
            float* aparams, float* work,
            int* iwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_spotrf")]
        public static extern int potrf(Layout layout, UpLoChar uplo, int n, float* a,
            int lda);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_spotrf2")]
        public static extern int potrf2(Layout layout, UpLoChar uplo, int n, float* a,
            int lda);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_spotri")]
        public static extern int potri(Layout layout, UpLoChar uplo, int n, float* a,
            int lda);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_spotrs")]
        public static extern int potrs(Layout layout, UpLoChar uplo, int n,
            int nrhs, /* const */ [In] float* a, int lda,
            float* b, int ldb);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sppcon")]
        public static extern int ppcon(Layout layout, UpLoChar uplo, int n,
            /* const */ [In] float* ap, float anorm, float* rcond);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sppcon_work")]
        public static extern int ppcon(Layout layout, UpLoChar uplo, int n,
            /* const */ [In] float* ap, float anorm, float* rcond,
            float* work, int* iwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sppequ")]
        public static extern int ppequ(Layout layout, UpLoChar uplo, int n,
            /* const */ [In] float* ap, float* s, float* scond,
            float* amax);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_spprfs")]
        public static extern int pprfs(Layout layout, UpLoChar uplo, int n,
            int nrhs, /* const */ [In] float* ap, /* const */ [In] float* afp,
            /* const */ [In] float* b, int ldb, float* x,
            int ldx, float* ferr, float* berr);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_spprfs_work")]
        public static extern int pprfs(Layout layout, UpLoChar uplo, int n,
            int nrhs, /* const */ [In] float* ap,
            /* const */ [In] float* afp, /* const */ [In] float* b,
            int ldb, float* x, int ldx,
            float* ferr, float* berr, float* work,
            int* iwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sppsv")]
        public static extern int ppsv(Layout layout, UpLoChar uplo, int n,
            int nrhs, float* ap, float* b, int ldb);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sppsvx")]
        public static extern int ppsvx(Layout layout, char fact, UpLoChar uplo, int n,
            int nrhs, float* ap, float* afp, char[] equed,
            float* s, float* b, int ldb, float* x,
            int ldx, float* rcond, float* ferr,
            float* berr);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sppsvx_work")]
        public static extern int ppsvx(Layout layout, char fact, UpLoChar uplo,
            int n, int nrhs, float* ap,
            float* afp, char[] equed, float* s, float* b,
            int ldb, float* x, int ldx,
            float* rcond, float* ferr, float* berr,
            float* work, int* iwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_spptrf")]
        public static extern int pptrf(Layout layout, UpLoChar uplo, int n,
            float* ap);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_spptri")]
        public static extern int pptri(Layout layout, UpLoChar uplo, int n,
            float* ap);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_spptrs")]
        public static extern int pptrs(Layout layout, UpLoChar uplo, int n,
            int nrhs, /* const */ [In] float* ap, float* b,
            int ldb);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_spstrf")]
        public static extern int pstrf(Layout layout, UpLoChar uplo, int n, float* a,
            int lda, int* piv, ref int rank,
            float tol);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_spstrf_work")]
        public static extern int pstrf(Layout layout, UpLoChar uplo, int n,
            float* a, int lda, int* piv,
            ref int rank, float tol, float* work);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sptcon")]
        public static extern int ptcon(int n, /* const */ [In] float* d, /* const */ [In] float* e,
            float anorm, float* rcond);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sptcon_work")]
        public static extern int ptcon(int n, /* const */ [In] float* d, /* const */ [In] float* e,
            float anorm, float* rcond, float* work);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_spteqr")]
        public static extern int pteqr(Layout layout, char compz, int n, float* d,
            float* e, float* z, int ldz);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_spteqr_work")]
        public static extern int pteqr(Layout layout, char compz, int n,
            float* d, float* e, float* z, int ldz,
            float* work);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sptrfs")]
        public static extern int ptrfs(Layout layout, int n, int nrhs,
            /* const */ [In] float* d, /* const */ [In] float* e, /* const */ [In] float* df,
            /* const */ [In] float* ef, /* const */ [In] float* b, int ldb,
            float* x, int ldx, float* ferr, float* berr);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sptrfs_work")]
        public static extern int ptrfs(Layout layout, int n, int nrhs,
            /* const */ [In] float* d, /* const */ [In] float* e, /* const */ [In] float* df,
            /* const */ [In] float* ef, /* const */ [In] float* b, int ldb,
            float* x, int ldx, float* ferr,
            float* berr, float* work);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sptsv")]
        public static extern int ptsv(Layout layout, int n, int nrhs,
            float* d, float* e, float* b, int ldb);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sptsvx")]
        public static extern int ptsvx(Layout layout, char fact, int n,
            int nrhs, /* const */ [In] float* d, /* const */ [In] float* e,
            float* df, float* ef, /* const */ [In] float* b, int ldb,
            float* x, int ldx, float* rcond, float* ferr,
            float* berr);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sptsvx_work")]
        public static extern int ptsvx(Layout layout, char fact, int n,
            int nrhs, /* const */ [In] float* d, /* const */ [In] float* e,
            float* df, float* ef, /* const */ [In] float* b,
            int ldb, float* x, int ldx,
            float* rcond, float* ferr, float* berr,
            float* work);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_spttrf")]
        public static extern int pttrf(int n, float* d, float* e);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_spttrs")]
        public static extern int pttrs(Layout layout, int n, int nrhs,
            /* const */ [In] float* d, /* const */ [In] float* e, float* b,
            int ldb);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_ssbev")]
        public static extern int sbev(Layout layout, char jobz, UpLoChar uplo, int n,
            int kd, float* ab, int ldab, float* w,
            float* z, int ldz);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_ssbev_work")]
        public static extern int sbev(Layout layout, char jobz, UpLoChar uplo,
            int n, int kd, float* ab,
            int ldab, float* w, float* z,
            int ldz, float* work);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_ssbevd")]
        public static extern int sbevd(Layout layout, char jobz, UpLoChar uplo, int n,
            int kd, float* ab, int ldab, float* w,
            float* z, int ldz);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_ssbevd_work")]
        public static extern int sbevd(Layout layout, char jobz, UpLoChar uplo,
            int n, int kd, float* ab,
            int ldab, float* w, float* z,
            int ldz, float* work, int lwork,
            int* iwork, int liwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_ssbevx")]
        public static extern int sbevx(Layout layout, char jobz, char range, UpLoChar uplo,
            int n, int kd, float* ab,
            int ldab, float* q, int ldq, float vl,
            float vu, int il, int iu, float abstol,
            int* m, float* w, float* z, int ldz,
            int* ifail);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_ssbevx_work")]
        public static extern int sbevx(Layout layout, char jobz, char range,
            UpLoChar uplo, int n, int kd,
            float* ab, int ldab, float* q,
            int ldq, float vl, float vu,
            int il, int iu, float abstol,
            int* m, float* w, float* z,
            int ldz, float* work, int* iwork,
            int* ifail);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_ssbgst")]
        public static extern int sbgst(Layout layout, char vect, UpLoChar uplo, int n,
            int ka, int kb, float* ab,
            int ldab, /* const */ [In] float* bb, int ldbb,
            float* x, int ldx);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_ssbgst_work")]
        public static extern int sbgst(Layout layout, char vect, UpLoChar uplo,
            int n, int ka, int kb,
            float* ab, int ldab, /* const */ [In] float* bb,
            int ldbb, float* x, int ldx,
            float* work);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_ssbgv")]
        public static extern int sbgv(Layout layout, char jobz, UpLoChar uplo, int n,
            int ka, int kb, float* ab,
            int ldab, float* bb, int ldbb, float* w,
            float* z, int ldz);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_ssbgv_work")]
        public static extern int sbgv(Layout layout, char jobz, UpLoChar uplo,
            int n, int ka, int kb,
            float* ab, int ldab, float* bb,
            int ldbb, float* w, float* z,
            int ldz, float* work);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_ssbgvd")]
        public static extern int sbgvd(Layout layout, char jobz, UpLoChar uplo, int n,
            int ka, int kb, float* ab,
            int ldab, float* bb, int ldbb,
            float* w, float* z, int ldz);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_ssbgvd_work")]
        public static extern int sbgvd(Layout layout, char jobz, UpLoChar uplo,
            int n, int ka, int kb,
            float* ab, int ldab, float* bb,
            int ldbb, float* w, float* z,
            int ldz, float* work, int lwork,
            int* iwork, int liwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_ssbgvx")]
        public static extern int sbgvx(Layout layout, char jobz, char range, UpLoChar uplo,
            int n, int ka, int kb,
            float* ab, int ldab, float* bb,
            int ldbb, float* q, int ldq, float vl,
            float vu, int il, int iu, float abstol,
            int* m, float* w, float* z, int ldz,
            int* ifail);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_ssbgvx_work")]
        public static extern int sbgvx(Layout layout, char jobz, char range,
            UpLoChar uplo, int n, int ka,
            int kb, float* ab, int ldab,
            float* bb, int ldbb, float* q,
            int ldq, float vl, float vu,
            int il, int iu, float abstol,
            int* m, float* w, float* z,
            int ldz, float* work, int* iwork,
            int* ifail);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_ssbtrd")]
        public static extern int sbtrd(Layout layout, char vect, UpLoChar uplo, int n,
            int kd, float* ab, int ldab, float* d,
            float* e, float* q, int ldq);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_ssbtrd_work")]
        public static extern int sbtrd(Layout layout, char vect, UpLoChar uplo,
            int n, int kd, float* ab,
            int ldab, float* d, float* e, float* q,
            int ldq, float* work);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_ssfrk")]
        public static extern int sfrk(Layout layout, TransChar transr, UpLoChar uplo, TransChar trans,
            int n, int k, float alpha,
            /* const */ [In] float* a, int lda, float beta, float* c);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sspcon")]
        public static extern int spcon(Layout layout, UpLoChar uplo, int n,
            /* const */ [In] float* ap, int* ipiv, float anorm,
            float* rcond);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sspcon_work")]
        public static extern int spcon(Layout layout, UpLoChar uplo, int n,
            /* const */ [In] float* ap, int* ipiv,
            float anorm, float* rcond, float* work,
            int* iwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sspev")]
        public static extern int spev(Layout layout, char jobz, UpLoChar uplo, int n,
            float* ap, float* w, float* z, int ldz);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sspev_work")]
        public static extern int spev(Layout layout, char jobz, UpLoChar uplo,
            int n, float* ap, float* w, float* z,
            int ldz, float* work);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sspevd")]
        public static extern int spevd(Layout layout, char jobz, UpLoChar uplo, int n,
            float* ap, float* w, float* z, int ldz);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sspevd_work")]
        public static extern int spevd(Layout layout, char jobz, UpLoChar uplo,
            int n, float* ap, float* w, float* z,
            int ldz, float* work, int lwork,
            int* iwork, int liwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sspevx")]
        public static extern int spevx(Layout layout, char jobz, char range, UpLoChar uplo,
            int n, float* ap, float vl, float vu,
            int il, int iu, float abstol,
            int* m, float* w, float* z, int ldz,
            int* ifail);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sspevx_work")]
        public static extern int spevx(Layout layout, char jobz, char range,
            UpLoChar uplo, int n, float* ap, float vl,
            float vu, int il, int iu,
            float abstol, int* m, float* w, float* z,
            int ldz, float* work, int* iwork,
            int* ifail);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sspgst")]
        public static extern int spgst(Layout layout, int itype, UpLoChar uplo,
            int n, float* ap, float* bp);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sspgv")]
        public static extern int spgv(Layout layout, int itype, char jobz,
            UpLoChar uplo, int n, float* ap, float* bp,
            float* w, float* z, int ldz);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sspgv_work")]
        public static extern int spgv(Layout layout, int itype, char jobz,
            UpLoChar uplo, int n, float* ap, float* bp,
            float* w, float* z, int ldz, float* work);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sspgvd")]
        public static extern int spgvd(Layout layout, int itype, char jobz,
            UpLoChar uplo, int n, float* ap, float* bp,
            float* w, float* z, int ldz);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sspgvd_work")]
        public static extern int spgvd(Layout layout, int itype, char jobz,
            UpLoChar uplo, int n, float* ap, float* bp,
            float* w, float* z, int ldz, float* work,
            int lwork, int* iwork,
            int liwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sspgvx")]
        public static extern int spgvx(Layout layout, int itype, char jobz,
            char range, UpLoChar uplo, int n, float* ap,
            float* bp, float vl, float vu, int il,
            int iu, float abstol, int* m, float* w,
            float* z, int ldz, int* ifail);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sspgvx_work")]
        public static extern int spgvx(Layout layout, int itype, char jobz,
            char range, UpLoChar uplo, int n, float* ap,
            float* bp, float vl, float vu, int il,
            int iu, float abstol, int* m,
            float* w, float* z, int ldz, float* work,
            int* iwork, int* ifail);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_ssprfs")]
        public static extern int sprfs(Layout layout, UpLoChar uplo, int n,
            int nrhs, /* const */ [In] float* ap, /* const */ [In] float* afp,
            int* ipiv, /* const */ [In] float* b,
            int ldb, float* x, int ldx,
            float* ferr, float* berr);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_ssprfs_work")]
        public static extern int sprfs(Layout layout, UpLoChar uplo, int n,
            int nrhs, /* const */ [In] float* ap,
            /* const */ [In] float* afp, int* ipiv,
            /* const */ [In] float* b, int ldb, float* x,
            int ldx, float* ferr, float* berr,
            float* work, int* iwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sspsv")]
        public static extern int spsv(Layout layout, UpLoChar uplo, int n,
            int nrhs, float* ap, int* ipiv,
            float* b, int ldb);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sspsvx")]
        public static extern int spsvx(Layout layout, char fact, UpLoChar uplo, int n,
            int nrhs, /* const */ [In] float* ap, float* afp,
            int* ipiv, /* const */ [In] float* b, int ldb,
            float* x, int ldx, float* rcond, float* ferr,
            float* berr);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sspsvx_work")]
        public static extern int spsvx(Layout layout, char fact, UpLoChar uplo,
            int n, int nrhs, /* const */ [In] float* ap,
            float* afp, int* ipiv, /* const */ [In] float* b,
            int ldb, float* x, int ldx,
            float* rcond, float* ferr, float* berr,
            float* work, int* iwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_ssptrd")]
        public static extern int sptrd(Layout layout, UpLoChar uplo, int n, float* ap,
            float* d, float* e, float* tau);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_ssptrf")]
        public static extern int sptrf(Layout layout, UpLoChar uplo, int n, float* ap,
            int* ipiv);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_ssptri")]
        public static extern int sptri(Layout layout, UpLoChar uplo, int n, float* ap,
            int* ipiv);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_ssptri_work")]
        public static extern int sptri(Layout layout, UpLoChar uplo, int n,
            float* ap, int* ipiv, float* work);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_ssptrs")]
        public static extern int sptrs(Layout layout, UpLoChar uplo, int n,
            int nrhs, /* const */ [In] float* ap,
            int* ipiv, float* b, int ldb);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sstebz")]
        public static extern int stebz(char range, char order, int n, float vl,
            float vu, int il, int iu, float abstol,
            /* const */ [In] float* d, /* const */ [In] float* e, int* m,
            int* nsplit, float* w, int* iblock,
            int* isplit);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sstebz_work")]
        public static extern int stebz(char range, char order, int n, float vl,
            float vu, int il, int iu,
            float abstol, /* const */ [In] float* d, /* const */ [In] float* e,
            int* m, int* nsplit, float* w,
            int* iblock, int* isplit,
            float* work, int* iwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sstedc")]
        public static extern int stedc(Layout layout, char compz, int n, float* d,
            float* e, float* z, int ldz);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sstedc_work")]
        public static extern int stedc(Layout layout, char compz, int n,
            float* d, float* e, float* z, int ldz,
            float* work, int lwork,
            int* iwork, int liwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sstegr")]
        public static extern int stegr(Layout layout, char jobz, char range,
            int n, float* d, float* e, float vl, float vu,
            int il, int iu, float abstol,
            int* m, float* w, float* z, int ldz,
            int* isuppz);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sstegr_work")]
        public static extern int stegr(Layout layout, char jobz, char range,
            int n, float* d, float* e, float vl,
            float vu, int il, int iu,
            float abstol, int* m, float* w, float* z,
            int ldz, int* isuppz, float* work,
            int lwork, int* iwork,
            int liwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sstein")]
        public static extern int stein(Layout layout, int n, /* const */ [In] float* d,
            /* const */ [In] float* e, int m, /* const */ [In] float* w,
            int* iblock, int* isplit,
            float* z, int ldz, int* ifailv);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sstein_work")]
        public static extern int stein(Layout layout, int n, /* const */ [In] float* d,
            /* const */ [In] float* e, int m, /* const */ [In] float* w,
            int* iblock,
            int* isplit, float* z,
            int ldz, float* work, int* iwork,
            int* ifailv);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sstemr")]
        public static extern int stemr(Layout layout, char jobz, char range,
            int n, float* d, float* e, float vl, float vu,
            int il, int iu, int* m,
            float* w, float* z, int ldz, int nzc,
            int* isuppz, int* tryrac);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sstemr_work")]
        public static extern int stemr(Layout layout, char jobz, char range,
            int n, float* d, float* e, float vl,
            float vu, int il, int iu,
            int* m, float* w, float* z,
            int ldz, int nzc,
            int* isuppz, int* tryrac,
            float* work, int lwork,
            int* iwork, int liwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_ssteqr")]
        public static extern int steqr(Layout layout, char compz, int n, float* d,
            float* e, float* z, int ldz);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_ssteqr_work")]
        public static extern int steqr(Layout layout, char compz, int n,
            float* d, float* e, float* z, int ldz,
            float* work);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_ssterf")]
        public static extern int sterf(int n, float* d, float* e);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sstev")]
        public static extern int stev(Layout layout, char jobz, int n, float* d,
            float* e, float* z, int ldz);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sstev_work")]
        public static extern int stev(Layout layout, char jobz, int n,
            float* d, float* e, float* z, int ldz,
            float* work);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sstevd")]
        public static extern int stevd(Layout layout, char jobz, int n, float* d,
            float* e, float* z, int ldz);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sstevd_work")]
        public static extern int stevd(Layout layout, char jobz, int n,
            float* d, float* e, float* z, int ldz,
            float* work, int lwork,
            int* iwork, int liwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sstevr")]
        public static extern int stevr(Layout layout, char jobz, char range,
            int n, float* d, float* e, float vl, float vu,
            int il, int iu, float abstol,
            int* m, float* w, float* z, int ldz,
            int* isuppz);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sstevr_work")]
        public static extern int stevr(Layout layout, char jobz, char range,
            int n, float* d, float* e, float vl,
            float vu, int il, int iu,
            float abstol, int* m, float* w, float* z,
            int ldz, int* isuppz, float* work,
            int lwork, int* iwork,
            int liwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sstevx")]
        public static extern int stevx(Layout layout, char jobz, char range,
            int n, float* d, float* e, float vl, float vu,
            int il, int iu, float abstol,
            int* m, float* w, float* z, int ldz,
            int* ifail);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sstevx_work")]
        public static extern int stevx(Layout layout, char jobz, char range,
            int n, float* d, float* e, float vl,
            float vu, int il, int iu,
            float abstol, int* m, float* w, float* z,
            int ldz, float* work, int* iwork,
            int* ifail);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_ssycon")]
        public static extern int sycon(Layout layout, UpLoChar uplo, int n,
            /* const */ [In] float* a, int lda,
            int* ipiv, float anorm, float* rcond);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_ssycon_work")]
        public static extern int sycon(Layout layout, UpLoChar uplo, int n,
            /* const */ [In] float* a, int lda,
            int* ipiv, float anorm,
            float* rcond, float* work, int* iwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_ssyconv")]
        public static extern int syconv(Layout layout, UpLoChar uplo, char way, int n,
            float* a, int lda, int* ipiv,
            float* e);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_ssyequb")]
        public static extern int syequb(Layout layout, UpLoChar uplo, int n,
            /* const */ [In] float* a, int lda, float* s,
            float* scond, float* amax);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_ssyequb_work")]
        public static extern int syequb(Layout layout, UpLoChar uplo, int n,
            /* const */ [In] float* a, int lda, float* s,
            float* scond, float* amax, float* work);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_ssyev")]
        public static extern int syev(Layout layout, char jobz, UpLoChar uplo, int n,
            float* a, int lda, float* w);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_ssyev_work")]
        public static extern int syev(Layout layout, char jobz, UpLoChar uplo,
            int n, float* a, int lda, float* w,
            float* work, int lwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_ssyevd")]
        public static extern int syevd(Layout layout, char jobz, UpLoChar uplo, int n,
            float* a, int lda, float* w);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_ssyevd_work")]
        public static extern int syevd(Layout layout, char jobz, UpLoChar uplo,
            int n, float* a, int lda,
            float* w, float* work, int lwork,
            int* iwork, int liwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_ssyevr")]
        public static extern int syevr(Layout layout, char jobz, char range, UpLoChar uplo,
            int n, float* a, int lda, float vl,
            float vu, int il, int iu, float abstol,
            out int m, float* w, float* z, int ldz,
            int* isuppz);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_ssyevr_work")]
        public static extern int syevr(Layout layout, char jobz, char range,
            UpLoChar uplo, int n, float* a,
            int lda, float vl, float vu,
            int il, int iu, float abstol,
            out int m, float* w, float* z,
            int ldz, int* isuppz, float* work,
            int lwork, int* iwork,
            int liwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_ssyevx")]
        public static extern int syevx(Layout layout, char jobz, char range, UpLoChar uplo,
            int n, float* a, int lda, float vl,
            float vu, int il, int iu, float abstol,
            int* m, float* w, float* z, int ldz,
            int* ifail);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_ssyevx_work")]
        public static extern int syevx(Layout layout, char jobz, char range,
            UpLoChar uplo, int n, float* a,
            int lda, float vl, float vu,
            int il, int iu, float abstol,
            int* m, float* w, float* z,
            int ldz, float* work, int lwork,
            int* iwork, int* ifail);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_ssygst")]
        public static extern int sygst(Layout layout, int itype, UpLoChar uplo,
            int n, float* a, int lda,
            /* const */ [In] float* b, int ldb);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_ssygv")]
        public static extern int sygv(Layout layout, int itype, char jobz,
            UpLoChar uplo, int n, float* a, int lda,
            float* b, int ldb, float* w);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_ssygv_work")]
        public static extern int sygv(Layout layout, int itype, char jobz,
            UpLoChar uplo, int n, float* a,
            int lda, float* b, int ldb,
            float* w, float* work, int lwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_ssygvd")]
        public static extern int sygvd(Layout layout, int itype, char jobz,
            UpLoChar uplo, int n, float* a, int lda,
            float* b, int ldb, float* w);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_ssygvd_work")]
        public static extern int sygvd(Layout layout, int itype, char jobz,
            UpLoChar uplo, int n, float* a,
            int lda, float* b, int ldb,
            float* w, float* work, int lwork,
            int* iwork, int liwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_ssygvx")]
        public static extern int sygvx(Layout layout, int itype, char jobz,
            char range, UpLoChar uplo, int n, float* a,
            int lda, float* b, int ldb, float vl,
            float vu, int il, int iu, float abstol,
            int* m, float* w, float* z, int ldz,
            int* ifail);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_ssygvx_work")]
        public static extern int sygvx(Layout layout, int itype, char jobz,
            char range, UpLoChar uplo, int n, float* a,
            int lda, float* b, int ldb,
            float vl, float vu, int il,
            int iu, float abstol, int* m,
            float* w, float* z, int ldz, float* work,
            int lwork, int* iwork,
            int* ifail);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_ssyrfs")]
        public static extern int syrfs(Layout layout, UpLoChar uplo, int n,
            int nrhs, /* const */ [In] float* a, int lda,
            /* const */ [In] float* af, int ldaf,
            int* ipiv, /* const */ [In] float* b,
            int ldb, float* x, int ldx,
            float* ferr, float* berr);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_ssyrfs_work")]
        public static extern int syrfs(Layout layout, UpLoChar uplo, int n,
            int nrhs, /* const */ [In] float* a, int lda,
            /* const */ [In] float* af, int ldaf,
            int* ipiv, /* const */ [In] float* b,
            int ldb, float* x, int ldx,
            float* ferr, float* berr, float* work,
            int* iwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_ssyrfsx")]
        public static extern int syrfsx(Layout layout, UpLoChar uplo, char equed,
            int n, int nrhs, /* const */ [In] float* a,
            int lda, /* const */ [In] float* af, int ldaf,
            int* ipiv, /* const */ [In] float* s,
            /* const */ [In] float* b, int ldb, float* x,
            int ldx, float* rcond, float* berr,
            int n_err_bnds, float* err_bnds_norm,
            float* err_bnds_comp, int nparams,
            float* aparams);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_ssyrfsx_work")]
        public static extern int syrfsx(Layout layout, UpLoChar uplo, char equed,
            int n, int nrhs, /* const */ [In] float* a,
            int lda, /* const */ [In] float* af,
            int ldaf, int* ipiv,
            /* const */ [In] float* s, /* const */ [In] float* b, int ldb,
            float* x, int ldx, float* rcond,
            float* berr, int n_err_bnds,
            float* err_bnds_norm, float* err_bnds_comp,
            int nparams, float* aparams, float* work,
            int* iwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_ssysv")]
        public static extern int sysv(Layout layout, UpLoChar uplo, int n,
            int nrhs, float* a, int lda,
            int* ipiv, float* b, int ldb);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_ssysv_rook")]
        public static extern int sysv_rook(Layout layout, UpLoChar uplo, int n,
            int nrhs, float* a, int lda,
            int* ipiv, float* b, int ldb);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_ssysv_rook_work")]
        public static extern int sysv_rook(Layout layout, UpLoChar uplo, int n,
            int nrhs, float* a, int lda,
            int* ipiv, float* b, int ldb,
            float* work, int lwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_ssysv_work")]
        public static extern int sysv(Layout layout, UpLoChar uplo, int n,
            int nrhs, float* a, int lda,
            int* ipiv, float* b, int ldb,
            float* work, int lwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_ssysvx")]
        public static extern int sysvx(Layout layout, char fact, UpLoChar uplo, int n,
            int nrhs, /* const */ [In] float* a, int lda,
            float* af, int ldaf, int* ipiv,
            /* const */ [In] float* b, int ldb, float* x,
            int ldx, float* rcond, float* ferr,
            float* berr);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_ssysvx_work")]
        public static extern int sysvx(Layout layout, char fact, UpLoChar uplo,
            int n, int nrhs, /* const */ [In] float* a,
            int lda, float* af, int ldaf,
            int* ipiv, /* const */ [In] float* b,
            int ldb, float* x, int ldx,
            float* rcond, float* ferr, float* berr,
            float* work, int lwork,
            int* iwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_ssysvxx")]
        public static extern int sysvxx(Layout layout, char fact, UpLoChar uplo,
            int n, int nrhs, float* a,
            int lda, float* af, int ldaf,
            int* ipiv, char[] equed, float* s, float* b,
            int ldb, float* x, int ldx,
            float* rcond, float* rpvgrw, float* berr,
            int n_err_bnds, float* err_bnds_norm,
            float* err_bnds_comp, int nparams,
            float* aparams);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_ssysvxx_work")]
        public static extern int sysvxx(Layout layout, char fact, UpLoChar uplo,
            int n, int nrhs, float* a,
            int lda, float* af, int ldaf,
            int* ipiv, char[] equed, float* s,
            float* b, int ldb, float* x,
            int ldx, float* rcond, float* rpvgrw,
            float* berr, int n_err_bnds,
            float* err_bnds_norm, float* err_bnds_comp,
            int nparams, float* aparams, float* work,
            int* iwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_ssyswapr")]
        public static extern int syswapr(Layout layout, UpLoChar uplo, int n,
            float* a, int lda, int i1, int i2);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_ssytrd")]
        public static extern int sytrd(Layout layout, UpLoChar uplo, int n, float* a,
            int lda, float* d, float* e, float* tau);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_ssytrd_work")]
        public static extern int sytrd(Layout layout, UpLoChar uplo, int n,
            float* a, int lda, float* d, float* e,
            float* tau, float* work, int lwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_ssytrf")]
        public static extern int sytrf(Layout layout, UpLoChar uplo, int n, float* a,
            int lda, int* ipiv);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_ssytrf_rook")]
        public static extern int sytrf_rook(Layout layout, UpLoChar uplo, int n, float* a,
            int lda, int* ipiv);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_ssytrf_rook_work")]
        public static extern int sytrf_rook(Layout layout, UpLoChar uplo, int n,
            float* a, int lda, int* ipiv,
            float* work, int lwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_ssytrf_work")]
        public static extern int sytrf(Layout layout, UpLoChar uplo, int n,
            float* a, int lda, int* ipiv,
            float* work, int lwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_ssytri")]
        public static extern int sytri(Layout layout, UpLoChar uplo, int n, float* a,
            int lda, int* ipiv);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_ssytri2")]
        public static extern int sytri2(Layout layout, UpLoChar uplo, int n, float* a,
            int lda, int* ipiv);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_ssytri2_work")]
        public static extern int sytri2(Layout layout, UpLoChar uplo, int n,
            float* a, int lda,
            int* ipiv,
            float* work, int lwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_ssytri2x")]
        public static extern int sytri2x(Layout layout, UpLoChar uplo, int n,
            float* a, int lda, int* ipiv,
            int nb);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_ssytri2x_work")]
        public static extern int sytri2x(Layout layout, UpLoChar uplo, int n,
            float* a, int lda,
            int* ipiv, float* work,
            int nb);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_ssytri_work")]
        public static extern int sytri(Layout layout, UpLoChar uplo, int n,
            float* a, int lda,
            int* ipiv, float* work);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_ssytrs")]
        public static extern int sytrs(Layout layout, UpLoChar uplo, int n,
            int nrhs, /* const */ [In] float* a, int lda,
            int* ipiv, float* b, int ldb);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_ssytrs2")]
        public static extern int sytrs2(Layout layout, UpLoChar uplo, int n,
            int nrhs, /* const */ [In] float* a, int lda,
            int* ipiv, float* b, int ldb);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_ssytrs2_work")]
        public static extern int sytrs2(Layout layout, UpLoChar uplo, int n,
            int nrhs, /* const */ [In] float* a,
            int lda, int* ipiv,
            float* b, int ldb, float* work);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_ssytrs_rook")]
        public static extern int sytrs_rook(Layout layout, UpLoChar uplo, int n,
            int nrhs, /* const */ [In] float* a, int lda,
            int* ipiv, float* b, int ldb);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_stbcon")]
        public static extern int tbcon(Layout layout, Norm norm, UpLoChar uplo, DiagChar diag,
            int n, int kd, /* const */ [In] float* ab,
            int ldab, float* rcond);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_stbcon_work")]
        public static extern int tbcon(Layout layout, Norm norm, UpLoChar uplo,
            DiagChar diag, int n, int kd,
            /* const */ [In] float* ab, int ldab, float* rcond,
            float* work, int* iwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_stbrfs")]
        public static extern int tbrfs(Layout layout, UpLoChar uplo, TransChar trans, DiagChar diag,
            int n, int kd, int nrhs,
            /* const */ [In] float* ab, int ldab, /* const */ [In] float* b,
            int ldb, /* const */ [In] float* x, int ldx,
            float* ferr, float* berr);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_stbrfs_work")]
        public static extern int tbrfs(Layout layout, UpLoChar uplo, TransChar trans,
            DiagChar diag, int n, int kd,
            int nrhs, /* const */ [In] float* ab,
            int ldab, /* const */ [In] float* b, int ldb,
            /* const */ [In] float* x, int ldx, float* ferr,
            float* berr, float* work, int* iwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_stbtrs")]
        public static extern int tbtrs(Layout layout, UpLoChar uplo, TransChar trans, DiagChar diag,
            int n, int kd, int nrhs,
            /* const */ [In] float* ab, int ldab, float* b,
            int ldb);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_stfsm")]
        public static extern int tfsm(Layout layout, TransChar transr, char side, UpLoChar uplo,
            TransChar trans, DiagChar diag, int m, int n,
            float alpha, /* const */ [In] float* a, float* b,
            int ldb);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_stftri")]
        public static extern int tftri(Layout layout, TransChar transr, UpLoChar uplo, DiagChar diag,
            int n, float* a);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_stfttp")]
        public static extern int tfttp(Layout layout, TransChar transr, UpLoChar uplo,
            int n, /* const */ [In] float* arf, float* ap);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_stfttr")]
        public static extern int tfttr(Layout layout, TransChar transr, UpLoChar uplo,
            int n, /* const */ [In] float* arf, float* a,
            int lda);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_stgevc")]
        public static extern int tgevc(Layout layout, char side, char howmny,
            int* select, int n,
            /* const */ [In] float* s, int lds, /* const */ [In] float* p,
            int ldp, float* vl, int ldvl,
            float* vr, int ldvr, int mm,
            int* m);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_stgevc_work")]
        public static extern int tgevc(Layout layout, char side, char howmny,
            int* select, int n,
            /* const */ [In] float* s, int lds, /* const */ [In] float* p,
            int ldp, float* vl, int ldvl,
            float* vr, int ldvr, int mm,
            int* m, float* work);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_stgexc")]
        public static extern int tgexc(Layout layout, int wantq,
            int wantz, int n, float* a,
            int lda, float* b, int ldb, float* q,
            int ldq, float* z, int ldz,
            int* ifst, int* ilst);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_stgexc_work")]
        public static extern int tgexc(Layout layout, int wantq,
            int wantz, int n, float* a,
            int lda, float* b, int ldb,
            float* q, int ldq, float* z,
            int ldz, int* ifst,
            int* ilst, float* work,
            int lwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_stgsen")]
        public static extern int tgsen(Layout layout, int ijob,
            int wantq, int wantz,
            int* select, int n, float* a,
            int lda, float* b, int ldb,
            float* alphar, float* alphai, float* beta, float* q,
            int ldq, float* z, int ldz,
            int* m, float* pl, float* pr, float* dif);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_stgsen_work")]
        public static extern int tgsen(Layout layout, int ijob,
            int wantq, int wantz,
            int* select, int n,
            float* a, int lda, float* b,
            int ldb, float* alphar, float* alphai,
            float* beta, float* q, int ldq, float* z,
            int ldz, int* m, float* pl,
            float* pr, float* dif, float* work,
            int lwork, int* iwork,
            int liwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_stgsja")]
        public static extern int tgsja(Layout layout, char jobu, char jobv, char jobq,
            int m, int p, int n,
            int k, int l, float* a, int lda,
            float* b, int ldb, float tola, float tolb,
            float* alpha, float* beta, float* u, int ldu,
            float* v, int ldv, float* q, int ldq,
            int* ncycle);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_stgsja_work")]
        public static extern int tgsja(Layout layout, char jobu, char jobv,
            char jobq, int m, int p,
            int n, int k, int l,
            float* a, int lda, float* b,
            int ldb, float tola, float tolb,
            float* alpha, float* beta, float* u,
            int ldu, float* v, int ldv,
            float* q, int ldq, float* work,
            int* ncycle);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_stgsna")]
        public static extern int tgsna(Layout layout, char job, char howmny,
            int* select, int n,
            /* const */ [In] float* a, int lda, /* const */ [In] float* b,
            int ldb, /* const */ [In] float* vl, int ldvl,
            /* const */ [In] float* vr, int ldvr, float* s,
            float* dif, int mm, int* m);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_stgsna_work")]
        public static extern int tgsna(Layout layout, char job, char howmny,
            int* select, int n,
            /* const */ [In] float* a, int lda, /* const */ [In] float* b,
            int ldb, /* const */ [In] float* vl,
            int ldvl, /* const */ [In] float* vr,
            int ldvr, float* s, float* dif,
            int mm, int* m, float* work,
            int lwork, int* iwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_stgsyl")]
        public static extern int tgsyl(Layout layout, TransChar trans, int ijob,
            int m, int n, /* const */ [In] float* a,
            int lda, /* const */ [In] float* b, int ldb,
            float* c, int ldc, /* const */ [In] float* d,
            int ldd, /* const */ [In] float* e, int lde,
            float* f, int ldf, float* scale, float* dif);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_stgsyl_work")]
        public static extern int tgsyl(Layout layout, TransChar trans, int ijob,
            int m, int n, /* const */ [In] float* a,
            int lda, /* const */ [In] float* b, int ldb,
            float* c, int ldc, /* const */ [In] float* d,
            int ldd, /* const */ [In] float* e, int lde,
            float* f, int ldf, float* scale,
            float* dif, float* work, int lwork,
            int* iwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_stpcon")]
        public static extern int tpcon(Layout layout, Norm norm, UpLoChar uplo, DiagChar diag,
            int n, /* const */ [In] float* ap, float* rcond);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_stpcon_work")]
        public static extern int tpcon(Layout layout, Norm norm, UpLoChar uplo,
            DiagChar diag, int n, /* const */ [In] float* ap,
            float* rcond, float* work, int* iwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_stpmqrt")]
        public static extern int tpmqrt(Layout layout, char side, TransChar trans,
            int m, int n, int k,
            int l, int nb, /* const */ [In] float* v,
            int ldv, /* const */ [In] float* t, int ldt,
            float* a, int lda, float* b, int ldb);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_stpmqrt_work")]
        public static extern int tpmqrt(Layout layout, char side, TransChar trans,
            int m, int n, int k,
            int l, int nb, /* const */ [In] float* v,
            int ldv, /* const */ [In] float* t, int ldt,
            float* a, int lda, float* b,
            int ldb, float* work);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_stpqrt")]
        public static extern int tpqrt(Layout layout, int m, int n,
            int l, int nb, float* a,
            int lda, float* b, int ldb, float* t,
            int ldt);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_stpqrt2")]
        public static extern int tpqrt2(Layout layout, int m, int n,
            int l,
            float* a, int lda, float* b, int ldb,
            float* t, int ldt);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_stpqrt_work")]
        public static extern int tpqrt(Layout layout, int m, int n,
            int l, int nb, float* a,
            int lda, float* b, int ldb,
            float* t, int ldt, float* work);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_stprfb")]
        public static extern int tprfb(Layout layout, char side, TransChar trans, char direct,
            char storev, int m, int n,
            int k, int l, /* const */ [In] float* v,
            int ldv, /* const */ [In] float* t, int ldt,
            float* a, int lda, float* b, int ldb);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_stprfb_work")]
        public static extern int tprfb(Layout layout, char side, TransChar trans,
            char direct, char storev, int m,
            int n, int k, int l,
            /* const */ [In] float* v, int ldv, /* const */ [In] float* t,
            int ldt, float* a, int lda,
            float* b, int ldb, float* work,
            int ldwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_stprfs")]
        public static extern int tprfs(Layout layout, UpLoChar uplo, TransChar trans, DiagChar diag,
            int n, int nrhs, /* const */ [In] float* ap,
            /* const */ [In] float* b, int ldb, /* const */ [In] float* x,
            int ldx, float* ferr, float* berr);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_stprfs_work")]
        public static extern int tprfs(Layout layout, UpLoChar uplo, TransChar trans,
            DiagChar diag, int n, int nrhs,
            /* const */ [In] float* ap, /* const */ [In] float* b, int ldb,
            /* const */ [In] float* x, int ldx, float* ferr,
            float* berr, float* work, int* iwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_stptri")]
        public static extern int tptri(Layout layout, UpLoChar uplo, DiagChar diag, int n,
            float* ap);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_stptrs")]
        public static extern int tptrs(Layout layout, UpLoChar uplo, TransChar trans, DiagChar diag,
            int n, int nrhs, /* const */ [In] float* ap,
            float* b, int ldb);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_stpttf")]
        public static extern int tpttf(Layout layout, TransChar transr, UpLoChar uplo,
            int n, /* const */ [In] float* ap, float* arf);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_stpttr")]
        public static extern int tpttr(Layout layout, UpLoChar uplo, int n,
            /* const */ [In] float* ap, float* a, int lda);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_strcon")]
        public static extern int trcon(Layout layout, Norm norm, UpLoChar uplo, DiagChar diag,
            int n, /* const */ [In] float* a, int lda,
            float* rcond);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_strcon_work")]
        public static extern int trcon(Layout layout, Norm norm, UpLoChar uplo,
            DiagChar diag, int n, /* const */ [In] float* a,
            int lda, float* rcond, float* work,
            int* iwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_strevc")]
        public static extern int trevc(Layout layout, char side, char howmny,
            int* select, int n, /* const */ [In] float* t,
            int ldt, float* vl, int ldvl,
            float* vr, int ldvr, int mm,
            int* m);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_strevc_work")]
        public static extern int trevc(Layout layout, char side, char howmny,
            int* select, int n,
            /* const */ [In] float* t, int ldt, float* vl,
            int ldvl, float* vr, int ldvr,
            int mm, int* m, float* work);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_strexc")]
        public static extern int trexc(Layout layout, char compq, int n, float* t,
            int ldt, float* q, int ldq,
            int* ifst, int* ilst);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_strexc_work")]
        public static extern int trexc(Layout layout, char compq, int n,
            float* t, int ldt, float* q,
            int ldq, int* ifst,
            int* ilst, float* work);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_strrfs")]
        public static extern int trrfs(Layout layout, UpLoChar uplo, TransChar trans, DiagChar diag,
            int n, int nrhs, /* const */ [In] float* a,
            int lda, /* const */ [In] float* b, int ldb,
            /* const */ [In] float* x, int ldx, float* ferr,
            float* berr);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_strrfs_work")]
        public static extern int trrfs(Layout layout, UpLoChar uplo, TransChar trans,
            DiagChar diag, int n, int nrhs,
            /* const */ [In] float* a, int lda, /* const */ [In] float* b,
            int ldb, /* const */ [In] float* x, int ldx,
            float* ferr, float* berr, float* work,
            int* iwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_strsen")]
        public static extern int trsen(Layout layout, char job, char compq,
            int* select, int n, float* t,
            int ldt, float* q, int ldq, float* wr,
            float* wi, int* m, float* s, float* sep);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_strsen_work")]
        public static extern int trsen(Layout layout, char job, char compq,
            int* select, int n,
            float* t, int ldt, float* q,
            int ldq, float* wr, float* wi,
            int* m, float* s, float* sep,
            float* work, int lwork,
            int* iwork, int liwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_strsna")]
        public static extern int trsna(Layout layout, char job, char howmny,
            int* select, int n,
            /* const */ [In] float* t, int ldt, /* const */ [In] float* vl,
            int ldvl, /* const */ [In] float* vr, int ldvr,
            float* s, float* sep, int mm, int* m);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_strsna_work")]
        public static extern int trsna(Layout layout, char job, char howmny,
            int* select, int n,
            /* const */ [In] float* t, int ldt, /* const */ [In] float* vl,
            int ldvl, /* const */ [In] float* vr,
            int ldvr, float* s, float* sep,
            int mm, int* m, float* work,
            int ldwork, int* iwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_strsyl")]
        public static extern int trsyl(Layout layout, char trana, char tranb,
            int isgn, int m, int n,
            /* const */ [In] float* a, int lda, /* const */ [In] float* b,
            int ldb, float* c, int ldc,
            float* scale);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_strtri")]
        public static extern int trtri(Layout layout, UpLoChar uplo, DiagChar diag, int n,
            float* a, int lda);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_strtrs")]
        public static extern int trtrs(Layout layout, UpLoChar uplo, TransChar trans, DiagChar diag,
            int n, int nrhs, /* const */ [In] float* a,
            int lda, float* b, int ldb);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_strttf")]
        public static extern int trttf(Layout layout, TransChar transr, UpLoChar uplo,
            int n, /* const */ [In] float* a, int lda,
            float* arf);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_strttp")]
        public static extern int trttp(Layout layout, UpLoChar uplo, int n,
            /* const */ [In] float* a, int lda, float* ap);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_stzrzf")]
        public static extern int tzrzf(Layout layout, int m, int n,
            float* a, int lda, float* tau);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_stzrzf_work")]
        public static extern int tzrzf(Layout layout, int m, int n,
            float* a, int lda, float* tau,
            float* work, int lwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dsysv_aa")]
        public static extern int sysv_aa(Layout layout, UpLoChar uplo, int n,
            int nrhs, double* a, int lda,
            int* ipiv, double* b, int ldb);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dsysv_aa_work")]
        public static extern int sysv_aa(Layout layout, UpLoChar uplo, int n,
            int nrhs, double* a, int lda,
            int* ipiv, double* b, int ldb,
            double* work, int lwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dsytrf_aa")]
        public static extern int sytrf_aa(Layout layout, UpLoChar uplo, int n,
            double* a, int lda, int* ipiv);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dsytrf_aa_work")]
        public static extern int sytrf_aa(Layout layout, UpLoChar uplo, int n,
            double* a, int lda, int* ipiv,
            double* work, int lwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dsytrs_aa")]
        public static extern int sytrs_aa(Layout layout, UpLoChar uplo, int n,
            int nrhs, /* const */ [In] double* a, int lda,
            int* ipiv, double* b,
            int ldb);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dsytrs_aa_work")]
        public static extern int sytrs_aa(Layout layout, UpLoChar uplo, int n,
            int nrhs, /* const */ [In] double* a,
            int lda, int* ipiv,
            double* b, int ldb, double* work,
            int lwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_ssysv_aa")]
        public static extern int sysv_aa(Layout layout, UpLoChar uplo, int n,
            int nrhs, float* a, int lda,
            int* ipiv, float* b, int ldb);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_ssysv_aa_work")]
        public static extern int sysv_aa(Layout layout, UpLoChar uplo, int n,
            int nrhs, float* a, int lda,
            int* ipiv, float* b, int ldb,
            float* work, int lwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_ssytrf_aa")]
        public static extern int sytrf_aa(Layout layout, UpLoChar uplo, int n,
            float* a, int lda, int* ipiv);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_ssytrf_aa_work")]
        public static extern int sytrf_aa(Layout layout, UpLoChar uplo, int n,
            float* a, int lda, int* ipiv,
            float* work, int lwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_ssytrs_aa")]
        public static extern int sytrs_aa(Layout layout, UpLoChar uplo, int n,
            int nrhs, /* const */ [In] float* a, int lda,
            int* ipiv, float* b,
            int ldb);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_ssytrs_aa_work")]
        public static extern int sytrs_aa(Layout layout, UpLoChar uplo, int n,
            int nrhs, /* const */ [In] float* a,
            int lda, int* ipiv,
            float* b, int ldb, float* work,
            int lwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dgemqr")]
        public static extern int gemqr(Layout layout, char side, TransChar trans,
            int m, int n, int k,
            /* const */ [In] double* a, int lda,
            /* const */ [In] double* t, int tsize, double* c,
            int ldc);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dgemqr_work")]
        public static extern int gemqr(Layout layout, char side, TransChar trans,
            int m, int n, int k,
            /* const */ [In] double* a, int lda,
            /* const */ [In] double* t, int tsize,
            double* c, int ldc, double* work,
            int lwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dgeqr")]
        public static extern int geqr(Layout layout, int m, int n,
            double* a, int lda, double* t,
            int tsize);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dgeqr_work")]
        public static extern int geqr(Layout layout, int m, int n,
            double* a, int lda, double* t,
            int tsize, double* work,
            int lwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sgemqr")]
        public static extern int gemqr(Layout layout, char side, TransChar trans,
            int m, int n, int k,
            /* const */ [In] float* a, int lda, /* const */ [In] float* t,
            int tsize, float* c, int ldc);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sgemqr_work")]
        public static extern int gemqr(Layout layout, char side, TransChar trans,
            int m, int n, int k,
            /* const */ [In] float* a, int lda,
            /* const */ [In] float* t, int tsize,
            float* c, int ldc, float* work,
            int lwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sgeqr")]
        public static extern int geqr(Layout layout, int m, int n,
            float* a, int lda, float* t,
            int tsize);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sgeqr_work")]
        public static extern int geqr(Layout layout, int m, int n,
            float* a, int lda, float* t,
            int tsize, float* work,
            int lwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dgelq")]
        public static extern int gelq(Layout layout, int m, int n,
            double* a, int lda, double* t,
            int tsize);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dgelq_work")]
        public static extern int gelq(Layout layout, int m, int n,
            double* a, int lda, double* t,
            int tsize, double* work,
            int lwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dgemlq")]
        public static extern int gemlq(Layout layout, char side, TransChar trans,
            int m, int n, int k,
            /* const */ [In] double* a, int lda, /* const */ [In] double* t,
            int tsize, double* c, int ldc);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dgemlq_work")]
        public static extern int gemlq(Layout layout, char side, TransChar trans,
            int m, int n, int k,
            /* const */ [In] double* a, int lda,
            /* const */ [In] double* t, int tsize, double* c,
            int ldc, double* work,
            int lwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sgelq")]
        public static extern int gelq(Layout layout, int m, int n,
            float* a, int lda, float* t,
            int tsize);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sgelq_work")]
        public static extern int gelq(Layout layout, int m, int n,
            float* a, int lda, float* t,
            int tsize, float* work,
            int lwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sgemlq")]
        public static extern int gemlq(Layout layout, char side, TransChar trans,
            int m, int n, int k,
            /* const */ [In] float* a, int lda, /* const */ [In] float* t,
            int tsize, float* c, int ldc);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sgemlq_work")]
        public static extern int gemlq(Layout layout, char side, TransChar trans,
            int m, int n, int k,
            /* const */ [In] float* a, int lda, /* const */ [In] float* t,
            int tsize, float* c, int ldc,
            float* work, int lwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dgetsls")]
        public static extern int getsls(Layout layout, TransChar trans, int m,
            int n, int nrhs, double* a,
            int lda, double* b, int ldb);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dgetsls_work")]
        public static extern int getsls(Layout layout, TransChar trans, int m,
            int n, int nrhs, double* a,
            int lda, double* b, int ldb,
            double* work, int lwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sgetsls")]
        public static extern int getsls(Layout layout, TransChar trans, int m,
            int n, int nrhs, float* a,
            int lda, float* b, int ldb);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_sgetsls_work")]
        public static extern int getsls(Layout layout, TransChar trans, int m,
            int n, int nrhs, float* a,
            int lda, float* b, int ldb,
            float* work, int lwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dsycon_3")]
        public static extern int sycon_3(Layout layout, UpLoChar uplo, int n,
            double* a, int lda, double* e,
            int* ipiv, double anorm,
            double* rcond);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dsycon_3_work")]
        public static extern int sycon_3(Layout layout, UpLoChar uplo, int n,
            double* a, int lda,
            double* e, int* ipiv,
            double anorm, double* rcond, double* work,
            int* iwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dsysv_rk")]
        public static extern int sysv_rk(Layout layout, UpLoChar uplo, int n,
            int nrhs, double* a, int lda,
            double* e, int* ipiv, double* b,
            int ldb);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dsysv_rk_work")]
        public static extern int sysv_rk(Layout layout, UpLoChar uplo, int n,
            int nrhs, double* a, int lda,
            double* e, int* ipiv, double* b,
            int ldb, double* work,
            int lwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dsytrf_rk")]
        public static extern int sytrf_rk(Layout layout, UpLoChar uplo, int n,
            double* a, int lda, double* e,
            int* ipiv);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dsytrf_rk_work")]
        public static extern int sytrf_rk(Layout layout, UpLoChar uplo, int n,
            double* a, int lda, double* e,
            int* ipiv, double* work,
            int lwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dsytri_3")]
        public static extern int sytri_3(Layout layout, UpLoChar uplo, int n,
            double* a, int lda, double* e,
            int* ipiv);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dsytri_3_work")]
        public static extern int sytri_3(Layout layout, UpLoChar uplo, int n,
            double* a, int lda, double* e,
            int* ipiv, double* work,
            int lwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dsytrs_3")]
        public static extern int sytrs_3(Layout layout, UpLoChar uplo, int n,
            int nrhs, double* a, int lda,
            double* e, int* ipiv,
            double* b, int ldb);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_ssycon_3")]
        public static extern int sycon_3(Layout layout, UpLoChar uplo, int n,
            float* a, int lda, float* e,
            int* ipiv, float anorm,
            float* rcond);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_ssycon_3_work")]
        public static extern int sycon_3(Layout layout, UpLoChar uplo, int n,
            float* a, int lda,
            float* e, int* ipiv,
            float anorm, float* rcond, float* work,
            int* iwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_ssysv_rk")]
        public static extern int sysv_rk(Layout layout, UpLoChar uplo, int n,
            int nrhs, float* a, int lda,
            float* e, int* ipiv, float* b,
            int ldb);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_ssysv_rk_work")]
        public static extern int sysv_rk(Layout layout, UpLoChar uplo, int n,
            int nrhs, float* a, int lda,
            float* e, int* ipiv, float* b,
            int ldb, float* work,
            int lwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_ssytrf_rk")]
        public static extern int sytrf_rk(Layout layout, UpLoChar uplo, int n,
            float* a, int lda, float* e,
            int* ipiv);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_ssytrf_rk_work")]
        public static extern int sytrf_rk(Layout layout, UpLoChar uplo, int n,
            float* a, int lda, float* e,
            int* ipiv, float* work,
            int lwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_ssytri_3")]
        public static extern int sytri_3(Layout layout, UpLoChar uplo, int n,
            float* a, int lda, float* e,
            int* ipiv);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_ssytri_3_work")]
        public static extern int sytri_3(Layout layout, UpLoChar uplo, int n,
            float* a, int lda, float* e,
            int* ipiv, float* work,
            int lwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_ssytrs_3")]
        public static extern int sytrs_3(Layout layout, UpLoChar uplo, int n,
            int nrhs, float* a, int lda,
            float* e, int* ipiv, float* b,
            int ldb);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dsbev_2stage")]
        public static extern int sbev_2stage(Layout layout, char jobz, UpLoChar uplo,
            int n, int kd, double* ab,
            int ldab, double* w, double* z,
            int ldz);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dsbev_2stage_work")]
        public static extern int sbev_2stage(Layout layout, char jobz, UpLoChar uplo,
            int n, int kd, double* ab,
            int ldab, double* w, double* z,
            int ldz, double* work,
            int lwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dsbevd_2stage")]
        public static extern int sbevd_2stage(Layout layout, char jobz, UpLoChar uplo,
            int n, int kd, double* ab,
            int ldab, double* w, double* z,
            int ldz);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dsbevd_2stage_work")]
        public static extern int sbevd_2stage(Layout layout, char jobz, UpLoChar uplo,
            int n, int kd, double* ab,
            int ldab, double* w, double* z,
            int ldz, double* work,
            int lwork, int* iwork,
            int liwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dsbevx_2stage")]
        public static extern int sbevx_2stage(Layout layout, char jobz, char range,
            UpLoChar uplo, int n, int kd,
            double* ab, int ldab, double* q,
            int ldq, double vl, double vu,
            int il, int iu, double abstol,
            int* m, double* w, double* z,
            int ldz, int* ifail);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dsbevx_2stage_work")]
        public static extern int sbevx_2stage(Layout layout, char jobz,
            char range, UpLoChar uplo, int n,
            int kd, double* ab,
            int ldab, double* q,
            int ldq, double vl, double vu,
            int il, int iu,
            double abstol, int* m, double* w,
            double* z, int ldz, double* work,
            int lwork, int* iwork,
            int* ifail);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dsyev_2stage")]
        public static extern int syev_2stage(Layout layout, char jobz, UpLoChar uplo,
            int n, double* a, int lda,
            double* w);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dsyev_2stage_work")]
        public static extern int syev_2stage(Layout layout, char jobz, UpLoChar uplo,
            int n, double* a, int lda,
            double* w, double* work,
            int lwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dsyevd_2stage")]
        public static extern int syevd_2stage(Layout layout, char jobz, UpLoChar uplo,
            int n, double* a, int lda,
            double* w);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dsyevd_2stage_work")]
        public static extern int syevd_2stage(Layout layout, char jobz, UpLoChar uplo,
            int n, double* a, int lda,
            double* w, double* work,
            int lwork, int* iwork,
            int liwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dsyevr_2stage")]
        public static extern int syevr_2stage(Layout layout, char jobz, char range,
            UpLoChar uplo, int n, double* a,
            int lda, double vl, double vu,
            int il, int iu, double abstol,
            int* m, double* w, double* z,
            int ldz, int* isuppz);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dsyevr_2stage_work")]
        public static extern int syevr_2stage(Layout layout, char jobz,
            char range, UpLoChar uplo, int n,
            double* a, int lda, double vl,
            double vu, int il, int iu,
            double abstol, int* m, double* w,
            double* z, int ldz,
            int* isuppz, double* work,
            int lwork, int* iwork,
            int liwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dsyevx_2stage")]
        public static extern int syevx_2stage(Layout layout, char jobz, char range,
            UpLoChar uplo, int n, double* a,
            int lda, double vl, double vu,
            int il, int iu, double abstol,
            int* m, double* w, double* z,
            int ldz, int* ifail);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dsyevx_2stage_work")]
        public static extern int syevx_2stage(Layout layout, char jobz,
            char range, UpLoChar uplo, int n,
            double* a, int lda, double vl,
            double vu, int il, int iu,
            double abstol, int* m, double* w,
            double* z, int ldz, double* work,
            int lwork, int* iwork,
            int* ifail);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dsygv_2stage")]
        public static extern int sygv_2stage(Layout layout, int itype,
            char jobz, UpLoChar uplo, int n, double* a,
            int lda, double* b, int ldb,
            double* w);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dsygv_2stage_work")]
        public static extern int sygv_2stage(Layout layout, int itype,
            char jobz, UpLoChar uplo, int n,
            double* a, int lda, double* b,
            int ldb, double* w, double* work,
            int lwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_ssbev_2stage")]
        public static extern int sbev_2stage(Layout layout, char jobz, UpLoChar uplo,
            int n, int kd, float* ab,
            int ldab, float* w, float* z,
            int ldz);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_ssbev_2stage_work")]
        public static extern int sbev_2stage(Layout layout, char jobz, UpLoChar uplo,
            int n, int kd, float* ab,
            int ldab, float* w, float* z,
            int ldz, float* work,
            int lwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_ssbevd_2stage")]
        public static extern int sbevd_2stage(Layout layout, char jobz, UpLoChar uplo,
            int n, int kd, float* ab,
            int ldab, float* w, float* z,
            int ldz);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_ssbevd_2stage_work")]
        public static extern int sbevd_2stage(Layout layout, char jobz, UpLoChar uplo,
            int n, int kd, float* ab,
            int ldab, float* w, float* z,
            int ldz, float* work,
            int lwork, int* iwork,
            int liwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_ssbevx_2stage")]
        public static extern int sbevx_2stage(Layout layout, char jobz, char range,
            UpLoChar uplo, int n, int kd,
            float* ab, int ldab, float* q,
            int ldq, float vl, float vu,
            int il, int iu, float abstol,
            int* m, float* w, float* z,
            int ldz, int* ifail);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_ssbevx_2stage_work")]
        public static extern int sbevx_2stage(Layout layout, char jobz,
            char range, UpLoChar uplo, int n,
            int kd, float* ab,
            int ldab, float* q,
            int ldq, float vl, float vu,
            int il, int iu,
            float abstol, int* m, float* w,
            float* z, int ldz, float* work,
            int lwork, int* iwork,
            int* ifail);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_ssyev_2stage")]
        public static extern int syev_2stage(Layout layout, char jobz, UpLoChar uplo,
            int n, float* a, int lda,
            float* w);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_ssyev_2stage_work")]
        public static extern int syev_2stage(Layout layout, char jobz, UpLoChar uplo,
            int n, float* a, int lda,
            float* w, float* work, int lwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_ssyevd_2stage")]
        public static extern int syevd_2stage(Layout layout, char jobz, UpLoChar uplo,
            int n, float* a, int lda,
            float* w);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_ssyevd_2stage_work")]
        public static extern int syevd_2stage(Layout layout, char jobz, UpLoChar uplo,
            int n, float* a, int lda,
            float* w, float* work, int lwork,
            int* iwork, int liwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_ssyevr_2stage")]
        public static extern int syevr_2stage(Layout layout, char jobz, char range,
            UpLoChar uplo, int n, float* a,
            int lda, float vl, float vu,
            int il, int iu, float abstol,
            int* m, float* w, float* z,
            int ldz, int* isuppz);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_ssyevr_2stage_work")]
        public static extern int syevr_2stage(Layout layout, char jobz,
            char range, UpLoChar uplo, int n,
            float* a, int lda, float vl,
            float vu, int il, int iu,
            float abstol, int* m, float* w,
            float* z, int ldz,
            int* isuppz, float* work,
            int lwork, int* iwork,
            int liwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_ssyevx_2stage")]
        public static extern int syevx_2stage(Layout layout, char jobz, char range,
            UpLoChar uplo, int n, float* a,
            int lda, float vl, float vu,
            int il, int iu, float abstol,
            int* m, float* w, float* z,
            int ldz, int* ifail);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_ssyevx_2stage_work")]
        public static extern int syevx_2stage(Layout layout, char jobz,
            char range, UpLoChar uplo, int n,
            float* a, int lda, float vl,
            float vu, int il, int iu,
            float abstol, int* m, float* w,
            float* z, int ldz, float* work,
            int lwork, int* iwork,
            int* ifail);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_ssygv_2stage")]
        public static extern int sygv_2stage(Layout layout, int itype,
            char jobz, UpLoChar uplo, int n, float* a,
            int lda, float* b, int ldb,
            float* w);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_ssygv_2stage_work")]
        public static extern int sygv_2stage(Layout layout, int itype,
            char jobz, UpLoChar uplo, int n,
            float* a, int lda, float* b,
            int ldb, float* w, float* work,
            int lwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_mkl_dgetrfnp")]
        public static extern int getrfnp(Layout layout, int m, int n,
            double* a, int lda);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_mkl_sgetrfnp")]
        public static extern int getrfnp(Layout layout, int m, int n,
            float* a, int lda);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_mkl_dgetrinp")]
        public static extern int getrinp(Layout layout, int n, double* a,
            int lda);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_mkl_dgetrinp_work")]
        public static extern int getrinp(Layout layout, int n,
            double* a, int lda, double* work,
            int lwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_mkl_sgetrinp")]
        public static extern int getrinp(Layout layout, int n, float* a,
            int lda);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_mkl_sgetrinp_work")]
        public static extern int getrinp(Layout layout, int n,
            float* a, int lda, float* work,
            int lwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dsysv_aa_2stage")]
        public static extern int sysv_aa_2stage(Layout layout, UpLoChar uplo,
            int n, int nrhs, double* a,
            int lda, double* tb, int ltb,
            int* ipiv, int* ipiv2,
            double* b, int ldb);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dsysv_aa_2stage_work")]
        public static extern int sysv_aa_2stage(Layout layout, UpLoChar uplo,
            int n, int nrhs,
            double* a, int lda, double* tb,
            int ltb, int* ipiv,
            int* ipiv2, double* b,
            int ldb, double* work,
            int lwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dsytrf_aa_2stage")]
        public static extern int sytrf_aa_2stage(Layout layout, UpLoChar uplo,
            int n, double* a, int lda,
            double* tb, int ltb,
            int* ipiv, int* ipiv2);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dsytrf_aa_2stage_work")]
        public static extern int sytrf_aa_2stage(Layout layout, UpLoChar uplo,
            int n, double* a,
            int lda, double* tb,
            int ltb, int* ipiv,
            int* ipiv2, double* work,
            int lwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_dsytrs_aa_2stage")]
        public static extern int sytrs_aa_2stage(Layout layout, UpLoChar uplo,
            int n, int nrhs, double* a,
            int lda, double* tb,
            int ltb, int* ipiv,
            int* ipiv2, double* b,
            int ldb);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_ssysv_aa_2stage")]
        public static extern int sysv_aa_2stage(Layout layout, UpLoChar uplo,
            int n, int nrhs, float* a,
            int lda, float* tb, int ltb,
            int* ipiv, int* ipiv2,
            float* b, int ldb);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_ssysv_aa_2stage_work")]
        public static extern int sysv_aa_2stage(Layout layout, UpLoChar uplo,
            int n, int nrhs,
            float* a, int lda, float* tb,
            int ltb, int* ipiv,
            int* ipiv2, float* b,
            int ldb, float* work,
            int lwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_ssytrf_aa_2stage")]
        public static extern int sytrf_aa_2stage(Layout layout, UpLoChar uplo,
            int n, float* a, int lda,
            float* tb, int ltb,
            int* ipiv, int* ipiv2);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_ssytrf_aa_2stage_work")]
        public static extern int sytrf_aa_2stage(Layout layout, UpLoChar uplo,
            int n, float* a,
            int lda, float* tb,
            int ltb, int* ipiv,
            int* ipiv2, float* work,
            int lwork);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "LAPACKE_ssytrs_aa_2stage")]
        public static extern int sytrs_aa_2stage(Layout layout, UpLoChar uplo,
            int n, int nrhs, float* a,
            int lda, float* tb, int ltb,
            int* ipiv, int* ipiv2,
            float* b, int ldb);
    }
}
