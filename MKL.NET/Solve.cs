using System;
using System.Security;
using System.Runtime.InteropServices;

namespace MKLNET
{
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
        static extern RciStatus dtrnlsp_solve(IntPtr* handle, double* fvec, double* fjac, int* RCI_Request);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern RciStatus dtrnlsp_delete(IntPtr* handle);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern RciStatus djacobi_init(IntPtr* handle, int* n, int* m, double* x, double* fjac, double* eps);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern RciStatus djacobi_solve(IntPtr* handle, double* f1, double* f2, int* RCI_Request);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern RciStatus djacobi_delete(IntPtr* handle);
        public delegate void djacobi_function(int* m, int* n, double* x, double* f);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern RciStatus djacobi(djacobi_function fcn, int* n, int* m, double* fjac, double* x, double* eps);
        
        const int CALCULATE_JACOBIAN = 2;
        const int CALCULATE_FUNCTION = 1;
        public static RciStatus NonLinearLeastSquares(Action<double[], double[]> F, double[] x, double[] Fx, double[] eps, int iter1, int iter2, double rs)
        {
            int n = x.Length;
            int m = Fx.Length;
            double[] jac = new double[n * m];
            double[] f1 = new double[m];
            double[] f2 = new double[m];
            fixed (double* xp = &x[0], epsp = &eps[0], Fxp = &Fx[0], jacp = &jac[0], f1p = &f1[0], f2p = &f2[0])
            {
                IntPtr handle;
                int request;
                var status = dtrnlsp_init(&handle, &n, &m, xp, epsp, &iter1, &iter1, &rs);
                while (status == RciStatus.SUCCESS && (status = dtrnlsp_solve(&handle, Fxp, jacp, &request)) == RciStatus.SUCCESS)
                {
                    if (request == CALCULATE_FUNCTION)
                    {
                        F(x, Fx);
                    }
                    else if (request == CALCULATE_JACOBIAN)
                    {
                        IntPtr jacHandle;
                        int jacRequest;
                        status = djacobi_init(&jacHandle, &n, &m, xp, jacp, epsp);
                        if (status == RciStatus.SUCCESS)
                            while ((status = djacobi_solve(&jacHandle, f1p, f2p, &jacRequest)) == RciStatus.SUCCESS && jacRequest != 0)
                                F(x, jacRequest == 1 ? f1 : f2);
                        djacobi_delete(&jacHandle);
                    }
                    else if (request < 0)
                    {
                        status = (RciStatus)request;
                        break;
                    }
                }
                dtrnlsp_delete(&handle);
                return status;
            }
        }


        public static RciStatus NonLinearLeastSquares(djacobi_function F, double[] x, double[] Fx, double[] eps, int iter1, int iter2, double rs)
        {
            int n = x.Length;
            int m = Fx.Length;
            double[] jac = new double[n * m];
            fixed (double* xp = &x[0], epsp = &eps[0], Fxp = &Fx[0], jacp = &jac[0])
            {
                IntPtr handle;
                int request;
                var status = dtrnlsp_init(&handle, &n, &m, xp, epsp, &iter1, &iter1, &rs);
                while (status == RciStatus.SUCCESS && (status = dtrnlsp_solve(&handle, Fxp, jacp, &request)) == RciStatus.SUCCESS)
                {
                    if (request == CALCULATE_FUNCTION)
                    {
                        F(&m, &n, xp, Fxp);
                    }
                    else if (request == CALCULATE_JACOBIAN)
                    {
                        status = djacobi(F, &n, &m, jacp, xp, epsp);
                    }
                    else if (request != 0)
                    {
                        status = (RciStatus)request;
                        break;
                    }
                }
                dtrnlsp_delete(&handle);
                return status;
            }
        }

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
    }

    public enum RciStatus
    {
        SUCCESS = 1501,
        INVALID_OPTION = 1502,
        OUT_OF_MEMORY = 1503,
        EXCEEDED_ITERATIONS = -1,
        DELTA_LESS_THAN_EPS0 = -2,
        F_NORM_2_LESS_THAN_EPS1 = -3,
        JACOBIAN_SINGULAR_LESS_THAN_ESP2 = -4,
        S_NORM_2_LESS_THAN_EPS3 = -5,
        F_J_S_LESS_THAN_EPS4 = -6,
    }
}