namespace AutomotiveMB.DataAccess
{
    public interface IDataAccess<T>
    {
        List<T> Read();
        void Save(List<T> lista);
    }
}
