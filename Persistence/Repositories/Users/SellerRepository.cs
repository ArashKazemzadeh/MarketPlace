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

        public async Task AddAsync(SellerRepDto sellerRepDto)
        {
            var seller = new Seller
            {
                Id = sellerRepDto.Id,
                CompanyName = sellerRepDto.CompanyName,
                CommissionPercentage = 0.1,
            };
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
        public async Task<bool> UpdateProfileAsync(AddSellerDto updatesellerDto)
        {
            var seller = await _dbSet.Include(x => x.Address)
                .Include(b=>b.Booth)
                .FirstOrDefaultAsync(x => x.Id == updatesellerDto.SellerId);

            if (seller == null)
            {
                return false;
            }

            seller.CompanyName = updatesellerDto.CompanyName;

            if (seller.Address == null)
            {
                var address = new Address
                {
                    City = updatesellerDto.City,
                    Street = updatesellerDto.Street,
                    Description = updatesellerDto.AddressDescription,
                    SellerId = updatesellerDto.SellerId
                };

                seller.Address = address;
            }
            else
            {
                // Update the existing address
                seller.Address.City = updatesellerDto.City;
                seller.Address.Street = updatesellerDto.Street;
                seller.Address.Description = updatesellerDto.AddressDescription;

            }
            if (seller.Booth == null)
            {
                var booth = new Booth()
                {
                    Name = updatesellerDto.BoothName,
                    SellerId  = updatesellerDto.SellerId,
                    Description = updatesellerDto.BoothDescription
                };

                seller.Booth = booth;
            }
            else
            {
                seller.Booth.Name = updatesellerDto.BoothName;
                seller.Booth.Description = updatesellerDto.BoothDescription;
            }


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
