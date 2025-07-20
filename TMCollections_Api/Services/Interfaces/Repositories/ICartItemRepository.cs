using TMCollections_Api.Models;

namespace TMCollections_Api.Services.Interfaces.Repositories
{
    public interface ICartItemRepository
    {
        Task<CartItem?> GetCartItemByIdAsync(Guid cartItemId);
        Task<List<CartItem>> GetItemsByCartIdAsync(Guid cartId);
        Task AddCartItemAsync(CartItem item);
        Task UpdateCartItemAsync(CartItem item);
        Task DeleteCartItemAsync(CartItem item);
        Task SaveChangesAsync();
        Task<List<CartItem>> GetCartItemsByCartIdAsync(Guid cartId);
        Task<decimal> CalculateCartTotalAsync(Guid cartId);

    }
}
