namespace GRTAssist.API.Models
{
    public class SearchLog
    {
        public int Id { get; set; }
        public string UserId { get; set; } = string.Empty;
        public string Query { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public int ResultCount { get; set; }
        public DateTime SearchedAt { get; set; } = DateTime.UtcNow;
        public TimeSpan ResponseTime { get; set; }

        // Navigation property
        public virtual User? User { get; set; }
    }
}