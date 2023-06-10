using Application.Dtos;

namespace Application.IServices.SellerServices.ProductServices.Commands
{
    public interface IDeleteProductSellerService
    {
       Task< GeneralDto> Execute(int id);

    }
}
