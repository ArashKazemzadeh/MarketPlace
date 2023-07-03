using ConsoleApp1.Models;
using Domin.IRepositories.Dtos.Cart;
namespace Domin.IRepositories.IseparationRepository.SqlServer;



public interface IProductsCartRepository
{
    Task AddProductToOldCartAsync(int cartId, int productId);
    Task<ProductsCart> GetByIdAsync(int id);
    Task<List<ProductsCart>> GetAllAsync();
    Task AddAsync(ProductsCartDto dto);
    Task UpdateAsync(ProductsCart productsCart);
    Task DeleteAsync(ProductsCart productsCart);
}