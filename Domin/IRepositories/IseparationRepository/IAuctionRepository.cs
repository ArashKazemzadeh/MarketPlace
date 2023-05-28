using ConsoleApp1.Models;

namespace Domin.IRepositories.IseparationRepository;

public interface IAuctionRepository
{
    Task<Auction> GetByIdAsync(int id);
    Task<List<Auction>> GetAllAsync();
    Task AddAsync(Auction auction);
    Task UpdateAsync(Auction auction);
    Task DeleteAsync(Auction auction);
}