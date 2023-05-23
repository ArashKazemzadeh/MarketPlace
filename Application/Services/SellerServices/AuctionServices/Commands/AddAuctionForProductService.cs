using Application.Dtos;
using Application.IServices.SellerServices.AuctionServices.Commands;
using ConsoleApp.Models;

namespace Application.Services.SellerServices.AuctionServices.Commands
{
    internal class AddAuctionForProductService : IAddAuctionForProductService
    {
        public GeneralDto<AuctionDto> Execute(AuctionDto auctionDto)
        {
            throw new NotImplementedException();
        }
    }
}
