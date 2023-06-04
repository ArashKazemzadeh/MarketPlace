using Application.Dtos;
using ConsoleApp.Models;

namespace Application.IServices.AdminServices.UserService.Commands;

public interface IUpdateSellerAdminService
{
    Task<GeneralDto> Execute(SellerDto sellerDto);
}