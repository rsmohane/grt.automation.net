namespace GRTAssist.API.Models
{
    public class DataSet
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string FileUrl { get; set; } = string.Empty;
        public decimal Price { get; set; } = 0;
        public bool IsVerified { get; set; } = false;
        public bool IsActive { get; set; } = true;
        public string UploadedByUserId { get; set; } = string.Empty;
        public DateTime UploadedAt { get; set; } = DateTime.UtcNow;
    }
}