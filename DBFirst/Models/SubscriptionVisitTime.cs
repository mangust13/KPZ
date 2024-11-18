using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBFirst.Models
{
    public class SubscriptionVisitTime
    {
        [Key]
        public int SubscriptionVisitTimeId { get; set; }

        [Required]
        [MaxLength(255)]
        public string SubscriptionVisitTimeName { get; set; }
    }
}
