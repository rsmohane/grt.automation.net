namespace GRTAssist.API.Models
{
    public class AutomationJob
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string UserId { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty; // e.g., "Scheduled", "Trigger", "AI"
        public string Status { get; set; } = "Pending"; // Pending, Running, Completed, Failed
        public string Configuration { get; set; } = "{}"; // JSON configuration
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? ScheduledAt { get; set; }
        public DateTime? StartedAt { get; set; }
        public DateTime? CompletedAt { get; set; }
        public string? Result { get; set; }
        public string? ErrorMessage { get; set; }

        // Navigation property
        public virtual User User { get; set; } = null!;
    }
}