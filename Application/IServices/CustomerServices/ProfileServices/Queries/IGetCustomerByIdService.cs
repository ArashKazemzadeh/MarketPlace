

using Application.Dtos;
using Application.Dtos.UserDto;

namespace Application.IServices.CustomerServices.ProfileServices.Queries
{
    public interface IGetCustomerByIdService
    {
        GeneralDto<CustomerDto> Execute(int id);

    }
}
