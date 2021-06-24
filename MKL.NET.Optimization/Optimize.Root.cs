using System;

namespace MKLNET
{
    public static partial class Optimize
    {
        public static bool Root_Bound(double fa, double fb) => (fa < 0.0 && fb > 0.0) || (fb < 0.0 && fa > 0.0);

        public static double Root_Linear(double a, double fa, double b, double fb) => (a * fb - b * fa) / (fb - fa);

        public static double Root_Quadratic(double a, double fa, double b, double fb, double c, double fc)
        {
            var r = (fb - fa) / (b - a) - (fc - fb) / (c - b);
            var w = (fc - fa) / (c - a) + r;
            r = Math.Sqrt(w * w - 4 * fa * r / (a - c));
            var x = a - 2 * fa / (w + r);
            if (a < x && x < b) return x;
            return a - 2 * fa / (w - r);
        }

        public static double Root_InverseQuadratic(double a, double fa, double b, double fb, double c, double fc)
        {
            var x = a * fb * fc / ((fa - fb) * (fa - fc)) + b * fa * fc / ((fb - fa) * (fb - fc)) + c * fa * fb / ((fc - fa) * (fc - fb));
            if (a < x && x < b) return x;
            return Root_Quadratic(a, fa, b, fb, c, fc);
        }

        static double Root_Inner(Func<double, double> f, double tol, double a, double fa, double b, double fb, double c, double fc)
        {
            int level = 1;
            while (b - a > tol * 2)
            {
                double x;
                if (b - a < tol * 4 || level >= 2) x = (a + b) * 0.5;
                else
                {
                    x = level == 0 ? Root_Quadratic(a, fa, b, fb, c, fc) : Root_InverseQuadratic(a, fa, b, fb, c, fc);
                    x = Math.Min(b - tol * 1.99, Math.Max(a + tol * 1.99, x));
                }
                var fx = f(x); if (fx == 0.0) return x;
                if (Root_Bound(fa, fx))
                {
                    level = b - x < 0.4 * (b - a) ? level + 1 : 0;
                    if (c > b || b - x < a - c) { c = b; fc = fb; }
                    b = x; fb = fx;
                }
                else
                {
                    level = x - a < 0.4 * (b - a) ? level + 1 : 0;
                    if (c < a || x - a < c - b) { c = a; fc = fa; }
                    a = x; fa = fx;
                }
            }
            return (a + b) * 0.5;
        }

        /// <summary>
        /// Finds x the root f(x) = 0 accurate to tol where xmin and xmax (xmin<xlower<xupper<xmax) bound a root i.e. f(xmin)f(xmax) < 0.
        /// </summary>
        /// <param name="f">The function to find the root of.</param>
        /// <param name="xtol">The tolerance of the root required.</param>
        /// <param name="xmin">The lower boundary.</param>
        /// <param name="xlower">The lower inner region.</param>
        /// <param name="xupper">The upper inner region.</param>
        /// <param name="xmax">The upper boundary.</param>
        /// <returns>The root x accurate to tol.</returns>
        public static double Root(Func<double, double> f, double xtol, double xmin, double xlower, double xupper, double xmax)
        {
            var fai = f(xlower); if (fai == 0.0) return xlower;
            var fbi = f(xupper); if (fbi == 0.0) return xupper;
            if (Root_Bound(fai, fbi)) return Root_Inner(f, xtol, xlower, fai, xupper, fbi, double.PositiveInfinity, 0);
            var lx = Root_Linear(xlower, fai, xupper, fbi);
            if (Math.Abs(fai) < Math.Abs(fbi))
            {
                if (lx > xmin && lx < xlower)
                {
                    var ai2 = lx - (lx - xmin) * 0.2;
                    var fai2 = f(ai2); if (fai2 == 0.0) return ai2;
                    if (Root_Bound(fai2, fai)) return Root_Inner(f, xtol, ai2, fai2, xlower, fai, xupper, fbi);
                    var fa = f(xmin); if (fa == 0.0) return xmin;
                    if (Root_Bound(fa, fai2)) return Root_Inner(f, xtol, xmin, fa, ai2, fai2, xlower, fai);
                    var fb = f(xmax); if (fb == 0.0) return xmax;
                    return Root_Inner(f, xtol, xupper, fbi, xmax, fb, xlower, fai);
                }
                else
                {
                    var fa = f(xmin); if (fa == 0.0) return xmin;
                    if (Root_Bound(fa, fai)) return Root_Inner(f, xtol, xmin, fa, xlower, fai, xupper, fbi);
                    var fb = f(xmax); if (fb == 0.0) return xmax;
                    return Root_Inner(f, xtol, xupper, fbi, xmax, fb, xlower, fai);
                }
            }
            else
            {
                if (lx > xupper && lx < xmax)
                {
                    var bi2 = lx + (xmax - lx) * 0.2;
                    var fbi2 = f(bi2); if (fbi2 == 0.0) return bi2;
                    if (Root_Bound(fbi, fbi2)) return Root_Inner(f, xtol, xupper, fbi, bi2, fbi2, xlower, fai);
                    var fb = f(xmax); if (fb == 0.0) return xmax;
                    if (Root_Bound(fbi2, fb)) return Root_Inner(f, xtol, bi2, fbi2, xmax, fb, xupper, fbi);
                    var fa = f(xmin); if (fa == 0.0) return xmin;
                    return Root_Inner(f, xtol, xmin, fa, xlower, fai, xupper, fbi);
                }
                else
                {
                    var fb = f(xmax); if (fb == 0.0) return xmax;
                    if (Root_Bound(fbi, fb)) return Root_Inner(f, xtol, xupper, fbi, xmax, fb, xlower, fai);
                    var fa = f(xmin); if (fa == 0.0) return xmin;
                    return Root_Inner(f, xtol, xmin, fa, xlower, fai, xupper, fbi);
                }
            }
        }

        /// <summary>
        /// Finds x the root f(x) = 0 accurate to tol where xmin and xmax (xmin<xmax) bound a root i.e. f(xmin)f(xmax) < 0.
        /// </summary>
        /// <param name="f">The function to find the root of.</param>
        /// <param name="xtol">The tolerance of the root required.</param>
        /// <param name="xmin">The lower boundary.</param>
        /// <param name="xmax">The upper boundary.</param>
        /// <returns>The root x accurate to tol.</returns>
        public static double Root(Func<double, double> f, double xtol, double xmin, double xmax)
            => Root(f, xtol, xmin, xmin + (xmax - xmin) * 0.2, xmax - (xmax - xmin) * 0.2, xmax);


        /// <summary>
        /// Finds x the root f(x) = 0 accurate to tol where xmin and xmax (xmin<xmax) bound a root i.e. f(xmin)f(xmax) < 0.
        /// </summary>
        /// <param name="f">The function to find the root of.</param>
        /// <param name="xtol">The tolerance of the root required.</param>
        /// <param name="xmin">The lower boundary.</param>
        /// <param name="xmax">The upper boundary.</param>
        /// <returns>The root x accurate to tol.</returns>
        public static double Root_Brent(Func<double, double> f, double xtol, double xmin, double xmax)
        {
            // Implementation and notation based on Chapter 4 in
            // "Algorithms for Minimization without Derivatives"
            // by Richard Brent.

            var fa = f(xmin);
            var fb = f(xmax);

            if (fa * fb > 0.0)
            {
                string str = "Invalid starting bracket. Function must be above target on one end and below target on other end.";
                string msg = string.Format("{0} Target: {1}. f(left) = {2}. f(right) = {3}", str, 0, fa + 0, fb + 0);
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
            if (Math.Abs(m) > xtol && fb != 0.0) // exact comparison with 0 is OK here
            {
                // See if bisection is forced
                if (Math.Abs(e) < xtol || Math.Abs(fa) <= Math.Abs(fb))
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
                    if (2.0 * p < 3.0 * m * q - Math.Abs(xtol * q) && p < Math.Abs(0.5 * s * q))
                        d = p / q;
                    else
                        d = e = m;
                }
                xmin = xmax; fa = fb;
                if (Math.Abs(d) > xtol)
                    xmax += d;
                else if (m > 0.0)
                    xmax += xtol;
                else
                    xmax -= xtol;

                fb = f(xmax);
                if (fb > 0.0 == fc > 0.0)
                    goto label_int;
                else
                    goto label_ext;
            }
            else
                return xmax;
        }
    }
}