using AutoMapper;
using BandApi.Dtos;
using BandApi.Entities;
using BandApi.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace BandApi.Profiles
{
    public class BandsProfile : Profile
    {
        public BandsProfile()
        {
            CreateMap<Band,BandDto>()
                .ForMember(
                    destination => destination.FoundedYearsAgo,
                    opt => opt
                    .MapFrom(src => $"{src.Founded.ToString("yyyy")} {src.Founded.GetYearsAgo()}) years ago")
                );
            CreateMap<BandForCreatingDto, Band>();
        }
    }
}
