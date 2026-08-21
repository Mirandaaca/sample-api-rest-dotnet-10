using CIWithJenkins.DTOs.Roles;

namespace CIWithJenkins.Interfaces.Services
{
    public interface IRoleService
    {
        public Task<List<ReadRoleDTO>> GetAll();
        public Task<ReadRoleDTO> GetById(Guid id);
        public Task Update(Guid id, RoleDTO roleDTO);
        public Task Delete(Guid id);
        public Task Create(RoleDTO roleDTO);
    }
}
