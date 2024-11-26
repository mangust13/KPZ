using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab4.DAL.Models
{
    public class Training
    {
        [Key]
        public int training_id { get; set; }

        [Required]
        public DateTime training_start_date_time { get; set; } = DateTime.Now;

        public DateTime? training_end_date_time { get; set; }

        [ForeignKey("Trainer")]
        public int trainer_id { get; set; }

        public Trainer Trainer { get; set; }

        [ForeignKey("Gym")]
        public int gym_id { get; set; }

        public Gym Gym { get; set; }
    }
}