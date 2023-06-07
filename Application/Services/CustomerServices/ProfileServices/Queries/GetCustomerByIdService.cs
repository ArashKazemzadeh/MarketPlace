using Application.Dtos;
using Application.Dtos.UserDto;
using Application.IServices.CustomerServices.ProfileServices.Queries;

namespace Application.Services.CustomerServices.ProfileServices.Queries
{
    internal class GetCustomerByIdService : IGetCustomerByIdService
    {
        public GeneralDto<CustomerDto> Execute(int id)
        {
            throw new NotImplementedException();
        }
    }
}
