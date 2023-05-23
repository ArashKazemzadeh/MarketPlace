
using Application.Dtos;

namespace Application.IServices.AdminServices.BoothServices.Commands
{
    public interface IDeleteBoothAdminService
    {
        GeneralDto Execute(int id);
    }
}
