﻿using ConsoleApp1.Models;
using Domin.IRepositories.Dtos.Category;

namespace Domin.IRepositories.IseparationRepository.SqlServer;

public interface ICategoryRepository
{
    Task AddProductToCategoryAsync(int productId, int categoryId);
    Task DeleteProductFromCategoryAsync(Category category, Product product);
    Task<Category> GetByIdOrginalAsync(int id);
    Task<CategoryRepDto> GetByIdAsync(int id);
    Task<List<Category>> GetAllAsync();
    Task AddAsync(Category category);
    Task UpdateAsync(Category category);
    Task DeleteAsync(Category category);
}