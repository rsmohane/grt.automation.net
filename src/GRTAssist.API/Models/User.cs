using Microsoft.AspNetCore.Identity;

namespace GRTAssist.API.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? LastLoginAt { get; set; }
        public bool IsActive { get; set; } = true;

        // Navigation properties
        public virtual ICollection<ApiKey> ApiKeys { get; set; } = new List<ApiKey>();
        public virtual ICollection<AutomationJob> AutomationJobs { get; set; } = new List<AutomationJob>();
        public virtual ICollection<AIRequest> AIRequests { get; set; } = new List<AIRequest>();
        public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
        public virtual ICollection<HistoryLog> HistoryLogs { get; set; } = new List<HistoryLog>();
    }
}