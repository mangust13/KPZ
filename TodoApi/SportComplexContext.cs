using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace TodoApi
{
    public class SportComplexContext : DbContext
    {
        public SportComplexContext(DbContextOptions<SportComplexContext> options) : base(options)
        { 
        }

        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<SubscriptionTerm> SubscriptionTerms { get; set; }
        public DbSet<SubscriptionVisitTime> SubscriptionVisitTimes { get; set; }
        public DbSet<SportComplex> SportComplexes { get; set; }
        public DbSet<Gym> Gyms { get; set; }
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<ActivityType> ActivityTypes { get; set; }
        public DbSet<Training> Trainings { get; set; }
        public DbSet<TrainerActivity> TrainerActivities { get; set; }
        public DbSet<SubscriptionActivityType> SubscriptionActivityTypes { get; set; }
    }
}
