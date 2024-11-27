using Lab4.Abstraction.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lab4.Abstraction.IServices
{
    public interface IPurchaseService
    {
        Task<IEnumerable<PurchaseViewModel>> GetAllPurchasesAsync();
        Task<PurchaseViewModel> GetPurchaseByIdAsync(int id);
        Task AddPurchaseAsync(PurchaseViewModel purchaseViewModel);
        Task UpdatePurchaseAsync(PurchaseViewModel purchaseViewModel);
        Task DeletePurchaseAsync(int id);
    }
}
