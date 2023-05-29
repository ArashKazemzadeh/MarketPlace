using Application.IServices.AdminServices.ConfirmServices;
using ConsoleApp.Models;
using AutoMapper;
using Domin.IRepositories.IseparationRepository;
using ConsoleApp1.Models;

namespace Application.Services.AdminServices.CommentService.Query
{
    public class GeAllCommentsByFalseConFirmService : IGeAllCommentsByFalseConFirmService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;

        public GeAllCommentsByFalseConFirmService(ICommentRepository commentRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }
        public async Task<List<CommentDto>> Execute()
        {
            var comments = await _commentRepository.GetAllCommentsWithSellerNameConfirmAsync();
            var commentDtos = comments.Select(p => new CommentDto
            {
                Id = p.Id,
                RegisterDate = p.RegisterDate,
                Title = p.Title,
                ProductId = p.ProductId,
                CustomertId = p.CustomertId,
                Description = p.Description,
                SellerName = p.Product?.Booth?.Seller.CompanyName,
            }).ToList();
            return commentDtos;
        }
    }
}
