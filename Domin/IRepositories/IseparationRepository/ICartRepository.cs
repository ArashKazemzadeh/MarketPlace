using ConsoleApp1.Models;
using Domin.IRepositories.Dtos;

namespace Domin.IRepositories.IseparationRepository;

public interface ICartRepository
{
    Task<List<CartGetDto>> GetfinalizedCartsByCustomerId(int customerId);
    Task<List<CartGetDto>> GetUnfinalizedCartsByCustomerId(int customerId);
    Task<bool> FinalizeCartAsync(int cartId);
    Task<Cart> GetByIdAsync(int id);
    Task<List<Cart>> GetAllAsync();
    Task AddAsync(Cart cart);
    Task UpdateAsync(Cart cart);
    Task DeleteAsync(Cart cart);
}