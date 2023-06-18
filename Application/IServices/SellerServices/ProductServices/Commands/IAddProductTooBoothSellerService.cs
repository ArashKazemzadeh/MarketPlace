using Application.Dtos.ProductDto;

namespace Application.IServices.SellerServices.ProductServices.Commands
{
    public interface IAddProductTooBoothSellerService
    {
        Task<int> Execute(ProductForAddDto productDto, int sellerId);
    }
}
