using Application.Dtos;
using Application.IServices.AdminServices.ConfirmServices;
using ConsoleApp.Models;
using Domin.IRepositories.IseparationRepository;

namespace Application.Services.AdminServices.ConfirmServices
{
    public class ConfirmForAddCommentService : IConfirmForAddCommentService
    {
        private readonly ICommentRepository _commentRepository;

        public ConfirmForAddCommentService(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }
        public GeneralDto Execute(int id)
        {
           var comment= _commentRepository.GetByIdAsync(id);
           if (comment.Result==null)
           {
               return new GeneralDto
               {
                   message = "این کامنت موجود نیست احتمالا خطایی هنگام ثبت به وسیله ی خریدار رخ داده است"
               };
           }

           if (comment.Result.IsConfirm==null || comment.Result.IsConfirm==false)
           {
               comment.Result.IsConfirm = true;
               return new GeneralDto
               {
                   message = "تایید کامنت انجام شد."
               };
            }
           else
           {
               comment.Result.IsConfirm = false;
               return new GeneralDto
               {
                   message = "عدم تایید کامنت انجام شد."
               };
            }
           
        }
    }
}
