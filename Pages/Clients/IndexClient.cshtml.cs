using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AutomotiveMB.Models;
using AutomotiveMB.DataAAccess;
using AutomotiveMB.Services;
using AutomotiveMB.Helpers;
using AutomotiveMB.Repositories;
using AutomotiveMB.Data;
using AutomotiveMB.Pages;

namespace AutomotiveMB.Pages.ClientCreate
{
    public class IndexClientModel : PageModel
    {
        public List<Client> Clients { get; set; }
        private readonly ServiceClient service;
        public IndexClientModel()
        {
            IDataAccess<Client> acceso = new DataAccess<Client>("clients");
            IRepositories<Client> repo = new RepositoriesJson<Client>(acceso);
            service = new ServiceClient(repo);
        }
        public void OnGet()
        {
            Clients = service.GetAll();
        }
    }
}
