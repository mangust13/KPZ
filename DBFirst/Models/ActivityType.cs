using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBFirst.Models
{
    public class ActivityType
    {
        [Key]
        public int ActivityTypeId { get; set; }

        [Required]
        [MaxLength(255)]
        public string ActivityName { get; set; }

        [Required]
        [MaxLength(255)]
        public string ActivityDescription { get; set; }

        [Range(0, double.MaxValue)]
        public decimal ActivityPrice { get; set; }
    }
}
