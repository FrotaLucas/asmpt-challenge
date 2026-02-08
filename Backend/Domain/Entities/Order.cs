namespace Backend.Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }

        public string OrderNumber { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public DateTime OrderDate { get; set; } = DateTime.Now;

        public List<OrderBoard> OrderBoards { get; set; } = new List<OrderBoard>();
    }
}