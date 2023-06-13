using ConsoleApp1.Models;
using Domin.IRepositories.IseparationRepository;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts.SqlServer;
namespace Persistence.Repositories.Orders
{
    public class AuctionRepository : IAuctionRepository
    {
        private readonly DatabaseContext _context;
        private readonly DbSet<Auction> _dbSet;

        public AuctionRepository(DatabaseContext context)
        {
            _context = context;
            _dbSet = _context.Set<Auction>();
        }

        public async Task<Auction> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }
       
        public async Task<List<Auction>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task AddAsync(Auction auction)
        {
            _context.Entry(auction).State = EntityState.Added; 
            await _context.SaveChangesAsync();
        }


        public async Task UpdateAsync(Auction auction)
        {
            _context.Entry(auction).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Auction auction)
        {
            _dbSet.Remove(auction);
            await _context.SaveChangesAsync();
        }
    }
}
