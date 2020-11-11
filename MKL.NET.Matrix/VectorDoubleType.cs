using System;
using System.Buffers;

namespace MKLNET
{
    public class vector : IDisposable
    {
        public readonly int Length;
        public double[] Array;
        public vector(int length)
        {
            Length = length;
            Array = ArrayPool<double>.Shared.Rent(length);
        }
        public double this[int i]
        {
            get => Array[i];
            set => Array[i] = value;
        }
        public void Dispose()
        {
            ArrayPool<double>.Shared.Return(Array);
            Array = null;
            GC.SuppressFinalize(this);
        }
        ~vector() => ArrayPool<double>.Shared.Return(Array);
        public vectorT T => new vectorT(this);
        public static vectorS operator *(vector a, double s) => new vectorS(a, s);
        public static vectorS operator *(double s, vector a) => new vectorS(a, s);
        public static vector operator +(vector m, double a) => Vector.LinearFrac(m, m, 1.0, a, 0.0, 0.0);
        public static vector operator +(double a, vector m) => Vector.LinearFrac(m, m, 1.0, a, 0.0, 0.0);

        public static vector operator +(vector a, vector b)
        {
            if (a.Length != b.Length) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new vector(a.Length);
            Vml.Add(a.Length, a.Array, 0, 1, b.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static vector operator +(vector a, vectorS bS)
        {
            var b = bS.Vector;
            if (a.Length != b.Length) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new vector(a.Length);
            Blas.omatadd(LayoutChar.ColMajor, TransChar.No, TransChar.No, a.Length, 1, 1.0, a.Array, a.Length, bS.Scale, b.Array, a.Length, r.Array, a.Length);
            return r;
        }

        public static vector operator -(vector a, vector b)
        {
            if (a.Length != b.Length) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new vector(a.Length);
            Vml.Sub(a.Length, a.Array, 0, 1, b.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static vector operator -(vector a, vectorS bS)
        {
            var b = bS.Vector;
            if (a.Length != b.Length) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new vector(a.Length);
            Blas.omatadd(LayoutChar.ColMajor, TransChar.No, TransChar.No, a.Length, 1, 1.0, a.Array, a.Length, -bS.Scale, b.Array, a.Length, r.Array, a.Length);
            return r;
        }

        public static matrix operator *(vector a, vectorT bT)
        {
            var b = bT.Vector;
            var r = new matrix(a.Length, b.Length);
            Blas.gemm(Layout.ColMajor, Trans.No, Trans.Yes, a.Length, b.Length, 1, 1.0, a.Array, a.Length, b.Array, b.Length, 0.0, r.Array, r.Rows);
            return r;
        }

        public static matrix operator *(vector a, vectorTS bTS)
        {
            var b = bTS.Vector;
            var r = new matrix(a.Length, b.Length);
            Blas.gemm(Layout.ColMajor, Trans.No, Trans.Yes, a.Length, b.Length, 1, bTS.Scale, a.Array, a.Length, b.Array, b.Length, 0.0, r.Array, r.Rows);
            return r;
        }
    }

    public struct vectorT
    {
        public readonly vector Vector;
        internal vectorT(vector v) => Vector = v;

        public vector T => Vector;
        public static vectorTS operator *(vectorT a, double s) => new vectorTS(a.Vector, s);
        public static vectorTS operator *(double s, vectorT a) => new vectorTS(a.Vector, s);
        public static vectorT operator +(vectorT m, double a) => new vectorT(MKLNET.Vector.LinearFrac(m.Vector, m.Vector, 1.0, a, 0.0, 0.0));
        public static vectorT operator +(double a, vectorT m) => new vectorT(MKLNET.Vector.LinearFrac(m.Vector, m.Vector, 1.0, a, 0.0, 0.0));
        public static vectorT operator +(vectorT aT, vectorT bT)
        {
            var a = aT.Vector;
            var b = bT.Vector;
            if (a.Length != b.Length) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new vector(a.Length);
            Vml.Add(a.Length, a.Array, 0, 1, b.Array, 0, 1, r.Array, 0, 1);
            return new vectorT(r);
        }

        public static vectorT operator +(vectorT aT, vectorTS bTS)
        {
            var a = aT.Vector;
            var b = bTS.Vector;
            if (a.Length != b.Length) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new vector(a.Length);
            Blas.omatadd(LayoutChar.ColMajor, TransChar.No, TransChar.No, a.Length, 1, 1.0, a.Array, a.Length, bTS.Scale, b.Array, a.Length, r.Array, a.Length);
            return new vectorT(r);
        }

        public static vectorT operator -(vectorT aT, vectorT bT)
        {
            var a = aT.Vector;
            var b = bT.Vector;
            if (a.Length != b.Length) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new vector(a.Length);
            Vml.Sub(a.Length, a.Array, 0, 1, b.Array, 0, 1, r.Array, 0, 1);
            return new vectorT(r);
        }

        public static vectorT operator -(vectorT aT, vectorTS bTS)
        {
            var a = aT.Vector;
            var b = bTS.Vector;
            if (a.Length != b.Length) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new vector(a.Length);
            Blas.omatadd(LayoutChar.ColMajor, TransChar.No, TransChar.No, a.Length, 1, 1.0, a.Array, a.Length, -bTS.Scale, b.Array, a.Length, r.Array, a.Length);
            return new vectorT(r);
        }

        public static double operator *(vectorT aT, vector b)
        {
            var a = aT.Vector;
            if (a.Length != b.Length) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = Blas.dot(a.Length, a.Array, 0, 1, b.Array, 0, 1);
            return r;
        }

        public static double operator *(vectorT aT, vectorS bS)
        {
            var a = aT.Vector;
            var b = bS.Vector;
            if (a.Length != b.Length) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = Blas.dot(a.Length, a.Array, 0, 1, b.Array, 0, 1);
            return r * bS.Scale;
        }

        public static vectorT operator *(vectorT aT, matrix b)
        {
            var a = aT.Vector;
            if (a.Length != b.Rows) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new vector(b.Cols);
            Blas.gemm(Layout.ColMajor, Trans.No, Trans.No, 1, b.Cols, a.Length, 1.0, a.Array, 1, b.Array, b.Rows, 0.0, r.Array, 1);
            return new vectorT(r);
        }

        public static vectorT operator *(vectorT aT, matrixT bT)
        {
            var a = aT.Vector;
            var b = bT.Matrix;
            if (a.Length != b.Cols) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new vector(b.Rows);
            Blas.gemm(Layout.ColMajor, Trans.No, Trans.Yes, 1, b.Rows, a.Length, 1.0, a.Array, 1, b.Array, b.Rows, 0.0, r.Array, 1);
            return new vectorT(r);
        }

        public static vectorT operator *(vectorT aT, matrixS bS)
        {
            var a = aT.Vector;
            var b = bS.Matrix;
            if (a.Length != b.Rows) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new vector(b.Cols);
            Blas.gemm(Layout.ColMajor, Trans.No, Trans.No, 1, b.Cols, a.Length, bS.Scale, a.Array, 1, b.Array, b.Rows, 0.0, r.Array, 1);
            return new vectorT(r);
        }

        public static vectorT operator *(vectorT aT, matrixTS bTS)
        {
            var a = aT.Vector;
            var b = bTS.Matrix;
            if (a.Length != b.Cols) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new vector(b.Rows);
            Blas.gemm(Layout.ColMajor, Trans.No, Trans.Yes, 1, b.Rows, a.Length, bTS.Scale, a.Array, 1, b.Array, b.Rows, 0.0, r.Array, 1);
            return new vectorT(r);
        }
    }

    public struct vectorS
    {
        public readonly vector Vector;
        public readonly double Scale;
        internal vectorS(vector v, double s)
        {
            Vector = v;
            Scale = s;
        }

        public vectorTS T => new vectorTS(Vector, Scale);
        public static vectorS operator *(vectorS a, double s) => new vectorS(a.Vector, a.Scale * s);
        public static vectorS operator *(double s, vectorS a) => new vectorS(a.Vector, s * a.Scale);
        public static vector operator +(vectorS m, double a) => MKLNET.Vector.LinearFrac(m.Vector, m.Vector, m.Scale, a, 0.0, 0.0);
        public static vector operator +(double a, vectorS m) => MKLNET.Vector.LinearFrac(m.Vector, m.Vector, m.Scale, a, 0.0, 0.0);

        public static implicit operator vector(vectorS vS)
        {
            var v = vS.Vector;
            var r = new vector(v.Length);
            Blas.omatcopy(LayoutChar.ColMajor, TransChar.No, v.Length, 1, vS.Scale, v.Array, v.Length, r.Array, v.Length);
            return r;
        }

        public static vector operator +(vectorS aS, vector b)
        {
            var a = aS.Vector;
            if (a.Length != b.Length) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new vector(a.Length);
            Blas.omatadd(LayoutChar.ColMajor, TransChar.No, TransChar.No, a.Length, 1, aS.Scale, a.Array, a.Length, 1.0, b.Array, a.Length, r.Array, a.Length);
            return r;
        }

        public static vector operator +(vectorS aS, vectorS bS)
        {
            var a = aS.Vector;
            var b = bS.Vector;
            if (a.Length != b.Length) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new vector(a.Length);
            Blas.omatadd(LayoutChar.ColMajor, TransChar.No, TransChar.No, a.Length, 1, aS.Scale, a.Array, a.Length, bS.Scale, b.Array, a.Length, r.Array, a.Length);
            return r;
        }

        public static vector operator -(vectorS aS, vector b)
        {
            var a = aS.Vector;
            if (a.Length != b.Length) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new vector(a.Length);
            Blas.omatadd(LayoutChar.ColMajor, TransChar.No, TransChar.No, a.Length, 1, aS.Scale, a.Array, a.Length, -1.0, b.Array, a.Length, r.Array, a.Length);
            return r;
        }

        public static vector operator -(vectorS aS, vectorS bS)
        {
            var a = aS.Vector;
            var b = bS.Vector;
            if (a.Length != b.Length) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new vector(a.Length);
            Blas.omatadd(LayoutChar.ColMajor, TransChar.No, TransChar.No, a.Length, 1, aS.Scale, a.Array, a.Length, -bS.Scale, b.Array, a.Length, r.Array, a.Length);
            return r;
        }

        public static matrix operator *(vectorS aS, vectorT bT)
        {
            var a = aS.Vector;
            var b = bT.Vector;
            var r = new matrix(a.Length, b.Length);
            Blas.gemm(Layout.ColMajor, Trans.No, Trans.Yes, a.Length, b.Length, 1, aS.Scale, a.Array, a.Length, b.Array, b.Length, 0.0, r.Array, r.Rows);
            return r;
        }

        public static matrix operator *(vectorS aS, vectorTS bTS)
        {
            var a = aS.Vector;
            var b = bTS.Vector;
            var r = new matrix(a.Length, b.Length);
            Blas.gemm(Layout.ColMajor, Trans.No, Trans.Yes, a.Length, b.Length, 1, aS.Scale * bTS.Scale, a.Array, a.Length, b.Array, b.Length, 0.0, r.Array, r.Rows);
            return r;
        }
    }

    public struct vectorTS
    {
        public readonly vector Vector;
        public readonly double Scale;
        internal vectorTS(vector v, double s)
        {
            Vector = v;
            Scale = s;
        }

        public vectorS T => new vectorS(Vector, Scale);
        public static vectorTS operator *(vectorTS a, double s) => new vectorTS(a.Vector, a.Scale * s);
        public static vectorTS operator *(double s, vectorTS a) => new vectorTS(a.Vector, s * a.Scale);
        public static vectorT operator +(vectorTS m, double a) => new vectorT(MKLNET.Vector.LinearFrac(m.Vector, m.Vector, m.Scale, a, 0.0, 0.0));
        public static vectorT operator +(double a, vectorTS m) => new vectorT(MKLNET.Vector.LinearFrac(m.Vector, m.Vector, m.Scale, a, 0.0, 0.0));
        public static vectorT operator +(vectorTS aTS, vectorT bT)
        {
            var a = aTS.Vector;
            var b = bT.Vector;
            if (a.Length != b.Length) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new vector(a.Length);
            Blas.omatadd(LayoutChar.ColMajor, TransChar.No, TransChar.No, a.Length, 1, aTS.Scale, a.Array, a.Length, 1.0, b.Array, a.Length, r.Array, a.Length);
            return new vectorT(r);
        }

        public static vectorT operator +(vectorTS aTS, vectorTS bTS)
        {
            var a = aTS.Vector;
            var b = bTS.Vector;
            if (a.Length != b.Length) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new vector(a.Length);
            Blas.omatadd(LayoutChar.ColMajor, TransChar.No, TransChar.No, a.Length, 1, aTS.Scale, a.Array, a.Length, bTS.Scale, b.Array, a.Length, r.Array, a.Length);
            return new vectorT(r);
        }

        public static vectorT operator -(vectorTS aTS, vectorT bT)
        {
            var a = aTS.Vector;
            var b = bT.Vector;
            if (a.Length != b.Length) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new vector(a.Length);
            Blas.omatadd(LayoutChar.ColMajor, TransChar.No, TransChar.No, a.Length, 1, aTS.Scale, a.Array, a.Length, -1.0, b.Array, a.Length, r.Array, a.Length);
            return new vectorT(r);
        }

        public static vectorT operator -(vectorTS aTS, vectorTS bTS)
        {
            var a = aTS.Vector;
            var b = bTS.Vector;
            if (a.Length != b.Length) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new vector(a.Length);
            Blas.omatadd(LayoutChar.ColMajor, TransChar.No, TransChar.No, a.Length, 1, aTS.Scale, a.Array, a.Length, -bTS.Scale, b.Array, a.Length, r.Array, a.Length);
            return new vectorT(r);
        }

        public static double operator *(vectorTS aTS, vector b)
        {
            var a = aTS.Vector;
            if (a.Length != b.Length) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = Blas.dot(a.Length, a.Array, 0, 1, b.Array, 0, 1);
            return aTS.Scale * r;
        }

        public static double operator *(vectorTS aTS, vectorS bS)
        {
            var a = aTS.Vector;
            var b = bS.Vector;
            if (a.Length != b.Length) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = Blas.dot(a.Length, a.Array, 0, 1, b.Array, 0, 1);
            return aTS.Scale * r * bS.Scale;
        }

        public static vectorT operator *(vectorTS aTS, matrix b)
        {
            var a = aTS.Vector;
            if (a.Length != b.Rows) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new vector(b.Cols);
            Blas.gemm(Layout.ColMajor, Trans.No, Trans.No, 1, b.Cols, a.Length, aTS.Scale, a.Array, 1, b.Array, b.Rows, 0.0, r.Array, 1);
            return new vectorT(r);
        }

        public static vectorT operator *(vectorTS aTS, matrixT bT)
        {
            var a = aTS.Vector;
            var b = bT.Matrix;
            if (a.Length != b.Cols) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new vector(b.Rows);
            Blas.gemm(Layout.ColMajor, Trans.No, Trans.Yes, 1, b.Rows, a.Length, aTS.Scale, a.Array, 1, b.Array, b.Rows, 0.0, r.Array, 1);
            return new vectorT(r);
        }

        public static vectorT operator *(vectorTS aTS, matrixS bS)
        {
            var a = aTS.Vector;
            var b = bS.Matrix;
            if (a.Length != b.Rows) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new vector(b.Cols);
            Blas.gemm(Layout.ColMajor, Trans.No, Trans.No, 1, b.Cols, a.Length, aTS.Scale * bS.Scale, a.Array, 1, b.Array, b.Rows, 0.0, r.Array, 1);
            return new vectorT(r);
        }

        public static vectorT operator *(vectorTS aTS, matrixTS bTS)
        {
            var a = aTS.Vector;
            var b = bTS.Matrix;
            if (a.Length != b.Cols) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new vector(b.Rows);
            Blas.gemm(Layout.ColMajor, Trans.No, Trans.Yes, 1, b.Rows, a.Length, aTS.Scale * bTS.Scale, a.Array, 1, b.Array, b.Rows, 0.0, r.Array, 1);
            return new vectorT(r);
        }
    }
}