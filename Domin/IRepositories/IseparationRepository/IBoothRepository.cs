using ConsoleApp1.Models;
using Domin.IRepositories.Dtos;

namespace Domin.IRepositories.IseparationRepository;

public interface IBoothRepository
{
    Task<Booth> GetByIdAsync(int id);
    Task<List<BoothRepositoryDto>> GetAllAsync();
    Task AddAsync(BoothRepDto booth);
    Task<bool> UpdateBoothAsync(BoothRepDto boothRepDto);
    Task DeleteAsync(Booth booth);
}