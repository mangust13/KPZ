using Lab4.Abstraction.IServices;
using Lab4.Abstraction.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityTypesController : ControllerBase
    {
        private readonly IActivityTypeService _service;

        public ActivityTypesController(IActivityTypeService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ActivityTypeViewModel>>> GetActivityTypes()
        {
            return Ok(await _service.GetAllActivityTypesAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ActivityTypeViewModel>> GetActivityType(int id)
        {
            var activityType = await _service.GetActivityTypeByIdAsync(id);
            if (activityType == null)
            {
                return NotFound();
            }
            return Ok(activityType);
        }

        [HttpPost]
        public async Task<ActionResult> PostActivityType(ActivityTypeViewModel activityTypeViewModel)
        {
            await _service.AddActivityTypeAsync(activityTypeViewModel);
            return CreatedAtAction(nameof(GetActivityType), new { id = activityTypeViewModel.Id }, activityTypeViewModel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutActivityType(int id, ActivityTypeViewModel activityTypeViewModel)
        {
            if (id != activityTypeViewModel.Id)
            {
                return BadRequest();
            }

            await _service.UpdateActivityTypeAsync(activityTypeViewModel);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActivityType(int id)
        {
            await _service.DeleteActivityTypeAsync(id);
            return NoContent();
        }
    }
}
