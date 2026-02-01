using Backend.Application.Responses;
using Backend.Domain.Entities;

namespace Backend.Domain.Interfaces
{
    public interface IBoardService
    {
        Task<ServiceResponse<List<Board>>> GetAllBoardsAsync();

        Task<ServiceResponse<Board>> GetBoardByIdAsync(int id);

        Task<ServiceResponse<Board>> CreateBoardAsync(Board board);

        Task<ServiceResponse<bool>> DeleteBoardAsync(int id);   
        
        Task<ServiceResponse<Board>> UpdateBoardAsync(Board board);

    }

}