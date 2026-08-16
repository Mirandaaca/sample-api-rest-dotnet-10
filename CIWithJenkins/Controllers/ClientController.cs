using CIWithJenkins.DTOs.Clients;
using CIWithJenkins.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CIWithJenkins.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;
        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }
        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<ActionResult<List<ReadClientDTO>>> GetAll()
        {
            return Ok(await _clientService.GetAll());
        }
        [HttpGet("{id:guid}")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<ReadClientDTO>> GetById(Guid id)
        {
            return Ok(await _clientService.GetById(id));
        }
        [HttpPut("{id:guid}")]
        [ProducesResponseType(204)]
        public async Task<ActionResult> Update(Guid id, ClientDTO client)
        {
            await _clientService.Update(id, client);
            return NoContent();
        }
        [HttpDelete("{id:guid}")]
        [ProducesResponseType(204)]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _clientService.Delete(id);
            return NoContent();
        }
        [HttpPost]
        [ProducesResponseType(201)]
        public async Task<ActionResult> Create(ClientDTO client)
        {
            await _clientService.Create(client);
            return Created();
        }
    }
}
