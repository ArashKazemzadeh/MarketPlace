using Domin.IRepositories.Dtos.Cart;
using Domin.IRepositories.Dtos;
namespace Application.IServices.CustomerServices.CartService.Queries;

public interface ICartQueryService
{
    Task<List<CartGetDto>> GetUnfinalizedCartsByCustomerId(int customerId);
    Task<List<CartGetDto>> GetfinalizedCartsByCustomerId(int customerId);
    Task<List<ProductInCartRepDto>> GetProductByCartId(int cartId);
}