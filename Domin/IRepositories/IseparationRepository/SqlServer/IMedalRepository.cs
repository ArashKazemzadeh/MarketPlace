using ConsoleApp1.Models;
using Domin.Enums;

namespace Domin.IRepositories.IseparationRepository.SqlServer;

public interface IMedalRepository
{
    Task<Medal> GetByIdAsync(int id);
    Task<List<Medal>> GetAllAsync();
    Task AddAsync(Medal medal);
    Task UpdateAsync(Medal medal);
    Task DeleteAsync(Medal medal);
    Task<Medal> GetMedalByTypeAsync(MedalEnum medalType);
}