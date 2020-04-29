using AutoMapper;
using BandApi.Dtos;
using BandApi.Entities;
using BandApi.Helpers;
using BandApi.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BandApi.Controllers
{
    [ApiController]
    [Route("api/bandcollections")]
    public class BandCollectionsController : ControllerBase
    {
        private readonly IBandAlbumRepository _repository;
        private readonly IMapper _mapper;

        public BandCollectionsController(IBandAlbumRepository repository, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet("({ids})", Name="GetBandCollection")]
        public IActionResult GetBandCollection([FromRoute] [ModelBinder(BinderType = typeof(ArrayModelBinder))] IEnumerable<Guid> ids)
        {
            if (ids == null)
                return BadRequest();

            var bandEntities = _repository.GetBands(ids);
            if (ids.Count() != bandEntities.Count())
            {
                return NotFound();
            }

            var bandsToReturn = _mapper.Map<IEnumerable<BandDto>>(bandEntities);
            return Ok(bandsToReturn);
            

        }

        [HttpPost]
        public ActionResult<IEnumerable<BandDto>> CreateBandCollection([FromBody] IEnumerable<BandForCreatingDto> bandCollection)
        {
            var bandEntities = _mapper.Map<IEnumerable<Band>>(bandCollection);
            foreach(var band in bandEntities)
            {
                _repository.AddBand(band);
            }
            _repository.Save();
            var bandCollectionToReturn = _mapper.Map<IEnumerable<BandDto>>(bandEntities);
            var IdsString = string.Join(",", bandCollectionToReturn.Select(a => a.Id));

            return CreatedAtRoute("GetBandCollection", new { ids = IdsString }, bandCollectionToReturn);
        }


    }
}
