using Application.Dtos;

using ConsoleApp.Models;

namespace Application.IServices.CustomerServices.AuctionServices.Queries
{
    public interface IGetAuctionByIdService
    {
        GeneralDto<AuctionDto> Execute(int id);
    }
}
