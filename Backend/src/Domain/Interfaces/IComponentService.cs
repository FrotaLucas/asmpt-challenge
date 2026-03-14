using Asmpt.Application.DTOs.Component;
using Asmpt.Application.Responses;
using Asmpt.Domain.Entities;

namespace Asmpt.Domain.Interfaces
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