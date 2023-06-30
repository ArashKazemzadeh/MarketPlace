using Application.Services.SellerServices.ProfileServices.Queries;
using ConsoleApp1.Models;
using Domin.IRepositories.Dtos;
using Domin.IRepositories.IseparationRepository.SqlServer;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts.SqlServer;


namespace Persistence.Repositories.SqlServer.Users
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
        public async Task<FinancialRepSeller> GetFinancialBySellerId(int sellerId)
        {
            var seller = await _dbSet.FirstOrDefaultAsync(x => x.Id == sellerId);
            if (seller == null)
                return null;

            var result = new FinancialRepSeller()
            {
                Id = sellerId,
                SalesAmount = seller.SalesAmount,
                CommissionPercentage = seller.CommissionPercentage,
                CommissionsAmount = seller.CommissionsAmount,
                Medals = seller.Medals
            };
            return result;
        }

        public async Task<Seller> GetByIdAsync(int id)
        {
            var result = await _dbSet
                  .Include(b => b.Booth)
                  .FirstOrDefaultAsync(x => x.Id == id);
            if (result == null)
                return null;
            return result;
        }
        public async Task<AddSellerDto> GetByIdWithNavigationAsync(int id)
        {
            var result = await _dbSet.AsNoTracking().Select(s => new AddSellerDto
            {
                SellerId = s.Id,
                CompanyName = s.CompanyName,
                City = s.Address.City,
                Street = s.Address.Street,
                AddressDescription = s.Address.Description,
                BoothName = s.Booth.Name,
                BoothDescription = s.Booth.Description,
                BoothId = s.Booth.Id,
                AddressId = s.Address.Id,

            })
                   .FirstOrDefaultAsync(x => x.SellerId == id);
            return result;
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
                .Include(b => b.Booth)
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
                    SellerId = updatesellerDto.SellerId,
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
