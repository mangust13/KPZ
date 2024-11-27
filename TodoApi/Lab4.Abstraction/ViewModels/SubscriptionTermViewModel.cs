using System.ComponentModel.DataAnnotations;

namespace Lab4.Abstraction.ViewModels
{
    public class SubscriptionTermViewModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Term { get; set; }
    }
}
