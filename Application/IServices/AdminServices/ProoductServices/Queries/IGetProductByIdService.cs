using Application.Dtos;
using Application.Dtos.ProductDto;



namespace Application.IServices.AdminServices.ProoductServices.Queries
{
    public interface IGetProductByIdService
    {
        Task<GeneralDto<ProductDto>> Execute(int id);
    }
}
