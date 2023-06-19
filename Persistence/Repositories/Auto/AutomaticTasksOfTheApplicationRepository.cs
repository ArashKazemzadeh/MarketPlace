

using ConsoleApp1.Models;
using Domin.IRepositories.IseparationRepository;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts.SqlServer;

namespace Persistence.Repositories.Auto
{
    public class AutomaticTasksOfTheApplicationRepository: IAutomaticTasksOfTheApplicationRepository
    {
        private readonly DatabaseContext _dbContext;
        public AutomaticTasksOfTheApplicationRepository(DatabaseContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public async Task ProcessCompletedAuctions()
        {
            var completedAuctions =await _dbContext.Auctions
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
                        TotalPrices = product.Availability* highestBid.Price
                    };
                 await   _dbContext.Carts.AddAsync(cart);
                 var productsCart = new ProductsCart
                    {
                        Cart = cart,
                        Product = product,
                        Quantity = product.Availability
                    };

                  await  _dbContext.ProductsCarts.AddAsync(productsCart);
                  product.Availability = 0;
                  _dbContext.Entry(product).State = EntityState.Modified;
                }

                auction.HighestPrice = highestBid?.Price ?? 0;
                _dbContext.Entry(auction).State = EntityState.Modified;
            }
            await  _dbContext.SaveChangesAsync();
        }

    }
}
