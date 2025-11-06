using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AutomotiveMB.Models;
using AutomotiveMB.DataAccess;
using AutomotiveMB.Services;
using AutomotiveMB.Helpers;
using AutomotiveMB.Repositories;
using AutomotiveMB.Data;
using AutomotiveMB.Pages;

namespace AutomotiveMB.Pages.ClientCreate
{
    public class IndexModel : PageModel
    {
        public List<Client> Clients { get; set; }
        private readonly ServiceClient service;
        public IndexClientModel()
        {
            IRepositories<Client> acceso = new DataAccess<Client>("clients)");
            IRepositories<Client> repo = new RepositoriesClient<Client>(acceso);
            service = new ServiceClient(repo);
        }
        public void OnGet()
        {
            Clients = service.GetAll();
        }
    }
}
