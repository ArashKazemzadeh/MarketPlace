using Application.Dtos.CategoryDto;

namespace Application.IServices.CustomerServices.CategoryServices;

public interface ICategoryCustomerQueryService
{
    Task<List<CategoryDto>> GetAllCategory();
}