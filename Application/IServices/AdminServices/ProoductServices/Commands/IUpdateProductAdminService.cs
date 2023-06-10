
using Application.Dtos;
using Application.Dtos.ProductDto;

namespace Application.IServices.AdminServices.ProoductServices.Commands
{
    public interface IUpdateProductAdminService
    {
       Task<GeneralDto> Execute(ProductDto product);

    }
}
