using System;
using System.Security;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;

namespace MKLNET
{
    //public struct RcidTrnspTask
    //{
    //    readonly IntPtr Ptr;
    //}

    [SuppressUnmanagedCodeSecurity]
    public unsafe static class Rci
    {
#if LINUX
        const string DLL = "libmkl_rt.so";
#elif OSX
        const string DLL = "libmkl_rt.dylib";
#else
        const string DLL = "mkl_rt.dll";
#endif

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern RciStatus dtrnlsp_init(IntPtr* handle, IntPtr n, IntPtr m, IntPtr x, IntPtr eps, IntPtr iter1, IntPtr iter2, IntPtr rs);
        //public static RciStatus trnlsp_init(int n, int m, double[] x, double[] eps, int iter1, int iter2, double rs)
        //{
        //    var pinned = new Pinned(4);
        //    IntPtr task;
        //    return dtrnlsp_init(&task, &n, &m, pinned.Add(x), pinned.Add(eps), &iter1, &iter2, &rs);
        //}
        //public static VsldSSTask SSNewTask(int p, int n, VslStorage storage, double[] x)
        //{
        //    var (pp, np, sp) = SSAllocate(p, n, storage);
        //    var pinned = new Pinned(4);
        //    IntPtr task;
        //    var status = vsldSSNewTask(&task, pp, np, sp, pinned.Add(x), IntPtr.Zero, IntPtr.Zero);
        //    if (status != 0) throw new Exception("Non zero status: " + status);
        //    return new VsldSSTask { Ptr = task, Allocated = pp, Pinned = pinned };
        //}

        //typedef void (* USRFCND) (MKL_INT*, MKL_INT*, double*, double*);
        //typedef void (* USRFCNXD) (MKL_INT*, MKL_INT*, double*, double*, void*);

        //typedef void (* USRFCNS) (MKL_INT*, MKL_INT*, float*, float*);
        //typedef void (* USRFCNXS) (MKL_INT*, MKL_INT*, float*, float*, void*);

        ///* Function prototypes */
        //extern MKL_INT dtrnlsp_init(_TRNSP_HANDLE_t*, const MKL_INT*, const MKL_INT*, const double*, const double*, const MKL_INT*, const MKL_INT*, const double*);
        //extern MKL_INT dtrnlsp_check(_TRNSP_HANDLE_t*, const MKL_INT*, const MKL_INT*, const double*, const double*, const double*, MKL_INT*);
        //extern MKL_INT dtrnlsp_solve(_TRNSP_HANDLE_t*, double*, double*, MKL_INT*);
        //extern MKL_INT dtrnlsp_get(_TRNSP_HANDLE_t*, MKL_INT*, MKL_INT*, double*, double*);
        //extern MKL_INT dtrnlsp_delete(_TRNSP_HANDLE_t*);

        //extern MKL_INT dtrnlspbc_init(_TRNSPBC_HANDLE_t*, const MKL_INT*, const MKL_INT*, const double*, const double*, const double*, const double*, const MKL_INT*, const MKL_INT*, const double*);
        //extern MKL_INT dtrnlspbc_check(_TRNSPBC_HANDLE_t*, const MKL_INT*, const MKL_INT*, const double*, const double*, const double*, const double*, const double*, MKL_INT*);
        //extern MKL_INT dtrnlspbc_solve(_TRNSPBC_HANDLE_t*, double*, double*, MKL_INT*);
        //extern MKL_INT dtrnlspbc_get(_TRNSPBC_HANDLE_t*, MKL_INT*, MKL_INT*, double*, double*);
        //extern MKL_INT dtrnlspbc_delete(_TRNSPBC_HANDLE_t*);

        //extern MKL_INT djacobi_init(_JACOBIMATRIX_HANDLE_t*, const MKL_INT*, const MKL_INT*, const double*, const double*, const double*);
        //extern MKL_INT djacobi_solve(_JACOBIMATRIX_HANDLE_t*, double*, double*, MKL_INT*);
        //extern MKL_INT djacobi_delete(_JACOBIMATRIX_HANDLE_t*);
        //extern MKL_INT djacobi(USRFCND fcn, const MKL_INT*, const MKL_INT*, double*, double*, double*);
        //extern MKL_INT djacobix(USRFCNXD fcn, const MKL_INT*, const MKL_INT*, double*, double*, double*, void*);

        //extern MKL_INT strnlsp_init(_TRNSP_HANDLE_t*, const MKL_INT*, const MKL_INT*, const float*, const float*, const MKL_INT*, const MKL_INT*, const float*);
        //extern MKL_INT strnlsp_check(_TRNSP_HANDLE_t*, const MKL_INT*, const MKL_INT*, const float*, const float*, const float*, MKL_INT*);
        //extern MKL_INT strnlsp_solve(_TRNSP_HANDLE_t*, float*, float*, MKL_INT*);
        //extern MKL_INT strnlsp_get(_TRNSP_HANDLE_t*, MKL_INT*, MKL_INT*, float*, float*);
        //extern MKL_INT strnlsp_delete(_TRNSP_HANDLE_t*);

        //extern MKL_INT strnlspbc_init(_TRNSPBC_HANDLE_t*, const MKL_INT*, const MKL_INT*, const float*, const float*, const float*, const float*, const MKL_INT*, const MKL_INT*, const float*);
        //extern MKL_INT strnlspbc_check(_TRNSPBC_HANDLE_t*, const MKL_INT*, const MKL_INT*, const float*, const float*, const float*, const float*, const float*, MKL_INT*);
        //extern MKL_INT strnlspbc_solve(_TRNSPBC_HANDLE_t*, float*, float*, MKL_INT*);
        //extern MKL_INT strnlspbc_get(_TRNSPBC_HANDLE_t*, MKL_INT*, MKL_INT*, float*, float*);
        //extern MKL_INT strnlspbc_delete(_TRNSPBC_HANDLE_t*);

        //extern MKL_INT sjacobi_init(_JACOBIMATRIX_HANDLE_t*, const MKL_INT*, const MKL_INT*, const float*, const float*, const float*);
        //extern MKL_INT sjacobi_solve(_JACOBIMATRIX_HANDLE_t*, float*, float*, MKL_INT*);
        //extern MKL_INT sjacobi_delete(_JACOBIMATRIX_HANDLE_t*);
        //extern MKL_INT sjacobi(USRFCNS fcn, const MKL_INT*, const MKL_INT*, float*, float*, float*);
        //extern MKL_INT sjacobix(USRFCNXS fcn, const MKL_INT*, const MKL_INT*, float*, float*, float*, void*);
    }
}