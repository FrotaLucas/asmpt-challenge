using AutoMapper;
using Asmpt.Application.DTOs.Component;
using Asmpt.Domain.Entities;

namespace Asmpt.Application.Mapping
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
