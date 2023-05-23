using Application.Dtos;
using ConsoleApp.Models;

namespace Application.IServices.CustomerServices.SellerServices.Queries
{
    public interface IGetSellersByCategoryId
    {
        GeneralDto<SellerDto> Execute(int id);

    }
}
