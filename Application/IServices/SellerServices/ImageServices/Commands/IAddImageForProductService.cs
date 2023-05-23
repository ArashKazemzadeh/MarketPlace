using Application.Dtos;
using ConsoleApp.Models;


namespace Application.IServices.SellerServices.ImageServices.Commands
{
    public interface IAddImageForProductService
    {
        GeneralDto<ImageForProductDto> Execute(ImageForProductDto imagedto,int productId);

    }
}
