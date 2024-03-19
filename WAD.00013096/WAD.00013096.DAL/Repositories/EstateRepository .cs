using Microsoft.EntityFrameworkCore;
using WAD._00013096.Data;
using WAD._00013096.Interfaces;
using WAD._00013096.Models;

namespace WAD._00013096.Repositories
{
    public class EstateRepository : IEstateRepository
    {
        private readonly AppDbContext _context;

        public EstateRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Estate>> GetAllEstatesAsync()
        {
            return await _context.Estates.ToListAsync();
        }

        public async Task<Estate> GetEstateByIdAsync(int estateId)
        {
            return await _context.Estates.FindAsync(estateId);
        }

        public async Task<Estate> AddEstateAsync(Estate estate)
        {
            _context.Estates.Add(estate);
            await _context.SaveChangesAsync();
            return estate;
        }

        public async Task UpdateEstateAsync(Estate estate)
        {
            _context.Entry(estate).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEstateAsync(int estateId)
        {
            var estate = await _context.Estates.FindAsync(estateId);
            if (estate != null)
            {
                _context.Estates.Remove(estate);
                await _context.SaveChangesAsync();
            }
        }
    }
}
