using AutomotiveMB.DataAccess;
using AutomotiveMB.Services;
using AutomotiveMB.Helpers;
using AutomotiveMB.Repositories;
using AutomotiveMB.Data;
using AutomotiveMB.Pages.Vehicles;


namespace AutomotiveMB.Pages.CreateClient
{
    public class CreateClientModel : PageModel
    {
        [BindProperty]
        public Client Client { get; set; }
        private readonly ServiceClient service;
        public CreateClientModel()
        {
            IDataAccess<Client> acceso = new DataAccess<Client>("clients)");
            IRepositories<Client> repo = new RepositoriesJson<Client>(acceso);
            service = new ServiceClient(repo);
        }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            service.Add(Client);
            return RedirectToPage("IndexClient");
        }
    }
}
