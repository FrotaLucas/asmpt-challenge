using Backend.Infrastructure.Data;
using Backend.Domain.Entities;
using Backend.Domain.Interfaces;

namespace Backend.Application.Services
{
    public class BoardService : IBoardService
    {
        private readonly DataContext _context;

        //private readonly ILogger<BoardService> _logger;

        //LogError
        //_logger.LogError(ex, "Error fetching boards");

        public BoardService(DataContext context)
        {
            _context = context;
        }



        public async Task<List<Board>> GetAllBoardsAsync()
        {
            List<Board> boards = _context.Boards.ToList();

            return boards;
        }

        public Task<Board> GetBoardByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Board> CreateBoardAsync(Board board)
        {
            await _context.Boards.AddAsync(board);
            await _context.SaveChangesAsync();
            return board;
        }
        public Task<bool> DeleteBoardAsync(int id)
        {
            throw new NotImplementedException();
        }
        public Task<Board> UpdateBoardAsync(Board board)
        {
            throw new NotImplementedException();
        }
    }
}