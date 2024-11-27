using System.ComponentModel.DataAnnotations;

namespace Lab4.Abstraction.ViewModels
{
    public class PaymentMethodViewModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Method { get; set; }
    }
}
