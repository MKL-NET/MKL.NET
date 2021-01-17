using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MKL0
{
    /// <summary>
    /// A class to generate random numbers.
    /// </summary>
    internal static class StaticRandom
    {
        static int seed = Environment.TickCount;

        static readonly ThreadLocal<Random> random = new ThreadLocal<Random>(() => new Random(Interlocked.Increment(ref seed)));

        /// <summary>
        /// Creates a new random number.
        /// </summary>
        /// <param name="min">The minimum value to the number.</param>
        /// <param name="max">The maximum value to the number.</param>
        /// <returns></returns>
        public static int Rand(int min, int max)
        {
            return random.Value.Next(min, max);
        }
    }
}
