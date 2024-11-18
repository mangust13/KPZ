using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBFirst.Models
{
    public class Training
    {
        [Key]
        public int TrainingId { get; set; }

        [Required]
        public DateTime TrainingStartDateTime { get; set; } = DateTime.Now;

        public DateTime? TrainingEndDateTime { get; set; }

        [ForeignKey("Trainer")]
        public int TrainerId { get; set; }

        public Trainer Trainer { get; set; }

        [ForeignKey("Gym")]
        public int GymId { get; set; }

        public Gym Gym { get; set; }
    }
}
