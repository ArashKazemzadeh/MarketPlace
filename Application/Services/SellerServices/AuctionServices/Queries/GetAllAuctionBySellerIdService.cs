using Application.Dtos;
using Application.IServices.SellerServices.AuctionServices.Queries;
using ConsoleApp.Models;

namespace Application.Services.SellerServices.AuctionServices.Queries
{
    internal class GetAllAuctionBySellerIdService : IGetAllAuctionBySellerIdService
    {
        public List<GeneralDto<AuctionDto>> Execute(int id)
        {
            throw new NotImplementedException();
        }
    }
}
