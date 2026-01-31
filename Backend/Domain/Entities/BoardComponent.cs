namespace Backend.Domain.Entities
{
    public class BoardComponent
    {
        public int BoardId { get; set; }

        public Board Board { get; set; } = default!;

        public int ComponentId { get; set; }

        public Component Component { get; set; } = default!;

        public int Quantity { get; set; }
    }
}