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
        public matrix(int rows, int cols)
        {
            Rows = rows;
            Cols = cols;
            A = ArrayPool<double>.Shared.Rent(rows * cols);
        }
        public double this[int row, int col]
        {
            get => A[col * Rows + row];
            set => A[col * Rows + row] = value;
        }
        public void Dispose()
        {
            ArrayPool<double>.Shared.Return(A);
            A = null;
            GC.SuppressFinalize(this);
        }
        ~matrix() => ArrayPool<double>.Shared.Return(A);
        public static matrix operator +(matrix a, matrix b)
        {
            if (a.Rows != b.Rows || a.Cols != b.Cols) ThrowHelper.ThrowIncorrectMatrixDimesionsForOperation();
            var r = new matrix(a.Rows, a.Cols);
            Vml.Add(a.Length, a.A, 0, 1, b.A, 0, 1, r.A, 0, 1);
            return r;
        }
        public static matrix operator -(matrix a, matrix b)
        {
            if (a.Rows != b.Rows || a.Cols != b.Cols) ThrowHelper.ThrowIncorrectMatrixDimesionsForOperation();
            var r = new matrix(a.Rows, a.Cols);
            Vml.Sub(a.Length, a.A, 0, 1, b.A, 0, 1, r.A, 0, 1);
            return r;
        }
        public matrixT T => new matrixT(this);
        public static matrixS operator *(matrix a, double s) => new matrixS(a, s);
        public static matrixS operator *(double s, matrix a) => new matrixS(a, s);
        public static matrix operator *(matrix a, matrix b)
        {
            if (a.Cols != b.Rows) ThrowHelper.ThrowIncorrectMatrixDimesionsForOperation();
            var r = new matrix(a.Rows, b.Cols);
            Blas.gemm(Layout.ColMajor, Trans.No, Trans.No, a.Rows, b.Cols, a.Cols, 1.0, a.A, a.Rows, b.A, b.Rows, 0.0, r.A, a.Rows);
            return r;
        }
        public static matrix operator *(matrix a, matrixT bT)
        {
            var b = bT.Matrix;
            if (a.Cols != b.Cols) ThrowHelper.ThrowIncorrectMatrixDimesionsForOperation();
            var r = new matrix(a.Rows, b.Rows);
            Blas.gemm(Layout.ColMajor, Trans.No, Trans.Yes, a.Rows, b.Rows, a.Cols, 1.0, a.A, a.Rows, b.A, b.Rows, 0.0, r.A, a.Rows);
            return r;
        }
        public static matrix operator *(matrix a, matrixS bS)
        {
            var b = bS.Matrix;
            if (a.Cols != b.Rows) ThrowHelper.ThrowIncorrectMatrixDimesionsForOperation();
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
        public static matrix operator *(matrixT aT, matrix b)
        {
            var a = aT.Matrix;
            if (a.Rows != b.Rows) ThrowHelper.ThrowIncorrectMatrixDimesionsForOperation();
            var r = new matrix(a.Cols, b.Cols);
            Blas.gemm(Layout.ColMajor, Trans.Yes, Trans.No, a.Cols, b.Cols, a.Rows, 1.0, a.A, a.Rows, b.A, b.Rows, 0.0, r.A, a.Cols);
            return r;
        }
        public static matrix operator *(matrixT aT, matrixT bT)
        {
            var a = aT.Matrix;
            var b = bT.Matrix;
            if (a.Rows != b.Cols) ThrowHelper.ThrowIncorrectMatrixDimesionsForOperation();
            var r = new matrix(a.Cols, b.Rows);
            Blas.gemm(Layout.ColMajor, Trans.Yes, Trans.Yes, a.Cols, b.Rows, a.Rows, 1.0, a.A, a.Rows, b.A, b.Rows, 0.0, r.A, a.Cols);
            return r;
        }
        public static matrix operator *(matrixT aT, matrixS bS)
        {
            var a = aT.Matrix;
            var b = bS.Matrix;
            if (a.Rows != b.Rows) ThrowHelper.ThrowIncorrectMatrixDimesionsForOperation();
            var r = new matrix(a.Cols, b.Cols);
            Blas.gemm(Layout.ColMajor, Trans.Yes, Trans.No, a.Cols, b.Cols, a.Rows, bS.Scale, a.A, a.Rows, b.A, b.Rows, 0.0, r.A, a.Cols);
            return r;
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
            if (a.Cols != b.Rows) ThrowHelper.ThrowIncorrectMatrixDimesionsForOperation();
            var r = new matrix(a.Rows, b.Cols);
            Blas.gemm(Layout.ColMajor, Trans.No, Trans.No, a.Rows, b.Cols, a.Cols, aS.Scale, a.A, a.Rows, b.A, b.Rows, 0.0, r.A, a.Rows);
            return r;
        }
        public static matrix operator *(matrixS aS, matrixT bT)
        {
            var a = aS.Matrix;
            var b = bT.Matrix;
            if (a.Cols != b.Cols) ThrowHelper.ThrowIncorrectMatrixDimesionsForOperation();
            var r = new matrix(a.Rows, b.Rows);
            Blas.gemm(Layout.ColMajor, Trans.No, Trans.Yes, a.Rows, b.Rows, a.Cols, aS.Scale, a.A, a.Rows, b.A, b.Rows, 0.0, r.A, a.Rows);
            return r;
        }
        public static matrix operator *(matrixS aS, matrixS bS)
        {
            var a = aS.Matrix;
            var b = bS.Matrix;
            if (a.Cols != b.Rows) ThrowHelper.ThrowIncorrectMatrixDimesionsForOperation();
            var r = new matrix(a.Rows, b.Cols);
            Blas.gemm(Layout.ColMajor, Trans.No, Trans.No, a.Rows, b.Cols, a.Cols, aS.Scale * bS.Scale, a.A, a.Rows, b.A, b.Rows, 0.0, r.A, a.Rows);
            return r;
        }
    }
}