using Application.Dtos;
using Application.Dtos.UserDto;

namespace Application.IServices.AdminServices.UserService.Commands;

public interface IAddUserIdToCustomerForRegisterService
{
    Task<GeneralDto> Execute(CustomerDto customerDto);
}