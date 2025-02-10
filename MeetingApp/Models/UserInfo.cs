using System.ComponentModel.DataAnnotations;

namespace MeetingApp.Models
{
    public class UserInfo
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Ad alanı zorunludur") ]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Telefon alanı zorunludur")]
        public string? Phone { get; set; }

        [Required (ErrorMessage = "Mail alanı zorunludur")]
        [EmailAddress(ErrorMessage = "Hatalı email")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Bir katılma durumu seçiniz ")]
        public bool? WillAttend  { get; set; }
    }
}
