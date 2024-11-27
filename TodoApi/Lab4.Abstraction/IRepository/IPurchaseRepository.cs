using Lab4.Abstraction.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lab4.Abstraction.IRepository
{
    public interface IPurchaseRepository
    {
        Task<IEnumerable<PurchaseViewModel>> GetAllAsync();
        Task<PurchaseViewModel> GetByIdAsync(int id);
        Task AddAsync(PurchaseViewModel purchaseViewModel);
        Task UpdateAsync(PurchaseViewModel purchaseViewModel);
        Task DeleteAsync(int id);
    }
}
