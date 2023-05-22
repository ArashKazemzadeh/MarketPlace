using ConsoleApp1.Models;

namespace Persistence.Repositories.Orders;

public interface IAuctionRepository
{
    Task<Auction> GetByIdAsync(int id);
    Task<List<Auction>> GetAllAsync();
    Task AddAsync(Auction auction);
    Task UpdateAsync(Auction auction);
    Task DeleteAsync(Auction auction);
}