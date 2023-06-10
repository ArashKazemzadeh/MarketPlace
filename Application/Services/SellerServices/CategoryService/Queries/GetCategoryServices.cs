using Application.Dtos.CategoryDto;
using Application.IServices.SellerServices.CategoryService;
using Domin.IRepositories.IseparationRepository;

namespace Application.Services.SellerServices.CategoryService.Queries;

public class GetCategoryServices : IGetCategoryServices
{
    private readonly ICategoryRepository _categoryRepository;

    public GetCategoryServices(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;   
    }
    public async Task<List<CategoryDto>> GetAll()
    {
        var products = await _categoryRepository.GetAllAsync();
        return products.Select(c => new CategoryDto
        {
            Id = c.Id,
            Name = c.Name,
            Description = c.Description
        }).ToList();

    }

    public async Task<CategoryDto> GetById(int categoryId)
    {
      var product=  await _categoryRepository.GetByIdAsync(categoryId);
      return new CategoryDto
      {
          Id = product.Id,
          Name = product.Name,
          Description = product.Description
      };
    }
}

