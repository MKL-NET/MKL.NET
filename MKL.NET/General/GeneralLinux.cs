using System.Runtime.InteropServices;

namespace MKLNET
{
    internal class GeneralLinux : IGeneral
    {
        const string DLL = "libmkl_rt.so";

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int mkl_get_version(ref MKLVersion_ version);
        public MKLVersion Version
        {
            get
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
        }

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void mkl_set_num_threads(int nt);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int mkl_get_max_threads();
        public int Max_Threads
        {
            get => mkl_get_max_threads();
            set => mkl_set_num_threads(value);
        }
    }
}
