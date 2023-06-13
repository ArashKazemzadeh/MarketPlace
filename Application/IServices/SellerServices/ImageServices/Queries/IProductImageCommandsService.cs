namespace Application.IServices.SellerServices.ImageServices.Queries;

public interface IProductImageCommandsService
{
    Task<string> AddImageToProduct(int productId, string imageUrl);
    Task<string> DeleteImageFromProduct(int id);
    Task<string> DeleteImageFromProduct(string url);
}