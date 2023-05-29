
using Application.Dtos;
using ConsoleApp.Models;

namespace Application.IServices.AdminServices.ProoductServices.Commands
{
    public interface IUpdateProductAdminService
    {
       Task<GeneralDto> Execute(ProductDto product);

    }
}
