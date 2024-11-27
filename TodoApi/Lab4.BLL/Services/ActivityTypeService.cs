using Lab4.Abstraction.IServices;
using Lab4.Abstraction.IRepository;
using Lab4.Abstraction.ViewModels;

namespace Lab4.BLL.Services
{
    public class ActivityTypeService : IActivityTypeService
    {
        private readonly IActivityTypeRepository _repository;

        public ActivityTypeService(IActivityTypeRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ActivityTypeViewModel>> GetAllActivityTypesAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<ActivityTypeViewModel> GetActivityTypeByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddActivityTypeAsync(ActivityTypeViewModel activityTypeViewModel)
        {
            await _repository.AddAsync(activityTypeViewModel);
        }

        public async Task UpdateActivityTypeAsync(ActivityTypeViewModel activityTypeViewModel)
        {
            await _repository.UpdateAsync(activityTypeViewModel);
        }

        public async Task DeleteActivityTypeAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
