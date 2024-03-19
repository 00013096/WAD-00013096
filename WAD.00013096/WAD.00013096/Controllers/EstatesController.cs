using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WAD._00013096.DTOs;
using WAD._00013096.Interfaces;
using WAD._00013096.Models;

namespace WAD._00013096.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstatesController : ControllerBase
    {
        private readonly IEstateRepository _estateRepository;
        private readonly IMapper _mapper;

        public EstatesController(IEstateRepository estateRepository, IMapper mapper)
        {
            _estateRepository = estateRepository;
            _mapper = mapper;
        }

        // GET: api/Estates
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EstateDto>>> GetEstates()
        {
            var estates = await _estateRepository.GetAllEstatesAsync();
            return Ok(_mapper.Map<IEnumerable<EstateDto>>(estates));
        }

        // GET: api/Estates/1
        [HttpGet("{id}")]
        public async Task<ActionResult<EstateDto>> GetEstate(int id)
        {
            var estate = await _estateRepository.GetEstateByIdAsync(id);

            if (estate == null)
            {
                return NotFound();
            }

            return _mapper.Map<EstateDto>(estate);
        }

        // POST: api/Estates
        [HttpPost]
        public async Task<ActionResult<EstateDto>> PostEstate(EstateDto estateDto)
        {
            var estate = _mapper.Map<Estate>(estateDto);
            estate = await _estateRepository.AddEstateAsync(estate);
            return CreatedAtAction(nameof(GetEstate), new { id = estate.EstateId }, _mapper.Map<EstateDto>(estate));
        }

        // PUT: api/Estates/1
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEstates(int id, EstateDto estateDto)
        {
            if (id != estateDto.EstateId)
            {
                return BadRequest();
            }

            var estate = _mapper.Map<Estate>(estateDto);
            await _estateRepository.UpdateEstateAsync(estate);

            return NoContent();
        }

        // DELETE: api/Estates/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEstate(int id)
        {
            await _estateRepository.DeleteEstateAsync(id);
            return NoContent();
        }
    }
}
