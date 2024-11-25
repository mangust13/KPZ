using System.ComponentModel.DataAnnotations;

namespace TodoApi.Models
{
    public class PaymentMethod
    {
        [Key]
        public int payment_method_id { get; set; }

        [Required]
        [MaxLength(255)]
        public string payment_method { get; set; }
    }
}
