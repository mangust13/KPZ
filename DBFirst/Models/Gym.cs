using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBFirst.Models
{
    public class Gym
    {
        [Key]
        public int GymId { get; set; }

        [Range(1, int.MaxValue)]
        public int GymNumber { get; set; }

        [Range(1, int.MaxValue)]
        public int GymCapacity { get; set; }

        [ForeignKey("SportComplex")]
        public int SportsComplexId { get; set; }

        public SportComplex SportComplex { get; set; }
    }
}
