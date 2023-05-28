using ConsoleApp1.Models;

namespace Domin.IRepositories.IseparationRepository;

public interface ICategoryRepository
{
    Task<Category> GetByIdAsync(int id);
    Task<List<Category>> GetAllAsync();
    Task AddAsync(Category category);
    Task UpdateAsync(Category category);
    Task DeleteAsync(Category category);
}