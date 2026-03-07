namespace GRTAssist.API.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public int PaymentId { get; set; }
        public string Type { get; set; } = string.Empty; // Payment, Refund, Chargeback
        public decimal Amount { get; set; }
        public string Status { get; set; } = "Pending";
        public string GatewayResponse { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation property
        public virtual Payment Payment { get; set; } = null!;
    }
}