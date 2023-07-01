

using Application.Dtos;
using Castle.Core.Resource;
using ConsoleApp1.Models;
using Domin.IRepositories.IseparationRepository.SqlServer;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts.SqlServer;

namespace Persistence.Repositories.SqlServer.Auto
{
    public class AutomaticTasksOfTheApplicationRepository : IAutomaticTasksOfTheApplicationRepository
    {
        private readonly DatabaseContext _dbContext;

        public AutomaticTasksOfTheApplicationRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<string> ProcessCompletedAuctions()
        {
            var completedAuctions = await _dbContext.Auctions
                .Where(a => a.EndDeadTime <= DateTime.Now)
                .ToListAsync();

            var tasks = completedAuctions.Select(auction => ProcessAuction(auction));

            await Task.WhenAll(tasks);
            var customerId= completedAuctions.FirstOrDefault()?.Bids.OrderByDescending(b => b.Price).FirstOrDefault()?.Customer?.Id.ToString();
            if (customerId==null || customerId=="0")
            {
                return "There was no winning bid";
            }

            return customerId;
        }

        private async Task ProcessAuction(Auction auction)
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
                product.IsActive = false;
                _dbContext.Entry(product).State = EntityState.Modified;
            }

            auction.HighestPrice = highestBid?.Price ?? 0;

            _dbContext.Entry(auction).State = EntityState.Modified;

            var result = await _dbContext.SaveChangesAsync();
          

        }


    }
}

