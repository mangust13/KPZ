using Lab4.Abstraction.IRepository;
using Lab4.Abstraction.ViewModels;
using Lab4.DAL.Data;
using Lab4.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab4.DAL.Repositories
{
    public class SubscriptionRepository : ISubscriptionRepository
    {
        private readonly SportComplexContext _context;

        public SubscriptionRepository(SportComplexContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SubscriptionViewModel>> GetAllAsync()
        {
            return await _context.Subscriptions
                .Include(s => s.SubscriptionTerm)
                .Include(s => s.SubscriptionVisitTime)
                .Select(s => new SubscriptionViewModel
                {
                    Id = s.subscription_id,
                    TermName = s.SubscriptionTerm.subscription_term,
                    VisitTime = s.SubscriptionVisitTime.subscription_visit_time,
                    TotalCost = s.subscription_total_cost
                })
                .ToListAsync();
        }

        public async Task<SubscriptionViewModel> GetByIdAsync(int id)
        {
            var subscription = await _context.Subscriptions
                .Include(s => s.SubscriptionTerm)
                .Include(s => s.SubscriptionVisitTime)
                .FirstOrDefaultAsync(s => s.subscription_id == id);

            if (subscription == null) return null;

            return new SubscriptionViewModel
            {
                Id = subscription.subscription_id,
                TermName = subscription.SubscriptionTerm.subscription_term,
                VisitTime = subscription.SubscriptionVisitTime.subscription_visit_time,
                TotalCost = subscription.subscription_total_cost
            };
        }

        public async Task AddAsync(SubscriptionViewModel subscriptionViewModel)
        {
            var subscription = new Subscription
            {
                subscription_term_id = subscriptionViewModel.TermId,
                subscription_visit_time_id = subscriptionViewModel.VisitTimeId,
                subscription_total_cost = subscriptionViewModel.TotalCost
            };

            _context.Subscriptions.Add(subscription);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(SubscriptionViewModel subscriptionViewModel)
        {
            var subscription = await _context.Subscriptions.FindAsync(subscriptionViewModel.Id);
            if (subscription == null) return;

            subscription.subscription_term_id = subscriptionViewModel.TermId;
            subscription.subscription_visit_time_id = subscriptionViewModel.VisitTimeId;
            subscription.subscription_total_cost = subscriptionViewModel.TotalCost;

            _context.Entry(subscription).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var subscription = await _context.Subscriptions.FindAsync(id);
            if (subscription != null)
            {
                _context.Subscriptions.Remove(subscription);
                await _context.SaveChangesAsync();
            }
        }
    }
}
