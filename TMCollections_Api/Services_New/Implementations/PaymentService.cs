using AutoMapper;
using TMCollections_Api.DTO.Payment;
using TMCollections_Api.Models;
using TMCollections_Api.Services.Interfaces.Repositories;
using TMCollections_Api.Services_New.Interfaces;

namespace TMCollections_Api.Services_New.Implementations
{
    public class PaymentService :IPaymentService
    {
        // Assuming you have a repository for payments
        // private readonly IPaymentRepository _paymentRepository;
        // public PaymentService(IPaymentRepository paymentRepository)

        private readonly IPaymentRepository _paymentRepo;
        private readonly IMapper _mapper;

        public PaymentService(IPaymentRepository paymentRepo, IMapper mapper)
        {
            _paymentRepo = paymentRepo;
            _mapper = mapper;
        }
        public async Task CreatePaymentAsync(Guid userId, CreatePaymentDto dto)
        {
            var payment = new Payment
            {
                Id = Guid.NewGuid(),
                OrderId = dto.OrderId,
                UserId = userId,
                Amount = dto.Amount,
                PaymentDate = DateTime.UtcNow,
                PaymentStatus = PaymentStatus.Completed
            };

            await _paymentRepo.AddAsync(payment);
            await _paymentRepo.SaveChangesAsync();
        }

        public async Task<PaymentDto?> GetPaymentByOrderIdAsync(Guid orderId)
        {
            var payment = await _paymentRepo.GetPaymentByOrderIdAsync(orderId);
            return payment == null ? null : _mapper.Map<PaymentDto>(payment);
        }
    }
}
