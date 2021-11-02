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
    /// <summary>A median and quartile estimator.</summary>
    public class QuartileEstimator
    {
        /// <summary>The number of sample observations.</summary>
        public int N;
        /// <summary>The number of observations less than or equal to the quantile.</summary>
        public int N0 = 1, N1 = 2, N2 = 3, N3 = 4;
        /// <summary>The minimum or 0th percentile value.</summary>
        public double Q0;
        /// <summary>The first, lower quartile, or 25th percentile value.</summary>
        public double Q1;
        /// <summary>The second quartile, median, or 50th percentile value.</summary>
        public double Q2;
        /// <summary>The third, upper quartile, or 75th percentile value.</summary>
        public double Q3;
        /// <summary>The maximum or 100th percentile value.</summary>
        public double Q4;
        /// <summary>The minimum or 0th percentile value.</summary>
        public double Minimum => Q0;
        /// <summary>The first, lower quartile, or 25th percentile value.</summary>
        public double LowerQuartile => Q1;
        /// <summary>The second quartile, median, or 50th percentile value.</summary>
        public double Median => Q2;
        /// <summary>The third, upper quartile, or 75th percentile value.</summary>
        public double UpperQuartile => Q3;
        /// <summary>The maximum or 100th percentile value.</summary>
        public double Maximum => Q4;

        /// <summary>Add a sample observation.</summary>
        /// <param name="s">Sample observation value.</param>
        public void Add(double s)
        {
            N++;
            if (N > 5)
            {
                if (s <= Q3)
                {
                    N3++;
                    if (s <= Q2)
                    {
                        N2++;
                        if (s <= Q1)
                        {
                            N1++;
                            if (s <= Q0)
                            {
                                if (s == Q0)
                                {
                                    N0++;
                                }
                                else
                                {
                                    Q0 = s;
                                    N0 = 1;
                                }
                            }
                        }
                    }
                }
                else if (s > Q4) Q4 = s;
                int h;
                double delta, d1, d2;
                s = (N - 1) * 0.25 + 1 - N1;
                if (s >= 1.0 && N2 - N1 > 1)
                {
                    h = N2 - N1;
                    delta = (Q2 - Q1) / h;
                    d1 = PchipDerivative(N1 - N0, (Q1 - Q0) / (N1 - N0), h, delta);
                    d2 = PchipDerivative(h, delta, N3 - N2, (Q3 - Q2) / (N3 - N2));
                    Q1 += HermiteInterpolationOne(h, delta, d1, d2);
                    N1++;
                }
                else if (s <= -1.0 && N1 - N0 > 1)
                {
                    h = N1 - N0;
                    delta = (Q1 - Q0) / h;
                    d1 = PchipDerivativeEnd(h, delta, N2 - N1, (Q2 - Q1) / (N2 - N1));
                    d2 = PchipDerivative(h, delta, N2 - N1, (Q2 - Q1) / (N2 - N1));
                    Q1 += HermiteInterpolationOne(h, -delta, -d2, -d1);
                    N1--;
                }
                s = (N - 1) * 0.50 + 1 - N2;
                if (s >= 1.0 && N3 - N2 > 1)
                {
                    h = N3 - N2;
                    delta = (Q3 - Q2) / h;
                    d1 = PchipDerivative(N2 - N1, (Q2 - Q1) / (N2 - N1), h, delta);
                    d2 = PchipDerivative(h, delta, N - N3, (Q4 - Q3) / (N - N3));
                    Q2 += HermiteInterpolationOne(h, delta, d1, d2);
                    N2++;
                }
                else if (s <= -1.0 && N2 - N1 > 1)
                {
                    h = N2 - N1;
                    delta = (Q2 - Q1) / h;
                    d1 = PchipDerivative(N1 - N0, (Q1 - Q0) / (N1 - N0), h, delta);
                    d2 = PchipDerivative(h, delta, N3 - N2, (Q3 - Q2) / (N3 - N2));
                    Q2 += HermiteInterpolationOne(h, -delta, -d2, -d1);
                    N2--;
                }
                s = (N - 1) * 0.75 + 1 - N3;
                if (s >= 1.0 && N - N3 > 1)
                {
                    h = N - N3;
                    delta = (Q4 - Q3) / h;
                    d1 = PchipDerivative(N3 - N2, (Q3 - Q2) / (N3 - N2), h, delta);
                    d2 = PchipDerivativeEnd(h, delta, N3 - N2, (Q3 - Q2) / (N3 - N2));
                    Q3 += HermiteInterpolationOne(h, delta, d1, d2);
                    N3++;
                }
                else if (s <= -1.0 && N3 - N2 > 1)
                {
                    h = N3 - N2;
                    delta = (Q3 - Q2) / h;
                    d1 = PchipDerivative(N2 - N1, (Q2 - Q1) / (N2 - N1), h, delta);
                    d2 = PchipDerivative(h, delta, N - N3, (Q4 - Q3) / (N - N3));
                    Q3 += HermiteInterpolationOne(h, -delta, -d2, -d1);
                    N3--;
                }
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

        /// <summary>Combine another QuartileEstimator.</summary>
        /// <param name="e">QuartileEstimator</param>
        public void Add(QuartileEstimator e)
        {
            N += e.N;
            N1 += e.N1;
            N2 += e.N2;
            N3 += e.N3;
            if (e.Q0 == Q0)
            {
                N0 += e.N0;
            }
            else if (e.Q0 < Q0)
            {
                Q0 = e.Q0;
                N0 = e.N0;
            }
            if (e.Q4 > Q4) Q4 = e.Q4;
            var w = (double)e.N / N;
            Q1 += (e.Q1 - Q1) * w;
            Q2 += (e.Q2 - Q2) * w;
            Q3 += (e.Q3 - Q3) * w;
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
                N0 = a.Q0 == b.Q0 ? a.N0 + b.N0
                   : a.Q0 < b.Q0 ? a.N0 : b.N0,
                N1 = a.N1 + b.N1,
                N2 = a.N2 + b.N2,
                N3 = a.N3 + b.N3,
                Q0 = a.Q0 < b.Q0 ? a.Q0 : b.Q0,
                Q1 = a.Q1 + (b.Q1 - a.Q1) * w,
                Q2 = a.Q2 + (b.Q2 - a.Q2) * w,
                Q3 = a.Q3 + (b.Q3 - a.Q3) * w,
                Q4 = a.Q4 > b.Q4 ? a.Q4 : b.Q4,
            };
        }
    }
}