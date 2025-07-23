using Microsoft.AspNetCore.Mvc;
using TMCollections_Api.DTO.Order;
using TMCollections_Api.Services_New.Interfaces;

namespace TMCollections_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost("user/{userId}")]
        public async Task<IActionResult> PlaceOrder(Guid userId, [FromBody] PlaceOrderDto dto)
        {
            await _orderService.PlaceOrderAsync(userId, dto);
            return Ok(new { message = "Order placed successfully" });

        }
        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetUserOrders(Guid userId)
        {
            var orders = await _orderService.GetOrdersByUserAsync(userId);
            return Ok(orders);
        }

        [HttpGet("details/{orderId}")]
        public async Task<IActionResult> GetOrder(Guid orderId)
        {
            var order = await _orderService.GetOrderDetailsAsync(orderId);
            return order == null ? NotFound() : Ok(order);
        }
    }
}
