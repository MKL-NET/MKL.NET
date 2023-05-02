// Copyright 2023 Anthony Lloyd
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
using System.Runtime.CompilerServices;

#pragma warning disable IDE1006 // Naming Styles

[SuppressUnmanagedCodeSecurity]
public static partial class Blas
{
    public unsafe static class Unsafe
    {
        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "cblas_sdot")]
        public static extern float dot(int N, /* const */ [In] float* X, int incX, /* const */ [In] float* Y, int incY);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "cblas_sdoti")]
        public static extern float doti(int N, /* const */ [In] float* X, int* indx, /* const */ [In] float* Y);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "cblas_ddot")]
        public static extern double dot(int N, /* const */ [In] double* X, int incX, /* const */ [In] double* Y, int incY);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "cblas_ddoti")]
        public static extern double doti(int N, /* const */ [In] double* X, int* indx, /* const */ [In] double* Y);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "cblas_dsdot")]
        public static extern double sdot(int N, /* const */ [In] float* X, int incX, /* const */ [In] float* Y, int incY);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "cblas_sdsdot")]
        public static extern float sdot(int N, float sb, /* const */ [In] float* X, int incX, /* const */ [In] float* Y, int incY);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "cblas_snrm2")]
        public static extern float nrm2(int N, /* const */ [In] float* X, int incX);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "cblas_sasum")]
        public static extern float asum(int N, /* const */ [In] float* X, int incX);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "cblas_dnrm2")]
        public static extern double nrm2(int N, /* const */ [In] double* X, int incX);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "cblas_dasum")]
        public static extern double asum(int N, /* const */ [In] double* X, int incX);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "cblas_isamax")]
        public static extern int iamax(int N, /* const */ [In] float* X, int incX);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "cblas_idamax")]
        public static extern int iamax(int N, /* const */ [In] double* X, int incX);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "cblas_isamin")]
        public static extern int iamin(int N, /* const */ [In] float* X, int incX);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "cblas_idamin")]
        public static extern int iamin(int N, /* const */ [In] double* X, int incX);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "cblas_sswap")]
        public static extern void swap(int N, float* X, int incX, float* Y, int incY);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "cblas_scopy")]
        public static extern void copy(int N, /* const */ [In] float* X, int incX, float* Y, int incY);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "cblas_saxpy")]
        public static extern void axpy(int N, float a, /* const */ [In] float* X, int incX, float* Y, int incY);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "cblas_saxpby")]
        public static extern void axpby(int N, float alpha, /* const */ [In] float* X, int incX, float beta, float* Y, int incY);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "cblas_saxpyi")]
        public static extern void axpyi(int N, float alpha, /* const */ [In] float* X, int* indx, float* Y);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "cblas_sgthr")]
        public static extern void gthr(int N, /* const */ [In] float* Y, float* X, int* indx);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "cblas_sgthrz")]
        public static extern void gthrz(int N, float* Y, float* X, int* indx);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "cblas_ssctr")]
        public static extern void sctr(int N, /* const */ [In] float* X, int* indx, float* Y);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "cblas_dswap")]
        public static extern void swap(int N, double* X, int incX, double* Y, int incY);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "cblas_dcopy")]
        public static extern void copy(int N, /* const */ [In] double* X, int incX, double* Y, int incY);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "cblas_daxpy")]
        public static extern void axpy(int N, double a, /* const */ [In] double* X, int incX, double* Y, int incY);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "cblas_daxpby")]
        public static extern void axpby(int N, double alpha, /* const */ [In] double* X, int incX, double beta, double* Y, int incY);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "cblas_daxpyi")]
        public static extern void axpyi(int N, double alpha, /* const */ [In] double* X, int* indx, double* Y);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "cblas_dgthr")]
        public static extern void gthr(int N, /* const */ [In] double* Y, double* X, int* indx);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "cblas_dgthrz")]
        public static extern void gthrz(int N, double* Y, double* X, int* indx);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "cblas_dsctr")]
        public static extern void sctr(int N, /* const */ [In] double* X, int* indx, double* Y);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "cblas_srotmg")]
        public static extern void rotmg(ref float d1, ref float d2, ref float x1, float y1, float* param);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "cblas_srot")]
        public static extern void rot(int N, float* X, int incX, float* Y, int incY, float c, float s);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "cblas_sroti")]
        public static extern void roti(int N, float* X, int* indx, float* Y, float c, float s);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "cblas_srotm")]
        public static extern void rotm(int N, float* X, int incX, float* Y, int incY, float* param);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "cblas_drotmg")]
        public static extern void rotmg(ref double d1, ref double d2, ref double x1, double y1, double* param);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "cblas_drot")]
        public static extern void rot(int N, double* X, int incX, double* Y, int incY, double c, double s);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "cblas_drotm")]
        public static extern void rotm(int N, double* X, int incX, double* Y, int incY, double* param);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "cblas_droti")]
        public static extern void roti(int N, double* X, int* indx, double* Y, double c, double s);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "cblas_sscal")]
        public static extern void scal(int N, float a, float* X, int incX);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "cblas_dscal")]
        public static extern void scal(int N, double a, double* X, int incX);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "cblas_sgemv")]
        public static extern void gemv(Layout Layout,
                    Trans TransA, int M, int N,
                    float alpha, /* const */ [In] float* A, int lda,
                     /* const */ [In] float* X, int incX, float beta,
                    float* Y, int incY);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "cblas_sgbmv")]
        public static extern void gbmv(Layout Layout,
                    Trans TransA, int M, int N,
                    int KL, int KU, float alpha,
                     /* const */ [In] float* A, int lda, /* const */ [In] float* X,
                    int incX, float beta, float* Y, int incY);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "cblas_strmv")]
        public static extern void trmv(Layout Layout, UpLo UPLO,
                    Trans TransA, Diag Diag,
                    int N, /* const */ [In] float* A, int lda,
                    float* X, int incX);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "cblas_stbmv")]
        public static extern void tbmv(Layout Layout, UpLo UPLO,
                    Trans TransA, Diag Diag,
                    int N, int K, /* const */ [In] float* A, int lda,
                    float* X, int incX);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "cblas_stpmv")]
        public static extern void tpmv(Layout Layout, UpLo UPLO,
                    Trans TransA, Diag Diag,
                    int N, /* const */ [In] float* Ap, float* X, int incX);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "cblas_strsv")]
        public static extern void trsv(Layout Layout, UpLo UPLO,
                    Trans TransA, Diag Diag,
                    int N, /* const */ [In] float* A, int lda, float* X,
                    int incX);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "cblas_stbsv")]
        public static extern void tbsv(Layout Layout, UpLo UPLO,
                    Trans TransA, Diag Diag,
                    int N, int K, /* const */ [In] float* A, int lda,
                    float* X, int incX);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "cblas_stpsv")]
        public static extern void tpsv(Layout Layout, UpLo UPLO,
                    Trans TransA, Diag Diag,
                    int N, /* const */ [In] float* Ap, float* X, int incX);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "cblas_dgemv")]
        public static extern void gemv(Layout Layout,
                    Trans TransA, int M, int N,
                    double alpha, /* const */ [In] double* A, int lda,
                     /* const */ [In] double* X, int incX, double beta,
                    double* Y, int incY);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "cblas_dgbmv")]
        public static extern void gbmv(Layout Layout,
                    Trans TransA, int M, int N,
                    int KL, int KU, double alpha,
                     /* const */ [In] double* A, int lda, /* const */ [In] double* X,
                    int incX, double beta, double* Y, int incY);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "cblas_dtrmv")]
        public static extern void trmv(Layout Layout, UpLo UPLO,
                    Trans TransA, Diag Diag,
                    int N, /* const */ [In] double* A, int lda,
                    double* X, int incX);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "cblas_dtbmv")]
        public static extern void tbmv(Layout Layout, UpLo UPLO,
                    Trans TransA, Diag Diag,
                    int N, int K, /* const */ [In] double* A, int lda,
                    double* X, int incX);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "cblas_dtpmv")]
        public static extern void tpmv(Layout Layout, UpLo UPLO,
                    Trans TransA, Diag Diag,
                    int N, /* const */ [In] double* Ap, double* X, int incX);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "cblas_dtrsv")]
        public static extern void trsv(Layout Layout, UpLo UPLO,
                    Trans TransA, Diag Diag,
                    int N, /* const */ [In] double* A, int lda, double* X,
                    int incX);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "cblas_dtbsv")]
        public static extern void tbsv(Layout Layout, UpLo UPLO,
                    Trans TransA, Diag Diag,
                    int N, int K, /* const */ [In] double* A, int lda,
                    double* X, int incX);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "cblas_dtpsv")]
        public static extern void tpsv(Layout Layout, UpLo UPLO,
                    Trans TransA, Diag Diag,
                    int N, /* const */ [In] double* Ap, double* X, int incX);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "cblas_ssymv")]
        public static extern void symv(Layout Layout, UpLo UPLO,
                    int N, float alpha, /* const */ [In] float* A,
                    int lda, /* const */ [In] float* X, int incX,
                    float beta, float* Y, int incY);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "cblas_ssbmv")]
        public static extern void sbmv(Layout Layout, UpLo UPLO,
                    int N, int K, float alpha, /* const */ [In] float* A,
                    int lda, /* const */ [In] float* X, int incX,
                    float beta, float* Y, int incY);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "cblas_sspmv")]
        public static extern void spmv(Layout Layout, UpLo UPLO,
                    int N, float alpha, /* const */ [In] float* Ap,
                     /* const */ [In] float* X, int incX,
                    float beta, float* Y, int incY);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "cblas_sger")]
        public static extern void ger(Layout Layout, int M, int N,
                    float alpha, /* const */ [In] float* X, int incX,
                     /* const */ [In] float* Y, int incY, float* A, int lda);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "cblas_ssyr")]
        public static extern void syr(Layout Layout, UpLo UPLO,
                    int N, float alpha, /* const */ [In] float* X,
                    int incX, float* A, int lda);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "cblas_sspr")]
        public static extern void spr(Layout Layout, UpLo UPLO,
                    int N, float alpha, /* const */ [In] float* X,
                    int incX, float* Ap);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "cblas_ssyr2")]
        public static extern void syr2(Layout Layout, UpLo UPLO,
                    int N, float alpha, /* const */ [In] float* X,
                    int incX, /* const */ [In] float* Y, int incY, float* A,
                    int lda);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "cblas_sspr2")]
        public static extern void spr2(Layout Layout, UpLo UPLO,
                    int N, float alpha, /* const */ [In] float* X,
                    int incX, /* const */ [In] float* Y, int incY, float* A);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "cblas_dsymv")]
        public static extern void symv(Layout Layout, UpLo UPLO,
                    int N, double alpha, /* const */ [In] double* A,
                    int lda, /* const */ [In] double* X, int incX,
                    double beta, double* Y, int incY);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "cblas_dsbmv")]
        public static extern void sbmv(Layout Layout, UpLo UPLO,
                    int N, int K, double alpha, /* const */ [In] double* A,
                    int lda, /* const */ [In] double* X, int incX,
                    double beta, double* Y, int incY);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "cblas_dspmv")]
        public static extern void spmv(Layout Layout, UpLo UPLO,
                    int N, double alpha, /* const */ [In] double* Ap,
                     /* const */ [In] double* X, int incX,
                    double beta, double* Y, int incY);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "cblas_dger")]
        public static extern void ger(Layout Layout, int M, int N,
                    double alpha, /* const */ [In] double* X, int incX,
                     /* const */ [In] double* Y, int incY, double* A, int lda);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "cblas_dsyr")]
        public static extern void syr(Layout Layout, UpLo UPLO,
                        int N, double alpha, /* const */ [In] double* X,
                        int incX, double* A, int lda);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "cblas_dspr")]
        public static extern void spr(Layout Layout, UpLo UPLO,
                    int N, double alpha, /* const */ [In] double* X,
                    int incX, double* Ap);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "cblas_dsyr2")]
        public static extern void syr2(Layout Layout, UpLo UPLO,
                    int N, double alpha, /* const */ [In] double* X,
                    int incX, /* const */ [In] double* Y, int incY, double* A,
                    int lda);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "cblas_dspr2")]
        public static extern void spr2(Layout Layout, UpLo UPLO,
                    int N, double alpha, /* const */ [In] double* X,
                    int incX, /* const */ [In] double* Y, int incY, double* A);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "cblas_sgemm")]
        public static extern void gemm(Layout Layout, Trans TransA,
                    Trans TransB, int M, int N,
                    int K, float alpha, /* const */ [In] float* A,
                    int lda, /* const */ [In] float* B, int ldb,
                    float beta, float* C, int ldc);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "cblas_sgemmt")]
        public static extern void gemmt(Layout Layout, UpLo UPLO,
                    Trans TransA, Trans TransB,
                    int N, int K,
                    float alpha, /* const */ [In] float* A, int lda,
                     /* const */ [In] float* B, int ldb, float beta,
                    float* C, int ldc);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "cblas_ssymm")]
        public static extern void symm(Layout Layout, Side Side,
                    UpLo UPLO, int M, int N,
                    float alpha, /* const */ [In] float* A, int lda,
                     /* const */ [In] float* B, int ldb, float beta,
                    float* C, int ldc);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "cblas_ssyrk")]
        public static extern void syrk(Layout Layout, UpLo UPLO,
                    Trans Trans, int N, int K,
                    float alpha, /* const */ [In] float* A, int lda,
                    float beta, float* C, int ldc);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "cblas_ssyr2k")]
        public static extern void syr2k(Layout Layout, UpLo UPLO,
                    Trans Trans, int N, int K,
                    float alpha, /* const */ [In] float* A, int lda,
                     /* const */ [In] float* B, int ldb, float beta,
                    float* C, int ldc);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "cblas_strmm")]
        public static extern void trmm(Layout Layout, Side Side,
                    UpLo UPLO, Trans TransA,
                    Diag Diag, int M, int N,
                    float alpha, /* const */ [In] float* A, int lda,
                    float* B, int ldb);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "cblas_strsm")]
        public static extern void trsm(Layout Layout, Side Side,
                    UpLo UPLO, Trans TransA,
                    Diag Diag, int M, int N,
                    float alpha, /* const */ [In] float* A, int lda,
                    float* B, int ldb);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "cblas_dgemm")]
        public static extern void gemm(Layout Layout, Trans TransA,
                    Trans TransB, int M, int N,
                    int K, double alpha, /* const */ [In] double* A,
                    int lda, /* const */ [In] double* B, int ldb,
                    double beta, double* C, int ldc);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "cblas_dgemmt")]
        public static extern void gemmt(Layout Layout, UpLo UPLO,
                    Trans TransA, Trans TransB,
                    int N, int K,
                    double alpha, /* const */ [In] double* A, int lda,
                     /* const */ [In] double* B, int ldb, double beta,
                    double* C, int ldc);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "cblas_dsymm")]
        public static extern void symm(Layout Layout, Side Side,
                    UpLo UPLO, int M, int N,
                    double alpha, /* const */ [In] double* A, int lda,
                     /* const */ [In] double* B, int ldb, double beta,
                    double* C, int ldc);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "cblas_dsyrk")]
        public static extern void syrk(Layout Layout, UpLo UPLO,
                    Trans Trans, int N, int K,
                    double alpha, /* const */ [In] double* A, int lda,
                    double beta, double* C, int ldc);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "cblas_dsyr2k")]
        public static extern void syr2k(Layout Layout, UpLo UPLO,
                    Trans Trans, int N, int K,
                    double alpha, /* const */ [In] double* A, int lda,
                     /* const */ [In] double* B, int ldb, double beta,
                    double* C, int ldc);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "cblas_dtrmm")]
        public static extern void trmm(Layout Layout, Side Side,
                    UpLo UPLO, Trans TransA,
                    Diag Diag, int M, int N,
                    double alpha, /* const */ [In] double* A, int lda,
                    double* B, int ldb);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "cblas_dtrsm")]
        public static extern void trsm(Layout Layout, Side Side,
                    UpLo UPLO, Trans TransA,
                    Diag Diag, int M, int N,
                    double alpha, /* const */ [In] double* A, int lda,
                    double* B, int ldb);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint="MKL_Dimatcopy")]
        public static extern void imatcopy(LayoutChar ordering, TransChar trans,
                    nuint rows, nuint cols,
                    double alpha, double* A, nuint lda,
                    nuint ldb);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "MKL_Simatcopy")]
        public static extern void imatcopy(LayoutChar ordering, TransChar trans,
                    nuint rows, nuint cols,
                    float alpha, float* A, nuint lda,
                    nuint ldb);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "MKL_Domatcopy")]
        public static extern void omatcopy(LayoutChar ordering, TransChar trans,
                    nuint rows, nuint cols,
                    double alpha, /* const */ [In] double* A, nuint lda,
                    double* B, nuint ldb);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "MKL_Somatcopy")]
        public static extern void omatcopy(LayoutChar ordering, TransChar trans,
                    nuint rows, nuint cols,
                    float alpha, /* const */ [In] float* A, nuint lda,
                    float* B, nuint ldb);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "MKL_Domatadd")]
        public static extern void omatadd(LayoutChar ordering,
                    TransChar transa, TransChar transb,
                    nuint rows, nuint cols,
                    double alpha, /* const */ [In] double* A, nuint lda,
                    double beta, /* const */ [In] double* B, nuint ldb,
                    double* C, nuint ldc);

        [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "MKL_Somatadd")]
        public static extern void omatadd(LayoutChar ordering,
                    TransChar transa, TransChar transb,
                    nuint rows, nuint cols,
                    float alpha, /* const */ [In] float* A, nuint lda,
                    float beta, /* const */ [In] float* B, nuint ldb,
                    float* C, nuint ldc);
    }

    // Keeping BLAS-like functions with int arguments around:
    //   The BLAS-like functions seem to be the only ones using size_t instead of MKL_INT
    //   cf. <https://www.intel.com/content/www/us/en/docs/onemkl/developer-reference-c/2023-0/mkl-omatadd.html>
    //   P/Invoke definitions with pointer arguments seem to require the correct nuint for size_t
    //   The previous definitions with array arguments used int for size_t, but it still worked
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void imatcopy(LayoutChar ordering, TransChar trans, int rows, int cols, double alpha, double[] A, int lda, int ldb)
        => imatcopy(ordering, trans, (nuint)rows, (nuint)cols, alpha, A, (nuint)lda, (nuint)ldb);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void imatcopy(LayoutChar ordering, TransChar trans, int rows, int cols, float alpha, float[] A, int lda, int ldb)
        => imatcopy(ordering, trans, (nuint)rows, (nuint)cols, alpha, A, (nuint)lda, (nuint)ldb);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void omatcopy(LayoutChar ordering, TransChar trans, int rows, int cols, double alpha, double[] A, int lda, double[] B, int ldb)
        => omatcopy(ordering, trans, (nuint)rows, (nuint)cols, alpha, A, (nuint)lda, B, (nuint)ldb);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void omatcopy(LayoutChar ordering, TransChar trans, int rows, int cols, float alpha, float[] A, int lda, float[] B, int ldb)
        => omatcopy(ordering, trans, (nuint)rows, (nuint)cols, alpha, A, (nuint)lda, B, (nuint)ldb);
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void omatadd(LayoutChar ordering, TransChar transa, TransChar transb, int rows, int cols, double alpha, double[] A,
        int lda, double beta, double[] B, int ldb, double[] C, int ldc)
        => omatadd(ordering, transa, transb, (nuint)rows, (nuint)cols, alpha, A, (nuint)lda, beta, B, (nuint)ldb, C, (nuint)ldc);
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void omatadd(LayoutChar ordering, TransChar transa, TransChar transb, int rows, int cols, float alpha, float[] A,
        int lda, float beta, float[] B, int ldb, float[] C, int ldc)
        => omatadd(ordering, transa, transb, (nuint)rows, (nuint)cols, alpha, A, (nuint)lda, beta, B, (nuint)ldb, C, (nuint)ldc);

    //  Not unsafe
    [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "cblas_srotg")]
    public static extern void rotg(ref float a, ref float b, ref float c, ref float s);

    [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, EntryPoint = "cblas_drotg")]
    public static extern void rotg(ref double a, ref double b, ref double c, ref double s);

    // Versions that also set offset/stride
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float dot(float[] X, float[] Y)
        => dot(X.Length, X, 0, 1, Y, 0, 1);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static double dot(double[] X, double[] Y)
        => dot(X.Length, X, 0, 1, Y, 0, 1);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static double sdot(float[] X, float[] Y)
        => sdot(X.Length, X, 0, 1, Y, 0, 1);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float sdot(float sb, float[] X, float[] Y)
        => sdot(X.Length, sb, X, 0, 1, Y, 0, 1);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float nrm2(float[] X)
        => nrm2(X.Length, X, 0, 1);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float asum(float[] X)
        => asum(X.Length, X, 0, 1);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static double nrm2(double[] X)
        => nrm2(X.Length, X, 0, 1);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static double asum(double[] X)
        => asum(X.Length, X, 0, 1);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int iamax(float[] X)
        => iamax(X.Length, X, 0, 1);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int iamax(double[] X)
        => iamax(X.Length, X, 0, 1);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int iamin(float[] X)
        => iamin(X.Length, X, 0, 1);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int iamin(double[] X)
        => iamin(X.Length, X, 0, 1);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void swap(float[] X, float[] Y)
        => swap(X.Length, X, 0, 1, Y, 0, 1);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void copy(float[] X, float[] Y)
        => copy(X.Length, X, 0, 1, Y, 0, 1);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void axpy(float a, float[] X, float[] Y)
        => axpy(X.Length, a, X, 0, 1, Y, 0, 1);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void axpby(float alpha, float[] X, float beta, float[] Y)
        => axpby(X.Length, alpha, X, 0, 1, beta, Y, 0, 1);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void swap(double[] X, double[] Y)
        => swap(X.Length, X, 0, 1, Y, 0, 1);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void copy(double[] X, double[] Y)
        => copy(X.Length, X, 0, 1, Y, 0, 1);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void axpy(double a, double[] X, double[] Y)
        => axpy(X.Length, a, X, 0, 1, Y, 0, 1);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void axpby(double alpha, double[] X, double beta, double[] Y)
        => axpby(X.Length, alpha, X, 0, 1, beta, Y, 0, 1);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void rot(float[] X, float[] Y, float c, float s)
        => rot(X.Length, X, 0, 1, Y, 0, 1, c, s);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void rotm(float[] X, float[] Y, float[] param)
        => rotm(X.Length, X, 0, 1, Y, 0, 1, param);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void rot(double[] X, double[] Y, double c, double s)
        => rot(X.Length, X, 0, 1, Y, 0, 1, c, s);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void rotm(double[] X, double[] Y, double[] param)
        => rotm(X.Length, X, 0, 1, Y, 0, 1, param);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void scal(float a, float[] X)
        => scal(X.Length, a, X, 0, 1);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void scal(double a, double[] X)
        => scal(X.Length, a, X, 0, 1);
}
