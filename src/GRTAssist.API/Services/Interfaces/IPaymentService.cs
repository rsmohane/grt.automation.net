using GRTAssist.API.DTOs;

namespace GRTAssist.API.Services.Interfaces
{
    public interface IPaymentService
    {
        Task<string> CreatePaymentIntentAsync(string userId, decimal amount, string currency, string description);
        Task<bool> ConfirmPaymentAsync(string paymentIntentId);
        Task<bool> ProcessRefundAsync(string paymentId, decimal amount);
        Task<IEnumerable<PaymentDto>> GetUserPaymentsAsync(string userId);
    }
}