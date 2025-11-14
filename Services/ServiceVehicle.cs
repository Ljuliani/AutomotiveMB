using AutomotiveMB.Models;
using AutomotiveMB.Repositories;

namespace AutomotiveMB.Services
{
    public class ServiceVehicle
    {
        private readonly IRepositories<Vehicle> _repo;
        public ServiceVehicle(IRepositories<Vehicle> repo)
        {
            _repo = repo;
        }

        public List<Vehicle> GetAll()
        {
            return _repo.GetAll();
        }

        public void Add(Vehicle vehicle)
        {
            _repo.Add(vehicle);
        }

        public Vehicle? GetForId(int id)
        {
            return _repo.SearchForId(id);
        }

        public void Edit(Vehicle vehicle)
        {
            _repo.Edit(vehicle);
        }

        public void Delete(Vehicle vehicle)
        {
            _repo.DeleteForId(vehicle.Id);
        }
    }
}