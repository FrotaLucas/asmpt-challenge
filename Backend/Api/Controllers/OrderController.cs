using Backend.Application.Responses;
using Backend.Domain.Entities;
using Backend.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Api.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        private readonly ILogger<OrderController> _logger;
        public OrderController(IOrderService orderService, ILogger<OrderController> logger)
        {
            _orderService = orderService;
            _logger = logger;
        }


        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Order>>>> GetAllOrders()
        {
            var result = await _orderService.GetAllOrdersAsync();

            if(!result.Success)
            {
                _logger.LogWarning("GET /api/orders failded: {message}", result.Message);
                return NotFound(result);
            }

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<Order>>> GetOrderById(int id)
        {
            var result = await _orderService.GetOrderByIdAsync(id);

            if(!result.Success)
            {
                _logger.LogWarning("GET api/orders failed for id {id}: {message}", id, result.Message);
                return NotFound(result);
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<Order>>> CreateOrder(Order order)
        {
            var result = await _orderService.CreateOrderAsync(order);

            if(!result.Success)
            {
                _logger.LogWarning("POST /api/orders failed: {message}", result.Message);
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}