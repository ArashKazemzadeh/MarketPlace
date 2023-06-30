using ConsoleApp1.Models;
using Microsoft.EntityFrameworkCore;
using Domin.IRepositories.Dtos;
using Persistence.Contexts.SqlServer;
using Domin.Entities.Users;
using Domin.IRepositories.IseparationRepository.SqlServer;

namespace Persistence.Repositories.SqlServer.Orders
{
    public class BidRepository : IBidRepository
    {
        private readonly DatabaseContext _context;
        private readonly DbSet<Bid> _dbSet;

        public BidRepository(DatabaseContext context)
        {
            _context = context;
            _dbSet = _context.Set<Bid>();
        }

        public async Task<bool> HasPlacedBid(int customerId, int auctionId)
        {
            var bid = await _dbSet.Where(b => b.Customer.Id == customerId)
                .FirstOrDefaultAsync(b => b.AuctionId == auctionId);
            if (bid == null)
            {
                return false;
            }

            return true;
        }


        public async Task<List<BidGetRepDto>> GetBidsByCustomerId(int customerId)
        {
            var customerBids = await _dbSet
                .Where(b => b.Customer.Id == customerId)
                .Select(b => new BidGetRepDto
                {
                    Id = b.Id,
                    Price = b.Price,
                    StartDateAuction = b.Auction.StartDeadTime,
                    EndDateAuction = b.Auction.EndDeadTime,
                    IsAccepted = b.IsAccepted,
                    RegisterDate = b.RegisterDate,
                    AuctionId = b.AuctionId,
                    ProductName = b.Auction.Product.Name
                }).ToListAsync();
            return customerBids;
        }

        public async Task<Bid> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<List<Bid>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<int> AddAsync(BidRepDto dto)//1
        {
            var bid = new Bid
            {
                Price = dto.Price,
                RegisterDate = dto.RegisterDate,
                AuctionId = dto.AuctionId,
                Customer = dto.Customer,
                Auction = dto.Auction,
            };
            await _dbSet.AddAsync(bid);
            var result = await _context.SaveChangesAsync();
            return result;
        }

        public async Task UpdateAsync(Bid bid)
        {
            _context.Entry(bid).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Bid bid)
        {
            _dbSet.Remove(bid);
            await _context.SaveChangesAsync();
        }
    }
}
