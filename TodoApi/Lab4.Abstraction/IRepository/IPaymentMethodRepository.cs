using Lab4.Abstraction.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lab4.Abstraction.IRepository
{
    public interface IPaymentMethodRepository
    {
        Task<IEnumerable<PaymentMethodViewModel>> GetAllAsync();
        Task<PaymentMethodViewModel> GetByIdAsync(int id);
        Task AddAsync(PaymentMethodViewModel paymentMethodViewModel);
        Task UpdateAsync(PaymentMethodViewModel paymentMethodViewModel);
        Task DeleteAsync(int id);
    }
}
