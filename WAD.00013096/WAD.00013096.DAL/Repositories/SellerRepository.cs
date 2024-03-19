using Microsoft.EntityFrameworkCore;
using WAD._00013096.Data;
using WAD._00013096.Interfaces;
using WAD._00013096.Models;

namespace WAD._00013096.Repositories
{
    public class SellerRepository : ISellerRepository
    {
        private readonly AppDbContext _context;

        public SellerRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Seller>> GetAllSellersAsync()
        {
            return await _context.Sellers.ToListAsync();
        }

        public async Task<Seller> GetSellerByIdAsync(int personId)
        {
            return await _context.Sellers.FindAsync(personId);
        }

        public async Task<Seller> AddSellerAsync(Seller person)
        {
            _context.Sellers.Add(person);
            await _context.SaveChangesAsync();
            return person;
        }

        public async Task UpdateSellerAsync(Seller person)
        {
            _context.Entry(person).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSellerAsync(int peopleId)
        {
            var person= await _context.Sellers.FindAsync(peopleId);
            if (person != null)
            {
                _context.Sellers.Remove(person);
                await _context.SaveChangesAsync();
            }
        }
    }
}
