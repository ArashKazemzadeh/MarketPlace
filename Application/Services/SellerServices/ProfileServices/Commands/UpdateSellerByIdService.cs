using Application.Dtos;
using Application.IServices.SellerServices.ProfileServices.Commands;
using ConsoleApp.Models;

namespace Application.Services.SellerServices.ProfileServices.Commands
{
    internal class UpdateSellerByIdService : IUpdateSellerByIdService
    {
        public GeneralDto<SellerDto> Execute(int sellerId)
        {
            throw new NotImplementedException();
        }
    }
}
