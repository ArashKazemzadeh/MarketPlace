using ConsoleApp1.Models;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts.SqlServer;
using Domin.IRepositories.IseparationRepository.SqlServer;
using Domin.IRepositories.Dtos.Category;

namespace Persistence.Repositories.SqlServer.Orders
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DatabaseContext _context;
        private readonly DbSet<Category> _dbSet;

        public CategoryRepository(DatabaseContext context)
        {
            _context = context;
            _dbSet = _context.Set<Category>();
        }

        public async Task<CategoryRepDto> GetByIdAsync(int id)
        {
            var product = await _dbSet.AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);
            return new CategoryRepDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Products = product.Products
            };

        }
        public async Task<Category> GetByIdOrginalAsync(int id)
        {
            var product = await _dbSet.AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);
            return product;

        }
        public async Task<List<Category>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task AddAsync(Category category)
        {
            await _dbSet.AddAsync(category);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Category category)
        {
            _context.Entry(category).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Category category)
        {
            _dbSet.Remove(category);
            await _context.SaveChangesAsync();
        }

        public async Task AddProductToCategoryAsync(int productId, int categoryId)
        {

            var trackedProduct = await _context.Products.FindAsync(productId);
            var trackedcaCategoryt = await _context.Categories.FindAsync(categoryId);
            trackedProduct.Categories.Add(trackedcaCategoryt);
            _context.Entry(trackedProduct).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }


        public async Task DeleteProductFromCategoryAsync(Category category, Product product)
        {
            category.Products.Remove(product);
            await _context.SaveChangesAsync();
        }
    }
}
