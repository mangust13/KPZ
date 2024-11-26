using System.ComponentModel.DataAnnotations;

namespace Lab4.DAL.Models
{
    public class ActivityType
    {
        [Key]
        public int activity_type_id { get; set; }

        [Required]
        [MaxLength(255)]
        public string activity_name { get; set; }

        [Required]
        [MaxLength(255)]
        public string activity_description { get; set; }

        [Range(0, double.MaxValue)]
        public decimal activity_price { get; set; }
    }
}