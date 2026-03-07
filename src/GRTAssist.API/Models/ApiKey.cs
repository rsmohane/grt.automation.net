namespace GRTAssist.API.Models
{
    public class ApiKey
    {
        public int Id { get; set; }
        public string Key { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string UserId { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? ExpiresAt { get; set; }
        public bool IsActive { get; set; } = true;
        public int RequestCount { get; set; } = 0;
        public int RequestLimit { get; set; } = 1000; // per day or month

        // Navigation property
        public virtual User User { get; set; } = null!;
    }
}