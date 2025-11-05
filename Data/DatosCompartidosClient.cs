using AutomotiveMB.Models;
using System.Text.Json;

namespace AutomotiveMB.Data

{
    public class DatosCompartidosClient
    {
        public static List<Client> Clients { get; set; } = new();
        private static int ultimoId = 0;
        public static int ObtenerNuevoId(List<Client> clients)
        {
            int maxId = 0;
            foreach (var client in Clients)
            {
                if (client.Id > maxId)
                {
                    maxId = client.Id;
                }
            }
            return maxId + 1;
        }
    }
}
