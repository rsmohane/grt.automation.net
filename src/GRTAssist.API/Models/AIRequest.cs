namespace GRTAssist.API.Models
{
    public class AIRequest
    {
        public int Id { get; set; }
        public string UserId { get; set; } = string.Empty;
        public string Prompt { get; set; } = string.Empty;
        public string Response { get; set; } = string.Empty;
        public string Model { get; set; } = "gpt-4";
        public int TokensUsed { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public TimeSpan ResponseTime { get; set; }

        // Navigation property
        public virtual User User { get; set; } = null!;
    }
}