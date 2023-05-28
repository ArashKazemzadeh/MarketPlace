using ConsoleApp1.Models;
using Domin.IRepositories.IseparationRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.Users
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DbContext _context;
        private readonly DbSet<Customer> _dbSet;

        public CustomerRepository(DbContext context)
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

        public async Task DeleteAsync(Customer customer)
        {
            _dbSet.Remove(customer);
            await _context.SaveChangesAsync();
        }
    }
}
