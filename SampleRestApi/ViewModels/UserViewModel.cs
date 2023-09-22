using System.ComponentModel.DataAnnotations;

namespace SampleRestApi.ViewModels
{
    public class UserViewModel
    {
        [Key]
        public long IdUser { get; set; }

        [Required]
        [StringLength(100)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        [StringLength(150)]
        public string Email { get; set; } = string.Empty;

        public AccountViewModel? Account { get; set; }

        public CardViewModel? Card { get; set; }

        public virtual List<FeaturesViewModel> Features { get; set; } = new List<FeaturesViewModel>();

        public virtual List<NewsViewModel> News { get; set; } = new List<NewsViewModel>();
    }
}