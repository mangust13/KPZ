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
        /// <response code="200">Успішно отримано список клієнтів</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
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
        /// <response code="200">Клієнт знайдений</response>
        /// <response code="404">Клієнт не знайдений</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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
        /// <response code="201">Клієнт успішно створений</response>
        /// <response code="400">Некоректний ввід</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ClientViewModel>> PostClient(ClientViewModel clientViewModel)
        {
            // Перевірка валідності моделі
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

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
        /// <response code="204">Успішно оновлено</response>
        /// <response code="400">Некоректний ввід</response>
        /// <response code="404">Клієнт не знайдений</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutClient(int id, ClientViewModel clientViewModel)
        {
            if (id != clientViewModel.Id)
            {
                return BadRequest();
            }

            var client = _mapper.Map<Client>(clientViewModel);
            client.client_id = id; // Установлюємо ID

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
        /// <returns>Результат</returns>
        /// <response code="204">Клієнт успішно видалений</response>
        /// <response code="404">Клієнт не знайдений</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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
