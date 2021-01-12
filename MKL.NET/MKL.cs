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
        static unsafe extern void mkl_get_version_string(sbyte* buf, int len);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static string get_version_string()
        {
            const int len = 198;
            fixed (sbyte* chars = new sbyte[len])
            {
                mkl_get_version_string(chars, len);
                return new string(chars);
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

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern MklThreading mkl_set_threading_layer(MklThreading required_threading);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static MklThreading set_threading_layer(MklThreading required_threading)
            => mkl_set_threading_layer(required_threading);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int mkl_get_dynamic();
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int get_dynamic() => mkl_get_dynamic();

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void mkl_set_dynamic(int flag);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void set_dynamic(int flag) => mkl_set_dynamic(flag);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int mkl_cbwr_set(MklCBWR option);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int cbwr_set(MklCBWR option)
            => mkl_cbwr_set(option);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern MklCBWR mkl_cbwr_get_auto_branch();
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static MklCBWR cbwr_get_auto_branch()
            => mkl_cbwr_get_auto_branch();
    }
}