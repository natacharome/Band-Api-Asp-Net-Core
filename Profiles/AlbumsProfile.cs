using AutoMapper;
using BandApi.Dtos;
using BandApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BandApi.Profiles
{
    public class AlbumsProfile : Profile
    {
        public AlbumsProfile()
        {
            CreateMap<Album, AlbumDto>().ReverseMap();
        }
        
    }
}
