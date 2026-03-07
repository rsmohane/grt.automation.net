namespace GRTAssist.API.Models
{
    public class HistoryLog
    {
        public int Id { get; set; }
        public string UserId { get; set; } = string.Empty;
        public string Action { get; set; } = string.Empty; // e.g., "Login", "Payment", "API Call"
        public string EntityType { get; set; } = string.Empty; // e.g., "User", "Payment", "AutomationJob"
        public string EntityId { get; set; } = string.Empty;
        public string Details { get; set; } = "{}"; // JSON details
        public string IPAddress { get; set; } = string.Empty;
        public string UserAgent { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation property
        public virtual User User { get; set; } = null!;
    }
}