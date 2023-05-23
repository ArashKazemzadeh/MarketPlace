using Application.Dtos;
using Application.IServices.CustomerServices.ProductServices.Commands;
using ConsoleApp.Models;

namespace Application.Services.CustomerServices.ProductServices.Commands
{
    internal class AddProductToCartService : IAddProductToCartService
    {
        public GeneralDto<ProductDto> Execute(ProductDto productDto)
        {
            throw new NotImplementedException();
        }
    }
}
