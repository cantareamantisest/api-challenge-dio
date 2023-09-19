using System.ComponentModel.DataAnnotations;

namespace SampleRestApi.ViewModels
{
    public class UserViewModel
    {
        [Key]
        public long IdUser { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        public AccountViewModel? Account { get; set; }

        public CardViewModel? Card { get; set; }

        public virtual List<FeaturesViewModel> Features { get; set; } = new List<FeaturesViewModel>();

        public virtual List<NewsViewModel> News { get; set; } = new List<NewsViewModel>();
    }
}