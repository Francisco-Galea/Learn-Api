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
            .ForMember(dest => dest.OUserResponse, opt => opt.MapFrom(src => src.OUser));

            CreateMap<CategoryRequest, Category>().ReverseMap();
            CreateMap<Category, CategoryResponse>().ReverseMap();


        }
    }
}
