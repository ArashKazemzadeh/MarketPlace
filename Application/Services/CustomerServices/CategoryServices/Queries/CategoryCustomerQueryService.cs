using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Dtos.CategoryDto;
using Application.IServices.CustomerServices.CategoryServices;
using ConsoleApp.Models;
using Domin.IRepositories.IseparationRepository;

namespace Application.Services.CustomerServices.CategoryServices.Queries
{
    public class CategoryCustomerQueryService: ICategoryCustomerQueryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryCustomerQueryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;   
        }

        public async Task<List<CategoryDto>> GetAllCategory()
        {
            var dto = await _categoryRepository.GetAllAsync();
            if (dto==null || dto.Count()==0)
            {
                return new List<CategoryDto>();
            }
            var result = dto.Select(c => new CategoryDto
            {
                Id = c.Id,
                Name = c.Name,
                Description = c.Description,
            }).ToList();
            return result;
        }
    }
}
