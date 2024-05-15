using BusinessLogic.DTOs;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Mapper
{
    public class Mapper:AutoMapper.Profile
    {
        public Mapper()
        {

            CreateMap<CardDto, Card>();
            CreateMap<Card, CardDto>()
             .ForMember(dest => dest.Board, opt => opt.MapFrom(src => src.Board.Name))
             .ForMember(dest => dest.CardList, opt => opt.MapFrom(src => src.CardList.Name));

            CreateMap<CardList, CardListDto>();
            CreateMap<CardListDto, CardList>();

            CreateMap<ActivityDto, Activity>();
            CreateMap<Activity, ActivityDto>();

            CreateMap<HistoryDto, History>();
            CreateMap<History, HistoryDto>();

            CreateMap<BoardDto, Board>();
            CreateMap<Board, BoardDto>()
                .ForMember(dest => dest.ListDtos, opt => opt.MapFrom(src => src.Lists))
                .ForMember(dest => dest.CardDtos, opt => opt.MapFrom(src => src.Cards));
        }
    }
}
