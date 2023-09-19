using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SampleRestApi.ViewModels
{
    public class FeaturesViewModel
    {
        [Key]
        public long IdFeature { get; set; }

        [Required]
        [StringLength(200)]
        public string Icon { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Description { get; set; } = string.Empty;

        [JsonIgnore]
        public long IdUser { get; set; }

        [JsonIgnore]
        public virtual UserViewModel? User { get; set; }
    }
}