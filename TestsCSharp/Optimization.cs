using System;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

public static class Optimization
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    static double Sqr(double x) => x * x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    static double Cube(double x) => x * x * x;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    static double Pow4(double x)
    {
        var r = x * x;
        return r * r;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    static double Pow5(double x) => x * x * x * x * x;
    static IEnumerable<int> Range(int start, int step, int finish)
    {
        for (int i = start; i <= finish; i += step)
            yield return i;
    }

    public readonly static (Func<double, double> F, Func<double, double> G, Func<double, double> H, double Min, double Max)[] RootTestProblems
        = RootProblems().ToArray();

    static IEnumerable<(Func<double, double> F, Func<double, double> G, Func<double, double> H, double Min, double Max)> RootProblems()
    {
        yield return (
            x => Math.Sin(x) - 0.5 * x,
            x => Math.Cos(x) - 0.5,
            x => -Math.Sin(x),
            Math.PI * 0.5,
            Math.PI
        );
        for (int n = 1; n <= 10; n++)
            yield return (
                x => -2.0 * Enumerable.Range(1, 20).Sum(i => Sqr(2 * i - 5) / Cube(x - i * i)),
                x => -2.0 * Enumerable.Range(1, 20).Sum(i => -3 * Sqr(2 * i - 5) / Sqr(Sqr(x - i * i))),
                x => -2.0 * Enumerable.Range(1, 20).Sum(i => 12 * Sqr(2 * i - 5) / Pow5(x - i * i)),
                Sqr(n) + 1e-9,
                Sqr(n + 1) - 1e-9
            );
        foreach (var (a, b) in new[] { (-40, -1), (-100, -2), (-200, -3) })
            yield return (
                x => a * x * Math.Exp(b * x),
                x => a * (b * x + 1) * Math.Exp(b * x),
                x => a * b * (b * x + 2) * Math.Exp(b * x),
                -9,
                31
            );
        foreach (var a in new[] { 0.2, 1 })
            foreach (var n in Range(4, 2, 12))
                yield return (
                    x => Math.Pow(x, n) - a,
                    x => n * Math.Pow(x, n - 1),
                    x => n * (n - 1) * Math.Pow(x, n - 2),
                    0,
                    5
                );
        foreach (var n in Range(8, 2, 14))
            yield return (
                x => Math.Pow(x, n) - 1,
                x => n * Math.Pow(x, n - 1),
                x => n * (n - 1) * Math.Pow(x, n - 2),
                -0.95,
                4.05
            );
        yield return (
            x => Math.Sin(x) - 0.5,
            x => Math.Cos(x),
            x => -Math.Sin(x),
            0,
            1.5
        );
        foreach (var n in Range(1, 1, 5).Concat(Range(20, 20, 100)))
            yield return (
                x => 2 * x * Math.Exp(-n) - 2 * Math.Exp(-n * x) + 1,
                x => 2 * Math.Exp(-n) + 2 * n * Math.Exp(-n * x),
                x => -2 * Sqr(n) * Math.Exp(-n * x),
                0,
                1
            );
        foreach (var n in new[] { 5, 10, 20 })
            yield return (
                x => (1 + Sqr(1 - n)) * x - Sqr(1 - n * x),
                x => Sqr(n) * (1 - 2 * x) + 2,
                x => Sqr(n) * -2,
                0,
                1
            );
        foreach (var n in new[] { 2, 5, 10, 15, 20 })
            yield return (
                x => Sqr(x) - Math.Pow(1 - x, n),
                x => 2 * x + n * Math.Pow(1 - x, n - 1),
                x => 2 - n * (n - 1) * Math.Pow(1 - x, n - 2),
                0,
                1
            );
        foreach (var n in new[] { 1, 2, 4, 5, 8, 15, 20 })
            yield return (
                x => (1 + Math.Pow(1 - n, 4)) * x - Math.Pow(1 - n * x, 4),
                x => (1 + Math.Pow(1 - n, 4)) + 4 * n * Math.Pow(1 - n * x, 3),
                x => -12 * Sqr(n) * Math.Pow(1 - n * x, 2),
                0,
                1
            );
        foreach (var n in new[] { 1, 5, 10, 15, 20 })
            yield return (
                x => Math.Exp(-n * x) * (x - 1) + Math.Pow(x, n),
                x => Math.Exp(-n * x) * (1 - n * (x - 1)) + n * Math.Pow(x, n - 1),
                x => -n * Math.Exp(-n * x) * (2 - n * (x - 1)) + n * (n - 1) * Math.Pow(x, n - 2),
                0,
                1
            );
        foreach (var n in new[] { 2, 5, 15, 20 })
            yield return (
                x => (n * x - 1) / ((n - 1) * x),
                x => 1.0 / (n - 1.0) / Sqr(x),
                x => -2.0 / (n - 1.0) / Cube(x),
                0.01,
                1
            );
        foreach (var n in Range(2, 1, 6).Concat(Range(7, 2, 33)))
            yield return (
                x => Math.Pow(x, 1.0 / n) - Math.Pow(n, 1.0 / n),
                x => Math.Pow(x, 1.0 / n - 1.0) / n,
                x => Math.Pow(x, 1.0 / n - 2.0) / n * (1.0 / n - 1.0),
                0,
                100
            );
        yield return (
            x => x == 0 ? 0 : x * Math.Exp(-Math.Pow(x, -2)),
            x => x == 0 ? 0 : Math.Exp(-Math.Pow(x, -2)) * (1 + 2 / Sqr(x)),
            x => x == 0 ? 0 : Math.Exp(-Math.Pow(x, -2)) * 2 / Cube(x) * (2 / Sqr(x) - 1),
            -1,
            4
        );
        foreach (var n in Range(1, 1, 40))
            yield return (
                x => x >= 0 ? 0.05 * n * (x / 1.5 + Math.Sin(x) - 1) : -0.05 * n,
                x => x >= 0 ? 0.05 * n * (1.5 + Math.Cos(x)) : 0,
                x => x >= 0 ? -0.05 * n * Math.Sin(x) : 0,
                -1e4,
                Math.PI * 0.5
            );
        foreach (var n in Range(20, 1, 40).Concat(Range(100, 100, 1000)))
            yield return (
                x => x < 0 ? -0.859
                    : x > 2e-3 / (1 + n) ? Math.E - 1.859
                    : Math.Exp((n + 1) * x / 2e-3) - 1.859,
                x => x < 0 ? 0
                    : x > 2e-3 / (1 + n) ? 0
                    : (n + 1) / 2e-3 * Math.Exp((n + 1) * x / 2e-3),
                x => x < 0 ? 0
                    : x > 2e-3 / (1 + n) ? 0
                    : Sqr((n + 1) / 2e-3) * Math.Exp((n + 1) * x / 2e-3),
                -1e4,
                1e-4
            );
    }

    public static double BondPrice(double spread, double coupon, double interestRate, double years)
    {
        double pv = 0.0;
        for (int t = 1; t < years * 2; t++)
            pv += coupon * 0.5 * Math.Pow(1 + interestRate + spread, -0.5 * t);
        pv += (1 + coupon * 0.5) * Math.Pow(1 + interestRate + spread, -years);
        return pv;
    }

    public static double BlackScholes(bool call, double s, double x, double t, double r, double v)
    {
        static double CND(double x)
        {
            var l = Math.Abs(x);
            var k = 1.0 / (1.0 + 0.2316419 * l);
            var cnd = 1.0 - 1.0 / Math.Sqrt(2 * Convert.ToDouble(Math.PI.ToString())) * Math.Exp(-l * l / 2.0) *
                (0.31938153 * k + -0.356563782 * k * k + 1.781477937 * Math.Pow(k, 3.0) + -1.821255978 * Math.Pow(k, 4.0)
                + 1.330274429 * Math.Pow(k, 5.0));
            return x < 0 ? 1.0 - cnd : cnd;
        }
        var d1 = (Math.Log(s / x) + (r + v * v / 2.0) * t) / (v * Math.Sqrt(t));
        var d2 = d1 - v * Math.Sqrt(t);
        return call ? s * CND(d1) - x * Math.Exp(-r * t) * CND(d2) : x * Math.Exp(-r * t) * CND(-d2) - s * CND(-d1);
    }

    public readonly static (Func<double, double> F, double Min, double Low, double Max)[] MinimumTestProblems
        = MinimumProblems().ToArray();
    static IEnumerable<(Func<double, double> F, double Min, double Low, double Max)> MinimumProblems()
    {
        yield return (
            x => Math.Cos(x) + 0.25 * x * x,
            Math.PI * 0.5,
            Math.PI * 0.6,
            Math.PI
        );
        for (int n = 1; n <= 10; n++)
            yield return (
                x => Enumerable.Range(1, 20).Sum(i => Sqr(2 * i - 5) / Sqr(x - i * i)),
                Sqr(n) + 1e-9,
                Sqr(n + 0.5) + 1e-9,
                Sqr(n + 1) - 1e-9
            );
        foreach (var (a, b) in new[] { (-40, -1), (-100, -2), (-200, -3) })
            yield return (
                x => (a - a * b * x) / Sqr(b) * Math.Exp(b * x),
                -9,
                20,
                31
            );
        foreach (var a in new[] { 0.2, 1 })
            foreach (var n in Range(4, 2, 12))
                yield return (
                    x => Math.Pow(x, n + 1) / (n + 1) - a * x,
                    0,
                    0.5,
                    5
                );
        foreach (var n in Range(8, 2, 14))
            yield return (
                x => Math.Pow(x, n + 1) / (n + 1) - x,
                -0.95,
                -0.9,
                4.05
            );
        yield return (
            x => -Math.Cos(x) - 0.5 * x,
            0,
            0.75,
            1.5
        );
        foreach (var n in Range(1, 1, 5).Concat(Range(20, 20, 100)))
            yield return (
                x => x * x * Math.Exp(-n) + 2.0 / n * Math.Exp(-n * x) + x,
                0,
                0.0125,
                1
            );
        foreach (var n in new[] { 5, 10, 20 })
            yield return (
                x => 0.5 * (1 + Sqr(1 - n)) * x * x + Cube(1 - n * x) / n / 3,
                0,
                0.001,
                1
            );
        foreach (var n in new[] { 2, 5, 10, 15, 20 })
            yield return (
                x => Cube(x) / 3 + Math.Pow(1 - x, n + 1) / (n + 1),
                0,
                0.5,
                1
            );
        foreach (var n in new[] { 1, 2, 4, 5, 8, 15, 20 })
            yield return (
                x => (1 + Math.Pow(1 - n, 4)) * x * x * 0.5 + Math.Pow(1 - n * x, 5) / n * 0.5,
                0,
                0.00001,
                1
            );
        foreach (var n in new[] { 1, 5, 10, 15, 20 })
            yield return (
                x => Math.Exp(-n * x) * (n - n * x - 1) / Sqr(n) + Math.Pow(x, n + 1) / (n + 1),
                0,
                0.5,
                1
            );
        foreach (var n in new[] { 2, 5, 15, 20 })
            yield return (
                x => (n * x - Math.Log(x)) / (n - 1),
                0.01,
                n == 2 ? 0.9 : 0.1,
                1
            );
        foreach (var n in Range(2, 1, 6).Concat(Range(7, 2, 33)))
            yield return (
                x => Math.Pow(x, 1.0 / n + 1.0) / (1.0 / n + 1.0) - Math.Pow(n, 1.0 / n) * x,
                0,
                0.1,
                100
            );
        foreach (var n in Range(1, 1, 40))
            yield return (
                x => x >= 0 ? 0.05 * n * (x * x / 3 - Math.Cos(x) - x) : -0.05 * n * x,
                -1e4,
                Math.PI * 0.25,
                Math.PI * 0.5
            );
        foreach (var n in Range(20, 1, 40).Concat(Range(100, 100, 1000)))
            yield return (
                x => x < 0 ? 2e-3 / (n + 1) - 0.859 * x
                    : x > 2e-3 / (1 + n) ? (Math.E - 1.859) * x
                    : Math.Exp((n + 1) * x / 2e-3) * 2e-3 / (n + 1) - 1.859 * x,
                -1e4,
                5e-5,
                1e-4
            );
    }

    public static double Rosenbrock(double[] x)
    {
        var sum = 0.0;
        for (int i = 1; i < x.Length; i++)
        {
            sum += 100.0 * Sqr(x[i] - Sqr(x[i - 1])) + Sqr(1- x[i - 1]);
        }
        return sum;
    }

    public static double StyblinskiTang(double[] x)
    {
        var sum = 0.0;
        for (int i = 0; i < x.Length; i++)
        {
            var x_i = Math.Max(-5, Math.Min(5, x[i]));
            sum += Pow4(x_i) - 16 * Sqr(x_i) + 5 * x_i;
        }
        return sum * 0.5;
    }

    public static double Beale(double x, double y)
    {
        return Sqr(1.5 - x + x * y) + Sqr(2.25 - x + x * Sqr(y)) + Sqr(2.625 - x + x * Cube(y));
    }

    public static double GoldsteinPrice(double x, double y)
    {
        return (1 + Sqr(x + y + 1) * (19 - 14 * x + 3 * x * x - 14 * y + 6 * x * y + 3 * y * y))
             * (30 + Sqr(2 * x - 3 * y) * (18 - 32 * x + 12 * x * x + 48 * y - 36 * x * y + 27 * y * y));
    }

    public static double Booth(double x, double y)
    {
        return Sqr(x + 2 * y - 7) + Sqr(2 * x + y - 5);
    }

    public static double Matyas(double x, double y)
    {
        return 0.26 * (x * x + y * y) - 0.48 * x * y;
    }

    public static double Himmelblau(double x, double y)
    {
        return Sqr(x*x + y - 11) + Sqr(x + y * y - 7);
    }

    public static double McCormick(double x, double y)
    {
        return Math.Sin(x + y) + Sqr(x - y) - 1.5 * x + 2.5 * y + 1;
    }

    public static double Wood(double x1, double x2, double x3, double x4)
    {
        return 100 * Sqr(x2 - x1 * x1) + Sqr(1 - x1) + 90 * Sqr(x4 - x3 * x3) + Sqr(1 - x3) + 10 * Sqr(x2 + x4 - 2) + 0.1 * Sqr(x2 - x4);
    }

    public static double Gaussian(double[] x, double t)
    {
        return x[0] * Math.Exp(-0.5 * x[1] * Sqr(t - x[2]));
    }
    public static double[] GaussianT = { - 3.5, -3.0, -2.5, -2.0, -1.5, -1.0, -0.5, 0.0, 0.5, 1.0, 1.5, 2.0, 2.5, 3.0, 3.5 };
    public static double[] GaussianY = { 0.0009, 0.0044, 0.0175, 0.0540, 0.1295, 0.2420, 0.3521, 0.3989, 0.3521, 0.2420, 0.1295, 0.0540, 0.0175, 0.0044, 0.0009 };

    public static double Osbourne(double[] x, double t)
    {
        return x[0] * Math.Exp(-t * x[4]) + x[1] * Math.Exp(-x[5] * Sqr(t - x[8])) + x[2] * Math.Exp(-x[6] * Sqr(t - x[9])) + x[3] * Math.Exp(-x[7] * Sqr(t - x[10]));
    }
    public static double[] OsbourneT = { 0, 0.1, 0.2, 0.3, 0.4, 0.5, 0.6, 0.7, 0.8, 0.9, 1, 1.1, 1.2, 1.3, 1.4, 1.5, 1.6, 1.7, 1.8, 1.9, 2, 2.1, 2.2, 2.3, 2.4, 2.5, 2.6, 2.7, 2.8, 2.9, 3, 3.1, 3.2, 3.3, 3.4, 3.5, 3.6, 3.7, 3.8, 3.9, 4, 4.1, 4.2, 4.3, 4.4, 4.5, 4.6, 4.7, 4.8, 4.9, 5, 5.1, 5.2, 5.3, 5.4, 5.5, 5.6, 5.7, 5.8, 5.9, 6, 6.1, 6.2, 6.3, 6.4 };
    public static double[] OsbourneY = { 1.366, 1.191, 1.112, 1.013, 0.991, 0.885, 0.831, 0.847, 0.786, 0.725, 0.746, 0.679, 0.608, 0.655, 0.616, 0.606, 0.602, 0.626, 0.651, 0.724, 0.649, 0.649, 0.694, 0.644, 0.624, 0.661, 0.612, 0.558, 0.533, 0.495, 0.5, 0.423, 0.395, 0.375, 0.372, 0.391, 0.396, 0.405, 0.428, 0.429, 0.523, 0.562, 0.607, 0.653, 0.672, 0.708, 0.633, 0.668, 0.645, 0.632, 0.591, 0.559, 0.597, 0.625, 0.739, 0.71, 0.729, 0.72, 0.636, 0.581, 0.428, 0.292, 0.162, 0.098, 0.054 };

    public static double Broyden(double[] x)
    {
        var total = Sqr((3 - 2 * x[0]) * x[0] - 2 * x[1] + 1);
        for (int i = 1; i < x.Length - 1; i++)
        {
            total += Sqr((3 - 2 * x[i]) * x[i] - x[i - 1] - 2 * x[i + 1] + 1);
        }
        total += Sqr((3 - 2 * x[x.Length - 1]) * x[x.Length - 1] - x[x.Length - 2] + 1);
        return total;
    }
}