using Application.Dtos;
using Application.IServices.SellerServices.ProductServices.Queries;
using ConsoleApp.Models;

namespace Application.Services.SellerServices.ProductServices.Queries
{
    internal class GetAllProductSellerService : IGetAllProductSellerService
    {
        public List<GeneralDto<ProductDto>> Execute(int sellerId)
        {
            throw new NotImplementedException();
        }
    }
}
