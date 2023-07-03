using ConsoleApp1.Models;
using Domin.IRepositories.Dtos.Booth;

namespace Domin.IRepositories.IseparationRepository.SqlServer;

public interface IBoothRepository
{
    Task<List<Booth>> GetByCategoryIdAsync(int categoryId);
    Task<Booth> GetByIdAsync(int id);
    Task<List<BoothRepositoryDto>> GetAllAsync();
    Task AddAsync(BoothRepDto booth);
    Task<bool> UpdateBoothAsync(BoothRepDto boothRepDto);
    Task DeleteAsync(Booth booth);
}