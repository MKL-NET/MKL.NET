namespace MKLNET
{
    /// <summary>Statistics functions based on cross platform MKL.NET.</summary>
    public static class Stats
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static vectorT Mean(matrix data)
        {
            var r = new vectorT(data.Cols);
            ThrowHelper.Check(Vsl.Mean(data.Rows, data.Cols, data.Array, r.Array));
            return r;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="weight"></param>
        /// <returns></returns>
        public static vectorT Mean(matrix data, vector weight)
        {
            var r = new vectorT(data.Cols);
            ThrowHelper.Check(Vsl.MeanWeighted(data.Rows, data.Cols, data.Array, weight.Array, r.Array));
            return r;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static vectorT Median(matrix data)
        {
            var r = new vectorT(data.Cols);
            ThrowHelper.Check(Vsl.Median(data.Rows, data.Cols, data.Array, r.Array));
            return r;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="weight"></param>
        /// <returns></returns>
        public static vectorT Median(matrix data, vector weight)
        {
            var r = new vectorT(data.Cols);
            ThrowHelper.Check(Vsl.MedianWeighted(data.Rows, data.Cols, data.Array, weight.Array, r.Array));
            return r;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static matrix MomentsRaw2(matrix data)
        {
            var moments = new matrix(2, data.Cols);
            ThrowHelper.Check(Vsl.MomentsRaw2(data.Rows, data.Cols, data.Array, moments.Array));
            return moments;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static matrix MomentsCentral2(matrix data)
        {
            var moments = new matrix(2, data.Cols);
            ThrowHelper.Check(Vsl.MomentsCentral2(data.Rows, data.Cols, data.Array, moments.Array));
            return moments;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="weight"></param>
        /// <returns></returns>
        public static matrix MomentsCentral2(matrix data, vector weight)
        {
            var moments = new matrix(2, data.Cols);
            ThrowHelper.Check(Vsl.MomentsCentral2Weighted(data.Rows, data.Cols, data.Array, weight.Array, moments.Array));
            return moments;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static matrix MomentsRaw3(matrix data)
        {
            var moments = new matrix(3, data.Cols);
            ThrowHelper.Check(Vsl.MomentsRaw3(data.Rows, data.Cols, data.Array, moments.Array));
            return moments;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="weight"></param>
        /// <returns></returns>
        public static matrix MomentsRaw3(matrix data, vector weight)
        {
            var moments = new matrix(3, data.Cols);
            ThrowHelper.Check(Vsl.MomentsRaw3Weighted(data.Rows, data.Cols, data.Array, weight.Array, moments.Array));
            return moments;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static matrix MomentsCentral3(matrix data)
        {
            var moments = new matrix(3, data.Cols);
            ThrowHelper.Check(Vsl.MomentsCentral3(data.Rows, data.Cols, data.Array, moments.Array));
            return moments;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="weight"></param>
        /// <returns></returns>
        public static matrix MomentsCentral3(matrix data, vector weight)
        {
            var moments = new matrix(3, data.Cols);
            ThrowHelper.Check(Vsl.MomentsCentral3Weighted(data.Rows, data.Cols, data.Array, weight.Array, moments.Array));
            return moments;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static matrix MomentsStandard3(matrix data)
        {
            var moments = new matrix(3, data.Cols);
            ThrowHelper.Check(Vsl.MomentsStandard3(data.Rows, data.Cols, data.Array, moments.Array));
            return moments;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="weight"></param>
        /// <returns></returns>
        public static matrix MomentsStandard3(matrix data, vector weight)
        {
            var moments = new matrix(3, data.Cols);
            ThrowHelper.Check(Vsl.MomentsStandard3Weighted(data.Rows, data.Cols, data.Array, weight.Array, moments.Array));
            return moments;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static matrix MomentsRaw4(matrix data)
        {
            var moments = new matrix(4, data.Cols);
            ThrowHelper.Check(Vsl.MomentsRaw4(data.Rows, data.Cols, data.Array, moments.Array));
            return moments;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="weight"></param>
        /// <returns></returns>
        public static matrix MomentsRaw4(matrix data, vector weight)
        {
            var moments = new matrix(4, data.Cols);
            ThrowHelper.Check(Vsl.MomentsRaw4Weighted(data.Rows, data.Cols, data.Array, weight.Array, moments.Array));
            return moments;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static matrix MomentsCentral4(matrix data)
        {
            var moments = new matrix(4, data.Cols);
            ThrowHelper.Check(Vsl.MomentsCentral4(data.Rows, data.Cols, data.Array, moments.Array));
            return moments;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="weight"></param>
        /// <returns></returns>
        public static matrix MomentsCentral4(matrix data, vector weight)
        {
            var moments = new matrix(4, data.Cols);
            ThrowHelper.Check(Vsl.MomentsCentral4Weighted(data.Rows, data.Cols, data.Array, weight.Array, moments.Array));
            return moments;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static matrix MomentsStandard4(matrix data)
        {
            var moments = new matrix(4, data.Cols);
            ThrowHelper.Check(Vsl.MomentsStandard4(data.Rows, data.Cols, data.Array, moments.Array));
            return moments;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="weight"></param>
        /// <returns></returns>
        public static matrix MomentsStandard4(matrix data, vector weight)
        {
            var moments = new matrix(4, data.Cols);
            ThrowHelper.Check(Vsl.MomentsStandard4Weighted(data.Rows, data.Cols, data.Array, weight.Array, moments.Array));
            return moments;
        }

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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="weight"></param>
        /// <returns></returns>
        public static matrix Quartiles(matrix data, vector weight)
        {
            var quants = new matrix(3, data.Cols);
            ThrowHelper.Check(Vsl.QuantilesWeighted(data.Rows, data.Cols, data.Array, weight.Array, quartiles, quants.Array));
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
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="weight"></param>
        /// <returns></returns>
        public static matrix QuartilesMinMax(matrix data, vector weight)
        {
            var quants = new matrix(5, data.Cols);
            ThrowHelper.Check(Vsl.QuantilesWeighted(data.Rows, data.Cols, data.Array, weight.Array, quartiles_minmax, quants.Array));
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
        /// <param name="weight"></param>
        /// <param name="quantiles"></param>
        /// <returns></returns>
        public static matrix Quantiles(matrix data, vector weight, double[] quantiles)
        {
            var quants = new matrix(quantiles.Length, data.Cols);
            ThrowHelper.Check(Vsl.QuantilesWeighted(data.Rows, data.Cols, data.Array, weight.Array, quantiles, quants.Array));
            return quants;
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