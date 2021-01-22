using MKLNET.Expression;

namespace MKLNET
{
    public class vector : matrix
    {
        public vector(int length) : base(length, 1) { }
        public vector(int length, double[] array) : base(length, 1, array) { }
        public double this[int i]
        {
            get => Array[i];
            set => Array[i] = value;
        }
        public new VectorTranspose T => new(this);
        public static VectorAddScalar operator +(vector m, double s) => new(m, s);
        public static VectorAddScalar operator +(double s, vector m) => new(m, s);
        public static VectorAddScalar operator -(vector m, double s) => new(m, -s);
        public static VectorScalarSub operator -(double s, vector m) => new(m, s);
        public static VectorAdd operator +(vector a, vector b) => new(a, b);
        public static VectorSub operator -(vector a, vector b) => new(a, b);
    }
    public class vectorT : matrix
    {
        public vectorT(int length) : base(1, length) { }
        public vectorT(int length, double[] array) : base(1, length, array) { }
        public double this[int i]
        {
            get => Array[i];
            set => Array[i] = value;
        }
        public new VectorTTranspose T => new(this);
        public static VectorTAddScalar operator +(vectorT m, double s) => new(m, s);
        public static VectorTAddScalar operator +(double s, vectorT m) => new(m, s);
        public static VectorTAddScalar operator -(vectorT m, double s) => new(m, -s);
        public static VectorTScalarSub operator -(double s, vectorT m) => new(m, s);
        public static VectorTAdd operator +(vectorT a, vectorT b) => new(a, b);
        public static VectorTSub operator -(vectorT a, vectorT b) => new(a, b);
    }
}