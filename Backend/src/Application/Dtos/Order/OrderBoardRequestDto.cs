
namespace Backend.Application.DTOs.Order
{
    public class OrderBoardRequestDto
    {
        public int Id { get; set; }

        public string Code { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public int BoardPosition { get; set; }

        public List<BoardComponentRequestDto> Components { get; set; } = new List<BoardComponentRequestDto>();
    }
}