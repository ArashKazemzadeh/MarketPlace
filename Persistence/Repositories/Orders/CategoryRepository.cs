using ConsoleApp1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.Orders
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DbContext _context;
        private readonly DbSet<Category> _dbSet;

        public CategoryRepository(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<Category>();
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<List<Category>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task AddAsync(Category category)
        {
            await _dbSet.AddAsync(category);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Category category)
        {
            _context.Entry(category).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Category category)
        {
            _dbSet.Remove(category);
            await _context.SaveChangesAsync();
        }
    }
}
