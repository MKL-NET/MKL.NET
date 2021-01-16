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
        static extern int dtrnlsp_init(IntPtr* handle, int* n, int* m, double* x, double* eps, int* iter1, int* iter2, double* rs);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int dtrnlsp_solve(IntPtr* handle, double* fvec, double* fjac, int* RCI_Request);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int dtrnlsp_delete(IntPtr* handle);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int dtrnlspbc_init(IntPtr* handle, int* n, int* m, double* x, double* lower, double* upper, double* eps, int* iter1, int* iter2, double* rs);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int dtrnlspbc_solve(IntPtr* handle, double* fvec, double* fjac, int* RCI_Request);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int dtrnlspbc_delete(IntPtr* handle);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int djacobi_init(IntPtr* handle, int* n, int* m, double* x, double* fjac, double* eps);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int djacobi_solve(IntPtr* handle, double* f1, double* f2, int* RCI_Request);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int djacobi_delete(IntPtr* handle);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int djacobi(SolveFn fcn, int* n, int* m, double* fjac, double* x, double* eps);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int strnlsp_init(IntPtr* handle, int* n, int* m, float* x, float* eps, int* iter1, int* iter2, float* rs);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int strnlsp_solve(IntPtr* handle, float* fvec, float* fjac, int* RCI_Request);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int strnlsp_delete(IntPtr* handle);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int strnlspbc_init(IntPtr* handle, int* n, int* m, float* x, float* lower, float* upper, float* eps, int* iter1, int* iter2, float* rs);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int strnlspbc_solve(IntPtr* handle, float* fvec, float* fjac, int* RCI_Request);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int strnlspbc_delete(IntPtr* handle);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int sjacobi_init(IntPtr* handle, int* n, int* m, float* x, float* fjac, float* eps);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int sjacobi_solve(IntPtr* handle, float* f1, float* f2, int* RCI_Request);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int sjacobi_delete(IntPtr* handle);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int sjacobi(SolveFnF fcn, int* n, int* m, float* fjac, float* x, float* eps);

        const int ONE_ITERATION = 0;
        const int CALCULATE_FUNCTION = 1;
        const int CALCULATE_JACOBIAN = 2;
        const int SUCCESS = 1501;
        static readonly double[] DEFAULT_EPS = new[] { 1e-12, 1e-12, 1e-12, 1e-12, 1e-12, 1e-12 };
        static readonly float[] DEFAULT_EPS_FLOAT = new[] { 1e-7f, 1e-7f, 1e-7f, 1e-7f, 1e-7f, 1e-7f };

        /// <summary>
        /// Nonlinear Least Squares Solver. Fx = F(x). minimizes Norm_2(F(x))
        /// </summary>
        /// <param name="F">objective function, not called in parallel</param>
        /// <param name="x">input values, initial guess to start, solution on exit</param>
        /// <param name="Fx">function values, just zero to start, solution on exit</param>
        /// <param name="eps">precisions for stop-criteria, defaults to all 1e-9</param>
        /// <param name="iter1">maximum number of iterations, defaults of 1000</param>
        /// <param name="iter2">maximum number of iterations of calculation of trial-step, default of 100</param>
        /// <param name="rs">initial step bound (0.1 - 100.0 recommended), default of 0.0 which MKL defaults as 100.0</param>
        /// <returns>stop criterion</returns>
        public static SolveResult NonLinearLeastSquares(Action<double[], double[]> F, double[] x, double[] Fx, double[] eps, int iter1 = 1000, int iter2 = 100, double rs = 0.0)
        {
            int n = x.Length;
            int m = Fx.Length;
            var jac = new double[n * m];
            var f1 = new double[m];
            var f2 = new double[m];
            fixed (double* xp = &x[0], epsp = &eps[0], Fxp = &Fx[0], jacp = &jac[0], f1p = &f1[0], f2p = &f2[0])
            {
                IntPtr handle;
                int request;
                var status = dtrnlsp_init(&handle, &n, &m, xp, epsp, &iter1, &iter1, &rs);
                while (status == SUCCESS && (status = dtrnlsp_solve(&handle, Fxp, jacp, &request)) == SUCCESS)
                {
                    if (request == CALCULATE_FUNCTION) F(x, Fx);
                    else if (request == CALCULATE_JACOBIAN)
                    {
                        IntPtr jacHandle;
                        int jacRequest;
                        status = djacobi_init(&jacHandle, &n, &m, xp, jacp, epsp);
                        if (status == SUCCESS)
                            while ((status = djacobi_solve(&jacHandle, f1p, f2p, &jacRequest)) == SUCCESS && jacRequest != 0)
                                F(x, jacRequest == 1 ? f1 : f2);
                        djacobi_delete(&jacHandle);
                    }
                    else if (request != ONE_ITERATION)
                    {
                        status = request;
                        break;
                    }
                }
                dtrnlsp_delete(&handle);
                return (SolveResult)status;
            }
        }

        /// <summary>
        /// Nonlinear Least Squares Solver. Fx = F(x). minimizes Norm_2(F(x))
        /// </summary>
        /// <param name="F">objective function, not called in parallel</param>
        /// <param name="x">input values, initial guess to start, solution on exit</param>
        /// <param name="Fx">function values, just zero to start, solution on exit</param>
        /// <returns>stop criterion</returns>
        public static SolveResult NonLinearLeastSquares(Action<double[], double[]> F, double[] x, double[] Fx)
            => NonLinearLeastSquares(F, x, Fx, DEFAULT_EPS);

        /// <summary>
        /// Nonlinear Least Squares Solver. Fx = F(x). minimizes Norm_2(F(x))
        /// </summary>
        /// <param name="F">objective function, called in parallel</param>
        /// <param name="x">input values, initial guess to start, solution on exit</param>
        /// <param name="Fx">function values, just zero to start, solution on exit</param>
        /// <param name="eps">precisions for stop-criteria, defaults to all 1e-9</param>
        /// <param name="iter1">maximum number of iterations, defaults of 1000</param>
        /// <param name="iter2">maximum number of iterations of calculation of trial-step, default of 100</param>
        /// <param name="rs">initial step bound (0.1 - 100.0 recommended), default of 0.0 which MKL defaults as 100.0</param>
        /// <returns>stop criterion</returns>
        public static SolveResult NonLinearLeastSquares(SolveFn F, double[] x, double[] Fx, double[] eps, int iter1 = 1000, int iter2 = 100, double rs = 0.0)
        {
            int n = x.Length;
            int m = Fx.Length;
            var jac = new double[n * m];
            fixed (double* xp = &x[0], epsp = &eps[0], Fxp = &Fx[0], jacp = &jac[0])
            {
                IntPtr handle;
                int request;
                var status = dtrnlsp_init(&handle, &n, &m, xp, epsp, &iter1, &iter1, &rs);
                while (status == SUCCESS && (status = dtrnlsp_solve(&handle, Fxp, jacp, &request)) == SUCCESS)
                {
                    if (request == CALCULATE_FUNCTION) F(&m, &n, xp, Fxp);
                    else if (request == CALCULATE_JACOBIAN) status = djacobi(F, &n, &m, jacp, xp, epsp);
                    else if (request != ONE_ITERATION)
                    {
                        status = request;
                        break;
                    }
                }
                dtrnlsp_delete(&handle);
                return (SolveResult)status;
            }
        }

        /// <summary>
        /// Nonlinear Least Squares Solver. Fx = F(x). minimizes Norm_2(F(x))
        /// </summary>
        /// <param name="F">objective function, called in parallel</param>
        /// <param name="x">input values, initial guess to start, solution on exit</param>
        /// <param name="Fx">function values, just zero to start, solution on exit</param>
        /// <returns>stop criterion</returns>
        public static SolveResult NonLinearLeastSquares(SolveFn F, double[] x, double[] Fx)
            => NonLinearLeastSquares(F, x, Fx, DEFAULT_EPS);

        /// <summary>
        /// Nonlinear Least Squares Solver. Fx = F(x). minimizes Norm_2(F(x))
        /// </summary>
        /// <param name="F">objective function, not called in parallel</param>
        /// <param name="x">input values, initial guess to start, solution on exit</param>
        /// <param name="lower">x lower bound</param>
        /// <param name="upper">x upper bound</param>
        /// <param name="Fx">function values, just zero to start, solution on exit</param>
        /// <param name="eps">precisions for stop-criteria, defaults to all 1e-9</param>
        /// <param name="iter1">maximum number of iterations, defaults of 1000</param>
        /// <param name="iter2">maximum number of iterations of calculation of trial-step, default of 100</param>
        /// <param name="rs">initial step bound (0.1 - 100.0 recommended), default of 0.0 which MKL defaults as 100.0</param>
        /// <returns>stop criterion</returns>
        public static SolveResult NonLinearLeastSquares(Action<double[], double[]> F, double[] x, double[] lower, double[] upper, double[] Fx, double[] eps, int iter1 = 1000, int iter2 = 100, double rs = 0.0)
        {
            int n = x.Length;
            int m = Fx.Length;
            var jac = new double[n * m];
            var f1 = new double[m];
            var f2 = new double[m];
            fixed (double* xp = &x[0], lowerp = &lower[0], upperp = &upper[0], epsp = &eps[0], Fxp = &Fx[0], jacp = &jac[0], f1p = &f1[0], f2p = &f2[0])
            {
                IntPtr handle;
                int request;
                var status = dtrnlspbc_init(&handle, &n, &m, xp, lowerp, upperp, epsp, &iter1, &iter1, &rs);
                while (status == SUCCESS && (status = dtrnlspbc_solve(&handle, Fxp, jacp, &request)) == SUCCESS)
                {
                    if (request == CALCULATE_FUNCTION) F(x, Fx);
                    else if (request == CALCULATE_JACOBIAN)
                    {
                        IntPtr jacHandle;
                        int jacRequest;
                        status = djacobi_init(&jacHandle, &n, &m, xp, jacp, epsp);
                        if (status == SUCCESS)
                            while ((status = djacobi_solve(&jacHandle, f1p, f2p, &jacRequest)) == SUCCESS && jacRequest != 0)
                                F(x, jacRequest == 1 ? f1 : f2);
                        djacobi_delete(&jacHandle);
                    }
                    else if (request != ONE_ITERATION)
                    {
                        status = request;
                        break;
                    }
                }
                dtrnlspbc_delete(&handle);
                return (SolveResult)status;
            }
        }

        /// <summary>
        /// Nonlinear Least Squares Solver. Fx = F(x). minimizes Norm_2(F(x))
        /// </summary>
        /// <param name="F">objective function, not called in parallel</param>
        /// <param name="x">input values, initial guess to start, solution on exit</param>
        /// <param name="lower">x lower bound</param>
        /// <param name="upper">x upper bound</param>
        /// <param name="Fx">function values, just zero to start, solution on exit</param>
        /// <returns>stop criterion</returns>
        public static SolveResult NonLinearLeastSquares(Action<double[], double[]> F, double[] x, double[] lower, double[] upper, double[] Fx)
            => NonLinearLeastSquares(F, x, lower, upper, Fx, DEFAULT_EPS);

        /// <summary>
        /// Nonlinear Least Squares Solver. Fx = F(x). minimizes Norm_2(F(x))
        /// </summary>
        /// <param name="F">objective function, called in parallel</param>
        /// <param name="x">input values, initial guess to start, solution on exit</param>
        /// <param name="lower">x lower bound</param>
        /// <param name="upper">x upper bound</param>
        /// <param name="Fx">function values, just zero to start, solution on exit</param>
        /// <param name="eps">precisions for stop-criteria, defaults to all 1e-9</param>
        /// <param name="iter1">maximum number of iterations, defaults of 1000</param>
        /// <param name="iter2">maximum number of iterations of calculation of trial-step, default of 100</param>
        /// <param name="rs">initial step bound (0.1 - 100.0 recommended), default of 0.0 which MKL defaults as 100.0</param>
        /// <returns>stop criterion</returns>
        public static SolveResult NonLinearLeastSquares(SolveFn F, double[] x, double[] lower, double[] upper, double[] Fx, double[] eps, int iter1 = 1000, int iter2 = 100, double rs = 0.0)
        {
            int n = x.Length;
            int m = Fx.Length;
            var jac = new double[n * m];
            var f1 = new double[m];
            var f2 = new double[m];
            fixed (double* xp = &x[0], lowerp = &lower[0], upperp = &upper[0], epsp = &eps[0], Fxp = &Fx[0], jacp = &jac[0], f1p = &f1[0], f2p = &f2[0])
            {
                IntPtr handle;
                int request;
                var status = dtrnlspbc_init(&handle, &n, &m, xp, lowerp, upperp, epsp, &iter1, &iter1, &rs);
                while (status == SUCCESS && (status = dtrnlspbc_solve(&handle, Fxp, jacp, &request)) == SUCCESS)
                {
                    if (request == CALCULATE_FUNCTION) F(&m, &n, xp, Fxp);
                    else if (request == CALCULATE_JACOBIAN) status = djacobi(F, &n, &m, jacp, xp, epsp);
                    else if (request != ONE_ITERATION)
                    {
                        status = request;
                        break;
                    }
                }
                dtrnlspbc_delete(&handle);
                return (SolveResult)status;
            }
        }

        /// <summary>
        /// Nonlinear Least Squares Solver. Fx = F(x). minimizes Norm_2(F(x))
        /// </summary>
        /// <param name="F">objective function, called in parallel</param>
        /// <param name="x">input values, initial guess to start, solution on exit</param>
        /// <param name="lower">x lower bound</param>
        /// <param name="upper">x upper bound</param>
        /// <param name="Fx">function values, just zero to start, solution on exit</param>
        /// <returns>stop criterion</returns>
        public static SolveResult NonLinearLeastSquares(SolveFn F, double[] x, double[] lower, double[] upper, double[] Fx)
            => NonLinearLeastSquares(F, x, lower, upper, Fx, DEFAULT_EPS);

        /// <summary>
        /// Nonlinear Least Squares Solver. Fx = F(x). minimizes Norm_2(F(x))
        /// </summary>
        /// <param name="F">objective function, not called in parallel</param>
        /// <param name="x">input values, initial guess to start, solution on exit</param>
        /// <param name="Fx">function values, just zero to start, solution on exit</param>
        /// <param name="eps">precisions for stop-criteria, defaults to all 1e-9</param>
        /// <param name="iter1">maximum number of iterations, defaults of 1000</param>
        /// <param name="iter2">maximum number of iterations of calculation of trial-step, default of 100</param>
        /// <param name="rs">initial step bound (0.1 - 100.0 recommended), default of 0.0 which MKL defaults as 100.0</param>
        /// <returns>stop criterion</returns>
        public static SolveResult NonLinearLeastSquares(Action<float[], float[]> F, float[] x, float[] Fx, float[] eps, int iter1 = 1000, int iter2 = 100, float rs = 0.0f)
        {
            int n = x.Length;
            int m = Fx.Length;
            var jac = new float[n * m];
            var f1 = new float[m];
            var f2 = new float[m];
            fixed (float* xp = &x[0], epsp = &eps[0], Fxp = &Fx[0], jacp = &jac[0], f1p = &f1[0], f2p = &f2[0])
            {
                IntPtr handle;
                int request;
                var status = strnlsp_init(&handle, &n, &m, xp, epsp, &iter1, &iter1, &rs);
                while (status == SUCCESS && (status = strnlsp_solve(&handle, Fxp, jacp, &request)) == SUCCESS)
                {
                    if (request == CALCULATE_FUNCTION) F(x, Fx);
                    else if (request == CALCULATE_JACOBIAN)
                    {
                        IntPtr jacHandle;
                        int jacRequest;
                        status = sjacobi_init(&jacHandle, &n, &m, xp, jacp, epsp);
                        if (status == SUCCESS)
                            while ((status = sjacobi_solve(&jacHandle, f1p, f2p, &jacRequest)) == SUCCESS && jacRequest != 0)
                                F(x, jacRequest == 1 ? f1 : f2);
                        sjacobi_delete(&jacHandle);
                    }
                    else if (request != ONE_ITERATION)
                    {
                        status = request;
                        break;
                    }
                }
                strnlsp_delete(&handle);
                return (SolveResult)status;
            }
        }

        /// <summary>
        /// Nonlinear Least Squares Solver. Fx = F(x). minimizes Norm_2(F(x))
        /// </summary>
        /// <param name="F">objective function, not called in parallel</param>
        /// <param name="x">input values, initial guess to start, solution on exit</param>
        /// <param name="Fx">function values, just zero to start, solution on exit</param>
        /// <returns>stop criterion</returns>
        public static SolveResult NonLinearLeastSquares(Action<float[], float[]> F, float[] x, float[] Fx)
            => NonLinearLeastSquares(F, x, Fx, DEFAULT_EPS_FLOAT);

        /// <summary>
        /// Nonlinear Least Squares Solver. Fx = F(x). minimizes Norm_2(F(x))
        /// </summary>
        /// <param name="F">objective function, called in parallel</param>
        /// <param name="x">input values, initial guess to start, solution on exit</param>
        /// <param name="Fx">function values, just zero to start, solution on exit</param>
        /// <param name="eps">precisions for stop-criteria, defaults to all 1e-9</param>
        /// <param name="iter1">maximum number of iterations, defaults of 1000</param>
        /// <param name="iter2">maximum number of iterations of calculation of trial-step, default of 100</param>
        /// <param name="rs">initial step bound (0.1 - 100.0 recommended), default of 0.0 which MKL defaults as 100.0</param>
        /// <returns>stop criterion</returns>
        public static SolveResult NonLinearLeastSquares(SolveFnF F, float[] x, float[] Fx, float[] eps, int iter1 = 1000, int iter2 = 100, float rs = 0.0f)
        {
            int n = x.Length;
            int m = Fx.Length;
            var jac = new float[n * m];
            fixed (float* xp = &x[0], epsp = &eps[0], Fxp = &Fx[0], jacp = &jac[0])
            {
                IntPtr handle;
                int request;
                var status = strnlsp_init(&handle, &n, &m, xp, epsp, &iter1, &iter1, &rs);
                while (status == SUCCESS && (status = strnlsp_solve(&handle, Fxp, jacp, &request)) == SUCCESS)
                {
                    if (request == CALCULATE_FUNCTION) F(&m, &n, xp, Fxp);
                    else if (request == CALCULATE_JACOBIAN) status = sjacobi(F, &n, &m, jacp, xp, epsp);
                    else if (request != ONE_ITERATION)
                    {
                        status = request;
                        break;
                    }
                }
                strnlsp_delete(&handle);
                return (SolveResult)status;
            }
        }

        /// <summary>
        /// Nonlinear Least Squares Solver. Fx = F(x). minimizes Norm_2(F(x))
        /// </summary>
        /// <param name="F">objective function, called in parallel</param>
        /// <param name="x">input values, initial guess to start, solution on exit</param>
        /// <param name="Fx">function values, just zero to start, solution on exit</param>
        /// <returns>stop criterion</returns>
        public static SolveResult NonLinearLeastSquares(SolveFnF F, float[] x, float[] Fx)
            => NonLinearLeastSquares(F, x, Fx, DEFAULT_EPS_FLOAT);

        /// <summary>
        /// Nonlinear Least Squares Solver. Fx = F(x). minimizes Norm_2(F(x))
        /// </summary>
        /// <param name="F">objective function, not called in parallel</param>
        /// <param name="x">input values, initial guess to start, solution on exit</param>
        /// <param name="lower">x lower bound</param>
        /// <param name="upper">x upper bound</param>
        /// <param name="Fx">function values, just zero to start, solution on exit</param>
        /// <param name="eps">precisions for stop-criteria, defaults to all 1e-9</param>
        /// <param name="iter1">maximum number of iterations, defaults of 1000</param>
        /// <param name="iter2">maximum number of iterations of calculation of trial-step, default of 100</param>
        /// <param name="rs">initial step bound (0.1 - 100.0 recommended), default of 0.0 which MKL defaults as 100.0</param>
        /// <returns>stop criterion</returns>
        public static SolveResult NonLinearLeastSquares(Action<float[], float[]> F, float[] x, float[] lower, float[] upper, float[] Fx, float[] eps, int iter1 = 1000, int iter2 = 100, float rs = 0.0f)
        {
            int n = x.Length;
            int m = Fx.Length;
            var jac = new float[n * m];
            var f1 = new float[m];
            var f2 = new float[m];
            fixed (float* xp = &x[0], lowerp = &lower[0], upperp = &upper[0], epsp = &eps[0], Fxp = &Fx[0], jacp = &jac[0], f1p = &f1[0], f2p = &f2[0])
            {
                IntPtr handle;
                int request;
                var status = strnlspbc_init(&handle, &n, &m, xp, lowerp, upperp, epsp, &iter1, &iter1, &rs);
                while (status == SUCCESS && (status = strnlspbc_solve(&handle, Fxp, jacp, &request)) == SUCCESS)
                {
                    if (request == CALCULATE_FUNCTION) F(x, Fx);
                    else if (request == CALCULATE_JACOBIAN)
                    {
                        IntPtr jacHandle;
                        int jacRequest;
                        status = sjacobi_init(&jacHandle, &n, &m, xp, jacp, epsp);
                        if (status == SUCCESS)
                            while ((status = sjacobi_solve(&jacHandle, f1p, f2p, &jacRequest)) == SUCCESS && jacRequest != 0)
                                F(x, jacRequest == 1 ? f1 : f2);
                        sjacobi_delete(&jacHandle);
                    }
                    else if (request != ONE_ITERATION)
                    {
                        status = request;
                        break;
                    }
                }
                strnlspbc_delete(&handle);
                return (SolveResult)status;
            }
        }

        /// <summary>
        /// Nonlinear Least Squares Solver. Fx = F(x). minimizes Norm_2(F(x))
        /// </summary>
        /// <param name="F">objective function, not called in parallel</param>
        /// <param name="x">input values, initial guess to start, solution on exit</param>
        /// <param name="lower">x lower bound</param>
        /// <param name="upper">x upper bound</param>
        /// <param name="Fx">function values, just zero to start, solution on exit</param>
        /// <returns>stop criterion</returns>
        public static SolveResult NonLinearLeastSquares(Action<float[], float[]> F, float[] x, float[] lower, float[] upper, float[] Fx)
            => NonLinearLeastSquares(F, x, lower, upper, Fx, DEFAULT_EPS_FLOAT);

        /// <summary>
        /// Nonlinear Least Squares Solver. Fx = F(x). minimizes Norm_2(F(x))
        /// </summary>
        /// <param name="F">objective function, called in parallel</param>
        /// <param name="x">input values, initial guess to start, solution on exit</param>
        /// <param name="lower">x lower bound</param>
        /// <param name="upper">x upper bound</param>
        /// <param name="Fx">function values, just zero to start, solution on exit</param>
        /// <param name="eps">precisions for stop-criteria, defaults to all 1e-9</param>
        /// <param name="iter1">maximum number of iterations, defaults of 1000</param>
        /// <param name="iter2">maximum number of iterations of calculation of trial-step, default of 100</param>
        /// <param name="rs">initial step bound (0.1 - 100.0 recommended), default of 0.0 which MKL defaults as 100.0</param>
        /// <returns>stop criterion</returns>
        public static SolveResult NonLinearLeastSquares(SolveFnF F, float[] x, float[] lower, float[] upper, float[] Fx, float[] eps, int iter1 = 1000, int iter2 = 100, float rs = 0.0f)
        {
            int n = x.Length;
            int m = Fx.Length;
            var jac = new float[n * m];
            var f1 = new float[m];
            var f2 = new float[m];
            fixed (float* xp = &x[0], lowerp = &lower[0], upperp = &upper[0], epsp = &eps[0], Fxp = &Fx[0], jacp = &jac[0], f1p = &f1[0], f2p = &f2[0])
            {
                IntPtr handle;
                int request;
                var status = strnlspbc_init(&handle, &n, &m, xp, lowerp, upperp, epsp, &iter1, &iter1, &rs);
                while (status == SUCCESS && (status = strnlspbc_solve(&handle, Fxp, jacp, &request)) == SUCCESS)
                {
                    if (request == CALCULATE_FUNCTION) F(&m, &n, xp, Fxp);
                    else if (request == CALCULATE_JACOBIAN) status = sjacobi(F, &n, &m, jacp, xp, epsp);
                    else if (request != ONE_ITERATION)
                    {
                        status = request;
                        break;
                    }
                }
                strnlspbc_delete(&handle);
                return (SolveResult)status;
            }
        }

        /// <summary>
        /// Nonlinear Least Squares Solver. Fx = F(x). minimizes Norm_2(F(x))
        /// </summary>
        /// <param name="F">objective function, called in parallel</param>
        /// <param name="x">input values, initial guess to start, solution on exit</param>
        /// <param name="lower">x lower bound</param>
        /// <param name="upper">x upper bound</param>
        /// <param name="Fx">function values, just zero to start, solution on exit</param>
        /// <returns>stop criterion</returns>
        public static SolveResult NonLinearLeastSquares(SolveFnF F, float[] x, float[] lower, float[] upper, float[] Fx)
            => NonLinearLeastSquares(F, x, lower, upper, Fx, DEFAULT_EPS_FLOAT);
    }

    public unsafe delegate void SolveFn(int* m, int* n, double* x, double* f);
    public unsafe delegate void SolveFnF(int* m, int* n, float* x, float* f);

    public enum SolveResult
    {
        EXCEEDED_ITERATIONS = -1,
        DELTA_LESS_THAN_EPS0 = -2,
        F_NORM_2_LESS_THAN_EPS1 = -3,
        JACOBIAN_SINGULAR_LESS_THAN_ESP2 = -4,
        S_NORM_2_LESS_THAN_EPS3 = -5,
        F_J_S_LESS_THAN_EPS4 = -6,
        INVALID_OPTION = 1502,
        OUT_OF_MEMORY = 1503,
    }
}