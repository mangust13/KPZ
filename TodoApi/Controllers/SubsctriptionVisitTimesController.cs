using Lab4.Abstraction.IServices;
using Lab4.Abstraction.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionVisitTimesController : ControllerBase
    {
        private readonly ISubscriptionVisitTimeService _service;

        public SubscriptionVisitTimesController(ISubscriptionVisitTimeService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubscriptionVisitTimeViewModel>>> GetSubscriptionVisitTimes()
        {
            return Ok(await _service.GetAllSubscriptionVisitTimesAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SubscriptionVisitTimeViewModel>> GetSubscriptionVisitTime(int id)
        {
            var subscriptionVisitTime = await _service.GetSubscriptionVisitTimeByIdAsync(id);
            if (subscriptionVisitTime == null)
            {
                return NotFound();
            }
            return Ok(subscriptionVisitTime);
        }

        [HttpPost]
        public async Task<ActionResult> PostSubscriptionVisitTime(SubscriptionVisitTimeViewModel subscriptionVisitTimeViewModel)
        {
            await _service.AddSubscriptionVisitTimeAsync(subscriptionVisitTimeViewModel);
            return CreatedAtAction(nameof(GetSubscriptionVisitTime), new { id = subscriptionVisitTimeViewModel.Id }, subscriptionVisitTimeViewModel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubscriptionVisitTime(int id, SubscriptionVisitTimeViewModel subscriptionVisitTimeViewModel)
        {
            if (id != subscriptionVisitTimeViewModel.Id)
            {
                return BadRequest();
            }

            await _service.UpdateSubscriptionVisitTimeAsync(subscriptionVisitTimeViewModel);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubscriptionVisitTime(int id)
        {
            await _service.DeleteSubscriptionVisitTimeAsync(id);
            return NoContent();
        }
    }
}
