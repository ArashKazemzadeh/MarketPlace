using Application.Dtos;
using Application.IServices.CustomerServices.BidServices.Commands;
using ConsoleApp.Models;

namespace Application.Services.CustomerServices.BidServices.Commands
{
    internal class AddBidForAuctionService : IAddBidForAuctionService
    {
        public GeneralDto<BidDto> Execute(BidDto biddto)
        {
            throw new NotImplementedException();
        }
    }
}
