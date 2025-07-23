using TMCollections_Api.DTO.Order;

namespace TMCollections_Api.Services_New.Interfaces
{
    public interface IOrderService
    {
        Task PlaceOrderAsync(Guid userId, PlaceOrderDto dto);
        Task<List<OrderDto>> GetOrdersByUserAsync(Guid userId);
        Task<OrderDto?> GetOrderDetailsAsync(Guid orderId);
    }
}
