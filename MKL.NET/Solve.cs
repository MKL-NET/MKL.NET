using System;
using System.Security;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;

namespace MKLNET
{
    public class RcidTrnspTask
    {
        internal IntPtr Ptr;
        internal IntPtr Allocated;
        internal Pinned Pinned;
    }

    public enum RciRequest
    {
        CALCULATE_JACOBIAN = 2,
        CALCULATE_FUNCTION = 1,
        ONE_ITERATION = 0,
        EXCEEDED_ITERATIONS = -1,
        DELTA_LESS_THAN_EPS0 = -2,
        F_NORM_2_LESS_THAN_EPS1 = -3,
        JACOBIAN_SINGULAR_LESS_THAN_ESP2 = -4,
        S_NORM_2_LESS_THAN_EPS3 = -5,
        F_J_S_LESS_THAN_EPS4 = -6,
    }

    [SuppressUnmanagedCodeSecurity]
    public unsafe static class Solve
    {
#if LINUX
        const string DLL = "libmkl_rt.so";
#elif OSX
        const string DLL = "libmkl_rt.dylib";
#else
        const string DLL = "mkl_rt.dll";
#endif
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern RciStatus dtrnlsp_init(IntPtr* handle, int* n, int* m, double* x, double* eps, int* iter1, int* iter2, double* rs);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern RciStatus dtrnlsp_solve(IntPtr* handle, double* fvec, double* fjac, RciRequest* RCI_Request);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern RciStatus dtrnlsp_delete(IntPtr* handle);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern RciStatus djacobi_init(IntPtr* handle, int* n, int* m, double* x, double* fjac, double* eps);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern RciStatus djacobi_solve(IntPtr* handle, double* f1, double* f2, int* RCI_Request);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern RciStatus djacobi_delete(IntPtr* handle);
        public static RciStatus NonLinearLeastSquares(Action<double[], double[]> F, double[] x, double[] Fx, double[] eps, int iter1, int iter2, double rs, double jac_eps)
        {
            int n = x.Length;
            int m = Fx.Length;
            double[] jac = new double[n * m];
            double[] f1 = new double[m];
            double[] f2 = new double[m];
            fixed (double* xp = &x[0], epsp = &eps[0], Fxp = &Fx[0], jacp = &jac[0], f1p = &f1[0], f2p = &f2[0])
            {
                IntPtr handle;
                RciStatus status;
                if ((status = dtrnlsp_init(&handle, &n, &m, xp, epsp, &iter1, &iter1, &rs)) != RciStatus.SUCCESS) return status;
                while (true)
                {
                    RciRequest request;
                    if ((status = dtrnlsp_solve(&handle, Fxp, jacp, &request)) != RciStatus.SUCCESS) break;
                    if (request == RciRequest.CALCULATE_FUNCTION)
                    {
                        F(x, Fx);
                    }
                    else if (request == RciRequest.CALCULATE_JACOBIAN)
                    {
                        IntPtr jacHandle;
                        int jacRequest;
                        if ((status = djacobi_init(&jacHandle, &n, &m, xp, jacp, &jac_eps)) != RciStatus.SUCCESS) break;
                        while (true)
                        {
                            if ((status = djacobi_solve(&jacHandle, f1p, f2p, &jacRequest)) != RciStatus.SUCCESS) break;
                            if (jacRequest == 1)
                            {
                                F(x, f1);
                            }
                            else if (jacRequest == 2)
                            {
                                F(x, f2);
                            }
                            else break;
                        }
                        djacobi_delete(&jacHandle);
                    }
                    else
                    {
                        status = (RciStatus)request;
                        break;
                    }
                }
                dtrnlsp_delete(&handle);
                return status;
            }
        }


        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern RciStatus dtrnlsp_init(IntPtr* handle, IntPtr n, IntPtr m, IntPtr x, IntPtr eps, IntPtr iter1, IntPtr iter2, IntPtr rs);
        public static RciStatus trnlsp_init(int n, int m, double[] x, double[] eps, int iter1, int iter2, double rs, out RcidTrnspTask task)
        {
            var np = Marshal.AllocHGlobal(sizeof(int) * 6);
            Marshal.WriteInt32(np, n);
            var mp = IntPtr.Add(np, sizeof(int));
            Marshal.WriteInt32(mp, m);
            var iter1p = IntPtr.Add(mp, sizeof(int));
            Marshal.WriteInt32(iter1p, iter1);
            var iter2p = IntPtr.Add(iter1p, sizeof(int));
            Marshal.WriteInt32(iter2p, iter2);
            var rsp = IntPtr.Add(iter2p, sizeof(int));
            Marshal.WriteInt64(rsp, BitConverter.DoubleToInt64Bits(rs));
            var pinned = new Pinned(2);
            IntPtr handle;
            var ret = dtrnlsp_init(&handle, np, mp, pinned.Add(x), pinned.Add(eps), iter1p, iter2p, rsp);
            task = new RcidTrnspTask { Ptr = handle, Allocated = np, Pinned = pinned };
            return ret;
        }

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void dtrnlsp_check(IntPtr handle, int n, int m, double[] fjac, double[] fvec, double[] eps, int[] info);
        public static int[] trnlsp_check(RcidTrnspTask task, int n, int m, double[] fjac, double[] fvec, double[] eps)
        {
            var info = new int[6];
            dtrnlsp_check(task.Ptr, n, m, fjac, fvec, eps, info);
            return info;
        }


        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void dtrnlsp_solve(IntPtr handle, double[] fvec, double[] fjac, RciRequest* RCI_Request);
        public static RciRequest trnlsp_solve(RcidTrnspTask task, double[] fvec, double[] fjac)
        {
            RciRequest rciRequest;
            dtrnlsp_solve(task.Ptr, fvec, fjac, &rciRequest);
            return rciRequest;
        }

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void dtrnlsp_get(IntPtr handle, int* iter, int* st_cr, double* r1, double* r2);
        public static void trnlsp_get(RcidTrnspTask task, out int iter, out int st_cr, out double r1, out double r2)
        {
            int iterl, st_crl;
            double r1l, r2l;
            dtrnlsp_get(task.Ptr, &iterl, &st_crl, &r1l, &r2l);
            iter = iterl;
            st_cr = st_crl;
            r1 = r1l;
            r2 = r2l;
        }

        
        public static void trnlsp_delete(RcidTrnspTask task)
        {
            Marshal.FreeHGlobal(task.Allocated);
            task.Pinned.Free();
            var t = task.Ptr;
            dtrnlsp_delete(&t);
        }

        
        //public static void jacobi_init(Rcidja task, out int iter, out int st_cr, out double r1, out double r2)
        //{
        //    int iterl, st_crl;
        //    double r1l, r2l;
        //    dtrnlsp_get(task.Ptr, &iterl, &st_crl, &r1l, &r2l);
        //    iter = iterl;
        //    st_cr = st_crl;
        //    r1 = r1l;
        //    r2 = r2l;
        //}

        //typedef void (* USRFCND) (MKL_INT*, MKL_INT*, double*, double*);
        //typedef void (* USRFCNXD) (MKL_INT*, MKL_INT*, double*, double*, void*);

        //typedef void (* USRFCNS) (MKL_INT*, MKL_INT*, float*, float*);
        //typedef void (* USRFCNXS) (MKL_INT*, MKL_INT*, float*, float*, void*);

        ///* Function prototypes */
        //extern MKL_INT dtrnlsp_init(_TRNSP_HANDLE_t*, const MKL_INT*, const MKL_INT*, const double*, const double*, const MKL_INT*, const MKL_INT*, const double*);
        //extern MKL_INT dtrnlsp_check(_TRNSP_HANDLE_t*, const MKL_INT*, const MKL_INT*, const double*, const double*, const double*, MKL_INT*);
        //extern MKL_INT dtrnlsp_solve(_TRNSP_HANDLE_t*, double*, double*, MKL_INT*);
        //extern MKL_INT dtrnlsp_get(_TRNSP_HANDLE_t*, MKL_INT*, MKL_INT*, double*, double*);
        //extern MKL_INT dtrnlsp_delete(_TRNSP_HANDLE_t*);

        //extern MKL_INT dtrnlspbc_init(_TRNSPBC_HANDLE_t*, const MKL_INT*, const MKL_INT*, const double*, const double*, const double*, const double*, const MKL_INT*, const MKL_INT*, const double*);
        //extern MKL_INT dtrnlspbc_check(_TRNSPBC_HANDLE_t*, const MKL_INT*, const MKL_INT*, const double*, const double*, const double*, const double*, const double*, MKL_INT*);
        //extern MKL_INT dtrnlspbc_solve(_TRNSPBC_HANDLE_t*, double*, double*, MKL_INT*);
        //extern MKL_INT dtrnlspbc_get(_TRNSPBC_HANDLE_t*, MKL_INT*, MKL_INT*, double*, double*);
        //extern MKL_INT dtrnlspbc_delete(_TRNSPBC_HANDLE_t*);

        //extern MKL_INT djacobi_init(_JACOBIMATRIX_HANDLE_t*, const MKL_INT*, const MKL_INT*, const double*, const double*, const double*);
        //extern MKL_INT djacobi_solve(_JACOBIMATRIX_HANDLE_t*, double*, double*, MKL_INT*);
        //extern MKL_INT djacobi_delete(_JACOBIMATRIX_HANDLE_t*);
        //extern MKL_INT djacobi(USRFCND fcn, const MKL_INT*, const MKL_INT*, double*, double*, double*);
        //extern MKL_INT djacobix(USRFCNXD fcn, const MKL_INT*, const MKL_INT*, double*, double*, double*, void*);

        //extern MKL_INT strnlsp_init(_TRNSP_HANDLE_t*, const MKL_INT*, const MKL_INT*, const float*, const float*, const MKL_INT*, const MKL_INT*, const float*);
        //extern MKL_INT strnlsp_check(_TRNSP_HANDLE_t*, const MKL_INT*, const MKL_INT*, const float*, const float*, const float*, MKL_INT*);
        //extern MKL_INT strnlsp_solve(_TRNSP_HANDLE_t*, float*, float*, MKL_INT*);
        //extern MKL_INT strnlsp_get(_TRNSP_HANDLE_t*, MKL_INT*, MKL_INT*, float*, float*);
        //extern MKL_INT strnlsp_delete(_TRNSP_HANDLE_t*);

        //extern MKL_INT strnlspbc_init(_TRNSPBC_HANDLE_t*, const MKL_INT*, const MKL_INT*, const float*, const float*, const float*, const float*, const MKL_INT*, const MKL_INT*, const float*);
        //extern MKL_INT strnlspbc_check(_TRNSPBC_HANDLE_t*, const MKL_INT*, const MKL_INT*, const float*, const float*, const float*, const float*, const float*, MKL_INT*);
        //extern MKL_INT strnlspbc_solve(_TRNSPBC_HANDLE_t*, float*, float*, MKL_INT*);
        //extern MKL_INT strnlspbc_get(_TRNSPBC_HANDLE_t*, MKL_INT*, MKL_INT*, float*, float*);
        //extern MKL_INT strnlspbc_delete(_TRNSPBC_HANDLE_t*);

        //extern MKL_INT sjacobi_init(_JACOBIMATRIX_HANDLE_t*, const MKL_INT*, const MKL_INT*, const float*, const float*, const float*);
        //extern MKL_INT sjacobi_solve(_JACOBIMATRIX_HANDLE_t*, float*, float*, MKL_INT*);
        //extern MKL_INT sjacobi_delete(_JACOBIMATRIX_HANDLE_t*);
        //extern MKL_INT sjacobi(USRFCNS fcn, const MKL_INT*, const MKL_INT*, float*, float*, float*);
        //extern MKL_INT sjacobix(USRFCNXS fcn, const MKL_INT*, const MKL_INT*, float*, float*, float*, void*);
    }
}