using AutomotiveMB.Data;
using System.Text.Json;

namespace AutomotiveMB.DataAAccess
{
    public class DataAccess<T> : IDataAccess<T>
    {
        private string ruta;

        public DataAccess(string nombreArchivo)
        {
            ruta = $"Data/{nombreArchivo}.json";
        }

        private string ReadTextInArchive()
        {
            if (File.Exists(ruta))
            {
                return File.ReadAllText(ruta);
            }
            return "[]"; // Retorna un JSON vacío si el archivo no existe
        }

        public List<T> Read()
        {
            string json = ReadTextInArchive();
            var lista = JsonSerializer.Deserialize<List<T>>(json);
            return lista ?? new List<T>();
        }

        public void Save(List<T> lista)
        {
            string textJson = JsonSerializer.Serialize(lista);
            File.WriteAllText(ruta, textJson);
        }
    }    
}
