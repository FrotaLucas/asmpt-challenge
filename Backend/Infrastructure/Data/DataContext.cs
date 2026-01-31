using Microsoft.EntityFrameworkCore;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<Order> Orders { get; set; }

    public DbSet<Board> Boards { get; set; }

    public DbSet<Component> Components { get; set; } 

    public DbSet<OrderBoard> OrderBoards { get; set; }

    public DbSet<BoardComponent> BoardComponents { get; set; } 
}