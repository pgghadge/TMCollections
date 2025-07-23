using AutoMapper;
using TMCollections_Api.DTO.Address;
using TMCollections_Api.DTO.Cart;
using TMCollections_Api.DTO.Category;
using TMCollections_Api.DTO.Order;
using TMCollections_Api.DTO.Payment;
using TMCollections_Api.DTO.Product;
using TMCollections_Api.DTO.User;
using TMCollections_Api.Models;

namespace TMCollections_Api.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // 🔹 Product
            CreateMap<Product, ProductDto>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name));
            CreateMap<CreateProductDto, Product>();

            // 🔹 Category
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<CreateCategoryDto, Category>();

            // 🔹 User
            CreateMap<User, UserDto>();
            CreateMap<RegisterUserDto, User>()
                .ForMember(dest => dest.Password, opt => opt.Ignore());

            // 🔹 Cart
            CreateMap<CartItem, CartItemDto>()
                .ForMember(dest => dest.CartItemId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name));

            CreateMap<Cart, CartDto>()
                .ForMember(dest => dest.CartId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.CartItems));

            // 🔹 Address
            CreateMap<Address, AddressDto>();
            CreateMap<CreateAddressDto, Address>();
            CreateMap<UpdateAddressDto, Address>();
            
            
            // 🔹 Order
            CreateMap<OrderItem, OrderItemDto>()
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId))
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name))
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
                .ForMember(dest => dest.PriceAtPurchase, opt => opt.MapFrom(src => src.Price));

            CreateMap<Order, OrderDto>()
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.OrderItems))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.status.ToString()))
                .ForMember(dest => dest.TotalAmount, opt => opt.MapFrom(src => src.TotalAmount))
                .ForMember(dest => dest.OrderDate, opt => opt.MapFrom(src => src.OrderDate));
            
            CreateMap<Payment, PaymentDto>()
                .ForMember(dest => dest.PaymentStatus, opt => opt.MapFrom(src => src.PaymentStatus.ToString()));

            CreateMap<CreatePaymentDto, Payment>();


        }
    }
}
