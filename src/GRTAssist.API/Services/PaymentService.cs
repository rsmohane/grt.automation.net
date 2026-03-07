using GRTAssist.API.DTOs;
using GRTAssist.API.Models;
using GRTAssist.API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Stripe;

namespace GRTAssist.API.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly ApplicationDbContext _context;
        private readonly string _stripeSecretKey;

        public PaymentService(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _stripeSecretKey = configuration["Stripe:SecretKey"] ?? "";
            if (!string.IsNullOrEmpty(_stripeSecretKey))
            {
                StripeConfiguration.ApiKey = _stripeSecretKey;
            }
        }

        public async Task<string> CreatePaymentIntentAsync(string userId, decimal amount, string currency, string description)
        {
            if (string.IsNullOrEmpty(_stripeSecretKey))
            {
                throw new Exception("Payment service is not configured.");
            }

            var options = new PaymentIntentCreateOptions
            {
                Amount = (long)(amount * 100), // Convert to cents
                Currency = currency.ToLower(),
                Description = description,
                Metadata = new Dictionary<string, string>
                {
                    { "user_id", userId }
                }
            };

            var service = new PaymentIntentService();
            var paymentIntent = await service.CreateAsync(options);

            // Save payment record
            var payment = new Payment
            {
                UserId = userId,
                Amount = amount,
                Currency = currency,
                Status = "Pending",
                PaymentMethod = "Stripe",
                TransactionId = paymentIntent.Id,
                Description = description
            };

            _context.Payments.Add(payment);
            await _context.SaveChangesAsync();

            return paymentIntent.ClientSecret;
        }

        public async Task<bool> ConfirmPaymentAsync(string paymentIntentId)
        {
            if (string.IsNullOrEmpty(_stripeSecretKey))
            {
                return false;
            }

            var service = new PaymentIntentService();
            var paymentIntent = await service.GetAsync(paymentIntentId);

            var payment = await _context.Payments
                .FirstOrDefaultAsync(p => p.TransactionId == paymentIntentId);

            if (payment != null)
            {
                payment.Status = paymentIntent.Status == "succeeded" ? "Completed" : "Failed";
                payment.ProcessedAt = DateTime.UtcNow;
                await _context.SaveChangesAsync();
            }

            return paymentIntent.Status == "succeeded";
        }

        public async Task<bool> ProcessRefundAsync(string paymentId, decimal amount)
        {
            if (string.IsNullOrEmpty(_stripeSecretKey))
            {
                return false;
            }

            var payment = await _context.Payments.FindAsync(int.Parse(paymentId));
            if (payment == null || payment.Status != "Completed")
            {
                return false;
            }

            var refundOptions = new RefundCreateOptions
            {
                PaymentIntent = payment.TransactionId,
                Amount = (long)(amount * 100)
            };

            var refundService = new RefundService();
            var refund = await refundService.CreateAsync(refundOptions);

            // Create transaction record
            var transaction = new Transaction
            {
                PaymentId = payment.Id,
                Type = "Refund",
                Amount = amount,
                Status = refund.Status,
                GatewayResponse = refund.Id
            };

            _context.Transactions.Add(transaction);
            await _context.SaveChangesAsync();

            return refund.Status == "succeeded";
        }

        public async Task<IEnumerable<PaymentDto>> GetUserPaymentsAsync(string userId)
        {
            var payments = await _context.Payments
                .Where(p => p.UserId == userId)
                .OrderByDescending(p => p.CreatedAt)
                .ToListAsync();

            return payments.Select(MapToDto);
        }

        private static PaymentDto MapToDto(Payment payment)
        {
            return new PaymentDto
            {
                Id = payment.Id,
                UserId = payment.UserId,
                Amount = payment.Amount,
                Currency = payment.Currency,
                Status = payment.Status,
                PaymentMethod = payment.PaymentMethod,
                TransactionId = payment.TransactionId,
                Description = payment.Description,
                CreatedAt = payment.CreatedAt,
                ProcessedAt = payment.ProcessedAt
            };
        }
    }
}