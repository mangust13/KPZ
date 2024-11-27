using Lab4.Abstraction.IServices;
using Lab4.Abstraction.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionsController : ControllerBase
    {
        private readonly ISubscriptionService _service;

        public SubscriptionsController(ISubscriptionService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubscriptionViewModel>>> GetSubscriptions()
        {
            return Ok(await _service.GetAllSubscriptionsAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SubscriptionViewModel>> GetSubscription(int id)
        {
            var subscription = await _service.GetSubscriptionByIdAsync(id);
            if (subscription == null)
            {
                return NotFound();
            }
            return Ok(subscription);
        }

        [HttpPost]
        public async Task<ActionResult> PostSubscription(SubscriptionViewModel subscriptionViewModel)
        {
            await _service.AddSubscriptionAsync(subscriptionViewModel);
            return CreatedAtAction(nameof(GetSubscription), new { id = subscriptionViewModel.Id }, subscriptionViewModel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubscription(int id, SubscriptionViewModel subscriptionViewModel)
        {
            if (id != subscriptionViewModel.Id)
            {
                return BadRequest();
            }

            await _service.UpdateSubscriptionAsync(subscriptionViewModel);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubscription(int id)
        {
            await _service.DeleteSubscriptionAsync(id);
            return NoContent();
        }
    }
}
