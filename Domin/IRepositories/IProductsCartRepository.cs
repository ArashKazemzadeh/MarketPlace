using ConsoleApp1.Models;

namespace Persistence.Repositories.Orders;

public interface IProductsCartRepository
{
    Task<ProductsCart> GetByIdAsync(int id);
    Task<List<ProductsCart>> GetAllAsync();
    Task AddAsync(ProductsCart productsCart);
    Task UpdateAsync(ProductsCart productsCart);
    Task DeleteAsync(ProductsCart productsCart);
}