using Application.Dtos;
using Application.Dtos.UserDto;
using Application.IServices.SellerServices.ProfileServices.Queries;

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
