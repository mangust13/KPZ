//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Lab_03.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Purchases
    {
        public int purchase_id { get; set; }
        public int client_id { get; set; }
        public int subscription_id { get; set; }
        public int payment_method_id { get; set; }
        public Nullable<int> purchase_number { get; set; }
        public System.DateTime purchase_date { get; set; }
    
        public virtual Clients Clients { get; set; }
        public virtual PaymentMethods PaymentMethods { get; set; }
        public virtual Subscriptions Subscriptions { get; set; }
    }
}