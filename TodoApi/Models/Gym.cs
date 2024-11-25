using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoApi.Models
{
    public class Gym
    {
        [Key]
        public int gym_id { get; set; }

        [Range(1, int.MaxValue)]
        public int gym_number { get; set; }

        [Range(1, int.MaxValue)]
        public int gym_capacity { get; set; }

        [ForeignKey("SportComplex")]
        public int sports_complex_id { get; set; }

        public SportComplex SportComplex { get; set; }
    }
}
