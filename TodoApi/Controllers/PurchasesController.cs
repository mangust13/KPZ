using Lab4.Abstraction.IServices;
using Lab4.Abstraction.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchasesController : ControllerBase
    {
        private readonly IPurchaseService _service;

        public PurchasesController(IPurchaseService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PurchaseViewModel>>> GetPurchases()
        {
            return Ok(await _service.GetAllPurchasesAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PurchaseViewModel>> GetPurchase(int id)
        {
            var purchase = await _service.GetPurchaseByIdAsync(id);
            if (purchase == null)
            {
                return NotFound();
            }
            return Ok(purchase);
        }

        [HttpPost]
        public async Task<ActionResult> PostPurchase(PurchaseViewModel purchaseViewModel)
        {
            await _service.AddPurchaseAsync(purchaseViewModel);
            return CreatedAtAction(nameof(GetPurchase), new { id = purchaseViewModel.Id }, purchaseViewModel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPurchase(int id, PurchaseViewModel purchaseViewModel)
        {
            if (id != purchaseViewModel.Id)
            {
                return BadRequest();
            }

            await _service.UpdatePurchaseAsync(purchaseViewModel);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePurchase(int id)
        {
            await _service.DeletePurchaseAsync(id);
            return NoContent();
        }
    }
}
