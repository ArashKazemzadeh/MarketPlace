using ConsoleApp1.Models;

namespace Persistence.Repositories.Optionals;

public interface ICommentRepository
{
    Task<Comment> GetByIdAsync(int id);
    Task<List<Comment>> GetAllAsync();
    Task AddAsync(Comment comment);
    Task UpdateAsync(Comment comment);
    Task DeleteAsync(Comment comment);
}