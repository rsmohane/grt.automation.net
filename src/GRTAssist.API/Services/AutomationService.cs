using GRTAssist.API.DTOs;
using GRTAssist.API.Models;
using GRTAssist.API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GRTAssist.API.Services
{
    public class AutomationService : IAutomationService
    {
        private readonly ApplicationDbContext _context;
        private readonly IAIService _aiService;

        public AutomationService(ApplicationDbContext context, IAIService aiService)
        {
            _context = context;
            _aiService = aiService;
        }

        public async Task<AutomationJobDto> CreateJobAsync(string userId, CreateAutomationJobDto jobDto)
        {
            var job = new AutomationJob
            {
                Name = jobDto.Name,
                Description = jobDto.Description,
                UserId = userId,
                Type = jobDto.Type,
                Configuration = jobDto.Configuration,
                ScheduledAt = jobDto.ScheduledAt,
                Status = "Pending"
            };

            _context.AutomationJobs.Add(job);
            await _context.SaveChangesAsync();

            return MapToDto(job);
        }

        public async Task<AutomationJobDto?> GetJobAsync(int jobId)
        {
            var job = await _context.AutomationJobs.FindAsync(jobId);
            return job != null ? MapToDto(job) : null;
        }

        public async Task<IEnumerable<AutomationJobDto>> GetUserJobsAsync(string userId)
        {
            var jobs = await _context.AutomationJobs
                .Where(j => j.UserId == userId)
                .OrderByDescending(j => j.CreatedAt)
                .ToListAsync();

            return jobs.Select(MapToDto);
        }

        public async Task<bool> ExecuteJobAsync(int jobId)
        {
            var job = await _context.AutomationJobs.FindAsync(jobId);
            if (job == null || job.Status != "Pending")
            {
                return false;
            }

            job.Status = "Running";
            job.StartedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();

            try
            {
                // Execute based on job type
                string result = await ExecuteJobTypeAsync(job);

                job.Status = "Completed";
                job.CompletedAt = DateTime.UtcNow;
                job.Result = result;
            }
            catch (Exception ex)
            {
                job.Status = "Failed";
                job.CompletedAt = DateTime.UtcNow;
                job.ErrorMessage = ex.Message;
            }

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> CancelJobAsync(int jobId)
        {
            var job = await _context.AutomationJobs.FindAsync(jobId);
            if (job == null || job.Status != "Pending")
            {
                return false;
            }

            job.Status = "Cancelled";
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task ProcessScheduledJobsAsync()
        {
            var now = DateTime.UtcNow;
            var jobs = await _context.AutomationJobs
                .Where(j => j.Status == "Pending" && j.ScheduledAt <= now)
                .ToListAsync();

            foreach (var job in jobs)
            {
                await ExecuteJobAsync(job.Id);
            }
        }

        private async Task<string> ExecuteJobTypeAsync(AutomationJob job)
        {
            return job.Type switch
            {
                "AI_Suggestion" => await _aiService.GetAutomationSuggestionsAsync(job.Configuration),
                "SEO_Update" => await _aiService.GetSEOSuggestionsAsync(job.Configuration),
                "Market_Analysis" => await _aiService.AnalyzeMarketDataAsync(job.Configuration),
                _ => "Job executed successfully"
            };
        }

        private static AutomationJobDto MapToDto(AutomationJob job)
        {
            return new AutomationJobDto
            {
                Id = job.Id,
                Name = job.Name,
                Description = job.Description,
                UserId = job.UserId,
                Type = job.Type,
                Status = job.Status,
                Configuration = job.Configuration,
                CreatedAt = job.CreatedAt,
                ScheduledAt = job.ScheduledAt,
                StartedAt = job.StartedAt,
                CompletedAt = job.CompletedAt,
                Result = job.Result,
                ErrorMessage = job.ErrorMessage
            };
        }
    }
}