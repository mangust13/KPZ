using Lab4.Abstraction.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lab4.Abstraction.IRepository
{
    public interface ISubscriptionRepository
    {
        Task<IEnumerable<SubscriptionViewModel>> GetAllAsync();
        Task<SubscriptionViewModel> GetByIdAsync(int id);
        Task AddAsync(SubscriptionViewModel subscriptionViewModel);
        Task UpdateAsync(SubscriptionViewModel subscriptionViewModel);
        Task DeleteAsync(int id);
    }
}
