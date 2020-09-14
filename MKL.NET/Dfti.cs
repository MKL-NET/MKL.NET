using System.Security;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;

namespace MKLNET
{
    [SuppressUnmanagedCodeSecurity]
    public static class Dfti
    {
#if LINUX
        const string DLL = "libmkl_rt.so";
#elif OSX
        const string DLL = "libmkl_rt.dylib";
#else
        const string DLL = "mkl_rt.dll";
#endif

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern DfdiStatus DftiCreateDescriptor(out DftiDescriptor handle, DftiConfigValue precision, DftiConfigValue forward_domain, long dimension, long length);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DfdiStatus CreateDescriptor(out DftiDescriptor handle, DftiConfigValue precision, DftiConfigValue forward_domain, long dimension, long length)
            => DftiCreateDescriptor(out handle, precision, forward_domain, dimension, length);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern DfdiStatus DftiCreateDescriptor(out DftiDescriptor handle, DftiConfigValue precision, DftiConfigValue forward_domain, long dimension, long[] length);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DfdiStatus CreateDescriptor(out DftiDescriptor handle, DftiConfigValue precision, DftiConfigValue forward_domain, long dimension, long[] length)
            => DftiCreateDescriptor(out handle, precision, forward_domain, dimension, length);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern DfdiStatus DftiCopyDescriptor(DftiDescriptor original, out DftiDescriptor copy);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DfdiStatus CopyDescriptor(DftiDescriptor original, out DftiDescriptor copy)
            => DftiCopyDescriptor(original, out copy);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern DfdiStatus DftiCommitDescriptor(DftiDescriptor handle);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DfdiStatus CommitDescriptor(DftiDescriptor handle)
            => DftiCommitDescriptor(handle);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern DfdiStatus DftiComputeForward(DftiDescriptor handle, double[] x_inout);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DfdiStatus ComputeForward(DftiDescriptor handle, double[] x_inout)
            => DftiComputeForward(handle, x_inout);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern DfdiStatus DftiComputeForward(DftiDescriptor handle, double[] x_in, double[] x_out);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DfdiStatus ComputeForward(DftiDescriptor handle, double[] x_in, double[] x_out)
            => DftiComputeForward(handle, x_in, x_out);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern DfdiStatus DftiComputeForward(DftiDescriptor handle, float[] x_inout);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DfdiStatus ComputeForward(DftiDescriptor handle, float[] x_inout)
            => DftiComputeForward(handle, x_inout);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern DfdiStatus DftiComputeForward(DftiDescriptor handle, float[] x_in, float[] x_out);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DfdiStatus ComputeForward(DftiDescriptor handle, float[] x_in, float[] x_out)
            => DftiComputeForward(handle, x_in, x_out);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern DfdiStatus DftiComputeBackward(DftiDescriptor handle, double[] x_inout);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DfdiStatus ComputeBackward(DftiDescriptor handle, double[] x_inout)
            => DftiComputeBackward(handle, x_inout);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern DfdiStatus DftiComputeBackward(DftiDescriptor handle, double[] x_in, double[] x_out);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DfdiStatus ComputeBackward(DftiDescriptor handle, double[] x_in, double[] x_out)
            => DftiComputeBackward(handle, x_in, x_out);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern DfdiStatus DftiComputeBackward(DftiDescriptor handle, float[] x_inout);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DfdiStatus ComputeBackward(DftiDescriptor handle, float[] x_inout)
            => DftiComputeBackward(handle, x_inout);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern DfdiStatus DftiComputeBackward(DftiDescriptor handle, float[] x_in, float[] x_out);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DfdiStatus ComputeBackward(DftiDescriptor handle, float[] x_in, float[] x_out)
            => DftiComputeBackward(handle, x_in, x_out);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern DfdiStatus DftiSetValue(DftiDescriptor handle, DftiConfigParam config_param, int config_value);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DfdiStatus SetValue(DftiDescriptor handle, DftiConfigParam config_param, int config_value)
            => DftiSetValue(handle, config_param, config_value);
        public static DfdiStatus SetValue(DftiDescriptor handle, DftiConfigParam config_param, DftiConfigValue config_value)
            => DftiSetValue(handle, config_param, (int)config_value);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern DfdiStatus DftiSetValue(DftiDescriptor handle, DftiConfigParam config_param, float config_value);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DfdiStatus SetValue(DftiDescriptor handle, DftiConfigParam config_param, float config_value)
            => DftiSetValue(handle, config_param, config_value);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern DfdiStatus DftiSetValue(DftiDescriptor handle, DftiConfigParam config_param, double config_value);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DfdiStatus SetValue(DftiDescriptor handle, DftiConfigParam config_param, double config_value)
            => DftiSetValue(handle, config_param, config_value);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern DfdiStatus DftiSetValue(DftiDescriptor handle, DftiConfigParam config_param, int[] config_value);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DfdiStatus SetValue(DftiDescriptor handle, DftiConfigParam config_param, int[] config_value)
            => DftiSetValue(handle, config_param, config_value);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern DfdiStatus DftiSetValue(DftiDescriptor handle, DftiConfigParam config_param, float[] config_value);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DfdiStatus SetValue(DftiDescriptor handle, DftiConfigParam config_param, float[] config_value)
            => DftiSetValue(handle, config_param, config_value);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern DfdiStatus DftiSetValue(DftiDescriptor handle, DftiConfigParam config_param, double[] config_value);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DfdiStatus SetValue(DftiDescriptor handle, DftiConfigParam config_param, double[] config_value)
            => DftiSetValue(handle, config_param, config_value);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern DfdiStatus DftiGetValue(DftiDescriptor handle, DftiConfigParam config_param, out int config_value);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DfdiStatus GetValue(DftiDescriptor handle, DftiConfigParam config_param, out int config_value)
            => DftiGetValue(handle, config_param, out config_value);
        public static DfdiStatus GetValue(DftiDescriptor handle, DftiConfigParam config_param, out DftiConfigValue config_value)
        {
            var status = GetValue(handle, config_param, out int config_value_int);
            config_value = (DftiConfigValue)config_value_int;
            return status;
        }

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern DfdiStatus DftiGetValue(DftiDescriptor handle, DftiConfigParam config_param, out float config_value);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DfdiStatus GetValue(DftiDescriptor handle, DftiConfigParam config_param, out float config_value)
            => DftiGetValue(handle, config_param, out config_value);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern DfdiStatus DftiGetValue(DftiDescriptor handle, DftiConfigParam config_param, out double config_value);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DfdiStatus GetValue(DftiDescriptor handle, DftiConfigParam config_param, out double config_value)
            => DftiGetValue(handle, config_param, out config_value);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern DfdiStatus DftiGetValue(DftiDescriptor handle, DftiConfigParam config_param, out int[] config_value);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DfdiStatus GetValue(DftiDescriptor handle, DftiConfigParam config_param, out int[] config_value)
            => DftiGetValue(handle, config_param, out config_value);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern DfdiStatus DftiGetValue(DftiDescriptor handle, DftiConfigParam config_param, out float[] config_value);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DfdiStatus GetValue(DftiDescriptor handle, DftiConfigParam config_param, out float[] config_value)
            => DftiGetValue(handle, config_param, out config_value);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern DfdiStatus DftiGetValue(DftiDescriptor handle, DftiConfigParam config_param, out double[] config_value);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DfdiStatus GetValue(DftiDescriptor handle, DftiConfigParam config_param, out double[] config_value)
            => DftiGetValue(handle, config_param, out config_value);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern DfdiStatus DftiFreeDescriptor(ref DftiDescriptor handle);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DfdiStatus FreeDescriptor(DftiDescriptor handle)
            => DftiFreeDescriptor(ref handle);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static unsafe extern char* DftiErrorMessage(DfdiStatus status);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern DfdiStatus DftiErrorClass(DfdiStatus status, DftiErrorClass error_class);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DfdiStatus ErrorClass(DfdiStatus status, DftiErrorClass error_class)
            => DftiErrorClass(status, error_class);
    }
}