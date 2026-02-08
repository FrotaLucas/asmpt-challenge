namespace Backend.Application.DTOs.Order
{

    //POST somente. Nao tem PUT
    public class BoardComponentRequestDto
    {
        public int Id { get; set; }

        public string Code { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;
    }
}