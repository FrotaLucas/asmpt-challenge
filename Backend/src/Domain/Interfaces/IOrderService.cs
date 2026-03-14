using Asmpt.Application.DTOs.Order;
using Asmpt.Application.Responses;
using Asmpt.Domain.Entities;

namespace Asmpt.Domain.Interfaces
{
    public interface IOrderService
    {
        Task<ServiceResponse<OrderResponseDto>> CreateOrderAsync(OrderRequestDto order);
        
        Task<ServiceResponse<List<OrderResponseDto>>> GetAllOrdersAsync();

        Task<ServiceResponse<OrderResponseDto>> GetOrderByIdAsync(int id);
    }
}