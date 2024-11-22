using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Models
{
    public class Trainer
    {
        [Key]
        public int TrainerId { get; set; }

        [ForeignKey("SportComplex")]
        public int SportsComplexId { get; set; }

        [Required]
        [MaxLength(255)]
        public string TrainerFullName { get; set; }

        public bool? TrainerGender { get; set; } // Nullable (0 = Male, 1 = Female)

        [MaxLength(15)]
        public string TrainerPhoneNumber { get; set; }

        public SportComplex SportComplex { get; set; }
    }
}
