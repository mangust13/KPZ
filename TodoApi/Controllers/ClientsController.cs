using Lab4.Abstraction.IServices;
using Lab4.Abstraction.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IClientService _service;

        public ClientsController(IClientService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClientViewModel>>> GetClients()
        {
            return Ok(await _service.GetAllClientsAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClientViewModel>> GetClient(int id)
        {
            var client = await _service.GetClientByIdAsync(id);
            if (client == null)
            {
                return NotFound();
            }
            return Ok(client);
        }

        [HttpPost]
        public async Task<ActionResult> PostClient(ClientViewModel clientViewModel)
        {
            if (clientViewModel == null)
            {
                return BadRequest("Client data is required.");
            }

            await _service.AddClientAsync(clientViewModel);
            return CreatedAtAction(nameof(GetClient), new { id = clientViewModel.Id }, clientViewModel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutClient(int id, ClientViewModel clientViewModel)
        {
            if (id != clientViewModel.Id)
            {
                return BadRequest();
            }

            await _service.UpdateClientAsync(clientViewModel);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient(int id)
        {
            await _service.DeleteClientAsync(id);
            return NoContent();
        }
    }
}
