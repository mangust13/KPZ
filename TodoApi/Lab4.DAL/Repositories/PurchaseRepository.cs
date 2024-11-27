using Lab4.Abstraction.IRepository;
using Lab4.Abstraction.ViewModels;
using Lab4.DAL.Data;
using Lab4.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab4.DAL.Repositories
{
    public class PurchaseRepository : IPurchaseRepository
    {
        private readonly SportComplexContext _context;

        public PurchaseRepository(SportComplexContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PurchaseViewModel>> GetAllAsync()
        {
            return await _context.Purchases
                .Include(p => p.Client)
                .Include(p => p.PaymentMethod)
                .Select(p => new PurchaseViewModel
                {
                    Id = p.purchase_id,
                    ClientFullName = p.Client.client_full_name,
                    SubscriptionId = p.subscription_id,
                    PaymentMethodName = p.PaymentMethod.payment_method,
                    PurchaseNumber = p.purchase_number,
                    PurchaseDate = p.purchase_date
                })
                .ToListAsync();
        }

        public async Task<PurchaseViewModel> GetByIdAsync(int id)
        {
            var purchase = await _context.Purchases
                .Include(p => p.Client)
                .Include(p => p.PaymentMethod)
                .FirstOrDefaultAsync(p => p.purchase_id == id);

            if (purchase == null) return null;

            return new PurchaseViewModel
            {
                Id = purchase.purchase_id,
                ClientFullName = purchase.Client.client_full_name,
                SubscriptionId = purchase.subscription_id,
                PaymentMethodName = purchase.PaymentMethod.payment_method,
                PurchaseNumber = purchase.purchase_number,
                PurchaseDate = purchase.purchase_date
            };
        }

        public async Task AddAsync(PurchaseViewModel purchaseViewModel)
        {
            var purchase = new Purchase
            {
                subscription_id = purchaseViewModel.SubscriptionId,
                purchase_number = purchaseViewModel.PurchaseNumber,
                purchase_date = purchaseViewModel.PurchaseDate
            };

            _context.Purchases.Add(purchase);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(PurchaseViewModel purchaseViewModel)
        {
            var purchase = await _context.Purchases.FindAsync(purchaseViewModel.Id);
            if (purchase == null) return;

            purchase.subscription_id = purchaseViewModel.SubscriptionId;
            purchase.purchase_number = purchaseViewModel.PurchaseNumber;
            purchase.purchase_date = purchaseViewModel.PurchaseDate;

            _context.Entry(purchase).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var purchase = await _context.Purchases.FindAsync(id);
            if (purchase != null)
            {
                _context.Purchases.Remove(purchase);
                await _context.SaveChangesAsync();
            }
        }
    }
}
