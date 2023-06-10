using ConsoleApp1.Models;
using Domin.IRepositories.Dtos;

namespace Domin.IRepositories.IseparationRepository;

public interface IProductRepository
{
    Task<List<Product>> GetProductsWithSellerNameConfirmAsync();
    Task<List<ProductDto>> GetAllWithNavigationsAsync(int sellerId);
    Task<ProductDto> GetWithAllNavigationsByIdSellerAsync(int id);
    Task<Product> GetByIdAsync(int id);
    Task<List<Product>> GetAllAsync();
    Task AddAsync(ProductAddDto product);
    Task UpdateAsync(ProductDto product);
    Task DeleteAsync(int id);
    Task UpdateAsync(Product product);
}