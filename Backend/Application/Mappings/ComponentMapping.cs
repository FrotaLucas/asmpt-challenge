using AutoMapper;
using Backend.Application.DTOs.Component;
using Backend.Domain.Entities;

namespace Backend.Application.Mapping
{
    public class ComponentMapping : Profile
    {
        public ComponentMapping()
        {
            CreateMap<ComponentRequestDto, Component>();
            CreateMap<Component, ComponentResponseDto>();
        }
    }
}
