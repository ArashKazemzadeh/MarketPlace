using Application.Dtos;
using Application.Dtos.ProductDto;
using Application.IServices.AdminServices.ProoductServices.Queries;
using Domin.IRepositories.IseparationRepository;
using System.Xml.Linq;

namespace Application.Services.AdminServices.ProoductServices.Queries;
public class GetProductByIdService : IGetProductByIdService
{
    private readonly IProductRepository _productRepository;
  
    public GetProductByIdService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
 

    }
    public async Task<GeneralDto<ProductDto>> Execute(int id)
    {
        var product = await _productRepository.GetByIdAsync(id);
        if (product == null)
            return new GeneralDto<ProductDto>
            {
                message = "کالا یافت نشد"
            };

        return new GeneralDto<ProductDto>
        {
            Data = new ProductDto
            {
                Id = id,
                Name = product.Name,
                Availability = product.Availability,
                BasePrice = product.BasePrice,
                Description = product.Description,
                IsAuction = product.IsAuction,
                IsConfirm = product.IsConfirm,
                IsActive = product.IsActive

            }

        };
    }
}


