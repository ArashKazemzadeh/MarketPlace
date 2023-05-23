using Application.Dtos;
using Application.IServices.CustomerServices.BoothServices.Commands;
using ConsoleApp.Models;

namespace Application.Services.CustomerServices.BoothServices.Commands
{
    internal class GetBoothWithSellerId : IGetBoothWithSellerId
    {
        public GeneralDto<BoothDto> Execute(int id)
        {
            throw new NotImplementedException();
        }
    }
}
