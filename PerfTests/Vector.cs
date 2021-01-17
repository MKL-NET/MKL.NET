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
    public class Vector : IDisposable
    {
        MKLNET.vector v;

        #region CONSTRUCTORS

        /// <summary>
        /// Creates a new empty vector.
        /// </summary>
        public Vector() { }

        /// <summary>
        /// Creates a new vector of a specific size filled with zeros.
        /// </summary>
        /// <param name="size">The vector will become 'size x 1'.</param>
        public Vector(int size)
        {
            v?.Dispose();
            v = new MKLNET.vector(size);
        }

        /// <summary>
        /// Creates a new vector of a specific size filled with the value.
        /// </summary>
        /// <param name="size">The vector will become 'size x 1'.</param>
        /// <param name="value">The value of all fields of the vector</param>
        public Vector(int size, double value)
        {
            v?.Dispose();
            v = new MKLNET.vector(size);
            for (int i = 0; i < size; i++)
            {
                v[i] = value;
            }
        }

        /// <summary>
        /// Creates a new vector based on an array.
        /// </summary>
        /// <param name="data">The vector content.</param>
        public Vector(double[] data)
        {
            v?.Dispose();
            v = new MKLNET.vector(data.Length);
            for (int i = 0; i < v.Length; i++)
            {
                v[i] = data[i];
            }
        }

        /// <summary>
        /// Creates a new vector based on an array and removing the first row.
        /// </summary>
        /// <param name="data">The vector content.</param>
        /// <param name="removeIndex0">Choose 'true' if the array contains an additional row with index 0.</param>
        public Vector(double[] data, bool removeIndex0)
        {
            v?.Dispose();
            if (removeIndex0)
            {
                v = new MKLNET.vector(data.Length - 1);
                for (int i = 1; i < v.Length; i++)
                {
                    v[i - 1] = data[i];
                }
            }
            else
            {
                v = new MKLNET.vector(data.Length);
                for (int i = 0; i < v.Length; i++)
                {
                    v[i] = data[i];
                }
            }
        }

        #endregion

        #region STATIC METHODS

        /// <summary>
        /// Returns an array with the inner vector data.
        /// </summary>
        /// <param name="m">The inner vector object.</param>
        /// <returns></returns>
        public static double[] GetVectorData(MKLNET.vector v)
        {
            double[] result = new double[v.Length];
            for (int i = 0; i < v.Length; i++)
            {
                result[i] = v[i];
            }
            return result;
        }

        #endregion

        #region PUBLIC METHODS

        /// <summary>
        /// Re-instances the inner vector with all values set to zero.
        /// </summary>
        public void RestartInnerVector()
        {
            v?.Dispose();
            v = v = new MKLNET.vector(v.Length);
        }

        /// <summary>
        /// Returns an array with the vector content.
        /// </summary>
        /// <returns></returns>
        public double[] GetData()
        {
            double[] result = new double[v.Length];
            for (int i = 0; i < v.Length; i++)
            {
                result[i] = v[i];
            }
            return result;
        }

        /// <summary>
        /// Returns a string containing the data in the vector.
        /// </summary>
        /// <returns></returns>
        public string GetString()
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < v.Length; i++)
            {
                result.Append(v[i]);
                if (i < v.Length - 1) result.Append("\n");

            }
            return result.ToString();
        }

        /// <summary>
        /// Transposes the vector.
        /// </summary>
        public void Transpose()
        {
            v = v.T.Vector;
        }

        /// <summary>
        /// Makes the vector to become filled with random values.
        /// </summary>
        /// <param name="size">The vector will become 'size x 1'.</param>
        /// <param name="minimumValue">The minimum random value.</param>
        /// <param name="maximumValue">The maximum random value.</param>
        /// <param name="useParallel">If true, uses parallelization in the external loop (better for big matrices, like 100x100).</param>
        public void MakeWithRandomValues(int size, int minimumValue, int maximumValue, bool useParallel)
        {
            v?.Dispose();
            v = new MKLNET.vector(size);
            if (useParallel)
            {
                Parallel.For(0, v.Length, i =>
                {
                    v[i] = StaticRandom.Rand(minimumValue, maximumValue);
                });
            }
            else
            {
                for (int i = 0; i < size; i++)
                {
                    v[i] = StaticRandom.Rand(minimumValue, maximumValue);
                }
            }
        }

        /// <summary>
        /// Returns a boolean value indicating if the vector has only zeros.
        /// </summary>
        /// <param name="useParallel">If true, uses parallelization in the external loop (better for big vector, like 100x100).</param>
        /// <returns></returns>
        public bool GetHasOnlyZeros(bool useParallel)
        {
            if (useParallel)//(better for gib vector, like 1000x1000)
            {
                bool result = true;
                Parallel.For(0, v.Length, i =>
                {
                    if (v[i] != 0) result &= false;
                });
                return result;
            }
            else//(better for small vector, like 10x10)
            {
                for (int i = 1; i < v.Length; i++)
                {
                    if (v[i] != 0) return false;
                }
                return true;
            }
        }

        /// <summary>
        /// Make all values in the vector positive.
        /// </summary>
        public void PerformABS()
        {
            v = MKLNET.Vector.Abs(v);
        }

        /// <summary>
        /// Disposes the inner vector (it's important to avoid 'system out of memory' problems).
        /// </summary>
        public void Dispose()
        {
            v?.Dispose();
        }

        /// <summary>
        /// Returns a copy (by valeu, not by reference) of the inner vector object (a clone, actually).
        /// </summary>
        /// <returns></returns>
        public MKLNET.vector GetCopyOfInnerVector()
        {
            return MKLNET.Vector.Copy(v);
        }

        #endregion

        #region PROPERTIES

        /// <summary>
        /// Returns a specific vector value.
        /// </summary>
        /// <param name="row">The row number (the first row is the row number 0).</param>
        /// <returns></returns>
        public double this[int row]
        {
            get { return v[row]; }
        }

        /// <summary>
        /// Returns the number of rows in the vector.
        /// </summary>
        public int Length
        {
            get { return v.Length; }
        }

        /// <summary>
        /// Returns the inner vector object (used to perform vector and matrix operations).
        /// </summary>
        public MKLNET.vector V
        {
            get { return v; }
            set { v = value; }
        }

        //Should not have complex properties (memory issues).

        #endregion

    }
}
