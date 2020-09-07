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
}
