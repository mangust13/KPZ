namespace CodeFirst.Models
{
    using System.ComponentModel.DataAnnotations;

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
