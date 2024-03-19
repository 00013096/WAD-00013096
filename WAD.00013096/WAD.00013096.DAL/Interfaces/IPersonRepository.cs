using WAD._00013096.Models;

namespace WAD._00013096.Interfaces
{
    public interface IPersonRepository
    {
        Task<IEnumerable<Person>> GetAllPeopleAsync();
        Task<Person> GetPersonByIdAsync(int personId);
        Task<Person> AddPersonAsync(Person person);
        Task UpdatePersonAsync(Person person);
        Task DeletePersonAsync(int personId);
    }
}
