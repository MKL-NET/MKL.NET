using System;
using System.Collections.Generic;
using System.Text;

namespace MKLNET
{
    /// <summary>
    /// Convention for indexing matrices, row or column Major.
    /// In row major (C), M[i, j] is the element at the i-row and j-column of M.
    /// In column major (Fortran), M[i, j] is the element at the i-column and j-row of M.
    /// </summary>
    public enum Order
    {
        RowMajor = 101, ColMajor = 102
    }

    /// <summary>
    /// Used to indicates if a matrix needs to be transposed before doing the calculation.
    /// For performance reason,
    /// Blas implementations usually don't actually transpose the matrix but modify their algorithm.
    /// </summary>
    public enum Transpose
    {
        No = 111, Yes = 112, YesConj = 113
    }
    public interface IBlas
    {
        void dgemm(Order order, Transpose transA, Transpose transB,
            int m, int n, int k, double alpha,
            double[] A, int lda,
            double[] B, int ldb,
            double beta,
            double[] C, int ldc);
    }
}
