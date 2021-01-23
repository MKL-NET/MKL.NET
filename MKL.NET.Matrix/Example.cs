namespace MKLNET
{
    public static class Example
    {
        public static void E1(matrix Ma, matrix Mb, vector Va, vector Vb)
        {
            using matrix me = Ma + Mb + Ma * 0.1 + 0.1 * Mb + Matrix.Abs(Ma) + Ma * Mb;
            using vector ve = Va + 0.1 + (1.0 - Vb.T).T;
            using vector ve2 = Ma * Va;
            using vector ve3 = Ma * (Va + 0.1);
            using vector ve4 = (Ma + 0.1) * Va;
            using vector ve5 = (Ma + 0.1) * (Va + 0.1);
            using vectorT ve6 = Va.T * Ma;
            using vectorT ve7 = (Va.T + 0.1) * Ma;
            using vectorT ve8 = Va.T * (Ma + 0.1);
            using vectorT ve9 = (Va.T + 0.1) * (Ma + 0.1);
        }

        public class RngGaussianExpression : Expression.MatrixExpression
        {
            readonly int rows, cols;
            readonly uint seed;
            readonly double mean, sigma;
            public RngGaussianExpression(int rows, int cols, uint seed, double mean, double sigma)
            {
                this.rows = rows;
                this.cols = cols;
                this.seed = seed;
                this.mean = mean;
                this.sigma = sigma;
            }
            public override matrix EvaluateMatrix()
            {
                var r = new matrix(rows, cols);
                var stream = Vsl.NewStream(VslBrng.MT19937, seed);
                ThrowHelper.Check(Vsl.RngGaussian(VslMethodGaussian.ICDF, stream, r.Length, r.Array, mean, sigma));
                ThrowHelper.Check(Vsl.DeleteStream(stream));
                return r;
            }
        }
        public static RngGaussianExpression RngGaussian(int rows, int cols, uint seed, double mean, double sigma)
            => new(rows, cols, seed, mean, sigma);

        public static (vector, matrix) MeanAndCovariance(matrix samples, vector weights)
        {
            if (samples.Rows != weights.Length) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var mean = new vector(samples.Cols);
            var cov = new matrix(samples.Cols, samples.Cols);
            var task = Vsl.SSNewTask(samples.Cols, samples.Rows, VslStorage.ROWS, samples.Array, weights.Array);
            ThrowHelper.Check(Vsl.SSEditCovCor(task, mean.Array, cov.Array, VslFormat.FULL, null, VslFormat.FULL));
            ThrowHelper.Check(Vsl.SSCompute(task, VslEstimate.COV, VslMethod.FAST));
            ThrowHelper.Check(Vsl.SSDeleteTask(task));
            return (mean, cov);
        }
    }
}
