using Application.Dtos;
using Application.Dtos.UserDto;
using Application.IServices.CustomerServices.ProfileServices.Commands;

namespace Application.Services.CustomerServices.ProfileServices.Commands
{
    internal class UpdateCustomerByIdService : IUpdateCustomerByIdService
    {
        public GeneralDto<CustomerDto> Execute(CustomerDto customerDto)
        {
            throw new NotImplementedException();
        }
    }
}
