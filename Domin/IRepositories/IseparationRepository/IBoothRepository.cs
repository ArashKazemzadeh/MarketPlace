using ConsoleApp1.Models;

namespace Domin.IRepositories.IseparationRepository;

public interface IBoothRepository
{
    Task<Booth> GetByIdAsync(int id);
    Task<List<Booth>> GetAllAsync();
    Task AddAsync(Booth booth);
    Task UpdateAsync(Booth booth);
    Task DeleteAsync(Booth booth);
}