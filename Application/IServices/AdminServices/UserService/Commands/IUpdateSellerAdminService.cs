using Application.Dtos;
using Application.Dtos.UserDto;

namespace Application.IServices.AdminServices.UserService.Commands;

public interface IUpdateSellerAdminService
{
    Task<GeneralDto> Execute(SellerDto sellerDto);
}
