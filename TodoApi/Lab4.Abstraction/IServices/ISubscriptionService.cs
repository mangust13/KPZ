using Lab4.Abstraction.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lab4.Abstraction.IServices
{
    public interface ISubscriptionService
    {
        Task<IEnumerable<SubscriptionViewModel>> GetAllSubscriptionsAsync();
        Task<SubscriptionViewModel> GetSubscriptionByIdAsync(int id);
        Task AddSubscriptionAsync(SubscriptionViewModel subscriptionViewModel);
        Task UpdateSubscriptionAsync(SubscriptionViewModel subscriptionViewModel);
        Task DeleteSubscriptionAsync(int id);
    }
}
