using ConsoleApp.Models;


namespace Application.IServices.CustomerServices.BidServices.Commands
{
    public interface IAddBidForAuctionService
    {
        Task<bool> Execute(int userId, int auctionId, int price);

    }
}
