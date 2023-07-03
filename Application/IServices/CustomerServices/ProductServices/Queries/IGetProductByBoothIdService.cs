using Domin.IRepositories.Dtos.Product;

namespace Application.IServices.CustomerServices.ProductServices.Queries
{
    public interface IGetAllProductsByBoothIdService
    {
        Task<List<ProductCustomerDto>> Execute(int boothId);
    }
}
