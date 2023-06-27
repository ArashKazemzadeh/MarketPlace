namespace Application.IServices.CustomerServices.CartService.Commands;



public interface ICartCommandService
{
    Task<string> AddProductToCart(int customerId, int productId, int boothId);
    Task<bool> FinalizeCartAsync(int cartId);
}