using AutoMapper;
using Backend.Application.DTOs.Order;
using Backend.Domain.Entities;

namespace Backend.Application.Mapping
{
    public class OrderMapping : Profile
    {
        public OrderMapping()
        {
            CreateMap<Order, OrderResponseDto>()
                .ForMember(dest => dest.OrderNumber,
                    opt => opt.MapFrom(src => src.OrderNumber))
                .ForMember(dest => dest.Name,
                    opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description,
                    opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.OrderDate,
                    opt => opt.MapFrom(src => src.OrderDate));
                // .ForMember(dest => dest.OrderBoards,
                //     opt => opt.MapFrom(src => src.OrderBoards));
        }
    }
}
