using System.ComponentModel.DataAnnotations;

namespace Lab4.DAL.Models
{
    public class Client
    {
        [Key]
        public int client_id { get; set; }

        [Required]
        [MaxLength(255)]
        public string client_full_name { get; set; }

        [Range(0, 1)]
        public bool? client_gender { get; set; }

        [MaxLength(15)]
        [Phone]
        public string client_phone_number { get; set; }
    }
}
