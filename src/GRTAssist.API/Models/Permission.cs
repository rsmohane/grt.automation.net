namespace GRTAssist.API.Models
{
    public class Permission
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Resource { get; set; } = string.Empty; // e.g., "Users", "APIs", "Payments"
        public string Action { get; set; } = string.Empty; // e.g., "Read", "Write", "Delete"
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation properties
        public virtual ICollection<Role> Roles { get; set; } = new List<Role>();
    }
}