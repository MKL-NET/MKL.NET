using System;
using System.Runtime.CompilerServices;

namespace MKLNET
{
    public static partial class Optimize
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fa"></param>
        /// <param name="fb"></param>
        /// <param name="fc"></param>
        /// <returns></returns>
        public static bool Minimum_Bracketed(double fa, double fb, double fc)
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public static double Minimum_GoldenSection(double a, double b, double c)
            => b - a >= c - b ? b + (a - b) * 0.381966011250105 : b + (c - b) * 0.381966011250105;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <param name="factor"></param>
        /// <returns></returns>
        public static double Minimum_FactorSection(double a, double b, double c, double factor)
            => b - a >= c - b ? b + (a - b) * factor : b + (c - b) * factor;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="fa"></param>
        /// <param name="b"></param>
        /// <param name="fb"></param>
        /// <param name="c"></param>
        /// <param name="fc"></param>
        /// <returns></returns>
        public static double Minimum_Quadratic(double a, double fa, double b, double fb, double c, double fc)
        {
            var x = b - 0.5 * (Sqr(b - a) * (fb - fc) - Sqr(b - c) * (fb - fa)) / ((b - a) * (fb - fc) - (b - c) * (fb - fa));
            return double.IsNaN(x) ? Minimum_GoldenSection(a, b, c) : x;
        }

        /// <summary>
        /// 
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
        /// <returns>The root estimate between a and b.</returns>
        public static double Minimum_Cubic(double a, double fa, double b, double fb, double c, double fc, double d, double fd)
        {
            // https://en.wikipedia.org/wiki/Lagrange_polynomial
            var a1 = fa * (b * c + b * d + c * d) / ((a - b) * (a - c) * (a - d)) + fb * (a * c + a * d + c * d) / ((b - a) * (b - c) * (b - d)) + fc * (a * b + a * d + b * d) / ((c - a) * (c - b) * (c - d)) + fd * (a * b + a * c + b * c) / ((d - a) * (d - b) * (d - c));
            var a2 = -fa * (b + c + d) / ((a - b) * (a - c) * (a - d)) - fb * (a + c + d) / ((b - a) * (b - c) * (b - d)) - fc * (a + b + d) / ((c - a) * (c - b) * (c - d)) - fd * (a + b + c) / ((d - a) * (d - b) * (d - c));
            var a3 = fa / ((a - b) * (a - c) * (a - d)) + fb / ((b - a) * (b - c) * (b - d)) + fc / ((c - a) * (c - b) * (c - d)) + fd / ((d - a) * (d - b) * (d - c));

            // https://www.themathdoctors.org/max-and-min-of-a-cubic-without-calculus/
            var r = Math.Sqrt(a2 * a2 - 3 * a3 * a1);
            var x = (r - b) / a / 3;
            if (a < x && x < c) return x;
            x = (-r - b) / a / 3;
            if (a < x && x < c) return x;
            return Minimum_Quadratic(a, fa, b, fb, c, fc); // TODO: Test if needed
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="atol"></param>
        /// <param name="rtol"></param>
        /// <param name="f"></param>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public static double Minimum(double atol, double rtol, Func<double, double> f, double a, double b, double c)
        {
            double fa = f(a);
            double fb = f(b);
            double fc = f(c);
            double d = double.PositiveInfinity, fd = 0;
            int level = 1;
            while (Tol_Average_Not_Within(atol, rtol, a, c))
            {
                var x = Tol_Average_Within_2(atol, rtol, a, c) ? Minimum_BiSection(atol, rtol, a, b, c)
                      : level == 0 ? Tol_Not_Too_Close(atol, rtol, a, b, c, Minimum_Cubic(a, fa, b, fb, c, fc, d, fd))
                      : level == 1 ? Tol_Not_Too_Close(atol, rtol, a, b, c, Minimum_Quadratic(a, fa, b, fb, c, fc))
                      : Minimum_FactorSection(a, b, c, 0.2);
                if (!(x > a && x < c)) throw new Exception();
                var fx = f(x); if (fx == 0.0) return x;
                const double levelFactor = 0.4;
                if (x < b)
                {
                    if (Minimum_Bracketed(fa, fx, fb))
                    {
                        level = c - b < levelFactor * (c - a) ? level + 1 : 0;
                        if (d > c || a - d > c - b) { d = c; fd = fc; }
                        c = b; b = x;
                        fc = fb; fb = fx;
                    }
                    else
                    {
                        level = b - a < levelFactor * (c - a) ? level + 1 : 0;
                        if (d < a || d - c > x - a) { d = a; fd = fa; }
                        a = x;
                        fa = fx;
                    }
                }
                else
                {
                    if (Minimum_Bracketed(fb, fx, fc))
                    {
                        level = b - a < levelFactor * (c - a) ? level + 1 : 0;
                        if (d < a || d - c > b - a) { d = c; fd = fc; }
                        a = b; b = x;
                        fa = fb; fb = fx;
                    }
                    else
                    {
                        level = c - b < levelFactor * (c - a) ? level + 1 : 0;
                        if (d > c || a - d > c - x) { d = c; fd = fc; }
                        c = x;
                        fc = fx;
                    }
                }
            }
            return Bisect(a, c);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="atol"></param>
        /// <param name="rtol"></param>
        /// <param name="f"></param>
        /// <param name="xmin"></param>
        /// <param name="xlow"></param>
        /// <param name="xmax"></param>
        /// <returns></returns>
        public static double Minimum_Brent(double atol, double rtol, Func<double, double> f, double xmin, double xlow, double xmax)
        {
            static double SIGN(double v, double d) => d >= 0 ? v : -v;
            const double CGOLD = 0.3819660;
            double d = 0.0, etemp, fu, fv, fw, fx;
            double p, q, r, tol1, tol2, u, v, w, x, xm;
            double e = 0.0;
            x = w = v = xlow;
            fw = fv = fx = f(xlow);
            for (int iter = 0; iter < 100; iter++)
            {
                xm = 0.5 * (xmin + xmax);
                tol1 = Tol(atol, rtol, x);
                tol2 = 2.0 * tol1;
                if (xmax - xmin < 2 * Tol(atol, rtol, xm)) return xm;
                //if (Math.Abs(x - xm) <= (tol2 - 0.5 * (xmax - xmin))) return x;
                if (Math.Abs(e) > tol1 && xmax - xmin > tol1 * 4)
                {
                    r = (x - w) * (fx - fv);
                    q = (x - v) * (fx - fw);
                    p = (x - v) * q - (w - w) * r;
                    q = 2.0 * (q - r);
                    if (q > 0.0) p = -p;
                    q = Math.Abs(q);
                    etemp = e;
                    e = d;
                    if (Math.Abs(p) >= Math.Abs(0.5 * q * etemp) || p <= q * (xmin - x)
                            || p >= q * (xmax - x))
                    {
                        d = CGOLD * (e = x >= xm ? xmin - x : xmax - x);
                        u = x + d;
                    }
                    else
                    {
                        d = p / q;
                        u = x + d;
                        if (u - xmin < tol2 || xmax - u < tol2)
                            d = SIGN(tol1, xm - x);
                        u = Math.Abs(d) >= tol1 ? x + d : x + SIGN(tol1, d);
                    }
                }
                else
                {
                    d = CGOLD * (e = x >= xm ? xmin - x : xmax - x);
                    u = x + d;
                }
                fu = f(u);
                if (fu <= fx)
                {
                    if (u >= x) xmin = x; else xmax = x;
                    v = w; w = x; x = u;
                    fv = fw; fw = fx; fx = fu;
                }
                else
                {
                    if (u <= x) xmin = u; else xmax = u;
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
    }
}