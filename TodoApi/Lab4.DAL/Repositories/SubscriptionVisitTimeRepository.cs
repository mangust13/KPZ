using Lab4.Abstraction.IRepository;
using Lab4.Abstraction.ViewModels;
using Lab4.DAL.Data;
using Lab4.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab4.DAL.Repositories
{
    public class SubscriptionVisitTimeRepository : ISubscriptionVisitTimeRepository
    {
        private readonly SportComplexContext _context;

        public SubscriptionVisitTimeRepository(SportComplexContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SubscriptionVisitTimeViewModel>> GetAllAsync()
        {
            return await _context.SubscriptionVisitTimes
                .Select(svt => new SubscriptionVisitTimeViewModel
                {
                    Id = svt.subscription_visit_time_id,
                    VisitTime = svt.subscription_visit_time
                })
                .ToListAsync();
        }

        public async Task<SubscriptionVisitTimeViewModel> GetByIdAsync(int id)
        {
            var subscriptionVisitTime = await _context.SubscriptionVisitTimes.FindAsync(id);
            if (subscriptionVisitTime == null) return null;

            return new SubscriptionVisitTimeViewModel
            {
                Id = subscriptionVisitTime.subscription_visit_time_id,
                VisitTime = subscriptionVisitTime.subscription_visit_time
            };
        }

        public async Task AddAsync(SubscriptionVisitTimeViewModel subscriptionVisitTimeViewModel)
        {
            var subscriptionVisitTime = new SubscriptionVisitTime
            {
                subscription_visit_time = subscriptionVisitTimeViewModel.VisitTime
            };

            _context.SubscriptionVisitTimes.Add(subscriptionVisitTime);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(SubscriptionVisitTimeViewModel subscriptionVisitTimeViewModel)
        {
            var subscriptionVisitTime = await _context.SubscriptionVisitTimes.FindAsync(subscriptionVisitTimeViewModel.Id);
            if (subscriptionVisitTime == null) return;

            subscriptionVisitTime.subscription_visit_time = subscriptionVisitTimeViewModel.VisitTime;

            _context.Entry(subscriptionVisitTime).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var subscriptionVisitTime = await _context.SubscriptionVisitTimes.FindAsync(id);
            if (subscriptionVisitTime != null)
            {
                _context.SubscriptionVisitTimes.Remove(subscriptionVisitTime);
                await _context.SaveChangesAsync();
            }
        }
    }
}
