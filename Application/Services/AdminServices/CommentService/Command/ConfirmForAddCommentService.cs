using Application.Dtos;
using Application.IServices.AdminServices.ConfirmServices;
using Domin.IRepositories.IseparationRepository.SqlServer;

namespace Application.Services.AdminServices.CommentService.Command
{
    public class ConfirmForAddCommentService : IConfirmForAddCommentService
    {
        private readonly ICommentRepository _commentRepository;

        public ConfirmForAddCommentService(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<GeneralDto> ExecuteFalse(int id)
        {
            var comment = await _commentRepository.GetByIdAsync(id);
            if (comment == null)
            {
                return new GeneralDto
                {
                    message = "این کامنت موجود نیست احتمالا خطایی هنگام ثبت  رخ داده است"
                };
            }

            if (comment.IsConfirm == null)
            {
                comment.IsConfirm = false;
                await _commentRepository.UpdateAsync(comment);
                return new GeneralDto
                {
                    message = "رد کردن کامنت انجام شد."
                };
            }

            return new GeneralDto
            {
                message = "عملیات با مشکل مواجه شد."
            };
        }

        public async Task<GeneralDto> ExecuteTrue(int id)
        {
            var comment = await _commentRepository.GetByIdAsync(id);
            if (comment == null)
            {
                return new GeneralDto
                {
                    message = "این کامنت موجود نیست احتمالا خطایی هنگام ثبت  رخ داده است"
                };
            }

            if (comment.IsConfirm == null)
            {
                comment.IsConfirm = true;
                await _commentRepository.UpdateAsync(comment);
                return new GeneralDto
                {
                    message = "تایید کامنت انجام شد."
                };
            }
            return new GeneralDto
            {
                message = "عملیات با مشکل مواجه شد."
            };
        }

    }
}
