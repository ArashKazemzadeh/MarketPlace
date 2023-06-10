using Application.Dtos;
using Application.Dtos.ProductDto;
using Application.IServices.CustomerServices.ProductServices.Commands;

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
