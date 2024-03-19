using WAD._00013096.Models;

namespace WAD._00013096.Interfaces
{
    public interface IEstateRepository
    {
        Task<IEnumerable<Estate>> GetAllEstatesAsync();
        Task<Estate> GetEstateByIdAsync(int estateId);
        Task<Estate> AddEstateAsync(Estate estate);
        Task UpdateEstateAsync(Estate estate);
        Task DeleteEstateAsync(int estateId);
    }
}
