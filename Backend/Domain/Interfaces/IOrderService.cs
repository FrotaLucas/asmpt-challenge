using Backend.Application.DTOs.Order;
using Backend.Application.Responses;
using Backend.Domain.Entities;

namespace Backend.Domain.Interfaces
{
    public interface IOrderService
    {
        Task<ServiceResponse<OrderResponseDto>> CreateOrderAsync(OrderRequestDto order);
        
        Task<ServiceResponse<List<Order>>> GetAllOrdersAsync();

        Task<ServiceResponse<Order>> GetOrderByIdAsync(int id);
    }
}