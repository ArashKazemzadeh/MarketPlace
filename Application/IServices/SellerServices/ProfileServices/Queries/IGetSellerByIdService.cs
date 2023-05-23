using Application.Dtos;
using ConsoleApp.Models;

namespace Application.IServices.SellerServices.ProfileServices.Queries
{
    public interface IGetSellerByIdService
    {
        GeneralDto<SellerDto> Execute(int sellerId);

    }
}
