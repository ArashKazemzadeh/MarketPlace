using Application.Dtos;
using Application.Dtos.ProductDto;


namespace Application.IServices.CustomerServices.ProductServices.Commands
{
    public interface IAddProductToCartService
    {
        GeneralDto<ProductDto> Execute(ProductDto productDto);

    }
}
