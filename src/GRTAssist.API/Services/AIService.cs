using GRTAssist.API.DTOs;
using GRTAssist.API.Models;
using GRTAssist.API.Services.Interfaces;

namespace GRTAssist.API.Services
{
    public class AIService : IAIService
    {
        private readonly ApplicationDbContext _context;

        public AIService(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            // TODO: Initialize OpenAI client when configured
        }

        public async Task<AIRequestDto> ProcessRequestAsync(string userId, CreateAIRequestDto requestDto)
        {
            var startTime = DateTime.UtcNow;

            // Mock AI response for now
            string response = $"AI Response to: {requestDto.Prompt}";
            int tokensUsed = requestDto.Prompt.Length / 4; // Rough estimation

            var aiRequest = new AIRequest
            {
                UserId = userId,
                Prompt = requestDto.Prompt,
                Response = response,
                Model = requestDto.Model,
                TokensUsed = tokensUsed,
                ResponseTime = DateTime.UtcNow - startTime
            };

            _context.AIRequests.Add(aiRequest);
            await _context.SaveChangesAsync();

            return MapToDto(aiRequest);
        }

        public async Task<string> GetChatResponseAsync(string prompt)
        {
            // Mock implementation
            return $"Mock AI response to: {prompt}";
        }

        public async Task<string> GetAutomationSuggestionsAsync(string context)
        {
            return $"Based on {context}, here are some automation suggestions...";
        }

        public async Task<string> GetSEOSuggestionsAsync(string content)
        {
            return $"SEO suggestions for content: {content}";
        }

        public async Task<string> AnalyzeMarketDataAsync(string data)
        {
            return $"Market analysis for: {data}";
        }

        private static AIRequestDto MapToDto(AIRequest request)
        {
            return new AIRequestDto
            {
                Id = request.Id,
                UserId = request.UserId,
                Prompt = request.Prompt,
                Response = request.Response,
                Model = request.Model,
                TokensUsed = request.TokensUsed,
                CreatedAt = request.CreatedAt,
                ResponseTime = request.ResponseTime
            };
        }
    }
}