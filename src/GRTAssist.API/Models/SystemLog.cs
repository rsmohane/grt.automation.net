namespace GRTAssist.API.Models
{
    public class SystemLog
    {
        public int Id { get; set; }
        public string Level { get; set; } = "Info"; // Info, Warning, Error
        public string Message { get; set; } = string.Empty;
        public string Source { get; set; } = string.Empty; // Service or component name
        public string Details { get; set; } = "{}"; // JSON details
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}