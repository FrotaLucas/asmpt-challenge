using Backend.Infrastructure.Data;

namespace Backend.Domain.Services.Component 
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