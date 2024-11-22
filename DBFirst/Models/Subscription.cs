using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CodeFirst.Models
{
    public class Subscription
    {
        [Key]
        public int SubscriptionId { get; set; }

        [ForeignKey("SubscriptionTerm")]
        public int SubscriptionTermId { get; set; }

        public SubscriptionTerm SubscriptionTerm { get; set; }

        [ForeignKey("SubscriptionVisitTime")]
        public int SubscriptionVisitTimeId { get; set; }

        public SubscriptionVisitTime SubscriptionVisitTime { get; set; }

        [Range(0, double.MaxValue)]
        public decimal SubscriptionTotalCost { get; set; }
    }
}
