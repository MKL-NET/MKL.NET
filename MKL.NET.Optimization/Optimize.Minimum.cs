using System;
using System.Runtime.CompilerServices;

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

        /// <summary>
        /// Brackets a minimum for f given two starting points a and b so that f(a) &lt;= f(b) &gt;= f(c).
        /// </summary>
        /// <param name="atol">The absolute tolerance of the root required.</param>
        /// <param name="rtol">The relative tolerance of the root required.</param>
        /// <param name="f">The function to bracket the minimum of.</param>
        /// <param name="a">First input.</param>
        /// <param name="fa">f(a) output.</param>
        /// <param name="b">Second input.</param>
        /// <param name="fb">f(b) output.</param>
        /// <param name="c">c output.</param>
        /// <param name="fc">f(c) output.</param>
        /// <param name="d">Additonal outer point d &lt; a or d &gt; c. Can be infinity if no more than three function evaluations are needed.</param>
        /// <param name="fd">f(d) output. Can be zero if no more than three function evaluations are needed.</param>
        public static void Minimum_Bracket(double atol, double rtol, Func<double, double> f, ref double a, out double fa, ref double b, out double fb,
            out double c, out double fc, out double d, out double fd)
        {
            fa = f(a);
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
            while (!Minimum_Is_Bracketed(fa, fb, fc))
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
        }

        /// <summary>
        /// Finds the minimum of f accurate to tol = atol + rtol * x for bracketed inputs a &lt; b &lt; c and f(a) &lt;= f(b) &gt;= f(c).
        /// </summary>
        /// <param name="atol">The absolute tolerance of the root required.</param>
        /// <param name="rtol">The relative tolerance of the root required.</param>
        /// <param name="f">The function to find the minimum of.</param>
        /// <param name="a">The first function input.</param>
        /// <param name="fa">f(a) input.</param>
        /// <param name="b">The second funtion input and also the minimum.</param>
        /// <param name="fb">f(b) input.</param>
        /// <param name="c">The third function input.</param>
        /// <param name="fc">f(c) input.</param>
        /// <param name="d">Additonal outer point d &lt; a or d &gt; c.</param>
        /// <param name="fd">f(d) input.</param>
        /// <returns>The minimum input point accurate to tol = atol + rtol * x.</returns>
        public static double Minimum_Bracketed(double atol, double rtol, Func<double, double> f,
            double a, double fa, double b, double fb, double c, double fc, double d = double.PositiveInfinity, double fd = 0)
        {
            int level = 0;
            while (Tol_Average_Not_Within(atol, rtol, a, c))
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
                    if (Minimum_Is_Bracketed(fb, fx, fc))
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

        /// <summary>Finds the minimum of f accurate to tol = atol + rtol * x given two starting function inputs.</summary>
        /// <param name="atol">The absolute tolerance of the root required.</param>
        /// <param name="rtol">The relative tolerance of the root required.</param>
        /// <param name="f">The function to find the minimum of.</param>
        /// <param name="a">The first starting input.</param>
        /// <param name="b">The second starting input.</param>
        /// <returns>The minimum input point accurate to tol = atol + rtol * x.</returns>
        public static double Minimum(double atol, double rtol, Func<double, double> f, double a, double b)
        {
            Minimum_Bracket(atol, rtol, f, ref a, out var fa, ref b, out var fb, out var c, out var fc, out var d, out var fd);
            return Minimum_Bracketed(atol, rtol, f, a, fa, b, fb, c, fc, d, fd);
        }

        /// <summary>Finds the minimum of f accurate to tol = atol + rtol * x given a starting function input.</summary>
        /// <param name="atol">The absolute tolerance of the root required.</param>
        /// <param name="rtol">The relative tolerance of the root required.</param>
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
        /// <param name="atol">The absolute tolerance of the root required.</param>
        /// <param name="rtol">The relative tolerance of the root required.</param>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="atol"></param>
        /// <param name="rtol"></param>
        /// <param name="f"></param>
        /// <param name="x"></param>
        /// <param name="p"></param>
        /// <param name="x2"></param>
        public static void Minimum_LineSearch(double atol, double rtol, Func<double[], double> f, vector x, vector p, vector x2)
        {
            var a = Minimum(atol, rtol, a => {
                x2 = x + (a * p).Reuse(x2);
                return f(x2.Array);
            }, 0);
            x2 = x + (a * p).Reuse(x2);
        }

        static void Calc_NegGrad(double atol, double rtol, Func<double[], double> f, double[] x, double[] df)
        {
            var fx = f(x);
            for (int i = 0; i < x.Length; i++)
            {
                var tol = Tol(atol, rtol, x[i]);
                x[i] += tol;
                df[i] = (fx - f(x)) / tol;
                x[i] -= tol;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="atol"></param>
        /// <param name="rtol"></param>
        /// <param name="f"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        public static void Minimum_Wikipedia(double atol, double rtol, Func<double[], double> f, double[] x)
        { // https://en.wikipedia.org/wiki/Broyden%E2%80%93Fletcher%E2%80%93Goldfarb%E2%80%93Shanno_algorithm
            vector df1 = new(x.Length);
            Calc_NegGrad(atol, rtol, f, x, df1.Array);
            vector x1 = new(x.Length, x);
            vector x2 = new(x.Length);
            vector p = Vector.Copy(df1);
            Minimum_LineSearch(atol, rtol, f, x1, p, x2);
            vector df2 = new(x.Length);
            Calc_NegGrad(atol, rtol, f, x2.Array, df2.Array);

            vector s = x2 - x1.Reuse();
            vector y = df1.Reuse() - df2;
            var sTy = s.T * y;
            matrix H = (sTy + y.T * y) / sTy / sTy * s * s.T
                     - (y * s.T + s * y.T) / sTy;

            while (true)
            {
                x1 = x2; x2 = s;
                df1 = df2; df2 = y;
                p = (H * df1).Reuse(p);
                Minimum_LineSearch(atol, rtol, f, x1, p, x2);
                Calc_NegGrad(atol, rtol, f, x2.Array, df2.Array);
                // If any are +ive check the other directions
                // If grad is low return
                s = x2 - x1.Reuse();
                y = df1.Reuse() - df2;
                sTy = s.T * y;
                vector Hy = H * y;
                H = ((sTy + y.T * Hy) / sTy / sTy * s * s.T).Reuse(H)
                  - (Hy * s.T + s * Hy.T) / sTy;
            }
        }

        static matrix Test_Numeric_Recipies(matrix H, vector s, vector y)
        {
            var sTy = s.T * y;
            using vector Hy = H * y;
            var yTHy = y.T * Hy;
            using vector u = s / sTy - H * y / yTHy;
            H = H + s * s.T / sTy - Hy * Hy.T / yTHy
              + yTHy * u * u.T;
            return H;
        }
    }
}