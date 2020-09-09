using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;

namespace MKLNET
{
    public static class MKL
    {
#if LINUX
        const string DLL = "libmkl_rt.so";
#elif OSX
        const string DLL = "libmkl_rt.dylib";
#else
        const string DLL = "mkl_rt.dll";
#endif
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int mkl_get_version(ref MKLVersion_ version);
        public static MKLVersion get_version()
        {
            var mklVer_ = new MKLVersion_();
            mkl_get_version(ref mklVer_);
            unsafe
            {
                return new MKLVersion
                {
                    MajorVersion = mklVer_.MajorVersion,
                    MinorVersion = mklVer_.MinorVersion,
                    UpdateVersion = mklVer_.UpdateVersion,
                    ProductStatus = new string(mklVer_.ProductStatus),
                    Build = new string(mklVer_.Build),
                    Processor = new string(mklVer_.Processor),
                    Platform = new string(mklVer_.Platform),
                };
            }
        }

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void mkl_set_num_threads(int nt);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void set_num_threads(int nt) => mkl_set_num_threads(nt);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int mkl_get_max_threads();
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int get_max_threads() => mkl_get_max_threads();
    }
}