using Application.Dtos.UserDto;

namespace Application.IServices.AdminServices.UserService.Queries;

public interface IGetAllSellerAdminService
{
    Task<List<SellerDto>> Execute();
}