using System.ComponentModel.DataAnnotations;

namespace SampleRestApi.ViewModels
{
    public class SmtpServerViewModel
    {
        [Required]
        public string Host { get; set; } = string.Empty;

        [Required]
        public string Username { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;
    }
}