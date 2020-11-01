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
        public static matrixS Sqrt(matrixS m) => Sqrt(m.Matrix) * Math.Sqrt(m.Scale);
        public static matrixT Sqrt(matrixT m) => new matrixT(Sqrt(m.Matrix));
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
        public matrixT T => new matrixT(this);
        public static matrixS operator *(matrix a, double s) => new matrixS(a, s);
        public static matrixS operator *(double s, matrix a) => new matrixS(a, s);
        public static matrix operator *(matrix a, matrix b)
        {
            var r = new matrix(a.Rows, b.Cols);
            Blas.gemm(Layout.ColMajor, Trans.No, Trans.No, a.Rows, b.Cols, a.Cols, 1.0, a.A, a.Rows, b.A, b.Rows, 0.0, r.A, a.Rows);
            return r;
        }
        public static matrix operator *(matrix a, matrixT b)
        {
            var bT = b.Matrix;
            var r = new matrix(a.Rows, bT.Cols);
            Blas.gemm(Layout.ColMajor, Trans.No, Trans.Yes, a.Rows, bT.Cols, a.Cols, 1.0, a.A, a.Rows, bT.A, bT.Rows, 0.0, r.A, a.Rows);
            return r;
        }
        public static matrix operator *(matrix a, matrixS bS)
        {
            var b = bS.Matrix;
            var r = new matrix(a.Rows, b.Cols);
            Blas.gemm(Layout.ColMajor, Trans.No, Trans.No, a.Rows, b.Cols, a.Cols, bS.Scale, a.A, a.Rows, b.A, b.Rows, 0.0, r.A, a.Rows);
            return r;
        }
    }

    public struct matrixT
    {
        public readonly matrix Matrix;
        internal matrixT(matrix m)
        {
            Matrix = m;
        }
    }

    public struct matrixS
    {
        public readonly matrix Matrix;
        public readonly double Scale;
        internal matrixS(matrix m, double s)
        {
            Matrix = m;
            Scale = s;
        }
        public static implicit operator matrix(matrixS d) => d.Matrix;
        public static matrix operator *(matrixS aS, matrix b)
        {
            var a = aS.Matrix;
            var r = new matrix(a.Rows, b.Cols);
            Blas.gemm(Layout.ColMajor, Trans.No, Trans.No, a.Rows, b.Cols, a.Cols, aS.Scale, a.A, a.Rows, b.A, b.Rows, 0.0, r.A, a.Rows);
            return r;
        }
        public static matrix operator *(matrixS aS, matrixT b)
        {
            var a = aS.Matrix;
            var bT = b.Matrix;
            var r = new matrix(a.Rows, bT.Cols);
            Blas.gemm(Layout.ColMajor, Trans.No, Trans.Yes, a.Rows, bT.Cols, a.Cols, aS.Scale, a.A, a.Rows, bT.A, bT.Rows, 0.0, r.A, a.Rows);
            return r;
        }
        public static matrix operator *(matrixS aS, matrixS bS)
        {
            var a = aS.Matrix;
            var b = bS.Matrix;
            var r = new matrix(a.Rows, b.Cols);
            Blas.gemm(Layout.ColMajor, Trans.No, Trans.No, a.Rows, b.Cols, a.Cols, aS.Scale * bS.Scale, a.A, a.Rows, b.A, b.Rows, 0.0, r.A, a.Rows);
            return r;
        }
    }

    public static class Test
    {
        public static matrix Test1(matrix a, matrix b) => 2.0 * a * b;
        public static matrixS Test2(matrix a) => Matrix.Sqrt(2.0 * a);
    }
}