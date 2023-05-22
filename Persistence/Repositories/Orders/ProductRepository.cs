using ConsoleApp1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.Orders
{
    public class ProductRepository : IProductRepository
    {
        private readonly DbContext _context;
        private readonly DbSet<Product> _dbSet;

        public ProductRepository(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<Product>();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task AddAsync(Product product)
        {
            await _dbSet.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Product product)
        {
            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Product product)
        {
            _dbSet.Remove(product);
            await _context.SaveChangesAsync();
        }
    }
}
