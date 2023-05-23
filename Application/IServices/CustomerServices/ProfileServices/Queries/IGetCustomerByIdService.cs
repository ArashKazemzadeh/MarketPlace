

using Application.Dtos;
using ConsoleApp.Models;

namespace Application.IServices.CustomerServices.ProfileServices.Queries
{
    public interface IGetCustomerByIdService
    {
        GeneralDto<CustomerDto> Execute(int id);

    }
}
