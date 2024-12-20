﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab4.DAL.Models
{
    public class Purchase
    {
        [Key]
        public int purchase_id { get; set; }

        [ForeignKey("Client")]
        public int client_id { get; set; }

        public Client Client { get; set; }

        [ForeignKey("Subscription")]
        public int subscription_id { get; set; }

        public Subscription Subscription { get; set; }

        [ForeignKey("PaymentMethod")]
        public int payment_method_id { get; set; }

        public PaymentMethod PaymentMethod { get; set; }

        [Range(1, int.MaxValue)]
        public int purchase_number { get; set; }

        public DateTime purchase_date { get; set; } = DateTime.Now;
    }
}