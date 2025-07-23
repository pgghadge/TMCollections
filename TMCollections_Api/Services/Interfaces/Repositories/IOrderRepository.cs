using TMCollections_Api.Models;

namespace TMCollections_Api.Services.Interfaces.Repositories
{
    public interface IOrderRepository:IGenericRepository<Order>
    {
        Task<List<Order>> GetOrdersByUserIdAsync(Guid userId);
        Task<Order?> GetOrderWithItemsAsync(Guid orderId);

    }
}
