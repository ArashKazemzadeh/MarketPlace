using Castle.Core.Resource;
using ConsoleApp1.Models;
using Domin.IRepositories.Dtos.Cart;
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
        public async Task<List<Cart>> GetOpenCartsForCustomerIdByBoothIdAsync(int boothId,int cudtomerId)
        {
            //لست کارت های باز یک مشتری که مربوط به یک غرفه است
            var carts = await _dbSet
                .Where(c => !c.IsRegistrationFinalized && c.Customer.Id==cudtomerId)
                .ToListAsync();
            var matchingCarts = carts
                .Where(c => c.ProductsCarts.Any(pc => pc.Product.BoothId == boothId))
                .ToList();
            return matchingCarts;
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

        public async Task<CartAddDto> AddAsync(CartAddDto dto)
        {
            var cart = new Cart
            {
                CustomerId = dto.CustomerId,
                SellerId = dto.SellerId,
                TotalPrices = dto.TotalPrices,
            };
            await _dbSet.AddAsync(cart);
          var result=  await _context.SaveChangesAsync();
          if (result != 0)
              return new CartAddDto
              {
                  Id = cart.Id,
                  CustomerId = dto.CustomerId,
                  SellerId = dto.SellerId,
                  TotalPrices = dto.TotalPrices,
              };
          return null;
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
