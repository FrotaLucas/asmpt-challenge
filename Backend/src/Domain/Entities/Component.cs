namespace Backend.Domain.Entities
{
    public class Component
    {
        public int Id { get; set; }

        public string Code { get; set; } = string.Empty;
        
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public List<BoardComponent> BoardComponents { get; set; } = new List<BoardComponent>();
    }

}