using Lab4.Abstraction.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lab4.Abstraction.IRepository
{
    public interface ISubscriptionTermRepository
    {
        Task<IEnumerable<SubscriptionTermViewModel>> GetAllAsync();
        Task<SubscriptionTermViewModel> GetByIdAsync(int id);
        Task AddAsync(SubscriptionTermViewModel subscriptionTermViewModel);
        Task UpdateAsync(SubscriptionTermViewModel subscriptionTermViewModel);
        Task DeleteAsync(int id);
    }
}
