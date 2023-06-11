using Application.Dtos;
using ConsoleApp.Models;
using Domin.IRepositories.Dtos;

namespace Application.IServices.SellerServices.AuctionServices.Queries
{
    public interface IGetAllAuctionBySellerIdService
    {
    public Task<GeneralDto<List<AuctionProductDto>>> Execute(int sellerId);

    }
}
