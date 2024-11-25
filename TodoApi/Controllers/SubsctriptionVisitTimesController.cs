using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionVisitTimesController : ControllerBase
    {
        private readonly SportComplexContext _context;

        public SubscriptionVisitTimesController(SportComplexContext context)
        {
            _context = context;
        }

        // GET: api/SubscriptionVisitTimes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubscriptionVisitTime>>> GetSubscriptionVisitTimes()
        {
            return await _context.SubscriptionVisitTimes.ToListAsync();
        }

        // GET: api/SubscriptionVisitTimes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SubscriptionVisitTime>> GetSubscriptionVisitTime(int id)
        {
            var subscriptionVisitTime = await _context.SubscriptionVisitTimes.FindAsync(id);

            if (subscriptionVisitTime == null)
            {
                return NotFound();
            }

            return subscriptionVisitTime;
        }

        // PUT: api/SubscriptionVisitTimes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubscriptionVisitTime(int id, SubscriptionVisitTime subscriptionVisitTime)
        {
            if (id != subscriptionVisitTime.subscription_visit_time_id)
            {
                return BadRequest();
            }

            _context.Entry(subscriptionVisitTime).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubscriptionVisitTimeExists(id))
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

        // POST: api/SubscriptionVisitTimes
        [HttpPost]
        public async Task<ActionResult<SubscriptionVisitTime>> PostSubscriptionVisitTime(SubscriptionVisitTime subscriptionVisitTime)
        {
            _context.SubscriptionVisitTimes.Add(subscriptionVisitTime);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSubscriptionVisitTime", new { id = subscriptionVisitTime.subscription_visit_time_id }, subscriptionVisitTime);
        }

        // DELETE: api/SubscriptionVisitTimes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubscriptionVisitTime(int id)
        {
            var subscriptionVisitTime = await _context.SubscriptionVisitTimes.FindAsync(id);
            if (subscriptionVisitTime == null)
            {
                return NotFound();
            }

            _context.SubscriptionVisitTimes.Remove(subscriptionVisitTime);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SubscriptionVisitTimeExists(int id)
        {
            return _context.SubscriptionVisitTimes.Any(e => e.subscription_visit_time_id == id);
        }
    }
}
