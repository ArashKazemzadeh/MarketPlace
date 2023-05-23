using Application.Dtos;
using ConsoleApp.Models;


namespace Application.IServices.SellerServices.ProductServices.Queries
{
    public interface IGetAllProductSellerService
    {
       List<GeneralDto<ProductDto>>  Execute( int sellerId);

    }
}
