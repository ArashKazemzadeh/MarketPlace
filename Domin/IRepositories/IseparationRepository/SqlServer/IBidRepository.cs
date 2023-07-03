using ConsoleApp1.Models;
using Domin.IRepositories.Dtos.Bid;

namespace Domin.IRepositories.IseparationRepository.SqlServer;

public interface IBidRepository
{
    Task<bool> HasPlacedBid(int customerId, int auctionId);
    Task<List<BidGetRepDto>> GetBidsByCustomerId(int customerId);
    Task<Bid> GetByIdAsync(int id);
    Task<List<Bid>> GetAllAsync();
    Task<int> AddAsync(BidRepDto dto);
    Task UpdateAsync(Bid bid);
    Task DeleteAsync(Bid bid);
}