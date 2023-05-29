using ConsoleApp.Models;

namespace Application.IServices.AdminServices.ConfirmServices
{
    public interface IGeAllCommentsByFalseConFirmService
    {
        Task<List<CommentDto>> Execute();
    }
}
