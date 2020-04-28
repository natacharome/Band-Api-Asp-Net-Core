using AutoMapper;
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
            CreateMap<Entities.Band, Dtos.BandDto>()
                .ForMember(
                    destination => destination.FoundedYearsAgo,
                    opt => opt
                    .MapFrom(src => $"{src.Founded.ToString("yyyy")} {src.Founded.GetYearsAgo()}) years ago")
                );
            
        }
    }
}
