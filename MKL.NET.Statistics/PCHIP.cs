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

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace MKLNET
{
    public static class PCHIP
    {
        public static double HermiteInterpolation(double y0, double d0, double y1, double d1, double h, double s)
        {
            var delta = (y1 - y0) / h;
            var c = (3 * delta - 2 * d0 - d1) / h;
            var b = (d0 + d1 - 2 * delta) / h / h;
            return y0 + s * (d0 + s * (c + s * b));
        }

        public static double HermiteInterpolationOne(double y0, double d0, double y1, double d1, double h)
        {
            var delta = (y1 - y0) / h;
            return ((d0 + d1 - 2 * delta) / h + 3 * delta - 2 * d0 - d1) / h + y0 + d0;
        }

        public static double HarmonicAverageWeight(double delta0, double w0, double delta1, double w1)
        {
            return (w0 + w1) / (w0 / delta0 + w1 / delta1);
        }

        public static double Derivative(double h0, double delta0, double h1, double delta1)
        {
            return (h0 + h1) / ((2 * h1 + h0) / delta0 + (2 * h0 + h1) / delta1) * 3;
        }

        public static double DerivativeEnd(double h0, double delta0, double h1, double delta1)
        {
            return ((2 * h0 + h1) * delta0 - h0 * delta1) / (h0 + h1);
        }
    }
}

#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member