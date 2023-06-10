using Application.Dtos;
using Application.Dtos.ProductDto;

namespace Application.IServices.SellerServices.ProductServices.Queries;

public interface IGetProductSellerService
{
    Task<GeneralDto<ProductGeneralDto>> FindByIdAsync(int id);
    Task<GeneralDto<List<ProductGeneralDto>>> GetAllProductBySellerIdAsync(int sellerId);
}