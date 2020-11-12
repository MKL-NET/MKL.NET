using System;

namespace MKLNET
{
    public class vectorF : IDisposable
    {
        public readonly int Length;
        public float[] Array;
        public vectorF(int length)
        {
            Length = length;
            Array = matrixF.Pool.Rent(length);
        }
        public float this[int i]
        {
            get => Array[i];
            set => Array[i] = value;
        }
        public void Dispose()
        {
            matrixF.Pool.Return(Array);
            GC.SuppressFinalize(this);
        }
        ~vectorF() => matrixF.Pool.Return(Array);
        public vectorFT T => new(this);
        public static vectorFS operator *(vectorF a, float s) => new(a, s);
        public static vectorFS operator *(float s, vectorF a) => new(a, s);
        public static vectorF operator +(vectorF m, float a) => Vector.LinearFrac(m, m, 1.0f, a, 0.0f, 0.0f);
        public static vectorF operator +(float a, vectorF m) => Vector.LinearFrac(m, m, 1.0f, a, 0.0f, 0.0f);

        public static vectorF operator +(vectorF a, vectorF b)
        {
            if (a.Length != b.Length) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new vectorF(a.Length);
            Vml.Add(a.Length, a.Array, 0, 1, b.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static vectorF operator +(vectorF a, vectorFS bS)
        {
            var b = bS.Vector;
            if (a.Length != b.Length) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new vectorF(a.Length);
            Blas.omatadd(LayoutChar.ColMajor, TransChar.No, TransChar.No, a.Length, 1, 1.0f, a.Array, a.Length, bS.Scale, b.Array, a.Length, r.Array, a.Length);
            return r;
        }

        public static vectorF operator -(vectorF a, vectorF b)
        {
            if (a.Length != b.Length) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new vectorF(a.Length);
            Vml.Sub(a.Length, a.Array, 0, 1, b.Array, 0, 1, r.Array, 0, 1);
            return r;
        }

        public static vectorF operator -(vectorF a, vectorFS bS)
        {
            var b = bS.Vector;
            if (a.Length != b.Length) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new vectorF(a.Length);
            Blas.omatadd(LayoutChar.ColMajor, TransChar.No, TransChar.No, a.Length, 1, 1.0f, a.Array, a.Length, -bS.Scale, b.Array, a.Length, r.Array, a.Length);
            return r;
        }

        public static matrixF operator *(vectorF a, vectorFT bT)
        {
            var b = bT.Vector;
            var r = new matrixF(a.Length, b.Length);
            Blas.gemm(Layout.ColMajor, Trans.No, Trans.Yes, a.Length, b.Length, 1, 1.0f, a.Array, a.Length, b.Array, b.Length, 0.0f, r.Array, r.Rows);
            return r;
        }

        public static matrixF operator *(vectorF a, vectorFTS bTS)
        {
            var b = bTS.Vector;
            var r = new matrixF(a.Length, b.Length);
            Blas.gemm(Layout.ColMajor, Trans.No, Trans.Yes, a.Length, b.Length, 1, bTS.Scale, a.Array, a.Length, b.Array, b.Length, 0.0f, r.Array, r.Rows);
            return r;
        }
    }

    public struct vectorFT
    {
        public readonly vectorF Vector;
        internal vectorFT(vectorF v) => Vector = v;

        public vectorF T => Vector;
        public static vectorFTS operator *(vectorFT a, float s) => new(a.Vector, s);
        public static vectorFTS operator *(float s, vectorFT a) => new(a.Vector, s);
        public static vectorFT operator +(vectorFT m, float a) => new(MKLNET.Vector.LinearFrac(m.Vector, m.Vector, 1.0f, a, 0.0f, 0.0f));
        public static vectorFT operator +(float a, vectorFT m) => new(MKLNET.Vector.LinearFrac(m.Vector, m.Vector, 1.0f, a, 0.0f, 0.0f));
        public static vectorFT operator +(vectorFT aT, vectorFT bT)
        {
            var a = aT.Vector;
            var b = bT.Vector;
            if (a.Length != b.Length) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new vectorF(a.Length);
            Vml.Add(a.Length, a.Array, 0, 1, b.Array, 0, 1, r.Array, 0, 1);
            return new vectorFT(r);
        }

        public static vectorFT operator +(vectorFT aT, vectorFTS bTS)
        {
            var a = aT.Vector;
            var b = bTS.Vector;
            if (a.Length != b.Length) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new vectorF(a.Length);
            Blas.omatadd(LayoutChar.ColMajor, TransChar.No, TransChar.No, a.Length, 1, 1.0f, a.Array, a.Length, bTS.Scale, b.Array, a.Length, r.Array, a.Length);
            return new vectorFT(r);
        }

        public static vectorFT operator -(vectorFT aT, vectorFT bT)
        {
            var a = aT.Vector;
            var b = bT.Vector;
            if (a.Length != b.Length) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new vectorF(a.Length);
            Vml.Sub(a.Length, a.Array, 0, 1, b.Array, 0, 1, r.Array, 0, 1);
            return new vectorFT(r);
        }

        public static vectorFT operator -(vectorFT aT, vectorFTS bTS)
        {
            var a = aT.Vector;
            var b = bTS.Vector;
            if (a.Length != b.Length) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new vectorF(a.Length);
            Blas.omatadd(LayoutChar.ColMajor, TransChar.No, TransChar.No, a.Length, 1, 1.0f, a.Array, a.Length, -bTS.Scale, b.Array, a.Length, r.Array, a.Length);
            return new vectorFT(r);
        }

        public static float operator *(vectorFT aT, vectorF b)
        {
            var a = aT.Vector;
            if (a.Length != b.Length) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = Blas.dot(a.Length, a.Array, 0, 1, b.Array, 0, 1);
            return r;
        }

        public static float operator *(vectorFT aT, vectorFS bS)
        {
            var a = aT.Vector;
            var b = bS.Vector;
            if (a.Length != b.Length) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = Blas.dot(a.Length, a.Array, 0, 1, b.Array, 0, 1);
            return r * bS.Scale;
        }

        public static vectorFT operator *(vectorFT aT, matrixF b)
        {
            var a = aT.Vector;
            if (a.Length != b.Rows) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new vectorF(b.Cols);
            Blas.gemm(Layout.ColMajor, Trans.No, Trans.No, 1, b.Cols, a.Length, 1.0f, a.Array, 1, b.Array, b.Rows, 0.0f, r.Array, 1);
            return new vectorFT(r);
        }

        public static vectorFT operator *(vectorFT aT, matrixFT bT)
        {
            var a = aT.Vector;
            var b = bT.Matrix;
            if (a.Length != b.Cols) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new vectorF(b.Rows);
            Blas.gemm(Layout.ColMajor, Trans.No, Trans.Yes, 1, b.Rows, a.Length, 1.0f, a.Array, 1, b.Array, b.Rows, 0.0f, r.Array, 1);
            return new vectorFT(r);
        }

        public static vectorFT operator *(vectorFT aT, matrixFS bS)
        {
            var a = aT.Vector;
            var b = bS.Matrix;
            if (a.Length != b.Rows) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new vectorF(b.Cols);
            Blas.gemm(Layout.ColMajor, Trans.No, Trans.No, 1, b.Cols, a.Length, bS.Scale, a.Array, 1, b.Array, b.Rows, 0.0f, r.Array, 1);
            return new vectorFT(r);
        }

        public static vectorFT operator *(vectorFT aT, matrixFTS bTS)
        {
            var a = aT.Vector;
            var b = bTS.Matrix;
            if (a.Length != b.Cols) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new vectorF(b.Rows);
            Blas.gemm(Layout.ColMajor, Trans.No, Trans.Yes, 1, b.Rows, a.Length, bTS.Scale, a.Array, 1, b.Array, b.Rows, 0.0f, r.Array, 1);
            return new vectorFT(r);
        }
    }

    public struct vectorFS
    {
        public readonly vectorF Vector;
        public readonly float Scale;
        internal vectorFS(vectorF v, float s)
        {
            Vector = v;
            Scale = s;
        }

        public vectorFTS T => new(Vector, Scale);
        public static vectorFS operator *(vectorFS a, float s) => new(a.Vector, a.Scale * s);
        public static vectorFS operator *(float s, vectorFS a) => new(a.Vector, s * a.Scale);
        public static vectorF operator +(vectorFS m, float a) => MKLNET.Vector.LinearFrac(m.Vector, m.Vector, m.Scale, a, 0.0f, 0.0f);
        public static vectorF operator +(float a, vectorFS m) => MKLNET.Vector.LinearFrac(m.Vector, m.Vector, m.Scale, a, 0.0f, 0.0f);

        public static implicit operator vectorF(vectorFS vS)
        {
            var v = vS.Vector;
            var r = new vectorF(v.Length);
            Blas.omatcopy(LayoutChar.ColMajor, TransChar.No, v.Length, 1, vS.Scale, v.Array, v.Length, r.Array, v.Length);
            return r;
        }

        public static vectorF operator +(vectorFS aS, vectorF b)
        {
            var a = aS.Vector;
            if (a.Length != b.Length) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new vectorF(a.Length);
            Blas.omatadd(LayoutChar.ColMajor, TransChar.No, TransChar.No, a.Length, 1, aS.Scale, a.Array, a.Length, 1.0f, b.Array, a.Length, r.Array, a.Length);
            return r;
        }

        public static vectorF operator +(vectorFS aS, vectorFS bS)
        {
            var a = aS.Vector;
            var b = bS.Vector;
            if (a.Length != b.Length) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new vectorF(a.Length);
            Blas.omatadd(LayoutChar.ColMajor, TransChar.No, TransChar.No, a.Length, 1, aS.Scale, a.Array, a.Length, bS.Scale, b.Array, a.Length, r.Array, a.Length);
            return r;
        }

        public static vectorF operator -(vectorFS aS, vectorF b)
        {
            var a = aS.Vector;
            if (a.Length != b.Length) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new vectorF(a.Length);
            Blas.omatadd(LayoutChar.ColMajor, TransChar.No, TransChar.No, a.Length, 1, aS.Scale, a.Array, a.Length, -1.0f, b.Array, a.Length, r.Array, a.Length);
            return r;
        }

        public static vectorF operator -(vectorFS aS, vectorFS bS)
        {
            var a = aS.Vector;
            var b = bS.Vector;
            if (a.Length != b.Length) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new vectorF(a.Length);
            Blas.omatadd(LayoutChar.ColMajor, TransChar.No, TransChar.No, a.Length, 1, aS.Scale, a.Array, a.Length, -bS.Scale, b.Array, a.Length, r.Array, a.Length);
            return r;
        }

        public static matrixF operator *(vectorFS aS, vectorFT bT)
        {
            var a = aS.Vector;
            var b = bT.Vector;
            var r = new matrixF(a.Length, b.Length);
            Blas.gemm(Layout.ColMajor, Trans.No, Trans.Yes, a.Length, b.Length, 1, aS.Scale, a.Array, a.Length, b.Array, b.Length, 0.0f, r.Array, r.Rows);
            return r;
        }

        public static matrixF operator *(vectorFS aS, vectorFTS bTS)
        {
            var a = aS.Vector;
            var b = bTS.Vector;
            var r = new matrixF(a.Length, b.Length);
            Blas.gemm(Layout.ColMajor, Trans.No, Trans.Yes, a.Length, b.Length, 1, aS.Scale * bTS.Scale, a.Array, a.Length, b.Array, b.Length, 0.0f, r.Array, r.Rows);
            return r;
        }
    }

    public struct vectorFTS
    {
        public readonly vectorF Vector;
        public readonly float Scale;
        internal vectorFTS(vectorF v, float s)
        {
            Vector = v;
            Scale = s;
        }

        public vectorFS T => new(Vector, Scale);
        public static vectorFTS operator *(vectorFTS a, float s) => new(a.Vector, a.Scale * s);
        public static vectorFTS operator *(float s, vectorFTS a) => new(a.Vector, s * a.Scale);
        public static vectorFT operator +(vectorFTS m, float a) => new(MKLNET.Vector.LinearFrac(m.Vector, m.Vector, m.Scale, a, 0.0f, 0.0f));
        public static vectorFT operator +(float a, vectorFTS m) => new(MKLNET.Vector.LinearFrac(m.Vector, m.Vector, m.Scale, a, 0.0f, 0.0f));
        public static vectorFT operator +(vectorFTS aTS, vectorFT bT)
        {
            var a = aTS.Vector;
            var b = bT.Vector;
            if (a.Length != b.Length) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new vectorF(a.Length);
            Blas.omatadd(LayoutChar.ColMajor, TransChar.No, TransChar.No, a.Length, 1, aTS.Scale, a.Array, a.Length, 1.0f, b.Array, a.Length, r.Array, a.Length);
            return new vectorFT(r);
        }

        public static vectorFT operator +(vectorFTS aTS, vectorFTS bTS)
        {
            var a = aTS.Vector;
            var b = bTS.Vector;
            if (a.Length != b.Length) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new vectorF(a.Length);
            Blas.omatadd(LayoutChar.ColMajor, TransChar.No, TransChar.No, a.Length, 1, aTS.Scale, a.Array, a.Length, bTS.Scale, b.Array, a.Length, r.Array, a.Length);
            return new vectorFT(r);
        }

        public static vectorFT operator -(vectorFTS aTS, vectorFT bT)
        {
            var a = aTS.Vector;
            var b = bT.Vector;
            if (a.Length != b.Length) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new vectorF(a.Length);
            Blas.omatadd(LayoutChar.ColMajor, TransChar.No, TransChar.No, a.Length, 1, aTS.Scale, a.Array, a.Length, -1.0f, b.Array, a.Length, r.Array, a.Length);
            return new vectorFT(r);
        }

        public static vectorFT operator -(vectorFTS aTS, vectorFTS bTS)
        {
            var a = aTS.Vector;
            var b = bTS.Vector;
            if (a.Length != b.Length) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new vectorF(a.Length);
            Blas.omatadd(LayoutChar.ColMajor, TransChar.No, TransChar.No, a.Length, 1, aTS.Scale, a.Array, a.Length, -bTS.Scale, b.Array, a.Length, r.Array, a.Length);
            return new vectorFT(r);
        }

        public static float operator *(vectorFTS aTS, vectorF b)
        {
            var a = aTS.Vector;
            if (a.Length != b.Length) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = Blas.dot(a.Length, a.Array, 0, 1, b.Array, 0, 1);
            return aTS.Scale * r;
        }

        public static float operator *(vectorFTS aTS, vectorFS bS)
        {
            var a = aTS.Vector;
            var b = bS.Vector;
            if (a.Length != b.Length) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = Blas.dot(a.Length, a.Array, 0, 1, b.Array, 0, 1);
            return aTS.Scale * r * bS.Scale;
        }

        public static vectorFT operator *(vectorFTS aTS, matrixF b)
        {
            var a = aTS.Vector;
            if (a.Length != b.Rows) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new vectorF(b.Cols);
            Blas.gemm(Layout.ColMajor, Trans.No, Trans.No, 1, b.Cols, a.Length, aTS.Scale, a.Array, 1, b.Array, b.Rows, 0.0f, r.Array, 1);
            return new vectorFT(r);
        }

        public static vectorFT operator *(vectorFTS aTS, matrixFT bT)
        {
            var a = aTS.Vector;
            var b = bT.Matrix;
            if (a.Length != b.Cols) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new vectorF(b.Rows);
            Blas.gemm(Layout.ColMajor, Trans.No, Trans.Yes, 1, b.Rows, a.Length, aTS.Scale, a.Array, 1, b.Array, b.Rows, 0.0f, r.Array, 1);
            return new vectorFT(r);
        }

        public static vectorFT operator *(vectorFTS aTS, matrixFS bS)
        {
            var a = aTS.Vector;
            var b = bS.Matrix;
            if (a.Length != b.Rows) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new vectorF(b.Cols);
            Blas.gemm(Layout.ColMajor, Trans.No, Trans.No, 1, b.Cols, a.Length, aTS.Scale * bS.Scale, a.Array, 1, b.Array, b.Rows, 0.0f, r.Array, 1);
            return new vectorFT(r);
        }

        public static vectorFT operator *(vectorFTS aTS, matrixFTS bTS)
        {
            var a = aTS.Vector;
            var b = bTS.Matrix;
            if (a.Length != b.Cols) ThrowHelper.ThrowIncorrectDimensionsForOperation();
            var r = new vectorF(b.Rows);
            Blas.gemm(Layout.ColMajor, Trans.No, Trans.Yes, 1, b.Rows, a.Length, aTS.Scale * bTS.Scale, a.Array, 1, b.Array, b.Rows, 0.0f, r.Array, 1);
            return new vectorFT(r);
        }
    }
}