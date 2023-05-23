using Application.Dtos;
using ConsoleApp.Models;
namespace Application.IServices.CustomerServices.AuctionServices.Queries
{
    public interface IGetAllAuctionsService
    {
       List<GeneralDto<AuctionDto>>  Execute();
    }
}
