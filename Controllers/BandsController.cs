using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BandApi.Dtos;
using BandApi.Helpers;
using BandApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace BandApi.Controllers
{
    [ApiController]
    [Route("api/{controller}")]
    public class BandsController : ControllerBase
    {
        private readonly IBandAlbumRepository _repository;

        public BandsController(IBandAlbumRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet]
        public ActionResult<IEnumerable<BandDto>> GetBands()
        {
            var bandsFromRepo = _repository.GetBands();
            var bandDto = new List<BandDto>();
            foreach(var band in bandsFromRepo)
            {
                bandDto.Add(new BandDto()
                {
                    Id = band.Id,
                    Name = band.Name,
                    MainGenre = band.MainGenre,
                    FoundedYearsAgo = $"{band.Founded.ToString("yyyy")} ({band.Founded.GetYearsAgo()} years ago)"
                });
            }
            return Ok(bandDto);
        }

        [HttpGet("{bandId}")]
        public IActionResult GetBand(Guid bandId)
        {
            var bandFromRepo = _repository.GetBand(bandId);
            if (bandFromRepo == null)
                return NotFound();

            return Ok(bandFromRepo);
        }


    }
}