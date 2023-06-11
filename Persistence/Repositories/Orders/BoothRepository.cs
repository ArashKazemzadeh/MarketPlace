using ConsoleApp.Models;
using ConsoleApp1.Models;
using Domin.IRepositories.Dtos;
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
        public async Task<List<BoothRepositoryDto>> GetAllAsync()
        {
           var booth= await _dbSet.AsNoTracking().Include(x=>x.Seller).ToListAsync();
           var result = booth.Select(b=>new BoothRepositoryDto
           {
               Id = b.Id,
               Name = b.Name,
               Description = b.Description,
               Seller = b.Seller,
               SellerId = b.SellerId,
               SellerName = b.Seller.CompanyName
           }).ToList();
           return result;
        }
        public async Task AddAsync(BoothRepDto boothRepDto)
        {
            var booth = new Booth()
            {
                Name = boothRepDto.Name,
                Description = boothRepDto.Description, 
                SellerId = boothRepDto.SellerId,
            };
            await _dbSet.AddAsync(booth);
            await _context.SaveChangesAsync();
        }
        public async Task<bool> UpdateBoothAsync(BoothRepDto boothRepDto)
        {
            var booth = await _dbSet.FirstOrDefaultAsync(x => x.Id == boothRepDto.BoothId);
            if (booth == null)
            {
                return false;
            }
            booth.Name = boothRepDto.Name;
            booth.Description = boothRepDto.Description;
            _context.Entry(booth).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task DeleteAsync(Booth booth)
        {
            _dbSet.Remove(booth);
            await _context.SaveChangesAsync();
        }
    }
}
