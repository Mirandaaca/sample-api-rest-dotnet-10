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
        public async Task<List<ReadClientDTO>> GetAll()
        {
            return await _clientService.GetAll();
        }
        [HttpGet("{id:guid}")]
        [ProducesResponseType(200)]
        public async Task<ReadClientDTO> GetById(Guid id)
        {
            return await _clientService.GetById(id);
        }
        [HttpPut("{id:guid}")]
        [ProducesResponseType(204)]
        public async Task Update(Guid id, ClientDTO client)
        {
            await _clientService.Update(id, client);
        }
        [HttpDelete("{id:guid}")]
        [ProducesResponseType(204)]
        public async Task Delete(Guid id)
        {
            await _clientService.Delete(id);
        }
        [HttpPost]
        [ProducesResponseType(201)]
        public async Task Create(ClientDTO client)
        {
            await _clientService.Create(client);
        }
    }
}
