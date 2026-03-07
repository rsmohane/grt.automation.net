using GRTAssist.API.Services.Interfaces;
using Hangfire;

namespace GRTAssist.API.BackgroundJobs
{
    public class AutomationJobProcessor
    {
        private readonly IAutomationService _automationService;

        public AutomationJobProcessor(IAutomationService automationService)
        {
            _automationService = automationService;
        }

        [AutomaticRetry(Attempts = 3)]
        public async Task ProcessScheduledJobs()
        {
            await _automationService.ProcessScheduledJobsAsync();
        }

        public static void ScheduleRecurringJobs()
        {
            RecurringJob.AddOrUpdate<AutomationJobProcessor>(
                "process-scheduled-jobs",
                x => x.ProcessScheduledJobs(),
                Cron.Minutely); // Run every minute
        }
    }
}