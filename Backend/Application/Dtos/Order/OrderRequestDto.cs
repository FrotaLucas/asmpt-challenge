using Backend.Domain.Entities;

namespace Backend.Application.DTOs.Order
{

    //POST somente. Nao tem PUT
    public class OrderRequestDto
    {
        public string OrderNumber { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public DateTime OrderDate { get; set; } = DateTime.Now;
        //1
        public List<OrderBoardRequestDto> Boards { get; set; } = new List<OrderBoardRequestDto>();
    }
}