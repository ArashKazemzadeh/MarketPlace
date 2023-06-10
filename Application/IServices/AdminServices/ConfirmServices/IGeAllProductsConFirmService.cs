using Application.Dtos.ProductDto;

namespace Application.IServices.AdminServices.ConfirmServices
{

    public interface IGeAllProductsByFalseConFirmService
    {
        Task<List<ProductDto>> Execute();
    }
}
