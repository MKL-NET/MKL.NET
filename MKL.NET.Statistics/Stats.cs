using System;

namespace MKLNET
{
    public static class Stats
    {
        public static double Norm2(double[] x) => Blas.nrm2(x);
    }
}