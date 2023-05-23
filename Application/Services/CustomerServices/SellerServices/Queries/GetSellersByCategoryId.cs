using Application.Dtos;
using Application.IServices.CustomerServices.SellerServices.Queries;
using ConsoleApp.Models;

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
