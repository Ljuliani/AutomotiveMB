using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AutomotiveMB.Models;
using AutomotiveMB.DataAAccess;
using AutomotiveMB.Services;
using AutomotiveMB.Helpers;
using AutomotiveMB.Repositories;
using AutomotiveMB.Data;


namespace AutomotiveMB.Pages.CreateVehicle
{
    public class CreateVehicleModel : PageModel
    {
        [BindProperty]
        public Vehicle Vehicle { get; set; } = new();
        public List<string> States { get; set; } = new List<string>();
        private readonly ServiceVehicle service;

        public CreateVehicleModel()
        {
            IDataAccess<Vehicle> access = new DataAccess<Vehicle>("vehicles");
            IRepositories<Vehicle> repo = new RepositoriesJson<Vehicle>(access);
            service = new ServiceVehicle(repo);
        }
        public void OnGet()
        {
            States = OptionState.Lista;
        }

        public IActionResult OnPost()
        {
            States = OptionState.Lista;

            if (!ModelState.IsValid)
            {
                return Page();
            }

            service.Add(Vehicle);
            return RedirectToPage("IndexVehicle");
        }
    }
}
