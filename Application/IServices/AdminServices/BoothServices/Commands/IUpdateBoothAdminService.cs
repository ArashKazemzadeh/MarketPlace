using Application.Dtos;
using ConsoleApp.Models;

namespace Application.IServices.AdminServices.BoothServices.Commands
{
    public interface IUpdateBoothAdminService
    {
        GeneralDto Execute(BoothDto booth);
    }
}
