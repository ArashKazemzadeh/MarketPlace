using Application.Dtos;
using Application.IServices.SellerServices.ProductServices.Commands;
using ConsoleApp.Models;

namespace Application.Services.SellerServices.ProductServices.Commands
{
    internal class DeleteProductSellerService : IDeleteProductSellerService
    {
        public GeneralDto Execute(ProductDto productDto, int boothId)
        {
            throw new NotImplementedException();
        }
    }
}
