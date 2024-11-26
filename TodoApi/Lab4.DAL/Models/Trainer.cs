using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab4.DAL.Models
{
    public class Trainer
    {
        [Key]
        public int trainer_id { get; set; }

        [ForeignKey("SportComplex")]
        public int sports_complex_id { get; set; }

        [Required]
        [MaxLength(255)]
        public string trainer_full_name { get; set; }

        [Range(0, 1)]
        public bool? trainer_gender { get; set; }

        [MaxLength(15)]
        [Phone]
        public string trainer_phone_number { get; set; }

        public SportComplex SportComplex { get; set; }
    }
}
