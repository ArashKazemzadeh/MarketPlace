using Application.Dtos.ProductDto;

namespace Application.IServices.SellerServices.ProductServices.Commands
{
    public interface IAddProductTooBoothSellerService
    {
        Task<string> Execute(ProductForAddDto productDto, int sellerId);
    }
}
