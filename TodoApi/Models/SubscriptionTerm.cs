using System.ComponentModel.DataAnnotations;

namespace TodoApi.Models
{
    public class SubscriptionTerm
    {
        [Key]
        public int subscription_term_id { get; set; }

        [Required]
        [MaxLength(255)]
        public string subscription_term { get; set; }
    }
}
