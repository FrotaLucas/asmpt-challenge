namespace Backend.Application.DTOs.Board
{
    public class BoardRequestDto
    {
        public int Id { get; set; }

        public string Code { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public double Length { get; set; }

        public double Width { get; set; }
    }
}