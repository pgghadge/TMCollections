using AutoMapper;
using TMCollections_Api.DTO.Cart;
using TMCollections_Api.Models;
using TMCollections_Api.Services.Interfaces.Repositories;
using TMCollections_Api.Services_New.Interfaces;

namespace TMCollections_Api.Services_New.Implementations
{
    public class CartService : ICartService
    {

        private readonly IICartRepository _cartRepo;
        private readonly ICartItemRepository _cartItemRepo;
        private readonly IProductRepository _productRepo; // You need to inject this too
        private readonly IMapper _mapper;

        public CartService(
        IICartRepository cartRepo,
        ICartItemRepository cartItemRepo,
        IProductRepository productRepo,
        IMapper mapper)
        {
            _cartRepo = cartRepo;
            _cartItemRepo = cartItemRepo;
            _productRepo = productRepo;
            _mapper = mapper;
        }

        public async Task AddToCartAsync(Guid userId, AddCartItemDto dto)
        {
            var product = await _productRepo.GetByIdAsync(dto.ProductId);
            
            if (product == null)
                throw new Exception("Product not available");

            // 🟢 1. Get user's cart
            var cart = await _cartRepo.GetCartByUserIdAsync(userId);

            // 🟢 2. If cart doesn't exist, create and save it first
            if (cart == null)
            {
                cart = new Cart
                {
                    Id = Guid.NewGuid(),
                    UserId = userId,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    CartItems = new List<CartItem>()
                };

                await _cartRepo.AddCartAsync(cart);
                await _cartRepo.SaveChangesAsync(); // 👈 Save so Cart ID exists for FK!
            }

            // 🟢 3. Now proceed to check or add cart item
            var existingItem = cart.CartItems?.FirstOrDefault(i => i.ProductId == dto.ProductId);
            
            if (existingItem != null)
            {
                existingItem.Quantity += dto.Quantity;
                existingItem.Price = product.Price * existingItem.Quantity;
                await _cartItemRepo.UpdateCartItemAsync(existingItem);
            }
            else
            {
                var newItem = new CartItem
                {
                    Id = Guid.NewGuid(),
                    ProductId = dto.ProductId,
                    Quantity = dto.Quantity,
                    Price = product.Price ,
                    CartId = cart.Id // 🔑 This is now a valid FK
                };
                await _cartItemRepo.AddCartItemAsync(newItem);
            }

            cart.UpdatedAt = DateTime.UtcNow;
            cart.TotalAmount = cart.CartItems.Sum(i => i.Price);
            await _cartRepo.UpdateCartAsync(cart);
            await _cartRepo.SaveChangesAsync();
        }

        public async Task ClearCartAsync(Guid userId)
        {
            var cart = await _cartRepo.GetCartByUserIdAsync(userId);
            if (cart == null)
                throw new Exception("Cart not found");

            foreach (var item in cart.CartItems.ToList())
            {
                await _cartItemRepo.DeleteCartItemAsync(item);
            }

            cart.TotalAmount = 0;
            cart.UpdatedAt = DateTime.UtcNow;
            await _cartRepo.UpdateCartAsync(cart);
            await _cartRepo.SaveChangesAsync();
        }

        public async Task<CartDto> GetUserCartAsync(Guid userId)
        {
            var cart = await _cartRepo.GetCartByUserIdAsync(userId);

            if (cart == null)
                throw new Exception("Cart not found");

            return _mapper.Map<CartDto>(cart);
        }

        public async Task RemoveCartItemAsync(Guid userId, Guid cartItemId)
        {
            var item = await _cartItemRepo.GetCartItemByIdAsync(cartItemId);
            if (item == null)
                throw new Exception("Cart item not found");

            await _cartItemRepo.DeleteCartItemAsync(item);
            await _cartItemRepo.SaveChangesAsync();
        }

        public async Task UpdateCartItemAsync(Guid userId, Guid cartItemId, UpdateCartItemDto dto)
        {
            var item = await _cartItemRepo.GetCartItemByIdAsync(cartItemId);

            if (item == null)
                throw new Exception("Item not found");

            if (dto.Quantity <= 0)
            {
                await _cartItemRepo.DeleteCartItemAsync(item);
            }
            else
            {
                var product = await _productRepo.GetByIdAsync(item.ProductId);
                item.Quantity = dto.Quantity;
                item.Price = product.Price * dto.Quantity;

                await _cartItemRepo.UpdateCartItemAsync(item);
            }

            var cart = await _cartRepo.GetByIdAsync(item.CartId);

            // 🟢 Always fetch latest items from DB to calculate total
            var updatedItems = await _cartItemRepo.GetCartItemsByCartIdAsync(cart.Id);
            cart.TotalAmount = updatedItems.Sum(i => i.Price);
            cart.UpdatedAt = DateTime.UtcNow;

            await _cartRepo.UpdateCartAsync(cart);
            await _cartRepo.SaveChangesAsync();
        }


    }

}
