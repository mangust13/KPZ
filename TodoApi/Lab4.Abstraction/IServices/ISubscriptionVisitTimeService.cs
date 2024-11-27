using Lab4.Abstraction.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lab4.Abstraction.IServices
{
    public interface ISubscriptionVisitTimeService
    {
        Task<IEnumerable<SubscriptionVisitTimeViewModel>> GetAllSubscriptionVisitTimesAsync();
        Task<SubscriptionVisitTimeViewModel> GetSubscriptionVisitTimeByIdAsync(int id);
        Task AddSubscriptionVisitTimeAsync(SubscriptionVisitTimeViewModel subscriptionVisitTimeViewModel);
        Task UpdateSubscriptionVisitTimeAsync(SubscriptionVisitTimeViewModel subscriptionVisitTimeViewModel);
        Task DeleteSubscriptionVisitTimeAsync(int id);
    }
}
