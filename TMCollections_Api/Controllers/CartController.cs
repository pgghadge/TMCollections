using Microsoft.AspNetCore.Mvc;
using TMCollections_Api.DTO.Cart;
using TMCollections_Api.Services_New.Interfaces;

namespace TMCollections_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartController : ControllerBase
    {

        private readonly ICartService _cartService;
        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        // 🔹 GET: api/cart/user/{userId}
        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetUserCart(Guid userId)
        {
            var cart = await _cartService.GetUserCartAsync(userId);
            return Ok(cart);
        }

        // 🔹 POST: api/cart/add/{userId}
        [HttpPost("add/{userId}")]
        public async Task<IActionResult> AddToCart(Guid userId, [FromBody] AddCartItemDto dto)
        {
            await _cartService.AddToCartAsync(userId, dto);
            return Ok(new { message = "Item added to cart successfully." });
        }

        // 🔹 PUT: api/cart/update/{userId}/{cartItemId}
        [HttpPut("update/{userId}/{cartItemId}")]
        public async Task<IActionResult> UpdateCartItem(Guid userId, Guid cartItemId, [FromBody] UpdateCartItemDto dto)
        {
            await _cartService.UpdateCartItemAsync(userId, cartItemId, dto);
            return Ok(new { message = "Cart item updated successfully." });
        }

        // 🔹 DELETE: api/cart/remove/{userId}/{cartItemId}
        [HttpDelete("remove/{userId}/{cartItemId}")]
        public async Task<IActionResult> RemoveCartItem(Guid userId, Guid cartItemId)
        {
            await _cartService.RemoveCartItemAsync(userId, cartItemId);
            return Ok(new { message = "Item removed from cart." });
        }

        // 🔹 DELETE: api/cart/clear/{userId}
        [HttpDelete("clear/{userId}")]
        public async Task<IActionResult> ClearCart(Guid userId)
        {
            await _cartService.ClearCartAsync(userId);
            return Ok(new { message = "Cart cleared successfully." });
        }


    }
}
