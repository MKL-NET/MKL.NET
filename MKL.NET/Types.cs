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

    public enum Diag
    {
        NonUnit = 131,
        Unit = 132,
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
