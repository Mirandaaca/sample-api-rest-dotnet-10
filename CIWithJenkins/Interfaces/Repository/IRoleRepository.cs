using CIWithJenkins.Entities;

namespace CIWithJenkins.Interfaces.Repository
{
    public interface IRoleRepository
    {
        public Task<List<Role>> GetAll();
        public Task<Role> GetById(Guid id);
        public Task Update(Role role);
        public Task Delete(Role role);
        public Task Create(Role role);
    }
}
