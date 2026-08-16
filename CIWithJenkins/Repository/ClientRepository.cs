using CIWithJenkins.Context;
using CIWithJenkins.Entities;
using CIWithJenkins.Exceptions;
using CIWithJenkins.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace CIWithJenkins.Repository
{
    public class ClientRepository : IClientRepository
    {
        private readonly StoreContext _storeContext;
        public ClientRepository(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }

        public async Task Create(Client client)
        {
            await _storeContext.Clients.AddAsync(client);
            await _storeContext.SaveChangesAsync();
        }

        public async Task Delete(Client client)
        {
            _storeContext.Clients.Remove(client);
            await _storeContext.SaveChangesAsync();
        }

        public async Task<List<Client>> GetAll()
        {
            return await _storeContext.Clients.AsNoTracking().ToListAsync();
        }

        public async Task<Client> GetById(Guid id)
        {
            return await _storeContext.Clients.FindAsync(id);
        }

        public async Task Update(Client client)
        {
            _storeContext.Clients.Update(client);
            await _storeContext.SaveChangesAsync();
        }
    }
}
