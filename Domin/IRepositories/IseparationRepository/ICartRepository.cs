using ConsoleApp1.Models;

namespace Domin.IRepositories.IseparationRepository;

public interface ICartRepository
{
    Task<Cart> GetByIdAsync(int id);
    Task<List<Cart>> GetAllAsync();
    Task AddAsync(Cart cart);
    Task UpdateAsync(Cart cart);
    Task DeleteAsync(Cart cart);
}