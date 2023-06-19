using ConsoleApp1.Models;
using Domin.IRepositories.Dtos;

namespace Domin.IRepositories.IseparationRepository;

public interface IBidRepository
{
    Task<List<BidGetRepDto>> GetBidsByCustomerId(int customerId);
    Task<Bid> GetByIdAsync(int id);
    Task<List<Bid>> GetAllAsync();
    Task AddAsync(BidRepDto dto);
    Task UpdateAsync(Bid bid);
    Task DeleteAsync(Bid bid);
}