using Application.Dtos;
using ConsoleApp.Models;

namespace Application.IServices.SellerServices.AuctionServices.Queries
{
    public interface IGetAllAuctionBySellerIdService
    {
       List<GeneralDto<AuctionDto>>  Execute(int id);

    }
}
