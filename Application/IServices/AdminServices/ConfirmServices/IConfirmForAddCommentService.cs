using ConsoleApp.Models;

using Application.Dtos;

namespace Application.IServices.AdminServices.ConfirmServices
{
    public interface IConfirmForAddCommentService
    {
        Task<GeneralDto> ExecuteTrue(int id);
        Task<GeneralDto> ExecuteFalse(int id);
    }
}
