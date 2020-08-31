namespace MKLNET
{
    public interface IGeneral
    {
        MKLVersion Version { get; }
        int Max_Threads { get; set; }
    }
}
