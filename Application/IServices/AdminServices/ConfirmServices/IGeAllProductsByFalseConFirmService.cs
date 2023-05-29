using ConsoleApp.Models;

namespace Application.IServices.AdminServices.ConfirmServices
{
    public interface IGeAllProductsByFalseConFirmService
    {
        Task<List<ProductDto>> Execute();
    }
}
