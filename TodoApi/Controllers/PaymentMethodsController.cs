using Lab4.Abstraction.IServices;
using Lab4.Abstraction.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentMethodsController : ControllerBase
    {
        private readonly IPaymentMethodService _service;

        public PaymentMethodsController(IPaymentMethodService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymentMethodViewModel>>> GetPaymentMethods()
        {
            return Ok(await _service.GetAllPaymentMethodsAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PaymentMethodViewModel>> GetPaymentMethod(int id)
        {
            var paymentMethod = await _service.GetPaymentMethodByIdAsync(id);
            if (paymentMethod == null)
            {
                return NotFound();
            }
            return Ok(paymentMethod);
        }

        [HttpPost]
        public async Task<ActionResult> PostPaymentMethod(PaymentMethodViewModel paymentMethodViewModel)
        {
            await _service.AddPaymentMethodAsync(paymentMethodViewModel);
            return CreatedAtAction(nameof(GetPaymentMethod), new { id = paymentMethodViewModel.Id }, paymentMethodViewModel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaymentMethod(int id, PaymentMethodViewModel paymentMethodViewModel)
        {
            if (id != paymentMethodViewModel.Id)
            {
                return BadRequest();
            }

            await _service.UpdatePaymentMethodAsync(paymentMethodViewModel);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePaymentMethod(int id)
        {
            await _service.DeletePaymentMethodAsync(id);
            return NoContent();
        }
    }
}
