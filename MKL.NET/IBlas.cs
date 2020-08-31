namespace MKLNET
{
    public interface IBlas
    {
        /// <summary>
        /// Computes a scalar-matrix-matrix product and adds the result to a scalar-matrix product. (c := alpha*op(A)*op(b) + beta*c)
        /// </summary>
        void dgemm(Order order, Transpose transA, Transpose transB,
            int m, int n, int k, double alpha,
            double[] A, int lda,
            double[] B, int ldb,
            double beta,
            double[] C, int ldc);
    }
}
