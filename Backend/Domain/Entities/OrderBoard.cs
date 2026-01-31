public class OrderBoard
{
    public int OrderId { get; set; }

    public Order Order { get; set; } = default!;

    public int BoardId { get; set; }

    public Board Board { get; set; } = default!;

    public int Quantity { get; set; }
}