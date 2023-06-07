using Application.Dtos;
using Application.Dtos.UserDto;
using Application.IServices.SellerServices.ProfileServices.Commands;

namespace Application.Services.SellerServices.ProfileServices.Commands
{
    internal class UpdateSellerByIdService : IUpdateSellerByIdService
    {
        public GeneralDto<SellerDto> Execute(int sellerId)
        {
            throw new NotImplementedException();
        }
    }
}
