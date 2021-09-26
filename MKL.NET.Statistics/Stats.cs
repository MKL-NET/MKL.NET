namespace MKLNET
{
    /// <summary>Statistics functions based on cross platform MKL.NET.</summary>
    public static class Stats
    {
        /// <summary>
        /// Calculates the sum on the columns of data.
        /// </summary>
        /// <param name="data">The data columns to calculate on.</param>
        /// <returns>The sum vectorT.</returns>
        public static vectorT Sum(matrix data)
        {
            var r = new vectorT(data.Cols);
            ThrowHelper.Check(Vsl.Sum(data.Rows, data.Cols, data.Array, r.Array));
            return r;
        }

        /// <summary>
        /// Calculates the weighted sum on the columns of data.
        /// </summary>
        /// <param name="data">The data columns to calculate on.</param>
        /// <param name="weight">The weights to use on the data columns (must be length data.Rows).</param>
        /// <returns>The sum vectorT.</returns>
        public static vectorT Sum(matrix data, vector weight)
        {
            var r = new vectorT(data.Cols);
            ThrowHelper.Check(Vsl.SumWeighted(data.Rows, data.Cols, data.Array, weight.Array, r.Array));
            return r;
        }

        /// <summary>
        /// Calculates the sum and sum ^ 2 on the columns of data.
        /// </summary>
        /// <param name="data">The data columns to calculate on.</param>
        /// <returns>2 x data.Cols matrix.</returns>
        public static matrix Sum2(matrix data)
        {
            var r = new matrix(2, data.Cols);
            ThrowHelper.Check(Vsl.SumRaw2(data.Rows, data.Cols, data.Array, r.Array));
            return r;
        }

        /// <summary>
        /// Calculates the weighted sum and sum ^ 2 on the columns of data.
        /// </summary>
        /// <param name="data">The data columns to calculate on.</param>
        /// <param name="weight">The weights to use on the data columns (must be length data.Rows).</param>
        /// <returns>2 x data.Cols matrix.</returns>
        public static matrix Sum2(matrix data, vector weight)
        {
            var r = new matrix(2, data.Cols);
            ThrowHelper.Check(Vsl.SumRaw2Weighted(data.Rows, data.Cols, data.Array, weight.Array, r.Array));
            return r;
        }

        /// <summary>
        /// Calculates the sum ... sum ^ 3 on the columns of data.
        /// </summary>
        /// <param name="data">The data columns to calculate on.</param>
        /// <returns>3 x data.Cols matrix.</returns>
        public static matrix Sum3(matrix data)
        {
            var r = new matrix(3, data.Cols);
            ThrowHelper.Check(Vsl.SumRaw3(data.Rows, data.Cols, data.Array, r.Array));
            return r;
        }

        /// <summary>
        /// Calculates the weighted sum ... sum ^ 3 on the columns of data.
        /// </summary>
        /// <param name="data">The data columns to calculate on.</param>
        /// <param name="weight">The weights to use on the data columns (must be length data.Rows).</param>
        /// <returns>3 x data.Cols matrix.</returns>
        public static matrix Sum3(matrix data, vector weight)
        {
            var r = new matrix(3, data.Cols);
            ThrowHelper.Check(Vsl.SumRaw3Weighted(data.Rows, data.Cols, data.Array, weight.Array, r.Array));
            return r;
        }

        /// <summary>
        /// Calculates the sum ... sum ^ 4 on the columns of data.
        /// </summary>
        /// <param name="data">The data columns to calculate on.</param>
        /// <returns>4 x data.Cols matrix.</returns>
        public static matrix Sum4(matrix data)
        {
            var r = new matrix(4, data.Cols);
            ThrowHelper.Check(Vsl.SumRaw4(data.Rows, data.Cols, data.Array, r.Array));
            return r;
        }

        /// <summary>
        /// Calculates the weighted sum ... sum ^ 4 on the columns of data.
        /// </summary>
        /// <param name="data">The data columns to calculate on.</param>
        /// <param name="weight">The weights to use on the data columns (must be length data.Rows).</param>
        /// <returns>4 x data.Cols matrix.</returns>
        public static matrix Sum4(matrix data, vector weight)
        {
            var r = new matrix(4, data.Cols);
            ThrowHelper.Check(Vsl.SumRaw4Weighted(data.Rows, data.Cols, data.Array, weight.Array, r.Array));
            return r;
        }

        /// <summary>
        /// Calculates the mean on the columns of data.
        /// </summary>
        /// <param name="data">The data columns to calculate on.</param>
        /// <returns>The mean vectorT.</returns>
        public static vectorT Mean(matrix data)
        {
            var r = new vectorT(data.Cols);
            ThrowHelper.Check(Vsl.Mean(data.Rows, data.Cols, data.Array, r.Array));
            return r;
        }

        /// <summary>
        /// Calculates the weighted mean on the columns of data.
        /// </summary>
        /// <param name="data">The data columns to calculate on.</param>
        /// <param name="weight">The weights to use on the data columns (must be length data.Rows).</param>
        /// <returns>The mean vectorT.</returns>
        public static vectorT Mean(matrix data, vector weight)
        {
            var r = new vectorT(data.Cols);
            ThrowHelper.Check(Vsl.MeanWeighted(data.Rows, data.Cols, data.Array, weight.Array, r.Array));
            return r;
        }

        /// <summary>
        /// Calculates the median on the columns of data.
        /// </summary>
        /// <param name="data">The data columns to calculate on.</param>
        /// <returns>The median vectorT.</returns>
        public static vectorT Median(matrix data)
        {
            var r = new vectorT(data.Cols);
            ThrowHelper.Check(Vsl.Median(data.Rows, data.Cols, data.Array, r.Array));
            return r;
        }

        /// <summary>
        /// Calculates the weighted median on the columns of data.
        /// </summary>
        /// <param name="data">The data columns to calculate on.</param>
        /// <param name="weight">The weights to use on the data columns (must be length data.Rows).</param>
        /// <returns>The median vectorT.</returns>
        public static vectorT Median(matrix data, vector weight)
        {
            var r = new vectorT(data.Cols);
            ThrowHelper.Check(Vsl.MedianWeighted(data.Rows, data.Cols, data.Array, weight.Array, r.Array));
            return r;
        }

        /// <summary>
        /// Calculates the median and MAD on the columns of data.
        /// </summary>
        /// <param name="data">The data columns to calculate on.</param>
        /// <param name="mad">The calculated MAD.</param>
        /// <returns>The median vectorT.</returns>
        public static vectorT MedianMAD(matrix data, out vectorT mad)
        {
            var median = new vectorT(data.Cols);
            mad = new vectorT(data.Cols);
            ThrowHelper.Check(Vsl.MedianMAD(data.Rows, data.Cols, data.Array, median.Array, mad.Array));
            return median;
        }

        /// <summary>
        /// Calculates the weighted median and MAD on the columns of data.
        /// </summary>
        /// <param name="data">The data columns to calculate on.</param>
        /// <param name="weight">The weights to use on the data columns (must be length data.Rows).</param>
        /// <param name="mad">The calculated MAD.</param>
        /// <returns>The median vectorT.</returns>
        public static vectorT MedianMAD(matrix data, vector weight, out vectorT mad)
        {
            var median = new vectorT(data.Cols);
            mad = new vectorT(data.Cols);
            ThrowHelper.Check(Vsl.MedianMADWeighted(data.Rows, data.Cols, data.Array, weight.Array, median.Array, mad.Array));
            return median;
        }

        /// <summary>
        /// Calculates the raw moments to order 2 on the columns of data.
        /// </summary>
        /// <param name="data">The data columns to calculate on.</param>
        /// <returns>2 x data.Cols matrix.</returns>
        public static matrix MomentsRaw2(matrix data)
        {
            var moments = new matrix(2, data.Cols);
            ThrowHelper.Check(Vsl.MomentsRaw2(data.Rows, data.Cols, data.Array, moments.Array));
            return moments;
        }

        /// <summary>
        /// Calculates the weighted raw moments to order 2 on the columns of data.
        /// </summary>
        /// <param name="data">The data columns to calculate on.</param>
        /// <param name="weight">The weights to use on the data columns (must be length data.Rows).</param>
        /// <returns>2 x data.Cols matrix.</returns>
        public static matrix MomentsRaw2(matrix data, vector weight)
        {
            var moments = new matrix(2, data.Cols);
            ThrowHelper.Check(Vsl.MomentsRaw2Weighted(data.Rows, data.Cols, data.Array, weight.Array, moments.Array));
            return moments;
        }

        /// <summary>
        /// Calculates the central moments to order 2 on the columns of data.
        /// </summary>
        /// <param name="data">The data columns to calculate on.</param>
        /// <returns>2 x data.Cols matrix.</returns>
        public static matrix MomentsCentral2(matrix data)
        {
            var moments = new matrix(2, data.Cols);
            ThrowHelper.Check(Vsl.MomentsCentral2(data.Rows, data.Cols, data.Array, moments.Array));
            return moments;
        }

        /// <summary>
        /// Calculates the weighted central moments to order 2 on the columns of data.
        /// </summary>
        /// <param name="data">The data columns to calculate on.</param>
        /// <param name="weight">The weights to use on the data columns (must be length data.Rows).</param>
        /// <returns>2 x data.Cols matrix.</returns>
        public static matrix MomentsCentral2(matrix data, vector weight)
        {
            var moments = new matrix(2, data.Cols);
            ThrowHelper.Check(Vsl.MomentsCentral2Weighted(data.Rows, data.Cols, data.Array, weight.Array, moments.Array));
            return moments;
        }

        /// <summary>
        /// Calculates the raw moments to order 3 on the columns of data.
        /// </summary>
        /// <param name="data">The data columns to calculate on.</param>
        /// <returns>3 x data.Cols matrix.</returns>
        public static matrix MomentsRaw3(matrix data)
        {
            var moments = new matrix(3, data.Cols);
            ThrowHelper.Check(Vsl.MomentsRaw3(data.Rows, data.Cols, data.Array, moments.Array));
            return moments;
        }

        /// <summary>
        /// Calculates the weighted raw moments to order 3 on the columns of data.
        /// </summary>
        /// <param name="data">The data columns to calculate on.</param>
        /// <param name="weight">The weights to use on the data columns (must be length data.Rows).</param>
        /// <returns>3 x data.Cols matrix.</returns>
        public static matrix MomentsRaw3(matrix data, vector weight)
        {
            var moments = new matrix(3, data.Cols);
            ThrowHelper.Check(Vsl.MomentsRaw3Weighted(data.Rows, data.Cols, data.Array, weight.Array, moments.Array));
            return moments;
        }

        /// <summary>
        /// Calculates the central moments to order 3 on the columns of data.
        /// </summary>
        /// <param name="data">The data columns to calculate on.</param>
        /// <returns>3 x data.Cols matrix.</returns>
        public static matrix MomentsCentral3(matrix data)
        {
            var moments = new matrix(3, data.Cols);
            ThrowHelper.Check(Vsl.MomentsCentral3(data.Rows, data.Cols, data.Array, moments.Array));
            return moments;
        }

        /// <summary>
        /// Calculates the weighted central moments to order 3 on the columns of data.
        /// </summary>
        /// <param name="data">The data columns to calculate on.</param>
        /// <param name="weight">The weights to use on the data columns (must be length data.Rows).</param>
        /// <returns>3 x data.Cols matrix.</returns>
        public static matrix MomentsCentral3(matrix data, vector weight)
        {
            var moments = new matrix(3, data.Cols);
            ThrowHelper.Check(Vsl.MomentsCentral3Weighted(data.Rows, data.Cols, data.Array, weight.Array, moments.Array));
            return moments;
        }

        /// <summary>
        /// Calculates the standard moments to order 3 on the columns of data.
        /// </summary>
        /// <param name="data">The data columns to calculate on.</param>
        /// <returns>3 x data.Cols matrix.</returns>
        public static matrix MomentsStandard3(matrix data)
        {
            var moments = new matrix(3, data.Cols);
            ThrowHelper.Check(Vsl.MomentsStandard3(data.Rows, data.Cols, data.Array, moments.Array));
            return moments;
        }

        /// <summary>
        /// Calculates the weighted standard moments to order 3 on the columns of data.
        /// </summary>
        /// <param name="data">The data columns to calculate on.</param>
        /// <param name="weight">The weights to use on the data columns (must be length data.Rows).</param>
        /// <returns>3 x data.Cols matrix.</returns>
        public static matrix MomentsStandard3(matrix data, vector weight)
        {
            var moments = new matrix(3, data.Cols);
            ThrowHelper.Check(Vsl.MomentsStandard3Weighted(data.Rows, data.Cols, data.Array, weight.Array, moments.Array));
            return moments;
        }

        /// <summary>
        /// Calculates the raw moments to order 4 on the columns of data.
        /// </summary>
        /// <param name="data">The data columns to calculate on.</param>
        /// <returns>4 x data.Cols matrix.</returns>
        public static matrix MomentsRaw4(matrix data)
        {
            var moments = new matrix(4, data.Cols);
            ThrowHelper.Check(Vsl.MomentsRaw4(data.Rows, data.Cols, data.Array, moments.Array));
            return moments;
        }

        /// <summary>
        /// Calculates the weighted raw moments to order 4 on the columns of data.
        /// </summary>
        /// <param name="data">The data columns to calculate on.</param>
        /// <param name="weight">The weights to use on the data columns (must be length data.Rows).</param>
        /// <returns>4 x data.Cols matrix.</returns>
        public static matrix MomentsRaw4(matrix data, vector weight)
        {
            var moments = new matrix(4, data.Cols);
            ThrowHelper.Check(Vsl.MomentsRaw4Weighted(data.Rows, data.Cols, data.Array, weight.Array, moments.Array));
            return moments;
        }

        /// <summary>
        /// Calculates the central moments to order 4 on the columns of data.
        /// </summary>
        /// <param name="data">The data columns to calculate on.</param>
        /// <returns>4 x data.Cols matrix.</returns>
        public static matrix MomentsCentral4(matrix data)
        {
            var moments = new matrix(4, data.Cols);
            ThrowHelper.Check(Vsl.MomentsCentral4(data.Rows, data.Cols, data.Array, moments.Array));
            return moments;
        }

        /// <summary>
        /// Calculates the weighted central moments to order 4 on the columns of data.
        /// </summary>
        /// <param name="data">The data columns to calculate on.</param>
        /// <param name="weight">The weights to use on the data columns (must be length data.Rows).</param>
        /// <returns>4 x data.Cols matrix.</returns>
        public static matrix MomentsCentral4(matrix data, vector weight)
        {
            var moments = new matrix(4, data.Cols);
            ThrowHelper.Check(Vsl.MomentsCentral4Weighted(data.Rows, data.Cols, data.Array, weight.Array, moments.Array));
            return moments;
        }

        /// <summary>
        /// Calculates the standard moments to order 4 on the columns of data.
        /// </summary>
        /// <param name="data">The data columns to calculate on.</param>
        /// <returns>4 x data.Cols matrix.</returns>
        public static matrix MomentsStandard4(matrix data)
        {
            var moments = new matrix(4, data.Cols);
            ThrowHelper.Check(Vsl.MomentsStandard4(data.Rows, data.Cols, data.Array, moments.Array));
            return moments;
        }

        /// <summary>
        /// Calculates the weighted standard moments to order 4 on the columns of data.
        /// </summary>
        /// <param name="data">The data columns to calculate on.</param>
        /// <param name="weight">The weights to use on the data columns (must be length data.Rows).</param>
        /// <returns>4 x data.Cols matrix.</returns>
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
        /// Calculates the weighted quartiles on the columns of data. Q1 = 25%, Q2 = 50% (median), Q3 = 75%
        /// </summary>
        /// <param name="data">The data columns to calculate on.</param>
        /// <param name="weight">The weights to use on the data columns (must be length data.Rows).</param>
        /// <returns>3 x data.Cols matrix of quartiles.</returns>
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
        /// Calculates the weighted quartiles plus min and max on the columns of data. Min = 0%, Q1 = 25%, Q2 = 50% (median), Q3 = 75%, Max = 100%
        /// </summary>
        /// <param name="data">The data columns to calculate on.</param>
        /// <param name="weight">The weights to use on the data columns (must be length data.Rows).</param>
        /// <returns>5 x data.Cols matrix of quartiles.</returns>
        public static matrix QuartilesMinMax(matrix data, vector weight)
        {
            var quants = new matrix(5, data.Cols);
            ThrowHelper.Check(Vsl.QuantilesWeighted(data.Rows, data.Cols, data.Array, weight.Array, quartiles_minmax, quants.Array));
            return quants;
        }

        /// <summary>
        /// Calculates the quantiles on the columns of data.
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
        /// Calculates the weighted quantiles on the columns of data.
        /// </summary>
        /// <param name="data">The data columns to calculate on.</param>
        /// <param name="weight">The weights to use on the data columns (must be length data.Rows).</param>
        /// <param name="quantiles">The quantiles to calculate in the range 0.0 - 1.0.</param>
        /// <returns>quantiles.Length x data.Cols matrix of quantiles.</returns>
        public static matrix Quantiles(matrix data, vector weight, double[] quantiles)
        {
            var quants = new matrix(quantiles.Length, data.Cols);
            ThrowHelper.Check(Vsl.QuantilesWeighted(data.Rows, data.Cols, data.Array, weight.Array, quantiles, quants.Array));
            return quants;
        }

        /// <summary>
        /// Calculates the covariance on the columns of data.
        /// </summary>
        /// <param name="data">The data columns to calculate on.</param>
        /// <param name="mean">The calculated mean.</param>
        /// <returns>data.Cols x data.Cols matrix.</returns>
        public static matrix Covariance(matrix data, out vectorT mean)
        {
            mean = new vectorT(data.Cols);
            var cov = new matrix(data.Cols, data.Cols);
            ThrowHelper.Check(Vsl.Covariance(data.Rows, data.Cols, data.Array, mean.Array, cov.Array));
            return cov;
        }

        /// <summary>
        /// Calculates the weighted covariance on the columns of data.
        /// </summary>
        /// <param name="data">The data columns to calculate on.</param>
        /// <param name="weight">The weights to use on the data columns (must be length data.Rows).</param>
        /// <param name="mean">The calculated mean.</param>
        /// <returns>data.Cols x data.Cols matrix.</returns>
        public static matrix Covariance(matrix data, vector weight, out vectorT mean)
        {
            mean = new vectorT(data.Cols);
            var cov = new matrix(data.Cols, data.Cols);
            ThrowHelper.Check(Vsl.CovarianceWeighted(data.Rows, data.Cols, data.Array, weight.Array, mean.Array, cov.Array));
            return cov;
        }

        /// <summary>
        /// Calculates the correlation on the columns of data.
        /// </summary>
        /// <param name="data">The data columns to calculate on.</param>
        /// <param name="mean">The calculated mean.</param>
        /// <returns>data.Cols x data.Cols matrix.</returns>
        public static matrix Correlation(matrix data, out vectorT mean)
        {
            mean = new vectorT(data.Cols);
            var cor = new matrix(data.Cols, data.Cols);
            ThrowHelper.Check(Vsl.Correlation(data.Rows, data.Cols, data.Array, mean.Array, cor.Array));
            return cor;
        }

        /// <summary>
        /// Calculates the weighted correlation on the columns of data.
        /// </summary>
        /// <param name="data">The data columns to calculate on.</param>
        /// <param name="weight">The weights to use on the data columns (must be length data.Rows).</param>
        /// <param name="mean">The calculated mean.</param>
        /// <returns>data.Cols x data.Cols matrix.</returns>
        public static matrix Correlation(matrix data, vector weight, out vectorT mean)
        {
            mean = new vectorT(data.Cols);
            var cor = new matrix(data.Cols, data.Cols);
            ThrowHelper.Check(Vsl.CorrelationWeighted(data.Rows, data.Cols, data.Array, weight.Array, mean.Array, cor.Array));
            return cor;
        }
    }
}