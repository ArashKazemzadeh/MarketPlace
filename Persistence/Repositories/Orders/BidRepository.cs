using ConsoleApp1.Models;
using Domin.IRepositories.IseparationRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domin.IRepositories.Dtos;
using Castle.Core.Resource;
using ConsoleApp.Models;

namespace Persistence.Repositories.Orders
{
    public class BidRepository : IBidRepository
    {
        private readonly DbContext _context;
        private readonly DbSet<Bid> _dbSet;

        public BidRepository(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<Bid>();
        }

        public async Task<Bid> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<List<Bid>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task AddAsync(BidRepDto dto)
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
            await _context.SaveChangesAsync();
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
