using Lab4.Abstraction.IServices;
using Lab4.Abstraction.IRepository;
using Lab4.Abstraction.ViewModels;
using Lab4.DAL.Repositories;

namespace Lab4.BLL.Services
{
    public class SubscriptionTermService : ISubscriptionTermService
    {
        private readonly ISubscriptionTermRepository _repository;

        public SubscriptionTermService(ISubscriptionTermRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<SubscriptionTermViewModel>> GetAllSubscriptionTermsAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<SubscriptionTermViewModel> GetSubscriptionTermByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddSubscriptionTermAsync(SubscriptionTermViewModel subscriptionTermViewModel)
        {
            await _repository.AddAsync(subscriptionTermViewModel);
        }

        public async Task UpdateSubscriptionTermAsync(SubscriptionTermViewModel subscriptionTermViewModel)
        {
            await _repository.UpdateAsync(subscriptionTermViewModel);
        }

        public async Task DeleteSubscriptionTermAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
