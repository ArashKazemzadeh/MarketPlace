using Application.Dtos;
using Application.Dtos.ProductDto;
using Application.IServices.AdminServices.ProoductServices.Commands;
using ConsoleApp1.Models;
using Domin.IRepositories.IseparationRepository.SqlServer;

namespace Application.Services.AdminServices.ProoductServices.Commands
{
    public class UpdateProductAdminService : IUpdateProductAdminService
    {
        private readonly IProductRepository _productRepository;
        public UpdateProductAdminService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
          
        }

        public async Task<GeneralDto> Execute(ProductDto product)
        {
            var existingProduct = await _productRepository.GetByIdAsync(product.Id);
            if (existingProduct == null)
                return new GeneralDto
                {
                    message = "کالا موجود نیست"
                };

            var result = new Domin.IRepositories.Dtos.ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                BasePrice = product.BasePrice,
                IsAuction = product.IsActive,
                Availability = product.Availability,
                Description = product.Description,
                IsActive = product.IsActive
            };
            await _productRepository.UpdateAsync(result);
          

            return new GeneralDto
            {
                message = "به روز رسانی انجام شد."
            };
        }
    }


}
