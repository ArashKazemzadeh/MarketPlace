

using ConsoleApp1.Models;
using Domin.IRepositories.IseparationRepository;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts.SqlServer;

namespace Persistence.Repositories.Auto
{
    public class AutomaticTasksOfTheApplicationRepository : IAutomaticTasksOfTheApplicationRepository
    {
        private readonly DatabaseContext _dbContext;
        public AutomaticTasksOfTheApplicationRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task ProcessCompletedAuctions()
        {
            var completedAuctions = await _dbContext.Auctions
                .Where(a => a.EndDeadTime <= DateTime.Now)
                .ToListAsync();
            foreach (var auction in completedAuctions)
            {
                var highestBid = auction.Bids
                    .OrderByDescending(b => b.Price)
                    .FirstOrDefault();

                if (highestBid != null && highestBid.Customer != null)
                {
                    var customer = highestBid.Customer;
                    var product = auction.Product;
                    var cart = new Cart
                    {
                        Customer = customer,
                        TotalPrices = product.Availability * highestBid.Price
                    };
                    await _dbContext.Carts.AddAsync(cart);
                    var productsCart = new ProductsCart
                    {
                        Cart = cart,
                        Product = product,
                        Quantity = product.Availability
                    };

                    await _dbContext.ProductsCarts.AddAsync(productsCart);
                    product.Availability = 0;
                    _dbContext.Entry(product).State = EntityState.Modified;
                }

                auction.HighestPrice = highestBid?.Price ?? 0;
                _dbContext.Entry(auction).State = EntityState.Modified;
            }
            await _dbContext.SaveChangesAsync();
        }
        public async Task CalculateCommissions()
        {
            // انجام محاسبات و ذخیره نتایج در فروشندگان
            // به عنوان مثال، محاسبه مبلغ کل و کمیسیون برای هر فروشنده
            List<Seller> sellers = await _dbContext.Sellers.ToListAsync();

            foreach (var seller in sellers)
            {
                // جمع آوری کارت‌های فروشنده با IsRegistrationFinalized == true
                List<Cart> sellerCarts = seller.Carts.Where(c => c.IsRegistrationFinalized).ToList();

                // محاسبه مبلغ کل کارت‌ها
                int salesAmount = sellerCarts.Sum(c => c.TotalPrices ?? 0);

                // بروزرسانی مبلغ کل در فروشنده
                seller.SalesAmount = salesAmount;

                // محاسبه کمیسیون
                double commissionPercentage = seller.CommissionPercentage;
                int commissionsAmount = (int)(salesAmount * commissionPercentage);

                // بروزرسانی کمیسیون در فروشنده
                seller.CommissionsAmount = commissionsAmount;
            }
            await _dbContext.SaveChangesAsync();
        }

        public async Task AggregateCommissionsForAdmin()
        {
            var totalCommissions = await _dbContext.Sellers.SumAsync(s => s.CommissionsAmount) ?? 0;

            var admin = await _dbContext.Admins.FirstOrDefaultAsync();
            if (admin != null)
            {
                admin.TotalSiteCommissionAmounts = totalCommissions;
                await _dbContext.SaveChangesAsync();
            }
        }

    }
}

