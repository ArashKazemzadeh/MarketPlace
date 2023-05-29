using Application.Dtos;
using ConsoleApp.Models;

namespace Application.IServices.AdminServices.BoothServices.Queries
{
    public interface IGetBoothByIdService
    {
        Task<GeneralDto<BoothDto>> Execute(int id);
    }
}
