using Microsoft.AspNetCore.Mvc.RazorPages;
using AutomotiveMB.Models;
using AutomotiveMB.DataAAccess;
using AutomotiveMB.Services;
using AutomotiveMB.Repositories;

namespace AutomotiveMB.Pages.ClientCreate
{
    public class IndexClientModel : PageModel
    {
        public List<Client> Clients { get; set; } = new();
        public Dictionary<int, Vehicle> VehiclesMap { get; set; } = new();

        private readonly ServiceClient service;
        private readonly ServiceVehicle serviceVehicle;

        public IndexClientModel()
        {
            IDataAccess<Client> acceso = new DataAccess<Client>("clients");
            IRepositories<Client> repo = new RepositoriesJson<Client>(acceso);
            service = new ServiceClient(repo);

            IDataAccess<Vehicle> accesoVeh = new DataAccess<Vehicle>("vehicles");
            IRepositories<Vehicle> repoVeh = new RepositoriesJson<Vehicle>(accesoVeh);
            serviceVehicle = new ServiceVehicle(repoVeh);
        }

        public void OnGet()
        {
            Clients = service.GetAll() ?? new List<Client>();

            var vehicles = serviceVehicle.GetAll() ?? new List<Vehicle>();
            VehiclesMap = vehicles
                .Where(v => v != null)
                .ToDictionary(v => v.Id, v => v);
        }
    }
}
