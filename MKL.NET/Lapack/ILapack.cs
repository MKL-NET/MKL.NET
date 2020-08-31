namespace MKLNET
{
    public interface ILapack
    {
        /// <summary>
        /// Cholesky factorization of a symmetric positive-definite matrix A = LLᵀ where L is a lower triangular matrix.
        /// Or A = UᵀU where U is an upper triangular matrix.
        /// </summary>
        int dpotrf(Order order, UpLo uplo, int n, double[] a, int lda);
    }
}
