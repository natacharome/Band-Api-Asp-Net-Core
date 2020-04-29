using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BandApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BandApi.Dtos;

namespace BandApi.Controllers
{
    [Route("api/bands/{bandId}/albums")]
    [ApiController]
    public class AlbumsController : ControllerBase
    {
        private readonly IBandAlbumRepository _repository;
        private readonly IMapper _mapper;

        public AlbumsController(IBandAlbumRepository repository, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }


        [HttpGet]
        public ActionResult<IEnumerable<AlbumDto>> GetAlbumsForBand(Guid bandId)
        {
            if (!_repository.BandExists(bandId))
                return NotFound();
            var albumFromRepo = _repository.GetAlbums(bandId);
            return Ok(_mapper.Map<IEnumerable<AlbumDto>>(albumFromRepo));
        }

        // api/bands/bandId/albums/albumId
        [HttpGet("{albumId}")]
        public ActionResult<AlbumDto> GetAlbum(Guid bandId, Guid albumId)
        {
            if (!_repository.BandExists(bandId))
                return NotFound();
            var albumForRepo = _repository.GetAlbum(bandId, albumId);
            if (albumForRepo == null)
                return NotFound();
            return Ok(_mapper.Map<AlbumDto>(albumForRepo));
        }
    }
}