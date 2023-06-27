
using ConsoleApp1.Models;
using Domin.IRepositories.Dtos.Cart;
using Domin.IRepositories.IseparationRepository;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts.SqlServer;

namespace Persistence.Repositories.Orders
{
    public class ProductsCartRepository : IProductsCartRepository
    {
        private readonly DatabaseContext _context;
        private readonly DbSet<ProductsCart> _dbSet;

        public ProductsCartRepository(DatabaseContext context)
        {
            _context = context;
            _dbSet = _context.Set<ProductsCart>();
        }
        public async Task AddProductToCartAsync(int cartId, int productId)
        {
            var cart = await _context.Carts.Include(pc=>pc.ProductsCarts)
                .ThenInclude(p=>p.Product)
                .FirstOrDefaultAsync(c => c.Id == cartId);
            if (cart == null)
                return;
            var existingProductsCart = cart.ProductsCarts.FirstOrDefault(pc => pc.ProductId == productId);
            if (existingProductsCart != null)
            {

                // کالای با ایدی مشترک در کارت وجود دارد، تعداد آن را افزایش دهید
                existingProductsCart.Quantity =1+ existingProductsCart.Quantity;
                existingProductsCart.Cart.TotalPrices = existingProductsCart.Quantity * existingProductsCart.Product.BasePrice;
                cart.TotalPrices = existingProductsCart.Quantity * existingProductsCart.Product.BasePrice;
                _context.Entry(cart).State = EntityState.Modified;
                _context.Entry(existingProductsCart).State = EntityState.Modified;
            }
            else
            {
                // کالای با ایدی مشترک در کارت وجود ندارد، کالای جدیدی را به کارت اضافه کنید
                var productsCart = new ProductsCart
                {
                    CartId = cart.Id,
                    ProductId = productId,
                    Quantity = 1
                };
                await _context.ProductsCarts.AddAsync(productsCart);
            }
         var result=   await _context.SaveChangesAsync();
        }

        public async Task<ProductsCart> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<List<ProductsCart>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task AddAsync(ProductsCartDto dto)
        {
            var productsCart = new ProductsCart
            {
                CartId =(int) dto.CartId ,
                ProductId = dto.ProductId ,
                Quantity = 1
            };
            await _dbSet.AddAsync(productsCart);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ProductsCart productsCart)
        {
            _context.Entry(productsCart).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(ProductsCart productsCart)
        {
            _dbSet.Remove(productsCart);
            await _context.SaveChangesAsync();
        }
    }
}
