using Backend.Domain.Entities;

namespace Backend.Application.DTOs.Order
{

    //POST somente. Nao tem PUT
    public class OrderRequestDto
    {
        public String OrderNumber { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public DateTime OrderDate { get; set; }
        //1
        public List<OrderBoardRequestDto> OrderBoards { get; set; } = new List<OrderBoardRequestDto>();
    }
}