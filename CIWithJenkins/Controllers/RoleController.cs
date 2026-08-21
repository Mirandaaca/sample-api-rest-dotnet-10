using CIWithJenkins.DTOs.Roles;
using CIWithJenkins.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CIWithJenkins.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }
        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<ActionResult<List<ReadRoleDTO>>> GetAll()
        {
            return Ok(await _roleService.GetAll());
        }
        [HttpGet("{id:guid}")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<ReadRoleDTO>> GetById(Guid id)
        {
            return Ok(await _roleService.GetById(id));
        }
        [HttpPut("{id:guid}")]
        [ProducesResponseType(204)]
        public async Task<ActionResult> Update(Guid id, RoleDTO roleDTO)
        {
            await _roleService.Update(id, roleDTO);
            return NoContent();
        }
        [HttpDelete("{id:guid}")]
        [ProducesResponseType(204)]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _roleService.Delete(id);
            return NoContent();
        }
        [HttpPost]
        [ProducesResponseType(201)]
        public async Task<ActionResult> Create(RoleDTO roleDTO)
        {
            await _roleService.Create(roleDTO);
            return Created();
        }
    }
}
