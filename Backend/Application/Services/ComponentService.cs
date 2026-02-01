using Backend.Infrastructure.Data;
using Backend.Domain.Interfaces;
using Backend.Application.Responses;
using Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backend.Application.Services
{
    public class ComponentService : IComponentService
    {
        private readonly DataContext _context;

        private readonly ILogger<ComponentService> _logger;

        public ComponentService(DataContext context, ILogger<ComponentService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<ServiceResponse<Component>> CreateComponentAsync(Component component)
        {
            var response = new ServiceResponse<Component>();
      
            await _context.Components.AddAsync(component);
            await _context.SaveChangesAsync();
            response.Data = component;
            response.Success = true;    

            return response;
        }

        public async Task<ServiceResponse<List<Component>>> GetAllComponentsAsync()
        {
            List<Component> components = await _context.Components.ToListAsync();

            if(components == null || components.Count == 0)
            {
                var response = new ServiceResponse<List<Component>>()
                {
                    Data = null,
                    Success = false,
                    Message = "No components found."
                };

                _logger.LogWarning("No components found in the database.");
                return response;
            }

            return new ServiceResponse<List<Component>>()
            {
                Data = components,
                Success = true
            };
        }

        public async Task<ServiceResponse<Component>> GetComponentByIdAsync(int id)
        {
            Component? component = await _context.Components.FindAsync(id);

            if(component == null)
            {
                var response = new ServiceResponse<Component>()
                {
                    Data = null,
                    Success = false,
                    Message = $"Component with ID {id} not found."
                };
                _logger.LogWarning("Component with ID {ComponentId} not found.", id);

                return response;
            }

            return new ServiceResponse<Component>()
            {
                Data = component,
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

        public async Task<ServiceResponse<Component>> UpdateComponentAsync(Component component)
        {
            Component? existingComponent = await _context.Components.FindAsync(component.Id);

            if(existingComponent == null)
            {
                var response = new ServiceResponse<Component>()
                {
                    Data = null,
                    Success = false,
                    Message = $"Component with ID {component.Id} not found."
                };
                
                _logger.LogWarning("Component with ID {ComponentId} not found.", component.Id);
                return response;
            }

            existingComponent.Code = component.Code;
            existingComponent.Name = component.Name;
            existingComponent.Description = component.Description;

            _context.Components.Update(existingComponent);
            await _context.SaveChangesAsync();

            return new ServiceResponse<Component>()
            {
                Data = existingComponent,
                Success = true
            };
        }
    }

}