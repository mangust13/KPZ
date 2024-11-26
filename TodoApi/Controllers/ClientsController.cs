using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;
using TodoApi.ViewModels;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly SportComplexContext _context;
        private readonly IMapper _mapper;

        public ClientsController(SportComplexContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Отримати список усіх клієнтів.
        /// </summary>
        /// <returns>Список клієнтів</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClientViewModel>>> GetClients()
        {
            var clients = await _context.Clients.ToListAsync();
            var clientViewModels = _mapper.Map<IEnumerable<ClientViewModel>>(clients);
            return Ok(clientViewModels);
        }

        /// <summary>
        /// Отримати клієнта за ідентифікатором.
        /// </summary>
        /// <param name="id">Ідентифікатор клієнта</param>
        /// <returns>Клієнт</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<ClientViewModel>> GetClient(int id)
        {
            var client = await _context.Clients.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }

            var clientViewModel = _mapper.Map<ClientViewModel>(client);
            return Ok(clientViewModel);
        }

        /// <summary>
        /// Додати нового клієнта.
        /// </summary>
        /// <param name="clientViewModel">Дані нового клієнта</param>
        /// <returns>Доданий клієнт</returns>
        [HttpPost]
        public async Task<ActionResult<ClientViewModel>> PostClient(ClientViewModel clientViewModel)
        {
            var client = _mapper.Map<Client>(clientViewModel);
            _context.Clients.Add(client);
            await _context.SaveChangesAsync();

            var createdClientViewModel = _mapper.Map<ClientViewModel>(client);
            return CreatedAtAction("GetClient", new { id = client.client_id }, createdClientViewModel);
        }

        /// <summary>
        /// Оновити дані клієнта.
        /// </summary>
        /// <param name="id">Ідентифікатор клієнта</param>
        /// <param name="clientViewModel">Дані для оновлення</param>
        /// <returns>Результат</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClient(int id, ClientViewModel clientViewModel)
        {
            if (id != clientViewModel.Id)
            {
                return BadRequest();
            }

            var client = _mapper.Map<Client>(clientViewModel);
            client.client_id = id; // Установлюємо ідентифікатор
            _context.Entry(client).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Clients.Any(c => c.client_id == id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        /// <summary>
        /// Видалити клієнта за ідентифікатором.
        /// </summary>
        /// <param name="id">Ідентифікатор клієнта</param>
        /// <returns>Нічого</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient(int id)
        {
            var client = await _context.Clients.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }

            _context.Clients.Remove(client);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
