using Backend.Application.DTOs.Order;
using Backend.Application.Responses;
using Backend.Domain.Entities;

namespace Backend.Domain.Interfaces
{
    public interface IOrderService
    {
        Task<ServiceResponse<OrderResponseDto>> CreateOrderAsync(OrderRequestDto order);
        
        Task<ServiceResponse<List<OrderResponseDto>>> GetAllOrdersAsync();

        Task<ServiceResponse<OrderResponseDto>> GetOrderByIdAsync(int id);
    }
}