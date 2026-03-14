using AutoMapper;
using Asmpt.Application.DTOs.Board;
using Asmpt.Domain.Entities;

namespace Asmpt.Application.Mapping
{
    public class BoardMapping : Profile
    {
        public BoardMapping()
        {
            CreateMap<BoardRequestDto, Board>();
            CreateMap<Board, BoardResponsetDto>();
        }
    }
}