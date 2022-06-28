// Copyright 2022 Anthony Lloyd
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

namespace MKLNET;

/// <summary>A histogram estimator.</summary>
public class HistogramEstimator
{
    /// <summary>The number of observations less than or equal at this histogram point.</summary>
    public readonly int[] N;
    /// <summary>The value estimate at this histogram point.</summary>
    public readonly double[] Q;

    /// <summary>A histogram estimator.</summary>
    /// <param name="n">The number of histogram point including min and max.</param>
    public HistogramEstimator(int n)
    {
        N = new int[n];
        Q = new double[n];
    }

    /// <summary>Add a sample observation.</summary>
    /// <param name="s">Sample observation value.</param>
    public void Add(double s)
    {
        var n = N; var q = Q;
        if (n[n.Length - 1] < n.Length)
        {
            q[n[n.Length - 1]++] = s;
            if (n[n.Length - 1] == n.Length)
            {
                for (int i = 0; i < n.Length - 1; i++) n[i] = i + 1;
                System.Array.Sort(q);
            }
            return;
        }

        if (s <= q[0])
        {
            if (s == q[0])
            {
                n[0]++;
            }
            else
            {
                q[0] = s;
                n[0] = 1;
            }
            for (int i = 1; i < n.Length; i++) n[i]++;
        }
        else if (s > q[q.Length - 1])
        {
            q[q.Length - 1] = s;
            n[n.Length - 1]++;
        }
        else
        {
            n[n.Length - 1]++;
            for (int i = n.Length - 2; i > 0 && s <= q[i]; i--) n[i]++;
        }

        for (int i = 1; i < n.Length - 1; i++)
        {
            var d = (n[n.Length - 1] - n[0]) * (double)i / (n.Length - 1) + n[0] - n[i];
            if (d >= 1.0 && n[i + 1] - n[i] > 1)
            {
                var h = n[i + 1] - n[i];
                var delta = (q[i + 1] - q[i]) / h;
                var d1 = PchipDerivative(n[i] - n[i - 1], (q[i] - q[i - 1]) / (n[i] - n[i - 1]), h, delta);
                var d2 = i == n.Length - 2
                    ? PchipDerivativeEnd(h, delta, n[i] - n[i - 1], (q[i] - q[i - 1]) / (n[i] - n[i - 1]))
                    : PchipDerivative(h, delta, n[i + 2] - n[i + 1], (q[i + 2] - q[i + 1]) / (n[i + 2] - n[i + 1]));
                q[i] += HermiteInterpolationOne(h, delta, d1, d2);
                n[i]++;
            }
            else if (d <= -1.0 && n[i] - n[i - 1] > 1)
            {
                var h = n[i] - n[i - 1];
                var delta = (q[i] - q[i - 1]) / h;
                var d1 = i == 1
                    ? PchipDerivativeEnd(h, delta, n[i + 1] - n[i], (q[i + 1] - q[i]) / (n[i + 1] - n[i]))
                    : PchipDerivative(n[i - 1] - n[i - 2], (q[i - 1] - q[i - 2]) / (n[i - 1] - n[i - 2]), h, delta);
                var d2 = PchipDerivative(h, delta, n[i + 1] - n[i], (q[i + 1] - q[i]) / (n[i + 1] - n[i]));
                q[i] += HermiteInterpolationOne(h, -delta, -d2, -d1);
                n[i]--;
            }
        }
    }

    [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
    static double PchipDerivative(int h1, double delta1, int h2, double delta2)
    {
        return (h1 + h2) * 3 * delta1 * delta2 / ((h1 * 2 + h2) * delta1 + (h2 * 2 + h1) * delta2);
    }

    [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
    static double PchipDerivativeEnd(int h1, double delta1, int h2, double delta2)
    {
        double d = (delta1 - delta2) * h1 / (h1 + h2) + delta1;
        return d < 0 ? 0 : d;
    }

    [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
    static double HermiteInterpolationOne(int h1, double delta1, double d1, double d2)
    {
        return ((d1 + d2 - delta1 * 2) / h1 + delta1 * 3 - d1 * 2 - d2) / h1 + d1;
    }

    /// <summary>Combine another HistogramEstimator.</summary>
    /// <param name="e">HistogramEstimator</param>
    public void Add(HistogramEstimator e)
    {
        for (int i = 1; i < N.Length; i++)
            N[i] += e.N[i];
        if (e.Q[0] == Q[0])
        {
            N[0] += e.N[0];
        }
        else if (e.Q[0] < Q[0])
        {
            Q[0] = e.Q[0];
            N[0] = e.N[0];
        }
        if (e.Q[e.Q.Length - 1] > Q[Q.Length - 1]) Q[Q.Length - 1] = e.Q[e.Q.Length - 1];
        var w = (double)e.N[e.N.Length - 1] / N[N.Length - 1];
        for (int i = 1; i < Q.Length - 1; i++)
            Q[i] += (e.Q[i] - Q[i]) * w;
    }

    /// <summary>Combine two HistogramEstimators.</summary>
    /// <param name="a">First HistogramEstimator</param>
    /// <param name="b">Second HistogramEstimator</param>
    public static HistogramEstimator operator +(HistogramEstimator a, HistogramEstimator b)
    {
        var e = new HistogramEstimator(a.N.Length);
        for (int i = 1; i < e.N.Length; i++)
            e.N[i] = a.N[i] + b.N[i];
        if (a.Q[0] == b.Q[0])
        {
            e.Q[0] = a.Q[0];
            e.N[0] = a.N[0] + b.N[0];
        }
        else if (a.Q[0] < b.Q[0])
        {
            e.Q[0] = a.Q[0];
            e.N[0] = a.N[0];
        }
        else
        {
            e.Q[0] = b.Q[0];
            e.N[0] = b.N[0];
        }
        e.Q[e.Q.Length - 1] = a.Q[a.Q.Length - 1] > b.Q[b.Q.Length - 1] ? a.Q[a.Q.Length - 1] : b.Q[b.Q.Length - 1];
        var w = (double)b.N[b.N.Length - 1] / (a.N[a.N.Length - 1] + b.N[b.N.Length - 1]);
        for (int i = 1; i < e.Q.Length - 1; i++)
            e.Q[i] += a.Q[i] + (b.Q[i] - a.Q[i]) * w;
        return e;
    }
}