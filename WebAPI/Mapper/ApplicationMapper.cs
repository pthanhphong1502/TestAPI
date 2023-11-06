using AutoMapper;
using WebAPI.Models;
using WebAPI.Models.Dtos;

namespace WebAPI.Mapper
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<Models.Member, GetAllUserDto>().ReverseMap();
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<OrderDetail, OrderDetailDto>().ReverseMap();
            CreateMap<Catelogy, CatelogyDto>().ReverseMap();
        }
    }
}
