using Application.Dtos.CategoryDto;

namespace Application.IServices.SellerServices.CategoryService;

public interface IGetCategoryServices
{
    Task<CategoryDto> GetById(int categoryId);
    Task<List<CategoryDto>> GetAll();
}