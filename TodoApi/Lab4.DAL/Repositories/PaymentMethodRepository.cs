using Lab4.Abstraction.IRepository;
using Lab4.Abstraction.ViewModels;
using Lab4.DAL.Data;
using Lab4.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab4.DAL.Repositories
{
    public class PaymentMethodRepository : IPaymentMethodRepository
    {
        private readonly SportComplexContext _context;

        public PaymentMethodRepository(SportComplexContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PaymentMethodViewModel>> GetAllAsync()
        {
            return await _context.PaymentMethods
                .Select(pm => new PaymentMethodViewModel
                {
                    Id = pm.payment_method_id,
                    Method = pm.payment_method
                })
                .ToListAsync();
        }

        public async Task<PaymentMethodViewModel> GetByIdAsync(int id)
        {
            var paymentMethod = await _context.PaymentMethods.FindAsync(id);
            if (paymentMethod == null) return null;

            return new PaymentMethodViewModel
            {
                Id = paymentMethod.payment_method_id,
                Method = paymentMethod.payment_method
            };
        }

        public async Task AddAsync(PaymentMethodViewModel paymentMethodViewModel)
        {
            var paymentMethod = new PaymentMethod
            {
                payment_method = paymentMethodViewModel.Method
            };

            _context.PaymentMethods.Add(paymentMethod);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(PaymentMethodViewModel paymentMethodViewModel)
        {
            var paymentMethod = await _context.PaymentMethods.FindAsync(paymentMethodViewModel.Id);
            if (paymentMethod == null) return;

            paymentMethod.payment_method = paymentMethodViewModel.Method;

            _context.Entry(paymentMethod).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var paymentMethod = await _context.PaymentMethods.FindAsync(id);
            if (paymentMethod != null)
            {
                _context.PaymentMethods.Remove(paymentMethod);
                await _context.SaveChangesAsync();
            }
        }
    }
}
