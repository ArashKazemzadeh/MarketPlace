using Application.Dtos;
using Application.IServices.AdminServices.ProoductServices.Queries;
using AutoMapper;
using ConsoleApp.Models;
using Domin.IRepositories.IseparationRepository;
namespace Application.Services.AdminServices.ProoductServices.Queries;
public class GetProductByIdService : IGetProductByIdService
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;
    public GetProductByIdService(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }
    public async Task<GeneralDto<ProductDto>> Execute(int id)
    {
        var product = await _productRepository.GetByIdAsync(id);
        if (product == null)
            return new GeneralDto<ProductDto>
            {
                message = "کالا یافت نشد"
            };
        var productDto = _mapper.Map<ProductDto>(product);
        return new GeneralDto<ProductDto>
        {
            Data = productDto
        };
    }
}









