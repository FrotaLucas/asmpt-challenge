using Backend.Application.DTOs.Component;
using Backend.Application.Responses;
using Backend.Domain.Entities;

namespace Backend.Domain.Interfaces
{
    public interface IComponentService
    {
        Task<ServiceResponse<List<ComponentResponseDto>>> GetAllComponentsAsync();

        Task<ServiceResponse<ComponentResponseDto>> GetComponentByIdAsync(int id);

        Task<ServiceResponse<ComponentResponseDto>> CreateComponentAsync(ComponentRequestDto component);

        Task<ServiceResponse<bool>> DeleteComponentAsync(int id);

        Task<ServiceResponse<ComponentResponseDto>> UpdateComponentAsync(ComponentRequestDto component);
    }
}