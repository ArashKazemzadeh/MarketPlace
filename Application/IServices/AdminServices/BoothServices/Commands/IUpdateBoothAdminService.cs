using Application.Dtos;
using ConsoleApp.Models;

namespace Application.IServices.AdminServices.BoothServices.Commands
{
    public interface IUpdateBoothAdminService
    {
        Task<GeneralDto> Execute(BoothDto booth);
    }
}
