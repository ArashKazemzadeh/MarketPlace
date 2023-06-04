using Application.Dtos;

namespace Application.IServices.AdminServices.UserService.Commands;

public interface IDeleteSellerByIdAdminService
{
    Task<GeneralDto> Execute(int id);
}