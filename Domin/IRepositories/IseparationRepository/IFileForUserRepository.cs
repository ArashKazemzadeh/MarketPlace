using ConsoleApp1.Models;

namespace Domin.IRepositories.IseparationRepository;

public interface IFileForUserRepository
{
    Task<FileForUser> GetByIdAsync(int id);
    Task<List<FileForUser>> GetAllAsync();
    Task AddAsync(FileForUser fileForUser);
    Task UpdateAsync(FileForUser fileForUser);
    Task DeleteAsync(FileForUser fileForUser);
}