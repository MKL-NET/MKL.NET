using System;
using System.Runtime.InteropServices;

namespace MKLNET
{
    public static class MKL
    {
        public static readonly IBlas Blas;
        public static readonly ILapack Lapack;
        static MKL()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                if (Environment.Is64BitProcess)
                {
                    Blas = new BlasWin64();
                    Lapack = new LapackWin64();
                }
                else
                {
                    Blas = new BlasWin86();
                    Lapack = new LapackWin86();
                }
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux) && Environment.Is64BitProcess)
            {
                Blas = new BlasLinux();
                Lapack = new LapackLinux();
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX) && Environment.Is64BitProcess)
            {
                Blas = new BlasOSX();
                Lapack = new LapackOSX();
            }
            else throw new PlatformNotSupportedException();
        }
    }
}