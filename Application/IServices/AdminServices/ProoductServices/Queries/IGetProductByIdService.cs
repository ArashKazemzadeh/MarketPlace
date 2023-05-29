using Application.Dtos;
using ConsoleApp.Models;



namespace Application.IServices.AdminServices.ProoductServices.Queries
{
    public interface IGetProductByIdService
    {
        Task<GeneralDto<ProductDto>> Execute(int id);
    }
}
