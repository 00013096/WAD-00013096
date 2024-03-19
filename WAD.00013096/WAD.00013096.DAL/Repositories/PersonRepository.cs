using Microsoft.EntityFrameworkCore;
using WAD._00013096.Data;
using WAD._00013096.Interfaces;
using WAD._00013096.Models;

namespace WAD._00013096.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly AppDbContext _context;

        public PersonRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Person>> GetAllPeopleAsync()
        {
            return await _context.People.ToListAsync();
        }

        public async Task<Person> GetPersonByIdAsync(int personId)
        {
            return await _context.People.FindAsync(personId);
        }

        public async Task<Person> AddPersonAsync(Person person)
        {
            _context.People.Add(person);
            await _context.SaveChangesAsync();
            return person;
        }

        public async Task UpdatePersonAsync(Person person)
        {
            _context.Entry(person).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeletePersonAsync(int peopleId)
        {
            var person= await _context.People.FindAsync(peopleId);
            if (person != null)
            {
                _context.People.Remove(person);
                await _context.SaveChangesAsync();
            }
        }
    }
}
