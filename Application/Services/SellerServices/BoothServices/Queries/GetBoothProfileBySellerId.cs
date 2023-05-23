using Application.Dtos;
using Application.IServices.SellerServices.BoothServices.Queries;
using ConsoleApp.Models;

namespace Application.Services.SellerServices.BoothServices.Queries
{
    internal class GetBoothProfileBySellerId : IGetBoothProfileBySellerId
    {
        public GeneralDto<BoothDto> Execute(int sellerId)
        {
            throw new NotImplementedException();
        }
    }
}
