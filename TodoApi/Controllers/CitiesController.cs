//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using TodoApi.Models; // Підключіть ваші моделі
//using TodoApi; // Підключіть ваш DbContext

//namespace TodoApi.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class CitiesController : ControllerBase
//    {
//        private readonly SportComplexContext _context;

//        public CitiesController(SportComplexContext context)
//        {
//            _context = context;
//        }

//        // GET: api/Cities
//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<City>>> GetCities()
//        {
//            return await _context.Cities.ToListAsync();
//        }

//        // GET: api/Cities/5
//        [HttpGet("{id}")]
//        public async Task<ActionResult<City>> GetCity(int id)
//        {
//            var city = await _context.Cities.FindAsync(id);

//            if (city == null)
//            {
//                return NotFound();
//            }

//            return city;
//        }

//        // PUT: api/Cities/5
//        [HttpPut("{id}")]
//        public async Task<IActionResult> PutCity(int id, City city)
//        {
//            if (id != city.city_id)
//            {
//                return BadRequest();
//            }

//            _context.Entry(city).State = EntityState.Modified;

//            try
//            {
//                await _context.SaveChangesAsync();
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                if (!CityExists(id))
//                {
//                    return NotFound();
//                }
//                else
//                {
//                    throw;
//                }
//            }

//            return NoContent();
//        }

//        // POST: api/Cities
//        [HttpPost]
//        public async Task<ActionResult<City>> PostCity(City city)
//        {
//            _context.Cities.Add(city);
//            await _context.SaveChangesAsync();

//            return CreatedAtAction("GetCity", new { id = city.city_id }, city);
//        }

//        // DELETE: api/Cities/5
//        [HttpDelete("{id}")]
//        public async Task<IActionResult> DeleteCity(int id)
//        {
//            var city = await _context.Cities.FindAsync(id);
//            if (city == null)
//            {
//                return NotFound();
//            }

//            _context.Cities.Remove(city);
//            await _context.SaveChangesAsync();

//            return NoContent();
//        }

//        private bool CityExists(int id)
//        {
//            return _context.Cities.Any(e => e.city_id == id);
//        }
//    }
//}
