using System;

namespace MKLNET
{
    public static class Optimize
    {
        static bool BoundsZero(double a, double b) => (a < 0.0 && b > 0.0) || (b < 0.0 && a > 0.0);

        static double LinearRoot(double a, double fa, double b, double fb) => (a * fb - b * fa) / (fb - fa);

        static double QuadraticRoot(double a, double fa, double b, double fb, double c, double fc)
        {
            var r = (fb - fa) / (b - a) - (fc - fb) / (c - b);
            var w = (fc - fa) / (c - a) + r;
            r = w * w - 4.0 * fa * r / (a - c);
            r = r <= 0.0 ? 0.0 : Math.Sqrt(r);
            var x = a - 2.0 * fa / (w + r);
            if (a < x && x < b) return x;
            x = a - 2.0 * fa / (w - r);
            if (a < x && x < b) return x;
            return LinearRoot(a, fa, b, fb);
        }

        static double InverseQuadraticRoot(double a, double fa, double b, double fb, double c, double fc)
        {
            var x = a * fb * fc / ((fa - fb) * (fa - fc)) + b * fa * fc / ((fb - fa) * (fb - fc)) + c * fa * fb / ((fc - fa) * (fc - fb));
            if (a < x && x < b) return x;
            return QuadraticRoot(a, fa, b, fb, c, fc);
        }

        static double RootInner(double tol, Func<double, double> f, double a, double fa, double b, double fb, double c, double fc)
        {
            int level = 1;
            while (b - a > tol * 2)
            {
                double x;
                if (b - a < tol * 4 || level >= 2) x = (a + b) * 0.5;
                else
                {
                    x = level == 0 ? QuadraticRoot(a, fa, b, fb, c, fc) : InverseQuadraticRoot(a, fa, b, fb, c, fc);
                    x = Math.Min(b - tol * 1.99, Math.Max(a + tol * 1.99, x));
                }
                var fx = f(x); if (fx == 0.0) return x;
                if (BoundsZero(fa, fx))
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
            if (BoundsZero(fai, fbi)) return RootInner(xtol, f, xlower, fai, xupper, fbi, double.PositiveInfinity, 0);
            var lx = LinearRoot(xlower, fai, xupper, fbi);
            if (Math.Abs(fai) < Math.Abs(fbi))
            {
                if (lx > xmin && lx < xlower)
                {
                    var ai2 = lx - (lx - xmin) * 0.2;
                    var fai2 = f(ai2); if (fai2 == 0.0) return ai2;
                    if (BoundsZero(fai2, fai)) return RootInner(xtol, f, ai2, fai2, xlower, fai, xupper, fbi);
                    var fa = f(xmin); if (fa == 0.0) return xmin;
                    if (BoundsZero(fa, fai2)) return RootInner(xtol, f, xmin, fa, ai2, fai2, xlower, fai);
                    var fb = f(xmax); if (fb == 0.0) return xmax;
                    return RootInner(xtol, f, xupper, fbi, xmax, fb, xlower, fai);
                }
                else
                {
                    var fa = f(xmin); if (fa == 0.0) return xmin;
                    if (BoundsZero(fa, fai)) return RootInner(xtol, f, xmin, fa, xlower, fai, xupper, fbi);
                    var fb = f(xmax); if (fb == 0.0) return xmax;
                    return RootInner(xtol, f, xupper, fbi, xmax, fb, xlower, fai);
                }
            }
            else
            {
                if (lx > xupper && lx < xmax)
                {
                    var bi2 = lx + (xmax - lx) * 0.2;
                    var fbi2 = f(bi2); if (fbi2 == 0.0) return bi2;
                    if (BoundsZero(fbi, fbi2)) return RootInner(xtol, f, xupper, fbi, bi2, fbi2, xlower, fai);
                    var fb = f(xmax); if (fb == 0.0) return xmax;
                    if (BoundsZero(fbi2, fb)) return RootInner(xtol, f, bi2, fbi2, xmax, fb, xupper, fbi);
                    var fa = f(xmin); if (fa == 0.0) return xmin;
                    return RootInner(xtol, f, xmin, fa, xlower, fai, xupper, fbi);
                }
                else
                {
                    var fb = f(xmax); if (fb == 0.0) return xmax;
                    if (BoundsZero(fbi, fb)) return RootInner(xtol, f, xupper, fbi, xmax, fb, xlower, fai);
                    var fa = f(xmin); if (fa == 0.0) return xmin;
                    return RootInner(xtol, f, xmin, fa, xlower, fai, xupper, fbi);
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
    }
}