namespace Application.IServices.CustomerServices.CartService.Commands;

public interface ICartCommandService
{
    Task<bool> FinalizeCartAsync(int cartId);
}