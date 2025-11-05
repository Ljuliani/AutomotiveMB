namespace AutomotiveMB.Repositories
{
    public interface IRepositories<T> where T : class
    {
        List<T> GetAll();
        T? SearchForId(int id);
        void Add(T? entidad);
        void Edit(T? entidad);
        void DeleteForId(int id);
    }
}
