using GRTAssist.API.DTOs;
using GRTAssist.API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GRTAssist.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class AutomationController : ControllerBase
    {
        private readonly IAutomationService _automationService;

        public AutomationController(IAutomationService automationService)
        {
            _automationService = automationService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateJob([FromBody] CreateAutomationJobDto jobDto)
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
            {
                return Unauthorized();
            }

            var job = await _automationService.CreateJobAsync(userId, jobDto);
            return CreatedAtAction(nameof(GetJob), new { id = job.Id }, job);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetJob(int id)
        {
            var job = await _automationService.GetJobAsync(id);
            if (job == null)
            {
                return NotFound();
            }

            return Ok(job);
        }

        [HttpGet]
        public async Task<IActionResult> GetUserJobs()
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
            {
                return Unauthorized();
            }

            var jobs = await _automationService.GetUserJobsAsync(userId);
            return Ok(jobs);
        }

        [HttpPost("{id}/execute")]
        public async Task<IActionResult> ExecuteJob(int id)
        {
            var success = await _automationService.ExecuteJobAsync(id);
            if (!success)
            {
                return BadRequest("Unable to execute job");
            }

            return Ok(new { Message = "Job execution started" });
        }

        [HttpPost("{id}/cancel")]
        public async Task<IActionResult> CancelJob(int id)
        {
            var success = await _automationService.CancelJobAsync(id);
            if (!success)
            {
                return BadRequest("Unable to cancel job");
            }

            return Ok(new { Message = "Job cancelled" });
        }
    }
}