using AutoMapper;
using TestApi.Models.DTOs.Request;
using TestApi.Models.DTOs.Response;
using TestApi.Models.Entities;

namespace TestApi
{
    public class Mapper : Profile
    {
        public Mapper()
        {

            CreateMap<UserRequest, User>().ReverseMap();
            CreateMap<User, UserResponse>().ReverseMap();

            CreateMap<OrderRequest, Order>().ReverseMap();
            CreateMap<Order, OrderResponse>()
            .ForMember(dest => dest.OUserResponse, opt => opt.MapFrom(src => src.OUser))
            .ForMember(dest => dest.OItemsOrderedResponse, opt => opt.MapFrom(src => src.OItemsOrdered));

            CreateMap<CategoryRequest, Category>().ReverseMap();
            CreateMap<Category, CategoryResponse>().ReverseMap();

            CreateMap<ProductRequest, Product>().ReverseMap();
            CreateMap<Product, ProductResponse>()
            .ForMember(dest => dest.OCategoryResponse, opt => opt.MapFrom(src => src.OCategory));

            CreateMap<ItemOrderedRequest, ItemOrdered>().ReverseMap();
            CreateMap<ItemOrdered, ItemOrderedResponse>()
            .ForMember(dest => dest.OProductResponse, opt => opt.MapFrom(src => src.OProduct));
            
           
        }
    }
}
