using Application.Dtos;
using Application.Dtos.UserDto;

namespace Application.IServices.CustomerServices.SellerServices.Queries
{
    public interface IGetSellersByCategoryId
    {
        GeneralDto<SellerDto> Execute(int id);

    }
}
