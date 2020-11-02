using System;
using System.Runtime.CompilerServices;

namespace MKLNET
{
    internal static class ThrowHelper
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        internal static void ThrowIncorrectMatrixDimesionsForOperation()
        {
            throw new Exception("Incorrect Matrix Dimensions For Operation");
        }
    }
}
