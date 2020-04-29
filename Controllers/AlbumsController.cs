using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BandApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BandApi.Dtos;
using BandApi.Entities;
using Microsoft.AspNetCore.JsonPatch;

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
        [HttpGet("{albumId}", Name = "GetAlbum")]
        public ActionResult<AlbumDto> GetAlbum(Guid bandId, Guid albumId)
        {
            if (!_repository.BandExists(bandId))
                return NotFound();
            var albumForRepo = _repository.GetAlbum(bandId, albumId);
            if (albumForRepo == null)
                return NotFound();
            return Ok(_mapper.Map<AlbumDto>(albumForRepo));
        }

        [HttpPost]
        public ActionResult<AlbumDto> CreateAlbumForBand(Guid bandId, [FromBody] AlbumForCreatingDto album)
        {
            if (!_repository.BandExists(bandId))
                return NotFound();
            var albumEntity = _mapper.Map<Album>(album);
            _repository.AddAlbum(bandId, albumEntity);
            _repository.Save();

            var albumToReturn = _mapper.Map<AlbumDto>(albumEntity);
            return CreatedAtRoute("GetAlbum", new { bandId = bandId, albumId = albumToReturn.Id }, albumToReturn);
        }

        [HttpPut("{albumId}")]
        public ActionResult UpdateAlbumForBand(Guid bandId, Guid albumId, [FromBody] AlbumForUpdatingDto album)
        {
            if (!_repository.BandExists(bandId))
                return NotFound();
            var albumFromRepo = _repository.GetAlbum(bandId, albumId);
            if (albumFromRepo == null)
                return NotFound();
            _mapper.Map(album, albumFromRepo);
            _repository.UpdateAlbum(albumFromRepo);
           _repository.Save();

            return NoContent();
        }

        [HttpPatch("{albumId}")]
        public ActionResult PartiallyUpdateAlbumForBand(Guid bandId, Guid albumId, [FromBody] JsonPatchDocument<AlbumForUpdatingDto> patchDocument)
        {
            if (!_repository.BandExists(bandId))
                return NotFound();
            var albumFromRepo = _repository.GetAlbum(bandId, albumId);
            if (albumFromRepo == null)
                return NotFound();

            var albumToPatch = _mapper.Map<AlbumForUpdatingDto>(albumFromRepo);
            patchDocument.ApplyTo(albumToPatch);

            _mapper.Map(albumToPatch, albumFromRepo);
            _repository.UpdateAlbum(albumFromRepo);
            _repository.Save();

            return NoContent();
        }
    }
}