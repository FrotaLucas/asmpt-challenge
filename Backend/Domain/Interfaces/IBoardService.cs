using Backend.Domain.Entities;

namespace Backend.Domain.Interfaces
{
    public interface IBoardService
    {
        Task<List<Board>> GetAllBoardsAsync();

        Task<Board> GetBoardByIdAsync(int id);

        Task<Board> CreateBoardAsync(Board board);

        Task<bool> DeleteBoardAsync(int id);

        Task<Board> UpdateBoardAsync(Board board);

    }

}