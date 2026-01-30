public class Order
{
public Guid Id { get; set; }
public string Name { get; set; }
public string Description { get; set; }
public DateTime OrderDate { get; set; }


// public ICollection<OrderBoard> OrderBoards { get; set; }
}