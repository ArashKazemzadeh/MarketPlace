

using ConsoleApp.Models;

namespace Application.IServices.AdminServices.BoothServices.Queries
{
    public interface IGetAllBoothAdminService
    {
        Task<List<BoothDto>> Execute();
    }
}
