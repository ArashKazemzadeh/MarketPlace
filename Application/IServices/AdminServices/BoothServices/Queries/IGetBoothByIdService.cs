using ConsoleApp.Models;

namespace Application.IServices.AdminServices.BoothServices.Queries
{
    public interface IGetBoothByIdService
    {
        BoothDto Execute(int id);

    }
}
