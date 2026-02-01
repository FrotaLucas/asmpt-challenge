using Backend.Infrastructure.Data;
using Backend.Domain.Interfaces;

namespace Backend.Application.Services
{
    public class ComponentService : IComponentService
    {
        private readonly DataContext _context;

        public ComponentService(DataContext context)
        {
            _context = context;
        }

    }

}