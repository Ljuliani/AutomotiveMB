using AutomotiveMB.DataAAccess;
using AutomotiveMB.Services;
using AutomotiveMB.Models;
using AutomotiveMB.Helpers;
using AutomotiveMB.Repositories;
using AutomotiveMB.Data;
using AutomotiveMB.Pages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AutomotiveMB.Pages.CreateVehicle
{
    public class DeleteModel : PageModel
    {
        [BindProperty]
        public Vehicle Vehicle { get; set; }
        private readonly ServiceVehicle service;
        public DeleteModel()
        {
            IDataAccess<Vehicle> access = new DataAccess<Vehicle>("vehicles");
            IRepositories<Vehicle> repo = new RepositoriesJson<Vehicle>(access);
            service = new ServiceVehicle(repo);
        }

        public IActionResult OnGet(int id)
        {
            var vehicle = service.GetForId(id);
            if (vehicle == null)
            {
                return RedirectToPage("Index");
            }

            Vehicle = vehicle;
            return Page();
        }
        public IActionResult OnPost(int id)
        {
            service.Delete(Vehicle);
            return RedirectToPage("IndexVehicle");
        }
    }
}
