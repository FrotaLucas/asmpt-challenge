using Backend.Application.DTOs.Order;
using Backend.Application.Responses;
using Backend.Domain.Entities;
using Backend.Domain.Interfaces;
using Backend.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace Backend.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly DataContext _context;

        private readonly ILogger<OrderService> _logger;

        private readonly IMapper _mapper;
        public OrderService(DataContext context, ILogger<OrderService> logger, IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<OrderResponseDto>> CreateOrderAsync(OrderRequestDto request)
        {
            var boards = request.OrderBoards;
            if (boards.Count == 0)
            {
                return new ServiceResponse<OrderResponseDto>
                {
                    Data = null,
                    Success = false,
                    Message = "Order does't have any board."
                };
            }

            using var transaction = _context.Database.BeginTransaction();

            try
            {

                Order newOrder = new Order();
                newOrder.Name = GenerateOrderName();
                newOrder.OrderNumber = GenerateOrderNumber();
                newOrder.Description = request.Description;

                await _context.Orders.AddAsync(newOrder);
                await _context.SaveChangesAsync();

                var orderBoards = request.OrderBoards
                    .Select(board => new OrderBoard
                    {
                        OrderId = newOrder.Id,
                        BoardId = board.Id
                    }).ToList();

                await _context.OrderBoards.AddRangeAsync(orderBoards);

                var boardComponents = request.OrderBoards
                    .SelectMany(board => board.BoardComponents,
                    (board, component) =>
                    new BoardComponent
                    {
                        BoardId = board.Id,
                        ComponentId = component.Id
                    }).ToList();

                await _context.BoardComponents.AddRangeAsync(boardComponents);
                await _context.SaveChangesAsync();

                await transaction.CommitAsync();

                var orderDto = _mapper.Map<OrderResponseDto>(newOrder);

                return new ServiceResponse<OrderResponseDto>
                {
                    Data = orderDto,
                    Success = true,
                    Message = "order successfully created."
                };
            }

            catch (DbUpdateException ex)
            {
                await transaction.RollbackAsync();
                _logger.LogWarning("Database constraint violation. ");

                return new ServiceResponse<OrderResponseDto>
                {
                    Success = false,
                    Message = "Database constraint violation."
                };
            }

            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                _logger.LogWarning("Unexpected error: {msg}", ex);

                return new ServiceResponse<OrderResponseDto>
                {
                    Success = false,
                    Message = $"Unexpected error: {ex.Message}"
                };
            }
        }

        public async Task<ServiceResponse<List<OrderResponseDto>>> GetAllOrdersAsync()
        {
            List<OrderResponseDto> ordersDto = new List<OrderResponseDto>();

            ordersDto = await _context.Orders
                .Select( order => new OrderResponseDto
                {
                    OrderNumber = order.OrderNumber,
                    Name = order.Name,
                    Description = order.Description,
                    OrderDate = order.OrderDate,

                    QuantityBoards = order.OrderBoards.Sum(ob => ob.Quantity),

                    QuantityComponents = order.OrderBoards
                        .SelectMany(ob => ob.Board.BoardComponents.Select(bc => bc.Quantity*ob.Quantity)).Sum()

                }).ToListAsync();

            if(ordersDto.Count == 0)
            {
                 _logger.LogWarning("No orders found in the database.");

                return new ServiceResponse<List<OrderResponseDto>>
                {
                    Data = null,
                    Success = false,
                    Message = "No orders found."
                };
                
            }
      
            return new ServiceResponse<List<OrderResponseDto>>
            {
                Data = ordersDto,
                Success = true,
            };
        }

        public async Task<ServiceResponse<OrderResponseDto>> GetOrderByIdAsync(int id)
        {
            Order? order = await _context.Orders.FindAsync(id);

            if (order == null)
            {
                _logger.LogWarning($"Order with ID {id} not found.");

                return new ServiceResponse<OrderResponseDto>
                {
                    Data = null,
                    Success = false,
                    Message = "Order not found."
                };
            }

            var orderDto = _mapper.Map<OrderResponseDto>(order);

            return new ServiceResponse<OrderResponseDto>
            {
                Data = orderDto,
                Success = true,
            };
        }

        private string GenerateOrderNumber()
        {
            const string prefix = "ORD-SMT";

            int randomSuffix = Random.Shared.Next(2000, 20000);

            return $"{prefix}-{randomSuffix}";
        }

        private string GenerateOrderName()
        {
            const string prefix = "JOB";

            int randomNumber = Random.Shared.Next(1000, 10000);

            return $"{prefix}-{randomNumber}";
        }
    }
}