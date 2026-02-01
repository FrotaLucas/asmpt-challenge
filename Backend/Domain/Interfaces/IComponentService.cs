using Backend.Application.Responses;
using Backend.Domain.Entities;

namespace Backend.Domain.Interfaces
{
    public interface IComponentService
    {
        Task<ServiceResponse<List<Component>>> GetAllComponentsAsync();

        Task<ServiceResponse<Component>> GetComponentByIdAsync(int id);

        Task<ServiceResponse<Component>> CreateComponentAsync(Component component);

        Task<ServiceResponse<bool>> DeleteComponentAsync(int id);

        Task<ServiceResponse<Component>> UpdateComponentAsync(Component component);
    }
}