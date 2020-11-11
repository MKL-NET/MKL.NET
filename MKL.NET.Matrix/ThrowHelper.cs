using System;
using System.Runtime.CompilerServices;

namespace MKLNET
{
    public static class ThrowHelper
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void ThrowIncorrectDimensionsForOperation()
        {
            throw new Exception("Incorrect Dimensions For Operation");
        }

        public static void Check(int i)
        {
            if (i != 0) throw new Exception("MKL Error code: " + i);
        }
    }
}
