

using ConsoleApp.Models;

namespace Application.IServices.AdminServices.BoothServices.Queries
{
    public interface IGetAllBoothAdminService
    {
        List<BoothDto> Execute();
    }
}
