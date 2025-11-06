using AutomotiveMB.DataAAccess;
using System.Text.Json;

namespace AutomotiveMB.Repositories
{
    public class RepositoriesJson <T> : IRepositories<T> where T : class
    {
        private readonly IDataAccess<T> _acceso;

        public RepositoriesJson(IDataAccess<T> acceso)
        {
            _acceso = acceso;
        }

        public List<T> GetAll()
        {
            return _acceso.Read();
        }

        public void Save(List<T> lista)
        {
            _acceso.Save(lista);
        }

        public int GetNewId(List<T> lista)
        {
            int maxId = 0;

            foreach(var item in lista)
            {
                var propertyId = typeof(T).GetProperty("id");
                int id = (int)propertyId.GetValue(item);
                if(id > maxId)
                {
                    maxId = id;
                }
            }
            return maxId + 1;
        }

        public void Add(T entidad)
        {
            var lista = GetAll();
            int newId = GetNewId(lista);

            var propertyId = typeof(T).GetProperty("id");
            propertyId.SetValue(entidad, newId);

            lista.Add(entidad);
            Save(lista);
        }

        private T? SearchInListForId(List<T> lista, int id)
        {
            var propertyId = typeof(T).GetProperty("id");

            foreach (var item in lista)
            {
                int valueId = (int)propertyId.GetValue(item);
                if (valueId == id)
                {
                    return item;
                }
            }
            return null;
        }

        public T? SearchForId(int id)
        {
            var lista = GetAll();
            return SearchInListForId(lista, id);
        }

        public void DeleteForId(int id)
        {
            var lista = GetAll();
            T? entidad = SearchInListForId(lista, id);

            if (entidad != null)
            {
                lista.Remove(entidad);
                Save(lista);
            }
        }

        private void UpdateProperties(T entidadExistente, T entidadNueva)
        {
            var properties = typeof(T).GetProperties();

            foreach (var property in properties)
            {
                if (property.Name == "Id") continue;

                var newValue = property.GetValue(entidadNueva);
                property.SetValue(entidadExistente, newValue);
            }
        }

        public void Edit(T entidadNueva)
        {
            var lista = GetAll();
            var propertyId = typeof(T).GetProperty("Id");
            int id = (int)propertyId.GetValue(entidadNueva);

            var entidadExistente = SearchInListForId(lista, id);
            if(entidadExistente != null)
            {
                UpdateProperties(entidadExistente, entidadNueva);
                Save(lista);
            }
        }
    }
}
