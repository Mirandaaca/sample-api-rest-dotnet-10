using CIWithJenkins.DTOs.Clients;

namespace CIWithJenkins.Interfaces.Services
{
    public interface IClientService
    {
        public Task<List<ReadClientDTO>> GetAll();
        public Task<ReadClientDTO> GetById(Guid id);
        public Task Update(Guid id, ClientDTO client);
        public Task Delete(Guid id);
        public Task Create(ClientDTO client);
    }
}
