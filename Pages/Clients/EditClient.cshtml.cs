using AutomotiveMB.DataAAccess;
using AutomotiveMB.Models;
using AutomotiveMB.Repositories;
using AutomotiveMB.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AutomotiveMB.Pages.ClientCreate
{
    public class EditClientModel : PageModel
    {
        [BindProperty]
        public Client? Client { get; set; }

        private readonly ServiceClient service;
        private readonly ServiceVehicle vehicleService;

        public SelectList Vehicles { get; set; } = default!;

        public EditClientModel()
        {
            IDataAccess<Client> acceso = new DataAccess<Client>("clients");
            IRepositories<Client> repo = new RepositoriesJson<Client>(acceso);
            service = new ServiceClient(repo);

            IDataAccess<Vehicle> accesoVehicle = new DataAccess<Vehicle>("vehicles");
            IRepositories<Vehicle> repoVehicle = new RepositoriesJson<Vehicle>(accesoVehicle);
            vehicleService = new ServiceVehicle(repoVehicle);
        }

        public void OnGet(int id)
        {
            Client? client = service.GetForId(id);
            if (client != null)
            {
                Client = client;
            }

            // Cargar lista de vehículos para el select
            var vehicles = vehicleService.GetAll() ?? new List<Vehicle>();
            Vehicles = new SelectList(vehicles, nameof(Vehicle.Id), nameof(Vehicle.Model));
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid || Client == null)
            {
                var vehicles = vehicleService.GetAll() ?? new List<Vehicle>();
                Vehicles = new SelectList(vehicles, nameof(Vehicle.Id), nameof(Vehicle.Model));
                return Page();
            }
            service.Edit(Client);
            return RedirectToPage("IndexClient");
        }
    }
}
