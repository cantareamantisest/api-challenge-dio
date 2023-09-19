using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SampleRestApi.ViewModels
{
    public class AccountViewModel
    {
        [Key]
        [JsonIgnore]
        public long IdAccount { get; set; }

        [Required]
        [StringLength(100)]
        public string Number { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Agency { get; set; } = string.Empty;

        [Required]
        public double Balance { get; set; }

        [Required]
        public double Limit { get; set; }

        [JsonIgnore]
        public long IdUser { get; set; }

        [JsonIgnore]
        public UserViewModel? User { get; set; }
    }
}