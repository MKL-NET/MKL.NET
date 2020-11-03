using System;

namespace MKLNET
{
    public static class Matrix
    {
        public static class Inplace
        {
            public static void Add(matrix a, matrix b)
            {
                Vml.Add(a.Length, a.A, 0, 1, b.A, 0, 1, a.A, 0, 1);
            }

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

        public static matrix Sqrt(matrixS m)
        {
            matrix r = m;
            Inplace.Sqrt(r);
            return r;
        }

        public static matrix Sqrt(matrixT m)
        {
            matrix r = m;
            Inplace.Sqrt(r);
            return r;
        }

        public static matrix Sqrt(matrixTS m)
        {
            matrix r = m;
            Inplace.Sqrt(r);
            return r;
        }
    }
}