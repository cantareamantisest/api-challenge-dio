namespace SampleRestApi.Models
{
    public class Card
    {
        public long IdCard { get; set; }
        public string Number { get; set; } = string.Empty;
        public double Limit { get; set; }
        public long IdUser { get; set; }
        public User User { get; set; }
    }
}