using TMCollections_Api.Models;

namespace TMCollections_Api.Services.Interfaces.Repositories
{
    public interface IICartRepository:IGenericRepository<Cart>
    {
        Task<Cart?> GetCartByUserIdAsync(Guid userId);
        Task AddCartAsync(Cart cart);
        Task UpdateCartAsync(Cart cart);
        Task DeleteCartAsync(Guid cartId);
        Task SaveChangesAsync();
    }
}
