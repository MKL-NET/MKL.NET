using System;
using System.Linq;
using System.Collections.Generic;

public static class Optimization
{
    public readonly static (Func<double, double> F, double Min, double Max)[] TestProblems = Problems().ToArray();
    static IEnumerable<(Func<double, double> F, double Min, double Max)> Problems()
    {
        static double Sqr(double x) => x * x;
        static double Cube(double x) => x * x * x;
        static IEnumerable<int> Range(int start, int step, int finish)
        {
            for (int i = start; i <= finish; i += step)
                yield return i;
        }

        yield return (
            x => Math.Sin(x) - 0.50 * x,
            Math.PI * 0.5,
            Math.PI
        );
        for (int n = 1; n <= 10; n++)
            yield return (
                x => -2.0 * Enumerable.Range(1, 20).Sum(i => Sqr(2 * i - 5.0) / Cube(x - i * i)),
                Sqr(n) + 1e-9,
                Sqr(n + 1) - 1e-9
            );
        foreach (var (a, b) in new[] { (-40, -1), (-100, -2), (-200, -3) })
            yield return (
                x => a * x * Math.Exp(b * x),
                -9,
                31
            );
        foreach (var a in new[] { 0.2, 1 })
            foreach (var n in Range(4, 2, 12))
                yield return (
                    x => Math.Pow(x, n) - a,
                    0,
                    5
                );
        foreach (var n in Range(8, 2, 14))
            yield return (
                x => Math.Pow(x, n) - 1,
                -0.95,
                4.05
            );
        yield return (
            x => Math.Sin(x) - 0.5,
            0,
            1.5
        );
        foreach (var n in Range(1, 1, 5).Concat(Range(20, 20, 100)))
            yield return (
                x => 2 * x * Math.Exp(-n) - 2 * Math.Exp(-n * x) + 1,
                0,
                1
            );
        foreach (var n in new[] { 5, 10, 20 })
            yield return (
                x => (1 + Sqr(1 - n)) * x - Sqr(1 - n * x),
                0,
                1
            );
        foreach (var n in new[] { 2, 5, 10, 15, 20 })
            yield return (
                x => Sqr(x) - Math.Pow(1 - x, n),
                0,
                1
            );
        foreach (var n in new[] { 1, 2, 4, 5, 8, 15, 20 })
            yield return (
                x => (1 + Math.Pow(1 - n, 4)) * x - Math.Pow(1 - n * x, 4),
                0,
                1
            );
        foreach (var n in new[] { 1, 5, 10, 15, 20 })
            yield return (
                x => Math.Exp(-n * x) * (x - 1) + Math.Pow(x, n),
                0,
                1
            );
        foreach (var n in new[] { 2, 5, 15, 20 })
            yield return (
                x => (n * x - 1) / ((n - 1) * x),
                0.01,
                1
            );
        foreach (var n in Range(2, 1, 6).Concat(Range(7, 2, 33)))
            yield return (
                x => Math.Pow(x, 1.0 / n) - Math.Pow(n, 1.0 / n),
                0,
                100
            );
        yield return (
            x => x == 0 ? 0 : x * Math.Exp(-Math.Pow(x, -2)),
            -1,
            4
        );
        foreach (var n in Range(1, 1, 40))
            yield return (
                x => x >= 0 ? 0.05 * n * (x / 1.5 + Math.Sin(x) - 1) : -0.05 * n,
                -1e4,
                Math.PI * 0.5
            );
        foreach (var n in Range(20, 1, 40).Concat(Range(100, 100, 1000)))
            yield return (
                x => x < 0 ? -0.859
                    : x > 2e-3 / (1 + n) ? Math.E - 1.859
                    : Math.Exp((n + 1) * x / 2e-3) - 1.859,
                -1e4,
                1e-4
            );
    }
}