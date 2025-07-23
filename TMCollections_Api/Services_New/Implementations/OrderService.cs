using AutoMapper;
using TMCollections_Api.DTO.Order;
using TMCollections_Api.Models;
using TMCollections_Api.Services.Interfaces.Repositories;
using TMCollections_Api.Services_New.Interfaces;

namespace TMCollections_Api.Services_New.Implementations
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepo;
        private readonly IICartRepository _cartRepo;
        private readonly IAddressRepository _addressRepo;
        private readonly ICartItemRepository _cartItemRepo;
        private readonly IMapper _mapper;

        public OrderService(
            IOrderRepository orderRepo,
            IICartRepository cartRepo,
            IAddressRepository addressRepo,
            IMapper mapper,
            ICartItemRepository cartItemRepo)
        {
            _orderRepo = orderRepo;
            _cartRepo = cartRepo;
            _addressRepo = addressRepo;
            _mapper = mapper;
            _cartItemRepo = cartItemRepo;
        }

        public async Task<OrderDto?> GetOrderDetailsAsync(Guid orderId)
        {
            var order = await _orderRepo.GetOrderWithItemsAsync(orderId);
            if (order == null) return null;

            return new OrderDto
            {
                Id = order.Id,
                OrderDate = order.OrderDate,
                Status = order.status.ToString(),
                TotalAmount = order.TotalAmount,
                Items = order.OrderItems.Select(oi => new OrderItemDto
                {
                    ProductId = oi.ProductId,
                    ProductName = oi.Product?.Name ?? "",
                    Quantity = oi.Quantity,
                    PriceAtPurchase = oi.Price
                }).ToList()
            };
        }

        public async Task<List<OrderDto>> GetOrdersByUserAsync(Guid userId)
        {
            var orders= await _orderRepo.GetOrdersByUserIdAsync(userId);

            return orders.Select(o => new OrderDto
            {
                Id = o.Id,
                OrderDate= o.OrderDate,
                Status=o.status.ToString(),
                TotalAmount=o.TotalAmount,

                Items=o.OrderItems.Select(oi => new OrderItemDto
                {
                    ProductId = oi.ProductId,
                    ProductName =oi.Product?.Name?? "",
                    Quantity = oi.Quantity,
                    PriceAtPurchase=oi.Price
                }).ToList()
            }).ToList();
        }

        public async Task PlaceOrderAsync(Guid userId, PlaceOrderDto dto)
        {
            var cart= await _cartRepo.GetCartByUserIdAsync(userId);

            if(cart == null)
            {
                throw new Exception("Cart not found");
            }

            var cartItems= await _cartItemRepo.GetCartItemsByCartIdAsync(cart.Id);

            if (!cartItems.Any())
                throw new Exception("cart is empty");

            var address = await _addressRepo.GetByIdAsync(dto.AddressId);

            if (address == null)
                throw new Exception("Shipping address not found");

            var totalAmount = cartItems.Sum(item => item.Quantity * item.Product.Price);

            var order = new Order
            {
                UserId = userId,
                TotalAmount = totalAmount,
                status = OrderStatus.Pending,
                OrderDate=DateTime.UtcNow,
            
                OrderItems = cartItems.Select(ci => new OrderItem
                {
                    ProductId=ci.ProductId,
                    Quantity = ci.Quantity,
                    Price=ci.Product.Price

                }).ToList()
            };

            await _orderRepo.AddAsync(order);
            await _orderRepo.SaveChangesAsync();

            // 🧹 Remove cart items
            foreach (var item in cartItems)
                await _cartItemRepo.DeleteCartItemAsync(item);

            await _cartItemRepo.SaveChangesAsync();

            cart.TotalAmount = 0;
            cart.CartItems = new List<CartItem>(); // Optional: clear navigation prop

            await _cartRepo.UpdateCartAsync(cart); // Make sure you have this in your repo
            await _cartRepo.SaveChangesAsync();


        }
    }
}
