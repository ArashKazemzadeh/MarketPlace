

using Application.Dtos;
using ConsoleApp.Models;

namespace Application.IServices.SellerServices.ProductServices.Queries
{
    public interface IFindByIdProductSellerService
    {
        GeneralDto<ProductDto> Execute( int id);

    }
}
