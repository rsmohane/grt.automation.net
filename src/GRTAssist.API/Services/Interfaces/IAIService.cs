using GRTAssist.API.DTOs;

namespace GRTAssist.API.Services.Interfaces
{
    public interface IAIService
    {
        Task<AIRequestDto> ProcessRequestAsync(string userId, CreateAIRequestDto requestDto);
        Task<string> GetChatResponseAsync(string prompt);
        Task<string> GetAutomationSuggestionsAsync(string context);
        Task<string> GetSEOSuggestionsAsync(string content);
        Task<string> AnalyzeMarketDataAsync(string data);
    }
}