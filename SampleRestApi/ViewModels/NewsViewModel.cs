﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SampleRestApi.ViewModels
{
    public class NewsViewModel
    {
        [Key]
        public long IdNews { get; set; }

        [Required]
        [StringLength(200)]
        public string Icon { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        [JsonIgnore]
        public long IdUser { get; set; }

        [JsonIgnore]
        public virtual UserViewModel? User { get; set; }
    }
}