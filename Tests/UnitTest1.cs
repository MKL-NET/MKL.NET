using NUnit.Framework;
using MKLNET;

namespace Tests
{
    public class Tests
    {
        [Test]
        public void Test1()
        {
            var a = new[] { 8.0, 4.0, 2.0, 1.0, 3.0, -6.0, -7.0, 0.0, 5.0 };
            var b = new[] { 5.0, 2.0, 3.0, 1.0, 4.0, -1.0 };
            var c = new double[6];
            var expected = new[] { 60.0, 18.0, -10.0, 11.0, -15.0, -19.0 };

            MKL.Blas.dgemm(Order.RowMajor, Transpose.No, Transpose.No,
                       3, 2, 3, 1.0, a, 3, b, 2, 1.0, c, 2);

            for (var i = 0; i < c.Length; i++)
                Assert.AreEqual(expected[i], c[i]);
        }
    }
}