using Lab4.Abstraction.IServices;
using Lab4.Abstraction.IRepository;
using Lab4.Abstraction.ViewModels;
using Lab4.DAL.Repositories;

namespace Lab4.BLL.Services
{
    public class SubscriptionVisitTimeService : ISubscriptionVisitTimeService
    {
        private readonly ISubscriptionVisitTimeRepository _repository;

        public SubscriptionVisitTimeService(ISubscriptionVisitTimeRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<SubscriptionVisitTimeViewModel>> GetAllSubscriptionVisitTimesAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<SubscriptionVisitTimeViewModel> GetSubscriptionVisitTimeByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddSubscriptionVisitTimeAsync(SubscriptionVisitTimeViewModel subscriptionVisitTimeViewModel)
        {
            await _repository.AddAsync(subscriptionVisitTimeViewModel);
        }

        public async Task UpdateSubscriptionVisitTimeAsync(SubscriptionVisitTimeViewModel subscriptionVisitTimeViewModel)
        {
            await _repository.UpdateAsync(subscriptionVisitTimeViewModel);
        }

        public async Task DeleteSubscriptionVisitTimeAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
