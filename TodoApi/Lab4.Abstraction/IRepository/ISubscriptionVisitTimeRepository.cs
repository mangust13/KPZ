using Lab4.Abstraction.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lab4.Abstraction.IRepository
{
    public interface ISubscriptionVisitTimeRepository
    {
        Task<IEnumerable<SubscriptionVisitTimeViewModel>> GetAllAsync();
        Task<SubscriptionVisitTimeViewModel> GetByIdAsync(int id);
        Task AddAsync(SubscriptionVisitTimeViewModel subscriptionVisitTimeViewModel);
        Task UpdateAsync(SubscriptionVisitTimeViewModel subscriptionVisitTimeViewModel);
        Task DeleteAsync(int id);
    }
}
