using AutomotiveMB.Models;
using System.Text.Json;
using System.IO;
using System.ComponentModel;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel;
using AutomotiveMB.Repositories;

namespace AutomotiveMB.Services
{
    public class ServiceClient
    {
        private readonly IRepositories<Client> _repo;
        public ServiceClient(IRepositories<Client> repo)
        {
            _repo = repo;
        }
        
        public List<Client> GetAll()
        {
            return _repo.GetAll();
        }

        public void Add(Client client)
        {
            _repo.Add(client);
        }

        public Client? GetForId(int id)
        {
            return _repo.SearchForId(id);
        }

        public void Edit(Client client)
        {
            _repo.Edit(client);
        }

        public void Delete(Client client)
        {
            _repo.DeleteForId(client.Id);
        }
    }
}
