using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TMCollections_Api.DTO.Payment;
using TMCollections_Api.Services_New.Interfaces;

namespace TMCollections_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentsController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPost("{userId}")]
        public async Task<IActionResult> CreatePayment(Guid userId, [FromBody] CreatePaymentDto dto)
        {
            await _paymentService.CreatePaymentAsync(userId, dto);
            return Ok(new { message = "Payment created successfully" });
        }

        [HttpGet("{orderId}")]
        public async Task<IActionResult> GetPayment(Guid orderId)
        {
            var payment = await _paymentService.GetPaymentByOrderIdAsync(orderId);
            return payment == null ? NotFound() : Ok(payment);
        }
    }
}
