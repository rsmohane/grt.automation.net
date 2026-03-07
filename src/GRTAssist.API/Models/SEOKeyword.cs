namespace GRTAssist.API.Models
{
    public class SEOKeyword
    {
        public int Id { get; set; }
        public string Keyword { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public int SearchVolume { get; set; }
        public decimal Competition { get; set; }
        public string Suggestions { get; set; } = "[]"; // JSON array of suggestions
        public DateTime LastUpdated { get; set; } = DateTime.UtcNow;
        public bool IsActive { get; set; } = true;
    }
}