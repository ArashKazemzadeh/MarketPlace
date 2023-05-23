using Application.Dtos;
using Application.IServices.CustomerServices.ProfileServices.Queries;
using ConsoleApp.Models;

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
