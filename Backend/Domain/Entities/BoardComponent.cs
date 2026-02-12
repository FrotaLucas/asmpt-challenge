namespace Backend.Domain.Entities
{
    public class BoardComponent
    {
        public int Id { get; set; }

        public int OrderId { get; set; }

        public int BoardPosition { get; set; }

        public int BoardId { get; set; }

        public Board Board { get; set; } = default!;

        public int ComponentId { get; set; }

        public Component Component { get; set; } = default!;

    }
}