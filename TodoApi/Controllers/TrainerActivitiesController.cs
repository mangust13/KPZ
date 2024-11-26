//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using TodoApi.Models;

//namespace TodoApi.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class TrainerActivitiesController : ControllerBase
//    {
//        private readonly SportComplexContext _context;

//        public TrainerActivitiesController(SportComplexContext context)
//        {
//            _context = context;
//        }

//        // GET: api/TrainerActivities
//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<TrainerActivity>>> GetTrainerActivities()
//        {
//            return await _context.TrainerActivities
//                .Include(ta => ta.Trainer)
//                .Include(ta => ta.ActivityType)
//                .ToListAsync();
//        }

//        // GET: api/TrainerActivities/5
//        [HttpGet("{id}")]
//        public async Task<ActionResult<TrainerActivity>> GetTrainerActivity(int id)
//        {
//            var trainerActivity = await _context.TrainerActivities
//                .Include(ta => ta.Trainer)
//                .Include(ta => ta.ActivityType)
//                .FirstOrDefaultAsync(ta => ta.trainer_activity_id == id);

//            if (trainerActivity == null)
//            {
//                return NotFound();
//            }

//            return trainerActivity;
//        }

//        // PUT: api/TrainerActivities/5
//        [HttpPut("{id}")]
//        public async Task<IActionResult> PutTrainerActivity(int id, TrainerActivity trainerActivity)
//        {
//            if (id != trainerActivity.trainer_activity_id)
//            {
//                return BadRequest();
//            }

//            _context.Entry(trainerActivity).State = EntityState.Modified;

//            try
//            {
//                await _context.SaveChangesAsync();
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                if (!TrainerActivityExists(id))
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

//        // POST: api/TrainerActivities
//        [HttpPost]
//        public async Task<ActionResult<TrainerActivity>> PostTrainerActivity(TrainerActivity trainerActivity)
//        {
//            _context.TrainerActivities.Add(trainerActivity);
//            await _context.SaveChangesAsync();

//            return CreatedAtAction("GetTrainerActivity", new { id = trainerActivity.trainer_activity_id }, trainerActivity);
//        }

//        // DELETE: api/TrainerActivities/5
//        [HttpDelete("{id}")]
//        public async Task<IActionResult> DeleteTrainerActivity(int id)
//        {
//            var trainerActivity = await _context.TrainerActivities.FindAsync(id);
//            if (trainerActivity == null)
//            {
//                return NotFound();
//            }

//            _context.TrainerActivities.Remove(trainerActivity);
//            await _context.SaveChangesAsync();

//            return NoContent();
//        }

//        private bool TrainerActivityExists(int id)
//        {
//            return _context.TrainerActivities.Any(e => e.trainer_activity_id == id);
//        }
//    }
//}
