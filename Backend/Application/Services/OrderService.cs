using Backend.Domain.Interfaces;
using Backend.Infrastructure.Data;

namespace Backend.Application.Services
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