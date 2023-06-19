namespace Application.IServices.CustomerServices.CartService.Commands;



public interface ICartCommandService
{
    Task<bool> AddProductToCart(int customerId, int productId, int boothId);
    Task<bool> FinalizeCartAsync(int cartId);
}