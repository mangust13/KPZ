using System.ComponentModel.DataAnnotations;

namespace Lab4.DAL.Models
{
    public class City
    {
        [Key]
        public int city_id { get; set; }

        [Required]
        [MaxLength(255)]
        public string city_name { get; set; }
    }
}