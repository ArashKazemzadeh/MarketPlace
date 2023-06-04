using ConsoleApp.Models;

namespace Application.IServices.AdminServices.UserService.Queries;

public interface IGetAllSellerAdminService
{
    Task<List<SellerDto>> Execute();
}