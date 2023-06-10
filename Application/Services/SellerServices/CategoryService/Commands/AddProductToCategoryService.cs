

using Application.IServices.SellerServices.CategoryService;
using Domin.IRepositories.IseparationRepository;

namespace Application.Services.SellerServices.CategoryService.Commands
{
    public class AddProductToCategoryService : IAddProductToCategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductRepository _productRepository;

        public AddProductToCategoryService(ICategoryRepository categoryRepository,
            IProductRepository productRepository)
        {
            _categoryRepository = categoryRepository;
            _productRepository = productRepository; 
        }
        public async Task<string> Execute(int productId, int categoryId)
        {
            var product = await _productRepository.GetByIdAsync(productId);
            var category = await _categoryRepository.GetByIdOrginalAsync(categoryId);
            if (product == null)
            {
                return "محصول مورد نظر یافت نشد.";
            }
            if (category == null)
            {
                return "دسته بندی مورد نظر یافت نشد.";
            }
            await _categoryRepository.AddProductToCategoryAsync(category, product);
            return "محصول با موفقیت به دسته بندی اضافه شد.";
        }
    }
    
}
