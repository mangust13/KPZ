namespace Lab_03.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Client
    {
        [Key]
        public int client_id { get; set; }

        [Required]
        [StringLength(100)]
        public string client_full_name { get; set; }

        public bool? client_gender { get; set; }

        [Phone]
        public string client_phone_number { get; set; }
        //public string Email { get; set; }
    }
}
