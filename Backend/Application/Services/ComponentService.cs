using Backend.Infrastructure.Data;
using Backend.Domain.Interfaces;
using Backend.Application.Responses;
using Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Backend.Application.DTOs.Component;
using AutoMapper;

namespace Backend.Application.Services
{
    public class ComponentService : IComponentService
    {
        private readonly DataContext _context;

        private readonly ILogger<ComponentService> _logger;

        private readonly IMapper _mapper;
        public ComponentService(DataContext context, ILogger<ComponentService> logger, IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<ComponentResponseDto>> CreateComponentAsync(ComponentRequestDto componentDto)
        {
            var response = new ServiceResponse<ComponentResponseDto>();

            var component = _mapper.Map<Component>(componentDto);
            await _context.Components.AddAsync(component);
            await _context.SaveChangesAsync();
            
            var componentResponse = _mapper.Map<ComponentResponseDto>(component);
            response.Data = componentResponse;
            response.Success = true;    

            return response;
        }

        public async Task<ServiceResponse<List<ComponentResponseDto>>> GetAllComponentsAsync()
        {
            List<Component> components = await _context.Components.ToListAsync();

            if(components == null || components.Count == 0)
            {
                var response = new ServiceResponse<List<ComponentResponseDto>>()
                {
                    Data = null,
                    Success = false,
                    Message = "No components found."
                };

                _logger.LogWarning("No components found in the database.");
                return response;
            }

            return new ServiceResponse<List<ComponentResponseDto>>()
            {
                Data = _mapper.Map<List<ComponentResponseDto>>(components),
                Success = true
            };
        }

        public async Task<ServiceResponse<ComponentResponseDto>> GetComponentByIdAsync(int id)
        {
            Component? component = await _context.Components.FindAsync(id);

            if(component == null)
            {
                var response = new ServiceResponse<ComponentResponseDto>()
                {
                    Data = null,
                    Success = false,
                    Message = $"Component with ID {id} not found."
                };
                _logger.LogWarning("Component with ID {ComponentId} not found.", id);

                return response;
            }

            return new ServiceResponse<ComponentResponseDto>()
            {
                Data = _mapper.Map<ComponentResponseDto>(component),
                Success = true
            };
        }

        public async Task<ServiceResponse<bool>> DeleteComponentAsync(int id)
        {
            Component? component = await _context.Components.FindAsync(id);

            if(component == null)
            {
                var response = new ServiceResponse<bool>()
                {
                    Data = false,
                    Success = false,
                    Message = $"Component with ID {id} not found."
                };
                _logger.LogWarning("Component with ID {ComponentId} not found.", id);
                return response;
            }

            _context.Components.Remove(component);;
            await _context.SaveChangesAsync();

            return new ServiceResponse<bool>()
            {
                Data = true,
                Success = true
            };
        }

        public async Task<ServiceResponse<ComponentResponseDto>> UpdateComponentAsync(ComponentRequestDto componentDto)
        {
            Component? existingComponent = await _context.Components.FindAsync(componentDto.Id);

            if(existingComponent == null)
            {
                var response = new ServiceResponse<ComponentResponseDto>()
                {
                    Data = null,
                    Success = false,
                    Message = $"Component with ID {componentDto.Id} not found."
                };
                
                _logger.LogWarning("Component with ID {ComponentId} not found.", componentDto.Id);
                return response;
            }

            existingComponent.Code = componentDto.Code;
            existingComponent.Name = componentDto.Name;
            existingComponent.Description = componentDto.Description;

            _context.Components.Update(existingComponent);
            await _context.SaveChangesAsync();

            return new ServiceResponse<ComponentResponseDto>()
            {
                Data = _mapper.Map<ComponentResponseDto>(existingComponent),
                Success = true
            };
        }
    }

}