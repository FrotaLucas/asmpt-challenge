namespace Backend.Application.DTOs.Order
{
    public class OrderResponseDto
    {
        public string OrderNumber { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public DateTime OrderDate { get; set; }

        public int QuantityBoards { get; set;}

        public int QuantityComponents {get; set; }

        //public List<OrderBoard> OrderBoards { get; set; } = new List<OrderBoard>();

    }
}