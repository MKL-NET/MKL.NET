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

using System;
using System.Security;
using System.Runtime.InteropServices;

[SuppressUnmanagedCodeSecurity]
public unsafe static class Solve
{
    [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    static extern int dtrnlsp_init(IntPtr* handle, int* n, int* m, double* x, double* eps, int* iter1, int* iter2, double* rs);
    [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    static extern int dtrnlsp_solve(IntPtr* handle, double* fvec, double* fjac, int* RCI_Request);
    [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    static extern int dtrnlsp_delete(IntPtr* handle);
    [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    static extern int dtrnlspbc_init(IntPtr* handle, int* n, int* m, double* x, double* lower, double* upper, double* eps, int* iter1, int* iter2, double* rs);
    [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    static extern int dtrnlspbc_solve(IntPtr* handle, double* fvec, double* fjac, int* RCI_Request);
    [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    static extern int dtrnlspbc_delete(IntPtr* handle);
    [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    static extern int djacobi_init(IntPtr* handle, int* n, int* m, double* x, double* fjac, double* eps);
    [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    static extern int djacobi_solve(IntPtr* handle, double* f1, double* f2, int* RCI_Request);
    [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    static extern int djacobi_delete(IntPtr* handle);
    [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    static extern int djacobi(SolveFn fcn, int* n, int* m, double* fjac, double* x, double* eps);
    [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    static extern int strnlsp_init(IntPtr* handle, int* n, int* m, float* x, float* eps, int* iter1, int* iter2, float* rs);
    [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    static extern int strnlsp_solve(IntPtr* handle, float* fvec, float* fjac, int* RCI_Request);
    [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    static extern int strnlsp_delete(IntPtr* handle);
    [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    static extern int strnlspbc_init(IntPtr* handle, int* n, int* m, float* x, float* lower, float* upper, float* eps, int* iter1, int* iter2, float* rs);
    [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    static extern int strnlspbc_solve(IntPtr* handle, float* fvec, float* fjac, int* RCI_Request);
    [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    static extern int strnlspbc_delete(IntPtr* handle);
    [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    static extern int sjacobi_init(IntPtr* handle, int* n, int* m, float* x, float* fjac, float* eps);
    [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    static extern int sjacobi_solve(IntPtr* handle, float* f1, float* f2, int* RCI_Request);
    [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    static extern int sjacobi_delete(IntPtr* handle);
    [DllImport(MKL.DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    static extern int sjacobi(SolveFnF fcn, int* n, int* m, float* fjac, float* x, float* eps);

    const int ONE_ITERATION = 0;
    const int CALCULATE_FUNCTION = 1;
    const int CALCULATE_JACOBIAN = 2;
    const int SUCCESS = 1501;
    static readonly double[] DEFAULT_EPS = new[] { 1e-12, 1e-12, 1e-12, 1e-12, 1e-12, 1e-12 };
    static readonly float[] DEFAULT_EPS_FLOAT = new[] { 1e-7f, 1e-7f, 1e-7f, 1e-7f, 1e-7f, 1e-7f };
    static bool IsNaN(double[] d)
    {
        for (int i = 0; i < d.Length; i++)
            if (double.IsNaN(d[i]))
                return true;
        return false;
    }
    static bool IsNaN(float[] d)
    {
        for (int i = 0; i < d.Length; i++)
            if (float.IsNaN(d[i]))
                return true;
        return false;
    }

    /// <summary>
    /// Nonlinear Least Squares Solver. Fx = F(x). minimizes Norm_2(F(x))
    /// </summary>
    /// <param name="F">objective function, not called in parallel</param>
    /// <param name="x">input values, initial guess to start, solution on exit</param>
    /// <param name="Fx">function values, just zero to start, solution on exit</param>
    /// <param name="eps">precisions for stop-criteria, defaults to all 1e-9</param>
    /// <param name="iter">maximum number of iterations, defaults of 1000</param>
    /// <param name="rs">initial step bound (0.1 - 100.0 recommended), default of 0.0 which MKL defaults as 100.0</param>
    /// <param name="jeps">precision of the Jacobian matrix calculation</param>
    /// <returns>stop criterion</returns>
    public static SolveResult NonLinearLeastSquares(Action<double[], double[]> F, double[] x, double[] Fx, double[] eps, int iter = 1000, double rs = 0.0, double jeps = 1e-12)
    {
        int n = x.Length;
        int m = Fx.Length;
        var jac = new double[n * m];
        var f1 = new double[m];
        var f2 = new double[m];
        fixed (double* xp = x, epsp = eps, Fxp = Fx, jacp = jac, f1p = f1, f2p = f2)
        {
            IntPtr handle;
            int request;
            var status = dtrnlsp_init(&handle, &n, &m, xp, epsp, &iter, &iter, &rs);
            while (status == SUCCESS && (status = dtrnlsp_solve(&handle, Fxp, jacp, &request)) == SUCCESS)
            {
                if (request == CALCULATE_FUNCTION)
                {
                    if (IsNaN(x)) return SolveResult.NAN_PARAMETER;
                    F(x, Fx);
                }
                else if (request == CALCULATE_JACOBIAN)
                {
                    IntPtr jacHandle;
                    int jacRequest;
                    status = djacobi_init(&jacHandle, &n, &m, xp, jacp, &jeps);
                    if (status == SUCCESS)
                        while ((status = djacobi_solve(&jacHandle, f1p, f2p, &jacRequest)) == SUCCESS && jacRequest != 0)
                        {
                            if (IsNaN(x)) return SolveResult.NAN_PARAMETER;
                            F(x, jacRequest == 1 ? f1 : f2);
                        }
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
    /// <param name="J">Jacobian function, J_ij = df_i / dx_j as a column major array</param>
    /// <param name="x">input values, initial guess to start, solution on exit</param>
    /// <param name="Fx">function values, just zero to start, solution on exit</param>
    /// <param name="eps">precisions for stop-criteria, defaults to all 1e-9</param>
    /// <param name="iter">maximum number of iterations, defaults of 1000</param>
    /// <param name="rs">initial step bound (0.1 - 100.0 recommended), default of 0.0 which MKL defaults as 100.0</param>
    /// <returns>stop criterion</returns>
    public static SolveResult NonLinearLeastSquares(Action<double[], double[]> F, Action<double[], double[]> J, double[] x, double[] Fx, double[] eps, int iter = 1000, double rs = 0.0)
    {
        int n = x.Length;
        int m = Fx.Length;
        var jac = new double[n * m];
        fixed (double* xp = x, epsp = eps, Fxp = Fx, jacp = jac)
        {
            IntPtr handle;
            int request;
            var status = dtrnlsp_init(&handle, &n, &m, xp, epsp, &iter, &iter, &rs);
            if (status == SUCCESS)
                while ((status = dtrnlsp_solve(&handle, Fxp, jacp, &request)) == SUCCESS)
                {
                    if (request == CALCULATE_FUNCTION)
                    {
                        if (IsNaN(x)) return SolveResult.NAN_PARAMETER;
                        F(x, Fx);
                    }
                    else if (request == CALCULATE_JACOBIAN)
                    {
                        if (IsNaN(x)) return SolveResult.NAN_PARAMETER;
                        J(x, jac);
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
    /// <param name="F">objective function, not called in parallel</param>
    /// <param name="J">Jacobian function, J_ij = df_i / dx_j as a column major array</param>
    /// <param name="x">input values, initial guess to start, solution on exit</param>
    /// <param name="Fx">function values, just zero to start, solution on exit</param>
    /// <returns>stop criterion</returns>
    public static SolveResult NonLinearLeastSquares(Action<double[], double[]> F, Action<double[], double[]> J, double[] x, double[] Fx)
        => NonLinearLeastSquares(F, J, x, Fx, DEFAULT_EPS);

    /// <summary>
    /// Nonlinear Least Squares Solver. Fx = F(x). minimizes Norm_2(F(x))
    /// </summary>
    /// <param name="F">objective function, called in parallel</param>
    /// <param name="x">input values, initial guess to start, solution on exit</param>
    /// <param name="Fx">function values, just zero to start, solution on exit</param>
    /// <param name="eps">precisions for stop-criteria, defaults to all 1e-9</param>
    /// <param name="iter">maximum number of iterations, defaults of 1000</param>
    /// <param name="rs">initial step bound (0.1 - 100.0 recommended), default of 0.0 which MKL defaults as 100.0</param>
    /// <param name="jeps">precision of the Jacobian matrix calculation</param>
    /// <returns>stop criterion</returns>
    public static SolveResult NonLinearLeastSquares(SolveFn F, double[] x, double[] Fx, double[] eps, int iter = 1000, double rs = 0.0, double jeps = 1e-12)
    {
        int n = x.Length;
        int m = Fx.Length;
        var jac = new double[n * m];
        fixed (double* xp = x, epsp = eps, Fxp = Fx, jacp = jac)
        {
            IntPtr handle;
            int request;
            var status = dtrnlsp_init(&handle, &n, &m, xp, epsp, &iter, &iter, &rs);
            while (status == SUCCESS && (status = dtrnlsp_solve(&handle, Fxp, jacp, &request)) == SUCCESS)
            {
                if (request == CALCULATE_FUNCTION)
                {
                    if (IsNaN(x)) return SolveResult.NAN_PARAMETER;
                    F(&m, &n, xp, Fxp);
                }
                else if (request == CALCULATE_JACOBIAN)
                {
                    if (IsNaN(x)) return SolveResult.NAN_PARAMETER;
                    status = djacobi(F, &n, &m, jacp, xp, &jeps);
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
    /// <param name="F">objective function, called in parallel</param>
    /// <param name="J">Jacobian function, J_ij = df_i / dx_j as a column major array</param>
    /// <param name="x">input values, initial guess to start, solution on exit</param>
    /// <param name="Fx">function values, just zero to start, solution on exit</param>
    /// <param name="eps">precisions for stop-criteria, defaults to all 1e-9</param>
    /// <param name="iter">maximum number of iterations, defaults of 1000</param>
    /// <param name="rs">initial step bound (0.1 - 100.0 recommended), default of 0.0 which MKL defaults as 100.0</param>
    /// <returns>stop criterion</returns>
    public static SolveResult NonLinearLeastSquares(SolveFn F, Action<double[], double[]> J, double[] x, double[] Fx, double[] eps, int iter = 1000, double rs = 0.0)
    {
        int n = x.Length;
        int m = Fx.Length;
        var jac = new double[n * m];
        fixed (double* xp = x, epsp = eps, Fxp = Fx, jacp = jac)
        {
            IntPtr handle;
            int request;
            var status = dtrnlsp_init(&handle, &n, &m, xp, epsp, &iter, &iter, &rs);
            if (status == SUCCESS)
                while ((status = dtrnlsp_solve(&handle, Fxp, jacp, &request)) == SUCCESS)
                {
                    if (request == CALCULATE_FUNCTION)
                    {
                        if (IsNaN(x)) return SolveResult.NAN_PARAMETER;
                        F(&m, &n, xp, Fxp);
                    }
                    else if (request == CALCULATE_JACOBIAN)
                    {
                        if (IsNaN(x)) return SolveResult.NAN_PARAMETER;
                        J(x, jac);
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
    /// <param name="F">objective function, called in parallel</param>
    /// <param name="x">input values, initial guess to start, solution on exit</param>
    /// <param name="Fx">function values, just zero to start, solution on exit</param>
    /// <returns>stop criterion</returns>
    public static SolveResult NonLinearLeastSquares(SolveFn F, double[] x, double[] Fx)
        => NonLinearLeastSquares(F, x, Fx, DEFAULT_EPS);

    /// <summary>
    /// Nonlinear Least Squares Solver. Fx = F(x). minimizes Norm_2(F(x))
    /// </summary>
    /// <param name="F">objective function, called in parallel</param>
    /// <param name="J">Jacobian function, J_ij = df_i / dx_j as a column major array</param>
    /// <param name="x">input values, initial guess to start, solution on exit</param>
    /// <param name="Fx">function values, just zero to start, solution on exit</param>
    /// <returns>stop criterion</returns>
    public static SolveResult NonLinearLeastSquares(SolveFn F, Action<double[], double[]> J, double[] x, double[] Fx)
        => NonLinearLeastSquares(F, J, x, Fx, DEFAULT_EPS);

    /// <summary>
    /// Nonlinear Least Squares Solver. Fx = F(x). minimizes Norm_2(F(x))
    /// </summary>
    /// <param name="F">objective function, not called in parallel</param>
    /// <param name="x">input values, initial guess to start, solution on exit</param>
    /// <param name="lower">x lower bound</param>
    /// <param name="upper">x upper bound</param>
    /// <param name="Fx">function values, just zero to start, solution on exit</param>
    /// <param name="eps">precisions for stop-criteria, defaults to all 1e-9</param>
    /// <param name="iter">maximum number of iterations, defaults of 1000</param>
    /// <param name="rs">initial step bound (0.1 - 100.0 recommended), default of 0.0 which MKL defaults as 100.0</param>
    /// <param name="jeps">precision of the Jacobian matrix calculation</param>
    /// <returns>stop criterion</returns>
    public static SolveResult NonLinearLeastSquares(Action<double[], double[]> F, double[] x, double[] lower, double[] upper, double[] Fx, double[] eps, int iter = 1000, double rs = 0.0, double jeps = 1e-12)
    {
        int n = x.Length;
        int m = Fx.Length;
        var jac = new double[n * m];
        var f1 = new double[m];
        var f2 = new double[m];
        fixed (double* xp = x, lowerp = lower, upperp = upper, epsp = eps, Fxp = Fx, jacp = jac, f1p = f1, f2p = f2)
        {
            IntPtr handle;
            int request;
            var status = dtrnlspbc_init(&handle, &n, &m, xp, lowerp, upperp, epsp, &iter, &iter, &rs);
            while (status == SUCCESS && (status = dtrnlspbc_solve(&handle, Fxp, jacp, &request)) == SUCCESS)
            {
                if (request == CALCULATE_FUNCTION)
                {
                    if (IsNaN(x)) return SolveResult.NAN_PARAMETER;
                    F(x, Fx);
                }
                else if (request == CALCULATE_JACOBIAN)
                {
                    IntPtr jacHandle;
                    int jacRequest;
                    status = djacobi_init(&jacHandle, &n, &m, xp, jacp, &jeps);
                    if (status == SUCCESS)
                        while ((status = djacobi_solve(&jacHandle, f1p, f2p, &jacRequest)) == SUCCESS && jacRequest != 0)
                        {
                            if (IsNaN(x)) return SolveResult.NAN_PARAMETER;
                            F(x, jacRequest == 1 ? f1 : f2);
                        }
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
    /// <param name="J">Jacobian function, J_ij = df_i / dx_j as a column major array</param>
    /// <param name="x">input values, initial guess to start, solution on exit</param>
    /// <param name="lower">x lower bound</param>
    /// <param name="upper">x upper bound</param>
    /// <param name="Fx">function values, just zero to start, solution on exit</param>
    /// <param name="eps">precisions for stop-criteria, defaults to all 1e-9</param>
    /// <param name="iter">maximum number of iterations, defaults of 1000</param>
    /// <param name="rs">initial step bound (0.1 - 100.0 recommended), default of 0.0 which MKL defaults as 100.0</param>
    /// <returns>stop criterion</returns>
    public static SolveResult NonLinearLeastSquares(Action<double[], double[]> F, Action<double[], double[]> J, double[] x, double[] lower, double[] upper, double[] Fx, double[] eps, int iter = 1000, double rs = 0.0)
    {
        int n = x.Length;
        int m = Fx.Length;
        var jac = new double[n * m];
        fixed (double* xp = x, lowerp = lower, upperp = upper, epsp = eps, Fxp = Fx, jacp = jac)
        {
            IntPtr handle;
            int request;
            var status = dtrnlspbc_init(&handle, &n, &m, xp, lowerp, upperp, epsp, &iter, &iter, &rs);
            if (status == SUCCESS)
                while ((status = dtrnlspbc_solve(&handle, Fxp, jacp, &request)) == SUCCESS)
                {
                    if (request == CALCULATE_FUNCTION)
                    {
                        if (IsNaN(x)) return SolveResult.NAN_PARAMETER;
                        F(x, Fx);
                    }
                    else if (request == CALCULATE_JACOBIAN)
                    {
                        if (IsNaN(x)) return SolveResult.NAN_PARAMETER;
                        J(x, jac);
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
    /// <param name="F">objective function, not called in parallel</param>
    /// <param name="J">Jacobian function, J_ij = df_i / dx_j as a column major array</param>
    /// <param name="x">input values, initial guess to start, solution on exit</param>
    /// <param name="lower">x lower bound</param>
    /// <param name="upper">x upper bound</param>
    /// <param name="Fx">function values, just zero to start, solution on exit</param>
    /// <returns>stop criterion</returns>
    public static SolveResult NonLinearLeastSquares(Action<double[], double[]> F, Action<double[], double[]> J, double[] x, double[] lower, double[] upper, double[] Fx)
        => NonLinearLeastSquares(F, J, x, lower, upper, Fx, DEFAULT_EPS);

    /// <summary>
    /// Nonlinear Least Squares Solver. Fx = F(x). minimizes Norm_2(F(x))
    /// </summary>
    /// <param name="F">objective function, called in parallel</param>
    /// <param name="x">input values, initial guess to start, solution on exit</param>
    /// <param name="lower">x lower bound</param>
    /// <param name="upper">x upper bound</param>
    /// <param name="Fx">function values, just zero to start, solution on exit</param>
    /// <param name="eps">precisions for stop-criteria, defaults to all 1e-9</param>
    /// <param name="iter">maximum number of iterations, defaults of 1000</param>
    /// <param name="rs">initial step bound (0.1 - 100.0 recommended), default of 0.0 which MKL defaults as 100.0</param>
    /// <param name="jeps">precision of the Jacobian matrix calculation</param>
    /// <returns>stop criterion</returns>
    public static SolveResult NonLinearLeastSquares(SolveFn F, double[] x, double[] lower, double[] upper, double[] Fx, double[] eps, int iter = 1000, double rs = 0.0, double jeps = 1e-12)
    {
        int n = x.Length;
        int m = Fx.Length;
        var jac = new double[n * m];
        var f1 = new double[m];
        var f2 = new double[m];
        fixed (double* xp = x, lowerp = lower, upperp = upper, epsp = eps, Fxp = Fx, jacp = jac, f1p = f1, f2p = f2)
        {
            IntPtr handle;
            int request;
            var status = dtrnlspbc_init(&handle, &n, &m, xp, lowerp, upperp, epsp, &iter, &iter, &rs);
            while (status == SUCCESS && (status = dtrnlspbc_solve(&handle, Fxp, jacp, &request)) == SUCCESS)
            {
                if (request == CALCULATE_FUNCTION)
                {
                    if (IsNaN(x)) return SolveResult.NAN_PARAMETER;
                    F(&m, &n, xp, Fxp);
                }
                else if (request == CALCULATE_JACOBIAN)
                {
                    if (IsNaN(x)) return SolveResult.NAN_PARAMETER;
                    status = djacobi(F, &n, &m, jacp, xp, &jeps);
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
    /// <param name="F">objective function, called in parallel</param>
    /// <param name="J">Jacobian function, J_ij = df_i / dx_j as a column major array</param>
    /// <param name="x">input values, initial guess to start, solution on exit</param>
    /// <param name="lower">x lower bound</param>
    /// <param name="upper">x upper bound</param>
    /// <param name="Fx">function values, just zero to start, solution on exit</param>
    /// <param name="eps">precisions for stop-criteria, defaults to all 1e-9</param>
    /// <param name="iter">maximum number of iterations, defaults of 1000</param>
    /// <param name="rs">initial step bound (0.1 - 100.0 recommended), default of 0.0 which MKL defaults as 100.0</param>
    /// <returns>stop criterion</returns>
    public static SolveResult NonLinearLeastSquares(SolveFn F, Action<double[], double[]> J, double[] x, double[] lower, double[] upper, double[] Fx, double[] eps, int iter = 1000, double rs = 0.0)
    {
        int n = x.Length;
        int m = Fx.Length;
        var jac = new double[n * m];
        var f1 = new double[m];
        var f2 = new double[m];
        fixed (double* xp = x, lowerp = lower, upperp = upper, epsp = eps, Fxp = Fx, jacp = jac, f1p = f1, f2p = f2)
        {
            IntPtr handle;
            int request;
            var status = dtrnlspbc_init(&handle, &n, &m, xp, lowerp, upperp, epsp, &iter, &iter, &rs);
            if (status == SUCCESS)
                while ((status = dtrnlspbc_solve(&handle, Fxp, jacp, &request)) == SUCCESS)
                {
                    if (request == CALCULATE_FUNCTION)
                    {
                        if (IsNaN(x)) return SolveResult.NAN_PARAMETER;
                        F(&m, &n, xp, Fxp);
                    }
                    else if (request == CALCULATE_JACOBIAN)
                    {
                        if (IsNaN(x)) return SolveResult.NAN_PARAMETER;
                        J(x, jac);
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
    /// <param name="F">objective function, called in parallel</param>
    /// <param name="J">Jacobian function, J_ij = df_i / dx_j as a column major array</param>
    /// <param name="x">input values, initial guess to start, solution on exit</param>
    /// <param name="lower">x lower bound</param>
    /// <param name="upper">x upper bound</param>
    /// <param name="Fx">function values, just zero to start, solution on exit</param>
    /// <returns>stop criterion</returns>
    public static SolveResult NonLinearLeastSquares(SolveFn F, Action<double[], double[]> J, double[] x, double[] lower, double[] upper, double[] Fx)
        => NonLinearLeastSquares(F, J, x, lower, upper, Fx, DEFAULT_EPS);

    /// <summary>
    /// Nonlinear Least Squares Solver. Fx = F(x). minimizes Norm_2(F(x))
    /// </summary>
    /// <param name="F">objective function, not called in parallel</param>
    /// <param name="x">input values, initial guess to start, solution on exit</param>
    /// <param name="Fx">function values, just zero to start, solution on exit</param>
    /// <param name="eps">precisions for stop-criteria, defaults to all 1e-9</param>
    /// <param name="iter">maximum number of iterations, defaults of 1000</param>
    /// <param name="rs">initial step bound (0.1 - 100.0 recommended), default of 0.0 which MKL defaults as 100.0</param>
    /// <param name="jeps">precision of the Jacobian matrix calculation</param>
    /// <returns>stop criterion</returns>
    public static SolveResult NonLinearLeastSquares(Action<float[], float[]> F, float[] x, float[] Fx, float[] eps, int iter = 1000, float rs = 0.0f, float jeps = 1e-7f)
    {
        int n = x.Length;
        int m = Fx.Length;
        var jac = new float[n * m];
        var f1 = new float[m];
        var f2 = new float[m];
        fixed (float* xp = x, epsp = eps, Fxp = Fx, jacp = jac, f1p = f1, f2p = f2)
        {
            IntPtr handle;
            int request;
            var status = strnlsp_init(&handle, &n, &m, xp, epsp, &iter, &iter, &rs);
            while (status == SUCCESS && (status = strnlsp_solve(&handle, Fxp, jacp, &request)) == SUCCESS)
            {
                if (request == CALCULATE_FUNCTION)
                {
                    if (IsNaN(x)) return SolveResult.NAN_PARAMETER;
                    F(x, Fx);
                }
                else if (request == CALCULATE_JACOBIAN)
                {
                    IntPtr jacHandle;
                    int jacRequest;
                    status = sjacobi_init(&jacHandle, &n, &m, xp, jacp, &jeps);
                    if (status == SUCCESS)
                        while ((status = sjacobi_solve(&jacHandle, f1p, f2p, &jacRequest)) == SUCCESS && jacRequest != 0)
                        {
                            if (IsNaN(x)) return SolveResult.NAN_PARAMETER;
                            F(x, jacRequest == 1 ? f1 : f2);
                        }
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
    /// <param name="J">Jacobian function, J_ij = df_i / dx_j as a column major array</param>
    /// <param name="x">input values, initial guess to start, solution on exit</param>
    /// <param name="Fx">function values, just zero to start, solution on exit</param>
    /// <param name="eps">precisions for stop-criteria, defaults to all 1e-9</param>
    /// <param name="iter">maximum number of iterations, defaults of 1000</param>
    /// <param name="rs">initial step bound (0.1 - 100.0 recommended), default of 0.0 which MKL defaults as 100.0</param>
    /// <returns>stop criterion</returns>
    public static SolveResult NonLinearLeastSquares(Action<float[], float[]> F, Action<float[], float[]> J, float[] x, float[] Fx, float[] eps, int iter = 1000, float rs = 0.0f)
    {
        int n = x.Length;
        int m = Fx.Length;
        var jac = new float[n * m];
        fixed (float* xp = x, epsp = eps, Fxp = Fx, jacp = jac)
        {
            IntPtr handle;
            int request;
            var status = strnlsp_init(&handle, &n, &m, xp, epsp, &iter, &iter, &rs);
            if (status == SUCCESS)
                while ((status = strnlsp_solve(&handle, Fxp, jacp, &request)) == SUCCESS)
                {
                    if (request == CALCULATE_FUNCTION)
                    {
                        if (IsNaN(x)) return SolveResult.NAN_PARAMETER;
                        F(x, Fx);
                    }
                    else if (request == CALCULATE_JACOBIAN)
                    {
                        if (IsNaN(x)) return SolveResult.NAN_PARAMETER;
                        J(x, jac);
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
    /// <param name="F">objective function, not called in parallel</param>
    /// <param name="J">Jacobian function, J_ij = df_i / dx_j as a column major array</param>
    /// <param name="x">input values, initial guess to start, solution on exit</param>
    /// <param name="Fx">function values, just zero to start, solution on exit</param>
    /// <returns>stop criterion</returns>
    public static SolveResult NonLinearLeastSquares(Action<float[], float[]> F, Action<float[], float[]> J, float[] x, float[] Fx)
        => NonLinearLeastSquares(F, J, x, Fx, DEFAULT_EPS_FLOAT);

    /// <summary>
    /// Nonlinear Least Squares Solver. Fx = F(x). minimizes Norm_2(F(x))
    /// </summary>
    /// <param name="F">objective function, called in parallel</param>
    /// <param name="x">input values, initial guess to start, solution on exit</param>
    /// <param name="Fx">function values, just zero to start, solution on exit</param>
    /// <param name="eps">precisions for stop-criteria, defaults to all 1e-9</param>
    /// <param name="iter">maximum number of iterations, defaults of 1000</param>
    /// <param name="rs">initial step bound (0.1 - 100.0 recommended), default of 0.0 which MKL defaults as 100.0</param>
    /// <param name="jeps">precision of the Jacobian matrix calculation</param>
    /// <returns>stop criterion</returns>
    public static SolveResult NonLinearLeastSquares(SolveFnF F, float[] x, float[] Fx, float[] eps, int iter = 1000, float rs = 0.0f, float jeps = 1e-7f)
    {
        int n = x.Length;
        int m = Fx.Length;
        var jac = new float[n * m];
        fixed (float* xp = x, epsp = eps, Fxp = Fx, jacp = jac)
        {
            IntPtr handle;
            int request;
            var status = strnlsp_init(&handle, &n, &m, xp, epsp, &iter, &iter, &rs);
            while (status == SUCCESS && (status = strnlsp_solve(&handle, Fxp, jacp, &request)) == SUCCESS)
            {
                if (request == CALCULATE_FUNCTION)
                {
                    if (IsNaN(x)) return SolveResult.NAN_PARAMETER;
                    F(&m, &n, xp, Fxp);
                }
                else if (request == CALCULATE_JACOBIAN)
                {
                    if (IsNaN(x)) return SolveResult.NAN_PARAMETER;
                    status = sjacobi(F, &n, &m, jacp, xp, &jeps);
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
    /// <param name="F">objective function, called in parallel</param>
    /// <param name="J">Jacobian function, J_ij = df_i / dx_j as a column major array</param>
    /// <param name="x">input values, initial guess to start, solution on exit</param>
    /// <param name="Fx">function values, just zero to start, solution on exit</param>
    /// <param name="eps">precisions for stop-criteria, defaults to all 1e-9</param>
    /// <param name="iter">maximum number of iterations, defaults of 1000</param>
    /// <param name="rs">initial step bound (0.1 - 100.0 recommended), default of 0.0 which MKL defaults as 100.0</param>
    /// <returns>stop criterion</returns>
    public static SolveResult NonLinearLeastSquares(SolveFnF F, Action<float[], float[]> J, float[] x, float[] Fx, float[] eps, int iter = 1000, float rs = 0.0f)
    {
        int n = x.Length;
        int m = Fx.Length;
        var jac = new float[n * m];
        fixed (float* xp = x, epsp = eps, Fxp = Fx, jacp = jac)
        {
            IntPtr handle;
            int request;
            var status = strnlsp_init(&handle, &n, &m, xp, epsp, &iter, &iter, &rs);
            if (status == SUCCESS)
                while ((status = strnlsp_solve(&handle, Fxp, jacp, &request)) == SUCCESS)
                {
                    if (request == CALCULATE_FUNCTION)
                    {
                        if (IsNaN(x)) return SolveResult.NAN_PARAMETER;
                        F(&m, &n, xp, Fxp);
                    }
                    else if (request == CALCULATE_JACOBIAN)
                    {
                        if (IsNaN(x)) return SolveResult.NAN_PARAMETER;
                        J(x, jac);
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
    /// <param name="F">objective function, called in parallel</param>
    /// <param name="x">input values, initial guess to start, solution on exit</param>
    /// <param name="Fx">function values, just zero to start, solution on exit</param>
    /// <returns>stop criterion</returns>
    public static SolveResult NonLinearLeastSquares(SolveFnF F, float[] x, float[] Fx)
        => NonLinearLeastSquares(F, x, Fx, DEFAULT_EPS_FLOAT);

    /// <summary>
    /// Nonlinear Least Squares Solver. Fx = F(x). minimizes Norm_2(F(x))
    /// </summary>
    /// <param name="F">objective function, called in parallel</param>
    /// <param name="J">Jacobian function, J_ij = df_i / dx_j as a column major array</param>
    /// <param name="x">input values, initial guess to start, solution on exit</param>
    /// <param name="Fx">function values, just zero to start, solution on exit</param>
    /// <returns>stop criterion</returns>
    public static SolveResult NonLinearLeastSquares(SolveFnF F, Action<float[], float[]> J, float[] x, float[] Fx)
        => NonLinearLeastSquares(F, J, x, Fx, DEFAULT_EPS_FLOAT);

    /// <summary>
    /// Nonlinear Least Squares Solver. Fx = F(x). minimizes Norm_2(F(x))
    /// </summary>
    /// <param name="F">objective function, not called in parallel</param>
    /// <param name="x">input values, initial guess to start, solution on exit</param>
    /// <param name="lower">x lower bound</param>
    /// <param name="upper">x upper bound</param>
    /// <param name="Fx">function values, just zero to start, solution on exit</param>
    /// <param name="eps">precisions for stop-criteria, defaults to all 1e-9</param>
    /// <param name="iter">maximum number of iterations, defaults of 1000</param>
    /// <param name="rs">initial step bound (0.1 - 100.0 recommended), default of 0.0 which MKL defaults as 100.0</param>
    /// <param name="jeps">precision of the Jacobian matrix calculation</param>
    /// <returns>stop criterion</returns>
    public static SolveResult NonLinearLeastSquares(Action<float[], float[]> F, float[] x, float[] lower, float[] upper, float[] Fx, float[] eps, int iter = 1000, float rs = 0.0f, float jeps = 1e-7f)
    {
        int n = x.Length;
        int m = Fx.Length;
        var jac = new float[n * m];
        var f1 = new float[m];
        var f2 = new float[m];
        fixed (float* xp = x, lowerp = lower, upperp = upper, epsp = eps, Fxp = Fx, jacp = jac, f1p = f1, f2p = f2)
        {
            IntPtr handle;
            int request;
            var status = strnlspbc_init(&handle, &n, &m, xp, lowerp, upperp, epsp, &iter, &iter, &rs);
            while (status == SUCCESS && (status = strnlspbc_solve(&handle, Fxp, jacp, &request)) == SUCCESS)
            {
                if (request == CALCULATE_FUNCTION)
                {
                    if (IsNaN(x)) return SolveResult.NAN_PARAMETER;
                    F(x, Fx);
                }
                else if (request == CALCULATE_JACOBIAN)
                {
                    IntPtr jacHandle;
                    int jacRequest;
                    status = sjacobi_init(&jacHandle, &n, &m, xp, jacp, &jeps);
                    if (status == SUCCESS)
                        while ((status = sjacobi_solve(&jacHandle, f1p, f2p, &jacRequest)) == SUCCESS && jacRequest != 0)
                        {
                            if (IsNaN(x)) return SolveResult.NAN_PARAMETER;
                            F(x, jacRequest == 1 ? f1 : f2);
                        }
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
    /// <param name="J">Jacobian function, J_ij = df_i / dx_j as a column major array</param>
    /// <param name="x">input values, initial guess to start, solution on exit</param>
    /// <param name="lower">x lower bound</param>
    /// <param name="upper">x upper bound</param>
    /// <param name="Fx">function values, just zero to start, solution on exit</param>
    /// <param name="eps">precisions for stop-criteria, defaults to all 1e-9</param>
    /// <param name="iter">maximum number of iterations, defaults of 1000</param>
    /// <param name="rs">initial step bound (0.1 - 100.0 recommended), default of 0.0 which MKL defaults as 100.0</param>
    /// <returns>stop criterion</returns>
    public static SolveResult NonLinearLeastSquares(Action<float[], float[]> F, Action<float[], float[]> J, float[] x, float[] lower, float[] upper, float[] Fx, float[] eps, int iter = 1000, float rs = 0.0f)
    {
        int n = x.Length;
        int m = Fx.Length;
        var jac = new float[n * m];
        fixed (float* xp = x, lowerp = lower, upperp = upper, epsp = eps, Fxp = Fx, jacp = jac)
        {
            IntPtr handle;
            int request;
            var status = strnlspbc_init(&handle, &n, &m, xp, lowerp, upperp, epsp, &iter, &iter, &rs);
            if (status == SUCCESS)
                while ((status = strnlspbc_solve(&handle, Fxp, jacp, &request)) == SUCCESS)
                {
                    if (request == CALCULATE_FUNCTION)
                    {
                        if (IsNaN(x)) return SolveResult.NAN_PARAMETER;
                        F(x, Fx);
                    }
                    else if (request == CALCULATE_JACOBIAN)
                    {
                        if (IsNaN(x)) return SolveResult.NAN_PARAMETER;
                        J(x, jac);
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
    /// <param name="F">objective function, not called in parallel</param>
    /// <param name="J">Jacobian function, J_ij = df_i / dx_j as a column major array</param>
    /// <param name="x">input values, initial guess to start, solution on exit</param>
    /// <param name="lower">x lower bound</param>
    /// <param name="upper">x upper bound</param>
    /// <param name="Fx">function values, just zero to start, solution on exit</param>
    /// <returns>stop criterion</returns>
    public static SolveResult NonLinearLeastSquares(Action<float[], float[]> F, Action<float[], float[]> J, float[] x, float[] lower, float[] upper, float[] Fx)
        => NonLinearLeastSquares(F, J, x, lower, upper, Fx, DEFAULT_EPS_FLOAT);

    /// <summary>
    /// Nonlinear Least Squares Solver. Fx = F(x). minimizes Norm_2(F(x))
    /// </summary>
    /// <param name="F">objective function, called in parallel</param>
    /// <param name="x">input values, initial guess to start, solution on exit</param>
    /// <param name="lower">x lower bound</param>
    /// <param name="upper">x upper bound</param>
    /// <param name="Fx">function values, just zero to start, solution on exit</param>
    /// <param name="eps">precisions for stop-criteria, defaults to all 1e-9</param>
    /// <param name="iter">maximum number of iterations, defaults of 1000</param>
    /// <param name="rs">initial step bound (0.1 - 100.0 recommended), default of 0.0 which MKL defaults as 100.0</param>
    /// <param name="jeps">precision of the Jacobian matrix calculation</param>
    /// <returns>stop criterion</returns>
    public static SolveResult NonLinearLeastSquares(SolveFnF F, float[] x, float[] lower, float[] upper, float[] Fx, float[] eps, int iter = 1000, float rs = 0.0f, float jeps = 1e-7f)
    {
        int n = x.Length;
        int m = Fx.Length;
        var jac = new float[n * m];
        var f1 = new float[m];
        var f2 = new float[m];
        fixed (float* xp = x, lowerp = lower, upperp = upper, epsp = eps, Fxp = Fx, jacp = jac, f1p = f1, f2p = f2)
        {
            IntPtr handle;
            int request;
            var status = strnlspbc_init(&handle, &n, &m, xp, lowerp, upperp, epsp, &iter, &iter, &rs);
            while (status == SUCCESS && (status = strnlspbc_solve(&handle, Fxp, jacp, &request)) == SUCCESS)
            {
                if (request == CALCULATE_FUNCTION)
                {
                    if (IsNaN(x)) return SolveResult.NAN_PARAMETER;
                    F(&m, &n, xp, Fxp);
                }
                else if (request == CALCULATE_JACOBIAN)
                {
                    if (IsNaN(x)) return SolveResult.NAN_PARAMETER;
                    status = sjacobi(F, &n, &m, jacp, xp, &jeps);
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
    /// <param name="F">objective function, called in parallel</param>
    /// <param name="J">Jacobian function, J_ij = df_i / dx_j as a column major array</param>
    /// <param name="x">input values, initial guess to start, solution on exit</param>
    /// <param name="lower">x lower bound</param>
    /// <param name="upper">x upper bound</param>
    /// <param name="Fx">function values, just zero to start, solution on exit</param>
    /// <param name="eps">precisions for stop-criteria, defaults to all 1e-9</param>
    /// <param name="iter">maximum number of iterations, defaults of 1000</param>
    /// <param name="rs">initial step bound (0.1 - 100.0 recommended), default of 0.0 which MKL defaults as 100.0</param>
    /// <returns>stop criterion</returns>
    public static SolveResult NonLinearLeastSquares(SolveFnF F, Action<float[], float[]> J, float[] x, float[] lower, float[] upper, float[] Fx, float[] eps, int iter = 1000, float rs = 0.0f)
    {
        int n = x.Length;
        int m = Fx.Length;
        var jac = new float[n * m];
        fixed (float* xp = x, lowerp = lower, upperp = upper, epsp = eps, Fxp = Fx, jacp = jac)
        {
            IntPtr handle;
            int request;
            var status = strnlspbc_init(&handle, &n, &m, xp, lowerp, upperp, epsp, &iter, &iter, &rs);
            if (status == SUCCESS)
                while ((status = strnlspbc_solve(&handle, Fxp, jacp, &request)) == SUCCESS)
                {
                    if (request == CALCULATE_FUNCTION)
                    {
                        if (IsNaN(x)) return SolveResult.NAN_PARAMETER;
                        F(&m, &n, xp, Fxp);
                    }
                    else if (request == CALCULATE_JACOBIAN)
                    {
                        if (IsNaN(x)) return SolveResult.NAN_PARAMETER;
                        J(x, jac);
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
    /// <param name="F">objective function, called in parallel</param>
    /// <param name="x">input values, initial guess to start, solution on exit</param>
    /// <param name="lower">x lower bound</param>
    /// <param name="upper">x upper bound</param>
    /// <param name="Fx">function values, just zero to start, solution on exit</param>
    /// <returns>stop criterion</returns>
    public static SolveResult NonLinearLeastSquares(SolveFnF F, float[] x, float[] lower, float[] upper, float[] Fx)
        => NonLinearLeastSquares(F, x, lower, upper, Fx, DEFAULT_EPS_FLOAT);

    /// <summary>
    /// Nonlinear Least Squares Solver. Fx = F(x). minimizes Norm_2(F(x))
    /// </summary>
    /// <param name="F">objective function, called in parallel</param>
    /// <param name="J">Jacobian function, J_ij = df_i / dx_j as a column major array</param>
    /// <param name="x">input values, initial guess to start, solution on exit</param>
    /// <param name="lower">x lower bound</param>
    /// <param name="upper">x upper bound</param>
    /// <param name="Fx">function values, just zero to start, solution on exit</param>
    /// <returns>stop criterion</returns>
    public static SolveResult NonLinearLeastSquares(SolveFnF F, Action<float[], float[]> J, float[] x, float[] lower, float[] upper, float[] Fx)
        => NonLinearLeastSquares(F, J, x, lower, upper, Fx, DEFAULT_EPS_FLOAT);
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
    NAN_PARAMETER = 10000,
}