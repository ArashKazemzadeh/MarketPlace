using Application.Dtos;
using Application.Dtos.ProductDto;
using Application.IServices.SellerServices.ProductServices.Commands;
using Domin.IRepositories.IseparationRepository.SqlServer;
using ProductDto = Domin.IRepositories.Dtos.Product.ProductDto;

namespace Application.Services.SellerServices.ProductServices.Commands
{
    public class UpdateProductSellerService : IUpdateProductSellerService
    {
        private readonly IProductRepository _productRepository;
        private readonly ISellerRepository _sellerRepository;

        public UpdateProductSellerService(IProductRepository productRepository,
            ISellerRepository sellerRepository)
        {
            _productRepository = productRepository;
            _sellerRepository = sellerRepository;
        }

        public async Task<GeneralDto> Execute(ProductForUpdateDto productUpdateDto)
        {
            var product = await _productRepository.GetByIdAsync(productUpdateDto.Id);
            if (product == null)
                return new GeneralDto { message = "کالا یافت نشد" };
            if (product.IsAuction)
                return new GeneralDto { message = "تا پایان مزایده امکان ویرایش کالا وجود ندارد!" };

            var result = new ProductDto
            {
                Id = productUpdateDto.Id,
                Name = productUpdateDto.Name,
                BasePrice = productUpdateDto.BasePrice,
                Availability = productUpdateDto.Availability,
                Description = productUpdateDto.Description,
                IsActive = product.IsActive, // استفاده از مقدار موجود در product
            };

            await _productRepository.UpdateAsync(result, productUpdateDto.CategoryIds); // ارسال لیست دسته‌بندی‌ها به متد UpdateAsync

            return new GeneralDto
            {
                message = "کالا با موفقیت ویرایش شد"
            };
        }


    }
}
