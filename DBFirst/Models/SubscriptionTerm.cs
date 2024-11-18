using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBFirst.Models
{
    public class SubscriptionTerm
    {
        [Key]
        public int SubscriptionTermId { get; set; }

        [Required]
        [MaxLength(255)]
        public string SubscriptionTermName { get; set; }
    }
}
