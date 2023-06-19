using Domin.IRepositories.Dtos.Cart;

namespace Application.IServices.CustomerServices.CartService.Queries;

public interface ICartQueryService
{
    Task<List<CartGetDto>> GetUnfinalizedCartsByCustomerId(int customerId);
    Task<List<CartGetDto>> GetfinalizedCartsByCustomerId(int customerId);
}