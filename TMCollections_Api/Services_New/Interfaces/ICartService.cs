using TMCollections_Api.DTO.Cart;

namespace TMCollections_Api.Services_New.Interfaces
{
    public interface ICartService
    {
        Task<CartDto> GetUserCartAsync(Guid userId);
        Task AddToCartAsync(Guid userId, AddCartItemDto dto);
        Task UpdateCartItemAsync(Guid userId, Guid cartItemId, UpdateCartItemDto dto);
        Task RemoveCartItemAsync(Guid userId, Guid cartItemId);

        Task ClearCartAsync(Guid userId);

    }
}
