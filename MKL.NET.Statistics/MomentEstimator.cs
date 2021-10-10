using System;

namespace MKLNET;
/// <summary>A central and standard moments estimator. See <see href="https://en.wikipedia.org/wiki/Algorithms_for_calculating_variance">Algorithms for calculating variance</see>.</summary>
public class Moment4Estimator
{
    /// <summary>The number of sample observations.</summary>
    public int N;
    /// <summary>The mean.</summary>
    public double M1;
    /// <summary>The second central sum.</summary>
    public double M2;
    /// <summary>The third central sum.</summary>
    public double M3;
    /// <summary>The fourth central sum.</summary>
    public double M4;
    /// <summary>The mean.</summary>
    public double Mean => M1;
    /// <summary>The variance.</summary>
    public double Variance => M2 / (N - 1);
    /// <summary>The standard deviation.</summary>
    public double StandardDeviation => Math.Sqrt(M2 / (N - 1));
    /// <summary>The skewness.</summary>
    public double Skewness => Math.Sqrt((N - 1) / M2) * M3 / M2 * N / (N - 2);
    /// <summary>The kurtosis.</summary>
    public double Kurtosis => ((double)N * N - 1) / ((N - 2) * (N - 3)) * (N * M4 / (M2 * M2) - 3 + 6.0 / (N + 1));
    /// <summary>Add a sample observation.</summary>
    /// <param name="o">Sample observation value.</param>
    public void Add(double o)
    {
        o -= M1;
        var s = o / ++N;
        var term1 = (N - 1) * o * s;
        M4 += (term1 * s * (N * N - 3 * N + 3) + 6 * s * M2 - 4 * M3) * s;
        M3 += (term1 * (N - 2) - 3 * M2) * s;
        M2 += term1;
        M1 += s;
    }
    /// <summary></summary>
    /// <param name="o"></param>
    public void Add(Moment4Estimator o)
    {
        int n = N + o.N;
        double d = M1 - o.M1;
        double d2 = d * d;
        double m1 = (N * M1 + o.N * o.M1) / n;
        double m2 = M2 + o.M2 + d2 * N * o.N / n;
        double m3 = M3 + o.M3 + d2 * d * N * o.N * (N - o.N) / (n * n) + 3 * d * (N * o.M2 - o.N * M2) / n;
        M4 += o.M4 + d2 * d2 * N * o.N * (N * N - N * o.N + o.N * o.N) / (n * n * n)
              + 6 * d2 * (N * N * o.M2 + o.N * o.N * M2) / (n * n) + 4 * d * (N * o.M3 - o.N * M3) / n;
        M1 = m1;
        M2 = m2;
        M3 = m3;
        N = n;
    }
    /// <summary></summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    public static Moment4Estimator operator +(Moment4Estimator a, Moment4Estimator b)
    {
        int n = a.N + b.N;
        double d = b.M1 - a.M1;
        double d2 = d * d;
        return new Moment4Estimator
        {
            N = n,
            M1 = (a.N * a.M1 + b.N * b.M1) / n,
            M2 = a.M2 + b.M2 + d2 * a.N * b.N / n,
            M3 = a.M3 + b.M3 + d2 * d * a.N * b.N * (a.N - b.N) / (n * n) + 3 * d * (a.N * b.M2 - b.N * a.M2) / n,
            M4 = a.M4 + b.M4 + d2 * d2 * a.N * b.N * (a.N * a.N - a.N * b.N + b.N * b.N) / (n * n * n)
                    + 6 * d2 * (a.N * a.N * b.M2 + b.N * b.N * a.M2) / (n * n) + 4 * d * (a.N * b.M3 - b.N * a.M3) / n
        };
    }
}