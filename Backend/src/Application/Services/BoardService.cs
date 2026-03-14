using Backend.Infrastructure.Data;
using Backend.Domain.Entities;
using Backend.Domain.Interfaces;
using Backend.Application.Responses;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Backend.Application.DTOs.Board;

namespace Backend.Application.Services
{
    public class BoardService : IBoardService
    {
        private readonly DataContext _context;

        private readonly ILogger<BoardService> _logger;

        private readonly IMapper _mapper;

        public BoardService(DataContext context, ILogger<BoardService> logger, IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<BoardResponsetDto>>> GetAllBoardsAsync()
        {
            List<Board> boards = await _context.Boards.ToListAsync();

            if(boards == null || boards.Count == 0)
            {
                var response = new ServiceResponse<List<BoardResponsetDto>>()
                {
                    Data = null,
                    Success = false,
                    Message = "No boards found."
                };

                _logger.LogWarning("No boards found in the database.");
                return response;
            }

            return new ServiceResponse<List<BoardResponsetDto>>()
            {
                Data = _mapper.Map<List<BoardResponsetDto>>(boards),
                Success = true
            };
        }

        public async Task<ServiceResponse<BoardResponsetDto>> GetBoardByIdAsync(int id)
        {
            Board? board = await _context.Boards.FindAsync(id);

            if(board == null)
            {
                var response = new ServiceResponse<BoardResponsetDto>()
                {
                    Data = null,
                    Success = false,
                    Message = $"Board with ID {id} not found."
                };
                _logger.LogWarning("Board with ID {BoardId} not found.", id);
                return response;
            }

            return new ServiceResponse<BoardResponsetDto>()
            {
                Data = _mapper.Map<BoardResponsetDto>(board),
                Success = true
            };
        }

        public async Task<ServiceResponse<BoardResponsetDto>> CreateBoardAsync(BoardRequestDto boardDto)
        {
            var board = _mapper.Map<Board>(boardDto);
            var responseBoard = await _context.Boards.AddAsync(board);
            await _context.SaveChangesAsync();

            return new ServiceResponse<BoardResponsetDto>()
            {
                Data = _mapper.Map<BoardResponsetDto>(board),
                Success = true
            };
        }

        public async Task<ServiceResponse<bool>> DeleteBoardAsync(int id)
        {
            Board? board = await _context.Boards.FindAsync(id);

            if(board == null)
            {
                var response = new ServiceResponse<bool>()
                {
                    Data = false,
                    Success = false,
                    Message = $"Board with ID {id} not found."
                };
                _logger.LogWarning("Board with ID {BoardId} not found.", id);
                return response;
            }

            _context.Boards.Remove(board);
            await _context.SaveChangesAsync();

            return new ServiceResponse<bool>()
            {
                Data = true,
                Success = true
            };
        }

        public async Task<ServiceResponse<BoardResponsetDto>> UpdateBoardAsync(BoardRequestDto board)
        {
            Board? existingBoard = await _context.Boards.FindAsync(board.Id);

            if(existingBoard == null)
            {
                var response = new ServiceResponse<BoardResponsetDto>()
                {
                    Data = null,
                    Success = false,
                    Message = $"Board with ID {board.Id} not found."
                };

                _logger.LogWarning("Board with ID {BoardId} not found.", board.Id);
                return response;
            }

            existingBoard.Name = board.Name;
            existingBoard.Description = board.Description;
            existingBoard.Code = board.Code;
            existingBoard.Length = board.Length;
            existingBoard.Width = board.Width;

            _context.Boards.Update(existingBoard);
            await _context.SaveChangesAsync();

            return new ServiceResponse<BoardResponsetDto>()
            {
                Data = _mapper.Map<BoardResponsetDto>(existingBoard),
                Success = true
            };
        }
    }
}