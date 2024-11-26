//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using Lab4.DAL.Models;
//using Lab4.DAL.Data;

//namespace TodoApi.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class PurchasesController : ControllerBase
//    {
//        private readonly SportComplexContext _context;

//        public PurchasesController(SportComplexContext context)
//        {
//            _context = context;
//        }

//        // GET: api/Purchases
//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<Purchase>>> GetPurchases()
//        {
//            return await _context.Purchases
//                .Include(p => p.Client)
//                .Include(p => p.Subscription)
//                .Include(p => p.PaymentMethod)
//                .ToListAsync();
//        }

//        // GET: api/Purchases/5
//        [HttpGet("{id}")]
//        public async Task<ActionResult<Purchase>> GetPurchase(int id)
//        {
//            var purchase = await _context.Purchases
//                .Include(p => p.Client)
//                .Include(p => p.Subscription)
//                .Include(p => p.PaymentMethod)
//                .FirstOrDefaultAsync(p => p.purchase_id == id);

//            if (purchase == null)
//            {
//                return NotFound();
//            }

//            return purchase;
//        }

//        // PUT: api/Purchases/5
//        [HttpPut("{id}")]
//        public async Task<IActionResult> PutPurchase(int id, Purchase purchase)
//        {
//            if (id != purchase.purchase_id)
//            {
//                return BadRequest();
//            }

//            _context.Entry(purchase).State = EntityState.Modified;

//            try
//            {
//                await _context.SaveChangesAsync();
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                if (!PurchaseExists(id))
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

//        // POST: api/Purchases
//        [HttpPost]
//        public async Task<ActionResult<Purchase>> PostPurchase(Purchase purchase)
//        {
//            _context.Purchases.Add(purchase);
//            await _context.SaveChangesAsync();

//            return CreatedAtAction("GetPurchase", new { id = purchase.purchase_id }, purchase);
//        }

//        // DELETE: api/Purchases/5
//        [HttpDelete("{id}")]
//        public async Task<IActionResult> DeletePurchase(int id)
//        {
//            var purchase = await _context.Purchases.FindAsync(id);
//            if (purchase == null)
//            {
//                return NotFound();
//            }

//            _context.Purchases.Remove(purchase);
//            await _context.SaveChangesAsync();

//            return NoContent();
//        }

//        private bool PurchaseExists(int id)
//        {
//            return _context.Purchases.Any(e => e.purchase_id == id);
//        }
//    }
//}
