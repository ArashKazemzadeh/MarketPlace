

using Application.Dtos;
using Application.IServices.CustomerServices.AuctionServices.Queries;
using ConsoleApp.Models;

namespace Application.Services.CustomerServices.AuctionServices.Queries
{
    internal class GetAuctionByIdService : IGetAuctionByIdService
    {
        public GeneralDto<AuctionDto> Execute(int id)
        {
            throw new NotImplementedException();
        }
    }
}
