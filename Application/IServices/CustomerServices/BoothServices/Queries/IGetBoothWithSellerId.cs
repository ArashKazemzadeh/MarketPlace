

using Application.Dtos;
using ConsoleApp.Models;

namespace Application.IServices.CustomerServices.BoothServices.Commands
{
    public interface IGetBoothWithSellerId
    {
        GeneralDto<BoothDto> Execute(int id);

    }
}
