// Copyright(c) 2020 Andrey Akinshin
// Copyright (c) 2013–2020.NET Foundation and contributors
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
// The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

namespace TestsCSharp;

using System;

public class P2QuantileEstimatorOriginal
{
    private readonly double p;
    private readonly int[] n = new int[5]; // marker positions
    private readonly double[] ns = new double[5]; // desired marker positions
    private readonly double[] dns = new double[5];
    private readonly double[] q = new double[5]; // marker heights
    private int count;

    public P2QuantileEstimatorOriginal(double probability)
    {
        p = probability;
    }

    public void AddValue(double x)
    {
        if (count < 5)
        {
            q[count++] = x;
            if (count == 5)
            {
                Array.Sort(q);

                for (int i = 0; i < 5; i++)
                    n[i] = i;

                ns[0] = 0;
                ns[1] = 2 * p;
                ns[2] = 4 * p;
                ns[3] = 2 + 2 * p;
                ns[4] = 4;

                dns[0] = 0;
                dns[1] = p / 2;
                dns[2] = p;
                dns[3] = (1 + p) / 2;
                dns[4] = 1;
            }

            return;
        }

        int k;
        if (x < q[0])
        {
            q[0] = x;
            k = 0;
        }
        else if (x < q[1])
            k = 0;
        else if (x < q[2])
            k = 1;
        else if (x < q[3])
            k = 2;
        else if (x < q[4])
            k = 3;
        else
        {
            q[4] = x;
            k = 3;
        }

        for (int i = k + 1; i < 5; i++)
            n[i]++;

        for (int i = 0; i < 5; i++)
            ns[i] += dns[i];

        for (int i = 1; i <= 3; i++)
        {
            double d = ns[i] - n[i];
            if (d >= 1 && n[i + 1] - n[i] > 1 || d <= -1 && n[i - 1] - n[i] < -1)
            {
                int dInt = Math.Sign(d);
                double qs = Parabolic(i, dInt);
                if (q[i - 1] < qs && qs < q[i + 1])
                    q[i] = qs;
                else
                    q[i] = Linear(i, dInt);
                n[i] += dInt;
            }
        }

        count++;
    }

    private double Parabolic(int i, double d)
    {
        if(d == 1.0)
            return q[i] +  (
                (n[i] - n[i - 1] + 1) * (q[i + 1] - q[i]) / (n[i + 1] - n[i]) +
                (n[i + 1] - n[i] - 1) * (q[i] - q[i - 1]) / (n[i] - n[i - 1])
            ) / (n[i + 1] - n[i - 1]);
        else
            return q[i] - (
                (n[i] - n[i - 1] - 1) * (q[i + 1] - q[i]) / (n[i + 1] - n[i]) +
                (n[i + 1] - n[i] + 1) * (q[i] - q[i - 1]) / (n[i] - n[i - 1])
            ) / (n[i + 1] - n[i - 1]);
    }

    private double Linear(int i, int d)
    {
        return q[i] + d * (q[i + d] - q[i]) / (n[i + d] - n[i]);
    }

    public double GetQuantile()
    {
        if (count <= 5)
        {
            Array.Sort(q, 0, count);
            int index = (int)Math.Round((count - 1) * p);
            return q[index];
        }

        return q[2];
    }
}