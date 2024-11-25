﻿using System.ComponentModel.DataAnnotations;

namespace TodoApi.Models
{
    public class SubscriptionVisitTime
    {
        [Key]
        public int subscription_visit_time_id { get; set; }

        [Required]
        [MaxLength(255)]
        public string subscription_visit_time { get; set; }
    }
}