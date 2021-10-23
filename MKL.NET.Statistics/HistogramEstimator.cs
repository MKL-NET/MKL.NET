using System;

namespace MKLNET;

/// <summary></summary>
public class HistogramEstimator
{
    /// <summary>
    /// 
    /// </summary>
    public readonly int[] N;
    /// <summary>
    /// 
    /// </summary>
    public readonly double[] Q;
    /// <summary></summary>
    /// <param name="n"></param>
    public HistogramEstimator(int n)
    {
        N = new int[n];
        Q = new double[n];
    }
    /// <summary></summary>
    /// <param name="s"></param>
    public void Add(double s)
    {
        if (N[N.Length - 1] < N.Length)
        {
            Q[N[N.Length - 1]++] = s;
            if (N[N.Length - 1] == N.Length)
            {
                for (int i = 0; i < N.Length - 1; i++) N[i] = i + 1;
                Array.Sort(Q);
            }
            return;
        }

        if (s < Q[0])
        {
            Q[0] = s;
            for (int i = 1; i < N.Length; i++) N[i]++;
        }
        else if (s > Q[Q.Length - 1])
        {
            Q[Q.Length - 1] = s;
            N[N.Length - 1]++;
        }
        else
        {
            N[N.Length - 1]++;
            for (int i = N.Length - 2; i > 0 && s < Q[i]; i--) N[i]++;
        }

        for (int i = 1; i < N.Length - 1; i++)
        {
            var d = (N[N.Length - 1] - 1) * (double)i / (N.Length - 1) + 1 - N[i];
            if (d >= 1.0 && N[i + 1] - N[i] > 1)
            {
                var q = Q[i] + ((N[i] - N[i - 1] + 1) * (Q[i + 1] - Q[i]) / (N[i + 1] - N[i]) + (N[i + 1] - N[i] - 1) * (Q[i] - Q[i - 1]) / (N[i] - N[i - 1])) / (N[i + 1] - N[i - 1]);
                Q[i] = Q[i - 1] < q && q < Q[i + 1] ? q : Q[i] + (Q[i + 1] - Q[i]) / (N[i + 1] - N[i]);
                N[i]++;
            }
            else if (d <= -1.0 && N[i] - N[i - 1] > 1)
            {
                var q = Q[i] - ((N[i] - N[i - 1] - 1) * (Q[i + 1] - Q[i]) / (N[i + 1] - N[i]) + (N[i + 1] - N[i] + 1) * (Q[i] - Q[i - 1]) / (N[i] - N[i - 1])) / (N[i + 1] - N[i - 1]);
                Q[i] = Q[i - 1] < q && q < Q[i + 1] ? q : Q[i] + (Q[i - 1] - Q[i]) / (N[i] - N[i - 1]);
                N[i]--;
            }
        }
    }
}