using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Models
{
    public class TrainerActivity
    {
        [Key]
        public int TrainerActivityId { get; set; }

        [ForeignKey("Trainer")]
        public int TrainerId { get; set; }

        public Trainer Trainer { get; set; }

        [ForeignKey("ActivityType")]
        public int ActivityTypeId { get; set; }

        public ActivityType ActivityType { get; set; }
    }
}
