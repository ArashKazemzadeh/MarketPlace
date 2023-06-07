using Application.Dtos;
using Application.Dtos.UserDto;

namespace Application.IServices.SellerServices.ProfileServices.Queries
{
    public interface IGetSellerByIdService
    {
        GeneralDto<SellerDto> Execute(int sellerId);

    }
}
