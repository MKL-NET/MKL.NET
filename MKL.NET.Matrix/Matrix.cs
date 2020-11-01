using System;
using System.Buffers;

namespace MKLNET
{
    public static class Matrix
    {
        public static class Inplace
        {
            public static void Sqrt(matrix m)
            {
                Vml.Sqrt(m.Length, m.A, 0, 1, m.A, 0, 1);
            }
        }
        public static matrix Sqrt(matrix m)
        {
            var r = new matrix(m.Rows, m.Cols);
            Vml.Sqrt(m.Length, m.A, 0, 1, r.A, 0, 1);
            return r;
        }
    }
    public class matrix : IDisposable
    {
        public readonly int Rows;
        public readonly int Cols;
        internal double[] A;
        public int Length => Rows * Cols;
        internal matrix(int rows, int cols)
        {
            Rows = rows;
            Cols = cols;
            A = ArrayPool<double>.Shared.Rent(rows * cols);
        }
        public double this[int row, int col] => A[col * Rows + row];

        public void Dispose()
        {
            ArrayPool<double>.Shared.Return(A);
            A = null;
            GC.SuppressFinalize(this);
        }
        ~matrix()
        {
            ArrayPool<double>.Shared.Return(A);
        }
        public static matrix operator +(matrix a, matrix b)
        {
            var r = new matrix(a.Rows, a.Cols);
            Vml.Add(a.Length, a.A, 0, 1, b.A, 0, 1, r.A, 0, 1);
            return r;
        }
        public static matrix operator -(matrix a, matrix b)
        {
            var r = new matrix(a.Rows, a.Cols);
            Vml.Sub(a.Length, a.A, 0, 1, b.A, 0, 1, r.A, 0, 1);
            return r;
        }
        public static matrix operator *(matrix a, matrix b)
        {
            var r = new matrix(a.Rows, b.Cols);
            Blas.gemm(Layout.ColMajor, Trans.No, Trans.No, a.Rows, b.Cols, a.Cols, 1.0, a.A, a.Rows, b.A, b.Rows, 0.0, r.A, a.Rows);
            return r;
        }
        public static matrix operator *(matrix a, matrixT b)
        {
            var r = new matrix(a.Rows, b.Cols);
            Blas.gemm(Layout.ColMajor, Trans.No, Trans.Yes, a.Rows, b.Cols, a.Cols, 1.0, a.A, a.Rows, b.A, b.Rows, 0.0, r.A, a.Rows);
            return r;
        }
        public matrixT T => new matrixT(Cols, Rows, A);
    }

    public class matrixT
    {
        public readonly int Rows;
        public readonly int Cols;
        public readonly double[] A;
        internal matrixT(int rows, int cols, double[] a)
        {
            Rows = rows;
            Cols = cols;
            A = a;
        }
        public double this[int row, int col] => A[row * Cols + col];
    }

    public class matrixF
    {
        readonly int Rows;
        readonly int Cols;
        readonly float[] A;
        internal matrixF(int rows, int cols, float[] a)
        {
            Rows = rows;
            Cols = cols;
            A = a;
        }
    }

    public static class Test
    {
        public static matrix Test1(matrix a, matrix b)
        {
            return a + b;
        }
    }
}
