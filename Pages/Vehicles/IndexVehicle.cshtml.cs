using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AutomotiveMB.Models;
using AutomotiveMB.DataAAccess;
using AutomotiveMB.Services;
using AutomotiveMB.Helpers;
using AutomotiveMB.Repositories;
using AutomotiveMB.Data;
using AutomotiveMB.Pages;

namespace AutomotiveMB.Pages.CreateVehicle
{
    public class IndexVehicleModel : PageModel
    {
        public List<Vehicle> Vehicles { get; set; }
        private readonly ServiceVehicle service;
        public IndexVehicleModel()
        {
            IDataAccess<Vehicle> access = new DataAccess<Vehicle>("vehicles");
            IRepositories<Vehicle> repo = new RepositoriesJson<Vehicle>(access);
            service = new ServiceVehicle(repo);
        }
        public void OnGet()
        {
            Vehicles = service.GetAll();
        }
    }
}
