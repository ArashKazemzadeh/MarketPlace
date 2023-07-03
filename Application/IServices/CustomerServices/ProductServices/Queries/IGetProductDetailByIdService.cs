using Application.Dtos;
using Domin.IRepositories.Dtos.Product;

namespace Application.IServices.CustomerServices.ProductServices.Queries;

public interface IGetProductDetailByIdService
{
    Task<GeneralDto<ProductDto>> Execute(int productId);
}