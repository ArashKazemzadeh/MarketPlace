using ConsoleApp.Models;

namespace Application.IServices.AdminServices.ConfirmServices
{
    public interface IGeAllCommentsConFirmService
    {
        Task<List<CommentDto>> Execute();
    }
}
