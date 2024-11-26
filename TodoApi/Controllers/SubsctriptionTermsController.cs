//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using TodoApi.Models;

//namespace TodoApi.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class SubscriptionTermsController : ControllerBase
//    {
//        private readonly SportComplexContext _context;

//        public SubscriptionTermsController(SportComplexContext context)
//        {
//            _context = context;
//        }

//        // GET: api/SubscriptionTerms
//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<SubscriptionTerm>>> GetSubscriptionTerms()
//        {
//            return await _context.SubscriptionTerms.ToListAsync();
//        }

//        // GET: api/SubscriptionTerms/5
//        [HttpGet("{id}")]
//        public async Task<ActionResult<SubscriptionTerm>> GetSubscriptionTerm(int id)
//        {
//            var subscriptionTerm = await _context.SubscriptionTerms.FindAsync(id);

//            if (subscriptionTerm == null)
//            {
//                return NotFound();
//            }

//            return subscriptionTerm;
//        }

//        // PUT: api/SubscriptionTerms/5
//        [HttpPut("{id}")]
//        public async Task<IActionResult> PutSubscriptionTerm(int id, SubscriptionTerm subscriptionTerm)
//        {
//            if (id != subscriptionTerm.subscription_term_id)
//            {
//                return BadRequest();
//            }

//            _context.Entry(subscriptionTerm).State = EntityState.Modified;

//            try
//            {
//                await _context.SaveChangesAsync();
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                if (!SubscriptionTermExists(id))
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

//        // POST: api/SubscriptionTerms
//        [HttpPost]
//        public async Task<ActionResult<SubscriptionTerm>> PostSubscriptionTerm(SubscriptionTerm subscriptionTerm)
//        {
//            _context.SubscriptionTerms.Add(subscriptionTerm);
//            await _context.SaveChangesAsync();

//            return CreatedAtAction("GetSubscriptionTerm", new { id = subscriptionTerm.subscription_term_id }, subscriptionTerm);
//        }

//        // DELETE: api/SubscriptionTerms/5
//        [HttpDelete("{id}")]
//        public async Task<IActionResult> DeleteSubscriptionTerm(int id)
//        {
//            var subscriptionTerm = await _context.SubscriptionTerms.FindAsync(id);
//            if (subscriptionTerm == null)
//            {
//                return NotFound();
//            }

//            _context.SubscriptionTerms.Remove(subscriptionTerm);
//            await _context.SaveChangesAsync();

//            return NoContent();
//        }

//        private bool SubscriptionTermExists(int id)
//        {
//            return _context.SubscriptionTerms.Any(e => e.subscription_term_id == id);
//        }
//    }
//}
