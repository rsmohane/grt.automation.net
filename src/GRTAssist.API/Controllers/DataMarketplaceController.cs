using GRTAssist.API.DTOs;
using GRTAssist.API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GRTAssist.API.Controllers
{
    [ApiController]
    [Route("api/marketplace/datasets")]
    public class DataMarketplaceController : ControllerBase
    {
        private readonly IMarketplaceService _marketplace;

        public DataMarketplaceController(IMarketplaceService marketplace)
        {
            _marketplace = marketplace;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var sets = await _marketplace.GetDataSetsAsync();
            return Ok(sets);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Upload([FromBody] DataSetDto dto)
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            if (userId == null) return Unauthorized();
            var result = await _marketplace.AddDataSetAsync(dto, userId);
            return CreatedAtAction(nameof(List), new { id = result.Id }, result);
        }

        [HttpPost("verify/{id}")]
        [Authorize(Roles = "SuperAdmin,CompanyAdmin")]
        public async Task<IActionResult> Verify(int id)
        {
            var success = await _marketplace.VerifyDataSetAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}