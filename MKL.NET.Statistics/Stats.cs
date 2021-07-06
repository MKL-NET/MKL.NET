using System;

namespace MKLNET
{
    /// <summary>
    /// 
    /// </summary>
    public static class Stats
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static double Norm2(double[] x) => Blas.nrm2(x);
    }
}