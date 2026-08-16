using CIWithJenkins.DTOs.Clients;
using CIWithJenkins.Entities;
using CIWithJenkins.Exceptions;
using CIWithJenkins.Interfaces.Repository;
using CIWithJenkins.Interfaces.Services;

namespace CIWithJenkins.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }
        public async Task Create(ClientDTO client)
        {
            Client objClient = new Client
            {
                Name = client.Name,
                Surname = client.Surname,
                Email = client.Email,
                Phone = client.Phone
            };
            await _clientRepository.Create(objClient);
        }

        public async Task Delete(Guid id)
        {
            var client = await _clientRepository.GetById(id);
            if (client == null) throw new ClientNotFoundException(id);
            await _clientRepository.Delete(client);
        }

        public async Task<List<ReadClientDTO>> GetAll()
        {
            var clients = await _clientRepository.GetAll();
            return clients.Select(client => new ReadClientDTO
            {
                Id = client.Id,
                Name = client.Name,
                Surname = client.Surname,
                Email = client.Email,
                Phone = client.Phone
            }).ToList();
        }

        public async Task<ReadClientDTO> GetById(Guid id)
        {
            var client = await _clientRepository.GetById(id);
            if (client == null) throw new ClientNotFoundException(id);
            return new ReadClientDTO
            {
                Id = client.Id,
                Name = client.Name,
                Surname = client.Surname,
                Email = client.Email,
                Phone = client.Phone
            };
        }

        public async Task Update(Guid id, ClientDTO client)
        {
            var clientFound = await _clientRepository.GetById(id);
            if (clientFound == null) throw new ClientNotFoundException(id);
            clientFound.Name = client.Name;
            clientFound.Surname = client.Surname;
            clientFound.Email = client.Email;
            clientFound.Phone = client.Phone;
            await _clientRepository.Update(clientFound);
        }
    }
}
