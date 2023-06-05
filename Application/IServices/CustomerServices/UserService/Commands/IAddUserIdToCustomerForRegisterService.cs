using Application.Dtos;
using Application.Services.CustomerServices.UserService.Commands;
using ConsoleApp.Models;

namespace Application.IServices.CustomerServices.UserService.Commands;

public interface IAddUserIdToCustomerForRegisterService
{
    Task<GeneralDto> Execute(CustomerDto customerDto);
}