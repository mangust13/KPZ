//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using TodoApi.Models;

//namespace TodoApi.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class SubscriptionActivityTypesController : ControllerBase
//    {
//        private readonly SportComplexContext _context;

//        public SubscriptionActivityTypesController(SportComplexContext context)
//        {
//            _context = context;
//        }

//        // GET: api/SubscriptionActivityTypes
//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<SubscriptionActivityType>>> GetSubscriptionActivityTypes()
//        {
//            return await _context.SubscriptionActivityTypes
//                .Include(sat => sat.Subscription)
//                .Include(sat => sat.ActivityType)
//                .ToListAsync();
//        }

//        // GET: api/SubscriptionActivityTypes/5
//        [HttpGet("{id}")]
//        public async Task<ActionResult<SubscriptionActivityType>> GetSubscriptionActivityType(int id)
//        {
//            var subscriptionActivityType = await _context.SubscriptionActivityTypes
//                .Include(sat => sat.Subscription)
//                .Include(sat => sat.ActivityType)
//                .FirstOrDefaultAsync(sat => sat.subscription_activity_type_id == id);

//            if (subscriptionActivityType == null)
//            {
//                return NotFound();
//            }

//            return subscriptionActivityType;
//        }

//        // PUT: api/SubscriptionActivityTypes/5
//        [HttpPut("{id}")]
//        public async Task<IActionResult> PutSubscriptionActivityType(int id, SubscriptionActivityType subscriptionActivityType)
//        {
//            if (id != subscriptionActivityType.subscription_activity_type_id)
//            {
//                return BadRequest();
//            }

//            _context.Entry(subscriptionActivityType).State = EntityState.Modified;

//            try
//            {
//                await _context.SaveChangesAsync();
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                if (!SubscriptionActivityTypeExists(id))
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

//        // POST: api/SubscriptionActivityTypes
//        [HttpPost]
//        public async Task<ActionResult<SubscriptionActivityType>> PostSubscriptionActivityType(SubscriptionActivityType subscriptionActivityType)
//        {
//            _context.SubscriptionActivityTypes.Add(subscriptionActivityType);
//            await _context.SaveChangesAsync();

//            return CreatedAtAction("GetSubscriptionActivityType", new { id = subscriptionActivityType.subscription_activity_type_id }, subscriptionActivityType);
//        }

//        // DELETE: api/SubscriptionActivityTypes/5
//        [HttpDelete("{id}")]
//        public async Task<IActionResult> DeleteSubscriptionActivityType(int id)
//        {
//            var subscriptionActivityType = await _context.SubscriptionActivityTypes.FindAsync(id);
//            if (subscriptionActivityType == null)
//            {
//                return NotFound();
//            }

//            _context.SubscriptionActivityTypes.Remove(subscriptionActivityType);
//            await _context.SaveChangesAsync();

//            return NoContent();
//        }

//        private bool SubscriptionActivityTypeExists(int id)
//        {
//            return _context.SubscriptionActivityTypes.Any(e => e.subscription_activity_type_id == id);
//        }
//    }
//}
