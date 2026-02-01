using Backend.Application.Responses;
using Backend.Domain.Entities;
using Backend.Domain.Interfaces;
using Backend.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Backend.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly DataContext _context;

        private readonly ILogger<OrderService> _logger;

        public OrderService(DataContext context, ILogger<OrderService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<ServiceResponse<Order>> CreateOrderAsync(Order order)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();

            return new ServiceResponse<Order>
            {
                Data = order,
                Success = true,
                Message = "Order created successfully."
            };
        }

        public async Task<ServiceResponse<List<Order>>> GetAllOrdersAsync()
        {
            List<Order> orders = await _context.Orders.ToListAsync();

            if (orders == null || orders.Count == 0)
            {
                _logger.LogWarning("No orders found in the database.");

                return new ServiceResponse<List<Order>>
                {
                    Data = null,
                    Success = false,
                    Message = "No orders found."
                };

            }

            return new ServiceResponse<List<Order>>
            {
                Data = orders,
                Success = true,
            };
        }

        public async Task<ServiceResponse<Order>> GetOrderByIdAsync(int id)
        {
            Order? order = await _context.Orders.FindAsync(id);

            if (order == null)
            {
                _logger.LogWarning($"Order with ID {id} not found.");

                return new ServiceResponse<Order>
                {
                    Data = null,
                    Success = false,
                    Message = "Order not found."
                };
            }

            return new ServiceResponse<Order>
            {
                Data = order,
                Success = true,
            };
        }
    }
}