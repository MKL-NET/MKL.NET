using System;
using System.Xml;

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

        static double Not_Too_Close(double tol, double lower, double upper, double x)
        {
            var c = lower + tol * 1.99;
            if (x < c) return c;
            c = upper - tol * 1.99;
            if (x > c) return c;
            return x;
        }

        static double Root_Hybrid(double tol, Func<double, double> f, double a, double fa, double b, double fb, double c, double fc)
        {
            int level = 0;
            while (b - a > tol * 2)
            {
                double x;
                if (b - a < tol * 4 || level == 2) x = (a + b) * 0.5;
                else if (level == 0) x = Not_Too_Close(tol, a, b, Root_Quadratic(a, fa, b, fb, c, fc));
                else x = Not_Too_Close(tol, a, b, Root_InverseQuadratic(a, fa, b, fb, c, fc));
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
        /// <param name="xtol">The tolerance of the root required.</param>
        /// <param name="f">The function to find the root of.</param>
        /// <param name="xmin">The lower boundary.</param>
        /// <param name="xlower">The lower inner region.</param>
        /// <param name="xupper">The upper inner region.</param>
        /// <param name="xmax">The upper boundary.</param>
        /// <returns>The root x accurate to tol.</returns>
        public static double Root(double xtol, Func<double, double> f, double xmin, double xlower, double xupper, double xmax)
        {
            var fxlower = f(xlower); if (fxlower == 0) return xlower;
            var fxupper = f(xupper); if (fxupper == 0) return xupper;
            if (Root_Bound(fxlower, fxupper))
            {
                var xmid = Not_Too_Close(xtol, xlower, xupper, Root_Linear(xlower, fxlower, xupper, fxupper));
                var fxmid = f(xmid); if (fxmid == 0) return xmid;
                return Root_Bound(fxlower, fxmid) ? Root_Hybrid(xtol, f, xlower, fxlower, xmid, fxmid, xupper, fxupper)
                                                  : Root_Hybrid(xtol, f, xmid, fxmid, xupper, fxupper, xlower, fxlower);
            }
            var lx = Root_Linear(xlower, fxlower, xupper, fxupper);
            if (Math.Abs(fxlower) < Math.Abs(fxupper))
            {
                if (lx > xmin && lx < xlower)
                {
                    var ai2 = lx - (lx - xmin) * 0.2;
                    var fai2 = f(ai2); if (fai2 == 0.0) return ai2;
                    if (Root_Bound(fai2, fxlower)) return Root_Hybrid(xtol, f, ai2, fai2, xlower, fxlower, xupper, fxupper);
                    var fa = f(xmin); if (fa == 0) return xmin;
                    if (Root_Bound(fa, fai2)) return Root_Hybrid(xtol, f, xmin, fa, ai2, fai2, xlower, fxlower);
                    var fb = f(xmax); if (fb == 0) return xmax;
                    return Root_Hybrid(xtol, f, xupper, fxupper, xmax, fb, xlower, fxlower);
                }
                else
                {
                    var fa = f(xmin); if (fa == 0) return xmin;
                    if (Root_Bound(fa, fxlower)) return Root_Hybrid(xtol, f, xmin, fa, xlower, fxlower, xupper, fxupper);
                    var fb = f(xmax); if (fb == 0) return xmax;
                    return Root_Hybrid(xtol, f, xupper, fxupper, xmax, fb, xlower, fxlower);
                }
            }
            else
            {
                if (lx > xupper && lx < xmax)
                {
                    var bi2 = lx + (xmax - lx) * 0.2;
                    var fbi2 = f(bi2); if (fbi2 == 0) return bi2;
                    if (Root_Bound(fxupper, fbi2)) return Root_Hybrid(xtol, f, xupper, fxupper, bi2, fbi2, xlower, fxlower);
                    var fb = f(xmax); if (fb == 0) return xmax;
                    if (Root_Bound(fbi2, fb)) return Root_Hybrid(xtol, f, bi2, fbi2, xmax, fb, xupper, fxupper);
                    var fa = f(xmin); if (fa == 0) return xmin;
                    return Root_Hybrid(xtol, f, xmin, fa, xlower, fxlower, xupper, fxupper);
                }
                else
                {
                    var fb = f(xmax); if (fb == 0) return xmax;
                    if (Root_Bound(fxupper, fb)) return Root_Hybrid(xtol, f, xupper, fxupper, xmax, fb, xlower, fxlower);
                    var fa = f(xmin); if (fa == 0) return xmin;
                    return Root_Hybrid(xtol, f, xmin, fa, xlower, fxlower, xupper, fxupper);
                }
            }
        }

        /// <summary>
        /// Finds x the root f(x) = 0 accurate to tol where xmin and xmax (xmin<xmax) bound a root i.e. f(xmin)f(xmax) < 0.
        /// </summary>
        /// <param name="xtol">The tolerance of the root required.</param>
        /// <param name="f">The function to find the root of.</param>
        /// <param name="xmin">The lower boundary.</param>
        /// <param name="xmax">The upper boundary.</param>
        /// <returns>The root x accurate to tol.</returns>
        public static double Root(double xtol, Func<double, double> f, double xmin, double xmax)
            => Root(xtol, f, xmin, xmin + (xmax - xmin) * 0.2, xmax - (xmax - xmin) * 0.2, xmax);


        /// <summary>
        /// Finds x the root f(x) = 0 accurate to tol where xmin and xmax (xmin<xmax) bound a root i.e. f(xmin)f(xmax) < 0.
        /// </summary>
        /// <param name="xtol">The tolerance of the root required.</param>
        /// <param name="f">The function to find the root of.</param>
        /// <param name="xmin">The lower boundary.</param>
        /// <param name="xmax">The upper boundary.</param>
        /// <returns>The root x accurate to tol.</returns>
        public static double Root_Brent(double xtol, Func<double, double> f, double xmin, double xmax)
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

        /// <summary>
        /// Finds x the root f(x) = 0 accurate to tol where xmin and xmax (xmin<xmax) bound a root i.e. f(xmin)f(xmax) < 0.
        /// </summary>
        /// <param name="xtol">The tolerance of the root required.</param>
        /// <param name="f">The function to find the root of.</param>
        /// <param name="xmin">The lower boundary.</param>
        /// <param name="xmax">The upper boundary.</param>
        /// <returns>The root x accurate to tol.</returns>
        public static double Root_Toms748_MathXK(double xtol, Func<double, double> f, double xmin, double xmax)
        {
            /// <summary>
            /// Smallest value such that 1.0+x != 1.0
            /// <para>Value = 2^(-52) = 2.2204460492503131e-016</para>
            /// </summary>
            const double MachineEpsilon = 2.2204460492503131e-016;
            /// <summary>
            /// Minimum normalized positive value 
            /// <para>Value = 2^-1022 = 2.2250738585072014e-308</para>
            /// </summary>
            const double MinNormalValue = 2.2250738585072014e-308; // 2^-1022

            // <summary>
            /// Performs standard secant interpolation of [a,b] given
            /// function evaluations f(a) and f(b).  
            /// </summary>
            /// <param name="a"></param>
            /// <param name="b"></param>
            /// <param name="fa"></param>
            /// <param name="fb"></param>
            /// <returns></returns>
            static double SecantStep(double a, double b, double fa, double fb)
            {
                double c = a - (fa / (fb - fa)) * (b - a);
                return c;
            }

            static double QuadraticStep(double a, double b, double d, double fa, double fb, double fd, int count)
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
                    return SecantStep(a, b, fa, fb);

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
                    c = SecantStep(a, b, fa, fb);
                }
                return c;
            }

            static double CubicStep(double a, double b, double d, double e, double fa, double fb, double fd, double fe)
            {
                //
                // Uses inverse cubic interpolation of f(x) at points 
                // [a,b,d,e] to obtain an approximate root of f(x).
                // Points d and e lie outside the interval [a,b]
                // and are the third and forth best approximations
                // to the root that we have found so far.
                //
                // Note: this does not guarentee to find a root
                // inside [a, b], so we fall back to quadratic
                // interpolation in case of an erroneous result.
                //

                double q11 = (d - e) * (fd / (fe - fd));
                double q21 = (b - d) * (fb / (fd - fb));
                double q31 = (a - b) * (fa / (fb - fa));
                double d21 = (b - d) * (fd / (fd - fb));
                double d31 = (a - b) * (fb / (fb - fa));

                double q22 = (d21 - q11) * (fb / (fe - fb));
                double q32 = (d31 - q21) * (fa / (fd - fa));
                double d32 = (d31 - q21) * (fd / (fd - fa));
                double q33 = (d32 - q22) * (fa / (fe - fa));
                double c = q31 + q32 + q33 + a;

#if EXTRA_DEBUG
            Debug.WriteLine("a = {0} b = {1} d = {2} e = {3} fa = {4} fb = {5} fd = {6} fe = {7}", a, b, d, e, fa, fb, fd, fe);
            Debug.WriteLine("q11 = {0} q21 = {1} q31 = {2} d21 = {3} d31 = {4}", q11, q21, q31, d21, d31);
            Debug.WriteLine("q22 = {0} q32 = {1} d32 = {2} q33 = {3} c = {4}", q22, q32, d32, q33, c);
#endif

                return c;
            }

            static double DoubleSecantStep(double a, double b, double fa, double fb)
            {
                double u;
                double fu;
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
                double c = u - 2 * (fu / (fb - fa)) * (b - a);
                if (Math.Abs(c - u) > (b - a) / 2)
                {
                    c = a + (b - a) / 2;
                }


                return c;
            }

            //
            // Main entry point and logic for Toms Algorithm 748
            // root finder.
            //

            double xSolution = double.NaN;
            int iterations = 0;


            double a = xmin;
            double fa = f(a);

            double b = xmax;
            double fb = f(b);

            if (fa == 0)
            {
                xSolution = a;
                goto exit;
            }
            if (fb == 0)
            {
                xSolution = b;
                goto exit;
            }
            if (b - a <= xtol * 2)
            {
                xSolution = a + (b - a) / 2.0; // don't have an exact solution so take a midpoint
                goto exit;
            }


            double d, fd; // d is the third best guess to the root
            double e, fe; // e is the fourth best guess to the root


            // initialize
            fe = e = d = fd = double.NaN;
            double c;

            int stepNumber = 0;
            while (iterations < 1000)
            {
                // the root is in [a, b]; save it 
                double a0 = a;
                double b0 = b;

                switch (stepNumber)
                {
                    case 0:
                        // *Only* on the first iteration we take a secant step:
                        c = SecantStep(a, b, fa, fb);
                        break;
                    case 1:
                        // *Only* on the second iteration, we take a quadratic step:
                        c = QuadraticStep(a, b, d, fa, fb, fd, 2);
                        break;
                    case 2:
                    case 3:
                        //
                        // Starting with the third step taken
                        // we can use either quadratic or cubic interpolation.
                        // Cubic interpolation requires that all four function values
                        // fa, fb, fd, and fe are distinct, should that not be the case
                        // then variable prof will get set to true, and we'll end up
                        // taking a quadratic step instead.
                        //
                        const double min_diff = MinNormalValue;
                        bool prof = (Math.Abs(fa - fb) < min_diff)
                            || (Math.Abs(fa - fd) < min_diff)
                            || (Math.Abs(fa - fe) < min_diff)
                            || (Math.Abs(fb - fd) < min_diff)
                            || (Math.Abs(fb - fe) < min_diff)
                            || (Math.Abs(fd - fe) < min_diff);

                        // the first time use 2 newton steps; the second time use three
                        int newtonSteps = (stepNumber == 2) ? 2 : 3;
                        if (prof)
                        {
                            c = QuadraticStep(a, b, d, fa, fb, fd, newtonSteps);
                        }
                        else
                        {
                            c = CubicStep(a, b, d, e, fa, fb, fd, fe);
                            if (!(c > a && c < b))
                                c = QuadraticStep(a, b, d, fa, fb, fd, newtonSteps);
                        }
                        break;
                    case 4:
                        // Now we take a double-length secant step:
                        c = DoubleSecantStep(a, b, fa, fb);
                        break;
                    case 5:
                        //
                        // And finally... check to see if an additional bisection step is 
                        // to be taken, we do this if we're not converging fast enough:
                        //
                        const double mu = 0.5;
                        if ((b - a) < mu * (b0 - a0))
                        {
                            stepNumber = 2;
                            continue;
                        }
                        c = a + (b - a) / 2;
                        break;
                    default:
                        return double.NegativeInfinity;

                }

                // save our next best bracket
                e = d;
                fe = fd;


                // We require c in the interval [ a + |a|*minTol, b - |b|*minTol ]
                // If the interval is not valid: (b-a) < (|a|+|b|)*minTol, then take a midpoint

                const double minTol = MachineEpsilon * 10;

                double minA = (a < 0) ? a * (1 - minTol) : a * (1 + minTol);
                double minB = (b < 0) ? b * (1 + minTol) : b * (1 - minTol);
                if ((b - a) < minTol * (Math.Abs(a) + Math.Abs(b)))
                {
                    c = a + (b - a) / 2;
                }
                else if (c < minA)
                {
                    c = minA;
                }
                else if (c > minB)
                {
                    c = minB;
                }

                // OK, lets invoke f(c):
                double fc = f(c);
                ++iterations;

                // if we have a zero then we have an exact solution to the root:
                if (fc == 0)
                {
                    xSolution = c;
                    break;
                }

                if (double.IsNaN(fc))
                {
                    //Policies.ReportDomainError("Requires a continuous function: f({0}) = {1}", c, fc);
                    break;
                }

                //
                // Non-zero fc, update the interval:
                //
                if (Root_Bound(fa, fc))
                {
                    d = b; fd = fb;
                    b = c; fb = fc;
                }
                else
                {
                    d = a; d = fa;
                    a = c; fa = fc;
                }


                if (b - a <= xtol * 2)
                {
                    // we're close enough, but we don't have an exact solution
                    // so take a midpoint
                    xSolution = a + (b - a) / 2.0;
                    break;
                }

                // reset our step if necessary;
                if (++stepNumber > 5)
                    stepNumber = 2;

            }

            exit:
            return xSolution;
        }

        /// <summary>
        /// Finds x the root f(x) = 0 accurate to tol where xmin and xmax (xmin<xmax) bound a root i.e. f(xmin)f(xmax) < 0.
        /// </summary>
        /// <param name="xtol">The tolerance of the root required.</param>
        /// <param name="f">The function to find the root of.</param>
        /// <param name="xmin">The lower boundary.</param>
        /// <param name="xmax">The upper boundary.</param>
        /// <returns>The root x accurate to tol.</returns>
        public static double Root_Toms748_SciPy(double xtol, Func<double, double> f, double a, double b)
        { //https://github.com/scipy/scipy/blob/master/scipy/optimize/zeros.py#L885
            const double rtol = 0, MU = 0.5;
            const int k = 1;

            static double Secant(double x0, double x1, double f0, double f1)
            {
                // Secant has many "mathematically" equivalent formulations
                // x2 = x0 - (x1 - x0)/(f1 - f0) * f0
                //    = x1 - (x1 - x0)/(f1 - f0) * f1
                //    = (-x1 * f0 + x0 * f1) / (f1 - f0)
                //    = (-f0 / f1 * x1 + x0) / (1 - f0 / f1)
                //    = (-f1 / f0 * x0 + x1) / (1 - f1 / f0)
                if (f0 == f1) return double.NaN;
                double x2;
                if (Math.Abs(f1) > Math.Abs(f0))
                    x2 = (-f0 / f1 * x1 + x0) / (1 - f0 / f1);
                else
                    x2 = (-f1 / f0 * x0 + x1) / (1 - f1 / f0);
                return x2;
            }

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

            static double Newton_Quadratic(double a, double b, double fa, double fb, double d, double fd, int k)
            {
                return Root_Quadratic(a, fa, b, fb, d, fd);
            }

            var fa = f(a); if (fa == 0) return a;
            var fb = f(b); if (fb == 0) return b;
            var c = Secant(a, b, fa, fb);
            if (c <= a || c >= b) c = (a + b) * 0.5;
            var fc = f(c); if (fc == 0) return c;
            double d, fd, e = double.NaN, fe = double.NaN;

            // update bracket
            if (Root_Bound(fa, fc))
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
                // iterate
                // Implements Algorithm 4.1(k=1) or 4.2(k=2) in [APS1995]
                var ab_width = b - a;
                c = double.NaN;
                for (int nsteps = 2; nsteps < k + 2; nsteps++)
                {
                    if (NotClose(0, 32 * double.Epsilon, fa, fb, fd, fe))
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
                    if (Root_Bound(fa, fc))
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

                c = u - 2 * (fu / (fb - fa)) * (b - a);

                if (Math.Abs(c - u) > 0.5 * (b - a))
                    c = (a + b) * 0.5;
                else
                {
                    if (IsClose(c, u, double.Epsilon, 0))
                    {
                        // c didn't change (much).
                        // Either because the f-values at the endpoints have vastly
                        // differing magnitudes, or because the root is very close to
                        // that endpoint
                        var check = Math.Abs(fa / fb); // instead of frexp
                        if (check > 2 << 50 || 1 / check > 2 << 50) // Differ by more than 2**50
                        {
                            if (Math.Abs(fa) < Math.Abs(fb))
                                c = (31 * a + b) / 32;
                            else
                                c = (31 * b + a) / 32;
                        }
                        else
                        {
                            // Make a bigger adjustment, about the
                            // size of the requested tolerance.
                            var adj = Math.Abs(c) * rtol + xtol;
                            if (Math.Abs(fa) < Math.Abs(fb))
                            {
                                c = u + adj;
                            }
                            else
                            {
                                c = u - adj;
                            }
                        }
                        if (c <= a || c >= b) c = (a + b) * 0.5;
                    }
                }

                fc = f(c); if (fc == 0) return c;
                e = d;
                fe = fd;
                // update bracket
                if (Root_Bound(fa, fc))
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
                    var z = (a + b) * 0.5;
                    var fz = f(z); if (fz == 0) return z;
                    e = d;
                    fe = fd;
                    // update bracket
                    if (Root_Bound(fa, fz))
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

                if (IsClose(a, b, rtol, xtol)) return (a + b) * 0.5;
            }
        }
    }
}

// TODO: Toms748
// TODO: Root_InverseCubic
// TODO: Newton
// TODO: Halley
// TODO: Root_Cubic
// TODO: Hybrid with Cubic
// TODO: rtol