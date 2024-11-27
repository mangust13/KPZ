using Lab4.Abstraction.IServices;
using Lab4.Abstraction.IRepository;
using Lab4.Abstraction.ViewModels;
using Lab4.DAL.Repositories;

namespace Lab4.BLL.Services
{
    public class SubscriptionService : ISubscriptionService
    {
        private readonly ISubscriptionRepository _repository;

        public SubscriptionService(ISubscriptionRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<SubscriptionViewModel>> GetAllSubscriptionsAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<SubscriptionViewModel> GetSubscriptionByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddSubscriptionAsync(SubscriptionViewModel subscriptionViewModel)
        {
            await _repository.AddAsync(subscriptionViewModel);
        }

        public async Task UpdateSubscriptionAsync(SubscriptionViewModel subscriptionViewModel)
        {
            await _repository.UpdateAsync(subscriptionViewModel);
        }

        public async Task DeleteSubscriptionAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
