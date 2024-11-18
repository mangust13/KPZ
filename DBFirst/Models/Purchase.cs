using Lab_03.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBFirst.Models
{
    public class Purchase
    {
        [Key]
        public int PurchaseId { get; set; }

        [ForeignKey("Client")]
        public int ClientId { get; set; }

        public Client Client { get; set; }

        [ForeignKey("Subscription")]
        public int SubscriptionId { get; set; }

        public Subscription Subscription { get; set; }

        [ForeignKey("PaymentMethod")]
        public int PaymentMethodId { get; set; }

        public PaymentMethod PaymentMethod { get; set; }

        [Range(1, int.MaxValue)]
        public int PurchaseNumber { get; set; }

        public DateTime PurchaseDate { get; set; } = DateTime.Now;
    }
}
