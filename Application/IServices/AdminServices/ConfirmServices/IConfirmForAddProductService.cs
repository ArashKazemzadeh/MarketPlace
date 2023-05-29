using Application.Dtos;
using ConsoleApp.Models;

namespace Application.IServices.AdminServices.ConfirmServices
{   
    /// <summary>
    /// کالاهای تایید نشده یا در انتظار تایید را تایید می کند
    /// </summary>
    public interface IConfirmForAddProductService
    {
        Task<GeneralDto> Execute(int id);

    }
}
