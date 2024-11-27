using Lab4.Abstraction.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lab4.Abstraction.IServices
{
    public interface ISubscriptionTermService
    {
        Task<IEnumerable<SubscriptionTermViewModel>> GetAllSubscriptionTermsAsync();
        Task<SubscriptionTermViewModel> GetSubscriptionTermByIdAsync(int id);
        Task AddSubscriptionTermAsync(SubscriptionTermViewModel subscriptionTermViewModel);
        Task UpdateSubscriptionTermAsync(SubscriptionTermViewModel subscriptionTermViewModel);
        Task DeleteSubscriptionTermAsync(int id);
    }
}
