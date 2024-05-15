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
            .ForMember(dest => dest.TaskStatus, opt => opt.MapFrom(src => src.List.Name));
             
            CreateMap<CardList, CardListDto>();
            CreateMap<CardListDto, CardList>();

            CreateMap<ActivityDto, Activity>();
            CreateMap<Activity, ActivityDto>();

            CreateMap<HistoryDto, History>();
            CreateMap<History, HistoryDto>();
        }
    }
}
