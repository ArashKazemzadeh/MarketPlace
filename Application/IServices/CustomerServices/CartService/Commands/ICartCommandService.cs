namespace Application.IServices.CustomerServices.CartService.Commands;



public interface ICartCommandService
{
    Task<string> AddProductToCart(int customerId, int productId, int boothId);
    Task<bool> FinalizeCartAsync(int cartId);
    Task<string> DeleteProductFromCart(string userId, int productId);
    Task<string> DeleteOpenCart(string userId, int cartId);
}