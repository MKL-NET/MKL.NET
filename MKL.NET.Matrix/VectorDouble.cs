using System;
using System.Buffers;

namespace MKLNET
{
    public class vector : IDisposable
    {
        public readonly int Length;
        internal double[] A;
        public vector(int length)
        {
            Length = length;
            A = ArrayPool<double>.Shared.Rent(length);
        }
        public double this[int i]
        {
            get => A[i];
            set => A[i] = value;
        }
        public void Dispose()
        {
            ArrayPool<double>.Shared.Return(A);
            A = null;
            GC.SuppressFinalize(this);
        }
        ~vector() => ArrayPool<double>.Shared.Return(A);
        public vectorT T => new vectorT(this);
        public static vectorS operator *(vector a, double s) => new vectorS(a, s);
        public static vectorS operator *(double s, vector a) => new vectorS(a, s);

        public static vector operator +(vector a, vector b)
        {
            if (a.Length != b.Length) ThrowHelper.ThrowIncorrectVectorDimensionsForOperation();
            var r = new vector(a.Length);
            Vml.Add(a.Length, a.A, 0, 1, b.A, 0, 1, r.A, 0, 1);
            return r;
        }

        public static vector operator +(vector a, vectorS bS)
        {
            var b = bS.Vector;
            if (a.Length != b.Length) ThrowHelper.ThrowIncorrectVectorDimensionsForOperation();
            var r = new vector(a.Length);
            Blas.omatadd(LayoutChar.ColMajor, TransChar.No, TransChar.No, a.Length, 1, 1.0, a.A, a.Length, bS.Scale, b.A, a.Length, r.A, a.Length);
            return r;
        }

        public static vector operator -(vector a, vector b)
        {
            if (a.Length != b.Length) ThrowHelper.ThrowIncorrectVectorDimensionsForOperation();
            var r = new vector(a.Length);
            Vml.Sub(a.Length, a.A, 0, 1, b.A, 0, 1, r.A, 0, 1);
            return r;
        }

        public static vector operator -(vector a, vectorS bS)
        {
            var b = bS.Vector;
            if (a.Length != b.Length) ThrowHelper.ThrowIncorrectVectorDimensionsForOperation();
            var r = new vector(a.Length);
            Blas.omatadd(LayoutChar.ColMajor, TransChar.No, TransChar.No, a.Length, 1, 1.0, a.A, a.Length, -bS.Scale, b.A, a.Length, r.A, a.Length);
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

        public static vectorT operator +(vectorT aT, vectorT bT)
        {
            var a = aT.Vector;
            var b = bT.Vector;
            if (a.Length != b.Length) ThrowHelper.ThrowIncorrectVectorDimensionsForOperation();
            var r = new vector(a.Length);
            Vml.Add(a.Length, a.A, 0, 1, b.A, 0, 1, r.A, 0, 1);
            return new vectorT(r);
        }

        public static vectorT operator +(vectorT aT, vectorTS bTS)
        {
            var a = aT.Vector;
            var b = bTS.Vector;
            if (a.Length != b.Length) ThrowHelper.ThrowIncorrectVectorDimensionsForOperation();
            var r = new vector(a.Length);
            Blas.omatadd(LayoutChar.ColMajor, TransChar.No, TransChar.No, a.Length, 1, 1.0, a.A, a.Length, bTS.Scale, b.A, a.Length, r.A, a.Length);
            return new vectorT(r);
        }

        public static vectorT operator -(vectorT aT, vectorT bT)
        {
            var a = aT.Vector;
            var b = bT.Vector;
            if (a.Length != b.Length) ThrowHelper.ThrowIncorrectVectorDimensionsForOperation();
            var r = new vector(a.Length);
            Vml.Sub(a.Length, a.A, 0, 1, b.A, 0, 1, r.A, 0, 1);
            return new vectorT(r);
        }

        public static vectorT operator -(vectorT aT, vectorTS bTS)
        {
            var a = aT.Vector;
            var b = bTS.Vector;
            if (a.Length != b.Length) ThrowHelper.ThrowIncorrectVectorDimensionsForOperation();
            var r = new vector(a.Length);
            Blas.omatadd(LayoutChar.ColMajor, TransChar.No, TransChar.No, a.Length, 1, 1.0, a.A, a.Length, -bTS.Scale, b.A, a.Length, r.A, a.Length);
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

        public static vector operator +(vectorS aS, vector b)
        {
            var a = aS.Vector;
            if (a.Length != b.Length) ThrowHelper.ThrowIncorrectVectorDimensionsForOperation();
            var r = new vector(a.Length);
            Blas.omatadd(LayoutChar.ColMajor, TransChar.No, TransChar.No, a.Length, 1, aS.Scale, a.A, a.Length, 1.0, b.A, a.Length, r.A, a.Length);
            return r;
        }

        public static vector operator +(vectorS aS, vectorS bS)
        {
            var a = aS.Vector;
            var b = bS.Vector;
            if (a.Length != b.Length) ThrowHelper.ThrowIncorrectVectorDimensionsForOperation();
            var r = new vector(a.Length);
            Blas.omatadd(LayoutChar.ColMajor, TransChar.No, TransChar.No, a.Length, 1, aS.Scale, a.A, a.Length, bS.Scale, b.A, a.Length, r.A, a.Length);
            return r;
        }

        public static vector operator -(vectorS aS, vector b)
        {
            var a = aS.Vector;
            if (a.Length != b.Length) ThrowHelper.ThrowIncorrectVectorDimensionsForOperation();
            var r = new vector(a.Length);
            Blas.omatadd(LayoutChar.ColMajor, TransChar.No, TransChar.No, a.Length, 1, aS.Scale, a.A, a.Length, -1.0, b.A, a.Length, r.A, a.Length);
            return r;
        }

        public static vector operator -(vectorS aS, vectorS bS)
        {
            var a = aS.Vector;
            var b = bS.Vector;
            if (a.Length != b.Length) ThrowHelper.ThrowIncorrectVectorDimensionsForOperation();
            var r = new vector(a.Length);
            Blas.omatadd(LayoutChar.ColMajor, TransChar.No, TransChar.No, a.Length, 1, aS.Scale, a.A, a.Length, -bS.Scale, b.A, a.Length, r.A, a.Length);
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

        public static vectorT operator +(vectorTS aTS, vectorT bT)
        {
            var a = aTS.Vector;
            var b = bT.Vector;
            if (a.Length != b.Length) ThrowHelper.ThrowIncorrectVectorDimensionsForOperation();
            var r = new vector(a.Length);
            Blas.omatadd(LayoutChar.ColMajor, TransChar.No, TransChar.No, a.Length, 1, aTS.Scale, a.A, a.Length, 1.0, b.A, a.Length, r.A, a.Length);
            return new vectorT(r);
        }

        public static vectorT operator +(vectorTS aTS, vectorTS bTS)
        {
            var a = aTS.Vector;
            var b = bTS.Vector;
            if (a.Length != b.Length) ThrowHelper.ThrowIncorrectVectorDimensionsForOperation();
            var r = new vector(a.Length);
            Blas.omatadd(LayoutChar.ColMajor, TransChar.No, TransChar.No, a.Length, 1, aTS.Scale, a.A, a.Length, bTS.Scale, b.A, a.Length, r.A, a.Length);
            return new vectorT(r);
        }

        public static vectorT operator -(vectorTS aTS, vectorT bT)
        {
            var a = aTS.Vector;
            var b = bT.Vector;
            if (a.Length != b.Length) ThrowHelper.ThrowIncorrectVectorDimensionsForOperation();
            var r = new vector(a.Length);
            Blas.omatadd(LayoutChar.ColMajor, TransChar.No, TransChar.No, a.Length, 1, aTS.Scale, a.A, a.Length, -1.0, b.A, a.Length, r.A, a.Length);
            return new vectorT(r);
        }

        public static vectorT operator -(vectorTS aTS, vectorTS bTS)
        {
            var a = aTS.Vector;
            var b = bTS.Vector;
            if (a.Length != b.Length) ThrowHelper.ThrowIncorrectVectorDimensionsForOperation();
            var r = new vector(a.Length);
            Blas.omatadd(LayoutChar.ColMajor, TransChar.No, TransChar.No, a.Length, 1, aTS.Scale, a.A, a.Length, -bTS.Scale, b.A, a.Length, r.A, a.Length);
            return new vectorT(r);
        }
    }
}