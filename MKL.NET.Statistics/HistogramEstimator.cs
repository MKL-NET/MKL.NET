// Copyright 2021 Anthony Lloyd
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

namespace MKLNET
{
    /// <summary>A histogram estimator.</summary>
    public class HistogramEstimator
    {
        /// <summary>The cumulative number of observations below this histgram point inclusive.</summary>
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
            if (N[N.Length - 1] < N.Length)
            {
                Q[N[N.Length - 1]++] = s;
                if (N[N.Length - 1] == N.Length)
                {
                    for (int i = 0; i < N.Length - 1; i++) N[i] = i + 1;
                    System.Array.Sort(Q);
                }
                return;
            }

            if (s <= Q[0])
            {
                if (s == Q[0])
                {
                    N[0]++;
                }
                else
                {
                    Q[0] = s;
                    N[0] = 1;
                }
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
                for (int i = N.Length - 2; i > 0 && s <= Q[i]; i--) N[i]++;
            }

            for (int i = 1; i < N.Length - 1; i++)
            {
                var d = (N[N.Length - 1] - 1) * (double)i / (N.Length - 1) + 1 - N[i];
                if (d >= 1.0 && N[i + 1] - N[i] > 1)
                {
                    var h = N[i + 1] - N[i];
                    var delta = (Q[i + 1] - Q[i]) / h;
                    if (i == N.Length - 2)
                    {
                        var d1 = Derivative(N[i] - N[i - 1], (Q[i] - Q[i - 1]) / (N[i] - N[i - 1]), h, delta);
                        var d2 = DerivativeEnd(h, delta, N[i] - N[i - 1], (Q[i] - Q[i - 1]) / (N[i] - N[i - 1]));
                        Q[i] = HermiteInterpolationOne(Q[i], d1, d2, h, delta);
                    }
                    else
                    {
                        var d1 = Derivative(N[i] - N[i - 1], (Q[i] - Q[i - 1]) / (N[i] - N[i - 1]), h, delta);
                        var d2 = Derivative(h, delta, N[i + 2] - N[i + 1], (Q[i + 2] - Q[i + 1]) / (N[i + 2] - N[i + 1]));
                        Q[i] = HermiteInterpolationOne(Q[i], d1, d2, h, delta);
                    }
                    N[i]++;
                }
                else if (d <= -1.0 && N[i] - N[i - 1] > 1)
                {
                    var h = N[i] - N[i - 1];
                    var delta = (Q[i] - Q[i - 1]) / h;
                    if (i == 1)
                    {
                        var d1 = DerivativeEnd(h, delta, N[i + 1] - N[i], (Q[i + 1] - Q[i]) / (N[i + 1] - N[i]));
                        var d2 = Derivative(h, delta, N[i + 1] - N[i], (Q[i + 1] - Q[i]) / (N[i + 1] - N[i]));
                        Q[i] = HermiteInterpolationOne(Q[i], -d2, -d1, h, -delta);
                    }
                    else
                    {
                        var d1 = Derivative(N[i - 1] - N[i - 2], (Q[i - 1] - Q[i - 2]) / (N[i - 1] - N[i - 2]), h, delta);
                        var d2 = Derivative(h, delta, N[i + 1] - N[i], (Q[i + 1] - Q[i]) / (N[i + 1] - N[i]));
                        Q[i] = HermiteInterpolationOne(Q[i], -d2, -d1, h, -delta);
                    }
                    N[i]--;
                }
            }
        }

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        static double Derivative(int h1, double delta1, int h2, double delta2)
        {
            return (h1 + h2) * 3 * delta1 * delta2 / ((h1 * 2 + h2) * delta1 + (h2 * 2 + h1) * delta2);
        }

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        static double DerivativeEnd(int h1, double delta1, int h2, double delta2)
        {
            double d = (delta1 - delta2) * h1 / (h1 + h2) + delta1;
            return d < 0.0 ? 0.0
                 : d > 3 * delta1 ? 3 * delta1
                 : d;
        }

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        static double HermiteInterpolationOne(double y1, double d1, double d2, int h1, double delta1)
        {
            return ((d1 + d2 - delta1 * 2) / h1 + delta1 * 3 - d1 * 2 - d2) / h1 + y1 + d1;
        }
    }
}