using WAD._00013096.Models;

namespace WAD._00013096.Interfaces
{
    public interface ISellerRepository
    {
        Task<IEnumerable<Seller>> GetAllSellersAsync();
        Task<Seller> GetSellerByIdAsync(int sellerId);
        Task<Seller> AddSellerAsync(Seller seller);
        Task UpdateSellerAsync(Seller seller);
        Task DeleteSellerAsync(int sellerId);
    }
}
