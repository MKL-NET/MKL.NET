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
        /// <summary>
        /// 
        /// </summary>
        public int N0 = 1, N1 = 2, N2 = 3, N3 = 4;
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
        /// <summary>Add a sample observation.</summary>
        /// <param name="s">Sample observation value.</param>
        public void Add(double s)
        {
            if (++N > 5)
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

                s = (N - 1) * 0.25 + 1 - N1;
                if (s >= 1.0 && N2 - N1 > 1)
                {
                    double q = Q1 + ((N1 - N0 + 1) * (Q2 - Q1) / (N2 - N1) + (N2 - N1 - 1) * (Q1 - Q0) / (N1 - N0)) / (N2 - N0);
                    Q1 = Q0 < q && q < Q2 ? q : Q1 + (Q2 - Q1) / (N2 - N1);
                    N1++;
                }
                else if (s <= -1.0 && N1 - N0 > 1)
                {
                    double q = Q1 - ((N1 - N0 - 1) * (Q2 - Q1) / (N2 - N1) + (N2 - N1 + 1) * (Q1 - Q0) / (N1 - N0)) / (N2 - N0);
                    Q1 = Q0 < q && q < Q2 ? q : Q1 + (Q0 - Q1) / (N1 - N0);
                    N1--;
                }
                s = (N - 1) * 0.50 + 1 - N2;
                if (s >= 1.0 && N3 - N2 > 1)
                {
                    double q = Q2 + ((N2 - N1 + 1) * (Q3 - Q2) / (N3 - N2) + (N3 - N2 - 1) * (Q2 - Q1) / (N2 - N1)) / (N3 - N1);
                    Q2 = Q1 < q && q < Q3 ? q : Q2 + (Q3 - Q2) / (N3 - N2);
                    N2++;
                }
                else if (s <= -1.0 && N2 - N1 > 1)
                {
                    double q = Q2 - ((N2 - N1 - 1) * (Q3 - Q2) / (N3 - N2) + (N3 - N2 + 1) * (Q2 - Q1) / (N2 - N1)) / (N3 - N1);
                    Q2 = Q1 < q && q < Q3 ? q : Q2 + (Q1 - Q2) / (N2 - N1);
                    N2--;
                }
                s = (N - 1) * 0.75 + 1 - N3;
                if (s >= 1.0 && N - N3 > 1)
                {
                    double q = Q3 + ((N3 - N2 + 1) * (Q4 - Q3) / (N - N3) + (N - N3 - 1) * (Q3 - Q2) / (N3 - N2)) / (N - N2);
                    Q3 = Q2 < q && q < Q4 ? q : Q3 + (Q4 - Q3) / (N - N3);
                    N3++;
                }
                else if (s <= -1.0 && N3 - N2 > 1)
                {
                    double q = Q3 - ((N3 - N2 - 1) * (Q4 - Q3) / (N - N3) + (N - N3 + 1) * (Q3 - Q2) / (N3 - N2)) / (N - N2);
                    Q3 = Q2 < q && q < Q4 ? q : Q3 + (Q2 - Q3) / (N3 - N2);
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
        /// <summary>Combine another QuartileEstimator.</summary>
        /// <param name="qe">QuartileEstimator</param>
        public void Add(QuartileEstimator qe)
        {
            N += qe.N;
            N1 += qe.N1;
            N2 += qe.N2;
            N3 += qe.N3;
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