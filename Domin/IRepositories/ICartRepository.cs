using ConsoleApp1.Models;

namespace Persistence.Repositories.Orders;

public interface ICartRepository
{
    Task<Cart> GetByIdAsync(int id);
    Task<List<Cart>> GetAllAsync();
    Task AddAsync(Cart cart);
    Task UpdateAsync(Cart cart);
    Task DeleteAsync(Cart cart);
}