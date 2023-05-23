using Application.Dtos;
using ConsoleApp.Models;


namespace Application.IServices.CustomerServices.ProductServices.Commands
{
    public interface IAddProductToCartService
    {
        GeneralDto<ProductDto> Execute(ProductDto productDto);

    }
}
