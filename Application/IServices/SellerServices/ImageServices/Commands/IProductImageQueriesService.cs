using ConsoleApp1.Models;

namespace Application.IServices.SellerServices.ImageServices.Commands;

public interface IProductImageQueriesService
{
    Task<ImageForProduct> GetImageByIdAsync(int imageId);
    Task<IEnumerable<ImageForProduct>> GetImagesForProductAsync(int productId);
}