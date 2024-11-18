using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBFirst.Models
{
    public class SubscriptionActivityType
    {
        [Key]
        public int SubscriptionActivityTypeId { get; set; }

        [ForeignKey("Subscription")]
        public int SubscriptionId { get; set; }

        public Subscription Subscription { get; set; }

        [ForeignKey("ActivityType")]
        public int ActivityTypeId { get; set; }

        public ActivityType ActivityType { get; set; }

        [Range(1, int.MaxValue)]
        public int ActivityTypeAmount { get; set; }
    }
}
