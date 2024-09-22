// Copyright 2024 Anthony Lloyd
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
using System.Diagnostics;
using System.Runtime.CompilerServices;

/// <summary>Optimization and root finding algorithms.</summary>
public static partial class Optimize
{
    /// <summary>Test if a root is bracketed by the function outputs.</summary>
    /// <param name="fa">First function output.</param>
    /// <param name="fb">Second function output.</param>
    /// <returns>True if the function outputs have the opposite sign.</returns>
    public static bool Root_Is_Bracketed(double fa, double fb)
        => (fa < 0.0 && fb > 0.0) || (fb < 0.0 && fa > 0.0);

    /// <summary>Root estimate using bisection i.e. the centre of the two inputs.</summary>
    /// <param name="a">First input.</param>
    /// <param name="b">Second input.</param>
    /// <returns>The centre of the two inputs.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    static double Bisect(double a, double b)
        => (a + b) * 0.5;

    /// <summary>Root estimate using linear interpolation. Also called false position or regula falsi.</summary>
    /// <param name="a">First function input.</param>
    /// <param name="fa">First function output.</param>
    /// <param name="b">Second function input.</param>
    /// <param name="fb">Second function output.</param>
    /// <returns>The linear interpolation root estimate.</returns>
    public static double Root_Linear(double a, double fa, double b, double fb)
    {
        var r = fa / (fa - fb);
        return a - r * a + r * b; // Rounding error mitigation.
    }

    /// <summary>
    /// Root estimate between a and b using quadratic interpolation, falling back to linear interpolation.
    /// See <see href="https://en.wikipedia.org/wiki/Muller%27s_method">Muller's method</see>.
    /// </summary>
    /// <param name="a">First function input.</param>
    /// <param name="fa">First function output.</param>
    /// <param name="b">Second function input.</param>
    /// <param name="fb">Second function output.</param>
    /// <param name="c">Third function input.</param>
    /// <param name="fc">Third function output.</param>
    /// <returns>The root estimate between a and b.</returns>
    public static double Root_Quadratic(double a, double fa, double b, double fb, double c, double fc)
    {
        Debug.Assert(fa * fb < 0, "fa and fb must bound a root");
        if (Math.Abs(fb) < Math.Abs(fa))
            (a, fa, b, fb) = (b, fb, a, fa);
        var r = (fb - fa) / (b - a) - (fc - fb) / (c - b);
        var w = (fc - fa) / (c - a) + r;
        r = w * w - fa * 4 * r / (a - c);
        if (r >= 0)
        {
            r = Math.Sqrt(r);
            var x = a - fa * 2 / (w + r);
            if (a < b && a < x && x < b || a > b && a > x && x > b) return x;
            x = a - fa * 2 / (w - r);
            if (a < b && a < x && x < b || a > b && a > x && x > b) return x;
        }
        return Root_Linear(a, fa, b, fb); // Rounding errors, it must be near a or b, Root_Linear will work.
    }

    /// <summary>
    /// Root estimate between a and b using inverse quadratic interpolation, falling back to quadratic then linear interpolation.
    /// See <see href="https://en.wikipedia.org/wiki/Inverse_quadratic_interpolation">Inverse quadratic interpolation</see>.
    /// </summary>
    /// <param name="a">First function input.</param>
    /// <param name="fa">First function output.</param>
    /// <param name="b">Second function input.</param>
    /// <param name="fb">Second function output.</param>
    /// <param name="c">Third function input.</param>
    /// <param name="fc">Third function output.</param>
    /// <returns>The root estimate between a and b.</returns>
    public static double Root_InverseQuadratic(double a, double fa, double b, double fb, double c, double fc)
    {
        var x = fb / (fa - fb) * fc / (fa - fc) * a
              + fa / (fb - fa) * fc / (fb - fc) * b
              + fa / (fc - fa) * fb / (fc - fb) * c;
        if (a < x && x < b) return x;
        return Root_Quadratic(a, fa, b, fb, c, fc);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#if NETCOREAPP
    static double Cbrt(double x) => Math.Cbrt(x);
#else
    static double Cbrt(double x) => x < 0.0 ? -Math.Pow(-x, 1.0 / 3.0) : Math.Pow(x, 1.0 / 3.0);
#endif

    /// <summary>
    /// Root estimate between a and b using cubic interpolation, falling back to quadratic then linear interpolation.
    /// See <see href="https://en.wikipedia.org/wiki/Lagrange_polynomial">Lagrange polynomial</see> and
    /// <see href="https://mathworld.wolfram.com/CubicFormula.html">Cubic formula</see>.
    /// </summary>
    /// <param name="a">First function input.</param>
    /// <param name="fa">First function output.</param>
    /// <param name="b">Second function input.</param>
    /// <param name="fb">Second function output.</param>
    /// <param name="c">Third function input.</param>
    /// <param name="fc">Third function output.</param>
    /// <param name="d">Fourth function input.</param>
    /// <param name="fd">Fourth function output.</param>
    /// <returns>The root estimate between a and b.</returns>
    public static double Root_Cubic(double a, double fa, double b, double fb, double c, double fc, double d, double fd)
    {
        Debug.Assert(fa * fb < 0, "fa and fb must bound a root");
        // https://en.wikipedia.org/wiki/Lagrange_polynomial
        var a0 = -fa * (b * c * d) / ((a - b) * (a - c) * (a - d)) - fb * (a * c * d) / ((b - a) * (b - c) * (b - d)) - fc * (a * b * d) / ((c - a) * (c - b) * (c - d)) - fd * (a * b * c) / ((d - a) * (d - b) * (d - c));
        var a1 = fa * (b * c + b * d + c * d) / ((a - b) * (a - c) * (a - d)) + fb * (a * c + a * d + c * d) / ((b - a) * (b - c) * (b - d)) + fc * (a * b + a * d + b * d) / ((c - a) * (c - b) * (c - d)) + fd * (a * b + a * c + b * c) / ((d - a) * (d - b) * (d - c));
        var a2 = -fa * (b + c + d) / ((a - b) * (a - c) * (a - d)) - fb * (a + c + d) / ((b - a) * (b - c) * (b - d)) - fc * (a + b + d) / ((c - a) * (c - b) * (c - d)) - fd * (a + b + c) / ((d - a) * (d - b) * (d - c));
        var a3 = fa / ((a - b) * (a - c) * (a - d)) + fb / ((b - a) * (b - c) * (b - d)) + fc / ((c - a) * (c - b) * (c - d)) + fd / ((d - a) * (d - b) * (d - c));
        a0 /= a3; a1 /= a3; a2 /= a3;

        // https://mathworld.wolfram.com/CubicFormula.html
        var Q = (a1 * 3 - a2 * a2) / 9;
        var R = (a2 * a1 * 9 - a0 * 27 - a2 * a2 * a2 * 2) / 54;
        var Q3 = Q * Q * Q;
        var D = Q3 + R * R;
        var shift = a2 / -3;
        if (D < 0)
        {
            var theta = Math.Acos(R / Math.Sqrt(-Q3));
            var x = Math.Sqrt(-Q) * Math.Cos(theta / 3) * 2 + shift;
            if (a < b && a < x && x < b || a > b && a > x && x > b) return x;
            x = Math.Sqrt(-Q) * Math.Cos((theta + Math.PI * 2) / 3) * 2 + shift;
            if (a < b && a < x && x < b || a > b && a > x && x > b) return x;
            x = Math.Sqrt(-Q) * Math.Cos((theta - Math.PI * 2) / 3) * 2 + shift;
            if (a < b && a < x && x < b || a > b && a > x && x > b) return x;
        }
        else if (D == 0)
        {
            var S = Cbrt(R);
            var x = shift + S * 2;
            if (a < b && a < x && x < b || a > b && a > x && x > b) return x;
            x = shift - S;
            if (a < b && a < x && x < b || a > b && a > x && x > b) return x;
        }
        else
        {
            var sqrtD = Math.Sqrt(D);
            var x = Cbrt(R + sqrtD) + Cbrt(R - sqrtD) + shift;
            if (a < b && a < x && x < b || a > b && a > x && x > b) return x;
        }

        return Math.Min(Math.Abs(c - a), Math.Abs(c - b)) <= Math.Min(Math.Abs(d - a), Math.Abs(d - b))
            ? Root_Quadratic(a, fa, b, fb, c, fc)
            : Root_Quadratic(a, fa, b, fb, d, fd);
    } // TODO: Possibly a Hermite spline is better especially when a cubic overshoots and has a max and a min

    /// <summary>
    /// Root estimate between a and b using inverse cubic interpolation, falling back to inverse quadratic, quadratic then linear interpolation.
    /// </summary>
    /// <param name="a">First function input.</param>
    /// <param name="fa">First function output.</param>
    /// <param name="b">Second function input.</param>
    /// <param name="fb">Second function output.</param>
    /// <param name="c">Third function input.</param>
    /// <param name="fc">Third function output.</param>
    /// <param name="d">Fourth function input.</param>
    /// <param name="fd">Fourth function output.</param>
    /// <returns>The root estimate between a and b.</returns>
    public static double Root_InverseCubic(double a, double fa, double b, double fb, double c, double fc, double d, double fd)
    {
        var Q11 = (c - d) * fc / (fd - fc);
        var Q21 = (b - c) * fb / (fc - fb);
        var Q31 = (a - b) * fa / (fb - fa);
        var D21 = (b - c) * fc / (fc - fb);
        var D31 = (a - b) * fb / (fb - fa);
        var Q22 = (D21 - Q11) * fb / (fd - fb);
        var Q32 = (D31 - Q21) * fa / (fc - fa);
        var D32 = (D31 - Q21) * fc / (fc - fa);
        var Q33 = (D32 - Q22) * fa / (fd - fa);
        var x = Q31 + Q32 + Q33 + a;
        if (a < x && x < b) return x;
        return Root_InverseQuadratic(a, fa, b, fb, c, fc);
    }

    /// <summary>Root estimate using <see href="https://en.wikipedia.org/wiki/Newton%27s_method">Newton's method</see>.</summary>
    /// <param name="x">Function input.</param>
    /// <param name="fx">Function output.</param>
    /// <param name="df_dx">Function derivative.</param>
    /// <returns>The root estimate.</returns>
    public static double Root_Newton(double x, double fx, double df_dx)
        => x - fx / df_dx;

    /// <summary>Root estimate using <see href="https://en.wikipedia.org/wiki/Halley%27s_method">Halley's method</see>.</summary>
    /// <param name="x">Function input.</param>
    /// <param name="fx">Function output.</param>
    /// <param name="df_dx">Function derivative.</param>
    /// <param name="d2f_dx2">Function second derivative.</param>
    /// <returns>The root estimate.</returns>
    public static double Root_Halley(double x, double fx, double df_dx, double d2f_dx2)
        => x - fx / (df_dx - 0.5 * fx / df_dx * d2f_dx2);

    /// <summary>
    /// The tolerance calculated at a point.
    /// </summary>
    /// <param name="atol">The absolute tolerance.</param>
    /// <param name="rtol">The relative tolerance.</param>
    /// <param name="x">The point at which to calculate the tolerance.</param>
    /// <returns>tol = atol + rtol * x</returns>
    public static double Tol(double atol, double rtol, double x)
        => atol + rtol * Math.Abs(x);

    static bool Tol_Average_Not_Within(double atol, double rtol, double a, double b)
        => b - a > atol * 2 + rtol * (a + b);

    static double Tol_Not_Too_Close(double atol, double rtol, double a, double b, double x)
    {
        var c = a + (atol + rtol * a) / (1 - rtol) * 1.99;
        if (x < c) return c;
        c = b - (atol + rtol * b) / (1 + rtol) * 1.99;
        if (x > c) return c;
        return x;
    }

    static bool Tol_Average_Within_2(double atol, double rtol, double a, double b)
        => b - a < atol * 4 + rtol * (a + b) * 2;

    static double Root_Hybrid_Bracketed(double atol, double rtol, Func<double, double> f,
        double a, double fa, double b, double fb, double c, double fc, double d, double fd)
    {
        int level = 0;
        while (Tol_Average_Not_Within(atol, rtol, a, b))
        {
            var x = Tol_Average_Within_2(atol, rtol, a, b) ? Bisect(a, b)
                  : level == 0 ? Tol_Not_Too_Close(atol, rtol, a, b, Root_Cubic(a, fa, b, fb, c, fc, d, fd))
                  : level == 1 ? Tol_Not_Too_Close(atol, rtol, a, b, Root_InverseQuadratic(a, fa, b, fb, c, fc))
                  : level == 2 ? Tol_Not_Too_Close(atol, rtol, a, b, (a + b) * 0.25 + Root_Linear(a, fa, b, fb) * 0.5)
                  : Bisect(a, b);
            var fx = f(x); if (fx == 0.0) return x;
            if (Root_Is_Bracketed(fa, fx))
            {
                level = b - x < 0.4 * (b - a) ? level + 1 : 0;
                if (c > b || b - x < a - c) { d = c; fd = fc; c = b; fc = fb; } else { d = b; fd = fb; }
                b = x; fb = fx;
            }
            else
            {
                level = x - a < 0.4 * (b - a) ? level + 1 : 0;
                if (c < a || x - a < c - b) { d = c; fd = fc; c = a; fc = fa; } else { d = a; fd = fa; }
                a = x; fa = fx;
            }
        }
        return Bisect(a, b);
    }

    /// <summary>
    /// Finds the solution f(root) = 0 accurate to tol = atol + rtol * root where xmin &lt; xlower &lt; xupper &lt; xmax.
    /// This is a hybrid method that uses cubic and inverse quadratic interpolation.
    /// It's more than 20% less function evaluations than Brent and also less than Newton and Halley for test problems.
    /// Prefer this method to all others.
    /// </summary>
    /// <param name="atol">The absolute tolerance of the root required.</param>
    /// <param name="rtol">The relative tolerance of the root required.</param>
    /// <param name="f">The function to find the root of.</param>
    /// <param name="xmin">The minimum x value.</param>
    /// <param name="xlower">The lower guess x value.</param>
    /// <param name="xupper">The upper guess x value.</param>
    /// <param name="xmax">The maximum x value.</param>
    /// <returns>The root accurate to tol = atol + rtol * root.</returns>
    public static double Root(double atol, double rtol, Func<double, double> f, double xmin, double xlower, double xupper, double xmax)
    {
        var flower = f(xlower); if (flower == 0) return xlower;
        var fupper = f(xupper); if (fupper == 0) return xupper;
        var xinterp = Root_Linear(xlower, flower, xupper, fupper);
        if (Root_Is_Bracketed(flower, fupper))
        {
            var xmid = Tol_Not_Too_Close(atol, rtol, xlower, xupper, xinterp);
            var fxmid = f(xmid); if (fxmid == 0) return xmid;
            return Root_Is_Bracketed(flower, fxmid) ? Root_Hybrid_Bracketed(atol, rtol, f, xlower, flower, xmid, fxmid, xupper, fupper, double.NaN, 0)
                                                 : Root_Hybrid_Bracketed(atol, rtol, f, xmid, fxmid, xupper, fupper, xlower, flower, double.NaN, 0);
        }
        if (xinterp > xmin && xinterp <= xlower)
        {
            var xlower2 = Tol_Not_Too_Close(atol, rtol, xmin, xmax, xinterp - (xinterp - xmin) * 0.2);
            var flower2 = f(xlower2); if (flower2 == 0.0) return xlower2;
            if (Root_Is_Bracketed(flower2, flower)) return Root_Hybrid_Bracketed(atol, rtol, f, xlower2, flower2, xlower, flower, xupper, fupper, double.NaN, 0);
            var fmin = f(xmin); if (fmin == 0) return xmin;
            if (Root_Is_Bracketed(fmin, flower2)) return Root_Hybrid_Bracketed(atol, rtol, f, xmin, fmin, xlower2, flower2, xlower, flower, xupper, fupper);
            var fmax = f(xmax); if (fmax == 0) return xmax;
            if (Root_Is_Bracketed(fupper, fmax)) Root_Hybrid_Bracketed(atol, rtol, f, xupper, fupper, xmax, fmax, xlower, flower, xlower2, flower2);
            return Math.Abs(fmin) < Math.Abs(fmax) ? xmin : xmax;
        }
        else if (xinterp >= xupper && xinterp < xmax)
        {
            var xupper2 = Tol_Not_Too_Close(atol, rtol, xmin, xmax, xinterp + (xmax - xinterp) * 0.2);
            var fupper2 = f(xupper2); if (fupper2 == 0) return xupper2;
            if (Root_Is_Bracketed(fupper, fupper2)) return Root_Hybrid_Bracketed(atol, rtol, f, xupper, fupper, xupper2, fupper2, xlower, flower, double.NaN, 0);
            var fmax = f(xmax); if (fmax == 0) return xmax;
            if (Root_Is_Bracketed(fupper2, fmax)) return Root_Hybrid_Bracketed(atol, rtol, f, xupper2, fupper2, xmax, fmax, xupper, fupper, xlower, flower);
            var fmin = f(xmin); if (fmin == 0) return xmin;
            if (Root_Is_Bracketed(fmin, flower)) return Root_Hybrid_Bracketed(atol, rtol, f, xmin, fmin, xlower, flower, xupper, fupper, xupper2, fupper2);
            return Math.Abs(fmin) < Math.Abs(fmax) ? xmin : xmax;
        }
        else if (xinterp <= xlower)
        {
            var fmin = f(xmin); if (fmin == 0) return xmin;
            if (Root_Is_Bracketed(fmin, flower)) return Root_Hybrid_Bracketed(atol, rtol, f, xmin, fmin, xlower, flower, xupper, fupper, double.NaN, 0);
            var fmax = f(xmax); if (fmax == 0) return xmax;
            if (Root_Is_Bracketed(fupper, fmax)) return Root_Hybrid_Bracketed(atol, rtol, f, xupper, fupper, xmax, fmax, xlower, flower, xmin, fmin);
            return Math.Abs(fmin) < Math.Abs(fmax) ? xmin : xmax;
        }
        else
        {
            var fmax = f(xmax); if (fmax == 0) return xmax;
            if (Root_Is_Bracketed(fupper, fmax)) return Root_Hybrid_Bracketed(atol, rtol, f, xupper, fupper, xmax, fmax, xlower, flower, double.NaN, 0);
            var fmin = f(xmin); if (fmin == 0) return xmin;
            if (Root_Is_Bracketed(fmin, flower)) return Root_Hybrid_Bracketed(atol, rtol, f, xmin, fmin, xlower, flower, xupper, fupper, xmax, fmax);
            return Math.Abs(fmin) < Math.Abs(fmax) ? xmin : xmax;
        }
    }

    /// <summary>
    /// Finds the solution f(root) = 0 accurate to tol = atol + rtol * root where xmin &lt; xguess &lt; xmax.
    /// This is a hybrid method that uses cubic and inverse quadratic interpolation.
    /// It's more than 20% less function evaluations than Brent and also less than Newton and Halley for test problems.
    /// Prefer this method to all others.
    /// </summary>
    /// <param name="atol">The absolute tolerance of the root required.</param>
    /// <param name="rtol">The relative tolerance of the root required.</param>
    /// <param name="f">The function to find the root of.</param>
    /// <param name="xmin">The minimum x value.</param>
    /// <param name="xguess">A guess x value.</param>
    /// <param name="xmax">The maximum x value.</param>
    /// <returns>The root accurate to tol = atol + rtol * root.</returns>
    public static double Root(double atol, double rtol, Func<double, double> f, double xmin, double xguess, double xmax)
        => Root(atol, rtol, f, xmin, xguess - (xguess - xmin) * 0.01, xguess + (xmax - xguess) * 0.01, xmax);

    /// <summary>
    /// Finds the solution f(root) = 0 accurate to tol = atol + rtol * root where xmin &lt; xmax.
    /// This is a hybrid method that uses cubic and inverse quadratic interpolation.
    /// It's more than 20% less function evaluations than Brent and also less than Newton and Halley for test problems.
    /// Prefer this method to all others.
    /// </summary>
    /// <param name="atol">The absolute tolerance of the root required.</param>
    /// <param name="rtol">The relative tolerance of the root required.</param>
    /// <param name="f">The function to find the root of.</param>
    /// <param name="xmin">The minimum x value.</param>
    /// <param name="xmax">The maximum x value.</param>
    /// <returns>The root accurate to tol = atol + rtol * root.</returns>
    public static double Root(double atol, double rtol, Func<double, double> f, double xmin, double xmax)
        => Root(atol, rtol, f, xmin, xmin + (xmax - xmin) * 0.2, xmax - (xmax - xmin) * 0.2, xmax);

    static double Root_Newton(double a, double fa, double dfa, double b, double fb, double dfb)
    {
        if (Math.Abs(fa) < Math.Abs(fb))
        {
            var x = Root_Newton(a, fa, dfa);
            if (a < x && x < b) return x;
            x = Root_Newton(b, fb, dfb);
            if (a < x && x < b) return x;
        }
        else
        {
            var x = Root_Newton(b, fb, dfb);
            if (a < x && x < b) return x;
            x = Root_Newton(a, fa, dfa);
            if (a < x && x < b) return x;
        }
        return Root_Linear(a, fa, b, fb);
    }

    static double Root_Newton_Bracketed(double atol, double rtol, Func<double, (double, double)> f,
        double a, double fa, double dfa, double b, double fb, double dfb)
    {
        int level = 0;
        while (Tol_Average_Not_Within(atol, rtol, a, b))
        {
            var x = Tol_Average_Within_2(atol, rtol, a, b) ? Bisect(a, b)
                  : level == 0 ? Tol_Not_Too_Close(atol, rtol, a, b, Root_Newton(a, fa, dfa, b, fb, dfb))
                  : level == 1 ? Tol_Not_Too_Close(atol, rtol, a, b, Root_Linear(a, fa, b, fb))
                  : Bisect(a, b);
            var (fx, dfx) = f(x); if (fx == 0.0) return x;
            if (Root_Is_Bracketed(fa, fx))
            {
                level = b - x < 0.4 * (b - a) ? level + 1 : 0;
                b = x; fb = fx; dfb = dfx;
            }
            else
            {
                level = x - a < 0.4 * (b - a) ? level + 1 : 0;
                a = x; fa = fx; dfa = dfx;
            }
        }
        return Bisect(a, b);
    }

    /// <summary>
    /// Finds the solution f(root) = 0 accurate to tol = atol + rtol * root where xmin &lt; xlower &lt; xupper &lt; xmax.
    /// This is a hybrid method that uses Newton's, linear and bisection interpolation.
    /// Included for completeness, prefer <see cref="Root(double, double, Func{double, double}, double, double, double, double)"/>.
    /// </summary>
    /// <param name="atol">The absolute tolerance of the root required.</param>
    /// <param name="rtol">The relative tolerance of the root required.</param>
    /// <param name="f">The function with derivative to find the root of.</param>
    /// <param name="xmin">The minimum x value.</param>
    /// <param name="xlower">The lower guess x value.</param>
    /// <param name="xupper">The upper guess x value.</param>
    /// <param name="xmax">The maximum x value.</param>
    /// <returns>The root accurate to tol = atol + rtol * root.</returns>
    public static double Root(double atol, double rtol, Func<double, (double, double)> f, double xmin, double xlower, double xupper, double xmax)
    {
        var xguess = (xlower + xupper) * 0.5;
        var (fguess, dguess) = f(xguess); if (fguess == 0) return xguess;
        var xinterp = Root_Newton(xguess, fguess, dguess);
        if (xinterp > xlower && xinterp < xguess)
        {
            var xlower2 = xinterp - (xinterp - xlower) * 0.2;
            var (flower2, dlower2) = f(xlower2); if (flower2 == 0.0) return xlower2;
            if (Root_Is_Bracketed(flower2, fguess)) return Root_Newton_Bracketed(atol, rtol, f, xlower2, flower2, dlower2, xguess, fguess, dguess);
            var (flower, dlower) = f(xlower); if (flower == 0.0) return xlower;
            if (Root_Is_Bracketed(flower, flower2)) return Root_Newton_Bracketed(atol, rtol, f, xlower, flower, dlower, xlower2, flower2, dlower2);
            var (fmin, dmin) = f(xmin); if (fmin == 0) return xmin;
            if (Root_Is_Bracketed(fmin, flower)) return Root_Newton_Bracketed(atol, rtol, f, xmin, fmin, dmin, xlower, flower, dlower);
            var (fmax, dmax) = f(xmax); if (fmax == 0) return xmax;
            if (Root_Is_Bracketed(fguess, fmax)) return Root_Newton_Bracketed(atol, rtol, f, xguess, fguess, dguess, xmax, fmax, dmax);
            return Math.Abs(fmin) < Math.Abs(fmax) ? xmin : xmax;
        }
        else if (xinterp > xguess && xinterp < xupper)
        {
            var xupper2 = xinterp + (xupper - xinterp) * 0.2;
            var (fupper2, dupper2) = f(xupper2); if (fupper2 == 0) return xupper2;
            if (Root_Is_Bracketed(fguess, fupper2)) return Root_Newton_Bracketed(atol, rtol, f, xguess, fguess, dguess, xupper2, fupper2, dupper2);
            var (fupper, dupper) = f(xupper); if (fupper == 0.0) return xupper;
            if (Root_Is_Bracketed(fupper2, fupper)) return Root_Newton_Bracketed(atol, rtol, f, xupper2, fupper2, dupper2, xupper, fupper, dupper);
            var (fmax, dmax) = f(xmax); if (fmax == 0) return xmax;
            if (Root_Is_Bracketed(fupper, fmax)) return Root_Newton_Bracketed(atol, rtol, f, xupper, fupper, dupper, xmax, fmax, dmax);
            var (fmin, dmin) = f(xmin); if (fmin == 0) return xmin;
            if (Root_Is_Bracketed(fmin, fguess)) return Root_Newton_Bracketed(atol, rtol, f, xmin, fmin, dmin, xguess, fguess, dguess);
            return Math.Abs(fmin) < Math.Abs(fmax) ? xmin : xmax;
        }
        else if (xinterp > xmin && xinterp < xguess)
        {
            var xlower2 = xinterp - (xinterp - xmin) * 0.2;
            var (flower2, dlower2) = f(xlower2); if (flower2 == 0.0) return xlower2;
            if (Root_Is_Bracketed(flower2, fguess)) return Root_Newton_Bracketed(atol, rtol, f, xlower2, flower2, dlower2, xguess, fguess, dguess);
            var (fmin, dmin) = f(xmin); if (fmin == 0) return xmin;
            if (Root_Is_Bracketed(fmin, flower2)) return Root_Newton_Bracketed(atol, rtol, f, xmin, fmin, dmin, xlower2, flower2, dlower2);
            var (fmax, dmax) = f(xmax); if (fmax == 0) return xmax;
            if (Root_Is_Bracketed(fguess, fmax)) return Root_Newton_Bracketed(atol, rtol, f, xguess, fguess, dguess, xmax, fmax, dmax);
            return Math.Abs(fmin) < Math.Abs(fmax) ? xmin : xmax;
        }
        else if (xinterp > xguess && xinterp < xmax)
        {
            var xupper2 = xinterp + (xmax - xinterp) * 0.2;
            var (fupper2, dupper2) = f(xupper2); if (fupper2 == 0) return xupper2;
            if (Root_Is_Bracketed(fguess, fupper2)) return Root_Newton_Bracketed(atol, rtol, f, xguess, fguess, dguess, xupper2, fupper2, dupper2);
            var (fmax, dmax) = f(xmax); if (fmax == 0) return xmax;
            if (Root_Is_Bracketed(fupper2, fmax)) return Root_Newton_Bracketed(atol, rtol, f, xupper2, fupper2, dupper2, xmax, fmax, dmax);
            var (fmin, dmin) = f(xmin); if (fmin == 0) return xmin;
            if (Root_Is_Bracketed(fmin, fguess)) return Root_Newton_Bracketed(atol, rtol, f, xmin, fmin, dmin, xguess, fguess, dguess);
            return Math.Abs(fmin) < Math.Abs(fmax) ? xmin : xmax;
        }
        else if (xinterp < xguess)
        {
            var (fmin, dmin) = f(xmin); if (fmin == 0) return xmin;
            if (Root_Is_Bracketed(fmin, fguess)) return Root_Newton_Bracketed(atol, rtol, f, xmin, fmin, dmin, xguess, fguess, dguess);
            var (fmax, dmax) = f(xmax); if (fmax == 0) return xmax;
            if (Root_Is_Bracketed(fguess, fmax)) return Root_Newton_Bracketed(atol, rtol, f, xguess, fguess, dguess, xmax, fmax, dmax);
            return Math.Abs(fmin) < Math.Abs(fmax) ? xmin : xmax;
        }
        else
        {
            var (fmax, dmax) = f(xmax); if (fmax == 0) return xmax;
            if (Root_Is_Bracketed(fguess, fmax)) return Root_Newton_Bracketed(atol, rtol, f, xguess, fguess, dguess, xmax, fmax, dmax);
            var (fmin, dmin) = f(xmin); if (fmin == 0) return xmin;
            if (Root_Is_Bracketed(fmin, fguess)) return Root_Newton_Bracketed(atol, rtol, f, xmin, fmin, dmin, xguess, fguess, dguess);
            return Math.Abs(fmin) < Math.Abs(fmax) ? xmin : xmax;
        }
    }

    /// <summary>
    /// Finds the solution f(root) = 0 accurate to tol = atol + rtol * root where xmin &lt; xguess &lt; xmax.
    /// This is a hybrid method that uses Newton's, linear and bisection interpolation.
    /// Included for completeness, prefer <see cref="Root(double, double, Func{double, double}, double, double, double)"/>.
    /// </summary>
    /// <param name="atol">The absolute tolerance of the root required.</param>
    /// <param name="rtol">The relative tolerance of the root required.</param>
    /// <param name="f">The function with derivative to find the root of.</param>
    /// <param name="xmin">The minimum x value.</param>
    /// <param name="xguess">A guess x value.</param>
    /// <param name="xmax">The maximum x value.</param>
    /// <returns>The root accurate to tol = atol + rtol * root.</returns>
    public static double Root(double atol, double rtol, Func<double, (double, double)> f, double xmin, double xguess, double xmax)
    {
        var (fguess, dguess) = f(xguess); if (fguess == 0) return xguess;
        var xinterp = Root_Newton(xguess, fguess, dguess);
        if (xinterp > xmin && xinterp < xguess)
        {
            var xlower = xinterp - (xinterp - xmin) * 0.2;
            var (flower, dlower) = f(xlower); if (flower == 0.0) return xlower;
            if (Root_Is_Bracketed(flower, fguess)) return Root_Newton_Bracketed(atol, rtol, f, xlower, flower, dlower, xguess, fguess, dguess);
            var (fmin, dmin) = f(xmin); if (fmin == 0) return xmin;
            if (Root_Is_Bracketed(fmin, flower)) return Root_Newton_Bracketed(atol, rtol, f, xmin, fmin, dmin, xlower, flower, dlower);
            var (fmax, dmax) = f(xmax); if (fmax == 0) return xmax;
            if (Root_Is_Bracketed(fguess, fmax)) return Root_Newton_Bracketed(atol, rtol, f, xguess, fguess, dguess, xmax, fmax, dmax);
            return Math.Abs(fmin) < Math.Abs(fmax) ? xmin : xmax;
        }
        else if (xinterp > xguess && xinterp < xmax)
        {
            var xupper = xinterp + (xmax - xinterp) * 0.2;
            var (fupper, dupper) = f(xupper); if (fupper == 0) return xupper;
            if (Root_Is_Bracketed(fguess, fupper)) return Root_Newton_Bracketed(atol, rtol, f, xguess, fguess, dguess, xupper, fupper, dupper);
            var (fmax, dmax) = f(xmax); if (fmax == 0) return xmax;
            if (Root_Is_Bracketed(fupper, fmax)) return Root_Newton_Bracketed(atol, rtol, f, xupper, fupper, dupper, xmax, fmax, dmax);
            var (fmin, dmin) = f(xmin); if (fmin == 0) return xmin;
            if (Root_Is_Bracketed(fmin, fguess)) return Root_Newton_Bracketed(atol, rtol, f, xmin, fmin, dmin, xguess, fguess, dguess);
            return Math.Abs(fmin) < Math.Abs(fmax) ? xmin : xmax;
        }
        else if (xinterp < xguess)
        {
            var (fmin, dmin) = f(xmin); if (fmin == 0) return xmin;
            if (Root_Is_Bracketed(fmin, fguess)) return Root_Newton_Bracketed(atol, rtol, f, xmin, fmin, dmin, xguess, fguess, dguess);
            var (fmax, dmax) = f(xmax); if (fmax == 0) return xmax;
            if (Root_Is_Bracketed(fguess, fmax)) return Root_Newton_Bracketed(atol, rtol, f, xguess, fguess, dguess, xmax, fmax, dmax);
            return Math.Abs(fmin) < Math.Abs(fmax) ? xmin : xmax;
        }
        else
        {
            var (fmax, dmax) = f(xmax); if (fmax == 0) return xmax;
            if (Root_Is_Bracketed(fguess, fmax)) return Root_Newton_Bracketed(atol, rtol, f, xguess, fguess, dguess, xmax, fmax, dmax);
            var (fmin, dmin) = f(xmin); if (fmin == 0) return xmin;
            if (Root_Is_Bracketed(fmin, fguess)) return Root_Newton_Bracketed(atol, rtol, f, xmin, fmin, dmin, xguess, fguess, dguess);
            return Math.Abs(fmin) < Math.Abs(fmax) ? xmin : xmax;
        }
    }

    /// <summary>
    /// Finds the solution f(root) = 0 accurate to tol = atol + rtol * root where xmin &lt; xmax.
    /// This is a hybrid method that uses Newton's, linear and bisection interpolation.
    /// Included for completeness, prefer <see cref="Root(double, double, Func{double, double}, double, double)"/>.
    /// </summary>
    /// <param name="atol">The absolute tolerance of the root required.</param>
    /// <param name="rtol">The relative tolerance of the root required.</param>
    /// <param name="f">The function with derivative to find the root of.</param>
    /// <param name="xmin">The minimum x value.</param>
    /// <param name="xmax">The maximum x value.</param>
    /// <returns>The root accurate to tol = atol + rtol * root.</returns>
    public static double Root(double atol, double rtol, Func<double, (double, double)> f, double xmin, double xmax)
        => Root(atol, rtol, f, xmin, (xmin + xmax) * 0.5, xmax);

    static double Root_Halley(double a, double fa, double dfa, double ddfa, double b, double fb, double dfb, double ddfb)
    {
        if (Math.Abs(fa) < Math.Abs(fb))
        {
            var x = Root_Halley(a, fa, dfa, ddfa);
            if (a < x && x < b) return x;
            x = Root_Halley(b, fb, dfb, ddfb);
            if (a < x && x < b) return x;
        }
        else
        {
            var x = Root_Halley(b, fb, dfb, ddfb);
            if (a < x && x < b) return x;
            x = Root_Halley(a, fa, dfa, ddfa);
            if (a < x && x < b) return x;
        }
        return Root_Linear(a, fa, b, fb); // Could be grad cubic
    }

    static double Root_Halley_Bracketed(double atol, double rtol, Func<double, (double, double, double)> f,
        double a, double fa, double dfa, double ddfa, double b, double fb, double dfb, double ddfb)
    {
        int level = 0;
        while (Tol_Average_Not_Within(atol, rtol, a, b))
        {
            var x = Tol_Average_Within_2(atol, rtol, a, b) ? Bisect(a, b)
                  : level == 0 ? Tol_Not_Too_Close(atol, rtol, a, b, Root_Halley(a, fa, dfa, ddfa, b, fb, dfb, ddfb))
                  : level == 1 ? Tol_Not_Too_Close(atol, rtol, a, b, Root_Linear(a, fa, b, fb))
                  : Bisect(a, b);
            var (fx, dfx, ddfx) = f(x); if (fx == 0.0) return x;
            if (Root_Is_Bracketed(fa, fx))
            {
                level = b - x < 0.4 * (b - a) ? level + 1 : 0;
                b = x; fb = fx; dfb = dfx; ddfb = ddfx;
            }
            else
            {
                level = x - a < 0.4 * (b - a) ? level + 1 : 0;
                a = x; fa = fx; dfa = dfx; ddfa = ddfx;
            }
        }
        return Bisect(a, b);
    }

    /// <summary>
    /// Finds the solution f(root) = 0 accurate to tol = atol + rtol * root where xmin &lt; xlower &lt; xupper &lt; xmax.
    /// This is a hybrid method that uses Halley's, linear and bisection interpolation.
    /// Included for completeness, prefer <see cref="Root(double, double, Func{double, double}, double, double, double, double)"/>.
    /// </summary>
    /// <param name="atol">The absolute tolerance of the root required.</param>
    /// <param name="rtol">The relative tolerance of the root required.</param>
    /// <param name="f">The function with derivative to find the root of.</param>
    /// <param name="xmin">The minimum x value.</param>
    /// <param name="xlower">The lower guess x value.</param>
    /// <param name="xupper">The upper guess x value.</param>
    /// <param name="xmax">The maximum x value.</param>
    /// <returns>The root accurate to tol = atol + rtol * root.</returns>
    public static double Root(double atol, double rtol, Func<double, (double, double, double)> f, double xmin, double xlower, double xupper, double xmax)
    {
        var xguess = (xlower + xupper) * 0.5;
        var (fguess, dguess, ddguess) = f(xguess); if (fguess == 0) return xguess;
        var xinterp = Root_Halley(xguess, fguess, dguess, ddguess);
        if (xinterp > xlower && xinterp < xguess)
        {
            var xlower2 = xinterp - (xinterp - xlower) * 0.2;
            var (flower2, dlower2, ddlower2) = f(xlower2); if (flower2 == 0.0) return xlower2;
            if (Root_Is_Bracketed(flower2, fguess)) return Root_Halley_Bracketed(atol, rtol, f, xlower2, flower2, dlower2, ddlower2, xguess, fguess, dguess, ddguess);
            var (flower, dlower, ddlower) = f(xlower); if (flower == 0.0) return xlower;
            if (Root_Is_Bracketed(flower, flower2)) return Root_Halley_Bracketed(atol, rtol, f, xlower, flower, dlower, ddlower, xlower2, flower2, dlower2, ddlower2);
            var (fmin, dmin, ddmin) = f(xmin); if (fmin == 0) return xmin;
            if (Root_Is_Bracketed(fmin, flower)) return Root_Halley_Bracketed(atol, rtol, f, xmin, fmin, dmin, ddmin, xlower, flower, dlower, ddlower);
            var (fmax, dmax, ddmax) = f(xmax); if (fmax == 0) return xmax;
            if (Root_Is_Bracketed(fguess, fmax)) return Root_Halley_Bracketed(atol, rtol, f, xguess, fguess, dguess, ddguess, xmax, fmax, dmax, ddmax);
            return Math.Abs(fmin) < Math.Abs(fmax) ? xmin : xmax;
        }
        else if (xinterp > xguess && xinterp < xupper)
        {
            var xupper2 = xinterp + (xupper - xinterp) * 0.2;
            var (fupper2, dupper2, ddupper2) = f(xupper2); if (fupper2 == 0) return xupper2;
            if (Root_Is_Bracketed(fguess, fupper2)) return Root_Halley_Bracketed(atol, rtol, f, xguess, fguess, dguess, ddguess, xupper2, fupper2, dupper2, ddupper2);
            var (fupper, dupper, ddupper) = f(xupper); if (fupper == 0.0) return xupper;
            if (Root_Is_Bracketed(fupper2, fupper)) return Root_Halley_Bracketed(atol, rtol, f, xupper2, fupper2, dupper2, ddupper2, xupper, fupper, dupper, ddupper);
            var (fmax, dmax, ddmax) = f(xmax); if (fmax == 0) return xmax;
            if (Root_Is_Bracketed(fupper, fmax)) return Root_Halley_Bracketed(atol, rtol, f, xupper, fupper, dupper, ddupper, xmax, fmax, dmax, ddmax);
            var (fmin, dmin, ddmin) = f(xmin); if (fmin == 0) return xmin;
            if (Root_Is_Bracketed(fmin, fguess)) return Root_Halley_Bracketed(atol, rtol, f, xmin, fmin, dmin, ddmin, xguess, fguess, dguess, ddguess);
            return Math.Abs(fmin) < Math.Abs(fmax) ? xmin : xmax;
        }
        else if (xinterp > xmin && xinterp < xguess)
        {
            var xlower2 = xinterp - (xinterp - xmin) * 0.2;
            var (flower2, dlower2, ddlower2) = f(xlower2); if (flower2 == 0.0) return xlower2;
            if (Root_Is_Bracketed(flower2, fguess)) return Root_Halley_Bracketed(atol, rtol, f, xlower2, flower2, dlower2, ddlower2, xguess, fguess, dguess, ddguess);
            var (fmin, dmin, ddmin) = f(xmin); if (fmin == 0) return xmin;
            if (Root_Is_Bracketed(fmin, flower2)) return Root_Halley_Bracketed(atol, rtol, f, xmin, fmin, dmin, ddmin, xlower2, flower2, dlower2, ddlower2);
            var (fmax, dmax, ddmax) = f(xmax); if (fmax == 0) return xmax;
            if (Root_Is_Bracketed(fguess, fmax)) return Root_Halley_Bracketed(atol, rtol, f, xguess, fguess, dguess, ddguess, xmax, fmax, dmax, ddmax);
            return Math.Abs(fmin) < Math.Abs(fmax) ? xmin : xmax;
        }
        else if (xinterp > xguess && xinterp < xmax)
        {
            var xupper2 = xinterp + (xmax - xinterp) * 0.2;
            var (fupper2, dupper2, ddupper2) = f(xupper2); if (fupper2 == 0) return xupper2;
            if (Root_Is_Bracketed(fguess, fupper2)) return Root_Halley_Bracketed(atol, rtol, f, xguess, fguess, dguess, ddguess, xupper2, fupper2, dupper2, ddupper2);
            var (fmax, dmax, ddmax) = f(xmax); if (fmax == 0) return xmax;
            if (Root_Is_Bracketed(fupper2, fmax)) return Root_Halley_Bracketed(atol, rtol, f, xupper2, fupper2, dupper2, ddupper2, xmax, fmax, dmax, ddmax);
            var (fmin, dmin, ddmin) = f(xmin); if (fmin == 0) return xmin;
            if (Root_Is_Bracketed(fmin, fguess)) return Root_Halley_Bracketed(atol, rtol, f, xmin, fmin, dmin, ddmin, xguess, fguess, dguess, ddguess);
            return Math.Abs(fmin) < Math.Abs(fmax) ? xmin : xmax;
        }
        else if (xinterp < xguess)
        {
            var (fmin, dmin, ddmin) = f(xmin); if (fmin == 0) return xmin;
            if (Root_Is_Bracketed(fmin, fguess)) return Root_Halley_Bracketed(atol, rtol, f, xmin, fmin, dmin, ddmin, xguess, fguess, dguess, ddguess);
            var (fmax, dmax, ddmax) = f(xmax); if (fmax == 0) return xmax;
            if (Root_Is_Bracketed(fguess, fmax)) return Root_Halley_Bracketed(atol, rtol, f, xguess, fguess, dguess, ddguess, xmax, fmax, dmax, ddmax);
            return Math.Abs(fmin) < Math.Abs(fmax) ? xmin : xmax;
        }
        else
        {
            var (fmax, dmax, ddmax) = f(xmax); if (fmax == 0) return xmax;
            if (Root_Is_Bracketed(fguess, fmax)) return Root_Halley_Bracketed(atol, rtol, f, xguess, fguess, dguess, ddguess, xmax, fmax, dmax, ddmax);
            var (fmin, dmin, ddmin) = f(xmin); if (fmin == 0) return xmin;
            if (Root_Is_Bracketed(fmin, fguess)) return Root_Halley_Bracketed(atol, rtol, f, xmin, fmin, dmin, ddmin, xguess, fguess, dguess, ddguess);
            return Math.Abs(fmin) < Math.Abs(fmax) ? xmin : xmax;
        }
    }

    /// <summary>
    /// Finds the solution f(root) = 0 accurate to tol = atol + rtol * root where xmin &lt; xguess &lt; xmax.
    /// This is a hybrid method that uses Halley's, linear and bisection interpolation.
    /// Included for completeness, prefer <see cref="Root(double, double, Func{double, double}, double, double, double)"/>.
    /// </summary>
    /// <param name="atol">The absolute tolerance of the root required.</param>
    /// <param name="rtol">The relative tolerance of the root required.</param>
    /// <param name="f">The function with derivative to find the root of.</param>
    /// <param name="xmin">The minimum x value.</param>
    /// <param name="xguess">A guess x value.</param>
    /// <param name="xmax">The maximum x value.</param>
    /// <returns>The root accurate to tol = atol + rtol * root.</returns>
    public static double Root(double atol, double rtol, Func<double, (double, double, double)> f, double xmin, double xguess, double xmax)
    {
        var (fguess, dguess, ddguess) = f(xguess); if (fguess == 0) return xguess;
        var xinterp = Root_Halley(xguess, fguess, dguess, ddguess);
        if (xinterp > xmin && xinterp < xguess)
        {
            var xlower = xinterp - (xinterp - xmin) * 0.2;
            var (flower, dlower, ddlower) = f(xlower); if (flower == 0.0) return xlower;
            if (Root_Is_Bracketed(flower, fguess)) return Root_Halley_Bracketed(atol, rtol, f, xlower, flower, dlower, ddlower, xguess, fguess, dguess, ddguess);
            var (fmin, dmin, ddmin) = f(xmin); if (fmin == 0) return xmin;
            if (Root_Is_Bracketed(fmin, flower)) return Root_Halley_Bracketed(atol, rtol, f, xmin, fmin, dmin, ddmin, xlower, flower, dlower, ddlower);
            var (fmax, dmax, ddmax) = f(xmax); if (fmax == 0) return xmax;
            if (Root_Is_Bracketed(fguess, fmax)) return Root_Halley_Bracketed(atol, rtol, f, xguess, fguess, dguess, ddguess, xmax, fmax, dmax, ddmax);
            return Math.Abs(fmin) < Math.Abs(fmax) ? xmin : xmax;
        }
        else if (xinterp > xguess && xinterp < xmax)
        {
            var xupper = xinterp + (xmax - xinterp) * 0.2;
            var (fupper, dupper, ddupper) = f(xupper); if (fupper == 0) return xupper;
            if (Root_Is_Bracketed(fguess, fupper)) return Root_Halley_Bracketed(atol, rtol, f, xguess, fguess, dguess, ddguess, xupper, fupper, dupper, ddupper);
            var (fmax, dmax, ddmax) = f(xmax); if (fmax == 0) return xmax;
            if (Root_Is_Bracketed(fupper, fmax)) return Root_Halley_Bracketed(atol, rtol, f, xupper, fupper, dupper, ddupper, xmax, fmax, dmax, ddmax);
            var (fmin, dmin, ddmin) = f(xmin); if (fmin == 0) return xmin;
            if (Root_Is_Bracketed(fmin, fguess)) return Root_Halley_Bracketed(atol, rtol, f, xmin, fmin, dmin, ddmin, xguess, fguess, dguess, ddguess);
            return Math.Abs(fmin) < Math.Abs(fmax) ? xmin : xmax;
        }
        else if (xinterp < xguess)
        {
            var (fmin, dmin, ddmin) = f(xmin); if (fmin == 0) return xmin;
            if (Root_Is_Bracketed(fmin, fguess)) return Root_Halley_Bracketed(atol, rtol, f, xmin, fmin, dmin, ddmin, xguess, fguess, dguess, ddguess);
            var (fmax, dmax, ddmax) = f(xmax); if (fmax == 0) return xmax;
            if (Root_Is_Bracketed(fguess, fmax)) return Root_Halley_Bracketed(atol, rtol, f, xguess, fguess, dguess, ddguess, xmax, fmax, dmax, ddmax);
            return Math.Abs(fmin) < Math.Abs(fmax) ? xmin : xmax;
        }
        else
        {
            var (fmax, dmax, ddmax) = f(xmax); if (fmax == 0) return xmax;
            if (Root_Is_Bracketed(fguess, fmax)) return Root_Halley_Bracketed(atol, rtol, f, xguess, fguess, dguess, ddguess, xmax, fmax, dmax, ddmax);
            var (fmin, dmin, ddmin) = f(xmin); if (fmin == 0) return xmin;
            if (Root_Is_Bracketed(fmin, fguess)) return Root_Halley_Bracketed(atol, rtol, f, xmin, fmin, dmin, ddmin, xguess, fguess, dguess, ddguess);
            return Math.Abs(fmin) < Math.Abs(fmax) ? xmin : xmax;
        }
    }

    /// <summary>
    /// Finds the solution f(root) = 0 accurate to tol = atol + rtol * root where xmin &lt; xmax.
    /// This is a hybrid method that uses Halley's, linear and bisection interpolation.
    /// Included for completeness, prefer <see cref="Root(double, double, Func{double, double}, double, double)"/>.
    /// </summary>
    /// <param name="atol">The absolute tolerance of the root required.</param>
    /// <param name="rtol">The relative tolerance of the root required.</param>
    /// <param name="f">The function with derivative to find the root of.</param>
    /// <param name="xmin">The minimum x value.</param>
    /// <param name="xmax">The maximum x value.</param>
    /// <returns>The root accurate to tol = atol + rtol * root.</returns>
    public static double Root(double atol, double rtol, Func<double, (double, double, double)> f, double xmin, double xmax)
        => Root(atol, rtol, f, xmin, (xmin + xmax) * 0.5, xmax);

    /// <summary>
    /// Finds the solution f(root) = 0 accurate to tol = atol + rtol * root where xmin &lt; xmax.
    /// This is Brent's method from Chapter 4 in "Algorithms for Minimization without Derivatives".
    /// Included for completeness, prefer <see cref="Root(double, double, Func{double, double}, double, double)"/>.
    /// </summary>
    /// <param name="atol">The absolute tolerance of the root required.</param>
    /// <param name="rtol">The relative tolerance of the root required.</param>
    /// <param name="f">The function to find the root of.</param>
    /// <param name="xmin">The minimum x value.</param>
    /// <param name="xmax">The maximum x value.</param>
    /// <returns>The root accurate to tol = atol + rtol * root.</returns>
    public static double Root_Brent(double atol, double rtol, Func<double, double> f, double xmin, double xmax)
    {
        // Implementation and notation based on Chapter 4 in
        // "Algorithms for Minimization without Derivatives"
        // by Richard Brent.

        var fa = f(xmin);
        var fb = f(xmax);

        if (fa * fb > 0.0)
        {
            const string str = "Invalid starting bracket. Function must be above target on one end and below target on other end.";
            string msg = $"{str} Target: {0}. f(left) = {fa}. f(right) = {fb}";
            throw new ArgumentException(msg);
        }

        label_int:
        double c = xmin, fc = fa, d = xmax - xmin, e = d;
        label_ext:
        if (Math.Abs(fc) < Math.Abs(fb))
        {
            xmin = xmax; xmax = c; c = xmin;
            fa = fb; fb = fc; fc = fa;
        }

        var m = 0.5 * (c - xmax);
        if (Math.Abs(m) > Tol(atol, rtol, xmax) && fb != 0.0) // exact comparison with 0 is OK here
        {
            // See if bisection is forced
            if (Math.Abs(e) < Tol(atol, rtol, xmax) || Math.Abs(fa) <= Math.Abs(fb))
            {
                d = e = m;
            }
            else
            {
                var s = fb / fa;
                double p, q;
                if (xmin == c)
                {
                    // linear interpolation
                    p = 2.0 * m * s; q = 1.0 - s;
                }
                else
                {
                    // Inverse quadratic interpolation
                    q = fa / fc; var r = fb / fc;
                    p = s * (2.0 * m * q * (q - r) - (xmax - xmin) * (r - 1.0));
                    q = (q - 1.0) * (r - 1.0) * (s - 1.0);
                }
                if (p > 0.0)
                    q = -q;
                else
                    p = -p;
                s = e; e = d;
                if (2.0 * p < 3.0 * m * q - Math.Abs(Tol(atol, rtol, xmax) * q) && p < Math.Abs(0.5 * s * q))
                    d = p / q;
                else
                    d = e = m;
            }
            xmin = xmax; fa = fb;
            var tol = Tol(atol, rtol, xmax);
            if (Math.Abs(d) > tol)
                xmax += d;
            else if (m > 0.0)
                xmax += tol;
            else
                xmax -= tol;

            fb = f(xmax);
            if (fb > 0.0 == fc > 0.0)
                goto label_int;
            else
                goto label_ext;
        }
        else
        {
            return xmax;
        }
    }

    /// <summary>
    /// Finds the solution f(root) = 0 accurate to tol = atol + rtol * root where xmin &lt; xmax.
    /// This is the Toms748 method ported from <see href="https://github.com/scipy/scipy/blob/master/scipy/optimize/zeros.py#L885">SciPy</see>.
    /// Included for completeness, prefer <see cref="Root(double, double, Func{double, double}, double, double)"/>.
    /// </summary>
    /// <param name="atol">The absolute tolerance of the root required.</param>
    /// <param name="rtol">The relative tolerance of the root required.</param>
    /// <param name="f">The function to find the root of.</param>
    /// <param name="xmin">The minimum x value.</param>
    /// <param name="xmax">The maximum x value.</param>
    /// <returns>The root accurate to tol = atol + rtol * root.</returns>
    public static double Root_Toms748(double atol, double rtol, Func<double, double> f, double xmin, double xmax)
    {
        const double MU = 0.5, EPS = 2.2204460492503131e-016; const int k = 1;

        var a = xmin; var b = xmax;

        static bool IsClose(double a, double b, double rtol, double atol)
            => Math.Abs(a - b) <= atol + rtol * Math.Abs(b);

        static bool NotClose(double rtol, double atol, params double[] fs)
        {
            for (int i = 0; i < fs.Length - 1; i++)
                if (double.IsNaN(fs[i + 1]) || IsClose(fs[i], fs[i + 1], rtol, atol)) return false;
            return true;
        }

        static double InverseCubic(double a, double b, double c, double d, double fa, double fb, double fc, double fd)
        {
            var Q11 = (c - d) * fc / (fd - fc);
            var Q21 = (b - c) * fb / (fc - fb);
            var Q31 = (a - b) * fa / (fb - fa);
            var D21 = (b - c) * fc / (fc - fb);
            var D31 = (a - b) * fb / (fb - fa);
            var Q22 = (D21 - Q11) * fb / (fd - fb);
            var Q32 = (D31 - Q21) * fa / (fc - fa);
            var D32 = (D31 - Q21) * fc / (fc - fa);
            var Q33 = (D32 - Q22) * fa / (fd - fa);
            return a + (Q31 + Q32 + Q33);
        }

        static double Newton_Quadratic(double a, double b, double fa, double fb, double d, double fd, int count)
        {
            //
            // Performs quadratic interpolation to determine the next point,
            // takes count Newton steps to find the location of the
            // quadratic polynomial.
            //
            // Point d must lie outside of the interval [a,b], it is the third
            // best approximation to the root, after a and b.
            //
            // Note: this does not guarentee to find a root
            // inside [a, b], so we fall back to a secant step should
            // the result be out of range.
            //
            // Start by obtaining the coefficients of the quadratic polynomial:
            //

            double C = fa;
            double B = (fb - fa) / (b - a);
            double A = ((fd - fb) / (d - b) - B) / (d - a);

            // if a == 0, we do not have an quadratic 
            // if a is not finite, we have an error in our calculations
            // try a secant step, instead:
            if (A == 0 || double.IsNaN(A) || double.IsInfinity(A))
                return Root_Linear(a, fa, b, fb);

            //
            // Determine the starting point of the Newton steps:
            //
            double c = (Math.Sign(A) * Math.Sign(fa) > 0) ? a : b;

            //
            // Take the Newton steps:
            //
            bool error = false;
            for (int i = 0; i < count; i++)
            {
                double fi = C + (B + A * (c - b)) * (c - a); // f(x_i)
                double fpi = B + A * (2 * c - a - b);        // f'(x_i)
                double delta = fi / fpi;
                if (double.IsInfinity(delta) || double.IsNaN(delta))
                {
                    error = true;
                    break;
                }
                c -= delta;
            }
            if (error || (c <= a) || (c >= b))
            {
                // Oops, failure, try a secant step:
                c = Root_Linear(a, fa, b, fb);
            }
            return c;
            //return Root_Quadratic(a, fa, b, fb, d, fd);
        }

        var fa = f(a); if (fa == 0) return a;
        var fb = f(b); if (fb == 0) return b;
        var c = Root_Linear(a, fa, b, fb);
        if (c <= a || c >= b) c = Bisect(a, b);
        var fc = f(c); if (fc == 0) return c;
        double d, fd, e = double.NaN, fe = double.NaN;

        // update bracket
        if (Root_Is_Bracketed(fa, fc))
        {
            d = b;
            fd = fb;
            b = c;
            fb = fc;
        }
        else
        {
            d = a;
            fd = fa;
            a = c;
            fa = fc;
        }

        while (true)
        {
            // Implements Algorithm 4.1(k=1) or 4.2(k=2) in [APS1995]
            var ab_width = b - a;
            c = double.NaN;
            for (int nsteps = 2; nsteps < k + 2; nsteps++)
            {
                if (NotClose(0, 32 * EPS, fa, fb, fd, fe))
                {
                    var c0 = InverseCubic(a, b, d, e, fa, fb, fd, fe);
                    if (a < c0 && c0 < b) c = c0;
                }
                if (double.IsNaN(c))
                    c = Newton_Quadratic(a, b, fa, fb, d, fd, nsteps);

                fc = f(c); if (fc == 0) return c;
                e = d;
                fe = fd;
                // update bracket
                if (Root_Is_Bracketed(fa, fc))
                {
                    d = b;
                    fd = fb;
                    b = c;
                    fb = fc;
                }
                else
                {
                    d = a;
                    fd = fa;
                    a = c;
                    fa = fc;
                }
            }

            double u, fu;
            if (Math.Abs(fa) < Math.Abs(fb))
            {
                u = a;
                fu = fa;
            }
            else
            {
                u = b;
                fu = fb;
            }

            c = u - 2 * fu / (fb - fa) * (b - a);

            if (Math.Abs(c - u) > 0.5 * (b - a))
            {
                c = Bisect(a, b);
            }
            else
            {
                if (IsClose(c, u, EPS, 0))
                {
                    // c didn't change (much).
                    // Either because the f-values at the endpoints have vastly
                    // differing magnitudes, or because the root is very close to
                    // that endpoint
                    var check = Math.Abs(fa / fb); // instead of frexp
                    if (check > 1 << 50 || 1 / check > 1 << 50) // Differ by more than 2**50
                    {
                        c = Math.Abs(fa) < Math.Abs(fb) ? (31 * a + b) / 32 : (31 * b + a) / 32;
                    }
                    else
                    {
                        // Make a bigger adjustment, about the
                        // size of the requested tolerance.
                        var adj = Math.Abs(c) * rtol + atol;
                        c = Math.Abs(fa) < Math.Abs(fb) ? u + adj : u - adj;
                    }
                    if (c <= a || c >= b) c = Bisect(a, b);
                }
            }

            fc = f(c); if (fc == 0) return c;
            e = d;
            fe = fd;
            // update bracket
            if (Root_Is_Bracketed(fa, fc))
            {
                d = b;
                fd = fb;
                b = c;
                fb = fc;
            }
            else
            {
                d = a;
                fd = fa;
                a = c;
                fa = fc;
            }

            if (b - a > MU * ab_width)
            {
                var z = Bisect(a, b);
                var fz = f(z); if (fz == 0) return z;
                e = d;
                fe = fd;
                // update bracket
                if (Root_Is_Bracketed(fa, fz))
                {
                    d = b;
                    fd = fb;
                    b = z;
                    fb = fz;
                }
                else
                {
                    d = a;
                    fd = fa;
                    a = z;
                    fa = fz;
                }
            }

            if (IsClose(a, b, rtol, atol)) return Bisect(a, b);
        }
    }

    /// <summary>
    /// Finds the solution f(root) = 0 accurate to tol = atol + rtol * root where xmin &lt; xmax.
    /// This is the Newton's safe method ported from <see href="http://www.numerical.recipes/">Numerical Recipes</see>.
    /// Included for completeness, prefer <see cref="Root(double, double, Func{double, double}, double, double)"/>.
    /// </summary>
    /// <param name="atol">The absolute tolerance of the root required.</param>
    /// <param name="rtol">The relative tolerance of the root required.</param>
    /// <param name="f">The function to find the root of.</param>
    /// <param name="xmin">The minimum x value.</param>
    /// <param name="xmax">The maximum x value.</param>
    /// <returns>The root accurate to tol = atol + rtol * root.</returns>
    public static double Root_Newton_Safe(double atol, double rtol, Func<double, (double, double)> f, double xmin, double xmax)
    {
        const int MAXIT = 100; //Maximum allowed number of iterations.
        double xh, xl;
        (double fl, double _) = f(xmin);
        (double fh, double _) = f(xmax);
        if (fl == 0) return xmin;
        if (fh == 0) return xmax;
        if (fl < 0)
        {
            xl = xmin;
            xh = xmax;
        }
        else
        {
            xh = xmin;
            xl = xmax;
        }
        double rts = 0.5 * (xmin + xmax); // Initialize the guess for root,
        double dxold = Math.Abs(xmax - xmin); // the “stepsize before last,”
        double dx = dxold; // and the last step.
        (double frts, double dfrts) = f(rts);
        if (frts == 0) return rts;
        for (int j = 0; j < MAXIT; j++)
        {
            if ((((rts - xh) * dfrts - frts) * ((rts - xl) * dfrts - frts) > 0.0)   // Bisect if Newton out of range,
                || (Math.Abs(2.0 * frts) > Math.Abs(dxold * dfrts)))          // or not decreasing fast enough
            {
                dxold = dx;
                dx = 0.5 * (xh - xl);
                rts = xl + dx;
                if (xl == rts) return rts;
            }
            else
            {
                dxold = dx;
                dx = frts / dfrts;
                double temp = rts;
                rts -= dx;
                if (temp == rts) return rts;
            }
            (frts, dfrts) = f(rts);
            if (Math.Abs(dx) < atol + rtol * Math.Abs(rts) || frts == 0) return rts;
            if (frts < 0.0)  // Maintain the bracket on the root.
                xl = rts;
            else
                xh = rts;
        }
        throw new Exception("Maximum number of iterations exceeded in rtsafe");
    }
}