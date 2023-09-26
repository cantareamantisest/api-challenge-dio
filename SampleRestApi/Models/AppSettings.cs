namespace SampleRestApi.Models
{
    public class AppSettings
    {
        public long Id { get; set; }
        public string Hostname { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}