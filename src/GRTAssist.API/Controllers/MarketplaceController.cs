using GRTAssist.API.DTOs;
using GRTAssist.API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GRTAssist.API.Controllers
{
    [ApiController]
    [Route("api/marketplace/apis")]
    public class MarketplaceController : ControllerBase
    {
        private readonly IMarketplaceService _marketplace;

        public MarketplaceController(IMarketplaceService marketplace)
        {
            _marketplace = marketplace;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var apis = await _marketplace.GetApisAsync();
            return Ok(apis);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Publish([FromBody] ApiListingDto dto)
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            if (userId == null) return Unauthorized();
            var result = await _marketplace.AddApiListingAsync(dto, userId);
            return CreatedAtAction(nameof(List), new { id = result.Id }, result);
        }
    }
}