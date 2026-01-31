using Backend.Infrastructure.Data;

namespace Backend.Domain.Services.Order
{
    public class OrderService : IOrderService
    {
        private readonly DataContext _context;

        public OrderService(DataContext context)
        {
            _context = context;
        }

    }
}