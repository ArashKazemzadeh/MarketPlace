using Application.Dtos;
using Application.IServices.AdminServices.ProoductServices.Commands;
using Domin.IRepositories.IseparationRepository;

namespace Application.Services.AdminServices.ProoductServices.Commands
{
    public class DeleteProductAdminService : IDeleteProductAdminService
    {
        private readonly IProductRepository _productRepository;

        public DeleteProductAdminService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<GeneralDto> Execute(int id)
        {
            var existingProduct = await _productRepository.GetByIdAsync(id);
            if (existingProduct == null)
                return new GeneralDto { message = "محصول مورد نظر یافت نشد." };

            await _productRepository.DeleteAsync(id);
            return new GeneralDto { message = "محصول با موفقیت حذف شد." };
        }
    }

}
