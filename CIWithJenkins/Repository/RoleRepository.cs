using CIWithJenkins.Context;
using CIWithJenkins.Entities;
using CIWithJenkins.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace CIWithJenkins.Repository
{
    public class RoleRepository : IRoleRepository
    {
        private readonly StoreContext _storeContext;
        public RoleRepository(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }

        public async Task Create(Role role)
        {
            await _storeContext.Roles.AddAsync(role);
            await _storeContext.SaveChangesAsync();
        }

        public async Task Delete(Role role)
        {
            _storeContext.Roles.Remove(role);
            await _storeContext.SaveChangesAsync();
        }

        public async Task<List<Role>> GetAll()
        {
            return await _storeContext.Roles.AsNoTracking().ToListAsync();
        }

        public async Task<Role> GetById(Guid id)
        {
            return await _storeContext.Roles.FindAsync(id);
        }

        public async Task Update(Role role)
        {
            _storeContext.Roles.Update(role);
            await _storeContext.SaveChangesAsync();
        }
    }
}
