using Application.IServices.AdminServices.ConfirmServices;
using ConsoleApp.Models;
using Domin.IRepositories.IseparationRepository.SqlServer;

namespace Application.Services.AdminServices.CommentService.Query
{
    public class GeAllCommentsConFirmService : IGeAllCommentsConFirmService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IUserRepository _userRepository;

        public GeAllCommentsConFirmService(ICommentRepository commentRepository,
            IUserRepository userRepository)
        {
            _commentRepository = commentRepository;
            _userRepository = userRepository;
        }
        public async Task<List<CommentDto>> Execute()
        {
            var comments = await _commentRepository.GetAllCommentsWithSellerNameConfirmAsync();
            var customerIds = comments.Select(c => c.CustomertId).ToList();
            var users = await _userRepository.GetUsersByCustomerIdsAsync(customerIds);
            if (comments==null)
            {
                return new List<CommentDto>();
            }
            var commentDtos = comments.Select(p => new CommentDto
            {
                Id = p.Id,
                RegisterDate = p.RegisterDate,
                Title = p.Title,
                ProductName = p.Product != null ? p.Product.Name : "",
                Description = p.Description,
                SellerName = p.Product?.Booth?.Seller != null ? p.Product.Booth.Seller.CompanyName : "",
                CustomerName = users.FirstOrDefault(u => u.Id == p.CustomertId)?.FullName
            }).ToList();



            return commentDtos;
        }

    }

}
