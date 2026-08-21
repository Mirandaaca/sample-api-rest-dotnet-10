using CIWithJenkins.DTOs.Roles;
using CIWithJenkins.Entities;
using CIWithJenkins.Exceptions;
using CIWithJenkins.Interfaces.Repository;
using CIWithJenkins.Interfaces.Services;
using FluentValidation;

namespace CIWithJenkins.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IValidator<RoleDTO> _roleValidator;
        public RoleService(IRoleRepository roleRepository, IValidator<RoleDTO> roleValidator)
        {
            _roleRepository = roleRepository;
            _roleValidator = roleValidator;
        }
        public async Task Create(RoleDTO roleDTO)
        {
            await _roleValidator.ValidateAndThrowAsync(roleDTO);
            Role objRole = new Role
            {
                Name = roleDTO.Name,
                Description = roleDTO.Description
            };
            await _roleRepository.Create(objRole);
        }
        public async Task Delete(Guid id)
        {
            var role = await _roleRepository.GetById(id);
            if (role == null) throw new RoleNotFoundException(id);
            await _roleRepository.Delete(role);
        }

        public async Task<List<ReadRoleDTO>> GetAll()
        {
            var roles = await _roleRepository.GetAll();
            return roles.Select(r => new ReadRoleDTO
            {
                Id = r.Id,
                Name = r.Name,
                Description = r.Description
            }).ToList();
        }

        public async Task<ReadRoleDTO> GetById(Guid id)
        {
            var role = await _roleRepository.GetById(id);
            if (role == null) throw new RoleNotFoundException(id);
            return new ReadRoleDTO
            {
                Id = role.Id,
                Name = role.Name,
                Description = role.Description
            };
        }

        public async Task Update(Guid id, RoleDTO roleDTO)
        {
            var role = await _roleRepository.GetById(id);
            if (role == null) throw new RoleNotFoundException(id);
            role.Name = roleDTO.Name;
            role.Description = roleDTO.Description;
            await _roleRepository.Update(role);
        }
    }
}
