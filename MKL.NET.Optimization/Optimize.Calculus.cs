using System;
using System.Linq;
using System.Collections.Generic;

namespace MKLNET
{
    public static partial class Optimize
    {
        public static double Derivative_Approx(Func<double, double> f, double x, double epsilon)
            => (f(x + epsilon) - f(x - epsilon)) * 0.5 / epsilon;

        public static double Integral_Approx(int n, Func<double, double> f, double a, double b)
        {
            var total = (f(a) + f(b)) * 0.5;
            var h = (b - a) / n;
            for (int i = 1; i < n; i++) total += f(i * h);
            return total * h;
        }

        static IEnumerable<double> Derivative_Estimates(Func<double, double> f, double x, double epsilon)
        {
            while (true)
            {
                yield return Derivative_Approx(f, x, epsilon);
                epsilon *= 0.5;
            }
        }

        static IEnumerable<double> Integral_Estimates(Func<double, double> f, double a, double b)
        {
            var n = 1;
            var h = b - a;
            var estimate = (f(a) + f(b)) * 0.5;
            yield return estimate * h;
            while (true)
            {
                estimate *= 0.5;
                h *= 0.5;
                n *= 2;
                for (int i = 1; i < n; i += 2) estimate += f(i * h);
                yield return estimate * h;
            }
        }

        static IEnumerable<double> Richardson_Extrapolation(IEnumerable<double> estimates)
        {
            var prevRow = Array.Empty<double>();
            foreach(var startEstimate in estimates)
            {
                var estimate = startEstimate;
                var row = new double[prevRow.Length + 1];
                row[0] = estimate;
                var pow4 = 4.0;
                for (int i = 0; i < prevRow.Length; i++)
                {
                    row[i + 1] = estimate = (estimate * pow4 - prevRow[i]) / (pow4 - 1);
                    pow4 *= 4;
                }
                yield return row[row.Length - 1];
                prevRow = row;
            }
        }

        static double Richardson_StoppingCriteria(double tol, IEnumerable<double> extrapolation)
        {
            var e = extrapolation.GetEnumerator();
            e.MoveNext();
            var a = e.Current;
            e.MoveNext();
            var b = e.Current;
            while (true)
            {
                e.MoveNext();
                var c = e.Current;
                if (Math.Abs(a - b) <= tol && Math.Abs(b - c) <= tol) return c;
                a = b; b = c;
            }
        }

        public static double Derivative(double tol, Func<double, double> f, double x, double epsilon)
            => Richardson_StoppingCriteria(tol, Richardson_Extrapolation(Derivative_Estimates(f, x, epsilon)));

        public static double Intergral(double tol, Func<double, double> f, double a, double b)
            => Richardson_StoppingCriteria(tol, Richardson_Extrapolation(Integral_Estimates(f, a, b)));
    }
}