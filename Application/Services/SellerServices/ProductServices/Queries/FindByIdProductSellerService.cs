using Application.Dtos;
using Application.IServices.SellerServices.ProductServices.Queries;
using ConsoleApp.Models;

namespace Application.Services.SellerServices.ProductServices.Queries
{
    internal class FindByIdProductSellerService : IFindByIdProductSellerService
    {
        public GeneralDto<ProductDto> Execute(int id)
        {
            throw new NotImplementedException();
        }
    }
}
