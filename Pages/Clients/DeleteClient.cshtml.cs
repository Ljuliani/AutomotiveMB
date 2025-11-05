using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AutomotiveMB.Models;
using AutomotiveMB.DataAccess;
using AutomotiveMB.Services;
using AutomotiveMB.Helpers;
using AutomotiveMB.Repositories;
using AutomotiveMB.Data;
using AutomotiveMB.Pages;

namespace AutomotiveMB.Pages.Client
{
    public class DeleteClientModel : PageModel
    {
        [BindProperty]
        public Client Client { get; set; }
        private readonly ServiceClient service;
        public DeleteClientModel()
        {
            IDataAccess<Client> acceso = new DataAccess<Client>("clients)");
            IRepositories<Client> repo = new RepositoriesJson<Client>(acceso);
            service = new ServiceClient(repo);
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
        public IActionResult OnPost(int id)
        {
            service.Delete(Client);
            return RedirectToPage("IndexClient");
        }
    }
}
