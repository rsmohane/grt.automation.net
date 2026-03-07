namespace GRTAssist.API.DTOs
{
    public class AIRequestDto
    {
        public int Id { get; set; }
        public string UserId { get; set; } = string.Empty;
        public string Prompt { get; set; } = string.Empty;
        public string Response { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public int TokensUsed { get; set; }
        public DateTime CreatedAt { get; set; }
        public TimeSpan ResponseTime { get; set; }
    }

    public class CreateAIRequestDto
    {
        public string Prompt { get; set; } = string.Empty;
        public string Model { get; set; } = "gpt-4";
    }
}