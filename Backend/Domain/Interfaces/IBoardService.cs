using Backend.Application.DTOs.Board;
using Backend.Application.Responses;
using Backend.Domain.Entities;

namespace Backend.Domain.Interfaces
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