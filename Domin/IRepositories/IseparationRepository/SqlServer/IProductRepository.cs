using ConsoleApp1.Models;
using Domin.IRepositories.Dtos.Auction;
using Domin.IRepositories.Dtos.Product;

namespace Domin.IRepositories.IseparationRepository.SqlServer;

public interface IProductRepository
{
   
    Task<string> RemoveFromCartByProductId(int productId, int customerId);
    Task<List<ProductGetDto>> GetAllProductsForView();
    Task UpdateAsync(ProductDto productDto, List<int> categoryIds);
    Task<List<ProductCustomerDto>> GetProductByBoothIdAsync(int boothId);
    Task<List<AuctionProductDto>> GetProductsWithTrueAuctions(int sellerId);
    Task<List<Product>> GetProductsWithSellerNameConfirmAsync();
    Task<List<ProductDto>> GetAllWithNavigationsAsync(int? boothId);
    Task<ProductDto> GetWithAllNavigationsByIdSellerAsync(int id);
    Task<Product> GetByIdAsync(int id);
    Task<List<Product>> GetAllAsync();
    Task<int> AddAsync(ProductAddDto product);
    Task UpdateAsync(ProductDto product);
    Task DeleteAsync(int id);
    Task UpdateAsync(Product product);
}