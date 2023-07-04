using ConsoleApp1.Models;
using Domin.IRepositories.Dtos;
using Domin.IRepositories.Dtos.Cart;
using Domin.IRepositories.IseparationRepository.SqlServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Persistence.Contexts.SqlServer;

namespace Persistence.Repositories.SqlServer.Orders
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
        public async Task<int> GetTotalPrices(int cartId)
        {
            var products = await _context.ProductsCarts
                .Where(pc => pc.CartId == cartId)
                .Include(pc => pc.Product)
                .ToListAsync();

            var amount = (int)products.Sum(pc => pc.Product.BasePrice * pc.Quantity);
            return amount;
        }

        public async Task<List<Cart>> GetOpenCartsForCustomerIdByBoothIdAsync(int boothId, int cudtomerId)
        {
            //A list of open cards of a customer that is related to a booth
            var carts = await _dbSet
                .Where(c => !c.IsRegistrationFinalized && c.Customer.Id == cudtomerId)
                .Include(s => s.Seller)
                .ThenInclude(b => b.Booth)
                .ToListAsync();

            var matchingCarts = carts
                .Where(c => c.Seller.Booth.Id == boothId).ToList();
            return matchingCarts;
        }
        public async Task<bool> FinalizeCartAsync(int cartId)
        {
            var cart = await _dbSet.FindAsync(cartId);
            var seller = await _dbSet
                .Where(c => c.Id == cartId)
                .SelectMany(c => c.ProductsCarts)
                .Select(pc => pc.Product)
                .Select(p => p.Booth)
                .Select(b => b.Seller)
                .FirstOrDefaultAsync();

            if (seller == null)
                return false;
            if (cart == null)
                return false;

            seller.CommissionsAmount += Convert.ToInt32(cart.TotalPrices * seller.CommissionPercentage);
            var amount = cart.TotalPrices - seller.CommissionsAmount;
            seller.SalesAmount += amount;

            cart.IsRegistrationFinalized = true;
            cart.RegisterDate = DateTime.Now;
            _context.Entry(seller).State = EntityState.Modified;
            _context.Entry(cart).State = EntityState.Modified;
            var e = await _context.SaveChangesAsync();
            if (e != 0)
                return true;
            return false;
        }
        public async Task<List<CartGetDto>> GetUnfinalizedCartsByCustomerId(int customerId)
        {

            var list = await _dbSet
                   .Where(c => c.CustomerId == customerId && (c.IsRegistrationFinalized == null || c.IsRegistrationFinalized == false))
                  
                   .Select(c => new CartGetDto
                   {
                       Id = c.Id,
                       CustomerId = customerId,
                       boothId = c.Seller.Booth.Id,
                       BoothName = c.Seller.Booth.Name,
                       TotalPrices = c.TotalPrices,//
                       IsRegistrationFinalized = c.IsRegistrationFinalized,
                       ProductsNames = c.ProductsCarts.Select(p => p.Product.Name).ToList(),
                       QuantityFromOne = c.ProductsCarts.Select(c => c.Quantity.Value).Sum() //
                   })
                   .ToListAsync();

            return list;
        }
        public async Task<List<CartGetDto>> GetfinalizedCartsByCustomerId(int customerId)
        {
            var list = await _dbSet
                .Where(c => c.CustomerId == customerId && c.IsRegistrationFinalized == true)
                .Select(c => new CartGetDto
                {
                    Id = c.Id,
                    CustomerId = customerId,
                    boothId = c.Seller.Booth.Id,
                    BoothName = c.Seller.Booth.Name,
                    TotalPrices = c.TotalPrices,
                    IsRegistrationFinalized = c.IsRegistrationFinalized,
                    ProductsNames = c.ProductsCarts.Select(p => p.Product.Name).ToList(),
                    RegisterDate = c.RegisterDate
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
            var result = await _context.SaveChangesAsync();
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

        public async Task<List<ProductInCartRepDto>> GetProductsOpenCartByCartIdAsync(int cartId)
        {
            var productsInfo = await _context.Carts
                .Where(c => c.Id == cartId && !c.IsRegistrationFinalized)
                .SelectMany(c => c.ProductsCarts)
                .Select(pc => new ProductInCartRepDto
                {
                    ProductId = pc.ProductId,
                    BasePrice = Convert.ToInt32(pc.Product.BasePrice),
                    Name = pc.Product.Name,
                    TotalPrice = Convert.ToInt32(pc.Quantity * pc.Product.BasePrice),
                    Quantity = Convert.ToInt32(pc.Quantity),
                    BoothId = (int)pc.Product.BoothId
                })
                .ToListAsync();

            return productsInfo;
        }
        public async Task<List<ProductInCartRepDto>> GetProductsByCartIdAsync(int cartId)
        {
            var productsInfo = await _context.Carts
                .Where(c => c.Id == cartId && c.IsRegistrationFinalized)
                .SelectMany(c => c.ProductsCarts)
                .Select(pc => new ProductInCartRepDto
                {
                    ProductId = pc.ProductId,
                    BasePrice = Convert.ToInt32(pc.Product.BasePrice),
                    Name = pc.Product.Name,
                    TotalPrice = Convert.ToInt32(pc.Quantity * pc.Product.BasePrice),
                    Quantity = Convert.ToInt32(pc.Quantity),
                    BoothId = (int)pc.Product.BoothId
                })
                .ToListAsync();

            return productsInfo;
        }
        public async Task<string> DeleteOpenCartAsync(int customerId, int cartId)
        {
            // دریافت سبد خرید مشتری
            var customerCart = await _context.Carts
                .Include(c => c.ProductsCarts)
                .ThenInclude(pc => pc.Product)
                .ThenInclude(p => p.Auction)
                .ThenInclude(a=>a.Bids)
                .SingleOrDefaultAsync(c => c.CustomerId == customerId && c.Id == cartId && !c.IsRegistrationFinalized);

            if (customerCart == null)
            {
                return "سبد خرید مشتری یافت نشد";
            }

            // بررسی وجود کالاهای با IsAuction=true در سبد خرید
            bool hasAuctionProducts = customerCart.ProductsCarts.Any(pc => pc.Product.IsAuction);

            if (hasAuctionProducts)
            {
                return "در سبد خرید مشتری کالاهایی با قابلیت حراجی وجود دارد. لطفاً برای حذف این سبد خرید با پشتیبانی تماس بگیرید.";
            }


            var isAuctionProductAddedByCustomer = customerCart.ProductsCarts
                .Any(pc => pc.Product.Auction.Bids.Any(b => b.CustomerId == customerId && b.IsAccepted == true));

            if (isAuctionProductAddedByCustomer)
            {
                return "شما مجاز به حذف سبد مزایده‌ای که پیشنهاد آن توسط مزایده پذیرفته شده است نمی‌باشید";
            }

            // حذف کلیه محصولات سبد خرید
            _context.ProductsCarts.RemoveRange(customerCart.ProductsCarts);

            // حذف سبد خرید
            _context.Carts.Remove(customerCart);

            await _context.SaveChangesAsync();

            return "سبد خرید مشتری با موفقیت حذف شد";
        }


    }
}
