using ConsoleApp1.Models;
using Domin.IRepositories.IseparationRepository;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts.SqlServer;


namespace Persistence.Repositories.Orders
{
    public class ProductRepository : IProductRepository
    {
        private readonly DatabaseContext _context;
        private readonly DbSet<Product> _dbSet;

        public ProductRepository(DatabaseContext context)
        {
            _context = context;
            _dbSet = _context.Set<Product>();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }
        

        public async Task<List<Product>> GetProductsWithSellerNameConfirmAsync()
        {
            var products = await _dbSet
                .Include(p => p.Booth)
                .ThenInclude(b => b.Seller).Where(x => x.IsConfirm == false || x.IsConfirm == null).ToListAsync();
               

            return products;
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
