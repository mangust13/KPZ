using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBFirst.Models
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
