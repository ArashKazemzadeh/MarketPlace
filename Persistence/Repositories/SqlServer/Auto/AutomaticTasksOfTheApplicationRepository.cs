using ConsoleApp1.Models;
using Domin.IRepositories.IseparationRepository.SqlServer;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts.SqlServer;
using Persistence.Repositories.SqlServer.Orders;
using System.Diagnostics;

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
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            var completedAuctions = await _dbContext.Auctions
                .Where(a => a.EndDeadTime <= DateTime.Now && a.Product.IsAuction)
                .Include(a => a.Bids)
                .ThenInclude(b => b.Customer)
                .Include(a => a.Product)
                .ThenInclude(p => p.Booth)
                .ToListAsync();

            if (completedAuctions.Count == 0)
            {
                stopwatch.Stop();
                var elapsedMilliseconds = stopwatch.ElapsedMilliseconds;
                return $"No completed auctions found at this time." +
                       $" Method execution time in milliseconds: {elapsedMilliseconds}";

            }

            foreach (var auction in completedAuctions)
            {
                if (auction.HighestPrice == 0)
                {
                    auction.Product.IsActive = false;
                    auction.Product.IsAuction = false;
                    _dbContext.Auctions.Update(auction);
                    await _dbContext.SaveChangesAsync();

                    stopwatch.Stop();
                    var elapsedMilliseconds = stopwatch.ElapsedMilliseconds;
                    return $"The auction failed and there was no winner." +
                           $" Method execution time in milliseconds: {elapsedMilliseconds}";
                }

                var customer = auction.Bids
                    .OrderByDescending(b => b.Price)
                    .Select(b => b.Customer)
                    .FirstOrDefault();

                if (customer == null)
                {
                    return $"No bids were made for the auction at this time." +
                           $" Method execution time in milliseconds." +
                           $" Auction ProductId: {auction.Product.Id}";
                }

                var cart = new Cart
                {
                    RegisterDate = DateTime.Now,
                    TotalPrices = auction.HighestPrice,
                    IsRegistrationFinalized = false,
                    SellerId = auction.Product.Booth.SellerId,
                    CustomerId = customer.Id
                };

                await _dbContext.AddAsync(cart);
                await _dbContext.SaveChangesAsync();

                var productCart = new ProductsCart
                {
                    ProductId = auction.ProductId,
                    CartId = cart.Id,
                    Quantity = auction.Product.Availability
                };

                await _dbContext.AddAsync(productCart);
                await _dbContext.SaveChangesAsync();

                auction.Product.IsAuction = false;
                auction.Product.Availability = 0;

                var bidToUpdate = auction.Bids.FirstOrDefault(b => b.CustomerId == customer.Id);
                if (bidToUpdate != null)
                {
                    bidToUpdate.IsAccepted = true;
                    _dbContext.Bids.Update(bidToUpdate);
                    await _dbContext.SaveChangesAsync();
                }

                _dbContext.Auctions.Update(auction);
                await _dbContext.SaveChangesAsync();

                stopwatch.Stop();
                var elapsedMilliseconds2 = stopwatch.ElapsedMilliseconds;
                return $"Success. Method execution time in milliseconds: {elapsedMilliseconds2}";
            }

            stopwatch.Stop();
            var elapsedMilliseconds3 = stopwatch.ElapsedMilliseconds;
            return $"Success. Method execution time in milliseconds: {elapsedMilliseconds3}";
        }

    }

}

