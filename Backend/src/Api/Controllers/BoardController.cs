namespace Backend.Api.Controllers
{
    using Backend.Domain.Entities;
    using Microsoft.AspNetCore.Mvc; 
    using Backend.Domain.Interfaces;
    using Backend.Application.Responses;
    using Backend.Application.DTOs.Board;

    [ApiController]
    [Route("api/boards")]
    public class BoardController : ControllerBase
    {
        private readonly IBoardService _boardService;

        private readonly ILogger<BoardController> _logger;

        public BoardController(IBoardService boardService, ILogger<BoardController> logger)
        {
            _boardService = boardService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<BoardResponsetDto>>>> GetAllBoards()
        {
            var result = await _boardService.GetAllBoardsAsync();
            if (!result.Success)
            {
                _logger.LogWarning("GET /api/boards failed: {Message}", result.Message);
                return NotFound(result);
            }

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<Board>>> GetBoardById(int id)
        {
            var result = await _boardService.GetBoardByIdAsync(id);
            if (!result.Success)
            {
                _logger.LogWarning("GET /api/boards failed for id {id}: {Message}", id, result.Message);
                return NotFound(result);
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<BoardResponsetDto>>> CreateBoard(BoardRequestDto board)
        {
            var result = await _boardService.CreateBoardAsync(board);
            if (!result.Success)
            {
                _logger.LogWarning("POST /api/boards failed: {Message}", result.Message);
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<bool>>> DeleteBoard(int id)
        {
            var result = await _boardService.DeleteBoardAsync(id);
            if (!result.Success)
            {
                _logger.LogWarning("DELETE api/boards failed: {message}", result.Message);
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<BoardResponsetDto>>> UpdateBoard(BoardRequestDto board)
        {
            var result = await _boardService.UpdateBoardAsync(board);

            if (!result.Success)
            {
                _logger.LogWarning("PUT /api/boards failed: {Message}", result.Message);
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}