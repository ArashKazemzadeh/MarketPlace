using Application.Dtos;
using Application.Dtos.UserDto;
using Application.IServices.CustomerServices.SellerServices.Queries;

namespace Application.Services.CustomerServices.SellerServices.Queries
{
    internal class GetSellersByCategoryId : IGetSellersByCategoryId
    {
        public GeneralDto<SellerDto> Execute(int id)
        {
            throw new NotImplementedException();
        }
    }
}
