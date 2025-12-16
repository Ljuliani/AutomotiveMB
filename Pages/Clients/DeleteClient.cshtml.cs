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
    public class DeleteClientModel : PageModel
    {
        [BindProperty]
        public Client Client { get; set; }
        private readonly ServiceClient service;
        private readonly ServiceVehicle vehicleService;
        public DeleteClientModel()
        {
            IDataAccess<Client> accesoClient = new DataAccess<Client>("clients");
            IRepositories<Client> repoClient = new RepositoriesJson<Client>(accesoClient);
            service = new ServiceClient(repoClient);

            IDataAccess<Vehicle> accesoVehicle = new DataAccess<Vehicle>("vehicles");
            IRepositories<Vehicle> repoVehicle = new RepositoriesJson<Vehicle>(accesoVehicle);
            vehicleService = new ServiceVehicle(repoVehicle);
        }
        public IActionResult OnGet(int id)
        {
            var client= service.GetForId(id);
            if (client == null)
            {
                return RedirectToPage("IndexClient");
            }

            Client = client;
            return Page();
        }
        public IActionResult OnPost()
        {
            Client = service.GetForId(Client.Id);
            if (Client == null)
            {
                ModelState.AddModelError(string.Empty, "El cliente no existe.");
                return Page();
            }

            // Verifica si el cliente tiene un vehículo asociado
            if (Client.VehicleId != null)
            {
                ModelState.AddModelError(string.Empty, "No se puede eliminar el cliente porque tiene un vehículo asociado.");
                return Page();
            }

            service.Delete(Client);
            return RedirectToPage("IndexClient");
        }
    }
}
