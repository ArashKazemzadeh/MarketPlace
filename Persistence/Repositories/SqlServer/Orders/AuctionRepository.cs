using Castle.Core.Resource;
using ConsoleApp1.Models;
using Domin.IRepositories.Dtos.Auction;
using Domin.IRepositories.Dtos.Bid;
using Domin.IRepositories.IseparationRepository.SqlServer;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts.SqlServer;

namespace Persistence.Repositories.SqlServer.Orders
{
    public class AuctionRepository : IAuctionRepository
    {
        private readonly DatabaseContext _context;
        private readonly DbSet<Auction> _dbSet;
        public AuctionRepository(DatabaseContext context)
        {
            _context = context;
            _dbSet = _context.Set<Auction>();
        }

        public async Task<List<Auction>> GetCompletedsAsync()
        {
            var completedAuctions = _dbSet
                .Where(a => a.EndDeadTime <= DateTime.Now)
                .ToList();
            return completedAuctions;
        }

        public async Task<Auction> GetByIdAsync(int id)
        {
         var action=   await _dbSet.Include(p=>p.Product)
                .FirstOrDefaultAsync(a=>a.Id==id);
         return action;
        }
        public async Task<List<AuctionProductDto>> GetAllAsync()//
        {
            var result = await _dbSet.AsNoTracking().Select(a => new AuctionProductDto
            {
                AuctionId = a.Id,
                ProductId = a.Product.Id,
                ProductName = a.Product.Name,
                BasePrice = a.Product.BasePrice,
                HighestPrice = a.HighestPrice,
                StartDeadTime = a.StartDeadTime,
                EndDeadTime = a.EndDeadTime,
                ImagesUrl = a.Product.Images.Select(i => i.Url).Take(1).First(),
                Availability = a.Product.Availability,
                IsActive = a.Product.IsActive,
                TotalPrice = a.Product.BasePrice * a.Product.Availability
            }).ToListAsync();
            return result;
        }
        public async Task<List<AuctionProductDto>> GetAllTrueAsync()//
        {
            var result = await _dbSet.AsNoTracking()
                .Where(x=>x.Product.IsAuction)
                .Select(a => new AuctionProductDto
            {
                AuctionId = a.Id,
                ProductId = a.Product.Id,
                ProductName = a.Product.Name,
                BasePrice = a.Product.BasePrice,
                HighestPrice = a.HighestPrice,
                StartDeadTime = a.StartDeadTime,
                EndDeadTime = a.EndDeadTime,
                ImagesUrl = a.Product.Images.Select(i => i.Url).Take(1).First(),
                Availability = a.Product.Availability,
                IsActive = a.Product.IsActive,
                TotalPrice = a.Product.BasePrice * a.Product.Availability
            }).ToListAsync();
            return result;
        }
        public async Task AddAsync(Auction auction)
        {
            _context.Entry(auction).State = EntityState.Added;
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Auction auction)
        {
            _context.Entry(auction).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateWithBidAsync(Auction auction, BidRepDto bidDto)
        {
            var bid = new Bid
            {
                Price = bidDto.Price,
                RegisterDate = bidDto.RegisterDate,
                AuctionId = bidDto.AuctionId,
                Customer = bidDto.Customer
            };
            auction.Bids.Add(bid);
            _context.Entry(auction).State = EntityState.Modified;
            var result = await _context.SaveChangesAsync();
            return result;
        }
        public async Task DeleteAsync(Auction auction)
        {
            _dbSet.Remove(auction);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> HasOwnedAction(int userId, int auctionId)
        {
            var action = await _dbSet.Where(s => s.Product.Booth.SellerId == userId)
                .FirstOrDefaultAsync(a=>a.Id==auctionId);
            if (action==null)
                return false;
            return true;
        }
    }
}
