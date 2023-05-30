using ConsoleApp1.Models;
using Domin.IRepositories.IseparationRepository;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts.SqlServer;

namespace Persistence.Repositories.Orders
{
    public class BoothRepository : IBoothRepository
    {
        private readonly DatabaseContext _context;
        private readonly DbSet<Booth> _dbSet;
        public BoothRepository(DatabaseContext context)
        {
            _context = context;
            _dbSet = _context.Set<Booth>();
        }
        public async Task<Booth> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }
        public async Task<List<Booth>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }
        public async Task AddAsync(Booth booth)
        {
            await _dbSet.AddAsync(booth);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Booth booth)
        {
            _context.Entry(booth).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(Booth booth)
        {
            _dbSet.Remove(booth);
            await _context.SaveChangesAsync();
        }
    }
}
