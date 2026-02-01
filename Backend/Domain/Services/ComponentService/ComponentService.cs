using Backend.Infrastructure.Data;

namespace Backend.Domain.Services.ComponentService
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