using ConsoleApp1.Models;

namespace Persistence.Repositories.Orders;

public interface IBidRepository
{
    Task<Bid> GetByIdAsync(int id);
    Task<List<Bid>> GetAllAsync();
    Task AddAsync(Bid bid);
    Task UpdateAsync(Bid bid);
    Task DeleteAsync(Bid bid);
}