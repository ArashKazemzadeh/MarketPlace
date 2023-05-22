using ConsoleApp1.Models;

namespace Persistence.Repositories.Optionals;

public interface IImageForProductRepository
{
    Task<ImageForProduct> GetByIdAsync(int id);
    Task<List<ImageForProduct>> GetAllAsync();
    Task AddAsync(ImageForProduct imageForProduct);
    Task UpdateAsync(ImageForProduct imageForProduct);
    Task DeleteAsync(ImageForProduct imageForProduct);
}