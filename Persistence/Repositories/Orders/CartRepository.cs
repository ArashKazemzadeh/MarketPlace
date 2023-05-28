using ConsoleApp1.Models;
using Domin.IRepositories.IseparationRepository;
using Microsoft.EntityFrameworkCore;


namespace Persistence.Repositories.Orders
{
    public class CartRepository : ICartRepository
    {
        private readonly DbContext _context;
        private readonly DbSet<Cart> _dbSet;

        public CartRepository(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<Cart>();
        }

        public async Task<Cart> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<List<Cart>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task AddAsync(Cart cart)
        {
            await _dbSet.AddAsync(cart);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Cart cart)
        {
            _context.Entry(cart).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Cart cart)
        {
            _dbSet.Remove(cart);
            await _context.SaveChangesAsync();
        }
    }
}
