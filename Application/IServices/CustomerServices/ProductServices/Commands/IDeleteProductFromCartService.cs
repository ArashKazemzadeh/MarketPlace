using Application.Dtos;

namespace Application.IServices.CustomerServices.ProductServices.Commands
{
    public interface IDeleteProductFromCartService
    {
        GeneralDto Execute(int id);

    }
}
