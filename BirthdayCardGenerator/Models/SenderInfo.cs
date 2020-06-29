using System.ComponentModel.DataAnnotations;

namespace BirthdayCardGenerator.Models
{
    public class SenderInfo
    {
        [Required(ErrorMessage = "Please enter From:")]
        public string From { get; set; }
        [Required(ErrorMessage = "Please enter To:")]
        public string To { get; set; }
        [Required(ErrorMessage = "Please enter Message:")]
        public string Message { get; set; }
    }
}
