namespace GRTAssist.API.Models
{
    public class MarketData
    {
        public int Id { get; set; }
        public string Source { get; set; } = string.Empty; // API source name
        public string Category { get; set; } = string.Empty; // Business, Government, News, etc.
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Data { get; set; } = "{}"; // JSON data
        public string Location { get; set; } = string.Empty;
        public DateTime PublishedAt { get; set; }
        public DateTime FetchedAt { get; set; } = DateTime.UtcNow;
        public bool IsActive { get; set; } = true;
    }
}