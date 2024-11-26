using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab4.DAL.Models
{
    public class SubscriptionActivityType
    {
        [Key]
        public int subscription_activity_type_id { get; set; }

        [ForeignKey("Subscription")]
        public int subscription_id { get; set; }

        public Subscription Subscription { get; set; }

        [ForeignKey("ActivityType")]
        public int activity_type_id { get; set; }

        public ActivityType ActivityType { get; set; }

        [Range(1, int.MaxValue)]
        public int activity_type_amount { get; set; }
    }
}