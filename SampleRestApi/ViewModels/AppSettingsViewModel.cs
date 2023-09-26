using System.ComponentModel.DataAnnotations;

namespace SampleRestApi.ViewModels
{
    public class AppSettingsViewModel
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public string Hostname { get; set; } = string.Empty;

        [Required]
        public string Username { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;
    }
}