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
    public class EditClientModel : PageModel
    {
        [BindProperty]
        public Client? client { get; set; }
        private readonly ServiceClient service;
        public EditClientModel()
        {
            IDataAccess<Client> acceso = new DataAccess<Client>("clients)");
            IRepositories<Client> repo = new RepositoriesJson<Client>(acceso);
            service = new ServiceClient(repo);
        }

        public void OnGet(int id)
        {
            Client? client = service.GetForId(id);
            if (client != null)
            {
                Client = client;
            }
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            service.Edit(Client);
            return RedirectToPage("IndexClient");
        }
    }
}
