using ConsoleApp1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Persistence.Contexts.SqlServer;
using ConsoleApp.Models;
using Domin.IRepositories.IseparationRepository.SqlServer;
using Domin.IRepositories.Dtos.Bid;

namespace Persistence.Repositories.SqlServer.Users
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DatabaseContext _context;
        private readonly DbSet<Customer> _dbSet;

        public CustomerRepository(DatabaseContext context)
        {
            _context = context;
            _dbSet = _context.Set<Customer>();
        }

        public async Task<Customer> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<List<Customer>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task AddAsync(Customer customer)
        {
            await _dbSet.AddAsync(customer);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Customer customer)
        {
            _context.Entry(customer).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task<int> UpdateWithBidAsync(Customer customer, BidRepDto bidDto)
        {
            var bid = new Bid
            {
                Price = bidDto.Price,
                RegisterDate = bidDto.RegisterDate,
                AuctionId = bidDto.AuctionId,
                Customer = bidDto.Customer
            };
            customer.Bids.Add(bid);
            _context.Entry(customer).State = EntityState.Modified;
            var result = await _context.SaveChangesAsync();
            return result;
        }
        public async Task DeleteAsync(Customer customer)
        {
            _dbSet.Remove(customer);
            await _context.SaveChangesAsync();
        }
    }
}
