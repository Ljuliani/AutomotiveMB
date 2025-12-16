using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AutomotiveMB.Models;
using AutomotiveMB.DataAAccess;
using AutomotiveMB.Services;
using AutomotiveMB.Repositories;
using AutomotiveMB.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AutomotiveMB.Pages.ClientCreate
{
    public class ClientCreateModel : PageModel
    {
        [BindProperty]
        public Client Client { get; set; }

        private readonly ServiceClient service;
        private readonly ServiceVehicle vehicleService;

        // Lista de vehículos para la vista
        public SelectList Vehicles { get; set; } = default!;

        public ClientCreateModel()
        {
            IDataAccess<Client> accesoClient = new DataAccess<Client>("clients");
            IRepositories<Client> repoClient = new RepositoriesJson<Client>(accesoClient);
            service = new ServiceClient(repoClient);

            IDataAccess<Vehicle> accesoVehicle = new DataAccess<Vehicle>("vehicles");
            IRepositories<Vehicle> repoVehicle = new RepositoriesJson<Vehicle>(accesoVehicle);
            vehicleService = new ServiceVehicle(repoVehicle);
        }

        public void OnGet()
        {
            var vehicles = vehicleService.GetAll();
            Vehicles = new SelectList(vehicles, nameof(Vehicle.Id), nameof(Vehicle.Model));
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                // Recargar lista si hay error
                var vehicles = vehicleService.GetAll();
                Vehicles = new SelectList(vehicles, nameof(Vehicle.Id), nameof(Vehicle.Model));
                return Page();
            }

            service.Add(Client);
            return RedirectToPage("IndexClient");
        }
    }
}