namespace MKLNET
{
    /// <summary>Statistics functions based on cross platform MKL.NET.</summary>
    public static class Stats
    {
        static readonly double[] quartiles = new[] { 0.25, 0.50, 0.75 };
        /// <summary>
        /// Calculates the quartiles on the columns of data. Q1 = 25%, Q2 = 50% (median), Q3 = 75%
        /// </summary>
        /// <param name="data">The data to calculate the quartiles of.</param>
        /// <returns>3 x data.Cols matrix of quartiles.</returns>
        public static matrix Quartiles(matrix data)
        {
            var quants = new matrix(3, data.Cols);
            ThrowHelper.Check(Vsl.Quantiles(data.Rows, data.Cols, data.Array, quartiles, quants.Array));
            return quants;
        }

        static readonly double[] quartiles_minmax = new[] { 0.00, 0.25, 0.50, 0.75, 1.00 };
        /// <summary>
        /// Calculates the quartiles plus min and max on the columns of data. Min = 0%, Q1 = 25%, Q2 = 50% (median), Q3 = 75%, Max = 100%
        /// </summary>
        /// <param name="data">The data to calculate the quartiles and min and max of.</param>
        /// <returns>5 x data.Cols matrix of quartiles.</returns>
        public static matrix QuartilesMinMax(matrix data)
        {
            var quants = new matrix(5, data.Cols);
            ThrowHelper.Check(Vsl.Quantiles(data.Rows, data.Cols, data.Array, quartiles_minmax, quants.Array));
            return quants;
        }


        /// <summary>
        /// Calculates the quantiles the columns of data.
        /// </summary>
        /// <param name="data">The data to calculate the quantiles of.</param>
        /// <param name="quantiles">The quantiles to calculate in the range 0.0 - 1.0.</param>
        /// <returns>quantiles.Length x data.Cols matrix of quantiles.</returns>
        public static matrix Quantiles(matrix data, double[] quantiles)
        {
            var quants = new matrix(quantiles.Length, data.Cols);
            ThrowHelper.Check(Vsl.Quantiles(data.Rows, data.Cols, data.Array, quantiles, quants.Array));
            return quants;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static (vectorT, vectorT) Moments(matrix data)
        {
            var mean = new vectorT(data.Cols);
            var mom2c = new vectorT(data.Cols);
            ThrowHelper.Check(Vsl.Moments(data.Rows, data.Cols, data.Array, mean.Array, mom2c.Array));
            return (mean, mom2c);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="mean"></param>
        /// <returns></returns>
        public static matrix Covariance(matrix data, out vectorT mean)
        {
            mean = new vectorT(data.Cols);
            var cov = new matrix(data.Cols, data.Cols);
            ThrowHelper.Check(Vsl.Covariance(data.Rows, data.Cols, data.Array, mean.Array, cov.Array));
            return cov;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="weight"></param>
        /// <param name="mean"></param>
        /// <returns></returns>
        public static matrix Covariance(matrix data, vector weight, out vectorT mean)
        {
            mean = new vectorT(data.Cols);
            var cov = new matrix(data.Cols, data.Cols);
            ThrowHelper.Check(Vsl.CovarianceWeighted(data.Rows, data.Cols, data.Array, weight.Array, mean.Array, cov.Array));
            return cov;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="mean"></param>
        /// <returns></returns>
        public static matrix Correlation(matrix data, out vectorT mean)
        {
            mean = new vectorT(data.Cols);
            var cor = new matrix(data.Cols, data.Cols);
            ThrowHelper.Check(Vsl.Correlation(data.Rows, data.Cols, data.Array, mean.Array, cor.Array));
            return cor;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="weight"></param>
        /// <param name="mean"></param>
        /// <returns></returns>
        public static matrix Correlation(matrix data, vector weight, out vectorT mean)
        {
            mean = new vectorT(data.Cols);
            var cor = new matrix(data.Cols, data.Cols);
            ThrowHelper.Check(Vsl.CorrelationWeighted(data.Rows, data.Cols, data.Array, weight.Array, mean.Array, cor.Array));
            return cor;
        }
    }
}