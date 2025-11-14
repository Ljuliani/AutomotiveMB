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
    public class EditModel : PageModel
    {
        [BindProperty]
        public Vehicle? Vehicle { get; set; }
        private readonly ServiceVehicle service;

        public EditModel()
        {
            IDataAccess<Vehicle> access = new DataAccess<Vehicle>("vehicles");
            IRepositories<Vehicle> repo = new RepositoriesJson<Vehicle>(access);
            service = new ServiceVehicle(repo);
        }
        public void OnGet(int id)
        {
            var States = OptionState.Lista;

            Vehicle? vehicle = service.GetForId(id);
            if (vehicle != null)
            {
                Vehicle = vehicle;
            }
        }

        public IActionResult OnPost()
        {
            var States = OptionState.Lista;

            if (!ModelState.IsValid)
            {
                return Page();
            }
            service.Edit(Vehicle);
            return RedirectToPage("IndexVehicle");
        }
    }
}
