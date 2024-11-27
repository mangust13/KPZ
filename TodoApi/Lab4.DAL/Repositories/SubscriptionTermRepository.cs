using Lab4.Abstraction.IRepository;
using Lab4.Abstraction.ViewModels;
using Lab4.DAL.Data;
using Lab4.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab4.DAL.Repositories
{
    public class SubscriptionTermRepository : ISubscriptionTermRepository
    {
        private readonly SportComplexContext _context;

        public SubscriptionTermRepository(SportComplexContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SubscriptionTermViewModel>> GetAllAsync()
        {
            return await _context.SubscriptionTerms
                .Select(st => new SubscriptionTermViewModel
                {
                    Id = st.subscription_term_id,
                    Term = st.subscription_term
                })
                .ToListAsync();
        }

        public async Task<SubscriptionTermViewModel> GetByIdAsync(int id)
        {
            var subscriptionTerm = await _context.SubscriptionTerms.FindAsync(id);
            if (subscriptionTerm == null) return null;

            return new SubscriptionTermViewModel
            {
                Id = subscriptionTerm.subscription_term_id,
                Term = subscriptionTerm.subscription_term
            };
        }

        public async Task AddAsync(SubscriptionTermViewModel subscriptionTermViewModel)
        {
            var subscriptionTerm = new SubscriptionTerm
            {
                subscription_term = subscriptionTermViewModel.Term
            };

            _context.SubscriptionTerms.Add(subscriptionTerm);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(SubscriptionTermViewModel subscriptionTermViewModel)
        {
            var subscriptionTerm = await _context.SubscriptionTerms.FindAsync(subscriptionTermViewModel.Id);
            if (subscriptionTerm == null) return;

            subscriptionTerm.subscription_term = subscriptionTermViewModel.Term;

            _context.Entry(subscriptionTerm).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var subscriptionTerm = await _context.SubscriptionTerms.FindAsync(id);
            if (subscriptionTerm != null)
            {
                _context.SubscriptionTerms.Remove(subscriptionTerm);
                await _context.SaveChangesAsync();
            }
        }
    }
}
