using Application.Dtos;
using Application.IServices.SellerServices.ImageServices.Commands;
using ConsoleApp.Models;

namespace Application.Services.SellerServices.ImageServices.Commands
{
    internal class AddImageForProductService : IAddImageForProductService
    {
        public GeneralDto<ImageForProductDto> Execute(ImageForProductDto imagedto, int productId)
        {
            throw new NotImplementedException();
        }
    }
}
