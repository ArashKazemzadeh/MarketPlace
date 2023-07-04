
using ConsoleApp1.Models;
using Domin.IRepositories.Dtos.Cart;

namespace Domin.IRepositories.IseparationRepository.SqlServer;

public interface ICartRepository
{
    Task<List<ProductInCartRepDto>> GetProductsOpenCartByCartIdAsync(int cartId);
    Task<string> DeleteOpenCartAsync(int customerId, int cartId);
    Task<int> GetTotalPrices(int cartId);
    Task<List<CartGetDto>> GetfinalizedCartsByCustomerId(int customerId);
    Task<List<CartGetDto>> GetUnfinalizedCartsByCustomerId(int customerId);
    Task<List<ProductInCartRepDto>> GetProductsByCartIdAsync(int cartId);
    Task<bool> FinalizeCartAsync(int cartId);//
    Task<List<Cart>> GetOpenCartsForCustomerIdByBoothIdAsync(int boothId, int cudtomerId);
    Task<Cart> GetByIdAsync(int id);
    Task<List<Cart>> GetAllAsync();
    Task<CartAddDto> AddAsync(CartAddDto dto);
    Task UpdateAsync(Cart cart);
    Task DeleteAsync(Cart cart);
}

