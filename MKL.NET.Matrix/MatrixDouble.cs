using System;
using System.Buffers;

namespace MKLNET
{
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
        public matrixT T => new matrixT(this);
        public static matrixS operator *(matrix a, double s) => new matrixS(a, s);
        public static matrixS operator *(double s, matrix a) => new matrixS(a, s);

        public static matrix operator +(matrix a, matrix b)
        {
            if (a.Rows != b.Rows || a.Cols != b.Cols) ThrowHelper.ThrowIncorrectMatrixDimesionsForOperation();
            var r = new matrix(a.Rows, a.Cols);
            Vml.Add(a.Length, a.A, 0, 1, b.A, 0, 1, r.A, 0, 1);
            return r;
        }

        public static matrix operator +(matrix a, matrixT bT)
        {
            var b = bT.Matrix;
            if (a.Rows != b.Cols || a.Cols != b.Rows) ThrowHelper.ThrowIncorrectMatrixDimesionsForOperation();
            var r = new matrix(a.Rows, a.Cols);
            Blas.omatadd(LayoutChar.ColMajor, TransChar.No, TransChar.Yes, a.Rows, a.Cols, 1.0, a.A, a.Rows, 1.0, b.A, b.Rows, r.A, a.Rows);
            return r;
        }

        public static matrix operator +(matrix a, matrixS bS)
        {
            var b = bS.Matrix;
            if (a.Rows != b.Rows || a.Cols != b.Cols) ThrowHelper.ThrowIncorrectMatrixDimesionsForOperation();
            var r = new matrix(a.Rows, a.Cols);
            Blas.omatadd(LayoutChar.ColMajor, TransChar.No, TransChar.No, a.Rows, a.Cols, 1.0, a.A, a.Rows, bS.Scale, b.A, b.Rows, r.A, a.Rows);
            return r;
        }

        public static matrix operator +(matrix a, matrixTS bTS)
        {
            var b = bTS.Matrix;
            if (a.Rows != b.Cols || a.Cols != b.Rows) ThrowHelper.ThrowIncorrectMatrixDimesionsForOperation();
            var r = new matrix(a.Rows, a.Cols);
            Blas.omatadd(LayoutChar.ColMajor, TransChar.No, TransChar.Yes, a.Rows, a.Cols, 1.0, a.A, a.Rows, bTS.Scale, b.A, b.Rows, r.A, a.Rows);
            return r;
        }

        public static matrix operator -(matrix a, matrix b)
        {
            if (a.Rows != b.Rows || a.Cols != b.Cols) ThrowHelper.ThrowIncorrectMatrixDimesionsForOperation();
            var r = new matrix(a.Rows, a.Cols);
            Vml.Sub(a.Length, a.A, 0, 1, b.A, 0, 1, r.A, 0, 1);
            return r;
        }

        public static matrix operator -(matrix a, matrixT bT)
        {
            var b = bT.Matrix;
            if (a.Rows != b.Cols || a.Cols != b.Rows) ThrowHelper.ThrowIncorrectMatrixDimesionsForOperation();
            var r = new matrix(a.Rows, a.Cols);
            Blas.omatadd(LayoutChar.ColMajor, TransChar.No, TransChar.Yes, a.Rows, a.Cols, 1.0, a.A, a.Rows, -1.0, b.A, b.Rows, r.A, a.Rows);
            return r;
        }

        public static matrix operator -(matrix a, matrixS bS)
        {
            var b = bS.Matrix;
            if (a.Rows != b.Rows || a.Cols != b.Cols) ThrowHelper.ThrowIncorrectMatrixDimesionsForOperation();
            var r = new matrix(a.Rows, a.Cols);
            Blas.omatadd(LayoutChar.ColMajor, TransChar.No, TransChar.No, a.Rows, a.Cols, 1.0, a.A, a.Rows, -bS.Scale, b.A, b.Rows, r.A, a.Rows);
            return r;
        }

        public static matrix operator -(matrix a, matrixTS bTS)
        {
            var b = bTS.Matrix;
            if (a.Rows != b.Cols || a.Cols != b.Rows) ThrowHelper.ThrowIncorrectMatrixDimesionsForOperation();
            var r = new matrix(a.Rows, a.Cols);
            Blas.omatadd(LayoutChar.ColMajor, TransChar.No, TransChar.Yes, a.Rows, a.Cols, 1.0, a.A, a.Rows, -bTS.Scale, b.A, b.Rows, r.A, a.Rows);
            return r;
        }

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

        public static matrix operator *(matrix a, matrixTS bTS)
        {
            var b = bTS.Matrix;
            if (a.Cols != b.Cols) ThrowHelper.ThrowIncorrectMatrixDimesionsForOperation();
            var r = new matrix(a.Rows, b.Rows);
            Blas.gemm(Layout.ColMajor, Trans.No, Trans.Yes, a.Rows, b.Rows, a.Cols, bTS.Scale, a.A, a.Rows, b.A, b.Rows, 0.0, r.A, a.Rows);
            return r;
        }
    }

    public struct matrixT
    {
        public readonly matrix Matrix;
        internal matrixT(matrix m) => Matrix = m;
        public matrix T => Matrix;
        public static matrixTS operator *(matrixT a, double s) => new matrixTS(a.Matrix, s);
        public static matrixTS operator *(double s, matrixT a) => new matrixTS(a.Matrix, s);

        public static implicit operator matrix(matrixT mT)
        {
            var m = mT.Matrix;
            var r = new matrix(m.Cols, m.Rows);
            Blas.omatcopy(LayoutChar.ColMajor, TransChar.Yes, m.Rows, m.Cols, 1.0, m.A, m.Rows, r.A, m.Cols);
            return r;
        }

        public static matrix operator +(matrixT aT, matrix b)
        {
            var a = aT.Matrix;
            if (a.Cols != b.Rows || a.Rows != b.Cols) ThrowHelper.ThrowIncorrectMatrixDimesionsForOperation();
            var r = new matrix(a.Cols, a.Rows);
            Blas.omatadd(LayoutChar.ColMajor, TransChar.Yes, TransChar.No, a.Cols, a.Rows, 1.0, a.A, a.Rows, 1.0, b.A, b.Rows, r.A, r.Rows);
            return r;
        }

        public static matrix operator +(matrixT aT, matrixT bT)
        {
            var a = aT.Matrix;
            var b = bT.Matrix;
            if (a.Rows != b.Rows || a.Cols != b.Cols) ThrowHelper.ThrowIncorrectMatrixDimesionsForOperation();
            var r = new matrix(a.Cols, a.Rows);
            Blas.omatadd(LayoutChar.ColMajor, TransChar.Yes, TransChar.Yes, a.Cols, a.Rows, 1.0, a.A, a.Rows, 1.0, b.A, b.Rows, r.A, r.Rows);
            return r;
        }

        public static matrix operator +(matrixT aT, matrixS bS)
        {
            var a = aT.Matrix;
            var b = bS.Matrix;
            if (a.Cols != b.Rows || a.Rows != b.Cols) ThrowHelper.ThrowIncorrectMatrixDimesionsForOperation();
            var r = new matrix(a.Cols, a.Rows);
            Blas.omatadd(LayoutChar.ColMajor, TransChar.Yes, TransChar.No, a.Cols, a.Rows, 1.0, a.A, a.Rows, bS.Scale, b.A, b.Rows, r.A, r.Rows);
            return r;
        }

        public static matrix operator +(matrixT aT, matrixTS bTS)
        {
            var a = aT.Matrix;
            var b = bTS.Matrix;
            if (a.Rows != b.Rows || a.Cols != b.Cols) ThrowHelper.ThrowIncorrectMatrixDimesionsForOperation();
            var r = new matrix(a.Cols, a.Rows);
            Blas.omatadd(LayoutChar.ColMajor, TransChar.Yes, TransChar.Yes, a.Cols, a.Rows, 1.0, a.A, a.Rows, bTS.Scale, b.A, b.Rows, r.A, r.Rows);
            return r;
        }

        public static matrix operator -(matrixT aT, matrix b)
        {
            var a = aT.Matrix;
            if (a.Cols != b.Rows || a.Rows != b.Cols) ThrowHelper.ThrowIncorrectMatrixDimesionsForOperation();
            var r = new matrix(a.Cols, a.Rows);
            Blas.omatadd(LayoutChar.ColMajor, TransChar.Yes, TransChar.No, a.Cols, a.Rows, 1.0, a.A, a.Rows, -1.0, b.A, b.Rows, r.A, r.Rows);
            return r;
        }

        public static matrix operator -(matrixT aT, matrixT bT)
        {
            var a = aT.Matrix;
            var b = bT.Matrix;
            if (a.Rows != b.Rows || a.Cols != b.Cols) ThrowHelper.ThrowIncorrectMatrixDimesionsForOperation();
            var r = new matrix(a.Cols, a.Rows);
            Blas.omatadd(LayoutChar.ColMajor, TransChar.Yes, TransChar.Yes, a.Cols, a.Rows, 1.0, a.A, a.Rows, -1.0, b.A, b.Rows, r.A, r.Rows);
            return r;
        }

        public static matrix operator -(matrixT aT, matrixS bS)
        {
            var a = aT.Matrix;
            var b = bS.Matrix;
            if (a.Cols != b.Rows || a.Rows != b.Cols) ThrowHelper.ThrowIncorrectMatrixDimesionsForOperation();
            var r = new matrix(a.Cols, a.Rows);
            Blas.omatadd(LayoutChar.ColMajor, TransChar.Yes, TransChar.No, a.Cols, a.Rows, 1.0, a.A, a.Rows, -bS.Scale, b.A, b.Rows, r.A, r.Rows);
            return r;
        }

        public static matrix operator -(matrixT aT, matrixTS bTS)
        {
            var a = aT.Matrix;
            var b = bTS.Matrix;
            if (a.Rows != b.Rows || a.Cols != b.Cols) ThrowHelper.ThrowIncorrectMatrixDimesionsForOperation();
            var r = new matrix(a.Cols, a.Rows);
            Blas.omatadd(LayoutChar.ColMajor, TransChar.Yes, TransChar.Yes, a.Cols, a.Rows, 1.0, a.A, a.Rows, -bTS.Scale, b.A, b.Rows, r.A, r.Rows);
            return r;
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

        public static matrix operator *(matrixT aT, matrixTS bTS)
        {
            var a = aT.Matrix;
            var b = bTS.Matrix;
            if (a.Rows != b.Cols) ThrowHelper.ThrowIncorrectMatrixDimesionsForOperation();
            var r = new matrix(a.Cols, b.Rows);
            Blas.gemm(Layout.ColMajor, Trans.Yes, Trans.Yes, a.Cols, b.Rows, a.Rows, bTS.Scale, a.A, a.Rows, b.A, b.Rows, 0.0, r.A, a.Cols);
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
        public matrixTS T => new matrixTS(Matrix, Scale);
        public static matrixS operator *(matrixS a, double s) => new matrixS(a.Matrix, a.Scale * s);
        public static matrixS operator *(double s, matrixS a) => new matrixS(a.Matrix, s * a.Scale);

        public static implicit operator matrix(matrixS mS)
        {
            var m = mS.Matrix;
            var r = new matrix(m.Rows, m.Cols);
            Blas.omatcopy(LayoutChar.ColMajor, TransChar.No, m.Rows, m.Cols, mS.Scale, m.A, m.Rows, r.A, r.Rows);
            return r;
        }

        public static matrix operator +(matrixS aS, matrix b)
        {
            var a = aS.Matrix;
            if (a.Rows != b.Rows || a.Cols != b.Cols) ThrowHelper.ThrowIncorrectMatrixDimesionsForOperation();
            var r = new matrix(a.Rows, a.Cols);
            Blas.omatadd(LayoutChar.ColMajor, TransChar.No, TransChar.No, a.Rows, a.Cols, aS.Scale, a.A, a.Rows, 1.0, b.A, b.Rows, r.A, a.Rows);
            return r;
        }

        public static matrix operator +(matrixS aS, matrixT bT)
        {
            var a = aS.Matrix;
            var b = bT.Matrix;
            if (a.Rows != b.Cols || a.Cols != b.Rows) ThrowHelper.ThrowIncorrectMatrixDimesionsForOperation();
            var r = new matrix(a.Rows, a.Cols);
            Blas.omatadd(LayoutChar.ColMajor, TransChar.No, TransChar.Yes, a.Rows, a.Cols, aS.Scale, a.A, a.Rows, 1.0, b.A, b.Rows, r.A, a.Rows);
            return r;
        }

        public static matrix operator +(matrixS aS, matrixS bS)
        {
            var a = aS.Matrix;
            var b = bS.Matrix;
            if (a.Rows != b.Rows || a.Cols != b.Cols) ThrowHelper.ThrowIncorrectMatrixDimesionsForOperation();
            var r = new matrix(a.Rows, a.Cols);
            Blas.omatadd(LayoutChar.ColMajor, TransChar.No, TransChar.No, a.Rows, a.Cols, aS.Scale, a.A, a.Rows, bS.Scale, b.A, b.Rows, r.A, a.Rows);
            return r;
        }

        public static matrix operator +(matrixS aS, matrixTS bTS)
        {
            var a = aS.Matrix;
            var b = bTS.Matrix;
            if (a.Rows != b.Cols || a.Cols != b.Rows) ThrowHelper.ThrowIncorrectMatrixDimesionsForOperation();
            var r = new matrix(a.Rows, a.Cols);
            Blas.omatadd(LayoutChar.ColMajor, TransChar.No, TransChar.Yes, a.Rows, a.Cols, aS.Scale, a.A, a.Rows, bTS.Scale, b.A, b.Rows, r.A, a.Rows);
            return r;
        }

        public static matrix operator -(matrixS aS, matrix b)
        {
            var a = aS.Matrix;
            if (a.Rows != b.Rows || a.Cols != b.Cols) ThrowHelper.ThrowIncorrectMatrixDimesionsForOperation();
            var r = new matrix(a.Rows, a.Cols);
            Blas.omatadd(LayoutChar.ColMajor, TransChar.No, TransChar.No, a.Rows, a.Cols, aS.Scale, a.A, a.Rows, -1.0, b.A, b.Rows, r.A, a.Rows);
            return r;
        }

        public static matrix operator -(matrixS aS, matrixT bT)
        {
            var a = aS.Matrix;
            var b = bT.Matrix;
            if (a.Rows != b.Cols || a.Cols != b.Rows) ThrowHelper.ThrowIncorrectMatrixDimesionsForOperation();
            var r = new matrix(a.Rows, a.Cols);
            Blas.omatadd(LayoutChar.ColMajor, TransChar.No, TransChar.Yes, a.Rows, a.Cols, aS.Scale, a.A, a.Rows, -1.0, b.A, b.Rows, r.A, a.Rows);
            return r;
        }

        public static matrix operator -(matrixS aS, matrixS bS)
        {
            var a = aS.Matrix;
            var b = bS.Matrix;
            if (a.Rows != b.Rows || a.Cols != b.Cols) ThrowHelper.ThrowIncorrectMatrixDimesionsForOperation();
            var r = new matrix(a.Rows, a.Cols);
            Blas.omatadd(LayoutChar.ColMajor, TransChar.No, TransChar.No, a.Rows, a.Cols, aS.Scale, a.A, a.Rows, -bS.Scale, b.A, b.Rows, r.A, a.Rows);
            return r;
        }

        public static matrix operator -(matrixS aS, matrixTS bTS)
        {
            var a = aS.Matrix;
            var b = bTS.Matrix;
            if (a.Rows != b.Cols || a.Cols != b.Rows) ThrowHelper.ThrowIncorrectMatrixDimesionsForOperation();
            var r = new matrix(a.Rows, a.Cols);
            Blas.omatadd(LayoutChar.ColMajor, TransChar.No, TransChar.Yes, a.Rows, a.Cols, aS.Scale, a.A, a.Rows, -bTS.Scale, b.A, b.Rows, r.A, a.Rows);
            return r;
        }

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

        public static matrix operator *(matrixS aS, matrixTS bTS)
        {
            var a = aS.Matrix;
            var b = bTS.Matrix;
            if (a.Cols != b.Cols) ThrowHelper.ThrowIncorrectMatrixDimesionsForOperation();
            var r = new matrix(a.Rows, b.Rows);
            Blas.gemm(Layout.ColMajor, Trans.No, Trans.Yes, a.Rows, b.Rows, a.Cols, aS.Scale * bTS.Scale, a.A, a.Rows, b.A, b.Rows, 0.0, r.A, a.Rows);
            return r;
        }
    }

    public struct matrixTS
    {
        public readonly matrix Matrix;
        public readonly double Scale;
        internal matrixTS(matrix m, double s)
        {
            Matrix = m;
            Scale = s;
        }
        public matrixS T => new matrixS(Matrix, Scale);
        public static matrixTS operator *(matrixTS a, double s) => new matrixTS(a.Matrix, a.Scale * s);
        public static matrixTS operator *(double s, matrixTS a) => new matrixTS(a.Matrix, s * a.Scale);

        public static implicit operator matrix(matrixTS mTS)
        {
            var m = mTS.Matrix;
            var r = new matrix(m.Cols, m.Rows);
            Blas.omatcopy(LayoutChar.ColMajor, TransChar.Yes, m.Rows, m.Cols, mTS.Scale, m.A, m.Rows, r.A, m.Cols);
            return r;
        }

        public static matrix operator +(matrixTS aTS, matrix b)
        {
            var a = aTS.Matrix;
            if (a.Cols != b.Rows || a.Rows != b.Cols) ThrowHelper.ThrowIncorrectMatrixDimesionsForOperation();
            var r = new matrix(a.Cols, a.Rows);
            Blas.omatadd(LayoutChar.ColMajor, TransChar.Yes, TransChar.No, a.Cols, a.Rows, aTS.Scale, a.A, a.Rows, 1.0, b.A, b.Rows, r.A, r.Rows);
            return r;
        }

        public static matrix operator +(matrixTS aTS, matrixT bT)
        {
            var a = aTS.Matrix;
            var b = bT.Matrix;
            if (a.Rows != b.Rows || a.Cols != b.Cols) ThrowHelper.ThrowIncorrectMatrixDimesionsForOperation();
            var r = new matrix(a.Cols, a.Rows);
            Blas.omatadd(LayoutChar.ColMajor, TransChar.Yes, TransChar.Yes, a.Cols, a.Rows, aTS.Scale, a.A, a.Rows, 1.0, b.A, b.Rows, r.A, r.Rows);
            return r;
        }

        public static matrix operator +(matrixTS aTS, matrixS bS)
        {
            var a = aTS.Matrix;
            var b = bS.Matrix;
            if (a.Cols != b.Rows || a.Rows != b.Cols) ThrowHelper.ThrowIncorrectMatrixDimesionsForOperation();
            var r = new matrix(a.Cols, a.Rows);
            Blas.omatadd(LayoutChar.ColMajor, TransChar.Yes, TransChar.No, a.Cols, a.Rows, aTS.Scale, a.A, a.Rows, bS.Scale, b.A, b.Rows, r.A, r.Rows);
            return r;
        }

        public static matrix operator +(matrixTS aTS, matrixTS bTS)
        {
            var a = aTS.Matrix;
            var b = bTS.Matrix;
            if (a.Rows != b.Rows || a.Cols != b.Cols) ThrowHelper.ThrowIncorrectMatrixDimesionsForOperation();
            var r = new matrix(a.Cols, a.Rows);
            Blas.omatadd(LayoutChar.ColMajor, TransChar.Yes, TransChar.Yes, a.Cols, a.Rows, aTS.Scale, a.A, a.Rows, bTS.Scale, b.A, b.Rows, r.A, r.Rows);
            return r;
        }

        public static matrix operator -(matrixTS aTS, matrix b)
        {
            var a = aTS.Matrix;
            if (a.Cols != b.Rows || a.Rows != b.Cols) ThrowHelper.ThrowIncorrectMatrixDimesionsForOperation();
            var r = new matrix(a.Cols, a.Rows);
            Blas.omatadd(LayoutChar.ColMajor, TransChar.Yes, TransChar.No, a.Cols, a.Rows, aTS.Scale, a.A, a.Rows, -1.0, b.A, b.Rows, r.A, r.Rows);
            return r;
        }

        public static matrix operator -(matrixTS aTS, matrixT bT)
        {
            var a = aTS.Matrix;
            var b = bT.Matrix;
            if (a.Rows != b.Rows || a.Cols != b.Cols) ThrowHelper.ThrowIncorrectMatrixDimesionsForOperation();
            var r = new matrix(a.Cols, a.Rows);
            Blas.omatadd(LayoutChar.ColMajor, TransChar.Yes, TransChar.Yes, a.Cols, a.Rows, aTS.Scale, a.A, a.Rows, -1.0, b.A, b.Rows, r.A, r.Rows);
            return r;
        }

        public static matrix operator -(matrixTS aTS, matrixS bS)
        {
            var a = aTS.Matrix;
            var b = bS.Matrix;
            if (a.Cols != b.Rows || a.Rows != b.Cols) ThrowHelper.ThrowIncorrectMatrixDimesionsForOperation();
            var r = new matrix(a.Cols, a.Rows);
            Blas.omatadd(LayoutChar.ColMajor, TransChar.Yes, TransChar.No, a.Cols, a.Rows, aTS.Scale, a.A, a.Rows, -bS.Scale, b.A, b.Rows, r.A, r.Rows);
            return r;
        }

        public static matrix operator -(matrixTS aTS, matrixTS bTS)
        {
            var a = aTS.Matrix;
            var b = bTS.Matrix;
            if (a.Rows != b.Rows || a.Cols != b.Cols) ThrowHelper.ThrowIncorrectMatrixDimesionsForOperation();
            var r = new matrix(a.Cols, a.Rows);
            Blas.omatadd(LayoutChar.ColMajor, TransChar.Yes, TransChar.Yes, a.Cols, a.Rows, aTS.Scale, a.A, a.Rows, -bTS.Scale, b.A, b.Rows, r.A, r.Rows);
            return r;
        }

        public static matrix operator *(matrixTS aTS, matrix b)
        {
            var a = aTS.Matrix;
            if (a.Rows != b.Rows) ThrowHelper.ThrowIncorrectMatrixDimesionsForOperation();
            var r = new matrix(a.Cols, b.Cols);
            Blas.gemm(Layout.ColMajor, Trans.Yes, Trans.No, a.Cols, b.Cols, a.Rows, aTS.Scale, a.A, a.Rows, b.A, b.Rows, 0.0, r.A, a.Cols);
            return r;
        }

        public static matrix operator *(matrixTS aTS, matrixT bT)
        {
            var a = aTS.Matrix;
            var b = bT.Matrix;
            if (a.Rows != b.Cols) ThrowHelper.ThrowIncorrectMatrixDimesionsForOperation();
            var r = new matrix(a.Cols, b.Rows);
            Blas.gemm(Layout.ColMajor, Trans.Yes, Trans.Yes, a.Cols, b.Rows, a.Rows, aTS.Scale, a.A, a.Rows, b.A, b.Rows, 0.0, r.A, a.Cols);
            return r;
        }

        public static matrix operator *(matrixTS aTS, matrixS bS)
        {
            var a = aTS.Matrix;
            var b = bS.Matrix;
            if (a.Rows != b.Rows) ThrowHelper.ThrowIncorrectMatrixDimesionsForOperation();
            var r = new matrix(a.Cols, b.Cols);
            Blas.gemm(Layout.ColMajor, Trans.Yes, Trans.No, a.Cols, b.Cols, a.Rows, aTS.Scale * bS.Scale, a.A, a.Rows, b.A, b.Rows, 0.0, r.A, a.Cols);
            return r;
        }

        public static matrix operator *(matrixTS aTS, matrixTS bTS)
        {
            var a = aTS.Matrix;
            var b = bTS.Matrix;
            if (a.Rows != b.Cols) ThrowHelper.ThrowIncorrectMatrixDimesionsForOperation();
            var r = new matrix(a.Cols, b.Rows);
            Blas.gemm(Layout.ColMajor, Trans.Yes, Trans.Yes, a.Cols, b.Rows, a.Rows, aTS.Scale * bTS.Scale, a.A, a.Rows, b.A, b.Rows, 0.0, r.A, a.Cols);
            return r;
        }
    }
}

// TODO
// +(matrix, double)
// vector
// matrixF
// bespoke ArrayPool
// Pinned Object Heap and pinning optimisations.