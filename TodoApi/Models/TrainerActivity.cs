using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoApi.Models
{
    public class TrainerActivity
    {
        [Key]
        public int trainer_activity_id { get; set; }

        [ForeignKey("Trainer")]
        public int trainer_id { get; set; }

        public Trainer Trainer { get; set; }

        [ForeignKey("ActivityType")]
        public int activity_type_id { get; set; }

        public ActivityType ActivityType { get; set; }
    }
}