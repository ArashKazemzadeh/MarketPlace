using Application.Dtos;
using Application.IServices.SellerServices.ProfileServices.Queries;
using ConsoleApp.Models;

namespace Application.Services.SellerServices.ProfileServices.Queries
{
    internal class GetSellerByIdService : IGetSellerByIdService
    {
        public GeneralDto<SellerDto> Execute(int sellerId)
        {
            throw new NotImplementedException();
        }
    }
}
