using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SportComplexesController : ControllerBase
    {
        private readonly SportComplexContext _context;

        public SportComplexesController(SportComplexContext context)
        {
            _context = context;
        }

        // GET: api/SportComplexes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SportComplex>>> GetSportComplexes()
        {
            return await _context.SportComplexes
                .Include(sc => sc.City)
                .ToListAsync();
        }

        // GET: api/SportComplexes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SportComplex>> GetSportComplex(int id)
        {
            var sportComplex = await _context.SportComplexes
                .Include(sc => sc.City)
                .FirstOrDefaultAsync(sc => sc.sports_complex_id == id);

            if (sportComplex == null)
            {
                return NotFound();
            }

            return sportComplex;
        }

        // PUT: api/SportComplexes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSportComplex(int id, SportComplex sportComplex)
        {
            if (id != sportComplex.sports_complex_id)
            {
                return BadRequest();
            }

            _context.Entry(sportComplex).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SportComplexExists(id))
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

        // POST: api/SportComplexes
        [HttpPost]
        public async Task<ActionResult<SportComplex>> PostSportComplex(SportComplex sportComplex)
        {
            _context.SportComplexes.Add(sportComplex);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSportComplex", new { id = sportComplex.sports_complex_id }, sportComplex);
        }

        // DELETE: api/SportComplexes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSportComplex(int id)
        {
            var sportComplex = await _context.SportComplexes.FindAsync(id);
            if (sportComplex == null)
            {
                return NotFound();
            }

            _context.SportComplexes.Remove(sportComplex);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SportComplexExists(int id)
        {
            return _context.SportComplexes.Any(e => e.sports_complex_id == id);
        }
    }
}
