using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Models
{
    public class SportComplex
    {
        [Key]
        public int SportsComplexId { get; set; }

        [Required]
        [MaxLength(255)]
        public string ComplexAddress { get; set; }

        [ForeignKey("City")]
        public int ComplexCityId { get; set; }

        public City City { get; set; }
    }
}
