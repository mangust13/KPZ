using System.ComponentModel.DataAnnotations;

namespace Lab4.Abstraction.ViewModels
{
    public class PurchaseViewModel
    {
        public int Id { get; set; }

        public string ClientFullName { get; set; }

        public int SubscriptionId { get; set; }

        public string PaymentMethodName { get; set; }

        [Range(1, int.MaxValue)]
        public int PurchaseNumber { get; set; }

        public DateTime PurchaseDate { get; set; } = DateTime.Now;
    }
}
