using Application.Dtos;
using Application.IServices.AdminServices.ConfirmServices;
using Domin.IRepositories.IseparationRepository;

namespace Application.Services.AdminServices.CommentService.Command
{
    public class ConfirmForAddCommentService : IConfirmForAddCommentService
    {
        private readonly ICommentRepository _commentRepository;

        public ConfirmForAddCommentService(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }
        public async Task<GeneralDto> Execute(int id)
        {
            var comment =await _commentRepository.GetByIdAsync(id);
            if (comment == null)
            {
                return new GeneralDto
                {
                    message = "این کامنت موجود نیست احتمالا خطایی هنگام ثبت به وسیله ی خریدار رخ داده است"
                };
            }

            if (comment.IsConfirm == null || comment.IsConfirm == false)
            {
                comment.IsConfirm = true;
                return new GeneralDto
                {
                    message = "تایید کامنت انجام شد."
                };
            }
            else
            {
                comment.IsConfirm = false;
                return new GeneralDto
                {
                    message = "عدم تایید کامنت انجام شد."
                };
            }

        }
    }
}
