using System.ComponentModel.DataAnnotations;

namespace Lab4.Abstraction.ViewModels
{
    public class SubscriptionViewModel
    {
        public int Id { get; set; }

        [Required]
        public int TermId { get; set; }

        public string TermName { get; set; }

        [Required]
        public int VisitTimeId { get; set; }

        public string VisitTime { get; set; }

        [Range(0, double.MaxValue)]
        public decimal TotalCost { get; set; }
    }
}
