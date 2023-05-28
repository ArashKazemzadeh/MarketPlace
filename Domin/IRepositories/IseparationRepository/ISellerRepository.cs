using ConsoleApp1.Models;

namespace Domin.IRepositories.IseparationRepository;

public interface ISellerRepository
{
    Task<Seller> GetByIdAsync(int id);
    Task<List<Seller>> GetAllAsync();
    Task AddAsync(Seller seller);
    Task UpdateAsync(Seller seller);
    Task DeleteAsync(Seller seller);
}