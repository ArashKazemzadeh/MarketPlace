using ConsoleApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories.Optionals
{
    public class AddressRepository : IAddressRepository
    {
        private readonly DbContext _context;
        private readonly DbSet<Address> _dbSet;

        public AddressRepository(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<Address>();
        }

        public async Task<Address> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<List<Address>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task AddAsync(Address address)
        {
            await _dbSet.AddAsync(address);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Address address)
        {
            _context.Entry(address).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Address address)
        {
            _dbSet.Remove(address);
            await _context.SaveChangesAsync();
        }
    }

}
