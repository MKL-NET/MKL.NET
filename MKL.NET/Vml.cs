using System.Security;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;

namespace MKLNET
{
    [SuppressUnmanagedCodeSecurity]
    public static class Vml
    {
#if LINUX
        const string DLL = "libmkl_rt.so";
#elif OSX
        const string DLL = "libmkl_rt.dylib";
#else
        const string DLL = "mkl_rt.dll";
#endif

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsAbs(int n, float[] a, float[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Abs(int n, float[] a, float[] r)
            => vsAbs(n, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdAbs(int n, double[] a, double[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Abs(int n, double[] a, double[] r)
            => vdAbs(n, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsAbs(int n, float[] a, float[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Abs(int n, float[] a, float[] r, VmlMode mode)
            => vmsAbs(n, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdAbs(int n, double[] a, double[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Abs(int n, double[] a, double[] r, VmlMode mode)
            => vmdAbs(n, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsAdd(int n, float[] a, float[] b, float[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Add(int n, float[] a, float[] b, float[] r)
            => vsAdd(n, a, b, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdAdd(int n, double[] a, double[] b, double[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Add(int n, double[] a, double[] b, double[] r)
            => vdAdd(n, a, b, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsAdd(int n, float[] a, float[] b, float[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Add(int n, float[] a, float[] b, float[] r, VmlMode mode)
            => vmsAdd(n, a, b, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdAdd(int n, double[] a, double[] b, double[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Add(int n, double[] a, double[] b, double[] r, VmlMode mode)
            => vmdAdd(n, a, b, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsSub(int n, float[] a, float[] b, float[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Sub(int n, float[] a, float[] b, float[] r)
            => vsSub(n, a, b, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdSub(int n, double[] a, double[] b, double[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Sub(int n, double[] a, double[] b, double[] r)
            => vdSub(n, a, b, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsSub(int n, float[] a, float[] b, float[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Sub(int n, float[] a, float[] b, float[] r, VmlMode mode)
            => vmsSub(n, a, b, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdSub(int n, double[] a, double[] b, double[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Sub(int n, double[] a, double[] b, double[] r, VmlMode mode)
            => vmdSub(n, a, b, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsInv(int n, float[] a, float[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Inv(int n, float[] a, float[] r)
            => vsInv(n, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdInv(int n, double[] a, double[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Inv(int n, double[] a, double[] r)
            => vdInv(n, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsInv(int n, float[] a, float[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Inv(int n, float[] a, float[] r, VmlMode mode)
            => vmsInv(n, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdInv(int n, double[] a, double[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Inv(int n, double[] a, double[] r, VmlMode mode)
            => vmdInv(n, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsSqrt(int n, float[] a, float[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Sqrt(int n, float[] a, float[] r)
            => vsSqrt(n, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdSqrt(int n, double[] a, double[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Sqrt(int n, double[] a, double[] r)
            => vdSqrt(n, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsSqrt(int n, float[] a, float[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Sqrt(int n, float[] a, float[] r, VmlMode mode)
            => vmsSqrt(n, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdSqrt(int n, double[] a, double[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Sqrt(int n, double[] a, double[] r, VmlMode mode)
            => vmdSqrt(n, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsInvSqrt(int n, float[] a, float[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void InvSqrt(int n, float[] a, float[] r)
            => vsInvSqrt(n, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdInvSqrt(int n, double[] a, double[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void InvSqrt(int n, double[] a, double[] r)
            => vdInvSqrt(n, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsInvSqrt(int n, float[] a, float[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void InvSqrt(int n, float[] a, float[] r, VmlMode mode)
            => vmsInvSqrt(n, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdInvSqrt(int n, double[] a, double[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void InvSqrt(int n, double[] a, double[] r, VmlMode mode)
            => vmdInvSqrt(n, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsCbrt(int n, float[] a, float[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Cbrt(int n, float[] a, float[] r)
            => vsCbrt(n, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdCbrt(int n, double[] a, double[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Cbrt(int n, double[] a, double[] r)
            => vdCbrt(n, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsCbrt(int n, float[] a, float[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Cbrt(int n, float[] a, float[] r, VmlMode mode)
            => vmsCbrt(n, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdCbrt(int n, double[] a, double[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Cbrt(int n, double[] a, double[] r, VmlMode mode)
            => vmdCbrt(n, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsInvCbrt(int n, float[] a, float[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void InvCbrt(int n, float[] a, float[] r)
            => vsInvCbrt(n, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdInvCbrt(int n, double[] a, double[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void InvCbrt(int n, double[] a, double[] r)
            => vdInvCbrt(n, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsInvCbrt(int n, float[] a, float[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void InvCbrt(int n, float[] a, float[] r, VmlMode mode)
            => vmsInvCbrt(n, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdInvCbrt(int n, double[] a, double[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void InvCbrt(int n, double[] a, double[] r, VmlMode mode)
            => vmdInvCbrt(n, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsSqr(int n, float[] a, float[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Sqr(int n, float[] a, float[] r)
            => vsSqr(n, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdSqr(int n, double[] a, double[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Sqr(int n, double[] a, double[] r)
            => vdSqr(n, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsSqr(int n, float[] a, float[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Sqr(int n, float[] a, float[] r, VmlMode mode)
            => vmsSqr(n, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdSqr(int n, double[] a, double[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Sqr(int n, double[] a, double[] r, VmlMode mode)
            => vmdSqr(n, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsExp(int n, float[] a, float[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Exp(int n, float[] a, float[] r)
            => vsExp(n, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdExp(int n, double[] a, double[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Exp(int n, double[] a, double[] r)
            => vdExp(n, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsExp(int n, float[] a, float[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Exp(int n, float[] a, float[] r, VmlMode mode)
            => vmsExp(n, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdExp(int n, double[] a, double[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Exp(int n, double[] a, double[] r, VmlMode mode)
            => vmdExp(n, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsExp2(int n, float[] a, float[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Exp2(int n, float[] a, float[] r)
            => vsExp2(n, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdExp2(int n, double[] a, double[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Exp2(int n, double[] a, double[] r)
            => vdExp2(n, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsExp2(int n, float[] a, float[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Exp2(int n, float[] a, float[] r, VmlMode mode)
            => vmsExp2(n, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdExp2(int n, double[] a, double[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Exp2(int n, double[] a, double[] r, VmlMode mode)
            => vmdExp2(n, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsExp10(int n, float[] a, float[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Exp10(int n, float[] a, float[] r)
            => vsExp10(n, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdExp10(int n, double[] a, double[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Exp10(int n, double[] a, double[] r)
            => vdExp10(n, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsExp10(int n, float[] a, float[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Exp10(int n, float[] a, float[] r, VmlMode mode)
            => vmsExp10(n, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdExp10(int n, double[] a, double[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Exp10(int n, double[] a, double[] r, VmlMode mode)
            => vmdExp10(n, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsExpm1(int n, float[] a, float[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Expm1(int n, float[] a, float[] r)
            => vsExpm1(n, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdExpm1(int n, double[] a, double[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Expm1(int n, double[] a, double[] r)
            => vdExpm1(n, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsExpm1(int n, float[] a, float[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Expm1(int n, float[] a, float[] r, VmlMode mode)
            => vmsExpm1(n, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdExpm1(int n, double[] a, double[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Expm1(int n, double[] a, double[] r, VmlMode mode)
            => vmdExpm1(n, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsLn(int n, float[] a, float[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Ln(int n, float[] a, float[] r)
            => vsLn(n, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdLn(int n, double[] a, double[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Ln(int n, double[] a, double[] r)
            => vdLn(n, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsLn(int n, float[] a, float[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Ln(int n, float[] a, float[] r, VmlMode mode)
            => vmsLn(n, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdLn(int n, double[] a, double[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Ln(int n, double[] a, double[] r, VmlMode mode)
            => vmdLn(n, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsLog2(int n, float[] a, float[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Log2(int n, float[] a, float[] r)
            => vsLog2(n, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdLog2(int n, double[] a, double[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Log2(int n, double[] a, double[] r)
            => vdLog2(n, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsLog2(int n, float[] a, float[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Log2(int n, float[] a, float[] r, VmlMode mode)
            => vmsLog2(n, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdLog2(int n, double[] a, double[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Log2(int n, double[] a, double[] r, VmlMode mode)
            => vmdLog2(n, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsLog10(int n, float[] a, float[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Log10(int n, float[] a, float[] r)
            => vsLog10(n, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdLog10(int n, double[] a, double[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Log10(int n, double[] a, double[] r)
            => vdLog10(n, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsLog10(int n, float[] a, float[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Log10(int n, float[] a, float[] r, VmlMode mode)
            => vmsLog10(n, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdLog10(int n, double[] a, double[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Log10(int n, double[] a, double[] r, VmlMode mode)
            => vmdLog10(n, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsLog1p(int n, float[] a, float[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Log1p(int n, float[] a, float[] r)
            => vsLog1p(n, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdLog1p(int n, double[] a, double[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Log1p(int n, double[] a, double[] r)
            => vdLog1p(n, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsLog1p(int n, float[] a, float[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Log1p(int n, float[] a, float[] r, VmlMode mode)
            => vmsLog1p(n, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdLog1p(int n, double[] a, double[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Log1p(int n, double[] a, double[] r, VmlMode mode)
            => vmdLog1p(n, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsLogb(int n, float[] a, float[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Logb(int n, float[] a, float[] r)
            => vsLogb(n, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdLogb(int n, double[] a, double[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Logb(int n, double[] a, double[] r)
            => vdLogb(n, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsLogb(int n, float[] a, float[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Logb(int n, float[] a, float[] r, VmlMode mode)
            => vmsLogb(n, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdLogb(int n, double[] a, double[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Logb(int n, double[] a, double[] r, VmlMode mode)
            => vmdLogb(n, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsCos(int n, float[] a, float[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Cos(int n, float[] a, float[] r)
            => vsCos(n, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdCos(int n, double[] a, double[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Cos(int n, double[] a, double[] r)
            => vdCos(n, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsCos(int n, float[] a, float[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Cos(int n, float[] a, float[] r, VmlMode mode)
            => vmsCos(n, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdCos(int n, double[] a, double[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Cos(int n, double[] a, double[] r, VmlMode mode)
            => vmdCos(n, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsSin(int n, float[] a, float[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Sin(int n, float[] a, float[] r)
            => vsSin(n, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdSin(int n, double[] a, double[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Sin(int n, double[] a, double[] r)
            => vdSin(n, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsSin(int n, float[] a, float[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Sin(int n, float[] a, float[] r, VmlMode mode)
            => vmsSin(n, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdSin(int n, double[] a, double[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Sin(int n, double[] a, double[] r, VmlMode mode)
            => vmdSin(n, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsTan(int n, float[] a, float[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Tan(int n, float[] a, float[] r)
            => vsTan(n, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdTan(int n, double[] a, double[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Tan(int n, double[] a, double[] r)
            => vdTan(n, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsTan(int n, float[] a, float[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Tan(int n, float[] a, float[] r, VmlMode mode)
            => vmsTan(n, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdTan(int n, double[] a, double[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Tan(int n, double[] a, double[] r, VmlMode mode)
            => vmdTan(n, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsCospi(int n, float[] a, float[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Cospi(int n, float[] a, float[] r)
            => vsCospi(n, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdCospi(int n, double[] a, double[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Cospi(int n, double[] a, double[] r)
            => vdCospi(n, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsCospi(int n, float[] a, float[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Cospi(int n, float[] a, float[] r, VmlMode mode)
            => vmsCospi(n, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdCospi(int n, double[] a, double[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Cospi(int n, double[] a, double[] r, VmlMode mode)
            => vmdCospi(n, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsSinpi(int n, float[] a, float[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Sinpi(int n, float[] a, float[] r)
            => vsSinpi(n, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdSinpi(int n, double[] a, double[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Sinpi(int n, double[] a, double[] r)
            => vdSinpi(n, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsSinpi(int n, float[] a, float[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Sinpi(int n, float[] a, float[] r, VmlMode mode)
            => vmsSinpi(n, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdSinpi(int n, double[] a, double[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Sinpi(int n, double[] a, double[] r, VmlMode mode)
            => vmdSinpi(n, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsTanpi(int n, float[] a, float[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Tanpi(int n, float[] a, float[] r)
            => vsTanpi(n, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdTanpi(int n, double[] a, double[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Tanpi(int n, double[] a, double[] r)
            => vdTanpi(n, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsTanpi(int n, float[] a, float[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Tanpi(int n, float[] a, float[] r, VmlMode mode)
            => vmsTanpi(n, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdTanpi(int n, double[] a, double[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Tanpi(int n, double[] a, double[] r, VmlMode mode)
            => vmdTanpi(n, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsCosd(int n, float[] a, float[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Cosd(int n, float[] a, float[] r)
            => vsCosd(n, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdCosd(int n, double[] a, double[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Cosd(int n, double[] a, double[] r)
            => vdCosd(n, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsCosd(int n, float[] a, float[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Cosd(int n, float[] a, float[] r, VmlMode mode)
            => vmsCosd(n, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdCosd(int n, double[] a, double[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Cosd(int n, double[] a, double[] r, VmlMode mode)
            => vmdCosd(n, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsSind(int n, float[] a, float[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Sind(int n, float[] a, float[] r)
            => vsSind(n, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdSind(int n, double[] a, double[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Sind(int n, double[] a, double[] r)
            => vdSind(n, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsSind(int n, float[] a, float[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Sind(int n, float[] a, float[] r, VmlMode mode)
            => vmsSind(n, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdSind(int n, double[] a, double[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Sind(int n, double[] a, double[] r, VmlMode mode)
            => vmdSind(n, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsTand(int n, float[] a, float[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Tand(int n, float[] a, float[] r)
            => vsTand(n, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdTand(int n, double[] a, double[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Tand(int n, double[] a, double[] r)
            => vdTand(n, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsTand(int n, float[] a, float[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Tand(int n, float[] a, float[] r, VmlMode mode)
            => vmsTand(n, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdTand(int n, double[] a, double[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Tand(int n, double[] a, double[] r, VmlMode mode)
            => vmdTand(n, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsCosh(int n, float[] a, float[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Cosh(int n, float[] a, float[] r)
            => vsCosh(n, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdCosh(int n, double[] a, double[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Cosh(int n, double[] a, double[] r)
            => vdCosh(n, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsCosh(int n, float[] a, float[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Cosh(int n, float[] a, float[] r, VmlMode mode)
            => vmsCosh(n, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdCosh(int n, double[] a, double[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Cosh(int n, double[] a, double[] r, VmlMode mode)
            => vmdCosh(n, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsSinh(int n, float[] a, float[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Sinh(int n, float[] a, float[] r)
            => vsSinh(n, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdSinh(int n, double[] a, double[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Sinh(int n, double[] a, double[] r)
            => vdSinh(n, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsSinh(int n, float[] a, float[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Sinh(int n, float[] a, float[] r, VmlMode mode)
            => vmsSinh(n, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdSinh(int n, double[] a, double[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Sinh(int n, double[] a, double[] r, VmlMode mode)
            => vmdSinh(n, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsTanh(int n, float[] a, float[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Tanh(int n, float[] a, float[] r)
            => vsTanh(n, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdTanh(int n, double[] a, double[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Tanh(int n, double[] a, double[] r)
            => vdTanh(n, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsTanh(int n, float[] a, float[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Tanh(int n, float[] a, float[] r, VmlMode mode)
            => vmsTanh(n, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdTanh(int n, double[] a, double[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Tanh(int n, double[] a, double[] r, VmlMode mode)
            => vmdTanh(n, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsAcos(int n, float[] a, float[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Acos(int n, float[] a, float[] r)
            => vsAcos(n, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdAcos(int n, double[] a, double[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Acos(int n, double[] a, double[] r)
            => vdAcos(n, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsAcos(int n, float[] a, float[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Acos(int n, float[] a, float[] r, VmlMode mode)
            => vmsAcos(n, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdAcos(int n, double[] a, double[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Acos(int n, double[] a, double[] r, VmlMode mode)
            => vmdAcos(n, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsAsin(int n, float[] a, float[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Asin(int n, float[] a, float[] r)
            => vsAsin(n, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdAsin(int n, double[] a, double[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Asin(int n, double[] a, double[] r)
            => vdAsin(n, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsAsin(int n, float[] a, float[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Asin(int n, float[] a, float[] r, VmlMode mode)
            => vmsAsin(n, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdAsin(int n, double[] a, double[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Asin(int n, double[] a, double[] r, VmlMode mode)
            => vmdAsin(n, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsAtan(int n, float[] a, float[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Atan(int n, float[] a, float[] r)
            => vsAtan(n, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdAtan(int n, double[] a, double[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Atan(int n, double[] a, double[] r)
            => vdAtan(n, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsAtan(int n, float[] a, float[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Atan(int n, float[] a, float[] r, VmlMode mode)
            => vmsAtan(n, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdAtan(int n, double[] a, double[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Atan(int n, double[] a, double[] r, VmlMode mode)
            => vmdAtan(n, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsAcospi(int n, float[] a, float[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Acospi(int n, float[] a, float[] r)
            => vsAcospi(n, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdAcospi(int n, double[] a, double[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Acospi(int n, double[] a, double[] r)
            => vdAcospi(n, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsAcospi(int n, float[] a, float[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Acospi(int n, float[] a, float[] r, VmlMode mode)
            => vmsAcospi(n, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdAcospi(int n, double[] a, double[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Acospi(int n, double[] a, double[] r, VmlMode mode)
            => vmdAcospi(n, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsAsinpi(int n, float[] a, float[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Asinpi(int n, float[] a, float[] r)
            => vsAsinpi(n, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdAsinpi(int n, double[] a, double[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Asinpi(int n, double[] a, double[] r)
            => vdAsinpi(n, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsAsinpi(int n, float[] a, float[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Asinpi(int n, float[] a, float[] r, VmlMode mode)
            => vmsAsinpi(n, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdAsinpi(int n, double[] a, double[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Asinpi(int n, double[] a, double[] r, VmlMode mode)
            => vmdAsinpi(n, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsAtanpi(int n, float[] a, float[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Atanpi(int n, float[] a, float[] r)
            => vsAtanpi(n, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdAtanpi(int n, double[] a, double[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Atanpi(int n, double[] a, double[] r)
            => vdAtanpi(n, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsAtanpi(int n, float[] a, float[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Atanpi(int n, float[] a, float[] r, VmlMode mode)
            => vmsAtanpi(n, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdAtanpi(int n, double[] a, double[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Atanpi(int n, double[] a, double[] r, VmlMode mode)
            => vmdAtanpi(n, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsAcosh(int n, float[] a, float[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Acosh(int n, float[] a, float[] r)
            => vsAcosh(n, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdAcosh(int n, double[] a, double[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Acosh(int n, double[] a, double[] r)
            => vdAcosh(n, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsAcosh(int n, float[] a, float[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Acosh(int n, float[] a, float[] r, VmlMode mode)
            => vmsAcosh(n, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdAcosh(int n, double[] a, double[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Acosh(int n, double[] a, double[] r, VmlMode mode)
            => vmdAcosh(n, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsAsinh(int n, float[] a, float[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Asinh(int n, float[] a, float[] r)
            => vsAsinh(n, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdAsinh(int n, double[] a, double[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Asinh(int n, double[] a, double[] r)
            => vdAsinh(n, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsAsinh(int n, float[] a, float[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Asinh(int n, float[] a, float[] r, VmlMode mode)
            => vmsAsinh(n, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdAsinh(int n, double[] a, double[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Asinh(int n, double[] a, double[] r, VmlMode mode)
            => vmdAsinh(n, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsAtanh(int n, float[] a, float[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Atanh(int n, float[] a, float[] r)
            => vsAtanh(n, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdAtanh(int n, double[] a, double[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Atanh(int n, double[] a, double[] r)
            => vdAtanh(n, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsAtanh(int n, float[] a, float[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Atanh(int n, float[] a, float[] r, VmlMode mode)
            => vmsAtanh(n, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdAtanh(int n, double[] a, double[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Atanh(int n, double[] a, double[] r, VmlMode mode)
            => vmdAtanh(n, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsErf(int n, float[] a, float[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Erf(int n, float[] a, float[] r)
            => vsErf(n, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdErf(int n, double[] a, double[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Erf(int n, double[] a, double[] r)
            => vdErf(n, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsErf(int n, float[] a, float[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Erf(int n, float[] a, float[] r, VmlMode mode)
            => vmsErf(n, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdErf(int n, double[] a, double[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Erf(int n, double[] a, double[] r, VmlMode mode)
            => vmdErf(n, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsErfInv(int n, float[] a, float[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ErfInv(int n, float[] a, float[] r)
            => vsErfInv(n, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdErfInv(int n, double[] a, double[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ErfInv(int n, double[] a, double[] r)
            => vdErfInv(n, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsErfInv(int n, float[] a, float[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ErfInv(int n, float[] a, float[] r, VmlMode mode)
            => vmsErfInv(n, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdErfInv(int n, double[] a, double[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ErfInv(int n, double[] a, double[] r, VmlMode mode)
            => vmdErfInv(n, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsHypot(int n, float[] a, float[] b, float[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Hypot(int n, float[] a, float[] b, float[] r)
            => vsHypot(n, a, b, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdHypot(int n, double[] a, double[] b, double[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Hypot(int n, double[] a, double[] b, double[] r)
            => vdHypot(n, a, b, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsHypot(int n, float[] a, float[] b, float[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Hypot(int n, float[] a, float[] b, float[] r, VmlMode mode)
            => vmsHypot(n, a, b, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdHypot(int n, double[] a, double[] b, double[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Hypot(int n, double[] a, double[] b, double[] r, VmlMode mode)
            => vmdHypot(n, a, b, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsErfc(int n, float[] a, float[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Erfc(int n, float[] a, float[] r)
            => vsErfc(n, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdErfc(int n, double[] a, double[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Erfc(int n, double[] a, double[] r)
            => vdErfc(n, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsErfc(int n, float[] a, float[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Erfc(int n, float[] a, float[] r, VmlMode mode)
            => vmsErfc(n, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdErfc(int n, double[] a, double[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Erfc(int n, double[] a, double[] r, VmlMode mode)
            => vmdErfc(n, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsErfcInv(int n, float[] a, float[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ErfcInv(int n, float[] a, float[] r)
            => vsErfcInv(n, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdErfcInv(int n, double[] a, double[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ErfcInv(int n, double[] a, double[] r)
            => vdErfcInv(n, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsErfcInv(int n, float[] a, float[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ErfcInv(int n, float[] a, float[] r, VmlMode mode)
            => vmsErfcInv(n, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdErfcInv(int n, double[] a, double[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ErfcInv(int n, double[] a, double[] r, VmlMode mode)
            => vmdErfcInv(n, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsCdfNorm(int n, float[] a, float[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CdfNorm(int n, float[] a, float[] r)
            => vsCdfNorm(n, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdCdfNorm(int n, double[] a, double[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CdfNorm(int n, double[] a, double[] r)
            => vdCdfNorm(n, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsCdfNorm(int n, float[] a, float[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CdfNorm(int n, float[] a, float[] r, VmlMode mode)
            => vmsCdfNorm(n, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdCdfNorm(int n, double[] a, double[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CdfNorm(int n, double[] a, double[] r, VmlMode mode)
            => vmdCdfNorm(n, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsCdfNormInv(int n, float[] a, float[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CdfNormInv(int n, float[] a, float[] r)
            => vsCdfNormInv(n, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdCdfNormInv(int n, double[] a, double[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CdfNormInv(int n, double[] a, double[] r)
            => vdCdfNormInv(n, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsCdfNormInv(int n, float[] a, float[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CdfNormInv(int n, float[] a, float[] r, VmlMode mode)
            => vmsCdfNormInv(n, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdCdfNormInv(int n, double[] a, double[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CdfNormInv(int n, double[] a, double[] r, VmlMode mode)
            => vmdCdfNormInv(n, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsLGamma(int n, float[] a, float[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void LGamma(int n, float[] a, float[] r)
            => vsLGamma(n, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdLGamma(int n, double[] a, double[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void LGamma(int n, double[] a, double[] r)
            => vdLGamma(n, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsLGamma(int n, float[] a, float[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void LGamma(int n, float[] a, float[] r, VmlMode mode)
            => vmsLGamma(n, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdLGamma(int n, double[] a, double[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void LGamma(int n, double[] a, double[] r, VmlMode mode)
            => vmdLGamma(n, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsTGamma(int n, float[] a, float[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void TGamma(int n, float[] a, float[] r)
            => vsTGamma(n, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdTGamma(int n, double[] a, double[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void TGamma(int n, double[] a, double[] r)
            => vdTGamma(n, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsTGamma(int n, float[] a, float[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void TGamma(int n, float[] a, float[] r, VmlMode mode)
            => vmsTGamma(n, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdTGamma(int n, double[] a, double[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void TGamma(int n, double[] a, double[] r, VmlMode mode)
            => vmdTGamma(n, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsAtan2(int n, float[] a, float[] b, float[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Atan2(int n, float[] a, float[] b, float[] r)
            => vsAtan2(n, a, b, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdAtan2(int n, double[] a, double[] b, double[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Atan2(int n, double[] a, double[] b, double[] r)
            => vdAtan2(n, a, b, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsAtan2(int n, float[] a, float[] b, float[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Atan2(int n, float[] a, float[] b, float[] r, VmlMode mode)
            => vmsAtan2(n, a, b, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdAtan2(int n, double[] a, double[] b, double[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Atan2(int n, double[] a, double[] b, double[] r, VmlMode mode)
            => vmdAtan2(n, a, b, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsAtan2pi(int n, float[] a, float[] b, float[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Atan2pi(int n, float[] a, float[] b, float[] r)
            => vsAtan2pi(n, a, b, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdAtan2pi(int n, double[] a, double[] b, double[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Atan2pi(int n, double[] a, double[] b, double[] r)
            => vdAtan2pi(n, a, b, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsAtan2pi(int n, float[] a, float[] b, float[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Atan2pi(int n, float[] a, float[] b, float[] r, VmlMode mode)
            => vmsAtan2pi(n, a, b, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdAtan2pi(int n, double[] a, double[] b, double[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Atan2pi(int n, double[] a, double[] b, double[] r, VmlMode mode)
            => vmdAtan2pi(n, a, b, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsMul(int n, float[] a, float[] b, float[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Mul(int n, float[] a, float[] b, float[] r)
            => vsMul(n, a, b, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdMul(int n, double[] a, double[] b, double[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Mul(int n, double[] a, double[] b, double[] r)
            => vdMul(n, a, b, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsMul(int n, float[] a, float[] b, float[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Mul(int n, float[] a, float[] b, float[] r, VmlMode mode)
            => vmsMul(n, a, b, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdMul(int n, double[] a, double[] b, double[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Mul(int n, double[] a, double[] b, double[] r, VmlMode mode)
            => vmdMul(n, a, b, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsDiv(int n, float[] a, float[] b, float[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Div(int n, float[] a, float[] b, float[] r)
            => vsDiv(n, a, b, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdDiv(int n, double[] a, double[] b, double[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Div(int n, double[] a, double[] b, double[] r)
            => vdDiv(n, a, b, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsDiv(int n, float[] a, float[] b, float[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Div(int n, float[] a, float[] b, float[] r, VmlMode mode)
            => vmsDiv(n, a, b, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdDiv(int n, double[] a, double[] b, double[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Div(int n, double[] a, double[] b, double[] r, VmlMode mode)
            => vmdDiv(n, a, b, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsPow(int n, float[] a, float[] b, float[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Pow(int n, float[] a, float[] b, float[] r)
            => vsPow(n, a, b, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdPow(int n, double[] a, double[] b, double[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Pow(int n, double[] a, double[] b, double[] r)
            => vdPow(n, a, b, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsPow(int n, float[] a, float[] b, float[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Pow(int n, float[] a, float[] b, float[] r, VmlMode mode)
            => vmsPow(n, a, b, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdPow(int n, double[] a, double[] b, double[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Pow(int n, double[] a, double[] b, double[] r, VmlMode mode)
            => vmdPow(n, a, b, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsPow3o2(int n, float[] a, float[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Pow3o2(int n, float[] a, float[] r)
            => vsPow3o2(n, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdPow3o2(int n, double[] a, double[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Pow3o2(int n, double[] a, double[] r)
            => vdPow3o2(n, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsPow3o2(int n, float[] a, float[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Pow3o2(int n, float[] a, float[] r, VmlMode mode)
            => vmsPow3o2(n, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdPow3o2(int n, double[] a, double[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Pow3o2(int n, double[] a, double[] r, VmlMode mode)
            => vmdPow3o2(n, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsPow2o3(int n, float[] a, float[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Pow2o3(int n, float[] a, float[] r)
            => vsPow2o3(n, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdPow2o3(int n, double[] a, double[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Pow2o3(int n, double[] a, double[] r)
            => vdPow2o3(n, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsPow2o3(int n, float[] a, float[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Pow2o3(int n, float[] a, float[] r, VmlMode mode)
            => vmsPow2o3(n, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdPow2o3(int n, double[] a, double[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Pow2o3(int n, double[] a, double[] r, VmlMode mode)
            => vmdPow2o3(n, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsPowx(int n, float[] a, float b, float[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Powx(int n, float[] a, float b, float[] r)
            => vsPowx(n, a, b, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdPowx(int n, double[] a, double b, double[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Powx(int n, double[] a, double b, double[] r)
            => vdPowx(n, a, b, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsPowx(int n, float[] a, float b, float[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Powx(int n, float[] a, float b, float[] r, VmlMode mode)
            => vmsPowx(n, a, b, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdPowx(int n, double[] a, double b, double[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Powx(int n, double[] a, double b, double[] r, VmlMode mode)
            => vmdPowx(n, a, b, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsPowr(int n, float[] a, float[] b, float[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Powr(int n, float[] a, float[] b, float[] r)
            => vsPowr(n, a, b, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdPowr(int n, double[] a, double[] b, double[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Powr(int n, double[] a, double[] b, double[] r)
            => vdPowr(n, a, b, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsPowr(int n, float[] a, float[] b, float[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Powr(int n, float[] a, float[] b, float[] r, VmlMode mode)
            => vmsPowr(n, a, b, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdPowr(int n, double[] a, double[] b, double[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Powr(int n, double[] a, double[] b, double[] r, VmlMode mode)
            => vmdPowr(n, a, b, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsSinCos(int n, float[] a, float[] r1, float[] r2);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SinCos(int n, float[] a, float[] r1, float[] r2)
            => vsSinCos(n, a, r1, r2);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdSinCos(int n, double[] a, double[] r1, double[] r2);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SinCos(int n, double[] a, double[] r1, double[] r2)
            => vdSinCos(n, a, r1, r2);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsSinCos(int n, float[] a, float[] r1, float[] r2, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SinCos(int n, float[] a, float[] r1, float[] r2, VmlMode mode)
            => vmsSinCos(n, a, r1, r2, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdSinCos(int n, double[] a, double[] r1, double[] r2, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SinCos(int n, double[] a, double[] r1, double[] r2, VmlMode mode)
            => vmdSinCos(n, a, r1, r2, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsLinearFrac(int n, float[] a, float[] b, float scalea, float shifta, float scaleb, float shiftb, float[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void LinearFrac(int n, float[] a, float[] b, float scalea, float shifta, float scaleb, float shiftb, float[] r)
            => vsLinearFrac(n, a, b, scalea, shifta, scaleb, shiftb, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdLinearFrac(int n, double[] a, double[] b, double scalea, double shifta, double scaleb, double shiftb, double[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void LinearFrac(int n, double[] a, double[] b, double scalea, double shifta, double scaleb, double shiftb, double[] r)
            => vdLinearFrac(n, a, b, scalea, shifta, scaleb, shiftb, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsLinearFrac(int n, float[] a, float[] b, float scalea, float shifta, float scaleb, float shiftb, float[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void LinearFrac(int n, float[] a, float[] b, float scalea, float shifta, float scaleb, float shiftb, float[] r, VmlMode mode)
            => vmsLinearFrac(n, a, b, scalea, shifta, scaleb, shiftb, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdLinearFrac(int n, double[] a, double[] b, double scalea, double shifta, double scaleb, double shiftb, double[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void LinearFrac(int n, double[] a, double[] b, double scalea, double shifta, double scaleb, double shiftb, double[] r, VmlMode mode)
            => vmdLinearFrac(n, a, b, scalea, shifta, scaleb, shiftb, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsCeil(int n, float[] a, float[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Ceil(int n, float[] a, float[] r)
            => vsCeil(n, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdCeil(int n, double[] a, double[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Ceil(int n, double[] a, double[] r)
            => vdCeil(n, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsCeil(int n, float[] a, float[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Ceil(int n, float[] a, float[] r, VmlMode mode)
            => vmsCeil(n, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdCeil(int n, double[] a, double[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Ceil(int n, double[] a, double[] r, VmlMode mode)
            => vmdCeil(n, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsFloor(int n, float[] a, float[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Floor(int n, float[] a, float[] r)
            => vsFloor(n, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdFloor(int n, double[] a, double[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Floor(int n, double[] a, double[] r)
            => vdFloor(n, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsFloor(int n, float[] a, float[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Floor(int n, float[] a, float[] r, VmlMode mode)
            => vmsFloor(n, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdFloor(int n, double[] a, double[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Floor(int n, double[] a, double[] r, VmlMode mode)
            => vmdFloor(n, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsFrac(int n, float[] a, float[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Frac(int n, float[] a, float[] r)
            => vsFrac(n, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdFrac(int n, double[] a, double[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Frac(int n, double[] a, double[] r)
            => vdFrac(n, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsFrac(int n, float[] a, float[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Frac(int n, float[] a, float[] r, VmlMode mode)
            => vmsFrac(n, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdFrac(int n, double[] a, double[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Frac(int n, double[] a, double[] r, VmlMode mode)
            => vmdFrac(n, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsModf(int n, float[] a, float[] r1, float[] r2);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Modf(int n, float[] a, float[] r1, float[] r2)
            => vsModf(n, a, r1, r2);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdModf(int n, double[] a, double[] r1, double[] r2);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Modf(int n, double[] a, double[] r1, double[] r2)
            => vdModf(n, a, r1, r2);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsModf(int n, float[] a, float[] r1, float[] r2, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Modf(int n, float[] a, float[] r1, float[] r2, VmlMode mode)
            => vmsModf(n, a, r1, r2, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdModf(int n, double[] a, double[] r1, double[] r2, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Modf(int n, double[] a, double[] r1, double[] r2, VmlMode mode)
            => vmdModf(n, a, r1, r2, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsFmod(int n, float[] a, float[] b, float[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Fmod(int n, float[] a, float[] b, float[] r)
            => vsFmod(n, a, b, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdFmod(int n, double[] a, double[] b, double[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Fmod(int n, double[] a, double[] b, double[] r)
            => vdFmod(n, a, b, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsFmod(int n, float[] a, float[] b, float[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Fmod(int n, float[] a, float[] b, float[] r, VmlMode mode)
            => vmsFmod(n, a, b, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdFmod(int n, double[] a, double[] b, double[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Fmod(int n, double[] a, double[] b, double[] r, VmlMode mode)
            => vmdFmod(n, a, b, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsRemainder(int n, float[] a, float[] b, float[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Remainder(int n, float[] a, float[] b, float[] r)
            => vsRemainder(n, a, b, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdRemainder(int n, double[] a, double[] b, double[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Remainder(int n, double[] a, double[] b, double[] r)
            => vdRemainder(n, a, b, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsRemainder(int n, float[] a, float[] b, float[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Remainder(int n, float[] a, float[] b, float[] r, VmlMode mode)
            => vmsRemainder(n, a, b, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdRemainder(int n, double[] a, double[] b, double[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Remainder(int n, double[] a, double[] b, double[] r, VmlMode mode)
            => vmdRemainder(n, a, b, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsNextAfter(int n, float[] a, float[] b, float[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void NextAfter(int n, float[] a, float[] b, float[] r)
            => vsNextAfter(n, a, b, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdNextAfter(int n, double[] a, double[] b, double[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void NextAfter(int n, double[] a, double[] b, double[] r)
            => vdNextAfter(n, a, b, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsNextAfter(int n, float[] a, float[] b, float[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void NextAfter(int n, float[] a, float[] b, float[] r, VmlMode mode)
            => vmsNextAfter(n, a, b, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdNextAfter(int n, double[] a, double[] b, double[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void NextAfter(int n, double[] a, double[] b, double[] r, VmlMode mode)
            => vmdNextAfter(n, a, b, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsCopySign(int n, float[] a, float[] b, float[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CopySign(int n, float[] a, float[] b, float[] r)
            => vsCopySign(n, a, b, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdCopySign(int n, double[] a, double[] b, double[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CopySign(int n, double[] a, double[] b, double[] r)
            => vdCopySign(n, a, b, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsCopySign(int n, float[] a, float[] b, float[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CopySign(int n, float[] a, float[] b, float[] r, VmlMode mode)
            => vmsCopySign(n, a, b, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdCopySign(int n, double[] a, double[] b, double[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CopySign(int n, double[] a, double[] b, double[] r, VmlMode mode)
            => vmdCopySign(n, a, b, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsFdim(int n, float[] a, float[] b, float[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Fdim(int n, float[] a, float[] b, float[] r)
            => vsFdim(n, a, b, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdFdim(int n, double[] a, double[] b, double[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Fdim(int n, double[] a, double[] b, double[] r)
            => vdFdim(n, a, b, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsFdim(int n, float[] a, float[] b, float[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Fdim(int n, float[] a, float[] b, float[] r, VmlMode mode)
            => vmsFdim(n, a, b, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdFdim(int n, double[] a, double[] b, double[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Fdim(int n, double[] a, double[] b, double[] r, VmlMode mode)
            => vmdFdim(n, a, b, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsFmax(int n, float[] a, float[] b, float[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Fmax(int n, float[] a, float[] b, float[] r)
            => vsFmax(n, a, b, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdFmax(int n, double[] a, double[] b, double[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Fmax(int n, double[] a, double[] b, double[] r)
            => vdFmax(n, a, b, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsFmax(int n, float[] a, float[] b, float[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Fmax(int n, float[] a, float[] b, float[] r, VmlMode mode)
            => vmsFmax(n, a, b, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdFmax(int n, double[] a, double[] b, double[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Fmax(int n, double[] a, double[] b, double[] r, VmlMode mode)
            => vmdFmax(n, a, b, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsFmin(int n, float[] a, float[] b, float[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Fmin(int n, float[] a, float[] b, float[] r)
            => vsFmin(n, a, b, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdFmin(int n, double[] a, double[] b, double[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Fmin(int n, double[] a, double[] b, double[] r)
            => vdFmin(n, a, b, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsFmin(int n, float[] a, float[] b, float[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Fmin(int n, float[] a, float[] b, float[] r, VmlMode mode)
            => vmsFmin(n, a, b, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdFmin(int n, double[] a, double[] b, double[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Fmin(int n, double[] a, double[] b, double[] r, VmlMode mode)
            => vmdFmin(n, a, b, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsMaxMag(int n, float[] a, float[] b, float[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void MaxMag(int n, float[] a, float[] b, float[] r)
            => vsMaxMag(n, a, b, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdMaxMag(int n, double[] a, double[] b, double[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void MaxMag(int n, double[] a, double[] b, double[] r)
            => vdMaxMag(n, a, b, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsMaxMag(int n, float[] a, float[] b, float[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void MaxMag(int n, float[] a, float[] b, float[] r, VmlMode mode)
            => vmsMaxMag(n, a, b, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdMaxMag(int n, double[] a, double[] b, double[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void MaxMag(int n, double[] a, double[] b, double[] r, VmlMode mode)
            => vmdMaxMag(n, a, b, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsMinMag(int n, float[] a, float[] b, float[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void MinMag(int n, float[] a, float[] b, float[] r)
            => vsMinMag(n, a, b, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdMinMag(int n, double[] a, double[] b, double[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void MinMag(int n, double[] a, double[] b, double[] r)
            => vdMinMag(n, a, b, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsMinMag(int n, float[] a, float[] b, float[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void MinMag(int n, float[] a, float[] b, float[] r, VmlMode mode)
            => vmsMinMag(n, a, b, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdMinMag(int n, double[] a, double[] b, double[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void MinMag(int n, double[] a, double[] b, double[] r, VmlMode mode)
            => vmdMinMag(n, a, b, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsNearbyInt(int n, float[] a, float[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void NearbyInt(int n, float[] a, float[] r)
            => vsNearbyInt(n, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdNearbyInt(int n, double[] a, double[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void NearbyInt(int n, double[] a, double[] r)
            => vdNearbyInt(n, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsNearbyInt(int n, float[] a, float[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void NearbyInt(int n, float[] a, float[] r, VmlMode mode)
            => vmsNearbyInt(n, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdNearbyInt(int n, double[] a, double[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void NearbyInt(int n, double[] a, double[] r, VmlMode mode)
            => vmdNearbyInt(n, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsRint(int n, float[] a, float[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Rint(int n, float[] a, float[] r)
            => vsRint(n, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdRint(int n, double[] a, double[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Rint(int n, double[] a, double[] r)
            => vdRint(n, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsRint(int n, float[] a, float[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Rint(int n, float[] a, float[] r, VmlMode mode)
            => vmsRint(n, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdRint(int n, double[] a, double[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Rint(int n, double[] a, double[] r, VmlMode mode)
            => vmdRint(n, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsRound(int n, float[] a, float[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Round(int n, float[] a, float[] r)
            => vsRound(n, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdRound(int n, double[] a, double[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Round(int n, double[] a, double[] r)
            => vdRound(n, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsRound(int n, float[] a, float[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Round(int n, float[] a, float[] r, VmlMode mode)
            => vmsRound(n, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdRound(int n, double[] a, double[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Round(int n, double[] a, double[] r, VmlMode mode)
            => vmdRound(n, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsTrunc(int n, float[] a, float[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Trunc(int n, float[] a, float[] r)
            => vsTrunc(n, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdTrunc(int n, double[] a, double[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Trunc(int n, double[] a, double[] r)
            => vdTrunc(n, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsTrunc(int n, float[] a, float[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Trunc(int n, float[] a, float[] r, VmlMode mode)
            => vmsTrunc(n, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdTrunc(int n, double[] a, double[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Trunc(int n, double[] a, double[] r, VmlMode mode)
            => vmdTrunc(n, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsExpInt1(int n, float[] a, float[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ExpInt1(int n, float[] a, float[] r)
            => vsExpInt1(n, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdExpInt1(int n, double[] a, double[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ExpInt1(int n, double[] a, double[] r)
            => vdExpInt1(n, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsExpInt1(int n, float[] a, float[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ExpInt1(int n, float[] a, float[] r, VmlMode mode)
            => vmsExpInt1(n, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdExpInt1(int n, double[] a, double[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ExpInt1(int n, double[] a, double[] r, VmlMode mode)
            => vmdExpInt1(n, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsAbsI(int n, float[] a, int inca, float[] r, int incr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void AbsI(int n, float[] a, int inca, float[] r, int incr)
            => vsAbsI(n, a, inca, r, incr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdAbsI(int n, double[] a, int inca, double[] r, int incr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void AbsI(int n, double[] a, int inca, double[] r, int incr)
            => vdAbsI(n, a, inca, r, incr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsAbsI(int n, float[] a, int inca, float[] r, int incr, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void AbsI(int n, float[] a, int inca, float[] r, int incr, VmlMode mode)
            => vmsAbsI(n, a, inca, r, incr, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdAbsI(int n, double[] a, int inca, double[] r, int incr, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void AbsI(int n, double[] a, int inca, double[] r, int incr, VmlMode mode)
            => vmdAbsI(n, a, inca, r, incr, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsAddI(int n, float[] a, int inca, float[] b, int incb, float[] r, int incr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void AddI(int n, float[] a, int inca, float[] b, int incb, float[] r, int incr)
            => vsAddI(n, a, inca, b, incb, r, incr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdAddI(int n, double[] a, int inca, double[] b, int incb, double[] r, int incr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void AddI(int n, double[] a, int inca, double[] b, int incb, double[] r, int incr)
            => vdAddI(n, a, inca, b, incb, r, incr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsAddI(int n, float[] a, int inca, float[] b, int incb, float[] r, int incr, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void AddI(int n, float[] a, int inca, float[] b, int incb, float[] r, int incr, VmlMode mode)
            => vmsAddI(n, a, inca, b, incb, r, incr, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdAddI(int n, double[] a, int inca, double[] b, int incb, double[] r, int incr, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void AddI(int n, double[] a, int inca, double[] b, int incb, double[] r, int incr, VmlMode mode)
            => vmdAddI(n, a, inca, b, incb, r, incr, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsSubI(int n, float[] a, int inca, float[] b, int incb, float[] r, int incr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SubI(int n, float[] a, int inca, float[] b, int incb, float[] r, int incr)
            => vsSubI(n, a, inca, b, incb, r, incr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdSubI(int n, double[] a, int inca, double[] b, int incb, double[] r, int incr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SubI(int n, double[] a, int inca, double[] b, int incb, double[] r, int incr)
            => vdSubI(n, a, inca, b, incb, r, incr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsSubI(int n, float[] a, int inca, float[] b, int incb, float[] r, int incr, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SubI(int n, float[] a, int inca, float[] b, int incb, float[] r, int incr, VmlMode mode)
            => vmsSubI(n, a, inca, b, incb, r, incr, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdSubI(int n, double[] a, int inca, double[] b, int incb, double[] r, int incr, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SubI(int n, double[] a, int inca, double[] b, int incb, double[] r, int incr, VmlMode mode)
            => vmdSubI(n, a, inca, b, incb, r, incr, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsInvI(int n, float[] a, int inca, float[] r, int incr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void InvI(int n, float[] a, int inca, float[] r, int incr)
            => vsInvI(n, a, inca, r, incr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdInvI(int n, double[] a, int inca, double[] r, int incr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void InvI(int n, double[] a, int inca, double[] r, int incr)
            => vdInvI(n, a, inca, r, incr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsInvI(int n, float[] a, int inca, float[] r, int incr, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void InvI(int n, float[] a, int inca, float[] r, int incr, VmlMode mode)
            => vmsInvI(n, a, inca, r, incr, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdInvI(int n, double[] a, int inca, double[] r, int incr, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void InvI(int n, double[] a, int inca, double[] r, int incr, VmlMode mode)
            => vmdInvI(n, a, inca, r, incr, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsSqrtI(int n, float[] a, int inca, float[] r, int incr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SqrtI(int n, float[] a, int inca, float[] r, int incr)
            => vsSqrtI(n, a, inca, r, incr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdSqrtI(int n, double[] a, int inca, double[] r, int incr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SqrtI(int n, double[] a, int inca, double[] r, int incr)
            => vdSqrtI(n, a, inca, r, incr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsSqrtI(int n, float[] a, int inca, float[] r, int incr, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SqrtI(int n, float[] a, int inca, float[] r, int incr, VmlMode mode)
            => vmsSqrtI(n, a, inca, r, incr, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdSqrtI(int n, double[] a, int inca, double[] r, int incr, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SqrtI(int n, double[] a, int inca, double[] r, int incr, VmlMode mode)
            => vmdSqrtI(n, a, inca, r, incr, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsInvSqrtI(int n, float[] a, int inca, float[] r, int incr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void InvSqrtI(int n, float[] a, int inca, float[] r, int incr)
            => vsInvSqrtI(n, a, inca, r, incr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdInvSqrtI(int n, double[] a, int inca, double[] r, int incr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void InvSqrtI(int n, double[] a, int inca, double[] r, int incr)
            => vdInvSqrtI(n, a, inca, r, incr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsInvSqrtI(int n, float[] a, int inca, float[] r, int incr, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void InvSqrtI(int n, float[] a, int inca, float[] r, int incr, VmlMode mode)
            => vmsInvSqrtI(n, a, inca, r, incr, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdInvSqrtI(int n, double[] a, int inca, double[] r, int incr, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void InvSqrtI(int n, double[] a, int inca, double[] r, int incr, VmlMode mode)
            => vmdInvSqrtI(n, a, inca, r, incr, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsCbrtI(int n, float[] a, int inca, float[] r, int incr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CbrtI(int n, float[] a, int inca, float[] r, int incr)
            => vsCbrtI(n, a, inca, r, incr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdCbrtI(int n, double[] a, int inca, double[] r, int incr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CbrtI(int n, double[] a, int inca, double[] r, int incr)
            => vdCbrtI(n, a, inca, r, incr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsCbrtI(int n, float[] a, int inca, float[] r, int incr, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CbrtI(int n, float[] a, int inca, float[] r, int incr, VmlMode mode)
            => vmsCbrtI(n, a, inca, r, incr, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdCbrtI(int n, double[] a, int inca, double[] r, int incr, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CbrtI(int n, double[] a, int inca, double[] r, int incr, VmlMode mode)
            => vmdCbrtI(n, a, inca, r, incr, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsInvCbrtI(int n, float[] a, int inca, float[] r, int incr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void InvCbrtI(int n, float[] a, int inca, float[] r, int incr)
            => vsInvCbrtI(n, a, inca, r, incr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdInvCbrtI(int n, double[] a, int inca, double[] r, int incr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void InvCbrtI(int n, double[] a, int inca, double[] r, int incr)
            => vdInvCbrtI(n, a, inca, r, incr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsInvCbrtI(int n, float[] a, int inca, float[] r, int incr, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void InvCbrtI(int n, float[] a, int inca, float[] r, int incr, VmlMode mode)
            => vmsInvCbrtI(n, a, inca, r, incr, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdInvCbrtI(int n, double[] a, int inca, double[] r, int incr, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void InvCbrtI(int n, double[] a, int inca, double[] r, int incr, VmlMode mode)
            => vmdInvCbrtI(n, a, inca, r, incr, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsSqrI(int n, float[] a, int inca, float[] r, int incr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SqrI(int n, float[] a, int inca, float[] r, int incr)
            => vsSqrI(n, a, inca, r, incr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdSqrI(int n, double[] a, int inca, double[] r, int incr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SqrI(int n, double[] a, int inca, double[] r, int incr)
            => vdSqrI(n, a, inca, r, incr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsSqrI(int n, float[] a, int inca, float[] r, int incr, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SqrI(int n, float[] a, int inca, float[] r, int incr, VmlMode mode)
            => vmsSqrI(n, a, inca, r, incr, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdSqrI(int n, double[] a, int inca, double[] r, int incr, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SqrI(int n, double[] a, int inca, double[] r, int incr, VmlMode mode)
            => vmdSqrI(n, a, inca, r, incr, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsExpI(int n, float[] a, int inca, float[] r, int incr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ExpI(int n, float[] a, int inca, float[] r, int incr)
            => vsExpI(n, a, inca, r, incr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdExpI(int n, double[] a, int inca, double[] r, int incr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ExpI(int n, double[] a, int inca, double[] r, int incr)
            => vdExpI(n, a, inca, r, incr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsExpI(int n, float[] a, int inca, float[] r, int incr, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ExpI(int n, float[] a, int inca, float[] r, int incr, VmlMode mode)
            => vmsExpI(n, a, inca, r, incr, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdExpI(int n, double[] a, int inca, double[] r, int incr, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ExpI(int n, double[] a, int inca, double[] r, int incr, VmlMode mode)
            => vmdExpI(n, a, inca, r, incr, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsExp2I(int n, float[] a, int inca, float[] r, int incr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Exp2I(int n, float[] a, int inca, float[] r, int incr)
            => vsExp2I(n, a, inca, r, incr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdExp2I(int n, double[] a, int inca, double[] r, int incr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Exp2I(int n, double[] a, int inca, double[] r, int incr)
            => vdExp2I(n, a, inca, r, incr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsExp2I(int n, float[] a, int inca, float[] r, int incr, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Exp2I(int n, float[] a, int inca, float[] r, int incr, VmlMode mode)
            => vmsExp2I(n, a, inca, r, incr, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdExp2I(int n, double[] a, int inca, double[] r, int incr, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Exp2I(int n, double[] a, int inca, double[] r, int incr, VmlMode mode)
            => vmdExp2I(n, a, inca, r, incr, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsExp10I(int n, float[] a, int inca, float[] r, int incr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Exp10I(int n, float[] a, int inca, float[] r, int incr)
            => vsExp10I(n, a, inca, r, incr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdExp10I(int n, double[] a, int inca, double[] r, int incr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Exp10I(int n, double[] a, int inca, double[] r, int incr)
            => vdExp10I(n, a, inca, r, incr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsExp10I(int n, float[] a, int inca, float[] r, int incr, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Exp10I(int n, float[] a, int inca, float[] r, int incr, VmlMode mode)
            => vmsExp10I(n, a, inca, r, incr, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdExp10I(int n, double[] a, int inca, double[] r, int incr, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Exp10I(int n, double[] a, int inca, double[] r, int incr, VmlMode mode)
            => vmdExp10I(n, a, inca, r, incr, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsExpm1I(int n, float[] a, int inca, float[] r, int incr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Expm1I(int n, float[] a, int inca, float[] r, int incr)
            => vsExpm1I(n, a, inca, r, incr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdExpm1I(int n, double[] a, int inca, double[] r, int incr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Expm1I(int n, double[] a, int inca, double[] r, int incr)
            => vdExpm1I(n, a, inca, r, incr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsExpm1I(int n, float[] a, int inca, float[] r, int incr, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Expm1I(int n, float[] a, int inca, float[] r, int incr, VmlMode mode)
            => vmsExpm1I(n, a, inca, r, incr, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdExpm1I(int n, double[] a, int inca, double[] r, int incr, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Expm1I(int n, double[] a, int inca, double[] r, int incr, VmlMode mode)
            => vmdExpm1I(n, a, inca, r, incr, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsLnI(int n, float[] a, int inca, float[] r, int incr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void LnI(int n, float[] a, int inca, float[] r, int incr)
            => vsLnI(n, a, inca, r, incr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdLnI(int n, double[] a, int inca, double[] r, int incr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void LnI(int n, double[] a, int inca, double[] r, int incr)
            => vdLnI(n, a, inca, r, incr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsLnI(int n, float[] a, int inca, float[] r, int incr, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void LnI(int n, float[] a, int inca, float[] r, int incr, VmlMode mode)
            => vmsLnI(n, a, inca, r, incr, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdLnI(int n, double[] a, int inca, double[] r, int incr, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void LnI(int n, double[] a, int inca, double[] r, int incr, VmlMode mode)
            => vmdLnI(n, a, inca, r, incr, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsLog10I(int n, float[] a, int inca, float[] r, int incr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Log10I(int n, float[] a, int inca, float[] r, int incr)
            => vsLog10I(n, a, inca, r, incr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdLog10I(int n, double[] a, int inca, double[] r, int incr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Log10I(int n, double[] a, int inca, double[] r, int incr)
            => vdLog10I(n, a, inca, r, incr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsLog10I(int n, float[] a, int inca, float[] r, int incr, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Log10I(int n, float[] a, int inca, float[] r, int incr, VmlMode mode)
            => vmsLog10I(n, a, inca, r, incr, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdLog10I(int n, double[] a, int inca, double[] r, int incr, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Log10I(int n, double[] a, int inca, double[] r, int incr, VmlMode mode)
            => vmdLog10I(n, a, inca, r, incr, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsLog2I(int n, float[] a, int inca, float[] r, int incr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Log2I(int n, float[] a, int inca, float[] r, int incr)
            => vsLog2I(n, a, inca, r, incr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdLog2I(int n, double[] a, int inca, double[] r, int incr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Log2I(int n, double[] a, int inca, double[] r, int incr)
            => vdLog2I(n, a, inca, r, incr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsLog2I(int n, float[] a, int inca, float[] r, int incr, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Log2I(int n, float[] a, int inca, float[] r, int incr, VmlMode mode)
            => vmsLog2I(n, a, inca, r, incr, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdLog2I(int n, double[] a, int inca, double[] r, int incr, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Log2I(int n, double[] a, int inca, double[] r, int incr, VmlMode mode)
            => vmdLog2I(n, a, inca, r, incr, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsLog1pI(int n, float[] a, int inca, float[] r, int incr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Log1pI(int n, float[] a, int inca, float[] r, int incr)
            => vsLog1pI(n, a, inca, r, incr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdLog1pI(int n, double[] a, int inca, double[] r, int incr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Log1pI(int n, double[] a, int inca, double[] r, int incr)
            => vdLog1pI(n, a, inca, r, incr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsLog1pI(int n, float[] a, int inca, float[] r, int incr, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Log1pI(int n, float[] a, int inca, float[] r, int incr, VmlMode mode)
            => vmsLog1pI(n, a, inca, r, incr, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdLog1pI(int n, double[] a, int inca, double[] r, int incr, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Log1pI(int n, double[] a, int inca, double[] r, int incr, VmlMode mode)
            => vmdLog1pI(n, a, inca, r, incr, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsLogbI(int n, float[] a, int inca, float[] r, int incr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void LogbI(int n, float[] a, int inca, float[] r, int incr)
            => vsLogbI(n, a, inca, r, incr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdLogbI(int n, double[] a, int inca, double[] r, int incr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void LogbI(int n, double[] a, int inca, double[] r, int incr)
            => vdLogbI(n, a, inca, r, incr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsLogbI(int n, float[] a, int inca, float[] r, int incr, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void LogbI(int n, float[] a, int inca, float[] r, int incr, VmlMode mode)
            => vmsLogbI(n, a, inca, r, incr, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdLogbI(int n, double[] a, int inca, double[] r, int incr, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void LogbI(int n, double[] a, int inca, double[] r, int incr, VmlMode mode)
            => vmdLogbI(n, a, inca, r, incr, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsCosI(int n, float[] a, int inca, float[] r, int incr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CosI(int n, float[] a, int inca, float[] r, int incr)
            => vsCosI(n, a, inca, r, incr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdCosI(int n, double[] a, int inca, double[] r, int incr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CosI(int n, double[] a, int inca, double[] r, int incr)
            => vdCosI(n, a, inca, r, incr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsCosI(int n, float[] a, int inca, float[] r, int incr, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CosI(int n, float[] a, int inca, float[] r, int incr, VmlMode mode)
            => vmsCosI(n, a, inca, r, incr, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdCosI(int n, double[] a, int inca, double[] r, int incr, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CosI(int n, double[] a, int inca, double[] r, int incr, VmlMode mode)
            => vmdCosI(n, a, inca, r, incr, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsSinI(int n, float[] a, int inca, float[] r, int incr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SinI(int n, float[] a, int inca, float[] r, int incr)
            => vsSinI(n, a, inca, r, incr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdSinI(int n, double[] a, int inca, double[] r, int incr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SinI(int n, double[] a, int inca, double[] r, int incr)
            => vdSinI(n, a, inca, r, incr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsSinI(int n, float[] a, int inca, float[] r, int incr, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SinI(int n, float[] a, int inca, float[] r, int incr, VmlMode mode)
            => vmsSinI(n, a, inca, r, incr, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdSinI(int n, double[] a, int inca, double[] r, int incr, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SinI(int n, double[] a, int inca, double[] r, int incr, VmlMode mode)
            => vmdSinI(n, a, inca, r, incr, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsTanI(int n, float[] a, int inca, float[] r, int incr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void TanI(int n, float[] a, int inca, float[] r, int incr)
            => vsTanI(n, a, inca, r, incr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdTanI(int n, double[] a, int inca, double[] r, int incr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void TanI(int n, double[] a, int inca, double[] r, int incr)
            => vdTanI(n, a, inca, r, incr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsTanI(int n, float[] a, int inca, float[] r, int incr, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void TanI(int n, float[] a, int inca, float[] r, int incr, VmlMode mode)
            => vmsTanI(n, a, inca, r, incr, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdTanI(int n, double[] a, int inca, double[] r, int incr, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void TanI(int n, double[] a, int inca, double[] r, int incr, VmlMode mode)
            => vmdTanI(n, a, inca, r, incr, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsCoshI(int n, float[] a, int inca, float[] r, int incr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CoshI(int n, float[] a, int inca, float[] r, int incr)
            => vsCoshI(n, a, inca, r, incr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdCoshI(int n, double[] a, int inca, double[] r, int incr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CoshI(int n, double[] a, int inca, double[] r, int incr)
            => vdCoshI(n, a, inca, r, incr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsCoshI(int n, float[] a, int inca, float[] r, int incr, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CoshI(int n, float[] a, int inca, float[] r, int incr, VmlMode mode)
            => vmsCoshI(n, a, inca, r, incr, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdCoshI(int n, double[] a, int inca, double[] r, int incr, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CoshI(int n, double[] a, int inca, double[] r, int incr, VmlMode mode)
            => vmdCoshI(n, a, inca, r, incr, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsCosdI(int n, float[] a, int inca, float[] r, int incr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CosdI(int n, float[] a, int inca, float[] r, int incr)
            => vsCosdI(n, a, inca, r, incr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdCosdI(int n, double[] a, int inca, double[] r, int incr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CosdI(int n, double[] a, int inca, double[] r, int incr)
            => vdCosdI(n, a, inca, r, incr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsCosdI(int n, float[] a, int inca, float[] r, int incr, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CosdI(int n, float[] a, int inca, float[] r, int incr, VmlMode mode)
            => vmsCosdI(n, a, inca, r, incr, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdCosdI(int n, double[] a, int inca, double[] r, int incr, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CosdI(int n, double[] a, int inca, double[] r, int incr, VmlMode mode)
            => vmdCosdI(n, a, inca, r, incr, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsCospiI(int n, float[] a, int inca, float[] r, int incr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CospiI(int n, float[] a, int inca, float[] r, int incr)
            => vsCospiI(n, a, inca, r, incr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdCospiI(int n, double[] a, int inca, double[] r, int incr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CospiI(int n, double[] a, int inca, double[] r, int incr)
            => vdCospiI(n, a, inca, r, incr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsCospiI(int n, float[] a, int inca, float[] r, int incr, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CospiI(int n, float[] a, int inca, float[] r, int incr, VmlMode mode)
            => vmsCospiI(n, a, inca, r, incr, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdCospiI(int n, double[] a, int inca, double[] r, int incr, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CospiI(int n, double[] a, int inca, double[] r, int incr, VmlMode mode)
            => vmdCospiI(n, a, inca, r, incr, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsSinhI(int n, float[] a, int inca, float[] r, int incr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SinhI(int n, float[] a, int inca, float[] r, int incr)
            => vsSinhI(n, a, inca, r, incr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdSinhI(int n, double[] a, int inca, double[] r, int incr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SinhI(int n, double[] a, int inca, double[] r, int incr)
            => vdSinhI(n, a, inca, r, incr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsSinhI(int n, float[] a, int inca, float[] r, int incr, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SinhI(int n, float[] a, int inca, float[] r, int incr, VmlMode mode)
            => vmsSinhI(n, a, inca, r, incr, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdSinhI(int n, double[] a, int inca, double[] r, int incr, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SinhI(int n, double[] a, int inca, double[] r, int incr, VmlMode mode)
            => vmdSinhI(n, a, inca, r, incr, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsSindI(int n, float[] a, int inca, float[] r, int incr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SindI(int n, float[] a, int inca, float[] r, int incr)
            => vsSindI(n, a, inca, r, incr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdSindI(int n, double[] a, int inca, double[] r, int incr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SindI(int n, double[] a, int inca, double[] r, int incr)
            => vdSindI(n, a, inca, r, incr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsSindI(int n, float[] a, int inca, float[] r, int incr, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SindI(int n, float[] a, int inca, float[] r, int incr, VmlMode mode)
            => vmsSindI(n, a, inca, r, incr, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdSindI(int n, double[] a, int inca, double[] r, int incr, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SindI(int n, double[] a, int inca, double[] r, int incr, VmlMode mode)
            => vmdSindI(n, a, inca, r, incr, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsSinpiI(int n, float[] a, int inca, float[] r, int incr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SinpiI(int n, float[] a, int inca, float[] r, int incr)
            => vsSinpiI(n, a, inca, r, incr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdSinpiI(int n, double[] a, int inca, double[] r, int incr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SinpiI(int n, double[] a, int inca, double[] r, int incr)
            => vdSinpiI(n, a, inca, r, incr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsSinpiI(int n, float[] a, int inca, float[] r, int incr, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SinpiI(int n, float[] a, int inca, float[] r, int incr, VmlMode mode)
            => vmsSinpiI(n, a, inca, r, incr, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdSinpiI(int n, double[] a, int inca, double[] r, int incr, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SinpiI(int n, double[] a, int inca, double[] r, int incr, VmlMode mode)
            => vmdSinpiI(n, a, inca, r, incr, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsTanhI(int n, float[] a, int inca, float[] r, int incr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void TanhI(int n, float[] a, int inca, float[] r, int incr)
            => vsTanhI(n, a, inca, r, incr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdTanhI(int n, double[] a, int inca, double[] r, int incr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void TanhI(int n, double[] a, int inca, double[] r, int incr)
            => vdTanhI(n, a, inca, r, incr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsTanhI(int n, float[] a, int inca, float[] r, int incr, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void TanhI(int n, float[] a, int inca, float[] r, int incr, VmlMode mode)
            => vmsTanhI(n, a, inca, r, incr, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdTanhI(int n, double[] a, int inca, double[] r, int incr, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void TanhI(int n, double[] a, int inca, double[] r, int incr, VmlMode mode)
            => vmdTanhI(n, a, inca, r, incr, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsTandI(int n, float[] a, int inca, float[] r, int incr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void TandI(int n, float[] a, int inca, float[] r, int incr)
            => vsTandI(n, a, inca, r, incr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdTandI(int n, double[] a, int inca, double[] r, int incr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void TandI(int n, double[] a, int inca, double[] r, int incr)
            => vdTandI(n, a, inca, r, incr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsTandI(int n, float[] a, int inca, float[] r, int incr, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void TandI(int n, float[] a, int inca, float[] r, int incr, VmlMode mode)
            => vmsTandI(n, a, inca, r, incr, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdTandI(int n, double[] a, int inca, double[] r, int incr, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void TandI(int n, double[] a, int inca, double[] r, int incr, VmlMode mode)
            => vmdTandI(n, a, inca, r, incr, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsTanpiI(int n, float[] a, int inca, float[] r, int incr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void TanpiI(int n, float[] a, int inca, float[] r, int incr)
            => vsTanpiI(n, a, inca, r, incr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdTanpiI(int n, double[] a, int inca, double[] r, int incr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void TanpiI(int n, double[] a, int inca, double[] r, int incr)
            => vdTanpiI(n, a, inca, r, incr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsTanpiI(int n, float[] a, int inca, float[] r, int incr, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void TanpiI(int n, float[] a, int inca, float[] r, int incr, VmlMode mode)
            => vmsTanpiI(n, a, inca, r, incr, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdTanpiI(int n, double[] a, int inca, double[] r, int incr, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void TanpiI(int n, double[] a, int inca, double[] r, int incr, VmlMode mode)
            => vmdTanpiI(n, a, inca, r, incr, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsAcosI(int n, float[] a, int inca, float[] r, int incr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void AcosI(int n, float[] a, int inca, float[] r, int incr)
            => vsAcosI(n, a, inca, r, incr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdAcosI(int n, double[] a, int inca, double[] r, int incr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void AcosI(int n, double[] a, int inca, double[] r, int incr)
            => vdAcosI(n, a, inca, r, incr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsAcosI(int n, float[] a, int inca, float[] r, int incr, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void AcosI(int n, float[] a, int inca, float[] r, int incr, VmlMode mode)
            => vmsAcosI(n, a, inca, r, incr, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdAcosI(int n, double[] a, int inca, double[] r, int incr, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void AcosI(int n, double[] a, int inca, double[] r, int incr, VmlMode mode)
            => vmdAcosI(n, a, inca, r, incr, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsAcospiI(int n, float[] a, int inca, float[] r, int incr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void AcospiI(int n, float[] a, int inca, float[] r, int incr)
            => vsAcospiI(n, a, inca, r, incr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdAcospiI(int n, double[] a, int inca, double[] r, int incr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void AcospiI(int n, double[] a, int inca, double[] r, int incr)
            => vdAcospiI(n, a, inca, r, incr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsAcospiI(int n, float[] a, int inca, float[] r, int incr, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void AcospiI(int n, float[] a, int inca, float[] r, int incr, VmlMode mode)
            => vmsAcospiI(n, a, inca, r, incr, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdAcospiI(int n, double[] a, int inca, double[] r, int incr, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void AcospiI(int n, double[] a, int inca, double[] r, int incr, VmlMode mode)
            => vmdAcospiI(n, a, inca, r, incr, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsAsinI(int n, float[] a, int inca, float[] r, int incr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void AsinI(int n, float[] a, int inca, float[] r, int incr)
            => vsAsinI(n, a, inca, r, incr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdAsinI(int n, double[] a, int inca, double[] r, int incr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void AsinI(int n, double[] a, int inca, double[] r, int incr)
            => vdAsinI(n, a, inca, r, incr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsAsinI(int n, float[] a, int inca, float[] r, int incr, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void AsinI(int n, float[] a, int inca, float[] r, int incr, VmlMode mode)
            => vmsAsinI(n, a, inca, r, incr, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdAsinI(int n, double[] a, int inca, double[] r, int incr, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void AsinI(int n, double[] a, int inca, double[] r, int incr, VmlMode mode)
            => vmdAsinI(n, a, inca, r, incr, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsAsinpiI(int n, float[] a, int inca, float[] r, int incr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void AsinpiI(int n, float[] a, int inca, float[] r, int incr)
            => vsAsinpiI(n, a, inca, r, incr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdAsinpiI(int n, double[] a, int inca, double[] r, int incr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void AsinpiI(int n, double[] a, int inca, double[] r, int incr)
            => vdAsinpiI(n, a, inca, r, incr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsAsinpiI(int n, float[] a, int inca, float[] r, int incr, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void AsinpiI(int n, float[] a, int inca, float[] r, int incr, VmlMode mode)
            => vmsAsinpiI(n, a, inca, r, incr, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdAsinpiI(int n, double[] a, int inca, double[] r, int incr, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void AsinpiI(int n, double[] a, int inca, double[] r, int incr, VmlMode mode)
            => vmdAsinpiI(n, a, inca, r, incr, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsAtanI(int n, float[] a, int inca, float[] r, int incr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void AtanI(int n, float[] a, int inca, float[] r, int incr)
            => vsAtanI(n, a, inca, r, incr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdAtanI(int n, double[] a, int inca, double[] r, int incr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void AtanI(int n, double[] a, int inca, double[] r, int incr)
            => vdAtanI(n, a, inca, r, incr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsAtanI(int n, float[] a, int inca, float[] r, int incr, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void AtanI(int n, float[] a, int inca, float[] r, int incr, VmlMode mode)
            => vmsAtanI(n, a, inca, r, incr, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdAtanI(int n, double[] a, int inca, double[] r, int incr, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void AtanI(int n, double[] a, int inca, double[] r, int incr, VmlMode mode)
            => vmdAtanI(n, a, inca, r, incr, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsAtanpiI(int n, float[] a, int inca, float[] r, int incr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void AtanpiI(int n, float[] a, int inca, float[] r, int incr)
            => vsAtanpiI(n, a, inca, r, incr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdAtanpiI(int n, double[] a, int inca, double[] r, int incr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void AtanpiI(int n, double[] a, int inca, double[] r, int incr)
            => vdAtanpiI(n, a, inca, r, incr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsAtanpiI(int n, float[] a, int inca, float[] r, int incr, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void AtanpiI(int n, float[] a, int inca, float[] r, int incr, VmlMode mode)
            => vmsAtanpiI(n, a, inca, r, incr, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdAtanpiI(int n, double[] a, int inca, double[] r, int incr, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void AtanpiI(int n, double[] a, int inca, double[] r, int incr, VmlMode mode)
            => vmdAtanpiI(n, a, inca, r, incr, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsAcoshI(int n, float[] a, int inca, float[] r, int incr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void AcoshI(int n, float[] a, int inca, float[] r, int incr)
            => vsAcoshI(n, a, inca, r, incr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdAcoshI(int n, double[] a, int inca, double[] r, int incr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void AcoshI(int n, double[] a, int inca, double[] r, int incr)
            => vdAcoshI(n, a, inca, r, incr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsAcoshI(int n, float[] a, int inca, float[] r, int incr, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void AcoshI(int n, float[] a, int inca, float[] r, int incr, VmlMode mode)
            => vmsAcoshI(n, a, inca, r, incr, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdAcoshI(int n, double[] a, int inca, double[] r, int incr, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void AcoshI(int n, double[] a, int inca, double[] r, int incr, VmlMode mode)
            => vmdAcoshI(n, a, inca, r, incr, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsAsinhI(int n, float[] a, int inca, float[] r, int incr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void AsinhI(int n, float[] a, int inca, float[] r, int incr)
            => vsAsinhI(n, a, inca, r, incr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdAsinhI(int n, double[] a, int inca, double[] r, int incr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void AsinhI(int n, double[] a, int inca, double[] r, int incr)
            => vdAsinhI(n, a, inca, r, incr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsAsinhI(int n, float[] a, int inca, float[] r, int incr, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void AsinhI(int n, float[] a, int inca, float[] r, int incr, VmlMode mode)
            => vmsAsinhI(n, a, inca, r, incr, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdAsinhI(int n, double[] a, int inca, double[] r, int incr, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void AsinhI(int n, double[] a, int inca, double[] r, int incr, VmlMode mode)
            => vmdAsinhI(n, a, inca, r, incr, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsAtanhI(int n, float[] a, int inca, float[] r, int incr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void AtanhI(int n, float[] a, int inca, float[] r, int incr)
            => vsAtanhI(n, a, inca, r, incr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdAtanhI(int n, double[] a, int inca, double[] r, int incr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void AtanhI(int n, double[] a, int inca, double[] r, int incr)
            => vdAtanhI(n, a, inca, r, incr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsAtanhI(int n, float[] a, int inca, float[] r, int incr, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void AtanhI(int n, float[] a, int inca, float[] r, int incr, VmlMode mode)
            => vmsAtanhI(n, a, inca, r, incr, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdAtanhI(int n, double[] a, int inca, double[] r, int incr, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void AtanhI(int n, double[] a, int inca, double[] r, int incr, VmlMode mode)
            => vmdAtanhI(n, a, inca, r, incr, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsErfI(int n, float[] a, int inca, float[] r, int incr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ErfI(int n, float[] a, int inca, float[] r, int incr)
            => vsErfI(n, a, inca, r, incr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdErfI(int n, double[] a, int inca, double[] r, int incr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ErfI(int n, double[] a, int inca, double[] r, int incr)
            => vdErfI(n, a, inca, r, incr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsErfI(int n, float[] a, int inca, float[] r, int incr, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ErfI(int n, float[] a, int inca, float[] r, int incr, VmlMode mode)
            => vmsErfI(n, a, inca, r, incr, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdErfI(int n, double[] a, int inca, double[] r, int incr, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ErfI(int n, double[] a, int inca, double[] r, int incr, VmlMode mode)
            => vmdErfI(n, a, inca, r, incr, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsErfInvI(int n, float[] a, int inca, float[] r, int incr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ErfInvI(int n, float[] a, int inca, float[] r, int incr)
            => vsErfInvI(n, a, inca, r, incr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdErfInvI(int n, double[] a, int inca, double[] r, int incr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ErfInvI(int n, double[] a, int inca, double[] r, int incr)
            => vdErfInvI(n, a, inca, r, incr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsErfInvI(int n, float[] a, int inca, float[] r, int incr, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ErfInvI(int n, float[] a, int inca, float[] r, int incr, VmlMode mode)
            => vmsErfInvI(n, a, inca, r, incr, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdErfInvI(int n, double[] a, int inca, double[] r, int incr, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ErfInvI(int n, double[] a, int inca, double[] r, int incr, VmlMode mode)
            => vmdErfInvI(n, a, inca, r, incr, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsHypotI(int n, float[] a, int inca, float[] b, int incb, float[] r, int incr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void HypotI(int n, float[] a, int inca, float[] b, int incb, float[] r, int incr)
            => vsHypotI(n, a, inca, b, incb, r, incr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdHypotI(int n, double[] a, int inca, double[] b, int incb, double[] r, int incr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void HypotI(int n, double[] a, int inca, double[] b, int incb, double[] r, int incr)
            => vdHypotI(n, a, inca, b, incb, r, incr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsHypotI(int n, float[] a, int inca, float[] b, int incb, float[] r, int incr, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void HypotI(int n, float[] a, int inca, float[] b, int incb, float[] r, int incr, VmlMode mode)
            => vmsHypotI(n, a, inca, b, incb, r, incr, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdHypotI(int n, double[] a, int inca, double[] b, int incb, double[] r, int incr, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void HypotI(int n, double[] a, int inca, double[] b, int incb, double[] r, int incr, VmlMode mode)
            => vmdHypotI(n, a, inca, b, incb, r, incr, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsErfcI(int n, float[] a, int inca, float[] r, int incr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ErfcI(int n, float[] a, int inca, float[] r, int incr)
            => vsErfcI(n, a, inca, r, incr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdErfcI(int n, double[] a, int inca, double[] r, int incr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ErfcI(int n, double[] a, int inca, double[] r, int incr)
            => vdErfcI(n, a, inca, r, incr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsErfcI(int n, float[] a, int inca, float[] r, int incr, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ErfcI(int n, float[] a, int inca, float[] r, int incr, VmlMode mode)
            => vmsErfcI(n, a, inca, r, incr, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdErfcI(int n, double[] a, int inca, double[] r, int incr, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ErfcI(int n, double[] a, int inca, double[] r, int incr, VmlMode mode)
            => vmdErfcI(n, a, inca, r, incr, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsErfcInvI(int n, float[] a, int inca, float[] r, int incr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ErfcInvI(int n, float[] a, int inca, float[] r, int incr)
            => vsErfcInvI(n, a, inca, r, incr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdErfcInvI(int n, double[] a, int inca, double[] r, int incr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ErfcInvI(int n, double[] a, int inca, double[] r, int incr)
            => vdErfcInvI(n, a, inca, r, incr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsErfcInvI(int n, float[] a, int inca, float[] r, int incr, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ErfcInvI(int n, float[] a, int inca, float[] r, int incr, VmlMode mode)
            => vmsErfcInvI(n, a, inca, r, incr, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdErfcInvI(int n, double[] a, int inca, double[] r, int incr, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ErfcInvI(int n, double[] a, int inca, double[] r, int incr, VmlMode mode)
            => vmdErfcInvI(n, a, inca, r, incr, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsCdfNormI(int n, float[] a, int inca, float[] r, int incr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CdfNormI(int n, float[] a, int inca, float[] r, int incr)
            => vsCdfNormI(n, a, inca, r, incr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdCdfNormI(int n, double[] a, int inca, double[] r, int incr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CdfNormI(int n, double[] a, int inca, double[] r, int incr)
            => vdCdfNormI(n, a, inca, r, incr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsCdfNormI(int n, float[] a, int inca, float[] r, int incr, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CdfNormI(int n, float[] a, int inca, float[] r, int incr, VmlMode mode)
            => vmsCdfNormI(n, a, inca, r, incr, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdCdfNormI(int n, double[] a, int inca, double[] r, int incr, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CdfNormI(int n, double[] a, int inca, double[] r, int incr, VmlMode mode)
            => vmdCdfNormI(n, a, inca, r, incr, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsCdfNormInvI(int n, float[] a, int inca, float[] r, int incr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CdfNormInvI(int n, float[] a, int inca, float[] r, int incr)
            => vsCdfNormInvI(n, a, inca, r, incr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdCdfNormInvI(int n, double[] a, int inca, double[] r, int incr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CdfNormInvI(int n, double[] a, int inca, double[] r, int incr)
            => vdCdfNormInvI(n, a, inca, r, incr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsCdfNormInvI(int n, float[] a, int inca, float[] r, int incr, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CdfNormInvI(int n, float[] a, int inca, float[] r, int incr, VmlMode mode)
            => vmsCdfNormInvI(n, a, inca, r, incr, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdCdfNormInvI(int n, double[] a, int inca, double[] r, int incr, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CdfNormInvI(int n, double[] a, int inca, double[] r, int incr, VmlMode mode)
            => vmdCdfNormInvI(n, a, inca, r, incr, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsLGammaI(int n, float[] a, int inca, float[] r, int incr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void LGammaI(int n, float[] a, int inca, float[] r, int incr)
            => vsLGammaI(n, a, inca, r, incr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdLGammaI(int n, double[] a, int inca, double[] r, int incr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void LGammaI(int n, double[] a, int inca, double[] r, int incr)
            => vdLGammaI(n, a, inca, r, incr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsLGammaI(int n, float[] a, int inca, float[] r, int incr, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void LGammaI(int n, float[] a, int inca, float[] r, int incr, VmlMode mode)
            => vmsLGammaI(n, a, inca, r, incr, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdLGammaI(int n, double[] a, int inca, double[] r, int incr, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void LGammaI(int n, double[] a, int inca, double[] r, int incr, VmlMode mode)
            => vmdLGammaI(n, a, inca, r, incr, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsTGammaI(int n, float[] a, int inca, float[] r, int incr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void TGammaI(int n, float[] a, int inca, float[] r, int incr)
            => vsTGammaI(n, a, inca, r, incr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdTGammaI(int n, double[] a, int inca, double[] r, int incr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void TGammaI(int n, double[] a, int inca, double[] r, int incr)
            => vdTGammaI(n, a, inca, r, incr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsTGammaI(int n, float[] a, int inca, float[] r, int incr, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void TGammaI(int n, float[] a, int inca, float[] r, int incr, VmlMode mode)
            => vmsTGammaI(n, a, inca, r, incr, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdTGammaI(int n, double[] a, int inca, double[] r, int incr, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void TGammaI(int n, double[] a, int inca, double[] r, int incr, VmlMode mode)
            => vmdTGammaI(n, a, inca, r, incr, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsAtan2I(int n, float[] a, int inca, float[] b, int incb, float[] r, int incr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Atan2I(int n, float[] a, int inca, float[] b, int incb, float[] r, int incr)
            => vsAtan2I(n, a, inca, b, incb, r, incr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdAtan2I(int n, double[] a, int inca, double[] b, int incb, double[] r, int incr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Atan2I(int n, double[] a, int inca, double[] b, int incb, double[] r, int incr)
            => vdAtan2I(n, a, inca, b, incb, r, incr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsAtan2I(int n, float[] a, int inca, float[] b, int incb, float[] r, int incr, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Atan2I(int n, float[] a, int inca, float[] b, int incb, float[] r, int incr, VmlMode mode)
            => vmsAtan2I(n, a, inca, b, incb, r, incr, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdAtan2I(int n, double[] a, int inca, double[] b, int incb, double[] r, int incr, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Atan2I(int n, double[] a, int inca, double[] b, int incb, double[] r, int incr, VmlMode mode)
            => vmdAtan2I(n, a, inca, b, incb, r, incr, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsAtan2piI(int n, float[] a, int inca, float[] b, int incb, float[] r, int incr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Atan2piI(int n, float[] a, int inca, float[] b, int incb, float[] r, int incr)
            => vsAtan2piI(n, a, inca, b, incb, r, incr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdAtan2piI(int n, double[] a, int inca, double[] b, int incb, double[] r, int incr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Atan2piI(int n, double[] a, int inca, double[] b, int incb, double[] r, int incr)
            => vdAtan2piI(n, a, inca, b, incb, r, incr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsAtan2piI(int n, float[] a, int inca, float[] b, int incb, float[] r, int incr, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Atan2piI(int n, float[] a, int inca, float[] b, int incb, float[] r, int incr, VmlMode mode)
            => vmsAtan2piI(n, a, inca, b, incb, r, incr, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdAtan2piI(int n, double[] a, int inca, double[] b, int incb, double[] r, int incr, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Atan2piI(int n, double[] a, int inca, double[] b, int incb, double[] r, int incr, VmlMode mode)
            => vmdAtan2piI(n, a, inca, b, incb, r, incr, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsMulI(int n, float[] a, int inca, float[] b, int incb, float[] r, int incr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void MulI(int n, float[] a, int inca, float[] b, int incb, float[] r, int incr)
            => vsMulI(n, a, inca, b, incb, r, incr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdMulI(int n, double[] a, int inca, double[] b, int incb, double[] r, int incr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void MulI(int n, double[] a, int inca, double[] b, int incb, double[] r, int incr)
            => vdMulI(n, a, inca, b, incb, r, incr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsMulI(int n, float[] a, int inca, float[] b, int incb, float[] r, int incr, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void MulI(int n, float[] a, int inca, float[] b, int incb, float[] r, int incr, VmlMode mode)
            => vmsMulI(n, a, inca, b, incb, r, incr, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdMulI(int n, double[] a, int inca, double[] b, int incb, double[] r, int incr, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void MulI(int n, double[] a, int inca, double[] b, int incb, double[] r, int incr, VmlMode mode)
            => vmdMulI(n, a, inca, b, incb, r, incr, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsDivI(int n, float[] a, int inca, float[] b, int incb, float[] r, int incr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void DivI(int n, float[] a, int inca, float[] b, int incb, float[] r, int incr)
            => vsDivI(n, a, inca, b, incb, r, incr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdDivI(int n, double[] a, int inca, double[] b, int incb, double[] r, int incr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void DivI(int n, double[] a, int inca, double[] b, int incb, double[] r, int incr)
            => vdDivI(n, a, inca, b, incb, r, incr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsDivI(int n, float[] a, int inca, float[] b, int incb, float[] r, int incr, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void DivI(int n, float[] a, int inca, float[] b, int incb, float[] r, int incr, VmlMode mode)
            => vmsDivI(n, a, inca, b, incb, r, incr, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdDivI(int n, double[] a, int inca, double[] b, int incb, double[] r, int incr, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void DivI(int n, double[] a, int inca, double[] b, int incb, double[] r, int incr, VmlMode mode)
            => vmdDivI(n, a, inca, b, incb, r, incr, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsFdimI(int n, float[] a, int inca, float[] b, int incb, float[] r, int incr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void FdimI(int n, float[] a, int inca, float[] b, int incb, float[] r, int incr)
            => vsFdimI(n, a, inca, b, incb, r, incr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdFdimI(int n, double[] a, int inca, double[] b, int incb, double[] r, int incr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void FdimI(int n, double[] a, int inca, double[] b, int incb, double[] r, int incr)
            => vdFdimI(n, a, inca, b, incb, r, incr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsFdimI(int n, float[] a, int inca, float[] b, int incb, float[] r, int incr, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void FdimI(int n, float[] a, int inca, float[] b, int incb, float[] r, int incr, VmlMode mode)
            => vmsFdimI(n, a, inca, b, incb, r, incr, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdFdimI(int n, double[] a, int inca, double[] b, int incb, double[] r, int incr, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void FdimI(int n, double[] a, int inca, double[] b, int incb, double[] r, int incr, VmlMode mode)
            => vmdFdimI(n, a, inca, b, incb, r, incr, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsFmodI(int n, float[] a, int inca, float[] b, int incb, float[] r, int incr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void FmodI(int n, float[] a, int inca, float[] b, int incb, float[] r, int incr)
            => vsFmodI(n, a, inca, b, incb, r, incr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdFmodI(int n, double[] a, int inca, double[] b, int incb, double[] r, int incr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void FmodI(int n, double[] a, int inca, double[] b, int incb, double[] r, int incr)
            => vdFmodI(n, a, inca, b, incb, r, incr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsFmodI(int n, float[] a, int inca, float[] b, int incb, float[] r, int incr, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void FmodI(int n, float[] a, int inca, float[] b, int incb, float[] r, int incr, VmlMode mode)
            => vmsFmodI(n, a, inca, b, incb, r, incr, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdFmodI(int n, double[] a, int inca, double[] b, int incb, double[] r, int incr, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void FmodI(int n, double[] a, int inca, double[] b, int incb, double[] r, int incr, VmlMode mode)
            => vmdFmodI(n, a, inca, b, incb, r, incr, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsFmaxI(int n, float[] a, int inca, float[] b, int incb, float[] r, int incr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void FmaxI(int n, float[] a, int inca, float[] b, int incb, float[] r, int incr)
            => vsFmaxI(n, a, inca, b, incb, r, incr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdFmaxI(int n, double[] a, int inca, double[] b, int incb, double[] r, int incr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void FmaxI(int n, double[] a, int inca, double[] b, int incb, double[] r, int incr)
            => vdFmaxI(n, a, inca, b, incb, r, incr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsFmaxI(int n, float[] a, int inca, float[] b, int incb, float[] r, int incr, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void FmaxI(int n, float[] a, int inca, float[] b, int incb, float[] r, int incr, VmlMode mode)
            => vmsFmaxI(n, a, inca, b, incb, r, incr, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdFmaxI(int n, double[] a, int inca, double[] b, int incb, double[] r, int incr, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void FmaxI(int n, double[] a, int inca, double[] b, int incb, double[] r, int incr, VmlMode mode)
            => vmdFmaxI(n, a, inca, b, incb, r, incr, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsFminI(int n, float[] a, int inca, float[] b, int incb, float[] r, int incr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void FminI(int n, float[] a, int inca, float[] b, int incb, float[] r, int incr)
            => vsFminI(n, a, inca, b, incb, r, incr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdFminI(int n, double[] a, int inca, double[] b, int incb, double[] r, int incr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void FminI(int n, double[] a, int inca, double[] b, int incb, double[] r, int incr)
            => vdFminI(n, a, inca, b, incb, r, incr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsFminI(int n, float[] a, int inca, float[] b, int incb, float[] r, int incr, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void FminI(int n, float[] a, int inca, float[] b, int incb, float[] r, int incr, VmlMode mode)
            => vmsFminI(n, a, inca, b, incb, r, incr, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdFminI(int n, double[] a, int inca, double[] b, int incb, double[] r, int incr, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void FminI(int n, double[] a, int inca, double[] b, int incb, double[] r, int incr, VmlMode mode)
            => vmdFminI(n, a, inca, b, incb, r, incr, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsPowI(int n, float[] a, int inca, float[] b, int incb, float[] r, int incr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void PowI(int n, float[] a, int inca, float[] b, int incb, float[] r, int incr)
            => vsPowI(n, a, inca, b, incb, r, incr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdPowI(int n, double[] a, int inca, double[] b, int incb, double[] r, int incr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void PowI(int n, double[] a, int inca, double[] b, int incb, double[] r, int incr)
            => vdPowI(n, a, inca, b, incb, r, incr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsPowI(int n, float[] a, int inca, float[] b, int incb, float[] r, int incr, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void PowI(int n, float[] a, int inca, float[] b, int incb, float[] r, int incr, VmlMode mode)
            => vmsPowI(n, a, inca, b, incb, r, incr, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdPowI(int n, double[] a, int inca, double[] b, int incb, double[] r, int incr, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void PowI(int n, double[] a, int inca, double[] b, int incb, double[] r, int incr, VmlMode mode)
            => vmdPowI(n, a, inca, b, incb, r, incr, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsPowrI(int n, float[] a, int inca, float[] b, int incb, float[] r, int incr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void PowrI(int n, float[] a, int inca, float[] b, int incb, float[] r, int incr)
            => vsPowrI(n, a, inca, b, incb, r, incr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdPowrI(int n, double[] a, int inca, double[] b, int incb, double[] r, int incr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void PowrI(int n, double[] a, int inca, double[] b, int incb, double[] r, int incr)
            => vdPowrI(n, a, inca, b, incb, r, incr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsPowrI(int n, float[] a, int inca, float[] b, int incb, float[] r, int incr, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void PowrI(int n, float[] a, int inca, float[] b, int incb, float[] r, int incr, VmlMode mode)
            => vmsPowrI(n, a, inca, b, incb, r, incr, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdPowrI(int n, double[] a, int inca, double[] b, int incb, double[] r, int incr, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void PowrI(int n, double[] a, int inca, double[] b, int incb, double[] r, int incr, VmlMode mode)
            => vmdPowrI(n, a, inca, b, incb, r, incr, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsPow3o2I(int n, float[] a, int inca, float[] r, int incr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Pow3o2I(int n, float[] a, int inca, float[] r, int incr)
            => vsPow3o2I(n, a, inca, r, incr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdPow3o2I(int n, double[] a, int inca, double[] r, int incr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Pow3o2I(int n, double[] a, int inca, double[] r, int incr)
            => vdPow3o2I(n, a, inca, r, incr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsPow3o2I(int n, float[] a, int inca, float[] r, int incr, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Pow3o2I(int n, float[] a, int inca, float[] r, int incr, VmlMode mode)
            => vmsPow3o2I(n, a, inca, r, incr, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdPow3o2I(int n, double[] a, int inca, double[] r, int incr, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Pow3o2I(int n, double[] a, int inca, double[] r, int incr, VmlMode mode)
            => vmdPow3o2I(n, a, inca, r, incr, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsPow2o3I(int n, float[] a, int inca, float[] r, int incr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Pow2o3I(int n, float[] a, int inca, float[] r, int incr)
            => vsPow2o3I(n, a, inca, r, incr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdPow2o3I(int n, double[] a, int inca, double[] r, int incr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Pow2o3I(int n, double[] a, int inca, double[] r, int incr)
            => vdPow2o3I(n, a, inca, r, incr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsPow2o3I(int n, float[] a, int inca, float[] r, int incr, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Pow2o3I(int n, float[] a, int inca, float[] r, int incr, VmlMode mode)
            => vmsPow2o3I(n, a, inca, r, incr, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdPow2o3I(int n, double[] a, int inca, double[] r, int incr, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Pow2o3I(int n, double[] a, int inca, double[] r, int incr, VmlMode mode)
            => vmdPow2o3I(n, a, inca, r, incr, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsPowxI(int n, float[] a, int inca, float b, float[] r, int incr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void PowxI(int n, float[] a, int inca, float b, float[] r, int incr)
            => vsPowxI(n, a, inca, b, r, incr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdPowxI(int n, double[] a, int inca, double b, double[] r, int incr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void PowxI(int n, double[] a, int inca, double b, double[] r, int incr)
            => vdPowxI(n, a, inca, b, r, incr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsPowxI(int n, float[] a, int inca, float b, float[] r, int incr, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void PowxI(int n, float[] a, int inca, float b, float[] r, int incr, VmlMode mode)
            => vmsPowxI(n, a, inca, b, r, incr, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdPowxI(int n, double[] a, int inca, double b, double[] r, int incr, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void PowxI(int n, double[] a, int inca, double b, double[] r, int incr, VmlMode mode)
            => vmdPowxI(n, a, inca, b, r, incr, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsSinCosI(int n, float[] a, int inca, float[] r1, int incr1, float[] r2, int incr2);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SinCosI(int n, float[] a, int inca, float[] r1, int incr1, float[] r2, int incr2)
            => vsSinCosI(n, a, inca, r1, incr1, r2, incr2);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdSinCosI(int n, double[] a, int inca, double[] r1, int incr1, double[] r2, int incr2);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SinCosI(int n, double[] a, int inca, double[] r1, int incr1, double[] r2, int incr2)
            => vdSinCosI(n, a, inca, r1, incr1, r2, incr2);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsSinCosI(int n, float[] a, int inca, float[] r1, int incr1, float[] r2, int incr2, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SinCosI(int n, float[] a, int inca, float[] r1, int incr1, float[] r2, int incr2, VmlMode mode)
            => vmsSinCosI(n, a, inca, r1, incr1, r2, incr2, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdSinCosI(int n, double[] a, int inca, double[] r1, int incr1, double[] r2, int incr2, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SinCosI(int n, double[] a, int inca, double[] r1, int incr1, double[] r2, int incr2, VmlMode mode)
            => vmdSinCosI(n, a, inca, r1, incr1, r2, incr2, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsLinearFracI(int n, float[] a, int inca, float[] b, int incb, float scalea, float shifta, float scaleb, float shiftb, float[] r, int incr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void LinearFracI(int n, float[] a, int inca, float[] b, int incb, float scalea, float shifta, float scaleb, float shiftb, float[] r, int incr)
            => vsLinearFracI(n, a, inca, b, incb, scalea, shifta, scaleb, shiftb, r, incr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdLinearFracI(int n, double[] a, int inca, double[] b, int incb, double scalea, double shifta, double scaleb, double shiftb, double[] r, int incr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void LinearFracI(int n, double[] a, int inca, double[] b, int incb, double scalea, double shifta, double scaleb, double shiftb, double[] r, int incr)
            => vdLinearFracI(n, a, inca, b, incb, scalea, shifta, scaleb, shiftb, r, incr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsLinearFracI(int n, float[] a, int inca, float[] b, int incb, float scalea, float shifta, float scaleb, float shiftb, float[] r, int incr, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void LinearFracI(int n, float[] a, int inca, float[] b, int incb, float scalea, float shifta, float scaleb, float shiftb, float[] r, int incr, VmlMode mode)
            => vmsLinearFracI(n, a, inca, b, incb, scalea, shifta, scaleb, shiftb, r, incr, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdLinearFracI(int n, double[] a, int inca, double[] b, int incb, double scalea, double shifta, double scaleb, double shiftb, double[] r, int incr, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void LinearFracI(int n, double[] a, int inca, double[] b, int incb, double scalea, double shifta, double scaleb, double shiftb, double[] r, int incr, VmlMode mode)
            => vmdLinearFracI(n, a, inca, b, incb, scalea, shifta, scaleb, shiftb, r, incr, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsCeilI(int n, float[] a, int inca, float[] r, int incr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CeilI(int n, float[] a, int inca, float[] r, int incr)
            => vsCeilI(n, a, inca, r, incr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdCeilI(int n, double[] a, int inca, double[] r, int incr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CeilI(int n, double[] a, int inca, double[] r, int incr)
            => vdCeilI(n, a, inca, r, incr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsCeilI(int n, float[] a, int inca, float[] r, int incr, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CeilI(int n, float[] a, int inca, float[] r, int incr, VmlMode mode)
            => vmsCeilI(n, a, inca, r, incr, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdCeilI(int n, double[] a, int inca, double[] r, int incr, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CeilI(int n, double[] a, int inca, double[] r, int incr, VmlMode mode)
            => vmdCeilI(n, a, inca, r, incr, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsFloorI(int n, float[] a, int inca, float[] r, int incr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void FloorI(int n, float[] a, int inca, float[] r, int incr)
            => vsFloorI(n, a, inca, r, incr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdFloorI(int n, double[] a, int inca, double[] r, int incr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void FloorI(int n, double[] a, int inca, double[] r, int incr)
            => vdFloorI(n, a, inca, r, incr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsFloorI(int n, float[] a, int inca, float[] r, int incr, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void FloorI(int n, float[] a, int inca, float[] r, int incr, VmlMode mode)
            => vmsFloorI(n, a, inca, r, incr, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdFloorI(int n, double[] a, int inca, double[] r, int incr, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void FloorI(int n, double[] a, int inca, double[] r, int incr, VmlMode mode)
            => vmdFloorI(n, a, inca, r, incr, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsFracI(int n, float[] a, int inca, float[] r, int incr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void FracI(int n, float[] a, int inca, float[] r, int incr)
            => vsFracI(n, a, inca, r, incr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdFracI(int n, double[] a, int inca, double[] r, int incr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void FracI(int n, double[] a, int inca, double[] r, int incr)
            => vdFracI(n, a, inca, r, incr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsFracI(int n, float[] a, int inca, float[] r, int incr, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void FracI(int n, float[] a, int inca, float[] r, int incr, VmlMode mode)
            => vmsFracI(n, a, inca, r, incr, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdFracI(int n, double[] a, int inca, double[] r, int incr, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void FracI(int n, double[] a, int inca, double[] r, int incr, VmlMode mode)
            => vmdFracI(n, a, inca, r, incr, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsModfI(int n, float[] a, int inca, float[] r1, int incr1, float[] r2, int incr2);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ModfI(int n, float[] a, int inca, float[] r1, int incr1, float[] r2, int incr2)
            => vsModfI(n, a, inca, r1, incr1, r2, incr2);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdModfI(int n, double[] a, int inca, double[] r1, int incr1, double[] r2, int incr2);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ModfI(int n, double[] a, int inca, double[] r1, int incr1, double[] r2, int incr2)
            => vdModfI(n, a, inca, r1, incr1, r2, incr2);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsModfI(int n, float[] a, int inca, float[] r1, int incr1, float[] r2, int incr2, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ModfI(int n, float[] a, int inca, float[] r1, int incr1, float[] r2, int incr2, VmlMode mode)
            => vmsModfI(n, a, inca, r1, incr1, r2, incr2, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdModfI(int n, double[] a, int inca, double[] r1, int incr1, double[] r2, int incr2, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ModfI(int n, double[] a, int inca, double[] r1, int incr1, double[] r2, int incr2, VmlMode mode)
            => vmdModfI(n, a, inca, r1, incr1, r2, incr2, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsNearbyIntI(int n, float[] a, int inca, float[] r, int incr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void NearbyIntI(int n, float[] a, int inca, float[] r, int incr)
            => vsNearbyIntI(n, a, inca, r, incr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdNearbyIntI(int n, double[] a, int inca, double[] r, int incr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void NearbyIntI(int n, double[] a, int inca, double[] r, int incr)
            => vdNearbyIntI(n, a, inca, r, incr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsNearbyIntI(int n, float[] a, int inca, float[] r, int incr, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void NearbyIntI(int n, float[] a, int inca, float[] r, int incr, VmlMode mode)
            => vmsNearbyIntI(n, a, inca, r, incr, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdNearbyIntI(int n, double[] a, int inca, double[] r, int incr, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void NearbyIntI(int n, double[] a, int inca, double[] r, int incr, VmlMode mode)
            => vmdNearbyIntI(n, a, inca, r, incr, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsNextAfterI(int n, float[] a, int inca, float[] b, int incb, float[] r, int incr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void NextAfterI(int n, float[] a, int inca, float[] b, int incb, float[] r, int incr)
            => vsNextAfterI(n, a, inca, b, incb, r, incr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdNextAfterI(int n, double[] a, int inca, double[] b, int incb, double[] r, int incr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void NextAfterI(int n, double[] a, int inca, double[] b, int incb, double[] r, int incr)
            => vdNextAfterI(n, a, inca, b, incb, r, incr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsNextAfterI(int n, float[] a, int inca, float[] b, int incb, float[] r, int incr, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void NextAfterI(int n, float[] a, int inca, float[] b, int incb, float[] r, int incr, VmlMode mode)
            => vmsNextAfterI(n, a, inca, b, incb, r, incr, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdNextAfterI(int n, double[] a, int inca, double[] b, int incb, double[] r, int incr, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void NextAfterI(int n, double[] a, int inca, double[] b, int incb, double[] r, int incr, VmlMode mode)
            => vmdNextAfterI(n, a, inca, b, incb, r, incr, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsMinMagI(int n, float[] a, int inca, float[] b, int incb, float[] r, int incr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void MinMagI(int n, float[] a, int inca, float[] b, int incb, float[] r, int incr)
            => vsMinMagI(n, a, inca, b, incb, r, incr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdMinMagI(int n, double[] a, int inca, double[] b, int incb, double[] r, int incr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void MinMagI(int n, double[] a, int inca, double[] b, int incb, double[] r, int incr)
            => vdMinMagI(n, a, inca, b, incb, r, incr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsMinMagI(int n, float[] a, int inca, float[] b, int incb, float[] r, int incr, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void MinMagI(int n, float[] a, int inca, float[] b, int incb, float[] r, int incr, VmlMode mode)
            => vmsMinMagI(n, a, inca, b, incb, r, incr, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdMinMagI(int n, double[] a, int inca, double[] b, int incb, double[] r, int incr, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void MinMagI(int n, double[] a, int inca, double[] b, int incb, double[] r, int incr, VmlMode mode)
            => vmdMinMagI(n, a, inca, b, incb, r, incr, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsMaxMagI(int n, float[] a, int inca, float[] b, int incb, float[] r, int incr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void MaxMagI(int n, float[] a, int inca, float[] b, int incb, float[] r, int incr)
            => vsMaxMagI(n, a, inca, b, incb, r, incr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdMaxMagI(int n, double[] a, int inca, double[] b, int incb, double[] r, int incr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void MaxMagI(int n, double[] a, int inca, double[] b, int incb, double[] r, int incr)
            => vdMaxMagI(n, a, inca, b, incb, r, incr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsMaxMagI(int n, float[] a, int inca, float[] b, int incb, float[] r, int incr, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void MaxMagI(int n, float[] a, int inca, float[] b, int incb, float[] r, int incr, VmlMode mode)
            => vmsMaxMagI(n, a, inca, b, incb, r, incr, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdMaxMagI(int n, double[] a, int inca, double[] b, int incb, double[] r, int incr, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void MaxMagI(int n, double[] a, int inca, double[] b, int incb, double[] r, int incr, VmlMode mode)
            => vmdMaxMagI(n, a, inca, b, incb, r, incr, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsRintI(int n, float[] a, int inca, float[] r, int incr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void RintI(int n, float[] a, int inca, float[] r, int incr)
            => vsRintI(n, a, inca, r, incr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdRintI(int n, double[] a, int inca, double[] r, int incr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void RintI(int n, double[] a, int inca, double[] r, int incr)
            => vdRintI(n, a, inca, r, incr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsRintI(int n, float[] a, int inca, float[] r, int incr, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void RintI(int n, float[] a, int inca, float[] r, int incr, VmlMode mode)
            => vmsRintI(n, a, inca, r, incr, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdRintI(int n, double[] a, int inca, double[] r, int incr, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void RintI(int n, double[] a, int inca, double[] r, int incr, VmlMode mode)
            => vmdRintI(n, a, inca, r, incr, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsRoundI(int n, float[] a, int inca, float[] r, int incr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void RoundI(int n, float[] a, int inca, float[] r, int incr)
            => vsRoundI(n, a, inca, r, incr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdRoundI(int n, double[] a, int inca, double[] r, int incr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void RoundI(int n, double[] a, int inca, double[] r, int incr)
            => vdRoundI(n, a, inca, r, incr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsRoundI(int n, float[] a, int inca, float[] r, int incr, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void RoundI(int n, float[] a, int inca, float[] r, int incr, VmlMode mode)
            => vmsRoundI(n, a, inca, r, incr, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdRoundI(int n, double[] a, int inca, double[] r, int incr, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void RoundI(int n, double[] a, int inca, double[] r, int incr, VmlMode mode)
            => vmdRoundI(n, a, inca, r, incr, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsTruncI(int n, float[] a, int inca, float[] r, int incr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void TruncI(int n, float[] a, int inca, float[] r, int incr)
            => vsTruncI(n, a, inca, r, incr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdTruncI(int n, double[] a, int inca, double[] r, int incr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void TruncI(int n, double[] a, int inca, double[] r, int incr)
            => vdTruncI(n, a, inca, r, incr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsTruncI(int n, float[] a, int inca, float[] r, int incr, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void TruncI(int n, float[] a, int inca, float[] r, int incr, VmlMode mode)
            => vmsTruncI(n, a, inca, r, incr, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdTruncI(int n, double[] a, int inca, double[] r, int incr, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void TruncI(int n, double[] a, int inca, double[] r, int incr, VmlMode mode)
            => vmdTruncI(n, a, inca, r, incr, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsExpInt1I(int n, float[] a, int inca, float[] r, int incr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ExpInt1I(int n, float[] a, int inca, float[] r, int incr)
            => vsExpInt1I(n, a, inca, r, incr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdExpInt1I(int n, double[] a, int inca, double[] r, int incr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ExpInt1I(int n, double[] a, int inca, double[] r, int incr)
            => vdExpInt1I(n, a, inca, r, incr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsExpInt1I(int n, float[] a, int inca, float[] r, int incr, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ExpInt1I(int n, float[] a, int inca, float[] r, int incr, VmlMode mode)
            => vmsExpInt1I(n, a, inca, r, incr, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdExpInt1I(int n, double[] a, int inca, double[] r, int incr, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ExpInt1I(int n, double[] a, int inca, double[] r, int incr, VmlMode mode)
            => vmdExpInt1I(n, a, inca, r, incr, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsCopySignI(int n, float[] a, int inca, float[] b, int incb, float[] r, int incr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CopySignI(int n, float[] a, int inca, float[] b, int incb, float[] r, int incr)
            => vsCopySignI(n, a, inca, b, incb, r, incr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdCopySignI(int n, double[] a, int inca, double[] b, int incb, double[] r, int incr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CopySignI(int n, double[] a, int inca, double[] b, int incb, double[] r, int incr)
            => vdCopySignI(n, a, inca, b, incb, r, incr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsCopySignI(int n, float[] a, int inca, float[] b, int incb, float[] r, int incr, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CopySignI(int n, float[] a, int inca, float[] b, int incb, float[] r, int incr, VmlMode mode)
            => vmsCopySignI(n, a, inca, b, incb, r, incr, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdCopySignI(int n, double[] a, int inca, double[] b, int incb, double[] r, int incr, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CopySignI(int n, double[] a, int inca, double[] b, int incb, double[] r, int incr, VmlMode mode)
            => vmdCopySignI(n, a, inca, b, incb, r, incr, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsRemainderI(int n, float[] a, int inca, float[] b, int incb, float[] r, int incr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void RemainderI(int n, float[] a, int inca, float[] b, int incb, float[] r, int incr)
            => vsRemainderI(n, a, inca, b, incb, r, incr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdRemainderI(int n, double[] a, int inca, double[] b, int incb, double[] r, int incr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void RemainderI(int n, double[] a, int inca, double[] b, int incb, double[] r, int incr)
            => vdRemainderI(n, a, inca, b, incb, r, incr);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsRemainderI(int n, float[] a, int inca, float[] b, int incb, float[] r, int incr, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void RemainderI(int n, float[] a, int inca, float[] b, int incb, float[] r, int incr, VmlMode mode)
            => vmsRemainderI(n, a, inca, b, incb, r, incr, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdRemainderI(int n, double[] a, int inca, double[] b, int incb, double[] r, int incr, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void RemainderI(int n, double[] a, int inca, double[] b, int incb, double[] r, int incr, VmlMode mode)
            => vmdRemainderI(n, a, inca, b, incb, r, incr, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsPackI(int n, float[] a, int incra, float[] y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void PackI(int n, float[] a, int incra, float[] y)
            => vsPackI(n, a, incra, y);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdPackI(int n, double[] a, int incra, double[] y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void PackI(int n, double[] a, int incra, double[] y)
            => vdPackI(n, a, incra, y);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsPackV(int n, float[] a, int[] ia, float[] y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void PackV(int n, float[] a, int[] ia, float[] y)
            => vsPackV(n, a, ia, y);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdPackV(int n, double[] a, int[] ia, double[] y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void PackV(int n, double[] a, int[] ia, double[] y)
            => vdPackV(n, a, ia, y);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsPackM(int n, float[] a, int[] ma, float[] y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void PackM(int n, float[] a, int[] ma, float[] y)
            => vsPackM(n, a, ma, y);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdPackM(int n, double[] a, int[] ma, double[] y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void PackM(int n, double[] a, int[] ma, double[] y)
            => vdPackM(n, a, ma, y);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsUnpackI(int n, float[] a, float[] y, int incry);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void UnpackI(int n, float[] a, float[] y, int incry)
            => vsUnpackI(n, a, y, incry);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdUnpackI(int n, double[] a, double[] y, int incry);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void UnpackI(int n, double[] a, double[] y, int incry)
            => vdUnpackI(n, a, y, incry);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsUnpackV(int n, float[] a, float[] y, int[] iy);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void UnpackV(int n, float[] a, float[] y, int[] iy)
            => vsUnpackV(n, a, y, iy);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdUnpackV(int n, double[] a, double[] y, int[] iy);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void UnpackV(int n, double[] a, double[] y, int[] iy)
            => vdUnpackV(n, a, y, iy);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsUnpackM(int n, float[] a, float[] y, int[] my);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void UnpackM(int n, float[] a, float[] y, int[] my)
            => vsUnpackM(n, a, y, my);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdUnpackM(int n, double[] a, double[] y, int[] my);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void UnpackM(int n, double[] a, double[] y, int[] my)
            => vdUnpackM(n, a, y, my);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern VmlStatus vmlSetErrStatus(VmlStatus status);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static VmlStatus SetErrStatus(VmlStatus status)
            => vmlSetErrStatus(status);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern VmlStatus vmlGetErrStatus();
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static VmlStatus GetErrStatus()
            => vmlGetErrStatus();

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern VmlStatus vmlClearErrStatus();
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static VmlStatus ClearErrStatus()
            => vmlClearErrStatus();

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern VmlMode vmlSetMode(VmlMode newmode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static VmlMode SetMode(VmlMode newmode)
            => vmlSetMode(newmode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern VmlMode vmlGetMode();
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static VmlMode GetMode()
            => vmlGetMode();
    }
}