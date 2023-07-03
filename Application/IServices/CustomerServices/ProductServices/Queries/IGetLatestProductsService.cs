using Domin.IRepositories.Dtos.Product;

namespace Application.IServices.CustomerServices.ProductServices.Queries;

public interface IGetLatestProductsService
{
    Task<List<ProductGetDto>> Execute();
}