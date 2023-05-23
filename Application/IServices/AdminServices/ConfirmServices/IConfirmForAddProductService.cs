using Application.Dtos;
using ConsoleApp.Models;

namespace Application.IServices.AdminServices.ConfirmServices
{
    public interface IConfirmForAddProductService
    {
        GeneralDto<ProductDto> Execute(int id);

    }
}
