namespace MKLNET
{
    public interface IGeneral
    {
        MKLVersion get_version();
        void set_num_threads(int nt);
        int get_max_threads();
    }
}
