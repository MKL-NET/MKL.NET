using System.Runtime.CompilerServices;

namespace MKLNET
{
    public static partial class Optimize
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fa"></param>
        /// <param name="fb"></param>
        /// <param name="fc"></param>
        /// <returns></returns>
        public static bool Minimize_Bracketed(double fa, double fb, double fc)
            => fa > fb && fb < fc;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static double Sqr(double x) => x * x;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="fa"></param>
        /// <param name="b"></param>
        /// <param name="fb"></param>
        /// <param name="c"></param>
        /// <param name="fc"></param>
        /// <returns></returns>
        public static double Minimize_Quadratic(double a, double fa, double b, double fb, double c, double fc)
            => b - 0.5 * (Sqr(b - a) * (fb - fc) - Sqr(b - c) * (fb - fa)) / ((b - a) * (fb - fc) - (b - c) * (fb - fa));
    }
}
