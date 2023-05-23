

using Application.Dtos;
using ConsoleApp.Models;

namespace Application.IServices.AdminServices.ProoductServices.Queries
{
    public interface IGetProductByBoothIdService
    {
        GeneralDto<ProductDto> Execute(int id);

    }
}
