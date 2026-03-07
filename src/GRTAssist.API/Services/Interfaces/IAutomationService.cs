using GRTAssist.API.DTOs;

namespace GRTAssist.API.Services.Interfaces
{
    public interface IAutomationService
    {
        Task<AutomationJobDto> CreateJobAsync(string userId, CreateAutomationJobDto jobDto);
        Task<AutomationJobDto?> GetJobAsync(int jobId);
        Task<IEnumerable<AutomationJobDto>> GetUserJobsAsync(string userId);
        Task<bool> ExecuteJobAsync(int jobId);
        Task<bool> CancelJobAsync(int jobId);
        Task ProcessScheduledJobsAsync();
    }
}