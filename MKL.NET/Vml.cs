using System.Security;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;

namespace MKLNET
{
    [SuppressUnmanagedCodeSecurity]
    public unsafe static class Vml
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
        public static void Abs(float[] a, float[] r)
            => vsAbs(a.Length, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdAbs(int n, double[] a, double[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Abs(double[] a, double[] r)
            => vdAbs(a.Length, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsAbs(int n, float[] a, float[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Abs(float[] a, float[] r, VmlMode mode)
            => vmsAbs(a.Length, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdAbs(int n, double[] a, double[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Abs(double[] a, double[] r, VmlMode mode)
            => vmdAbs(a.Length, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsAdd(int n, float[] a, float[] b, float[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Add(float[] a, float[] b, float[] r)
            => vsAdd(a.Length, a, b, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdAdd(int n, double[] a, double[] b, double[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Add(double[] a, double[] b, double[] r)
            => vdAdd(a.Length, a, b, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsAdd(int n, float[] a, float[] b, float[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Add(float[] a, float[] b, float[] r, VmlMode mode)
            => vmsAdd(a.Length, a, b, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdAdd(int n, double[] a, double[] b, double[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Add(double[] a, double[] b, double[] r, VmlMode mode)
            => vmdAdd(a.Length, a, b, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsSub(int n, float[] a, float[] b, float[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Sub(float[] a, float[] b, float[] r)
            => vsSub(a.Length, a, b, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdSub(int n, double[] a, double[] b, double[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Sub(double[] a, double[] b, double[] r)
            => vdSub(a.Length, a, b, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsSub(int n, float[] a, float[] b, float[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Sub(float[] a, float[] b, float[] r, VmlMode mode)
            => vmsSub(a.Length, a, b, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdSub(int n, double[] a, double[] b, double[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Sub(double[] a, double[] b, double[] r, VmlMode mode)
            => vmdSub(a.Length, a, b, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsInv(int n, float[] a, float[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Inv(float[] a, float[] r)
            => vsInv(a.Length, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdInv(int n, double[] a, double[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Inv(double[] a, double[] r)
            => vdInv(a.Length, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsInv(int n, float[] a, float[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Inv(float[] a, float[] r, VmlMode mode)
            => vmsInv(a.Length, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdInv(int n, double[] a, double[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Inv(double[] a, double[] r, VmlMode mode)
            => vmdInv(a.Length, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsSqrt(int n, float[] a, float[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Sqrt(float[] a, float[] r)
            => vsSqrt(a.Length, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdSqrt(int n, double[] a, double[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Sqrt(double[] a, double[] r)
            => vdSqrt(a.Length, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsSqrt(int n, float[] a, float[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Sqrt(float[] a, float[] r, VmlMode mode)
            => vmsSqrt(a.Length, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdSqrt(int n, double[] a, double[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Sqrt(double[] a, double[] r, VmlMode mode)
            => vmdSqrt(a.Length, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsInvSqrt(int n, float[] a, float[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void InvSqrt(float[] a, float[] r)
            => vsInvSqrt(a.Length, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdInvSqrt(int n, double[] a, double[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void InvSqrt(double[] a, double[] r)
            => vdInvSqrt(a.Length, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsInvSqrt(int n, float[] a, float[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void InvSqrt(float[] a, float[] r, VmlMode mode)
            => vmsInvSqrt(a.Length, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdInvSqrt(int n, double[] a, double[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void InvSqrt(double[] a, double[] r, VmlMode mode)
            => vmdInvSqrt(a.Length, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsCbrt(int n, float[] a, float[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Cbrt(float[] a, float[] r)
            => vsCbrt(a.Length, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdCbrt(int n, double[] a, double[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Cbrt(double[] a, double[] r)
            => vdCbrt(a.Length, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsCbrt(int n, float[] a, float[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Cbrt(float[] a, float[] r, VmlMode mode)
            => vmsCbrt(a.Length, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdCbrt(int n, double[] a, double[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Cbrt(double[] a, double[] r, VmlMode mode)
            => vmdCbrt(a.Length, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsInvCbrt(int n, float[] a, float[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void InvCbrt(float[] a, float[] r)
            => vsInvCbrt(a.Length, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdInvCbrt(int n, double[] a, double[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void InvCbrt(double[] a, double[] r)
            => vdInvCbrt(a.Length, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsInvCbrt(int n, float[] a, float[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void InvCbrt(float[] a, float[] r, VmlMode mode)
            => vmsInvCbrt(a.Length, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdInvCbrt(int n, double[] a, double[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void InvCbrt(double[] a, double[] r, VmlMode mode)
            => vmdInvCbrt(a.Length, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsSqr(int n, float[] a, float[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Sqr(float[] a, float[] r)
            => vsSqr(a.Length, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdSqr(int n, double[] a, double[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Sqr(double[] a, double[] r)
            => vdSqr(a.Length, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsSqr(int n, float[] a, float[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Sqr(float[] a, float[] r, VmlMode mode)
            => vmsSqr(a.Length, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdSqr(int n, double[] a, double[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Sqr(double[] a, double[] r, VmlMode mode)
            => vmdSqr(a.Length, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsExp(int n, float[] a, float[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Exp(float[] a, float[] r)
            => vsExp(a.Length, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdExp(int n, double[] a, double[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Exp(double[] a, double[] r)
            => vdExp(a.Length, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsExp(int n, float[] a, float[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Exp(float[] a, float[] r, VmlMode mode)
            => vmsExp(a.Length, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdExp(int n, double[] a, double[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Exp(double[] a, double[] r, VmlMode mode)
            => vmdExp(a.Length, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsExp2(int n, float[] a, float[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Exp2(float[] a, float[] r)
            => vsExp2(a.Length, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdExp2(int n, double[] a, double[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Exp2(double[] a, double[] r)
            => vdExp2(a.Length, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsExp2(int n, float[] a, float[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Exp2(float[] a, float[] r, VmlMode mode)
            => vmsExp2(a.Length, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdExp2(int n, double[] a, double[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Exp2(double[] a, double[] r, VmlMode mode)
            => vmdExp2(a.Length, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsExp10(int n, float[] a, float[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Exp10(float[] a, float[] r)
            => vsExp10(a.Length, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdExp10(int n, double[] a, double[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Exp10(double[] a, double[] r)
            => vdExp10(a.Length, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsExp10(int n, float[] a, float[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Exp10(float[] a, float[] r, VmlMode mode)
            => vmsExp10(a.Length, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdExp10(int n, double[] a, double[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Exp10(double[] a, double[] r, VmlMode mode)
            => vmdExp10(a.Length, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsExpm1(int n, float[] a, float[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Expm1(float[] a, float[] r)
            => vsExpm1(a.Length, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdExpm1(int n, double[] a, double[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Expm1(double[] a, double[] r)
            => vdExpm1(a.Length, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsExpm1(int n, float[] a, float[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Expm1(float[] a, float[] r, VmlMode mode)
            => vmsExpm1(a.Length, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdExpm1(int n, double[] a, double[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Expm1(double[] a, double[] r, VmlMode mode)
            => vmdExpm1(a.Length, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsLn(int n, float[] a, float[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Ln(float[] a, float[] r)
            => vsLn(a.Length, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdLn(int n, double[] a, double[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Ln(double[] a, double[] r)
            => vdLn(a.Length, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsLn(int n, float[] a, float[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Ln(float[] a, float[] r, VmlMode mode)
            => vmsLn(a.Length, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdLn(int n, double[] a, double[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Ln(double[] a, double[] r, VmlMode mode)
            => vmdLn(a.Length, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsLog2(int n, float[] a, float[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Log2(float[] a, float[] r)
            => vsLog2(a.Length, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdLog2(int n, double[] a, double[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Log2(double[] a, double[] r)
            => vdLog2(a.Length, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsLog2(int n, float[] a, float[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Log2(float[] a, float[] r, VmlMode mode)
            => vmsLog2(a.Length, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdLog2(int n, double[] a, double[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Log2(double[] a, double[] r, VmlMode mode)
            => vmdLog2(a.Length, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsLog10(int n, float[] a, float[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Log10(float[] a, float[] r)
            => vsLog10(a.Length, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdLog10(int n, double[] a, double[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Log10(double[] a, double[] r)
            => vdLog10(a.Length, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsLog10(int n, float[] a, float[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Log10(float[] a, float[] r, VmlMode mode)
            => vmsLog10(a.Length, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdLog10(int n, double[] a, double[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Log10(double[] a, double[] r, VmlMode mode)
            => vmdLog10(a.Length, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsLog1p(int n, float[] a, float[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Log1p(float[] a, float[] r)
            => vsLog1p(a.Length, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdLog1p(int n, double[] a, double[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Log1p(double[] a, double[] r)
            => vdLog1p(a.Length, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsLog1p(int n, float[] a, float[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Log1p(float[] a, float[] r, VmlMode mode)
            => vmsLog1p(a.Length, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdLog1p(int n, double[] a, double[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Log1p(double[] a, double[] r, VmlMode mode)
            => vmdLog1p(a.Length, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsLogb(int n, float[] a, float[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Logb(float[] a, float[] r)
            => vsLogb(a.Length, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdLogb(int n, double[] a, double[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Logb(double[] a, double[] r)
            => vdLogb(a.Length, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsLogb(int n, float[] a, float[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Logb(float[] a, float[] r, VmlMode mode)
            => vmsLogb(a.Length, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdLogb(int n, double[] a, double[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Logb(double[] a, double[] r, VmlMode mode)
            => vmdLogb(a.Length, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsCos(int n, float[] a, float[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Cos(float[] a, float[] r)
            => vsCos(a.Length, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdCos(int n, double[] a, double[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Cos(double[] a, double[] r)
            => vdCos(a.Length, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsCos(int n, float[] a, float[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Cos(float[] a, float[] r, VmlMode mode)
            => vmsCos(a.Length, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdCos(int n, double[] a, double[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Cos(double[] a, double[] r, VmlMode mode)
            => vmdCos(a.Length, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsSin(int n, float[] a, float[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Sin(float[] a, float[] r)
            => vsSin(a.Length, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdSin(int n, double[] a, double[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Sin(double[] a, double[] r)
            => vdSin(a.Length, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsSin(int n, float[] a, float[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Sin(float[] a, float[] r, VmlMode mode)
            => vmsSin(a.Length, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdSin(int n, double[] a, double[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Sin(double[] a, double[] r, VmlMode mode)
            => vmdSin(a.Length, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsTan(int n, float[] a, float[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Tan(float[] a, float[] r)
            => vsTan(a.Length, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdTan(int n, double[] a, double[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Tan(double[] a, double[] r)
            => vdTan(a.Length, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsTan(int n, float[] a, float[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Tan(float[] a, float[] r, VmlMode mode)
            => vmsTan(a.Length, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdTan(int n, double[] a, double[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Tan(double[] a, double[] r, VmlMode mode)
            => vmdTan(a.Length, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsCospi(int n, float[] a, float[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Cospi(float[] a, float[] r)
            => vsCospi(a.Length, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdCospi(int n, double[] a, double[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Cospi(double[] a, double[] r)
            => vdCospi(a.Length, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsCospi(int n, float[] a, float[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Cospi(float[] a, float[] r, VmlMode mode)
            => vmsCospi(a.Length, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdCospi(int n, double[] a, double[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Cospi(double[] a, double[] r, VmlMode mode)
            => vmdCospi(a.Length, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsSinpi(int n, float[] a, float[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Sinpi(float[] a, float[] r)
            => vsSinpi(a.Length, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdSinpi(int n, double[] a, double[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Sinpi(double[] a, double[] r)
            => vdSinpi(a.Length, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsSinpi(int n, float[] a, float[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Sinpi(float[] a, float[] r, VmlMode mode)
            => vmsSinpi(a.Length, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdSinpi(int n, double[] a, double[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Sinpi(double[] a, double[] r, VmlMode mode)
            => vmdSinpi(a.Length, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsTanpi(int n, float[] a, float[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Tanpi(float[] a, float[] r)
            => vsTanpi(a.Length, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdTanpi(int n, double[] a, double[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Tanpi(double[] a, double[] r)
            => vdTanpi(a.Length, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsTanpi(int n, float[] a, float[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Tanpi(float[] a, float[] r, VmlMode mode)
            => vmsTanpi(a.Length, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdTanpi(int n, double[] a, double[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Tanpi(double[] a, double[] r, VmlMode mode)
            => vmdTanpi(a.Length, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsCosd(int n, float[] a, float[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Cosd(float[] a, float[] r)
            => vsCosd(a.Length, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdCosd(int n, double[] a, double[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Cosd(double[] a, double[] r)
            => vdCosd(a.Length, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsCosd(int n, float[] a, float[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Cosd(float[] a, float[] r, VmlMode mode)
            => vmsCosd(a.Length, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdCosd(int n, double[] a, double[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Cosd(double[] a, double[] r, VmlMode mode)
            => vmdCosd(a.Length, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsSind(int n, float[] a, float[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Sind(float[] a, float[] r)
            => vsSind(a.Length, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdSind(int n, double[] a, double[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Sind(double[] a, double[] r)
            => vdSind(a.Length, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsSind(int n, float[] a, float[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Sind(float[] a, float[] r, VmlMode mode)
            => vmsSind(a.Length, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdSind(int n, double[] a, double[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Sind(double[] a, double[] r, VmlMode mode)
            => vmdSind(a.Length, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsTand(int n, float[] a, float[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Tand(float[] a, float[] r)
            => vsTand(a.Length, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdTand(int n, double[] a, double[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Tand(double[] a, double[] r)
            => vdTand(a.Length, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsTand(int n, float[] a, float[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Tand(float[] a, float[] r, VmlMode mode)
            => vmsTand(a.Length, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdTand(int n, double[] a, double[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Tand(double[] a, double[] r, VmlMode mode)
            => vmdTand(a.Length, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsCosh(int n, float[] a, float[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Cosh(float[] a, float[] r)
            => vsCosh(a.Length, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdCosh(int n, double[] a, double[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Cosh(double[] a, double[] r)
            => vdCosh(a.Length, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsCosh(int n, float[] a, float[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Cosh(float[] a, float[] r, VmlMode mode)
            => vmsCosh(a.Length, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdCosh(int n, double[] a, double[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Cosh(double[] a, double[] r, VmlMode mode)
            => vmdCosh(a.Length, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsSinh(int n, float[] a, float[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Sinh(float[] a, float[] r)
            => vsSinh(a.Length, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdSinh(int n, double[] a, double[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Sinh(double[] a, double[] r)
            => vdSinh(a.Length, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsSinh(int n, float[] a, float[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Sinh(float[] a, float[] r, VmlMode mode)
            => vmsSinh(a.Length, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdSinh(int n, double[] a, double[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Sinh(double[] a, double[] r, VmlMode mode)
            => vmdSinh(a.Length, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsTanh(int n, float[] a, float[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Tanh(float[] a, float[] r)
            => vsTanh(a.Length, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdTanh(int n, double[] a, double[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Tanh(double[] a, double[] r)
            => vdTanh(a.Length, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsTanh(int n, float[] a, float[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Tanh(float[] a, float[] r, VmlMode mode)
            => vmsTanh(a.Length, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdTanh(int n, double[] a, double[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Tanh(double[] a, double[] r, VmlMode mode)
            => vmdTanh(a.Length, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsAcos(int n, float[] a, float[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Acos(float[] a, float[] r)
            => vsAcos(a.Length, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdAcos(int n, double[] a, double[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Acos(double[] a, double[] r)
            => vdAcos(a.Length, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsAcos(int n, float[] a, float[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Acos(float[] a, float[] r, VmlMode mode)
            => vmsAcos(a.Length, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdAcos(int n, double[] a, double[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Acos(double[] a, double[] r, VmlMode mode)
            => vmdAcos(a.Length, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsAsin(int n, float[] a, float[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Asin(float[] a, float[] r)
            => vsAsin(a.Length, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdAsin(int n, double[] a, double[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Asin(double[] a, double[] r)
            => vdAsin(a.Length, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsAsin(int n, float[] a, float[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Asin(float[] a, float[] r, VmlMode mode)
            => vmsAsin(a.Length, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdAsin(int n, double[] a, double[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Asin(double[] a, double[] r, VmlMode mode)
            => vmdAsin(a.Length, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsAtan(int n, float[] a, float[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Atan(float[] a, float[] r)
            => vsAtan(a.Length, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdAtan(int n, double[] a, double[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Atan(double[] a, double[] r)
            => vdAtan(a.Length, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsAtan(int n, float[] a, float[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Atan(float[] a, float[] r, VmlMode mode)
            => vmsAtan(a.Length, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdAtan(int n, double[] a, double[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Atan(double[] a, double[] r, VmlMode mode)
            => vmdAtan(a.Length, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsAcospi(int n, float[] a, float[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Acospi(float[] a, float[] r)
            => vsAcospi(a.Length, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdAcospi(int n, double[] a, double[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Acospi(double[] a, double[] r)
            => vdAcospi(a.Length, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsAcospi(int n, float[] a, float[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Acospi(float[] a, float[] r, VmlMode mode)
            => vmsAcospi(a.Length, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdAcospi(int n, double[] a, double[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Acospi(double[] a, double[] r, VmlMode mode)
            => vmdAcospi(a.Length, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsAsinpi(int n, float[] a, float[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Asinpi(float[] a, float[] r)
            => vsAsinpi(a.Length, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdAsinpi(int n, double[] a, double[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Asinpi(double[] a, double[] r)
            => vdAsinpi(a.Length, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsAsinpi(int n, float[] a, float[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Asinpi(float[] a, float[] r, VmlMode mode)
            => vmsAsinpi(a.Length, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdAsinpi(int n, double[] a, double[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Asinpi(double[] a, double[] r, VmlMode mode)
            => vmdAsinpi(a.Length, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsAtanpi(int n, float[] a, float[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Atanpi(float[] a, float[] r)
            => vsAtanpi(a.Length, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdAtanpi(int n, double[] a, double[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Atanpi(double[] a, double[] r)
            => vdAtanpi(a.Length, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsAtanpi(int n, float[] a, float[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Atanpi(float[] a, float[] r, VmlMode mode)
            => vmsAtanpi(a.Length, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdAtanpi(int n, double[] a, double[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Atanpi(double[] a, double[] r, VmlMode mode)
            => vmdAtanpi(a.Length, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsAcosh(int n, float[] a, float[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Acosh(float[] a, float[] r)
            => vsAcosh(a.Length, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdAcosh(int n, double[] a, double[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Acosh(double[] a, double[] r)
            => vdAcosh(a.Length, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsAcosh(int n, float[] a, float[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Acosh(float[] a, float[] r, VmlMode mode)
            => vmsAcosh(a.Length, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdAcosh(int n, double[] a, double[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Acosh(double[] a, double[] r, VmlMode mode)
            => vmdAcosh(a.Length, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsAsinh(int n, float[] a, float[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Asinh(float[] a, float[] r)
            => vsAsinh(a.Length, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdAsinh(int n, double[] a, double[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Asinh(double[] a, double[] r)
            => vdAsinh(a.Length, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsAsinh(int n, float[] a, float[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Asinh(float[] a, float[] r, VmlMode mode)
            => vmsAsinh(a.Length, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdAsinh(int n, double[] a, double[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Asinh(double[] a, double[] r, VmlMode mode)
            => vmdAsinh(a.Length, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsAtanh(int n, float[] a, float[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Atanh(float[] a, float[] r)
            => vsAtanh(a.Length, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdAtanh(int n, double[] a, double[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Atanh(double[] a, double[] r)
            => vdAtanh(a.Length, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsAtanh(int n, float[] a, float[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Atanh(float[] a, float[] r, VmlMode mode)
            => vmsAtanh(a.Length, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdAtanh(int n, double[] a, double[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Atanh(double[] a, double[] r, VmlMode mode)
            => vmdAtanh(a.Length, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsErf(int n, float[] a, float[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Erf(float[] a, float[] r)
            => vsErf(a.Length, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdErf(int n, double[] a, double[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Erf(double[] a, double[] r)
            => vdErf(a.Length, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsErf(int n, float[] a, float[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Erf(float[] a, float[] r, VmlMode mode)
            => vmsErf(a.Length, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdErf(int n, double[] a, double[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Erf(double[] a, double[] r, VmlMode mode)
            => vmdErf(a.Length, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsErfInv(int n, float[] a, float[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ErfInv(float[] a, float[] r)
            => vsErfInv(a.Length, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdErfInv(int n, double[] a, double[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ErfInv(double[] a, double[] r)
            => vdErfInv(a.Length, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsErfInv(int n, float[] a, float[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ErfInv(float[] a, float[] r, VmlMode mode)
            => vmsErfInv(a.Length, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdErfInv(int n, double[] a, double[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ErfInv(double[] a, double[] r, VmlMode mode)
            => vmdErfInv(a.Length, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsHypot(int n, float[] a, float[] b, float[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Hypot(float[] a, float[] b, float[] r)
            => vsHypot(a.Length, a, b, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdHypot(int n, double[] a, double[] b, double[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Hypot(double[] a, double[] b, double[] r)
            => vdHypot(a.Length, a, b, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsHypot(int n, float[] a, float[] b, float[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Hypot(float[] a, float[] b, float[] r, VmlMode mode)
            => vmsHypot(a.Length, a, b, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdHypot(int n, double[] a, double[] b, double[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Hypot(double[] a, double[] b, double[] r, VmlMode mode)
            => vmdHypot(a.Length, a, b, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsErfc(int n, float[] a, float[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Erfc(float[] a, float[] r)
            => vsErfc(a.Length, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdErfc(int n, double[] a, double[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Erfc(double[] a, double[] r)
            => vdErfc(a.Length, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsErfc(int n, float[] a, float[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Erfc(float[] a, float[] r, VmlMode mode)
            => vmsErfc(a.Length, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdErfc(int n, double[] a, double[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Erfc(double[] a, double[] r, VmlMode mode)
            => vmdErfc(a.Length, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsErfcInv(int n, float[] a, float[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ErfcInv(float[] a, float[] r)
            => vsErfcInv(a.Length, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdErfcInv(int n, double[] a, double[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ErfcInv(double[] a, double[] r)
            => vdErfcInv(a.Length, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsErfcInv(int n, float[] a, float[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ErfcInv(float[] a, float[] r, VmlMode mode)
            => vmsErfcInv(a.Length, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdErfcInv(int n, double[] a, double[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ErfcInv(double[] a, double[] r, VmlMode mode)
            => vmdErfcInv(a.Length, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsCdfNorm(int n, float[] a, float[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CdfNorm(float[] a, float[] r)
            => vsCdfNorm(a.Length, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdCdfNorm(int n, double[] a, double[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CdfNorm(double[] a, double[] r)
            => vdCdfNorm(a.Length, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsCdfNorm(int n, float[] a, float[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CdfNorm(float[] a, float[] r, VmlMode mode)
            => vmsCdfNorm(a.Length, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdCdfNorm(int n, double[] a, double[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CdfNorm(double[] a, double[] r, VmlMode mode)
            => vmdCdfNorm(a.Length, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsCdfNormInv(int n, float[] a, float[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CdfNormInv(float[] a, float[] r)
            => vsCdfNormInv(a.Length, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdCdfNormInv(int n, double[] a, double[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CdfNormInv(double[] a, double[] r)
            => vdCdfNormInv(a.Length, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsCdfNormInv(int n, float[] a, float[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CdfNormInv(float[] a, float[] r, VmlMode mode)
            => vmsCdfNormInv(a.Length, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdCdfNormInv(int n, double[] a, double[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CdfNormInv(double[] a, double[] r, VmlMode mode)
            => vmdCdfNormInv(a.Length, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsLGamma(int n, float[] a, float[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void LGamma(float[] a, float[] r)
            => vsLGamma(a.Length, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdLGamma(int n, double[] a, double[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void LGamma(double[] a, double[] r)
            => vdLGamma(a.Length, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsLGamma(int n, float[] a, float[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void LGamma(float[] a, float[] r, VmlMode mode)
            => vmsLGamma(a.Length, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdLGamma(int n, double[] a, double[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void LGamma(double[] a, double[] r, VmlMode mode)
            => vmdLGamma(a.Length, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsTGamma(int n, float[] a, float[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void TGamma(float[] a, float[] r)
            => vsTGamma(a.Length, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdTGamma(int n, double[] a, double[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void TGamma(double[] a, double[] r)
            => vdTGamma(a.Length, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsTGamma(int n, float[] a, float[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void TGamma(float[] a, float[] r, VmlMode mode)
            => vmsTGamma(a.Length, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdTGamma(int n, double[] a, double[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void TGamma(double[] a, double[] r, VmlMode mode)
            => vmdTGamma(a.Length, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsAtan2(int n, float[] a, float[] b, float[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Atan2(float[] a, float[] b, float[] r)
            => vsAtan2(a.Length, a, b, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdAtan2(int n, double[] a, double[] b, double[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Atan2(double[] a, double[] b, double[] r)
            => vdAtan2(a.Length, a, b, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsAtan2(int n, float[] a, float[] b, float[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Atan2(float[] a, float[] b, float[] r, VmlMode mode)
            => vmsAtan2(a.Length, a, b, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdAtan2(int n, double[] a, double[] b, double[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Atan2(double[] a, double[] b, double[] r, VmlMode mode)
            => vmdAtan2(a.Length, a, b, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsAtan2pi(int n, float[] a, float[] b, float[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Atan2pi(float[] a, float[] b, float[] r)
            => vsAtan2pi(a.Length, a, b, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdAtan2pi(int n, double[] a, double[] b, double[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Atan2pi(double[] a, double[] b, double[] r)
            => vdAtan2pi(a.Length, a, b, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsAtan2pi(int n, float[] a, float[] b, float[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Atan2pi(float[] a, float[] b, float[] r, VmlMode mode)
            => vmsAtan2pi(a.Length, a, b, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdAtan2pi(int n, double[] a, double[] b, double[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Atan2pi(double[] a, double[] b, double[] r, VmlMode mode)
            => vmdAtan2pi(a.Length, a, b, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsMul(int n, float[] a, float[] b, float[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Mul(float[] a, float[] b, float[] r)
            => vsMul(a.Length, a, b, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdMul(int n, double[] a, double[] b, double[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Mul(double[] a, double[] b, double[] r)
            => vdMul(a.Length, a, b, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsMul(int n, float[] a, float[] b, float[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Mul(float[] a, float[] b, float[] r, VmlMode mode)
            => vmsMul(a.Length, a, b, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdMul(int n, double[] a, double[] b, double[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Mul(double[] a, double[] b, double[] r, VmlMode mode)
            => vmdMul(a.Length, a, b, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsDiv(int n, float[] a, float[] b, float[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Div(float[] a, float[] b, float[] r)
            => vsDiv(a.Length, a, b, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdDiv(int n, double[] a, double[] b, double[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Div(double[] a, double[] b, double[] r)
            => vdDiv(a.Length, a, b, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsDiv(int n, float[] a, float[] b, float[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Div(float[] a, float[] b, float[] r, VmlMode mode)
            => vmsDiv(a.Length, a, b, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdDiv(int n, double[] a, double[] b, double[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Div(double[] a, double[] b, double[] r, VmlMode mode)
            => vmdDiv(a.Length, a, b, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsPow(int n, float[] a, float[] b, float[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Pow(float[] a, float[] b, float[] r)
            => vsPow(a.Length, a, b, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdPow(int n, double[] a, double[] b, double[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Pow(double[] a, double[] b, double[] r)
            => vdPow(a.Length, a, b, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsPow(int n, float[] a, float[] b, float[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Pow(float[] a, float[] b, float[] r, VmlMode mode)
            => vmsPow(a.Length, a, b, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdPow(int n, double[] a, double[] b, double[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Pow(double[] a, double[] b, double[] r, VmlMode mode)
            => vmdPow(a.Length, a, b, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsPow3o2(int n, float[] a, float[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Pow3o2(float[] a, float[] r)
            => vsPow3o2(a.Length, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdPow3o2(int n, double[] a, double[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Pow3o2(double[] a, double[] r)
            => vdPow3o2(a.Length, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsPow3o2(int n, float[] a, float[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Pow3o2(float[] a, float[] r, VmlMode mode)
            => vmsPow3o2(a.Length, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdPow3o2(int n, double[] a, double[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Pow3o2(double[] a, double[] r, VmlMode mode)
            => vmdPow3o2(a.Length, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsPow2o3(int n, float[] a, float[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Pow2o3(float[] a, float[] r)
            => vsPow2o3(a.Length, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdPow2o3(int n, double[] a, double[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Pow2o3(double[] a, double[] r)
            => vdPow2o3(a.Length, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsPow2o3(int n, float[] a, float[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Pow2o3(float[] a, float[] r, VmlMode mode)
            => vmsPow2o3(a.Length, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdPow2o3(int n, double[] a, double[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Pow2o3(double[] a, double[] r, VmlMode mode)
            => vmdPow2o3(a.Length, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsPowx(int n, float[] a, float b, float[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Powx(float[] a, float b, float[] r)
            => vsPowx(a.Length, a, b, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdPowx(int n, double[] a, double b, double[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Powx(double[] a, double b, double[] r)
            => vdPowx(a.Length, a, b, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsPowx(int n, float[] a, float b, float[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Powx(float[] a, float b, float[] r, VmlMode mode)
            => vmsPowx(a.Length, a, b, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdPowx(int n, double[] a, double b, double[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Powx(double[] a, double b, double[] r, VmlMode mode)
            => vmdPowx(a.Length, a, b, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsPowr(int n, float[] a, float[] b, float[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Powr(float[] a, float[] b, float[] r)
            => vsPowr(a.Length, a, b, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdPowr(int n, double[] a, double[] b, double[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Powr(double[] a, double[] b, double[] r)
            => vdPowr(a.Length, a, b, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsPowr(int n, float[] a, float[] b, float[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Powr(float[] a, float[] b, float[] r, VmlMode mode)
            => vmsPowr(a.Length, a, b, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdPowr(int n, double[] a, double[] b, double[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Powr(double[] a, double[] b, double[] r, VmlMode mode)
            => vmdPowr(a.Length, a, b, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsSinCos(int n, float[] a, float[] r1, float[] r2);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SinCos(float[] a, float[] r1, float[] r2)
            => vsSinCos(a.Length, a, r1, r2);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdSinCos(int n, double[] a, double[] r1, double[] r2);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SinCos(double[] a, double[] r1, double[] r2)
            => vdSinCos(a.Length, a, r1, r2);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsSinCos(int n, float[] a, float[] r1, float[] r2, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SinCos(float[] a, float[] r1, float[] r2, VmlMode mode)
            => vmsSinCos(a.Length, a, r1, r2, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdSinCos(int n, double[] a, double[] r1, double[] r2, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SinCos(double[] a, double[] r1, double[] r2, VmlMode mode)
            => vmdSinCos(a.Length, a, r1, r2, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsLinearFrac(int n, float[] a, float[] b, float scalea, float shifta, float scaleb, float shiftb, float[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void LinearFrac(float[] a, float[] b, float scalea, float shifta, float scaleb, float shiftb, float[] r)
            => vsLinearFrac(a.Length, a, b, scalea, shifta, scaleb, shiftb, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdLinearFrac(int n, double[] a, double[] b, double scalea, double shifta, double scaleb, double shiftb, double[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void LinearFrac(double[] a, double[] b, double scalea, double shifta, double scaleb, double shiftb, double[] r)
            => vdLinearFrac(a.Length, a, b, scalea, shifta, scaleb, shiftb, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsLinearFrac(int n, float[] a, float[] b, float scalea, float shifta, float scaleb, float shiftb, float[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void LinearFrac(float[] a, float[] b, float scalea, float shifta, float scaleb, float shiftb, float[] r, VmlMode mode)
            => vmsLinearFrac(a.Length, a, b, scalea, shifta, scaleb, shiftb, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdLinearFrac(int n, double[] a, double[] b, double scalea, double shifta, double scaleb, double shiftb, double[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void LinearFrac(double[] a, double[] b, double scalea, double shifta, double scaleb, double shiftb, double[] r, VmlMode mode)
            => vmdLinearFrac(a.Length, a, b, scalea, shifta, scaleb, shiftb, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsCeil(int n, float[] a, float[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Ceil(float[] a, float[] r)
            => vsCeil(a.Length, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdCeil(int n, double[] a, double[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Ceil(double[] a, double[] r)
            => vdCeil(a.Length, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsCeil(int n, float[] a, float[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Ceil(float[] a, float[] r, VmlMode mode)
            => vmsCeil(a.Length, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdCeil(int n, double[] a, double[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Ceil(double[] a, double[] r, VmlMode mode)
            => vmdCeil(a.Length, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsFloor(int n, float[] a, float[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Floor(float[] a, float[] r)
            => vsFloor(a.Length, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdFloor(int n, double[] a, double[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Floor(double[] a, double[] r)
            => vdFloor(a.Length, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsFloor(int n, float[] a, float[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Floor(float[] a, float[] r, VmlMode mode)
            => vmsFloor(a.Length, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdFloor(int n, double[] a, double[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Floor(double[] a, double[] r, VmlMode mode)
            => vmdFloor(a.Length, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsFrac(int n, float[] a, float[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Frac(float[] a, float[] r)
            => vsFrac(a.Length, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdFrac(int n, double[] a, double[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Frac(double[] a, double[] r)
            => vdFrac(a.Length, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsFrac(int n, float[] a, float[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Frac(float[] a, float[] r, VmlMode mode)
            => vmsFrac(a.Length, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdFrac(int n, double[] a, double[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Frac(double[] a, double[] r, VmlMode mode)
            => vmdFrac(a.Length, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsModf(int n, float[] a, float[] r1, float[] r2);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Modf(float[] a, float[] r1, float[] r2)
            => vsModf(a.Length, a, r1, r2);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdModf(int n, double[] a, double[] r1, double[] r2);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Modf(double[] a, double[] r1, double[] r2)
            => vdModf(a.Length, a, r1, r2);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsModf(int n, float[] a, float[] r1, float[] r2, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Modf(float[] a, float[] r1, float[] r2, VmlMode mode)
            => vmsModf(a.Length, a, r1, r2, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdModf(int n, double[] a, double[] r1, double[] r2, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Modf(double[] a, double[] r1, double[] r2, VmlMode mode)
            => vmdModf(a.Length, a, r1, r2, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsFmod(int n, float[] a, float[] b, float[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Fmod(float[] a, float[] b, float[] r)
            => vsFmod(a.Length, a, b, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdFmod(int n, double[] a, double[] b, double[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Fmod(double[] a, double[] b, double[] r)
            => vdFmod(a.Length, a, b, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsFmod(int n, float[] a, float[] b, float[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Fmod(float[] a, float[] b, float[] r, VmlMode mode)
            => vmsFmod(a.Length, a, b, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdFmod(int n, double[] a, double[] b, double[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Fmod(double[] a, double[] b, double[] r, VmlMode mode)
            => vmdFmod(a.Length, a, b, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsRemainder(int n, float[] a, float[] b, float[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Remainder(float[] a, float[] b, float[] r)
            => vsRemainder(a.Length, a, b, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdRemainder(int n, double[] a, double[] b, double[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Remainder(double[] a, double[] b, double[] r)
            => vdRemainder(a.Length, a, b, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsRemainder(int n, float[] a, float[] b, float[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Remainder(float[] a, float[] b, float[] r, VmlMode mode)
            => vmsRemainder(a.Length, a, b, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdRemainder(int n, double[] a, double[] b, double[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Remainder(double[] a, double[] b, double[] r, VmlMode mode)
            => vmdRemainder(a.Length, a, b, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsNextAfter(int n, float[] a, float[] b, float[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void NextAfter(float[] a, float[] b, float[] r)
            => vsNextAfter(a.Length, a, b, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdNextAfter(int n, double[] a, double[] b, double[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void NextAfter(double[] a, double[] b, double[] r)
            => vdNextAfter(a.Length, a, b, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsNextAfter(int n, float[] a, float[] b, float[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void NextAfter(float[] a, float[] b, float[] r, VmlMode mode)
            => vmsNextAfter(a.Length, a, b, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdNextAfter(int n, double[] a, double[] b, double[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void NextAfter(double[] a, double[] b, double[] r, VmlMode mode)
            => vmdNextAfter(a.Length, a, b, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsCopySign(int n, float[] a, float[] b, float[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CopySign(float[] a, float[] b, float[] r)
            => vsCopySign(a.Length, a, b, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdCopySign(int n, double[] a, double[] b, double[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CopySign(double[] a, double[] b, double[] r)
            => vdCopySign(a.Length, a, b, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsCopySign(int n, float[] a, float[] b, float[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CopySign(float[] a, float[] b, float[] r, VmlMode mode)
            => vmsCopySign(a.Length, a, b, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdCopySign(int n, double[] a, double[] b, double[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CopySign(double[] a, double[] b, double[] r, VmlMode mode)
            => vmdCopySign(a.Length, a, b, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsFdim(int n, float[] a, float[] b, float[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Fdim(float[] a, float[] b, float[] r)
            => vsFdim(a.Length, a, b, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdFdim(int n, double[] a, double[] b, double[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Fdim(double[] a, double[] b, double[] r)
            => vdFdim(a.Length, a, b, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsFdim(int n, float[] a, float[] b, float[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Fdim(float[] a, float[] b, float[] r, VmlMode mode)
            => vmsFdim(a.Length, a, b, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdFdim(int n, double[] a, double[] b, double[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Fdim(double[] a, double[] b, double[] r, VmlMode mode)
            => vmdFdim(a.Length, a, b, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsFmax(int n, float[] a, float[] b, float[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Fmax(float[] a, float[] b, float[] r)
            => vsFmax(a.Length, a, b, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdFmax(int n, double[] a, double[] b, double[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Fmax(double[] a, double[] b, double[] r)
            => vdFmax(a.Length, a, b, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsFmax(int n, float[] a, float[] b, float[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Fmax(float[] a, float[] b, float[] r, VmlMode mode)
            => vmsFmax(a.Length, a, b, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdFmax(int n, double[] a, double[] b, double[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Fmax(double[] a, double[] b, double[] r, VmlMode mode)
            => vmdFmax(a.Length, a, b, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsFmin(int n, float[] a, float[] b, float[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Fmin(float[] a, float[] b, float[] r)
            => vsFmin(a.Length, a, b, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdFmin(int n, double[] a, double[] b, double[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Fmin(double[] a, double[] b, double[] r)
            => vdFmin(a.Length, a, b, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsFmin(int n, float[] a, float[] b, float[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Fmin(float[] a, float[] b, float[] r, VmlMode mode)
            => vmsFmin(a.Length, a, b, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdFmin(int n, double[] a, double[] b, double[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Fmin(double[] a, double[] b, double[] r, VmlMode mode)
            => vmdFmin(a.Length, a, b, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsMaxMag(int n, float[] a, float[] b, float[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void MaxMag(float[] a, float[] b, float[] r)
            => vsMaxMag(a.Length, a, b, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdMaxMag(int n, double[] a, double[] b, double[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void MaxMag(double[] a, double[] b, double[] r)
            => vdMaxMag(a.Length, a, b, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsMaxMag(int n, float[] a, float[] b, float[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void MaxMag(float[] a, float[] b, float[] r, VmlMode mode)
            => vmsMaxMag(a.Length, a, b, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdMaxMag(int n, double[] a, double[] b, double[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void MaxMag(double[] a, double[] b, double[] r, VmlMode mode)
            => vmdMaxMag(a.Length, a, b, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsMinMag(int n, float[] a, float[] b, float[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void MinMag(float[] a, float[] b, float[] r)
            => vsMinMag(a.Length, a, b, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdMinMag(int n, double[] a, double[] b, double[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void MinMag(double[] a, double[] b, double[] r)
            => vdMinMag(a.Length, a, b, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsMinMag(int n, float[] a, float[] b, float[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void MinMag(float[] a, float[] b, float[] r, VmlMode mode)
            => vmsMinMag(a.Length, a, b, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdMinMag(int n, double[] a, double[] b, double[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void MinMag(double[] a, double[] b, double[] r, VmlMode mode)
            => vmdMinMag(a.Length, a, b, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsNearbyInt(int n, float[] a, float[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void NearbyInt(float[] a, float[] r)
            => vsNearbyInt(a.Length, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdNearbyInt(int n, double[] a, double[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void NearbyInt(double[] a, double[] r)
            => vdNearbyInt(a.Length, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsNearbyInt(int n, float[] a, float[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void NearbyInt(float[] a, float[] r, VmlMode mode)
            => vmsNearbyInt(a.Length, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdNearbyInt(int n, double[] a, double[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void NearbyInt(double[] a, double[] r, VmlMode mode)
            => vmdNearbyInt(a.Length, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsRint(int n, float[] a, float[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Rint(float[] a, float[] r)
            => vsRint(a.Length, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdRint(int n, double[] a, double[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Rint(double[] a, double[] r)
            => vdRint(a.Length, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsRint(int n, float[] a, float[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Rint(float[] a, float[] r, VmlMode mode)
            => vmsRint(a.Length, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdRint(int n, double[] a, double[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Rint(double[] a, double[] r, VmlMode mode)
            => vmdRint(a.Length, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsRound(int n, float[] a, float[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Round(float[] a, float[] r)
            => vsRound(a.Length, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdRound(int n, double[] a, double[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Round(double[] a, double[] r)
            => vdRound(a.Length, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsRound(int n, float[] a, float[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Round(float[] a, float[] r, VmlMode mode)
            => vmsRound(a.Length, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdRound(int n, double[] a, double[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Round(double[] a, double[] r, VmlMode mode)
            => vmdRound(a.Length, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsTrunc(int n, float[] a, float[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Trunc(float[] a, float[] r)
            => vsTrunc(a.Length, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdTrunc(int n, double[] a, double[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Trunc(double[] a, double[] r)
            => vdTrunc(a.Length, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsTrunc(int n, float[] a, float[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Trunc(float[] a, float[] r, VmlMode mode)
            => vmsTrunc(a.Length, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdTrunc(int n, double[] a, double[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Trunc(double[] a, double[] r, VmlMode mode)
            => vmdTrunc(a.Length, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsExpInt1(int n, float[] a, float[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ExpInt1(float[] a, float[] r)
            => vsExpInt1(a.Length, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vdExpInt1(int n, double[] a, double[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ExpInt1(double[] a, double[] r)
            => vdExpInt1(a.Length, a, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmsExpInt1(int n, float[] a, float[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ExpInt1(float[] a, float[] r, VmlMode mode)
            => vmsExpInt1(a.Length, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vmdExpInt1(int n, double[] a, double[] r, VmlMode mode);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ExpInt1(double[] a, double[] r, VmlMode mode)
            => vmdExpInt1(a.Length, a, r, mode);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern void vsAbsI(int n, float* a, int inca, float* r, int incr);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void AbsI(int n, float[] a, int inia, int inca, float[] r, int inir, int incr)
        {
            fixed (float* ap = &a[inia])
            fixed (float* rp = &r[inir])
            {
                vsAbsI(n, ap, inca, rp, incr);
            }
        }

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