using ConsoleApp1.Models;

namespace Domin.IRepositories.IseparationRepository;

public interface IProductsCartRepository
{
    Task<ProductsCart> GetByIdAsync(int id);
    Task<List<ProductsCart>> GetAllAsync();
    Task AddAsync(ProductsCart productsCart);
    Task UpdateAsync(ProductsCart productsCart);
    Task DeleteAsync(ProductsCart productsCart);
}