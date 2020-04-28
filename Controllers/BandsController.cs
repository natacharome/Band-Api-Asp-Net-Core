using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public IActionResult GetBands()
        {
            var bandsFromRepo = _repository.GetBands();
            return Ok(bandsFromRepo);
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