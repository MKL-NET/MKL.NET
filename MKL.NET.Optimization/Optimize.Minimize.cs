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
        public static bool Minimize_Bracketed(double fa, double fb, double fc)
            => fa > fb && fb < fc;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static double Sqr(double x) => x * x;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public static double Minimize_GoldenSection(double a, double b, double c)
            => b - a >= c - b ? b + (a - b) * 0.381966011250105 : b + (c - b) * 0.381966011250105;

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
        public static double Minimize_Quadratic(double a, double fa, double b, double fb, double c, double fc)
            => b - 0.5 * (Sqr(b - a) * (fb - fc) - Sqr(b - c) * (fb - fa)) / ((b - a) * (fb - fc) - (b - c) * (fb - fa));

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
        public static double Minimize_Brent(double atol, double rtol, Func<double, double> f, double xmin, double xlow, double xmax)
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