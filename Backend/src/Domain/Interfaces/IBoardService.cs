using Asmpt.Application.DTOs.Board;
using Asmpt.Application.Responses;
using Asmpt.Domain.Entities;

namespace Asmpt.Domain.Interfaces
{
    public interface IBoardService
    {
        Task<ServiceResponse<List<BoardResponsetDto>>> GetAllBoardsAsync();

        Task<ServiceResponse<BoardResponsetDto>> GetBoardByIdAsync(int id);

        Task<ServiceResponse<BoardResponsetDto>> CreateBoardAsync(BoardRequestDto board);

        Task<ServiceResponse<bool>> DeleteBoardAsync(int id);   
        
        Task<ServiceResponse<BoardResponsetDto>> UpdateBoardAsync(BoardRequestDto board);

    }

}