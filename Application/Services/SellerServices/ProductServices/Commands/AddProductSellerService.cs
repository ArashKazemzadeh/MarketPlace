using Application.Dtos;
using Application.IServices.SellerServices.ProductServices.Commands;
using ConsoleApp.Models;

namespace Application.Services.SellerServices.ProductServices.Commands
{
    internal class AddProductSellerService : IAddProductSellerService
    {
        public GeneralDto<ProductDto> Execute(ProductDto productDto, int boothId)
        {
            throw new NotImplementedException();
        }
    }
}
