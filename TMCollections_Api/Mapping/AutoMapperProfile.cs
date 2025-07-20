using AutoMapper;
using TMCollections_Api.DTO.Cart;
using TMCollections_Api.DTO.Category;
using TMCollections_Api.DTO.Product;
using TMCollections_Api.DTO.User;
using TMCollections_Api.Models;

namespace TMCollections_Api.Mapping
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            // Product
            CreateMap<Product, ProductDto>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name));
            
            CreateMap<CreateProductDto, Product>();
            //CreateMap<UpdateProductDto, Product>();

            // User
            CreateMap<User, UserDto>();
            CreateMap<RegisterUserDto, User>()
                .ForMember(dest => dest.Password, opt => opt.Ignore());

            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<CreateCategoryDto, Category>();
            //CreateMap<UpdateCategoryDto, Category>();

            CreateMap<CartItem, CartItemDto>()
                .ForMember(dest => dest.CartItemId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name)); // optional

            CreateMap<Cart, CartDto>()
                .ForMember(dest => dest.CartId, opt => opt.MapFrom(src => src.Id)) // 👈 FIX
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.CartItems));
        }
    
    }
}
