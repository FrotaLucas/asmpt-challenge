using Backend.Infrastructure.Data;
using Backend.Domain.Entities;
using Backend.Domain.Interfaces;
using Backend.Application.Responses;

namespace Backend.Application.Services
{
    public class BoardService : IBoardService
    {
        private readonly DataContext _context;

        private readonly ILogger<BoardService> _logger;

        //LogError
        //_logger.LogError(ex, "Error fetching boards");

        public BoardService(DataContext context, ILogger<BoardService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<ServiceResponse<List<Board>>> GetAllBoardsAsync()
        {
            List<Board> boards = _context.Boards.ToList();

            if(boards == null || boards.Count == 0)
            {
                var response = new ServiceResponse<List<Board>>()
                {
                    Data = null,
                    Success = false,
                    Message = "No boards found."
                };
                
                _logger.LogWarning("No boards found in the database.");
                return response;
            }

            return new ServiceResponse<List<Board>>()
            {
                Data = boards,
                Success = true
            };
        }

        public Task<ServiceResponse<Board>> GetBoardByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<Board>> CreateBoardAsync(Board board)
        {
            await _context.Boards.AddAsync(board);
            await _context.SaveChangesAsync();
            return new ServiceResponse<Board>()
            {
                Data = board,
                Success = true
            };
        }
        public Task<ServiceResponse<bool>> DeleteBoardAsync(int id)
        {
            throw new NotImplementedException();
        }
        public Task<ServiceResponse<Board>> UpdateBoardAsync(Board board)
        {
            throw new NotImplementedException();
        }
    }
}