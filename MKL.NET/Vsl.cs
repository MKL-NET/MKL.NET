using System;
using System.Security;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;

namespace MKLNET
{
    [SuppressUnmanagedCodeSecurity]
    public static class Vsl
    {
#if LINUX
        const string DLL = "libmkl_rt.so";
#elif OSX
        const string DLL = "libmkl_rt.dylib";
#else
        const string DLL = "mkl_rt.dll";
#endif

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int vdRngCauchy(VslMethodCauchy method, VslStream stream, int n, double[] r, double a, double beta);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dRngCauchy(VslMethodCauchy method, VslStream stream, int n, double[] r, double a, double beta)
            => vdRngCauchy(method, stream, n, r, a, beta);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int vsRngCauchy(VslMethodCauchy method, VslStream stream, int n, float[] r, float a, float beta);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sRngCauchy(VslMethodCauchy method, VslStream stream, int n, float[] r, float a, float beta)
            => vsRngCauchy(method, stream, n, r, a, beta);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int vdRngUniform(VslMethodUniform method, VslStream stream, int n, double[] r, double a, double b);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dRngUniform(VslMethodUniform method, VslStream stream, int n, double[] r, double a, double b)
            => vdRngUniform(method, stream, n, r, a, b);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int vsRngUniform(VslMethodUniform method, VslStream stream, int n, float[] r, float a, float b);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sRngUniform(VslMethodUniform method, VslStream stream, int n, float[] r, float a, float b)
            => vsRngUniform(method, stream, n, r, a, b);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int vdRngGaussian(VslMethodGaussian method, VslStream stream, int n, double[] r, double mean, double sigma);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dRngGaussian(VslMethodGaussian method, VslStream stream, int n, double[] r, double mean, double sigma)
            => vdRngGaussian(method, stream, n, r, mean, sigma);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int vsRngGaussian(VslMethodGaussian method, VslStream stream, int n, float[] r, float mean, float sigma);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sRngGaussian(VslMethodGaussian method, VslStream stream, int n, float[] r, float mean, float sigma)
            => vsRngGaussian(method, stream, n, r, mean, sigma);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int vdRngGaussianMV(VslMethodGaussian method, VslStream stream, int n, double[] r, int dimen, int mstorage, double[] a, double[] t);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dRngGaussianMV(VslMethodGaussian method, VslStream stream, int n, double[] r, int dimen, int mstorage, double[] a, double[] t)
            => vdRngGaussianMV(method, stream, n, r, dimen, mstorage, a, t);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int vsRngGaussianMV(VslMethodGaussian method, VslStream stream, int n, float[] r, int dimen, int mstorage, float[] a, float[] t);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sRngGaussianMV(VslMethodGaussian method, VslStream stream, int n, float[] r, int dimen, int mstorage, float[] a, float[] t)
            => vsRngGaussianMV(method, stream, n, r, dimen, mstorage, a, t);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int vdRngExponential(VslMethodExponential method, VslStream stream, int n, double[] r, double a, double beta);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dRngExponential(VslMethodExponential method, VslStream stream, int n, double[] r, double a, double beta)
            => vdRngExponential(method, stream, n, r, a, beta);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int vsRngExponential(VslMethodExponential method, VslStream stream, int n, float[] r, float a, float beta);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sRngExponential(VslMethodExponential method, VslStream stream, int n, float[] r, float a, float beta)
            => vsRngExponential(method, stream, n, r, a, beta);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int vdRngLaplace(VslMethodLaplace method, VslStream stream, int n, double[] r, double a, double beta);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dRngLaplace(VslMethodLaplace method, VslStream stream, int n, double[] r, double a, double beta)
            => vdRngLaplace(method, stream, n, r, a, beta);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int vsRngLaplace(VslMethodLaplace method, VslStream stream, int n, float[] r, float a, float beta);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sRngLaplace(VslMethodLaplace method, VslStream stream, int n, float[] r, float a, float beta)
            => vsRngLaplace(method, stream, n, r, a, beta);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int vdRngWeibull(VslMethodWeibull method, VslStream stream, int n, double[] r, double alpha, double a, double beta);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dRngWeibull(VslMethodWeibull method, VslStream stream, int n, double[] r, double alpha, double a, double beta)
            => vdRngWeibull(method, stream, n, r, alpha, a, beta);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int vsRngWeibull(VslMethodWeibull method, VslStream stream, int n, float[] r, float alpha, float a, float beta);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sRngWeibull(VslMethodWeibull method, VslStream stream, int n, float[] r, float alpha, float a, float beta)
            => vsRngWeibull(method, stream, n, r, alpha, a, beta);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int vdRngRayleigh(VslMethodRayleigh method, VslStream stream, int n, double[] r, double a, double beta);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dRngRayleigh(VslMethodRayleigh method, VslStream stream, int n, double[] r, double a, double beta)
            => vdRngRayleigh(method, stream, n, r, a, beta);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int vsRngRayleigh(VslMethodRayleigh method, VslStream stream, int n, float[] r, float a, float beta);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sRngRayleigh(VslMethodRayleigh method, VslStream stream, int n, float[] r, float a, float beta)
            => vsRngRayleigh(method, stream, n, r, a, beta);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int vdRngLognormal(VslMethodLognormal method, VslStream stream, int n, double[] r, double a, double sigma, double b, double beta);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dRngLognormal(VslMethodLognormal method, VslStream stream, int n, double[] r, double a, double sigma, double b, double beta)
            => vdRngLognormal(method, stream, n, r, a, sigma, b, beta);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int vsRngLognormal(VslMethodLognormal method, VslStream stream, int n, float[] r, float a, float sigma, float b, float beta);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sRngLognormal(VslMethodLognormal method, VslStream stream, int n, float[] r, float a, float sigma, float b, float beta)
            => vsRngLognormal(method, stream, n, r, a, sigma, b, beta);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int vdRngGumbel(VslMethodGumbel method, VslStream stream, int n, double[] r, double a, double beta);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dRngGumbel(VslMethodGumbel method, VslStream stream, int n, double[] r, double a, double beta)
            => vdRngGumbel(method, stream, n, r, a, beta);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int vsRngGumbel(VslMethodGumbel method, VslStream stream, int n, float[] r, float a, float beta);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sRngGumbel(VslMethodGumbel method, VslStream stream, int n, float[] r, float a, float beta)
            => vsRngGumbel(method, stream, n, r, a, beta);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int vdRngGamma(VslMethodGamma method, VslStream stream, int n, double[] r, double alpha, double a, double beta);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dRngGamma(VslMethodGamma method, VslStream stream, int n, double[] r, double alpha, double a, double beta)
            => vdRngGamma(method, stream, n, r, alpha, a, beta);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int vsRngGamma(VslMethodGamma method, VslStream stream, int n, float[] r, float alpha, float a, float beta);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sRngGamma(VslMethodGamma method, VslStream stream, int n, float[] r, float alpha, float a, float beta)
            => vsRngGamma(method, stream, n, r, alpha, a, beta);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int vdRngBeta(VslMethodBeta method, VslStream stream, int n, double[] r, double p, double q, double a, double beta);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dRngBeta(VslMethodBeta method, VslStream stream, int n, double[] r, double p, double q, double a, double beta)
            => vdRngBeta(method, stream, n, r, p, q, a, beta);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int vsRngBeta(VslMethodBeta method, VslStream stream, int n, float[] r, float p, float q, float a, float beta);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sRngBeta(VslMethodBeta method, VslStream stream, int n, float[] r, float p, float q, float a, float beta)
            => vsRngBeta(method, stream, n, r, p, q, a, beta);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int vdRngChiSquare(VslMethodChiSquare method, VslStream stream, int n, double[] r, int v);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dRngChiSquare(VslMethodChiSquare method, VslStream stream, int n, double[] r, int v)
            => vdRngChiSquare(method, stream, n, r, v);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int vsRngChiSquare(VslMethodChiSquare method, VslStream stream, int n, float[] r, int v);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sRngChiSquare(VslMethodChiSquare method, VslStream stream, int n, float[] r, int v)
            => vsRngChiSquare(method, stream, n, r, v);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int viRngBernoulli(VslMethodBernoulli method, VslStream stream, int n, int[] r, double p);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int iRngBernoulli(VslMethodBernoulli method, VslStream stream, int n, int[] r, double p)
            => viRngBernoulli(method, stream, n, r, p);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int viRngUniform(VslMethodUniform method, VslStream stream, int n, int[] r, int a, int b);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int iRngUniform(VslMethodUniform method, VslStream stream, int n, int[] r, int a, int b)
            => viRngUniform(method, stream, n, r, a, b);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int viRngUniformBits(VslMethodUniformBits method, VslStream stream, int n, uint[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int iRngUniformBits(VslMethodUniformBits method, VslStream stream, int n, uint[] r)
            => viRngUniformBits(method, stream, n, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int viRngUniformBits32(VslMethodUniformBits method, VslStream stream, int n, uint[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int iRngUniformBits32(VslMethodUniformBits method, VslStream stream, int n, uint[] r)
            => viRngUniformBits32(method, stream, n, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int viRngUniformBits64(VslMethodUniformBits method, VslStream stream, int n, ulong[] r);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int iRngUniformBits64(VslMethodUniformBits method, VslStream stream, int n, ulong[] r)
            => viRngUniformBits64(method, stream, n, r);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int viRngGeometric(VslMethodGeometric method, VslStream stream, int n, int[] r, double p);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int iRngGeometric(VslMethodGeometric method, VslStream stream, int n, int[] r, double p)
            => viRngGeometric(method, stream, n, r, p);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int viRngBinomial(VslMethodBinomial method, VslStream stream, int n, int[] r, int ntrial, double p);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int iRngBinomial(VslMethodBinomial method, VslStream stream, int n, int[] r, int ntrial, double p)
            => viRngBinomial(method, stream, n, r, ntrial, p);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int viRngMultinomial(VslMethodMultinomial method, VslStream stream, int n, int[] r, int ntrial, int k, double[] p);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int iRngMultinomial(VslMethodMultinomial method, VslStream stream, int n, int[] r, int ntrial, int k, double[] p)
            => viRngMultinomial(method, stream, n, r, ntrial, k, p);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int viRngHypergeometric(VslMethodHypergeometric method, VslStream stream, int n, int[] r, int l, int s, int m);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int iRngHypergeometric(VslMethodHypergeometric method, VslStream stream, int n, int[] r, int l, int s, int m)
            => viRngHypergeometric(method, stream, n, r, l, s, m);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int viRngNegBinomial(VslMethodNegBinomial method, VslStream stream, int n, int[] r, double a, double p);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int iRngNegBinomial(VslMethodNegBinomial method, VslStream stream, int n, int[] r, double a, double p)
            => viRngNegBinomial(method, stream, n, r, a, p);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int viRngPoisson(VslMethodPoisson method, VslStream stream, int n, int[] r, double lambda);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int iRngPoisson(VslMethodPoisson method, VslStream stream, int n, int[] r, double lambda)
            => viRngPoisson(method, stream, n, r, lambda);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int viRngPoissonV(VslMethodPoissonV method, VslStream stream, int n, int[] r, double[] lambda);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int iRngPoissonV(VslMethodPoissonV method, VslStream stream, int n, int[] r, double[] lambda)
            => viRngPoissonV(method, stream, n, r, lambda);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int vslNewStream(out VslStream stream, VslBrng brng, uint seed);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int NewStream(out VslStream stream, VslBrng brng, uint seed)
            => vslNewStream(out stream, brng, seed);
        public static VslStream NewStream(VslBrng brng, uint seed)
        {
            int status = NewStream(out var stream, brng, seed);
            if (status != 0) throw new Exception("Non zero status: " + status);
            return stream;
        }

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int vslNewStreamEx(out VslStream stream, VslBrng brng, uint seed, uint[] param);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int NewStreamEx(out VslStream stream, VslBrng brng, uint seed, uint[] param)
            => vslNewStreamEx(out stream, brng, seed, param);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int vslDeleteStream(ref VslStream stream);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int DeleteStream(VslStream stream)
            => vslDeleteStream(ref stream);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int vslCopyStream(out VslStream newstream, VslStream srcstream);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int CopyStream(out VslStream newstream, VslStream srcstream)
            => vslCopyStream(out newstream, srcstream);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int vslCopyStreamState(out VslStream deststream, VslStream srcstream);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int CopyStreamState(out VslStream deststream, VslStream srcstream)
            => vslCopyStreamState(out deststream, srcstream);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int vslLeapfrogStream(VslStream stream, int k, int nstreams);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int LeapfrogStream(VslStream stream, int k, int nstreams)
            => vslLeapfrogStream(stream, k, nstreams);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int vslSkipAheadStream(VslStream stream, int nskip);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SkipAheadStream(VslStream stream, int nskip)
            => vslSkipAheadStream(stream, nskip);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int vslSkipAheadStreamEx(VslStream stream, int n, ulong[] nskip);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SkipAheadStreamEx(VslStream stream, int n, ulong[] nskip)
            => vslSkipAheadStreamEx(stream, n, nskip);

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        static extern int vslGetStreamStateBrng(VslStream stream);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetStreamStateBrng(VslStream stream)
            => vslGetStreamStateBrng(stream);

        //_Mkl_Api(int, vsldConvNewTask, (VSLConvTaskPtr*, int  , int  , int[], int[], int[]))
        //_Mkl_Api(int, vslsConvNewTask, (VSLConvTaskPtr*, int  , int  , int[], int[], int[]))
        //_Mkl_Api(int, vsldCorrNewTask, (VSLCorrTaskPtr*, int  , int  , int[], int[], int[]))
        //_Mkl_Api(int, vslsCorrNewTask, (VSLCorrTaskPtr*, int  , int  , int[], int[], int[]))
        //_Mkl_Api(int, vsldConvNewTask1D, (VSLConvTaskPtr*, int  , int  , int ,  int  ))
        //_Mkl_Api(int, vslsConvNewTask1D, (VSLConvTaskPtr*, int  , int  , int ,  int  ))
        //_Mkl_Api(int, vsldCorrNewTask1D, (VSLCorrTaskPtr*, int  , int  , int ,  int  ))
        //_Mkl_Api(int, vslsCorrNewTask1D, (VSLCorrTaskPtr*, int  , int  , int ,  int  ))
        //_Mkl_Api(int, vsldConvNewTaskX, (VSLConvTaskPtr*, int  , int  , int[], int[], int[], double[], int[]))
        //_Mkl_Api(int, vslsConvNewTaskX, (VSLConvTaskPtr*, int  , int  , int[], int[], int[], float[],  int[]))
        //_Mkl_Api(int, vsldCorrNewTaskX, (VSLCorrTaskPtr*, int  , int  , int[], int[], int[], double[], int[]))
        //_Mkl_Api(int, vslsCorrNewTaskX, (VSLCorrTaskPtr*, int  , int  , int[], int[], int[], float[],  int[]))
        //_Mkl_Api(int, vsldConvNewTaskX1D, (VSLConvTaskPtr*, int  , int  , int  , int  , double[], int  ))
        //_Mkl_Api(int, vslsConvNewTaskX1D, (VSLConvTaskPtr*, int  , int  , int  , int  , float[],  int  ))
        //_Mkl_Api(int, vsldCorrNewTaskX1D, (VSLCorrTaskPtr*, int  , int  , int  , int  , double[], int  ))
        //_Mkl_Api(int, vslsCorrNewTaskX1D, (VSLCorrTaskPtr*, int  , int  , int  , int  , float[],  int  ))
        //_Mkl_Api(int, vslConvDeleteTask, (VSLConvTaskPtr* ))
        //_Mkl_Api(int, vslCorrDeleteTask, (VSLCorrTaskPtr* ))
        //_Mkl_Api(int, vslConvCopyTask, (VSLConvTaskPtr*, VSLConvTaskPtr  ))
        //_Mkl_Api(int, vslCorrCopyTask, (VSLCorrTaskPtr*, VSLCorrTaskPtr  ))
        //_Mkl_Api(int, vslConvSetMode, (VSLConvTaskPtr, int  ))
        //_Mkl_Api(int, vslCorrSetMode, (VSLCorrTaskPtr, int  ))
        //_Mkl_Api(int, vslConvSetInternalPrecision, (VSLConvTaskPtr, int  ))
        //_Mkl_Api(int, vslCorrSetInternalPrecision, (VSLCorrTaskPtr, int  ))
        //_Mkl_Api(int, vslConvSetStart, (VSLConvTaskPtr, int[]))
        //_Mkl_Api(int, vslCorrSetStart, (VSLCorrTaskPtr, int[]))
        //_Mkl_Api(int, vslConvSetDecimation, (VSLConvTaskPtr, int[]))
        //_Mkl_Api(int, vslCorrSetDecimation, (VSLCorrTaskPtr, int[]))
        //_Mkl_Api(int, vsldConvExec, (VSLConvTaskPtr, double[], int[], double[], int[], double[], int[]))
        //_Mkl_Api(int, vslsConvExec, (VSLConvTaskPtr, float[],  int[], float[],  int[], float[],  int[]))
        //_Mkl_Api(int, vsldCorrExec, (VSLCorrTaskPtr, double[], int[], double[], int[], double[], int[]))
        //_Mkl_Api(int, vslsCorrExec, (VSLCorrTaskPtr, float[],  int[], float[],  int[], float[],  int[]))
        //_Mkl_Api(int, vsldConvExec1D, (VSLConvTaskPtr, double[], int  , double[], int  , double[], int  ))
        //_Mkl_Api(int, vslsConvExec1D, (VSLConvTaskPtr, float[],  int  , float[],  int  , float[],  int  ))
        //_Mkl_Api(int, vsldCorrExec1D, (VSLCorrTaskPtr, double[], int  , double[], int  , double[], int  ))
        //_Mkl_Api(int, vslsCorrExec1D, (VSLCorrTaskPtr, float[],  int  , float[],  int  , float[],  int  ))
        //_Mkl_Api(int, vsldConvExecX, (VSLConvTaskPtr, double[], int[], double[], int[]))
        //_Mkl_Api(int, vslsConvExecX, (VSLConvTaskPtr, float[],  int[], float[],  int[]))
        //_Mkl_Api(int, vsldCorrExecX, (VSLCorrTaskPtr, double[], int[], double[], int[]))
        //_Mkl_Api(int, vslsCorrExecX, (VSLCorrTaskPtr, float[],  int[], float[],  int[]))
        //_Mkl_Api(int, vsldConvExecX1D, (VSLConvTaskPtr, double[], int  , double[], int  ))
        //_Mkl_Api(int, vslsConvExecX1D, (VSLConvTaskPtr, float[],  int  , float[],  int  ))
        //_Mkl_Api(int, vsldCorrExecX1D, (VSLCorrTaskPtr, double[], int  , double[], int  ))
        //_Mkl_Api(int, vslsCorrExecX1D, (VSLCorrTaskPtr, float[],  int  , float[],  int  ))
        //_Mkl_Api(int, vsldSSNewTask, (VSLSSTaskPtr*, int* , int* , int* , double[], double[], int[]))
        //_Mkl_Api(int, vslsSSNewTask, (VSLSSTaskPtr*, int* , int* , int* , float[], float[], int[]))
        //_Mkl_Api(int, vsldSSEditTask, (VSLSSTaskPtr, int  , double* ))
        //_Mkl_Api(int, vslsSSEditTask, (VSLSSTaskPtr, int  , float* ))
        //_Mkl_Api(int, vsliSSEditTask, (VSLSSTaskPtr, int  , int* ))
        //_Mkl_Api(int, vsldSSEditMoments, (VSLSSTaskPtr, double*, double*, double*, double*, double*, double*, double*))
        //_Mkl_Api(int, vslsSSEditMoments, (VSLSSTaskPtr, float*, float*, float*, float*, float*, float*, float*))
        //_Mkl_Api(int, vsldSSEditSums, (VSLSSTaskPtr, double*, double*, double*, double*, double*, double*, double*))
        //_Mkl_Api(int, vslsSSEditSums, (VSLSSTaskPtr, float*, float*, float*, float*, float*, float*, float*))
        //_Mkl_Api(int, vsldSSEditCovCor, (VSLSSTaskPtr, double*, double*,  int* , double* , int* ))
        //_Mkl_Api(int, vslsSSEditCovCor, (VSLSSTaskPtr, float*, float*, int* , float* , int* ))
        //_Mkl_Api(int, vsldSSEditCP, (VSLSSTaskPtr, double*, double*, double*, int* ))
        //_Mkl_Api(int, vslsSSEditCP, (VSLSSTaskPtr, float*, float*, float*, int* ))
        //_Mkl_Api(int, vsldSSEditPartialCovCor, (VSLSSTaskPtr, int[], double* , int* , double* , int* , double* , int* , double* , int* ))
        //_Mkl_Api(int, vslsSSEditPartialCovCor, (VSLSSTaskPtr, int[], float* , int* , float* , int* , float* ,  int* , float* ,  int* ))
        //_Mkl_Api(int, vsldSSEditQuantiles, (VSLSSTaskPtr, int* , double* , double* , double* , int* ))
        //_Mkl_Api(int, vslsSSEditQuantiles, (VSLSSTaskPtr, int* , float* , float* , float* , int* ))
        //_Mkl_Api(int, vsldSSEditStreamQuantiles, (VSLSSTaskPtr, int* , double* , double* , int* , double* ))
        //_Mkl_Api(int, vslsSSEditStreamQuantiles, (VSLSSTaskPtr, int* , float* , float* , int* , float* ))
        //_Mkl_Api(int, vsldSSEditPooledCovariance, (VSLSSTaskPtr, int* , double* , double* , int* , double* , double* ))
        //_Mkl_Api(int, vslsSSEditPooledCovariance, (VSLSSTaskPtr, int* , float* , float* , int* , float* , float* ))
        //_Mkl_Api(int, vsldSSEditRobustCovariance, (VSLSSTaskPtr, int* , int* ,  double* , double* , double* ))
        //_Mkl_Api(int, vslsSSEditRobustCovariance, (VSLSSTaskPtr, int* , int* ,  float* , float* , float* ))
        //_Mkl_Api(int, vsldSSEditOutliersDetection, (VSLSSTaskPtr, int* , double* , double* ))
        //_Mkl_Api(int, vslsSSEditOutliersDetection, (VSLSSTaskPtr, int* , float* , float* ))
        //_Mkl_Api(int, vsldSSEditMissingValues, (VSLSSTaskPtr, int* , double* , int* , double* , int* , double* , int* , double* , int* , double* ))
        //_Mkl_Api(int, vslsSSEditMissingValues, (VSLSSTaskPtr, int* , float* , int* , float* , int* , float* , int* , float* , int* , float* ))
        //_Mkl_Api(int, vsldSSEditCorParameterization, (VSLSSTaskPtr, double* , int* , double* , int* ))
        //_Mkl_Api(int, vslsSSEditCorParameterization, (VSLSSTaskPtr, float* , int* , float* , int* ))
        //_Mkl_Api(int, vsldSSCompute, (VSLSSTaskPtr, unsigned int64, int  ))
        //_Mkl_Api(int, vslsSSCompute, (VSLSSTaskPtr, unsigned int64, int  ))
        //_Mkl_Api(int, vslSSDeleteTask, (VSLSSTaskPtr* ))
    }
}