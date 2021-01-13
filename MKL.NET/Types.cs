using System;
using System.Runtime.InteropServices;

namespace MKLNET
{
    public enum Layout
    {
        RowMajor = 101,
        ColMajor = 102,
    }

    public enum LayoutChar : byte
    {
        RowMajor = (byte)'R',
        ColMajor = (byte)'C',
    }

    public enum Trans
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

    public enum UpLo
    {
        Upper = 121,
        Lower = 122,
    }

    public enum UpLoChar : byte
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

    public enum VmlMode : long
    {
        LA               = 0x00000001,
        HA               = 0x00000002,
        EP               = 0x00000003,
        ERRMODE_IGNORE   = 0x00000100,
        ERRMODE_ERRNO    = 0x00000200,
        ERRMODE_STDERR   = 0x00000400,
        ERRMODE_EXCEPT   = 0x00000800,
        ERRMODE_CALLBACK = 0x00001000,
        ERRMODE_NOERR    = 0x00002000,
        ERRMODE_DEFAULT  = ERRMODE_ERRNO | ERRMODE_CALLBACK | ERRMODE_EXCEPT,
        FTZDAZ_ON        = 0x00280000,
        FTZDAZ_OFF       = 0x00140000,
    }

    public enum VmlStatus
    {
        OK              = 0,
        BADSIZE         =-1,
        BADMEM          =-2,
        ERRDOM          = 1,
        SING            = 2,
        OVERFLOW        = 3,
        UNDERFLOW       = 4,
        ACCURACYWARNING = 1000,

    }

#pragma warning disable IDE0051 // Remove unused private members
    public struct VslStream
    {
        readonly IntPtr Ptr;
    }

    public struct VsldConvTask
    {
        readonly IntPtr Ptr;
    }

    public struct VslsConvTask
    {
        readonly IntPtr Ptr;
    }

    public struct VsldCorrTask
    {
        readonly IntPtr Ptr;
    }

    public struct VslsCorrTask
    {
        readonly IntPtr Ptr;
    }

    public struct DftiDescriptor
    {
        readonly IntPtr Ptr;
    }

    //public struct RcidTrnspTask
    //{
    //    readonly IntPtr Ptr;
    //}

    //public struct RcisTrnspTask
    //{
    //    readonly IntPtr Ptr;
    //}

    //public struct RcidTrnspbcTask
    //{
    //    readonly IntPtr Ptr;
    //}

    //public struct RcisTrnspbcTask
    //{
    //    readonly IntPtr Ptr;
    //}

    //public struct RcidJacobiTask
    //{
    //    readonly IntPtr Ptr;
    //}

    //public struct RcisJacobiTask
    //{
    //    readonly IntPtr Ptr;
    //}
#pragma warning restore IDE0051 // Remove unused private members

    internal struct Pinned
    {
        int count;
        GCHandle[] handles;
        internal Pinned(int c)
        {
            count = 0;
            handles = new GCHandle[c];
        }
        internal IntPtr Add(object? o)
        {
            if(count == handles.Length)
            {
                var newHandles = new GCHandle[count * 2];
                Array.Copy(handles, 0, newHandles, 0, count);
                handles = newHandles;
            }
            var h = GCHandle.Alloc(o, GCHandleType.Pinned);
            handles[count++] = h;
            return h.AddrOfPinnedObject();
        }
        internal void Free()
        {
            for (int i = 0; i < count; i++)
                handles[i].Free();
        }
    }

    public class VsldSSTask
    {
        internal IntPtr Ptr;
        internal IntPtr Allocated;
        internal Pinned Pinned;
    }

    public struct VslsSSTask
    {
        internal IntPtr Ptr;
        internal IntPtr Allocated;
        internal Pinned Pinned;
    }

    public enum VslMode
    {
        AUTO   = 0,
        DIRECT = 1,
        FFT    = 2,
    }

    public enum VslStorage
    {
        ROWS = 0x00010000,
        COLS = 0x00020000,
    }

    public enum VslFormat
    {
        FULL     = 0x00000000,
        L_PACKED = 0x00000001,
        U_PACKED = 0x00000002,
    }

    public enum VslPrecision
    {
        SINGLE = 1,
        DOUBLE = 2,
    }

    public enum VslEdit
    {
        DIMEN                  =  1,
        OBSERV_N               =  2,
        OBSERV                 =  3,
        OBSERV_STORAGE         =  4,
        INDC                   =  5,
        WEIGHTS                =  6,
        MEAN                   =  7,
        MOM_2R                 =  8,
        MOM_3R                 =  9,
        MOM_4R                 = 10,
        MOM_2C                 = 11,
        MOM_3C                 = 12,
        MOM_4C                 = 13,
        SUM                    = 67,
        SUM_2R                 = 68,
        SUM_3R                 = 69,
        SUM_4R                 = 70,
        SUM_2C                 = 71,
        SUM_3C                 = 72,
        SUM_4C                 = 73,
        KURTOSIS               = 14,
        SKEWNESS               = 15,
        MIN                    = 16,
        MAX                    = 17,
        VARIATION              = 18,
        COV                    = 19,
        COV_STORAGE            = 20,
        COR                    = 21,
        COR_STORAGE            = 22,
        CP                     = 74,
        CP_STORAGE             = 75,
        ACCUM_WEIGHT           = 23,
        QUANT_ORDER_N          = 24,
        QUANT_ORDER            = 25,
        QUANT_QUANTILES        = 26,
        ORDER_STATS            = 27,
        GROUP_INDC             = 28,
        POOLED_COV_STORAGE     = 29,
        POOLED_MEAN            = 30,
        POOLED_COV             = 31,
        GROUP_COV_INDC         = 32,
        REQ_GROUP_INDC         = 32,
        GROUP_MEAN             = 33,
        GROUP_COV_STORAGE      = 34,
        GROUP_COV              = 35,
        ROBUST_COV_STORAGE     = 36,
        ROBUST_COV_PARAMS_N    = 37,
        ROBUST_COV_PARAMS      = 38,
        ROBUST_MEAN            = 39,
        ROBUST_COV             = 40,
        OUTLIERS_PARAMS_N      = 41,
        OUTLIERS_PARAMS        = 42,
        OUTLIERS_WEIGHT        = 43,
        ORDER_STATS_STORAGE    = 44,
        PARTIAL_COV_IDX        = 45,
        PARTIAL_COV            = 46,
        PARTIAL_COV_STORAGE    = 47,
        PARTIAL_COR            = 48,
        PARTIAL_COR_STORAGE    = 49,
        MI_PARAMS_N            = 50,
        MI_PARAMS              = 51,
        MI_INIT_ESTIMATES_N    = 52,
        MI_INIT_ESTIMATES      = 53,
        MI_SIMUL_VALS_N        = 54,
        MI_SIMUL_VALS          = 55,
        MI_ESTIMATES_N         = 56,
        MI_ESTIMATES           = 57,
        MI_PRIOR_N             = 58,
        MI_PRIOR               = 59,
        PARAMTR_COR            = 60,
        PARAMTR_COR_STORAGE    = 61,
        STREAM_QUANT_PARAMS_N  = 62,
        STREAM_QUANT_PARAMS    = 63,
        STREAM_QUANT_ORDER_N   = 64,
        STREAM_QUANT_ORDER     = 65,
        STREAM_QUANT_QUANTILES = 66,
        MDAD                   = 76,
        MNAD                   = 77,
        SORTED_OBSERV          = 78,
        SORTED_OBSERV_STORAGE  = 79,
    }

    public enum VslEstimate : long
    {
        MEAN          = 0x0000000000000001,
        MOM_2R        = 0x0000000000000002,
        MOM_3R        = 0x0000000000000004,
        MOM_4R        = 0x0000000000000008,
        MOM_2C        = 0x0000000000000010,
        MOM_3C        = 0x0000000000000020,
        MOM_4C        = 0x0000000000000040,
        SUM           = 0x0000000002000000,
        SUM2_R        = 0x0000000004000000,
        SUM3_R        = 0x0000000008000000,
        SUM4_R        = 0x0000000010000000,
        SUM2_C        = 0x0000000020000000,
        SUM3_C        = 0x0000000040000000,
        SUM4_C        = 0x0000000080000000,
        KURTOSIS      = 0x0000000000000080,
        SKEWNESS      = 0x0000000000000100,
        VARIATION     = 0x0000000000000200,
        MIN           = 0x0000000000000400,
        MAX           = 0x0000000000000800,
        COV           = 0x0000000000001000,
        COR           = 0x0000000000002000,
        CP            = 0x0000000100000000,
        POOLED_COV    = 0x0000000000004000,
        GROUP_COV     = 0x0000000000008000,
        POOLED_MEAN   = 0x0000000800000000,
        GROUP_MEAN    = 0x0000001000000000,
        QUANTS        = 0x0000000000010000,
        ORDER_STATS   = 0x0000000000020000,
        SORTED_OBSERV = 0x0000008000000000,
        ROBUST_COV    = 0x0000000000040000,
        OUTLIERS      = 0x0000000000080000,
        PARTIAL_COV   = 0x0000000000100000,
        PARTIAL_COR   = 0x0000000000200000,
        MISSING_VALS  = 0x0000000000400000,
        PARAMTR_COR   = 0x0000000000800000,
        STREAM_QUANTS = 0x0000000001000000,
        MDAD          = 0x0000000200000000,
        MNAD          = 0x0000000400000000,
    }

    public enum VslMethod
    {
        FAST            = 0x00000001,
        ONEPASS         = 0x00000002,
        SD              = 0x00000004,
        TBS             = 0x00000008,
        MI              = 0x00000010,
        BACON           = 0x00000020,
        SQUANTS_ZW      = 0x00000040,
        SQUANTS_ZW_FAST = 0x00000080,
        FAST_USER_MEAN  = 0x00000100,
        CP_TO_COVCOR    = 0x00000200,
        SUM_TO_MOM      = 0x00000400,
        RADIX           = 0x00100000,
    }

    public enum VslBaconInit
    {
        MAHALANOBIS = 0x00000001,
        MEDIAN      = 0x00000002,
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

    public enum DftiConfigValue
    {
        COMMITTED = 30,
        UNCOMMITTED = 31,
        COMPLEX = 32,
        REAL = 33,
        SINGLE = 35,
        DOUBLE = 36,
        COMPLEX_COMPLEX = 39,
        COMPLEX_REAL = 40,
        REAL_COMPLEX = 41,
        REAL_REAL = 42,
        INPLACE = 43,
        NOT_INPLACE = 44,
        ORDERED = 48,
        BACKWARD_SCRAMBLED = 49,
        ALLOW = 51,
        AVOID = 52,
        NONE = 53,
        CCS_FORMAT = 54,
        PACK_FORMAT = 55,
        PERM_FORMAT = 56,
        CCE_FORMAT = 57,
    }

    public enum DftiConfigParam
    {
        FORWARD_DOMAIN = 0,
        DIMENSION = 1,
        LENGTHS = 2,
        PRECISION = 3,
        FORWARD_SCALE = 4,
        BACKWARD_SCALE = 5,
        NUMBER_OF_TRANSFORMS = 7,
        COMPLEX_STORAGE = 8,
        REAL_STORAGE = 9,
        CONJUGATE_EVEN_STORAGE = 10,
        PLACEMENT = 11,
        INPUT_STRIDES = 12,
        OUTPUT_STRIDES = 13,
        INPUT_DISTANCE = 14,
        OUTPUT_DISTANCE = 15,
        WORKSPACE = 17,
        ORDERING = 18,
        TRANSPOSE = 19,
        DESCRIPTOR_NAME_DEPRECATED = 20,
        PACKED_FORMAT = 21,
        COMMIT_STATUS = 22,
        VERSION = 23,
        NUMBER_OF_USER_THREADS = 26,
        THREAD_LIMIT = 27,
        DESTROY_INPUT = 28,
        FWD_DISTANCE = 58,
        BWD_DISTANCE = 59
    }

    public enum DftiErrorClass : long
    {
        NO_ERROR                   = 0,
        MEMORY_ERROR               = 1,
        INVALID_CONFIGURATION      = 2,
        INCONSISTENT_CONFIGURATION = 3,
        MULTITHREADED_ERROR        = 4,
        BAD_DESCRIPTOR             = 5,
        UNIMPLEMENTED              = 6,
        MKL_INTERNAL_ERROR         = 7,
        NUMBER_OF_THREADS_ERROR    = 8,
        LENGTH_1D_EXCEEDS_INT32    = 9,
    }

    public enum DfdiStatus : long
    {
        NO_ERROR = 0L,
    }


    public enum RciStatus
    {
        SUCCESS         = 1501,
        INVALID_OPTION  = 1502,
        OUT_OF_MEMORY   = 1503,
    }
}