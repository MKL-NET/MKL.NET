using System;
using System.Runtime.CompilerServices;

namespace MKLNET
{
    internal static class ThrowHelper
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        internal static void ThrowIncorrectVectorDimensionsForOperation()
        {
            throw new Exception("Incorrect Vector Dimensions For Operation");
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        internal static void ThrowIncorrectMatrixDimensionsForOperation()
        {
            throw new Exception("Incorrect Matrix Dimensions For Operation");
        }
    }
}
