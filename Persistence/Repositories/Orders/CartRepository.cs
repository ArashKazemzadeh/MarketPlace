using ConsoleApp1.Models;
using Domin.IRepositories.Dtos;
using Domin.IRepositories.IseparationRepository;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts.SqlServer;


namespace Persistence.Repositories.Orders
{
    public class CartRepository : ICartRepository
    {
        private readonly DatabaseContext _context;
        private readonly DbSet<Cart> _dbSet;

        public CartRepository(DatabaseContext context)
        {
            _context = context;
            _dbSet = _context.Set<Cart>();
        }
        public async Task<bool> FinalizeCartAsync(int cartId)
        {
            var cart = await _dbSet.FindAsync(cartId);
            if (cart == null)
            {
                return false; 
            }

            cart.IsRegistrationFinalized = true;
            await _context.SaveChangesAsync();
            return true; 
        }
        public async Task<List<CartGetDto>> GetUnfinalizedCartsByCustomerId(int customerId)
        {
         var list=   await _dbSet
                .Where(c => c.CustomerId == customerId && (c.IsRegistrationFinalized == null || c.IsRegistrationFinalized == false))
                .Select(c=>new CartGetDto
                {
                    Id = c.Id,
                    CustomerId = customerId,
                    boothId = c.Seller.Booth.Id,
                    BoothName = c.Seller.Booth.Name,
                    TotalPrices = c.TotalPrices,
                    IsRegistrationFinalized = c.IsRegistrationFinalized,
                    ProductsNames = c.ProductsCarts.Select(p=>p.Product.Name).ToList()
                })
                .ToListAsync();

         return list;
        }
        public async Task<List<CartGetDto>> GetfinalizedCartsByCustomerId(int customerId)
        {
            var list = await _dbSet
                .Where(c => c.CustomerId == customerId && (c.IsRegistrationFinalized == true))
                .Select(c => new CartGetDto
                {
                    Id = c.Id,
                    CustomerId = customerId,
                    boothId = c.Seller.Booth.Id,
                    BoothName = c.Seller.Booth.Name,
                    TotalPrices = c.TotalPrices,
                    IsRegistrationFinalized = c.IsRegistrationFinalized,
                    ProductsNames = c.ProductsCarts.Select(p => p.Product.Name).ToList()
                })
                .ToListAsync();

            return list;
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
