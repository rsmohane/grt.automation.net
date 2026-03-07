using Microsoft.AspNetCore.Identity;

namespace GRTAssist.API.Models
{
    public class Role : IdentityRole
    {
        public string Description { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation properties
        public virtual ICollection<Permission> Permissions { get; set; } = new List<Permission>();
    }
}