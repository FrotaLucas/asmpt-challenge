public class ComponentService : IComponentService
{
    private readonly DataContext _context;

    public ComponentService(DataContext context)
    {
        _context = context;
    }

}   