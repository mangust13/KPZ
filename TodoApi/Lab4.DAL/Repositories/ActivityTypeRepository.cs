using Lab4.Abstraction.IRepository;
using Lab4.Abstraction.ViewModels;
using Lab4.DAL.Data;
using Lab4.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab4.DAL.Repositories
{
    public class ActivityTypeRepository : IActivityTypeRepository
    {
        private readonly SportComplexContext _context;

        public ActivityTypeRepository(SportComplexContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ActivityTypeViewModel>> GetAllAsync()
        {
            return await _context.ActivityTypes
                .Select(a => new ActivityTypeViewModel
                {
                    Id = a.activity_type_id,
                    Name = a.activity_name,
                    Description = a.activity_description,
                    Price = a.activity_price
                })
                .ToListAsync();
        }

        public async Task<ActivityTypeViewModel> GetByIdAsync(int id)
        {
            var activityType = await _context.ActivityTypes.FindAsync(id);
            if (activityType == null) return null;

            return new ActivityTypeViewModel
            {
                Id = activityType.activity_type_id,
                Name = activityType.activity_name,
                Description = activityType.activity_description,
                Price = activityType.activity_price
            };
        }

        public async Task AddAsync(ActivityTypeViewModel activityTypeViewModel)
        {
            var activityType = new ActivityType
            {
                activity_name = activityTypeViewModel.Name,
                activity_description = activityTypeViewModel.Description,
                activity_price = activityTypeViewModel.Price
            };

            _context.ActivityTypes.Add(activityType);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ActivityTypeViewModel activityTypeViewModel)
        {
            var existingActivityType = await _context.ActivityTypes.FindAsync(activityTypeViewModel.Id);
            if (existingActivityType == null) return;

            existingActivityType.activity_name = activityTypeViewModel.Name;
            existingActivityType.activity_description = activityTypeViewModel.Description;
            existingActivityType.activity_price = activityTypeViewModel.Price;

            _context.Entry(existingActivityType).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var activityType = await _context.ActivityTypes.FindAsync(id);
            if (activityType != null)
            {
                _context.ActivityTypes.Remove(activityType);
                await _context.SaveChangesAsync();
            }
        }
    }
}
