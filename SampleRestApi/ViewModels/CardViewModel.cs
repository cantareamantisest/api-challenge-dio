using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SampleRestApi.ViewModels
{
    public class CardViewModel
    {
        [Key]
        [JsonIgnore]
        public long IdCard { get; set; }

        [Required]
        [StringLength(50)]
        public string Number { get; set; } = string.Empty;

        [Required]
        public double Limit { get; set; }

        [JsonIgnore]
        public long IdUser { get; set; }

        [JsonIgnore]
        public virtual UserViewModel? User { get; set; }
    }
}