using Application.IServices.CustomerServices.CommentServices.Queries;
using Domin.IRepositories.Dtos;
using Domin.IRepositories.IseparationRepository.SqlServer;

namespace Application.Services.CustomerServices.CommentServices.Queries;





public class CommentQueryService: ICommentQueryService
{
      private readonly ICommentRepository _commentRepository;
        public CommentQueryService(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }
        public async Task<List<CommentGetDto>> GetCommentByProductId(int productId)
        {
            var result = await _commentRepository.GetByProductIdAsync(productId);
            if (result==null)
                return new List<CommentGetDto>();
            return result;
        }
}

