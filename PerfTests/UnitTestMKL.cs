using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MKLNET;

namespace MKL0Test
{
    [TestClass]
    public class UnitTestMKL
    {

        #region FUNCTIONALITY

        [TestMethod]
        public void TestEigenValuesMKL()
        {
            //the problem and the result
            MKL0.Matrix A = new MKL0.Matrix(new double[,] {
                {14165, 8437, 7554},
                {8437, 11902, 7962},
                {7554, 7962, 5940}});
            double[] expectedResult = new double[] { 128.134, 4698.444, 27180.421 };
            //computes
            double[] eigenValues = A.RealPartOfEigenValues();
            //check results
            for (int i = 0; i < eigenValues.Length; i++)
            {
                Assert.AreEqual(Math.Round(eigenValues[i], 2), Math.Round(expectedResult[i], 2));
            }
        }

        [TestMethod]
        public void TestEigenVectorsMKL()
        {
            //the problem and the result
            MKL0.Matrix A = new MKL0.Matrix(new double[,] {
                 {14165, 8437, 7554},
                {8437, 11902, 7962},
                {7554, 7962, 5940}});
            double[,] expectedResult = new double[3, 3];
            expectedResult[0, 0] = 00000;
            expectedResult[0, 1] = 00000;
            expectedResult[0, 2] = 00000;
            expectedResult[1, 0] = 00000;
            expectedResult[1, 1] = 00000;
            expectedResult[1, 2] = 00000;
            expectedResult[2, 0] = 00000;
            expectedResult[2, 1] = 00000;
            expectedResult[2, 2] = 00000;
            //computes
            double[,] eigenVectors = A.EigenVectors();
            //check results
            for (int i = 0; i < eigenVectors.GetLength(0); i++)
            {
                for (int j = 0; j < eigenVectors.GetLength(1); j++)
                {
                    Assert.AreEqual(Math.Round(eigenVectors[i, j], 2), Math.Round(expectedResult[i, j], 2));
                }
            }
        }

        [TestMethod]
        public void TestInverseMKL()
        {
            //the problem and the result
            MKL0.Matrix A = new MKL0.Matrix(new double[,] {
                {1, 2, 1},
                {2, 1, 3},
                {1, 1, 1}});
            double[,] expectedResult = new double[,] {
                { -2, -1, 5},
                { 1, 0, -1},
                { 1, 1, -3}};
            //computes
            A.Invert();
            //check results
            for (int i = 0; i < A.Rows; i++)
            {
                for (int j = 0; j < A.Cols; j++)
                {
                    Assert.AreEqual(Math.Round(A[i, j], 12), Math.Round(expectedResult[i, j], 12));
                }
            }
        }

        [TestMethod]
        public void TestCheckPositiveDefinite()
        {
            //the problem and the result
            int size = 250;
            int numberOfChecks = 100;
            //execute
            MKL0.Matrix A = new MKL0.Matrix();
            for (int i = 0; i < numberOfChecks; i++)
            {
                A.MakeRandomPositiveDefinite(size, 0, 1000);
                Assert.AreEqual(true, A.GetIsPositiveDefinite());
            }
        }

        [TestMethod]
        public void TestCholeskyDecomposition()
        {
            //https://pt.wikipedia.org/wiki/Fatora%C3%A7%C3%A3o_de_Cholesky#:~:text=Em%20%C3%A1lgebra%20linear%2C%20a%20decomposi%C3%A7%C3%A3o,e%20simula%C3%A7%C3%B5es%20de%20Monte%20Carlo
            //the problem and the result
            MKL0.Matrix A = new MKL0.Matrix(new double[,] {
                {4, 12, -16},
                {12, 37, -43},
                {-16, -43, 98}});
            double[,] expectedResult = new double[,] {
                {2, 0, 0},
                {6, 1, 0},
                {-8, 5, 3}};
            //computes
            double[,] cholesky;
            if (A.GetCholeskyDecomposition(out cholesky))
            {
                //check results
                for (int i = 0; i < expectedResult.GetLength(0); i++)
                {
                    for (int j = 0; j < expectedResult.GetLength(1); j++)
                    {
                        Assert.AreEqual(Math.Round(cholesky[i, j], 12), Math.Round(expectedResult[i, j], 12));
                    }
                }
            }
            else
            {
                Assert.Fail("The matrix is not positive definite.");
            }
        }

        [TestMethod]
        public void TestDeterminant()
        {
            //the problem and the result
            MKL0.Matrix A = new MKL0.Matrix(new double[,] {
                {4, 12, -16},
                {12, 37, -43},
                {-16, -43, 98}});
            double expectedResult = 36;
            //computes
            double determinant = A.GetDeterminant();
            //check results
            Assert.AreEqual(Math.Round(determinant, 12), Math.Round(expectedResult, 12));
        }

        [TestMethod]
        public void TestDeterminants()
        {
            //the problem and the result
            MKL0.Matrix A = new MKL0.Matrix(new double[,] {
                {4, 12, -16},
                {12, 37, -43},
                {-16, -43, 98}});
            double[] expectedResult = new double[] { 4, 4, 36 };
            //computes
            double[] determinants = A.GetDeterminants();
            //check results
            for (int i = 0; i < determinants.Length; i++)
            {
                Assert.AreEqual(Math.Round(determinants[i], 12), Math.Round(expectedResult[i], 12));
            }
        }

        [TestMethod]
        public void TestIsSymetric()
        {
            //PROBLEM 1 (TRUE)
            //the problem and the result
            MKL0.Matrix A = new MKL0.Matrix(new double[,] {
                {10, 5, 6, 8},
                {5, 3, 9, 2},
                {6, 9, 4, 1},
                {8, 2, 1, 1}});
            bool expectedResult = true;
            //computes
            bool isSymetric = A.GetIsSymetric(true);
            //check results
            Assert.AreEqual(isSymetric, expectedResult);
            //------------------------------------------------------------
            //PROBLEM 2 (FALSE)
            //the problem and the result
            MKL0.Matrix B = new MKL0.Matrix(new double[,] {
                {10, 5, 6, 8},
                {5, 3, 9, 2},
                {6, 9, 4, 1},
                {8, 2, 1, 1}});
            expectedResult = true;
            //computes
            isSymetric = A.GetIsSymetric(true);
            //check results
            Assert.AreEqual(isSymetric, expectedResult);
        }

        [TestMethod]
        public void TestHasOnlyZeros()
        {
            //PROBLEM 1 (TRUE)
            //the problem and the result
            MKL0.Matrix A = new MKL0.Matrix(new double[,] {
                {0, 0, 0, 0},
                {0, 0, 0, 0},
                {0, 0, 0, 0},
                {0, 0, 0, 0}});
            bool expectedResult = true;
            //computes
            bool hasOnlyZeros = A.GetIsSymetric(true);
            //check results
            Assert.AreEqual(hasOnlyZeros, expectedResult);
            //------------------------------------------------------------
            //PROBLEM 2 (FALSE)
            //the problem and the result
            MKL0.Matrix B = new MKL0.Matrix(new double[,] {
                {0, 0, 0, 0},
                {0, 0, 0, 0},
                {0, 0, 1, 0},
                {0, 0, 0, 0}});
            expectedResult = true;
            //computes
            hasOnlyZeros = A.GetIsSymetric(true);
            //check results
            Assert.AreEqual(hasOnlyZeros, expectedResult);
        }

        #endregion

        #region PERFORMANCE

        [TestMethod]
        public void TestPerformanceMultiplication()
        {
            //the problem and the result
            int size = 250;
            int multiplications = 5000;
            //execute
            MKL0.Matrix A = new MKL0.Matrix();
            MKL0.Matrix B = new MKL0.Matrix();
            A.MakeSquareWithRandomValues(size, 0, 1000, true);
            B.MakeSquareWithRandomValues(size, 0, 1000, true);
            MKL0.Matrix C = new MKL0.Matrix();
            for (int i = 0; i < multiplications; i++)
            {
                C.M = A.M * B.M;
                C.M.Dispose();
            }
        }

        [TestMethod]
        public void TestPerformanceInvert()
        {
            //the problem and the result
            int size = 250;
            int inversions = 1000;
            //execute
            MKL0.Matrix A = new MKL0.Matrix();
            A.MakeSquareWithRandomValues(size, 0, 1000, true);
            MKL0.Matrix B = new MKL0.Matrix();
            for (int i = 0; i < inversions; i++)
            {
                B = A.GetInverse();
                B.M.Dispose();
            }
        }

        [TestMethod]
        public void TestPerformanceIsSymetric()
        {
            //the problem and the result
            int size = 500;
            int inversions = 1000;
            //execute
            MKL0.Matrix A = new MKL0.Matrix();
            A.MakeRandomPositiveDefinite(size, 0, 1000);
            bool isSymetric = true;
            for (int i = 0; i < inversions; i++)
            {
                isSymetric &= A.GetIsSymetric(true);
            }
            Assert.AreEqual(isSymetric, true);
        }

        [TestMethod]
        public void TestPerformanceHasOnlyZeros()
        {
            //the problem and the result
            int size = 500;
            int inversions = 1000;
            //execute
            MKL0.Matrix A = new MKL0.Matrix(size, size);
            bool hasOnlyZeros = true;
            for (int i = 0; i < inversions; i++)
            {
                hasOnlyZeros &= A.GetIsSymetric(true);
            }
            Assert.AreEqual(hasOnlyZeros, true);
        }

        [TestMethod]
        public void TestPerformanceVectorVsMatrix()
        {
            //the problem
            int size = 250;
            int multiplications = 10000;
            double c1 = 0.25;
            double c2 = 0.25;
            //prepare with matrix
            MKL0.Matrix A = new MKL0.Matrix();
            MKL0.Matrix B = new MKL0.Matrix();
            MKL0.Matrix C = new MKL0.Matrix();
            MKL0.Matrix D = new MKL0.Matrix();
            MKL0.Matrix E = new MKL0.Matrix();
            A.MakeWithRandomValues(size, 1, 1, 1000);
            B.MakeWithRandomValues(size, 1, 1, 1000);
            C.MakeWithRandomValues(size, 1, 1, 1000);
            D.MakeWithRandomValues(size, 1, 1, 1000);
            //prepare with vector
            MKL0.Vector a = new MKL0.Vector();
            MKL0.Vector b = new MKL0.Vector();
            MKL0.Vector c = new MKL0.Vector();
            MKL0.Vector d = new MKL0.Vector();
            MKL0.Vector e = new MKL0.Vector();
            a.MakeWithRandomValues(size, 0, 1000, true);
            b.MakeWithRandomValues(size, 0, 1000, true);
            c.MakeWithRandomValues(size, 0, 1000, true);
            d.MakeWithRandomValues(size, 0, 1000, true);
            //execute with matrix
            System.Diagnostics.Stopwatch sw1 = new System.Diagnostics.Stopwatch();
            sw1.Start();
            for (int i = 0; i < multiplications; i++)
            {
                E.M = A.M + B.M + C.M * c1 + D.M * c2;
                E.M.Dispose();
            }
            sw1.Stop();
            //execute with vector
            System.Diagnostics.Stopwatch sw2 = new System.Diagnostics.Stopwatch();
            sw2.Start();
            for (int i = 0; i < multiplications; i++)
            {
                e.V = a.V + b.V + c1 * c.V + c2 * d.V;
                e.V.Dispose();
            }
            sw2.Stop();
            //compare
            Assert.IsTrue(sw1.ElapsedMilliseconds > sw2.ElapsedMilliseconds);
        }

        #endregion

        #region MEMORY LEAK

        [TestMethod]
        public void MemoryLeakTest()
        {
            //the problem and the result
            int size = 1000;
            int operations = 500;
            //execute
            MKL0.Matrix A = new MKL0.Matrix();
            MKL0.Matrix B = new MKL0.Matrix();
            MKL0.Matrix C = new MKL0.Matrix();
            MKL0.Matrix D = new MKL0.Matrix(size, size, 1e-30);
            MKL0.Matrix E = new MKL0.Matrix();
            MKL0.Vector a = new MKL0.Vector();
            MKL0.Vector b = new MKL0.Vector();
            A.MakeSquareWithRandomValues(size, 0, 10, true);
            B.MakeSquareWithRandomValues(size, 0, 10, true);
            C.MakeSquareWithRandomValues(size, 0, 10, true);
            D.MakeSquareWithRandomValues(size, 0, 10, true);
            E.MakeSquareWithRandomValues(size, 0, 10, true);
            a.MakeWithRandomValues(size, 0, 10, true);
            b.MakeWithRandomValues(size, 0, 10, true);

            for (int i = 0; i < operations; i++)
            {
                // C.M = 0 * C.M + A.M;
                C.M.LinearFrac(0.0, A.M, 1.0);
                // B.M = A.M * B.M + A.M + 0 * C.M - E.M + C.M + 0.15 * E.M;
                B.M.PreMul(A.M).Add(A.M).AddMul(0, C.M).Sub(E.M).Add(C.M).AddMul(0.15, E.M);
                // A.M = A.M * B.M + B.M + 0 * C.M - E.M + C.M + 0.15 * E.M;
                A.M.Mul(B.M).Add(B.M).AddMul(0, C.M).Sub(E.M).Add(C.M).AddMul(0.15, E.M);
                // A.M = A.M * 0.1;
                A.M.Scal(0.1);
                // b.V = b.V + A.M * a.V + B.M * a.V + C.M * a.V + D.M * a.V + E.M * a.V;
                b.V.AddMul(A.M, a.V).AddMul(B.M, a.V).AddMul(C.M, a.V).AddMul(D.M, a.V).AddMul(E.M, a.V);
                // b.V = b.V * 0.1;
                b.V.Scal(0.1);
            }
        }

        public void Ex(MKL0.Matrix A11Inv, MKL0.Matrix A22, MKL0.Vector Xold, double mvarH, MKL0.Matrix B, MKL0.Vector Sources, MKL0.Vector X)
        {
            // X.V = A11Inv.M * (0.5 * mvarH * B.M * Sources.V + A22.M * Xold.V);
            X.V.CopyMul(0.5 * mvarH, B.M, Sources.V).AddMul(A22.M, Xold.V).PreMul(A11Inv.M);
            // Xold.V = X.V;
            Xold.V.Copy(X.V);
        }

        #endregion

    }
}
