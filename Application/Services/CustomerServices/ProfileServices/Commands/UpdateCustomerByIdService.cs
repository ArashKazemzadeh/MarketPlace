using Application.Dtos;
using Application.IServices.CustomerServices.ProfileServices.Commands;
using ConsoleApp.Models;

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
