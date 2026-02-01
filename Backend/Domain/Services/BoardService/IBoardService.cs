using Backend.Domain.Entities;

namespace Backend.Domain.Services.BoardService
{
    public interface IBoardService
    {
        public Task<Board> CreateBoardAsync(Board board);
    }

}