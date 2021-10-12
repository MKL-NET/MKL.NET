using System;

namespace MKLNET;
/// <summary>A central and standard moments estimator. See <see href="https://en.wikipedia.org/wiki/Algorithms_for_calculating_variance">Algorithms for calculating variance</see>.</summary>
public class Moment4Estimator
{
    /// <summary>The number of sample observations.</summary>
    public long N;
    /// <summary>The mean.</summary>
    public double M1;
    /// <summary>The second central sum.</summary>
    public double S2;
    /// <summary>The third central sum.</summary>
    public double S3;
    /// <summary>The fourth central sum.</summary>
    public double S4;
    /// <summary>The mean.</summary>
    public double Mean => M1;
    /// <summary>The variance.</summary>
    public double Variance => S2 / (N - 1);
    /// <summary>The standard deviation.</summary>
    public double StandardDeviation => Math.Sqrt(S2 / (N - 1));
    /// <summary>The skewness.</summary>
    public double Skewness => Math.Sqrt((N - 1) / S2) * S3 / S2 * N / (N - 2);
    /// <summary>The kurtosis.</summary>
    public double Kurtosis => (((N + 1) * S4 / (S2 * S2) - 3) * N + 3) * (N - 1) / (N - 2) / (N - 3);
    /// <summary>Add a sample observation.</summary>
    /// <param name="o">Sample observation value.</param>
    public void Add(double o)
    {
        o -= M1;
        var s = o / ++N;
        var term1 = (N - 1) * o * s;
        S4 += (term1 * s * (N * N - 3 * N + 3) + 6 * s * S2 - 4 * S3) * s;
        S3 += (term1 * (N - 2) - 3 * S2) * s;
        S2 += term1;
        M1 += s;
    }
    /// <summary></summary>
    /// <param name="o"></param>
    public void Add(Moment4Estimator o)
    {
        var n = N + o.N;
        var d = o.M1 - M1;
        var d2 = d * d;
        var s1 = (N * M1 + o.N * o.M1) / n;
        var s2 = S2 + o.S2 + d2 * N * o.N / n;
        var s3 = S3 + o.S3 + d2 * d * N * o.N * (N - o.N) / (n * n) + 3 * d * (N * o.S2 - o.N * S2) / n;
        S4 = S4 + o.S4 + d2 * d2 * N * o.N * (N * N - N * o.N + o.N * o.N) / (n * n * n)
              + 6 * d2 * (N * N * o.S2 + o.N * o.N * S2) / (n * n) + 4 * d * (N * o.S3 - o.N * S3) / n;
        M1 = s1;
        S2 = s2;
        S3 = s3;
        N = n;
    }
    /// <summary></summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    public static Moment4Estimator operator +(Moment4Estimator a, Moment4Estimator b)
    {
        var n = a.N + b.N;
        var d = b.M1 - a.M1;
        var d2 = d * d;
        return new Moment4Estimator
        {
            N = n,
            M1 = (a.N * a.M1 + b.N * b.M1) / n,
            S2 = a.S2 + b.S2 + d2 * a.N * b.N / n,
            S3 = a.S3 + b.S3 + d2 * d * a.N * b.N * (a.N - b.N) / (n * n) + 3 * d * (a.N * b.S2 - b.N * a.S2) / n,
            S4 = a.S4 + b.S4 + d2 * d2 * a.N * b.N * (a.N * a.N - a.N * b.N + b.N * b.N) / (n * n * n)
                    + 6 * d2 * (a.N * a.N * b.S2 + b.N * b.N * a.S2) / (n * n) + 4 * d * (a.N * b.S3 - b.N * a.S3) / n
        };
    }
}