using System;
using System.Runtime.InteropServices;

namespace MKLNET
{
    public static class MKL
    {
        public static readonly IGeneral General;
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
                    General = new GeneralWin64();
                }
                else
                {
                    Blas = new BlasWin86();
                    Lapack = new LapackWin86();
                    General = new GeneralWin86();
                }
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux) && Environment.Is64BitProcess)
            {
                Blas = new BlasLinux();
                Lapack = new LapackLinux();
                General = new GeneralLinux();
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX) && Environment.Is64BitProcess)
            {
                Blas = new BlasOSX();
                Lapack = new LapackOSX();
                General = new GeneralOSX();
            }
            else throw new PlatformNotSupportedException();
        }
    }
}