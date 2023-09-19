namespace SampleRestApi.Models
{
    public class News
    {
        public long IdNews { get; set; }
        public string Icon { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public long IdUser { get; set; }
        public virtual User User { get; set; }
    }
}