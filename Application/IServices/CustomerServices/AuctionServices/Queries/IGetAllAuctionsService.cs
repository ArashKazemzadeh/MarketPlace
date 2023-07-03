using ConsoleApp.Models;
using Domin.IRepositories.Dtos.Auction;

namespace Application.IServices.CustomerServices.AuctionServices.Queries
{
    public interface IGetAllAuctionsService
    {
      Task<List<AuctionProductDto>> Execute();
    }
}
