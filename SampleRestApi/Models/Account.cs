namespace SampleRestApi.Models
{
    public class Account
    {
        public long IdAccount { get; set; }
        public string Number { get; set; } = string.Empty;
        public string Agency { get; set; } = string.Empty;
        public double Balance { get; set; }
        public double Limit { get; set; }
        public long IdUser { get; set; }
        public User? User { get; set; }
    }
}