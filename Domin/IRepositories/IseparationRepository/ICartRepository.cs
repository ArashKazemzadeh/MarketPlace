using ConsoleApp1.Models;
using Domin.IRepositories.Dtos;
using Domin.IRepositories.Dtos.Cart;

namespace Domin.IRepositories.IseparationRepository;

public interface ICartRepository
{

    Task<List<CartGetDto>> GetfinalizedCartsByCustomerId(int customerId);
    Task<List<CartGetDto>> GetUnfinalizedCartsByCustomerId(int customerId);
    Task<List<ProductDto>> GetProductByCartId(int cartId);
    Task<bool> FinalizeCartAsync(int cartId);//
    Task<List<Cart>> GetOpenCartsForCustomerIdByBoothIdAsync(int boothId, int cudtomerId);
    Task<Cart> GetByIdAsync(int id);
    Task<List<Cart>> GetAllAsync();
    Task<CartAddDto> AddAsync(CartAddDto dto);
    Task UpdateAsync(Cart cart);
    Task DeleteAsync(Cart cart);
}

