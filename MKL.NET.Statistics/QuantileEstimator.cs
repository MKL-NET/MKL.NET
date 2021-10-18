using System;

namespace MKLNET;

/// <summary>A quantile estimator.</summary>
public class QuantileEstimator
{
    readonly double p;
    /// <summary>The number of sample observations.</summary>
    public int N;
    int N1 = 1, N2 = 2, N3 = 3;
    double Q0, Q1, Q3, Q4;
    /// <summary>
    /// The quantile estimate.
    /// </summary>
    public double Quantile;
    /// <summary>
    /// A quantile estimator.
    /// </summary>
    /// <param name="p">The quantile 0.0-1.0 to estimate.</param>
    public QuantileEstimator(double p) => this.p = p;
    /// <summary>Add a sample observation.</summary>
    /// <param name="s">Sample observation value.</param>
    public void Add(double s)
    {
        if (++N > 5)
        {
            if (s < Q3)
            {
                N3++;
                if (s < Quantile)
                {
                    N2++;
                    if (s < Q1)
                    {
                        N1++;
                        if (s < Q0) Q0 = s;
                    }
                }
            }
            else if (s > Q4) Q4 = s;

            s = (N - 1) * p * 0.5 - N1;
            if (s >= 1.0 && N2 - N1 > 1)
            {
                double q = Q1 + ((N1 + 1) * (Quantile - Q1) / (N2 - N1) + (N2 - N1 - 1) * (Q1 - Q0) / N1) / N2;
                Q1 = Q0 < q && q < Quantile ? q : Q1 + (Quantile - Q1) / (N2 - N1);
                N1++;
            }
            else if (s <= -1.0 && N1 > 1)
            {
                double q = Q1 - ((N1 - 1) * (Quantile - Q1) / (N2 - N1) + (N2 - N1 + 1) * (Q1 - Q0) / N1) / N2;
                Q1 = Q0 < q && q < Quantile ? q : Q1 + (Q0 - Q1) / N1;
                N1--;
            }
            s = (N - 1) * p - N2;
            if (s >= 1.0 && N3 - N2 > 1)
            {
                double q = Quantile + ((N2 - N1 + 1) * (Q3 - Quantile) / (N3 - N2) + (N3 - N2 - 1) * (Quantile - Q1) / (N2 - N1)) / (N3 - N1);
                Quantile = Q1 < q && q < Q3 ? q : Quantile + (Q3 - Quantile) / (N3 - N2);
                N2++;
            }
            else if (s <= -1.0 && N2 - N1 > 1)
            {
                double q = Quantile - ((N2 - N1 - 1) * (Q3 - Quantile) / (N3 - N2) + (N3 - N2 + 1) * (Quantile - Q1) / (N2 - N1)) / (N3 - N1);
                Quantile = Q1 < q && q < Q3 ? q : Quantile + (Q1 - Quantile) / (N2 - N1);
                N2--;
            }
            s = (N - 1) * (1 + p) * 0.5 - N3;
            if (s >= 1.0 && N - N3 > 2)
            {
                double q = Q3 + ((N3 - N2 + 1) * (Q4 - Q3) / (N - N3 - 1) + (N - N3 - 2) * (Q3 - Quantile) / (N3 - N2)) / (N - N2 - 1);
                Q3 = Quantile < q && q < Q4 ? q : Q3 + (Q4 - Q3) / (N - N3 - 1);
                N3++;
            }
            else if (s <= -1.0 && N3 - N2 > 1)
            {
                double q = Q3 - ((N3 - N2 - 1) * (Q4 - Q3) / (N - N3 - 1) + (N - N3) * (Q3 - Quantile) / (N3 - N2)) / (N - N2 - 1);
                Q3 = Quantile < q && q < Q4 ? q : Q3 + (Quantile - Q3) / (N3 - N2);
                N3--;
            }
        }
        else if (N == 5)
        {
            if (s > Q4)
            {
                Q0 = Q1;
                Q1 = Quantile;
                Quantile = Q3;
                Q3 = Q4;
                Q4 = s;
            }
            else if (s > Q3)
            {
                Q0 = Q1;
                Q1 = Quantile;
                Quantile = Q3;
                Q3 = s;
            }
            else if (s > Quantile)
            {
                Q0 = Q1;
                Q1 = Quantile;
                Quantile = s;
            }
            else if (s > Q1)
            {
                Q0 = Q1;
                Q1 = s;
            }
            else Q0 = s;
        }
        else if (N == 4)
        {
            if (s < Q1)
            {
                Q4 = Q3;
                Q3 = Quantile;
                Quantile = Q1;
                Q1 = s;
            }
            else if (s < Quantile)
            {
                Q4 = Q3;
                Q3 = Quantile;
                Quantile = s;
            }
            else if (s < Q3)
            {
                Q4 = Q3;
                Q3 = s;
            }
            else Q4 = s;
        }
        else if (N == 3)
        {
            if (s < Q1)
            {
                Q3 = Quantile;
                Quantile = Q1;
                Q1 = s;
            }
            else if (s < Quantile)
            {
                Q3 = Quantile;
                Quantile = s;
            }
            else Q3 = s;
        }
        else if (N == 2)
        {
            if (s > Quantile)
            {
                Q1 = Quantile;
                Quantile = s;
            }
            else Q1 = s;
        }
        else Quantile = s;
    }
    /// <summary>Combine another QuartileEstimator.</summary>
    /// <param name="qe">QuartileEstimator</param>
    public void Add(QuantileEstimator qe)
    {
        N += qe.N;
        N1 += qe.N1;
        N2 += qe.N2;
        N3 += qe.N3;
        if (qe.Q0 < Q0) Q0 = qe.Q0;
        if (qe.Q4 > Q4) Q4 = qe.Q4;
        var w = (double)qe.N / N;
        Q1 += (qe.Q1 - Q1) * w;
        Quantile += (qe.Quantile - Quantile) * w;
        Q3 += (qe.Q3 - Q3) * w;
    }
    /// <summary>Combine two QuartileEstimators.</summary>
    /// <param name="a">First QuartileEstimator</param>
    /// <param name="b">Second QuartileEstimator</param>
    public static QuantileEstimator operator +(QuantileEstimator a, QuantileEstimator b)
    {
        var w = (double)b.N / (a.N + b.N);
        return new QuantileEstimator(a.p)
        {
            N = a.N + b.N,
            N1 = a.N1 + b.N1,
            N2 = a.N2 + b.N2,
            N3 = a.N3 + b.N3,
            Q0 = Math.Min(a.Q0, b.Q0),
            Q1 = a.Q1 + (b.Q1 - a.Q1) * w,
            Quantile = a.Quantile + (b.Quantile - a.Quantile) * w,
            Q3 = a.Q3 + (b.Q3 - a.Q3) * w,
            Q4 = Math.Max(a.Q4, b.Q4),
        };
    }
}