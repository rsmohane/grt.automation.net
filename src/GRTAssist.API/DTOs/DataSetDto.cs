namespace GRTAssist.API.DTOs
{
    public class DataSetDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public bool IsVerified { get; set; }
        public bool IsActive { get; set; }
    }
}