using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.SqlServer;
using System.Runtime.Remoting.Contexts;
using CodeFirst.Models;

namespace CodeFirst.Data
{
    public class SportComplexContext : DbContext
    {
        public SportComplexContext() : base("name=sportComplexEntities") {}

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