using Application.Dtos.ProductDto;
using Application.IServices.SellerServices.ProductServices.Commands;
using Domin.IRepositories.Dtos;
using Domin.IRepositories.IseparationRepository;

namespace Application.Services.SellerServices.ProductServices.Commands
{
    public class AddProductTooBoothSellerService : IAddProductTooBoothSellerService
    {
        private readonly IProductRepository _productRepository;
        private readonly ISellerRepository _sellerRepository;

        public AddProductTooBoothSellerService(IProductRepository productRepository,
            ISellerRepository sellerRepository)
        {
            _productRepository = productRepository;
            _sellerRepository = sellerRepository;
         
        }
        public async Task<string> Execute(ProductForAddDto productDto, int sellerId)
        {
            var seller = await _sellerRepository.GetByIdAsync(sellerId);
            if (seller==null)
            {
                return "فروشنده موجود نیست";
            }
            var booth = seller.Booth;
            if (booth==null)
            {
                return "غرفه موجود نیست";
            }

            var newProductDto = new ProductAddDto
            {
                Name = productDto.Name,
                BasePrice = productDto.BasePrice,
                Description = productDto.Description,
                Availability = productDto.Availability,
                BoothId = booth.Id,
                Booth = booth
            };

            _productRepository.AddAsync(newProductDto);
            return "کالااضافه شد";
        }
    }
}
