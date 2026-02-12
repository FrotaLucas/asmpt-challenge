using AutoMapper;
using Backend.Application.DTOs.Board;
using Backend.Domain.Entities;

namespace Backend.Application.Mapping
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