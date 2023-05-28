using ConsoleApp1.Models;
using Domin.IRepositories.IseparationRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.Orders
{
    public class ProductsCartRepository : IProductsCartRepository
    {
        private readonly DbContext _context;
        private readonly DbSet<ProductsCart> _dbSet;

        public ProductsCartRepository(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<ProductsCart>();
        }

        public async Task<ProductsCart> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<List<ProductsCart>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task AddAsync(ProductsCart productsCart)
        {
            await _dbSet.AddAsync(productsCart);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ProductsCart productsCart)
        {
            _context.Entry(productsCart).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(ProductsCart productsCart)
        {
            _dbSet.Remove(productsCart);
            await _context.SaveChangesAsync();
        }
    }
}
