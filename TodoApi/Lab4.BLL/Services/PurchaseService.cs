using Lab4.Abstraction.IServices;
using Lab4.Abstraction.IRepository;
using Lab4.Abstraction.ViewModels;
using Lab4.DAL.Repositories;

namespace Lab4.BLL.Services
{
    public class PurchaseService : IPurchaseService
    {
        private readonly IPurchaseRepository _repository;

        public PurchaseService(IPurchaseRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<PurchaseViewModel>> GetAllPurchasesAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<PurchaseViewModel> GetPurchaseByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddPurchaseAsync(PurchaseViewModel purchaseViewModel)
        {
            await _repository.AddAsync(purchaseViewModel);
        }

        public async Task UpdatePurchaseAsync(PurchaseViewModel purchaseViewModel)
        {
            await _repository.UpdateAsync(purchaseViewModel);
        }

        public async Task DeletePurchaseAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
