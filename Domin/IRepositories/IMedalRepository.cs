using ConsoleApp1.Models;

namespace Persistence.Repositories.Optionals;

public interface IMedalRepository
{
    Task<Medal> GetByIdAsync(int id);
    Task<List<Medal>> GetAllAsync();
    Task AddAsync(Medal medal);
    Task UpdateAsync(Medal medal);
    Task DeleteAsync(Medal medal);
}