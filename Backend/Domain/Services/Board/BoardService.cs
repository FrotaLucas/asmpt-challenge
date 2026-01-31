using Backend.Infrastructure.Data;

namespace Backend.Domain.Services.Board 
{
    public class BoardService : IBoardService
    {
        private readonly DataContext _context;

        public BoardService(DataContext context)
        {
            _context = context;
        }

        // Implement methods defined in IBoardService interface
    }

}