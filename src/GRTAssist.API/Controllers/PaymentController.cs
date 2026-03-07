using GRTAssist.API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GRTAssist.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPost("create-intent")]
        public async Task<IActionResult> CreatePaymentIntent([FromBody] CreatePaymentIntentDto dto)
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
            {
                return Unauthorized();
            }

            try
            {
                var clientSecret = await _paymentService.CreatePaymentIntentAsync(
                    userId, dto.Amount, dto.Currency, dto.Description);
                return Ok(new { ClientSecret = clientSecret });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }

        [HttpPost("confirm/{paymentIntentId}")]
        public async Task<IActionResult> ConfirmPayment(string paymentIntentId)
        {
            var success = await _paymentService.ConfirmPaymentAsync(paymentIntentId);
            if (!success)
            {
                return BadRequest("Payment confirmation failed");
            }

            return Ok(new { Message = "Payment confirmed" });
        }

        [HttpPost("refund/{paymentId}")]
        public async Task<IActionResult> ProcessRefund(string paymentId, [FromBody] decimal amount)
        {
            var success = await _paymentService.ProcessRefundAsync(paymentId, amount);
            if (!success)
            {
                return BadRequest("Refund processing failed");
            }

            return Ok(new { Message = "Refund processed" });
        }

        [HttpGet("history")]
        public async Task<IActionResult> GetPaymentHistory()
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
            {
                return Unauthorized();
            }

            var payments = await _paymentService.GetUserPaymentsAsync(userId);
            return Ok(payments);
        }
    }

    public class CreatePaymentIntentDto
    {
        public decimal Amount { get; set; }
        public string Currency { get; set; } = "USD";
        public string Description { get; set; } = string.Empty;
    }
}