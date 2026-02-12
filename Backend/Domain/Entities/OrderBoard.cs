namespace Backend.Domain.Entities
{
    public class OrderBoard
    {
        public int Id { get; set; }

        public int OrderId { get; set; }

        public Order Order { get; set; } = default!;

        public int BoardId { get; set; }

        public Board Board { get; set; } = default!;

        public string OrderNumber { get; set; } = string.Empty;

        public int BoardPosition { get; set; }
    }
}