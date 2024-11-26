using System.ComponentModel.DataAnnotations;

namespace Lab4.DAL.Models
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
