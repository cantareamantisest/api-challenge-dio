﻿namespace SampleRestApi.Models
{
    public class User
    {
        public long IdUser { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public virtual Account Account { get; set; }
        public virtual Card Card { get; set; }
        public virtual List<Features> Features { get; set; } = new List<Features>();
        public virtual List<News> News { get; set; } = new List<News>();
    }
}