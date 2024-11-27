using Lab4.Abstraction.IServices;
using Lab4.Abstraction.IRepository;
using Lab4.Abstraction.ViewModels;
using Lab4.DAL.Repositories;

namespace Lab4.BLL.Services
{
    public class PaymentMethodService : IPaymentMethodService
    {
        private readonly IPaymentMethodRepository _repository;

        public PaymentMethodService(IPaymentMethodRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<PaymentMethodViewModel>> GetAllPaymentMethodsAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<PaymentMethodViewModel> GetPaymentMethodByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddPaymentMethodAsync(PaymentMethodViewModel paymentMethodViewModel)
        {
            await _repository.AddAsync(paymentMethodViewModel);
        }

        public async Task UpdatePaymentMethodAsync(PaymentMethodViewModel paymentMethodViewModel)
        {
            await _repository.UpdateAsync(paymentMethodViewModel);
        }

        public async Task DeletePaymentMethodAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
