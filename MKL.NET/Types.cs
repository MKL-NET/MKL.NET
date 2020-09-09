using System;

namespace MKLNET
{
    public enum Layout
    {
        RowMajor = 101,
        ColMajor = 102,
    }

    public enum Transpose
    {
        No = 111,
        Yes = 112,
    }

    public enum TransChar : byte
    {
        No = (byte)'N',
        Yes = (byte)'T',
    }

    public enum Diag
    {
        NonUnit = 131,
        Unit = 132,
    }

    public enum DiagChar : byte
    {
        NonUnit = (byte)'N',
        Unit = (byte)'U',
    }

    public enum Side
    {
        Left = 141,
        Right = 142,
    }

    public enum UpLo : byte
    {
        Lower = (byte)'L',
        Upper = (byte)'U',
    }

    public enum Norm : byte
    {
        // Largest absolute value of the matrix.
        MaxAbs = (byte)'M',
        // 1-norm of the matrix (maximum column sum).
        One = (byte)'1',
        // Infinity norm of the matrix (maximum row sum).
        Inf = (byte)'I',
        // Frobenius norm of the matrix (square root of sum of squares).
        Frobenius = (byte)'F',
    }

    unsafe internal struct MKLVersion_
    {
        public int MajorVersion;
        public int MinorVersion;
        public int UpdateVersion;
        public sbyte* ProductStatus;
        public sbyte* Build;
        public sbyte* Processor;
        public sbyte* Platform;
    }

    public struct MKLVersion
    {
        public int MajorVersion;
        public int MinorVersion;
        public int UpdateVersion;
        public string ProductStatus;
        public string Build;
        public string Processor;
        public string Platform;
    }

    public struct VslStream
    {
        readonly IntPtr Ptr;
    }

    public enum VslBrng
    {
        MCG31         = (1 << 20),
        R250          = (1 << 20) * 2,
        MRG32K3A      = (1 << 20) * 3,
        MCG59         = (1 << 20) * 4,
        WH            = (1 << 20) * 5,
        SOBOL         = (1 << 20) * 6,
        NIEDERR       = (1 << 20) * 7,
        MT19937       = (1 << 20) * 8,
        MT2203        = (1 << 20) * 9,
        IABSTRACT     = (1 << 20) * 10,
        DABSTRACT     = (1 << 20) * 11,
        SABSTRACT     = (1 << 20) * 12,
        SFMT19937     = (1 << 20) * 13,
        NONDETERM     = (1 << 20) * 14,
        ARS5          = (1 << 20) * 15,
        PHILOX4X32X10 = (1 << 20) * 16,
    }

    public enum VslMethodUniform
    {
        STD = 0,
        STD_ACCURATE = 1<<30,
    }

    public enum VslMethodUniformBits
    {
        STD = 0,
    }

    public enum VslMethodGaussian
    {
        BOXMULLER = 0,
        BOXMULLER2 = 1,
        ICDF = 2,
    }

    public enum VslMethodExponential
    {
        ICDF = 0,
        ICDF_ACCURATE = 1 << 30,
    }

    public enum VslMethodLaplace
    {
        ICDF = 0,
    }

    public enum VslMethodWeibull
    {
        ICDF = 0,
        ICDF_ACCURATE = 1 << 30,
    }

    public enum VslMethodCauchy
    {
        ICDF = 0,
    }

    public enum VslMethodRayleigh
    {
        ICDF = 0,
        ICDF_ACCURATE = 1 << 30,
    }

    public enum VslMethodLognormal
    {
        BOXMULLER2 = 0,
        ICDF = 1,
        BOXMULLER2_ACCURATE = 1 << 30,
        ICDF_ACCURATE = (1 << 30) | 1,
    }

    public enum VslMethodGumbel
    {
        ICDF = 0,
    }

    public enum VslMethodGamma
    {
        ICDF = 0,
        ICDF_ACCURATE = 1 << 30,
    }

    public enum VslMethodBeta
    {
        CJA = 0,
        CJA_ACCURATE = 1 << 30,
    }

    public enum VslMethodChiSquare
    {
        CHI2GAMMA = 0,
    }

    public enum VslMethodBernoulli
    {
        ICDF = 0,
    }

    public enum VslMethodGeometric
    {
        ICDF = 0,
    }

    public enum VslMethodBinomial
    {
        BTPE = 0,
    }

    public enum VslMethodMultinomial
    {
        MULTPOISSON = 0,
    }

    public enum VslMethodHypergeometric
    {
        H2PE = 0,
    }

    public enum VslMethodPoisson
    {
        PTPE = 0,
        POISNORM = 1,
    }

    public enum VslMethodPoissonV
    {
        POISNORM = 0,
    }

    public enum VslMethodNegBinomial
    {
        NBAR = 0,
    }

    public enum MklThreading
    {
        INTEL      = 0,
        SEQUENTIAL = 1,
        PGI        = 2,
        GNU        = 3,
        TBB        = 4,
    }

    public enum MklCBWR
    {
        OFF           =  0,
        BRANCH_OFF    =  1,
        AUTO          =  2,
        COMPATIBLE    =  3,
        SSE2          =  4,
        SSSE3         =  6,
        SSE4_1        =  7,
        SSE4_2        =  8,
        AVX           =  9,
        AVX2          = 10,
        AVX512_MIC    = 11,
        AVX512        = 12,
        AVX512_MIC_E1 = 13,
        AVX512_E1     = 14,
        STRICT        = 0x10000,
    }
}