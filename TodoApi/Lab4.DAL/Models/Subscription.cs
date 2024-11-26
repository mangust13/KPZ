using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab4.DAL.Models
{
    public class Subscription
    {
        [Key]
        public int subscription_id { get; set; }

        [ForeignKey("SubscriptionTerm")]
        public int subscription_term_id { get; set; }

        public SubscriptionTerm SubscriptionTerm { get; set; }

        [ForeignKey("SubscriptionVisitTime")]
        public int subscription_visit_time_id { get; set; }

        public SubscriptionVisitTime SubscriptionVisitTime { get; set; }

        [Range(0, double.MaxValue)]
        public decimal subscription_total_cost { get; set; }
    }
}
