using System;
using System.Runtime.CompilerServices;

namespace MKLNET;

/// <summary>A median and quartile estimator.</summary>
public class QuartileEstimator
{
    /// <summary>The number of sample observations.</summary>
    public int N;
    int n1 = 2, n2 = 3, n3 = 4;
    /// <summary>The minimum or 0th percentile.</summary>
    public double Q0;
    /// <summary>The first, lower quartile, or 25th percentile.</summary>
    public double Q1;
    /// <summary>The second quartile, median, or 50th percentile.</summary>
    public double Q2;
    /// <summary>The third, upper quartile, or 75th percentile.</summary>
    public double Q3;
    /// <summary>The maximum or 100th percentile.</summary>
    public double Q4;
    /// <summary>The minimum or 0th percentile.</summary>
    public double Minimum => Q0;
    /// <summary>The first, lower quartile, or 25th percentile.</summary>
    public double LowerQuartile => Q1;
    /// <summary>The second quartile, median, or 50th percentile.</summary>
    public double Median => Q2;
    /// <summary>The third, upper quartile, or 75th percentile.</summary>
    public double UpperQuartile => Q3;
    /// <summary>The maximum or 100th percentile.</summary>
    public double Maximum => Q4;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    static void Adjust(double p, int N, int n1, ref int n2, int n3, double q1, ref double q2, double q3)
    {
        double d = 1 - n2 + (N - 1) * p;
        if ((d >= 1.0 && n3 - n2 > 1) || (d <= -1.0 && n1 - n2 < -1))
        {
            int ds = Math.Sign(d);
            double q = q2 + (double)ds / (n3 - n1) * ((n2 - n1 + ds) * (q3 - q2) / (n3 - n2) + (n3 - n2 - ds) * (q2 - q1) / (n2 - n1));
            q = q1 < q && q < q3 ? q :
                ds == 1 ? q2 + (q3 - q2) / (n3 - n2) :
                q2 - (q1 - q2) / (n1 - n2);
            n2 += ds;
            q2 = q;
        }
    }
    /// <summary>Add a sample observation.</summary>
    /// <param name="s">Sample observation value.</param>
    public void Add(double s)
    {
        if (++N > 5)
        {
            if (s < Q0) Q0 = s;
            if (s < Q1) n1++;
            if (s < Q2) n2++;
            if (s < Q3) n3++;
            if (s > Q4) Q4 = s;
            Adjust(0.25, N, 1, ref n1, n2, Q0, ref Q1, Q2);
            Adjust(0.50, N, n1, ref n2, n3, Q1, ref Q2, Q3);
            Adjust(0.75, N, n2, ref n3, N, Q2, ref Q3, Q4);
        }
        else if (N == 5)
        {
            if (s > Q4)
            {
                Q0 = Q1;
                Q1 = Q2;
                Q2 = Q3;
                Q3 = Q4;
                Q4 = s;
            }
            else if (s > Q3)
            {
                Q0 = Q1;
                Q1 = Q2;
                Q2 = Q3;
                Q3 = s;
            }
            else if (s > Q2)
            {
                Q0 = Q1;
                Q1 = Q2;
                Q2 = s;
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
                Q3 = Q2;
                Q2 = Q1;
                Q1 = s;
            }
            else if (s < Q2)
            {
                Q4 = Q3;
                Q3 = Q2;
                Q2 = s;
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
                Q3 = Q2;
                Q2 = Q1;
                Q1 = s;
            }
            else if (s < Q2)
            {
                Q3 = Q2;
                Q2 = s;
            }
            else Q3 = s;
        }
        else if (N == 2)
        {
            if (s > Q2)
            {
                Q1 = Q2;
                Q2 = s;
            }
            else Q1 = s;
        }
        else Q2 = s;
    }
    /// <summary>Combine another QuartileEstimator.</summary>
    /// <param name="qe">QuartileEstimator</param>
    public void Add(QuartileEstimator qe)
    {
        N += qe.N;
        n1 += qe.n1;
        n2 += qe.n2;
        n3 += qe.n3;
        if (qe.Q0 < Q0) Q0 = qe.Q0;
        if (qe.Q4 > Q4) Q4 = qe.Q4;
        var w = (double)qe.N / N;
        Q1 += (qe.Q1 - Q1) * w;
        Q2 += (qe.Q2 - Q2) * w;
        Q3 += (qe.Q3 - Q3) * w;
    }
    /// <summary>Combine two QuartileEstimators.</summary>
    /// <param name="a">First QuartileEstimator</param>
    /// <param name="b">Second QuartileEstimator</param>
    public static QuartileEstimator operator +(QuartileEstimator a, QuartileEstimator b)
    {
        var w = (double)b.N / (a.N + b.N);
        return new QuartileEstimator
        {
            N = a.N + b.N,
            n1 = a.n1 + b.n1,
            n2 = a.n2 + b.n2,
            n3 = a.n3 + b.n3,
            Q0 = Math.Min(a.Q0, b.Q0),
            Q1 = a.Q1 + (b.Q1 - a.Q1) * w,
            Q2 = a.Q2 + (b.Q2 - a.Q2) * w,
            Q3 = a.Q3 + (b.Q3 - a.Q3) * w,
            Q4 = Math.Min(a.Q4, b.Q4),
        };
    }
}