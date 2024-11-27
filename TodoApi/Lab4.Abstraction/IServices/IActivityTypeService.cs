using Lab4.Abstraction.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lab4.Abstraction.IServices
{
    public interface IActivityTypeService
    {
        Task<IEnumerable<ActivityTypeViewModel>> GetAllActivityTypesAsync();
        Task<ActivityTypeViewModel> GetActivityTypeByIdAsync(int id);
        Task AddActivityTypeAsync(ActivityTypeViewModel activityTypeViewModel);
        Task UpdateActivityTypeAsync(ActivityTypeViewModel activityTypeViewModel);
        Task DeleteActivityTypeAsync(int id);
    }
}
