using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKL0
{
    /// <summary>
    /// A class that uses MKL to high performance matrix operations.
    /// </summary>
    public class Matrix : IDisposable
    {
        private const double SymetricDifferenceTolerance = 1e-6;

        MKLNET.matrix m;

        #region CONSTRUCTORS

        /// <summary>
        /// Creates a new empty matrix.
        /// </summary>
        public Matrix() { }

        /// <summary>
        /// Creates a new square matrix of a specific size filled with zeros.
        /// </summary>
        /// <param name="size">The matrix will become 'size x size'.</param>
        public Matrix(int size)
        {
            m?.Dispose();
            m = new MKLNET.matrix(size, size);
        }

        /// <summary>
        /// Creates a new square matrix of a specific size filled with the value.
        /// </summary>
        /// <param name="size">The matrix will become 'size x size'.</param>
        /// <param name="value">The value of all fields of the matrix</param>
        public Matrix(int size, double value)
        {
            m?.Dispose();
            m = new MKLNET.matrix(size, size);
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    m[i, j] = value;
                }
            }
        }

        /// <summary>
        /// Creates a new matrix with a specific number of rows and columns filled with zeros.
        /// </summary>
        /// <param name="rows">The number of rows in the matrix.</param>
        /// <param name="columns">The number of columns in the matrix.</param>
        public Matrix(int rows, int columns)
        {
            m?.Dispose();
            m = new MKLNET.matrix(rows, columns);
        }

        /// <summary>
        /// Creates a new matrix with a specific number of rows and columns filled with the value.
        /// </summary>
        /// <param name="rows">The number of rows in the matrix.</param>
        /// <param name="columns">The number of columns in the matrix.</param>
        /// <param name = "value" > The value of all fields of the matrix</param>
        public Matrix(int rows, int columns, double value)
        {
            m?.Dispose();
            m = new MKLNET.matrix(rows, columns);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    m[i, j] = value;
                }
            }
        }

        /// <summary>
        /// Creates a new matrix based on an array.
        /// </summary>
        /// <param name="data">The matrix content.</param>
        public Matrix(double[,] data)
        {
            m?.Dispose();
            m = new MKLNET.matrix(data.GetLength(0), data.GetLength(1));
            for (int i = 0; i < m.Rows; i++)
            {
                for (int j = 0; j < m.Cols; j++)
                {
                    m[i, j] = data[i, j];
                }
            }
        }

        /// <summary>
        /// Creates a new matrix (a vector, actually) based on an array.
        /// </summary>
        /// <param name="data">The matrix content.</param>
        public Matrix(double[] data)
        {
            m?.Dispose();
            m = new MKLNET.matrix(data.Length, 1);
            for (int i = 0; i < m.Rows; i++)
            {
                m[i, 0] = data[i];
            }
        }

        /// <summary>
        /// Creates a new matrix based on an array and removing the first row and column.
        /// </summary>
        /// <param name="data">The matrix content.</param>
        /// <param name="removeIndex0">Choose 'true' if the array contains an additional row/column with index 0.</param>
        public Matrix(double[,] data, bool removeIndex0)
        {
            m?.Dispose();
            if (removeIndex0)
            {
                m = new MKLNET.matrix(data.GetLength(0) - 1, data.GetLength(1) - 1);
                for (int i = 1; i < data.GetLength(0); i++)
                {
                    for (int j = 1; j < data.GetLength(1); j++)
                    {
                        m[i - 1, j - 1] = data[i, j];
                    }
                }
            }
            else
            {
                m = new MKLNET.matrix(data.GetLength(0), data.GetLength(1));
                for (int i = 0; i < m.Rows; i++)
                {
                    for (int j = 0; j < m.Cols; j++)
                    {
                        m[i, j] = data[i, j];
                    }
                }
            }
        }

        /// <summary>
        /// Creates a new matrix (a vector, actually) based on an array and removing the first row.
        /// </summary>
        /// <param name="data">The matrix content.</param>
        /// <param name="removeIndex0">Choose 'true' if the array contains an additional row with index 0.</param>
        public Matrix(double[] data, bool removeIndex0)
        {
            m?.Dispose();
            if (removeIndex0)
            {
                m = new MKLNET.matrix(data.Length - 1, 1);
                for (int i = 1; i < m.Rows; i++)
                {
                    m[i - 1, 0] = data[i];
                }
            }
            else
            {
                m = new MKLNET.matrix(data.Length, 1);
                for (int i = 0; i < m.Rows; i++)
                {
                    m[i, 0] = data[i];
                }
            }
        }

        #endregion

        #region STATIC METHODS

        /// <summary>
        /// Returns square matrix with values 1 in the main diagonal.
        /// </summary>
        /// <param name="size">The matrix will become 'size x size'.</param>
        /// <returns></returns>
        public static Matrix GetIdentity(int size)
        {
            Matrix result = new Matrix(size);
            for (int i = 0; i < size; i++)
            {
                result.M[i, i] = 1;
            }
            return result;
        }

        /// <summary>
        /// Returns an array with the inner matrix data.
        /// </summary>
        /// <param name="m">The inner matrix object.</param>
        /// <returns></returns>
        public static double[,] GetMatrixData(MKLNET.matrix m)
        {
            double[,] result = new double[m.Rows, m.Cols];
            for (int i = 0; i < m.Rows; i++)
            {
                for (int j = 0; j < m.Cols; j++)
                {
                    result[i, j] = m[i, j];
                }
            }
            return result;
        }

        /// <summary>
        /// Returns an minor matrix (dimension nxn) that is inside the matrix m (in wich the dimension is bigger or equan to n).
        /// </summary>
        /// <returns></returns>
        private static double[,] getMinorPartialData(double[,] matrixData, int n)
        {
            double[,] result = new double[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    result[i, j] = matrixData[i, j];
                }
            }
            return result;
        }

        //from https://www.geeksforgeeks.org/determinant-of-a-matrix/
        /// <summary>
        /// Recursive function for finding determinant of matrix. n is current Sdimension of mat[][]. */
        /// </summary>
        /// <returns></returns>
        private static double determinantOfMatrix(double[,] mat, int n)
        {
            double D = 0; // Initialize result
            // Base case : if matrix
            // contains single
            // element
            if (n == 1) return mat[0, 0];
            // To store cofactors
            double[,] temp = new double[n, n];
            // To store sign multiplier
            int sign = 1;
            // Iterate for each element
            // of first row
            for (int f = 0; f < n; f++)
            {
                // Getting Cofactor of mat[0][f]
                getCofactor(mat, temp, 0, f, n);
                D += sign * mat[0, f] * determinantOfMatrix(temp, n - 1);
                // terms are to be added with
                // alternate sign
                sign = -sign;
            }
            return D;
        }

        //from https://www.geeksforgeeks.org/determinant-of-a-matrix/
        /// <summary>
        /// Function to get cofactor of mat[p][q] in temp[][]. n is  current dimension of mat[][]
        /// </summary>
        /// <returns></returns>
        private static void getCofactor(double[,] mat, double[,] temp, int p, int q, int n)
        {
            int i = 0, j = 0;
            // Looping for each element of
            // the matrix
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    // Copying into temporary matrix
                    // only those element which are
                    // not in given row and column
                    if (row != p && col != q)
                    {
                        temp[i, j++] = mat[row, col];
                        // Row is filled, so increase
                        // row index and reset col
                        // index
                        if (j == n - 1)
                        {
                            j = 0;
                            i++;
                        }
                    }
                }
            }
        }

        #endregion

        #region PUBLIC METHODS

        /// <summary>
        /// Re-instances the inner matrix with all values set to zero.
        /// </summary>
        public void RestartInnerMatrix()
        {
            m?.Dispose();
            m = new MKLNET.matrix(m.Rows, m.Cols);
        }

        /// <summary>
        /// Returns an array with the matrix content.
        /// </summary>
        /// <returns></returns>
        public double[,] GetData()
        {
            double[,] result = new double[m.Rows, m.Cols];
            for (int i = 0; i < m.Rows; i++)
            {
                for (int j = 0; j < m.Cols; j++)
                {
                    result[i, j] = m[i, j];
                }
            }
            return result;
        }

        /// <summary>
        /// Returns a string containing the data separeted by ';'.
        /// </summary>
        /// <returns></returns>
        public string GetString()
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < m.Rows; i++)
            {
                for (int j = 0; j < m.Cols; j++)
                {
                    if (j > 0) result.Append(";");
                    result.Append(m[i, j]);
                }
                result.Append("\n");
            }
            return result.ToString();
        }

        /// <summary>
        /// Returns an array with the real part of the eigenvalues.
        /// </summary>
        /// <returns></returns>
        public double[] RealPartOfEigenValues()
        {
            MKLNET.vector ev = MKLNET.Matrix.Eigens(m).Item2;
            double[] result = new double[ev.Length];
            for (int i = 0; i < ev.Length; i++)
            {
                result[i] = ev[i];
            }
            return result;
        }

        /// <summary>
        /// Returns an matrix with the eigenvectors.
        /// </summary>
        /// <returns></returns>
        public double[,] EigenVectors()
        {
            MKLNET.matrix ev = MKLNET.Matrix.Eigens(m).Item1;
            return GetMatrixData(ev);
        }

        /// <summary>
        /// Inverts the matrix.
        /// </summary>
        public void Invert()
        {
            MKLNET.MatrixInplace.Inverse(m);
        }

        /// <summary>
        /// Returns the inverse of the matrix.
        /// </summary>
        /// <returns></returns>
        public Matrix GetInverse()
        {
            Matrix result = new Matrix(m.Rows, m.Cols);
            result.m = MKLNET.Matrix.Inverse(m);
            return result;
        }

        /// <summary>
        /// Transposes the matrix.
        /// </summary>
        public void Transpose()
        {
            m = m.T.Matrix;
        }

        /// <summary>
        /// Returns the transpose of the matrix.
        /// </summary>
        /// <returns></returns>
        public Matrix GetTranspose()
        {
            Matrix result = new Matrix(m.Rows, m.Cols);
            result.m = MKLNET.Matrix.Copy(m).T.Matrix;
            return result;
        }

        /// <summary>
        /// Makes the matrix to become square filled with random values.
        /// </summary>
        /// <param name="size">The matrix will become 'size x size'.</param>
        /// <param name="minimumValue">The minimum random value.</param>
        /// <param name="maximumValue">The maximum random value.</param>
        /// <param name="useParallel">If true, uses parallelization in the external loop (better for big matrices, like 100x100).</param>
        public void MakeSquareWithRandomValues(int size, int minimumValue, int maximumValue, bool useParallel)
        {
            m?.Dispose();
            m = new MKLNET.matrix(size, size);
            if (useParallel)//(better for big matrices, like 1000x1000)
            {
                Parallel.For(0, m.Rows, i =>
                {
                    for (int j = 0; j < m.Cols; j++)
                    {
                        m[i, j] = StaticRandom.Rand(minimumValue, maximumValue);
                    }
                });
            }
            else//(better for small matrices, like 10x10)
            {
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        m[i, j] = StaticRandom.Rand(minimumValue, maximumValue);
                    }
                }
            }
        }

        /// <summary>
        /// Makes the matrix to become square filled with random values.
        /// </summary>
        /// <param name="rows">The number of rows in the matrix.</param>
        /// <param name="cols">The number of columns in the matrix.</param>
        /// <param name="minimumValue">The minimum random value.</param>
        /// <param name="maximumValue">The maximum random value.</param>
        public void MakeWithRandomValues(int rows, int cols, int minimumValue, int maximumValue)
        {
            m?.Dispose();
            m = new MKLNET.matrix(rows, cols);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    m[i, j] = StaticRandom.Rand(minimumValue, maximumValue);
                }
            }
        }

        /// <summary>
        /// Makes the matrix to become square and positive definite filled with random values.
        /// </summary>
        /// <param name="size">The matrix will become 'size x size'.</param>
        /// <param name="minimumValue">The minimum random value.</param>
        /// <param name="maximumValue">The maximum random value.</param>
        public void MakeRandomPositiveDefinite(int size, int minimumValue, int maximumValue)
        {
            m?.Dispose();
            m = new MKLNET.matrix(size, size);
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    m[i, j] = StaticRandom.Rand(minimumValue, maximumValue);
                    m[j, i] = m[i, j];
                }
            }
            m = m * m.T;
        }

        /// <summary>
        /// Returns a boolean value indicating if the matrix is positive definite.
        /// </summary>
        /// <returns></returns>
        public bool GetIsPositiveDefinite()
        {
            //OPTION 1 (has Cholesky's decomposition)
            double[,] ch;
            return GetCholeskyDecomposition(out ch);
            //------------------------------------------------------------
            //OPTION 2 (all real part of eigenvalues greater than zero)
            //return RealPartOfEigenValues().Min() > 0;
            //------------------------------------------------------------
            //OPTION 3 (symetric and all determinants greater than zero)
            //bool isSymetric = GetIsSymetric();
            //bool determinantsGreaterThanZero = GetDeterminants().Min() > 0;
            //return isSymetric && determinantsGreaterThanZero;
        }

        /// <summary>
        /// Returns the Cholesky decomposition of the matrix.
        /// </summary>
        /// <returns></returns>
        public bool GetCholeskyDecomposition(out double[,] cholesky)
        {
            MKLNET.matrix m1;
            try
            {
                m1 = MKLNET.Matrix.Cholesky(m);
            }
            catch (Exception)
            {
                cholesky = null;
                return false;
            }
            cholesky = GetMatrixData(m1);
            return true;
        }

        /// <summary>
        /// Returns the determinant of the matrix.
        /// </summary>
        /// <returns></returns>
        public double GetDeterminant()
        {
            return determinantOfMatrix(GetMatrixData(m), m.Rows);
        }

        /// <summary>
        /// Returns the determinant of each minor matrix inside the matrix.
        /// </summary>
        /// <returns></returns>
        public double[] GetDeterminants()
        {
            double[] result = new double[m.Rows];
            double[,] matrixData = GetMatrixData(m);
            for (int i = 0; i < m.Rows; i++)
            {
                result[i] = determinantOfMatrix(matrixData, i + 1);
            }
            return result;
        }

        /// <summary>
        /// Returns a boolean value indicating if the matrix is symetric.
        /// </summary>
        /// <param name="useParallel">If true, uses parallelization in the external loop (better for big matrices, like 100x100).</param>
        /// <returns></returns>
        public bool GetIsSymetric(bool useParallel)
        {
            if (useParallel)//(better for big matrices, like 1000x1000)
            {
                bool result = true;
                Parallel.For(0, m.Rows, i =>
                {
                    for (int j = 0; j < m.Cols; j++)
                    {
                        if (Math.Abs(m[i, j] - m[j, i]) > SymetricDifferenceTolerance) result &= false;
                    }
                });
                return result;
            }
            else//(better for small matrices, like 10x10)
            {
                for (int i = 1; i < m.Rows; i++)
                {
                    for (int j = 0; j < m.Cols; j++)
                    {
                        if (Math.Abs(m[i, j] - m[j, i]) > SymetricDifferenceTolerance) return false;
                    }
                }
                return true;
            }
        }

        /// <summary>
        /// Returns a boolean value indicating if the matrix has only zeros.
        /// </summary>
        /// <param name="useParallel">If true, uses parallelization in the external loop (better for big matrices, like 100x100).</param>
        /// <returns></returns>
        public bool GetHasOnlyZeros(bool useParallel)
        {
            if (useParallel)//(better for gib matrices, like 1000x1000)
            {
                bool result = true;
                Parallel.For(0, m.Rows, i =>
                {
                    for (int j = 0; j < m.Cols; j++)
                    {
                        if (m[i, j] != 0) result &= false;
                    }
                });
                return result;
            }
            else//(better for small matrices, like 10x10)
            {
                for (int i = 1; i < m.Rows; i++)
                {
                    for (int j = 0; j < m.Cols; j++)
                    {
                        if (m[i, j] != 0) return false;
                    }
                }
                return true;
            }
        }

        /// <summary>
        /// Make all values in the matrix positive.
        /// </summary>
        public void PerformABS()
        {
            m = MKLNET.Matrix.Abs(m);
        }

        /// <summary>
        /// Returns a new matrix with all values with absolute value in place.
        /// </summary>
        /// <returns></returns>
        public Matrix GetAbs()
        {
            Matrix result = new Matrix(m.Rows, m.Cols);
            result.m = MKLNET.Matrix.Abs(m);
            return result;
        }

        /// <summary>
        /// Disposes the inner matrix (it's important to avoid 'system out of memory' problems).
        /// </summary>
        public void Dispose()
        {
            m?.Dispose();
        }

        /// <summary>
        /// Returns a copy (by valeu, not by reference) of the inner matrix object (a clone, actually).
        /// </summary>
        /// <returns></returns>
        public MKLNET.matrix GetCopyOfInnerMatrix()
        {
            return MKLNET.Matrix.Copy(m);
        }

        #endregion

        #region PROPERTIES

        /// <summary>
        /// Returns a specific matrix value.
        /// </summary>
        /// <param name="row">The row number (the first row is the row number 0).</param>
        /// <param name="col">The column number (the first column is the column number 0).</param>
        /// <returns></returns>
        public double this[int row, int col]
        {
            get { return m[row, col]; }
        }

        /// <summary>
        /// Returns the number of rows in the matrix.
        /// </summary>
        public int Rows
        {
            get { return m.Rows; }
        }

        /// <summary>
        /// Returns the number of columns in the matrix.
        /// </summary>
        public int Cols
        {
            get { return m.Cols; }
        }

        /// <summary>
        /// Returns the inner matrix object (used to perform matrix operations).
        /// </summary>
        public MKLNET.matrix M
        {
            get { return m; }
            set { m = value; }
        }

        //Should not have complex properties (memory issues).

        #endregion

    }
}
