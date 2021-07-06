using System;
using System.Linq;
using System.Collections.Generic;

public static class Optimization
{
    public readonly static (Func<double, double> F, Func<double, double> G, Func<double, double> H, double Min, double Max)[] TestProblems = Problems().ToArray();
    static IEnumerable<(Func<double, double> F, Func<double, double> G, Func<double, double> H, double Min, double Max)> Problems()
    {
        static double Sqr(double x) => x * x;
        static double Cube(double x) => x * x * x;
        static double Pow5(double x) => x * x * x * x * x;
        static IEnumerable<int> Range(int start, int step, int finish)
        {
            for (int i = start; i <= finish; i += step)
                yield return i;
        }

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
}