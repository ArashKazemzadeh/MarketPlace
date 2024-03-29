﻿using ConsoleApp1.Models;
using Domin.IRepositories.Dtos.Auction;
using Domin.IRepositories.Dtos.Bid;

namespace Domin.IRepositories.IseparationRepository.SqlServer;

public interface IAuctionRepository
{
  Task<bool> HasOwnedAction(int userId, int auctionId);
    Task<List<Auction>> GetCompletedsAsync();
    Task<int> UpdateWithBidAsync(Auction auction, BidRepDto bidDto);
    Task<List<AuctionProductDto>> GetAllTrueAsync();
    Task<Auction> GetByIdAsync(int id);
    Task<List<AuctionProductDto>> GetAllAsync();
    Task AddAsync(Auction auction);
    Task UpdateAsync(Auction auction);
    Task DeleteAsync(Auction auction);
}