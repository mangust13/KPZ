using Lab4.Abstraction.IServices;
using Lab4.Abstraction.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionTermsController : ControllerBase
    {
        private readonly ISubscriptionTermService _service;

        public SubscriptionTermsController(ISubscriptionTermService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubscriptionTermViewModel>>> GetSubscriptionTerms()
        {
            return Ok(await _service.GetAllSubscriptionTermsAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SubscriptionTermViewModel>> GetSubscriptionTerm(int id)
        {
            var subscriptionTerm = await _service.GetSubscriptionTermByIdAsync(id);
            if (subscriptionTerm == null)
            {
                return NotFound();
            }
            return Ok(subscriptionTerm);
        }

        [HttpPost]
        public async Task<ActionResult> PostSubscriptionTerm(SubscriptionTermViewModel subscriptionTermViewModel)
        {
            await _service.AddSubscriptionTermAsync(subscriptionTermViewModel);
            return CreatedAtAction(nameof(GetSubscriptionTerm), new { id = subscriptionTermViewModel.Id }, subscriptionTermViewModel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubscriptionTerm(int id, SubscriptionTermViewModel subscriptionTermViewModel)
        {
            if (id != subscriptionTermViewModel.Id)
            {
                return BadRequest();
            }

            await _service.UpdateSubscriptionTermAsync(subscriptionTermViewModel);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubscriptionTerm(int id)
        {
            await _service.DeleteSubscriptionTermAsync(id);
            return NoContent();
        }
    }
}
