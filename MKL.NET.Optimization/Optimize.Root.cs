using System;

namespace MKLNET
{
    public static partial class Optimize
    {
        public static bool Root_Bound(double fa, double fb) => (fa < 0.0 && fb > 0.0) || (fb < 0.0 && fa > 0.0);

        public static double Root_Linear(double a, double fa, double b, double fb)
        {
            var r = fa / (fa - fb);
            return a - r * a + r * b; // Rounding error mitigation.
        }

        public static double Root_Quadratic(double a, double fa, double b, double fb, double c, double fc)
        { // https://en.wikipedia.org/wiki/Muller%27s_method
            var r = (fb - fa) / (b - a) - (fc - fb) / (c - b);
            var w = (fc - fa) / (c - a) + r;
            r = Math.Sqrt(w * w - 4 * fa * r / (a - c));
            var x = a - 2 * fa / (w + r);
            if (a < x && x < b) return x;
            x = a - 2 * fa / (w - r);
            if (a < x && x < b) return x;
            return Root_Linear(a, fa, b, fb); // Rounding errors, it must be near a or b, Root_Linear will work.
        }

        public static double Root_InverseQuadratic(double a, double fa, double b, double fb, double c, double fc)
        { // https://en.wikipedia.org/wiki/Inverse_quadratic_interpolation
            var x = fb / (fa - fb) * fc / (fa - fc) * a
                  + fa / (fb - fa) * fc / (fb - fc) * b
                  + fa / (fc - fa) * fb / (fc - fb) * c;
            if (a < x && x < b) return x;
            return Root_Quadratic(a, fa, b, fb, c, fc);
        }

        static double Not_Too_Close(double tol, double lower, double upper, double x) =>
            Math.Min(upper - tol * 1.99, Math.Max(lower + tol * 1.99, x));

        static double Root_Hybrid(Func<double, double> f, double tol, double a, double fa, double b, double fb, double c, double fc)
        {
            int level = 1;
            while (b - a > tol * 2)
            {
                double x;
                if (b - a < tol * 4 || level >= 2) x = (a + b) * 0.5;
                else
                {
                    x = level == 0 ? Root_Quadratic(a, fa, b, fb, c, fc) : Root_InverseQuadratic(a, fa, b, fb, c, fc);
                    x = Not_Too_Close(tol, a, b, x);
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
            var fxlower = f(xlower); if (fxlower == 0.0) return xlower;
            var fxupper = f(xupper); if (fxupper == 0.0) return xupper;
            if (Root_Bound(fxlower, fxupper))
            {
                var xmid = Not_Too_Close(xtol, xlower, xupper, Root_Linear(xlower, fxlower, xupper, fxupper));
                var fxmid = f(xmid); if (fxmid == 0.0) return xmid;
                return Root_Bound(fxlower, fxmid) ? Root_Hybrid(f, xtol, xlower, fxlower, xmid, fxmid, xupper, fxupper)
                                                  : Root_Hybrid(f, xtol, xmid, fxmid, xupper, fxupper, xlower, fxlower);
            }
            var lx = Root_Linear(xlower, fxlower, xupper, fxupper);
            if (Math.Abs(fxlower) < Math.Abs(fxupper))
            {
                if (lx > xmin && lx < xlower)
                {
                    var ai2 = lx - (lx - xmin) * 0.2;
                    var fai2 = f(ai2); if (fai2 == 0.0) return ai2;
                    if (Root_Bound(fai2, fxlower)) return Root_Hybrid(f, xtol, ai2, fai2, xlower, fxlower, xupper, fxupper);
                    var fa = f(xmin); if (fa == 0.0) return xmin;
                    if (Root_Bound(fa, fai2)) return Root_Hybrid(f, xtol, xmin, fa, ai2, fai2, xlower, fxlower);
                    var fb = f(xmax); if (fb == 0.0) return xmax;
                    return Root_Hybrid(f, xtol, xupper, fxupper, xmax, fb, xlower, fxlower);
                }
                else
                {
                    var fa = f(xmin); if (fa == 0.0) return xmin;
                    if (Root_Bound(fa, fxlower)) return Root_Hybrid(f, xtol, xmin, fa, xlower, fxlower, xupper, fxupper);
                    var fb = f(xmax); if (fb == 0.0) return xmax;
                    return Root_Hybrid(f, xtol, xupper, fxupper, xmax, fb, xlower, fxlower);
                }
            }
            else
            {
                if (lx > xupper && lx < xmax)
                {
                    var bi2 = lx + (xmax - lx) * 0.2;
                    var fbi2 = f(bi2); if (fbi2 == 0.0) return bi2;
                    if (Root_Bound(fxupper, fbi2)) return Root_Hybrid(f, xtol, xupper, fxupper, bi2, fbi2, xlower, fxlower);
                    var fb = f(xmax); if (fb == 0.0) return xmax;
                    if (Root_Bound(fbi2, fb)) return Root_Hybrid(f, xtol, bi2, fbi2, xmax, fb, xupper, fxupper);
                    var fa = f(xmin); if (fa == 0.0) return xmin;
                    return Root_Hybrid(f, xtol, xmin, fa, xlower, fxlower, xupper, fxupper);
                }
                else
                {
                    var fb = f(xmax); if (fb == 0.0) return xmax;
                    if (Root_Bound(fxupper, fb)) return Root_Hybrid(f, xtol, xupper, fxupper, xmax, fb, xlower, fxlower);
                    var fa = f(xmin); if (fa == 0.0) return xmin;
                    return Root_Hybrid(f, xtol, xmin, fa, xlower, fxlower, xupper, fxupper);
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