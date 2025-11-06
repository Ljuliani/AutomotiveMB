namespace AutomotiveMB.DataAAccess
{
    public interface IDataAccess<T>
    {
        List<T> Read();
        void Save(List<T> lista);
    }
}
