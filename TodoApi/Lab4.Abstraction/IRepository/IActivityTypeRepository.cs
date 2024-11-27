using Lab4.Abstraction.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lab4.Abstraction.IRepository
{
    public interface IActivityTypeRepository
    {
        Task<IEnumerable<ActivityTypeViewModel>> GetAllAsync();
        Task<ActivityTypeViewModel> GetByIdAsync(int id);
        Task AddAsync(ActivityTypeViewModel activityTypeViewModel);
        Task UpdateAsync(ActivityTypeViewModel activityTypeViewModel);
        Task DeleteAsync(int id);
    }
}
