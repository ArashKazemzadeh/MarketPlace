using Domin.IRepositories.Dtos;

namespace Application.IServices.CustomerServices.CommentServices.Queries;

public interface ICommentQueryService
{
    Task<List<CommentGetDto>> GetCommentByProductId(int productId);
}