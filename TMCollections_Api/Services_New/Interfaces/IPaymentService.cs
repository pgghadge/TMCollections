using TMCollections_Api.DTO.Payment;

namespace TMCollections_Api.Services_New.Interfaces
{
    public interface IPaymentService
    {
        Task CreatePaymentAsync(Guid userId, CreatePaymentDto dto);
        Task<PaymentDto?> GetPaymentByOrderIdAsync(Guid orderId);
    }
}
