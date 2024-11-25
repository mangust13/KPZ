using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoApi.Models
{
    public class SportComplex
    {
        [Key]
        public int sports_complex_id { get; set; }

        [Required]
        [MaxLength(255)]
        public string complex_address { get; set; }

        [ForeignKey("City")]
        public int complex_city_id { get; set; }

        public City City { get; set; }
    }
}