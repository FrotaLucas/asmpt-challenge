using Microsoft.EntityFrameworkCore;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<OrderBoard>().HasKey(orderBoard => new { orderBoard.OrderId, orderBoard.BoardId });
        modelBuilder.Entity<BoardComponent>().HasKey(borderComponent => new { borderComponent.BoardId, borderComponent.ComponentId });
    }
    
    public DbSet<Order> Orders { get; set; }

    public DbSet<Board> Boards { get; set; }

    public DbSet<Component> Components { get; set; }

    public DbSet<OrderBoard> OrderBoards { get; set; }

    public DbSet<BoardComponent> BoardComponents { get; set; }
}