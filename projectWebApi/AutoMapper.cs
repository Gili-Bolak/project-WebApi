using AutoMapper;
using DTOs;
using Entities;


namespace projectWebApi
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<Order, OrderDto>().ReverseMap();//.ForMember(dest => dest.UserName, opts => opts.MapFrom(src => src.User.FirstName + src.User.LastName)).ReverseMap();
            CreateMap<OrderItem, OrderItemDto>().ReverseMap();
            CreateMap<Product, ProductDto>().ReverseMap();
            //CreateMap<List<Product>, List<ProductDto>>().ReverseMap();
            CreateMap<UserLoginDto, User>();
            CreateMap<Category, CategoryDto>().ReverseMap();
        }
    }
}
