using ConsoleApp1.Models;
using Domin.IRepositories.Dtos.Comment;

namespace Domin.IRepositories.IseparationRepository.SqlServer;

public interface ICommentRepository
{
    Task<Comment> GetByIdAsync(int id);
    Task<List<CommentGetDto>> GetByProductIdAsync(int productId);
    Task<List<Comment>> GetAllAsync();
    Task<int> AddAsync(CommentAddDto comment);
    Task UpdateAsync(Comment comment);
    Task DeleteAsync(Comment comment);
    Task<List<Comment>> GetAllCommentsWithSellerNameConfirmAsync();
}