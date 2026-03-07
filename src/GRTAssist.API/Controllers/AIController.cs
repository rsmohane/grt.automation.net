using GRTAssist.API.DTOs;
using GRTAssist.API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GRTAssist.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class AIController : ControllerBase
    {
        private readonly IAIService _aiService;

        public AIController(IAIService aiService)
        {
            _aiService = aiService;
        }

        [HttpPost("chat")]
        public async Task<IActionResult> Chat([FromBody] CreateAIRequestDto requestDto)
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
            {
                return Unauthorized();
            }

            var response = await _aiService.ProcessRequestAsync(userId, requestDto);
            return Ok(response);
        }

        [HttpPost("suggestions/automation")]
        public async Task<IActionResult> GetAutomationSuggestions([FromBody] string context)
        {
            var suggestions = await _aiService.GetAutomationSuggestionsAsync(context);
            return Ok(new { Suggestions = suggestions });
        }

        [HttpPost("suggestions/seo")]
        public async Task<IActionResult> GetSEOSuggestions([FromBody] string content)
        {
            var suggestions = await _aiService.GetSEOSuggestionsAsync(content);
            return Ok(new { Suggestions = suggestions });
        }

        [HttpPost("analyze/market")]
        public async Task<IActionResult> AnalyzeMarketData([FromBody] string data)
        {
            var analysis = await _aiService.AnalyzeMarketDataAsync(data);
            return Ok(new { Analysis = analysis });
        }
    }
}