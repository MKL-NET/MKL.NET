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
            Vsl.Quantiles(data.Rows, data.Cols, data.Array, quartiles, quants.Array);
            return quants;
        }

        static readonly double[] quartiles_minmax = new[] { 0.00, 0.25, 0.50, 0.75, 1.00 };
        /// <summary>
        /// Calculates the quartiles plus min and max on the columns of data. Min = 0%, Q1 = 25%, Q2 = 50% (median), Q3 = 75%, Max = 100%
        /// </summary>
        /// <param name="data">The data to calculate the quartiles and min and max of.</param>
        /// <returns>5 x data.Cols matrix of quartiles.</returns>
        public static matrix Quartiles_MinMax(matrix data)
        {
            var quants = new matrix(5, data.Cols);
            Vsl.Quantiles(data.Rows, data.Cols, data.Array, quartiles_minmax, quants.Array);
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
            Vsl.Quantiles(data.Rows, data.Cols, data.Array, quantiles, quants.Array);
            return quants;
        }
    }
}