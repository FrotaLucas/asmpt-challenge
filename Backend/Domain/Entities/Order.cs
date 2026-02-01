namespace Backend.Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }

        public String OrderNumber { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public DateTime OrderDate { get; set; }

        public List<OrderBoard> OrderBoards { get; set; } = new List<OrderBoard>();
    }
}