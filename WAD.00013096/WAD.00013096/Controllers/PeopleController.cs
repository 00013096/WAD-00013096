using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WAD._00013096.DTOs;
using WAD._00013096.Interfaces;
using WAD._00013096.Models;

namespace WAD._00013096.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;

        public PeopleController(IPersonRepository companyRepository, IMapper mapper)
        {
            _personRepository = companyRepository;
            _mapper = mapper;
        }

        // GET: api/People
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonDto>>> GetAllPeople()
        {
            var people = await _personRepository.GetAllPeopleAsync();
            return Ok(_mapper.Map<IEnumerable<PersonDto>>(people));
        }

        // GET: api/People/1
        [HttpGet("{id}")]
        public async Task<ActionResult<PersonDto>> GetPerson(int id)
        {
            var person = await _personRepository.GetPersonByIdAsync(id);

            if (person == null)
            {
                return NotFound();
            }

            return _mapper.Map<PersonDto>(person);
        }

        // POST: api/People
        [HttpPost]
        public async Task<ActionResult<PersonDto>> PostPerson(PersonDto personDto)
        {
            var person = _mapper.Map<Person>(personDto);
            person = await _personRepository.AddPersonAsync(person);
            return CreatedAtAction(nameof(GetPerson), new { id = person.PersonId }, _mapper.Map<PersonDto>(person));
        }

        // PUT: api/People/1
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPerson(int id, PersonDto personDto)
        {
            if (id != personDto.PersonId)
            {
                return BadRequest();
            }

            var person = _mapper.Map<Person>(personDto);
            await _personRepository.UpdatePersonAsync(person);

            return NoContent();
        }

        // DELETE: api/People/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerson(int id)
        {
            await _personRepository.DeletePersonAsync(id);
            return NoContent();
        }
    }
}
