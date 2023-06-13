using ConsoleApp1.Models;
using Domin.IRepositories.Dtos;

namespace Domin.IRepositories.IseparationRepository;

public interface IImageForProductRepository
{
    Task<ImageForProduct> GetByIdAsync(int imageId);
    Task<IEnumerable<ImageForProduct>> GetImagesForProductAsync(int productId);
    Task AddAsync(ImageForProductRepDto image);
    Task<bool> RemoveAsync(int id);
    Task<ImageForProduct> GetByUrlAsync(string url);
    Task<bool> RemoveAsync(string url);

}
