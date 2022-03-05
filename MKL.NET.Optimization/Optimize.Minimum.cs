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

using System;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace MKLNET
{
    public static partial class Optimize
    {
        /// <summary>Test if a minimum is bracketed by the function outputs.</summary>
        /// <param name="fa">First function output.</param>
        /// <param name="fb">Middle function output.</param>
        /// <param name="fc">Third function output.</param>
        /// <returns>True if the middle function output is less than or equals to the two outer.</returns>
        public static bool Minimum_Is_Bracketed(double fa, double fb, double fc)
            => fa >= fb && fb <= fc;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static double Minimum_BiSection(double atol, double rtol, double a, double b, double c)
        {
            var x = (a + c) * 0.5;
            if (x == b) return x + Tol(atol, rtol, x) * 0.1;
            return x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static double Sqr(double x) => x * x;

        const double GOLD = 0.381966011250105;

        /// <summary>Minmimum estimate using golden section a &lt; b &lt; c.</summary>
        /// <param name="a">First input.</param>
        /// <param name="b">Middle input.</param>
        /// <param name="c">Third input.</param>
        /// <returns>Golden section of the three inputs.</returns>
        public static double Minimum_GoldenSection(double a, double b, double c)
            => b - a >= c - b ? b + (a - b) * GOLD : b + (c - b) * GOLD;

        /// <summary>Minmimum estimate using factor section a &lt; b &lt; c.</summary>
        /// <param name="a">First input.</param>
        /// <param name="b">Middle input.</param>
        /// <param name="c">Third input.</param>
        /// <param name="factor">The factor.</param>
        /// <returns>Factor section of the three inputs.</returns>
        public static double Minimum_FactorSection(double a, double b, double c, double factor)
            => b - a >= c - b ? b + (a - b) * factor : b + (c - b) * factor;

        /// <summary>
        /// Minimum estmate using quadratic interpolation, falling back to golden section.
        /// </summary>
        /// <param name="a">First function input.</param>
        /// <param name="fa">First function output.</param>
        /// <param name="b">Second function input.</param>
        /// <param name="fb">Second function output.</param>
        /// <param name="c">Third function input.</param>
        /// <param name="fc">Third function output.</param>
        /// <returns>The minimum estimate.</returns>
        public static double Minimum_Quadratic(double a, double fa, double b, double fb, double c, double fc)
        {
            var x = b - 0.5 * (Sqr(b - a) * (fb - fc) - Sqr(b - c) * (fb - fa)) / ((b - a) * (fb - fc) - (b - c) * (fb - fa));
            return double.IsNaN(x) ? Minimum_GoldenSection(a, b, c) : x;
        }

        /// <summary>
        /// Minimum estmate between a and c using cubic interpolation, falling back to quadratic then golden interpolation a &lt; b &lt; c.
        /// See <see href="https://en.wikipedia.org/wiki/Lagrange_polynomial">Lagrange polynomial</see> and
        /// <see href="https://www.themathdoctors.org/max-and-min-of-a-cubic-without-calculus/">Cubic max and min</see>.
        /// </summary>
        /// <param name="a">First function input.</param>
        /// <param name="fa">First function output.</param>
        /// <param name="b">Second function input.</param>
        /// <param name="fb">Second function output.</param>
        /// <param name="c">Third function input.</param>
        /// <param name="fc">Third function output.</param>
        /// <param name="d">Fourth function input.</param>
        /// <param name="fd">Fourth function output.</param>
        /// <returns>The cubic estimate between a and c.</returns>
        public static double Minimum_Cubic(double a, double fa, double b, double fb, double c, double fc, double d, double fd)
        {
            // https://en.wikipedia.org/wiki/Lagrange_polynomial
            var a1 = fa * (b * c + b * d + c * d) / ((a - b) * (a - c) * (a - d)) + fb * (a * c + a * d + c * d) / ((b - a) * (b - c) * (b - d)) + fc * (a * b + a * d + b * d) / ((c - a) * (c - b) * (c - d)) + fd * (a * b + a * c + b * c) / ((d - a) * (d - b) * (d - c));
            var a2 = -fa * (b + c + d) / ((a - b) * (a - c) * (a - d)) - fb * (a + c + d) / ((b - a) * (b - c) * (b - d)) - fc * (a + b + d) / ((c - a) * (c - b) * (c - d)) - fd * (a + b + c) / ((d - a) * (d - b) * (d - c));
            var a3 = fa / ((a - b) * (a - c) * (a - d)) + fb / ((b - a) * (b - c) * (b - d)) + fc / ((c - a) * (c - b) * (c - d)) + fd / ((d - a) * (d - b) * (d - c));

            // https://www.themathdoctors.org/max-and-min-of-a-cubic-without-calculus/
            var r = Math.Sqrt(a2 * a2 - 3 * a3 * a1);
            var x = (r - a2) / a3 / 3;
            if (a < x && x < c) return x;
            x = (-r - a2) / a3 / 3;
            if (a < x && x < c) return x;
            return Minimum_Quadratic(a, fa, b, fb, c, fc);
        }

        static double Tol_Not_Too_Close(double atol, double rtol, double a, double b, double c, double x)
        {
            var tol = Tol(atol, rtol, x);
            if (x <= b)
            {
                if (b - a < tol) return b + tol;
                if (b - a < 2 * tol) return (a + b) * 0.5;
                if (x < a + tol) return a + tol;
                if (x > b - tol) return b - tol;
            }
            else
            {
                if (c - b < tol) return b - tol;
                if (c - b < 2 * tol) return (b + c) * 0.5;
                if (x < b + tol) return b + tol;
                if (x > c - tol) return c - tol;
            }
            return x;
        }

        static void Minimum_Bracket_Fa(double atol, double rtol, Func<double, double> f, ref double a, ref double fa, ref double b, out double fb,
            out double c, out double fc, out double d, out double fd, double? lower, double? upper, CancellationToken cancellationToken)
        {
            if (lower is not null && upper is not null)
            {
                var g = f;
                f = x => x < lower.Value ? double.PositiveInfinity
                       : x > upper.Value ? double.PositiveInfinity
                       : g(x);
            }
            else if (lower is not null)
            {
                var g = f;
                f = x => x < lower.Value ? double.PositiveInfinity : g(x);
            }
            else if (upper is not null)
            {
                var g = f;
                f = (double x) => x > upper.Value ? double.PositiveInfinity : g(x);
            }
            fb = f(b);
            if (fa < fb)
            {
                c = b; fc = fb;
                b = a; fb = fa;
                a = b + (b - c);
                fa = f(a);
            }
            else
            {
                c = b + (b - a);
                fc = f(c);
            }
            d = double.PositiveInfinity;
            fd = 0;
            while (!Minimum_Is_Bracketed(fa, fb, fc) && !cancellationToken.IsCancellationRequested)
            {
                var x = Minimum_Quadratic(a, fa, b, fb, c, fc);
                if (fa <= fb)
                {
                    if (x > a + Tol(atol, rtol, a) && x < b - Tol(atol, rtol, b))
                    {
                        var fx = f(x);
                        d = c; fd = fc;
                        c = b; fc = fb;
                        b = x; fb = fx;
                    }
                    else
                    {
                        x = x < a - Tol(atol, rtol, a) ? Math.Max(x, a - (c - a) * 500) : a - (c - a);
                        var fx = f(x);
                        d = c; fd = fc;
                        c = b; fc = fb;
                        b = a; fb = fa;
                        a = x; fa = fx;
                    }
                }
                else
                {
                    if (x < c - Tol(atol, rtol, c) && a > b + Tol(atol, rtol, b))
                    {
                        var fx = f(x);
                        d = a; fd = fa;
                        a = b; fa = fb;
                        b = x; fb = fx;
                    }
                    else
                    {
                        x = x > c + Tol(atol, rtol, c) ? Math.Min(x, c + (c - a) * 500) : c + (c - a);
                        var fx = f(x);
                        d = a; fd = fa;
                        a = b; fa = fb;
                        b = c; fb = fc;
                        c = x; fc = fx;
                    }
                }
            }
            if (lower is not null && a < lower.Value)
            {
                a = lower.Value;
                fa = f(a);
            }
            else if (upper is not null && c > upper.Value)
            {
                c = upper.Value;
                fc = f(c);
            }
        }


        /// <summary>
        /// Brackets a minimum for f given two starting points a and b so that f(a) &lt;= f(b) &gt;= f(c).
        /// </summary>
        /// <param name="atol">The absolute tolerance of the minimum position required.</param>
        /// <param name="rtol">The relative tolerance of the minimum position required.</param>
        /// <param name="f">The function to bracket the minimum of.</param>
        /// <param name="a">First input.</param>
        /// <param name="fa">f(a) output.</param>
        /// <param name="b">Second input.</param>
        /// <param name="fb">f(b) output.</param>
        /// <param name="c">c output.</param>
        /// <param name="fc">f(c) output.</param>
        /// <param name="d">Additonal outer point d &lt; a or d &gt; c. Can be infinity if no more than three function evaluations are needed.</param>
        /// <param name="fd">f(d) output. Can be zero if no more than three function evaluations are needed.</param>
        /// <param name="lower"></param>
        /// <param name="upper"></param>
        /// <param name="cancellationToken"></param>
        public static void Minimum_Bracket(double atol, double rtol, Func<double, double> f, ref double a, out double fa, ref double b, out double fb,
            out double c, out double fc, out double d, out double fd, double? lower = null, double? upper = null, CancellationToken cancellationToken = default)
        {
            fa = f(a);
            Minimum_Bracket_Fa(atol, rtol, f, ref a, ref fa, ref b, out fb, out c, out fc, out d, out fd, lower, upper, cancellationToken);
        }

        /// <summary>
        /// Finds the minimum of f accurate to tol = atol + rtol * x for bracketed inputs a &lt; b &lt; c and f(a) &lt;= f(b) &gt;= f(c).
        /// </summary>
        /// <param name="atol">The absolute tolerance of the minimum position required.</param>
        /// <param name="rtol">The relative tolerance of the minimum position required.</param>
        /// <param name="f">The function to find the minimum of.</param>
        /// <param name="a">The first function input.</param>
        /// <param name="fa">f(a) input.</param>
        /// <param name="b">The second funtion input and also the minimum.</param>
        /// <param name="fb">f(b) input.</param>
        /// <param name="c">The third function input.</param>
        /// <param name="fc">f(c) input.</param>
        /// <param name="d">Additonal outer point d &lt; a or d &gt; c.</param>
        /// <param name="fd">f(d) input.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>The minimum input point accurate to tol = atol + rtol * x.</returns>
        public static double Minimum_Bracketed(double atol, double rtol, Func<double, double> f,
            double a, double fa, double b, double fb, double c, double fc, double d = double.PositiveInfinity, double fd = 0,
            CancellationToken cancellationToken = default)
        {
            int level = 0;
            while (Tol_Average_Not_Within(atol, rtol, a, c) && !cancellationToken.IsCancellationRequested)
            {
                var x = Tol_Average_Within_2(atol, rtol, a, c) ? Minimum_BiSection(atol, rtol, a, b, c)
                      : level == 0 ? Tol_Not_Too_Close(atol, rtol, a, b, c, Minimum_Cubic(a, fa, b, fb, c, fc, d, fd))
                      : level == 1 ? Tol_Not_Too_Close(atol, rtol, a, b, c, Minimum_Quadratic(a, fa, b, fb, c, fc))
                      : Minimum_FactorSection(a, b, c, 0.1);
                var fx = f(x);
                const double levelFactor = 1.0 / 3;
                if (x < b)
                {
                    if (Minimum_Is_Bracketed(fa, fx, fb))
                    {
                        level = c - b < levelFactor * (c - a) ? level + 1 : 0;
                        if (d > c || a - d > c - b) { d = c; fd = fc; }
                        c = b; b = x;
                        fc = fb; fb = fx;
                    }
                    else if (Minimum_Is_Bracketed(fx, fb, fc) || fa > fc)
                    {
                        level = x - a < levelFactor * (c - a) ? level + 1 : 0;
                        if (d < a || d - c > x - a) { d = a; fd = fa; }
                        a = x;
                        fa = fx;
                    }
                    else
                    {
                        level = c - b < levelFactor * (c - a) ? level + 1 : 0;
                        if (d > c || a - d > c - b) { d = c; fd = fc; }
                        c = b; b = x;
                        fc = fb; fb = fx;
                    }
                }
                else
                {
                    if (Minimum_Is_Bracketed(fb, fx, fc))
                    {
                        level = b - a < levelFactor * (c - a) ? level + 1 : 0;
                        if (d < a || d - c > b - a) { d = c; fd = fc; }
                        a = b; b = x;
                        fa = fb; fb = fx;
                    }
                    else if (Minimum_Is_Bracketed(fa, fb, fx) || fc > fa)
                    {
                        level = c - x < levelFactor * (c - a) ? level + 1 : 0;
                        if (d > c || a - d > c - x) { d = c; fd = fc; }
                        c = x;
                        fc = fx;
                    }
                    else
                    {
                        level = b - a < levelFactor * (c - a) ? level + 1 : 0;
                        if (d < a || d - c > b - a) { d = c; fd = fc; }
                        a = b; b = x;
                        fa = fb; fb = fx;
                    }
                }
            }
            return Bisect(a, c);
        }

        /// <summary>Finds the minimum of f accurate to tol = atol + rtol * x given two starting function inputs.</summary>
        /// <param name="atol">The absolute tolerance of the minimum position required.</param>
        /// <param name="rtol">The relative tolerance of the minimum position required.</param>
        /// <param name="f">The function to find the minimum of.</param>
        /// <param name="a">The first starting input.</param>
        /// <param name="b">The second starting input.</param>
        /// <returns>The minimum input point accurate to tol = atol + rtol * x.</returns>
        public static double Minimum(double atol, double rtol, Func<double, double> f, double a, double b)
        {
            Minimum_Bracket(atol, rtol, f, ref a, out var fa, ref b, out var fb, out var c, out var fc, out var d, out var fd);
            return Minimum_Bracketed(atol, rtol, f, a, fa, b, fb, c, fc, d, fd);
        }

        static double Minimum_Fa(double atol, double rtol, Func<double, double> f, double a, double fa, double b, double? lower, double? upper,
            CancellationToken cancellationToken)
        {
            if (lower is not null && b < lower.Value) b = lower.Value;
            else if (upper is not null && b > upper.Value) b = upper.Value;
            Minimum_Bracket_Fa(atol, rtol, f, ref a, ref fa, ref b, out var fb, out var c, out var fc, out var d, out var fd, lower, upper, cancellationToken);
            return Minimum_Bracketed(atol, rtol, f, a, fa, b, fb, c, fc, d, fd, cancellationToken);
        }

        /// <summary>Finds the minimum of f accurate to tol = atol + rtol * x given a starting function input.</summary>
        /// <param name="atol">The absolute tolerance of the minimum position required.</param>
        /// <param name="rtol">The relative tolerance of the minimum position required.</param>
        /// <param name="f">The function to find the minimum of.</param>
        /// <param name="a">The starting input.</param>
        /// <returns>The minimum input point accurate to tol = atol + rtol * x.</returns>
        public static double Minimum(double atol, double rtol, Func<double, double> f, double a)
        {
            var b = a + Tol(atol, rtol, a) * 1000;
            Minimum_Bracket(atol, rtol, f, ref a, out var fa, ref b, out var fb, out var c, out var fc, out var d, out var fd);
            return Minimum_Bracketed(atol, rtol, f, a, fa, b, fb, c, fc, d, fd);
        }

        /// <summary>
        /// Finds the minimum of f using Brent accurate to tol = atol + rtol * x for bracketed inputs a &lt; b &lt; c and f(a) &lt;= f(b) &gt;= f(c).
        /// </summary>
        /// <param name="atol">The absolute tolerance of the minimum position required.</param>
        /// <param name="rtol">The relative tolerance of the minimum position required.</param>
        /// <param name="f">The function to find the minimum of.</param>
        /// <param name="a">The first function input.</param>
        /// <param name="b">The second funtion input and also the minimum.</param>
        /// <param name="c">The third function input.</param>
        /// <returns>The minimum input point accurate to tol = atol + rtol * x.</returns>
        public static double Minimum_Brent(double atol, double rtol, Func<double, double> f, double a, double b, double c)
        {
            static double SIGN(double v, double d) => d >= 0 ? v : -v;
            const double CGOLD = 0.3819660;
            double d = 0.0, etemp, fu, fv, fw, fx;
            double p, q, r, tol1, tol2, u, v, w, x, xm;
            double e = 0.0;
            x = w = v = b;
            fw = fv = fx = f(b);
            for (int iter = 0; iter < 100; iter++)
            {
                xm = 0.5 * (a + c);
                tol1 = Tol(atol, rtol, xm);
                tol2 = 2.0 * tol1;
                if (c - a < tol2) return xm;
                if (Math.Abs(e) > tol1 && c - a > tol1 * 4)
                {
                    r = (x - w) * (fx - fv);
                    q = (x - v) * (fx - fw);
                    p = (x - v) * q - (w - w) * r;
                    q = 2.0 * (q - r);
                    if (q > 0.0) p = -p;
                    q = Math.Abs(q);
                    etemp = e;
                    e = d;
                    if (Math.Abs(p) >= Math.Abs(0.5 * q * etemp) || p <= q * (a - x)
                            || p >= q * (c - x))
                    {
                        d = CGOLD * (e = x >= xm ? a - x : c - x);
                        u = x + d;
                    }
                    else
                    {
                        d = p / q;
                        u = x + d;
                        if (u - a < tol2 || c - u < tol2)
                            d = SIGN(tol1, xm - x);
                        u = Math.Abs(d) >= tol1 ? x + d : x + SIGN(tol1, d);
                    }
                }
                else
                {
                    d = CGOLD * (e = x >= xm ? a - x : c - x);
                    u = x + d;
                }
                fu = f(u);
                if (fu <= fx)
                {
                    if (u >= x) a = x; else c = x;
                    v = w; w = x; x = u;
                    fv = fw; fw = fx; fx = fu;
                }
                else
                {
                    if (u <= x) a = u; else c = u;
                    if (fu <= fw || w == x)
                    {
                        v = w; w = u;
                        fv = fw; fw = fu;
                    }
                    else if (fu <= fv || v == x || v == w)
                    {
                        v = u;
                        fv = fu;
                    }
                }
            }
            throw new Exception("Too many iterations in brent");
        }

        static void Minimum_LineSearch(double atol, double rtol, Func<double[], double> f, vector x, double fx, vector p, double dx, vector x2, out double fx2,
            double[]? lower, double[]? upper, CancellationToken cancellationToken)
        {
            var tol = Tol(atol, rtol, Vector.Nrm2(x));
            if (dx > tol * 1e5) { atol *= 1e3; rtol *= 1e3; }
            var norm = Vector.Nrm2(p);
            double? lowera = null;
            double? uppera = null;
            if (lower is not null)
            {
                for (int i = 0; i < lower.Length; i++)
                {
                    if (p[i] != 0.0)
                    {
                        var aa = (lower[i] - x[i]) / p[i] * norm;
                        if (p[i] > 0.0)
                        {
                            if (lowera is null || lowera.Value < aa) lowera = aa;
                        }
                        else
                        {
                            if (uppera is null || uppera.Value > aa) uppera = aa;
                        }
                    }
                }
            }
            if (upper is not null)
            {
                for (int i = 0; i < upper.Length; i++)
                {
                    if (p[i] != 0.0)
                    {
                        var aa = (upper[i] - x[i]) / p[i] * norm;
                        if (p[i] > 0.0)
                        {
                            if (uppera is null || uppera.Value > aa) uppera = aa;
                        }
                        else
                        {
                            if (lowera is null || lowera.Value < aa) lowera = aa;
                        }
                    }
                }
            }
            var a = Minimum_Fa(atol, rtol, a =>
            {
                x2.Set(x + a / norm * p);
                return f(x2.Array);
            }, 0, fx, Math.Max(dx, tol) * 0.25, lowera, uppera, cancellationToken);
            x2.Set(x + a / norm * p);
            fx2 = f(x2.Array);
            if(fx2 > fx)
            {
                Vector.Copy(x, x2);
                fx2 = fx;
            }
        }

        static bool WithinTol_CalcNegGrad(double atol, double rtol, Func<double[], double> f, double[] x, double fx, double[] df,
            ref bool gradientDescent, double[]? lower, double[]? upper, Action<double[], double[]>? fdf)
        {
            int nonMinimum = -1;
            double dfi_tol = 0;
            for (int i = 0; i < x.Length; i++)
            {
                var x_i = x[i];
                var tol = Tol(atol, rtol, x_i);
                x[i] = x_i - tol;
                if (lower is null || x[i] >= lower[i])
                {
                    dfi_tol = f(x);
                    if (dfi_tol < fx)
                    {
                        x[i] = x_i;
                        dfi_tol = (dfi_tol - fx) / tol;
                        nonMinimum = i;
                        break;
                    }
                }
                x[i] = x_i + tol;
                if (upper is null || x[i] <= upper[i])
                {
                    dfi_tol = f(x);
                    if (dfi_tol < fx)
                    {
                        x[i] = x_i;
                        dfi_tol = (fx - dfi_tol) / tol;
                        nonMinimum = i;
                        break;
                    }
                }
                x[i] = x_i;
            }
            if (nonMinimum == -1) return true;
            if (!gradientDescent)
            {
                if (fdf is null)
                {
                    bool allZero = true;
                    for (int i = 0; i < x.Length; i++)
                    {
                        var x_i = x[i];
                        var dx = Tol(atol, rtol, x_i) * 0.05;
                        var x_i_d = x_i + dx;
                        if (upper is not null && x_i_d > upper[i])
                        {
                            x_i_d = x_i - dx;
                        }
                        x[i] = x_i_d;
                        var df_i = (fx - f(x)) / (x_i_d - x_i);
                        df[i] = df_i;
                        if (df_i != 0) allZero = false;
                        x[i] = x_i;
                    }
                    if (allZero) gradientDescent = true;
                }
                else
                {
                    fdf(x, df);
                    for (int i = 0; i < x.Length; i++)
                        df[i] = -df[i];
                }
            }
            if (gradientDescent)
            {
                if (fdf is null)
                {
                    for (int i = 0; i < x.Length; i++) df[i] = 0;
                    df[nonMinimum] = dfi_tol;
                    for (int i = nonMinimum + 1; i < x.Length; i++)
                    {
                        var x_i = x[i];
                        var tol = Tol(atol, rtol, x_i);
                        x[i] = x_i - tol;
                        if (lower is null || x[i] >= lower[i])
                        {
                            dfi_tol = f(x);
                            if (dfi_tol < fx || (upper is not null && x_i + tol > upper[i]))
                            {
                                x[i] = x_i;
                                df[i] = (dfi_tol - fx) / tol;
                                continue;
                            }
                        }
                        x[i] = x_i + tol;
                        if (upper is null || x[i] <= upper[i])
                        {
                            dfi_tol = f(x);
                            if (dfi_tol < fx)
                                df[i] = (fx - dfi_tol) / tol;
                        }
                        x[i] = x_i;
                    }
                }
                else
                {
                    fdf(x, df);
                    for (int i = 0; i < x.Length; i++)
                        df[i] = -df[i];
                }
            }
            return false;
        }

        /// <summary>Minimum grid search iteration results.</summary>
        public class MinimumIteration
        {
            internal MinimumIteration(double[] xmin, double fmin, TimeSpan timeSpan, TimeSpan nextTimeSpan)
            {
                Xmin = xmin;
                Fmin = fmin;
                TimeSpan = timeSpan;
                NextTimeSpan = nextTimeSpan;
            }
            /// <summary>The x values of the global minimum so far over all minimum iterations.</summary>
            public double[] Xmin { get; }
            /// <summary>The f(x) of the global minimum so far over all minimum iterations.</summary>
            public double Fmin { get; }
            /// <summary>The elapsed time taken for this minimum iteration.</summary>
            public TimeSpan TimeSpan { get; }
            /// <summary>The estimated time taken for the next minimum iteration.</summary>
            public TimeSpan NextTimeSpan { get; }
        }

        /// <summary>
        /// Finds the global minimum of n dimensional function f using <see href="https://en.wikipedia.org/wiki/Broyden%E2%80%93Fletcher%E2%80%93Goldfarb%E2%80%93Shanno_algorithm">BFGS</see>
        /// in a sequence of parallel grid BFGS searches ever reducing the spacing between prior searches. Accurate to tol x_i = atol + rtol * x_i.
        /// </summary>
        /// <param name="atol">The absolute tolerance of the minimum position required.</param>
        /// <param name="rtol">The relative tolerance of the minimum position required.</param>
        /// <param name="f">The n dimensional function to find the minimum of.</param>
        /// <param name="lower">The lower x boundary values (optional).</param>
        /// <param name="upper">The upper x boundary values (optional).</param>
        /// <param name="df">The derivative function (optional).</param>
        /// <param name="cancellationToken">Cancellation token (optional).</param>
        /// <returns>A sequence of grid search calculations with ever reducing spacing.</returns>
        public static IEnumerable<MinimumIteration> Minimum_Global_Enumerable(double atol, double rtol, Func<double[], double> f, double[] lower, double[] upper,
            Action<double[], double[]>? df = null, CancellationToken cancellationToken = default)
        {
            var xmin = new double[lower.Length];
            var fmin = double.MaxValue;
            var stopwatch = new Stopwatch();
            int n = 1;
            while (!cancellationToken.IsCancellationRequested)
            {
                stopwatch.Restart();
                Parallel.For(0, (int)Math.Pow(n, xmin.Length), () => ((double[])xmin.Clone(), fmin, new double[xmin.Length]),
                (index, _, lmin) =>
                {
                    if (cancellationToken.IsCancellationRequested) return lmin;
                    var x = lmin.Item3;
                    for (int i = 0; i < x.Length; i++)
                    {
                        index = Math.DivRem(index, n, out int r);
                        x[i] = lower[i] + (upper[i] - lower[i]) * (0.5 + r) / n;
                    }
                    var fmin = Minimum(atol, rtol, f, x, lower, upper, df, cancellationToken);
                    return fmin < lmin.fmin ? (x, fmin, lmin.Item1) : lmin;
                },
                x =>
                {
                    lock (xmin)
                    {
                        if (x.fmin < fmin)
                        {
                            fmin = x.fmin;
                            x.Item1.CopyTo(xmin, 0);
                        }
                    }
                });
                var timeSpan = stopwatch.Elapsed;
                var nextTicks = cancellationToken.IsCancellationRequested ? 0
                    : timeSpan.Ticks
                        / Math.Ceiling(Math.Pow(n, xmin.Length) / Environment.ProcessorCount)
                        * Math.Ceiling(Math.Pow(n * 2, xmin.Length) / Environment.ProcessorCount);
                yield return new((double[])xmin.Clone(), fmin, timeSpan, new((long)nextTicks));
                n *= 2;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="atol"></param>
        /// <param name="rtol"></param>
        /// <param name="f"></param>
        /// <param name="lower"></param>
        /// <param name="upper"></param>
        /// <param name="time"></param>
        /// <param name="same"></param>
        /// <param name="fatol"></param>
        /// <param name="frtol"></param>
        /// <param name="df"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static List<MinimumIteration> Minimum_Global(double atol, double rtol, Func<double[], double> f, double[] lower, double[] upper,
            int same = 0, double fatol = 0.0, double frtol = 0.0, TimeSpan time = default,
            Action<double[], double[]>? df = null, CancellationToken cancellationToken = default)
        {
            var cts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
            if (time != default) _ = Task.Delay(time, cancellationToken).ContinueWith(_ => cts.Cancel(), cancellationToken);
            var iterations = new List<MinimumIteration>();
            int nSame = 1;
            double pF = double.PositiveInfinity;
            foreach (var i in Minimum_Global_Enumerable(atol, rtol, f, lower, upper, df, cts.Token))
            {
                iterations.Add(i);
                if (Math.Abs(i.Fmin - pF) < Tol(fatol, frtol, i.Fmin))
                {
                    if (++nSame == same) return iterations;
                }
                else nSame = 1;
                pF = i.Fmin;
            }
            return iterations;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="atol"></param>
        /// <param name="rtol"></param>
        /// <param name="f"></param>
        /// <param name="lower"></param>
        /// <param name="upper"></param>
        /// <param name="time"></param>
        /// <param name="df"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static List<MinimumIteration> Minimum_Global(double atol, double rtol, Func<double[], double> f, double[] lower, double[] upper,
            TimeSpan time = default, Action<double[], double[]>? df = null, CancellationToken cancellationToken = default)
            => Minimum_Global(atol, rtol, f, lower, upper, time: time, df: df, cancellationToken: cancellationToken);

        /// <summary>
        /// Finds the global minimum of n dimensional function f using <see href="https://en.wikipedia.org/wiki/Broyden%E2%80%93Fletcher%E2%80%93Goldfarb%E2%80%93Shanno_algorithm">BFGS</see>
        /// in a sequence of parallel grid BFGS searches ever reducing the spacing between prior searches. Accurate to tol x_i = atol + rtol * x_i.
        /// </summary>
        /// <param name="atol">The absolute tolerance of the minimum position required.</param>
        /// <param name="rtol">The relative tolerance of the minimum position required.</param>
        /// <param name="f">The n dimensional function to find the minimum of.</param>
        /// <param name="lower">The lower x boundary values (optional).</param>
        /// <param name="upper">The upper x boundary values (optional).</param>
        /// <param name="df">The derivative function (optional).</param>
        /// <param name="cancellationToken">Cancellation token (optional).</param>
        /// <returns>A sequence of grid search calculations with ever reducing spacing.</returns>
        public static IEnumerable<Func<Task<MinimumIteration>>> Minimum_Global_EnumerableAsync(double atol, double rtol, Func<double[], double> f, double[] lower, double[] upper,
            Action<double[], double[]>? df = null, CancellationToken cancellationToken = default)
        {
            var xmin = new double[lower.Length];
            var fmin = double.MaxValue;
            int n = 1;
            while (!cancellationToken.IsCancellationRequested)
            {
                yield return () => Task.Run(async () =>
                {
                    var stopwatch = Stopwatch.StartNew();
                    var points = (int)Math.Pow(n, xmin.Length);
                    var threads = Environment.ProcessorCount;
                    var tasks = new Task[threads];
                    while (threads-- > 0)
                        tasks[threads] = Task.Run(() =>
                        {
                            var x = new double[xmin.Length];
                            var txmin = new double[xmin.Length];
                            var tfmin = double.MaxValue;
                            while (true)
                            {
                                var index = Interlocked.Decrement(ref points);
                                if (index < 0 || cancellationToken.IsCancellationRequested) break;
                                for (int i = 0; i < x.Length; i++)
                                {
                                    index = Math.DivRem(index, n, out int r);
                                    x[i] = lower[i] + (upper[i] - lower[i]) * (0.5 + r) / n;
                                }
                                var fmin = Minimum(atol, rtol, f, x, lower, upper, df, cancellationToken);
                                if (fmin < tfmin)
                                {
                                    tfmin = fmin;
                                    (txmin, x) = (x, txmin);
                                }
                            }
                            lock (f)
                            {
                                if (tfmin < fmin)
                                {
                                    fmin = tfmin;
                                    xmin = txmin;
                                }
                            }
                        });
                    await Task.WhenAll(tasks);
                    var timeSpan = stopwatch.Elapsed;

                    var nextTicks = cancellationToken.IsCancellationRequested ? 0
                        : timeSpan.Ticks
                            / Math.Ceiling(Math.Pow(n, xmin.Length) / Environment.ProcessorCount)
                            * Math.Ceiling(Math.Pow(n * 2, xmin.Length) / Environment.ProcessorCount);
                    return new MinimumIteration((double[])xmin.Clone(), fmin, timeSpan, new((long)nextTicks));
                });
                n *= 2;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="atol"></param>
        /// <param name="rtol"></param>
        /// <param name="f"></param>
        /// <param name="lower"></param>
        /// <param name="upper"></param>
        /// <param name="time"></param>
        /// <param name="same"></param>
        /// <param name="fatol"></param>
        /// <param name="frtol"></param>
        /// <param name="df"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<List<MinimumIteration>> Minimum_GlobalAsync(double atol, double rtol, Func<double[], double> f, double[] lower, double[] upper,
            int same = 0, double fatol = 0.0, double frtol = 0.0, TimeSpan time = default,
            Action<double[], double[]>? df = null, CancellationToken cancellationToken = default)
        {
            var cts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
            if(time != default) _ = Task.Delay(time, cancellationToken).ContinueWith(_ => cts.Cancel(), cancellationToken);
            var iterations = new List<MinimumIteration>();
            int nSame = 1;
            double pF = double.PositiveInfinity;
            foreach (var iteration in Minimum_Global_EnumerableAsync(atol, rtol, f, lower, upper, df, cts.Token))
            {
                var i = await iteration();
                iterations.Add(i);
                if (Math.Abs(i.Fmin - pF) < Tol(fatol, frtol, i.Fmin))
                {
                    if (++nSame == same) return iterations;
                }
                else nSame = 1;
                pF = i.Fmin;
            }
            return iterations;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="atol"></param>
        /// <param name="rtol"></param>
        /// <param name="f"></param>
        /// <param name="lower"></param>
        /// <param name="upper"></param>
        /// <param name="time"></param>
        /// <param name="df"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static Task<List<MinimumIteration>> Minimum_GlobalAsync(double atol, double rtol, Func<double[], double> f, double[] lower, double[] upper,
            TimeSpan time = default, Action<double[], double[]>? df = null, CancellationToken cancellationToken = default)
            => Minimum_GlobalAsync(atol, rtol, f, lower, upper, time: time, df: df, cancellationToken: cancellationToken);

        /// <summary>
        /// Finds the minimum of n dimensional function f using <see href="https://en.wikipedia.org/wiki/Broyden%E2%80%93Fletcher%E2%80%93Goldfarb%E2%80%93Shanno_algorithm">BFGS</see> accurate to tol x_i = atol + rtol * x_i.
        /// </summary>
        /// <param name="atol">The absolute tolerance of the minimum position required.</param>
        /// <param name="rtol">The relative tolerance of the minimum position required.</param>
        /// <param name="f">The n dimensional function to find the minimum of.</param>
        /// <param name="x">The starting position and the minimum position found.</param>
        /// <param name="lower">The lower x boundary values (optional).</param>
        /// <param name="upper">The upper x boundary values (optional).</param>
        /// <param name="df">The derivative function (optional).</param>
        /// <param name="cancellationToken">Cancellation token (optional).</param>
        /// <returns>f(x) at the minimum position found.</returns>
        public static double Minimum(double atol, double rtol, Func<double[], double> f, double[] x, double[]? lower = null, double[]? upper = null,
            Action<double[], double[]>? df = null, CancellationToken cancellationToken = default)
        {
            using vector df1 = new(x.Length);
            bool gradientDescent = false;
            var fx = f(x);
            if (WithinTol_CalcNegGrad(atol, rtol, f, x, fx, df1.Array, ref gradientDescent, lower, upper, df)) return fx;
            vector x2 = new(x.Length, x);
            x2.ReuseArray(); // x2 finalized could cause x to be put in the pool
            using vector x1 = Vector.Copy(x2);
            using vector p = Vector.Copy(df1);
            Minimum_LineSearch(atol, rtol, f, x1, fx, p, Tol(atol, rtol, Vector.Nrm2(x1)) * 1000, x2, out fx, lower, upper, cancellationToken);
            using vector df2 = new(x.Length);
            if (WithinTol_CalcNegGrad(atol, rtol, f, x2.Array, fx, df2.Array, ref gradientDescent, lower, upper, df)) return fx;
            vector s = x1, y = df1; // Alias for the formula below so no need to use using
            s.Set(x2 - x1);
            double dx = Vector.Nrm2(s);
            double dxPrev = double.MaxValue;
            y.Set(df1 - df2);
            double sTy = s.T * y;
            // H = I + (sTy + y.T * y) / sTy / sTy * s * s.T - (y * s.T + s * y.T) / sTy;
            using matrix H = Matrix.Identity(x.Length);
            Matrix.Symmetric_Rank_k_Update((sTy + y.T * y) / sTy / sTy, s, 1, H);
            Matrix.Symmetric_Rank_2k_Update(-1 / sTy, y, s, 1, H);
            using vector Hy = new(x.Length);
            while (!cancellationToken.IsCancellationRequested)
            {
                Vector.Copy(x2, x1);
                Vector.Copy(df2, df1);
                Matrix.Symmetric_Multiply_Update(H, df1, p); // p = H * df1
                Minimum_LineSearch(atol, rtol, f, x1, fx, p, dx, x2, out fx, lower, upper, cancellationToken);
                if (WithinTol_CalcNegGrad(atol, rtol, f, x2.Array, fx, df2.Array, ref gradientDescent, lower, upper, df)) return fx;
                if (gradientDescent) break;
                s.Set(x2 - x1);
                dxPrev = dx;
                dx = Vector.Nrm2(s);
                var tol = Tol(atol, rtol, Vector.Nrm2(x2));
                if (dx < tol && dxPrev < tol)
                {
                    dxPrev = double.MinValue;
                    break;
                }
                else
                {
                    y.Set(df1 - df2);
                    sTy = s.T * y;
                    if (sTy == 0) break;
                }
                Matrix.Symmetric_Multiply_Update(H, y, Hy); // Hy = H * y
                //H = H + ((sTy + y.T * Hy) / sTy / sTy * s * s.T) - (Hy * s.T + s * Hy.T) / sTy;
                Matrix.Symmetric_Rank_k_Update((sTy + y.T * Hy) / sTy / sTy, s, 1, H);
                Matrix.Symmetric_Rank_2k_Update(-1 / sTy, Hy, s, 1, H);
            }
            while (!cancellationToken.IsCancellationRequested)
            {
                Vector.Copy(x2, x1);
                Minimum_LineSearch(atol, rtol, f, x1, fx, df2, dx, x2, out fx, lower, upper, cancellationToken);
                if (WithinTol_CalcNegGrad(atol, rtol, f, x2.Array, fx, df2.Array, ref gradientDescent, lower, upper, df)) return fx;
                s.Set(x2 - x1);
                dxPrev = dx;
                dx = Vector.Nrm2(s);
                var tol = Tol(atol, rtol, Vector.Nrm2(x2));
                if (dx < tol && dxPrev < tol) return fx;
            }
            return fx;
        }

        /// <summary>
        /// Finds the minimum of n dimensional function f using <see href="https://en.wikipedia.org/wiki/Broyden%E2%80%93Fletcher%E2%80%93Goldfarb%E2%80%93Shanno_algorithm">BFGS</see> accurate to tol x_i = atol + rtol * x_i.
        /// </summary>
        /// <param name="atol">The absolute tolerance of the minimum position required.</param>
        /// <param name="rtol">The relative tolerance of the minimum position required.</param>
        /// <param name="f">The n dimensional function to find the minimum of.</param>
        /// <param name="x0">The starting position and the minimum position found.</param>
        /// <param name="x1">The starting position and the minimum position found.</param>
        /// <returns>f(x) at the minimum position found.</returns>
        public static double Minimum(double atol, double rtol, Func<double, double, double> f, ref double x0, ref double x1)
        {
            var x = new[] { x0, x1 };
            var fx = Minimum(atol, rtol, x => f(x[0], x[1]), x);
            x0 = x[0]; x1 = x[1];
            return fx;
        }

        /// <summary>
        /// Finds the minimum of n dimensional function f using <see href="https://en.wikipedia.org/wiki/Broyden%E2%80%93Fletcher%E2%80%93Goldfarb%E2%80%93Shanno_algorithm">BFGS</see> accurate to tol x_i = atol + rtol * x_i.
        /// </summary>
        /// <param name="atol">The absolute tolerance of the minimum position required.</param>
        /// <param name="rtol">The relative tolerance of the minimum position required.</param>
        /// <param name="f">The n dimensional function to find the minimum of.</param>
        /// <param name="x0">The starting position and the minimum position found.</param>
        /// <param name="x1">The starting position and the minimum position found.</param>
        /// <param name="x2">The starting position and the minimum position found.</param>
        /// <returns>f(x) at the minimum position found.</returns>
        public static double Minimum(double atol, double rtol, Func<double, double, double, double> f, ref double x0, ref double x1, ref double x2)
        {
            var x = new[] { x0, x1, x2 };
            var fx = Minimum(atol, rtol, x => f(x[0], x[1], x[2]), x);
            x0 = x[0]; x1 = x[1]; x2 = x[2];
            return fx;
        }

        /// <summary>
        /// Finds the minimum of n dimensional function f using <see href="https://en.wikipedia.org/wiki/Broyden%E2%80%93Fletcher%E2%80%93Goldfarb%E2%80%93Shanno_algorithm">BFGS</see> accurate to tol x_i = atol + rtol * x_i.
        /// </summary>
        /// <param name="atol">The absolute tolerance of the minimum position required.</param>
        /// <param name="rtol">The relative tolerance of the minimum position required.</param>
        /// <param name="f">The n dimensional function to find the minimum of.</param>
        /// <param name="x0">The starting position and the minimum position found.</param>
        /// <param name="x1">The starting position and the minimum position found.</param>
        /// <param name="x2">The starting position and the minimum position found.</param>
        /// <param name="x3">The starting position and the minimum position found.</param>
        /// <returns>f(x) at the minimum position found.</returns>
        public static double Minimum(double atol, double rtol, Func<double, double, double, double, double> f, ref double x0, ref double x1, ref double x2, ref double x3)
        {
            var x = new[] { x0, x1, x2, x3 };
            var fx = Minimum(atol, rtol, x => f(x[0], x[1], x[2], x[3]), x);
            x0 = x[0]; x1 = x[1]; x2 = x[2]; x3 = x[3];
            return fx;
        }

        /// <summary>
        /// Use ordinary least squares to fit a function y = f(p, x) to data.
        /// </summary>
        /// <param name="atol">The absolute tolerance of the minimum position required.</param>
        /// <param name="rtol">The relative tolerance of the minimum position required.</param>
        /// <param name="f">The function to fit y = f(p, x).</param>
        /// <param name="p">The starting parameters and the best fit parameters found.</param>
        /// <param name="x">The x data values.</param>
        /// <param name="y">The y data values.</param>
        /// <returns>least squares total at the best fit.</returns>
        public static double CurveFit_OLS(double atol, double rtol, Func<double[], double, double> f, double[] p, double[] x, double[] y)
        {
            return Minimum(atol, rtol, (double[] param) =>
            {
                var total = 0.0;
                for (int i = 0; i < x.Length; i++)
                    total += Sqr(f(param, x[i]) - y[i]);
                return total;
            }, p);
        }

        /// <summary>
        /// Use ordinary least squares to fit a function y = f(p, x) to data.
        /// </summary>
        /// <param name="atol">The absolute tolerance of the minimum position required.</param>
        /// <param name="rtol">The relative tolerance of the minimum position required.</param>
        /// <param name="f">The function to fit y = f(p, x).</param>
        /// <param name="p">The starting parameter and the best fit parameter found.</param>
        /// <param name="x">The x data values.</param>
        /// <param name="y">The y data values.</param>
        public static void CurveFit_OLS(double atol, double rtol, Func<double, double, double> f,
            ref double p, double[] x, double[] y)
        {
            p = Minimum(atol, rtol, p =>
            {
                var total = 0.0;
                for (int i = 0; i < x.Length; i++)
                    total += Sqr(f(p, x[i]) - y[i]);
                return total;
            }, p);
        }

        /// <summary>
        /// Use ordinary least squares to fit a function y = f(p0, p1, x) to data.
        /// </summary>
        /// <param name="atol">The absolute tolerance of the minimum position required.</param>
        /// <param name="rtol">The relative tolerance of the minimum position required.</param>
        /// <param name="f">The function to fit y = f(p0, p1, x).</param>
        /// <param name="p0">The starting parameters and the best fit parameters found.</param>
        /// <param name="p1">The starting parameters and the best fit parameters found.</param>
        /// <param name="x">The x data values.</param>
        /// <param name="y">The y data values.</param>
        /// <returns>least squares total at the best fit.</returns>
        public static double CurveFit_OLS(double atol, double rtol, Func<double, double, double, double> f,
            ref double p0, ref double p1, double[] x, double[] y)
        {
            var p = new[] { p0, p1 };
            var ols = CurveFit_OLS(atol, rtol, (p, x) => f(p[0], p[1], x), p, x, y);
            p0 = p[0]; p1 = p[1];
            return ols;
        }

        /// <summary>
        /// Use ordinary least squares to fit a function y = f(p0, p1, p2, x) to data.
        /// </summary>
        /// <param name="atol">The absolute tolerance of the minimum position required.</param>
        /// <param name="rtol">The relative tolerance of the minimum position required.</param>
        /// <param name="f">The function to fit y = f(p0, p1, p2, x).</param>
        /// <param name="p0">The starting parameters and the best fit parameters found.</param>
        /// <param name="p1">The starting parameters and the best fit parameters found.</param>
        /// <param name="p2">The starting parameters and the best fit parameters found.</param>
        /// <param name="x">The x data values.</param>
        /// <param name="y">The y data values.</param>
        /// <returns>least squares total at the best fit.</returns>
        public static double CurveFit_OLS(double atol, double rtol, Func<double, double, double, double, double> f,
            ref double p0, ref double p1, ref double p2, double[] x, double[] y)
        {
            var p = new[] { p0, p1, p2 };
            var ols = CurveFit_OLS(atol, rtol, (p, x) => f(p[0], p[1], p[2], x), p, x, y);
            p0 = p[0]; p1 = p[1]; p2 = p[2];
            return ols;
        }

        /// <summary>
        /// Use ordinary least squares to fit a function y = f(p0, p1, p2, p3, x) to data.
        /// </summary>
        /// <param name="atol">The absolute tolerance of the minimum position required.</param>
        /// <param name="rtol">The relative tolerance of the minimum position required.</param>
        /// <param name="f">The function to fit y = f(p0, p1, p2, p3, x).</param>
        /// <param name="p0">The starting parameters and the best fit parameters found.</param>
        /// <param name="p1">The starting parameters and the best fit parameters found.</param>
        /// <param name="p2">The starting parameters and the best fit parameters found.</param>
        /// <param name="p3">The starting parameters and the best fit parameters found.</param>
        /// <param name="x">The x data values.</param>
        /// <param name="y">The y data values.</param>
        /// <returns>least squares total at the best fit.</returns>
        public static double CurveFit_OLS(double atol, double rtol, Func<double, double, double, double, double, double> f,
            ref double p0, ref double p1, ref double p2, ref double p3, double[] x, double[] y)
        {
            var p = new[] { p0, p1, p2, p3 };
            var ols = CurveFit_OLS(atol, rtol, (p, x) => f(p[0], p[1], p[2], p[3], x), p, x, y);
            p0 = p[0]; p1 = p[1]; p2 = p[2]; p3 = p[3];
            return ols;
        }

        /// <summary>
        /// Use least absolute deviation to fit a function y = f(p, x) to data.
        /// </summary>
        /// <param name="atol">The absolute tolerance of the minimum position required.</param>
        /// <param name="rtol">The relative tolerance of the minimum position required.</param>
        /// <param name="f">The function to fit y = f(p, x).</param>
        /// <param name="p">The starting parameters and the best fit parameters found.</param>
        /// <param name="x">The x data values.</param>
        /// <param name="y">The y data values.</param>
        /// <returns>least absolute deviation at the best fit.</returns>
        public static double CurveFit_LAD(double atol, double rtol, Func<double[], double, double> f, double[] p, double[] x, double[] y)
        {
            return Minimum(atol, rtol, (double[] param) =>
            {
                var total = 0.0;
                for (int i = 0; i < x.Length; i++)
                    total += Math.Abs(f(param, x[i]) - y[i]);
                return total;
            }, p);
        }

        /// <summary>
        /// Use least absolute deviation to fit a function y = f(p, x) to data.
        /// </summary>
        /// <param name="atol">The absolute tolerance of the minimum position required.</param>
        /// <param name="rtol">The relative tolerance of the minimum position required.</param>
        /// <param name="f">The function to fit y = f(p, x).</param>
        /// <param name="p">The starting parameter and the best fit parameter found.</param>
        /// <param name="x">The x data values.</param>
        /// <param name="y">The y data values.</param>
        public static void CurveFit_LAD(double atol, double rtol, Func<double, double, double> f,
            ref double p, double[] x, double[] y)
        {
            p = Minimum(atol, rtol, p =>
            {
                var total = 0.0;
                for (int i = 0; i < x.Length; i++)
                    total += Math.Abs(f(p, x[i]) - y[i]);
                return total;
            }, p);
        }

        /// <summary>
        /// Use least absolute deviation to fit a function y = f(p0, p1, x) to data.
        /// </summary>
        /// <param name="atol">The absolute tolerance of the minimum position required.</param>
        /// <param name="rtol">The relative tolerance of the minimum position required.</param>
        /// <param name="f">The function to fit y = f(p0, p1, x).</param>
        /// <param name="p0">The starting parameters and the best fit parameters found.</param>
        /// <param name="p1">The starting parameters and the best fit parameters found.</param>
        /// <param name="x">The x data values.</param>
        /// <param name="y">The y data values.</param>
        /// <returns>least absolute deviation at the best fit.</returns>
        public static double CurveFit_LAD(double atol, double rtol, Func<double, double, double, double> f,
            ref double p0, ref double p1, double[] x, double[] y)
        {
            var p = new[] { p0, p1 };
            var lad = CurveFit_LAD(atol, rtol, (p, x) => f(p[0], p[1], x), p, x, y);
            p0 = p[0]; p1 = p[1];
            return lad;
        }

        /// <summary>
        /// Use least absolute deviation to fit a function y = f(p0, p1, p2, x) to data.
        /// </summary>
        /// <param name="atol">The absolute tolerance of the minimum position required.</param>
        /// <param name="rtol">The relative tolerance of the minimum position required.</param>
        /// <param name="f">The function to fit y = f(p0, p1, p2, x).</param>
        /// <param name="p0">The starting parameters and the best fit parameters found.</param>
        /// <param name="p1">The starting parameters and the best fit parameters found.</param>
        /// <param name="p2">The starting parameters and the best fit parameters found.</param>
        /// <param name="x">The x data values.</param>
        /// <param name="y">The y data values.</param>
        /// <returns>least absolute deviation at the best fit.</returns>
        public static double CurveFit_LAD(double atol, double rtol, Func<double, double, double, double, double> f,
            ref double p0, ref double p1, ref double p2, double[] x, double[] y)
        {
            var p = new[] { p0, p1, p2 };
            var lad = CurveFit_LAD(atol, rtol, (p, x) => f(p[0], p[1], p[2], x), p, x, y);
            p0 = p[0]; p1 = p[1]; p2 = p[2];
            return lad;
        }

        /// <summary>
        /// Use least absolute deviation to fit a function y = f(p0, p1, p2, p3, x) to data.
        /// </summary>
        /// <param name="atol">The absolute tolerance of the minimum position required.</param>
        /// <param name="rtol">The relative tolerance of the minimum position required.</param>
        /// <param name="f">The function to fit y = f(p0, p1, p2, p3, x).</param>
        /// <param name="p0">The starting parameters and the best fit parameters found.</param>
        /// <param name="p1">The starting parameters and the best fit parameters found.</param>
        /// <param name="p2">The starting parameters and the best fit parameters found.</param>
        /// <param name="p3">The starting parameters and the best fit parameters found.</param>
        /// <param name="x">The x data values.</param>
        /// <param name="y">The y data values.</param>
        /// <returns>least absolute deviation at the best fit.</returns>
        public static double CurveFit_LAD(double atol, double rtol, Func<double, double, double, double, double, double> f,
            ref double p0, ref double p1, ref double p2, ref double p3, double[] x, double[] y)
        {
            var p = new[] { p0, p1, p2, p3 };
            var lad = CurveFit_LAD(atol, rtol, (p, x) => f(p[0], p[1], p[2], p[3], x), p, x, y);
            p0 = p[0]; p1 = p[1]; p2 = p[2]; p3 = p[3];
            return lad;
        }

        /// <summary>
        /// Solve a non-linear least-squares problem.
        /// </summary>
        /// <param name="atol">The absolute tolerance of the minimum position required.</param>
        /// <param name="rtol">The relative tolerance of the minimum position required.</param>
        /// <param name="f">The n dimensional function to calculate the residuals.</param>
        /// <param name="x">The starting position and the minimum position found.</param>
        /// <param name="residuals">Working residual array. Values can be anything on entry.</param>
        /// <returns>least squares total at the best fit.</returns>
        public static double LeastSquares(double atol, double rtol, Action<double[], double[]> f, double[] x, double[] residuals)
        {
            return Minimum(atol, rtol, x => { f(x, residuals); return Blas.dot(residuals, residuals); }, x);
        }

        /// <summary>
        /// Solve a non-linear least-squares problem.
        /// </summary>
        /// <param name="atol">The absolute tolerance of the minimum position required.</param>
        /// <param name="rtol">The relative tolerance of the minimum position required.</param>
        /// <param name="f">The n dimensional function to calculate the residuals.</param>
        /// <param name="x0">The starting position and the minimum position found.</param>
        /// <param name="x1">The starting position and the minimum position found.</param>
        /// <param name="residuals">Working residual array. Values can be anything on entry.</param>
        /// <returns>least squares total at the best fit.</returns>
        public static double LeastSquares(double atol, double rtol, Action<double, double, double[]> f,
            ref double x0, ref double x1, double[] residuals)
        {
            var x = new[] { x0, x1 };
            var ols = LeastSquares(atol, rtol, (x, r) => f(x[0], x[1], r), x, residuals);
            x0 = x[0]; x1 = x[1];
            return ols;
        }

        /// <summary>
        /// Solve a non-linear least-squares problem.
        /// </summary>
        /// <param name="atol">The absolute tolerance of the minimum position required.</param>
        /// <param name="rtol">The relative tolerance of the minimum position required.</param>
        /// <param name="f">The n dimensional function to calculate the residuals.</param>
        /// <param name="x0">The starting position and the minimum position found.</param>
        /// <param name="x1">The starting position and the minimum position found.</param>
        /// <param name="x2">The starting position and the minimum position found.</param>
        /// <param name="residuals">Working residual array. Values can be anything on entry.</param>
        /// <returns>least squares total at the best fit.</returns>
        public static double LeastSquares(double atol, double rtol, Action<double, double, double, double[]> f,
            ref double x0, ref double x1, ref double x2, double[] residuals)
        {
            var x = new[] { x0, x1, x2 };
            var ols = LeastSquares(atol, rtol, (x, r) => f(x[0], x[1], x[2], r), x, residuals);
            x0 = x[0]; x1 = x[1]; x2 = x[2];
            return ols;
        }

        /// <summary>
        /// Solve a non-linear least-squares problem.
        /// </summary>
        /// <param name="atol">The absolute tolerance of the minimum position required.</param>
        /// <param name="rtol">The relative tolerance of the minimum position required.</param>
        /// <param name="f">The n dimensional function to calculate the residuals.</param>
        /// <param name="x0">The starting position and the minimum position found.</param>
        /// <param name="x1">The starting position and the minimum position found.</param>
        /// <param name="x2">The starting position and the minimum position found.</param>
        /// <param name="x3">The starting position and the minimum position found.</param>
        /// <param name="residuals">Working residual array. Values can be anything on entry.</param>
        /// <returns>least squares total at the best fit.</returns>
        public static double LeastSquares(double atol, double rtol, Action<double, double, double, double, double[]> f,
            ref double x0, ref double x1, ref double x2, ref double x3, double[] residuals)
        {
            var x = new[] { x0, x1, x2, x3 };
            var ols = LeastSquares(atol, rtol, (x, r) => f(x[0], x[1], x[2], x[3], r), x, residuals);
            x0 = x[0]; x1 = x[1]; x2 = x[2]; x3 = x[3];
            return ols;
        }
    }
}