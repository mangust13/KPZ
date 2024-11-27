using Lab4.Abstraction.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lab4.Abstraction.IServices
{
    public interface IPaymentMethodService
    {
        Task<IEnumerable<PaymentMethodViewModel>> GetAllPaymentMethodsAsync();
        Task<PaymentMethodViewModel> GetPaymentMethodByIdAsync(int id);
        Task AddPaymentMethodAsync(PaymentMethodViewModel paymentMethodViewModel);
        Task UpdatePaymentMethodAsync(PaymentMethodViewModel paymentMethodViewModel);
        Task DeletePaymentMethodAsync(int id);
    }
}
