
using Application.Dtos;

namespace Application.IServices.AdminServices.BoothServices.Commands
{
    public interface IDeleteBoothAdminService
    {
        Task<GeneralDto> Execute(int id);
    }
}
