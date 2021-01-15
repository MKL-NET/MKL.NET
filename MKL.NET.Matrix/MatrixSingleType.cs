using System;

namespace MKLNET
{
    public class matrixF : IDisposable
    {
        internal static ArrayPool<float> Pool = new(ArrayPool<float>.DefaultMaxNumberOfArraysPerBucket, Environment.Is64BitProcess ? 20 : 10);
        public readonly int Rows;
        public readonly int Cols;
        public float[] Array;
        public int Length => Rows * Cols;
        public matrixF(int rows, int cols)
        {
            Rows = rows;
            Cols = cols;
            Array = Pool.Rent(rows * cols);
        }
        public float this[int row, int col]
        {
            get => Array[col * Rows + row];
            set => Array[col * Rows + row] = value;
        }
        public void Dispose()
        {
            Pool.Return(Array);
            GC.SuppressFinalize(this);
        }
        ~matrixF() => Pool.Return(Array);
        public matrixFT T => new(this);
        public static matrixFS operator *(matrixF a, float s) => new(a, s);
        public static matrixFS operator *(float s, matrixF a) => new(a, s);
        public static matrixF operator +(matrixF m, float a) => Matrix.LinearFrac(m, m, 1.0f, a, 0.0f, 0.0f);
        public static matrixF operator +(float a, matrixF m) => Matrix.LinearFrac(m, m, 1.0f, a, 0.0f, 0.0f);

        public static matrixF operator +(matrixF a, matrixF b)
        {
            if (a.Rows != b.Rows || a.Cols != b.Cols) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new matrixF(a.Rows, a.Cols);
            Vml.Add(a.Length, a.Array, 0, 1, b.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrixF operator +(matrixF a, matrixFT bT)
        {
            var b = bT.Matrix;
            if (a.Rows != b.Cols || a.Cols != b.Rows) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new matrixF(a.Rows, a.Cols);
            Blas.omatadd(LayoutChar.ColMajor, TransChar.No, TransChar.Yes, a.Rows, a.Cols, 1.0f, a.Array, a.Rows, 1.0f, b.Array, b.Rows, r.Array, a.Rows);
            return r;
        }

        public static matrixF operator +(matrixF a, matrixFS bS)
        {
            var b = bS.Matrix;
            if (a.Rows != b.Rows || a.Cols != b.Cols) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new matrixF(a.Rows, a.Cols);
            Blas.omatadd(LayoutChar.ColMajor, TransChar.No, TransChar.No, a.Rows, a.Cols, 1.0f, a.Array, a.Rows, bS.Scale, b.Array, b.Rows, r.Array, a.Rows);
            return r;
        }

        public static matrixF operator +(matrixF a, matrixFTS bTS)
        {
            var b = bTS.Matrix;
            if (a.Rows != b.Cols || a.Cols != b.Rows) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new matrixF(a.Rows, a.Cols);
            Blas.omatadd(LayoutChar.ColMajor, TransChar.No, TransChar.Yes, a.Rows, a.Cols, 1.0f, a.Array, a.Rows, bTS.Scale, b.Array, b.Rows, r.Array, a.Rows);
            return r;
        }

        public static matrixF operator -(matrixF a, matrixF b)
        {
            if (a.Rows != b.Rows || a.Cols != b.Cols) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new matrixF(a.Rows, a.Cols);
            Vml.Sub(a.Length, a.Array, 0, 1, b.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static matrixF operator -(matrixF a, matrixFT bT)
        {
            var b = bT.Matrix;
            if (a.Rows != b.Cols || a.Cols != b.Rows) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new matrixF(a.Rows, a.Cols);
            Blas.omatadd(LayoutChar.ColMajor, TransChar.No, TransChar.Yes, a.Rows, a.Cols, 1.0f, a.Array, a.Rows, -1.0f, b.Array, b.Rows, r.Array, a.Rows);
            return r;
        }

        public static matrixF operator -(matrixF a, matrixFS bS)
        {
            var b = bS.Matrix;
            if (a.Rows != b.Rows || a.Cols != b.Cols) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new matrixF(a.Rows, a.Cols);
            Blas.omatadd(LayoutChar.ColMajor, TransChar.No, TransChar.No, a.Rows, a.Cols, 1.0f, a.Array, a.Rows, -bS.Scale, b.Array, b.Rows, r.Array, a.Rows);
            return r;
        }

        public static matrixF operator -(matrixF a, matrixFTS bTS)
        {
            var b = bTS.Matrix;
            if (a.Rows != b.Cols || a.Cols != b.Rows) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new matrixF(a.Rows, a.Cols);
            Blas.omatadd(LayoutChar.ColMajor, TransChar.No, TransChar.Yes, a.Rows, a.Cols, 1.0f, a.Array, a.Rows, -bTS.Scale, b.Array, b.Rows, r.Array, a.Rows);
            return r;
        }

        public static matrixF operator *(matrixF a, matrixF b)
        {
            if (a.Cols != b.Rows) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new matrixF(a.Rows, b.Cols);
            Blas.gemm(Layout.ColMajor, Trans.No, Trans.No, a.Rows, b.Cols, a.Cols, 1.0f, a.Array, a.Rows, b.Array, b.Rows, 0.0f, r.Array, a.Rows);
            return r;
        }

        public static matrixF operator *(matrixF a, matrixFT bT)
        {
            var b = bT.Matrix;
            if (a.Cols != b.Cols) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new matrixF(a.Rows, b.Rows);
            Blas.gemm(Layout.ColMajor, Trans.No, Trans.Yes, a.Rows, b.Rows, a.Cols, 1.0f, a.Array, a.Rows, b.Array, b.Rows, 0.0f, r.Array, a.Rows);
            return r;
        }

        public static matrixF operator *(matrixF a, matrixFS bS)
        {
            var b = bS.Matrix;
            if (a.Cols != b.Rows) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new matrixF(a.Rows, b.Cols);
            Blas.gemm(Layout.ColMajor, Trans.No, Trans.No, a.Rows, b.Cols, a.Cols, bS.Scale, a.Array, a.Rows, b.Array, b.Rows, 0.0f, r.Array, a.Rows);
            return r;
        }

        public static matrixF operator *(matrixF a, matrixFTS bTS)
        {
            var b = bTS.Matrix;
            if (a.Cols != b.Cols) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new matrixF(a.Rows, b.Rows);
            Blas.gemm(Layout.ColMajor, Trans.No, Trans.Yes, a.Rows, b.Rows, a.Cols, bTS.Scale, a.Array, a.Rows, b.Array, b.Rows, 0.0f, r.Array, a.Rows);
            return r;
        }

        public static vectorF operator *(matrixF a, vectorF b)
        {
            if (a.Cols != b.Length) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new vectorF(a.Rows);
            Blas.gemv(Layout.ColMajor, Trans.No, a.Rows, a.Cols, 1.0f, a.Array, a.Rows, b.Array, 0, 1, 0.0f, r.Array, 0, 1);
            return r;
        }

        public static vectorF operator *(matrixF a, vectorFS bS)
        {
            var b = bS.Vector;
            if (a.Cols != b.Length) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new vectorF(a.Rows);
            Blas.gemv(Layout.ColMajor, Trans.No, a.Rows, a.Cols, bS.Scale, a.Array, a.Rows, b.Array, 0, 1, 0.0f, r.Array, 0, 1);
            return r;
        }
    }

    public struct matrixFT
    {
        public readonly matrixF Matrix;
        internal matrixFT(matrixF m) => Matrix = m;
        public matrixF T => Matrix;
        public static matrixFTS operator *(matrixFT a, float s) => new(a.Matrix, s);
        public static matrixFTS operator *(float s, matrixFT a) => new(a.Matrix, s);
        public static matrixF operator +(matrixFT m, float a)
        {
            matrixF r = m;
            MKLNET.Matrix.Inplace.LinearFrac(r, r, 1.0f, a, 0.0f, 0.0f);
            return r;
        }
        public static matrixF operator +(float a, matrixFT m)
        {
            matrixF r = m;
            MKLNET.Matrix.Inplace.LinearFrac(r, r, 1.0f, a, 0.0f, 0.0f);
            return r;
        }

        public static implicit operator matrixF(matrixFT mT)
        {
            var m = mT.Matrix;
            var r = new matrixF(m.Cols, m.Rows);
            Blas.omatcopy(LayoutChar.ColMajor, TransChar.Yes, m.Rows, m.Cols, 1.0f, m.Array, m.Rows, r.Array, m.Cols);
            return r;
        }

        public static matrixF operator +(matrixFT aT, matrixF b)
        {
            var a = aT.Matrix;
            if (a.Cols != b.Rows || a.Rows != b.Cols) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new matrixF(a.Cols, a.Rows);
            Blas.omatadd(LayoutChar.ColMajor, TransChar.Yes, TransChar.No, a.Cols, a.Rows, 1.0f, a.Array, a.Rows, 1.0f, b.Array, b.Rows, r.Array, r.Rows);
            return r;
        }

        public static matrixF operator +(matrixFT aT, matrixFT bT)
        {
            var a = aT.Matrix;
            var b = bT.Matrix;
            if (a.Rows != b.Rows || a.Cols != b.Cols) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new matrixF(a.Cols, a.Rows);
            Blas.omatadd(LayoutChar.ColMajor, TransChar.Yes, TransChar.Yes, a.Cols, a.Rows, 1.0f, a.Array, a.Rows, 1.0f, b.Array, b.Rows, r.Array, r.Rows);
            return r;
        }

        public static matrixF operator +(matrixFT aT, matrixFS bS)
        {
            var a = aT.Matrix;
            var b = bS.Matrix;
            if (a.Cols != b.Rows || a.Rows != b.Cols) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new matrixF(a.Cols, a.Rows);
            Blas.omatadd(LayoutChar.ColMajor, TransChar.Yes, TransChar.No, a.Cols, a.Rows, 1.0f, a.Array, a.Rows, bS.Scale, b.Array, b.Rows, r.Array, r.Rows);
            return r;
        }

        public static matrixF operator +(matrixFT aT, matrixFTS bTS)
        {
            var a = aT.Matrix;
            var b = bTS.Matrix;
            if (a.Rows != b.Rows || a.Cols != b.Cols) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new matrixF(a.Cols, a.Rows);
            Blas.omatadd(LayoutChar.ColMajor, TransChar.Yes, TransChar.Yes, a.Cols, a.Rows, 1.0f, a.Array, a.Rows, bTS.Scale, b.Array, b.Rows, r.Array, r.Rows);
            return r;
        }

        public static matrixF operator -(matrixFT aT, matrixF b)
        {
            var a = aT.Matrix;
            if (a.Cols != b.Rows || a.Rows != b.Cols) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new matrixF(a.Cols, a.Rows);
            Blas.omatadd(LayoutChar.ColMajor, TransChar.Yes, TransChar.No, a.Cols, a.Rows, 1.0f, a.Array, a.Rows, -1.0f, b.Array, b.Rows, r.Array, r.Rows);
            return r;
        }

        public static matrixF operator -(matrixFT aT, matrixFT bT)
        {
            var a = aT.Matrix;
            var b = bT.Matrix;
            if (a.Rows != b.Rows || a.Cols != b.Cols) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new matrixF(a.Cols, a.Rows);
            Blas.omatadd(LayoutChar.ColMajor, TransChar.Yes, TransChar.Yes, a.Cols, a.Rows, 1.0f, a.Array, a.Rows, -1.0f, b.Array, b.Rows, r.Array, r.Rows);
            return r;
        }

        public static matrixF operator -(matrixFT aT, matrixFS bS)
        {
            var a = aT.Matrix;
            var b = bS.Matrix;
            if (a.Cols != b.Rows || a.Rows != b.Cols) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new matrixF(a.Cols, a.Rows);
            Blas.omatadd(LayoutChar.ColMajor, TransChar.Yes, TransChar.No, a.Cols, a.Rows, 1.0f, a.Array, a.Rows, -bS.Scale, b.Array, b.Rows, r.Array, r.Rows);
            return r;
        }

        public static matrixF operator -(matrixFT aT, matrixFTS bTS)
        {
            var a = aT.Matrix;
            var b = bTS.Matrix;
            if (a.Rows != b.Rows || a.Cols != b.Cols) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new matrixF(a.Cols, a.Rows);
            Blas.omatadd(LayoutChar.ColMajor, TransChar.Yes, TransChar.Yes, a.Cols, a.Rows, 1.0f, a.Array, a.Rows, -bTS.Scale, b.Array, b.Rows, r.Array, r.Rows);
            return r;
        }

        public static matrixF operator *(matrixFT aT, matrixF b)
        {
            var a = aT.Matrix;
            if (a.Rows != b.Rows) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new matrixF(a.Cols, b.Cols);
            Blas.gemm(Layout.ColMajor, Trans.Yes, Trans.No, a.Cols, b.Cols, a.Rows, 1.0f, a.Array, a.Rows, b.Array, b.Rows, 0.0f, r.Array, a.Cols);
            return r;
        }

        public static matrixF operator *(matrixFT aT, matrixFT bT)
        {
            var a = aT.Matrix;
            var b = bT.Matrix;
            if (a.Rows != b.Cols) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new matrixF(a.Cols, b.Rows);
            Blas.gemm(Layout.ColMajor, Trans.Yes, Trans.Yes, a.Cols, b.Rows, a.Rows, 1.0f, a.Array, a.Rows, b.Array, b.Rows, 0.0f, r.Array, a.Cols);
            return r;
        }

        public static matrixF operator *(matrixFT aT, matrixFS bS)
        {
            var a = aT.Matrix;
            var b = bS.Matrix;
            if (a.Rows != b.Rows) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new matrixF(a.Cols, b.Cols);
            Blas.gemm(Layout.ColMajor, Trans.Yes, Trans.No, a.Cols, b.Cols, a.Rows, bS.Scale, a.Array, a.Rows, b.Array, b.Rows, 0.0f, r.Array, a.Cols);
            return r;
        }

        public static matrixF operator *(matrixFT aT, matrixFTS bTS)
        {
            var a = aT.Matrix;
            var b = bTS.Matrix;
            if (a.Rows != b.Cols) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new matrixF(a.Cols, b.Rows);
            Blas.gemm(Layout.ColMajor, Trans.Yes, Trans.Yes, a.Cols, b.Rows, a.Rows, bTS.Scale, a.Array, a.Rows, b.Array, b.Rows, 0.0f, r.Array, a.Cols);
            return r;
        }

        public static vectorF operator *(matrixFT aT, vectorF b)
        {
            var a = aT.Matrix;
            if (a.Rows != b.Length) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new vectorF(a.Cols);
            Blas.gemv(Layout.ColMajor, Trans.Yes, a.Rows, a.Cols, 1.0f, a.Array, a.Rows, b.Array, 0, 1, 0.0f, r.Array, 0, 1);
            return r;
        }

        public static vectorF operator *(matrixFT aT, vectorFS bS)
        {
            var a = aT.Matrix;
            var b = bS.Vector;
            if (a.Rows != b.Length) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new vectorF(a.Cols);
            Blas.gemv(Layout.ColMajor, Trans.Yes, a.Rows, a.Cols, bS.Scale, a.Array, a.Rows, b.Array, 0, 1, 0.0f, r.Array, 0, 1);
            return r;
        }
    }

    public struct matrixFS
    {
        public readonly matrixF Matrix;
        public readonly float Scale;
        internal matrixFS(matrixF m, float s)
        {
            Matrix = m;
            Scale = s;
        }
        public matrixFTS T => new(Matrix, Scale);
        public static matrixFS operator *(matrixFS a, float s) => new(a.Matrix, a.Scale * s);
        public static matrixFS operator *(float s, matrixFS a) => new(a.Matrix, s * a.Scale);
        public static matrixF operator +(matrixFS m, float a) => MKLNET.Matrix.LinearFrac(m.Matrix, m.Matrix, m.Scale, a, 0.0f, 0.0f);
        public static matrixF operator +(float a, matrixFS m) => MKLNET.Matrix.LinearFrac(m.Matrix, m.Matrix, m.Scale, a, 0.0f, 0.0f);

        public static implicit operator matrixF(matrixFS mS)
        {
            var m = mS.Matrix;
            var r = new matrixF(m.Rows, m.Cols);
            Blas.omatcopy(LayoutChar.ColMajor, TransChar.No, m.Rows, m.Cols, mS.Scale, m.Array, m.Rows, r.Array, r.Rows);
            return r;
        }

        public static matrixF operator +(matrixFS aS, matrixF b)
        {
            var a = aS.Matrix;
            if (a.Rows != b.Rows || a.Cols != b.Cols) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new matrixF(a.Rows, a.Cols);
            Blas.omatadd(LayoutChar.ColMajor, TransChar.No, TransChar.No, a.Rows, a.Cols, aS.Scale, a.Array, a.Rows, 1.0f, b.Array, b.Rows, r.Array, a.Rows);
            return r;
        }

        public static matrixF operator +(matrixFS aS, matrixFT bT)
        {
            var a = aS.Matrix;
            var b = bT.Matrix;
            if (a.Rows != b.Cols || a.Cols != b.Rows) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new matrixF(a.Rows, a.Cols);
            Blas.omatadd(LayoutChar.ColMajor, TransChar.No, TransChar.Yes, a.Rows, a.Cols, aS.Scale, a.Array, a.Rows, 1.0f, b.Array, b.Rows, r.Array, a.Rows);
            return r;
        }

        public static matrixF operator +(matrixFS aS, matrixFS bS)
        {
            var a = aS.Matrix;
            var b = bS.Matrix;
            if (a.Rows != b.Rows || a.Cols != b.Cols) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new matrixF(a.Rows, a.Cols);
            Blas.omatadd(LayoutChar.ColMajor, TransChar.No, TransChar.No, a.Rows, a.Cols, aS.Scale, a.Array, a.Rows, bS.Scale, b.Array, b.Rows, r.Array, a.Rows);
            return r;
        }

        public static matrixF operator +(matrixFS aS, matrixFTS bTS)
        {
            var a = aS.Matrix;
            var b = bTS.Matrix;
            if (a.Rows != b.Cols || a.Cols != b.Rows) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new matrixF(a.Rows, a.Cols);
            Blas.omatadd(LayoutChar.ColMajor, TransChar.No, TransChar.Yes, a.Rows, a.Cols, aS.Scale, a.Array, a.Rows, bTS.Scale, b.Array, b.Rows, r.Array, a.Rows);
            return r;
        }

        public static matrixF operator -(matrixFS aS, matrixF b)
        {
            var a = aS.Matrix;
            if (a.Rows != b.Rows || a.Cols != b.Cols) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new matrixF(a.Rows, a.Cols);
            Blas.omatadd(LayoutChar.ColMajor, TransChar.No, TransChar.No, a.Rows, a.Cols, aS.Scale, a.Array, a.Rows, -1.0f, b.Array, b.Rows, r.Array, a.Rows);
            return r;
        }

        public static matrixF operator -(matrixFS aS, matrixFT bT)
        {
            var a = aS.Matrix;
            var b = bT.Matrix;
            if (a.Rows != b.Cols || a.Cols != b.Rows) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new matrixF(a.Rows, a.Cols);
            Blas.omatadd(LayoutChar.ColMajor, TransChar.No, TransChar.Yes, a.Rows, a.Cols, aS.Scale, a.Array, a.Rows, -1.0f, b.Array, b.Rows, r.Array, a.Rows);
            return r;
        }

        public static matrixF operator -(matrixFS aS, matrixFS bS)
        {
            var a = aS.Matrix;
            var b = bS.Matrix;
            if (a.Rows != b.Rows || a.Cols != b.Cols) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new matrixF(a.Rows, a.Cols);
            Blas.omatadd(LayoutChar.ColMajor, TransChar.No, TransChar.No, a.Rows, a.Cols, aS.Scale, a.Array, a.Rows, -bS.Scale, b.Array, b.Rows, r.Array, a.Rows);
            return r;
        }

        public static matrixF operator -(matrixFS aS, matrixFTS bTS)
        {
            var a = aS.Matrix;
            var b = bTS.Matrix;
            if (a.Rows != b.Cols || a.Cols != b.Rows) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new matrixF(a.Rows, a.Cols);
            Blas.omatadd(LayoutChar.ColMajor, TransChar.No, TransChar.Yes, a.Rows, a.Cols, aS.Scale, a.Array, a.Rows, -bTS.Scale, b.Array, b.Rows, r.Array, a.Rows);
            return r;
        }

        public static matrixF operator *(matrixFS aS, matrixF b)
        {
            var a = aS.Matrix;
            if (a.Cols != b.Rows) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new matrixF(a.Rows, b.Cols);
            Blas.gemm(Layout.ColMajor, Trans.No, Trans.No, a.Rows, b.Cols, a.Cols, aS.Scale, a.Array, a.Rows, b.Array, b.Rows, 0.0f, r.Array, a.Rows);
            return r;
        }

        public static matrixF operator *(matrixFS aS, matrixFT bT)
        {
            var a = aS.Matrix;
            var b = bT.Matrix;
            if (a.Cols != b.Cols) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new matrixF(a.Rows, b.Rows);
            Blas.gemm(Layout.ColMajor, Trans.No, Trans.Yes, a.Rows, b.Rows, a.Cols, aS.Scale, a.Array, a.Rows, b.Array, b.Rows, 0.0f, r.Array, a.Rows);
            return r;
        }

        public static matrixF operator *(matrixFS aS, matrixFS bS)
        {
            var a = aS.Matrix;
            var b = bS.Matrix;
            if (a.Cols != b.Rows) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new matrixF(a.Rows, b.Cols);
            Blas.gemm(Layout.ColMajor, Trans.No, Trans.No, a.Rows, b.Cols, a.Cols, aS.Scale * bS.Scale, a.Array, a.Rows, b.Array, b.Rows, 0.0f, r.Array, a.Rows);
            return r;
        }

        public static matrixF operator *(matrixFS aS, matrixFTS bTS)
        {
            var a = aS.Matrix;
            var b = bTS.Matrix;
            if (a.Cols != b.Cols) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new matrixF(a.Rows, b.Rows);
            Blas.gemm(Layout.ColMajor, Trans.No, Trans.Yes, a.Rows, b.Rows, a.Cols, aS.Scale * bTS.Scale, a.Array, a.Rows, b.Array, b.Rows, 0.0f, r.Array, a.Rows);
            return r;
        }

        public static vectorF operator *(matrixFS aS, vectorF b)
        {
            var a = aS.Matrix;
            if (a.Cols != b.Length) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new vectorF(a.Rows);
            Blas.gemv(Layout.ColMajor, Trans.No, a.Rows, a.Cols, aS.Scale, a.Array, a.Rows, b.Array, 0, 1, 0.0f, r.Array, 0, 1);
            return r;
        }

        public static vectorF operator *(matrixFS aS, vectorFS bS)
        {
            var a = aS.Matrix;
            var b = bS.Vector;
            if (a.Cols != b.Length) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new vectorF(a.Rows);
            Blas.gemv(Layout.ColMajor, Trans.No, a.Rows, a.Cols, aS.Scale * bS.Scale, a.Array, a.Rows, b.Array, 0, 1, 0.0f, r.Array, 0, 1);
            return r;
        }
    }

    public struct matrixFTS
    {
        public readonly matrixF Matrix;
        public readonly float Scale;
        internal matrixFTS(matrixF m, float s)
        {
            Matrix = m;
            Scale = s;
        }
        public matrixFS T => new(Matrix, Scale);
        public static matrixFTS operator *(matrixFTS a, float s) => new(a.Matrix, a.Scale * s);
        public static matrixFTS operator *(float s, matrixFTS a) => new(a.Matrix, s * a.Scale);
        public static matrixF operator +(matrixFTS m, float a)
        {
            matrixF r = m;
            MKLNET.Matrix.Inplace.LinearFrac(r, r, 1.0f, a, 0.0f, 0.0f);
            return r;
        }
        public static matrixF operator +(float a, matrixFTS m)
        {
            matrixF r = m;
            MKLNET.Matrix.Inplace.LinearFrac(r, r, 1.0f, a, 0.0f, 0.0f);
            return r;
        }

        public static implicit operator matrixF(matrixFTS mTS)
        {
            var m = mTS.Matrix;
            var r = new matrixF(m.Cols, m.Rows);
            Blas.omatcopy(LayoutChar.ColMajor, TransChar.Yes, m.Rows, m.Cols, mTS.Scale, m.Array, m.Rows, r.Array, m.Cols);
            return r;
        }

        public static matrixF operator +(matrixFTS aTS, matrixF b)
        {
            var a = aTS.Matrix;
            if (a.Cols != b.Rows || a.Rows != b.Cols) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new matrixF(a.Cols, a.Rows);
            Blas.omatadd(LayoutChar.ColMajor, TransChar.Yes, TransChar.No, a.Cols, a.Rows, aTS.Scale, a.Array, a.Rows, 1.0f, b.Array, b.Rows, r.Array, r.Rows);
            return r;
        }

        public static matrixF operator +(matrixFTS aTS, matrixFT bT)
        {
            var a = aTS.Matrix;
            var b = bT.Matrix;
            if (a.Rows != b.Rows || a.Cols != b.Cols) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new matrixF(a.Cols, a.Rows);
            Blas.omatadd(LayoutChar.ColMajor, TransChar.Yes, TransChar.Yes, a.Cols, a.Rows, aTS.Scale, a.Array, a.Rows, 1.0f, b.Array, b.Rows, r.Array, r.Rows);
            return r;
        }

        public static matrixF operator +(matrixFTS aTS, matrixFS bS)
        {
            var a = aTS.Matrix;
            var b = bS.Matrix;
            if (a.Cols != b.Rows || a.Rows != b.Cols) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new matrixF(a.Cols, a.Rows);
            Blas.omatadd(LayoutChar.ColMajor, TransChar.Yes, TransChar.No, a.Cols, a.Rows, aTS.Scale, a.Array, a.Rows, bS.Scale, b.Array, b.Rows, r.Array, r.Rows);
            return r;
        }

        public static matrixF operator +(matrixFTS aTS, matrixFTS bTS)
        {
            var a = aTS.Matrix;
            var b = bTS.Matrix;
            if (a.Rows != b.Rows || a.Cols != b.Cols) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new matrixF(a.Cols, a.Rows);
            Blas.omatadd(LayoutChar.ColMajor, TransChar.Yes, TransChar.Yes, a.Cols, a.Rows, aTS.Scale, a.Array, a.Rows, bTS.Scale, b.Array, b.Rows, r.Array, r.Rows);
            return r;
        }

        public static matrixF operator -(matrixFTS aTS, matrixF b)
        {
            var a = aTS.Matrix;
            if (a.Cols != b.Rows || a.Rows != b.Cols) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new matrixF(a.Cols, a.Rows);
            Blas.omatadd(LayoutChar.ColMajor, TransChar.Yes, TransChar.No, a.Cols, a.Rows, aTS.Scale, a.Array, a.Rows, -1.0f, b.Array, b.Rows, r.Array, r.Rows);
            return r;
        }

        public static matrixF operator -(matrixFTS aTS, matrixFT bT)
        {
            var a = aTS.Matrix;
            var b = bT.Matrix;
            if (a.Rows != b.Rows || a.Cols != b.Cols) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new matrixF(a.Cols, a.Rows);
            Blas.omatadd(LayoutChar.ColMajor, TransChar.Yes, TransChar.Yes, a.Cols, a.Rows, aTS.Scale, a.Array, a.Rows, -1.0f, b.Array, b.Rows, r.Array, r.Rows);
            return r;
        }

        public static matrixF operator -(matrixFTS aTS, matrixFS bS)
        {
            var a = aTS.Matrix;
            var b = bS.Matrix;
            if (a.Cols != b.Rows || a.Rows != b.Cols) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new matrixF(a.Cols, a.Rows);
            Blas.omatadd(LayoutChar.ColMajor, TransChar.Yes, TransChar.No, a.Cols, a.Rows, aTS.Scale, a.Array, a.Rows, -bS.Scale, b.Array, b.Rows, r.Array, r.Rows);
            return r;
        }

        public static matrixF operator -(matrixFTS aTS, matrixFTS bTS)
        {
            var a = aTS.Matrix;
            var b = bTS.Matrix;
            if (a.Rows != b.Rows || a.Cols != b.Cols) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new matrixF(a.Cols, a.Rows);
            Blas.omatadd(LayoutChar.ColMajor, TransChar.Yes, TransChar.Yes, a.Cols, a.Rows, aTS.Scale, a.Array, a.Rows, -bTS.Scale, b.Array, b.Rows, r.Array, r.Rows);
            return r;
        }

        public static matrixF operator *(matrixFTS aTS, matrixF b)
        {
            var a = aTS.Matrix;
            if (a.Rows != b.Rows) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new matrixF(a.Cols, b.Cols);
            Blas.gemm(Layout.ColMajor, Trans.Yes, Trans.No, a.Cols, b.Cols, a.Rows, aTS.Scale, a.Array, a.Rows, b.Array, b.Rows, 0.0f, r.Array, a.Cols);
            return r;
        }

        public static matrixF operator *(matrixFTS aTS, matrixFT bT)
        {
            var a = aTS.Matrix;
            var b = bT.Matrix;
            if (a.Rows != b.Cols) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new matrixF(a.Cols, b.Rows);
            Blas.gemm(Layout.ColMajor, Trans.Yes, Trans.Yes, a.Cols, b.Rows, a.Rows, aTS.Scale, a.Array, a.Rows, b.Array, b.Rows, 0.0f, r.Array, a.Cols);
            return r;
        }

        public static matrixF operator *(matrixFTS aTS, matrixFS bS)
        {
            var a = aTS.Matrix;
            var b = bS.Matrix;
            if (a.Rows != b.Rows) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new matrixF(a.Cols, b.Cols);
            Blas.gemm(Layout.ColMajor, Trans.Yes, Trans.No, a.Cols, b.Cols, a.Rows, aTS.Scale * bS.Scale, a.Array, a.Rows, b.Array, b.Rows, 0.0f, r.Array, a.Cols);
            return r;
        }

        public static matrixF operator *(matrixFTS aTS, matrixFTS bTS)
        {
            var a = aTS.Matrix;
            var b = bTS.Matrix;
            if (a.Rows != b.Cols) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new matrixF(a.Cols, b.Rows);
            Blas.gemm(Layout.ColMajor, Trans.Yes, Trans.Yes, a.Cols, b.Rows, a.Rows, aTS.Scale * bTS.Scale, a.Array, a.Rows, b.Array, b.Rows, 0.0f, r.Array, a.Cols);
            return r;
        }

        public static vectorF operator *(matrixFTS aTS, vectorF b)
        {
            var a = aTS.Matrix;
            if (a.Rows != b.Length) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new vectorF(a.Cols);
            Blas.gemv(Layout.ColMajor, Trans.Yes, a.Rows, a.Cols, aTS.Scale, a.Array, a.Rows, b.Array, 0, 1, 0.0f, r.Array, 0, 1);
            return r;
        }

        public static vectorF operator *(matrixFTS aTS, vectorFS bS)
        {
            var a = aTS.Matrix;
            var b = bS.Vector;
            if (a.Rows != b.Length) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new vectorF(a.Cols);
            Blas.gemv(Layout.ColMajor, Trans.Yes, a.Rows, a.Cols, aTS.Scale * bS.Scale, a.Array, a.Rows, b.Array, 0, 1, 0.0f, r.Array, 0, 1);
            return r;
        }
    }
}