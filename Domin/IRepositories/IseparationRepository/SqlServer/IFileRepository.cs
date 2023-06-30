using ConsoleApp1.Models;
using Domin.IRepositories.Dtos.File;

namespace Domin.IRepositories.IseparationRepository.SqlServer;

public interface IFileRepository
{

    Task<FileGetDto> GetByIdAsync(int id);
    Task<List<ConsoleApp1.Models.File>> GetAllAsync();
    Task<int> AddAsync(FileAddDto fileDto, int ownerFileId);
    Task<List<FileGetDto>> GetAllByOwnerFileIdAsync(int ownerFileId);
    Task UpdateAsync(ConsoleApp1.Models.File fileForUser);
    Task<bool> DeleteAsync(FileGetDto dto);
}