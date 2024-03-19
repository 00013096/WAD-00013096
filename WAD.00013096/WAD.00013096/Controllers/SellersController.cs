using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WAD._00013096.DTOs;
using WAD._00013096.Interfaces;
using WAD._00013096.Models;

namespace WAD._00013096.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellersController : ControllerBase
    {
        private readonly ISellerRepository _sellerRepository;
        private readonly IMapper _mapper;

        public SellersController(ISellerRepository companyRepository, IMapper mapper)
        {
            _sellerRepository = companyRepository;
            _mapper = mapper;
        }

        // GET: api/People
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SellerDto>>> GetAllSellers()
        {
            var sellers = await _sellerRepository.GetAllSellersAsync();
            return Ok(_mapper.Map<IEnumerable<SellerDto>>(sellers));
        }

        // GET: api/People/1
        [HttpGet("{id}")]
        public async Task<ActionResult<SellerDto>> GetSeller(int id)
        {
            var seller = await _sellerRepository.GetSellerByIdAsync(id);

            if (seller == null)
            {
                return NotFound();
            }

            return _mapper.Map<SellerDto>(seller);
        }

        // POST: api/People
        [HttpPost]
        public async Task<ActionResult<SellerDto>> PostSeller(SellerDto sellerDto)
        {
            var seller = _mapper.Map<Seller>(sellerDto);
            seller = await _sellerRepository.AddSellerAsync(seller);
            return CreatedAtAction(nameof(GetSeller), new { id = seller.SellerId }, _mapper.Map<SellerDto>(seller));
        }

        // PUT: api/People/1
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSeller(int id, SellerDto sellerDto)
        {
            if (id != sellerDto.SellerId)
            {
                return BadRequest();
            }

            var seller = _mapper.Map<Seller>(sellerDto);
            await _sellerRepository.UpdateSellerAsync(seller);

            return NoContent();
        }

        // DELETE: api/People/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSeller(int id)
        {
            await _sellerRepository.DeleteSellerAsync(id);
            return NoContent();
        }
    }
}
