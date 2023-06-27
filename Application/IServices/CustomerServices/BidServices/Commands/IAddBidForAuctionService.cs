using ConsoleApp.Models;


namespace Application.IServices.CustomerServices.BidServices.Commands
{
    public interface IAddBidForAuctionService
    {
        Task<string> Execute(int userId, int auctionId, int price);

    }
}
