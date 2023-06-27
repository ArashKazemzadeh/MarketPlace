using ConsoleApp1.Models;
using Domin.IRepositories.Dtos;

namespace Domin.IRepositories.IseparationRepository;

public interface IAuctionRepository
{
    Task<List<Auction>> GetCompletedsAsync();
    Task<int> UpdateWithBidAsync(Auction auction, BidRepDto bidDto);
    Task<Auction> GetByIdAsync(int id);
    Task<Auction> GetByCustomerIdAsync(int id);
    Task<List<AuctionProductDto>> GetAllAsync();
    Task AddAsync(Auction auction);
    Task UpdateAsync(Auction auction);
    Task DeleteAsync(Auction auction);
}