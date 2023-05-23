using Application.Dtos;
using Application.IServices.AdminServices.ProoductServices.Queries;
using ConsoleApp.Models;

namespace Application.Services.AdminServices.ProoductServices.Queries
{
    public class GetProductByBoothIdService : IGetProductByBoothIdService
    {
        public GeneralDto<ProductDto> Execute(int id)
        {
            throw new NotImplementedException();
        }
    }
}
