using ConsoleApp1.Models;
namespace Domin.IRepositories.IseparationRepository;

public interface IProductRepository
{
    Task<List<Product>> GetProductsWithSellerNameConfirmAsync();
    Task<Product> GetByIdAsync(int id);
    Task<List<Product>> GetAllAsync();
    Task AddAsync(Product product);
    Task UpdateAsync(Product product);
    Task DeleteAsync(Product product);
}