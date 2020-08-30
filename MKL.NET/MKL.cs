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
            Blas = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? Environment.Is64BitProcess ? (IBlas)new BlasWin64() : new BlasWin86()
                 : RuntimeInformation.IsOSPlatform(OSPlatform.Linux) && Environment.Is64BitProcess ? (IBlas)new BlasLinux()
                 : RuntimeInformation.IsOSPlatform(OSPlatform.OSX) && Environment.Is64BitProcess ? new BlasOSX()
                 : throw new PlatformNotSupportedException();
            Lapack = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? Environment.Is64BitProcess ? (ILapack)new LapackWin64() : new LapackWin86()
                 : RuntimeInformation.IsOSPlatform(OSPlatform.Linux) && Environment.Is64BitProcess ? (ILapack)new LapackLinux()
                 : RuntimeInformation.IsOSPlatform(OSPlatform.OSX) && Environment.Is64BitProcess ? new LapackOSX()
                 : throw new PlatformNotSupportedException();
        }
    }
}