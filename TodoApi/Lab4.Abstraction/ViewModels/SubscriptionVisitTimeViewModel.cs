using System.ComponentModel.DataAnnotations;

namespace Lab4.Abstraction.ViewModels
{
    public class SubscriptionVisitTimeViewModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string VisitTime { get; set; }
    }
}
