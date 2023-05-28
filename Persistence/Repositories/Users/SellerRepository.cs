using ConsoleApp1.Models;
using Domin.IRepositories.IseparationRepository;
using Microsoft.EntityFrameworkCore;


namespace Persistence.Repositories.Users
{
    public class SellerRepository : ISellerRepository
    {
        private readonly DbContext _context;
        private readonly DbSet<Seller> _dbSet;

        public SellerRepository(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<Seller>();
        }
        public async Task<Seller> GetByIdAsync(int id)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
        }


        public async Task<List<Seller>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task AddAsync(Seller seller)
        {
            await _dbSet.AddAsync(seller);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Seller seller)
        {
            _context.Entry(seller).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Seller seller)
        {
            _dbSet.Remove(seller);
            await _context.SaveChangesAsync();
        }
    }
}
