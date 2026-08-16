using CIWithJenkins.Entities;

namespace CIWithJenkins.Interfaces.Repository
{
    public interface IClientRepository
    {
        public Task<List<Client>> GetAll();
        public Task<Client> GetById(Guid id);
        public Task Update(Client client);
        public Task Delete(Client client);
        public Task Create(Client client);
    }
}
