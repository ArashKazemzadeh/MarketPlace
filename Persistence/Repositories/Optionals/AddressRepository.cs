using ConsoleApp1.Models;
using Domin.IRepositories.Dtos;
using Domin.IRepositories.IseparationRepository;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts.SqlServer;

namespace Persistence.Repositories.Optionals
{
    public class AddressRepository : IAddressRepository
    {
        private readonly DatabaseContext _context;
        private readonly DbSet<Address> _dbSet;

        public AddressRepository(DatabaseContext context)
        {
            _context = context;
            _dbSet = _context.Set<Address>();
        }

        public async Task<Address> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<List<Address>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task AddAsync(AddressRepDto addressRepDto)
        {
            var address = new Address
            {
                City = addressRepDto.City,
                Street = addressRepDto.Street,
                Description = addressRepDto.Description,
                SellerId= addressRepDto.SellerId,
                CustomerId = addressRepDto.CustomerId
            };
            await _dbSet.AddAsync(address);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(AddressRepDto addressdto)
        {
            var address = await _dbSet.FindAsync(addressdto.AddressId);
            if (address == null)
            {
                // Handle the case when the address is not found
                return;
            }

            // Update address properties
            address.City = addressdto.City;
            address.Street = addressdto.Street;
            address.Description = addressdto.Description;

            _context.Entry(address).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Address address)
        {
            _dbSet.Remove(address);
            await _context.SaveChangesAsync();
        }
    }

}
