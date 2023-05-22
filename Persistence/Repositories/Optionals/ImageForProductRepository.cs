using ConsoleApp1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.Optionals
{
    public class ImageForProductRepository : IImageForProductRepository
    {
        private readonly DbContext _context;
        private readonly DbSet<ImageForProduct> _dbSet;

        public ImageForProductRepository(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<ImageForProduct>();
        }

        public async Task<ImageForProduct> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<List<ImageForProduct>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task AddAsync(ImageForProduct imageForProduct)
        {
            await _dbSet.AddAsync(imageForProduct);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ImageForProduct imageForProduct)
        {
            _context.Entry(imageForProduct).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(ImageForProduct imageForProduct)
        {
            _dbSet.Remove(imageForProduct);
            await _context.SaveChangesAsync();
        }
    }
}
