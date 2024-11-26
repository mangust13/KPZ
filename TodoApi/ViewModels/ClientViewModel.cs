using System.ComponentModel.DataAnnotations;

namespace TodoApi.ViewModels
{
    public class ClientViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле 'FullName' є обов'язковим")]
        [MaxLength(255, ErrorMessage = "Максимальна довжина імені — 255 символів")]
        public string FullName { get; set; }

        [Phone(ErrorMessage = "Поле 'PhoneNumber' повинно бути у форматі телефону")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Поле 'Gender' є обов'язковим")]
        [RegularExpression("^(Чоловік|Жінка)$", ErrorMessage = "Стать повинна бути 'Чоловік' або 'Жінка'")]
        public string Gender { get; set; }
    }
}
