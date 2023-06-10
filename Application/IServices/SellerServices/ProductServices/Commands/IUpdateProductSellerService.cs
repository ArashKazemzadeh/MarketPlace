using Application.Dtos;
using Application.Dtos.ProductDto;

namespace Application.IServices.SellerServices.ProductServices.Commands
{
    public interface IUpdateProductSellerService
    {
       Task<GeneralDto>  Execute(ProductForUpdateDto productDto);

    }
}
