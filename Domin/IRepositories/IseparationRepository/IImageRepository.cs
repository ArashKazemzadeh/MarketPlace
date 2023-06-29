using ConsoleApp1.Models;
using Domin.IRepositories.Dtos;

namespace Domin.IRepositories.IseparationRepository;

public interface IImageRepository
{
    Task<Image> GetByIdAsync(int imageId);
    Task<IEnumerable<Image>> GetImagesForProductAsync(int productId);
    Task AddAsync(ImageForProductRepDto image);
    Task<bool> RemoveAsync(int id);
    Task<Image> GetByUrlAsync(string url);
    Task<bool> RemoveAsync(string url);

}
