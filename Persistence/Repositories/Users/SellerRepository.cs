using ConsoleApp1.Models;
using Domin.IRepositories.Dtos;
using Domin.IRepositories.IseparationRepository;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts.SqlServer;


namespace Persistence.Repositories.Users
{
    public class SellerRepository : ISellerRepository
    {
        private readonly DatabaseContext _context;
        private readonly DbSet<Seller> _dbSet;

        public SellerRepository(DatabaseContext context)
        {
            _context = context;
            _dbSet = _context.Set<Seller>();
        }
        public async Task<Seller> GetByIdAsync(int id)
        {
            return await _dbSet.AsNoTracking()
                .Include(b=>b.Booth).
                FirstOrDefaultAsync(x => x.Id == id);
        }


        public async Task<List<Seller>> GetAllAsync()
        {
            return await _dbSet.Where(x => x.IsRemoved == false).ToListAsync();
        }

        public async Task AddAsync(Seller seller)
        {
            await _dbSet.AddAsync(seller);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateAsync(SellerUpdateRepositoryDto sellerDto)
        {
            var seller = await _dbSet.FirstOrDefaultAsync(x => x.Id == sellerDto.Id);
            if (seller == null)
            {
                return false;
            }
            seller.IsRemoved = sellerDto.IsRemoved;
            seller.CompanyName = sellerDto.CompanyName;
            seller.IsActive = sellerDto.IsActive;
            seller.CommissionPercentage = sellerDto.CommissionPercentage;
           _context.Entry(seller).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task DeleteAsync(int id)
        {
            var seller = await _dbSet.FirstOrDefaultAsync(s => s.Id == id);
            if (seller != null)
            {
                seller.IsRemoved = true;
            }
            await _context.SaveChangesAsync();
        }
    }
}
