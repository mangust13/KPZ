using System.ComponentModel.DataAnnotations;

namespace Lab4.Abstraction.ViewModels
{
    public class ActivityTypeViewModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [Required]
        [MaxLength(255)]
        public string Description { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }
    }
}
